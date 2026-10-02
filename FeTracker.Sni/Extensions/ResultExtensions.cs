using FeTracker.Sni.Classes;

namespace FeTracker.Sni.Extensions;

public static class ResponseExtensions
{
    extension<T>(Response<T> response)
    {
        public Response<TOut> Map<TOut>(Func<T, TOut> mapMethod) => response.Success
            ? Response<TOut>.SetSuccess(mapMethod(response.Data))
            : Response<TOut>.SetError(response.ErrorMessage);

        public async Task<Response<TOut>> MapAsync<TOut>(Func<T, Task<TOut>> mapAsync) =>
            response.Success
            ? Response<TOut>.SetSuccess(await mapAsync(response.Data))
            : Response<TOut>.SetError(response.ErrorMessage);

        public Response<TOut> Bind<TOut>(Func<T, Response<TOut>> bind) => response.Success
            ? bind(response.Data)
            : Response<TOut>.SetError(response.ErrorMessage);

        public async Task<Response<TOut>> BindAsync<TOut>(Func<T, Task<Response<TOut>>> bindAsync) =>
            response.Success
            ? await bindAsync(response.Data)
            : Response<TOut>.SetError(response.ErrorMessage);
    }

    extension<T>(Task<Response<T>> asyncResponse)
    {
        public async Task<Response<TOut>> MapAsync<TOut>(Func<T, TOut> map) => (await asyncResponse).Map(map);

        public async Task<Response<TOut>> MapAsync<TOut>(Func<T, Task<TOut>> mapAsync) => await (await asyncResponse).MapAsync(mapAsync);

        public async Task<Response<TOut>> BindAsync<TOut>(Func<T, Response<TOut>> bind) => (await asyncResponse).Bind(bind);

        public async Task<Response<TOut>> BindAsync<TOut>(Func<T, Task<Response<TOut>>> bindAsync) =>
            await (await asyncResponse).BindAsync(bindAsync);
    }
}
