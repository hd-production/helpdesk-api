namespace HdProduction.HelpDesk.Api.Models.Users
{
    public class UserRequestModel
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}