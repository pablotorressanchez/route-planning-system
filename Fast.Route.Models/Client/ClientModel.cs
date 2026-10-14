using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Route.Models.Client
{
    public class ClientModel: BaseCommonModel
    {
        public ClientModel()
        {
            ProgramId = string.Empty;
            ProgramName = string.Empty;
            IdentificationTypeId = string.Empty;
            IdentificationTypeName = string.Empty;
            DocumentNumber = string.Empty;
            Name = string.Empty;
            Address = string.Empty;
            PhoneNumber = string.Empty;
            Email = string.Empty;
            Lat = 0f;
            Lng = 0f;
        }
        public string ProgramId { get; set; }
        public string ProgramName { get; set; }
        public string IdentificationTypeId { get; set; }
        public string IdentificationTypeName { get; set; }
        public string DocumentNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Lat { get; set; }
        public float Lng { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
