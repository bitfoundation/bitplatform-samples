using Bit.Tutorial06.Shared.Dtos.Sample;

namespace Bit.Tutorial06.Server.Controllers.Sample;

[Route("api/[controller]/[action]")]
[ApiController]
public partial class CategoryController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<CategoryDto[]> Get()
    {
        return await dbContext.Categories
            .Project()
            .ToArrayAsync();

        return await dbContext.Categories
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Color = c.Color,
                ProductsCount = c.Products.Count
            })
            .ToArrayAsync();
    }

    [HttpGet("{id}")]
    public async Task<CategoryDto> Get(int id)
    {
        return await dbContext.Categories
            .Project()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    [HttpPost]
    public async Task<CategoryDto> Create(CategoryDto dto)
    {
        var entityToAdd = dto.Map();

        await dbContext.Categories.AddAsync(entityToAdd);

        await dbContext.SaveChangesAsync();

        return entityToAdd.Map();
    }

    [HttpPut]
    public async Task<CategoryDto> Update(CategoryDto dto)
    {
        var entityToUpdate = await dbContext.Categories.FirstOrDefaultAsync(t => t.Id == dto.Id);

        dto.Patch(entityToUpdate);

        await dbContext.SaveChangesAsync();

        return entityToUpdate.Map();

        /*
        var entityToUpdate = dto.Map();
          
        dbContext.Update(entityToUpdate);

        await dbContext.SaveChangesAsync();
        
        return entityToUpdate.Map();
        */
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        dbContext.Categories.Remove(new() { Id = id });

        await dbContext.SaveChangesAsync();
    }
}
