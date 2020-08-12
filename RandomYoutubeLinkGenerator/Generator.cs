using System;
using System.Collections.Generic;
using ScrapySharp;
using ScrapySharp.Network;
using System.Text.Json;
using System.IO;

namespace RandomYoutubeLinkGenerator
{
    class Generator
    {
        static void Main(string[] args)
        {
            


        }
        /// <summary>
        /// Get Words and save it in Json format.
        /// </summary>
        private void GetWords()
        {
            GetMostUsedWords words = new GetMostUsedWords();
            RandomSerachKeyWordApi randomSerachKeyWord = new RandomSerachKeyWordApi();
            foreach (string page in words.websites)
            {
                words.Extract(new Uri(page));

            }
            string json = JsonSerializer.Serialize(words.wordsList);
            File.WriteAllText(System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/json.txt", json);
        }
        void BrutalForce()
        {
            ScrapingBrowser scrapingBrowser = new ScrapingBrowser();
            BrutalForceString brutalForceString = new BrutalForceString();
            ByRandomNambers byRandomNambers = new ByRandomNambers();

            List<string> codes = new List<string>();

            for (int i = 0; i < 10000; i++)
            {

                string id = byRandomNambers.Next();

                if (codes.Contains(id))
                {
                    Console.WriteLine("Trying again");

                    id = byRandomNambers.Next();
                }
                codes.Add(id);
                Uri url = new Uri("https://www.youtube.com/watch?v=" + id);
                //Uri url = new Uri("https://www.youtube.com/watch?v=Mvsb_Z1Xorw");
                var Website = scrapingBrowser.NavigateToPage(url).Html;
                if (Website.OuterHtml.Contains("var meta"))
                {
                    Console.WriteLine("Errror  " + id);
                    if (i % 15 == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("TRY nr: " + i);
                    }

                }
                else
                {
                    Console.WriteLine(id);
                    break;
                }
            }
        }
    }
}
