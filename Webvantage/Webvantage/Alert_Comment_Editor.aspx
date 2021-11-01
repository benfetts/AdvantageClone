<%@ Page Title="Alert Comment" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Alert_Comment_Editor.aspx.vb" Inherits="Webvantage.Alert_Comment_Editor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
   <%-- <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            
            function returnValue() {
                //Get a reference to the parent (MDI) page 
                var oWnd = GetRadWindow();
                //get a reference to the second RadWindow
                var CallingWindowName = '<%= Me.radwindowname %>';
                var CallingWindow = oWnd.get_windowManager().getWindowByName(CallingWindowName);
                // Get a reference to the first RadWindow's content
                var CallingWindowContent = CallingWindow.get_contentFrame().contentWindow;
                //Call the predefined function in Dialog1
                //alert(CallingWindowName + '\n' + CallingWindow + '\n');
                var controlsToSet = "";
                controlsToSet = "CallingWindowContent.document.getElementById('ctl00_ContentPlaceHolderMain_RadEditorAssignmentComment').set_html = 'adsf';"
                alert(controlsToSet);
                var ContentPageHiddenField = CallingWindowContent.document.getElementById("ctl00_ContentPlaceHolderMain_ContentPageHiddenFieldLookupPassthrough");

                if (ContentPageHiddenField) {
                    cts = controlsToSet;
                    ContentPageHiddenField.value = cts;
                    CallingWindowContent.setIFrameContentControls();
                } else {
                    eval(controlsToSet);
                };
                //Close the second RadWindow
                oWnd.close();
            }
           

        </script>
    </telerik:RadScriptBlock>--%>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:HiddenField ID="HiddenFieldControlsToSet" runat="server"  />
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <asp:Panel ID="Panel1" runat="server" DefaultButton="ButtonAdd" CssClass="button-box">
            <div style="display: inline-block; clear: both; padding: 4px 0px 8px 8px;">
                <%--<asp:TextBox ID="TextBoxComment" runat="server" Width="310"></asp:TextBox>--%>
                <telerik:RadEditor ID="RadEditorComment" runat="server" Width="1100" Height="550" NewLineBr="true" NewLineMode="Br" OnClientLoad="RadEditorOnClientLoad"
                    ContentAreaCssFile="~/CSS/RadEditorContentArea.css" ToolsFile="~/RadEditorToolbars.xml" OnClientCommandExecuted="RadEditorOnClientCommandExecuted" StripFormattingOptions="MsWord"
                    EditModes="Design" EmptyMessage="Enter Comment">
                        <CssFiles>
                            <telerik:EditorCssFile Value="~/CSS/RadEditorContentArea.css" />
                        </CssFiles>
                </telerik:RadEditor>                
            </div>
            <div vertical-align: middle !important">
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="ButtonAdd" runat="server" Text="Add" />&nbsp;&nbsp;
                            <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" />
                        </td>
                    </tr>
                </table>                
            </div>
        </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
