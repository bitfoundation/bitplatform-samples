using Bit.Tutorial08.Shared.Dtos.Sample;

namespace Bit.Tutorial08.Server.Controllers.Sample;

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

        if (entityToUpdate is null)
            throw new ResourceNotFoundException(nameof(AppStrings.ProductCouldNotBeFound));

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

    [HttpGet]
    public async Task<int> SampleOfCostlyOperation(CancellationToken cancellationToken)
    {
        // Count the number of products that are unique to their category.

        return await DbContext
            .Products
            .Where(p => p.Category!.Products.Count() == 1)
            .CountAsync(cancellationToken);
    }

    [HttpGet]
    public async Task<PagedResult<ProductDto>> GetProducts(ODataQueryOptions<ProductDto> odataQuery, CancellationToken cancellationToken)
    {
        // Let's apply $filter (where), $orderby etc, except $top and $skip because we need to calculate the total count first.
        var query = (IQueryable<ProductDto>)odataQuery.ApplyTo(Get(), ignoreQueryOptions: AllowedQueryOptions.Top | AllowedQueryOptions.Skip);

        var totalCount = await query.LongCountAsync(cancellationToken);

        // Apply paging (if any)
        if (odataQuery.Skip is not null)
            query = query.Skip(odataQuery.Skip.Value);
        if (odataQuery.Top is not null)
            query = query.Take(odataQuery.Top.Value);

        // We must provide the outcome along with the overall count simultaneously.
        return new PagedResult<ProductDto>(await query.ToArrayAsync(cancellationToken), totalCount);
    }
}

