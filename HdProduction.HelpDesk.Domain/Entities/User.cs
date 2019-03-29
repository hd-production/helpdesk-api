namespace HdProduction.HelpDesk.Domain.Entities
{
  public class User : EntityBase<long>
  {
    public User(string email, string firstName, string lastName, string permissionsRaw, string pwdHash, string pwdSalt)
    {
      Email = email;
      FirstName = firstName;
      LastName = lastName;
      PermissionsRaw = permissionsRaw;
      PwdHash = pwdHash;
      PwdSalt = pwdSalt;
    }

    public string Email { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string PermissionsRaw { get; }
    public string PwdHash { get; }
    public string PwdSalt { get; }
  }
}