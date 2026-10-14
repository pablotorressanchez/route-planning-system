namespace Fast.Route.Models.Common
{
    public class ParameterModel : BaseModel
    {
        public ParameterModel()
        {
            StatusId = 0;
            Description = String.Empty;
        }
        public int StatusId { get; set; }
        public string Description { get; set; }
    }
}
