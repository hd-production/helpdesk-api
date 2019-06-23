using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Infrastructure.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Task FindAsync(long id) => _projectRepository.FindAsync(id);

        public async Task<long> CreateAsync(long dashboardId, string name)
        {
            var project = new Project
            {
                DashboardId = dashboardId,
                Name = name
            };
            _projectRepository.Add(project);
            await _projectRepository.SaveAsync();
            return project.Id;
        }
    }
}