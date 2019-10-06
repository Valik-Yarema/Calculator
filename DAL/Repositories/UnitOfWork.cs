using Interface.InterfacesDAL;
using Model.DB;
using System;


namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        IBaseRepository<Computing> computingRepo;
        IBaseRepository<ApplicationUser> appUserRepo;
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }


        public int Save()
        {
            return context.SaveChanges();
        }

        private bool isDisposed = false;

        public IBaseRepository<Computing> ComputingsRepository {
            get
            {
                if (computingRepo == null) { computingRepo = new BaseRepository<Computing>(context); }
                return computingRepo;
            }
        }

        public IBaseRepository<ApplicationUser> AppUsersRepository {
            get
            {
                if (appUserRepo == null)
                {
                    appUserRepo = new BaseRepository<ApplicationUser>(context);
                }
                return appUserRepo;
                
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                context.Dispose();
            }
            isDisposed = true;
        }
    }
}
