<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopCardsMySummary.ascx.vb" Inherits="Webvantage.DesktopCardsMySummary" EnableViewState="false" %>
<div>
    <style>
        .card-edge {
            border-bottom: 4px solid #808080 !important;
        }
    </style>
    <div style="display: none !important;">
        <asp:ImageButton ID="ImageButtonRefreshDesktopCardsMySummary" runat="server" ImageAlign="AbsMiddle" SkinID="ImageButtonRefresh" ToolTip="Refresh" />
    </div>
    <div class="my-summary-header dark-highlight-bg">
        <div id="user_picture" style="float: left; cursor: pointer;" onclick="OpenRadWindow('','MySettings.aspx');">
            <dx:ASPxBinaryImage ID="ASPxBinaryImageEmp" runat="server" CssClass="wv-employee-img-thumbnail-xxlg" BinaryStorageMode="Session"
                EmptyImage-Url="~/Images/Icons/White/256/user.png">
            </dx:ASPxBinaryImage>
        </div>
        <div id="DivWelcomeText" runat="server" style="float: right; text-align: right;display:none;">
            <div style="font-size: 18px; cursor: pointer;">
                <asp:Literal ID="LiteralEmployeeName" runat="server"></asp:Literal>
            </div>
            <div style="font-size: 12px;">
                <asp:LinkButton ID="LinkButtonLastUpdated" runat="server" ToolTip="Click to refresh"></asp:LinkButton>
            </div>
        </div>
    </div>
    <div style="overflow: hidden; height: 66px;" class="background-color-sidebar bottom-shadow">
        <div style="text-align:center; padding: 14px 20px 0px 0px;">
            <a id="LinkUserSchedulePanelMySummaryCard" href="#DivUserSchedule">
                <div runat="server" id="DivDate">
                    <asp:Literal ID="LiteralDate" runat="server"></asp:Literal>
                </div>
            </a>
        </div>
    </div>
    <div class="card-container">
        <asp:Panel ID="PanelAssignments" runat="server">
            <div class="card card-edge" style="cursor: pointer; min-height: 0px !important;">
                <div class="card-content">
                    <div>
                        High Priority: 
                            <asp:Label ID="LabelHighPriorityAssignments" runat="server" Text=""></asp:Label>
                    </div>

                    <div>
                        Due Today:
                            <asp:Label ID="LabelAssignmentsDueToday" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        Overdue:
                            <asp:Label ID="LabelOverDueAssignments" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div style="text-align: right; padding-right: 4px; padding-bottom: 2px; font-weight: bold;">
                    <asp:Label ID="LabelAssignments" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="PanelAlerts" runat="server">
            <div class="card card-edge" style="cursor: pointer; min-height: 0px !important;">
                <div class="card-content">
                    <div>
                        High Priority: 
                        <asp:Label ID="LabelHighPriorityAlerts" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        Due Today:
                    <asp:Label ID="LabelAlertsDueToday" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        Overdue:
                        <asp:Label ID="LabelOverDueAlerts" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div style="text-align: right; padding-right: 4px; padding-bottom: 2px; font-weight: bold;">
                    <asp:Label ID="LabelAlerts" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="PanelTasks" runat="server">
            <div class="card card-edge" style="cursor: pointer; min-height: 0px !important;">
                <div class="card-content">
                    <div>
                        High Priority: 
                        <asp:Label ID="LabelHighPriorityTasks" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        Due Today:
                        <asp:Label ID="LabelTasksDueToday" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        Overdue:
                        <asp:Label ID="LabelOverDueTasks" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div style="text-align: right; padding-right: 4px; padding-bottom: 2px; font-weight: bold;">
                    <asp:Label ID="LabelTasks" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </asp:Panel>
    </div>
</div>
