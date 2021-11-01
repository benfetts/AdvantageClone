<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Event_QuickPrint.aspx.vb"
    Inherits="Webvantage.Event_QuickPrint" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="CSS/Print.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" valign="top"  colspan="2">
                <asp:Label   ID="LblHeader" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top" colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="FNC_CODE" HeaderText="Function Code" ReadOnly="True" SortExpression=""
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="AD_NUMBER" HeaderText="Ad Number" ReadOnly="True" SortExpression=""
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="EVENT_LABEL" HeaderText="Event Description" ReadOnly="True"
                            SortExpression="" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="EVENT_DESC_LONG" HeaderText="Event Comment" ReadOnly="True"
                            SortExpression="" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="EVENT_DATE" HeaderText="Date" ReadOnly="True" SortExpression=""
                            ItemStyle-Width="90px" HeaderStyle-Width="90px" HeaderStyle-HorizontalAlign="Right"
                            ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="DAY_OF_WEEK" HeaderText="Day" ReadOnly="True" SortExpression=""
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="START_TIME" HeaderText="Start Time" ReadOnly="True" SortExpression=""
                            ItemStyle-Width="80px" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Right"
                            ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="END_TIME" HeaderText="End Time" ReadOnly="True" SortExpression=""
                            ItemStyle-Width="80px" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Right"
                            ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="QTY_HRS" HeaderText="Hours" ReadOnly="True" SortExpression=""
                            HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="RESOURCE_CODE" HeaderText="Resource Code" ReadOnly="True"
                            HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" SortExpression="" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" valign="top" colspan="2">
                &nbsp;
            </td>
        </tr>
    </table>
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
    </form>
</body>
</html>
