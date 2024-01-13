using Bit.Tutorial07.Shared.Dtos.Sample;

namespace Bit.Tutorial07.Server.Controllers.Sample;

// Constructor Injection

/*
[Route("api/[controller]/[action]")]
[ApiController]
public partial class ProductsController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public ProductsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ProductDto[]> Get()
    {
        return await _dbContext.Products
            .Project()
            .ToArrayAsync();
    }

    [HttpGet("{id}")]
    public async Task<ProductDto> Get(int id)
    {
        return await _dbContext.Products
            .Project()
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    [HttpPost]
    public async Task<ProductDto> Create(ProductDto dto)
    {
        var entityToAdd = dto.Map();

        await _dbContext.Products.AddAsync(entityToAdd);

        await _dbContext.SaveChangesAsync();

        return entityToAdd.Map();
    }

    [HttpPut]
    public async Task<ProductDto> Update(ProductDto dto)
    {
        var entityToUpdate = await _dbContext.Products.FirstOrDefaultAsync(t => t.Id == dto.Id);

        dto.Patch(entityToUpdate);

        await _dbContext.SaveChangesAsync();

        return entityToUpdate.Map();
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        _dbContext.Products.Remove(new() { Id = id });

        await _dbContext.SaveChangesAsync();
    }
}
*/

// C# 12 primary contructor

/*
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
*/

// Bit Source Generators AutoInject attribute

/*
[Route("api/[controller]/[action]")]
[ApiController]
public partial class ProductsController : ControllerBase
{
    [AutoInject] private readonly AppDbContext dbContext;

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
*/

// Bit Source Generators AutoInject attribute with Inheritance

/*
[Route("api/[controller]/[action]")]
[ApiController]
public partial class ProductsController : AppControllerBase
{
    [HttpGet]
    public async Task<ProductDto[]> Get()
    {
        return await DbContext.Products
            .Project()
            .ToArrayAsync();
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
*/
