namespace Domain.Model
{
    public enum WebServiceStatus
    {
        Success,
        Unauthorized,
        ServiceError,
        ConnectionError
    }

    public class WebResult<T>
    {
        public WebResult(WebServiceStatus webServiceStatus)
        {
            WebServiceStatus = webServiceStatus;
            Result = default(T);
        }

        public WebResult(T result)
        {
            WebServiceStatus = WebServiceStatus.Success;
            Result = result;
        }

        public WebServiceStatus WebServiceStatus { get; set; }
        public T Result { get; set; }
    }
}