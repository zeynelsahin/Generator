using System;
using System.Collections.Generic;
using System.Text;
using Generator.Entities.Abstract;

namespace Generator.Entities
{
    public class ObjectParameter: IEntity
    {
        public string ProfileId { get; set; }
        public string ObjectId { get; set; }
        public string ParameterId { get; set; }
        public string DataType { get; set; }
        public string InputOutput { get; set; }
        public char NullableFlag { get; set; }
    }
}
