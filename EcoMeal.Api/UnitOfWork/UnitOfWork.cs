using EcoMeal.Api.Data;
using EcoMeal.Api.Repository;
using EcoMeal.Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoMeal.Api.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcoMealDbContext _context;
        private IBusinessRepository _businessRepository;
        public IBusinessRepository BusinessRepository
        {
            get
            {
                if(this._businessRepository == null)
                {
                    this._businessRepository = new BusinessRepository(_context);
                }
                return _businessRepository;
            }
        }

        private IBusinessTypeRepository _businessTypeRepository;
        public IBusinessTypeRepository BusinessTypeRepository
        {
            get
            {
                if(this._businessTypeRepository == null)
                {
                    this._businessTypeRepository = new BusinessTypeRepository(_context);
                }
                return _businessTypeRepository;
            }
        }
        private IOrderPackageRepository _orderPackageRepository;
        public IOrderPackageRepository OrderPackageRepository
        {
            get
            {
                if (this._orderPackageRepository == null)
                {
                    this._orderPackageRepository = new OrderPackageRepository(_context);
                }
                return _orderPackageRepository;
            }
        }
        private IOrderRepository _orderRepository;
        public IOrderRepository OrderRepository
        {
            get
            {
                if (this._orderPackageRepository == null)
                {
                    this._orderRepository = new OrderRepository(_context);
                }
                return _orderRepository;
            }
        }
        private IPackageRepository _packageRepository;
        public IPackageRepository PackageRepository
        {
            get
            {
                if (this._packageRepository == null)
                {
                    this._packageRepository = new PackageRepository(_context);
                }
                return _packageRepository;
            }
        }
        private IPackageTypeRepository _packageTypeRepository;
        public IPackageTypeRepository PackageTypeRepository
        {
            get
            {
                if (this._packageTypeRepository == null)
                {
                    this._packageTypeRepository = new PackageTypeRepository(_context);
                }
                return _packageTypeRepository;
            }
        }
        private IRoleRepository _roleRepository;
        public IRoleRepository RoleRepository
        {
            get
            {
                if (this._roleRepository == null)
                {
                    this._roleRepository = new RoleRepository(_context);
                }
                return _roleRepository;
            }
        }
        private IStatusRepository _statusRepository;
        public IStatusRepository StatusRepository
        {
            get
            {
                if (this._statusRepository == null)
                {
                    this._statusRepository = new StatusRepository(_context);
                }
                return _statusRepository;
            }
        }
        private IUserRepository _userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        public UnitOfWork(EcoMealDbContext context)
        {
            _context = context;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
