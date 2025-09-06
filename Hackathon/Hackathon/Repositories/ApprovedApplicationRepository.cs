namespace Hackathon.Repositories;

using Hackathon.Models;
using Hackathon.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class ApprovedApplicationRepository(AppDbContext context) : IApprovedApplicationRepository
{
    public async Task<IEnumerable<ApprovedApplication>> GetAllAsync() =>
        await context.ApprovedApplications.ToListAsync();

    public async Task<ApprovedApplication?> GetByIdAsync(long id) =>
        await context.ApprovedApplications.FindAsync(id);

    public async Task<IEnumerable<ApprovedApplication>> GetByIsoDocumentIdAsync(long isoDocumentId) =>
        await context.ApprovedApplications
            .Where(a => a.IsoDocumentId == isoDocumentId)
            .ToListAsync();

    public async Task AddAsync(ApprovedApplication application) =>
        await context.ApprovedApplications.AddAsync(application);

    public void Update(ApprovedApplication application) =>
        context.ApprovedApplications.Update(application);

    public void Remove(ApprovedApplication application) =>
        context.ApprovedApplications.Remove(application);
}

