using System.Threading.Tasks;
using Domain.Model;
using Domain.Services.Interfaces;
using WebServices.Dto;
using WebServices.Services.Interfaces;

namespace Domain.Services
{
    public class FollowMeService : BaseService, IFollowMeService
    {
        private readonly IFollowMeWebService _followMeWebService;

        public FollowMeService(IFollowMeWebService followMeWebService)
        {
            _followMeWebService = followMeWebService;
        }

        public async Task<WebResult<Driver>> GetCodeAsync()
        {
            return await GetWebServiceData(() => _followMeWebService.GetCode());
        }

        public async Task<WebResult<Driver>> GetDriverAsync(int code)
        {
            return await GetWebServiceData(() => _followMeWebService.GetDriver(code));
        }

        public async Task<WebResult<Driver>> PostDriverAsync(Driver driver)
        {
            return await GetWebServiceData(() => _followMeWebService.PostDriver(driver));
        }
    }
}