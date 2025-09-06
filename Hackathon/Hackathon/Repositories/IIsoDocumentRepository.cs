namespace Hackathon.Repositories;

using Hackathon.Models;

public interface IIsoDocumentRepository
{
    Task<int> CountByYearAsync(int year);
    Task AddAsync(IsoDocument document);
}
