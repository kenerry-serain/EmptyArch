using EmptyArch.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmptyArch.Domain.Abstractions
{
    public interface IPersonDomainService
    {
        Task<IEnumerable<Person>> ReadAll();
        Task<Person> ReadById(int id);
        Task<Person> Create(Person person);
        Task<Person> Update(Person person);
        Task Remove(int id);
    }
}
