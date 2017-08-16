<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="GCSEMatrix.index" %>

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
				<img style="width: 65%;" src="nptc-logo.png"/>

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
		<asp:Label ID="lblUser" runat="server" >
		<% Response.Write(HttpContext.Current.User.Identity.Name); %>
		 </asp:Label>
		  <div class="container">
			  <div class="alert alert-success">
				<p>If you wish to update the details of an applicant who is not on EBS, then <a href="#">click here</a></p>
			</div>
				<div class="row">
			<div style="padding-left: 0px !important;" class="col-lg-12">
				<h1>GCSE Matrix</h1>
				<p class="lead">Please Enter Student Name</p>
				<div style="padding-left: 0px !important;" class="col-lg-6">
					<div class="input-group">
							<asp:TextBox ID="txtperson_code" runat="server" required CssClass="form-control"></asp:TextBox>
					  <span class="input-group-btn">
						  <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-default" />
					  </span>
					</div><!-- /input-group -->
				  </div><!-- /.col-lg-6 -->
			</div>
		</div>
		<br /><br />
		<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetLearnerDetails" TypeName="GCSEMatrix.DAO.ReturnData">
			<SelectParameters>
				<asp:ControlParameter ControlID="txtperson_code" Name="full_name" PropertyName="Text" Type="String" />
			</SelectParameters>
		</asp:ObjectDataSource>
		<asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1" OnItemDataBound="Repeater1_ItemDataBound">
			<HeaderTemplate>
				<table class="table table-bordered table-inverse">
					<tr>
						<th>Person Code</th>
						<th>Image</th>
						 <th>Full Name</th>
						<th>Action</th>
					</tr>
			</HeaderTemplate>
			<ItemTemplate>
				<tr>
					<td><%# Eval("person_code") %></td>
					<td><asp:Image ID="learnerImage" CssClass="img-rounded" runat="server" ImageAlign="Left" ImageUrl='<%# "https://ebsagent.ad.nptcgroup.ac.uk//personimage.aspx?personcode=" +  Eval("person_code")  %>' Height="60px" AlternateText='' /></td>
					<td><%# Eval("full_name") %> </td>
					<td><asp:HyperLink ID="lnkDetails" runat="server" CssClass="btn btn-default" NavigateUrl='<%#"Default.aspx?person_code=" + Eval("person_code") %>'>View Details</asp:HyperLink>
						<asp:HyperLink ID="lnkUpdateDetails" runat="server" CssClass="btn btn-default" NavigateUrl='<%#"UpdateDetails.aspx?person_code=" + Eval("person_code") %>'>Update Details</asp:HyperLink>
					</td>
				</tr>
			</ItemTemplate>
			<FooterTemplate>
			  </table>
						<%-- Label used for send people to matrix page with default person code (0) --%>
				<asp:HyperLink ID="lnkNewStudent" NavigateUrl='<%#"Default.aspx?person_code=0"%>' runat="server">If this is a new applicant and has no record in EBS. Click Here to create a new version</asp:HyperLink>
			</FooterTemplate>
		</asp:Repeater>
		</div>
	</form>
</body>

</html>
