<%@ Page Title="Status Summary" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="TrafficSchedule_Status_Summary.aspx.vb" Inherits="Webvantage.TrafficSchedule_Status_Summary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <style type="text/css">
            
     </style>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        
    </telerik:RadScriptBlock>
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolbarSummary" runat="server" AutoPostBack="True"
                EnableViewState="True" Width="100%">
                <Items>
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton Text="Employee Time Forecast" Value="ETF" ToolTip="Planned based on ETF."
                        CheckOnClick="true" AllowSelfUnCheck="true" Group="Hours" />
                    <telerik:RadToolBarButton Text="Hours Allowed" Value="Allowed" ToolTip="Planned based on Hours Allowed."
                        CheckOnClick="true" AllowSelfUnCheck="true" Group="Hours" Checked="true" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton Text="Quoted" Value="Quoted" ToolTip="Calculate based on Actual to Quoted."
                        CheckOnClick="true" AllowSelfUnCheck="true" Group="HoursType" Checked="true" />
                    <telerik:RadToolBarButton Text="Planned" Value="Planned" ToolTip="Calculate based on Actual to Planned."
                        CheckOnClick="true" AllowSelfUnCheck="true" Group="HoursType" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton>
                        <ItemTemplate>
                            Filter:&nbsp;
                        </ItemTemplate>
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton Text="Current Risk based on Hours" Value="AdjustedHours" ToolTip="Current Risk based on Hours"
                        CheckOnClick="true" AllowSelfUnCheck="true" Group="Filter" />
                    <telerik:RadToolBarButton Text="Long Term Risk based on Hours" Value="AllHours" ToolTip="Long Term Risk based on Hours"
                        CheckOnClick="true" AllowSelfUnCheck="true" Group="Filter" />
                    <telerik:RadToolBarButton Text="Current Risk based on Dollars" Value="AdjustedDollars" ToolTip="Current Risk based on Dollars"
                        CheckOnClick="true" AllowSelfUnCheck="true" Group="Filter" />
                    <telerik:RadToolBarButton Text="Long Term Risk based on Dollars" Value="AllDollars" ToolTip="Long Term Risk based on Dollars"
                        CheckOnClick="true" AllowSelfUnCheck="true" Group="Filter" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton Text="" Value="Export" SkinID="RadToolBarButtonExportExcel" CheckOnClick="true" AllowSelfUnCheck="true" Group="Export" />
                </Items>
            </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
        <telerik:RadGrid ID="RadGridSummary" runat="server" AutoGenerateColumns="false" GridLines="None"
                EnableEmbeddedSkins="True" HorizontalAlign="Center" AllowSorting="true" ShowFooter="true">
                <ClientSettings EnableRowHoverStyle="true">
                    <Selecting AllowRowSelect="True" />
                </ClientSettings>
                <MasterTableView HorizontalAlign="center" DataKeyNames="JOB_NUMBER,JOB_COMPONENT_NBR">
                    <Columns>
                        <telerik:GridTemplateColumn UniqueName="colDetails">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:LinkButton ID="LinkButtonSchedule" runat="server" CssClass="icon-text" CommandName="SingleView" ToolTip="Go to schedule">P</asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="colDetails">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:LinkButton ID="LinkButtonRiskAnalysis" runat="server" CssClass="icon-text" CommandName="RiskAnalysis" ToolTip="Risk Analysis">R</asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="CLIENT" HeaderText="Client" UniqueName="colCLIENT">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PROJECT_DESC" HeaderText="Project" UniqueName="colPROJECT" SortExpression="JOB_NUMBER">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="AE_NAME" HeaderText="Account Exec" UniqueName="colAE_NAME">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="STATUS" HeaderText="Status" UniqueName="colSTATUS">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="START_DATE" HeaderText="Start Date" UniqueName="colSTART_DATE">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="right" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="END_DATE" HeaderText="End Date" UniqueName="colEND_DATE">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="right" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PERC_SCHEDULE" HeaderText="% of Schedule" UniqueName="colPERC_SCHEDULE">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="QUOTED_HOURS" HeaderText="Hours Quoted" UniqueName="colQUOTED_HOURS">
                            <%--11--%>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FORECAST_HOURS" HeaderText="Hours Planned (ETF)" UniqueName="colFORECAST_HOURS">
                            <%--12--%>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="HOURS_ALLOWED" HeaderText="Hours Planned (Allowed)" UniqueName="colHOURS_ALLOWED">
                            <%--13--%>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ADJ_HOURS_ALLOWED" HeaderText="Hours Adjusted" UniqueName="colADJUSTED_HOURS">
                            <%--14--%>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ACTUAL_HOURS" HeaderText="Hours Actual" UniqueName="colACTUAL_HOURS">
                            <%--15--%>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="" HeaderText="% Complete (Adj)" UniqueName="colPERC_COMPLETE_ADJ">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="" HeaderText="% Complete (All)" UniqueName="colPERC_COMPLETE_ALL">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="JOB_NUMBER" HeaderText="Job" UniqueName="colJOB_NUMBER" Visible="false">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="JOB_COMPONENT_NBR" HeaderText="Comp" UniqueName="colJOB_COMPONENT_NBR" Visible="false">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="QUOTED_HRS_AMT" HeaderText="Dollars Quoted" UniqueName="colQUOTED_HRS_AMT">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FORECAST_HRS_AMT" HeaderText="Dollars Planned (ETF)" UniqueName="colFORECAST_HRS_AMT">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="HOURS_ALLOWED_AMT" HeaderText="Dollars Planned (Allowed)" UniqueName="colHOURS_ALLOWED_AMT">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ADJ_HOURS_ALLOWED_AMT" HeaderText="Dollars Adjusted" UniqueName="colADJUSTED_HOURS_AMT">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ACTUAL_HRS_AMT" HeaderText="Dollars Actual" UniqueName="colACTUAL_HRS_AMT">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="" HeaderText="% Complete (Adj)" UniqueName="colPERC_COMPLETE_ADJ_AMT">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="" HeaderText="% Complete (All)" UniqueName="colPERC_COMPLETE_ALL_AMT">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
    </div>
    
</asp:Content>
