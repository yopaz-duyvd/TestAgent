namespace Hackathon.Repositories;

using Hackathon.Models;
using System.Collections.Generic;

public interface IIsoDocumentRepository
{
    Task<int> CountByYearAsync(int year);
    Task AddAsync(IsoDocument document);
    Task<IEnumerable<IsoDocument>> GetByYearAsync(int year);
}
