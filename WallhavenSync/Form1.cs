using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WallhavenSyncNm.src;

namespace WallhavenSyncNm
{
    public partial class Form1 : Form

        
    {

        private SessionManager manager;
        private const string WHSUBDIR = "\\Wallhaven";
        
        public Form1(SessionManager manager)
        {
            InitializeComponent();
            this.manager = manager;
            

        }






        public void startScrapingSelected()
        {
            this.listBoxVerbose.Items.Add("Syncing " + this.listBoxFavCategories.SelectedItem.ToString());

            Console.WriteLine("Fav selected:" + this.listBoxFavCategories.SelectedItem.ToString());
            string saveDir = this.textBoxSaveDir.Text + "\\" + this.listBoxFavCategories.SelectedItem.ToString();

          
            manager.scrapeFavourite(this.listBoxFavCategories.SelectedItem.ToString(), saveDir);

            this.listBoxVerbose.Items.Add("Done.");
        }






        public void startScrapingSelectedThreadSafe()
        {

            string category="";
            string savedir = "";
            this.Invoke((MethodInvoker)delegate
            {
                //make sure that we have a folder to work with
                if (this.listBoxFavCategories.SelectedItem == null)
                    if (this.listBoxFavCategories.Items.Count > 0)
                        this.listBoxFavCategories.SelectedItem = this.listBoxFavCategories.Items[0];
                    else
                        return;
                this.listBoxVerbose.Items.Add("Syncing " + this.listBoxFavCategories.SelectedItem.ToString());
                category = this.listBoxFavCategories.SelectedItem.ToString();
                savedir = this.textBoxSaveDir.Text;
                this.buttonDownload.Enabled = false;
            });


            Console.WriteLine("Fav selected:" + category);
            string saveDir = savedir  + "\\" + category;

            manager.scrapeFavourite(category, saveDir);

            this.Invoke((MethodInvoker)delegate
            {
                this.listBoxVerbose.Items.Add("Done.");
                this.buttonDownload.Enabled = true;
            });
            
        }




        /// <summary>
        /// start scraping selected folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //startScrapingSelected();
            Thread oThread = new Thread(new ThreadStart(startScrapingSelectedThreadSafe));
            oThread.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> categories = manager.getFavouritesCategories();
            foreach (string element in categories)
            {
                this.listBoxFavCategories.Items.Add(element);
            }

            this.textBoxSaveDir.Text = Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures) + WHSUBDIR;
            //Environment.SpecialFolder.MyPictures
            Console.WriteLine("MYPICTURES dir: " + this.textBoxSaveDir.Text );
            
        }

        private void buttonChangeDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogSaveDir.ShowDialog() == DialogResult.OK)
            {
                this.textBoxSaveDir.Text = folderBrowserDialogSaveDir.SelectedPath;
            }
        }

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(this.textBoxSaveDir.Text);
            }
            catch (Exception exc)
            {
                this.listBoxVerbose.Items.Add("Couln't open folder, it probably doesn't exist.");
            }
        }
    }
}
