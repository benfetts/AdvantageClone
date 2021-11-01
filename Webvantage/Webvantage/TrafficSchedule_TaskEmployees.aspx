<%@ Page AutoEventWireup="false" CodeBehind="TrafficSchedule_TaskEmployees.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Employees" Inherits="Webvantage.TrafficSchedule_TaskEmployees"
    Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlockMain" runat="server">
        <script type="text/javascript">
            function hoursAllowedChanged(sender) {
                var dataItem = findGridDataItemFromControl(sender);
                var val = $(sender).val();
                if(val != ""){
                    if(!$.isNumeric(val)){
                        ShowMessage('Hours allowed must be numeric.');
                        return;
                    }
                }
                if (dataItem) {
                    $.ajax({
                        type: 'POST',
                        url: 'TrafficSchedule_TaskEmployees.aspx/UpdateHoursAllowed',
                        data: JSON.stringify({ "ID": dataItem.getDataKeyValue('ID'), "EmployeeCode": dataItem.getDataKeyValue('EMP_CODE'), "HoursAllowed": $(sender).val() }),
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (response) {
                            
                        },
                        error: function (response) {
                            ShowMessage('Hours allowed failed to save.');
                        }
                    });
                }
            }
            function findGridDataItemFromControl(control) {
                var dataItems = $find('<%= RadGridTaskEmployees.ClientID %>').get_masterTableView().get_dataItems();
                for (var i = 0; i < dataItems.length; i++) {
                    var dataItem = dataItems[i];
                    if ($(dataItem.get_element()).prop('id') === $(control).closest('tr').prop('id')) {
                        return dataItem;
                    }
                }
                return;
            }
        </script>
    </telerik:RadScriptBlock>
    <telerik:RadToolBar ID="RadToolbarEmployees" runat="server" AutoPostBack="true" Width="100%">
        <Items>
            <telerik:RadToolBarButton ID="RadToolbarButtonSaveAll" SkinID="RadToolBarButtonSave"
                Text="" Value="Save" ToolTip="Save" />
            <telerik:RadToolBarButton ID="RadToolbarTemplateButtonRefresh" SkinID="RadToolBarButtonRefresh" Value="Refresh" ToolTip="Refresh" />
            <telerik:RadToolBarButton ID="RadToolBarButtonChkLimitToRole" 
                 Group="Role" Text="Limit List to Task Roles" Value="Role" Checked="True" AllowSelfUnCheck="true"
                 CheckOnClick="true" />
           <telerik:RadToolBarButton ID="RadToolBarButtonChkAvailability" 
                 Group="Availability" Text="Check Availability" Value="Availability" Checked="false" AllowSelfUnCheck="true"
                 CheckOnClick="true" />
        </Items>
    </telerik:RadToolBar>
    <table border="0" cellpadding="0" cellspacing="2" id="TableDates" runat="server"> 
       
        <tr>
            <td width="200">
                <span>Start Date:</span>&nbsp;&nbsp;
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
            </td>
            <td width="200">
                <span>Due Date:</span>&nbsp;&nbsp;
                <telerik:RadDatePicker ID="RadDatePickerDueDate" runat="server" 
                      SkinID="RadDatePickerStandard">
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
        </tr>
        <tr>
            <td>
                <span>Time Due:</span>&nbsp;&nbsp;<asp:Label   ID="LblTimeDue" runat="server" Text=""
                    ></asp:Label>
            </td>
            <td>
                <span>Default Hours:</span>&nbsp;&nbsp;<asp:Label   ID="LblDefaultHours" runat="server"
                    Text="" ></asp:Label>
            </td>
        </tr>
    </table> 
    <table style="width: 100%; border: 0px;">
        <tr>
            <td>Current Employees:
            </td>
        </tr>
        <tr>
            <td style="padding: 0px 12px 4px 0px;">
                <telerik:RadGrid ID="RadGridTaskEmployees" runat="server" AllowAutomaticDeletes="false" AllowMultiRowSelection="true" GroupingSettings-CaseSensitive="false"
                    EnableEmbeddedSkins="True" AllowAutomaticInserts="false" AllowAutomaticUpdates="false" AllowFilteringByColumn="true" AllowSorting="True"
                    AutoGenerateColumns="false" Width="100%">
                    <ClientSettings>
                        <Selecting AllowRowSelect="true" EnableDragToSelectRows="true" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="ID,EMP_CODE" ClientDataKeyNames="ID,EMP_CODE" NoMasterRecordsText="No Records to Display">
                        <Columns>
                            <telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Employee" UniqueName="colEMP_NAME" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn DataField="HOURS_ALLOWED" HeaderText="Hours Allowed" UniqueName="colHOURS_ALLOWED" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="right" VerticalAlign="middle" Width="70" />
                                <ItemStyle HorizontalAlign="right" VerticalAlign="middle" Width="70" />
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtTHOURS_ALLOWED" runat="server" Text='<%# Eval("HOURS_ALLOWED") %>' SkinID="TextBoxStandard"
                                        Width="70" Style="text-align: right;" onblur="hoursAllowedChanged(this);"></asp:TextBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="TEMP_COMP_DATE" DataFormatString="{0:d}" HeaderText="Completed" UniqueName="ColTEMP_COMP_DATE" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="90" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="90" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="90" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn Display="false" HeaderText="&nbsp;" UniqueName="colUpdateRow" AllowFiltering="false">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="imgbtnUpdateRow" runat="server" CommandName="UpdateRow" SkinID="RadToolBarButtonSaveWhite"
                                            ToolTip="UpdateThisRow" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="colRemoveEmpFromTask" AllowFiltering="false">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <HeaderTemplate>
                                    <asp:ImageButton ID="imgbtnRemoveEmpFromTask" runat="server" CommandName="RemoveSelectedEmpsFromTask"
                                        SkinID="ImageButtonDelete" ToolTip="Remove all selected employee(s) from Task" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="icon-background background-color-delete">
                                        <asp:ImageButton ID="imgbtnRemoveEmpFromTask" runat="server" CommandName="RemoveEmpFromTask"
                                            SkinID="ImageButtonDeleteWhite" ToolTip="Remove Employee from Task" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <ExpandCollapseColumn Visible="False">
                            <HeaderStyle Width="19px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <DetailTables>
                            <telerik:GridTableView AllowSorting="false" AutoGenerateColumns="false" Caption="Workload"
                                Name="WorkloadGrid" NoDetailRecordsText="No Records to Display">
                                <Columns>
                                    <telerik:GridBoundColumn DataField="TextColumn" UniqueName="ColText" AllowFiltering="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DataColumn" UniqueName="ColData" AllowFiltering="false">
                                        <HeaderStyle HorizontalAlign="right" Width="80" />
                                        <ItemStyle HorizontalAlign="right" Width="80" />
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </telerik:GridTableView>
                            <telerik:GridTableView AllowSorting="True" Caption="Assignments" Name="AssignmentsGrid"
                                NoDetailRecordsText="No Records to Display" DataKeyNames="JOB_NUMBER,JOB_COMPONENT_NBR,SEQ_NBR,REC_TYPE,ALERT_ID">
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="C/D/P" UniqueName="ColCDP" AllowFiltering="false">
                                        <ItemStyle />
                                        <ItemTemplate>
                                            <%#Eval("CL_CODE")%>
                                                &nbsp;/&nbsp;<%#Eval("DIV_CODE")%>&nbsp;/&nbsp;<%#Eval("PRD_CODE")%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Job/Comp" UniqueName="ColJobComp" AllowFiltering="false">
                                        <ItemStyle />
                                        <ItemTemplate>
                                            <%#Eval("JOB_NUMBER")%>
                                                &nbsp;-&nbsp;<%#Eval("JOB_DESC")%><br />
                                            <%#Eval("JOB_COMPONENT_NBR")%>
                                                &nbsp;-&nbsp;<%#Eval("JOB_COMP_DESC")%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="TASK_DESCRIPTION" HeaderText="Task" UniqueName="ColTASK_DESCRIPTION" AllowFiltering="false">
                                        <ItemStyle />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TASK_START_DATE" DataFormatString="{0:M/d/yyyy }"
                                        HeaderText="Start" UniqueName="ColTASK_START_DATE" AllowFiltering="false">
                                        <HeaderStyle HorizontalAlign="right" />
                                        <ItemStyle HorizontalAlign="right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="JOB_REVISED_DATE" DataFormatString="{0:M/d/yyyy }"
                                        HeaderText="Due" UniqueName="ColJOB_REVISED_DATE" AllowFiltering="false">
                                        <HeaderStyle HorizontalAlign="right" />
                                        <ItemStyle HorizontalAlign="right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn DataField="JOB_HRS" HeaderText="Hours"
                                        UniqueName="ColJOB_HRS" AllowFiltering="false">
                                        <HeaderStyle HorizontalAlign="right" VerticalAlign="middle" Width="70" />
                                        <ItemStyle HorizontalAlign="right" VerticalAlign="middle" Width="70" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtJOB_HRS" runat="server" Text='<%# FormatNumber(Eval("DISTRIBUTED_HRS"), 2, True, False, True) %>'
                                                SkinID="TextBoxStandard" Width="70" Style="text-align: right;"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="ADJ_JOB_HRS" HeaderText="Adj. Hours" UniqueName="ColADJ_JOB_HRS" AllowFiltering="false"
                                        DataFormatString="{0:0.00}">
                                        <HeaderStyle HorizontalAlign="right" />
                                        <ItemStyle HorizontalAlign="right" />
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </telerik:GridTableView>
                        </DetailTables>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <table style="width: 100%; border: 0px;">
        <tr>
            <td>Available Employees:
            </td>
        </tr>
        <tr>
            <td style="padding: 0px 12px 4px 0px;">
                <telerik:RadGrid ID="RadGridEmployeesList" runat="server" AllowAutomaticDeletes="false" AllowFilteringByColumn="true" AllowSorting="True" AllowMultiRowSelection="true" GroupingSettings-CaseSensitive="false"
                    AllowAutomaticInserts="false" AllowAutomaticUpdates="false" AutoGenerateColumns="false"
                    EnableEmbeddedSkins="True" Width="100%">
                    <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                    <ClientSettings EnablePostBackOnRowClick="False">
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="true" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="EMPCODE" NoDetailRecordsText="No Records to Display"
                        NoMasterRecordsText="No Records To Display">
                        <Columns>
                            <telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Employee" UniqueName="colEMP_NAME" FilterControlWidth="95%"
                                CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="colAddEmpToTask" AllowFiltering="false">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <HeaderTemplate>
                                    <asp:ImageButton ID="imgbtnAddEmpToTask" runat="server" CommandName="AddSelectedEmpsToTask"
                                        SkinID="ImageButtonNew" ToolTip="Add all selected employee(s) to Task" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="imgbtnAddEmpToTask" runat="server" CommandName="AddEmpToTask"
                                            SkinID="ImageButtonNewWhite" ToolTip="Add Employee to Task" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <ExpandCollapseColumn Visible="False">
                            <HeaderStyle Width="19px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <DetailTables>
                            <telerik:GridTableView AllowSorting="false" AutoGenerateColumns="false" Caption="Workload"
                                Name="WorkloadGrid" NoDetailRecordsText="No Records to Display">
                                <Columns>
                                    <telerik:GridBoundColumn DataField="TextColumn" UniqueName="ColText" AllowFiltering="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DataColumn" UniqueName="ColData" AllowFiltering="false">
                                        <HeaderStyle HorizontalAlign="right" Width="80" />
                                        <ItemStyle HorizontalAlign="right" Width="80" />
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </telerik:GridTableView>
                            <telerik:GridTableView AllowSorting="True" Caption="Assignments" Name="AssignmentsGrid"
                                NoDetailRecordsText="No Records to Display" Width="99%" DataKeyNames="JOB_NUMBER,JOB_COMPONENT_NBR,SEQ_NBR,REC_TYPE,ALERT_ID">
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="C/D/P" UniqueName="ColCDP" AllowFiltering="false">
                                        <ItemTemplate>
                                            <%#Eval("CL_CODE")%>
                                                &nbsp;/&nbsp;<%#Eval("DIV_CODE")%>&nbsp;/&nbsp;<%#Eval("PRD_CODE")%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Job/Comp" UniqueName="ColJobComp" AllowFiltering="false">
                                        <ItemTemplate>
                                            <%#Eval("JOB_NUMBER")%>
                                                &nbsp;-&nbsp;<%#Eval("JOB_DESC")%><br />
                                            <%#Eval("JOB_COMPONENT_NBR")%>
                                                &nbsp;-&nbsp;<%#Eval("JOB_COMP_DESC")%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="TASK_DESCRIPTION" HeaderText="Task" UniqueName="ColTASK_DESCRIPTION" AllowFiltering="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TASK_START_DATE" DataFormatString="{0:M/d/yyyy }" AllowFiltering="false"
                                        HeaderText="Start" UniqueName="ColTASK_START_DATE">
                                        <HeaderStyle HorizontalAlign="right" />
                                        <ItemStyle HorizontalAlign="right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="JOB_REVISED_DATE" DataFormatString="{0:M/d/yyyy }" AllowFiltering="false"
                                        HeaderText="Due" UniqueName="ColJOB_REVISED_DATE">
                                        <HeaderStyle HorizontalAlign="right" />
                                        <ItemStyle HorizontalAlign="right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn DataField="JOB_HRS" HeaderText="Hours" AllowFiltering="false"
                                        UniqueName="ColJOB_HRS">
                                        <HeaderStyle HorizontalAlign="right" VerticalAlign="middle" Width="70" />
                                        <ItemStyle HorizontalAlign="right" VerticalAlign="middle" Width="70" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtJOB_HRS" runat="server" Text='<%# FormatNumber(Eval("JOB_HRS"), 2, True, False, True) %>'
                                                SkinID="TextBoxStandard" Width="70" Style="text-align: right;"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="ADJ_JOB_HRS" HeaderText="Adj. Hours" UniqueName="ColADJ_JOB_HRS" AllowFiltering="false"
                                        DataFormatString="{0:0.00}">
                                        <HeaderStyle HorizontalAlign="right" />
                                        <ItemStyle HorizontalAlign="right" />
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </telerik:GridTableView>
                        </DetailTables>
                    </MasterTableView>
                </telerik:RadGrid>
                <fieldset id="FieldsetRoles" runat="server">
                    <legend>Roles</legend>
                    <asp:DataList ID="DataListRoles" runat="server">
                        <ItemTemplate>
                            <%# Eval("ROLE_CODE") %>&nbsp;-&nbsp;<%# Eval("ROLE_DESC") %><br />
                        </ItemTemplate>
                    </asp:DataList>
                </fieldset>
            </td>
        </tr>
    </table>
    
</asp:Content>
