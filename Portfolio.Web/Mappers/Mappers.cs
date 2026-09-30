using Portfolio.Web.Dtos;
using Portfolio.Web.Entities;

namespace Portfolio.Web.Mappers;

public static class MapperExtensions
{
    public static PersonalInfoDto ToDto(this PersonalInfo entity) => new()
    {
        Id = entity.Id,
        FullName = entity.FullName,
        JobTitle = entity.JobTitle,
        Summary = entity.Summary,
        Email = entity.Email,
        Phone = entity.Phone,
        Country = entity.Country,
        City = entity.City,
        Address = entity.Address,
        BirthDate = entity.BirthDate,
        PhotoUrl = entity.PhotoUrl,
        CvUrl = entity.CvUrl,
        GitHubUrl = entity.GitHubUrl,
        LinkedInUrl = entity.LinkedInUrl
    };

    public static PersonalInfo ToEntity(this PersonalInfoDto dto) => new()
    {
        Id = dto.Id,
        FullName = dto.FullName,
        JobTitle = dto.JobTitle,
        Summary = dto.Summary,
        Email = dto.Email,
        Phone = dto.Phone,
        Country = dto.Country,
        City = dto.City,
        Address = dto.Address,
        BirthDate = dto.BirthDate,
        PhotoUrl = dto.PhotoUrl,
        CvUrl = dto.CvUrl,
        GitHubUrl = dto.GitHubUrl,
        LinkedInUrl = dto.LinkedInUrl
    };

    public static EducationDto ToDto(this Education entity) => new()
    {
        Id = entity.Id,
        Institution = entity.Institution,
        Degree = entity.Degree,
        FieldOfStudy = entity.FieldOfStudy,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        Grade = entity.Grade,
        Description = entity.Description
    };

    public static Education ToEntity(this EducationDto dto) => new()
    {
        Id = dto.Id,
        Institution = dto.Institution,
        Degree = dto.Degree,
        FieldOfStudy = dto.FieldOfStudy,
        StartDate = dto.StartDate,
        EndDate = dto.EndDate,
        Grade = dto.Grade,
        Description = dto.Description
    };

    public static ExperienceDto ToDto(this Experience entity) => new()
    {
        Id = entity.Id,
        CompanyName = entity.CompanyName,
        Position = entity.Position,
        Address = entity.Address,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        Highlights = entity.Highlights
    };

    public static Experience ToEntity(this ExperienceDto dto) => new()
    {
        Id = dto.Id,
        CompanyName = dto.CompanyName,
        Position = dto.Position,
        Address = dto.Address,
        StartDate = dto.StartDate,
        EndDate = dto.EndDate,
        Highlights = dto.Highlights
    };

    public static SkillDto ToDto(this Skill entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Level = entity.Level,
        Category = entity.Category
    };

    public static Skill ToEntity(this SkillDto dto) => new()
    {
        Id = dto.Id,
        Name = dto.Name,
        Level = dto.Level,
        Category = dto.Category
    };
}
