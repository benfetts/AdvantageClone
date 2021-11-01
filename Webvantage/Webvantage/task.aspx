<%@ Page AutoEventWireup="false" CodeBehind="task.aspx.vb" Inherits="Webvantage.task"
    MasterPageFile="~/ChildPage.Master" Title="Task Details" Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script type="text/javascript">

        function checkLength(field, len) {
            if (field.value.length > len) // too long...trim it!
                field.value = field.value.substring(0, len);
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <telerik:RadToolBar ID="RadToolBarTask" runat="server" Width="100%">
            <Items>
                <telerik:RadToolBarButton Text="Comments" Value="Comments" CommandName="Comments">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Text="Mark Completed" Value="MarkCompleted" CommandName="MarkCompleted">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Text="Mark Not Completed" Value="MarkNotCompleted" CommandName="MarkNotCompleted">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Text="Add Time" Value="AddTime" CommandName="AddTime">
                </telerik:RadToolBarButton>
            </Items>
        </telerik:RadToolBar>
        <asp:DataList ID="dlTask" runat="server" Width="100%">
        <ItemTemplate>
            <ew:CollapsablePanel ID="CollapsablePanelClient" runat="server" TitleText="Client"
                >
                <table id="Table1" border="0" cellpadding="0" cellspacing="2" width="100%">
                    <tr>
                        <td width="145">
                            Client:
                        </td>
                        <td>
                            <%# Eval("CLIENT")%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Division:
                        </td>
                        <td>
                            <%# Eval("DIVISION")%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Product:
                        </td>
                        <td>
                            <%# Eval("PRODUCT")%>
                        </td>
                    </tr>
                </table>
            </ew:CollapsablePanel>
            <ew:CollapsablePanel ID="CollapsablePanelJob" runat="server" 
                TitleText="Job" >
                <table id="Table2" border="0" cellpadding="0" cellspacing="2" width="100%">
                    <tr>
                        <td width="145">
                            Job:
                        </td>
                        <td>
                            <%# Eval("Job")%>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Job Comp:
                        </td>
                        <td>
                            <%# Eval("JobComp")%>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Account Executive:
                        </td>
                        <td>
                            <%# Eval("AE")%>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Start Date:
                        </td>
                        <td>
                            <%# Webvantage.LoGlo.FormatDate(Eval("JobStartDate"))%>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Due Date:
                        </td>
                        <td>
                            <%# Webvantage.LoGlo.FormatDate(Eval("JobDueDate"))%>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Status:
                        </td>
                        <td>
                            <%# Eval("TrafficStatus")%>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Comments:
                        </td>
                        <td align="left" valign="top">
                            <%# Eval("TrafficComments")%>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </ew:CollapsablePanel>
            <ew:CollapsablePanel ID="CollapsablePanelTask" runat="server" 
                TitleText="Task" >
                <table id="Table3" border="0" cellpadding="0" cellspacing="2" width="100%">
                    <tr>
                        <td width="145">
                            Phase:
                        </td>
                        <td>
                            <%# Eval("Phase")%>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Task:
                        </td>
                        <td>
                            <%# Eval("Task")%>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Employee:
                        </td>
                        <td>
                            <%# Eval("Employee")%>
                            &nbsp;&nbsp;&nbsp;<asp:HyperLink ID="hlEmps" runat="server" Text="Assigned" href=""></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Status:
                        </td>
                        <td>
                            <%# ShowTaskStatus(Eval("TaskStatus"))%>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Hours Allowed:
                        </td>
                        <td>
                            <%# Eval("HoursAllowed")%>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Start Date:
                        </td>
                        <td>
                            <%# Webvantage.LoGlo.FormatDate(Eval("TaskStartDate"))%>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Due Date:
                        </td>
                        <td>
                            <%# Webvantage.LoGlo.FormatDate(Eval("RevDueDate"))%>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Time Due:
                        </td>
                        <td>
                            <%#Eval("RevDueTime")%>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Temp Complete Date:
                        </td>
                        <td>
                            <%# Webvantage.LoGlo.FormatDate(Eval("TempCompDate"))%>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Comments:
                        </td>
                        <td align="left" valign="top">
                            <%# replace(Eval("Comments"), vbcrlf, "<br />")%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Due Date Comments:
                        </td>
                        <td align="left" valign="top">
                            <%#Replace(Eval("DueDateComments"), vbCrLf, "<br />")%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Revised Due Date Comments:
                        </td>
                        <td align="left" valign="top">
                            <%#Replace(Eval("RevDateComments"), vbCrLf, "<br />")%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Completion Comments:
                        </td>
                        <td align="left" valign="top">
                            <%#Replace(Eval("CompletedComments"), vbCrLf, "<br />")%>&nbsp;
                        </td>
                    </tr>
                </table>
            </ew:CollapsablePanel>
        </ItemTemplate>
        </asp:DataList>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
