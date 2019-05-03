using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using HdProduction.HelpDesk.Domain.Exceptions;

namespace HdProduction.HelpDesk.Infrastructure.Services
{
    public class TicketStatusService: ITicketStatusService
    {
        private readonly ITicketStatusRepository _repository;
        private readonly ITicketStatusSafeguard _safeguard;

        public TicketStatusService(ITicketStatusRepository repository, ITicketStatusSafeguard safeguard)
        {
            _repository = repository;
            _safeguard = safeguard;
        }
        
        public async Task<int> CreateAsync(string name)
        {
            await _safeguard.EnsureNameAsync(name);
            
            var entity = new TicketStatus(name);
            _repository.Add(entity);
            await _repository.SaveAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(int id, string name)
        {
            await _safeguard.EnsureNameAsync(name);

            var statusEntity = await FindById(id);
            statusEntity.Name = name;
            await _repository.SaveAsync();
        }

        public async Task<List<TicketStatus>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        
        public async Task<TicketStatus> FindById(int id)
        {
            return await _repository.FindAsync(id) 
                   ?? throw ExceptionsHelper.EntityNotFound("Ticket status");;
        }

        public async Task DeleteAsync(int id)
        {
            var ticketStatus = await FindById(id);
            _repository.Remove(ticketStatus);
            await _repository.SaveAsync();
        }
    }
}