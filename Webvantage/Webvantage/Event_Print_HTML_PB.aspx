<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Event_Print_HTML_PB.aspx.vb" Inherits="Webvantage.Event_Print_HTML_PB" EnableEventValidation="false" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="CSS/Print.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <div align="center" class="no-print">
        <webvantage:Print_Buttons ID="Print_Buttons2" runat="server" />
    </div>
    <br />
    <br />
    <asp:Repeater ID="RptrGrouping" runat="server">
        <ItemTemplate>
            <!--Beginning of email div-->
            <div runat="server" id="div_email">
                <table width="900" border="0" align="center" cellpadding="2" cellspacing="0" style="border-top: #000000 1px solid;border-right: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid;background-color: #FFFFFF; color: #000000;">
                    <tr>
                        <td>
                            <strong><font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                <asp:Label   ID="LblGroupingTitle" runat="server" Text="" CssClass="HeaderPageBreak"></asp:Label></font></strong>
                            <asp:HiddenField ID="HfEmailAddress" runat="server" Value='<%#Eval("EMP_EMAIL")%>' />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Repeater ID="RptrEvent" runat="server" OnItemDataBound="RptrEvents_ItemDataBound">
                    <ItemTemplate>
                        <table width="900" border="0" align="center" cellpadding="2" cellspacing="0" style="border-top: #000000 1px solid;border-right: #000000 1px solid; border-left: #000000 1px solid; border-bottom: #000000 1px solid;background-color: #FFFFFF; color: #000000;">
                            <tr>
                                <td align="left" valign="top">
                                    <strong><font size="2" face="Verdana, Arial, Helvetica, sans-serif">EVENT:</font></strong>
                                </td>
                                <td align="left" valign="top">
                                    <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                        <%#Eval("EVENT_LABEL")%></font>
                                </td>
                                <td id="TdAdNumberImage" runat="server" width="100" align="center" valign="middle" style="border-left: #000000 1px solid; background-color: #FFFFFF; color: #000000;">
                                    <asp:Image ID="ImgAdNumber" runat="server" />
                                    <asp:HiddenField ID="HfDOCUMENT_ID" runat="server" Value='<%#Eval("DOCUMENT_ID")%>' />
                                    <br />
                                    <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                        <%#Eval("AD_NBR")%></font>
                                </td>
                            </tr>
                            <tr id="TrEventDate" runat="server">
                                <td width="70" align="left" valign="top">
                                    <strong><font size="2" face="Verdana, Arial, Helvetica, sans-serif">Date:</font></strong>
                                </td>
                                <td width="718" align="left" valign="top">
                                    <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                        <%# CType(Webvantage.LoGlo.FormatDate(Eval("EVENT_DATE")), Date).ToLongDateString()%>&nbsp;&nbsp;
                                        <%# CType(Webvantage.LoGlo.FormatDateTime(Eval("EVENT_START_TIME")), Date).ToShortTimeString%>&nbsp;-&nbsp;<%# CType(Webvantage.LoGlo.FormatDateTime(Eval("EVENT_END_TIME")), Date).ToShortTimeString()%>
                                    </font>
                                </td>
                            </tr>
                            <tr id="TrClient" runat="server">
                                <td align="left" valign="top">
                                    <strong><font size="2" face="Verdana, Arial, Helvetica, sans-serif">Client:</font></strong>
                                </td>
                                <td align="left" valign="top">
                                    <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                        <%#Eval("CL_CODE")%>
                                        -
                                        <%#Eval("CL_NAME")%></font>
                                </td>
                            </tr>
                            <tr id="TrNotes" runat="server">
                                <td align="left" valign="top">
                                    <strong><font size="2" face="Verdana, Arial, Helvetica, sans-serif">Notes:</font></strong>
                                </td>
                                <td align="left" valign="top">
                                    <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                        <%#Eval("EVENT_COMMENT")%></font>
                                </td>
                            </tr>
                            <tr id="TrResource" runat="server">
                                <td align="left" valign="top">
                                    <strong><font size="2" face="Verdana, Arial, Helvetica, sans-serif">Resource:</font></strong>
                                </td>
                                <td align="left" valign="top">
                                    <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                        <%#Eval("RESOURCE_CODE")%>
                                        -
                                        <%#Eval("RESOURCE_DESC")%></font>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="bottom">
                                    &nbsp;
                                </td>
                                <td align="left" valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="left" valign="top" style="border-top: #000000 1px solid; background-color: #FFFFFF;color: #000000;">
                                    <strong><font size="2" face="Verdana, Arial, Helvetica, sans-serif">Tasks</font></strong><br />
                                    <asp:GridView ID="GvEventTasks" runat="server" AutoGenerateColumns="false" Width="100%" BorderStyle="Solid" BorderWidth="1px" BorderColor="#dbdbdb">
                                        <Columns>
                                            <asp:BoundField DataField="EMP_FULL" HeaderText="Employee" HeaderStyle-HorizontalAlign="Left"
                                                HeaderStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif" HeaderStyle-Font-Size="X-Small"
                                                ItemStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif" ItemStyle-Font-Size="X-Small"
                                                ItemStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="TRF_CODE" HeaderText="Task Code" HeaderStyle-HorizontalAlign="Left"
                                                HeaderStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif" HeaderStyle-Font-Size="X-Small"
                                                ItemStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif" ItemStyle-Font-Size="X-Small"
                                                ItemStyle-Width="75px" ItemStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="TRF_DESC" HeaderText="Task Description" HeaderStyle-HorizontalAlign="Left"
                                                HeaderStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif" HeaderStyle-Font-Size="X-Small"
                                                ItemStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif" ItemStyle-Font-Size="X-Small"
                                                ItemStyle-Width="130px" ItemStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="START_DATE" HeaderText="Date"
                                                HeaderStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif" HeaderStyle-Font-Size="X-Small"
                                                ItemStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif" ItemStyle-Font-Size="X-Small"
                                                ItemStyle-Width="245px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                            <asp:BoundField DataField="START_TIME" HeaderText="Start"
                                                HeaderStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif" HeaderStyle-Font-Size="X-Small"
                                                ItemStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif" ItemStyle-Font-Size="X-Small"
                                                ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField DataField="END_TIME" HeaderText="End"
                                                HeaderStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif" HeaderStyle-Font-Size="X-Small"
                                                ItemStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif" ItemStyle-Font-Size="X-Small"
                                                ItemStyle-Width="75px" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                                            <asp:BoundField DataField="HOURS_ALLOWED" HeaderText="Hours" HeaderStyle-HorizontalAlign="Right"
                                                HeaderStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif" HeaderStyle-Font-Size="X-Small"
                                                ItemStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif" ItemStyle-Font-Size="X-Small"
                                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="50px" />
                                            <asp:BoundField DataField="COMMENTS" HeaderText="Comments" HeaderStyle-HorizontalAlign="Left"
                                                HeaderStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif" HeaderStyle-Font-Size="X-Small"
                                                ItemStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif" ItemStyle-Font-Size="X-Small"
                                                ItemStyle-HorizontalAlign="Left" />
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No tasks
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
                <div id="DivPageBreak" runat="server" class="page-break">
                </div>
                <div align="center" class="no-print">
                    <asp:Button ID="BtnEmail" runat="server" Text="Email" OnClick="BtnEmail_Click" BackColor="White"
                        BorderStyle="Solid" BorderWidth="1px" BorderColor="Black" /><br />
                    <br />
                    <br />
                    <br />
                </div>
            </div>
            <!--End of email div-->
        </ItemTemplate>
    </asp:Repeater>
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
    </form>
</body>
</html>
