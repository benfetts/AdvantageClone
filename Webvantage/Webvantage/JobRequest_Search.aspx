<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="JobRequest_Search.aspx.vb" Inherits="Webvantage.JobRequest_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
    </telerik:RadScriptBlock>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <style>
       .two-col-leftcolumn {
            float: left;
            margin-top: 0px;
            width: 250px;
            border: 0px solid transparent;
            /* border-radius: 6px; */
        }
   </style>
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolBar_JobRequestSearch" runat="server" AutoPostBack="True" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonFind" Text="Search" Value="Search" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonNew" ToolTip="New" Value="New" Visible="false" />
                <telerik:RadToolBarButton IsSeparator="true" Visible="false" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonClear" Text="Clear" Value="Clear" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    
    <div class="telerik-aqua-body">
        <div id="DivFilter" runat="server" class="two-col-leftcolumn">
            <div class="" style="">
                <div class="filter-card">
                    <div class="card-content" style="margin-bottom: 20px;">
                        <asp:Panel ID="PnlSearch" runat="server" DefaultButton="BtnSearch">
                            <div>
                                <div>
                                    <div id="TrClient" runat="server">
                                        <div>
                                            <asp:HyperLink ID="HyperLink_Client" runat="server" href="" TabIndex="-1">Client:</asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TextBox_Client" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrDivision" runat="server">
                                        <div>
                                            <asp:HyperLink ID="HyperLink_Division" runat="server" href="" TabIndex="-1">Division:</asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TextBox_Division" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrProduct" runat="server">
                                        <div>
                                            <asp:HyperLink ID="HyperLink_Product" runat="server" href="" TabIndex="-1">Product:</asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TextBox_Product" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="DivFromDate" runat="server">
                                        <div>
                                            <span>From Date:</span>
                                        </div>
                                        <div>
                                            <telerik:RadDatePicker ID="RadDatePickerStart" runat="server" SkinID="RadDatePickerStandard">
                                                <DateInput DateFormat="d" EmptyMessage="">
                                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                </DateInput>
                                                <Calendar ID="CalendarIssueFromDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                    <SpecialDays>
                                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                        </telerik:RadCalendarDay>
                                                    </SpecialDays>
                                                </Calendar>
                                            </telerik:RadDatePicker>
                                        </div>
                                    </div>
                                    <div id="DivToDate" runat="server">
                                        <div>
                                            <span>To Date:</span>
                                        </div>
                                        <div>
                                            <telerik:RadDatePicker ID="RadDatePickerDue" runat="server" SkinID="RadDatePickerStandard">
                                                <DateInput DateFormat="d" EmptyMessage="">
                                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                </DateInput>
                                                <Calendar ID="CalendarIssueToDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                    <SpecialDays>
                                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                        </telerik:RadCalendarDay>
                                                    </SpecialDays>
                                                </Calendar>
                                            </telerik:RadDatePicker>
                                        </div>
                                    </div>
                                    <div id="DivExcludeCOmpleted" runat="server">
                                        <div>                                            
                                            &nbsp;
                                        </div>
                                        <div>
                                            <asp:CheckBox ID="CheckboxExclude" runat="server" TextAlign="Right" Text="Exclude Completed Job Requests" />
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
            <telerik:RadGrid ID="RadGrid_JobRequestSearch" runat="server" AllowPaging="True" AllowSorting="False"
                AutoGenerateColumns="False" GridLines="None" GroupingSettings-GroupByFieldsSeparator="  "
                PageSize="10">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
                <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
                <ClientSettings AllowColumnsReorder="False">
                </ClientSettings>
                <GroupingSettings GroupByFieldsSeparator=" " />
                <MasterTableView HorizontalAlign="Left" DataKeyNames="JOB_VER_HDR_ID, JOB_NUMBER, JOB_COMPONENT_NBR">
                    <Columns>
                        <telerik:GridTemplateColumn>
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImageButton_Detail" runat="server" CommandName="Detail" SkinID="ImageButtonViewWhite" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Job Request Description">
                            <ItemTemplate>
                                <asp:Label ID="Label_JobRequestDescription" runat="server" Text='<%#Eval("JOB_VER_DESC").ToString%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Job Request Template">
                            <ItemTemplate>
                                <asp:Label ID="Label_Description" runat="server" Text='<%#Eval("JV_TMPLT_DESC").ToString%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Client">
                            <ItemTemplate>
                                <asp:Label ID="Label_Client" runat="server" Text='<%#Eval("CL_NAME").ToString%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Division">
                            <ItemTemplate>
                                <asp:Label ID="Label_Division" runat="server" Text='<%#Eval("DIV_NAME").ToString%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Product">
                            <ItemTemplate>
                                <asp:Label ID="Label_Product" runat="server" Text='<%#Eval("PRD_DESCRIPTION").ToString%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Width="55" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Width="55" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Date Created">
                            <ItemTemplate>
                                <asp:Label ID="Label_Campaign" runat="server" Text='<%#Eval("CREATE_DATE")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Width="55" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Width="55" />
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
</asp:Content>
