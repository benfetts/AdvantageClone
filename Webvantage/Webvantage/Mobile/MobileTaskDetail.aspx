<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MobileTaskDetail.aspx.vb" Inherits="Webvantage.MobileTaskDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>Webvantage Mobile</title>
    
    
    <link href="~/CSS/MobileBB.min.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
        <meta name="viewport" content="width = 320" />  
    <meta name="viewport" content="initial-scale=1, user-scalable=yes" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table id="tblMobileHeader" runat="server" width="200">
                <tr>
                    <td style="width: 60px;">
                        <asp:Button runat="server" ID="btnBack" Text="Back" ForeColor="blue" BorderStyle="Solid"
                            BorderWidth="1px" Font-Size="XX-Small" />
                    </td>
                    <td style="width: 60px;">
                        <asp:Button runat="server" ID="btnLogout" Text="Logout" ToolTip="Logout" ForeColor="blue"
                            BorderStyle="Solid" BorderWidth="1px" Font-Size="XX-Small"></asp:Button>
                    </td>
                </tr>
            </table>
            <asp:DataList ID="dlTask" runat="server" Width="100%">
            <ItemTemplate>
    <asp:Table runat="server" ID="tblDetails" Font-Size="XX-Small" Width="320px">
        <asp:TableRow BackColor="#d8e4f8">
        <asp:TableCell>Client Info</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label   runat="server" ID="lblClient" Font-Bold="true" Text="Client: "></asp:Label><%# Eval("CLIENT")%></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label   runat="server" ID="lblClientDivision" Font-Bold="true"  Text="Division: "></asp:Label><%# Eval("DIVISION")%>  </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label   runat="server" ID="lblClientProduct" Font-Bold="true"  Text="Product: "></asp:Label><%# Eval("PRODUCT")%></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow BackColor="#d8e4f8">
            <asp:TableCell>Job Info</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label   runat="server" ID="lblJob" Font-Bold="true"  Text="Job: "></asp:Label><%# Eval("Job")%></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label   runat="server" ID="lblJobComp"  Font-Bold="true" Text="Job Comp: "></asp:Label><%# Eval("JobComp")%> </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label   runat="server" ID="lblJobAccountexec" Font-Bold="true"  Text="Account Executive: "></asp:Label><%# Eval("AE")%> </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label   runat="server" ID="lblJobStartDate" Font-Bold="true"  Text="Start Date: "></asp:Label><%# Eval("JobStartDate")%> </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label   runat="server" ID="lblJobDueDate" Font-Bold="true"  Text="Due Date: "></asp:Label><%# Eval("JobDueDate")%> </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label   runat="server" ID="lblJobStatus" Font-Bold="true"  Text="Status: "></asp:Label><%# Eval("TrafficStatus")%> </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow Width="300px">
            <asp:TableCell><asp:Label   runat="server" ID="lblJobComment" Font-Bold="true" Text="Comment: "></asp:Label><%# Eval("TrafficComments")%> </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow BackColor="#d8e4f8">
            <asp:TableCell>Task Info</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label   runat="server" ID="lblTaskPhase" Font-Bold="true"  Text="Phase: "></asp:Label><%# Eval("Phase")%> </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label   runat="server" ID="lblTask" Font-Bold="true"  Text="Task: "></asp:Label><%# Eval("Task")%> </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label   runat="server" ID="lblTaskEmployee" Font-Bold="true"  Text="Employee: "></asp:Label> <%# Eval("Employee")%>
                             </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label   runat="server" ID="lblTaskStatus" Font-Bold="true"  Text="Status: "></asp:Label><%# ShowTaskStatus(Eval("TaskStatus"))%> </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label   runat="server" ID="lblTaskHoursAllowed"  Font-Bold="true" Text="Hours Allowed: "></asp:Label><%# Eval("HoursAllowed")%> </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label   runat="server" ID="lblTaskStartDate" Font-Bold="true"  Text="Start Date: "></asp:Label><%# Eval("TaskStartDate")%> </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label   runat="server" ID="lblTaskDueDate" Font-Bold="true"  Text="Due Date: "></asp:Label><%# Eval("RevDueDate")%> </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label   runat="server" ID="lblTaskTimeDue"  Font-Bold="true" Text="Time Due: "></asp:Label><%#Eval("RevDueTime")%> </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label   runat="server" ID="lblTaskTempCompleteDate" Font-Bold="true"  Text="Temp Complete Date: "></asp:Label><%# Eval("TempCompDate")%></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="300px"><asp:Label   runat="server" ID="lblTaskComments" Font-Bold="true"  Text="Comments: "></asp:Label><%# replace(Eval("Comments"), vbcrlf, "<br />")%> </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="300px"><asp:Label   runat="server" ID="lblTaskDueDateComments"  Font-Bold="true"  Text="Due Date Comments: "></asp:Label><%#Replace(Eval("DueDateComments"), vbCrLf, "<br />")%></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="300px"><asp:Label   runat="server" ID="lblTaskRevisedDueDateComments"  Font-Bold="true"  Text="Revised Due Date Comments: "></asp:Label><%#Replace(Eval("RevDateComments"), vbCrLf, "<br />")%></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell Width="300px">
            <asp:Label   runat="server" ID="lblTaskCompletionComments"  Font-Bold="true"  Text="Completion Comments: "></asp:Label><%#Replace(Eval("CompletedComments"), vbCrLf, "<br />")%> </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow BackColor="#d8e4f8">
            <asp:TableCell> </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </ItemTemplate>
    </asp:DataList>
    <asp:LinkButton ID="lbComments"  runat="server" Text="Comments"></asp:LinkButton>&nbsp;
    <asp:LinkButton ID="lbMarkNotCompleted"  runat="server" Text="Mark Not Completed"></asp:LinkButton>&nbsp;
    <asp:LinkButton ID="lbMarkCompleted"  runat="server" Text="Mark Completed"></asp:LinkButton>&nbsp;
    <asp:LinkButton ID="lbAddTime"  runat="server" Text="Add Time"></asp:LinkButton>&nbsp;
    </div>
    </form>
</body>
</html>
