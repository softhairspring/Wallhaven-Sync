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
        /// <summary>
        /// Number of images in category folder
        /// used to predict number of page reequests needed
        /// </summary>
        private List<uint> favcategoriesimagecount;

        public SessionManager(){
            browser = new BrowserSession();
            scrapper = new WallhavenScrapper(browser);
            ISLOGGEDIN=false;
            favcategories = new List<string>();
            favcategoriesurls = new List<string>();
            favcategoriesimagecount = new List<uint>();

        }

        public Boolean login(string user,string password){
            browser.Get("https://wallhaven.cc/login");
            browser.FormElements["username"] = user;
            browser.FormElements["password"] = password;
            string response = browser.Post("https://wallhaven.cc/auth/login");
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

            browser.Get("https://wallhaven.cc/favorites");
            //this.setDebugText(response);  //response = 

            
            HtmlAgilityPack.HtmlDocument doc = browser.getHtmlDocument();
            foreach (HtmlAgilityPack.HtmlNode li in doc.DocumentNode.SelectNodes("//a[@class='label']"))
            {

                string InnerTextTrim = li.InnerText;
                string ImagesCount = string.Empty;
                uint ImagesCountNumber = 0;

                //remove spaces
                InnerTextTrim = InnerTextTrim.Trim();

                //ignore Trash folder
                if (InnerTextTrim.Equals("Trash"))
                {
                    continue;
                }

                //clean names and get image count
                int i = 0;
                for (i = 0; i < InnerTextTrim.Length; i++)
                {
                    if (Char.IsDigit(InnerTextTrim[i]))
                    {
                        ImagesCount += InnerTextTrim[i];
                        
                    }

                    else
                    {
                        break;
                    }
                        
                }
                
                InnerTextTrim = InnerTextTrim.Remove(0, i);//remove number;
                ImagesCountNumber = uint.Parse(ImagesCount);

                //remove image count from str and white spaces
                //string InnerTextTrim = new String(li.InnerText.Where(c => c != '-' && (c < '0' || c > '9')).ToArray()).Trim();
                //add name and url to lists
                this.favcategories.Add(InnerTextTrim);
                this.favcategoriesurls.Add(li.Attributes["href"].Value);
                this.favcategoriesimagecount.Add(ImagesCountNumber);
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
        public uint getFavCategoryImageCount(string cat)
        {

            string outp = "empty url";
            int id = this.favcategories.FindIndex(s => s == cat);
            if (id < 0 || id > this.favcategoriesurls.Count)
                return 0;

            return this.favcategoriesimagecount[id];
        }

        ///
        public void scrapeFavourite(string favcategoryname, string savedirectory){
            scrapper.scrapeDirectory(getFavCategoryUrl(favcategoryname), savedirectory, getFavCategoryImageCount(favcategoryname));
        }

        /**
         * 
         *  iterate all fav folders
         *  */
        public void scrapeAllFavourites(string savedirectory)
        {
            for(int i=0;i<favcategoriesurls.Count;i++)
            {
                string subdir = favcategories[i];
                scrapper.scrapeDirectory(favcategoriesurls[i], savedirectory + subdir,favcategoriesimagecount[i]);
            }
        }

        /// no no senore~ do not use
        public void scrapeTag(string tagcategoryname, string savedirectory)
        {
            //TODO: update fot imagecount
            scrapper.scrapeDirectory("https://wallhaven.cc/search?q=\"" + (tagcategoryname) + "\"&categories=111&purity=000", savedirectory, 0000000);
        }


        public Boolean isLoggedIn()
        {
            return ISLOGGEDIN;

        }
            
    }
}
