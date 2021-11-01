<%@ Page Title="Edit Diary" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_DiaryEdit.aspx.vb" Inherits="Webvantage.Maintenance_DiaryEdit" %>

<asp:Content ID="conDiaryContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <div class="no-float-menu" style="max-width: 800px;">
        <telerik:RadToolBar ID="RadToolbarDiary" runat="server" AutoPostBack="True" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonSave" SkinID="RadToolBarButtonSave" Text="" Value="Save"
                    ToolTip="Save" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonClose" runat="server" Text="Close" Value="Close" CommandName="Close"
                    ToolTip="Close" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div style="width: 100%;">
        <table cellpadding="2" cellspacing="0" width="100%" align="center" border="0">
                    <tr>
                        <td colspan="2" style="height: 10px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                <tr>
                                    <td style="width: 15%; text-align: right">
                                        Subject:</td>
                                    <td style="width: 85%">&nbsp;&nbsp;
                                        <asp:TextBox ID="TextBoxSubject" runat="server" Width="500px" SkinID="TextBoxStandard"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFVCode" runat="server" ControlToValidate="TextBoxSubject"
                                            CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                            ErrorMessage="<br />Subject is required."></asp:RequiredFieldValidator>&nbsp; &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%; text-align: right">
                                        Body:</td>
                                    <td style="width: 85%">&nbsp;&nbsp;
                                        <asp:TextBox ID="TextBoxBody" runat="server"   SkinID="TextBoxStandard"
                                            Width="500px" Rows="9" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
    </div>
    
</asp:Content>
