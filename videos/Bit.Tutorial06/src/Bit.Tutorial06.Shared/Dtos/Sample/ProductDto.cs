namespace Bit.Tutorial06.Shared.Dtos.Sample;

public class ProductDto
{
    public int Id { get; set; }

    [Required]
    [MaxLength(64)]
    public string? Name { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [MaxLength(512)]
    public string? Description { get; set; }

    [Required]
    public int? CategoryId { get; set; }

    public string? CategoryName { get; set; }
}
