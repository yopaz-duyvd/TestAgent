namespace Hackathon.UnitOfWork;

using Hackathon.Repositories;

public class UnitOfWork(
    AppDbContext context,
    IUserRepository users,
    IIsoDocumentRepository isoDocuments,
    IApprovedApplicationRepository approvedApplications,
    IDeviceScanRepository deviceScans) : IUnitOfWork
{
    public IUserRepository Users { get; } = users;
    public IIsoDocumentRepository IsoDocuments { get; } = isoDocuments;
    public IApprovedApplicationRepository ApprovedApplications { get; } = approvedApplications;
    public IDeviceScanRepository DeviceScans { get; } = deviceScans;

    public async Task<int> SaveChangesAsync() => await context.SaveChangesAsync();
}

