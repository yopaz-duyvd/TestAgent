namespace Hackathon.Repositories;

using Hackathon.Models;
using System.Collections.Generic;

public interface IApprovedApplicationRepository
{
    Task<IEnumerable<ApprovedApplication>> GetAllAsync();
    Task<ApprovedApplication?> GetByIdAsync(long id);
    Task<IEnumerable<ApprovedApplication>> GetWhitelistAsync();
    Task AddAsync(ApprovedApplication application);
    void Update(ApprovedApplication application);
    void Remove(ApprovedApplication application);
}

