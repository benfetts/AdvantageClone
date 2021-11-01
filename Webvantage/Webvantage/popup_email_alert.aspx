<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="popup_email_alert.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Email Alert" Inherits="Webvantage.popup_email_alert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type='text/javascript'>

            function UpdateAllChildren(nodes, checked) {
                var i;
                for (i = 0; i < nodes.get_count() ; i++) {
                    if (checked) {
                        nodes.getNode(i).check();
                    }
                    else {
                        nodes.getNode(i).set_checked(false);
                    }

                    if (nodes.getNode(i).get_nodes().get_count() > 0) {
                        UpdateAllChildren(nodes.getNode(i).get_nodes(), checked);
                    }
                }
            }
            function clientNodeChecked(sender, eventArgs) {
                var childNodes = eventArgs.get_node().get_nodes();
                var isChecked = eventArgs.get_node().get_checked();
                UpdateAllChildren(childNodes, isChecked);
            }
            function RadToolbarAlertNewOnClientButtonClicking(sender, args) {
                var commandName = args.get_item().get_commandName();
                if (commandName == "Cancel") {
                    ////args.set_cancel(!confirm("Are you sure you want to cancel the email alert?"));
                    radToolBarConfirm(sender, args, "Are you sure you want to cancel the email alert?");
                }
            }
        </script>

    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div >
        <telerik:RadToolBar ID="RadToolbarAlert" runat="server" AutoPostBack="True" Width="100%" OnClientButtonClicking="RadToolbarAlertNewOnClientButtonClicking">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Text="Send" Value="Send" ToolTip="Send new alert or email" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonCancel" Text="Cancel" CausesValidation="false" Value="Cancel" ToolTip="Cancel" CommandName="Cancel" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonDiaryOnly" Text="Diary Only" Value="Diary" CausesValidation="false" ToolTip="Diary Only" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div >
    </div>
    <table width="99%" border="0" cellspacing="2" cellpadding="2">
        <tr>
            <td>
                <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                <input id="txtJobNo" runat="server" name="txtJobNo" type="hidden" />
                <input id="txtJobCompNo" runat="server" name="txtJobCompNo" type="hidden" />
                <input id="txtRecipients" runat="server" name="txtRecipients" type="hidden" />
                <h4>Subject</h4>
                <div style="margin-top: 4px;margin-bottom: 4px;">
                    <asp:TextBox ID="txtAlertSubject" runat="server" Width="98%" SkinID="TextBoxStandard"></asp:TextBox>
                </div>
                <h4>Body</h4>
                <div style="margin-top: 4px; margin-bottom: 4px;">
                    <telerik:RadEditor ID="BodyRadEditor" runat="server" Height="310" ToolsFile="~/RadEditorToolbars.xml" NewLineBr="true" NewLineMode="Br" OnClientLoad="RadEditorOnClientLoad" StripFormattingOptions="MsWord"
                        ContentAreaCssFile="~/CSS/RadEditorContentArea.min.css" Width="97%" EditModes="Design" OnClientCommandExecuted="RadEditorOnClientCommandExecuted">
                        <CssFiles>
                            <telerik:EditorCssFile Value="~/CSS/RadEditorContentArea.css" />
                        </CssFiles>
                    </telerik:RadEditor>
                    <script type="text/javascript">
                        Telerik.Web.UI.Editor.Utils.containsHtmlAtClipboard = function (event) {
                            return false;
                        }
                    </script>
                </div>
                <h4>Recipients</h4>
                <div style="margin-top: 4px; margin-bottom: 4px;">
                    <telerik:RadTreeView ID="RadTreeView1" runat="server" Width="100%" CheckBoxes="true"
                        Height="200" OnClientNodeChecked="clientNodeChecked">
                    </telerik:RadTreeView>
                </div>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">&nbsp;
            </td>
        </tr>
        <%--<tr>
            <td align="center" valign="top">
                <asp:Button ID="butSendAlert" runat="server" Text="Send" OnClientClick="javascript:returnValue();" />
                <asp:Button ID="butCancelAlert" runat="server" CausesValidation="False"
                    Text="Cancel" />
                <asp:Button ID="butDiaryOnly" runat="server" Text="Diary Only" />
            </td>
        </tr>--%>
    </table>
</asp:Content>
