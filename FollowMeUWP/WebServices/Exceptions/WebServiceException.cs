using System;
using Windows.Web;

namespace WebServices.Exceptions
{
    public class WebServiceException : Exception
    {
        public WebServiceException(WebErrorStatus status)
        {
            WebErrorStatus = status;
        }

        public WebServiceException(Exception innerException, WebErrorStatus status)
            : base(string.Empty, innerException)
        {
            WebErrorStatus = status;
        }

        public WebErrorStatus WebErrorStatus { get; set; }
    }
}