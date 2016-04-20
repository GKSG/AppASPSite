using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EasyUKRaine.Models.Repo;
using WebApplication1.Taskes.Anagram;

namespace WebApplication1.Taskes
{
    public partial class ATaskPage : System.Web.UI.Page
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
                task = new AnagramWord
                {
                    CorrectAnswer = repo.topics[index.Key].words[index.Value].word.Replace('\"', '\''),
                    Content = repo.topics[index.Key].words[index.Value].translates[0].translate
                };
            ((AnagramTask) task).CreateAnagram();

            MainPanel.Width = 512;
            MainPanel.Height = 256;
            Label header = new Label();
            header.Font.Name = "Helvetica";
            header.Font.Size = 24;
            Label sense = new Label();
            sense.Font.Name = "Helvetica";
            sense.Font.Size = 18;
            //----пофіксити багатозначність

            Label content = new Label();
            content.Font.Name = "Helvetica";
            content.Font.Size = 40;
            Label comb = new Label();
            comb.Font.Name = "Helvetica";
            comb.Font.Size = 40;

            header.Text = task.Header + "<br />";
            sense.Text = "<br />" + task.Sence + "<br />";
            content.BorderColor = System.Drawing.Color.Black;
            content.Text = ((AnagramTask) task).Content + "<br />";
            comb.Text = (new string(((AnagramTask) task).AnagramWord.Select(x=>x.Value).ToArray())) + "<br />";
            MainPanel.Controls.Add(header);
            MainPanel.Controls.Add(sense);
            MainPanel.Controls.Add(content);
            MainPanel.Controls.Add(comb);


            next = false;

        }


       /* protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (((AnagramTask) task).CorrectWord.Replace('\"','\'') == InputWord.Text.Trim(' '))
            {
                next = true;           
                ClientScript.RegisterClientScriptBlock(this.GetType(), "calling",
                    $"<script type=\"text/javascript\">alert(\"Чудово! Wery well, bro!\")</script>");      
            }

        }*/
    }
}