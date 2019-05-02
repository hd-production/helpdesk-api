using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
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
                throw new BusinessLogicException("Name can't be empty");
            }
            if (name.Length > 32)
            {
                throw new BusinessLogicException("Name is too long");
            }
            if (await _ticketPriorityRepository.FindByNameAsync(name) != null)
            {
                throw new BusinessLogicException("There can not be duplicated names");
            }
        }
    }
}