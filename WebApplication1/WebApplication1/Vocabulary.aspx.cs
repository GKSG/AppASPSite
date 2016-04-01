using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Repo;

namespace WebApplication1
{
    public partial class Vocabulary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void List_Load(object sender, EventArgs e)
        {
            if(Tags.repo==null)
                Tags.repo = new Repository();
            Header.Text = Tags.repo.topics.First(x => x.header == Request.QueryString["topic"]).header;
            var words = Tags.repo.topics.First(x => x.header == Request.QueryString["topic"]).words;  
            Header.Font.Name = "Cambria Math";
            Header.Font.Size = 24;
            int count = words.Count;
            List<List<TableCell>> rows = new List<List<TableCell>>();
            List<TableCell> row = new List<TableCell>();
            int Index = 0;
            for (var i = 0; i < words.Count; i++)
            {
                
                TableCell current = new TableCell();
                TableRow imagerow = new TableRow();
                TableRow textrow = new TableRow();
                Table tcurrent = new Table();
                TableCell image = new TableCell() {HorizontalAlign=HorizontalAlign.Center,VerticalAlign=VerticalAlign.Middle,Width=Unit.Pixel(512),Height=Unit.Pixel(512),BackColor=System.Drawing.Color.White};
                TableCell header = new TableCell(){HorizontalAlign=HorizontalAlign.Center,VerticalAlign=VerticalAlign.Middle};
                var pic = words[i].translates[0].image;
                pic.ImageAlign = ImageAlign.Middle;
                pic.CssClass = "PicWordAuto1";
                image.Controls.Add(pic);
                Label headrl = new Label();
                headrl.Font.Name = "Cambria Math";
                headrl.Font.Size = 24;
                for (var j = 0 ; j < words[i].translates.Count ; j++)
                    headrl.Text += $"{words[i].translates[j].translate};";
                header.Controls.Add(headrl);
                imagerow.Cells.Add(image);
                textrow.Cells.Add(header);
                tcurrent.Rows.Add(imagerow);
                tcurrent.Rows.Add(textrow);
                current.Controls.Add(tcurrent);
                row.Add(current);
                //if ((i+1)%5 == 0)
                    rows.Add(row); 
            }
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