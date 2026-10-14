using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Route.Models.RouteSequence
{
    public class CoordinatesModel
    {
        public CoordinatesModel() 
        {
            Lat = 0f;
            Lng = 0f;
        }
        
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
