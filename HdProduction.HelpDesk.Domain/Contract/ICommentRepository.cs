using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Domain.Contract
{
    public interface ICommentRepository : IRepository<Comment, long>
    {
    }
}