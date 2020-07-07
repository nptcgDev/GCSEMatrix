<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="GCSEMatrix.ErrorPage.Error" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../Content/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Content/custom.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-3.2.1.js"></script>
    <script src="../Scripts/bootstrap.js"></script>

    <title>NPTC Group - an error has occurred</title>
</head>
<body>
<nav class="navbar navbar-inverse navbar-fixed" role="navigation">
    <div class="container">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
        </div>
        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav">
                <li>
                    <a href="http://ebsagent.ad.nptcgroup.ac.uk/">Back to Agent</a>
                </li>
                <li>
                </li>
            </ul>
            <asp:label style="color: white; margin-top: 15px; float: right;" id="lblUser" runat="server">
                <% Response.Write(HttpContext.Current.User.Identity.Name); %>
            </asp:label>
        </div>
        <!-- /.navbar-collapse -->
    </div>
    <!-- /.container -->
</nav>
    <form id="form1" runat="server">
    <div class="container">
        <div class="row">
            <div style="padding-left: 0 !important; top: 0px; left: 0px;" class="col-lg-12">
                <h1>An error has occurred.</h1>
                <asp:Label ID="Label2" runat="server" CssClass="lead" Text="For help on this matter, please contact"> </asp:Label><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="mis-developers@nptcgroup.ac.uk" CssClass="lead"> mis-developers@nptcgroup.ac.uk.</asp:HyperLink><br /><br />
                 <asp:Label ID="Label3" runat="server" CssClass="lead" Text="We apologise for the inconvenience caused."> </asp:Label><br /><br />
                <asp:Label ID="Label4" runat="server" CssClass="lead" Text="MIS"></asp:Label>
            </div>
            </div>
    </div>
    </form>
    </body>
</html>