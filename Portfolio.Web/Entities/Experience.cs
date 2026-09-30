using Portfolio.Web.Entities.Base;

namespace Portfolio.Web.Entities;

public record Experience : Entity
{
    public string CompanyName { get; set; } = default!;
    public string Position { get; set; } = default!;
    public string? Address { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public List<string> Highlights { get; set; } = new();
}
