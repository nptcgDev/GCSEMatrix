<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GCSEMatrix.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
	<link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
	<link href="Content/custom.css" rel="stylesheet" type="text/css" />
	<script src="Scripts/jquery-3.1.1.js"></script>
	<script src="Scripts/bootstrap.js"></script>

	<title>NPTC Group - Learner</title>
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
				<asp:Label style="color: white; margin-top:15px; float: right;" ID="Label1" runat="server"> <% Response.Write(HttpContext.Current.User.Identity.Name); %></asp:Label>
			</div>
			<!-- /.navbar-collapse -->
		</div>
		<!-- /.container -->
	</nav>

		<div class="container">
		   <asp:Label CssClass="sr-only" ID="lblUser" runat="server" > <% Response.Write(HttpContext.Current.User.Identity.Name); %></asp:Label>
			<!-- /.row -->
			<div class="row">
				<div class="form-inline">
					<asp:Label ID="lblStudentID" runat="server" CssClass="lead">Student ID:</asp:Label>
					<asp:TextBox ID="txtStudentID" class="form-control" runat="server"></asp:TextBox>
				</div>
				<div class="form-inline">
					<label for="txtStudentName" id="lblStudentName" required class="lead">Student Name:</label>
					<asp:TextBox ID="txtStudentName" class="form-control" runat="server"></asp:TextBox>
				</div>

				<div class="form-inline">
					<label for="txtULI" class="lead">ULI:</label>
					<asp:TextBox ID="txtULI" required class="form-control" placeholder="E.G L587034202311" runat="server" MaxLength="13"></asp:TextBox>

				</div>
				<div class="form-inline">
					<label for="txtUCI" class="lead">UCI:</label>
					<asp:TextBox ID="txtUCI" required class="form-control" runat="server" placeholder="E.G 577211217376N" MaxLength="13"></asp:TextBox>

				</div>
				<div class="table-responsive col-lg-6">
				 <p class="lead">GCSEs</p>
					 <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetGCSESubjectList" TypeName="GCSEMatrix.DAO.ReturnData"></asp:ObjectDataSource>
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
								<td><asp:DropDownList ID="DDLVocationalSubject1" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DDLVocationalSubject1_SelectedIndexChanged">
									<asp:ListItem Value="SELECT">Select Subject</asp:ListItem>
									<asp:ListItem Value="BTEC-AW2">BTEC L2 Award - BTEC-AW2</asp:ListItem>
									<asp:ListItem Value="BTEC-CE2">BTEC L2 Certificate - BTEC-CE2</asp:ListItem>
									<asp:ListItem Value="BTEC-EC2">BTEC L2 Ext Cert - BTEC-EC2</asp:ListItem>
									<asp:ListItem Value="BTEC-D12">BTEC Diploma - BTEC-D12</asp:ListItem>
									<asp:ListItem Value="ONAT-FA2">OCR National First Award - ONAT-FA2</asp:ListItem>
									<asp:ListItem Value="ONAT-AW2">OCR National Award - ONAT-AW2</asp:ListItem>
									<asp:ListItem Value="ONAT-FC2">OCR National Certificate - ONAT-FC2</asp:ListItem>
									</asp:DropDownList></td>
								<td><asp:DropDownList ID="DDLVocationalGrade1" AutoPostBack="true"  CssClass="form-control" runat="server">
									<asp:ListItem Value="SELECT">Select Grade</asp:ListItem>
									<asp:ListItem Value="PASS">PASS</asp:ListItem>
									<asp:ListItem Value="MERIT">MERIT</asp:ListItem>
									<asp:ListItem Value="DIST">DIST</asp:ListItem>
									<asp:ListItem Value="DIST*">DIST*</asp:ListItem>
									</asp:DropDownList>

								</td>
							</tr>
							  <tr>
								<td><asp:DropDownList ID="DDLVocationalSubject2" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DDLVocationalSubject2_SelectedIndexChanged">
									<asp:ListItem Value="SELECT">Select Subject</asp:ListItem>
									<asp:ListItem Value="BTEC-AW2">BTEC L2 Award - BTEC-AW2</asp:ListItem>
									<asp:ListItem Value="BTEC-CE2">BTEC L2 Certificate - BTEC-CE2</asp:ListItem>
									<asp:ListItem Value="BTEC-EC2">BTEC L2 Ext Cert - BTEC-EC2</asp:ListItem>
									<asp:ListItem Value="BTEC-D12">BTEC Diploma - BTEC-D12</asp:ListItem>
									<asp:ListItem Value="ONAT-FA2">OCR National First Award - ONAT-FA2</asp:ListItem>
									<asp:ListItem Value="ONAT-AW2">OCR National Award - ONAT-AW2</asp:ListItem>
									<asp:ListItem Value="ONAT-FC2">OCR National Certificate - ONAT-FC2</asp:ListItem>
									</asp:DropDownList></td>
								<td><asp:DropDownList ID="DDLVocationalGrade2" AutoPostBack="true"  CssClass="form-control" runat="server">
									<asp:ListItem Value="SELECT">Select Grade</asp:ListItem>
									<asp:ListItem Value="PASS">PASS</asp:ListItem>
									<asp:ListItem Value="MERIT">MERIT</asp:ListItem>
									<asp:ListItem Value="DIST">DIST</asp:ListItem>
									<asp:ListItem Value="DIST*">DIST*</asp:ListItem>
									</asp:DropDownList>

								</td>
							</tr>
								<tr>
								<td><asp:DropDownList ID="DDLVocationalSubject3" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DDLVocationalSubject3_SelectedIndexChanged">
									<asp:ListItem Value="SELECT">Select Subject</asp:ListItem>
									<asp:ListItem Value="BTEC-AW2">BTEC L2 Award - BTEC-AW2</asp:ListItem>
									<asp:ListItem Value="BTEC-CE2">BTEC L2 Certificate - BTEC-CE2</asp:ListItem>
									<asp:ListItem Value="BTEC-EC2">BTEC L2 Ext Cert - BTEC-EC2</asp:ListItem>
									<asp:ListItem Value="BTEC-D12">BTEC Diploma - BTEC-D12</asp:ListItem>
									<asp:ListItem Value="ONAT-FA2">OCR National First Award - ONAT-FA2</asp:ListItem>
									<asp:ListItem Value="ONAT-AW2">OCR National Award - ONAT-AW2</asp:ListItem>
									<asp:ListItem Value="ONAT-FC2">OCR National Certificate - ONAT-FC2</asp:ListItem>
									</asp:DropDownList></td>
								<td><asp:DropDownList ID="DDLVocationalGrade3" AutoPostBack="true"  CssClass="form-control" runat="server">
									<asp:ListItem Value="Select Grade">Select Grade</asp:ListItem>
									<asp:ListItem Value="PASS">PASS</asp:ListItem>
									<asp:ListItem Value="MERIT">MERIT</asp:ListItem>
									<asp:ListItem Value="DIST">DIST</asp:ListItem>
									<asp:ListItem Value="DIST*">DIST*</asp:ListItem>
									</asp:DropDownList>

								</td>
							</tr>
							<tr>
								<td><asp:DropDownList ID="DDLVocationalSubject4" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DDLVocationalSubject4_SelectedIndexChanged">
									<asp:ListItem Value="SELECT">Select Subject</asp:ListItem>
									<asp:ListItem Value="BTEC-AW2">BTEC L2 Award - BTEC-AW2</asp:ListItem>
									<asp:ListItem Value="BTEC-CE2">BTEC L2 Certificate - BTEC-CE2</asp:ListItem>
									<asp:ListItem Value="BTEC-EC2">BTEC L2 Ext Cert - BTEC-EC2</asp:ListItem>
									<asp:ListItem Value="BTEC-D12">BTEC Diploma - BTEC-D12</asp:ListItem>
									<asp:ListItem Value="ONAT-FA2">OCR National First Award - ONAT-FA2</asp:ListItem>
									<asp:ListItem Value="ONAT-AW2">OCR National Award - ONAT-AW2</asp:ListItem>
									<asp:ListItem Value="ONAT-FC2">OCR National Certificate - ONAT-FC2</asp:ListItem>
									</asp:DropDownList></td>
								<td><asp:DropDownList ID="DDLVocationalGrade4" AutoPostBack="true"  CssClass="form-control" runat="server">
									<asp:ListItem Value="SELECT">Select Grade</asp:ListItem>
									<asp:ListItem Value="PASS">PASS</asp:ListItem>
									<asp:ListItem Value="MERIT">MERIT</asp:ListItem>
									<asp:ListItem Value="DIST">DIST</asp:ListItem>
									<asp:ListItem Value="DIST*">DIST*</asp:ListItem>
									</asp:DropDownList>

								</td>
							</tr>
							<tr>
								<td><asp:DropDownList ID="DDLVocationalSubject5" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DDLVocationalSubject5_SelectedIndexChanged">
									<asp:ListItem Value="SELECT">Select Subject</asp:ListItem>
									<asp:ListItem Value="BTEC-AW2">BTEC L2 Award - BTEC-AW2</asp:ListItem>
									<asp:ListItem Value="BTEC-CE2">BTEC L2 Certificate - BTEC-CE2</asp:ListItem>
									<asp:ListItem Value="BTEC-EC2">BTEC L2 Ext Cert - BTEC-EC2</asp:ListItem>
									<asp:ListItem Value="BTEC-D12">BTEC Diploma - BTEC-D12</asp:ListItem>
									<asp:ListItem Value="ONAT-FA2">OCR National First Award - ONAT-FA2</asp:ListItem>
									<asp:ListItem Value="ONAT-AW2">OCR National Award - ONAT-AW2</asp:ListItem>
									<asp:ListItem Value="ONAT-FC2">OCR National Certificate - ONAT-FC2</asp:ListItem>
									</asp:DropDownList></td>
								<td><asp:DropDownList ID="DDLVocationalGrade5" AutoPostBack="true"  CssClass="form-control" runat="server">
									<asp:ListItem Value="SELECT">Select Grade</asp:ListItem>
									<asp:ListItem Value="PASS">PASS</asp:ListItem>
									<asp:ListItem Value="MERIT">MERIT</asp:ListItem>
									<asp:ListItem Value="DIST">DIST</asp:ListItem>
									<asp:ListItem Value="DIST*">DIST*</asp:ListItem>
									</asp:DropDownList>
								</td>
							</tr>            

							<tr>
								<td><asp:DropDownList ID="DDLVocationalSubject6" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DDLVocationalSubject6_SelectedIndexChanged">
									<asp:ListItem Value="SELECT">Select Subject</asp:ListItem>
									<asp:ListItem Value="BTEC-AW2">BTEC L2 Award - BTEC-AW2</asp:ListItem>
									<asp:ListItem Value="BTEC-CE2">BTEC L2 Certificate - BTEC-CE2</asp:ListItem>
									<asp:ListItem Value="BTEC-EC2">BTEC L2 Ext Cert - BTEC-EC2</asp:ListItem>
									<asp:ListItem Value="BTEC-D12">BTEC Diploma - BTEC-D12</asp:ListItem>
									<asp:ListItem Value="ONAT-FA2">OCR National First Award - ONAT-FA2</asp:ListItem>
									<asp:ListItem Value="ONAT-AW2">OCR National Award - ONAT-AW2</asp:ListItem>
									<asp:ListItem Value="ONAT-FC2">OCR National Certificate - ONAT-FC2</asp:ListItem>
									</asp:DropDownList></td>
								<td><asp:DropDownList ID="DDLVocationalGrade6" AutoPostBack="true"  CssClass="form-control" runat="server">
									<asp:ListItem Value="SELECT">Select Grade</asp:ListItem>
									<asp:ListItem Value="PASS">PASS</asp:ListItem>
									<asp:ListItem Value="MERIT">MERIT</asp:ListItem>
									<asp:ListItem Value="DIST">DIST</asp:ListItem>
									<asp:ListItem Value="DIST*">DIST*</asp:ListItem>
									</asp:DropDownList>
								</td>
							</tr>
							<tr>
								<td><asp:DropDownList ID="DDLVocationalSubject7" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DDLVocationalSubject7_SelectedIndexChanged">
									<asp:ListItem Value="SELECT">Select Subject</asp:ListItem>
									<asp:ListItem Value="BTEC-AW2">BTEC L2 Award - BTEC-AW2</asp:ListItem>
									<asp:ListItem Value="BTEC-CE2">BTEC L2 Certificate - BTEC-CE2</asp:ListItem>
									<asp:ListItem Value="BTEC-EC2">BTEC L2 Ext Cert - BTEC-EC2</asp:ListItem>
									<asp:ListItem Value="BTEC-D12">BTEC Diploma - BTEC-D12</asp:ListItem>
									<asp:ListItem Value="ONAT-FA2">OCR National First Award - ONAT-FA2</asp:ListItem>
									<asp:ListItem Value="ONAT-AW2">OCR National Award - ONAT-AW2</asp:ListItem>
									<asp:ListItem Value="ONAT-FC2">OCR National Certificate - ONAT-FC2</asp:ListItem>
									</asp:DropDownList></td>
								<td><asp:DropDownList ID="DDLVocationalGrade7" AutoPostBack="true"  CssClass="form-control" runat="server">
									<asp:ListItem Value="SELECT">Select Grade</asp:ListItem>
									<asp:ListItem Value="PASS">PASS</asp:ListItem>
									<asp:ListItem Value="MERIT">MERIT</asp:ListItem>
									<asp:ListItem Value="DIST">DIST</asp:ListItem>
									<asp:ListItem Value="DIST*">DIST*</asp:ListItem>
									</asp:DropDownList>
								</td>
							</tr>
						</tbody>
					</table>
					<asp:Button ID="BtnUpdateResults" cssClass="btn btn-default" runat="server" Visible="False" Text="Update Results" OnClick="BtnUpdateResults_Click" />
				<asp:Button ID="BtnViewReport" cssClass="btn btn-default" runat="server" Text="Print Results" OnClick="BtnViewReport_Click" Visible="False" />
				<asp:Button ID="BtnRedirectToIndex" CssClass="btn btn-danger" runat="server" Text="Search for Another Learner" Visible="false" OnClick="BtnRedirectToIndex_Click" />
				</div>
			</div>
			<asp:RadioButtonList ID="rdiolstResults_Status" runat="server">
				<asp:ListItem Value="INFO-CORRECT" Selected="True"><p class="lead">I hereby declare that the results supplied above are correct.</p></asp:ListItem>
				<asp:ListItem Value="CHECK-LATER"><p class="lead">I hereby declare that result(s) supplied above need to be confirmed at a later date via PLR.</p></asp:ListItem>
			</asp:RadioButtonList>
			<asp:Button ID="BtnSaveResults" cssClass="btn btn-default" runat="server" Text="Save Results" OnClick="BtnSaveResults_Click" />
	  </div> <!-- /. Row -->
	</form>
</body>

</html>

