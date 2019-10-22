using EmptyArch.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmptyArch.Application.Abstractions
{
    public interface IPersonApplicationService
    {
        Task<IEnumerable<PersonViewModel>> ReadAll();
        Task<PersonViewModel> ReadById(int id);
        Task<PersonViewModel> Create(PersonViewModel PersonViewModel);
        Task<PersonViewModel> Update(PersonViewModel PersonViewModel);
        Task Remove(int id);
    }
}
