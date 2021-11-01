<%@ Page Title="Workload Analysis" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="TrafficSchedule_Workload2.aspx.vb" Inherits="Webvantage.TrafficSchedule_Workload2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <style type="text/css">
        .emp-name {
            min-width: 200px;
        }
    </style>
    <div class="telerik-aqua-body" style="margin-top: 5px!important;">
    <div style="width: 100%;padding: 10px 0px 10px 0px;">
        <asp:CheckBox ID="ChkOnlyOverbooked" runat="server" Text="Only overbooked employees" AutoPostBack="true" Visible="true" />
    </div>
    <div style="width:100%;">
        <telerik:RadGrid ID="RadGridWorkload" runat="server" AllowSorting="True" AutoGenerateColumns="False" GridLines="None" Width="100%" EnableEmbeddedSkins="true" CssClass="grid-width">
            <MasterTableView NoMasterRecordsText="No Records to Display" Caption="">
                <ExpandCollapseColumn Resizable="False" Visible="False">
                    <HeaderStyle Width="20px" />
                </ExpandCollapseColumn>
                <RowIndicatorColumn Visible="False">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="EMP_CODE" HeaderText="Employee Code" UniqueName="ColEMP_CODE">
                        <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" />
                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EMP_FML_NAME" HeaderText="Employee Name" UniqueName="ColEMP_FML_NAME">
                        <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" CssClass="emp-name" />
                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" CssClass="emp-name" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="STD_HRS_AVAIL" HeaderText="Standard Hours Availabile" UniqueName="ColSTD_HRS_AVAIL" DataFormatString="{0:0.00}">
                        <HeaderStyle HorizontalAlign="right" VerticalAlign="middle" />
                        <ItemStyle HorizontalAlign="right" VerticalAlign="middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="APPT_HRS" HeaderText="Appointment Hours" UniqueName="ColAPPT_HRS" DataFormatString="{0:0.00}">
                        <HeaderStyle HorizontalAlign="right" VerticalAlign="middle" />
                        <ItemStyle HorizontalAlign="right" VerticalAlign="middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="HRS_OFF" HeaderText="Hours Off" UniqueName="ColHRS_OFF" DataFormatString="{0:0.00}">
                        <HeaderStyle HorizontalAlign="right" VerticalAlign="middle" />
                        <ItemStyle HorizontalAlign="right" VerticalAlign="middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ADJ_HRS_ASSIGNED_TASK" HeaderText="Adjusted Hours Assigned (Current Job)" DataFormatString="{0:0.00}" UniqueName="ColADJ_HRS_ASSIGNED_TASK">
                        <HeaderStyle HorizontalAlign="right" VerticalAlign="middle" />
                        <ItemStyle HorizontalAlign="right" VerticalAlign="middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ADJ_HRS_ASSIGNED_TASK_OTHER" HeaderText="Adjusted Hours Assigned (All Other Jobs)" DataFormatString="{0:0.00}" UniqueName="ColADJ_HRS_ASSIGNED_TASK">
                        <HeaderStyle HorizontalAlign="right" VerticalAlign="middle" />
                        <ItemStyle HorizontalAlign="right" VerticalAlign="middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="VARIANCE" HeaderText="Variance" UniqueName="ColVARIANCE" DataFormatString="{0:0.00}">
                        <HeaderStyle HorizontalAlign="right" VerticalAlign="middle" />
                        <ItemStyle HorizontalAlign="right" VerticalAlign="middle" />
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
    </div>

</asp:Content>
