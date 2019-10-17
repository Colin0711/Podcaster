using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Podcaster_Projekt.Model
{
    public class RssInformation
    {
        public string Title;
        public string PublicationDate;
        public string Description;
        public string Length;
    }

    public class RssReader
    {
        public static  List<RssInformation> Read(string url)
        {
            var webClient = new WebClient();
            webClient.Headers.Add("Podcaster by Volkan Javuz, Teja Finkbeiner, Colin Rieger");

            string xmlData = webClient.DownloadString(url);

            XDocument xml = XDocument.Parse(xmlData);

            var Feed = (from descendant in xml.Descendants("item")
                        select new RssInformation()
                        {
                            Description = descendant.Element("description").Value,
                            Title = descendant.Element("title").Value,
                            PublicationDate = descendant.Element("pubDate").Value,
                            Length = descendant.Element("length").Value,
                    }).ToList();

            return Feed;
        }

        public class GetRssFeed
        {
            public List<RssInformation> RSSFeed { get; set; }
        }
    }
}
