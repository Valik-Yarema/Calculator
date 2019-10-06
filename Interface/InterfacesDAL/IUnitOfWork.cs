using Model.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.InterfacesDAL
{
    public interface IUnitOfWork: IDisposable
    {
        int Save();
        IBaseRepository<Computing> ComputingsRepository { get; }
        IBaseRepository<ApplicationUser> AppUsersRepository { get; }
    }
}
