using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using HdProduction.HelpDesk.Domain.Exceptions;

namespace HdProduction.HelpDesk.Domain.Safeguards
{
    public class TicketStatusSafeguard : ITicketStatusSafeguard
    {
        private readonly ITicketStatusRepository _ticketStatusRepository;

        public TicketStatusSafeguard(ITicketStatusRepository ticketStatusRepository)
        {
            _ticketStatusRepository = ticketStatusRepository;
        }

        public async Task EnsureNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw ExceptionsHelper.Empty(nameof(name));
            }
            if (name.Length > TicketStatus.MaxNameLength)
            {
                throw ExceptionsHelper.LongLength(nameof(name));
            }
            if (await _ticketStatusRepository.FindByNameAsync(name) != null)
            {
                throw ExceptionsHelper.Duplicate(nameof(name));
            }
        }
    }
}