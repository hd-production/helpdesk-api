using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using HdProduction.HelpDesk.Domain.Exceptions;
using HdProduction.HelpDesk.Domain.Safeguards;

namespace HdProduction.HelpDesk.Infrastructure.Services
{
    public class IdNamedTicketAttributeService<T> : IIdNamedTicketAttributeService<T> 
        where T : IdNamedTicketAttribute, new()
    {
        private readonly IIdNamedTicketAttributeRepository<T> _repository;
        private readonly IdNamedTicketAttributeSafeguard<T> _safeguard;

        public IdNamedTicketAttributeService(
            IIdNamedTicketAttributeRepository<T> repository,
            IdNamedTicketAttributeSafeguard<T> safeguard)
        {
            _repository = repository;
            _safeguard = safeguard;
        }
        
        public async Task<int> CreateAsync(string name)
        {
            await _safeguard.EnsureNameAsync(name);

            var entity = new T {Name = name};
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

        public async Task<List<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        
        public async Task<T> FindById(int id)
        {
            return await _repository.FindAsync(id) 
                   ?? throw ExceptionsHelper.EntityNotFound(typeof(T).Name);;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await FindById(id);
            _repository.Remove(entity);
            await _repository.SaveAsync();
        }
    }
}