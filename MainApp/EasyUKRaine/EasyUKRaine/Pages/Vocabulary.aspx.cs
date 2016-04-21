using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using EasyUKRaine.Models.Repo;

namespace EasyUKRaine.kuchmynda
{
    public partial class Vocabulary : System.Web.UI.Page
    {
        public static Repo repo = null;
        bool IsTag=true;
        string Topic=null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Tages_Load(object sender, EventArgs e)
        {
            if (IsTag)
            {
                repo = new Repo();
                List<KeyValuePair<String, ImageButton>> tags =
                repo.topics.Select(t => new KeyValuePair<string, ImageButton>($"{t.header}({t.capacity})", t.image)).ToList();
                Tages.Controls.Clear();
                TableRow row = new TableRow();
                for (int index = 0 ; index < tags.Count ; index++)
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
                        IsTag = false;
                        Topic = Request.Params.AllKeys[1].Split('.').First().Split('$').Last();
                        Tages_Load(this, null);

                        // Response.Redirect($"Vocabulary.aspx?topic={Request.Params.AllKeys[1].Split('.').First()}");
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
                    if ((index + 1) % 2 == 0)
                    {
                        Tages.Rows.Add(row);
                    }
                }
            }
            else
            {
                // Table Words=new Table();
                Label Header=new Label();
                Header.Text = Tags.repo.topics.First(x => x.header == Topic).header;
                var words = Tags.repo.topics.First(x => x.header == Topic).words;
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
                        Width = Unit.Pixel(200),
                        Height = Unit.Pixel(200),
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
                    pic.Width = 200;
                    pic.Height = 200;
                    //pic.CssClass = "PicWordAuto1";
                    image.Controls.Add(pic);
                    Label headrl = new Label();
                    headrl.Font.Name = "Helvetica";
                    headrl.Font.Size = 14;
                    headrl.Text = words[i].word + " : ";
                    for (var j = 0 ; j < words[i].translates.Count ; j++)
                        headrl.Text += $"{words[i].translates[j].translate};";
                    headrl.Text = headrl.Text.TrimEnd(';');
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
                Tages.Rows.Clear();
                foreach (var cells in rows)
                {
                    TableRow _row = new TableRow();
                    foreach (var cell in cells)
                        _row.Cells.Add(cell);
                    Tages.Rows.Add(_row);
                }
            }
        }


        /*
        protected void List_Load(object sender, EventArgs e)
        {
           /* if(EasyUKRaine.kuchmynda.Tags.repo==null)
                EasyUKRaine.kuchmynda.Tags.repo = new Repo();
            Header.Text = EasyUKRaine.kuchmynda.Tags.repo.topics.First(x => x.header == Request.QueryString["topic"]).header;
            var words = EasyUKRaine.kuchmynda.Tags.repo.topics.First(x => x.header == Request.QueryString["topic"]).words;  
            Header.Font.Name = "Helvetica";
            Header.Font.Size = 24;
            int count = words.Count;
            List<List<TableCell>> rows = new List<List<TableCell>>();
            List<TableCell> row = new List<TableCell>();
            int Index = 0;
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
        }*/
    }
}