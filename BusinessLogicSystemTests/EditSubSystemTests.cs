using System;

using BusinessLogicLayer.SubSystems;

using BusinessLogicLayer.SubSystemInterfaces;
using UnitOfWorkLayer;
using UnitOfWorkLayer.Repository;
using Entities;
using System.Collections.Generic;

using NUnit.Framework;
using Ninject;

using Ninject.MockingKernel.Moq;
using Ninject.MockingKernel.NSubstitute;
using NSubstitute;
using RssLibrary;

namespace BusinessLogicSystemTests
{
    [TestFixture]
    public class EditSubSystemTests
    {
        IUnitOfWork uow;
        IEditSubSystem ess;
        IKernel kernel = new NSubstituteMockingKernel();
        private void Arrange()
        {
            uow = kernel.Get<IUnitOfWork>();
            ess = new EditSubSystem(uow);
          
        }
        [Test]
        public void CreateTest()
        {
            Arrange();
            Assert.AreEqual(0, ess.Create());
        }
        [Test]
        public void AddRSSFeedTest()
        {
            Arrange();
            var mockFeedCollectionRepository = kernel.Get<IGenericRepository<FeedCollection>>();
            
            var rss = new RSS() { Id = 1, Name = "Before", RssUrl = "urlurl" };
            var feeds = new List<Feed>() { rss };
            var feedColl = new FeedCollection() { Id = 1, Feeds = feeds };
            var mockFeedCollection = new List<FeedCollection>() { feedColl };
            uow.FeedCollectionRepository.Returns(mockFeedCollectionRepository);
            mockFeedCollectionRepository.Get().Returns(mockFeedCollection);
           
            ess.AddRSSFeed(1, "Test", "www.test");
            Assert.AreEqual(feeds.Count, 2);
        }
    }
}
