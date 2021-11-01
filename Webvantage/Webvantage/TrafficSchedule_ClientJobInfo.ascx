<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="TrafficSchedule_ClientJobInfo.ascx.vb"
    Inherits="Webvantage.TrafficSchedule_ClientJobInfo" %>
<table border="0" cellpadding="0" cellspacing="2" width="100%">
    <tr>
        <td align="right" valign="middle" width="27%">
            <span>Client:</span>
        </td>
        <td width="2%">
            &nbsp;
        </td>
        <td width="71%">
            <asp:Label   ID="lblClient" runat="server" Css></asp:Label>
    
        </td>
    </tr>
    <tr>
        <td align="right" valign="middle">
            <span>Division:</span>
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            <asp:Label   ID="lblDivision" runat="server" Css></asp:Label>
       
        </td>
    </tr>
    <tr>
        <td align="right" valign="middle">
            <span>Product:</span>
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            <asp:Label   ID="lblProduct" runat="server" Css></asp:Label>
           
        </td>
    </tr>
    <tr>
        <td align="right" valign="middle" >
            <span>Job:</span>
        </td>
        <td >
            &nbsp;
        </td>
        <td>
            <asp:Label   ID="lblJob" runat="server" Css></asp:Label>
           
        </td>
    </tr>
    <tr>
        <td align="right" valign="middle">
            <span>Component:</span>
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            <asp:Label   ID="lblJobComp" runat="server" Css></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right" valign="middle">
            <span>Account Executive:</span>
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            <asp:Label   ID="lblAE" runat="server" Css></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right" valign="middle">
            <span>Job Start Date:</span>
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            <asp:Label   ID="lblJobStartDate" runat="server" Css></asp:Label>
           
        </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <span>Job Due Date:</span>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label   ID="lblJobDueDate" runat="server" Css></asp:Label>
               
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <span>Job Status:</span>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label   ID="lblJobStatus" runat="server" Css></asp:Label>
               
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <span>Comments:</span>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label   ID="lblJobComments" runat="server" Css></asp:Label>
            </td>
        </tr>
</table>
