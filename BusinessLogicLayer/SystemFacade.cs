using BusinessLogicLayer.SubSystemInterfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace BusinessLogicLayer
{
    public class SystemFacade : ISystemFacade
    {
        IEditSubSystem ess;
        IPresentSubSystem prss;
        ILoggingSubSystem logss;
        Cache cache;
        public SystemFacade(IEditSubSystem ess, IPresentSubSystem prss, ILoggingSubSystem logss)
        {
            this.ess = ess;
            this.prss = prss;
            this.logss = logss;
            cache = new Cache();
        }


        public int Create()
        {
            
            int id = ess.Create();
            logss.RecordAction("Created new feed collection with id: " + id);
            return id;
        }

        public List<List<NewsPresent>> ReadNews(int id)
        {
            logss.RecordAction("Someone read news from collection with id: " + id);
            if (cache.Get(id.ToString()) != null)
            {
              
                return (List<List<NewsPresent>>)cache.Get(id.ToString());
            }
            else
            {
                if(prss.ReadNews(id)!=null)
                {
                    cache.Insert(id.ToString(), prss.ReadNews(id));
                    return (List<List<NewsPresent>>)cache.Get(id.ToString());
                }
                else
                {
                    return null;
                }
                
               
            }
            
        }

        public bool AddFeed(int id, string name, string feedurl)
        {
            logss.RecordAction("Someone added new feed: " + feedurl + " to collection with id: " + id);
            return ess.AddRSSFeed(id, name, feedurl);
        }
    }
}
