namespace Hackathon.UnitOfWork;

using Hackathon.Repositories;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    IIsoDocumentRepository IsoDocuments { get; }
    Task<int> SaveChangesAsync();
}

