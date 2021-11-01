<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="popReportSelect.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Report Selection" Inherits="Webvantage.popReportSelect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table id="wrapper" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="center" valign="middle">
                <div id="divReportSelection">
                    <table>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                <asp:RadioButton ID="rbReport1" runat="server" Text="Schedule Detail by Job" GroupName="ReportGroup"
                                    Checked="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbHours" runat="server" Text='Include Employee Hours' />
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                <asp:RadioButton ID="rbReport2" runat="server" Text="Gantt Chart by Job" GroupName="ReportGroup" />
                            </td>
                        </tr>
                        <tr align="left">
                            <td>
                                <asp:RadioButton ID="rbCalendar" runat="server" Text="Calendar by Job" GroupName="ReportGroup" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button OnClientClick="javascript:window.close();" ID="BtnClose" runat="server"
                                    Text="Close" />&nbsp;&nbsp;<asp:Button ID="BtnGenReport" runat="server" Text="Print" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>