using sni;

namespace FeTracker.Sni.Services;

public class DeviceService
{
    public static async Task<DevicesResponse> GetDevicesListAsync(int port = 8190, string host = "localhost", bool useHttpHandler = true)
    {
        var channel = GrpcChannelService.GetChannel(port, host, useHttpHandler);
        var devicesClient = new Devices.DevicesClient(channel);

        return await devicesClient.ListDevicesAsync(new DevicesRequest());
    }
}