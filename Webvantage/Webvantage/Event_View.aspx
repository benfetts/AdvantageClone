<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Event_View.aspx.vb" Inherits="Webvantage.Event_View"
    MasterPageFile="~/ChildPage.Master" Title="" %>

<%@ Register Src="Event_Type.ascx" TagName="EventType" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function CancelNonInputSelect(sender, args) {

                var e = args.get_domEvent();
                //IE - srcElement, Others - target  
                var targetElement = e.srcElement || e.target;


                //this condition is needed if multi row selection is enabled for the grid  
                if (typeof (targetElement) != "undefined") {
                    //is the clicked element an input checkbox? <input type="checkbox"...>  
                    if (targetElement.tagName.toLowerCase() != "input" &&
									(!targetElement.type || targetElement.type.toLowerCase() != "checkbox"))// && currentClickEvent)  
                    {

                        //cancel the event  
                        args.set_cancel(true);
                    };
                }
                else
                    args.set_cancel(true);
            };
            function DataChangeIsResourceBooked(EventDate, StartTime, EndTime, ResourceCodeClientId) {
                PageMethods.IsResourceBooked(EventDate, StartTime, EndTime, ResourceCodeClientId, IsResourceBookedSuccess, IsResourceBookedFail);
            };
            function IsResourceBookedSuccess(result, userContext, methodName) {
                if (result != '') {
                    var str = "";
                    str = result
                    str = str.replace("##", '\n');
                    str = str.replace("##", '\n');
                    if (str.indexOf("object Object") > -1) {
                    }
                    else {
                        ShowMessage(str);
                    };
                    return false;
                }
                else {
                    return true;
                };
                return false;
            };

            function IsResourceBookedFail(error, userContext, methodName) {
                ShowMessage(error);
                //return false;
            };

        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
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
                };
            };
        </script>
    </telerik:RadScriptBlock>
    <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
        <telerik:RadToolBar ID="RadToolbarJobComponentEvents" runat="server" AutoPostBack="true"
            OnClientButtonClicking="JsOnClientButtonClicking" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonSave" SkinID="RadToolBarButtonSave"
                    Text="" Value="SaveEvents" ToolTip="Save events" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonAddEvent"
                    Text="Add" Value="AddEvent" ToolTip="Add an event" />
                <telerik:RadToolBarButton ID="RadToolbarButtonGenerate"
                    Text="Generate" Value="GenerateEvent" ToolTip="Generate events" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonDelete" SkinID="RadToolBarButtonDelete" Value="DeleteEvents" ToolTip="Delete selected events" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonFindResources" Text="Find Resources" Value="FindResources" ToolTip="Find resources" />
                <telerik:RadToolBarButton ID="RadToolbarButtonClearResources" Text="Clear Resources"
                    Value="ClearResources" ToolTip="Clear all resources" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonFindEmps" Text="Find Employees" Value="FindEmps" ToolTip="Find employees for tasks" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonBillEvents" Enabled="false" Text="Bill Events" Value="BillEvents" ToolTip="Create billing records for selected events" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonPrint" SkinID="RadToolBarButtonPrint"
                    Text="Print" Value="Print" ToolTip="Print" />
                <telerik:RadToolBarButton ID="RadToolbarButtonClose" SkinID="RadToolBarButtonClear" Text="Back To Job"
                    Value="CloseWindow" ToolTip="Back To Job" Visible="false" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton>
                    <ItemTemplate>
                        Group by:&nbsp;
                    <telerik:RadComboBox ID="DropGroupBy" runat="server" AutoPostBack="true" Width="120" SkinID="RadComboBoxStandard">
                        <Items>
                            <telerik:RadComboBoxItem Text="[None]" Value="none"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="Function Code" Value="fnc"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="Ad Number" Value="ad"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="Date" Value="date"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="Day" Value="day"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="Resource Code" Value="resc"></telerik:RadComboBoxItem>
                        </Items>
                    </telerik:RadComboBox>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh" />
            </Items>
        </telerik:RadToolBar>
    </div>
    
    <div class="telerik-aqua-body">
        <ew:CollapsablePanel ID="CollapsablePanelFilter" runat="server" TitleText="Filter" Collapsed="true">
            <table width="100%" border="0" cellspacing="2" cellpadding="0">
                <tr>
                    <td width="5%">&nbsp;
                    </td>
                    <td width="16%">&nbsp;
                    </td>
                    <td width="79%">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                    <td>Date Cutoff:
                    </td>
                    <td>Ad Number:
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="RadDatePickerDateCutoff" runat="server" SkinID="RadDatePickerStandard">
                            <DateInput DateFormat="d" EmptyMessage="">
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
                    <td>
                        <telerik:RadComboBox ID="DropDownListAdNumbers" runat="server" AppendDataBoundItems="true" SkinID="RadComboBoxStandard">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                    <td>Generator:
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                    <td colspan="2">
                        <telerik:RadComboBox ID="DropEventGenerators" runat="server" Width="450px" AppendDataBoundItems="true" SkinID="RadComboBoxStandard">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                    <td colspan="2">
                        <asp:Button ID="BtnApplyFilter" runat="server" Text="Apply" />
                        <asp:Button ID="BtnClear" runat="server" Text="Clear" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
            </table>
        </ew:CollapsablePanel>
        <telerik:RadGrid ID="RadGridEvents" runat="server" AllowMultiRowSelection="True"
            AllowPaging="True" AllowSorting="true" AutoGenerateColumns="False" EnableAJAX="False"
            EnableAJAXLoadingTemplate="False" PageSize="10" EnableOutsideScripts="true" GroupingEnabled="true"
            ShowFooter="False" EnableEmbeddedSkins="True" Visible="True" Width="100%">
            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="TopAndBottom"></PagerStyle>
            <ClientSettings>
                <Selecting AllowRowSelect="true" EnableDragToSelectRows="True" />
                <ClientEvents OnRowSelecting="CancelNonInputSelect" OnRowDeselecting="CancelNonInputSelect" />
            </ClientSettings>
            <MasterTableView GroupsDefaultExpanded="true" NoMasterRecordsText="No records found"
                DataKeyNames="EVENT_ID">
                <Columns>
                    <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="10px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10px" />
                    </telerik:GridClientSelectColumn>
                    <telerik:GridTemplateColumn Display="True" UniqueName="ColDetails">
                        <HeaderStyle CssClass="radgrid-icon-column" />
                        <ItemStyle CssClass="radgrid-icon-column" />
                        <FooterStyle CssClass="radgrid-icon-column" />
                        <HeaderTemplate>
                            &nbsp;
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="icon-background background-color-sidebar">
                                <asp:ImageButton ID="ImgBtnEdit" runat="server" AlternateText="Edit Event" CommandArgument='<%#Eval("EVENT_ID")%>'
                                    CommandName="EditEvent" SkinID="ImageButtonViewWhite" />
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="FNC_CODE" HeaderText="Function<br/>Code" UniqueName="ColFNC_CODE">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="50px" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50px" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="50px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn DataField="AD_NUMBER" HeaderText="Ad Number" UniqueName="ColAD_NUMBER"
                        SortExpression="AD_NUMBER">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="285px" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="285px" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="285px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TxtAD_NUMBER" runat="server" MaxLength="30" Text='<%# Eval("AD_NUMBER") %>' SkinID="TextBoxStandard"></asp:TextBox>
                            <asp:HiddenField ID="HfAD_NUMBER" runat="server" Value='<%# Eval("AD_NUMBER") %>' />
                            <asp:HiddenField ID="HfEVENT_ID" runat="server" Value='<%# Eval("EVENT_ID") %>' />
                            <asp:HiddenField ID="HfINCOME_ONLY_ID" runat="server" Value='<%# Eval("INCOME_ONLY_ID") %>' />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="EVENT_LABEL" HeaderText="Event Description"
                        UniqueName="ColEVENT_LABEL">
                        <HeaderStyle CssClass="radgrid-textarea-column" />
                        <ItemStyle CssClass="radgrid-textarea-column" />
                        <FooterStyle CssClass="radgrid-textarea-column" />
                        <ItemTemplate>
                            <asp:TextBox ID="TxtEVENT_LABEL" runat="server" Width="100%" MaxLength="50" Text='<%# Eval("EVENT_LABEL") %>' TextMode="multiLine" CssClass="radgrid-textarea" SkinID="TextBoxStandard"></asp:TextBox>
                            <asp:HiddenField ID="HfEVENT_LABEL" runat="server" Value='<%# Eval("EVENT_LABEL") %>' />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Event<br />Comment" UniqueName="ColEVENT_DESC_LONG">
                        <HeaderStyle CssClass="radgrid-textarea-column" />
                        <ItemStyle CssClass="radgrid-textarea-column" />
                        <FooterStyle CssClass="radgrid-textarea-column" />
                        <ItemTemplate>
                            <asp:TextBox ID="TxtEVENT_DESC_LONG" runat="server" Width="100%" Text='<%#Eval("EVENT_DESC_LONG")%>'
                                TextMode="multiLine" ToolTip="Event Comment" CssClass="radgrid-textarea" SkinID="TextBoxStandard"></asp:TextBox>
                            <asp:HiddenField ID="HfEVENT_DESC_LONG" runat="server" Value='<%# Eval("EVENT_DESC_LONG") %>' />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="EVENT_DATE" Display="True" HeaderText="Date"
                        SortExpression="EVENT_DATE" UniqueName="ColEVENT_DATE">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="bottom" Width="140px" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="middle" Width="140px" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="middle" Width="140px" />
                        <ItemTemplate>
                            <telerik:RadDatePicker ID="RadDatePickerEVENT_DATE" runat="server"
                                SkinID="RadDatePickerStandard">
                                <DateInput DateFormat="d" EmptyMessage="">
                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                </DateInput>
                            </telerik:RadDatePicker>
                            <asp:HiddenField ID="HfEVENT_DATE" runat="server" Value='<%# Eval("EVENT_DATE") %>' />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="DAY_OF_WEEK" HeaderText="Day" UniqueName="ColDAY_OF_WEEK"
                        SortExpression="DAY_OF_WEEK">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="30px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" Width="30px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn DataField="START_TIME" Display="True" HeaderText="Start Time"
                        UniqueName="ColSTART_TIME">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="115px" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="115px" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="115px" />
                        <ItemTemplate>
                            <telerik:RadTimePicker ID="RadTimePickerStartTime" runat="server" SelectedDate='<%# Eval("START_TIME") %>'
                                Width="110px">
                                <DateInput onfocus="this.select();">
                                </DateInput>
                            </telerik:RadTimePicker>
                            <asp:HiddenField ID="HfSTART_TIME" runat="server" Value='<%# Eval("START_TIME") %>' />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="END_TIME" Display="True" HeaderText="End Time"
                        UniqueName="ColEND_TIME">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="115px" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="115px" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="115px" />
                        <ItemTemplate>
                            <telerik:RadTimePicker ID="RadTimePickerEndTime" runat="server" SelectedDate='<%# Eval("END_TIME") %>'
                                Width="110px">
                                <DateInput onfocus="this.select();">
                                </DateInput>
                            </telerik:RadTimePicker>
                            <asp:HiddenField ID="HfEND_TIME" runat="server" Value='<%# Eval("END_TIME") %>' />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="QTY_HRS" Display="True" HeaderText="Hours"
                        UniqueName="ColQTY_HRS">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="bottom" Width="50px" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="middle" Width="50px" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="middle" Width="50px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TxtQTY_HRS" runat="server" Style="text-align: right;" MaxLength="6" Width="75"
                                Text='<%# Eval("QTY_HRS") %>' SkinID="TextBoxStandard"></asp:TextBox>
                            <asp:HiddenField ID="HfQTY_HRS" runat="server" Value='<%# Eval("QTY_HRS") %>' />
                            <asp:HiddenField ID="HfQTY_TYPE" runat="server" Value='<%# Eval("QTY_TYPE") %>' />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="RESOURCE_CODE" Display="True" HeaderText="Resource Code"
                        SortExpression="RESOURCE_CODE" UniqueName="ColRESOURCE_CODE">
                        <HeaderStyle HorizontalAlign="left" VerticalAlign="bottom" Width="72px" />
                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="72px" />
                        <FooterStyle HorizontalAlign="left" VerticalAlign="middle" Width="72px" />
                        <ItemTemplate>
                            <asp:TextBox ID="TxtRESOURCE_CODE" runat="server" MaxLength="6" Text='<%# Eval("RESOURCE_CODE") %>'
                                Width="75" SkinID="TextBoxStandard"></asp:TextBox>
                            <asp:HiddenField ID="HfRESOURCE_CODE" runat="server" Value='<%# Eval("RESOURCE_CODE") %>' />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="EVENT_TYPE_ID" Display="True" HeaderText="Event Type"
                        SortExpression="EVENT_TYPE_ID_ALPHA_SORT" UniqueName="ColEVENT_TYPE_ID">
                        <HeaderStyle HorizontalAlign="left" VerticalAlign="bottom" Width="72px" />
                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="72px" />
                        <FooterStyle HorizontalAlign="left" VerticalAlign="middle" Width="72px" />
                        <ItemTemplate>
                            <uc1:EventType runat="server" ID="UcEventType" />
                            <asp:HiddenField ID="HfEVENT_TYPE_ID" runat="server" Value='<%# Eval("EVENT_TYPE_ID") %>' />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="EVENT_ID" HeaderText="TEST" UniqueName="ColTEST_COLUMN_ID"
                        Display="False">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                </Columns>
                <RowIndicatorColumn Visible="False">
                </RowIndicatorColumn>
                <ExpandCollapseColumn Resizable="False" Visible="False">
                </ExpandCollapseColumn>
            </MasterTableView>
        </telerik:RadGrid>
        <telerik:RadCalendar ID="RadCalendarShared" runat="server" RangeMinDate="1900-01-01">
        </telerik:RadCalendar>
        <telerik:RadTimeView ID="RadTimeViewShared" runat="server" Interval="00:30:00" HeaderText="Time Selector">
        </telerik:RadTimeView>
    </div>

</asp:Content>
