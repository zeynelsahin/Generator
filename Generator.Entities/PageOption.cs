using Generator.Entities.Abstract;

namespace Generator.Entities
{
    public class PageOption : IEntity
    {
        public string DomainId { get; set; }
        public string Environment { get; set; }
        public string ApplicationId { get; set; }
        public string PageId { get; set; }
        public string Name { get; set; }
        public char ValidFlag { get; set; }
    }
}