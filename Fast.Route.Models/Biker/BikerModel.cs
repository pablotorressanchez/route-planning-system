using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Route.Models.Biker
{
    public class BikerModel: BaseCommonModel
    {
        public BikerModel()
        {
            EnterpriseId = string.Empty;
            EnterpriseName = string.Empty;
            IdentificationTypeId = string.Empty;
            IdentificationTypeName = string.Empty;
            DocumentNumber = string.Empty;
            Name = string.Empty;
            Address = string.Empty;
            PhoneNumber = string.Empty;
            Email = string.Empty;
        }
        public string EnterpriseId { get; set; }
        public string EnterpriseName { get; set; }
        public string IdentificationTypeId { get; set; }
        public string IdentificationTypeName { get; set; }
        public string DocumentNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
