<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="dtp_statistics.aspx.vb" Inherits="Webvantage.dtp_statistics" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadGrid ID="OfficeStatsRadGrid" runat="server" AllowSorting="True" AutoGenerateColumns="true" EnableViewState="false"
        GridLines="None" EnableEmbeddedSkins="True" >
        <MasterTableView>
            <%--<Columns>
                <telerik:GridBoundColumn DataField="OFFICE_DESCRIPT" HeaderText="Office" UniqueName="colClient">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOBS_CREATED" HeaderText="Created" UniqueName="colCreated">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOBS_COMPLETED" HeaderText="Completed" UniqueName="colCompleted">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOBS_DUE" HeaderText="Due" UniqueName="colDue">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOBS_IN_PROGRESS" HeaderText="In Progress"
                    UniqueName="colTotalInProgress">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOBS_CANCELLED" HeaderText="Cancelled" UniqueName="colCancelled">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                </telerik:GridBoundColumn>
            </Columns>--%>
            <ExpandCollapseColumn Visible="False">
                <HeaderStyle Width="19px" />
            </ExpandCollapseColumn>
            <RowIndicatorColumn Visible="False">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
        </MasterTableView>
    </telerik:RadGrid>
    <telerik:RadGrid ID="OfficeStatsRadGridV" runat="server" AllowSorting="True" AutoGenerateColumns="false" EnableViewState="false"
        GridLines="None" EnableEmbeddedSkins="True" >
        <MasterTableView>
            <Columns>
                <telerik:GridBoundColumn DataField="OFFICE_DESCRIPT" HeaderText="Office" UniqueName="colClient">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOBS_CREATED" HeaderText="Created" UniqueName="colCreated">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOBS_COMPLETED" HeaderText="Completed" UniqueName="colCompleted">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOBS_DUE" HeaderText="Due" UniqueName="colDue">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOBS_IN_PROGRESS" HeaderText="In Progress"
                    UniqueName="colTotalInProgress">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOBS_CANCELLED" HeaderText="Cancelled" UniqueName="colCancelled">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                </telerik:GridBoundColumn>
            </Columns>
            <ExpandCollapseColumn Visible="False">
                <HeaderStyle Width="19px" />
            </ExpandCollapseColumn>
            <RowIndicatorColumn Visible="False">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
        </MasterTableView>
    </telerik:RadGrid>
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
</asp:Content>