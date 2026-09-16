using Grpc.Core;

namespace FeTracker.Sni.Classes;

internal static class RetryHelper
{
    /// <summary>
    /// A method specifically for calls to SNI to retry with a built-in backoff mechanism.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="task"></param>
    /// <param name="retryCount"></param>
    /// <param name="backoffMultiplier"></param>
    /// <returns></returns>
    internal static async Task<Response<T>> Retry<T>(Func<AsyncUnaryCall<T>> task, int retryCount = 10, int backoffMultiplier = 10)
    {
        for (var attempt = 0; attempt <= retryCount; attempt++)
        {
            try
            {
                var result = await task();
                return Response<T>.SetSuccess(result);
            }
            catch when (attempt < retryCount)
            {
                Thread.Sleep(20 + backoffMultiplier * attempt);
            }
            catch (Exception ex)
            {
                return Response<T>.SetError(ex.Message);
            }
        }

        return Response<T>.SetError("Unknown Error");
    }
}
