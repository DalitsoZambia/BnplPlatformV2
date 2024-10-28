namespace BnplV2.Utils.Defaults;

public class DefaultResponse<T> where T : class
{
    public required int StatusCode { get; set; }
    public required string Message { get; set; }
    public List<string>? Errors { get; set; }
    public T? Data { get; set; }
}
