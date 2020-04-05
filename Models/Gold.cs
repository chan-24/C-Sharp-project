
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Xml;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace Goldy.Models
{   
    public static class Gold
    {
        public static List<string> cityList = new List<string>();
        public static List<int> oneList = new List<int>();
        public static List<int> twoList = new List<int>();
        public static List<string> dateList = new List<string>();
        public static List<int> one1List = new List<int>();
        public static List<int> two1List = new List<int>();

        public static int large22 = 0;
        public static int large24 = 0;
        public static int small22 = 0;
        public static int small24 = 0;
        public static async void GetHtmlAsync()
        {
            var url = "https://www.goodreturns.in/gold-rates/#Today+24+Carat+Gold+Rate+Per+Gram+in+India+%28INR%29";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var GoldHtml = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("id", "")
                .Equals("moneyweb-container")).ToList();

            var GoldList = GoldHtml[0].Descendants("div")
               .Where(node => node.GetAttributeValue("id", "")
               .Contains("moneyweb-leftPanel")).ToList();

            var GoldListCities = GoldList[0].Descendants("section")
                .ToList();

            var GLC = GoldListCities[2].Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("gold_silver_table")).ToList();

            var ABC = GLC[0].Descendants("table").ToList();
            var AAA = ABC[0].Descendants("tr")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Contains("row")).ToList();

            int count = 1;

            foreach (var AA in AAA)
            {
                foreach (var XYZ in AA.Descendants("td"))
                {
                    if (count % 3 == 1)
                    {
                        var a = (XYZ.InnerText.Replace("&#8377;", "").Trim('\r', '\n', '\t', ' ', ','));
                        cityList.Add(a);
                        Console.WriteLine(a);
                    }

                    if (count % 3 == 2)
                    {
                        string priceNumeric = "";
                        var a = (XYZ.InnerText.Replace("&#8377;", "").Trim('\r', '\n', '\t', ' ', ','));
                        for (int i = 0; i < a.Length; i++)
                        {
                            string ch = a[i] + "";
                            bool isTrue = System.Text.RegularExpressions.Regex.IsMatch(ch, @"\d");

                            if (isTrue)
                            {
                                priceNumeric = priceNumeric + ch;
                            }
                        }

                        int priceInt = System.Convert.ToInt32(priceNumeric);

                        oneList.Add(priceInt);
                        Console.WriteLine(priceInt);
                    }

                    if (count % 3 == 0)
                    {
                        string priceNumeric = "";
                        var a = (XYZ.InnerText.Replace("&#8377;", "").Trim('\r', '\n', '\t', ' ', ','));
                        for (int i = 0; i < a.Length; i++)
                        {
                            string ch = a[i] + "";
                            bool isTrue = System.Text.RegularExpressions.Regex.IsMatch(ch, @"\d");

                            if (isTrue)
                            {
                                priceNumeric = priceNumeric + ch;
                            }
                        }

                        int priceInt = System.Convert.ToInt32(priceNumeric);

                        twoList.Add(priceInt);
                        Console.WriteLine(priceInt);

                    }

                    count++;

                }
                Console.WriteLine();

                foreach(var a in oneList)
                {
                    if(oneList[large22] < a)
                        large22 = oneList.IndexOf(a) ;
                }
                foreach (var a in twoList)
                {
                    if (twoList[large24] < a)
                        large24 = twoList.IndexOf(a);
                }
                foreach (var a in oneList)
                {
                    if (oneList[small22] > a)
                        small22 = oneList.IndexOf(a);
                }
                foreach (var a in twoList)
                {
                    if (twoList[small24] > a)
                        small24 = twoList.IndexOf(a);
                }
            }
        }
        public static async void GetHtmlAsync2()
        {
            var url = "https://www.goodreturns.in/gold-rates/bangalore.html#Gold+Rate+in+Bangalore+for+Last+10+Days+%2810+g%29";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var GoldHtml = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("id", "")
                .Equals("moneyweb-container")).ToList();

            var GoldList = GoldHtml[0].Descendants("div")
               .Where(node => node.GetAttributeValue("id", "")
               .Contains("moneyweb-leftPanel")).ToList();

            var GoldListCities = GoldList[0].Descendants("section")
                .ToList();

            var GLC = GoldListCities[2].Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("gold_silver_table gold_silver_table_10_days")).ToList();

            var ABC = GLC[0].Descendants("table").ToList();
            var AAA = ABC[0].Descendants("tr")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Contains("row")).ToList();
            

            int count = 1;
            foreach (var AA in AAA)
            {
                foreach (var XYZ in AA.Descendants("td"))
                {
                    if (count % 3 == 1)
                    {
                        string date = "";
                        var a = (XYZ.InnerText.Replace("&#8377;", "").Trim('\r', '\n', '\t', ' ', ','));
                        for (int i = 0; i < 6; i++)
                        {
                            string ch = a[i] + "";
                            date = date + ch;
                        }
                        dateList.Add(date);
                        Console.WriteLine(date);
                    }

                    if (count % 3 == 2)
                    {
                        string priceNumeric = "";
                        var a = (XYZ.InnerText.Replace("&#8377;", "").Trim('\r', '\n', '\t', ' ', ','));
                        for (int i = 0; i < 6; i++)
                        {
                            string ch = a[i] + "";
                            bool isTrue = System.Text.RegularExpressions.Regex.IsMatch(ch, @"\d");

                            if (isTrue)
                            {
                                priceNumeric = priceNumeric + ch;
                            }
                        }

                        int priceInt = System.Convert.ToInt32(priceNumeric);

                        one1List.Add(priceInt);
                        Console.WriteLine(priceInt);
                    }

                    if (count % 3 == 0)
                    {
                        string priceNumeric = "";
                        var a = (XYZ.InnerText.Replace("&#8377;", "").Trim('\r', '\n', '\t', ' ', ','));
                        for (int i = 0; i < 6; i++)
                        {
                            string ch = a[i] + "";
                            bool isTrue = System.Text.RegularExpressions.Regex.IsMatch(ch, @"\d");

                            if (isTrue)
                            {
                                priceNumeric = priceNumeric + ch;
                            }
                        }

                        int priceInt = System.Convert.ToInt32(priceNumeric);

                        two1List.Add(priceInt);
                        Console.WriteLine(priceInt);

                    }

                    count++;

                }
                Console.WriteLine();
            }

        }
    }
}
