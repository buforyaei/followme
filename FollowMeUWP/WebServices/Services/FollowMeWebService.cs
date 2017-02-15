using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp.Portable;
using WebServices.Consts;
using WebServices.Dto;
using WebServices.Services.Interfaces;

namespace WebServices.Services
{
    public class FollowMeWebService : RestClientBase, IFollowMeWebService
    {
        public FollowMeWebService()
            : base(FollowMeConsts.BaseAddress) { }

        public async Task<Driver> GetCode()
        {
            var request = new RestRequest(FollowMeConsts.ApiDrivers + "/?boolean=true", Method.GET);
            return await CallAsync<Driver>(request);
        }

        public async Task<Driver> GetDriver(int code)
        {
            var request = new RestRequest(FollowMeConsts.ApiDrivers + "/?code=" + code, Method.GET);
            return await CallAsync<Driver>(request);
        }

        public async Task<Driver> PostDriver(Driver driver)
        {
            var request = new RestRequest(FollowMeConsts.ApiDrivers, Method.POST);
            request.AddJsonBody(driver);
            return await CallAsync<Driver>(request);
        }
    }
}