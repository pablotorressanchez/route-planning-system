using Fast.Route.Models;

namespace Fast.Route.Models.Program
{
    public class ProgramModel: BaseCommonModel
    {
        public ProgramModel()
        {
            EnterpriseId = string.Empty;
            EnterpriseName = string.Empty;
            Description = string.Empty;
            ProgramDate = DateTime.Now;
            Status = 1;
        }
        public string EnterpriseId { get; set; }
        public string EnterpriseName { get; set; }
        public string Description { get; set; }
        public DateTime ProgramDate { get; set; }
        public int NumberOfClients { get; set; }
        public EnumTravelMode TransportMode { get; set; }
        public int NumberOfRoutes { get; set; }
        public int Status { get; set; }

        public string TransportModeDescription
        {
            get
            {
                string TrasportModeDesc = "OTROS";
                switch (TransportMode)
                {
                    case EnumTravelMode.Driving: TrasportModeDesc = "DRIVING"; break;
                    case EnumTravelMode.Bicycling: TrasportModeDesc = "BICYCLING"; break;
                    case EnumTravelMode.Transit: TrasportModeDesc = "TRANSIT"; break;
                    case EnumTravelMode.Walking: TrasportModeDesc = "WALKING"; break;
                }
                return TrasportModeDesc;
            }
        }
        public string StatusDescription
        {
            get
            {
                string statusDesc = "OTROS";
                switch (Status)
                {
                    case 1: statusDesc = "PENDIENTE"; break;
                    case 2: statusDesc = "EN EJECUCIÓN"; break;
                    case 3: statusDesc = "COMPLETADO"; break;
                    case 4: statusDesc = "CANCELADO"; break;
                }
                return statusDesc;
            }
        }
    }

    public enum EnumTravelMode
    {
        Driving = 0,
        Bicycling = 1,
        Transit = 2,
        Walking = 3
    }
}
