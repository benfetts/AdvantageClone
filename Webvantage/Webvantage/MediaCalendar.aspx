<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="MediaCalendar.aspx.vb" Inherits="Webvantage.MediaCalendar" %>

<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <!-- This was added by JL it might not be the correct way to do it please provide feedback! ty -jl -->
    <telerik:RadScriptBlock ID="RadScriptBlock" runat="server">
        
        <script type="text/javascript">
            function RefreshPage(radWindowCaller) {
                setTimeout(function () {
                   __doPostBack('onclick#Refresh', 'Refresh');
                }, 0);                 
            };           

        </script>
        
    </telerik:RadScriptBlock>
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolBarMediaCalendar" runat="server" AutoPostBack="true"
            Width="100%">
            <Items>
    
                <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="Bookmark" Value="Bookmark" ToolTip="Bookmark" />
                <telerik:RadToolBarButton ID="RadToolbarButtonRefresh" runat="server" SkinID="RadToolBarButtonRefresh" Value="Refresh" ToolTip="Refresh" />

            </Items>
        </telerik:RadToolBar>
    </div>
        
    <div class="telerik-aqua-body" style="margin-top: 5px!important;">

             <telerik:RadTabStrip ID="RadTabStrip" runat="server" AutoPostBack="True" CausesValidation="False" Width="100%">
                    <Tabs>
                        <telerik:RadTab ID="Tab1" runat="server" Text="Root Tab">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPageCalendar" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="RadPageViewCalendar" runat="server">
                        <telerik:RadScheduler ID="RadSchedulerProjectMediaCalendar" runat="server" DataEndField="DISPLAY_END_DATE" DataStartField="DISPLAY_START_DATE"
                            DataKeyField="ID" DataSubjectField="ORDER_DESC" AppointmentStyleMode="Default" EnableAdvancedForm="true" Width="100%" ReadOnly="true"
                            OverflowBehavior="Expand" AllowDelete="False" Localization-HeaderMultiDay="Resource" EnableViewState="true"
                            StartInsertingInAdvancedForm="false" ExportSettings-OpenInNewWindow="True"
                            ToolTip='' TimeSlotContextMenuSettings-EnableEmbeddedSkins="False" ViewStateMode="Enabled">
                            <MultiDayView NumberOfDays="10" />
                            <TimelineView NumberOfSlots="14" ShowDateHeaders="True" ShowResourceHeaders="True" />
                            <MonthView VisibleAppointmentsPerDay="5" AdaptiveRowHeight="false" />
                            <AppointmentContextMenus>
                                <telerik:RadSchedulerContextMenu runat="server" ID="SchedulerAppointmentContextMenu">
                                    <Items>
                                        <telerik:RadMenuItem Text="View Details" Value="Edit" />
                                    </Items>
                                </telerik:RadSchedulerContextMenu>
                                <telerik:RadSchedulerContextMenu runat="server" ID="RadSchedulerContextMenuDocuments">
                                    <Items>
                                        <telerik:RadMenuItem Text="View Details" Value="Edit" />
                                        <telerik:RadMenuItem Text="Order Documents" Value="Docs" />
                                    </Items>
                                </telerik:RadSchedulerContextMenu>
                            </AppointmentContextMenus>
                            <AppointmentTemplate>
                                <div class="rsAptSubject">
                                    <div style="width: 80%"><%# Eval("Subject") %></div>
                                    <div id="divDocumentsMagazine" visible="false" runat="server" style="float:right; position:absolute;top:3px;right:10px;padding: 1px;" class='icon-background background-color-sidebar standard-light-green'>
                                        <span style="cursor: pointer; cursor: hand;">
                                            <asp:ImageButton runat="server" ID="ImageButtonDocuments"
                                                ImageUrl="~/Images/Icons/White/256/documents_empty.png"
                                                CommandName="Docs"
                                                CommandArgument=""
                                                CssClass="icon-image"/>
                                        </span>
                                    </div>
                                </div>
                            </AppointmentTemplate>
                            <ResourceHeaderTemplate>
                                <asp:Panel ID="ResourceImageWrapperType" runat="server" HorizontalAlign="center">
                                    <div style="width: 100%; text-align: center;">
                                        <asp:Label ID="LabelType" runat="server"></asp:Label>
                                    </div>
                                </asp:Panel>
                            </ResourceHeaderTemplate>
                            <ResourceStyles>
                                    <telerik:ResourceStyleMapping Type="Type" Text="M"
                                        BorderColor="#E2A62E" />
                                    <telerik:ResourceStyleMapping Type="Type" Text="N"
                                        BorderColor="#C96615" />
                                    <telerik:ResourceStyleMapping Type="Type" Text="I"
                                        BorderColor="#D63251" />
                                    <telerik:ResourceStyleMapping Type="Type" Text="O"
                                        BorderColor="#203850" />
                                    <telerik:ResourceStyleMapping Type="Type" Text="R"
                                        BorderColor="#00BCD4" />
                                    <telerik:ResourceStyleMapping Type="Type" Text="T"
                                        BorderColor="#4B7D70" />
                                </ResourceStyles>
                            <TimeSlotContextMenuSettings EnableDefault="false" />
                            <AppointmentContextMenuSettings EnableDefault="true" />
                            <ExportSettings OpenInNewWindow="True" FileName="SchedulerExport">
                                <Pdf PageTitle="Schedule" Author="Telerik" Creator="Telerik" Title="Schedule" />
                            </ExportSettings>
                        </telerik:RadScheduler>
                        <div style="width:100%;text-align:center;padding: 20px 0px 0px 0px;">
                            <div style="height:40px;width:140px;float:left;">
                                <div style="height: 30px; width: 30px; border-radius: 50%; display:inline-block;" class="media-magazine"></div>
                                <div style="display:inline-block;height:39px;vertical-align:middle;">Magazine</div>
                            </div>
                            <div style="height: 35px; width: 140px; float: left;">
                                <div style="height: 30px; width: 30px; border-radius: 50%; display: inline-block;" class="media-newspaper"></div>
                                <div style="display: inline-block; height: 39px; vertical-align: middle;">Newspaper</div>
                            </div>

                            <div style="height: 35px; width: 140px; float: left;">
                                <div style="height: 30px; width: 30px; border-radius: 50%; display: inline-block;" class="media-internet"></div>
                                <div style="display: inline-block; height: 39px; vertical-align: middle;">Internet</div>
                            </div>
                            <div style="height: 35px; width: 140px; float: left;">
                                <div style="height: 30px; width: 30px; border-radius: 50%; display: inline-block;" class="media-out-of-home"></div>
                                <div style="display: inline-block; height: 39px; vertical-align: middle;">Out Of Home</div>
                            </div>
                            <div style="height: 35px; width: 140px; float: left;">
                                <div style="height: 30px; width: 30px; border-radius: 50%; display: inline-block;" class="media-radio"></div>
                                <div style="display: inline-block; height: 39px; vertical-align: middle;">Radio</div>
                            </div>
                            <div style="height: 35px; width: 140px; float: left;">
                                <div style="height: 30px; width: 30px; border-radius: 50%; display: inline-block;" class="media-tv"></div>
                                <div style="display: inline-block; height: 39px; vertical-align: middle;">Television</div>
                            </div>

                        </div>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
</div>
   
</asp:Content>
