
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Entities
{
    
    [XmlRoot("News")]
    public class NewsPresent
    {
        [XmlAttribute("Title")]
        public string Title { get; set; }
        [XmlAttribute("Description")]
        public string Description { get; set; }
        [XmlAttribute("PublicationDate")]
        public DateTime PublicationDate { get; set; }
        public NewsPresent()
        { }
    }
}