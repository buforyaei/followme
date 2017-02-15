using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Domain.Model;
using WebServices.Dto;

namespace Domain.Services.Interfaces
{
    public interface IFollowMeService
    {
        Task<WebResult<Driver>> GetCodeAsync();

        Task<WebResult<Driver>> GetDriverAsync(int code);

        Task<WebResult<Driver>> PostDriverAsync(Driver driver);

        Task<WebResult<Driver>> DeleteDriverAsync(int code);
    }
}