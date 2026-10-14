namespace Fast.Route.Models
{
    public abstract class BaseModel
    {
        protected BaseModel()
        {
            UniqueId = Guid.NewGuid().ToString().ToUpper();
            IsActive = true;
            Op = 1;
        }

        public int Op { get; set; }
        public string UniqueId { get; set; }
        public bool IsActive { get; set; }
        public bool ShowUniqueId => !string.IsNullOrEmpty(UniqueId);
        public string IsActiveValue => IsActive ? "ACTIVO" : "INACTIVO";
    }
}
