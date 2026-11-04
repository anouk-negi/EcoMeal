using EcoMeal.Api.Repository.Interfaces;

namespace EcoMeal.Api.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBusinessRepository BusinessRepository { get; }
        IBusinessTypeRepository BusinessTypeRepository { get; }
        IOrderPackageRepository OrderPackageRepository { get; }
        IOrderRepository OrderRepository { get; }
        IPackageRepository PackageRepository { get; }
        IPackageTypeRepository PackageTypeRepository { get; }
        IRoleRepository RoleRepository { get; }
        IStatusRepository StatusRepository { get; }
        IUserRepository UserRepository { get; }

        Task Save();
    }
}
