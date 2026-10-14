namespace Fast.Route.Models.L.Routing
{
    public class LineOptionsModel
    {
        public LineOptionsModel() 
        {
            Styles = new() { new(), new() };
            MissingRouteStyles = new() { new(), new() };
        }
        public List<StylesModel> Styles { get; set; }
        public List<StylesModel> MissingRouteStyles { get; set; }
    }
}
