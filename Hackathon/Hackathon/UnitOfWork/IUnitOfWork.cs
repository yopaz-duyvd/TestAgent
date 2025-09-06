namespace Hackathon.UnitOfWork;

using Hackathon.Repositories;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    Task<int> SaveChangesAsync();
}

