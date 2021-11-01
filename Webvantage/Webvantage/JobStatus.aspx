<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="JobStatus.aspx.vb" Inherits="Webvantage.JobStatus" %>
<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
    <div class="telerik-aqua-body" style="margin-top: 5px!important;">
        <div class="card-container">
                <div id="DivDetailsCard" runat="server" class="card content-card">
                    <div style="margin-left: 7px !important;" class="card-content" style="margin-bottom: 20px;">
                        <asp:Literal ID="LiteralDetails" runat="server"></asp:Literal>
                    </div>
                    <div class="card-action-bar card-bottom-header card-bottom-header-bg" style="background-color: #DC3545 !important;">
                        <div class="card-bottom-header-text">
                            Details
                        </div>
                    </div>
                </div>
                <div id="DivPeopleCard" runat="server" class="card content-card">
                    <div style="margin-left: 7px !important;" class="card-content" style="margin-bottom: 20px;">
                        <asp:Literal ID="LiteralPeople" runat="server"></asp:Literal>
                    </div>
                    <div class="card-action-bar card-bottom-header card-bottom-header-bg" style="background-color: #FFC107 !important;">
                        <div class="card-bottom-header-text">
                            People
                        </div>
                    </div>
                </div>
                <div id="DivAlertsCard" runat="server" class="card content-card">
                    <div style="margin-left: 7px !important;" class="card-content" style="margin-bottom: 20px;">
                        <asp:Literal ID="LiteralAlerts" runat="server"></asp:Literal>
                    </div>
                    <div class="card-action-bar card-bottom-header card-bottom-header-bg" style="background-color: #FD7E14 !important;">
                        <div class="card-bottom-header-text">
                            Alerts
                        </div>
                    </div>
                </div>
                <div id="DivAssignmentCard" runat="server" class="card content-card">
                    <div style="margin-left: 7px !important;" class="card-content" style="margin-bottom: 20px;">
                        <asp:Literal ID="LiteralAssignments" runat="server"></asp:Literal>
                    </div>
                    <div class="card-action-bar card-bottom-header card-bottom-header-bg" style="background-color: #801A2D !important;">
                        <div class="card-bottom-header-text">
                            Assignments
                        </div>
                    </div>
                </div>
                <div id="DivScheduleCard" runat="server" class="card content-card">
                    <div style="margin-left: 7px !important;" class="card-content" style="margin-bottom: 20px;">
                        <asp:Literal ID="LiteralSchedule" runat="server"></asp:Literal>
                    </div>
                    <div class="card-action-bar card-bottom-header card-bottom-header-bg" style="background-color: #4D82B8 !important;">
                        <div class="card-bottom-header-text">
                            Schedule
                        </div>
                    </div>
                </div>
                <div id="DivTasksCard" runat="server" class="card content-card">
                    <div style="margin-left: 7px !important;" class="card-content" style="margin-bottom: 20px;">
                        <asp:Literal ID="LiteralTasks" runat="server"></asp:Literal>
                    </div>
                    <div class="card-action-bar card-bottom-header card-bottom-header-bg" style="background-color: #008080 !important;">
                        <div class="card-bottom-header-text">
                            Tasks
                        </div>
                    </div>
                </div>
                <div id="DivEstimateApprovalCard" runat="server" class="card content-card" style="margin-bottom: 20px;">
                    <div style="margin-left: 7px !important;" class="card-content">
                        <asp:Literal ID="LiteralEstimate" runat="server"></asp:Literal>
                    </div>
                    <div class="card-action-bar card-bottom-header card-bottom-header-bg" style="background-color: #826446 !important;">
                        <div class="card-bottom-header-text">
                            Estimate Approval
                        </div>
                    </div>
                </div>
                <div id="DivQvACard" runat="server" class="card content-card" style="margin-bottom: 20px;">
                    <div style="margin-left: 7px !important;" class="card-content">
                        <asp:Literal ID="LiteralQvA" runat="server"></asp:Literal>
                    </div>
                    <div class="card-action-bar card-bottom-header card-bottom-header-bg" style="background-color: #515151 !important;">
                        <div class="card-bottom-header-text">
                            QvA
                        </div>
                    </div>
                </div>
                <div id="DivBillingApprovalCard" runat="server" class="card content-card" style="margin-bottom: 20px;">
                    <div style="margin-left: 7px !important;" class="card-content">
                        <asp:Literal ID="LiteralBillingApproval" runat="server"></asp:Literal>
                    </div>
                    <div class="card-action-bar card-bottom-header card-bottom-header-bg" style="background-color: #5CB85C !important;">
                        <div class="card-bottom-header-text">
                            Billing Approval
                        </div>
                    </div>
                </div>
            </div>
    </div>
    
</asp:Content>
