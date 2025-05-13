using Microsoft.EntityFrameworkCore;

namespace WebApi.Data;

public class AppDataContext(DbContextOptions<AppDataContext> options) : DbContext(options)
{
}
