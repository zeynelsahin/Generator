using System;
using System.Collections.Generic;
using System.Text;
using Generator.Entities.Abstract;

namespace Generator.Entities
{
    public class ServiceMethod : IEntity
    {
        public string ProfileId { get; set; }
        public string ObjectId { get; set; }
        public string ClassType { get; set; }
        public char GetMethodFlag { get; set; }
        public char GetValidMethodFlag { get; set; }
        public char GetPagedMethodFlag { get; set; }
        public char GetPrimaryKeyMethodFlag { get; set; }
        public char DeleteMethodFlag { get; set; }
        public char CreateMethodFlag { get; set; }
        public char ModifyMethodFlag { get; set; }
        public char CustomMethodFlag { get; set; }
        public char IndexMethodFlag { get; set; }
        public char OnlyEntityFlag { get; set; }
    }
}