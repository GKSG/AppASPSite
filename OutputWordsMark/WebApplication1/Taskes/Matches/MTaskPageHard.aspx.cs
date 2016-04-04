using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Repo;
using WebApplication1.Taskes.Anagram;
using WebApplication1.Taskes.Matches;

namespace WebApplication1.Taskes
{
    public partial class MTaskPageHard : System.Web.UI.Page
    {
        private static bool next = true;
        public static Repository repo = new Repository();
        private  static ITask task = null;
        private TextBox[] Boxes = new TextBox[5];

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void MainPanel_Load(object sender, EventArgs e)
        {
            if (next)
                task = new MatchesHard(new Random((int) DateTime.Now.Ticks), new Random((int) DateTime.Now.Ticks), repo);
            MainPanel.Width = 700;
            MainPanel.Height = 320;   
            Label header = new Label();
            header.Font.Name = "Helvetica";
            header.Font.Size = 24;
            Label sense = new Label();
            sense.Font.Name = "Helvetica";
            sense.Font.Size = 18;
            header.Text = task.Header + "<br />";
            sense.Text = "<br />" + task.Sence + "<br />";
            //----пофіксити багатозначність
            Table table = new Table();
            table.HorizontalAlign = HorizontalAlign.Center;
            var normtask=(MatchesTask)task;
            for (int i = 0 ; i < 5 ; i++)
            {
                Boxes[i] = new TextBox { TextMode = TextBoxMode.SingleLine };
                Boxes[i].Font.Name = "Helvetica";
                Boxes[i].Font.Size = 24;
                Boxes[i].Width = 50;
                Boxes[i].TextChanged += Text;
                Boxes[i].AutoCompleteType = AutoCompleteType.None;
                var leftl = new Label {Text = normtask.ContentLeft[i]};
                leftl.Font.Name = "Helvetica";
                leftl.Font.Size = 24;
                TableCell left = new TableCell {Controls = { leftl}};
                TableCell mid = new TableCell {Controls = {Boxes[i],new Label {Text= "|" } }};
                var rightl = new Label {Text =(i+1)+"."+ ((string[])normtask.ContentRight)[i]};
                rightl.Font.Name = "Helvetica";
                rightl.Font.Size = 24;
                TableCell right = new TableCell {Controls = {rightl}};
                table.Rows.Add(new TableRow { Cells = { left, mid, right } });
            }
            MainPanel.Controls.Add(header);
            MainPanel.Controls.Add(sense);
            MainPanel.Controls.Add(table);
            next = false;
        }

        protected void Text(object sender, EventArgs e)
        {
            var control = sender as TextBox;
            control.Text = new string(new[] { control.Text.First() });
        }


        protected void Unnamed_Click(object sender, EventArgs e)
        {
            //bool norm = false;
            int counter = 0;
            var normtask=(MatchesTask)task;
            for (int i = 0 ; i < 5 ; i++)
            {
                try
                {
                    if (normtask.CorrectPair[i].Equals(normtask.PairRight[int.Parse(Boxes[i].Text) - 1]))
                        counter++;
                }
                catch
                {
                    return;
                }
            }
            if (counter == 5)
            {
                next = true;
                ClientScript.RegisterClientScriptBlock(this.GetType(), "calling",
                    $"<script type=\"text/javascript\">alert(\"Чудово! Wery well, bro!\")</script>");
            }

        }
    }
}