using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FollowMeWeb.Models;

namespace FollowMeWeb.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "as";
        }

        // POST api/values
        public void Post([FromBody]Driver value)
        {
            try
            {
                foreach (var d in DriversController.DriversList)
                {
                    if (d.Code == value.Code)
                    {
                        d.Latitude = value.Latitude;
                        d.Longitude = value.Longitude;
                        return;
                    }
                }
            }
            catch
            {
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
