<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Event_Detail.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Event Detail" Inherits="Webvantage.Event_Detail" %>

<%@ Register Src="Event_Type.ascx" TagName="EventType" TagPrefix="uc1" %>
<%@ Register Src="Resources.ascx" TagName="Resources" TagPrefix="uc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
    <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
        <script type="text/javascript">
            function JsOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();
                if (comandName == "DeleteEvent") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete this event?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete this event?");
                }
            }
        </script>
    </telerik:RadScriptBlock>
    <div >
        <telerik:RadToolBar ID="RadToolbarEventDetails" runat="server" AutoPostBack="true"
        OnClientButtonClicking="JsOnClientButtonClicking" Width="100%">
        <Items>
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolbarButtonSave" SkinID="RadToolBarButtonSave"
                Text="" Value="SaveEvent" CommandName="SaveEvent" ToolTip="Save event details" />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolbarButtonDelete" SkinID="RadToolBarButtonDelete" Value="DeleteEvent" CommandName="DeleteEvent" ToolTip="Delete this event" />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolbarButtonGoBack" SkinID="RadToolBarButtonClear"
                Text="Go to Job Events" CommandName="GoBack" Value="GoBack" ToolTip="Go to Job Events" Visible="True" />
            <telerik:RadToolBarButton IsSeparator="true" Visible="false" />
        </Items>
    </telerik:RadToolBar>
    </div>
    <div >
    </div>
    <ew:CollapsablePanel ID="CollapsablePanelHeader" runat="server"
        TitleText="Details" >
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="right" valign="middle">
                    Billing Record Created?:&nbsp;&nbsp;<asp:Label   ID="LblIncomeOnly" runat="server"
                        Text=""></asp:Label>&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table border="0" cellpadding="0" cellspacing="2" width="600">
                        <tr>
                            <td width="100">
                                Job/Component:
                            </td>
                            <td width="494">
                                <asp:Label   ID="LblJobComp" runat="server" Text=""></asp:Label>
                                <%--<asp:LinkButton ID="LnkBtnGoToJob" runat="server" Visible="false">Go</asp:LinkButton>--%>
                            </td>
                        </tr>
                        <tr>
                            <td width="100">
                                Event ID:
                            </td>
                            <td width="494">
                                <asp:Label   ID="LblEventID" runat="server" Text="[None]"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Event Description:
                            </td>
                            <td>
                                <asp:TextBox ID="TxtShortDesc" runat="server" TabIndex="1" MaxLength="50" CssClass="RequiredInput" SkinID="TextBoxStandard"
                                    Width="450px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Event Comment:
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="TxtLongDesc" runat="server" Height="66px" TabIndex="2" TextMode="MultiLine" SkinID="TextBoxStandard"
                                    Width="450px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Event Type:
                            </td>
                            <td align="left" valign="top">
                                <uc1:EventType runat="server" ID="UcEventType" TabIndex="3" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Date:
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="RadDatePickerEventDate" runat="server" 
                                      SkinID="RadDatePickerStandard">
                                    <DateInput DateFormat="d" EmptyMessage="" CssClass="RequiredInput">
                                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                    </DateInput>
                                    <Calendar ID="Calendar1" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                        <SpecialDays>
                                            <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                            </telerik:RadCalendarDay>
                                        </SpecialDays>
                                    </Calendar>
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RbTime" runat="server" GroupName="RbGrpTimeHours" />
                                Time:
                            </td>
                            <td>
                                <telerik:RadTimePicker ID="RadTimePickerStartTime" runat="server" SharedTimeViewID="RadTimeViewShared"
                                    Width="150" TabIndex="5">
                                    <DateInput onfocus="this.select();">
                                    </DateInput>
                                </telerik:RadTimePicker>
                                &nbsp;to&nbsp;
                                <telerik:RadTimePicker ID="RadTimePickerEndTime" runat="server" SharedTimeViewID="RadTimeViewShared"
                                    Width="150" TabIndex="6">
                                    <DateInput onfocus="this.select();">
                                    </DateInput>
                                </telerik:RadTimePicker>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="RbHours" runat="server" GroupName="RbGrpTimeHours" />
                                Hours:
                            </td>
                            <td>
                                <asp:TextBox ID="TxtHours" runat="server" TabIndex="7" Width="80" Style="text-align: right;" SkinID="TextBoxStandard"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label   ID="LblFunctionCodeLabel" runat="server" Text="Function Code:"></asp:Label>
                                <asp:HyperLink ID="HlFunctionCode" runat="server" TabIndex="-1" href=""><span>Function Code:</span></asp:HyperLink>
                            </td>
                            <td>
                                <asp:Label   ID="LblFunctionCode" runat="server" Text=""></asp:Label>
                                <asp:TextBox ID="TxtFunctionCode" runat="server" MaxLength="6" CssClass="RequiredInput" SkinID="TextBoxStandard"
                                    TabIndex="8" Text="" Width="63px"></asp:TextBox>
                                <asp:TextBox ID="TxtFunctionCodeDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                    Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                <asp:HyperLink ID="HlAdNumber" runat="server" TabIndex="-1" href=""><span 
                                                >Ad Number:</span></asp:HyperLink>
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="TxtAdNumber" runat="server" TabIndex="9" Text="" Width="275px" MaxLength="30" SkinID="TextBoxStandard"></asp:TextBox>
                                <asp:TextBox ID="TxtAdNumberColor" runat="server" ReadOnly="true" Visible="True" SkinID="TextBoxStandard"
                                    Width="15px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Ad Number Description:
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="TxtAdNumberDescription" runat="server" ReadOnly="true" TextMode="MultiLine" SkinID="TextBoxStandard"
                                    Height="45px" TabIndex="-1" Width="275px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Quantity Type:
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RblQuantityType" runat="server" RepeatDirection="Horizontal"
                                    TabIndex="10" RepeatColumns="2" RepeatLayout="Flow">
                                    <asp:ListItem Text="Event" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Hours" Value="1"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <telerik:RadTimeView ID="RadTimeViewShared" runat="server" Interval="00:30:00" HeaderText="Time Selector">
        </telerik:RadTimeView>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelResource" runat="server"
        TitleText="Resource">
        <table width="600" border="0" cellspacing="2" cellpadding="0">
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:HiddenField ID="HfResource" runat="server" Value="" />
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                        <uc1:Resources runat="server" ID="UcResources" Visible="True" SaveOnResourceChange="false"
                            HideLastUseRows="false" ShowRefreshTaskGridButton="False" />
                </ContentTemplate>
            </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
        </table>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelTasks" runat="server"
        TitleText="Tasks">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr id="TrTasksToolbar" runat="server">
                <td runat="server" id="TdTasksToolbar">
                    <telerik:RadScriptBlock ID="RadScriptBlock3" runat="server">
                        <script type="text/javascript">
                            function JsOnClientButtonClicking2(sender, args) {
                                var comandName = args.get_item().get_commandName();
                                if (comandName == "DeleteTasks") {
                                    ////args.set_cancel(!confirm('Are you sure you want to delete selected task(s)?'));
                                    radToolBarConfirm(sender, args, "Are you sure you want to delete selected task(s)?");
                                }
                            }
                        </script>
                    </telerik:RadScriptBlock>
                    <telerik:RadToolBar ID="RadToolbarEventTasks" runat="server" AutoPostBack="true"
                        TabIndex="11" OnClientButtonClicking="JsOnClientButtonClicking2" Width="100%">
                        <Items>
                            <telerik:RadToolBarButton IsSeparator="true" />
                            <telerik:RadToolBarButton ID="RadToolbarButtonAddTaks" SkinID="RadToolBarButtonNew"
                                Text="Add" Value="AddTask" CommandName="AddTask" ToolTip="Add a task/resource" />
                            <telerik:RadToolBarButton IsSeparator="true" Visible="false" />
                            <telerik:RadToolBarButton ID="RadToolbarButtonSaveTasks" SkinID="RadToolBarButtonSave"
                                Text="Save Grid" Value="SaveTasks" CommandName="SaveTasks" Visible="True" ToolTip="Save tasks grid" />
                            <telerik:RadToolBarButton IsSeparator="true" />
                            <telerik:RadToolBarButton ID="RadToolbarButtonDeleteTasks" SkinID="RadToolBarButtonDelete" Value="DeleteTasks" CommandName="DeleteTasks" ToolTip="Delete tasks" />
                            <telerik:RadToolBarButton ID="RadToolbarButtonRefreshAutoTasks" Visible="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkRefreshAutoTasks" runat="server" Checked="True" />
                                </ItemTemplate>
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton IsSeparator="true" />
                        </Items>
                    </telerik:RadToolBar>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    <asp:Label   ID="LblMSG_Grid" runat="server" Text="" CssClass="CssRequired"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="PnlGrid" runat="server" DefaultButton="BtnPnlGridSave">
                        <telerik:RadGrid ID="RadGridEventTasks" runat="server" AllowMultiRowSelection="True"
                            AllowPaging="False" AllowSorting="true" AutoGenerateColumns="False" EnableAJAX="False"
                            EnableAJAXLoadingTemplate="False" EnableOutsideScripts="true" GroupingEnabled="true"
                            ShowFooter="True" EnableEmbeddedSkins="True" Visible="True" TabIndex="12">
                            <ClientSettings>
                                <Selecting AllowRowSelect="true" EnableDragToSelectRows="True" />
                            </ClientSettings>
                            <MasterTableView GroupsDefaultExpanded="true" NoMasterRecordsText="No records found"
                                DataKeyNames="INDEX">
                                <Columns>
                                    <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                        <HeaderStyle HorizontalAlign="center" Width="5px" />
                                        <ItemStyle HorizontalAlign="center" Width="5px" />
                                    </telerik:GridClientSelectColumn>
                                    <telerik:GridBoundColumn DataField="INDEX" HeaderText="index" UniqueName="ColTEST"
                                        Display="False">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="EVENT_TASK_ID" HeaderText="task id" UniqueName="ColTEST2"
                                        Display="False">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn DataField="TASK_CODE" Display="True" HeaderText="Task Code"
                                        UniqueName="colTASK_CODE">
                                        <HeaderStyle HorizontalAlign="left" VerticalAlign="bottom" Width="80px" />
                                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="80px" />
                                        <FooterStyle HorizontalAlign="left" VerticalAlign="middle" Width="80px" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtTASK_CODE" runat="server" MaxLength="10" Text='<%# Eval("TASK_CODE") %>'
                                                Style="min-width: 90px; width: 90px;" SkinID="TextBoxStandard"></asp:TextBox>
                                            <asp:HiddenField ID="HfTASK_CODE" runat="server" Value='<%# Eval("TASK_CODE") %>' />
                                            <asp:HiddenField ID="HfEVENT_TASK_ID" runat="server" Value='<%# Eval("EVENT_TASK_ID") %>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="" Display="True" HeaderText="" UniqueName="ColTASK_CODE_LOOKUP">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                 <asp:ImageButton ID="ImgBtnTASK_CODE_LOOKUP" runat="server" SkinID="ImageButtonFindWhite"
                                                    AlternateText="Lookup task code" ToolTip="Lookup task code" />
                                            </div>                      
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="EVENT_TASK_DATE" Display="True" HeaderText="Date"
                                        UniqueName="colEVENT_TASK_DATE">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="bottom" Width="80px" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="middle" Width="80px" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="middle" Width="80px" />
                                        <ItemTemplate>
                                            <telerik:RadDatePicker ID="RadDatePickerEVENT_TASK_DATE" runat="server" 
                                                  SkinID="RadDatePickerStandard">
                                                <DateInput DateFormat="d" EmptyMessage="">
                                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                </DateInput>
                                            </telerik:RadDatePicker>
                                            <asp:HiddenField ID="HfSTART_DATE" runat="server" Value='<%# Eval("EVENT_TASK_DATE") %>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="START_TIME" Display="True" HeaderText="Start Time"
                                        UniqueName="colSTART_TIME">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="85px" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="85px" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="85px" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtSTART_TIME" runat="server" MaxLength="8" Text='<%# Eval("START_TIME") %>' SkinID="TextBoxStandard"
                                                Style="min-width: 72px; width: 72px;" Visible="true"></asp:TextBox>
                                            <asp:HiddenField ID="HfSTART_TIME" runat="server" Value='<%# Eval("START_TIME") %>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="END_TIME" Display="True" HeaderText="End Time"
                                        UniqueName="colEND_TIME">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="85px" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="85px" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="85px" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtEND_TIME" runat="server" MaxLength="8" Text='<%# Eval("END_TIME") %>' SkinID="TextBoxStandard"
                                                Style="min-width: 72px; width: 72px;" Visible="true"></asp:TextBox>
                                            <asp:HiddenField ID="HfEND_TIME" runat="server" Value='<%# Eval("END_TIME") %>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="EMP_CODE" Display="True" HeaderText="Employee"
                                        UniqueName="colEMP_CODE">
                                        <HeaderStyle HorizontalAlign="left" VerticalAlign="bottom" Width="80px" />
                                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="80px" />
                                        <FooterStyle HorizontalAlign="left" VerticalAlign="middle" Width="80px" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtEMP_CODE" runat="server" MaxLength="6" Text='<%# Eval("EMP_CODE") %>' SkinID="TextBoxStandard"
                                                Style="min-width: 90px; width: 90px;"></asp:TextBox>
                                            <asp:HiddenField ID="HfEMP_CODE" runat="server" Value='<%# Eval("EMP_CODE") %>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Hours Allowed" UniqueName="ColHOURS_ALLOWED">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="50px" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="50px" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="50px" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtHOURS_ALLOWED" runat="server" MaxLength="6" Style="text-align: right;
                                                min-width: 50px; width: 50px;" Text='<%#Eval("HOURS_ALLOWED")%>' ToolTip="Hours allowed" SkinID="TextBoxStandard"></asp:TextBox>
                                            <asp:HiddenField ID="HfHOURS_ALLOWED" runat="server" Value='<%# Eval("HOURS_ALLOWED") %>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Comments" UniqueName="colCOMMENTS">
                                        <HeaderStyle CssClass="radgrid-textarea-column" />
                                        <ItemStyle CssClass="radgrid-textarea-column" />
                                        <FooterStyle CssClass="radgrid-textarea-column" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtCOMMENTS" runat="server" Text='<%#Eval("COMMENTS")%>' TextMode="multiLine" ToolTip="Comments" CssClass="radgrid-textarea"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="TEMP_COMP_DATE" Display="True" HeaderText="Completed<br/>Date"
                                        UniqueName="colTEMP_COMP_DATE">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="bottom" Width="80px" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="middle" Width="80px" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="middle" Width="80px" />
                                        <ItemTemplate>
                                            <telerik:RadDatePicker ID="RadDatePickerTEMP_COMP_DATE" runat="server" 
                                                  SkinID="RadDatePickerStandard">
                                                <DateInput DateFormat="d" EmptyMessage="">
                                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                </DateInput>
                                            </telerik:RadDatePicker>
                                            <asp:HiddenField ID="HfTEMP_COMP_DATE" runat="server" Value='<%# Eval("TEMP_COMP_DATE") %>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Completed<br />Comments" UniqueName="colCOMPLETED_COMMENTS">
                                        <HeaderStyle CssClass="radgrid-textarea-column" />
                                        <ItemStyle CssClass="radgrid-textarea-column" />
                                        <FooterStyle CssClass="radgrid-textarea-column" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtCOMPLETED_COMMENTS" runat="server" Text='<%#Eval("COMPLETED_COMMENTS")%>' TextMode="multiLine" ToolTip="Completed comments" CssClass="radgrid-textarea" SkinID="TextBoxStandard"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <RowIndicatorColumn Visible="False">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn Resizable="False" Visible="False">
                                </ExpandCollapseColumn>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <telerik:RadCalendar ID="RadCalendarShared" runat="server" RangeMinDate="1900-01-01">
                        </telerik:RadCalendar>
                        <div style="display:none !important;" >
                            <asp:Button ID="BtnPnlGridSave" runat="server" Text="SaveGrid" Visible="True" />
                        </div>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </ew:CollapsablePanel>
</asp:Content>
