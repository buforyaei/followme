using System;
using System.Threading.Tasks;
using Windows.Web;
using Domain.Model;
using WebServices.Exceptions;

namespace Domain.Services
{
    public abstract class BaseService
    {
        public async Task<WebResult<T>> GetWebServiceData<T>(Func<Task<T>> getDataFuncAsync)
        {
            try
            {
                var result = await getDataFuncAsync();
                return new WebResult<T>(result);
            }
            catch (WebServiceException ex)
            {
                return HandleWebServiceException<T>(ex);
            }
        }

        protected WebResult<T> HandleWebServiceException<T>(WebServiceException exception)
        {
            if (exception.WebErrorStatus == WebErrorStatus.Unauthorized)
            {
                return new WebResult<T>(WebServiceStatus.Unauthorized);
            }
            if (exception.WebErrorStatus != WebErrorStatus.HostNameNotResolved)
            {
                return new WebResult<T>(WebServiceStatus.ServiceError);
            }
            return new WebResult<T>(WebServiceStatus.ConnectionError);
        }
    }
}