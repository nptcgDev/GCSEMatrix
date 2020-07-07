<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="NoResults.aspx.cs" Inherits="GCSEMatrix.NoResults" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="CntMainContent" ContentPlaceHolderID="CphMainContent" runat="server">
    <h1>No Results to enter.</h1>
    <p class="lead">
    This learner has no results that can be entered into the GCSE Matrix. Click on the button below to return to OntrackHub.
    </p>
    <asp:Button ID="BtnReturnToOntrack" runat="server" CssClass="btn btn-default" Text="Return to OntrackHub" OnClick="BtnReturnToOntrack_Click" />

</asp:Content>