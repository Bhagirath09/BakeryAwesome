namespace BakeryAwesome.Model;
public class BakeryAwesomeResponse
{           
    public DateTimeOffset CreatedAt { get; set; }
    public string? CakeName { get; set; }
    public string? Price { get; set; }
    public string? ClientEmail { get; set; }
    public string? Id { get; set; }
}