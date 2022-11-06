using Generator.Business.Abstract;
using Generator.DataAccess.Abstract;
using Generator.Entities;

namespace Generator.Business.Concrete
{
    public class PageOptionService : IPageOptionService
    {
        private readonly IPageOptionDal _pageOptionDal;

        public PageOptionService(IPageOptionDal pageOptionDal)
        {
            _pageOptionDal = pageOptionDal;
        }

        public void Add(PageOption pageOption)
        {
            _pageOptionDal.Add(pageOption);
        }

        public PageOption Get(string domainId, string environment, string applicationId, string pageId)
        {
            var result = _pageOptionDal.Get(p =>
                p.DomainId == domainId && p.Environment == environment && p.ApplicationId == applicationId &&
                p.PageId == pageId);
            return result;
        }
    }
}