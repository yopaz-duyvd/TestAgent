namespace Hackathon.Repositories;

using Hackathon.Models;
using System.Collections.Generic;

public interface IIsoDocumentRepository
{
    Task<int> CountByYearAsync(int year);
    Task AddAsync(IsoDocument document);
    Task<IEnumerable<IsoDocument>> GetByYearAsync(int year);
    Task<IEnumerable<IsoDocument>> GetAllAsync();
    Task<IsoDocument?> GetByIdAsync(long id);
    Task<IsoDocument?> GetByIdWithFilesAsync(long id);
    Task<IEnumerable<IsoFile>> GetFilesByDocumentIdAsync(long documentId);
    void Remove(IsoDocument document);
}
