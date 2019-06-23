using System.Collections.Generic;
using System.Threading.Tasks;

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
    public string RefreshToken { get; private set; }
    public long ProjectId { get; private set; }

    public void SetRefreshToken(string refreshToken)
    {
      RefreshToken = refreshToken;
    }
    
    public ICollection<Ticket> Tickets { get; } 
    public ICollection<Comment> Comments { get; } // ef
    public ICollection<TicketAction> Actions { get; } // ef
  }
}