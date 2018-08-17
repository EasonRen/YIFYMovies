using System;
using HtmlAgilityPack;

namespace YIFYMovies
{
    class Program
    {
        public const string FILEPATH = @"C:\Users\eason.ren\Downloads\YIFY Movies Release in 2018 - yify-torrent.org.html";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            HtmlDocument doc = new HtmlDocument();
            doc.Load(FILEPATH);

            //解析年份
            HtmlNodeCollection yearNodes = doc.DocumentNode.SelectNodes("//fieldset[@id='g1']/label");
            if (yearNodes != null)
            {
                foreach (var item in yearNodes)
                {
                    HtmlNode htmlNode = item.SelectSingleNode(".//input");

                    if (htmlNode != null)
                    {
                        Console.WriteLine($"Year:{htmlNode.Attributes["value"].Value}");
                        Console.WriteLine("");
                    }
                }
            }

            //解析页数
            HtmlNode pageNode = doc.DocumentNode.SelectSingleNode("//ul[@class='pagination']/li[last()]/a");
            if (pageNode != null)
            {
                string[] pages = pageNode.Attributes["href"].Value.Split('/');

                Console.WriteLine($"total pages:{pages[pages.Length - 2].Replace("t-", "")}");
            }

            //解析电影
            HtmlNodeCollection htmlNodes = doc.DocumentNode.SelectNodes("//article[@class='img-item']");
            if (htmlNodes != null)
            {
                foreach (var item in htmlNodes)
                {
                    HtmlNode htmlNode = item.SelectSingleNode(".//a[@class='movielink']");

                    if (htmlNode != null)
                    {
                        Console.WriteLine($"Name:{htmlNode.InnerText}");
                        Console.WriteLine($"_ _ _ _ _ _ _");
                        Console.WriteLine($"Url:{htmlNode.Attributes["href"].Value}");
                        Console.WriteLine($"_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _");
                        Console.WriteLine("");
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
