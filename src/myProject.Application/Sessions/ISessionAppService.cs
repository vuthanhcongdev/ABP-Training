using System.Threading.Tasks;
using Abp.Application.Services;
using myProject.Sessions.Dto;

namespace myProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
