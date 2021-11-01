<%@ Page Title="Events Scheduler" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Scheduler_Events.aspx.vb" Inherits="Webvantage.Scheduler_Events" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="Resources.ascx" TagName="Resources" TagPrefix="uc1" %>
<%@ Register Src="Event_Type.ascx" TagName="EventType" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadWindowManager ID="RadWindowManagerEvents" runat="server" EnableViewState="false">
    </telerik:RadWindowManager>
    <style type="text/css">
        #row {
	        width:900px;
	        height:100%;
	        display:block;
        }
        .col-label {
	        float:left;
	        width:20%;
	        vertical-align:middle;
	        height:20px;
	        font-weight:bold;
        }
        .col-data {
	        float:left;
	        width:80%;
	        vertical-align:middle;
	        height:20px;
        }
    </style>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">

            function DataChangeAutoSaveComment(RowEventId, CommentString) {
                try {
                    PageMethods.AutoSaveComment(RowEventId, CommentString);
                    return false;
                }
                catch (err) {
                    ShowMessage(err);
                }
            }

        </script>
        <script type="text/javascript">

            function DataChangeAutoSaveTaskComment(RowEventTaskId, CommentString) {
                try {
                    PageMethods.AutoSaveTaskComment(RowEventTaskId, CommentString);
                    return false;
                }
                catch (err) {
                    ShowMessage(err);
                }
            }

        </script>
        <script type="text/javascript">

            function DataChangeAutoSaveTaskEmployee(RowEventTaskId, TbName, TbValue) {
                try {
                    PageMethods.AutoSaveTaskEmployee(RowEventTaskId, TbName, TbValue, SaveTaskEmployeeSucceeded, SaveTaskEmployeeFailed);
                    return false;
                }
                catch (err) {
                    ShowMessage(err);
                }

            }

            function SaveTaskEmployeeSucceeded(result, userContext, methodName) {
                try {
                    //$get('div1').innerHTML = result;
                    if (result != '') {
                        var str = "";
                        str = result
                        str = str.replace("##", '\n');
                        str = str.replace("##", '\n');
                        if (str.indexOf("[object") > -1) {
                        }
                        else {
                            ShowMessage(str);
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

            function SaveTaskEmployeeFailed(error, userContext, methodName) {
                try {
                    var str = '';
                    str = error;
                    if (str.indexOf("[object") > -1) {
                    }
                    else {
                        ShowMessage(str);
                    }
                    //return false;
                }
                catch (err) { }
            }

        </script>
        <script type="text/javascript">
            function InvalidStart(sender, args) {
                $find('<%= RadDatePickerStartDate.ClientID %>').clear();
            }
            function InvalidEnd(sender, args) {
                $find('<%= RadDatePickerEndDate.ClientID %>').clear();
            }
        </script>
    </telerik:RadScriptBlock>
    <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
        <script type="text/javascript">
            function JsOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();
                if (comandName == "DeleteEvents") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete selected event(s)?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete selected event(s)?");
                }
                else if (comandName == "CloseWindow") {
                    window.close();
                }
            }
        </script>
    </telerik:RadScriptBlock>
    <div >
        <telerik:RadToolBar ID="RadToolbarEventScheduler" runat="server" AutoPostBack="true"
            OnClientButtonClicking="JsOnClientButtonClicking" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton id="RadToolBarButtonStartDate">
                    <ItemTemplate>
                        Start Date:
                        <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server"
                            SkinID="RadDatePickerStandard">
                            <DateInput DateFormat="d" EmptyMessage="Start Date">
                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                            </DateInput>
                            <Calendar ID="CalendarStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                    </telerik:RadCalendarDay>
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton id="RadToolBarButtonEndDate">
                    <ItemTemplate>
                        End Date:
                        <telerik:RadDatePicker ID="RadDatePickerEndDate" runat="server"
                            SkinID="RadDatePickerStandard">
                            <DateInput DateFormat="d" EmptyMessage="End Date">
                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                            </DateInput>
                            <Calendar ID="CalendarEndDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                    </telerik:RadCalendarDay>
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton>
                    <ItemTemplate>
                        &nbsp;&nbsp;View By:&nbsp;
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton id="RadToolBarButtonViewByJobComponent" Text="Job Component"
                    ToolTip="View Events by Job Component" Value="ViewByJobComponent" Group="ViewBy"
                    CheckOnClick="true" Checked="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonViewbyDate" Text="Date" Value="ViewbyDate"
                    ToolTip="View Events by Date" Group="ViewBy" CheckOnClick="true" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonRefresh" SkinID="RadToolBarButtonRefresh" Value="Refresh" ToolTip="Refresh page / Apply filter" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div >
    </div>
    <div class="telerik-aqua-body">
        <ew:CollapsablePanel ID="CollapsablePanelFilter" runat="server" TitleText="Filter" Collapsed="true">
        <div class="code-description-container">
            <div class="code-description-label">
                Ad Number:
            </div>
            <div class="code-description-description">
                <telerik:RadComboBox ID="DropDownListAdNumbersFilter" runat="server" Visible="false"
                    AutoPostBack="true" AppendDataBoundItems="true">
                </telerik:RadComboBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Generator:
            </div>
            <div class="code-description-description">
                <telerik:RadComboBox ID="DropDownListEventGenerators" runat="server" AutoPostBack="true"
                    Width="450px" AppendDataBoundItems="true">
                </telerik:RadComboBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-description">
                <asp:CheckBox ID="CheckBoxOnlyEventsWithoutResource" runat="server" Text="Show only events without a resource"
                    AutoPostBack="true" />
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-description">
                <asp:CheckBox ID="CheckBoxShowAdNumberImage" runat="server" Text="Show Ad Number image"
                    AutoPostBack="true" Checked="true" />
            </div>
        </div>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelResourceFinder" runat="server" TitleText="Resource Finder">
        <div class="code-description-container">
            <div class="code-description-label">
                Resource Type:
            </div>
            <div class="code-description-description">
                <telerik:RadComboBox ID="DropDownListResourceType" runat="server" AppendDataBoundItems="true" Width="300"
                    AutoPostBack="true">
                </telerik:RadComboBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Ad Number:
            </div>
            <div class="code-description-description">
                <telerik:RadComboBox ID="DropDownListAdNumbers" runat="server" AppendDataBoundItems="true" Width="300"
                    Enabled="true" AutoPostBack="true">
                </telerik:RadComboBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-description">
                <asp:CheckBox ID="CheckBoxOverrideExistingResources" runat="server" Text="Override Existing Resources"
                    Checked="false" Visible="false" />
                <asp:CheckBox ID="CheckBoxDeleteAutomaticTasks" runat="server" Text="Delete Automatic Tasks"
                    Checked="true" />
            </div>
        </div>
        <asp:Button ID="ButtonResourcesFind" runat="server" Text="Find Resources" />
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelEventsGrid" runat="server" TitleText="Events">
        <asp:HiddenField ID="HiddenFieldCurrentRecord" runat="server" />
        <asp:HiddenField ID="HiddenFieldMoveDirection" runat="server" />
        <telerik:RadGrid ID="RadGridEventScheduler" runat="server" AllowFilteringByColumn="False"
            ShowHeader="false" ShowFooter="false" en GroupingEnabled="true" AllowSorting="True"
            AutoGenerateColumns="False" GridLines="None" ShowGroupPanel="False">
            <ClientSettings AllowDragToGroup="False">
                <Selecting AllowRowSelect="false" />
            </ClientSettings>
            <MasterTableView DataKeyNames="EVENT_ID" CommandItemDisplay="TopAndBottom" Width="100%">
                <CommandItemTemplate>
                    <table width="100%" border="0" cellspacing="" cellpadding="2">
                        <tr>
                            <td>
                                <asp:ImageButton ID="ImageButtonPrevious" runat="server" SkinID="ImageButtonPrevious"
                                    CommandName="PreviousRecord" ToolTip="Go to previous record" />
                                &nbsp;&nbsp;
                                <asp:Label ID="LabelCurrentRecordDisplay" runat="server" Text="Label"></asp:Label>
                                &nbsp;&nbsp;
                                <asp:ImageButton ID="ImageButtonNext" runat="server" SkinID="ImageButtonNext" CommandName="NextRecord" ToolTip="Go to next record" />
                            </td>
                        </tr>
                    </table>
                </CommandItemTemplate>
                <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                <RowIndicatorColumn>
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>
                <ExpandCollapseColumn>
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnEventInfo">
                        <ItemTemplate>
                            <table width="764" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="85">EVENT:
                                    </td>
                                    <td width="334">
                                        <%#Eval("EVENT_LABEL")%>
                                    </td>
                                    <td width="340" rowspan="7" align="left" valign="top">
                                        <uc1:Resources runat="server" ID="UcResources" ResourceCode='<%# Eval("RESOURCE_CODE")%>'
                                            EventId='<%# Eval("EVENT_ID")%>' HideLastUseRows="True" SaveOnResourceChange="True"
                                            ShowRefreshTaskGridButton="True" />
                                        <asp:HiddenField ID="HiddenFieldResourceCode" runat="server" Value='<%# Eval("EVENT_ID")%>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Date:
                                    </td>
                                    <td>
                                        <%#CType(Eval("EVENT_DATE"), Date).ToLongDateString()%>
                                        &nbsp;&nbsp;<%# CType(Eval("START_TIME"), Date).ToShortTimeString()%>&nbsp;-&nbsp;<%# CType(Eval("END_TIME"), Date).ToShortTimeString()%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Job:
                                    </td>
                                    <td>
                                        <%# Eval("JOB_NUMBER").ToString().PadLeft(6, "0")%>/<%# Eval("JOB_COMPONENT_NBR").ToString().PadLeft(2, "0")%>
                                        -
                                        <%# Eval("JOB_COMP_DESC")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Hours:
                                    </td>
                                    <td>
                                        <%# Eval("QTY_HRS")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Ad Number:
                                    </td>
                                    <td>
                                        <%# Eval("AD_NBR")%>&nbsp;-&nbsp;<%# Eval("AD_NBR_DESC")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">Comment:
                                    </td>
                                    <td align="left" valign="top">
                                        <asp:TextBox ID="TxtEVENT_DESC_LONG" runat="server" Height="30px" Text='<%# Eval("EVENT_DESC_LONG")%>' SkinID="TextBoxStandard"
                                            TextMode="MultiLine" Width="370px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">Event Type:
                                    </td>
                                    <td align="left" valign="top">
                                        <uc1:EventType runat="server" ID="UcEventType" AutoPostBack="true" EventId='<%# Eval("EVENT_ID")%>'
                                            SaveOnChange="true" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnThumbNail" Display="True"
                        Visible="True">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="20px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" />
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" Width="20px" />
                        <ItemTemplate>
                            <asp:Image ID="ImageThumbnail" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/spacer.gif" />
                            <div style="background-color: <%#Eval("AD_NBR_COLOR")%>; height: 5px; width: 100%">
                            </div>
                            <asp:HiddenField ID="HfDocumentId" runat="server" Value='<%#Eval("DOCUMENT_ID")%>' />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <DetailTables>
                    <telerik:GridTableView Name="EventTasks" AllowSorting="True" AutoGenerateColumns="false"
                        Visible="True" Caption="" DataKeyNames="EVENT_TASK_ID" HorizontalAlign="right"
                        Width="100%" ShowHeader="false" NoDetailRecordsText="No Records to Display" ShowHeadersWhenNoRecords="false">
                        <Columns>
                            <telerik:GridTemplateColumn DataField="" Display="True" HeaderText="" UniqueName="GridTemplateColumnTaskInfo">
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="bottom" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                <FooterStyle HorizontalAlign="left" VerticalAlign="middle" />
                                <ItemTemplate>
                                    <table width="404" border="0" align="right" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="70">Task Code:
                                            </td>
                                            <td width="327">
                                                <%# Eval("TASK_CODE")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Date:
                                            </td>
                                            <td>
                                                <%# CType(Eval("EVENT_TASK_DATE"), Date).ToLongDateString()%>
                                                &nbsp;&nbsp;<%# CType(Eval("START_TIME"), Date).ToShortTimeString()%>&nbsp;-&nbsp;<%# CType(Eval("END_TIME"), Date).ToShortTimeString()%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Hours:
                                            </td>
                                            <td>
                                                <%# Eval("HOURS_ALLOWED")%>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="" UniqueName="GridTemplateColumnTaskEditableInfo">
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <div class="code-description-container">
                                        <div class="code-description-label">
                                            Employee:
                                        </div>
                                        <div class="code-description-code">
                                            <asp:TextBox ID="TxtEMP_CODE" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall" Text='<%# Eval("EMP_CODE") %>'></asp:TextBox>
                                            <asp:HiddenField ID="HfEMP_CODE" runat="server" Value='<%# Eval("EMP_CODE") %>' />
                                        </div>
                                    </div>
                                    <div class="code-description-container">
                                        <div class="code-description-label">
                                            Comment:
                                        </div>
                                        <div class="code-description-description">
                                            <asp:TextBox ID="TxtTaskCOMMENTS" runat="server" Height="30px" Text='<%# Eval("COMMENTS")%>' SkinID="TextBoxStandard"
                                                TextMode="MultiLine" Width="370px"></asp:TextBox>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </telerik:GridTableView>
                </DetailTables>
            </MasterTableView>
            <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
            </HeaderContextMenu>
        </telerik:RadGrid>
    </ew:CollapsablePanel>
    </div>
    
</asp:Content>
