using System.Collections.Generic;
using Generator.Business.Abstract;
using Generator.DataAccess.Abstract;
using Generator.Entities;

namespace Generator.Business.Concrete
{
    public class StringOptionService : IStringOptionService
    {
        private readonly IStringOptionDal _stringOptionDal;

        public StringOptionService(IStringOptionDal stringOptionDal)
        {
            _stringOptionDal = stringOptionDal;
        }

        public void Add(StringOption stringOption)
        {
            _stringOptionDal.Add(stringOption);
        }

        public List<StringOption> GetAll()
        {
            return _stringOptionDal.GetAll();
        }

        public StringOption Get(string languageId, string keyId)
        {
            var result = _stringOptionDal.Get(p => p.LanguageId == languageId && p.KeyId == keyId);
            return result;
        }
    }
}