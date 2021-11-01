<%@ Page Title="Event Tasks Scheduler" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Scheduler_EventTasks.aspx.vb" Inherits="Webvantage.Scheduler_EventTasks" %>

<%@ Register Src="Event_Type.ascx" TagName="EventType" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
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

            function DataChangeAutoSaveTaskEmployee(RowEventTaskId, TbName, TbValue) {
                try {
                    //alert(TbValue);
                    PageMethods.AutoSaveTaskEmployee(RowEventTaskId, TbName, TbValue, SaveTaskEmployeeSucceeded, SaveTaskEmployeeFailed);
                    return false;
                }
                catch (err) {
                    //radalert(err);
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

            function DataChangeAutoSaveComment(RowEventId, CommentString) {
                try {
                    PageMethods.AutoSaveComment(RowEventId, CommentString);
                    return false;
                }
                catch (err) {
                    //alert(err);
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
                    //alert(err);
                }
            }

        </script>
    </telerik:RadScriptBlock>
    <div >
        <telerik:RadToolBar ID="RadToolbarEventTasksScheduler" runat="server" AutoPostBack="true"
            Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton>
                    <ItemTemplate>
                        Start Date:
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton id="RadToolBarButtonStartDate">
                    <ItemTemplate>
                        <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" 
                            AutoPostBack="true"  SkinID="RadDatePickerStandard" >
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
                <telerik:RadToolBarButton>
                    <ItemTemplate>
                        End Date:
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton id="RadToolBarButtonEndDate">
                    <ItemTemplate>
                        <telerik:RadDatePicker ID="RadDatePickerEndDate" runat="server" AutoPostBack="true" SkinID="RadDatePickerStandard">
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
                <telerik:RadToolBarButton IsSeparator="true" Visible="false" />
                <telerik:RadToolBarButton Visible="false">
                    <ItemTemplate>
                        Role:
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton id="RadToolBarButtonRole" Visible="false">
                    <ItemTemplate>
                        <telerik:RadComboBox ID="RadComboBoxTrafficRoles" runat="server">
                        </telerik:RadComboBox>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton ID="RadToolbarButtonFindEmployees" ImageUrl="Images/users3.png"
                    Text="Find Employees" Value="FindEmployees" ToolTip="Find employees for tasks"
                    Visible="false" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonRefresh" SkinID="RadToolBarButtonRefresh" Value="Refresh" ToolTip="Refresh page" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div >
    </div>
    <asp:HiddenField ID="HiddenFieldCurrentRecord" runat="server" />
    <asp:HiddenField ID="HiddenFieldMoveDirection" runat="server" />
    <div class="telerik-aqua-body">
            <telerik:RadGrid ID="RadGridEventTasksScheduler" runat="server" AllowFilteringByColumn="False"
        ShowHeader="false" ShowFooter="false" en GroupingEnabled="true" AllowSorting="True"
        AutoGenerateColumns="False" GridLines="None" ShowGroupPanel="False">
        <ClientSettings AllowDragToGroup="False">
            <Selecting AllowRowSelect="false" />
        </ClientSettings>
        <MasterTableView DataKeyNames="EVENT_ID,EVENT_TASK_ID,JOB_NUMBER,JOB_COMPONENT_NBR" CommandItemDisplay="TopAndBottom" Width="100%">
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
                        <table border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td colspan="2">
                                    Job:&nbsp;&nbsp;<asp:LinkButton ID="LinkButtonJob" runat="server" CommandName="ViewEventsView"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td width="480" align="left" valign="top">
                                    <fieldset>
                                        <legend>
                                            <asp:LinkButton ID="LinkButtonEvent" runat="server" CommandName="ViewEventDetails"
                                                CommandArgument='<%# Eval("EVENT_ID")%>'>Event</asp:LinkButton>
                                            <asp:Literal ID="Literal2" runat="server" Visible="false" Text=':&nbsp;&nbsp;<%# Eval("EVENT_ID")%>'></asp:Literal>
                                        </legend>
                                        <table width="380" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="70">
                                                    Description:
                                                </td>
                                                <td width="310">
                                                    <%#Eval("EVENT_LABEL")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="70">
                                                    Resource:
                                                </td>
                                                <td width="310">
                                                    <%# Eval("RESOURCE_CODE")%>&nbsp;-&nbsp;
                                                    <%# Eval("RESOURCE_DESC")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Event Date:
                                                </td>
                                                <td>
                                                    <%#CType(Eval("EVENT_DATE"), Date).ToLongDateString()%>
                                                    &nbsp;&nbsp;<%# CType(Eval("EVENT_START_TIME"), Date).ToShortTimeString()%>&nbsp;-&nbsp;<%# CType(Eval("EVENT_END_TIME"), Date).ToShortTimeString()%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Function:
                                                </td>
                                                <td>
                                                    <%# Eval("FNC_CODE")%>&nbsp;-&nbsp;
                                                    <%# Eval("FNC_DESCRIPTION")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Ad Number:
                                                </td>
                                                <td>
                                                    <%# Eval("AD_NBR")%>&nbsp;-&nbsp;
                                                    <%# Eval("AD_NBR_DESC")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    Comment:
                                                </td>
                                                <td align="left" valign="top">
                                                    <div style="border: solid 1px #666666; background: #FFFFFF; color: #000000; padding: 2px;
                                                        width: 300px; height: 38px; overflow: auto;">
                                                        <%# Eval("EVENT_DESC_LONG")%>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    Event Type:
                                                </td>
                                                <td align="left" valign="top">
                                                    <uc1:EventType runat="server" ID="UcEventType" AutoPostBack="true" EventId='<%# Eval("EVENT_ID")%>'
                                                        SaveOnChange="true" />
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                                <td width="480" align="left" valign="top">
                                    <fieldset>
                                        <legend>Task
                                            <asp:Literal ID="Literal1" runat="server" Visible="false" Text=':&nbsp;&nbs;<%# Eval("EVENT_TASK_ID")%>'></asp:Literal>
                                        </legend>
                                        <table width="380" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="70">
                                                    Task:
                                                </td>
                                                <td width="310">
                                                    <%# Eval("EVENT_TASK_TRF_CODE")%>&nbsp;-&nbsp;
                                                    <%# Eval("TRF_DESC")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Task Date:
                                                </td>
                                                <td>
                                                    <%# CType(Eval("NORMALIZED_EVENT_TASK_DATE"), Date).ToLongDateString()%>
                                                    &nbsp;&nbsp;<%# CType(Eval("EVENT_TASK_START_TIME"), Date).ToShortTimeString()%>&nbsp;-&nbsp;<%# CType(Eval("EVENT_TASK_END_TIME"), Date).ToShortTimeString()%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Hours:
                                                </td>
                                                <td>
                                                    <%# Eval("EVENT_TASK_HOURS_ALLOWED")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Employee:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtEMP_CODE" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall" Text='<%# Eval("EVENT_TASK_EMP_CODE") %>'></asp:TextBox>
                                                    <asp:HiddenField ID="HfEMP_CODE" runat="server" Value='<%# Eval("EVENT_TASK_EMP_CODE") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    Comment:
                                                </td>
                                                <td align="left" valign="top">
                                                    <asp:TextBox ID="TxtTaskCOMMENTS" runat="server" Height="38" Text='<%# Eval("EVENT_TASK_COMMENTS")%>' SkinID="TextBoxStandard"
                                                        TextMode="MultiLine" Width="300"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
        <HeaderContextMenu EnableImageSprites="True" CssClass="GridContextMenu GridContextMenu_Default">
        </HeaderContextMenu>
    </telerik:RadGrid>
    </div>

</asp:Content>
