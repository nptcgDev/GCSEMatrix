<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchNonEBSLearners.aspx.cs" Inherits="GCSEMatrix.SearchNonEBSLearners" %>

<!DOCTYPE html>
	<link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
	<link href="Content/custom.css" rel="stylesheet" type="text/css" />
	<script src="Scripts/jquery-3.1.1.js"></script>
	<script src="Scripts/bootstrap.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>NPTC Group - GCSE Matrix</title>
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
				<img style="width: 65%;" alt="nptc group logo" src="nptc-logo.png"/>

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

				<asp:Label style="color: white; margin-top:15px; float: right;" ID="Label1" runat="server">
					 <% Response.Write(HttpContext.Current.User.Identity.Name); %>
				 </asp:Label>
			</div>
			<!-- /.navbar-collapse -->
		</div>
		<!-- /.container -->
	</nav>           
		<asp:Label CssClass="sr-only" ID="lblUser" runat="server" >
		<% Response.Write(HttpContext.Current.User.Identity.Name); %>
		 </asp:Label>
		  <div class="container">
			  <div class="alert alert-success">
				<p>If you wish to update the details of an applicant who is on EBS, then <a href="Index.aspx">Click this link</a></p>
			</div>
				<div class="row">
			<div style="padding-left: 0px !important;" class="col-lg-12">
				<h1>GCSE Matrix - Non EBS learners</h1>
				<p class="lead">Please Enter Student Name</p>
				<div style="padding-left: 0px !important;" class="col-lg-6">
					<div class="input-group">
							<asp:TextBox ID="txtstudent_name" runat="server" required CssClass="form-control"></asp:TextBox>
					  <span class="input-group-btn">
						  <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-default" />
					  </span>
					</div><!-- /input-group -->
				  </div><!-- /.col-lg-6 -->
			</div>
		</div>
		<br /><br />
		<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetExistingNonEBSLearnerDetails" TypeName="GCSEMatrix.DAO.ReturnData">
			<SelectParameters>
				<asp:ControlParameter ControlID="txtstudent_name" Name="full_name" PropertyName="Text" Type="String" />
			</SelectParameters>
		</asp:ObjectDataSource>
		<asp:Repeater ID="RptSearchNonEBSLearners" runat="server" DataSourceID="ObjectDataSource1" OnItemDataBound="RptSearchNonEBSLearners_ItemDataBound">
			<HeaderTemplate>
				<table class="table table-bordered table-inverse">
					<tr>
						<th>UCI number</th>
						 <th>Student Name</th>
						<th>Action</th>
					</tr>
			</HeaderTemplate>
			<ItemTemplate>
				<tr>
					<td><%# Eval("UCI_NUMBER") %></td>
					<td><%# Eval("student_name") %> </td>
					<td>
						<asp:HyperLink ID="lnkUpdateDetails" runat="server" CssClass="btn btn-default" NavigateUrl='<%#"UpdateNonEBSLearnerDetails.aspx?UCI_NUMBER=" + Eval("UCI_NUMBER") %>'>Update Results</asp:HyperLink>
					</td>
				</tr>
			</ItemTemplate>
			<FooterTemplate>
			  </table>
						<%-- Label used for send people to matrix page with default person code (0) --%>
				<asp:Label ID="NoResults" runat="server">Cannot find learner, please search again</asp:Label>
			</FooterTemplate>
		</asp:Repeater>
		</div>
	</form>
</body>

</html>
