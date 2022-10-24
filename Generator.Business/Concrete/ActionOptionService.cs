using System.Collections.Generic;
using Generator.Business.Abstract;
using Generator.DataAccess.Abstract;
using Generator.Entities;

namespace Generator.Business.Concrete
{
    public class ActionOptionService : IActionOptionService
    {
        private readonly IActionOptionDal _actionOptionDal;

        public ActionOptionService(IActionOptionDal actionOptionDal)
        {
            _actionOptionDal = actionOptionDal;
        }

        public void Add(ActionOption actionOption)
        {
            _actionOptionDal.Add(actionOption);
        }

        public List<ActionOption> GetAll(string domainId, string environment, string applicationId, string actionId)
        {
            return _actionOptionDal.GetAll(a =>
                a.DomainId == domainId && a.Environment == environment && a.ApplicationId == applicationId &&
                a.ActionId == actionId);
        }

        public ActionOption Get(string domainId, string environment, string applicationId, string actionId)
        {
            var result = _actionOptionDal.Get(p =>
                p.ActionId == actionId && p.Environment == environment && p.DomainId == domainId &&
                p.ApplicationId == applicationId);
            return result;
        }
    }
}