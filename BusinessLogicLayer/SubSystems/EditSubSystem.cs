
using BusinessLogicLayer.SubSystemInterfaces;
using Entities;
using RssLibrary;
using System.Linq;
using UnitOfWorkLayer;

namespace BusinessLogicLayer.SubSystems
{
    public class EditSubSystem : IEditSubSystem
    {
        IUnitOfWork uow;
     
        public EditSubSystem(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public int Create()
        {
            var item = new FeedCollection();
            uow.FeedCollectionRepository.Insert(item);
            uow.Save();
            return item.Id;
             
        }
        public bool AddRSSFeed(int id, string name, string feedurl)
        {
            
            var item = uow.FeedCollectionRepository.Get().FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                item.Feeds.Add(new RSS(name, feedurl));
                uow.Save();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}