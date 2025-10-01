using System.Net;

namespace Project.Domain.Responses;

public record Response<T>
(
    T? Data,
    string Message,
    bool Status,
    HttpStatusCode StatusCode
)
{

    public static Response<PaginatedResult<U>> GetData<U>(IEnumerable<U> data, int pageNumber, int pageSize, int totalRecords)
    {
        var pagedData = new PaginatedResult<U>
        (
            data,
            pageNumber,
            pageSize,
            totalRecords,
            (int)Math.Ceiling((double)totalRecords / pageSize)
        );

        return new Response<PaginatedResult<U>>(pagedData, "Data retrieved successfully", true, HttpStatusCode.OK);
    }
    
    public static Response<T> Success(T? data = default)
    {
        return new Response<T>(data, "Request was successful", true, HttpStatusCode.OK);
    }
    
    public static Response<T> Failure(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        return new Response<T>(default!, message, false, statusCode);
    }
    
    public static Response<T> NotFound(string message)
    {
        return new Response<T>(default!, message, false, HttpStatusCode.NotFound);
    }
    
    public static Response<T> Created(T data)
    {
        return new Response<T>(data, "Resource created successfully", true, HttpStatusCode.Created);
    }
    
    public static Response<T> Unauthorized(string message)
    {
        return new Response<T>(default!, message, false, HttpStatusCode.Unauthorized);
    }
}