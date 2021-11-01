<%@ Page Title="New Activity" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Calendar_NewActivity.aspx.vb" Inherits="Webvantage.Calendar_NewActivity" EnableViewState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            var formattedDate;
            var olAppointmentItem = 1; //fixed for different properties of outlook object
            //EXPORT to OUTLOOK
            function ExportDataToOutlook(subject, body, date, duration, reminder, allday) {
                //var duration = 120; //number of minutes (duration in Outlook being in minutes)
                //SetTimeForAppointment();//time of appoinment was fixed 
                try {
                    var objOutlook = new ActiveXObject("Outlook.Application");
                }
                catch (e) {
                    radalert("Outlook needs to be installed on the machine for data to export.");
                    return false;
                }

                var objAppointment = objOutlook.CreateItem(olAppointmentItem);

                objAppointment.Subject = subject;
                objAppointment.AllDayEvent = allday;
                objAppointment.Body = body;
                objAppointment.Start = date;
                objAppointment.Duration = duration;
                objAppointment.ReminderMinutesBeforeStart = 15;
                objAppointment.ReminderSet = reminder;
                //objAppointment.Location = '';

                //var objRecurrence = objAppointment.GetRecurrencePattern
                //objRecurrence.RecurrenceType = olRecursDaily
                //objRecurrence.PatternStartDate = #2/15/2008#
                //objRecurrence.PatternEndDate = #3/3/2008#

                objAppointment.Save();


                //alert("An appointment was exported successfully to your Outlook calendar in todays date.");
                return true;
            }

            function SetTimeForAppointment() {
                var currentDate = new Date();
                var month = currentDate.getMonth();
                var day = currentDate.getDate();
                var year = currentDate.getFullYear();
                formattedDate = (month + 1) + "/" + day + "/" + year + " 08:00AM";
            }

        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server" EnableViewState="true">  
    <div class="calendar-activity-2">
        <div class="no-float-menu">
            <telerik:RadToolBar ID="RadToolbarActivity" runat="server" Width="100%" CausesValidation="false">
                <Items>
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonSave" runat="server" Text="" Value="Save" ToolTip="Save Activity"
                        SkinID="RadToolBarButtonSave" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonUpdate" runat="server" Text="Update" Value="Update" ToolTip="Update Activity"
                        SkinID="RadToolBarButtonSave" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonDelete" runat="server" Value="Delete" SkinID="RadToolBarButtonDelete"
                        ToolTip="Delete Activity" CommandName="Delete" />                        
                    <telerik:RadToolBarButton ID="RadToolBarButtonAddTime" runat="server" Text="Add Time" Value="AddTime" SkinID="RadToolBarButtonNewTime"
                        ToolTip="Click to add time" CommandName="AddTime" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonExport" runat="server" Text="ICS"
                        Value="Export" ToolTip="Export Activity" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonEditSeries" runat="server" Text="Edit Series"
                        Value="EditSeries" ToolTip="Edit Series" />
                </Items>
            </telerik:RadToolBar>
        </div>
        <div style="padding: 4px 0px 0px 0px;">
            <telerik:RadTabStrip ID="RadTabStripActivity" runat="server" CausesValidation="false" MultiPageID="RadMultiPageActivity" Style="z-index: 1000;" Width="100%">
                <Tabs>
                    <telerik:RadTab Text="General" Value="General" PageViewID="RadPageViewGeneral">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Employee" Value="Employee" PageViewID="RadPageViewEmployee">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Details" Value="Details" PageViewID="RadPageViewDetails">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Recurrence" Value="Recurrence" PageViewID="RadPageViewRecurrence">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
        </div>
        <telerik:RadMultiPage ID="RadMultiPageActivity" runat="server" SelectedIndex="0">
            <telerik:RadPageView ID="RadPageViewGeneral" runat="server">
                <div style="padding: 4px 0px 0px 0px;">
                    <div class="code-description-container-2">
                        <div class="code-description-label">
                            Type:
                        </div>
                        <div class="code-description-description">
                            <telerik:RadComboBox ID="RadComboBoxType" runat="server" AutoPostBack="true" Width="200px" SkinID="RadComboBoxStandard">
                                <Items>
                                    <telerik:RadComboBoxItem Text="[Please select]" Value="" />
                                    <telerik:RadComboBoxItem Text="Call" Value="C" />
                                    <telerik:RadComboBoxItem Text="Meeting" Value="M" />
                                    <telerik:RadComboBoxItem Text="To Do" Value="TD" />
                                    <telerik:RadComboBoxItem Text="Email" Value="EL" />
                                    <telerik:RadComboBoxItem Text="Holiday" Value="H" />
                                    <telerik:RadComboBoxItem Text="Appointment (Personal)" Value="A" />
                                </Items>
                            </telerik:RadComboBox>
                        </div>
                    </div>
                    <div id="DivCategory" runat="server" class="code-description-container-2">
                        <div class="code-description-label">
                            Category:
                        </div>
                        <div class="code-description-description">
                            <telerik:RadComboBox ID="ddlCategory" runat="server" AutoPostBack="true" Width="200px" SkinID="RadComboBoxStandard">
                            </telerik:RadComboBox>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Subject:
                        </div>
                        <div class="code-description-description">
                            <asp:TextBox ID="txtSubject" runat="server" Width="385px" CssClass="RequiredInput" SkinID="TextBoxStandard"></asp:TextBox>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Start:
                        </div>
                        <div class="code-description-description">
                            <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server"
                                SkinID="RadDatePickerStandard" AutoPostBack="True">
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
                            <telerik:RadTimePicker ID="radTimePickerStart" runat="server" AutoPostBack="True"
                                TimeView-HeaderText="Time Selector" TimeView-RenderDirection="Vertical">
                                <TimeView ID="TimeView1" runat="server" StartTime="05:00:00" EndTime="22:31:00" Interval="00:30:00"
                                    Columns="6" HeaderText="Time Selector">
                                    <HeaderTemplate>
                                        Time Selector
                                    </HeaderTemplate>
                                </TimeView>
                            </telerik:RadTimePicker>
                            <asp:CheckBox ID="chkAllDay" runat="server" Text='All Day' AutoPostBack="true" />
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            End:
                        </div>
                        <div class="code-description-description">
                            <telerik:RadDatePicker ID="RadDatePickerEndDate" runat="server" AutoPostBack="True"
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
                            <telerik:RadTimePicker ID="radTimePickerEnd" runat="server" TimeView-HeaderText="Time Selector" AutoPostBack="True" TimeView-RenderDirection="Vertical">
                                <TimeView ID="TimeView2" runat="server" StartTime="05:00:00" EndTime="22:31:00" Interval="00:30:00"
                                    Columns="6" HeaderText="Time Selector">
                                    <HeaderTemplate>
                                        Time Selector
                                    </HeaderTemplate>
                                </TimeView>
                            </telerik:RadTimePicker>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Priority:
                        </div>
                        <div class="code-description-description">
                            <telerik:RadComboBox ID="RadComboBoxPriority" runat="server" AutoPostBack="False" SkinID="RadComboBoxStandard"
                                Width="100px">
                            </telerik:RadComboBox>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Reminder:
                        </div>
                        <div class="code-description-description">
                            <telerik:RadComboBox runat="server" ID="ReminderDropDown" Width="120px" SkinID="RadComboBoxStandard">
                                <Items>
                                    <telerik:RadComboBoxItem Text="None" Value=""></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="0 minutes" Value="0"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="5 minute" Value="5"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="10 minutes" Value="10"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="15 minutes" Value="10"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="30 minutes" Value="30"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="1 hour" Value="60"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="5 hour" Value="60"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="10 hour" Value="60"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="1 day" Value="1440"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="2 days" Value="2880"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="3 days" Value="4320"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="4 days" Value="5760"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="1 week" Value="10080"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="2 weeks" Value="20160"></telerik:RadComboBoxItem>
                                </Items>
                            </telerik:RadComboBox>
                        </div>
                    </div>
                    <asp:Panel ID="PanelCDP" runat="server">
                        <div class="code-description-container">
                            <div class="code-description-label">
                                <asp:HyperLink ID="HlClient" runat="server" href="" TabIndex="-1">Client:</asp:HyperLink>
                            </div>
                            <div class="code-description-code">
                                <asp:TextBox ID="txtClient" runat="server" MaxLength="6" TabIndex="1" Text=""
                                    SkinID="TextBoxCodeSmall"></asp:TextBox>
                            </div>
                            <div class="code-description-description">
                                <span style="float: left; margin: 5px 6px 0 0;">
                                    <asp:TextBox ID="TxtClientDesc" runat="server" ReadOnly="true" TabIndex="-1"
                                    Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </span>
                                
                                <asp:Button ID="ButtonClear" runat="server" Text="Clear" />
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                <asp:HyperLink ID="HlDivision" runat="server" href="" TabIndex="-1">Division:</asp:HyperLink>
                            </div>
                            <div class="code-description-code">
                                <asp:TextBox ID="txtDivision" runat="server" MaxLength="6" TabIndex="2" Text=""
                                    SkinID="TextBoxCodeSmall"></asp:TextBox>
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TxtDivisionDesc" runat="server" ReadOnly="true" TabIndex="-1"
                                    Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                <asp:HyperLink ID="HlProduct" runat="server" href="" TabIndex="-1">Product:</asp:HyperLink>
                            </div>
                            <div class="code-description-code">
                                <asp:TextBox ID="txtProduct" runat="server" MaxLength="6" TabIndex="2" Text=""
                                    SkinID="TextBoxCodeSmall"></asp:TextBox>
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TxtProductDesc" runat="server" ReadOnly="true" TabIndex="-1" Text=""
                                    SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                <asp:HyperLink ID="HlJob" runat="server" TabIndex="-1" href="">Job:</asp:HyperLink>
                            </div>
                            <div class="code-description-code">
                                <asp:TextBox ID="txtJob" runat="server" MaxLength="6"
                                    TabIndex="4" Text="" SkinID="TextBoxCodeSmall" AutoPostBack="true"></asp:TextBox>
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TxtJobDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                    Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                <asp:HyperLink ID="HlComponent" runat="server" TabIndex="-1" href="">Component:</asp:HyperLink>
                            </div>
                            <div class="code-description-code">
                                <asp:TextBox ID="txtComponent" runat="server" MaxLength="3"
                                    TabIndex="5" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TxtJobCompDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                    Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                <asp:HyperLink ID="HlContact" runat="server" TabIndex="-1" href="">Contact:</asp:HyperLink>
                                <asp:HiddenField ID="HfContactCodeID" runat="server" />
                            </div>
                            <div class="code-description-code">
                                <asp:TextBox ID="TextBoxContact" runat="server" MaxLength="6"
                                    TabIndex="6" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TxtContactDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                    Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                <asp:ImageButton ID="ImageButtonContacts" runat="server" SkinID="ImageButtonClientContact" CommandName="GoToContacts" />
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                Function:
                            </div>
                            <div class="code-description-description">
                                <telerik:RadComboBox ID="ddlFunction" runat="server" AutoPostBack="false" SkinID="RadComboBoxStandard">
                                </telerik:RadComboBox>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageViewEmployee" runat="server">
                <div id="DivEmployees" runat="server" style="width: 99%;" class="code-description-container-2">
                    <div style="width: 50%;display:inline-block;float:left;">
                        Available Employees<br />
                        <telerik:RadListBox ID="RadListBoxEmps_AvailableEmps" runat="server" Width="100%"
                            Height="180" TransferToID="RadListBoxEmps_EmpsInActivity" SelectionMode="Multiple"
                            AllowTransfer="True" AutoPostBackOnTransfer="true" AllowReorder="False" EnableDragAndDrop="true">
                        </telerik:RadListBox>
                        <div style="width:92%;margin:8px 0px 0px 0px;">
                            <fieldset>
                                <legend>Filter by</legend>
                                <asp:RadioButtonList ID="RblAvailableEmployeesFilter" runat="server" RepeatDirection="Horizontal"  AutoPostBack="true" RepeatLayout="Flow">
                                    <asp:ListItem Text="Role" Value="role"></asp:ListItem>
                                    <asp:ListItem Text="Alert Group" Value="alert_group"></asp:ListItem>
                                    <asp:ListItem Text="None" Value="none"></asp:ListItem>
                                </asp:RadioButtonList>
                                <br />
                                <telerik:RadComboBox ID="DropAvailableEmployeesFilter" runat="server" Enabled="false" Width="90%" AutoPostBack="true" SkinID="RadComboBoxStandard">
                                </telerik:RadComboBox>
                            </fieldset>
                        </div>
                    </div>
                    <div style="width: 50%; display: inline-block;float:right;">
                        Current Employees Assigned<br />
                        <telerik:RadListBox ID="RadListBoxEmps_EmpsInActivity" runat="server" Width="100%"
                            Height="180" SelectionMode="Multiple" AllowReorder="False" AutoPostBackOnReorder="true"
                            EnableDragAndDrop="true">
                        </telerik:RadListBox>
                    </div>
                </div>
                <div id="DivContacts" runat="server" style="width: 99%;" class="code-description-container-2">
                    Contact(s):
                    <telerik:RadGrid ID="RadGridContacts" runat="server" AutoGenerateColumns="False"
                        GridLines="None" EnableEmbeddedSkins="True" Width="99%">
                        <MasterTableView DataKeyNames="CDP_CONTACT_ID,CONT_EXTENTION,CONT_FAX_EXTENTION,EMAIL_ADDRESS">
                            <Columns>
                                <telerik:GridBoundColumn DataField="description" HeaderText="Contact" UniqueName="column1">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="code2" HeaderText="" UniqueName="column2" Visible="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CDP_CONTACT_ID" HeaderText="" UniqueName="column4"
                                    Visible="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CONT_TELEPHONE" HeaderText="Telephone" UniqueName="column55">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CELL_PHONE" HeaderText="Cell Phone" UniqueName="column6" Visible="false">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CONT_FAX" HeaderText="Fax" UniqueName="column7" Visible="false">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EMAIL_ADDRESS" HeaderText="Email Address" UniqueName="column8" Visible="false">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CONT_EXTENTION" HeaderText="" UniqueName="column9"
                                    ItemStyle-HorizontalAlign="Left" Visible="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CONT_FAX_EXTENTION" HeaderText="" UniqueName="column10"
                                    ItemStyle-HorizontalAlign="Left" Visible="false">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <RowIndicatorColumn Visible="False">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Resizable="False" Visible="False">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <EditFormSettings>
                                <PopUpSettings ScrollBars="None" />
                            </EditFormSettings>
                        </MasterTableView>
                    </telerik:RadGrid>
                    <br />
                    <asp:CheckBox id="CheckboxCreateApptContact" runat="server" Text="Create appointment for contact(s)." Visible="false"/>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageViewDetails" runat="server">
                <div class="code-description-container-2">
                    <h4>Description</h4>
                    <telerik:RadEditor ID="RadEditorDescription" runat="server" Width="95%" Height="275" NewLineBr="true" NewLineMode="Br" OnClientLoad="RadEditorOnClientLoad" StripFormattingOptions="MsWord"
                        ContentAreaCssFile="~/CSS/RadEditorContentArea.min.css" ToolsFile="~/RadEditorToolbars.xml" OnClientCommandExecuted="RadEditorOnClientCommandExecuted"
                        EditModes="Design">
                            <CssFiles>
                                <telerik:EditorCssFile Value="~/CSS/RadEditorContentArea.css" />
                            </CssFiles>
                    </telerik:RadEditor>
                    <script type="text/javascript">
                        Telerik.Web.UI.Editor.Utils.containsHtmlAtClipboard = function (event) {
                            return false;
                        }
                    </script>
                </div>
                <div id="DivAttachments" runat="server" class="code-description-container-2">
                    <h4>Attachments</h4>
                    <telerik:RadGrid ID="RadGridAttachments" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" GridLines="None" PageSize="25" EnableEmbeddedSkins="True"
                        Width="100%">
                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" Height="20px">
                        </PagerStyle>
                        <MasterTableView DataKeyNames="ATTACHMENT_ID" NoDetailRecordsText="No attachments">
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <ItemTemplate>
                                        <div id="DivDocumentType" runat="server" class="icon-background background-color-sidebar">
                                            <asp:LinkButton ID="LinkButtonDocumentType" runat="server" Text="" ToolTip="" CommandName="Download" CssClass="icon-text" CommandArgument='<%# Eval("DOCUMENT_ID")%>'></asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Filename" SortExpression="FILENAME" UniqueName="FilenameTemplateColumn">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButtonDownload" runat="server"></asp:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="FILE_SIZE_KB" SortExpression="FILE_SIZE" HeaderText="Size"
                                    UniqueName="SizeColumn">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="55" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="55" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="55" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="USER_NAME" SortExpression="USER_NAME" HeaderText="Added By"
                                    UniqueName="column1">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="GENERATED_DATE" DataFormatString="{0:g}" HeaderText="Added"
                                    SortExpression="GENERATED_DATE" UniqueName="column2">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="140" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="140" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="140" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="USER_CODE" UniqueName="column11" Visible="False">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Private" UniqueName="colChkPrivate" SortExpression="PRIVATE_FLAG">
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="20" />
                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="20" />
                                    <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="20" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkPrivate" runat="server" Checked='<%# SetCheckBox(Eval("PRIVATE_FLAG")) %>'
                                            Enabled="false" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAddComments">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <ItemTemplate>
                                        <div id="DivAddComments" runat="server" class="icon-background background-color-sidebar">
                                            <asp:ImageButton ID="ImageButtonAddComments" runat="server" SkinID="ImageButtonCommentWhite" ToolTip="Click to add comment to this document" Visible="false" />
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <ItemTemplate>
                                        <div class="icon-background background-color-delete">
                                            <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite" ToolTip="Click to delete this row" CommandName="DeleteRow" />
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
                        </MasterTableView>
                    </telerik:RadGrid>
                    <h4>Add Attachments</h4>
                        Add new files:<asp:LinkButton ID="LinkButtonHelpFileSelection" runat="server" OnClientClick="OpenRadWindow('Selecting files for upload','Help_FileSelection.aspx');return false;" ToolTip="Click for upload instructions">?</asp:LinkButton>
                        <telerik:RadAsyncUpload ID="RadUploadAlertDocuments" runat="server" AutoAddFileInputs="true" PostbackTriggers="RadToolbarActivity"
                            MultipleFileSelection="Automatic" InputSize="70">
                        </telerik:RadAsyncUpload>
                        <asp:Label ID="LabelFileSizeLimitMessage" runat="server" Text="" style="font-size:smaller;"></asp:Label>
                        <br />
                        <asp:CheckBox ID="ChkUploadToRepository" runat="server" Text="Upload to Document Manager" />
                        <br />
                        To link an already uploaded file from the Document Manager, select the file(s) from
                        the list box below.<asp:ImageButton ID="ImageButtonRefreshLinkDocumentsListBox" runat="server" SkinID="ImageButtonRefresh" CausesValidation="false" />
                        <br />
                        <br />
                        <telerik:RadListBox ID="RadListBoxLinkableDocuments" runat="server" Width="500" SelectionMode="Multiple" Height="100"></telerik:RadListBox>                            
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageViewRecurrence" runat="server">
                <telerik:RadSchedulerRecurrenceEditor runat="server" ID="RadSchedulerRecurrenceEditor1" RecurrenceRuleText="">
                </telerik:RadSchedulerRecurrenceEditor>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </div>
</asp:Content>
