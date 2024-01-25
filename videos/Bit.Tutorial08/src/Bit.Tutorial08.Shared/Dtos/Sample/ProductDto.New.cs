namespace Bit.Tutorial08.Shared.Dtos.Sample;

[DtoResourceType(typeof(AppStrings))]
public class ProductDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = nameof(AppStrings.RequiredAttribute_ValidationError))]
    [MaxLength(64, ErrorMessage = nameof(AppStrings.MaxLengthAttribute_InvalidMaxLength))]
    [Display(Name = nameof(AppStrings.Name))]
    public string? Name { get; set; }

    [Required(ErrorMessage = nameof(AppStrings.RequiredAttribute_ValidationError))]
    [Range(0, double.MaxValue, ErrorMessage = nameof(AppStrings.RangeAttribute_ValidationError))]
    [Display(Name = nameof(AppStrings.Price))]
    public decimal Price { get; set; }

    [MaxLength(512, ErrorMessage = nameof(AppStrings.MaxLengthAttribute_InvalidMaxLength))]
    [Display(Name = nameof(AppStrings.Description))]
    public string? Description { get; set; }

    [Required(ErrorMessage = nameof(AppStrings.RequiredAttribute_ValidationError))]
    public int? CategoryId { get; set; }

    public string? CategoryName { get; set; }
}
