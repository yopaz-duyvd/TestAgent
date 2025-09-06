namespace Hackathon.UnitOfWork;

using Hackathon.Repositories;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    IIsoDocumentRepository IsoDocuments { get; }
    IApprovedApplicationRepository ApprovedApplications { get; }
    IDeviceScanRepository DeviceScans { get; }
    Task<int> SaveChangesAsync();
}

