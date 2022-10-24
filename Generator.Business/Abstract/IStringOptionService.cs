using System.Collections.Generic;
using Generator.Entities;

namespace Generator.Business.Abstract
{
    public interface IStringOptionService
    {
        void Add(StringOption stringOption);
        List<StringOption> GetAll();
        StringOption Get(string languageId, string keyId);
    }
}