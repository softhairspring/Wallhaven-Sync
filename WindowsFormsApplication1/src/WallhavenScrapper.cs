using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.IO;
using System.Threading;

namespace WallhavenSyncNm.src
{
    public class WallhavenScrapper
    {
        private BrowserSession browser;
        private System.Net.WebClient webclient;
        private const string URLPAGE = "?page=";
        private const string URLDIRECT = "https://wallpapers.wallhaven.cc/wallpapers/full/wallhaven-";
        private const string JPG = ".jpg";




        public WallhavenScrapper(BrowserSession browser)
        {
            this.browser = browser;
            webclient = new System.Net.WebClient();
        }

        /// <summary>
        /// sscrape number of pages loaded by ajax calls
        /// </summary>
        /// <param name="pagecontent"></param>
        /// <returns></returns>
        public int getPageCount(HtmlAgilityPack.HtmlDocument doc)
        {
            int pagec = 0;
            //foreach (HtmlAgilityPack.HtmlNode node in doc.DocumentNode.SelectNodes("@thumb-listing-page-num"))
            HtmlAgilityPack.HtmlNode node = doc.DocumentNode.SelectSingleNode("//h2[@class='thumb-listing-page-header']");
            
                if (node == null)
                    return 1;   //return 1 cause small amount of wallpapers dont get pagecount
                string[] tokens = node.InnerText.Split(' ');
                if (tokens.Count() <= 0)
                    return 0;
                pagec = Int32.Parse(tokens.Last());
            
                return pagec;
        }

        public void scrapeDirectory(string urldir, string savedirectory)
        {

            int pagenr = 1;
            int pagecount = 0;
            string page = browser.Get(urldir+URLPAGE+pagenr.ToString());

            if (page.Contains("id=\"username\" required=\"required\""))
            {
                Console.Write("fav page loading error/login error");
                return;
            }

            //check/mk dir
            if (!mkDir(savedirectory))
            {
                Console.WriteLine("Error - couldn't create Directory") ;
                return;
            }

            HtmlAgilityPack.HtmlDocument doc = browser.getHtmlDocument();

            //check how many pages are there
            pagecount = getPageCount(doc);
            if (pagecount == 0) {
                Console.WriteLine("Error - couldnt find page length");
                return;
            }
            //for page
            Boolean NotLastPage=true;
            while (NotLastPage)
            {

                
                foreach (HtmlAgilityPack.HtmlNode li in doc.DocumentNode.SelectNodes("//figure"))
                {

                    string wallpaperid = (li.Attributes["data-wallpaper-id"].Value);

                    this.scrapeImage(wallpaperid, JPG, savedirectory);
                }

                //next page
                pagenr++;
                //exit on end
                if (pagenr > pagecount)
                {
                    NotLastPage = false;
                    break;
                }

                page = browser.Get(urldir + URLPAGE + pagenr.ToString());
                //page = browser.Get(urldir + URLPAGE + "3");
                doc = browser.getHtmlDocument();
                //valid.

            }

        }

        /// <summary>
        /// download wallhaven image using its id number and static url
        /// </summary>
        /// <param name="imagenumber"></param>
        /// <param name="extension"></param>
        /// <param name="savedirectory"></param>
        public void scrapeImage(string imagenumber, string extension, string savedirectory)
        {

            string abspath = savedirectory+"\\"+"wallhaven-" + imagenumber + extension;

            //deb
            Boolean a=File.Exists(abspath);
            Boolean b = File.Exists(savedirectory + "\\" + "wallhaven-" + imagenumber + ".png");
            if ( File.Exists(abspath) || File.Exists(savedirectory+"\\"+"wallhaven-" + imagenumber + ".png") )
            {
                Console.WriteLine("Wallpaper " + imagenumber + " exists. Omitting.");
                return;
            }

            try
            {
                Console.WriteLine("Downloading: " + imagenumber);//
                webclient.DownloadFile(URLDIRECT + imagenumber + extension, savedirectory+"\\"+"wallhaven-" + imagenumber + extension);
            }
            catch (Exception e)
            {
                //
                //couldnt find jpg? its probably png
                if (!extension.Contains(".png"))
                    scrapeImage(imagenumber, ".png", savedirectory);
                else
                    Console.WriteLine("Error writing file: "+e.Message + " " + URLDIRECT + imagenumber + extension);
            }

            //pause thread to avoid server overload in parallel universe.
            //if you change this, youre a bad and you shoould feel bad.
            Thread.Sleep(587);

        }

        public Boolean mkDir(string dir){
            System.IO.DirectoryInfo nfo = Directory.CreateDirectory(dir);
            return nfo.Exists;
        }


    }
}
