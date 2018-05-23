using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BusinessLogicLayer.SubSystemInterfaces
{
    public interface IPresentSubSystem
    {
        List<List<NewsPresent>> ReadNews(int id);
    }
}
