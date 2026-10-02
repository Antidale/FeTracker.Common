using System.Collections;
using FeTracker.Common.Enums;
using FeTracker.Common.Icons;
using FeTracker.Sni.Constants;
using FeTracker.Sni.Extensions;
using FeTracker.Sni.Models;
using Grpc.Net.Client;
using static sni.DeviceMemory;

namespace FeTracker.Sni.Classes;

public static class KeyItemHelper
{
    public static async Task<List<KeyItemIcon>> GetKeyItemsAsync(GrpcChannel channel, string uri, bool includePass = true)
    {
        var client = new DeviceMemoryClient(channel);
        var notFound = Enum.GetValues<KeyItem>().Select(x => new KeyItemIcon(x)).ToList();
        var found = await GetKiStateAsync(client, uri, AddressData.FOUND_KEY_ITEMS, IconState.Color, includePass);
        var used = await GetKiStateAsync(client, uri, AddressData.USED_KEY_ITEMS, IconState.Check, includePass);
        List<KeyItemIcon> returnList = [.. used];

        foreach (var item in found)
        {
            if (!returnList.Select(x => x.Icon).Contains(item.Icon))
                returnList.Add(item);
        }

        foreach (var item in notFound)
        {
            if (!returnList.Select(x => x.Icon).Contains(item.Icon))
                returnList.Add(item);
        }

        return returnList;
    }


    private static async Task<List<KeyItemIcon>> GetKiStateAsync(DeviceMemoryClient client, string uri, MemoryAddress address, IconState assignedState, bool includePass)
    {
        var response = await client.ReadByMemoryAddressAsync(address, uri);
        var kiBits = new BitArray(response.Data.Response.Data.ToByteArray());
        var kiCount = includePass ? 18 : 17;
        var keyItems = new List<KeyItemIcon>();

        for (var i = 0; i < kiCount; i++)
        {
            if (Enum.IsDefined(typeof(KeyItem), i) && kiBits[i])
                keyItems.Add(new((KeyItem)i, assignedState));
        }

        return keyItems;
    }
}
