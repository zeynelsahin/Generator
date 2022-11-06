using System.Collections.Generic;
using Generator.Entities;

namespace Generator.Business.Abstract
{
    public interface IMenuOptionService
    {
        void Add(MenuOption menuOption);
        List<MenuOption> GetAll();
        MenuOption Get(string domainId, string environment, string applicationId, string menuId);
    }
}