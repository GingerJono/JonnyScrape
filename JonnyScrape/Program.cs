using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Web;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;

namespace JonnyGetVids
{
    public class Scrapes
    {
        private HtmlAgilityPack.HtmlDocument GetURLAsDoc(string URL)
        {
            string HTMLPage;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            WebResponse objResponse;

            var surl = URL;

            var url = new Uri(surl);
            Console.WriteLine("Broken: " + url.ToString());

            MethodInfo getSyntax = typeof(UriParser).GetMethod("GetSyntax", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            FieldInfo flagsField = typeof(UriParser).GetField("m_Flags", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (getSyntax != null && flagsField != null)
            {
                foreach (string scheme in new[] { "http", "https" })
                {
                    UriParser parser = (UriParser)getSyntax.Invoke(null, new object[] { scheme });
                    if (parser != null)
                    {
                        int flagsValue = (int)flagsField.GetValue(parser);
                        // Clear the CanonicalizeAsFilePath attribute
                        if ((flagsValue & 0x1000000) != 0)
                            flagsField.SetValue(parser, flagsValue & ~0x1000000);
                    }
                }
            }

            url = new Uri(surl);

            WebRequest objRequest = HttpWebRequest.Create(surl);

            try
            {
                objRequest.Proxy = null;
                objResponse = objRequest.GetResponse();

                using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
                {
                    HTMLPage = sr.ReadToEnd();
                    sr.Close();
                }

                doc.LoadHtml(HTMLPage);
                return doc;
            }
            catch (Exception ex)
            {
                doc.LoadHtml("<html>" + ex.ToString() + "</html>");
                return doc;
            }
        }

        private string NormaliseURL(string URL)
        {
            string FixedURL;

            if (URL.Contains("://"))
            {
                FixedURL = URL;
            }
            else
            {
                FixedURL = "http://" + URL;
            }

            return FixedURL;
        }

        public List<string> GetLengthOfHTMLPages(List<string> InputURLs)
        {
            List<string> output = new List<string>();

            string FixedURL;

            foreach (string URL in InputURLs)
            {
                FixedURL = NormaliseURL(URL);

                try
                {
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc = GetURLAsDoc(FixedURL);
                    output.Add(FixedURL + ": " + doc.DocumentNode.InnerHtml.Length.ToString());
                }
                catch (Exception ex)
                {
                    output.Add(FixedURL + ": ERROR! " + ex.ToString());
                }
            }

            return output;
        }

        public List<string> GetPGNFromCGComCollection(List<string> InputURLs)
        {
            List<string> output = new List<string>();

            foreach (string URL in InputURLs)
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                HtmlAgilityPack.HtmlDocument doc2 = new HtmlAgilityPack.HtmlDocument();
                HtmlAgilityPack.HtmlNodeCollection nodes;

                doc = GetURLAsDoc(URL);
                nodes = doc.DocumentNode.SelectNodes("//body/center[1]/table//center[3]//a");

                foreach (HtmlAgilityPack.HtmlNode node in nodes)
                {
                    doc2 = GetURLAsDoc("http://www.chessgames.com" + node.Attributes["href"].Value.ToString());
                    HtmlAgilityPack.HtmlNode node2 = doc2.DocumentNode.SelectSingleNode("//textarea[@id='pgnText']");
                    output.Add(node2.InnerHtml);
                }
            }

            return output;
        }

        public List<string> GetGamePGNFromCGCom(List<string> InputURLs)
        {
            List<string> output = new List<string>();
            try
            {

                foreach (string URL in InputURLs)
                {
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    HtmlAgilityPack.HtmlNodeCollection nodes;

                    doc = GetURLAsDoc(URL.Replace("chessgame?","nph-chesspgn?text=1&"));

                    output.Add(doc.DocumentNode.InnerHtml.ToString());
                }
            }

            catch (Exception ex)
            {
                output.Add(ex.ToString());
            }

            return output;
        }

        public List<string> GetVideoTitlesFromAmazon(List<string> InputURLs)
        {
            List<string> output = new List<string>();
            try
            {
                foreach (string URL in InputURLs)
                {
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    HtmlAgilityPack.HtmlNodeCollection nodes;

                    doc = GetURLAsDoc(URL);

                    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@id='atfResults']/div/h3"))
                    {
                        output.Add(node.ChildNodes[1].InnerText + ";" + node.ChildNodes[3].InnerText);
                    }

                    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@id='btfResults']/div/h3"))
                    {
                        output.Add(node.ChildNodes[1].InnerText + ";" + node.ChildNodes[3].InnerText);
                    }
                }
            }

            catch (Exception ex)
            {
                output.Add(ex.ToString());
            }

            return output;
        }

        public List<string> GetTomatoScore(List<string> InputURLs)
        {
            List<string> output = new List<string>();
            try
            {
                foreach (string URL in InputURLs)
                {
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    HtmlAgilityPack.HtmlNodeCollection nodes;

                    doc = GetURLAsDoc(URL);

                    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@id='atfResults']/div/h3"))
                    {
                        output.Add(node.ChildNodes[1].InnerText + ";" + node.ChildNodes[3].InnerText);
                    }

                    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@id='btfResults']/div/h3"))
                    {
                        output.Add(node.ChildNodes[1].InnerText + ";" + node.ChildNodes[3].InnerText);
                    }
                }
            }

            catch (Exception ex)
            {
                output.Add(ex.ToString());
            }

            return output;
        }

        public List<string> GetTomatoInfo(List<string> InputURLs)
        {
            List<string> output = new List<string>();
            try
            {
                foreach (string URL in InputURLs)
                {
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    HtmlAgilityPack.HtmlDocument doc2 = new HtmlAgilityPack.HtmlDocument();

                    doc = GetURLAsDoc("http://www.rottentomatoes.com/search/?search=" + URL.Replace(" ", "+") + "&sitesearch=rt");
                    HtmlNode node = doc.DocumentNode.SelectSingleNode("//div[@class='media_block_content']/h3/a");

                    if (node != null)
                    {
                        doc2 = GetURLAsDoc("http://www.rottentomatoes.com/" + node.Attributes["href"].Value);

                        string outputBuild = "";
                        outputBuild = outputBuild + doc2.DocumentNode.SelectSingleNode("//span[@itemprop='name']").InnerText + ";";
                        outputBuild = outputBuild + doc2.DocumentNode.SelectSingleNode("//span[@itemprop='ratingValue']").InnerText + " per cent;";
                        outputBuild = outputBuild + doc2.DocumentNode.SelectSingleNode("//span[@itemprop='reviewCount']").InnerText + " reviews;";
                        outputBuild = outputBuild + doc2.DocumentNode.SelectSingleNode("//time[@itemprop='duration']").InnerText + ";";

                        foreach (HtmlNode node2 in doc2.DocumentNode.SelectNodes("//span[@itemprop='genre']"))
                        {
                            outputBuild = outputBuild + node2.InnerText + ",";
                        }

                        outputBuild = outputBuild + ";";
                        outputBuild = outputBuild + Regex.Replace(doc2.DocumentNode.SelectSingleNode("//p[@id='movieSynopsis']").InnerText.Substring(0, Math.Max(0, doc2.DocumentNode.SelectSingleNode("//p[@id='movieSynopsis']").InnerText.IndexOf("$"))), @"\r\n?|\n", "").Replace("\t", "") + ";";

                        output.Add(URL + ";" + outputBuild);
                    }
                    else
                    {
                        output.Add(URL + ";" + "Doc2 not found");
                    }
                }
            }

            catch (Exception ex)
            {
                output.Add(ex.ToString());
            }

            return output;
        }

        public List<string> GetLVSeasonScorecardURLs(List<string> InputURLs)
        {
            List<string> output = new List<string>();
            try
            {
                foreach (string URL in InputURLs)
                {
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    HtmlAgilityPack.HtmlNode node;
                    HtmlAgilityPack.HtmlNodeCollection nodes;

                    doc = GetURLAsDoc(URL);

                    node = doc.DocumentNode.SelectSingleNode("//h1[@class='SubnavSitesection']");
                    nodes = doc.DocumentNode.SelectNodes("//p[@class='potMatchMenuText mat_links']/span[1]/a");

                    foreach (HtmlNode node2 in nodes)
                    {
                        output.Add(node2.Attributes["href"].Value);
                    }

                }
            }

            catch (Exception ex)
            {
                output.Add(ex.ToString());
            }

            return output;
        }

        public List<string> GetScorecardDetails(List<string> InputURLs)
        {
            List<string> output = new List<string>();
            try
            {
                foreach (string URL in InputURLs)
                {
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

                    doc = GetURLAsDoc("http://www.espncricinfo.com" + URL);

                    HtmlAgilityPack.HtmlNode TeamText = doc.DocumentNode.SelectSingleNode("//p[@class='teamText']");
                    HtmlAgilityPack.HtmlNode StatusText = doc.DocumentNode.SelectSingleNode("//p[@class='statusText']");
                    HtmlAgilityPack.HtmlNode DateText = doc.DocumentNode.SelectSingleNode("//div[@class='headRightDiv']/ul/li[3]");
                    HtmlAgilityPack.HtmlNode DivisionSeason = doc.DocumentNode.SelectSingleNode("//h1[@class='SubnavSitesection']");

                    HtmlAgilityPack.HtmlNodeCollection InningsTableNodes = doc.DocumentNode.SelectNodes("//table[@class='inningsTable']");

                    if (InningsTableNodes != null && StatusText.InnerText != "Match abandoned without a ball bowled")
                    {
                        foreach (HtmlNode Table in InningsTableNodes)
                        {
                            HtmlAgilityPack.HtmlDocument doc2 = new HtmlAgilityPack.HtmlDocument();
                            doc2.DocumentNode.InnerHtml = Table.OuterHtml;

                            HtmlAgilityPack.HtmlNodeCollection TableRows = doc2.DocumentNode.SelectNodes("//tr");

                            String Innings = "";

                            foreach (HtmlNode TableRow in TableRows)
                            {
                                if (TableRow.Attributes["class"] != null && TableRow.Attributes["class"].Value == "inningsHead" && !(TableRow.InnerText.Trim().Contains("Bowling")))
                                {
                                    Innings = TableRow.InnerText.Trim().Substring(0, TableRow.InnerText.Trim().IndexOf("innings") + 7);
                                }

                                if (TableRow.Attributes["class"] != null && TableRow.Attributes["class"].Value != "inningsComms")
                                {
                                    String Collector = DivisionSeason.InnerText.Replace("\r", "").Replace("\n", "").Trim() + ";";
                                    Collector = Collector + DateText.InnerText.Replace("\r", "").Replace("\n", "").Trim() + ";";
                                    Collector = Collector + TeamText.InnerText.Replace("\r", "").Replace("\n", "").Trim() + ";";
                                    Collector = Collector + StatusText.InnerText.Replace("\r", "").Replace("\n", "").Trim() + ";";
                                    Collector = Collector + Table.Attributes["id"].Value.Trim() + ";";
                                    Collector = Collector + Innings + ";";

                                    HtmlAgilityPack.HtmlDocument doc3 = new HtmlAgilityPack.HtmlDocument();
                                    doc3.DocumentNode.InnerHtml = TableRow.OuterHtml;

                                    HtmlAgilityPack.HtmlNodeCollection TableCells = doc3.DocumentNode.SelectNodes("//td");

                                    foreach (HtmlNode TableCell in TableCells)
                                    {
                                        if (TableCell.Attributes["class"] != null && TableCell.Attributes["class"].Value == "playerName")
                                        {
                                            Collector = Collector + TableCell.ChildNodes[0].Attributes["href"].Value.Replace("/ci/content/player/", "").Replace(".html", "") + ";" + HttpUtility.HtmlDecode(TableCell.InnerText).Trim() + ";";
                                        }
                                        else
                                        {
                                            Collector = Collector + HttpUtility.HtmlDecode(TableCell.InnerText).Trim() + ";";
                                        }
                                    }

                                    output.Add(Collector);
                                }
                            }
                        }
                    }
                    else
                    {
                        //String Collector = DivisionSeason.InnerText.Replace("\r", "").Replace("\n", "").Trim() + ";";
                        //String Collector =  DateText.InnerText.Replace("\r", "").Replace("\n", "").Trim() + ";";
                        //Collector = Collector + TeamText.InnerText.Replace("\r", "").Replace("\n", "").Trim() + ";";
                        //Collector = Collector + StatusText.InnerText.Replace("\r", "").Replace("\n", "").Trim() + ";";
                        //output.Add(Collector);
                    }
                }
            }

            catch (Exception ex)
            {
                output.Add(ex.ToString());
            }

            return output;
        }

        public List<string> GetPlayerPageURLsFromFuthead(List<string> InputURLs)
        {
            List<string> output = new List<string>();
            try
            {
                foreach (string URL in InputURLs)
                {
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    HtmlAgilityPack.HtmlNodeCollection nodes;
                    
                    doc = GetURLAsDoc(URL);
                    
                    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//table[@id='player-list']/tbody/tr/td/a"))
                    {
                        output.Add(node.Attributes["href"].Value);
                    }

                }
            }

            catch (Exception ex)
            {
                output.Add(ex.ToString());
            }

            return output;
        }

        public List<string> GetPlayerAttributesFromFuthead(List<string> InputURLs)
        {
            List<string> output = new List<string>();
            try
            {
                foreach (string URL in InputURLs)
                {
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    HtmlAgilityPack.HtmlNodeCollection nodes;
                    String JonoPlayerCode;

                    doc = GetURLAsDoc(URL);

                    JonoPlayerCode = doc.DocumentNode.SelectSingleNode("//div[@class='playercard-attr playercard-attr1']").InnerText.Substring(0, 2);
                    JonoPlayerCode = JonoPlayerCode + doc.DocumentNode.SelectSingleNode("//div[@class='playercard-attr playercard-attr2']").InnerText.Substring(0, 2);
                    JonoPlayerCode = JonoPlayerCode + doc.DocumentNode.SelectSingleNode("//div[@class='playercard-attr playercard-attr3']").InnerText.Substring(0, 2);
                    JonoPlayerCode = JonoPlayerCode + doc.DocumentNode.SelectSingleNode("//div[@class='playercard-attr playercard-attr4']").InnerText.Substring(0, 2);
                    JonoPlayerCode = JonoPlayerCode + doc.DocumentNode.SelectSingleNode("//div[@class='playercard-attr playercard-attr5']").InnerText.Substring(0, 2);
                    JonoPlayerCode = JonoPlayerCode + doc.DocumentNode.SelectSingleNode("//div[@class='playercard-attr playercard-attr6']").InnerText.Substring(0, 2);
                    
                    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@class='igs-list']/div"))
                    {
                        output.Add(URL + ";" + JonoPlayerCode + ";" + node.ChildNodes[3].InnerHtml + ";" + node.ChildNodes[1].InnerHtml);
                    }

                    output.Add(URL + ";" + JonoPlayerCode + ";Club;" + doc.DocumentNode.SelectSingleNode("//table['table table-striped table-condensed']/tbody/tr[2]/td[2]/a").InnerHtml.Replace("\r", "").Replace("\n", ""));
                    output.Add(URL + ";" + JonoPlayerCode + ";League;" + doc.DocumentNode.SelectSingleNode("//table['table table-striped table-condensed']/tbody/tr[3]/td[2]/a").InnerHtml.Replace("\r", "").Replace("\n", ""));
                    output.Add(URL + ";" + JonoPlayerCode + ";Nation;" + doc.DocumentNode.SelectSingleNode("//table['table table-striped table-condensed']/tbody/tr[4]/td[2]/a").InnerHtml.Replace("\r", "").Replace("\n", ""));
                    output.Add(URL + ";" + JonoPlayerCode + ";Traits;" + doc.DocumentNode.SelectSingleNode("(//table['table table-striped table-condensed'])[2]/tbody/tr[10]/td[2]").InnerHtml.Replace("\r", "").Replace("\n", ""));
                    output.Add(URL + ";" + JonoPlayerCode + ";Specialities;" + doc.DocumentNode.SelectSingleNode("(//table['table table-striped table-condensed'])[2]/tbody/tr[11]/td[2]").InnerHtml.Replace("\r", "").Replace("\n", ""));

                }
            }

            catch (Exception ex)
            {
                output.Add(ex.ToString());
            }

            return output;
        }

        public List<string> GetWordsFromODO(List<string> InputURLs)
        {
            List<string> output = new List<string>();
            try
            {
                foreach (string URL in InputURLs)
                {
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    HtmlAgilityPack.HtmlNodeCollection nodes;
                    String Entry3;
                    String Entry4;
                    String NextURL;

                    doc = GetURLAsDoc(URL);

                    int number = 0;

                    while (number < 150000)
                    {
                        Entry3 = System.Web.HttpUtility.HtmlDecode(doc.DocumentNode.SelectSingleNode("(//span[@class='alpha_title alpha_hw'])[3]").InnerText);
                        Entry4 = System.Web.HttpUtility.HtmlDecode(doc.DocumentNode.SelectSingleNode("(//span[@class='alpha_title alpha_hw'])[4]").InnerText);
                        NextURL = doc.DocumentNode.SelectSingleNode("(//span[@class='alpha_title alpha_hw'])[5]/..").Attributes["href"].Value;
                        output.Add(Entry3 + "\r\n" + Entry4);
                        doc = GetURLAsDoc(NextURL); // hide
                        number++;
                    }
                }
            }

            catch (Exception ex)
            {
                output.Add(ex.ToString());
            }

            return output;
        }

        public List<string> TestODOSearch(List<string> InputURLs)
        {
            List<string> output = new List<string>();
            try
            {
                foreach (string URL in InputURLs)
                {
                    string HTMLPage;
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    WebResponse objResponse;

                    var surl = "http://www.oxforddictionaries.com/search/?dictCode=english&q=" + URL;
                    WebRequest objRequest = HttpWebRequest.Create(surl);

                    try
                    {
                        objRequest.Proxy = null;
                        objResponse = objRequest.GetResponse();
                        output.Add(URL + ";" + objResponse.ResponseUri.LocalPath);
                        objResponse.Close();
                    }
                    catch (Exception ex)
                    {
                        output.Add(ex.ToString());
                    }

                }
            }

            catch (Exception ex)
            {
                output.Add(ex.ToString());
            }

            return output;
        }

        public List<string> TestMusicDirectorySubfolders(List<string> InputURLs)
        {
            List<string> output = new List<string>();
            try
            {

                String[] allfiles = System.IO.Directory.GetFiles("D:\\Music\\", "*.mp3", System.IO.SearchOption.AllDirectories);

                foreach (string s in allfiles)
                    {
                    
                    output.Add(s);

                }

                

            }

            catch (Exception ex)
            {
                output.Add(ex.ToString());
            }

            return output;
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
