using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net;
using EasyUKRaine.Models;

namespace game
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static bool IsGeneration = true;
        public static List<TableRow> tr = new List<TableRow>();
        public static List<string> words = new List<string>();
        public static List<string> symb = new List<string>();
        public static List<string> WordsDB = (new EasyUKRainianEntities()).Word.Select(x => x.Word1.Replace("\"","")).ToList();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsGeneration == true)
                {
                    TableRow t1 = new TableRow();
                    TableCell tc1 = new TableCell();
                    tc1.Text = "Words";
                    TableCell tc2 = new TableCell();
                    tc2.Text = "Points";
                    t1.Cells.Add(tc1);
                    t1.Cells.Add(tc2);
                    tr.Add(t1);
                    Table_res.Rows.Add(tr[0]);
                    for (int i = 0; i < WordsDB.Count; i++)
                    {
                        for (int j = 0; j < WordsDB[i].Length; j++)
                        {
                            if (!symb.Contains(WordsDB[i][j].ToString()) && symb.Count <= 16)
                            {
                                symb.Add(WordsDB[i][j].ToString().ToLower());
                            }
                        }
                    }
                    //symb.Add("а");
                    //symb.Add("б");
                    //symb.Add("в");
                    //symb.Add("г");
                    //symb.Add("д");
                    //symb.Add("е");
                    //symb.Add("є"); 
                    //symb.Add("ж");
                    //symb.Add("з");
                    //symb.Add("и");
                    //symb.Add("і");
                    //symb.Add("ї");
                    //symb.Add("й");
                    //symb.Add("к");            
                    //symb.Add("л");
                    //symb.Add("м");
                    //symb.Add("н");
                    //symb.Add("о");
                    //symb.Add("п");
                    //symb.Add("р");
                    //symb.Add("с");
                    //symb.Add("т");
                    //symb.Add("у");
                    //symb.Add("ф");
                    //symb.Add("х");
                    //symb.Add("ц");
                    //symb.Add("ч");
                    //symb.Add("ш");
                    //symb.Add("щ");
                    //symb.Add("ь");
                    //symb.Add("ю");
                    //symb.Add("я");
                    Random rnd = new Random();
                    string[] k = new string[16];
                    for (int i = 0; i < k.Length; i++)
                    {
                        k[i] = symb[rnd.Next(0, symb.Count)].ToString();
                        symb.Remove(k[i]);
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
                    IsGeneration = false;
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        public static int timeLeft = 180;
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < tr.Count; i++)
            {
                Table_res.Rows.Add(tr[i]);
            }
            if (timeLeft > 10)
            {

                timeLeft = timeLeft - 10;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                timeLabel.Text = "Time's up!";
                int sum = 0;
                for (int i = 1; i < tr.Count; i++)
                {
                    sum += Convert.ToInt32(tr[i].Cells[1].Text.ToString());
                    //Response.Write("Time is over!!! Your Score" + tr[i].Cells[1].Text.T);
                }
                Response.Write("Time is over!!! Your Score" + sum.ToString());
            }
           
        }
        protected void button_submit_Click(object sender, EventArgs e)
        {
            string find = Text1.Text;
            string filePath = @"D:\6 семестр\проект\EasyUKRaine\EasyUKRaine\uk_UA.dic";
            string text = System.IO.File.ReadAllText(filePath);
            var output = text.Split('/').Select(x=>x=x.Replace("\n","")).ToList();
            
            if(output.Contains(find))
            {
                if (words.Contains(find))
                {
                    for (int i = 0; i < tr.Count; i++)
                    {
                        Table_res.Rows.Add(tr[i]);
                    }
                }
                else
                {
                    words.Add(find);
                    TableRow t1 = new TableRow();
                    TableCell tc1 = new TableCell();
                    tc1.Text = find;
                    TableCell tc2 = new TableCell();
                    tc2.Text = find.Length.ToString();
                    t1.Cells.Add(tc1);
                    t1.Cells.Add(tc2);
                    tr.Add(t1);
                    for (int i = 0; i < tr.Count; i++)
                    {
                        Table_res.Rows.Add(tr[i]);
                    }
                }
                
            }
            else
            {
                Response.Write("have not this word");
                for (int i = 0; i < tr.Count; i++)
                {
                    Table_res.Rows.Add(tr[i]);
                }
            }
            Text1.Text = "";
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