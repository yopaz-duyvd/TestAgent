namespace Hackathon.Services;

using Hackathon.Models;
using Hackathon.Models.Dtos;
using Hackathon.UnitOfWork;
using System.Collections.Generic;

public class ApprovedApplicationService(IUnitOfWork unitOfWork) : IApprovedApplicationService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<IEnumerable<ApprovedApplication>> GetAllAsync() =>
        await _unitOfWork.ApprovedApplications.GetAllAsync();

    public async Task<ApprovedApplication?> GetByIdAsync(long id) =>
        await _unitOfWork.ApprovedApplications.GetByIdAsync(id);

    public async Task<IEnumerable<ApprovedApplication>> GetWhitelistAsync() =>
        await _unitOfWork.ApprovedApplications.GetWhitelistAsync();

    public async Task<ApprovedApplication> CreateAsync(ApprovedApplicationRequest request)
    {
        var application = new ApprovedApplication
        {
            IsoFileId = request.IsoFileId,
            AppName = request.AppName,
            AppVersion = request.AppVersion,
            Vendor = request.Vendor,
            Category = request.Category
        };

        await _unitOfWork.ApprovedApplications.AddAsync(application);
        await _unitOfWork.SaveChangesAsync();
        return application;
    }

    public async Task<bool> UpdateAsync(long id, ApprovedApplicationRequest request)
    {
        var application = await _unitOfWork.ApprovedApplications.GetByIdAsync(id);
        if (application == null)
        {
            return false;
        }

        application.IsoFileId = request.IsoFileId;
        application.AppName = request.AppName;
        application.AppVersion = request.AppVersion;
        application.Vendor = request.Vendor;
        application.Category = request.Category;

        _unitOfWork.ApprovedApplications.Update(application);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var application = await _unitOfWork.ApprovedApplications.GetByIdAsync(id);
        if (application == null)
        {
            return false;
        }

        _unitOfWork.ApprovedApplications.Remove(application);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}

