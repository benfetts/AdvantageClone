<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Estimating_Phase.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="" Inherits="Webvantage.Estimating_Phase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Label   ID="lblMSG" runat="server" CssClass="CssRequired"></asp:Label>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left" valign="top">
                <asp:Panel ID="pnlPhase" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:RadioButton ID="rbExisting" runat="server" Text="Select Existing Phase" GroupName="Phase"
                                    AutoPostBack="true" /><br />
                                <asp:RadioButton ID="rbNew" runat="server" Text="Add New Phase" GroupName="Phase"
                                    AutoPostBack="true" /><br />
                            </td>
                        </tr>
                        <tr align="center">
                            <td>
                                <br />
                                <telerik:RadComboBox ID="ddEstimatePhase" runat="server" SkinID="RadComboBoxStandard">
                                </telerik:RadComboBox>
                                <asp:Label   ID="lblPhase" runat="server" Text="Phase: "></asp:Label>
                                <asp:TextBox ID="txtNewPhase" runat="server" Width="300px" MaxLength="30" SkinID="TextBoxStandard"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <table>
                    <tr>
                        <td align="center">
                            <br />
                            <asp:Button ID="SaveButton" runat="server" Text="Set Phase" />&nbsp;
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" />&nbsp;
                            <asp:Button id="CancelButton" runat="server" Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <telerik:RadWindowManager ID="RadWindowManagerSpecs" runat="server" >
        <Windows>
            <telerik:RadWindow ID="MediaSpecs" runat="server" DestroyOnClose="true" Height="550" InitialBehavior="Close"
                Modal="true" ReloadOnShow="true" EnableViewState="true" VisibleOnPageLoad="false"
                VisibleStatusbar="false" Width="650" Behavior="Close" />
        </Windows>
    </telerik:RadWindowManager>
    <asp:Label   ID="InjectScriptLabel" runat="server"></asp:Label>
</asp:Content>
