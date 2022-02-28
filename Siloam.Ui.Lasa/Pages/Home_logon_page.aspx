<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home_logon_page.aspx.cs" Inherits="Siloam.Ui.Lasa.Pages.Home_logon_page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<!--###########################################################################################################################################-->
<!------------------------------------------------------------------ The Script ----------------------------------------------------------------->

 <script type="text/javascript">



     //function preventBack() {
     //    window.history.forward();
     //}
     //setTimeout("preventBack()", 0);
     //window.onunload = function () {
     //    null
     //};

        //$(document).ready(function () {
        //    // Handler for .ready() called.
        //    window.setTimeout(function () {
        //        location.href = "LasaMaster.aspx";
        //    }, 1500);
        //});



 </script>


<!--###########################################################################################################################################-->
<!------------------------------------------------------------------ The Content ---------------------------------------------------------------->

        <div class="login-box-body" style="margin-top:10px">  
            <div class="row">
                <div class="col-sm-12">
                    <div style="text-align:center; margin-top:15%;">
                        <asp:Image ID="ImageLoad" ImageUrl="~/Assets/hospital.gif" style="width:350px; margin-bottom:-50px; margin-top:-140px;" runat="server" />
                        <h1>..:: <asp:Label ID="LabelWelcome" runat="server" Text="WELCOME"></asp:Label> ::..</h1>
                        <h1 style="margin-top:-10px;"> <asp:Label ID="LabelName" runat="server" Text="WELCOME"></asp:Label> </h1>       
                    </div>
                </div>
            </div>
        </div>

</asp:Content>
