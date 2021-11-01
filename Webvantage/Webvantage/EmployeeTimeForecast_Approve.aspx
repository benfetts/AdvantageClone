<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EmployeeTimeForecast_Approve.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.EmployeeTimeForecast_Approve" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" border="0" cellpadding="0" cellspacing="0" width="475">
        <tr>
            <td colspan="2">
                <%--&nbsp;&nbsp;Employee Time Forecast--%>
            </td>
        </tr>
        <tr>
            <td runat="server" id="TdRadToolBarEmployeeTimeForecast" align="left" valign="top"
                colspan="2">
                <telerik:RadToolBar ID="RadToolBarEmployeeTimeForecast" runat="server" AutoPostBack="true"
                    Width="100%">
                    <Items>
                        <telerik:RadToolBarButton  IsSeparator="true" />
                        <telerik:RadToolBarButton id="RadToolBarButtonApprove" runat="server"
                            Text="Approve" Value="Approve" CommandName="Approve" ToolTip="Approve revision" />
                        <telerik:RadToolBarButton 
                            IsSeparator="true" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonCancel"
                            Text="Cancel" Value="Cancel" CommandName="Cancel" ToolTip="Cancel approving revision" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorThirdSeparator" runat="server" IsSeparator="true" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td width="1%">
                &nbsp;
            </td>
            <td>
                <br />
                <asp:Label   ID="LabelWarningMessage" runat="server" Text="">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
            </td>
        </tr>
    </table>
</asp:Content>