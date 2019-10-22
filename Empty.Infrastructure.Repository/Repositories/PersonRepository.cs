using Dapper;
using EmptyArch.Domain.Abstractions;
using EmptyArch.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EmptyArch.Infrastructure.Repository.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private IConfiguration _configuration;
        public PersonRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Person> Create(Person person)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                var createdPerson = await connection.QuerySingleAsync<Person>(string.Format("INSERT INTO Person VALUES ('{0}'); SELECT * FROM Person WHERE Id = (SELECT SCOPE_IDENTITY()) ", person.Name));
                return createdPerson;
            }
        }

        public async Task<IEnumerable<Person>> ReadAll()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                var personList = await connection.QueryAsync<Person>("SELECT * FROM Person");
                return personList;
            }
        }

        public async Task<Person> ReadById(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                var person = await connection.QuerySingleAsync<Person>(string.Format("SELECT * FROM Person WHERE Id={0}",id));
                return person;
            }
        }

        public async Task Remove(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                await connection.QueryAsync<Person>(string.Format("DELETE FROM Person WHERE Id={0}", id));
            }
        }

        public async Task<Person> Update(Person person)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                var createdPerson = await connection.QuerySingleAsync<Person>(string.Format("UPDATE Person SET Name= '{0}' WHERE Id={1}; SELECT * FROM Person WHERE Id = {1}", person.Name, person.Id));
                return createdPerson;
            }
        }
    }
}
