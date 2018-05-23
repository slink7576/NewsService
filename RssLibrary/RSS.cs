using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RssLibrary
{
    public class RSS : Feed
    {
        public RSS(string name, string rssUrl) : base(name)
        {
            RssUrl = rssUrl;

        }
        public RSS()
        {


        }

        public string RssUrl { get; set; }

        public override List<NewsPresent> GetNews()
        {
            return RSSManager.Read(RssUrl);
        }
    }
}