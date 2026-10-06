using System.Collections;
using FeTracker.Common.Enums;
using FeTracker.Sni.Constants;
using FeTracker.Sni.Extensions;
using FeTracker.Sni.Models;
using Grpc.Net.Client;
using static sni.DeviceMemory;

namespace FeTracker.Sni.Classes;

public static class KeyItemReader
{
    public static async Task<Dictionary<KeyItem, IconState>> GetKeyItemStatusAsync(GrpcChannel channel, string uri, bool includePass = true)
    {
        var client = new DeviceMemoryClient(channel);
        var notFound = Enum.GetValues<KeyItem>().Select(x => x).ToList();
        var found = await GetKiByAddressAsync(client, uri, AddressData.FOUND_KEY_ITEMS, includePass);
        var used = await GetKiByAddressAsync(client, uri, AddressData.USED_KEY_ITEMS, includePass);
        Dictionary<KeyItem, IconState> returnObject = [];

        used.ForEach(ki => returnObject.TryAdd(ki, IconState.Check));
        found.ForEach(ki => returnObject.TryAdd(ki, IconState.Color));
        notFound.ForEach(ki => returnObject.TryAdd(ki, IconState.Gray));
        return returnObject;
    }


    private static async Task<List<KeyItem>> GetKiByAddressAsync(DeviceMemoryClient client, string uri, MemoryAddress address, bool includePass)
    {
        var response = await client.ReadByMemoryAddressAsync(address, uri);
        var kiBits = new BitArray(response.Data.Response.Data.ToByteArray());
        //When pass is a Ki in 5.0, it is KI 18. We're not going to concern ourselves with handling pre v0.3 (released on Dec 24 2018) seeds and times when the Pass then could or could not be a KI
        var kiCount = includePass ? 18 : 17;
        var keyItems = new List<KeyItem>();

        for (var i = 0; i < kiCount; i++)
        {
            if (Enum.IsDefined(typeof(KeyItem), i) && kiBits[i])
                keyItems.Add((KeyItem)i);
        }

        return keyItems;
    }
}
