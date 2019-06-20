namespace HdProduction.HelpDesk.Domain.Metadata
{
  public static class Permissions
  {
//    public const string InviteUsers = "admin:invite-users";
//    public const string ManagePermissions = "admin:manage-permissions";

//    public const string 

    public const string AdminRole = "admin";
    public const string SupportAgentRole = "support-agent";
    public const string SupportAdminRole = "support-admin";

    public static string Many(params string[] permissions)
    {
      return string.Join(',', permissions);
    }
  }
}