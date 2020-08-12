using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using ScrapySharp;
using ScrapySharp.Extensions;
using ScrapySharp.Network;

namespace RandomYoutubeLinkGenerator
{
    /// <summary>
    /// Collecting words from 
    /// https://en.wiktionary.org/wiki/Wiktionary:Frequency_lists/PG/2005/08/1-10000
    /// 
    /// 
    /// This Will output araund 90000 words 
    /// It will skip some words with asci characters bigger that u/0080
    /// </summary>
    class GetMostUsedWords
    {

        public List<string> websites = new List<string> {
        "https://en.wiktionary.org/wiki/Wiktionary:Frequency_lists/PG/2005/08/1-10000",
        "https://en.wiktionary.org/wiki/Wiktionary:Frequency_lists/PG/2005/08/10001-20000",
        "https://en.wiktionary.org/wiki/Wiktionary:Frequency_lists/PG/2005/08/20001-30000",
        "https://en.wiktionary.org/wiki/Wiktionary:Frequency_lists/PG/2005/08/30001-40000",
        "https://en.wiktionary.org/wiki/Wiktionary:Frequency_lists/PG/2005/08/40001-50000",
        "https://en.wiktionary.org/wiki/Wiktionary:Frequency_lists/PG/2005/08/50001-60000",
        "https://en.wiktionary.org/wiki/Wiktionary:Frequency_lists/PG/2005/08/60001-70000",
        "https://en.wiktionary.org/wiki/Wiktionary:Frequency_lists/PG/2005/08/70001-80000",
        "https://en.wiktionary.org/wiki/Wiktionary:Frequency_lists/PG/2005/08/80001-90000",
        "https://en.wiktionary.org/wiki/Wiktionary:Frequency_lists/PG/2005/08/90001-100000"



        };
        ScrapingBrowser _brownser = new ScrapingBrowser();
        
        HtmlNode webPage;
        public  List<string> wordsList = new List<string>();
        public GetMostUsedWords()
        {
            
            
        }
        public void Extract(Uri addres)
        {
            webPage = _brownser.NavigateToPage(addres).Html;
            HtmlNode MainContiner = webPage.CssSelect("#mw-content-text").First();
            IEnumerable<HtmlNode> paragraphs = MainContiner.CssSelect("p");
            Console.WriteLine(paragraphs.Count());

            String ZipRegex = @"[^\u0000-\u0080]+";

            foreach (HtmlNode paragraph in paragraphs)
            {
                foreach (HtmlNode alink in paragraph.CssSelect("a"))
                {
                    if (Regex.IsMatch(alink.InnerText,ZipRegex))
                    {
                        Console.Write("\n skipping  :::");
                        Console.Write(alink.InnerText);
                        continue;
                    }
                    wordsList.Add(alink.InnerText);
                }

            }
            Console.WriteLine("Words Count"+" "+wordsList.Count);
        }

    }
}
