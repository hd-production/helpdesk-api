using System.Threading.Tasks;
using HdProduction.HelpDesk.Api.Models.Projects;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace HdProduction.HelpDesk.Api.Controllers
{
    [Route("projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IUserService _userService;

        public ProjectsController(IProjectService service, IUserService userService)
        {
            _projectService = service;
            _userService = userService;
        }

        [HttpPost]
        public async Task CreateProject(CreateProjectRequest request)
        {
            await _projectService.CreateAsync(request.Id, request.Name);
            await _userService.CreateAsync(request.DefaultAdminSettings.FirstName,
                request.DefaultAdminSettings.LastName, request.DefaultAdminSettings.Email,
                Permissions.AdminRole, request.Id);
        }
    }
}