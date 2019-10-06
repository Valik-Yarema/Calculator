﻿using AutoMapper;
using Interface.InterfacesBAL;
using Interface.InterfacesDAL;
using Model.DB;
using Model.ViewModels.ComputingViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Services;

namespace BAL.Managers
{
    public class ComputingManager :BaseManager, IComputingManager
    {
        private readonly ComputingModule _computingModule=new ComputingModule();

        public ComputingManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task< IEnumerable<ComputingViewModel>> GetComputingUser(int page, int countOnPage,string userId)
        {
            IEnumerable<Computing> countings = await unitOfWork.ComputingsRepository.GetFiltered(page, countOnPage, c => c.UserId == userId);
           return mapper.Map<IEnumerable<Computing>, IEnumerable<ComputingViewModel>>(countings);
            
        }
        public async Task<ComputingViewModel> GetComputingById(Guid id)
        {
            Computing countings = await unitOfWork.ComputingsRepository.GetById(id);
            return mapper.Map<Computing, ComputingViewModel>(countings);

        }

        public  async Task<ComputingViewModel> Insert(ComputingCreateViewModel model)
        {
            Computing computing = mapper.Map<ComputingCreateViewModel, Computing>(model);
           computing.Outcome = _computingModule.CountOperation(model.Expression);
          
           await unitOfWork.ComputingsRepository.Insert(computing);
            unitOfWork.Save();
            return mapper.Map<Computing,ComputingViewModel>(computing);
        }

        public async Task Delete(Guid item)
        {
            Computing comput = await unitOfWork.ComputingsRepository.GetById(item);
            if (comput == null) { return; }
            unitOfWork.ComputingsRepository.Delete(comput);
            unitOfWork.Save();
        }

        public async Task<IEnumerable<ComputingViewModel>> GetAll(int page, int countOnPage)
        {
            IEnumerable<Computing> countings = await unitOfWork.ComputingsRepository.GetAll(page, countOnPage);
            return mapper.Map<IEnumerable<Computing>, IEnumerable<ComputingViewModel>>(countings);
        }

       
    }
}
