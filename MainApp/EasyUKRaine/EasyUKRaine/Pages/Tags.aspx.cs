using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using EasyUKRaine.Models.Repo;
using EasyUKRaine.Models.Repository;

namespace EasyUKRaine.kuchmynda
{
    public partial class Tags : System.Web.UI.Page
    {
        public static Repo repo = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect();
        }
        protected void Tages_Load(object sender, EventArgs e)
        {
            repo = new Repo();
            List<KeyValuePair<String, ImageButton>> tags =
                repo.topics.Select(t => new KeyValuePair<string, ImageButton>($"{t.header}({t.capacity})", t.image)).ToList();
            Tages.Controls.Clear();

            TableRow row = new TableRow();
            for (int index = 0; index < tags.Count; index++)
            {
                var item = tags[index];
                row.ForeColor = System.Drawing.Color.Black;
                
                TableCell Cell = new TableCell()
                {
                    HorizontalAlign = HorizontalAlign.Center,
                    VerticalAlign = VerticalAlign.Middle
                };
                Table Current = new Table();

                TableRow row1 = new TableRow();
                TableCell c1 = new TableCell()
                {
                    HorizontalAlign = HorizontalAlign.Center,
                    VerticalAlign = VerticalAlign.Middle
                };
                item.Value.ID = tags[index].Key.Split('(').First();
                item.Value.Click += delegate
                {                                                                     
                    Response.Redirect($"Vocabulary.aspx?topic={Request.Params.AllKeys[1].Split('.').First()}");
                };
                item.Value.Width = 200;
                item.Value.Height = 200;
                c1.Controls.Add(item.Value);
                row1.Controls.Add(c1);
                TableRow row2 = new TableRow();
                TableCell c2 = new TableCell()
                {
                    HorizontalAlign = HorizontalAlign.Center,
                    VerticalAlign = VerticalAlign.Middle
                };
                var la=new Label {Text = item.Key };
                la.Font.Name = "Helvetica";
                la.Font.Size = 18;
                c2.Controls.Add(la);
                row2.Controls.Add(c2);
                Current.Rows.Add(row1);
                Current.Rows.Add(row2);  
                Cell.Controls.Add(Current); 
                row.Controls.Add(Cell);
                if ((index+1)%2 == 0)
                {
                    Tages.Rows.Add(row);
                }
            }
            
        }
    }
}
