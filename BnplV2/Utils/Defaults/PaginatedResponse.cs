namespace BnplV2.Utils.Defaults;

public class PaginatedResponse<T> where T : class
{
    public int PageSize { get; set; } 
    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
    public required int StatusCode { get; set; }
    public required string Message { get; set; }
    public List<string>? Errors { get; set; }
    public List<T>? Data { get; set; }
}


public class PaginationFilter
{
    public int PageSize { get; set; } 
    public int PageNumber { get; set; }
}