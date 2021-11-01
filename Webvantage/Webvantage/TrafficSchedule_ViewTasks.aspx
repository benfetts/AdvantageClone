<%@ Page Title="View Tasks" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="TrafficSchedule_ViewTasks.aspx.vb" Inherits="Webvantage.TrafficSchedule_ViewTasks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="telerik-aqua-body" style="margin-top: 5px!important;">
         <fieldset>
                <legend>Client</legend>
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="2" id="Table2">
                    <tr>
                        <td width="110">
                            Client:
                        </td>
                        <td>
                            <asp:Label   ID="LabelClient" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Division:
                        </td>
                        <td>
                            <asp:Label   ID="LabelDivision" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap="nowrap">
                            Product:
                        </td>
                        <td>
                            <asp:Label   ID="LabelProduct" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend>Project</legend>
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="2" id="Table1">
                    <tr>
                        <td width="110">
                            Job:
                        </td>
                        <td>
                            <asp:Label   ID="LabelJob" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Job Comp:
                        </td>
                        <td>
                            <asp:Label   ID="LabelJobComponent" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Start Date:
                        </td>
                        <td>
                            <asp:Label   ID="LabelStartDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Due Date:
                        </td>
                        <td>
                            <asp:Label   ID="LabelDueDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Traffic Status:
                        </td>
                        <td>
                            <asp:Label   ID="LabelTrafficStatus" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            Traffic Comments:
                        </td>
                        <td align="left" valign="top">
                            <asp:Label   ID="LabelTrafficComments" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend>Tasks</legend>
                <telerik:RadGrid ID="RadGridTasks" runat="server" AutoGenerateColumns="False" ShowFooter="false"
                    GridLines="None" EnableEmbeddedSkins="True">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="JOB_NUMBER,JOB_COMPONENT_NBR,SEQ_NBR">
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Resizable="False" Visible="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Task" HeaderText="Description" SortExpression="Task"
                                ReadOnly="True" UniqueName="GridBoundColumnTask">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                                <FooterStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DueDate" HeaderText="Due" SortExpression="DueDate"
                                ReadOnly="True" UniqueName="GridBoundColumnDueDate">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EmpCode" HeaderText="Employee" SortExpression="EmpCode"
                                ReadOnly="True" UniqueName="GridBoundColumnEmpCode">
                                <HeaderStyle HorizontalAlign="Left"  Width="200" />
                                <ItemStyle HorizontalAlign="Left" Width="200" />
                                <FooterStyle HorizontalAlign="Left" Width="200" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="HoursAllowed" HeaderText="Hours Allowed" SortExpression="HoursAllowed"
                                ReadOnly="True" UniqueName="GridBoundColumnHoursAllowed">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="RevDueDate" HeaderText="Revised Due" SortExpression="RevDueDate"
                                ReadOnly="True" UniqueName="GridBoundColumnRevDueDate">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TempCompDate" HeaderText="Temp Completed"
                                SortExpression="TempCompDate" ReadOnly="True" UniqueName="GridBoundColumnTempCompDate">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </fieldset>
    </div>
   
</asp:Content>
