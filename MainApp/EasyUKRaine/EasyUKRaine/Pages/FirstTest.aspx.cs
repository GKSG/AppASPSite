using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using EasyUKRaine.Models;
using EasyUKRaine.Models.Repository;
using EasyUKRaine.Pages.Helpers;


namespace EasyUKRaine.Pages
{
    public partial class FirstTest : System.Web.UI.Page
    {
        private List<FTquestion> list_inForm = new List<FTquestion>();
        private int pageSize = Repository.GetInstance().GetFTquestions.Count;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                if (Request.Form["pathNext"] != null && CurrentPage < Repository.GetInstance().GetFTquestions.Count)
                {
                    int i = CurrentPage;

                    switch (CurrentPage)
                    {
                        case 1:
                        {
                            HelpSwitch(0);
                            break;
                        }
                        case 2:
                        {
                            HelpSwitch(1);
                            break;
                        }
                        case 3:
                        {
                            HelpSwitch(2);
                            break;
                        }
                        case 4:
                        {
                            HelpSwitch(3);
                            break;
                        }
                        case 5:
                        {
                            HelpSwitch(4);
                            break;
                        }
                        case 6:
                        {
                            HelpSwitch(5);
                            break;
                        }
                        case 7:
                        {
                            HelpSwitch(6);
                            break;
                        }
                        case 8:
                        {
                            HelpSwitch(7);
                            break;
                        }
                        case 9:
                        {
                            HelpSwitch(8);
                            break;
                        }
                        case 10:
                        {
                            HelpSwitch(9);
                            break;
                        }
                        default:
                            break;
                    }

                    Response.Redirect(
                        RouteTable.Routes.GetVirtualPath(null, null, new RouteValueDictionary() {{"page", ++i}})
                            .VirtualPath);
                }

                string go_out = Request.Form["go_out"];
                if (go_out == "go")
                {

                    Repository.GetInstance().CurrentUser.Level = Repository.GetInstance().CurrentUser.Score / 100;
                    Repository.GetInstance().UpdateUserAccount(Repository.GetInstance().CurrentUser);


                    Response.Redirect(RouteTable.Routes.GetVirtualPath(null, null).VirtualPath);
                    
                }
            }

            if (!Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect(RouteTable.Routes.GetVirtualPath(null, null).VirtualPath);
            }
        }

        private void HelpSwitch(int i)
        {
            if (this.Request.Form[Repository.GetInstance().GetFTquestions[i].answer] != null)
            {
                string answer =
                    Request.Form[Repository.GetInstance().GetFTquestions[i].answer].ToString();
                if (answer == Repository.GetInstance().GetFTquestions[i].answer)
                {
                    Repository.GetInstance().CurrentUser.Score += 100;
                    
                }
            }
        }

        public List<FTquestion> ShuflleTest()
        {
            Random r = new Random();
            List<int> usedIndex = new List<int>();

            List<FTquestion> list = Repository.GetInstance().GetFTquestions;
            List<FTquestion> listGood = new List<FTquestion>();


            while (true)
            {
                if (usedIndex.Count == list.Count)
                {
                    break;
                }
                int tmp = r.Next(1, 11);
                if (!usedIndex.Contains(tmp))
                {
                    usedIndex.Add(tmp);

                }

            }


            for (int i = 0; i < list.Count; i++)
            {
                listGood.Add(list.Find(delegate (FTquestion ft) { return ft.ID == usedIndex[i]; }));
            }

            return listGood;
        }



        public IEnumerable<FTquestion> GetProducts()
        {
            IEnumerable<FTquestion> tmp = Repository.GetInstance().GetFTquestions.Skip((CurrentPage - 1)).Take(1);
            return tmp;
        }

        protected int CurrentPage
        {
            get
            {
                int page = GetPageFromRequest();
                return page > MaxPage ? MaxPage : page;
            }
        }

        protected int MaxPage
        {
            get
            {
                return ShuflleTest().Count;
            }
        }

        private int GetPageFromRequest()
        {
            int page;
            string reqValue = (string)RouteData.Values["page"] ??
            Request.QueryString["page"];
            return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;
        }


    }
}