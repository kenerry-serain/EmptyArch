using AutoMapper;
using EmptyArch.Application.Abstractions;
using EmptyArch.Application.ViewModels;
using EmptyArch.Domain.Abstractions;
using EmptyArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmptyArch.Application.Services
{
    public class PersonApplicationService : IPersonApplicationService
    {
        private readonly IPersonDomainService _personDomainService;
        private readonly IMapper _mapper;
        public PersonApplicationService(IPersonDomainService personDomainService, IMapper mapper)
        {
            _mapper = mapper;
            _personDomainService = personDomainService;
        }

        public async Task<PersonViewModel> Create(PersonViewModel personViewModel)
        {
            var person = _mapper.Map<Person>(personViewModel);
            var createdPerson = await _personDomainService.Create(person);
            return _mapper.Map<PersonViewModel>(createdPerson);
        }

        public async Task<IEnumerable<PersonViewModel>> ReadAll()
        {
            var personList = await _personDomainService.ReadAll();
            return _mapper.Map<IEnumerable<PersonViewModel>>(personList);
        }

        public async Task<PersonViewModel> ReadById(int id)
        {
            var person = await _personDomainService.ReadById(id);
            return _mapper.Map<PersonViewModel>(person);
        }

        public async Task Remove(int id)
        {
            await _personDomainService.Remove(id);
        }

        public async Task<PersonViewModel> Update(PersonViewModel personViewModel)
        {
            var person = _mapper.Map<Person>(personViewModel);
            var createdPerson = await _personDomainService.Update(person);
            return _mapper.Map<PersonViewModel>(createdPerson);
        }
    }
}
