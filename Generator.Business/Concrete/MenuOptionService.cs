using System.Collections.Generic;
using Generator.Business.Abstract;
using Generator.DataAccess.Abstract;
using Generator.Entities;

namespace Generator.Business.Concrete
{
    public class MenuOptionService : IMenuOptionService
    {
        private readonly IMenuOptionDal _menuOptionDal;

        public MenuOptionService(IMenuOptionDal menuOptionDal)
        {
            _menuOptionDal = menuOptionDal;
        }

        public void Add(MenuOption menuOption)
        {
            _menuOptionDal.Add(menuOption);
        }

        public List<MenuOption> GetAll()
        {
            return _menuOptionDal.GetAll(p => p.DomainId == "UXLocal");
        }

        public MenuOption Get(string domainId, string environment, string applicationId, string menuId)
        {
            var result = _menuOptionDal.Get(p =>
                p.DomainId == domainId && p.Environment == environment && p.ApplicationId == applicationId &&
                p.MenuId == menuId);
            return result;
        }
    }
}