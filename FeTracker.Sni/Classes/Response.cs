namespace FeTracker.Sni.Classes;

// <summary>
/// <para>A class to encapsulate the status of an operation. Use when there are multiple possible failure modes that should be reported to the caller</para>
/// <para>Should not be returned by a controller.</para>
/// </summary>
/// <typeparam name="T"></typeparam>
public class Response<T>
{
    public T? Data { get; private set; }
    public string ErrorMessage { get; private set; } = string.Empty;
    public bool Success { get; private set; } = false;


    /// <summary>
    /// Basic constructor for the Response object.
    /// </summary>
    /// <param name="responseObject"></param>
    /// <param name="errorMessage"></param>
    /// <param name="success"></param>
    /// <param name="errorStatusCode">Should be not null when using this constructor for an error</param>
    public Response(T? responseObject, string errorMessage = "", bool success = false)
    {
        Data = responseObject;
        ErrorMessage = errorMessage;
        Success = success;
    }

    public Response() { }

    public static Response<T> SetSuccess(T responseObject)
    {
        return new Response<T>
        {
            Data = responseObject,
            Success = true,
            ErrorMessage = string.Empty
        };
    }

    public static Response<T> SetError(string errorMessage)
    {
        return new Response<T>
        {
            ErrorMessage = errorMessage,
            Success = false,
            Data = default
        };
    }
}
