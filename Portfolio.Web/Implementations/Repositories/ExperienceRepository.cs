using Portfolio.Web.Context;
using Portfolio.Web.Entities;
using Portfolio.Web.Implementations.Repositories.Base;
using Portfolio.Web.Interfaces.Repositories;

namespace Portfolio.Web.Implementations.Repositories;

public class ExperienceRepository(PortfolioDbContext context)
    : Repository<Experience>(context),
        IExperienceRepository { }
