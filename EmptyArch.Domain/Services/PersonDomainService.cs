using System.Collections.Generic;
using System.Threading.Tasks;
using EmptyArch.Domain.Abstractions;
using EmptyArch.Domain.Entities;

namespace EmptyArch.Domain.Services
{
    public class PersonDomainService : IPersonDomainService
    {
        private readonly IPersonRepository _personRepository;
        public PersonDomainService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<Person> Create(Person person)
        {
            return await _personRepository.Create(person);
        }

        public async Task<IEnumerable<Person>> ReadAll()
        {
            return await _personRepository.ReadAll();
        }

        public async Task<Person> ReadById(int id)
        {
            return await _personRepository.ReadById(id);
        }

        public async Task Remove(int id)
        {
            await _personRepository.Remove(id);
        }

        public async Task<Person> Update(Person person)
        {
            return await _personRepository.Update(person);
        }
    }
}
