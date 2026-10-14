using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Route.Models.Common
{
    public class IdentificationTypeModel
    {
        public IdentificationTypeModel() 
        {
            IdentificationTypeId = string.Empty;
            IdentificationTypeName = string.Empty;
            DocumentNumber = string.Empty;
        }

        public string IdentificationTypeId { get; set; }
        public string IdentificationTypeName { get; set; }
        public string DocumentNumber { get; set; }
    }
}
