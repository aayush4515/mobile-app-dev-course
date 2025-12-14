using SQLite;

namespace Cars_Acharya.Models;

public class Car
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [Indexed]
    public string Make { get; set; } = string.Empty;

    public string Model { get; set; } = string.Empty;

    public int Year { get; set; }

    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    public string DisplayName => $"{Year} {Make} {Model}";
}
