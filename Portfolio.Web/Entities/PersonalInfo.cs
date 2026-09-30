using Portfolio.Web.Entities.Base;

namespace Portfolio.Web.Entities;

public record PersonalInfo : Entity
{
    public string FullName { get; set; } = default!;
    public string JobTitle { get; set; } = default!;
    public string? Summary { get; set; }
    public string Email { get; set; } = default!;
    public string? Phone { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }
    public DateOnly? BirthDate { get; set; }
    public string? PhotoUrl { get; set; }
    public string? CvUrl { get; set; }
    public string? GitHubUrl { get; set; }
    public string? LinkedInUrl { get; set; }
}
