<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Campaign.aspx.vb" Inherits="Webvantage.CampaignPage"
    MasterPageFile="~/ChildPage.Master" %>

<asp:Content ID="ContentCampaign" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadScriptBlock ID="RadScriptBlockSub" runat="server">
        <script type="text/javascript">
            function JsOnClientButtonClicking(sender, args) {
                var commandName = args.get_item().get_commandName();
                if (commandName == "Delete") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                }
                if (commandName == "WvPermaLink") {
                    <%=Me.WebvantageLink%>
                    args.set_cancel(true);
                }
                if (commandName == "CpPermaLink") {
                    <%=Me.ClientPortalLink%>
                    args.set_cancel(true);
                }
            }
        </script>
    </telerik:RadScriptBlock>
    <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
        <telerik:RadToolBar ID="RadToolbarCampaign" runat="server" AutoPostBack="True" Width="100%" OnClientButtonClicking="JsOnClientButtonClicking">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSave" SkinID="RadToolBarButtonSave" Text="" Value="Save"
                    ToolTip="Save" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonFind" Text="Search" Value="Search"
                    ToolTip="Search" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonNew" SkinID="RadToolBarButtonNew" Text="New" Value="New" ToolTip="Add New" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonDelete" SkinID="RadToolBarButtonDelete" CommandName="Delete" Text="Delete" Value="Delete" ToolTip="Delete" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonChangeCode" CommandName="ChangeCode" Text="Change Code" Value="ChangeCode" ToolTip="Change Code" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonUploadDocument" SkinID="RadToolBarButtonUpload" Text="Upload Documents" Value="Upload"
                    ToolTip="Upload a document" />
                <telerik:RadToolBarButton ID="RadToolBarButtonDocuments" SkinID="RadToolBarButtonDownload" Text="Documents" Value="ViewDocs"
                    ToolTip="View documents" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonAlerts" Text="" Value="Alerts" ToolTip="Alerts" Visible="false" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAlert" Text="" Value="NewAlert"
                    ToolTip="New Alert" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAssignment" CommandName="NewAlertAssignment" Text="" Value="NewAlertAssignment" ToolTip="New Assignment" />
                <telerik:RadToolBarButton Value="SendEmail" ToolTip="Send Email" Text="Send Email" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh"
                    ToolTip="Refresh" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark" ToolTip="Bookmark" />
                <telerik:RadToolBarButton ImageUrl="~/Images/Icons/Grey/256/magnifying_glass.png" Text="" Value="Detail" ToolTip="View Campaign Periods" />
                <telerik:RadToolBarSplitButton DropDownWidth="125">
                    <Buttons>
                        <telerik:RadToolBarButton Text="WV Link" Value="WvPermaLink" CommandName="WvPermaLink" ToolTip="Create Webvantage link for use in other systems" Visible="True" />
                        <telerik:RadToolBarButton Text="CP Link" Value="CpPermaLink" CommandName="CpPermaLink" ToolTip="Create Client Portal link for use in other systems" Visible="True" />
                    </Buttons>
                </telerik:RadToolBarSplitButton>
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>

    <div class="telerik-aqua-body">
     <ew:CollapsablePanel ID="CollapsablePanelHeader" runat="server"
            TitleText="Campaign Information">
            <table align="left" border="0" cellpadding="2" cellspacing="0" width="100%">
                <tr>
                    <td colspan="2" style="height: 10px">
                        <asp:TextBox ID="txtCmp_ID" runat="server" Visible="false" TabIndex="-1" SkinID="TextBoxStandard"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 30%; text-align: right">
                        <asp:LinkButton ID="hlOffice" runat="server" CausesValidation="False" TabIndex="-1">Office:</asp:LinkButton>
                    </td>
                    <td align="left" style="width: 70%">&nbsp;&nbsp;
                                    <asp:TextBox ID="txtOffice" runat="server" SkinID="TextBoxCodeSmall" MaxLength="4" TabIndex="10"></asp:TextBox>
                        <asp:TextBox ID="txtOfficeDesc" runat="server" SkinID="TextBoxCodeSingleLineDescription" ReadOnly="True" TabIndex="-1"></asp:TextBox>
                        &nbsp;<asp:Label ID="InvalidOffice" CssClass="warning" Visible="false" Text="Invalid Office"
                            runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;

                    </td>
                    <td>
                        <asp:CheckBox ID="cbCloseCmp" runat="server" Text="Close Campaign" TabIndex="50" />

                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>
                            <asp:LinkButton ID="LBtnClient" runat="server">Client:</asp:LinkButton>
                        </span>
                    </td>
                    <td align="left">&nbsp;&nbsp;
                                    <asp:TextBox ID="txtClient" runat="server" ReadOnly="True" MaxLength="6"
                                        SkinID="TextBoxCodeSmall" TabIndex="-1"></asp:TextBox>
                        <asp:TextBox ID="txtClientDesc" runat="server" ReadOnly="True"
                            SkinID="TextBoxCodeSingleLineDescription" TabIndex="-1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>
                            <asp:LinkButton ID="LBtnDivision" runat="server">Division:</asp:LinkButton>
                        </span>
                    </td>
                    <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="txtDivision" runat="server" ReadOnly="True" MaxLength="6"
                                        SkinID="TextBoxCodeSmall" TabIndex="-1"></asp:TextBox>
                        <asp:TextBox ID="txtDivisionDesc" runat="server" ReadOnly="True"
                            SkinID="TextBoxCodeSingleLineDescription" TabIndex="-1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>
                            <asp:LinkButton ID="LBtnProduct" runat="server">Product:</asp:LinkButton>
                        </span>
                    </td>
                    <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="txtProduct" runat="server" MaxLength="6" ReadOnly="True"
                                        SkinID="TextBoxCodeSmall" TabIndex="-1"></asp:TextBox>
                        <asp:TextBox ID="txtProductDesc" runat="server" ReadOnly="True"
                            SkinID="TextBoxCodeSingleLineDescription" TabIndex="-1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>
                            <asp:LinkButton ID="LBtnCampaign" runat="server">Campaign:</asp:LinkButton>
                        </span>
                    </td>
                    <td>&nbsp;&nbsp;
                        <asp:TextBox ID="txtCampaignCode" runat="server" MaxLength="6"
                            ReadOnly="True" SkinID="TextBoxCodeSmall" TabIndex="-1"></asp:TextBox>
                        <asp:TextBox ID="txtCampaignCodeDesc" runat="server" SkinID="TextBoxCodeSingleLineDescription" MaxLength="60"
                            TabIndex="20"></asp:TextBox>
                        &nbsp;<asp:Label ID="InvalidDescription" CssClass="warning" Visible="false" Text="Description required"
                            runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>
                            <asp:Label ID="LabelCampaign" runat="server">Campaign ID:</asp:Label>
                        </span>
                    </td>
                    <td>&nbsp;&nbsp;
                                    <asp:Label ID="LabelCampaignID" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>Alert Group:</span>
                    </td>
                    <td>&nbsp;&nbsp;
                                    <telerik:RadComboBox ID="DDAlertGrp" runat="server" TabIndex="30" SkinID="RadComboBoxStandard">
                                    </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="vertical-align: middle;">
                        <span>Campaign Type:</span>
                    </td>
                    <td style="vertical-align: top;">
                        <asp:RadioButtonList runat="server" ID="rbType" RepeatColumns="2" AutoPostBack="true"
                            TabIndex="40">
                            <asp:ListItem Text="Assigned to Jobs and Orders" Value="2"> 
                            </asp:ListItem>
                            <asp:ListItem Text="Overall" Value="1"> 
                            </asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox ID="TextBox1" runat="server" Visible="false" TabIndex="-1" SkinID="TextBoxStandard"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelHeaderDetails" runat="server"
            TitleText="Campaign Additional Information" Collapsed="true">
            <table align="left" border="0" cellpadding="2" cellspacing="0" width="80%">
                <tr>
                    <td colspan="2" style="height: 10px">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>Ad Number:</span>
                    </td>
                    <td>&nbsp;&nbsp;
                        <telerik:RadComboBox ID="RadComboBoxAdNumber" runat="server" TabIndex="30" DataTextField="Description" DataValueField="Number" Width="450px" SkinID="RadComboBoxStandard">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>Market:</span>
                    </td>
                    <td>&nbsp;&nbsp;
                        <telerik:RadComboBox ID="RadComboBoxMarket" runat="server" TabIndex="30" DataTextField="Description" DataValueField="Code" Width="450px" SkinID="RadComboBoxStandard">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>Job/Component:</span>
                    </td>
                    <td>&nbsp;&nbsp;
                        <telerik:RadComboBox ID="RadComboBoxJobComponent" runat="server" TabIndex="30" DataTextField="Description" DataValueField="JobComponent" Width="450px" SkinID="RadComboBoxStandard">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>Landing Page:</span>
                    </td>
                    <td>&nbsp;&nbsp;
                        <telerik:RadComboBox ID="RadComboBoxLandingPage" runat="server" DropDownAutoWidth="Enabled" TabIndex="30" DataTextField="WebsiteAddress" DataValueField="ID" Width="450px" AutoPostBack="true" SkinID="RadComboBoxStandard">
                            <HeaderTemplate>
                                <table style="width: 450px; text-align: left">     
                                    <tr>        
                                        <td style="width: 150px;">Description</td>
                                        <td style="width: 150px;">Website Type</td>
                                        <td style="width: 150px;">Website Name</td>
                                    </tr>   
                                </table> 
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table style="width: 450px; text-align: left">
                                    <tr>
                                        <td style="width: 150px;">
                                            <%# DataBinder.Eval(Container.DataItem, "WebsiteAddress") %>
                                        </td>
                                        <td style="width: 150px;">
                                            <%# DataBinder.Eval(Container.DataItem, "WebsiteTypeCode") %>
                                        </td>
                                        <td style="width: 150px;">
                                            <%# DataBinder.Eval(Container.DataItem, "WebsiteName") %>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>Website Name:</span>
                    </td>
                    <td>&nbsp;&nbsp;
                         <asp:TextBox ID="TextBoxWebsiteName" runat="server" ReadOnly="true" SkinID="TextBoxCodeSingleLineDescription" Width="440px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;
                    </td>
                </tr>
            </table>
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelCampaignDetail" runat="server"
            TitleText="Campaign Details" Collapsed="true">
            <table align="left" border="0" cellpadding="2" cellspacing="0" width="80%">
                <tr>
                    <td align="right" style="width: 30%">
                        <asp:TextBox ID="TextBox2" runat="server" Visible="false" TabIndex="-1" SkinID="TextBoxStandard"></asp:TextBox>
                    </td>
                    <td colspan="3" style="width: 70%">
                        <asp:TextBox ID="TextBox3" runat="server" Visible="false" TabIndex="-1" SkinID="TextBoxStandard"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>Total Billing:</span>
                    </td>
                    <td align="left">&nbsp;&nbsp;
                                    <asp:TextBox ID="txtTotalBilling" runat="server" MaxLength="16" Width="130px" TabIndex="60" SkinID="TextBoxStandard"></asp:TextBox>
                        &nbsp;<asp:Label ID="InvalidBilling" CssClass="warning" Visible="false" Text="Invalid Total Billing Amount"
                            runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        <span>Beginning Date:</span>
                    </td>
                    <td align="left">&nbsp;&nbsp;
                                    <telerik:RadDatePicker ID="RadDatePickerBeginningDate" runat="server" SkinID="RadDatePickerStandard">
                                        <DateInput DateFormat="d" EmptyMessage="">
                                            <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                        </DateInput>
                                        <Calendar ID="Calendar1" RangeMinDate="1900-01-01" runat="server" TabIndex="-1" RenderMode="Classic">
                                            <SpecialDays>
                                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                </telerik:RadCalendarDay>
                                            </SpecialDays>
                                        </Calendar>
                                    </telerik:RadDatePicker>
                        &nbsp;<asp:Label ID="InvalidBegDate" CssClass="warning" Visible="false" Text="Invalid Beginning Date"
                            runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>Total Income:</span>
                    </td>
                    <td align="left">&nbsp;&nbsp;
                                    <asp:TextBox ID="txtTotalIncome" runat="server" MaxLength="16" Width="130px" TabIndex="80" SkinID="TextBoxStandard"></asp:TextBox>
                        &nbsp;<asp:Label ID="InvalidIncome" CssClass="warning" Visible="false" Text="Invalid Total Income Amount"
                            runat="server"></asp:Label>
                    </td>
                    <td align="right">
                        <span>Ending Date:</span>
                    </td>
                    <td align="left">&nbsp;&nbsp;
                                    <telerik:RadDatePicker ID="RadDatePickerEndDate" runat="server" SkinID="RadDatePickerStandard">
                                        <DateInput DateFormat="d" EmptyMessage="" TabIndex="90">
                                            <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                        </DateInput>
                                        <Calendar ID="Calendar2" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                            <SpecialDays>
                                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                </telerik:RadCalendarDay>
                                            </SpecialDays>
                                        </Calendar>
                                    </telerik:RadDatePicker>
                        &nbsp;<asp:Label ID="InvalidEndDate" CssClass="warning" Visible="false" Text="Invalid Ending Date"
                            runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:TextBox ID="TextBox4" runat="server" Visible="false" TabIndex="-1" SkinID="TextBoxStandard"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelMediaTypes" runat="server"
            TitleText="Media Types" Collapsed="true">
            <table align="center" border="0" cellpadding="0" cellspacing="0" width="60%">
                <tr>
                    <td colspan="4" style="height: 10px">&nbsp;
                    </td>
                </tr>
                <tr valign="top" align="left">
                    <td>
                        <asp:CheckBox ID="cbMagazine" runat="server" Text="Magazine" TabIndex="100" />
                    </td>
                    <td>
                        <asp:CheckBox ID="cbNewspaper" runat="server" Text="Newspaper" TabIndex="110" />
                    </td>
                    <td>
                        <asp:CheckBox ID="cbInternet" runat="server" Text="Internet" TabIndex="120" />
                    </td>
                    <td>
                        <asp:CheckBox ID="cbOutOfHome" runat="server" Text="Out of Home" TabIndex="130" />
                    </td>
                </tr>
                <tr valign="top" align="left">
                    <td>
                        <asp:CheckBox ID="cbRadio" runat="server" Text="Radio" TabIndex="140" />
                    </td>
                    <td>
                        <asp:CheckBox ID="cbTV" runat="server" Text="Television" TabIndex="150" />
                    </td>
                    <td>
                        <asp:CheckBox ID="cbPrint" runat="server" Text="Print/Collateral" TabIndex="160" />
                    </td>
                    <td>
                        <asp:CheckBox ID="cbDirect" runat="server" Text="Direct Response" TabIndex="170" />
                    </td>
                </tr>
                <tr valign="middle" align="left">
                    <td colspan="4">
                        <asp:CheckBox ID="cbOther" runat="server" Text="Other" TabIndex="175" />
                        &nbsp;
                                    <asp:TextBox ID="txtOther" runat="server" MaxLength="30" Width="300px" TabIndex="180" SkinID="TextBoxStandard"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;
                    </td>
                </tr>
            </table>
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelComment" runat="server"
            Collapsed="true"
            TitleText="Comments">
            <table align="center" border="0" cellpadding="0" cellspacing="0" width="80%">
                <tr valign="top">
                    <td align="right" style="width: 75px">
                        <span>Comments:</span>
                    </td>
                    <td align="left">&nbsp;&nbsp;
                                    <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Width="600px" Height="75px" SkinID="TextBoxStandard"
                                        TabIndex="200"></asp:TextBox>&nbsp;
                    </td>
                </tr>
            </table>
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelMediaGrid" runat="server"
            TitleText="Associated Jobs and Media Orders">
            <telerik:RadGrid ID="radGridAllMedia" runat="server" AllowPaging="false" AllowSorting="False"
                AutoGenerateColumns="False" GridLines="None" PageSize="20">
                <MasterTableView HorizontalAlign="Left" DataKeyNames="ORDER_NBR,TYPE">
                    <GroupByExpressions>
                        <telerik:GridGroupByExpression>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="GROUP_DESC" HeaderText="Type" SortOrder="None" />
                            </SelectFields>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="SORT" />
                                <telerik:GridGroupByField FieldName="GROUP_DESC" SortOrder="None" />
                            </GroupByFields>
                        </telerik:GridGroupByExpression>
                    </GroupByExpressions>
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="Number">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderNum" runat="server" Text='<%#Eval("ORDER_NBR").ToString%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="ORDER_DESC" HeaderText="Description" UniqueName="ORDER_DESC">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="VN_CODE" HeaderText="Vendor" UniqueName="VN_CODE">
                            <HeaderStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="VN_NAME" HeaderText="Description" UniqueName="VN_NAME">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="SC_CODE" HeaderText="Sales Class" UniqueName="SC_CODE">
                            <HeaderStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="SC_DESCRIPTION" HeaderText="Description" UniqueName="SC_DESCRIPTION">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ORDER_DATE" HeaderText="Date" UniqueName="ORDER_DATE">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridBoundColumn>
                    </Columns>
                    <ExpandCollapseColumn Visible="False">
                        <HeaderStyle Width="19px" />
                    </ExpandCollapseColumn>
                    <RowIndicatorColumn Visible="False">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                </MasterTableView>
                <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
                <AlternatingItemStyle VerticalAlign="Top" />
                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                    <Selecting AllowRowSelect="True" />
                </ClientSettings>
            </telerik:RadGrid>
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelAttachMedia" runat="server"
            TitleText="Assign Jobs and Media Orders">
            <table align="center" border="0" cellpadding="0" cellspacing="0" width="80%">
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">Type:
                        <telerik:RadComboBox ID="ddGroups" runat="server" AutoPostBack="True" TabIndex="210" SkinID="RadComboBoxStandard"
                            Width="200">
                            <Items>
                                <telerik:RadComboBoxItem Text="Production" Value="Production"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Text="Internet" Value="Internet"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Text="Magazine" Value="Magazine"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Text="Newspaper" Value="Newspaper"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Text="Out of Home" Value="Outdoor"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Text="Radio" Value="Radio"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Text="TV" Value="TV"></telerik:RadComboBoxItem>
                            </Items>
                        </telerik:RadComboBox>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="900">
                            <tr>
                                <td valign="top">Available<br />
                                    <telerik:RadListBox ID="listAllow" runat="server" Height="250px" SelectionMode="Multiple"
                                        Width="430px">
                                    </telerik:RadListBox>
                                </td>
                                <td align="center" skinid="TextBoxCodeSmall">
                                    <asp:ImageButton ID="imgbtnAdd" runat="server" SkinID="ImageButtonAdd"
                                        CausesValidation="False" /><br />
                                    <br />
                                    <asp:ImageButton ID="imgbtnRemove" runat="server" SkinID="ImageButtonRemove"
                                        CausesValidation="False" />
                                </td>
                                <td valign="top">Assigned<br />
                                    <telerik:RadListBox ID="listNotAllowed" runat="server" Height="250px" SelectionMode="Multiple"
                                        Width="430px">
                                    </telerik:RadListBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
            </table>
        </ew:CollapsablePanel>
    </div>
   
</asp:Content>
