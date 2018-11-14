using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;

namespace lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            string urlAddress = "https://www.znu.edu.ua/cms/index.php?action=news/view&start=0&site_id=27&lang=ukr";
            Regex regexNews = new Regex("(?s)<div class=\"znu-2016-new-img-list-info\">.+?</div>");

            string result = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                string data = readStream.ReadToEnd();
                Match matchNews = regexNews.Match(data);

                while (matchNews.Success)
                {
                    result = Regex.Replace(matchNews.Value, @"<(.|\n)*?>", string.Empty);
                    //result = Regex.Replace(matchNews.Value, @"<", ".");
                    result = result.Replace("?", "i");
                    Console.WriteLine(result);
                    matchNews = matchNews.NextMatch();
                }

                response.Close();
                readStream.Close();
            }

            Console.ReadKey();
        }
    }
}