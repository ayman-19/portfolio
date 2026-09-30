namespace Portfolio.Web.Dtos;

public class EducationDto
{
    public long Id { get; set; }
    public string Institution { get; set; } = default!;
    public string Degree { get; set; } = default!;      
    public string? FieldOfStudy { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }              
    public string? Grade { get; set; }                  
    public string? Description { get; set; }
}
