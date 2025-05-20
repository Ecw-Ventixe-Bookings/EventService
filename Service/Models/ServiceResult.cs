namespace Service.Models;

public class ServiceResult
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
}

public class ServiceResult<TModel> : ServiceResult where TModel : class
{
    public TModel Data { get; set; }
}