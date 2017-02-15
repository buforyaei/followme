using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using FollowMeWeb.Models;

namespace FollowMeWeb.Controllers
{
    public class DriversController : ApiController
    {
        public static List<Driver> DriversList = new List<Driver>();

        
        public List<Driver> Get()
        {
            return DriversList;
        }

        [ResponseType(typeof(Driver))]
        public IHttpActionResult GetCode(bool boolean)
        {
            var newDriver = new Driver();
            newDriver.GenerateNewCode();
            var isUnique = false;
            while (isUnique == false)
            {
                if (CheckUniqueness(newDriver)) isUnique = true;
                else newDriver.GenerateNewCode();
            }
            DriversList.Add(newDriver);
            return Ok(newDriver);
        }

        // POST: api/Users
        public IHttpActionResult Post(Driver driver)
        {
            try
            {
                foreach (var d in DriversList)
                {
                    if (d.Code == driver.Code)
                    {
                        d.Latitude = driver.Latitude;
                        d.Longitude = driver.Longitude;
                        return Ok();
                    }
                }
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(Driver))]
        public IHttpActionResult Getdriver(string code)
        {
            var driver = DriversList.Find(d => d.Code == code);
            return Ok(driver);
        }

        private bool CheckUniqueness(Driver driver)
        {
            return DriversList.All(d => driver.Code != d.Code);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteDriver(string code)
        {
            var driver = DriversList.RemoveAll(d => d.Code == code);
            return Ok();
        }

    }
}