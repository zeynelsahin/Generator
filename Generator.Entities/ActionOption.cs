using Generator.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generator.Entities
{
    [Table("UX_ACTION_OPTION")]
    public class ActionOption: IEntity
    {
        public string DomainId { get; set; }
        public string Environment { get; set; }
        public string ApplicationId  { get; set; }
        public string ActionId { get; set; }
        public string ServiceActionName { get; set; }
        public string Description { get; set; }
        public char ValidFlag { get; set; }
        public string ServiceId { get; set; }
    }
}