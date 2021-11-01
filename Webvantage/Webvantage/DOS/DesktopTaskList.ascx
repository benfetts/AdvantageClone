<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopTaskList.ascx.vb"
    Inherits="Webvantage.DesktopTaskList" %>
<%@ Register Src="~/UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>
<telerik:RadScriptBlock ID="sbControl_ScriptBlock" runat="server">
    <script type="text/javascript">

        function RadGridTaskListColumnPreferences(event) {

            var grid = $find("<%= TasksRG.ClientID %>");

            grid.get_masterTableView().get_columns()[0].showHeaderMenu(event, 10, 10);

        };
        // used in document_list2
        function SetTaskDocumentIcon(input, hasDocuments) {
            try {
                var div = $(input).parent('div');
                if (hasDocuments === true) {
                    $(input).attr('title', 'Task Documents');
                    if (!$(div).hasClass('standard-green'))
                        $(div).addClass('standard-green');
                } else {
                    $(input).attr('title', 'No Task Documents');
                    if (!$(div).hasClass('standard-green'))
                        $(div).removeClass('standard-green');
                }
            } catch (err) {

            }
        };
        
        function setGridHeight() {
            try {
                var win = GetRadWindow();
                if (win) {
                    var grid = $find("<%=TasksRG.ClientID %>");
                    if (grid) {
                        var fixedHeaderHeight = (grid.GridHeaderDiv ? $(grid.GridHeaderDiv).height() : 0) * 2;
                        var windowHeight = $(window).height() - 55 - fixedHeaderHeight;
                        console.log('windowHeight', windowHeight);
                        console.log('fixedHeaderHeight', fixedHeaderHeight);

                        var scrollArea = grid.GridDataDiv;
                        if (scrollArea) {
                            scrollArea.style.height = windowHeight + "px";
                        }
                    }
                }
            } catch (e) {
            }
        }
        $(document).ready(function () {
            setGridHeight();
            $(window).resize(function () {
                setGridHeight();
            });
        });

    </script>
</telerik:RadScriptBlock>
<div class="telerik-aqua-body" style="margin-top: 5px!important;">
    <div class="DO-ButtonHeader">
        <div style="float: left; width: 50%; text-align: left;vertical-align: middle;" >
            <asp:ImageButton ID="butPrint" runat="server" SkinID="ImageButtonPrint" />
            <asp:ImageButton ID="butExport" runat="server" SkinID="ImageButtonExportExcel" ToolTip="Export to Excel" />
            <asp:ImageButton ID="ImageButtonFilter" runat="server" SkinID="ImageButtonFilter" />
            <asp:ImageButton ID="ImageButtonBookmark" runat="server" ToolTip="Bookmarks" SkinID="ImageButtonBookmark"/>
             <asp:ImageButton ID="butRefresh" runat="server"
                SkinID="ImageButtonRefresh" ToolTip="Refresh" />
            <asp:ImageButton ID="ImgBtnTempComplete" runat="server" CssClass="icon-image"
                ImageUrl="~/Images/Icons/Grey/256/clipboard_checks.png" ToolTip="Mark Temp Complete to Completed" />
        </div>
        <div style="float: right; width: 50%; text-align: right;">
           
        </div>
    </div>
    <div class="DO-Container">
        <ew:CollapsablePanel ID="CollapsablePanelFilter" runat="server" SkinID="CollapsablePanelDesktopObjectFilter" Collapsed="true" Visible="false">
            <div style="font-size: larger; margin: -7px 0px 0px 0px !important;">
                Filter
            </div>
            <table id="TableFilterTaskList" border="0" cellspacing="2" cellpadding="0">
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server">Due Date Range:</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label9" runat="server">Start Due Date:</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label10" runat="server">End Due Date:</asp:Label>
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadComboBox ID="ddDatePicker" runat="server" AutoPostBack="True" EnableViewState="true" width="220">
                            <Items>
                                <telerik:RadComboBoxItem Value="0" Text="Today"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="1" Text="This Week"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="2" Text="Two Weeks"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="3" Text="One Month"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="4" Text="[Select]"></telerik:RadComboBoxItem>
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td align="left" valign="top">
                        <table border="0" cellspacing="0" cellpadding="0" width="185px">
                            <tr>
                                <td width="185px" height="25px" valign="top">
                                    <telerik:RadDatePicker ID="RadDatePickerStart" runat="server" AutoPostBack="True"
                                        DateInput-BackColor="#FFFFE0" SkinID="RadDatePickerStandard">
                                        <DateInput AutoPostBack="True" CssClass="RequiredInput">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table border="0" cellspacing="0" cellpadding="0" width="185px">
                            <tr>
                                <td width="185px" height="25px" valign="top">
                                    <telerik:RadDatePicker ID="RadDatePickerDue" runat="server" AutoPostBack="True" DateInput-BackColor="#FFFFE0"
                                        SkinID="RadDatePickerStandard">
                                        <DateInput AutoPostBack="True" CssClass="RequiredInput" Width="80px">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server">Office:</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server">Manager:</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server">Task Status:</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LabelAcctExec" runat="server">Account Executive:</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadComboBox ID="ddOffice" runat="server" AutoPostBack="true" width="220">
                        </telerik:RadComboBox>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="ddManager" runat="server" AutoPostBack="true" width="220">
                        </telerik:RadComboBox>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="ddType" runat="server" AutoPostBack="true" EnableViewState="true" width="210">
                            <Items>
                                <telerik:RadComboBoxItem Value="" Text="All"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem  Value="P" Text="Projected"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="A" Text="Active"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="H" Text="High Priority"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="L"  Text="Low Priority"></telerik:RadComboBoxItem>
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="RadComboBoxAccountExec" runat="server" AutoPostBack="true" width="220"></telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server">Employee:</asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server">Role:</asp:Label>
                    </td>
                    <td>cf
                        <asp:Label ID="Label2" runat="server">Search:</asp:Label>
                    </td>
                    <td align="right" valign="middle">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadComboBox ID="ddEmployee" runat="server" AutoPostBack="true" width="220">
                        </telerik:RadComboBox>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="ddRole" runat="server" AutoPostBack="true" width="220">
                        </telerik:RadComboBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                        <asp:ImageButton ID="imgbtnSearch" runat="server" SkinID="ImageButtonFind" ToolTip="Search" />
                    </td>
                    <td align="right" valign="middle">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:CheckBox ID="ChkOnlyMarkedComplete" runat="server" Text="Only Tasks Marked Temp Complete"
                            AutoPostBack="true" />&nbsp;&nbsp;
                        <asp:CheckBox ID="CheckBoxOnlyUnassigned" runat="server" Text="Only Unassigned Tasks"
                            AutoPostBack="true" />&nbsp;&nbsp;
                        <asp:CheckBox ID="CheckBoxExcludeUnassigned" runat="server" Text="Exclude Unassigned Tasks"
                            AutoPostBack="true" />
                    </td>
                </tr>
            </table>
        </ew:CollapsablePanel>
    <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
                <telerik:RadGrid ID="TasksRG" runat="server" AllowPaging="True" AllowSorting="True" AllowColumnResize="True"
                    AutoGenerateColumns="False" EnableHeaderContextMenu="True" GroupPanelPosition="Top"> 
                    <ClientSettings AllowRowsDragDrop="true">
                        <Resizing AllowColumnResize="true" />
                        <Scrolling AllowScroll="true" UseStaticHeaders="true" />
                        <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" />
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                    </ClientSettings>
                    <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                    <MasterTableView AllowMultiColumnSorting="True" Width="100%" DataKeyNames="JobNo, JobComp, SeqNo" >
                        <Columns>
                            <telerik:GridDragDropColumn HeaderStyle-Width="18px" Visible="true">
                                <HeaderStyle Width="18px" BorderColor="#e5e5e5" BorderStyle="Solid" BorderWidth="1px"></HeaderStyle>
                            </telerik:GridDragDropColumn>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderAbbr="FIXED">
                                <HeaderStyle CssClass="radgrid-icon-column" BorderColor="#e5e5e5" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <HeaderTemplate>
                                    <asp:ImageButton ID="ImageButtonColumnPreferences" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon"
                                        ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" OnClientClick="RadGridTaskListColumnPreferences(event);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonViewDetails" runat="server" ImageAlign="AbsMiddle" CssClass="icon-image" SkinID="ImageButtonViewWhite" ToolTip="View Task" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn1" HeaderText="Status">
                                <HeaderStyle CssClass="radgrid-icon-column" BorderColor="#e5e5e5" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivPriorityColor" runat="server" class="icon-background background-color-sidebar">
                                        <asp:Image ID="ImagePriority" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/progress_bar.png" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="Documents" HeaderText="">
                                <HeaderStyle CssClass="radgrid-icon-column" BorderStyle="Solid" BorderWidth="1px" BorderColor="#e5e5e5"/>
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivDocumentsColor" runat="server" class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonDocuments" runat="server" CommandName="Documents" ToolTip="Documents" ImageUrl="~/Images/Icons/White/256/documents_empty.png" CssClass="icon-image" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="Employee" HeaderText="Employee" UniqueName="column1"
                                HeaderAbbr="FIXED">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-employee-name-column" BorderStyle="Solid" BorderWidth="1px" BorderColor="#e5e5e5"/>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-employee-name-column" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-employee-name-column" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CDP" HeaderText="Client" UniqueName="column2">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" BorderStyle="Solid" BorderWidth="1px" BorderColor="#e5e5e5"/>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn DataField="JobNo" HeaderText="Project" UniqueName="column3"
                                SortExpression="JobNo">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" BorderStyle="Solid" BorderWidth="1px" BorderColor="#e5e5e5"/>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="ViewLinkButton" runat="server" Visible="true"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="JOB_COMP" HeaderText="Job/Comp" UniqueName="column36">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" BorderStyle="Solid" BorderWidth="1px" BorderColor="#e5e5e5"/>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_DESC" HeaderText="Job Description" UniqueName="column34">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" BorderStyle="Solid" BorderWidth="1px" BorderColor="#e5e5e5"/>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_COMP_DESC" HeaderText="Comp Description" UniqueName="column35">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" BorderStyle="Solid" BorderWidth="1px" BorderColor="#e5e5e5"/>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Task" HeaderText="Task" UniqueName="column4">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" BorderStyle="Solid" BorderWidth="1px" BorderColor="#e5e5e5"/>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn DataField="FNC_COMMENTS" HeaderText="Task Comment" UniqueName="column31">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" BorderStyle="Solid" BorderWidth="1px" BorderColor="#e5e5e5"/>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemTemplate>
                                    <div style="min-width: 150px; margin: -2px 0px -2px 0px; max-height:70px; overflow: auto;min-height: 40px;">
                                        <%# If(IsDBNull(Eval("TaskComment")), "", Server.HtmlEncode(Eval("TaskComment")))%>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="HoursAllowed" HeaderText="Hours" UniqueName="column5">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="55" BorderStyle="Solid" BorderWidth="1px" BorderColor="#e5e5e5"/>
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="55" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="55" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="StartDate" HeaderText="Start" UniqueName="column6" DataFormatString="{0:d}">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="95" BorderStyle="Solid" BorderWidth="1px" BorderColor="#e5e5e5"/>
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="95" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="95" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DueDate" HeaderText="Due" UniqueName="column66" DataFormatString="{0:d}">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="95" BorderStyle="Solid" BorderWidth="1px" BorderColor="#e5e5e5"/>
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="95" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="95" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DueTime" HeaderText="Due By" UniqueName="column7">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="95" BorderColor="#e5e5e5" BorderStyle="Solid" BorderWidth="1px" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="95" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="95" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TempCompleteDate" Visible="false" HeaderText="Temp Complete"
                                UniqueName="ColTempComplete" HeaderAbbr="FIXED">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="95" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="95" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="95" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn2" HeaderAbbr="FIXED">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar" runat="server" id="DivFlagColor">
                                        <asp:Image ID="ImageFlag" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/signal_flag.png" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="EmpCode" UniqueName="column8" Visible="false"
                                HeaderAbbr="FIXED">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JobNo" UniqueName="column9" Visible="false" HeaderAbbr="FIXED">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JobComp" UniqueName="column10" Visible="false"
                                HeaderAbbr="FIXED">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SeqNo" UniqueName="column11" Visible="false"
                                HeaderAbbr="FIXED">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TASK_STATUS" UniqueName="column12" Visible="false"
                                HeaderAbbr="FIXED">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                        </Columns>
                        <ExpandCollapseColumn Visible="False">
                            <HeaderStyle Width="19px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                    </MasterTableView>
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom"></PagerStyle>
                </telerik:RadGrid>
    <%--        </ContentTemplate>
        </asp:UpdatePanel>--%>
    </div>
</div>

<asp:HiddenField ID="HiddenFieldWindowName" Value="" runat="server" />
<telerik:RadScriptBlock ID="ScriptBlockFooter" runat="server">
    <script type="text/javascript">

        function getRadWindowName() {
            try {
                var oWnd = GetRadWindow();
                var id = oWnd.get_name();
                document.getElementById('<%= HiddenFieldWindowName.ClientID %>').value = id;
            } catch (err) {
                var abc = null;
            }
        }

        getRadWindowName();

    </script>
</telerik:RadScriptBlock>
<custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
