using Bit.Tutorial06.Server.Models.Sample;
using Bit.Tutorial06.Shared.Dtos.Sample;
using Riok.Mapperly.Abstractions;

namespace Bit.Tutorial06.Server.Mappers;

[Mapper(UseDeepCloning = true)]
public static partial class CategoriesMapper
{
    public static partial IQueryable<CategoryDto> Project(this IQueryable<Category> query);

    [MapProperty(nameof(@Category.Products.Count), nameof(@CategoryDto.ProductsCount))]
    public static partial CategoryDto Map(this Category source);
    public static partial Category Map(this CategoryDto source);
    public static partial void Patch(this CategoryDto source, Category destination);
    public static partial void Patch(this Category source, CategoryDto destination);
}
