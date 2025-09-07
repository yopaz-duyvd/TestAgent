namespace Hackathon.Repositories;

using Hackathon.Models;
using Hackathon.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class ApprovedApplicationRepository(AppDbContext context) : IApprovedApplicationRepository
{
    public async Task<IEnumerable<ApprovedApplication>> GetAllAsync() =>
        await context.ApprovedApplications
            .Include(a => a.IsoFile)
            .ToListAsync();

    public async Task<ApprovedApplication?> GetByIdAsync(long id) =>
        await context.ApprovedApplications
            .Include(a => a.IsoFile)
            .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<IEnumerable<ApprovedApplication>> GetWhitelistAsync()
    {
        var manualApps = await context.ApprovedApplications
            .Where(a => a.IsoFileId == null)
            .Include(a => a.IsoFile)
            .ToListAsync();

        var activeDocument = await context.IsoDocuments
            .Include(d => d.Files)
            .FirstOrDefaultAsync(d => d.IsActive);

        if (activeDocument == null || activeDocument.Files.Count == 0)
        {
            return manualApps;
        }

        var fileIds = activeDocument.Files.Select(f => f.Id).ToList();

        var documentApps = await context.ApprovedApplications
            .Where(a => a.IsoFileId != null && fileIds.Contains(a.IsoFileId.Value))
            .Include(a => a.IsoFile)
            .ToListAsync();

        return manualApps.Concat(documentApps);
    }

    public async Task AddAsync(ApprovedApplication application) =>
        await context.ApprovedApplications.AddAsync(application);

    public void Update(ApprovedApplication application) =>
        context.ApprovedApplications.Update(application);

    public void Remove(ApprovedApplication application) =>
        context.ApprovedApplications.Remove(application);
}

