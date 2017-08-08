<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Learner.aspx.cs" Inherits="GCSEMatrix.Learner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
	<link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
	<link href="Content/custom.css" rel="stylesheet" type="text/css" />
	<link href="Content/jquery-3.1.1.js" type="text/javascript" />
	<link href="Scripts/bootstrap.js" type="text/javascript" />

	<title>GCSE Matrix - Learner</title>
</head>
<body>
	<form id="form1" runat="server">
			<div class="container">
		<!-- /.row -->
		<div class="row">
		  <p class="lead">Student Name:</p>
		   
		  <p class="lead">Student ID:</p>
		  <p class="lead">Unique Learner Number (ULN):</p>
		  <div class="table-responsive col-lg-6">
			<p class="lead">GCSEs</p>
			  <asp:Table ID="tblGCSEs" CssClass="table table-bordered table-condensed table-responive" runat="server">
				  <asp:TableHeaderRow>
					  <asp:TableHeaderCell>Qualification</asp:TableHeaderCell>
					  <asp:TableHeaderCell>Grade</asp:TableHeaderCell>
				  </asp:TableHeaderRow>
				  <asp:TableRow>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEQual1" CssClass="form-control" runat="server">
						  </asp:DropDownList>
					  </asp:TableCell>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEGrade1" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
				  </asp:TableRow>
				  <asp:TableRow>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEQual2" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEGrade2" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
				  </asp:TableRow>
				  <asp:TableRow>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEQual3" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEGrade3" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
				  </asp:TableRow>
				  <asp:TableRow>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEQual4" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEGrade4" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
				  </asp:TableRow>
				  <asp:TableRow>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEQual5" CssClass="form-control" runat="server">
							  <asp:ListItem></asp:ListItem>
						  </asp:DropDownList>
					  </asp:TableCell>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEGrade5" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
				  </asp:TableRow>
				  <asp:TableRow>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEQual6" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEGrade6" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
				  </asp:TableRow>
				  <asp:TableRow>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEQual7" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEGrade7" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
				  </asp:TableRow>
				  <asp:TableRow>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEQual8" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEGrade8" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
				  </asp:TableRow>
				  <asp:TableRow>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEQual9" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEGrade9" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
				  </asp:TableRow>
				  <asp:TableRow>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEQual10" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEGrade10" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
				  </asp:TableRow>
				  <asp:TableRow>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEQual11" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlGCSEGrade11" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
				  </asp:TableRow>
			  </asp:Table>
				
		  </div>
		  <div class="table-responsive col-lg-6">
			<p class="lead">Vocationals</p>
			  <asp:Table ID="tblVocationals" CssClass="table table-bordered table-condensed table-responive" runat="server">
				  <asp:TableHeaderRow>
					  <asp:TableHeaderCell>Qualification</asp:TableHeaderCell>
					  <asp:TableHeaderCell>Grade</asp:TableHeaderCell>
				  </asp:TableHeaderRow>
				  <asp:TableRow>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlVocQual1" CssClass="form-control" runat="server">
						  </asp:DropDownList>
					  </asp:TableCell>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlVocGrade1" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
				  </asp:TableRow>
				  <asp:TableRow>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlVocQual2" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlVocGrade2" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
				  </asp:TableRow>
				  <asp:TableRow>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlVocQual3" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlVocGrade3" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
				  </asp:TableRow>
				  <asp:TableRow>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlVocQual4" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlVocGrade4" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
				  </asp:TableRow>
				  <asp:TableRow>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlVocQual5" CssClass="form-control" runat="server">
						  </asp:DropDownList>
					  </asp:TableCell>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlVocGrade5" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
				  </asp:TableRow>
				  <asp:TableRow>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlVocQual6" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlVocGrade6" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
				  </asp:TableRow>
				  <asp:TableRow>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlVocQual7" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
					  <asp:TableCell>
						  <asp:DropDownList ID="ddlVocGrade7" CssClass="form-control" runat="server"></asp:DropDownList>
					  </asp:TableCell>
				  </asp:TableRow>
			  </asp:Table>
				
		  </div>
		  </div>
				 <asp:Button ID="btnCalculateScore" runat="server" CssClass="btn btn-default" Text="Calcaulate Score" />
		</div><!-- /.container -->
	</form>
</body>
</html>
