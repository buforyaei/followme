using System.Threading.Tasks;
using WebServices.Dto;

namespace WebServices.Services.Interfaces
{
    public interface IFollowMeWebService
    {
        Task<Driver> GetCode();

        Task<Driver> GetDriver(int code);

        Task<Driver> PostDriver(Driver driver);
    }
}