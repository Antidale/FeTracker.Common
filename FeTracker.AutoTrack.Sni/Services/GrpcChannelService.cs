using Grpc.Net.Client.Web;
using Grpc.Net.Client;

namespace FeTracker.AutoTrack.Sni.Services
{
    public static class GrpcChannelService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="port">Defaults to 8190. Use 8191 for a desktop application, or send a different port if you expect SNI to be listening on a different port</param>
        /// <param name="useHttpHandler">Defaults to true. Use false for a desktop application</param>
        /// <returns></returns>
        public static GrpcChannel? GetGrpcChannel(int port = 8190, bool useHttpHandler = true) => useHttpHandler 
            ? GrpcChannel.ForAddress($"http://localhost:{port}", new GrpcChannelOptions { HttpHandler = new GrpcWebHandler(new HttpClientHandler()) })
            : GrpcChannel.ForAddress($"http://localhost:{port}");
    }
}
