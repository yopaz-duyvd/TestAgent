namespace Hackathon.UnitOfWork;

using Hackathon.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<IsoDocument> IsoDocuments => Set<IsoDocument>();
    public DbSet<IsoFile> IsoFiles => Set<IsoFile>();
    public DbSet<ApprovedApplication> ApprovedApplications => Set<ApprovedApplication>();
    public DbSet<DeviceScan> DeviceScans => Set<DeviceScan>();
    public DbSet<ScannedApplication> ScannedApplications => Set<ScannedApplication>();
    public DbSet<Violation> Violations => Set<Violation>();
    public DbSet<ViolationDetail> ViolationDetails => Set<ViolationDetail>();
    public DbSet<EmailNotification> EmailNotifications => Set<EmailNotification>();
}
