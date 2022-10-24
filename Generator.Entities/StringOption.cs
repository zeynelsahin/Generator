using System.ComponentModel.DataAnnotations.Schema;
using Generator.Entities.Abstract;

namespace Generator.Entities
{
    [Table("UX_STRING_OPTION")]
    public class StringOption : IEntity
    {
        public string LanguageId { get; set; }
        public string KeyId { get; set; }
        public string Value { get; set; }
    }
}