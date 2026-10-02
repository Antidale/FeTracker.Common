using System.IO.Compression;
using System.Text;
using System.Text.Json;
using FeTracker.Sni.Constants;
using FeTracker.Sni.Extensions;
using FeTracker.Sni.Models;
using Grpc.Net.Client;
using static sni.DeviceMemory;

namespace FeTracker.Sni.Classes;

public class MetadataHelper
{
    public static async Task<Response<SeedDetail>> GetSeedDetails(GrpcChannel channel, string uri)
    {
        try
        {
            var memoryClient = new DeviceMemoryClient(channel);
            return await GetMetadataDocLength(memoryClient, uri)
                            .BindAsync(docLength =>
                                GetMetadataDocument(memoryClient, uri, docLength))
                            .BindAsync(metadata =>
                                ParseMetadataInforamation(memoryClient, uri, metadata));
        }
        catch (Exception ex)
        {
            //As we find causes of why things hit this, we can start using more specific handling
            Console.WriteLine(ex.Message);
            return Response<SeedDetail>.SetError("Error while trying to get metadata. Make sure you have an FE rom loaded.");
        }
    }

    private static async Task<Response<uint>> GetMetadataDocLength(DeviceMemoryClient client, string uri)
    {
        var response = await client.ReadByMemoryAddressAsync(AddressData.Metadata, uri);

        if (response.Data is null || !response.Success)
        {
            return Response<uint>.SetError(response.ErrorMessage);
        }

        try
        {
            var jsonDocLength = BitConverter.ToUInt32([.. response.Data.Response.Data], 0);
            if (jsonDocLength == 0)
            {
                return Response<uint>.SetError("Unexpected metadata document length of 0 returned");
            }

            return Response.SetSuccess(jsonDocLength);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Response<uint>.SetError("Unable to get metadata length. Are you sure you have an FE seed loaded?");
        }
    }

    private static async Task<Response<SeedMetadata>> GetMetadataDocument(DeviceMemoryClient client, string uri, uint docLength)
    {
        var docString = await client.ReadByMemoryAddressAsync(AddressData.JsonDocument, uri, docLength);

        if (!docString.Success || docString.Data is null)
        {
            return Response<SeedMetadata>.SetError("Unable to read metadata document. Are you sure you have an FE seed loaded?");
        }

        var stuff = docString.Data.Response.Data.ToStringUtf8();
        var metadata = JsonSerializer.Deserialize<SeedMetadata>(docString.Data.Response.Data.ToStringUtf8());

        if (metadata is null) { return Response<SeedMetadata>.SetError("Unable to parse metadata document. Are you sure you have an FE seed loaded?"); }

        return Response.SetSuccess(metadata);
    }

    private static async Task<Response<SeedDetail>> ParseMetadataInforamation(DeviceMemoryClient client, string uri, SeedMetadata metadata)
    {
        return (metadata.Version.Split(".").First(), metadata.MetadataAddr) switch
        {
            (_, > 0) => await ParseCompressedData(client, uri, metadata),
            ("v5", _) => ParseV5Data(metadata),
            ("v4", _) => ParseV4Data(metadata),
            (_, _) => Response.SetSuccess(new SeedDetail { Flags = metadata.Flags })
        };
    }

    private static async Task<Response<SeedDetail>> ParseCompressedData(DeviceMemoryClient client, string uri, SeedMetadata metadata)
    {
        var response = await client.ReadByMemoryAddressAsync(metadata.MetadataAddr, metadata.MetadataLen, uri);
        var junk = GetUncompressedPayload([.. response.Data.Response.Data]);
        var paylod = Encoding.UTF8.GetString(junk);
        var decompressedMetadata = JsonSerializer.Deserialize<SeedMetadata>(paylod) ?? new();
        metadata.Flags = decompressedMetadata.Flags;
        metadata.Objectives = decompressedMetadata.Objectives;
        return ParseV5Data(metadata);
    }

    private static Response<SeedDetail> ParseV5Data(SeedMetadata metadata)
    {
        try
        {
            metadata.Objectives ??= string.Empty;
            var groups = JsonSerializer.Deserialize<List<ObjectiveGroup>>(metadata.Objectives) ?? [];
            foreach (var group in groups)
            {
                foreach (var task in group.Tasks)
                {
                    if (ObjectiveDictionary.TryGetObjectiveText(task.Objective, task.Threshold, out var returnValue))
                    {
                        task.Objective = returnValue;
                    }
                }
            }

            return Response.SetSuccess(metadata.ToSeedDetail().WithObjectiveGroups(groups));

        }
        catch (Exception ex)
        {
            return Response<SeedDetail>.SetError(ex.Message);
        }
    }

    private static Response<SeedDetail> ParseV4Data(SeedMetadata metadata)
    {
        try
        {
            var objectives = new List<string>();
            if (metadata.Flags.StartsWith("Onone"))
            {
                objectives = ["Find Crystal"];
            }
            else
            {
                objectives = JsonSerializer.Deserialize<List<string>>(metadata.Objectives) ?? objectives;
            }

            return Response.SetSuccess(metadata.ToSeedDetail().WithObjectives(objectives));
        }
        catch (Exception ex)
        {
            return Response<SeedDetail>.SetError(ex.Message);
        }
    }

    private static byte[] GetUncompressedPayload(byte[] data)
    {
        using var outputStream = new MemoryStream();
        using var inputStream = new MemoryStream(data);
        using var zipInputStream = new ZipArchive(inputStream, ZipArchiveMode.Read);
        using var entryStream = zipInputStream.Entries[0].Open();
        entryStream.CopyTo(outputStream);

        return outputStream.ToArray();
    }
}
