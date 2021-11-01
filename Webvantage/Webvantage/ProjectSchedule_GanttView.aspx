<%@ Page Title="Gantt View" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="ProjectSchedule_GanttView.aspx.vb" Inherits="Webvantage.ProjectSchedule_GanttView" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentProjectScheduleGanttView" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="5px">
                            &nbsp;
                        </td>
                        <td>
                            <telerik:RadComboBox ID="DropDownListJob" runat="server" AutoPostBack="true" Width="300px"
                                DataTextField="Description" DataValueField="Number" >
                            </telerik:RadComboBox>
                        </td>
                        <td align="center" width="5px">
                            <telerik:RadButton ID="RadButtonAddJob" runat="server" Text="Add Job"
                                Width="100%">
                            </telerik:RadButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <br />
                    <telerik:RadScheduler ID="RadSchedulerProjectSchedule" runat="server" SelectedView="MultiDayView" DataEndField="DueDate" DataStartField="StartDate"
                        DataKeyField="ID" DataSubjectField="Description" 
                        OverflowBehavior="Expand">
                        <MultiDayView NumberOfDays="20"/>
                        <ResourceTypes>
                        
                        </ResourceTypes>
                    </telerik:RadScheduler>
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
