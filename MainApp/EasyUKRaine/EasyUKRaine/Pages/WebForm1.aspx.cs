using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net;
using EasyUKRaine.Models;
using System.Web.Routing;
using EasyUKRaine.Models.Repository;

namespace game
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static bool IsGeneration = true;
        public static List<TableRow> tr = new List<TableRow>();
        public static List<TableRow> tr1 = new List<TableRow>();
        public static List<string> words = new List<string>();
        public static List<string> symb = new List<string>();
        public static List<string> translate = new List<string>();
        public static List<string> english = new List<string>();
        public static List<string> WordsDB = (new EasyUKRainianEntities()).Word.Select(x => x.Word1.Replace("\"","'")).ToList();
        private static EasyUKRainianEntities repo = new EasyUKRainianEntities();
        public static List<Word> WordsDB1 = repo.Word.ToList();
        public static List<Translate> TranslDB = repo.Translate.ToList();
        public static string[] k = new string[16];
        public static List<KeyValuePair<string, string>> WordAndTranslate = new List<KeyValuePair<string, string>>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect(RouteTable.Routes.GetVirtualPath(null, "SingIn", null).VirtualPath);
            }

            if (IsGeneration == true)
                {
                for (int i = 0; i < WordsDB1.Count; i++)
                    for (int j = 0; j < TranslDB.Count; j++)
                        if (WordsDB1[i].WID == TranslDB[j].WID)
                        {
                            WordAndTranslate.Add(new KeyValuePair<string, string>(WordsDB1[i].Word1.Replace('\"','\''), TranslDB[j].Translate1));
                            continue;
                        }
                
                Random rnd1 = new Random();                   
                    int m = 0;
                    for (int i = 0; i < WordAndTranslate.Count; i++)
                    {
                        m=rnd1.Next(0, WordAndTranslate.Count);
                        
                        for (int j = 0; j < WordAndTranslate[m].Key.Length; j++)
                        {
                            
                            if (!symb.Contains(WordAndTranslate[m].Key[j].ToString()) && symb.Count < 16)
                            {
                                symb.Add(WordAndTranslate[m].Key[j].ToString());
                            if (!translate.Contains(WordAndTranslate[m].Key))
                            {
                                translate.Add(WordAndTranslate[m].Key);
                                english.Add(WordAndTranslate[m].Value);
                                words.Add("");
                            }
                        }                        
                     }                                     
                    }              
                    Random rnd = new Random();
                    
                    for (int i = 0; i < k.Length; i++)
                    {
                        k[i] = symb[rnd.Next(0, symb.Count)].ToString();
                        symb.Remove(k[i]);
                    }
                TableRow t1 = new TableRow();
                TableCell tc1 = new TableCell();
                tc1.Text = "Words";
                tc1.BorderWidth = 2;
                tc1.BorderColor = System.Drawing.Color.Black;
                TableCell tc2 = new TableCell();
                tc2.Text = "Translation";
                tc2.BorderWidth = 2;
                tc2.BorderColor = System.Drawing.Color.Black;
                t1.Cells.Add(tc1);
                t1.Cells.Add(tc2);
                tr.Add(t1);
                Table_res.Rows.Add(tr[0]);
                for (int i = 1; i < translate.Count; i++)
                {
                    TableRow t11 = new TableRow();
                    TableCell tc11 = new TableCell();
                    tc11.BorderWidth = 2;
                    tc11.BorderColor = System.Drawing.Color.Black;
                    tc11.Text = english[i - 1];
                    TableCell tc21 = new TableCell();
                    tc21.Text = "";
                    tc21.BorderWidth = 2;
                    tc21.BorderColor = System.Drawing.Color.Black;
                    t11.Cells.Add(tc11);
                    t11.Cells.Add(tc21);
                    tr.Add(t11);
                    Table_res.Rows.Add(tr[i]);
                }
            }
                    b1.Text = k[0].ToString();
                    b2.Text = k[1].ToString();
                    b3.Text = k[2].ToString();
                    b4.Text = k[3].ToString();
                    b5.Text = k[4].ToString();
                    b6.Text = k[5].ToString();
                    b7.Text = k[6].ToString();
                    b8.Text = k[7].ToString();
                    b9.Text = k[8].ToString();
                    b10.Text = k[9].ToString();
                    b11.Text = k[10].ToString();
                    b12.Text = k[11].ToString();
                    b13.Text = k[12].ToString();
                    b14.Text = k[13].ToString();
                    b15.Text = k[14].ToString();
                    b16.Text = k[15].ToString();
            Table_res.Rows.Clear();
            for (int i = 0; i < tr.Count; i++)
            {
               Table_res.Rows.Add(tr[i]);
            }
            IsGeneration = false;            
        }

        //public static int timeLeft = 180;
        //protected void Timer1_Tick(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < tr.Count; i++)
        //    {
        //        Table_res.Rows.Add(tr[i]);
        //    }
        //    if (timeLeft > 10)
        //    {

        //        timeLeft = timeLeft - 10;
        //        timeLabel.Text = timeLeft + " seconds";
        //    }
        //    else
        //    {
        //        timeLabel.Text = "Time's up!";
        //        int sum = 0;
        //        for (int i = 1; i < tr.Count; i++)
        //        {
        //            sum += Convert.ToInt32(tr[i].Cells[1].Text.ToString());
        //            //Response.Write("Time is over!!! Your Score" + tr[i].Cells[1].Text.T);
        //        }
        //        Response.Write("Time is over!!! Your Score" + sum.ToString());
        //    }
           
        //}
        protected void button_submit_Click(object sender, EventArgs e)
        {
            Table_res.Rows.Clear();
            string find = Text1.Text;
            //string filePath = @"C:\Users\q\Desktop\uk_UA.dic";
            //string text = System.IO.File.ReadAllText(filePath);
            //var output = text.Split('/').Select(x=>x=x.Replace("\n","")).ToList();
            Table_res.Rows.Add(tr[0]);
            int notword = 0;
            for (int y = 0; y < translate.Count; y++)
            {                
                if (translate[y] == find)
                {
                    words[y] = translate[y];
                    notword++;
                }            
            }
            if (notword == 0)
            {
                string scrp = "alert('Have not this word!!! Немає цього слова!!!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", scrp, true);
            }
            for (int i = 1; i < translate.Count; i++)
            {
                TableRow t11 = new TableRow();
                TableCell tc11 = new TableCell();
                tc11.BorderWidth = 2;
                tc11.BorderColor = System.Drawing.Color.Black;
                tc11.Text = english[i-1];
                TableCell tc21 = new TableCell();
                tc21.Text = words[i-1];
                tc21.BorderWidth = 2;
                tc21.BorderColor = System.Drawing.Color.Black;
                t11.Cells.Add(tc11);
                t11.Cells.Add(tc21);
                tr[i]=t11;
                Table_res.Rows.Add(tr[i]);
            }
            Text1.Text = "";
            int res=0;
            for (int i = 0; i < translate.Count; i++)
            {
                if (words[i] == translate[i])
                {
                    res += 1;
                }
                if (res == translate.Count-1)
                {
                    IsGeneration = true;
                    translate.Clear();
                    english.Clear();
                    WordAndTranslate.Clear();
                    words.Clear();
                    Table_res.Rows.Clear();
                    tr.Clear();
                    Repository.GetInstance().CurrentUser.Score += WordsDB1.Count*4;
                    Repository.GetInstance().CurrentUser.Level = Repository.GetInstance().CurrentUser.Score /100;
                    Repository.GetInstance().UpdateUserAccount(Repository.GetInstance().CurrentUser);
                    //  ClientScript.RegisterStartupScript(this.GetType(), "calling", $"<script type=\"text/javascript\">alert(\"Good job!!!\")</script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "calling",
                           $"<script type=\"text/javascript\">if(window.confirm(\"Чудово! Wery well, bro!\")) window.location.href=\"{RouteTable.Routes.GetVirtualPath(null, "Games", null).VirtualPath}\"</script>");
                    string scrp= "if (window.confirm(\"Чудово! Wery well, bro!\")) window.location.href=\"Games\"";
                   ////// string scrp = "alert('Good job!!! Хороша робота!!!');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", scrp, true);
                   // Response.Redirect(RouteTable.Routes.GetVirtualPath(null, "Games", null).VirtualPath);
                }
            }
               
        }
        protected string redirect()
        {
            Response.Redirect(RouteTable.Routes.GetVirtualPath(null, "Games", null).VirtualPath);
            return "";
        }
        protected void b1_Click(object sender, EventArgs e)
        {
            Text1.Text += b1.Text;            
            for (int i = 0; i < tr.Count; i++)
            {
                Table_res.Rows.Add(tr[i]);
            }            
        }

        protected void b2_Click(object sender, EventArgs e)
        {
            Text1.Text += b2.Text;
            for (int i = 0; i < tr.Count; i++)
            {
                Table_res.Rows.Add(tr[i]);
            }
        }
        protected void b3_Click(object sender, EventArgs e)
        {
            Text1.Text += b3.Text;
            for (int i = 0; i < tr.Count; i++)
            {
                Table_res.Rows.Add(tr[i]);
            }
        }
        protected void b4_Click(object sender, EventArgs e)
        {
            Text1.Text += b4.Text;
            for (int i = 0; i < tr.Count; i++)
            {
                Table_res.Rows.Add(tr[i]);
            }
        }
        protected void b5_Click(object sender, EventArgs e)
        {
            Text1.Text += b5.Text;
            for (int i = 0; i < tr.Count; i++)
            {
                Table_res.Rows.Add(tr[i]);
            }
        }
        protected void b6_Click(object sender, EventArgs e)
        {
            Text1.Text += b6.Text;
            for (int i = 0; i < tr.Count; i++)
            {
                Table_res.Rows.Add(tr[i]);
            }
        }
        protected void b7_Click(object sender, EventArgs e)
        {
            Text1.Text += b7.Text;
            for (int i = 0; i < tr.Count; i++)
            {
                Table_res.Rows.Add(tr[i]);
            }
        }
        protected void b8_Click(object sender, EventArgs e)
        {
            Text1.Text += b8.Text;
            for (int i = 0; i < tr.Count; i++)
            {
                Table_res.Rows.Add(tr[i]);
            }
        }
        protected void b9_Click(object sender, EventArgs e)
        {
            Text1.Text += b9.Text;
            for (int i = 0; i < tr.Count; i++)
            {
                Table_res.Rows.Add(tr[i]);
            }
        }
        protected void b10_Click(object sender, EventArgs e)
        {
            Text1.Text += b10.Text;
            for (int i = 0; i < tr.Count; i++)
            {
                Table_res.Rows.Add(tr[i]);
            }
        }
        protected void b11_Click(object sender, EventArgs e)
        {
            Text1.Text += b11.Text;
            for (int i = 0; i < tr.Count; i++)
            {
                Table_res.Rows.Add(tr[i]);
            }
        }
        protected void b12_Click(object sender, EventArgs e)
        {
            Text1.Text += b12.Text;
            for (int i = 0; i < tr.Count; i++)
            {
                Table_res.Rows.Add(tr[i]);
            }
        }
        protected void b13_Click(object sender, EventArgs e)
        {
            Text1.Text += b13.Text;
            for (int i = 0; i < tr.Count; i++)
            {
                Table_res.Rows.Add(tr[i]);
            }
        }
        protected void b14_Click(object sender, EventArgs e)
        {
            Text1.Text += b14.Text;
            for (int i = 0; i < tr.Count; i++)
            {
                Table_res.Rows.Add(tr[i]);
            }
        }
        protected void b15_Click(object sender, EventArgs e)
        {
            Text1.Text += b15.Text;
            for (int i = 0; i < tr.Count; i++)
            {
                Table_res.Rows.Add(tr[i]);
            }
        }
        protected void b16_Click(object sender, EventArgs e)
        {
            Text1.Text += b16.Text;
            for (int i = 0; i < tr.Count; i++)
            {
                Table_res.Rows.Add(tr[i]);
            }
        }
        protected void button_clear_Click(object sender, EventArgs e)
        {
            Text1.Text = "";
            for (int i = 0; i < tr.Count; i++)
            {
                Table_res.Rows.Add(tr[i]);
            }
        }
           /* protected void button_clear_Click(object sender, EventArgs e)
             {
            Response.Redirect("OpenPDF.aspx");
            string FilePath = Server.MapPath("Pro-ASP-Net-MVC-5-Adam-Freeman(www.ebook-dl.com).pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }*/
        }
}