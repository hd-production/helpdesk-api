using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using HdProduction.HelpDesk.Domain.Exceptions;

namespace HdProduction.HelpDesk.Domain.Safeguards
{
    public class TicketPrioritySafeguard : ITicketPrioritySafeguard
    {
        private readonly ITicketPriorityRepository _ticketPriorityRepository;

        public TicketPrioritySafeguard(ITicketPriorityRepository ticketPriorityRepository)
        {
            _ticketPriorityRepository = ticketPriorityRepository;
        }

        public async Task EnsureNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw ExceptionsHelper.Empty(nameof(name));
            }
            if (name.Length > TicketPriority.MaxNameLength)
            {
                throw ExceptionsHelper.LongLength(nameof(name));
            }
            if (await _ticketPriorityRepository.FindByNameAsync(name) != null)
            {
                throw ExceptionsHelper.EntityAlreadyExists("Ticket priority", nameof(name));
            }
        }
    }
}