namespace Hackathon.Repositories;

using Hackathon.Models;
using Hackathon.UnitOfWork;
using Microsoft.EntityFrameworkCore;

public class IsoDocumentRepository(AppDbContext context) : IIsoDocumentRepository
{
    public async Task<int> CountByYearAsync(int year) =>
        await context.IsoDocuments.CountAsync(d => d.Year == year);

    public async Task AddAsync(IsoDocument document) =>
        await context.IsoDocuments.AddAsync(document);
}
