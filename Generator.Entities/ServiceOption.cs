using Generator.Entities.Abstract;

namespace Generator.Entities
{
    public class ServiceOption : IEntity
    {
        public string DomainId { get; set; }
        public string Environment { get; set; }
        public string ServiceId { get; set; }
    }
}