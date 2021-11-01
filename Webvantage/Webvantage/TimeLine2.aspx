<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="TimeLine2.aspx.vb" Inherits="Webvantage.TimeLine2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" border="0" cellpadding="0" cellspacing="0" width="95%">
        <tr>
            <td align="left" colspan="2">&nbsp;&nbsp; <a href="" onclick="Javascript:window.open('timeline_p.aspx?JobNo=<%=(strJobNo)%>&amp;JobCompNo=<%=(strJobCompNo)%>&amp;Period=<%=(strPeriod)%>', 'PopLookup','screenX=100,left=100,screenY=100,top=100,width=800,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">
                <asp:Image ID="PrintImage" runat="server" SkinID="ImagePrint" />
            </a>&nbsp;&nbsp;Traffic Timeline
            </td>
        </tr>
        <tr>
            <td align="center" rowspan="3" valign="top" width="5%">
                <!-- New Panel -->
                <div align="left">
                    <table cellpadding="4" width="100%">
                        <tr>
                            <td>
                                <table border="0">
                                    <asp:Panel ID="pnlJob" runat="server">
                                        <tr>
                                            <td>
                                                <asp:HyperLink ID="hlJob" runat="server" href=""><span>Job:</span></asp:HyperLink>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtJob" runat="server" CssClass="RequiredInput" Width="145px" SkinID="TextBoxStandard"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlComponent" runat="server">
                                        <tr>
                                            <td>
                                                <asp:HyperLink ID="hlJobComp" runat="server" href=""><span>Component:</span></asp:HyperLink>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtJobComp" runat="server" CssClass="RequiredInput" Width="145px" SkinID="TextBoxStandard"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlPeriod" runat="server">
                                        <tr>
                                            <td align="left" valign="top">
                                                <span>View By:</span>
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:RadioButtonList ID="rbPeriod" runat="server">
                                                    <asp:ListItem Value="Day">Day</asp:ListItem>
                                                    <asp:ListItem Selected="True" Value="Week">Week</asp:ListItem>
                                                    <asp:ListItem Value="Month">Month</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <br />
                                            <table border="0" cellpadding="0" cellspacing="4" width="100%">
                                                <tr>
                                                    <td align="right" valign="bottom">
                                                        <asp:Button ID="butRefresh" runat="server" Text="View" />
                                                    </td>
                                                    <td align="left" valign="bottom">
                                                        <asp:Button ID="butClear" runat="server" Text="Clear" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" valign="top">
                                                        <%--<input id="btnClientPrint"  name="btnClientPrint" onclick="Javascript:window.open('timeline_p.aspx?JobNo=<%=(strJobNo)%>&amp;JobCompNo=<%=(strJobCompNo)%>&amp;Period=<%=(strPeriod)%>', 'PopLookup','screenX=100,left=100,screenY=100,top=100,width=800,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;"
                                                                                    type="submit" value="Print" />--%>
                                                        <%--<asp:Button ID="butPrint" runat="server"  Text="Print" />--%>
                                                    </td>
                                                    <td align="left" valign="top">&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td width="95%">
                <asp:Repeater ID="dlJobs" runat="server">
                    <ItemTemplate>
                        <table align="left" border="0" cellpadding="3" cellspacing="0">
                            <tr>
                                <td align="right" nowrap="nowrap" valign="top">
                                    <strong>Client:</strong>
                                    <br />
                                    <strong>Division:</strong>
                                    <br />
                                    <strong>Product:</strong>
                                </td>
                                <td align="left" nowrap="nowrap" valign="top">
                                    <%# Eval("Client") %>
                                    <br />
                                    <%# Eval("Division") %>
                                    <br />
                                    <%# Eval("Product") %>
                                    &nbsp;
                                </td>
                                <td align="right" nowrap="nowrap" valign="top">
                                    <strong>Job:</strong>
                                    <br />
                                    <strong>Job Comp:</strong>
                                    <br />
                                    <strong>AE:</strong>
                                </td>
                                <td align="left" nowrap="nowrap" valign="top">
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
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <asp:DataGrid ID="dgTimeline" runat="server" AlternatingItemStyle-BackColor="#F3F3FF"
                    CellPadding="0" CellSpacing="0" EnableViewState="False" GridLines="Vertical"
                    HeaderStyle-BackColor="#A5A4E5" HeaderStyle-ForeColor="#ffffff">
                    <AlternatingItemStyle BackColor="#F3F3FF" />
                    <HeaderStyle BackColor="#A5A4E5" ForeColor="White" />
                </asp:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 70px" valign="bottom">
                <img src="images/phase_start.gif"><img src="images/phase_end.gif">=&nbsp;&nbsp;Phase
                Duration<br />
                <img src="images/task_start.gif"><img src="images/task_end.gif">=&nbsp;&nbsp;Task
                Duration<br />
                <img src="images/mile_start.gif"><img src="images/mile_end.gif">=&nbsp;&nbsp;Task
                Milestone Duration<br />
            </td>
        </tr>
    </table>
</asp:Content>
