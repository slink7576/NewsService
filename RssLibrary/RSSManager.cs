using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssLibrary
{
    public static class RSSManager
    {
        public static List<NewsPresent> Read(string url)
        {
            if(url == null)
            {
                return null;
            }
            var webClient = new WebClient();

            string result = Encoding.UTF8.GetString(webClient.DownloadData(url));


            XDocument document = XDocument.Parse(result);

            return (from descendant in document.Descendants("item")
                    select new NewsPresent()
                    {
                        Title = descendant.Element("title").Value,
                        Description = descendant.Element("description").Value,
                        PublicationDate = DateTime.Parse(descendant.Element("pubDate").Value)
                    }).ToList();
        }
    }

}
