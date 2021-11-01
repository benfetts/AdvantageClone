<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Resources_Emps_QuickPrint.aspx.vb"
    Inherits="Webvantage.Resources_Emps_QuickPrint" %>

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
            <td align="center" valign="top" >
                <asp:Label   ID="LblHeader" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:GridView ID="GridViewQuickPrint_Event" runat="server" AutoGenerateColumns="false"
                    Width="100%">
                    <Columns>
                        <asp:BoundField DataField="EVENT_ID" HeaderText="Event ID" ReadOnly="True" SortExpression=""
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="EVENT_LABEL" HeaderText="Event Description" ReadOnly="True"
                            SortExpression="" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="TASK_CODE" HeaderText="Task" ReadOnly="True" SortExpression=""
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="TRF_DESC" HeaderText="Task Description" ReadOnly="True"
                            SortExpression="" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="START_DATE" HeaderText="Date" ReadOnly="True" SortExpression=""
                            DataFormatString="{0:d}" ItemStyle-Width="90px" HeaderStyle-Width="90px"
                            HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="START_TIME" HeaderText="Start Time" ReadOnly="True" SortExpression=""
                            DataFormatString="{0:t}" ItemStyle-Width="80px" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Right"
                            ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="END_TIME" HeaderText="End Time" ReadOnly="True" SortExpression=""
                            DataFormatString="{0:t}" ItemStyle-Width="80px" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Right"
                            ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="EMP_CODE" HeaderText="Employee Code" ReadOnly="True" HeaderStyle-HorizontalAlign="Left"
                            ItemStyle-HorizontalAlign="Left" SortExpression="" />
                        <asp:BoundField DataField="EMP_FML" HeaderText="Employee Name" ReadOnly="True" HeaderStyle-HorizontalAlign="Left"
                            ItemStyle-HorizontalAlign="Left" SortExpression="" />
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="GridViewQuickPrint_PS" runat="server" AutoGenerateColumns="false"
                    Width="100%">
                    <Columns>
                        <asp:BoundField DataField="FNC_CODE" HeaderText="Task" ReadOnly="True" SortExpression=""
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="TASK_DESCRIPTION" HeaderText="Task Description" ReadOnly="True"
                            SortExpression="" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="TASK_START_DATE" HeaderText="Date" ReadOnly="True" SortExpression=""
                            DataFormatString="{0:d}" ItemStyle-Width="90px" HeaderStyle-Width="90px"
                            HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="JOB_REVISED_DATE" HeaderText="Start Time" ReadOnly="True"
                            DataFormatString="{0:d}" SortExpression="" ItemStyle-Width="80px" HeaderStyle-Width="80px"
                            HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="EMP_CODE_LIST" HeaderText="Employee Code(s)" ReadOnly="True"
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" SortExpression="" />
                        <asp:BoundField DataField="EMP_LFI_LIST" HeaderText="Employee Name(s)" ReadOnly="True"
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" SortExpression="" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                &nbsp;
            </td>
        </tr>
    </table>
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
    </form>
</body>
</html>
