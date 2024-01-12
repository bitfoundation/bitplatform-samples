using Bit.Tutorial06.Server.Models.Sample;
using Bit.Tutorial06.Shared.Dtos.Sample;
using Riok.Mapperly.Abstractions;

namespace Bit.Tutorial06.Server.Mappers;

[Mapper(UseDeepCloning = true)]
public static partial class ProductsMapper
{
    public static partial IQueryable<ProductDto> Project(this IQueryable<Product> query);
    public static partial ProductDto Map(this Product source);
    public static partial Product Map(this ProductDto source);
    public static partial void Patch(this ProductDto source, Product destination);

    [MapperIgnoreSource(nameof(Product.Category))]
    public static partial void Patch(this Product source, ProductDto destination);
}
