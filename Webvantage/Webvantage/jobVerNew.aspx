<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="jobVerNew.aspx.vb" Inherits="Webvantage.jobVerNew"
    MasterPageFile="~/ChildPage.Master" Title="New Job Version" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script>
            function closeWindow() {
                var oWnd = GetRadWindow();
                if (oWnd) {
                    if (oWnd.BrowserWindow && oWnd.BrowserWindow.closeWindow) {
                        oWnd.BrowserWindow.closeWindow();
                    }
                    else if (oWnd.BrowserWindow && oWnd.BrowserWindow.Cancel) {
                        oWnd.BrowserWindow.Cancel();
                    }
                    else {
                        if (oWnd.GetRadWindow) {
                            oWnd = oWnd.GetRadWindow();

                            if (oWnd.BrowserWindow) {
                                oWnd.BrowserWindow.Cancel();
                            }
                            else {
                                try {
                                    oWnd.close();
                                } catch (e) {

                                }
                            }
                        }
                        else {
                            oWnd.close();
                        }
                    }
                }
            }

        </script>
    </telerik:RadScriptBlock>

    <style type="text/css">       
        .RadComboBox_Metro .rcbInput {
            height: 32px !important;
            font-size: 13px !important;
            font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;
        }
        .RadComboBox_Bootstrap .rcbInput {
             height: 32px !important;
            font-size: 13px !important;
            font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;
        }

        .RadComboBoxDropDown_Metro {
            font-size: 13px !important;
        }

        .RadComboBoxDropDown_Bootstrap {
            font-size: 13px !important;
        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="">
        <asp:Panel ID="pnlJSNew" runat="server">
           
            <div class="code-description-container" style="text-align: center; margin-top: 10px;">
                <div class="code-description-code">
                    Select a Template:
                </div>
                <div class="code-description-description">
                    <telerik:RadComboBox ID="ddJVTemplates" runat="server" Width="400" SkinID="RadComboBoxStandard">
                </telerik:RadComboBox>
                </div>
            </div>
            <div style="width: 100%; text-align: center; padding: 30px 0px 0px 0px;">
                <asp:Button ID="ButtonNewSave" runat="server" Text="Save" />&nbsp;
                <asp:Button ID="ButtonNewCopy" runat="server" Text="Copy" />&nbsp;
                <asp:Button ID="ButtonNewCancel" runat="server" Text="Cancel" />
            </div>

        </asp:Panel>
        <asp:Panel ID="PanelJobRequest" runat="server">
            <div class="code-description-container" style="text-align: center">
                <div class="code-description-label">
                   &nbsp;
                </div>
                <div class="code-description-description">
                    &nbsp;
                </div>
            </div>
            <div class="code-description-container" style="text-align: center">
                <div class="code-description-code">
                    Select a Template:
                </div>
                <div class="code-description-description">
                    <telerik:RadComboBox ID="RadComboBoxJobRequest" runat="server" Width="400" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </div>
            </div>
            <div style="width: 100%; text-align: center; padding: 30px 0px 0px 0px;">
                <asp:Button ID="ButtonNewSaveRequest" runat="server" Text="Save" />&nbsp;
                <%--<asp:Button ID="Button2" runat="server" Text="Copy" />&nbsp;--%>
                <asp:Button ID="ButtonCancelRequest" runat="server" Text="Cancel" OnClientClick="closeWindow();" />
            </div>

        </asp:Panel>
        <asp:Panel ID="pnlJVCopy" runat="server">
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HlClientSource" runat="server" Text="Client:" href=""></asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtClientSource" runat="server" MaxLength="6" TabIndex="1" Text=""
                        SkinID="TextBoxCodeSmall"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtClientSourceDesc" runat="server" ReadOnly="true" TabIndex="-1"
                        Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HlDivisionSource" runat="server" TabIndex="-1" Text="Division:"
                        href=""></asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtDivisionSource" runat="server" MaxLength="6" TabIndex="2" Text=""
                        SkinID="TextBoxCodeSmall"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtDivisionSourceDesc" runat="server" ReadOnly="true" TabIndex="-1"
                        Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HlProductSource" runat="server" href="" TabIndex="-1" Text="Product:"></asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtProductSource" runat="server" MaxLength="6" TabIndex="3" Text=""
                        SkinID="TextBoxCodeSmall"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtProductSourceDesc" runat="server" ReadOnly="true" TabIndex="-1"
                        Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HlJob" runat="server" TabIndex="-1" Text="Job:" href=""></asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtJobNum" runat="server" MaxLength="6" TabIndex="4" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtJobDescription" runat="server" ReadOnly="true" TabIndex="-1"
                        Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HlComponent" runat="server" TabIndex="-1" Text="Component:" href=""></asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtJobCompNum" runat="server" MaxLength="3" TabIndex="5" Text=""
                        SkinID="TextBoxCodeSmall"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtJobCompDescription" runat="server" ReadOnly="true" TabIndex="-1"
                        Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    <asp:HiddenField ID="hfContactCodeID" runat="server" />
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                </div>
                <div class="code-description-code">
                </div>
                <div class="code-description-description">
                </div>
            </div>
            <div style="width: 90%; text-align: center; padding: 10px;">
                <asp:Button ID="btnGetVersions" runat="server" Text="Get Versions" TabIndex="6" />
            </div>
            <div style="width: 90%; text-align: center; padding: 10px;">
                Version:
            </div>
            <div style="width: 90%; text-align: center; padding: 10px;">
                <telerik:RadComboBox ID="ddVersions" runat="server" TabIndex="7" Width="400" SkinID="RadComboBoxStandard">
                </telerik:RadComboBox>
            </div>
            <div style="width: 90%; text-align: center; padding: 30px;">
                <asp:Button ID="ButtonCopySave" runat="server" Text="Save" />&nbsp;
                <asp:Button ID="ButtonCopyNew" runat="server" Text="New" Visible="false" />&nbsp;
                <asp:Button ID="ButtonCopyCancel" runat="server" Text="Cancel" />
            </div>
        </asp:Panel>
    </div>
    
</asp:Content>
