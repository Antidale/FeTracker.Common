namespace FeTracker.Sni.Classes;

// <summary>
/// <para>A class to encapsulate the status of an operation. Use when there are multiple possible failure modes that should be reported to the caller</para>
/// <para>Should not be returned by a controller.</para>
/// </summary>
/// <typeparam name="T"></typeparam>
public class Response<T>
{
    private T? data;
    public T Data { get => Success && data is not null ? data! : throw new InvalidOperationException(); }
    public string ErrorMessage { get; private set; } = string.Empty;
    public bool Success { get; private set; } = false;


    private Response() { }

    public static Response<T> SetSuccess(T responseObject)
    {
        return new Response<T>
        {
            data = responseObject,
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
        };
    }
}

public class Response
{
    public static Response<T> SetSuccess<T>(T data) => Response<T>.SetSuccess(data);
}
