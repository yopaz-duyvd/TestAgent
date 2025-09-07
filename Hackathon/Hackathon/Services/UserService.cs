namespace Hackathon.Services;

using Hackathon.Models.Dtos;
using Hackathon.UnitOfWork;

public class UserService(IUnitOfWork unitOfWork) : IUserService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<IEnumerable<UserScanSummaryResponse>> GetUsersWithLastScanAsync()
    {
        return await _unitOfWork.Users.GetUsersWithLastScanAsync();
    }
}
