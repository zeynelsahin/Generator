using Generator.Entities.Abstract;

namespace Generator.Entities
{
    public class ObjectResult : IEntity
    {
        public string ProfileId { get; set; }
        public string ObjectId { get; set; }
        public string ResultId { get; set; }
        public string DataType { get; set; }
        public char NullableFlag { get; set; }
    }
}