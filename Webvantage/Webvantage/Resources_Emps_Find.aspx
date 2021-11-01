<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Resources_Emps_Find.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.Resources_Emps_Find" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
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
                }
            }
            else
                args.set_cancel(true);
        }  
    </script>
    <script type="text/javascript">
        var grid;
        function GridCreated() {
            grid = this;
        }

        function RowSelected() {
            if (grid.MasterTableView.SelectedRows.length == grid.MasterTableView.Rows.length) {
                setCheckBox(true);
            }
        }

        function RowDeselected() {
            if (grid.MasterTableView.SelectedRows.length < grid.MasterTableView.Rows.length) {
                setCheckBox(false);
            }
        }

        function setCheckBox(toCheck) {
            var checkBoxID = document.getElementById("hf1").value;
            var checkBox = document.getElementById(checkBoxID);
            checkBox.checked = toCheck;
        } 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function RadToolbarEventTasksJsOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();
                if (comandName == "DeleteEventTasks") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                }
                if (comandName == "Print") {
                    window.open('Resources_Emps_QuickPrint.aspx?f=<%=Me.FromForm %>&j=<%=Me.JobNumber %>&jc=<%=Me.JobComponentNbr %>&cli=<%=Me.CliCode %>', 'PopEvtQuickPrint', 'screenX=150,left=150,screenY=150,top=150,width=900,height=800,scrollbars=yes,resizable=no,menubar=no,maximazable=no');
                    return false;
                }
            }
        </script>
    </telerik:RadScriptBlock>
    <telerik:RadToolBar ID="RadToolbarEventTasks" runat="server" AutoPostBack="True"
        OnClientButtonClicking="RadToolbarEventTasksJsOnClientButtonClicking" Width="100%">
        <Items>
            <telerik:RadToolBarButton Value="FilterByRole">
                <ItemTemplate>
                    Filter by role:&nbsp;
                    <telerik:RadComboBox ID="DropFilterRole" runat="server" AutoPostBack="true" AppendDataBoundItems="true">
                        <Items>
                            <telerik:RadComboBoxItem Text="[Please select]" Value="none"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="All Roles" Value=""></telerik:RadComboBoxItem>
                        </Items>
                    </telerik:RadComboBox>
                </ItemTemplate>
            </telerik:RadToolBarButton>
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton Text="Apply Recommended" Value="ApplyRecommended"
                ToolTip="Apply recommended employees to tasks" />
            <telerik:RadToolBarButton Enabled="True" Text="Clear Employees" Value="ClearEmployees"
                ToolTip="Clear all current employees" />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Text="" Value="Save"
                ToolTip="Save tasks" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonDelete" Value="DeleteEventTasks"
                ToolTip="Delete selected tasks" />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonPrint" Text="Print" Value="Print"
                ToolTip="Print" />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton Value="GroupBy">
                <ItemTemplate>
                    Group by:&nbsp;
                    <telerik:RadComboBox ID="DropGroupBy" runat="server" AutoPostBack="true">
                        <Items>
                            <telerik:RadComboBoxItem Text="[None]" Value="none"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="Event" Value="event"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="Task" Value="task"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="Date" Value="date"></telerik:RadComboBoxItem>
                        </Items>
                    </telerik:RadComboBox>
                </ItemTemplate>
            </telerik:RadToolBarButton>
        </Items>
    </telerik:RadToolBar>
    <table align="left" border="0" cellpadding="0" cellspacing="2" width="100%">
        <tr>
            <td align="center" valign="top">
                <asp:Label   ID="LblPleaseSelect" runat="server" Text="Please select a role filter."></asp:Label>
                <asp:Label   ID="LblMSG_Grid" runat="server" Text="" CssClass="CssRequired"></asp:Label>
                <telerik:RadGrid ID="RadGridAvailableEmployees" runat="server" AllowMultiRowSelection="True"
                    EnableEmbeddedSkins="True" AllowPaging="True" AllowSorting="true" AutoGenerateColumns="False"
                    EnableAJAX="False" PageSize="10" EnableAJAXLoadingTemplate="False" EnableOutsideScripts="true"
                    GroupingEnabled="true" ShowFooter="False" Visible="True" Width="100%">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="TopAndBottom" Height="20px">
                    </PagerStyle>
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
                        <ClientEvents OnRowSelecting="CancelNonInputSelect" OnRowDeselecting="CancelNonInputSelect" />
                    </ClientSettings>
                    <MasterTableView GroupsDefaultExpanded="true" NoMasterRecordsText="No records found"
                        Width="100%" HierarchyLoadMode="ServerOnDemand" HierarchyDefaultExpanded="False"
                        DataKeyNames="EVENT_TASK_ID,SEQ_NBR">
                        <Columns>
                            <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="10px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10px" />
                            </telerik:GridClientSelectColumn>
                            <telerik:GridBoundColumn DataField="EVENT_ID" HeaderText="Event ID" UniqueName="ColEVENT_ID"
                                Visible="True">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="20px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20px" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="20px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EVENT_TASK_DESC" HeaderText="Event Description"
                                UniqueName="ColEVENT_TASK_DESC" Visible="True">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="130px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="130px" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="130px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EVENT_TASK_ID" HeaderText="Task ID" UniqueName="ColEVENT_TASK_ID"
                                Visible="False">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="20px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20px" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="20px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TRF_ROLE_CODE" HeaderText="Role" UniqueName="ColTRF_ROLE_CODE"
                                Visible="True">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="20px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20px" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="20px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TRF_TASK_CODE" HeaderText="Task" UniqueName="ColTRF_TASK_CODE"
                                Visible="True">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="20px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20px" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="20px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TRF_TASK_DESC" HeaderText="Task Description"
                                UniqueName="ColTRF_TASK_DESC" Visible="True">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="130px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="130px" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="130px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="START_DATE" HeaderText="Task Start Date" UniqueName="ColSTART_DATE"
                                DataFormatString="{0:d}">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="80px" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80px" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="80px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="END_DATE" HeaderText="Task End Date" UniqueName="ColEND_DATE"
                                DataFormatString="{0:d}">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="80px" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80px" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="80px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DAY_OF_WEEK" HeaderText="Day" UniqueName="ColDAY_OF_WEEK"
                                SortExpression="DAY_OF_WEEK">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="30px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" Width="30px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="START_TIME" HeaderText="Start Time" UniqueName="ColSTART_TIME"
                                DataFormatString="{0:t}">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="80px" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80px" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="80px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="END_TIME" HeaderText="End Time" UniqueName="ColEND_TIME"
                                DataFormatString="{0:t}">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="80px" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80px" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="80px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EVENT_TASK_HOURS_ALLOWED" HeaderText="Hours<br/>Allowed"
                                UniqueName="ColEVENT_TASK_HOURS_ALLOWED" DataFormatString="{0:0.00}" SortExpression="EVENT_TASK_HOURS_ALLOWED">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="30px" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="30px" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="30px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EMP_CODE_FIRST_CHOICE" HeaderText="Recommended<br />Employee"
                                UniqueName="ColEMP_CODE_FIRST_CHOICE" SortExpression="EMP_CODE_FIRST_CHOICE">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="80px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="80px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn DataField="CURR_EMP_CODE" HeaderText="Current<br />Employee"
                                UniqueName="ColCURR_EMP_CODE">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="80px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="80px" />
                                <ItemTemplate>
                                    <asp:HiddenField ID="HfEVENT_TASK_ID" runat="server" Value='<%#Eval("EVENT_TASK_ID")%>' />
                                    <asp:HiddenField ID="HfEMP_CODE_FIRST_CHOICE" runat="server" Value='<%#Eval("EMP_CODE_FIRST_CHOICE")%>' />
                                    <asp:HiddenField ID="HfCURR_EMP" runat="server" Value="" />
                                    <asp:HiddenField ID="HfEVENT_TASK_DATE" runat="server" Value='<%#Eval("START_DATE")%>' />
                                    <asp:HiddenField ID="HfSTART_TIME" runat="server" Value='<%#Eval("START_TIME")%>' />
                                    <asp:HiddenField ID="HfEND_TIME" runat="server" Value='<%#Eval("END_TIME")%>' />
                                    <asp:HiddenField ID="HfTRF_TASK_CODE" runat="server" Value='<%#Eval("TRF_TASK_CODE")%>' />
                                    <asp:HiddenField ID="HfJOB_NUMBER" runat="server" Value='<%#Eval("JOB_NUMBER")%>' />
                                    <asp:HiddenField ID="HfJOB_COMPONENT_NBR" runat="server" Value='<%#Eval("JOB_COMPONENT_NBR")%>' />
                                    <asp:HiddenField ID="HfSEQ_NBR" runat="server" Value='<%#Eval("SEQ_NBR")%>' />
                                    <asp:HiddenField ID="HfEVENT_TASK_HOURS_ALLOWED" runat="server" Value='<%#Eval("EVENT_TASK_HOURS_ALLOWED")%>' />
                                    <asp:HiddenField ID="HfIS_EVENT_TASK" runat="server" Value='<%#Eval("IS_EVENT_TASK")%>' />
                                    <asp:TextBox ID="TxtCURR_EMP_CODE" runat="server" MaxLength="6" Text='<%# Eval("CURR_EMP_CODE") %>'
                                        ReadOnly="false" SkinID="TextBoxStandard"></asp:TextBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Display="True" UniqueName="ColSave">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <HeaderTemplate>
                                    &nbsp;
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImgBtnSave" runat="server" AlternateText="Save employee on this row only"
                                            ToolTip="Save employee on this row only" CommandName="SaveRowEmp"
                                            SkinID="ImageButtonSaveWhite" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <DetailTables>
                            <telerik:GridTableView AllowSorting="True" AutoGenerateColumns="false" Caption=""
                                DataKeyNames="EMP_CODE" HorizontalAlign="right" Name="OtherEmpsGrid" NoDetailRecordsText="No Records to Display"
                                ShowHeadersWhenNoRecords="false">
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Recommended" UniqueName="colIS_FIRST_CHOICE">
                                        <HeaderStyle CssClass="radgrid-icon-column" Width="50px" />
                                        <ItemStyle CssClass="radgrid-icon-column" Width="50px" />
                                        <FooterStyle CssClass="radgrid-icon-column" Width="50px" />
                                        <ItemTemplate>
                                            <div id="DivIsFirstChoice" runat="server" class="icon-background standard-green">
                                                <asp:Image ID="ImageIsFirstChoice" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                            </div>
                                            <asp:HiddenField ID="HfIS_FIRST_CHOICE" runat="server" Value='<%#Eval("IS_FIRST_CHOICE")%>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="EMP_CODE" HeaderText="Employee" UniqueName="ColEMP_CODE"
                                        SortExpression="EMP_CODE" Visible="True">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="115px" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="115px" />
                                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="115px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="HRS_AVAIL" HeaderText="Total Hours" UniqueName="ColHRS_AVAIL"
                                        SortExpression="HRS_AVAIL" DataFormatString="{0:0.00}" Visible="True">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="80px" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80px" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="80px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="HRS_ASSIGNED_TASK" HeaderText="Hours Assigned"
                                        UniqueName="ColHRS_ASSIGNED_TASK" SortExpression="HRS_ASSIGNED_TASK" DataFormatString="{0:0.00}"
                                        Visible="True">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="80px" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80px" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="80px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="HRS_BALANCE_AVAIL" HeaderText="Hours Available"
                                        SortExpression="HRS_BALANCE_AVAIL" DataFormatString="{0:0.00}" UniqueName="ColHRS_BALANCE_AVAIL"
                                        Visible="True">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="80px" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80px" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="80px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="EMP_START_TIME" HeaderText="From" UniqueName="ColEMP_START_TIME"
                                        SortExpression="EMP_START_TIME" Visible="True">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="115px" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="115px" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="115px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="EMP_END_TIME" HeaderText="To" UniqueName="ColEMP_END_TIME"
                                        SortExpression="EMP_END_TIME" Visible="True">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="115px" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="115px" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="115px" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="ColAddEmpToTask">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImgBtnAddEmpToTask" runat="server" CommandName="AddEmpToTask"
                                                    CommandArgument='<%#Eval("EMP_CODE")%>' SkinID="ImageButtonNewWhite" ToolTip="Add Employee to Task" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </telerik:GridTableView>
                        </DetailTables>
                        <RowIndicatorColumn Visible="False">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Resizable="False" Visible="False">
                            <HeaderStyle Width="20px" />
                            <ItemStyle Width="20px" />
                            <FooterStyle Width="20px" />
                        </ExpandCollapseColumn>
                    </MasterTableView>
                </telerik:RadGrid>
                <asp:HiddenField ID="HfExpandedItems" runat="server" />
                <asp:HiddenField ID="HfSingleExpandedItemIndex" runat="server" />
                <asp:HiddenField ID="HfSingleCollapsedItemIndex" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
