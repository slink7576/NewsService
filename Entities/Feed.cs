using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Entities
{
    
    public abstract class Feed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public abstract List<NewsPresent> GetNews();
        public Feed( string name)
        {

            Name = name;

        }
        public Feed()
        {

        }
   }
}