<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="GCSEMatrix.index" %>

<!DOCTYPE html>
	<link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
	<link href="Content/custom.css" rel="stylesheet" type="text/css" />
	<link href="Content/jquery-3.1.1.js" type="text/javascript" />
	<link href="Scripts/bootstrap.js" type="text/javascript" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
			<!-- Navigation -->
	<nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
		<div class="container">
			<!-- Brand and toggle get grouped for better mobile display -->
			<div class="navbar-header">
				<button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
					<span class="sr-only">Toggle navigation</span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
				</button>
				<a class="navbar-brand" href="#">NPTC Group</a>
			</div>
			<!-- Collect the nav links, forms, and other content for toggling -->
			<div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
				<ul class="nav navbar-nav">
					<li>
						<a href="#"></a>
					</li>
					<li>
						<a href="#"></a>
					</li>
					<li>
						<a href="#"></a>
					</li>
				</ul>
			</div>
			<!-- /.navbar-collapse -->
		</div>
		<!-- /.container -->
	</nav>           

		<asp:Label ID="lblUser" CssClass="sr-only " runat="server" >
		<% Response.Write(HttpContext.Current.User.Identity.Name); %>
		 </asp:Label>
		  <div class="container">
				<div class="row">
			<div style="padding-left: 0px !important;" class="col-lg-12">
				<h1>GCSE Matrix</h1>
				<p class="lead">Please enter Student Name or Person Code</p>
				<div style="padding-left: 0px !important;" class="col-lg-6">
					<div class="input-group">
							<asp:TextBox ID="txtperson_code" runat="server" required CssClass="form-control" MaxLength="9"></asp:TextBox>
					  <span class="input-group-btn">
						  <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-default" />
					  </span>
					</div><!-- /input-group -->
				  </div><!-- /.col-lg-6 -->
			</div>
		</div><br /><br />

		<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetLearnerDetails" TypeName="GCSEMatrix.DAO.ReturnSubjects">
			<SelectParameters>
				<asp:ControlParameter ControlID="txtperson_code" Name="person_code" PropertyName="Text" Type="Int32" />
			</SelectParameters>
		</asp:ObjectDataSource>
		<asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
			<HeaderTemplate>
				<table class="table table-bordered table-inverse">
					<tr>
						<th>Image</th>
						<th>Person Code</th>
						 <th>Full Name</th>
						<th>Action</th>
					</tr>
			</HeaderTemplate>
			<ItemTemplate>
				<tr>
					<td><asp:Image ID="learnerImage" CssClass="img-rounded" runat="server" ImageAlign="Left" ImageUrl='<%# "https://ebsagent.ad.nptcgroup.ac.uk//personimage.aspx?personcode=" +  Eval("person_code")  %>' Height="60px" /></td>
					<td><%# Eval("person_code") %></td>				
					<td><%# Eval("full_name") %> </td>
					<td><asp:HyperLink ID="lnkDetails" runat="server" CssClass="btn btn-default" NavigateUrl='<%#"Default.aspx?person_code=" + Eval("person_code") %>'>View Details</asp:HyperLink></td>
				</tr>
			</ItemTemplate>
			<FooterTemplate>
				</table>
				</FooterTemplate>
		</asp:Repeater>
			  </div>
	</form>
</body>

</html>
