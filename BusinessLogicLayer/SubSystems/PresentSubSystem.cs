
using BusinessLogicLayer.SubSystemInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Entities;
using UnitOfWorkLayer;
using System.Web.Caching;

namespace BusinessLogicLayer.SubSystems
{
    public class PresentSubSystem : IPresentSubSystem
    {
        IUnitOfWork uow;
       
        public PresentSubSystem(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public List<List<NewsPresent>> ReadNews(int id)
        {
            try
            {
               
                return uow.FeedCollectionRepository.Get().FirstOrDefault(c => c.Id == id).Feeds.Select(g => g.GetNews()).ToList();
            }
            catch(Exception c)
            {
                return null;
            }
            
        }
    }
}