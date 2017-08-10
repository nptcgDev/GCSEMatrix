<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="GCSEMatrix.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
		<link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
	<link href="Content/custom.css" rel="stylesheet" type="text/css" />
	<link href="Content/jquery-3.1.1.js" type="text/javascript" />
	<link href="Scripts/bootstrap.js" type="text/javascript" />

</head>
<body>
	<form id="form1" runat="server">
	<div>
		<asp:Repeater ID="rptParent" runat="server" OnItemDataBound="rptParent_ItemDataBound">
			<HeaderTemplate>
				<table style="width:auto;" class="table table-bordered table-inverse">
					<thead>
						<th>Subject</th>
						<th>Current Grade</th>
						<th>New Grade</th>
					</thead>
			</HeaderTemplate>
			<ItemTemplate>
				<tr>
					<td><asp:Label ID="lblSubjectName" runat="server" CssClass="form-control" Text='<%# Eval("SUBJECT_NAME") %>'></asp:Label></td>
					<asp:Repeater ID="rptChild" runat="server">
				        <ItemTemplate><td><asp:Label ID="lblGrade" runat="server" Text='<%# Eval("GRADE_NAME") %>'></asp:Label></td></ItemTemplate>
		            </asp:Repeater>

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
	</form>
</body>
</html>
