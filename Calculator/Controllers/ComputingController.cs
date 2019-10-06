using Interface.InterfacesBAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModels.ComputingViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Calculator.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ComputingController : Controller
    {
        private readonly IComputingManager _computingManager;
        public ComputingController(IComputingManager computingManager)
        {
            _computingManager = computingManager;
        }
        public IActionResult Index()
        {
            return View();
        }
      
        [HttpGet]
        public async Task<IEnumerable<ComputingViewModel>> GetComputings()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var items =await _computingManager.GetComputingUser(1, 20, userId);
            return await _computingManager.GetComputingUser(1, 20,userId);
        }

       
        [HttpPost]
        public async Task<ComputingViewModel> ComputingCreate([FromBody]ComputingCreateViewModel inputModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ComputingCreateViewModel model = new ComputingCreateViewModel() { Expression = inputModel.Expression, UserId = userId};
            try
            {
                return await _computingManager.Insert(model);
            }
            catch (DivideByZeroException e)
            {
                return new ComputingViewModel(){Expression = e.Message + inputModel.Expression, Outcome = Double.NaN};
            }
           
        }
        [HttpGet("{id}")]
        public async Task<ComputingViewModel> GetComputing(Guid id)
        {
            return await _computingManager.GetComputingById(id);
        }

        [HttpDelete("{id}")]
        public ComputingViewModel DeleteComputing(Guid id)
        {
            _computingManager.Delete(id);
            return new ComputingViewModel(){ Id = id };
        }
    }
}
