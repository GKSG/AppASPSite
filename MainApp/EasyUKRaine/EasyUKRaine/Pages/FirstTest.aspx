<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainWindow.Master" AutoEventWireup="true" CodeBehind="FirstTest.aspx.cs" Inherits="EasyUKRaine.Pages.FirstTest" %>
<%@ Import Namespace="System.Activities.Statements" %>
<%@ Import Namespace="EasyUKRaine.Models.Repository" %>
<%@ Import Namespace="System.Web.Routing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    
    
    <div id="content">



                <%
                    try
                    {
                        Console.WriteLine(ShuflleTest().Count);
                        foreach (var l in GetProducts())
                        {
                            
                           // if (Repository.GetInstance().HelpWithFT_list.Contains(l.ID)) continue;
                            Response.Write("<div >");
                            Response.Write(string.Format("<h3>{1})  {0}</h3>", l.quizz, l.ID));

                            foreach (var list in l.AnswerList)
                            {

                                Response.Write(string.Format("<input type=\"radio\" ID=\"RB{0}\" runat=\"server\" name=\"{1}\" value='{2}'/> {2} <br />", list, l.answer, list));
                            }
                            Response.Write("</div >");

                            Repository.GetInstance().HelpWithFT_list.Add(l.ID);

                        }
                    }
                    catch(Exception e) {} %>
    </div>

    <div class="pager">
<%
  //  int i = CurrentPage;
    // string pathBack =  RouteTable.Routes.GetVirtualPath(null, null,new RouteValueDictionary() {{ "page", --i }}).VirtualPath;
   // string pathNext = RouteTable.Routes.GetVirtualPath(null, null,new RouteValueDictionary() {{ "page", ++i }}).VirtualPath;

    // Response.Write(string.Format("<a href='{0}'{1}> Back </a>", pathBack, "class='selected'"));

    if (CurrentPage < 10)
        Response.Write(string.Format("<button type='submit' name='{0}'{1}> Next</button>", "pathNext", "class='selected'"));
    else
    {
        Response.Write(string.Format("<button type='submit' id='submit_res' name='go_out'  value='go' runat='server' > Submit</button>"));
    }



%>

</div>
    

</asp:Content>
