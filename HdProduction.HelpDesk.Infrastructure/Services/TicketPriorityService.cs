using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using HdProduction.HelpDesk.Domain.Exceptions;

namespace HdProduction.HelpDesk.Infrastructure.Services
{
    public class TicketPriorityService: ITicketPriorityService
    {
        private readonly ITicketPriorityRepository _repository;
        private readonly ITicketPrioritySafeguard _safeguard;


        public TicketPriorityService(ITicketPriorityRepository repository, 
            ITicketPrioritySafeguard safeguard)
        {
            _repository = repository;
            _safeguard = safeguard;
        }
        
        public async Task<int> CreateAsync(string name)
        {
            await _safeguard.EnsureNameAsync(name);

            var entity = new TicketPriority(name);
            _repository.Add(entity);
            await _repository.SaveAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(int id, string name)
        {
            await _safeguard.EnsureNameAsync(name);

            var entity = await FindById(id);
            entity.Name = name;
            await _repository.SaveAsync();
        }

        public async Task<List<TicketPriority>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        
        public async Task<TicketPriority> FindById(int id)
        {
            return await _repository.FindAsync(id)
                   ?? throw new EntityNotFoundException("Ticket priority doesn't exist");;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await FindById(id);
            _repository.Remove(entity);
            await _repository.SaveAsync();
        }
    }
}