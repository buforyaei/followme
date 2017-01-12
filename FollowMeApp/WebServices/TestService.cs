using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable.Serializers;
using WebServices.Dto;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace WebServices
{
    public class TestService
    {
        public async Task Post()
        {
            var client = new RestClient("http://localhost:58174/api/drivers");
            var request = new RestRequest(Method.POST);
            var d = new Driver// {"34534", "345", "234"};
            {
                Code = "23423",
                Latitude = 354.5,
                Longitude = 2343.4
            };
            request.AddJsonBody(d);

            try
            {
                var response = await client.Execute(request);
                var strin = Encoding.UTF8.GetString(response.RawBytes, 0,
                response.RawBytes.Length);
            }
            catch(Exception e)
            {
                
            }

        }
       
        
        
    }
}
