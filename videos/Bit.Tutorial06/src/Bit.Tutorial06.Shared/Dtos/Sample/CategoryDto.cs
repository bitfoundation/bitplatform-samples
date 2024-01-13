namespace Bit.Tutorial06.Shared.Dtos.Sample;

public class CategoryDto
{
    public int Id { get; set; }

    [Required]
    [MaxLength(64)]
    public string? Name { get; set; }

    [Display]
    public string? Color { get; set; } = "#FFFFFF";

    public int ProductsCount { get; set; }
}
