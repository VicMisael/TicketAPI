namespace RestAPI.Common;

public class ApiError(string message, string detail = null)
{
    public string Message { get; set; } = message;
    public string Detail { get; set; } = detail;
}
