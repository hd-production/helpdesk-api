using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using HdProduction.HelpDesk.Domain.Exceptions;

namespace HdProduction.HelpDesk.Domain.Safeguards
{
    public class IdNamedTicketAttributeSafeguard<T> where T : IdNamedTicketAttribute
    {
        private readonly IIdNamedTicketAttributeRepository<T> _repository;

        public IdNamedTicketAttributeSafeguard(IIdNamedTicketAttributeRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task EnsureNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw ExceptionsHelper.Empty(nameof(name));
            }
            if (name.Length > IdNamedTicketAttribute.MaxNameLength)
            {
                throw ExceptionsHelper.LongLength(nameof(name));
            }
            if (await _repository.FindByNameAsync(name) != null)
            {
                throw ExceptionsHelper.EntityAlreadyExists(typeof(T).Name, nameof(name));
            }
        }
    }
}