using Bit.Tutorial07.Shared.Dtos.Sample;

namespace Bit.Tutorial07.Server.Controllers.Sample;

[Route("api/[controller]/[action]")]
[ApiController]
public partial class CategoryController : AppControllerBase
{
    [HttpGet]
    public IQueryable<CategoryDto> Get()
    {
        return DbContext.Categories
            .Project();
    }

    [HttpGet, EnableQuery]
    public IQueryable<CategoryDto> GetNonEmptyCategories()
    {
        return DbContext
            .Categories
            .Where(c => c.Products.Any())
            .Project();
    }

    [HttpGet("{id}")]
    public async Task<CategoryDto> Get(int id)
    {
        return await DbContext.Categories
            .Project()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    [HttpPost]
    public async Task<CategoryDto> Create(CategoryDto dto)
    {
        var entityToAdd = dto.Map();

        await DbContext.Categories.AddAsync(entityToAdd);

        await DbContext.SaveChangesAsync();

        return entityToAdd.Map();
    }

    [HttpPut]
    public async Task<CategoryDto> Update(CategoryDto dto)
    {
        var entityToUpdate = await DbContext.Categories.FirstOrDefaultAsync(t => t.Id == dto.Id);

        dto.Patch(entityToUpdate);

        await DbContext.SaveChangesAsync();

        return entityToUpdate.Map();

        /*
        var entityToUpdate = dto.Map();
          
        DbContext.Update(entityToUpdate);

        await DbContext.SaveChangesAsync();
        
        return entityToUpdate.Map();
        */
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        DbContext.Categories.Remove(new() { Id = id });

        await DbContext.SaveChangesAsync();
    }
}
