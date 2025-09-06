namespace Hackathon.Services;

using Hackathon.Models;
using Hackathon.Models.Dtos;
using System.Collections.Generic;

public interface IApprovedApplicationService
{
    Task<IEnumerable<ApprovedApplication>> GetAllAsync();
    Task<ApprovedApplication?> GetByIdAsync(long id);
    Task<IEnumerable<ApprovedApplication>> GetByIsoDocumentIdAsync(long isoDocumentId);
    Task<ApprovedApplication> CreateAsync(ApprovedApplicationRequest request);
    Task<bool> UpdateAsync(long id, ApprovedApplicationRequest request);
    Task<bool> DeleteAsync(long id);
}

