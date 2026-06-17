namespace MyAspNetProject.Ports;

public class AppException(string message, int status, string field) : Exception(message)
{
    public int Status { get; set; }
    public string? Field { get; set; }
}



public class Result
{
    private List<AppException> _exceptions;

    public static void Err(List<AppException> exceptions)
    {
        
    }
}