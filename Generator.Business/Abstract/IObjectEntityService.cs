using System.Collections.Generic;
using Generator.Entities;

namespace Generator.Business.Abstract
{
    public interface IObjectEntityService
    {
        void Add(ObjectEntity objectEntity);
        List<ObjectEntity> GetAllOrFilter(string objectId = null, string profileId = null, string schemaName = null);
        List<string> GetAllByProfileId(string profileId);
        List<string> GetAllCustomByProfileId(string profileId);
        List<ObjectEntity> GetByProfileId(string profileId);
        List<string> GetAllObjectId();
        List<ObjectEntity> GetByObjectIdContains(string objectId);

        List<string> GetAllProfileId();
        List<string> GetAllSchemaName();
        string GetOracleText(string objectId, string profileId, string schemaName);
        string GetMSSqlText(string objectId, string profileId, string schemaName);
        List<string> GetColumnsName(string tableName);
        List<OracleColumn> GetOracleColumns(string tableName);

        string GetObjectType(string objectId, string profileId);
        List<string> GetTablePrimaryKeyList(string tableName);
    }
}