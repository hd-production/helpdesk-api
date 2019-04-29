using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using HdProduction.HelpDesk.Domain.Exceptions;

namespace HdProduction.HelpDesk.Infrastructure.Services
{
    public class TicketStatusService: ITicketStatusService
    {
        private readonly ITicketStatusRepository _ticketStatusRepository;

        public TicketStatusService(ITicketStatusRepository ticketStatusRepository)
        {
            _ticketStatusRepository = ticketStatusRepository;
        }
        
        public async Task<TicketStatus> CreateAsync(TicketStatus ticketStatus)
        {
            _ticketStatusRepository.Add(ticketStatus);
            await _ticketStatusRepository.SaveAsync();
            return ticketStatus;
        }

        public async Task<TicketStatus> UpdateAsync(long id, TicketStatus ticketStatus)
        {
            var statusEntity = await FindById(id);
            statusEntity.Name = ticketStatus.Name;
            await _ticketStatusRepository.SaveAsync();
            return statusEntity;
        }

        public async Task<List<TicketStatus>> GetAllAsync()
        {
            return await _ticketStatusRepository.GetAllAsync();
        }
        
        public async Task<TicketStatus> FindById(long id)
        {
            return await _ticketStatusRepository.FindAsync(id)
                   ?? throw new EntityNotFoundException("Ticket status doesn't exist");;
        }

        public async Task DeleteAsync(long id)
        {
            var ticketStatus = await FindById(id);
            _ticketStatusRepository.Remove(ticketStatus);
            await _ticketStatusRepository.SaveAsync();
        }
    }
}