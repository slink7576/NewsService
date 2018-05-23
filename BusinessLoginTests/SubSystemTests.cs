using System;
using Ninject;
using NinjectConfigurationModule;
using BusinessLogicLayer.SubSystemInterfaces;
using NUnit.Framework;
using Ninject.MockingKernel;
using UnitOfWorkLayer;
using BusinessLogicLayer.SubSystems;
using Entities;
using UnitOfWorkLayer.Repository;

using RssLibrary;
using System.Collections.Generic;
using Ninject.MockingKernel.NSubstitute;
using NSubstitute;

namespace BusinessLoginTests
{
    [TestFixture]
    public class SubSystemTests
    {
        IEditSubSystem editSubSys;
        IUnitOfWork mockUnitOfWork;
        IKernel kernel = new NSubstituteMockingKernel();
        [Test]
        public void CreateTest()
        {
            Arrange();
            
            Assert.AreEqual(0, editSubSys.Create());
        }
        [Test]
        public void AddRSSFeedTest()
        {
            
            var mockFeedCollRepository = Substitute.For<IGenericRepository<FeedCollection>>();
            var feed = new RSS() { Id = 1, Name = "Zero", RssUrl = "123" };
            var listoffeeds = new List<Feed>() { feed };

            FeedCollection coll = new FeedCollection() { Feeds = listoffeeds, Id = 0 };
            mockFeedCollRepository.Get().Returns(coll);
            editSubSys.AddRSSFeed(0, "test", "www.test");

        }
        private void Arrange()
        {
            mockUnitOfWork = kernel.Get<IUnitOfWork>();
            editSubSys = new EditSubSystem(mockUnitOfWork);
        }
     }
}
