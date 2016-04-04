using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using EasyUKRaine.Models.Repo;

namespace EasyUKRaine.kuchmynda
{
    public partial class Vocabulary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void List_Load(object sender, EventArgs e)
        {
            if(EasyUKRaine.kuchmynda.Tags.repo==null)
                EasyUKRaine.kuchmynda.Tags.repo = new Repo();
            Header.Text = EasyUKRaine.kuchmynda.Tags.repo.topics.First(x => x.header == Request.QueryString["topic"]).header;
            var words = EasyUKRaine.kuchmynda.Tags.repo.topics.First(x => x.header == Request.QueryString["topic"]).words;  
            Header.Font.Name = "Helvetica";
            Header.Font.Size = 24;
            int count = words.Count;
            List<List<TableCell>> rows = new List<List<TableCell>>();
            List<TableCell> row = new List<TableCell>();
            int Index = 0;
            //HtmlTable table = new HtmlTable();

            for (var i = 0 ; i < words.Count ; i++)
            {

                TableCell current = new TableCell();
                TableRow imagerow = new TableRow();
                TableRow textrow = new TableRow();
                Table tcurrent = new Table();
                TableCell image = new TableCell()
                {
                    HorizontalAlign = HorizontalAlign.Center,
                    VerticalAlign = VerticalAlign.Middle,
                    Width = Unit.Pixel(512),
                    Height = Unit.Pixel(512),
                    BackColor = System.Drawing.Color.White
                };
                TableCell header = new TableCell()
                {
                    HorizontalAlign = HorizontalAlign.Center,
                    VerticalAlign = VerticalAlign.Middle
                };
                //------тут пофіксити на різін значення
                var pic = words[i].translates[0].image;
                //------тут пофіксити на різін значення
                pic.ImageAlign = ImageAlign.Middle;
                pic.CssClass = "PicWordAuto1";
                image.Controls.Add(pic);
                Label headrl = new Label();
                headrl.Font.Name = "Helvetica";
                headrl.Font.Size = 24;
                headrl.Text = words[i].word+" : ";
                for (var j = 0 ; j < words[i].translates.Count ; j++)
                    headrl.Text += $"{words[i].translates[j].translate};";
                headrl.Text= headrl.Text.TrimEnd(';');
                header.Controls.Add(headrl);
                imagerow.Cells.Add(image);
                textrow.Cells.Add(header);
                tcurrent.Rows.Add(imagerow);
                tcurrent.Rows.Add(textrow);
                current.Controls.Add(tcurrent);
                row.Add(current);
                if ((i + 1) % 4 == 0)
                {
                    rows.Add(row);
                    row = new List<TableCell>();
                }
            }
            rows.Add(row);
            Words.Rows.Clear();
            foreach (var cells in rows)
            {
                TableRow _row = new TableRow();
                foreach (var cell in cells)
                    _row.Cells.Add(cell);
                Words.Rows.Add(_row);
            }
        }
    }
}