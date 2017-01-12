using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FollowMeWeb.Models
{
    public class Driver
    {
        public string Code { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public void GenerateNewCode()
        {
            var random = new Random();
            var code = string.Empty;
            for (var i = 0; i < 5; i++)
            {
                code += random.Next(0, 9).ToString();
            }
            Code = code;
        }
    }
}