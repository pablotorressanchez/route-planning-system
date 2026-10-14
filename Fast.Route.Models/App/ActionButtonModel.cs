  namespace Fast.Route.Models.App
{
    public class ActionButtonModel
    {
        public ActionButtonModel()
        {
            TextColor = "amber";
            _icon = "";
            Type = ButtonType.New;
            Label = string.Empty;
            Size = ButtonSize.Medium;
            ShowLabel = true;
            Style = String.Empty;
            Id = string.Empty;
        }

        public string TextColor { get; set; }

        private string _icon;
        public string Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = $"bx bx-{value}";
            }
        }

        public string Label { get; set; }

        public ButtonType Type { get; set; }

        public ButtonSize Size { get; set; }

        public bool ShowLabel { get; set; }

        public string Style { get; set; }

        public string Id { get; set; }

        public string IsSubmit => Type == ButtonType.Submit ? "submit" : "button";

        public string? OnClick { get; set; }

        public string? Resource { get; set; }

    }

    public enum ButtonSize
    {
        EstraSmall,
        Small,
        Medium
    }

    public enum ButtonType
    {
        New,
        Acept,
        Edit,
        Close,
        Cancel,
        Submit,
        Bordered,
        Ghost,
        Icon
    }
}
