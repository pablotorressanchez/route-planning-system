using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Route.Models.RouteSequence
{
    public class ClusterModel: PointModel
    {
        public ClusterModel() => Points = new();
        public List<PointModel> Points { get; set; }
    }
}
