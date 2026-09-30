using Portfolio.Web.Entities.Base;

namespace Portfolio.Web.Entities;

public record Skill : Entity
{
    public string Name { get; set; }
    public int Level { get; set; }
    public string? Category { get; set; }
}
