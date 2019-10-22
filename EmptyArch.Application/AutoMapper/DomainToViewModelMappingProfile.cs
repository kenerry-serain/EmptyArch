using AutoMapper;
using EmptyArch.Application.ViewModels;
using EmptyArch.Domain.Entities;

namespace EmptyArch.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Person, PersonViewModel>();
        }
    }
}
