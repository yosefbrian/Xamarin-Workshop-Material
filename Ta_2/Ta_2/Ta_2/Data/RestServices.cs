using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ta_2.Data
{
    public class RestService : IRestService
    {
        HttpClient client;
        public List<Movie> Items { get; private set; }
        
        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<Movie>> RefreshDataAsync()
        {
            Items = new List<Movie>();
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    XDocument xmlFile = XDocument.Parse(content);
                    var query = from c in xmlFile.Descendants("item") select c;

                    foreach (XElement book in query)
                    {

                        Movie movie = new Movie();
                        movie.Title = book.Element("title").Value;
                        movie.Link2 = book.Element("link").Value;
                        movie.PubDate = book.Element("pubDate").Value;
                        movie.Category = book.Element("category").Value;
                        movie.Guid = book.Element("guid").Value;
                        movie.Description = RemoveHtmlTags(book.Element("description").Value);


                        string image = (string)("<xml>" + IgnoreHtmlTags(book.Element("description").Value) + "</xml>");
                        XElement xe = XElement.Parse(image);
                        var query2 = from c in xe.Descendants("img") select c;
                        foreach (XElement book2 in query2)
                        {
                            movie.ImageUrl = book2.Attribute("src").Value;
                        }
                        Items.Add(movie);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Kesalahan {0}", ex.Message);
            }

            return Items;
      
        }

        string RemoveHtmlTags(string html)
        {
            return Regex.Replace(html, "<.+?>", string.Empty);
        }

        string IgnoreHtmlTags(string html)
        {
            MatchCollection mc = Regex.Matches(html, "<.+?>");
            string data = "";
            foreach (Match m in mc)
            {
                data += m.Value;
            }
            return data;
        }
    }
}
