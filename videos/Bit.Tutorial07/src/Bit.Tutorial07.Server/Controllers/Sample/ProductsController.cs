using Bit.Tutorial07.Shared.Dtos.Sample;

namespace Bit.Tutorial07.Server.Controllers.Sample;

[Route("api/[controller]/[action]")]
[ApiController]
public partial class ProductsController : AppControllerBase
{
    [HttpGet]
    public IQueryable<ProductDto> Get()
    {
        return DbContext.Products
            .Project();
    }

    [HttpGet("{id}")]
    public async Task<ProductDto> Get(int id)
    {
        return await DbContext.Products
            .Project()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    [HttpPost]
    public async Task<ProductDto> Create(ProductDto dto)
    {
        var entityToAdd = dto.Map();

        await DbContext.Products.AddAsync(entityToAdd);

        await DbContext.SaveChangesAsync();

        return entityToAdd.Map();
    }

    [HttpPut]
    public async Task<ProductDto> Update(ProductDto dto)
    {
        var entityToUpdate = await DbContext.Products.FirstOrDefaultAsync(t => t.Id == dto.Id);

        dto.Patch(entityToUpdate);

        await DbContext.SaveChangesAsync();

        return entityToUpdate.Map();
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        DbContext.Products.Remove(new() { Id = id });

        await DbContext.SaveChangesAsync();
    }
}

