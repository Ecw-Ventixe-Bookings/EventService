using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class CategoryRepository(SqlServerDbContext context) : BaseRepository<CategoryEntity>(context), ICategoryRepository
{
    
}