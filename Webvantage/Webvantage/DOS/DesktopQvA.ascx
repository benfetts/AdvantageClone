<%@ Control AutoEventWireup="false" CodeBehind="DesktopQvA.ascx.vb" Inherits="Webvantage.DesktopQvA"
    Language="vb" %>

<telerik:RadScriptBlock ID="sbControl_ScriptBlock" runat="server">
    <script type="text/javascript">

        function RadGridQVAColumnPreferences(event) {

            var grid = $find("<%= RadGridQVA.ClientID%>");

            grid.get_masterTableView().get_columns()[0].showHeaderMenu(event, 10, 10);

        }

    </script>
    <script type="text/javascript">

        function RadToolbarQvAOnClientButtonClicking(sender, args) {

            var commandName = args.get_item().get_commandName();

        }

    </script>
</telerik:RadScriptBlock>
<div class="no-float-menu">
    <telerik:RadToolBar ID="RadToolbarQvA" runat="server" AutoPostBack="true"
        OnClientButtonClicking="RadToolbarQvAOnClientButtonClicking" Width="100%">
        <Items>
            <telerik:RadToolBarButton CausesValidation="true"
                CommandName="QvA" CheckOnClick="true" Group="QvAView" Value="QvA"
                Hidden="False" ToolTip="QvA" Text="QvA" />
            <telerik:RadToolBarButton IsSeparator="true" Value="SeparatorMain" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonFilter" Text="" CausesValidation="true"
                Group="QvAView" CommandName="FilterView" Value="FilterView" Hidden="False"
                CheckOnClick="true" ToolTip="Filter" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonPrint" CausesValidation="true"
                CommandName="Print" Value="Print" Hidden="False" ToolTip="Print" />
            <telerik:RadToolBarButton ImageUrl="~/Images/document_pdf.png" CausesValidation="true" Visible="false"
                CommandName="ExportPDF" Value="ExportPDF" Hidden="true" ToolTip="Export to a PDF file" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonExportExcel" CausesValidation="true"
                CommandName="ExportExcel" Value="ExportExcel" Hidden="False" ToolTip="Export to a spreadsheet" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark" ToolTip="Bookmark" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" CausesValidation="true"
                CommandName="Refresh" Value="Refresh" Hidden="False" ToolTip="Refresh" />
            <telerik:RadToolBarButton IsSeparator="true" Value="Separator2" />
            <telerik:RadToolBarButton CausesValidation="true" Text="Campaign Estimate" ID="RadToolbarButtonGroupCampaign" AllowSelfUnCheck="true" CheckOnClick="true"
                CommandName="GroupJob" Value="GroupJobCampaign" Hidden="False" ToolTip="Campaign Estimate" />
            <telerik:RadToolBarButton CausesValidation="true" Text="Campaign Master Job Estimate" ID="RadToolbarButtonGroupCampaignMaster" AllowSelfUnCheck="true" CheckOnClick="true"
                CommandName="GroupJob" Value="GroupJobCampaignMaster" Hidden="False" ToolTip="Campaign Master Job Estimate" />
            <telerik:RadToolBarButton CausesValidation="true" Text="Campaign Job" ID="RadToolbarButtonGroupCampaignJob" AllowSelfUnCheck="true" CheckOnClick="true"
                CommandName="GroupJob" Value="GroupJobCampaignJob" Hidden="False" ToolTip="Campaign Job" />
            <telerik:RadToolBarButton CausesValidation="true" Text="Job" ID="RadToolbarButtonGroupJob" AllowSelfUnCheck="true" CheckOnClick="true"
                CommandName="GroupJob" Value="GroupJob" Hidden="False" ToolTip="Job" />
        </Items>
    </telerik:RadToolBar>
</div>


<div class="telerik-aqua-body">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="ViewMain" runat="server">
        
            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <telerik:RadGrid ID="RadGridQVA" runat="server" AllowPaging="True" AllowSorting="True"
                            enableajax="True" Width="100%" AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True"
                            EnableHeaderContextMenu="true" AllowFilteringByColumn="true">
                            <GroupingSettings CaseSensitive="false" />
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" ></PagerStyle>
                            <ExportSettings IgnorePaging="true" Excel-Format="Html"></ExportSettings>
                            <MasterTableView AllowMultiColumnSorting="true" DataKeyNames="JobAndComp,Job, JOB_NUMBER, JOB_COMPONENT_NBR, CMP_ID" AllowFilteringByColumn="True">
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="colDetails" HeaderAbbr="FIXED" AllowFiltering="false">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <HeaderTemplate>
                                            <asp:ImageButton ID="ImageButtonColumnPreferences" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon"
                                                ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" OnClientClick="RadGridQVAColumnPreferences(event);" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="HfJobNumber" runat="server" Value='<%# Eval("JOB_NUMBER") %>' />
                                            <asp:HiddenField ID="HfJobCompNumber" runat="server" Value='<%# Eval("JOB_COMPONENT_NBR") %>' />
                                            <asp:HiddenField ID="HfCampaignID" runat="server" Value='<%# Eval("CMP_ID")%>' />
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImageButtonViewDetails" runat="server" ImageAlign="AbsMiddle" CssClass="icon-image"
                                                    SkinID="ImageButtonViewWhite" ToolTip="View QvA Summary" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="CDP" HeaderText="Client" UniqueName="column" FilterControlWidth="100"
                                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="110" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="110" />
                                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="110" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CMP_NAME" HeaderText="Campaign" UniqueName="columnCampaign" FilterControlWidth="100"
                                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false" >
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"/>
                                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"  />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn DataField="JobAndComp" HeaderText="Project" UniqueName="GridTemplateColumnProject" Visible="true"
                                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                        SortExpression="JobAndComp" HeaderAbbr="FIXED">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="ViewLinkButton" runat="server" Visible="true" ToolTip='<%# Eval("JobAndComp") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="FIRST_USE_DATE" HeaderText="Due Date" DataFormatString="{0:d}"
                                        UniqueName="DueDate" FilterControlWidth="75"
                                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TRAFFIC_STATUS" HeaderText="Status"
                                        UniqueName="Status" FilterControlWidth="75"
                                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="QUOTED_HRS" HeaderText="Quote Qty/Hrs" DataFormatString="{0:#,##0.00}" FilterControlWidth="75"
                                        CurrentFilterFunction="GreaterThan" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                        UniqueName="QuoteHours">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ACTUAL_HRS" HeaderText="Actual Qty/Hrs" DataFormatString="{0:#,##0.00}" FilterControlWidth="75"
                                        CurrentFilterFunction="GreaterThan" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                        UniqueName="ActualHours">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Quoted" HeaderText="Quote Total" DataFormatString="{0:#,##0.00}" FilterControlWidth="75"
                                        CurrentFilterFunction="GreaterThan" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                        UniqueName="column3">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Actual" HeaderText="Actual Total" DataFormatString="{0:#,##0.00}" FilterControlWidth="75"
                                        CurrentFilterFunction="GreaterThan" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                        UniqueName="column4">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PERCENT_QUOTED" HeaderText="% of Quote (Hours)" FilterControlWidth="75"
                                        CurrentFilterFunction="GreaterThan" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                        DataFormatString="{0:#,##0.00}%" UniqueName="PercentOfQuoted">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PERCENT_QUOTED_AMT" HeaderText="% of Quote (Amount)" FilterControlWidth="75"
                                        CurrentFilterFunction="GreaterThan" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                        DataFormatString="{0:#,##0.00}%" UniqueName="PercentOfQuotedAmt">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn UniqueName="Flag" HeaderAbbr="FIXED" AllowFiltering="false">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-sidebar" runat="server" id="DivFlagColor">
                                                <asp:Image ID="ImageFlag" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/signal_flag.png" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="Job" UniqueName="column5" Visible="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="JobComp" UniqueName="column6" Visible="false">
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <ExpandCollapseColumn Visible="False">
                                    <HeaderStyle Width="19px" />
                                </ExpandCollapseColumn>
                                <RowIndicatorColumn Visible="False">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                            </MasterTableView>
                            <ClientSettings>
                                <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" />
                            </ClientSettings>
                        </telerik:RadGrid>
                        <asp:Label ID="LblMSG" runat="server" CssClass="CssRequired" Visible="True" Text="&nbsp;"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="ViewFilter" runat="server">
            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr style="display: none;">
                    <td>&nbsp;
                    </td>
                    <td align="right" valign="middle">
                        <asp:Button ID="BtnBack" runat="server" CausesValidation="False" Text="Back" />&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="Center" colspan="2">
                        <table align="center" width="100%" cellspacing="0">
                            <tr>
                                <td align="center" valign="top">
                                    <table id="Table3" align="center" cellpadding="2" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="left" colspan="2" class="sub-header sub-header-color">&nbsp;&nbsp;QvA Filter Options
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="Label6" runat="server" CssClass="warning" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="TrAeOfficeSalesClassManagerFilters" runat="server">
                                            <td colspan="2">
                                                <table align="center" border="0" cellpadding="0" cellspacing="2" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 25%">Account Executive<br />
                                                            <telerik:RadListBox ID="LbAEs" runat="server" TabIndex="10" AutoPostBack="True" Height="100px"
                                                                SelectionMode="Multiple" Width="100%">
                                                            </telerik:RadListBox>
                                                        </td>
                                                        <td style="width: 25%">Office<br />
                                                            <telerik:RadListBox ID="LBOffice" runat="server" AutoPostBack="True" Height="100px"
                                                                SelectionMode="Multiple" TabIndex="51" Width="100%">
                                                            </telerik:RadListBox>
                                                        </td>
                                                        <td style="width: 25%">Sales Class<br />
                                                            <telerik:RadListBox ID="LBSC" runat="server" AutoPostBack="False" Height="100px"
                                                                SelectionMode="Multiple" TabIndex="52" Width="100%">
                                                            </telerik:RadListBox>
                                                        </td>
                                                        <td style="width: 25%">
                                                            <asp:Label ID="LabelManager" runat="server" Text="Manager"></asp:Label><br />
                                                            <telerik:RadListBox ID="RadListBoxManager" runat="server" TabIndex="10" AutoPostBack="True"
                                                                Height="100px" SelectionMode="Multiple" Width="100%">
                                                            </telerik:RadListBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <table align="center" border="0" cellpadding="0" cellspacing="2" width="100%">
                                                    <tr>
                                                        <td align="left">&nbsp;
                                                            <asp:RadioButtonList ID="RblSelectionLevel" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                                                RepeatLayout="Table" TabIndex="59">
                                                                <asp:ListItem Value="CDPC">All</asp:ListItem>
                                                                <asp:ListItem Value="CLIENT">Client</asp:ListItem>
                                                                <asp:ListItem Value="DIVISION">Division</asp:ListItem>
                                                                <asp:ListItem Value="PRODUCT">Product</asp:ListItem>
                                                                <asp:ListItem Value="CAMPAIGN">Campaign</asp:ListItem>
                                                                <asp:ListItem Value="JOB">Job</asp:ListItem>
                                                                <asp:ListItem Value="COMP">Component</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="LitCDPCSelections" runat="server"></asp:Literal>
                                                            <telerik:RadListBox ID="LbCDPCSelections" runat="server" AutoPostBack="False" Height="185px"
                                                                SelectionMode="Multiple" TabIndex="60" Width="525px">
                                                            </telerik:RadListBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td align="left">
                                                <table align="center" border="0" cellpadding="0" cellspacing="2" width="100%">
                                                    <tr>
                                                        <td align="left" style="vertical-align: middle; height: 40px">&nbsp;Type:
                                                            <telerik:RadComboBox ID="ddQvAType" runat="server" AutoPostBack="false" EnableViewState="true" Width="200">
                                                                <Items>
                                                                    <telerik:RadComboBoxItem Value="False" Text="All"></telerik:RadComboBoxItem>
                                                                    <telerik:RadComboBoxItem Value="True" Text="Time Only"></telerik:RadComboBoxItem>
                                                                </Items>
                                                            </telerik:RadComboBox>
                                                            &nbsp;&nbsp;&nbsp; Threshold:
                                                            <telerik:RadNumericTextBox ID="RadNumericTextBoxThreshold" runat="server" Value="100" MaxValue="100"
                                                                Type="Number" MaxLength="3" MinValue="0" Width="35px">
                                                                <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                                                <EnabledStyle HorizontalAlign="Right" />
                                                            </telerik:RadNumericTextBox>
                                                            %
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">

                                                            <asp:CheckBox ID="cbClosedJobs" runat="server" TabIndex="70" Text="Include Closed Jobs" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="cbExcludeClientApproval" runat="server" Text="Exclude jobs without Client Approval" /><br />
                                                            <asp:CheckBox ID="cbExcludeInternalApproval" runat="server" Text="Exclude jobs without Internal Approval" /><br />
                                                            <asp:CheckBox ID="cbAllProcessing" runat="server" Text="Include 'All Processing' jobs only" /><br />
                                                            <asp:CheckBox ID="cbSalesTax" runat="server" Text="Include Sales Tax" /><br />
                                                            <asp:CheckBox ID="CbLimitToMyJobs" runat="server" Text="Limit to my Jobs" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: middle; height: 40px">
                                                            <asp:Label ID="Label7" runat="server" Text="Search:" />&nbsp;
                                                            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="BtnSave" runat="server" CausesValidation="False" Text="Save" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</div>

