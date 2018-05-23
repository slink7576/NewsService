namespace DataAccessLayer
{
    using Entities;
    using RssLibrary;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class NewsModel : DbContext
    {
        // Контекст настроен для использования строки подключения "NewsModel" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "DataAccessLayer.NewsModel" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "NewsModel" 
        // в файле конфигурации приложения.
        public NewsModel()
            : base("name=NewsModel")
        {
            Database.SetInitializer(new CustomDbInitiaslizer());
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<FeedCollection> FeedCollections { get; set; }
        public virtual DbSet<RSS> Feeds { get; set; }
        public class CustomDbInitiaslizer : DropCreateDatabaseAlways<NewsModel>
        {
            protected override void Seed(NewsModel context)
            {
                var rss1 = new RSS("Sport news", "http://fakty.ua/rss_feed/sport");
                var rss2 = new RSS("Society news", " http://fakty.ua/rss_feed/society");
                var collection = new FeedCollection();
                var feeds = new List<Feed>();
                feeds.Add(rss1);
                feeds.Add(rss2);
                collection.Feeds = feeds;
                context.FeedCollections.Add(collection);
                context.SaveChanges();
            }
        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}