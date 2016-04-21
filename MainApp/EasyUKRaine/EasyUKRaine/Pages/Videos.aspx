<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainWindow.Master" AutoEventWireup="true" CodeBehind="Videos.aspx.cs" Inherits="EasyUKRaine.Pages.Videos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    
    <style>

         #video12 {
             margin-left: 135px;
             position: relative;
             padding-bottom: 75%;
         }
        #video12 iframe {
            position: absolute;
            width: calc(80%);
            height: 80%;
        }
        #video12 div {
            position: absolute;
            top: 0;
            right: 0;
            width: 5em;
            height: 80%;
            overflow-y: auto;
        }
        #video12 span {
            display: block;
            text-align: center;
        }
        #video12 span:hover {
            color: #ff3200;
            cursor: pointer;
        }
    </style>

<div id="video12">
  <iframe src="http://www.youtube.com/embed/UYRpLN4OnuQ" allowfullscreen="" frameborder="0"></iframe>
  <div>
    <span data-video="UYRpLN4OnuQ" tabindex="0">video 1</span>
    <span data-video="lSBqkdBDopU" tabindex="0">video 2</span>
    <span data-video="qIIA5-d76q4" tabindex="0">video 3</span>
    <span data-video="_dhF3ffDUg8" tabindex="0">video 4</span>
  </div>
</div>
      
<script>
var IMG = document.querySelectorAll('#video12 span'),
    IFRAME = document.querySelector('#video12 iframe');
for (var i = 0; i < IMG.length; i++) {
  IMG[i].onclick = function() {
    IFRAME.src = 'http://www.youtube.com/embed/' + this.dataset.video + '?rel=0&autoplay=1';
    if(this.dataset.end) IFRAME.src = IFRAME.src.replace(/([\s\S]*)/g, '$1&end=' + this.dataset.end);
    if(this.dataset.start) IFRAME.src = IFRAME.src.replace(/([\s\S]*)/g, '$1&start=' + this.dataset.start);
    this.style.backgroundColor='rgba(0,0,0,.2)';
  }
}
</script>
</asp:Content>
