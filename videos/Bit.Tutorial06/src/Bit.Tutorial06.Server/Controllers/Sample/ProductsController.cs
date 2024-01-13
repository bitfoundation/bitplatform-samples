using Bit.Tutorial06.Shared.Dtos.Sample;

namespace Bit.Tutorial06.Server.Controllers.Sample;

[Route("api/[controller]/[action]")]
[ApiController]
public partial class ProductsController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ProductDto[]> Get()
    {
        return await dbContext.Products
            .Project()
            .ToArrayAsync();
    }

    [HttpGet("{id}")]
    public async Task<ProductDto> Get(int id)
    {
        return await dbContext.Products
            .Project()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    [HttpPost]
    public async Task<ProductDto> Create(ProductDto dto)
    {
        var entityToAdd = dto.Map();

        await dbContext.Products.AddAsync(entityToAdd);

        await dbContext.SaveChangesAsync();

        return entityToAdd.Map();
    }

    [HttpPut]
    public async Task<ProductDto> Update(ProductDto dto)
    {
        var entityToUpdate = await dbContext.Products.FirstOrDefaultAsync(t => t.Id == dto.Id);

        dto.Patch(entityToUpdate);

        await dbContext.SaveChangesAsync();

        return entityToUpdate.Map();
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        dbContext.Products.Remove(new() { Id = id });

        await dbContext.SaveChangesAsync();
    }
}
