<%@ Page Title="Upload a New Document" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Documents_ProofHQUpload.aspx.vb" Inherits="Webvantage.Documents_ProofHQUpload" %>

<%@ Register Src="Alert_RecipientUC.ascx" TagName="AutoCompleteAlertRecipient" TagPrefix="custom" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock" runat="server">
        <script type="text/javascript">

            function ClientSetAutoCompleteEntries(str) {
                var autoCompleteBox = $find("<%= AutoCompleteAlertRecipient.GetClientID%>");
                //alert(autoCompleteBox);
                if (autoCompleteBox) {
                    var entries = new Array();
                    entries = str.split("|");
                    for (var i = 0; i < entries.length; i++) {
                        var emp = new Array();
                        emp = entries[i].split(",");
                        if (emp[0] != "") {
                            var entry = new Telerik.Web.UI.AutoCompleteBoxEntry();
                            entry.set_value(emp[0]);
                            entry.set_text(emp[1]);
                            autoCompleteBox.get_entries().add(entry);
                        }
                    }
                } else {
                    return false;
                }
            }

        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolbarDocumentUpload" runat="server" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonUpload" Text="Upload" Value="Upload" CommandName="Upload"
                    ToolTip="Upload this document" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonCancel" runat="server" SkinID="RadToolBarButtonCancel"
                    Text="Cancel" Value="Cancel" ToolTip="Cancel Proof HQ upload" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="style-fixes">
        <table width="100%" border="0" cellspacing="2" cellpadding="0" style="padding-left: 6px; padding-top: 4px; padding-right: 6px;">
        <tr>
            <td width="100px">Document:
            </td>
            <td>
                <asp:Label ID="LabelDocument" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="100px">Name:
            </td>
            <td>
                <asp:TextBox ID="TextBoxName" runat="server" Text="" Width="99%" AutoPostBack="false" CssClass="RequiredInput" SkinID="TextBoxStandard">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="100px">Folder:
            </td>
            <td>
                <telerik:RadComboBox ID="RadComboBoxFolder" runat="server" SkinID="RadComboBoxStandard"
                    AutoPostBack="false" Width="100%" DataTextField="Description" DataValueField="Code">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td width="100px">&nbsp;
            </td>
            <td>
                <telerik:RadButton ID="RadButtonSendAlert" runat="server" ButtonType="ToggleButton" ToggleType="CheckBox" Text="Send Alert" GroupName="Alert"></telerik:RadButton>
            </td>
        </tr>
        <tr>
            <td width="100px">&nbsp;
            </td>
            <td>
                <telerik:RadButton ID="RadButtonSendAlertAssignment" runat="server" ButtonType="ToggleButton" ToggleType="CheckBox" Text="Send Alert Assignment" GroupName="Alert"></telerik:RadButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div id="divSendAlert" runat="server" style="padding-top: 10px" visible="false">
                        <fieldset>
                            <legend>Alert Options</legend>
                            <table>
                                <tr>
                                    <td>Subject:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxSubject" runat="server" MaxLength="254" Width="300" Text="" SkinID="TextBoxStandard"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Category:
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="RadComboBoxCategory" runat="server" Width="110px" DataTextField="Description" DataValueField="ID" SkinID="RadComboBoxStandard">
                                        </telerik:RadComboBox>
                                        &nbsp;&nbsp;Priority:
                                        <telerik:RadComboBox ID="RadComboBoxPriority" runat="server" Width="100px" DataTextField="Name" DataValueField="Value" SkinID="RadComboBoxStandard">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonAddRecipients" runat="server" CausesValidation="False" Text="Select Recipients"
                                            UseSubmitBehavior="False" />
                                        <asp:Button ID="ButtonClearRecipients" runat="server" CausesValidation="False" Text="Clear Recipients"
                                            UseSubmitBehavior="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Label ID="LabelRecipients" runat="server" Text="Recipients: "></asp:Label>
                                    </td>
                                    <td valign="top">
                                        <custom:AutoCompleteAlertRecipient runat="server" ID="AutoCompleteAlertRecipient" Visible="true" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </div>
                    <div id="divSendAlertAssignment" runat="server" style="padding-top: 10px" visible="false">
                        <fieldset>
                            <legend>Alert Assignment Options</legend>
                            <table>
                                <tr>
                                    <td>Template:
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="RadComboBoxTemplate" runat="server" Width="100%" DataTextField="Name" DataValueField="ID" AutoPostBack="true" SkinID="RadComboBoxStandard">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>State:
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="RadComboBoxState" runat="server" Width="100%" DataTextField="Name" DataValueField="ID" AutoPostBack="true" SkinID="RadComboBoxStandard">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Assign To:
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="RadComboBoxAssignTo" runat="server" Width="100%" DataTextField="FullName" DataValueField="Code" AutoPostBack="false" SkinID="RadComboBoxStandard">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    </div>

    
</asp:Content>
