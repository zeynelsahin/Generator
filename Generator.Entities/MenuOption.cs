using Generator.Entities.Abstract;

namespace Generator.Entities
{
    public class MenuOption : IEntity
    {
        public string DomainId { get; set; }
        public string Environment { get; set; }
        public string ApplicationId { get; set; }
        public string MenuId { get; set; }
        public string ParentMenuId { get; set; }
        public string PageId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int SortId { get; set; }
        public char ValidFlag { get; set; }
    }
}