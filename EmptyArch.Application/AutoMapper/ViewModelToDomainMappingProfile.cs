using AutoMapper;
using EmptyArch.Application.ViewModels;
using EmptyArch.Domain.Entities;

namespace EmptyArch.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PersonViewModel, Person>();
        }
    }
}
