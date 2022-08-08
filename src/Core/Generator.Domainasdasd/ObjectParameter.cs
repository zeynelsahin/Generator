using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Entities
{
    public class ObjectParameter
    {
        public string ProfileId { get; set; }
        public string ObjectId { get; set; }
        public string ParameterId { get; set; }
        public string DataType { get; set; }
        public string InputOutput { get; set; }
        public char NullableFlag { get; set; }
    }
}
