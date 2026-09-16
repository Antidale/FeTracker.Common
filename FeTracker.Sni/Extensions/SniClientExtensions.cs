using FeTracker.Sni.Classes;
using FeTracker.Sni.Models;
using sni;
using static sni.DeviceInfo;
using static sni.DeviceMemory;

namespace FeTracker.Sni.Extensions;

public static class SniClientExtensions
{
    extension(DeviceMemoryClient client)
    {
        public async Task<Response<SingleReadMemoryResponse>> ReadByMemoryAddressAsync(MemoryAddress address, string uri, uint size = 0)
        {
            var readMemoryRequest = new SingleReadMemoryRequest
            {
                Request = new ReadMemoryRequest
                {
                    RequestAddress = address.Address,
                    RequestAddressSpace = AddressSpace.FxPakPro,
                    RequestMemoryMapping = MemoryMapping.Unknown,
                    Size = size > 0 ? size : address.Size
                },
                Uri = uri,
            };

            return await RetryHelper.Retry(() => client.SingleReadAsync(readMemoryRequest));
        }
    }

    extension(DeviceInfoClient client)
    {
        public async Task<Response<FieldsResponse>> FetchFieldsRetryAsync(string uri, params Field[] fields)
        {
            var request = new FieldsRequest
            {
                Uri = uri,
                Fields = { fields }
            };

            return await RetryHelper.Retry(() => client.FetchFieldsAsync(request));
        }
    }
}
