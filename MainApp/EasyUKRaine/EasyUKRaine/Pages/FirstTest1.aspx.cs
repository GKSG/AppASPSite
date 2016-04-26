using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using EasyUKRaine.Models;
using EasyUKRaine.Models.Repo;
using EasyUKRaine.Models.Repository;
using EasyUKRaine.Pages.Helpers;
using WebApplication1.Taskes;
using WebApplication1.Taskes.Anagram;
using WebApplication1.Taskes.Matches;
using WebApplication1.Taskes.Single;

namespace EasyUKRaine.Pages
{
    public partial class FirstTest1 : System.Web.UI.Page
    {
        private static TextBox[] Boxes = new TextBox[5];
        private static bool next = true;
        private static KeyValuePair<int, int> index;
        private static Random randTag=  new Random((int) DateTime.Now.Second);
        private static Random randWord=  new Random((int) DateTime.Now.Millisecond);
        static Random RandomTask=new Random((int) DateTime.Now.Second);
        static int num = RandomTask.Next(8);
        public static Repo repo = new Repo();
        private  static ITask task = null;
        static TextBox InputWord=new TextBox ();
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (task is MatchesTask)
                {
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
                            break;
                        }
                    }
                    if (counter == 5)
                    {
                        next = true;
                        num = RandomTask.Next(8);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                             $"if (window.confirm(\"Чудово! Wery well, bro!\")) window.location.href=\"{RouteTable.Routes.GetVirtualPath(null, "vocabularyTest", null).VirtualPath}\"", true);
                        Repository.GetInstance().CurrentUser.Score += 25*5;
                        Repository.GetInstance().CurrentUser.Level = Repository.GetInstance().CurrentUser.Score / 100;
                        Repository.GetInstance().UpdateUserAccount(Repository.GetInstance().CurrentUser);

                    }
                    else
                    {
                        next = false;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                             $"alert('Wrong answer(-s), bro(');", true);
                    }
                }
                else if (InputWord.Text != "")
                {
                    if (task.CorrectAnswer is string && (task.CorrectAnswer as string).Replace('\"', '\'') == InputWord.Text.Trim(' '))
                    {
                        next = true;
                        InputWord = new TextBox();
                        num = RandomTask.Next(5);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                             $"if (window.confirm(\"Чудово! Wery well, bro!\")) window.location.href=\"{RouteTable.Routes.GetVirtualPath(null, "vocabularyTest", null).VirtualPath}\"", true);
                        Repository.GetInstance().CurrentUser.Score += 75;
                        Repository.GetInstance().CurrentUser.Level = Repository.GetInstance().CurrentUser.Score/100;
                        Repository.GetInstance().UpdateUserAccount(Repository.GetInstance().CurrentUser);
                    }
                    else
                    {
                        next = false;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                             $"alert('Wrong answer(-s), bro(');", true);
                    }



                    /*if (InputWord.Text != "")
                    {
                        if (task.CorrectAnswer is string && (task.CorrectAnswer as string).Replace('\"', '\'') == InputWord.Text.Trim(' '))
                        {
                            next = true;
                            InputWord = new TextBox();
                            num = RandomTask.Next(5);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                 $"if (window.confirm(\"Чудово! Wery well, bro!\")) window.location.href=\"{RouteTable.Routes.GetVirtualPath(null, "firstTest", null).VirtualPath}\"", true);
                        }
                        else
                        {
                            next = false;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                 $"alert('Wrong answer(-s), bro(');", true);
                        }
                    }*/
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect(RouteTable.Routes.GetVirtualPath(null, "SingIn", null).VirtualPath);
            }
        }

        protected void MainPanel_Load(object sender, EventArgs e)
        {

            MainPanel.Controls.Clear();
            Label end=new Label {Text="<br />" };
            switch (num)
            {
                case 0:
                    {
                        int t = randTag.Next(repo.topics.Count);
                        int w = randWord.Next(repo.topics[t].words.Count);
                        index = new KeyValuePair<int, int>(t, w);
                        if (next)
                            task = new SingleWord
                            {
                                CorrectAnswer = repo.topics[index.Key].words[index.Value].word,
                                Content = repo.topics[index.Key].words[index.Value].translates[0].translate
                            };

                        Label header = new Label();
                        header.Font.Name = "Helvetica";
                        header.Font.Size = 14;
                        Label sense = new Label();
                        sense.Font.Name = "Helvetica";
                        sense.Font.Size = 14;

                        var content = new Label();


                        header.Text = task.Header;
                        sense.Text = task.Sence + "</br>";
                        content.Font.Name = "Helvetica";
                        content.Font.Size = 40;
                        content.Text = ((SingleWord) task).Content + "<br />";

                        MainPanel.Width = 256;
                        MainPanel.Height = (256);

                        MainPanel.Controls.Add(header); MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(sense); MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(new TableCell { Controls = { content } });
                        MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(new TableCell { Controls = { InputWord, end } });
                        MainPanel.Controls.Add(end);
                        break;
                    }
                case 1:
                    {
                        int t = randTag.Next(repo.topics.Count);
                        int w = randWord.Next(repo.topics[t].words.Count);
                        index = new KeyValuePair<int, int>(t, w);
                        if (next)
                            task = new SingleImage
                            {
                                CorrectAnswer = repo.topics[index.Key].words[index.Value].word,
                                Content = repo.topics[index.Key].words[index.Value].translates[0].image
                            };

                        Label header = new Label();
                        header.Font.Name = "Helvetica";
                        header.Font.Size = 14;
                        Label sense = new Label();
                        sense.Font.Name = "Helvetica";
                        sense.Font.Size = 14;

                        Image content = new Image();
                        header.Text = task.Header;
                        sense.Text = task.Sence + "</br>";
                        content.BorderColor = System.Drawing.Color.Black;
                        content.ImageUrl = (((SingleImage) task).Content as Image).ImageUrl;

                        content.ImageAlign = ImageAlign.Middle;
                        content.Width = 128;
                        content.Height = 128;
                        MainPanel.Width = 256;
                        MainPanel.Height = (256);
                        MainPanel.Controls.Add(header); MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(sense); MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(new TableCell { Controls = { content } });
                        MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(new TableCell { Controls = { InputWord, end } });
                        MainPanel.Controls.Add(end);
                        break;
                    }
                case 2:
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

                        MainPanel.Width = 256;
                        MainPanel.Height = 256;
                        Label header = new Label();
                        header.Font.Name = "Helvetica";
                        header.Font.Size = 14;
                        Label sense = new Label();
                        sense.Font.Name = "Helvetica";
                        sense.Font.Size = 14;

                        Label content = new Label();
                        content.Font.Name = "Helvetica";
                        content.Font.Size = 40;
                        Label comb = new Label();
                        comb.Font.Name = "Helvetica";
                        comb.Font.Size = 18;

                        header.Text = task.Header;
                        sense.Text = task.Sence + "<br />";
                        content.BorderColor = System.Drawing.Color.Black;
                        content.Text = ((AnagramTask) task).Content + "<br />";
                        comb.Text = (new string(((AnagramTask) task).AnagramWord.Select(x => x.Value).ToArray()));
                        MainPanel.Controls.Add(header); MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(sense); MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(content); MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(new TableCell { Controls = { InputWord, end } });
                        MainPanel.Controls.Add(end);
                        break;
                    }
                case 3:
                    {
                        // InputWord.Text = "";
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
                        header.Font.Size = 14;
                        Label sense = new Label();
                        sense.Font.Name = "Helvetica";
                        sense.Font.Size = 14;
                        Label comb = new Label();
                        comb.Font.Name = "Helvetica";
                        comb.Font.Size = 18;

                        Image content = new Image();


                        header.Text = task.Header;
                        sense.Text = task.Sence + "<br />";
                        comb.Text = (new string(((AnagramTask) task).AnagramWord.Select(x => x.Value).ToArray()));
                        content.BorderColor = System.Drawing.Color.Black;
                        content.ImageUrl = (((AnagramImage) task).Content as Image).ImageUrl;

                        content.ImageAlign = ImageAlign.Middle;
                        content.Width = 128;
                        content.Height = 128;
                        MainPanel.Width = 256;
                        MainPanel.Height = (256);
                        MainPanel.Controls.Add(header); MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(sense); MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(new TableCell { Controls = { content, end } });
                        MainPanel.Controls.Add(comb);
                        MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(new TableCell { Controls = { InputWord, end } });
                        MainPanel.Controls.Add(end);
                        break;
                    }
                case 4:
                    {
                        randTag = new Random((int) DateTime.Now.Ticks);
                        randWord = new Random((int) DateTime.Now.Ticks);
                        int t = randTag.Next(repo.topics.Count);
                        int w = randWord.Next(repo.topics[t].words.Count);
                        index = new KeyValuePair<int, int>(t, w);
                        if (next)
                            task = new AnagramNoTip
                            {
                                CorrectAnswer = repo.topics[index.Key].words[index.Value].word.Replace('\"', '\''),
                                Content = repo.topics[index.Key].words[index.Value].translates[0].translate
                            };
                        ((AnagramTask) task).CreateAnagram();

                        MainPanel.Width = 256;
                        MainPanel.Height = 256;
                        Label header = new Label();
                        header.Font.Name = "Helvetica";
                        header.Font.Size = 14;
                        Label sense = new Label();
                        sense.Font.Name = "Helvetica";
                        sense.Font.Size = 14;

                        Label content = new Label();
                        content.Font.Name = "Helvetica";
                        content.Font.Size = 40;
                        Label comb = new Label();
                        comb.Font.Name = "Helvetica";
                        comb.Font.Size = 18;

                        header.Text = task.Header;
                        sense.Text = task.Sence + "<br />";
                        content.BorderColor = System.Drawing.Color.Black;
                        //content.Text = ((AnagramTask) task).Content + "<br />";
                        comb.Text = (new string(((AnagramTask) task).AnagramWord.Select(x => x.Value).ToArray()));
                        MainPanel.Controls.Add(header); MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(sense);
                        MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(comb); MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(new TableCell { Controls = { InputWord, end } });
                        MainPanel.Controls.Add(end);
                        break;
                    }
                case 7:
                    {
                        if (next)
                            task = new MatchesWord(new Random((int) DateTime.Now.Ticks), new Random((int) DateTime.Now.Ticks), repo);
                        Boxes = new TextBox[5];
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
                        MainPanel.Controls.Add(header); MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(sense); MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(table);
                        MainPanel.Controls.Add(end);
                        break;
                    }
                case 5:
                    {
                        Boxes = new TextBox[5];
                        if (next)
                            task = new MatchesImage(new Random((int) DateTime.Now.Ticks), new Random((int) DateTime.Now.Ticks), repo);
                        MainPanel.Width = 700;
                        MainPanel.Height = 512;
                        Label header = new Label();
                        header.Font.Name = "Helvetica";
                        header.Font.Size = 24;
                        Label sense = new Label();
                        sense.Font.Name = "Helvetica";
                        sense.Font.Size = 18;
                        header.Text = task.Header + "<br />";
                        sense.Text = "<br />" + task.Sence + "<br />";
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
                            var mid1l = new Label {Text =(i+1)+"."};
                            mid1l.Font.Name = "Helvetica";
                            mid1l.Font.Size = 24;
                            TableCell mid = new TableCell {Controls = {Boxes[i], new Label {Text = "|"}, mid1l}};
                            var rightl = ((Image[])normtask.ContentRight)[i];
                            rightl.Font.Name = "Helvetica";
                            rightl.Font.Size = 24;
                            TableCell right = new TableCell {Controls = {rightl}};
                            table.Rows.Add(new TableRow { Cells = { left, mid, right } });
                        }
                        MainPanel.Controls.Add(header); MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(sense); MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(table);
                        MainPanel.Controls.Add(end);
                        break;
                    }
                case 6:
                    {
                        Boxes = new TextBox[5];
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
                        MainPanel.Controls.Add(header); MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(sense); MainPanel.Controls.Add(end);
                        MainPanel.Controls.Add(table);
                        MainPanel.Controls.Add(end);
                        break;
                    }

            }
            next = false;
        }
        protected void Text(object sender, EventArgs e)
        {
            var control = sender as TextBox;
            try
            {
                control.Text = new string(new[] { control.Text.First() });
            }
            catch { return; }
        }

        



    }
}