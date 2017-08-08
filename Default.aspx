<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GCSEMatrix.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
	<link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
	<link href="Content/custom.css" rel="stylesheet" type="text/css" />
	<link href="Content/jquery-3.1.1.js" type="text/javascript" />
	<link href="Scripts/bootstrap.js" type="text/javascript" />

	<title>GCSE Matrix - Learner</title>
	</head>
<body>
	<form id="form1" runat="server">
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
				<a class="navbar-brand" href="index.html">NPTC Group</a>

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

		<div class="container">
			<!-- /.row -->
			<div class="row">
				<asp:Label ID="lblUsername" runat="server" Text="willrob"></asp:Label>
				<div class="form-inline">
					<label for="txtStudentID" class="lead">Student ID:</label>
					<asp:TextBox ID="txtStudentID" class="form-control" runat="server" Enabled="False"></asp:TextBox>
				</div>
				<div class="form-inline">
					<label for="txtStudentName" class="lead">Student Name:</label>
					<asp:TextBox ID="txtStudentName" required class="form-control" Enabled="False" runat="server"></asp:TextBox>
				</div>

				<div class="form-inline">
					<label for="txtULN" class="lead">ULN:</label>
					<asp:TextBox ID="txtULN" class="form-control" runat="server" MaxLength="13"></asp:TextBox>
				</div>

				<div class="form-inline">
					<label for="txtUCI" class="lead">UCI:</label>
					<asp:TextBox ID="txtUCI" class="form-control" runat="server" MaxLength="13"></asp:TextBox>
				</div>
				<div class="table-responsive col-lg-6">
				 <p class="lead">GCSEs</p>
					 <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetGCSESubjectList" TypeName="GCSEMatrix.DAO.ReturnSubjects"></asp:ObjectDataSource>
					<asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
						<HeaderTemplate>
				<table style="width:auto;" class="table table-bordered table-inverse">
					<tr>
						<th>Subject</th>
						 <th>Grade</th>
					</tr>
			</HeaderTemplate>
			<ItemTemplate>
				<tr>
					<td><asp:Label ID="lblSubjectName" runat="server" CssClass="form-control" Text='<%# Eval("SUBJECT_NAME") %>'></asp:Label></td>
					<td>
						<asp:DropDownList ID="DDLGCSEGrade" CssClass="form-control" runat="server">
						<asp:ListItem>Select Grade</asp:ListItem>
						<asp:ListItem>A*</asp:ListItem>
						<asp:ListItem>A</asp:ListItem>
						<asp:ListItem>B</asp:ListItem>
						<asp:ListItem>C</asp:ListItem>
						<asp:ListItem>D</asp:ListItem>
						<asp:ListItem>E</asp:ListItem>
						<asp:ListItem>F</asp:ListItem>
						<asp:ListItem>G</asp:ListItem>                       
						</asp:DropDownList>
					</td>
					<td class="sr-only">
						<asp:Label ID="lblSubjectType" runat="server" CssClass="sr-only" Text='<%# Eval("SUBJECT_CODE") %>'></asp:Label>
					</td>
				</tr>
			</ItemTemplate>
			<FooterTemplate>
				</table>
				</FooterTemplate>   
					</asp:Repeater>
				</div>
				<div class="table-responsive col-lg-6">
					<table class="table table-bordered table-inverse">
						<p class="lead">Vocationals</p>
						<thead>
							<th>Subject</th>
							<th>Grade</th>
						</thead>
						<tbody>
							<tr>
								<td><asp:DropDownList ID="DDLVocationalSubject1" runat="server" CssClass="form-control" AutoPostBack="true">
									<asp:ListItem Value="Select Subject">Select Subject</asp:ListItem>
                                    <asp:ListItem Value="BTEC-AW2">BTEC L2 AWARD</asp:ListItem>
									<asp:ListItem Value="BTEC-CE2">BTEC L2 Certificate</asp:ListItem>
									<asp:ListItem Value="BTEC-EC2">BTEC Ext Cert</asp:ListItem>
                                    <asp:ListItem Value="BTEC-EC2">BTEC Ext Cert</asp:ListItem>
									</asp:DropDownList></td>
								<td><asp:DropDownList ID="DDLVocationalGrade1"  CssClass="form-control" runat="server">
									<asp:ListItem>Select Grade</asp:ListItem>
									<asp:ListItem Text="PASS">PASS</asp:ListItem>
									</asp:DropDownList></td>
							</tr>
							<tr>
								<td><asp:DropDownList ID="DDLVocationalSubject2" runat="server" CssClass="form-control" AutoPostBack="true">

								    </asp:DropDownList></td>
								<td><asp:DropDownList ID="DDLVocationalGrade2"  CssClass="form-control" runat="server"></asp:DropDownList></td>
							</tr>
							<tr>
								<td><asp:DropDownList ID="DDLVocationalSubject3" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList></td>
								<td><asp:DropDownList ID="DDLVocationalGrade3"  CssClass="form-control" runat="server"></asp:DropDownList></td>
							</tr>
							<tr>
								<td><asp:DropDownList ID="DDLVocationalSubject4" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList></td>
								<td><asp:DropDownList ID="DDLVocationalGrade4"  CssClass="form-control" runat="server"></asp:DropDownList></td>
							</tr>
							<tr>
								<td><asp:DropDownList ID="DDLVocationalSubject5" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList></td>
								<td><asp:DropDownList ID="DDLVocationalGrade5"  CssClass="form-control" runat="server"></asp:DropDownList></td>
							</tr>
							<tr>
								<td><asp:DropDownList ID="DDLVocationalSubject6" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList></td>
								<td><asp:DropDownList ID="DDLVocationalGrade6"  CssClass="form-control" runat="server"></asp:DropDownList></td>
							</tr>
						</tbody>
					</table>
				</div>
			</div>
			<asp:Label ID="lbltrue" runat="server" Text="Y"></asp:Label>
			<asp:Label ID="lblplr" runat="server" Text="N"></asp:Label>
			<asp:Button ID="BtnSaveResults" cssClass="btn btn-default" runat="server" Text="Save Results" OnClick="BtnSaveResults_Click" />

	  </div> <!-- /. Row -->
	</form>
</body>
</html>

