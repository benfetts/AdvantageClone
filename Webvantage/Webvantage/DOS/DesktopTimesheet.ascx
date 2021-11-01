<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopTimesheet.ascx.vb"
    Inherits="Webvantage.DesktopTimesheet" %>
<div class="DO-ButtonHeader" style="margin-bottom: 35px;">
    <div style="float: left; text-align: left; vertical-align: middle; display: inline-block;width:48%;">
        <div id="DivTimeWarnings" runat="server" style="display:inline-block;">
            <div id="DivMissingTime" runat="server" class="time-warning-icon-background standard-red" style="">
                <asp:ImageButton ID="ImageButtonMissingTime" runat="server" CausesValidation="false" ImageUrl="~/Images/Icons/White/256/sign_warning.png" CssClass="time-warning-icon-image" />
            </div>
        </div>
        <div style="display: inline-block;">
            <a href="#" onclick="Javascript:window.open('dtp_timesheet.aspx', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=435,height=400,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">
                <asp:Image ID="butPrint" runat="server" SkinID="ImagePrint" />
            </a>
        </div>
   </div>
    <div style="float: right; text-align: right; display: inline-block;width:48%;">
            <asp:ImageButton ID="ImageButtonNew" runat="server" ImageAlign="AbsMiddle" SkinID="ImageButtonNew"
                ToolTip="New Timesheet Entry" />
            <asp:ImageButton ID="ImageButtonSearch" runat="server" SkinID="ImageButtonFind"
                OnClientClick="OpenRadWindow('', 'Timesheet_Search.aspx', 0, 0, false); return false;"
                ToolTip="Search" />
            <asp:ImageButton ID="butRefresh" runat="server" ImageAlign="AbsMiddle" SkinID="ImageButtonRefresh" ToolTip="Refresh" />
    </div>
</div>
<div class="DO-Container">
    <telerik:RadGrid ID="TimeSheetRadGrid" runat="server" ShowFooter="true" AutoGenerateColumns="False"
        GridLines="None" EnableEmbeddedSkins="True">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="DayDisplay">
            <RowIndicatorColumn Visible="False">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn Resizable="False" Visible="False">
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridTemplateColumn DataField="DayDisplay" DataType="System.DateTime" HeaderText="Day"
                    UniqueName="ColDayDisplay">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonDayDisplay" runat="server" Text='<%# CType(Eval("DayDisplay"),Date).ToLongDateString() %>'
                            CommandName="OpenTimesheetDay" CommandArgument='<%# CType(Eval("DayDisplay"),Date).ToShortDateString() %>'></asp:LinkButton>
                        <asp:ImageButton ID="ImageButtonStopwatch" runat="server" SkinID="RadToolBarButtonStopwatchStop" CommandName="StopStopwatch" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <div style="width: 100%; margin: 0 auto; font-weight: bold;">
                            <div style="width: 50%; float: left; text-align: left;">
                                <asp:LinkButton ID="LinkButtonDayDisplayWeek" runat="server" Text="View entire week"
                                    CommandName="OpenTimesheetWeek"></asp:LinkButton>
                            </div>
                            <div style="width: 50%; float: right; text-align: right;">
                                Total:
                            </div>
                        </div>
                    </FooterTemplate>
                    <HeaderStyle HorizontalAlign="left" Width="85%" />
                    <ItemStyle HorizontalAlign="left" Width="85%" />
                    <FooterStyle HorizontalAlign="right" Width="85%" />
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="Hours" DataType="System.Decimal" HeaderText="Hours"
                    ReadOnly="True" SortExpression="Hours" UniqueName="ColHours">
                    <HeaderStyle HorizontalAlign="right" Width="15%" />
                    <ItemStyle HorizontalAlign="right" Width="15%" />
                    <FooterStyle HorizontalAlign="right" Width="15%" Font-Bold="true" />
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</div>