<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Calendar_QuickPrint.aspx.vb"
    Inherits="Webvantage.Calendar_QuickPrint" MasterPageFile="~/ChildPage.Master" Title="Calendar Print" %>

<%@ Register Src="ReportTypeUC.ascx" TagName="reporttype" TagPrefix="uc1" %>
<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain"
    EnableViewState="true">
    <%--<fieldset>
        <legend><strong>Location ID</strong></legend>
        <table id="Table5" cellpadding="2" cellspacing="0" width="99%">
            <tr>
                <td align="left" valign="top">
                   Location ID:
                    <telerik:RadComboBox ID="ddLocation" runat="server"  Width="500px" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </td>
            </tr>
        </table>
    </fieldset>--%>
    <fieldset>
        <legend><strong>Report Title and Placement</strong></legend>
        <table id="Table7" cellpadding="2" cellspacing="0" width="99%">
            <tr style="width: 40%">
                <td align="left" colspan="2">
                   <strong>Title:</strong>
                    <asp:TextBox ID="TBTitle" runat="server" Width="70%" MaxLength="60" SkinID="TextBoxStandard">Calendar Report</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 5%">
                    &nbsp;
                </td>
                <td align="left" style="width: 95%">
                    <asp:RadioButtonList ID="rbplacement" runat="server"  
                        RepeatColumns="3">
                        <asp:ListItem Selected="True" Value="left">Left</asp:ListItem>
                        <asp:ListItem Value="right">Right</asp:ListItem>
                        <asp:ListItem Value="center">Center</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
    </fieldset>
    <table width="95%" align="center">
        <tr>
            <td align="center" colspan="8" valign="middle">                
                <telerik:RadComboBox ID="ddlReportType" runat="server" Visible="false" SkinID="RadComboBoxStandard">
                </telerik:RadComboBox>
                <br />
                <br />
                <asp:Button ID="btnSubmit" runat="server" Text="View" /><br />
                <br />                
            </td>
        </tr>
    </table>
</asp:Content>
