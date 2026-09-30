using Portfolio.Web.Entities.Base;

namespace Portfolio.Web.Entities;

public record Education : Entity
{
    public string Institution { get; set; } = default!;
    public string Degree { get; set; } = default!;
    public string? FieldOfStudy { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public string? Grade { get; set; }
    public string? Description { get; set; }
}
