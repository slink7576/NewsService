using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface ISystemFacade
    {
        int Create();
        List<List<NewsPresent>> ReadNews(int id);
        bool AddFeed(int id, string name, string feedurl);
    }
}
