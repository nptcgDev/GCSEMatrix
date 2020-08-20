<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" MasterPageFile="~/Site.Master" Inherits="GCSEMatrix.Index" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="CntMainContent" ContentPlaceHolderID="CphMainContent" runat="server">

    <asp:Literal runat="server" ID="litPersonCode" Visible="false" />
    <asp:Label runat="server" ID="lbPersonCode" Visible="false" />
    <h1>GCSE Matrix</h1>
<%--    <div class="row">
        <div style="padding-left: 0px !important;" class="col-lg-12">
            <p class="lead">Please Enter Student ID</p>
            <div style="padding-left: 0px !important;" class="col-lg-6">
                <div class="input-group">
                    <asp:TextBox ID="txtstudent_id" runat="server" CssClass="form-control"></asp:TextBox>
                    <span class="input-group-btn">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-default" />
                    </span>
                </div>
                <!-- /input-group -->
            </div>
            <!-- /.col-lg-6 -->
        </div>
    </div>--%>
    <br />
    <br />
    <asp:ObjectDataSource ID="odsGetLearnerDetails" runat="server" SelectMethod="GetLearnerDetails" TypeName="GCSEMatrix.DAO.ReturnData">
        <SelectParameters>
            <asp:ControlParameter ControlID="lbPersonCode" Name="person_code" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:Repeater ID="RptSearchResults" runat="server" DataSourceID="odsGetLearnerDetails" OnItemDataBound="RptSearchResults_ItemDataBound">
        <HeaderTemplate>
            <table class="table table-bordered table-inverse">
                <tr>
                    <th>Person Code</th>
                    <th>Image</th>
                    <th>Full Name</th>
                    <th>Date Of Birth</th>
                    <th>Action</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("person_code") %></td>
                <td>
                    <asp:Image ID="learnerImage" CssClass="img-rounded" runat="server" ImageAlign="Left" ImageUrl='<%# "https://ebsagent.ad.nptcgroup.ac.uk//personimage.aspx?personcode=" +  Eval("person_code")  %>' Height="60px" AlternateText='' /></td>
                <td><%# Eval("full_name") %> </td>
                <td><%# Eval("date_of_birth","{0:d}") %></td>
                <td>
                    <asp:HyperLink ID="lnkAddResults" runat="server" CssClass="btn btn-default" NavigateUrl='<%#"AddResults.aspx?personCode=" + Eval("person_code") %>'>Add Results</asp:HyperLink>
                    <asp:HyperLink ID="lnkViewExistingResults" runat="server" Target="_blank" CssClass="btn btn-default" NavigateUrl='<%#"http://nth-mis-app-01/ReportServer/Pages/ReportViewer.aspx?%2fColeg+Powys%2fSkills+Matrix%2fmatrix-slip-2021&PERSON_CODE=" + Eval("person_code") %>'>View Existing Results</asp:HyperLink>

                    <asp:Label ID="lblNoResultsMessage" Visible="false" runat="server" CssClass="alert-danger " Text="It has previously been indicated that this learner has no results to enter onto the system. Therefore it is not possible to enter results for this learner."></asp:Label>
                </td>

                    <asp:Label ID="lblResultsStatus" Visible="false" runat="server" Text='<%# Eval("results_status") %>'></asp:Label>
                    <asp:Label ID="lbExistingResults" Visible="false" runat="server" Text='<%# Eval("existing_entries") %>'></asp:Label>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <%-- Label used for send people to matrix page with default person code (0) --%>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Panel ID="PnlNoResults" runat="server" Style="display: none; border-style: solid; border-width: thin; background-color: #ffffff; border-color: #FFDBCA">

        <div class="modal-header">
            <h1>Alert</h1>
        </div>
        <div class="modal-body">
           <p class="lead">Does the learner have any results that need to be entered onto the GCSE Matrix?</p>
        </div>
        <div class="modal-footer">
            <asp:Button ID="BtnYesResults" CssClass="btn btn-primary" runat="server" Text="Yes" OnClick="BtnYesResults_Click" />
            <asp:Button ID="BtnNoResults" CssClass="btn btn-primary" runat="server" Text="No" OnClick="BtnNoResults_Click" />
        </div>

        <ajaxToolkit:ModalPopupExtender ID="modalPopupEx" runat="server" PopupControlID="PnlNoResults"
            TargetControlID="invisibleTarget" CancelControlID="BtnYesResults"
            BackgroundCssClass="modal-content">
        </ajaxToolkit:ModalPopupExtender>

        <ajaxToolkit:AnimationExtender ID="popupAnimation" runat="server"
            TargetControlID="invisibleTarget">

            <Animations>
                <OnLoad>
                    <Parallel AnimationTarget="PnlNoResults"
                    Duration="0.3" Fps="25">
                    <FadeIn />
                    </Parallel>
                </OnLoad>
            </Animations>
        </ajaxToolkit:AnimationExtender>
    </asp:Panel>
    <asp:Label ID="invisibleTarget" runat="server" Style="display: none" Font-Size="Large" /><br />
</asp:Content>
