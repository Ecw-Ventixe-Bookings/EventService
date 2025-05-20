namespace Data.Models;

public class RepositoryResult
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
}

public class RepositoryResult<TEntity> where TEntity : class
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
    public TEntity? Data { get; set; }
}