<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddResults.aspx.cs" Inherits="GCSEMatrix.Default" MaintainScrollPositionOnPostback="True" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="CntMainContent" ContentPlaceHolderID="CphMainContent" runat="server">

            <asp:Label CssClass="sr-only" ID="lblUser" runat="server"> <% Response.Write(HttpContext.Current.User.Identity.Name); %></asp:Label>
            <!-- /.row -->
            <div class="row">
                <div class="form-inline">
                    <asp:Label ID="lblStudentID" runat="server" CssClass="lead">Student ID:</asp:Label>
                    <asp:TextBox ID="txtStudentID" Enabled="false" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-inline">
                    <label for="txtStudentName" id="lblStudentName" class="lead">Student Name (Required):</label>
                    <asp:TextBox ID="txtStudentName" required class="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="form-inline">
                    <label for="txtULI" class="lead">ULN (Required):</label>
                    <asp:TextBox ID="txtULI" required class="form-control" placeholder="e.g. 7034202311" runat="server" MaxLength="10"></asp:TextBox>
                </div>
                <div class="form-inline">
                    <label for="txtUCI" class="lead">UCI Number (Required):</label>
                    <asp:TextBox ID="txtUCI" required class="form-control" MaxLength="13" runat="server"></asp:TextBox>
                </div>
                <div class="table-responsive col-lg-6">
                    <p class="lead">Core GCSEs</p>


                    <table class="table table-bordered table-inverse">
                        <tr>
                            <th>Subject</th>
                            <th>Grade</th>
                        </tr>
                        <tr>
                            <td style="height: 65px">
                                <asp:Label ID="lblGCSEEnglish" runat="server" CssClass="form-control" Text="English Language"></asp:Label></td>
                            <td style="height: 65px">
                                <asp:DropDownList ID="DDLCoreGCSEGrade1" CssClass="form-control" runat="server" AutoPostBack="True">
                                    <asp:ListItem>Select Grade</asp:ListItem>
                                    <asp:ListItem>A*</asp:ListItem>
                                    <asp:ListItem>A</asp:ListItem>
                                    <asp:ListItem>B</asp:ListItem>
                                    <asp:ListItem>C</asp:ListItem>
                                    <asp:ListItem>D</asp:ListItem>
                                    <asp:ListItem>E</asp:ListItem>
                                    <asp:ListItem>F</asp:ListItem>
                                    <asp:ListItem>G</asp:ListItem>
                                    <asp:ListItem>U</asp:ListItem>
                                    <asp:ListItem>No Grade</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblGCSEMaths" runat="server" CssClass="form-control" Text="Mathematics"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="DDLCoreGCSEGrade2" CssClass="form-control" runat="server" AutoPostBack="True">
                                    <asp:ListItem>Select Grade</asp:ListItem>
                                    <asp:ListItem>A*</asp:ListItem>
                                    <asp:ListItem>A</asp:ListItem>
                                    <asp:ListItem>B</asp:ListItem>
                                    <asp:ListItem>C</asp:ListItem>
                                    <asp:ListItem>D</asp:ListItem>
                                    <asp:ListItem>E</asp:ListItem>
                                    <asp:ListItem>F</asp:ListItem>
                                    <asp:ListItem>G</asp:ListItem>
                                    <asp:ListItem>U</asp:ListItem>
                                    <asp:ListItem>No Grade</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblGCSENumeracy" runat="server" CssClass="form-control" Text="Mathematics Numeracy"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="DDLCoreGCSEGrade3" CssClass="form-control" runat="server" AutoPostBack="True">
                                    <asp:ListItem>Select Grade</asp:ListItem>
                                    <asp:ListItem>A*</asp:ListItem>
                                    <asp:ListItem>A</asp:ListItem>
                                    <asp:ListItem>B</asp:ListItem>
                                    <asp:ListItem>C</asp:ListItem>
                                    <asp:ListItem>D</asp:ListItem>
                                    <asp:ListItem>E</asp:ListItem>
                                    <asp:ListItem>F</asp:ListItem>
                                    <asp:ListItem>G</asp:ListItem>
                                    <asp:ListItem>U</asp:ListItem>
                                    <asp:ListItem>No Grade</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblGCSEWelsh" runat="server" CssClass="form-control" Text="Cymraeg Iaith Cyntaf (Welsh First Language)"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="DDLCoreGCSEGrade4" CssClass="form-control" runat="server" AutoPostBack="True">
                                    <asp:ListItem>Select Grade</asp:ListItem>
                                    <asp:ListItem>A*</asp:ListItem>
                                    <asp:ListItem>A</asp:ListItem>
                                    <asp:ListItem>B</asp:ListItem>
                                    <asp:ListItem>C</asp:ListItem>
                                    <asp:ListItem>D</asp:ListItem>
                                    <asp:ListItem>E</asp:ListItem>
                                    <asp:ListItem>F</asp:ListItem>
                                    <asp:ListItem>G</asp:ListItem>
                                    <asp:ListItem>U</asp:ListItem>
                                    <asp:ListItem>No Grade</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <div class="row">
                        <asp:CompareValidator ID="CVWelsh" runat="server"  Display="None" ValidationGroup="valGroup" EnableClientScript="false" ControlToValidate="DDLCoreGCSEGrade4"  ErrorMessage="You must enter a grade, if the learner doesn't have a Welsh First Language GCSE then please select 'No Grade'." Operator="NotEqual" ValueToCompare="Select Grade" ForeColor="Red" SetFocusOnError="true" ValidateRequestMode="Inherit" Font-Size="Large" />
                        <asp:CompareValidator ID="CVNumeracy" runat="server" Display="None" ValidationGroup="valGroup" EnableClientScript="false" ControlToValidate="DDLCoreGCSEGrade3" ErrorMessage="You must enter a grade, if the learner doesn't have a Mathematics Numeracy GCSE then please select 'No Grade'." Operator="NotEqual" ValueToCompare="Select Grade" ForeColor="Red" SetFocusOnError="true" ValidateRequestMode="Inherit" Font-Size="Large" />
                         <asp:CompareValidator ID="CVMaths" runat="server"  Display="None" ValidationGroup="valGroup" EnableClientScript="false" ControlToValidate="DDLCoreGCSEGrade2" ErrorMessage="Mathematics is a required subject, you must enter a grade for it." Operator="NotEqual" ValueToCompare="Select Grade" ForeColor="Red" SetFocusOnError="true" ValidateRequestMode="Inherit" Font-Size="Medium" />
                        <asp:CompareValidator ID="CVEnglish" runat="server" Display="None" ValidationGroup="valGroup" EnableClientScript="false" ControlToValidate="DDLCoreGCSEGrade1" ErrorMessage="English Language is a required subject, you must enter a grade for it." Operator="NotEqual" ValueToCompare="Select Grade" ForeColor="Red" SetFocusOnError="true" ValidateRequestMode="Inherit" Font-Size="Medium" />                     
                    </div>

                    <asp:ObjectDataSource ID="odsGetGcseSubjects" runat="server" SelectMethod="GetGcseSubjectList" TypeName="GCSEMatrix.DAO.ReturnData"></asp:ObjectDataSource>
                    <asp:Repeater ID="rptGcseSubjectList" runat="server" DataSourceID="odsGetGcseSubjects" OnItemDataBound="rptGcseSubjectList_ItemDataBound">
                        <HeaderTemplate>
                            <table class="table table-bordered table-inverse">
                                <tr>
                                    <th>Subject</th>
                                    <th>Grade</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSubjectName" runat="server" CssClass="form-control" Text='<%# Eval("SUBJECT_NAME") %>'></asp:Label></td>
                                <td>
                                    <asp:DropDownList ID="DDLGCSEGrade" CssClass="form-control" runat="server" OnSelectedIndexChanged="DDLGCSEGrade_SelectedIndexChanged"  AutoPostBack="True" CausesValidation="False">
                                        <asp:ListItem>Select Grade</asp:ListItem>
                                        <asp:ListItem>A*</asp:ListItem>
                                        <asp:ListItem>A</asp:ListItem>
                                        <asp:ListItem>B</asp:ListItem>
                                        <asp:ListItem>C</asp:ListItem>
                                        <asp:ListItem>D</asp:ListItem>
                                        <asp:ListItem>E</asp:ListItem>
                                        <asp:ListItem>F</asp:ListItem>
                                        <asp:ListItem>G</asp:ListItem>
                                        <asp:ListItem>P*</asp:ListItem>
                                        <asp:ListItem>P</asp:ListItem>
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

                    <asp:ObjectDataSource ID="odsGetVocationalSubjects" runat="server" SelectMethod="GetVocationalSubjectList" TypeName="GCSEMatrix.DAO.ReturnData"></asp:ObjectDataSource>
                </div>
                <div class="table-responsive col-lg-6">
                    <asp:GridView ID="gvVocationalQual" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-inverse" OnRowDataBound="gvVocationalQual_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="SubjectName" HeaderText="Subject Name" />
                            <asp:BoundField DataField="SubjectCode" HeaderText="Subject Code" HeaderStyle-CssClass="sr-only" ItemStyle-CssClass="sr-only" />
                            <asp:BoundField DataField="GradeName" HeaderText="Grade Name" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="HFGV_Voc" runat="server" />
                                    <asp:LinkButton ID="LBLDeleteVoc" runat="server" OnClick="RemoveVoc_Click" CssClass="btn btn-danger">Remove</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <table class="table table-bordered table-inverse">
                        <p class="lead">Vocationals</p>
                        <thead>
                            <th>Subject</th>
                            <th>Grade</th>
                            <th>Actions</th>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="DDLVocationalSubject1" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DDLVocationalSubject1_SelectedIndexChanged" DataSourceID="odsGetVocationalSubjects" DataTextField="SUBJECT_NAME" DataValueField="SUBJECT_CODE">
                                    </asp:DropDownList></td>
                                <td>
                                    <asp:DropDownList ID="DDLVocationalGrade1" AutoPostBack="True" CssClass="form-control" runat="server">
                                    </asp:DropDownList>

                                </td>
                                <td>
                                    <asp:Button ID="btnAddVoc" runat="server" Text="Add" CssClass="btn btn-success" OnClick="BtnAddVoc_Click" /></td>
                                <%--							    <asp:CompareValidator ID="cvVocGrade" runat="server" ErrorMessage="Please select a grade for this vocational qualification." Display="Dynamic" ControlToValidate="DDLVocationalGrade1" ValueToCompare="SELECT" SetFocusOnError="True" Font-Bold="True" ForeColor="red" Font-Size="Medium" Operator="NotEqual"></asp:CompareValidator>--%>
                            </tr>
                        </tbody>
                    </table>
                    <asp:GridView ID="grdvwOther" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-inverse" OnRowDataBound="grdvwOther_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="SubjectName" HeaderText="Subject Name" />
                            <asp:BoundField DataField="SubjectCode" HeaderText="Subject Code" HeaderStyle-CssClass="sr-only" ItemStyle-CssClass="sr-only" />
                            <asp:BoundField DataField="GradeName" HeaderText="Grade Name" />

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="HFGV" runat="server" />
                                    <asp:LinkButton ID="LBLDeleteOther" runat="server" OnClick="Remove_Click" CssClass="btn btn-danger">Remove</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <p style="font-size: 18px;" class="lead">If a learner has a GCSE that's not available in the list, please use this option and select the grade.</p>
                    <table class="table table-bordered table-inverse">
                        <tr>
                            <th>Subject</th>
                            <th>Select Grade</th>
                            <th>Actions</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblOtherSubjectCode" CssClass="sr-only" runat="server" Text="GCSEFULL"></asp:Label>
                                <asp:DropDownList ID="DDLOther" runat="server" CssClass="form-control" AutoPostBack="true">
                                    <asp:ListItem Value="GCSEFULL">Other</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="DDLOtherGCSEGrade" CssClass="form-control" runat="server">
                                    <asp:ListItem>A*</asp:ListItem>
                                    <asp:ListItem>A</asp:ListItem>
                                    <asp:ListItem>B</asp:ListItem>
                                    <asp:ListItem>C</asp:ListItem>
                                    <asp:ListItem>D</asp:ListItem>
                                    <asp:ListItem>E</asp:ListItem>
                                    <asp:ListItem>F</asp:ListItem>
                                    <asp:ListItem>G</asp:ListItem>
                                    <asp:ListItem>U</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnAddOther" runat="server" Text="Add" CssClass="btn btn-success" OnClick="BtnAddOther_Click" />
                            </td>
                        </tr>
                    </table>
                    <div class="btn-group btn-group-sm">
                        <asp:Button ID="BtnUpdateResults" CssClass="btn btn-default" runat="server" Visible="False" Text="Update Results" OnClick="BtnUpdateResults_Click" />
                        <asp:Button ID="BtnViewReport" CssClass="btn btn-success" runat="server" Text="Print Results" OnClick="BtnViewReport_Click" Visible="False" />
                        <asp:Button ID="BtnRedirectToIndex" CssClass="btn btn-danger" runat="server" Text="Search for Another Learner" Visible="false" OnClick="BtnRedirectToIndex_Click" />
                    </div>
                </div>
            </div>
            <asp:RadioButtonList ID="rdiolstResults_Status" runat="server">
                <asp:ListItem Value="INFO-CORRECT" Selected="True"><p class="lead">I hereby declare that the results supplied above are correct.</p></asp:ListItem>
                <asp:ListItem Value="CHECK-LATER"><p class="lead">I hereby declare that result(s) supplied above need to be confirmed at a later date via PLR.</p></asp:ListItem>
            </asp:RadioButtonList>
            <asp:Button ID="BtnSaveResults" CssClass="btn btn-default" runat="server" Text="Save Results" OnClick="BtnSaveResults_Click" />
        <!-- /. Row -->
        <asp:ObjectDataSource ID="odsCoreGcseList" runat="server" SelectMethod="GetCoreGcseSubjectList" TypeName="GCSEMatrix.DAO.ReturnData"></asp:ObjectDataSource>
                        <asp:Panel ID="PnlErrorsPanel" runat="server" Style="display: none; border-style: solid; border-width: thin; background-color: #ffffff; border-color: #FFDBCA">

                        <div class="modal-header">
                            <h1>Errors made</h1>
                        </div>
                        <asp:ValidationSummary ID="valSummary" CssClass="modal-dialog" runat="server"
                            DisplayMode="BulletList" ShowSummary="true"
                            ValidationGroup="valGroup" Font-Size="Large" />
                        <div id="WelshBaccError" class="modal-dialog" visible="false" runat="server">
                            You have entered a grade for: <b>WBQ/1&2 - Skills Challenge Welsh Bacc Foundation </b> and <b>WBQ/1&2 - Skills Challenge Welsh Bacc National</b>, please remove one of the grades.
                         </div>
                        <div class="modal-footer">
                            <asp:Button ID="BtnCloseModal" CssClass="btn btn-primary" runat="server" Text="Ok" />
                        </div>

                        <ajaxToolkit:ModalPopupExtender ID="modalPopupEx" runat="server" PopupControlID="PnlErrorsPanel"
                            TargetControlID="invisibleTarget" CancelControlID="BtnCloseModal"
                            BackgroundCssClass="modal-content">
                        </ajaxToolkit:ModalPopupExtender>
                        <ajaxToolkit:AnimationExtender ID="popupAnimation" runat="server"
                            TargetControlID="invisibleTarget">

                            <Animations>
                <OnLoad>
                    <Parallel AnimationTarget="PnlErrorsPanel"
                    Duration="0.3" Fps="25">
                    <FadeIn />
                    </Parallel>
                </OnLoad>
                            </Animations>
                        </ajaxToolkit:AnimationExtender>
                    </asp:Panel>
                    <asp:Label ID="invisibleTarget" runat="server" Style="display: none" Font-Size="Large" /><br />
</asp:Content>