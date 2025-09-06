namespace Hackathon.UnitOfWork;

using Hackathon.Repositories;

public class UnitOfWork(AppDbContext context, IUserRepository users) : IUnitOfWork
{
    public IUserRepository Users { get; } = users;

    public async Task<int> SaveChangesAsync() => await context.SaveChangesAsync();
}

