using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Generator.Entities.Abstract;

namespace Generator.Entities
{
    public class ObjectEntity : IEntity
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