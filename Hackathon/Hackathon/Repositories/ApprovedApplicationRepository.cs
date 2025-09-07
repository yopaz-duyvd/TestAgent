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
            .Include(a => a.IsoDocument)
            .ToListAsync();

    public async Task<ApprovedApplication?> GetByIdAsync(long id) =>
        await context.ApprovedApplications
            .Include(a => a.IsoDocument)
            .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<IEnumerable<ApprovedApplication>> GetWhitelistAsync()
    {
        var manualApps = await context.ApprovedApplications
            .Where(a => a.IsoDocumentId == null)
            .Include(a => a.IsoDocument)
            .ToListAsync();

        var activeDocument = await context.IsoDocuments
            .FirstOrDefaultAsync(d => d.IsActive);

        if (activeDocument == null)
        {
            return manualApps;
        }

        var documentApps = await context.ApprovedApplications
            .Where(a => a.IsoDocumentId == activeDocument.Id)
            .Include(a => a.IsoDocument)
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

