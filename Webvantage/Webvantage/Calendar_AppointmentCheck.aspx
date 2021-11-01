<%@ Page Title="Edit" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Calendar_AppointmentCheck.aspx.vb" Inherits="Webvantage.Calendar_AppointmentCheck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">            
        </script>
    </telerik:RadScriptBlock>
    <table id="Table2" align="center" border="0" cellpadding="4" cellspacing="0" width="100%">
        <tr>
            <td rowspan="1" valign="top" align="center">
                <table id="Table1" cellpadding="2" cellspacing="0" width="100%" align="center">
                    <tr>
                        <td nowrap="nowrap" align="center">                            
                            <asp:RadioButton ID="RadioButtonOccurence" runat="server" Text='Edit only this occurrence.'
                                GroupName="Edit" /><br />
                            <asp:RadioButton ID="RadioButtonSeries" runat="server" Text='Edit the series.'
                                GroupName="Edit" />
                        </td>
                    </tr>
                </table>                
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:Button ID="ButtonSave" runat="server" Text="OK" />&nbsp;&nbsp;
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" />
            </td>
        </tr>
    </table>
</asp:Content>