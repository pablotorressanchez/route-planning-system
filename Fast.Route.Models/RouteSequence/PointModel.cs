using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Fast.Route.Models.RouteSequence
{
    public class PointModel: LocationModel
    {
        public PointModel() 
        {
            ClusterId = Guid.NewGuid().ToString().ToUpper();
            ResourceId = string.Empty;
            CentroDistanceId = 0;
        }
        public string ClusterId { get; set; }
        public string ResourceId { get; set; }
        public double CentroDistanceId { get; set; }

    }
}
