using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using HdProduction.HelpDesk.Domain.Exceptions;

namespace HdProduction.HelpDesk.Domain.Safeguards
{
    public class TicketAttributeSafeguard<T> where T : TicketAttribute
    {
        private readonly ITicketAttributeRepository<T> _repository;

        public TicketAttributeSafeguard(ITicketAttributeRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task EnsureNameAsync(string name, long projectId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw ExceptionsHelper.Empty(nameof(name));
            }
            if (name.Length > TicketAttribute.MaxNameLength)
            {
                throw ExceptionsHelper.LongLength(nameof(name));
            }
            if (await _repository.FindByNameAsync(name, projectId) != null)
            {
                throw ExceptionsHelper.EntityAlreadyExists(typeof(T).Name, nameof(name));
            }
        }
    }
}