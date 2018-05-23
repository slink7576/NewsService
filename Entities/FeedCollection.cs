
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Entities
{
    
    public class FeedCollection
    {
        public int Id { get; set; }
        public List<Feed> Feeds { get; set; }
        public FeedCollection()
        {
            Feeds = new List<Feed>();
        }
    }
}