using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Infrastructure.Repositories
{
    public class CommentsRepository : RepositoryBase<Comment, long>, ICommentRepository
    {
        public CommentsRepository(ApplicationContext context) : base(context)
        {
        }
    }
}