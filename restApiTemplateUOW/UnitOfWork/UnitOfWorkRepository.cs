using restApiTemplateDBEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace restApiTemplateUOW.UnitOfWork
{

    public interface IUnitOfWork
        : IDisposable
    {
        void Save();
    }

 
    public class UnitOfWork
        :  IUnitOfWork
    {
        public UnitOfWork(EntityTemplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private EntityTemplateDbContext _dbContext;

       
        private bool _disposed = false;
        private IParentEntityRepository _IParentEntityRepository;
        private IChildEntityRepository _IChildEntityRepository;
        public IParentEntityRepository ParentEntityRepository
        {
            get
            {
                if (_IParentEntityRepository == null)
                    _IParentEntityRepository = new ParentEntityRepository(_dbContext);
                return _IParentEntityRepository;
            }
        }

        public IChildEntityRepository ChildEntityRepository
        {
            get
            {
                if (_IChildEntityRepository == null)
                    _IChildEntityRepository = new ChildEntityRepository(_dbContext);
                return _IChildEntityRepository;
            }
        }

        public void Save()
        {
            using (TransactionScope tScope = new TransactionScope())
            {
                _dbContext.SaveChanges();
                tScope.Complete();
            }
        }

       



        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }


}
