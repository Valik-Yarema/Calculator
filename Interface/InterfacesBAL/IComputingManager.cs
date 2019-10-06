using Model.DB;
using Model.ViewModels.ComputingViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interface.InterfacesBAL
{
    public interface IComputingManager
    {
        Task<ComputingViewModel> GetComputingById(Guid id);
        Task<IEnumerable<ComputingViewModel>> GetAll(int page, int countOnPage);
       Task<IEnumerable<ComputingViewModel>> GetComputingUser(int page,int countOnPage, string userId);

        Task<ComputingViewModel> Insert(ComputingCreateViewModel model);
        Task Delete(Guid item);

    }
}