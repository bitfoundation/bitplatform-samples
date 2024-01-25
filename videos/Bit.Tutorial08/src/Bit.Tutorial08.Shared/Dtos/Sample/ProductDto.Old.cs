namespace Bit.Tutorial08.Shared.Dtos.Sample;

public class ProductDto_Old_Way
{
    public int Id { get; set; }

    [Required(ErrorMessageResourceName = nameof(AppStrings.RequiredAttribute_ValidationError), ErrorMessageResourceType = typeof(AppStrings))]
    [MaxLength(64, ErrorMessageResourceName = nameof(AppStrings.MaxLengthAttribute_InvalidMaxLength), ErrorMessageResourceType = typeof(AppStrings))]
    [Display(Name = nameof(AppStrings.Name))]
    public string? Name { get; set; }

    [Required(ErrorMessageResourceName = nameof(AppStrings.RequiredAttribute_ValidationError), ErrorMessageResourceType = typeof(AppStrings))]
    [Range(0, double.MaxValue, ErrorMessageResourceName = nameof(AppStrings.RangeAttribute_ValidationError), ErrorMessageResourceType = typeof(AppStrings))]
    [Display(Name = nameof(AppStrings.Price))]
    public decimal Price { get; set; }

    [MaxLength(512, ErrorMessageResourceName = nameof(AppStrings.MaxLengthAttribute_InvalidMaxLength), ErrorMessageResourceType = typeof(AppStrings))]
    [Display(Name = nameof(AppStrings.Description))]
    public string? Description { get; set; }

    [Required(ErrorMessageResourceName = nameof(AppStrings.RequiredAttribute_ValidationError), ErrorMessageResourceType = typeof(AppStrings))]
    public int? CategoryId { get; set; }

    public string? CategoryName { get; set; }
}
