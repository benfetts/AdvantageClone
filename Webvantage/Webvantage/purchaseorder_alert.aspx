<%@ Page AutoEventWireup="false" CodeBehind="purchaseorder_alert.aspx.vb" Inherits="Webvantage.purchaseorder_alert"
    MasterPageFile="~/ChildPage.Master" Title="Send Purchase Order" Language="vb" %>

<%@ Register Src="ReportTypeUC.ascx" TagName="reporttype" TagPrefix="uc2" %>
<%@ Register Src="purchaseorder_base_info.ascx" TagName="purchaseorder_base_info"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" cellpadding="0" cellspacing="0" width="95%">
        <tr>
            <td align="left">
                &nbsp;&nbsp;Email Purchase Order
            </td>
            <td align="right">
                <!--Buttons-->
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp;
                <table>
                    <tr>
                        <td align="left" style="width: 710px">
                            <uc1:purchaseorder_base_info ID="Purchaseorder_base_info1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 706px">
                            <table id="TABLE1" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="width: 425px" class="sub-header sub-header-color">
                                        <span style="color: white">Recipient(s)</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 425px">
                                        <table cellpadding="0" cellspacing="0" style="width: 100%">
                                            <tr>
                                                <td valign="top">
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td style="width: 100px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadToolBar ID="RadToolbarPOAlert" runat="server" AutoPostBack="True" Width="100%">
                                                                    <Items>
                                                                        <telerik:RadToolBarButton Value="RadToolBarButtonEmail">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtRTBEmail" runat="server" CausesValidation="true" SkinID="TextBoxStandard">
                                                                                </asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="Valid_Email" runat="server" ControlToValidate="txtRTBEmail"
                                                                                    Display="none" ErrorMessage="Email format is not correct. Example: sample@webvantage.com"
                                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                                                </asp:RegularExpressionValidator>
                                                                            </ItemTemplate>
                                                                        </telerik:RadToolBarButton>
                                                                        <telerik:RadToolBarButton Text="Add Email" Value="Add_Email" />
                                                                        <telerik:RadToolBarButton Text="Remove Selected Email"
                                                                            CausesValidation="False" Value="Delete_Email" />
                                                                        <telerik:RadToolBarButton  Text="Check All" Value="Check_All" />
                                                                        <telerik:RadToolBarButton Text="UnCheck All"
                                                                            Value="UnCheck_All" />
                                                                    </Items>
                                                                </telerik:RadToolBar>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 100px; height: 143px" valign="top">
                                                    <div style="overflow: auto; width: 300px; height: 120px">
                                                        <telerik:RadTreeView ID="RadTreeViewContacts" runat="server" CheckBoxes="True" DataTextField="CONTACT_NAME"
                                                            TabIndex="1">
                                                        </telerik:RadTreeView>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnRecipients" runat="server" Text="Select Recipients" Visible="false" /><br />
                                                    <br />
                                                    <asp:Button ID="btnGroups" runat="server" Text="Select Groups" Visible="false" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="Left" style="width: 706px" class="sub-header sub-header-color">
                            <span style="color: white">Email Options</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 706px">
                            <div style="text-align: left">
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 100px; height: 39px">
                                            <span style="font-size: 11px; font-weight: bold">Location ID:</span>
                                        </td>
                                        <td align="right" style="width: 11px; height: 39px">
                                        </td>
                                        <td style="width: 100px;">
                                            <telerik:RadComboBox ID="dl_LocationID" runat="server" AutoPostBack="true" DataTextField="LOC_NAME"
                                                DataValueField="LOCATION_ID" TabIndex="2" Width="425px">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px; height: 35px">
                                            <span style="font-size: 11px; font-weight: bold">Priority:</span>
                                        </td>
                                        <td align="right" style="width: 11px; height: 35px">
                                        </td>
                                        <td style="width: 100px;">
                                            <telerik:RadComboBox ID="PriorityDropDownList" runat="server" AutoPostBack="true" TabIndex="3"
                                                Width="100px">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px; height: 35px">
                                            <span style="font-size: 11px; font-weight: bold">Subject:</span>
                                        </td>
                                        <td align="right" style="width: 11px; height: 35px">
                                        </td>
                                        <td style="width: 100px; height: 30px">
                                            <asp:TextBox ID="txtSubject" runat="server" AutoCompleteType="Disabled" BorderStyle="Inset" SkinID="TextBoxStandard"
                                                CausesValidation="True" MaxLength="300" TabIndex="4" Width="565px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px; height: 13px">
                                            <span style="font-size: 11px; font-weight: bold">Body:</span>
                                        </td>
                                        <td align="right" style="width: 11px; height: 13px">
                                        </td>
                                        <td style="width: 100px; height: 13px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td style="width: 11px">
                                        </td>
                                        <td style="width: 100px">
                                            <telerik:RadEditor ID="Radeditor1" runat="server" ToolsFile="~/RadEditorToolbars.xml" NewLineBr="true" NewLineMode="Br" OnClientLoad="RadEditorOnClientLoad" StripFormattingOptions="MsWord"
                                                ContentAreaCssFile="~/CSS/RadEditorContentArea.min.css" Height="200px" Width="625px" OnClientCommandExecuted="RadEditorOnClientCommandExecuted"
                                                EditModes="Design">
                                                    <CssFiles>
                                                        <telerik:EditorCssFile Value="~/CSS/RadEditorContentArea.css" />
                                                    </CssFiles>
                                            </telerik:RadEditor>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px; height: 30px">
                                            <span style="font-size: 11px; font-weight: bold">Template:</span>
                                        </td>
                                        <td align="right" style="width: 11px; height: 30px">
                                        </td>
                                        <td style="width: 100px; height: 30px">
                                            <telerik:RadComboBox ID="dl_Template" runat="server" AutoPostBack="true" TabIndex="6"
                                                Width="140px">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px; height: 30px">
                                            <span style="font-size: 11px; font-weight: bold">Attachment:</span>
                                        </td>
                                        <td align="right" style="width: 11px; height: 30px">
                                        </td>
                                        <td style="width: 100px; height: 30px;">
                                            <uc2:reporttype ID="Reporttype1" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td style="width: 11px">
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <asp:Label   ID="lbl_msg" runat="server" CssClass="warning"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 706px">
                            <div style="overflow: auto; width: 698px; height: 31px">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 706px">
                            &nbsp;<table cellpadding="0" cellspacing="0" style="width: 334px">
                                <tr>
                                    <td style="width: 100px; height: 7px;">
                                        <asp:Button ID="but_SendYes" runat="server" TabIndex="8" Text="Send Email" />
                                    </td>
                                    <td style="width: 100px; height: 7px;">
                                        <button id="btnClose" causesvalidation="false" onclick="JavaScript:window.close();">
                                            Cancel</button>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:RequiredFieldValidator ID="SubjectRequiredFieldValidator" runat="server" ControlToValidate="txtSubject"
                    Display="None" ErrorMessage="Please enter a subject." SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:Label   ID="lbl_alert_funct" runat="server" Text="email_po" Visible="False"></asp:Label>
                <asp:Label   ID="lbl_RefID" runat="server" Text="-1" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
