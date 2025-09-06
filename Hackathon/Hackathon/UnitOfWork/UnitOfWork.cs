namespace Hackathon.UnitOfWork;

using Hackathon.Repositories;

public class UnitOfWork(AppDbContext context, IUserRepository users, IIsoDocumentRepository isoDocuments) : IUnitOfWork
{
    public IUserRepository Users { get; } = users;
    public IIsoDocumentRepository IsoDocuments { get; } = isoDocuments;

    public async Task<int> SaveChangesAsync() => await context.SaveChangesAsync();
}

