using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Infrastructure.Repositories
{
    public class ProjectRepository : RepositoryBase<Project, long>, IProjectRepository
    {
        public ProjectRepository(ApplicationContext context) : base(context)
        {
        }
    }
}