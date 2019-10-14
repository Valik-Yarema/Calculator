using Model.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interface.InterfacesDAL
{
    public interface IUnitOfWork: IDisposable
    {
        Task<int> Save();
        IBaseRepository<Computing> ComputingsRepository { get; }
        IBaseRepository<ApplicationUser> AppUsersRepository { get; }
    }
}
