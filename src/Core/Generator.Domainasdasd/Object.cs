using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Entities
{
    public class Object
    {
        public char ValidFlag { get; set; }
        public char GenerateUIFlag { get; set; }
        public string UIPathSuffix { get; set; }
        public string ObjectId { get; set; }
        public string ObjectType { get; set; }
        public string ProfileId { get; set; }
        public string RepositoryName { get; set; }
        public string SchemaName { get; set; }
        public string OracleSchemaName { get; set; }
        public string Text { get; set; }
        public string OracleText { get; set; }
        public char ResultCollectionFlag { get; set; }
        public char SpcallFlag { get; set; }
        public char IgnoreDefaultColumnsFlag { get; set; }
        public char LocalTransactionFlag { get; set; }
        public char CustomPagedFlag { get; set; }
    }
}
