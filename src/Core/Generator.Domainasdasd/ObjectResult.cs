using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Entities
{
    public class ObjectResult
    {
        public string ProfileId { get; set; }
        public string ObjectId { get; set; }
        public string ResultId { get; set; }
        public string DataType { get; set; }
        public char NullableFlag { get; set; }
    }
}
