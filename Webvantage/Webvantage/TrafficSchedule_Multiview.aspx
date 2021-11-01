<%@ Page AutoEventWireup="false" CodeBehind="TrafficSchedule_Multiview.aspx.vb" Inherits="Webvantage.TrafficSchedule_Multiview" Language="vb" MasterPageFile="~/ChildPage.Master" Title="Project Schedule - Multi View" ValidateRequest="false" %>

<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
        <style type="text/css">
            div.RadGrid {
                overflow: auto;
            }
        </style>
        <script type="text/javascript">
            function RowClick(index) {
                return false;
            }

            function JsOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();

                if (comandName == "DeleteRows") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                }
                if (comandName == "Calculate") {
                    ////args.set_cancel(!confirm('Are you sure you want to Calculate Due Dates on all checked schedules?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to Calculate Due Dates on all checked schedules?");
                }
                if (comandName == "ApplyTeam") {
                    ////args.set_cancel(!confirm('Are you sure you want to Apply Team members to all checked schedules?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to Apply Team members to all checked schedules?");
                }
                if (comandName == "MarkTempComplete") {
                    ////args.set_cancel(!confirm('Are you sure you want to change all tasks marked Temp Complete to Completed on on all checked schedules?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to change all tasks marked Temp Complete to Completed on on all checked schedules?");
                }
                if (comandName == "CalculateDates") {
                    ////args.set_cancel(!confirm('All jobs associated with this job will be calculated.  Are you sure you want to Calculate Due Dates on all checked schedules?'));
                    radToolBarConfirm(sender, args, "All jobs associated with this job will be calculated.  Are you sure you want to Calculate Due Dates on all checked schedules?");
                }
                if (comandName == "NoPostBack") {
                    args.set_cancel(true);
                };
            }
            function DataChangeScheduleHeader(ThisDataKey, FieldName, ControlValue, ControlClientId) {
                try {

                    //alert(ThisDataKey);
                    //alert(FieldName);
                    //alert(ControlValue);
                    //alert(ControlClientId);
                    
                    PageMethods.AutoSaveScheduleHeader(ThisDataKey, FieldName, ControlValue, ControlClientId, DataChangeScheduleHeaderSucceeded, DataChangeScheduleHeaderFailed);

                }
                catch (err) { }
            }
            function DataChangeScheduleHeaderSucceeded(result, userContext, methodName) {
                try {
                    //alert(result);
                    if (result != "") {
                        //alert("hi")
                        var str = "";
                        str = result
                        str = str.replace("##", '\n');
                        str = str.replace("##", '\n');
                        if (str.indexOf("[object") > -1) {
                        }
                        else if (str.indexOf("STATUS_UPDATE|") > -1) {
                            var ar = new Array();
                            ar = str.split("|");
                            //alert(ar[1]);
                            //document.getElementById("ctl00_ContentPlaceHolderMain_TxtTrafficStatusDescription").value = ar[1];
                        }
                        else if (str.indexOf("ERROR|") > -1) {
                            var ar = new Array();
                            ar = str.split("|");
                            ShowMessage(ar[1]);
                        }
                        else {
                            //alert(str);
                        }
                        return false;
                    }
                    else {
                        return true;
                    }
                    return false;
                }
                catch (err) { }
            }
            function DataChangeScheduleHeaderFailed(error, userContext, methodName) {
                try {
                    var str = '';
                    str = error;
                    if (str.indexOf("[object") > -1) {
                    }
                    else {
                        radalert(str);
                    }
                }
                catch (err) { }
            }
            function checkSelectAll() {
                var checked = $('th > input[id*="ColClientSelectSelectCheckBox"]').is(":checked");
                var toolbar = $find('<%=RadToolbarSchedule.ClientID %>');
                toolbar.findItemByValue('RadToolBarButtonFindAndReplace').set_enabled(checked);
            }
            $('body').on('change', 'input[id*="ColClientSelectSelectCheckBox"]', function () {
                checkSelectAll();
            });
            $(document).ready(function () {
                checkSelectAll();
            });
        </script>
    </telerik:RadScriptBlock>
    <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
        <telerik:RadToolBar ID="RadToolbarSchedule" runat="server" AutoPostBack="True" Width="100%"
            OnClientButtonClicking="JsOnClientButtonClicking">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Visible="false"
                    Text="" Value="SaveAll" ToolTip="Save" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonFind"
                    Text="" Value="Search" ToolTip="Search" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <%--<telerik:RadToolBarButton  Text="Update Status" Value="UpdateStatus" ToolTip="Update Status of checked Schedules" />--%>
                <telerik:RadToolBarButton Value="RadToolBarButtonUpdateStatus" Text="Update Status" CommandName="NoPostBack">
                    </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true" />
                <%--<telerik:RadToolBarButton  Text="Calculate" Value="CalculateDates" CommandName="CalculateDates" ToolTip="Calculate due dates" />--%>
                <telerik:RadToolBarButton Value="RadToolBarButtonCalculate" Text="Calculate" CommandName="NoPostBack">
                    </telerik:RadToolBarButton>
                <%--<telerik:RadToolBarButton  Text="Team" Value="ApplyTeam" CommandName="ApplyTeam" ToolTip="Apply team" />--%>
                <telerik:RadToolBarButton Value="RadToolBarButtonTeam" Text="Team" CommandName="NoPostBack">
                    </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Value="RadToolBarButtonApplyTeamType" EnableViewState="true">
                    <ItemTemplate>
                        <telerik:RadComboBox ID="DropApplyTeamType" runat="server" EnableViewState="true">
                            <Items>
                                <telerik:RadComboBoxItem Text="Function" Value="function"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Text="Role" Value="role"></telerik:RadComboBoxItem>
                            </Items>
                        </telerik:RadComboBox>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <%--<telerik:RadToolBarButton  Text="Temp Complete" Value="MarkTempComplete" CommandName="MarkTempComplete" ToolTip="Mark temp complete" />--%>
                <telerik:RadToolBarButton Value="RadToolBarButtonMarkTempComplete" Text="Temp Complete" CommandName="NoPostBack">
                    </telerik:RadToolBarButton>
                <%--<telerik:RadToolBarButton  Text="Replace" Value="FindAndReplace" Enabled="True" ToolTip="Search and replace selected task items on current page" />
                <telerik:RadToolBarButton  Text="Replace All" Value="FindAndReplaceAll" Enabled="True" ToolTip="Search and replace all task items" />--%>
                <telerik:RadToolBarButton Value="RadToolBarButtonFindAndReplace" Text="Replace" CommandName="NoPostBack">
                    </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Visible="false" Text="Grid" Value="ViewSingle" ToolTip="View Grid" />
                <telerik:RadToolBarButton Text="Multi" Value="ViewMulti" Enabled="false" ToolTip="View multiple schedules" />
                <telerik:RadToolBarButton Visible="false" Text="Worksheet" Value="ViewWorksheet" ToolTip="View as worksheet" />
                <%--<telerik:RadToolBarButton Text="Gantt" Value="GanttView" ToolTip="View Gantt" />--%>
                <telerik:RadToolBarButton Value="RadToolBarButtonGantt" Text="Gantt" CommandName="NoPostBack">
                    </telerik:RadToolBarButton>
                <%--<telerik:RadToolBarButton Text="Calendar" Value="Calendar" ToolTip="View Calendar" />--%>
                <telerik:RadToolBarButton Value="RadToolBarButtonCalendar" Text="Calendar" CommandName="NoPostBack">
                    </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Find overbooked employees" Value="CheckWorkload" ToolTip="Find overbooked employees" Visible="False" />
                <%--<telerik:RadToolBarButton Text="Risk Analysis" Value="Summary" ToolTip="Risk Analysis" />--%>
                <telerik:RadToolBarButton Value="RadToolBarButtonRiskAnalysis" Text="Risk Analysis" CommandName="NoPostBack">
                    </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true" />

                <telerik:RadToolBarButton SkinID="RadToolBarButtonPrint" Text="" Value="Print" ToolTip="Print" CommandName="Print" />                
                <telerik:RadToolBarButton SkinID="RadToolBarButtonSettings" Value="PrintSendOptions" ToolTip="Print Options" CommandName="PrintSendOptions" />

                <telerik:RadToolBarButton IsSeparator="true" />

                <telerik:RadToolBarButton ImageUrl="Images/selection_down.png" Text="Expand All" Value="ExpandAll" Checked="false" AllowSelfUnCheck="true" CheckOnClick="true" ToolTip="Expand all tasks on refresh" Visible="false" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh" ToolTip="Refresh" />
                <telerik:RadToolBarButton SkinId="RadToolBarButtonBookmark" Text="" Value="Bookmark"
                    ToolTip="Bookmark" Visible="false" />
                <telerik:RadToolBarButton IsSeparator="true" />

            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
        <telerik:RadToolTip ID="RadToolTipUpdateStatus" runat="server" SkinID="RadToolTipToolbarContentArea" Width="290" Height="110" TargetControlID="RadToolBarButtonUpdateStatus" OffsetY="20">
            <div style="width: 275px; float: left; position: relative;">
                <div>
                    <div style="padding: 11px 0px 0px 0px;">
                        <asp:Button ID="ButtonUpdateStatusSelected" runat="server" Text="Update Selected" ToolTip="" Width="250" />
                    </div>
                    <div style="padding: 6px 0px 0px 0px;">
                        <asp:Button ID="ButtonUpdateStatusAll" runat="server" Text="Update All" ToolTip="" Width="250" />
                    </div>
                </div>
            </div>
        </telerik:RadToolTip>
        <telerik:RadToolTip ID="RadToolTipCalculate" runat="server" SkinID="RadToolTipToolbarContentArea" Width="290" Height="110" TargetControlID="RadToolBarButtonCalculate" OffsetY="20">
            <div style="width: 275px; float: left; position: relative;">
                <div>
                    <div style="padding: 11px 0px 0px 0px;">
                        <asp:Button ID="ButtonCalculateSelected" runat="server" Text="Calculate Selected" ToolTip="" Width="250" CommandName="CalculateDates" OnClientClick="JsOnClientButtonClicking" />
                    </div>
                    <div style="padding: 6px 0px 0px 0px;">
                        <asp:Button ID="ButtonCalculateAll" runat="server" Text="Calculate All" ToolTip="" Width="250" CommandName="CalculateDates" OnClientClick="JsOnClientButtonClicking" />
                    </div>
                </div>
            </div>
        </telerik:RadToolTip>
        <telerik:RadToolTip ID="RadToolTipTeam" runat="server" SkinID="RadToolTipToolbarContentArea" Width="290" Height="110" TargetControlID="RadToolBarButtonTeam" OffsetY="20">
            <div style="width: 275px; float: left; position: relative;">
                <div>
                    <div style="padding: 11px 0px 0px 0px;">
                        <asp:Button ID="ButtonApplyTeamSelected" runat="server" Text="Apply Team Selected" ToolTip="" Width="250" CommandName="ApplyTeam" />
                    </div>
                    <div style="padding: 6px 0px 0px 0px;">
                        <asp:Button ID="ButtonApplyTeamAll" runat="server" Text="Apply Team All" ToolTip="" Width="250" CommandName="ApplyTeam" />
                    </div>
                </div>
            </div>
        </telerik:RadToolTip>
        <telerik:RadToolTip ID="RadToolTipTempComplete" runat="server" SkinID="RadToolTipToolbarContentArea" Width="290" Height="110" TargetControlID="RadToolBarButtonMarkTempComplete" OffsetY="20">
            <div style="width: 275px; float: left; position: relative;">
                <div>
                    <div style="padding: 11px 0px 0px 0px;">
                        <asp:Button ID="ButtonTempCompleteSelected" runat="server" Text="Mark Temp Complete Selected" ToolTip="" Width="250" CommandName="MarkTempComplete" />
                    </div>
                    <div style="padding: 6px 0px 0px 0px;">
                        <asp:Button ID="ButtonTempCompleteAll" runat="server" Text="Mark Temp Complete All" ToolTip="" Width="250" CommandName="MarkTempComplete" />
                    </div>
                </div>
            </div>
        </telerik:RadToolTip>
        <telerik:RadToolTip ID="RadToolTipReplace" runat="server" SkinID="RadToolTipToolbarContentArea" Width="290" Height="110" TargetControlID="RadToolBarButtonFindAndReplace" OffsetY="20">
            <div style="width: 275px; float: left; position: relative;">
                <div>
                    <div style="padding: 11px 0px 0px 0px;">
                        <asp:Button ID="ButtonReplaceSelected" runat="server" Text="Replace Selected" ToolTip="" Width="250" />
                    </div>
                    <div style="padding: 6px 0px 0px 0px;">
                        <asp:Button ID="ButtonReplaceAll" runat="server" Text="Replace All" ToolTip="" Width="250" />
                    </div>
                </div>
            </div>
        </telerik:RadToolTip>
        <telerik:RadToolTip ID="RadToolTipGantt" runat="server" SkinID="RadToolTipToolbarContentArea" Width="290" Height="110" TargetControlID="RadToolBarButtonGantt" OffsetY="20">
            <div style="width: 275px; float: left; position: relative;">
                <div>
                    <div style="padding: 11px 0px 0px 0px;">
                        <asp:Button ID="ButtonGanttSelected" runat="server" Text="Gantt for Selected" ToolTip="" Width="250" />
                    </div>
                    <div style="padding: 6px 0px 0px 0px;">
                        <asp:Button ID="ButtonGanttAll" runat="server" Text="Gantt for All" ToolTip="" Width="250" />
                    </div>
                </div>
            </div>
        </telerik:RadToolTip>
        <telerik:RadToolTip ID="RadToolTipCalendar" runat="server" SkinID="RadToolTipToolbarContentArea" Width="290" Height="110" TargetControlID="RadToolBarButtonCalendar" OffsetY="20">
            <div style="width: 275px; float: left; position: relative;">
                <div>
                    <div style="padding: 11px 0px 0px 0px;">
                        <asp:Button ID="ButtonCalendarSelected" runat="server" Text="Calendar for Selected" ToolTip="" Width="250" />
                    </div>
                    <div style="padding: 6px 0px 0px 0px;">
                        <asp:Button ID="ButtonCalendarAll" runat="server" Text="Calendar for All" ToolTip="" Width="250" />
                    </div>
                </div>
            </div>
        </telerik:RadToolTip>
        <telerik:RadToolTip ID="RadToolTipRiskAnalysis" runat="server" SkinID="RadToolTipToolbarContentArea" Width="290" Height="110" TargetControlID="RadToolBarButtonRiskAnalysis" OffsetY="20">
            <div style="width: 275px; float: left; position: relative;">
                <div>
                    <div style="padding: 11px 0px 0px 0px;">
                        <asp:Button ID="ButtonRiskAnalysisSelected" runat="server" Text="Risk Analysis for Selected" ToolTip="" Width="250" />
                    </div>
                    <div style="padding: 6px 0px 0px 0px;">
                        <asp:Button ID="ButtonRiskAnalysisAll" runat="server" Text="Risk Analysis for All" ToolTip="" Width="250" />
                    </div>
                </div>
            </div>
        </telerik:RadToolTip>
        <telerik:RadGrid ID="RadGridProjectScheduleMultiview" runat="server" AllowMultiRowEdit="False" AllowMultiRowSelection="True"
            AllowSorting="true" EnableEmbeddedSkins="True" AutoGenerateColumns="False" AllowPaging="true"
            PageSize="10" EnableAJAX="true" GridLines="None" Width="100%" >
            <PagerStyle Mode="NextPrevNumericAndAdvanced" AlwaysVisible="true" Position="Bottom"></PagerStyle>
            <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
            <ClientSettings AllowColumnHide="True">
                <Scrolling UseStaticHeaders="False" />
                <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
                <ClientEvents OnRowClick="RowClick" OnDataBound="checkSelectAll" />
            </ClientSettings>
            <MasterTableView DataKeyNames="JOB_NUMBER,JOB_COMPONENT_NBR,CL_CODE,DIV_CODE,PRD_CODE" HierarchyLoadMode="ServerOnDemand"
                HorizontalAlign="right" Width="100%">
                <Columns>
                    <telerik:GridClientSelectColumn UniqueName="ColClientSelect">
                    </telerik:GridClientSelectColumn>
                    <telerik:GridTemplateColumn UniqueName="colDetails">
                        <HeaderStyle CssClass="radgrid-icon-column" />
                        <ItemStyle CssClass="radgrid-icon-column" />
                        <FooterStyle CssClass="radgrid-icon-column" />
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="icon-background background-color-sidebar">
                                <div class="icon-background background-color-sidebar">
                                    <asp:LinkButton ID="LinkButtonSchedule" runat="server" CssClass="icon-text" CommandName="SingleView" ToolTip="Go to schedule">P</asp:LinkButton>
                                </div>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Cli/Div/Prod" UniqueName="ColCDP" SortExpression="CDP">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Label ID="LabelCDP" runat="server" Text='' Width="100px"></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Job/Comp" UniqueName="ColJobAndComp" SortExpression="JOB_AND_COMP">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:Label ID="LabelJC" runat="server" Text='' Width="200px"></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Status" UniqueName="ColTRF" SortExpression="TRF_CODE">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <telerik:RadComboBox ID="DropStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropStatus_SelectedIndexChanged" InputCssClass="no-border">
                            </telerik:RadComboBox>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="EMP_CODE_AE" HeaderText="AE" UniqueName="ColEMP_CODE_AE"
                        SortExpression="EMP_CODE_AE">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn HeaderText="Start" UniqueName="ColSTART_DATE" SortExpression="START_DATE">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <telerik:RadDatePicker ID="RadDatePickerSTART_DATE" runat="server"  AutoPostBack="false" SkinID="RadDatePickerStandard">
                                <DateInput DateFormat="d" EmptyMessage="">
                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                </DateInput>
                            </telerik:RadDatePicker>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Due" UniqueName="ColJOB_FIRST_USE_DATE" SortExpression="JOB_FIRST_USE_DATE">
                        <HeaderStyle HorizontalAlign="right" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <telerik:RadDatePicker ID="RadDatePickerJOB_FIRST_USE_DATE" runat="server"  AutoPostBack="false" SkinID="RadDatePickerStandard">
                                <DateInput DateFormat="d" EmptyMessage="">
                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                </DateInput>
                            </telerik:RadDatePicker>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Completed" UniqueName="ColJobCompleted" SortExpression="JobCompleted">
                        <HeaderStyle HorizontalAlign="right" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <telerik:RadDatePicker ID="RadDatePickerJobCompleted" runat="server"  AutoPostBack="false" SkinID="RadDatePickerStandard">
                                <DateInput DateFormat="d" EmptyMessage="">
                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                </DateInput>
                            </telerik:RadDatePicker>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Gut Percent Complete" UniqueName="ColPercentComplete"
                        SortExpression="GUT_PERCENT_COMPLETE">
                        <HeaderStyle HorizontalAlign="right" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:TextBox ID="TxtPercentComplete" Style="text-align: right; min-width: 68px; width: 68px;"
                                runat="server" TabIndex="0" Text='<%# Eval("GUT_PERCENT_COMPLETE") %>'></asp:TextBox>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Comments" UniqueName="ColComments">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:TextBox ID="TxtComments" runat="server" Height="30px" TabIndex="0" Text='<%# Eval("Comments") %>'
                                TextMode="MultiLine" Width="510px"></asp:TextBox>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="CL_CODE" HeaderText="" UniqueName="ColCL_CODE"
                        Visible="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DIV_CODE" HeaderText="" UniqueName="ColDIV_CODE"
                        Visible="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PRD_CODE" HeaderText="" UniqueName="ColPRD_CODE"
                        Visible="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JOB_NUMBER" HeaderText="" UniqueName="ColJOB_NUMBER"
                        Visible="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JOB_DESC" HeaderText="" UniqueName="ColJOB_DESC"
                        Visible="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JOB_COMPONENT_NBR" HeaderText="" UniqueName="ColJOB_COMPONENT_NBR"
                        Visible="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JOB_COMP_DESC" HeaderText="" UniqueName="ColJOB_COMP_DESC"
                        Visible="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="IS_TEMPLATE" HeaderText="" UniqueName="ColIS_TEMPLATE"
                        Visible="false">
                    </telerik:GridBoundColumn>
                </Columns>
                <ExpandCollapseColumn Resizable="False" Visible="False">
                    <HeaderStyle Width="20px" />
                </ExpandCollapseColumn>
                <RowIndicatorColumn Visible="False">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
            </MasterTableView>
        </telerik:RadGrid>
        <asp:HiddenField ID="HfExpandedItems" runat="server" />
        <asp:HiddenField ID="HfSingleExpandedItemIndex" runat="server" />
        <asp:HiddenField ID="HfSingleCollapsedItemIndex" runat="server" />
        <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
    </div>

</asp:Content>
