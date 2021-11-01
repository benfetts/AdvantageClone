<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="timeline_p.aspx.vb" Inherits="Webvantage.timeline_p" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
<table align="center" border="0" cellpadding="2" cellspacing="0"
            width="100%">
            <tr>
                <td valign="top" >
                    <table align="center" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="center"   width="100%" >
                               Traffic Timeline</td>
                        </tr>
                        <tr>
                            <td style="width: 338px">
                                <asp:Repeater ID="dlJobs" runat="server">
                                    <ItemTemplate>
                                        <table align="center" border="0" bordercolor="#333399" cellpadding="0" cellspacing="0"
                                            width="100%">
                                            <tr>
                                                <td align="center" colspan="2" >
                                                   Client/Divsion/Product</strong></td>
                                                <td align="center" colspan="2" >
                                                   Job/Job Component/AE</strong></td>
                                            </tr>
                                            <tr>
                                                <td align="right" valign="top">
                                                   <strong>Client:&nbsp;</strong>
                                                    <br />
                                                   <strong>Division:&nbsp;</strong>
                                                    <br />
                                                   <strong>Product:&nbsp;</strong>
                                                </td>
                                                <td align="left" valign="top">
                                                    <%# Eval("Client") %>
                                                    <br />
                                                    <%# Eval("Division") %>
                                                    <br />
                                                    <%# Eval("Product") %>
                                                    &nbsp;
                                                </td>
                                                <td align="right" valign="top">
                                                   <strong>Job:&nbsp;</strong>
                                                    <br />
                                                   <strong>Job Comp:&nbsp;</strong>
                                                    <br />
                                                   <strong>AE:&nbsp;</strong>
                                                </td>
                                                <td align="left" valign="top">
                                                    <%# Eval("Job") %>
                                                    <br />
                                                    <%# Eval("Job Comp") %>
                                                    <br />
                                                    <%# Eval("AE") %>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr>
                                    <td align="center" valign="top" style="width: 338px">
                                        <asp:DataGrid ID="dgTimeline" runat="server" CellPadding="0" CellSpacing="0" EnableViewState="False"
                                            GridLines="None" HeaderStyle-BackColor="#F5F5F5" >
                                        </asp:DataGrid></td>
                                </tr>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="bottom" style="width: 338px">
                                <img src="images/phase_start.gif"><img src="images/phase_middle.gif"><img src="images/phase_end.gif">&nbsp;=&nbsp;&nbsp;Phase
                                Duration<br />
                                <img src="images/task_start.gif"><img src="images/task_middle.gif"><img src="images/task_end.gif">&nbsp;=&nbsp;&nbsp;Task
                                Duration<br />
                                <img src="images/mile_start.gif"><img src="images/mile_middle.gif"><img src="images/mile_end.gif">&nbsp;=&nbsp;&nbsp;Task
                                Milestone Duration<br />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label   ID="lblNorecords" runat="server" Width="160px"></asp:Label>
                </td>
            </tr>
        </table>
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />


</asp:Content>
