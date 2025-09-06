namespace Hackathon.UnitOfWork;

using Hackathon.Repositories;

public class UnitOfWork(
    AppDbContext context,
    IUserRepository users,
    IIsoDocumentRepository isoDocuments,
    IApprovedApplicationRepository approvedApplications) : IUnitOfWork
{
    public IUserRepository Users { get; } = users;
    public IIsoDocumentRepository IsoDocuments { get; } = isoDocuments;
    public IApprovedApplicationRepository ApprovedApplications { get; } = approvedApplications;

    public async Task<int> SaveChangesAsync() => await context.SaveChangesAsync();
}

