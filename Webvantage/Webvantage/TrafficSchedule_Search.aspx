<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="TrafficSchedule_Search.aspx.vb" Inherits="Webvantage.TrafficSchedule_Search"
    Title="Find Project Schedule" %>

<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div >
        <telerik:RadToolBar ID="RadToolbarSearch" runat="server" AutoPostBack="true" Width="100%"
            TabIndex="-1">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonSearch" SkinID="RadToolBarButtonFind"
                    Text="Search" Value="Search" ToolTip="Search" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonNew" SkinID="RadToolBarButtonNew" ToolTip="New"
                    Text="New" Value="New" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonClear" SkinID="RadToolBarButtonClear" Text="Clear"
                    Value="Clear" ToolTip="Clear" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark"
                    ToolTip="Bookmark" Visible="false" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div >
    </div>
    <div class="wrapper">
        <div id="DivFilter" runat="server" class="two-col-leftcolumn">
            <div class="" style="">
                <div class="filter-card">
                    <div class="card-content" style="margin-bottom: 20px;">
                        <asp:Panel ID="PnlSearch" runat="server" DefaultButton="BtnSearch">
                            <div>
                                <div>
                                    <div id="TrSelect" runat="server">
                                        <div>
                                            <span>View:</span>
                                        </div>
                                        <div>
                                            <asp:RadioButtonList ID="RblSelect" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                                                AutoPostBack="true">
                                                <asp:ListItem Text="Single" Value="single"></asp:ListItem>
                                                <asp:ListItem Text="Multi" Value="multi" Selected="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div id="TrOffice" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlOffice" runat="server" href="" TabIndex="-1">Office:</asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtOffice" runat="server" SkinID="TextBoxCodeLarge" MaxLength="4" TabIndex="1"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrClient" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlClient" runat="server" TabIndex="-1" NavigateUrl="~/Blank.htm"><span>Client:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtClient" runat="server" SkinID="TextBoxCodeLarge" TabIndex="1" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrDivision" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlDivision" runat="server" TabIndex="-1" NavigateUrl="~/Blank.htm"><span>Division:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtDivision" runat="server" SkinID="TextBoxCodeLarge" TabIndex="2" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrProduct" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlProduct" runat="server" TabIndex="-1" NavigateUrl="~/Blank.htm"><span>Product:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtProduct" runat="server" SkinID="TextBoxCodeLarge" TabIndex="3" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrSalesClass" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlSalesClass" runat="server" href="" TabIndex="-1"><span>Sales Class:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtSalesClass" runat="server" SkinID="TextBoxCodeLarge" TabIndex="4" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="Tr4" runat="server">
                                        <div>
                                            <asp:HyperLink ID="HlCampaign" runat="server" TabIndex="-1" NavigateUrl="~/Blank.htm"><span>Campaign:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TxtCampaign" runat="server" MaxLength="6" TabIndex="5" Text="" SkinID="TextBoxCodeLarge"></asp:TextBox>
                                            <asp:HiddenField ID="hfCampaignID" runat="server" />
                                        </div>
                                    </div>
                                    <div id="TrJobNum" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlJob" runat="server" TabIndex="-1" NavigateUrl="~/Blank.htm"><span>Job:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtJob" runat="server" SkinID="TextBoxCodeLarge" TabIndex="6" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrJobComp" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlComponent" runat="server" TabIndex="-1" NavigateUrl="~/Blank.htm"><span>Component:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtComponent" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6" TabIndex="7"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="Tr2" runat="server">
                                        <div>
                                            <asp:HyperLink ID="HlAccountExecutive" runat="server" TabIndex="-1" NavigateUrl="~/Blank.htm"><span>AE:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TxtAccountExecutive" runat="server" MaxLength="6" TabIndex="8" Text=""
                                                SkinID="TextBoxCodeLarge"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrJobType" runat="server">
                                        <div>
                                            <asp:HyperLink ID="HyperLinkJobType" runat="server" TabIndex="-1" NavigateUrl="~/Blank.htm"><span>Job Type:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TextBoxJobType" runat="server" MaxLength="10" TabIndex="9" Text=""
                                                SkinID="TextBoxCodeLarge"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="Tr0" runat="server">
                                        <div>
                                            &nbsp;
                                        </div>
                                        <div>
                                            &nbsp;
                                        </div>
                                    </div>
                                    <div id="Tr1" runat="server">
                                        <div>
                                            <asp:HyperLink ID="HlManager" runat="server" TabIndex="-1" NavigateUrl="~/Blank.htm"></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TxtManager" runat="server" MaxLength="6" TabIndex="10" Text="" SkinID="TextBoxCodeLarge"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="Tr3" runat="server">
                                        <div>
                                            <asp:CheckBox ID="ChkExcludeCompletedSchedules" runat="server" Checked="True" TabIndex="11"
                                                Text="" />Exclude Completed Schedules
                                        </div>
                                    </div>
                                    <div id="Tr14" runat="server">
                                        <div>
                                            <asp:CheckBox ID="CheckBoxOnlyScheduleTemplates" runat="server" Checked="False" TabIndex="12"
                                                Text="" />Only Schedule Templates
                                        </div>
                                    </div>
                                    <div id="Tr13" runat="server">
                                        <div>
                                            &nbsp;
                                        </div>
                                        <div>
                                            &nbsp;
                                        </div>
                                    </div>
                                    <div id="Tr5" runat="server">
                                        <div>
                                            <span>Phase:</span>
                                        </div>
                                        <div>
                                            <telerik:RadComboBox ID="DropPhaseFilter" runat="server" TabIndex="13" AppendDataBoundItems="true" SkinID="RadComboBoxStandard"
                                                DropDownWidth="175" Width="137" Visible="true">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="[No Filter]" Value="no_filter"></telerik:RadComboBoxItem>
                                                </Items>
                                            </telerik:RadComboBox>
                                        </div>
                                    </div>
                                    <div id="Tr7" runat="server">
                                        <div>
                                            <asp:HyperLink ID="HlRole" runat="server" TabIndex="-1" NavigateUrl="~/Blank.htm"><span>Role:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TxtRole" runat="server" MaxLength="6" TabIndex="14" Text="" SkinID="TextBoxCodeLarge"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="Tr9" runat="server">
                                        <div>
                                            <asp:HyperLink ID="HlTask" runat="server" TabIndex="-1" NavigateUrl="~/Blank.htm"><span>Task:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TxtTaskCode" runat="server" MaxLength="10" TabIndex="15" Text=""
                                                SkinID="TextBoxCodeLarge"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="Tr11" runat="server">
                                        <div>
                                            <asp:HyperLink ID="HlEmployee" runat="server" TabIndex="-1" NavigateUrl="~/Blank.htm"><span>Employee:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TxtEmployee" runat="server" MaxLength="6" TabIndex="16" Text=""
                                                SkinID="TextBoxCodeLarge"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="Tr12" runat="server">
                                        <div>
                                            <span>Date Cutoff:</span>
                                        </div>
                                        <div>
                                            <telerik:RadDatePicker ID="RadDatePickerDateCutoff" runat="server" SkinID="RadDatePickerStandard">
                                                <DateInput DateFormat="d" EmptyMessage="Start Date" TabIndex="17">
                                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                </DateInput>
                                                <Calendar ID="CalendarStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                    <SpecialDays>
                                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                        </telerik:RadCalendarDay>
                                                    </SpecialDays>
                                                </Calendar>
                                            </telerik:RadDatePicker>
                                        </div>
                                    </div>
                                    <div id="Tr6" runat="server">
                                        <div>
                                            <asp:CheckBox ID="ChkOnlyPendingTasks" runat="server" TabIndex="18" Text="" />Only
                                                            Pending Tasks
                                        </div>
                                    </div>
                                    <div id="Tr8" runat="server">
                                        <div>
                                            <asp:CheckBox ID="ChkExcludeProjectedTasks" runat="server" TabIndex="19" Text="" />Exclude
                                                            Projected Tasks
                                        </div>
                                    </div>
                                    <div id="Tr10" runat="server">
                                        <div>
                                            <asp:CheckBox ID="ChkIncludeCompletedTasks" runat="server" Checked="True" TabIndex="20"
                                                Text="" />Include Completed Tasks
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="display: none;">
                                <asp:Button ID="BtnSearch" runat="server" Text="Search" Visible="true" TabIndex="-1" />
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
        <div id="DivGrid" runat="server" class="two-col-rightcolumn">
            <telerik:RadGrid ID="RadGridProjectScheduleSearch" runat="server" AllowSorting="True"
                AutoGenerateColumns="False" GridLines="None" GroupingSettings-GroupByFieldsSeparator="  "
                AllowPaging="true" PageSize="15" EnableEmbeddedSkins="True">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
                <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
                <ClientSettings AllowColumnsReorder="False">
                </ClientSettings>
                <GroupingSettings GroupByFieldsSeparator=" " />
                <MasterTableView HorizontalAlign="Left" DataKeyNames="JOB_NUMBER,JOB_COMPONENT_NBR">
                    <Columns>
                        <telerik:GridTemplateColumn>
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="butDetail" runat="server" CommandName="Detail" SkinID="ImageButtonViewWhite" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn Visible="false">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImgBtnPrint" runat="server" CommandName="Print" SkinID="ImageButtonPrintWhite" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Job Number" SortExpression="JOB_NUMBER">
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Width="70px" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Width="70px" />
                            <ItemTemplate>
                                <asp:Label ID="lblJobNum" runat="server" Text='<%#Eval("JOB_NUMBER")%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Job Description" SortExpression="JOB_DESC">
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lblJobDesc" runat="server" Text='<%#Eval("JOB_DESC")%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Component Number" SortExpression="JOB_COMPONENT_NBR">
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Width="70px" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Width="70px" />
                            <ItemTemplate>
                                <asp:Label ID="lblJobComp" runat="server" Text='<%#Eval("JOB_COMPONENT_NBR")%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Component Description" SortExpression="JOB_COMP_DESC">
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lblJobCompDesc" runat="server" Text='<%#Eval("JOB_COMP_DESC")%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Client" SortExpression="CL_CODE">
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Width="55" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Width="55" />
                            <ItemTemplate>
                                <asp:Label ID="lblClientCode" runat="server" Text='<%#Eval("CL_CODE")%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Division" SortExpression="DIV_CODE">
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Width="55" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Width="55" />
                            <ItemTemplate>
                                <asp:Label ID="lblDivisionCode" runat="server" Text='<%#Eval("DIV_CODE")%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Product" SortExpression="PRD_CODE">
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Width="55" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Width="55" />
                            <ItemTemplate>
                                <asp:Label ID="lblProductCode" runat="server" Text='<%#Eval("PRD_CODE")%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                    <FilterItemStyle VerticalAlign="Top" Wrap="False" />
                    <ExpandCollapseColumn Visible="False">
                        <HeaderStyle Width="19px" />
                    </ExpandCollapseColumn>
                    <RowIndicatorColumn Visible="False">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </div>
    <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
</asp:Content>
