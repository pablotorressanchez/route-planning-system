using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Route.Models.Company
{
    public class CompanyModel: BaseCommonModel
    {
        public CompanyModel()
        {
            GroupId = string.Empty;
            GroupName = string.Empty;
            RUC = string.Empty;
            CompanyName = string.Empty;
            CompanyCode = string.Empty;
        }

        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public string RUC { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
    }
}
