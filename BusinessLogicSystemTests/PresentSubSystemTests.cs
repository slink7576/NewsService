using BusinessLogicLayer.SubSystemInterfaces;
using BusinessLogicLayer.SubSystems;
using Entities;
using Ninject;
using Ninject.MockingKernel.NSubstitute;
using NSubstitute;
using NUnit.Framework;
using RssLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnitOfWorkLayer;
using UnitOfWorkLayer.Repository;

namespace BusinessLogicSystemTests
{
    [TestFixture]
    public class PresentSubSystemTests
    {
        IUnitOfWork uow;
        IPresentSubSystem prss;
        IKernel kernel = new NSubstituteMockingKernel();
        private void Arrange()
        {
            uow = kernel.Get<IUnitOfWork>();
            prss = new PresentSubSystem(uow);
        }
        [Test]
        public void ReadNewsTest()
        {
            Arrange();
            var presentView = new List<NewsPresent>() { new NewsPresent() { Description = "Desc", Title = "Title", PublicationDate = DateTime.Now } };
            var mockFeedCollectionRepository = kernel.Get<IGenericRepository<FeedCollection>>();
            uow.FeedCollectionRepository.Returns(mockFeedCollectionRepository);
            var mockRSS = new RSS() {  Id = 1, Name = "Name", RssUrl = "http://fakty.ua/rss_feed/ukraina" }; 
            
            mockFeedCollectionRepository.Get().Returns(new List<FeedCollection>() { new FeedCollection()
            {  Id = 1, Feeds = new List<Feed>() { mockRSS } } });
            var newsPres = new NewsPresent() { Description = "info", Title = "title", PublicationDate = DateTime.Now };
            var backList = new List<NewsPresent>() { newsPres };
            Assert.AreNotEqual(prss.ReadNews(1).Count, 20);
        }
        
    }
}