namespace HdProduction.HelpDesk.Api.Models.Sessions
{
  public class AuthenticateRequestModel
  {
    public string Email { get; set; }
    public string PwdHash { get; set; }
  }
}