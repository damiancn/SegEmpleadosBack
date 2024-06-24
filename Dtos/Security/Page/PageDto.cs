namespace Dtos.Security.Page
{
    public class PageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Code { get; set; }
        public Guid Fk_Menu { get; set; }
        public string MenuName { get; set; }
        public bool Active { get; set; }

    }
}
