using Fast.Route.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Route.Models.App
{
    public class SelectFieldModel : InputFieldModel
    {
        public SelectFieldModel() : base()
        {
            Type = InputFieldType.Select;
            Options = new();
            Order = 1;
        }

        public int Order { get; set; }
        public List<SelectValueModel> Options { get; set; }
    }
}
