using HdProduction.HelpDesk.Api.Models.Users;

namespace HdProduction.HelpDesk.Api.Models.Projects
{
    public class CreateProjectRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public UserRequestModel DefaultAdminSettings { get; set; }
    }
}