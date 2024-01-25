namespace Bit.Tutorial08.Server.Models.Sample;

public class Category
{
    public int Id { get; set; }

    [Required, MaxLength(64)]
    public string? Name { get; set; }

    public string? Color { get; set; }

    public IList<Product> Products { get; set; } = [];
}
