namespace Dtos.Security.Menu
{
    public class MenuDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
    }
}
