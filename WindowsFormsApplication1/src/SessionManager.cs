using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WallhavenSyncNm.src
{
    public class SessionManager
    {
        private BrowserSession browser;
        private WallhavenScrapper scrapper;
        private Boolean ISLOGGEDIN;
        /// <summary>
        /// list of favourites folders
        /// </summary>
        private List<string> favcategories ;
        /// <summary>
        ///  urls to fav folders
        /// </summary>
        private List<string> favcategoriesurls ;

        public SessionManager(){
            browser = new BrowserSession();
            scrapper = new WallhavenScrapper(browser);
            ISLOGGEDIN=false;
            favcategories = new List<string>();
            favcategoriesurls = new List<string>();
        }

        public Boolean login(string user,string password){
            browser.Get("https://alpha.wallhaven.cc/auth/login");
            browser.FormElements["username"] = user;
            browser.FormElements["password"] = password;
            string response = browser.Post("https://alpha.wallhaven.cc/auth/login");
            //this.setDebugText(response);
            // confirmation hack
            if (response.Contains(user)){
                ISLOGGEDIN = true;
                return true;      
            }
            ISLOGGEDIN=false;
            return false;
        }
                    
        public List<string> getFavouritesCategories(){
            if(!ISLOGGEDIN)
                return new List<string>();

            browser.Get("https://alpha.wallhaven.cc/favorites");
            //this.setDebugText(response);  //response = 

            
            HtmlAgilityPack.HtmlDocument doc = browser.getHtmlDocument();
            foreach (HtmlAgilityPack.HtmlNode li in doc.DocumentNode.SelectNodes("//a[@class='label']"))
            {
                //remove image count from str and white spaces
                string InnerTextTrim = new String(li.InnerText.Where(c => c != '-' && (c < '0' || c > '9')).ToArray()).Trim();
                //add name and url to lists
                this.favcategories.Add(InnerTextTrim);
                this.favcategoriesurls.Add(li.Attributes["href"].Value);
            }

            if (this.favcategories.Count == 0)
                Console.WriteLine("No favourite folders found.");
            //foreach(string element in favcategories){
            //    this.listBoxFavCategories.Items.Add(element);
            //}



            return this.favcategories;
        }


        public string getFavCategoryUrl(string cat){

            string outp = "empty url";
            int id = this.favcategories.FindIndex(s => s== cat);
            if (id < 0 || id > this.favcategoriesurls.Count)
                return outp;

            return this.favcategoriesurls[id];
        }

        ///
        public void scrapeFavourite(string favcategoryname, string savedirectory){
            scrapper.scrapeDirectory(getFavCategoryUrl(favcategoryname), savedirectory);
        }

        public Boolean isLoggedIn()
        {
            return ISLOGGEDIN;

        }
            
    }
}
