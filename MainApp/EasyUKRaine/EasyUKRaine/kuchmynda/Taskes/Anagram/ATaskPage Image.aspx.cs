using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EasyUKRaine.Models.Repo;
using EasyUKRaine.Models.Repository;

using WebApplication1.Taskes.Anagram;

namespace WebApplication1.Taskes
{
    public partial class ATaskPageImage : System.Web.UI.Page
    {
        private static bool next = true;
        private static KeyValuePair<int, int> index;
        private static Random randTag;
        private static Random randWord;
        public static Repo repo = new Repo();
        private  static ITask task = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void MainPanel_Load(object sender, EventArgs e)
        {                  
                randTag = new Random((int) DateTime.Now.Ticks);
                randWord = new Random((int) DateTime.Now.Ticks);
                int t = randTag.Next(repo.topics.Count);
                int w = randWord.Next(repo.topics[t].words.Count);
                index = new KeyValuePair<int, int>(t, w);
            if (next)
                task = new AnagramImage
                {
                    CorrectAnswer = repo.topics[index.Key].words[index.Value].word,
                    Content = repo.topics[index.Key].words[index.Value].translates[0].image
                };
            ((AnagramTask) task).CreateAnagram();
            Label header = new Label();
                header.Font.Name = "Helvetica";
                header.Font.Size = 26;
                Label sense = new Label();
                sense.Font.Name = "Helvetica";
                sense.Font.Size = 26;
            Label comb = new Label();
            comb.Font.Name = "Helvetica";
            comb.Font.Size = 40;
            //----пофіксити багатозначність

            Image content = new Image();
                

                header.Text = task.Header + "<br />";
                sense.Text = "<br />" + task.Sence + "<br />";
            comb.Text = (new string(((AnagramTask) task).AnagramWord.Select(x => x.Value).ToArray())) + "<br />";
            content.BorderColor = System.Drawing.Color.Black;
                content.ImageUrl = (((AnagramImage) task).Content as Image).ImageUrl;
            
            content.ImageAlign = ImageAlign.Middle; 
                content.CssClass = "PicWordAuto1";
            content.Width = 512;
            content.Height = 512;
                MainPanel.Width = 512;
                MainPanel.Height = (256 + 512);     

                MainPanel.Controls.Add(header);
                MainPanel.Controls.Add(sense);
                MainPanel.Controls.Add(new TableCell {Controls= {content}});
            MainPanel.Controls.Add(comb);


            next = false;
            
        }

        /*
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (((AnagramTask) task).CorrectAnswer.Replace('\"','\'') == InputWord.Text.Trim(' '))
            {
                next = true;           
                ClientScript.RegisterClientScriptBlock(this.GetType(), "calling",
                    $"<script type=\"text/javascript\">alert(\"Чудово! Wery well, bro!\")</script>");      
            }

        }*/
    }
}