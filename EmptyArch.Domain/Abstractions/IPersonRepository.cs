using EmptyArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmptyArch.Domain.Abstractions
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> ReadAll();
        Task<Person> ReadById(int id);
        Task<Person> Create(Person person);
        Task<Person> Update(Person person);
        Task Remove(int id);
    }
}
