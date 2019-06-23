using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Domain.Contract
{
    public interface IProjectRepository : IRepository<Project, long>
    {
    }
}