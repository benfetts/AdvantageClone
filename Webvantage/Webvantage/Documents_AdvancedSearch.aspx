<%@ Page AutoEventWireup="false" CodeBehind="Documents_AdvancedSearch.aspx.vb" Inherits="Webvantage.Documents_AdvancedSearch"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Advanced Document Search" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function RadGridDocumentsAdvancedSearchColumnHeaderMenu(ev) {
                var grid = $find("<%= RadGridDocumentsAdvancedSearch.ClientID %>");
                grid.get_masterTableView().get_columns()[0].showHeaderMenu(ev, 10, 10);
            }
            function onRequestStart(sender, args)
            {
                args.set_enableAjax(false);
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolbarAdvancedSearch" runat="server" AutoPostBack="true" Width="100%">
                    <Items>
                        <telerik:RadToolBarButton Value="RadToolBarButtonSearch">
                            <ItemTemplate>
                                <telerik:RadComboBox ID="RadComboBoxLevel" runat="server" DropDownAutoWidth="Enabled" AutoPostBack="true" Width="200" SkinID="RadComboBoxStandard">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="[All Levels]" Value="" Selected="true" />
                                    </Items>
                                </telerik:RadComboBox>
                                <asp:CheckBox ID="CheckBoxIncludeAttachments" runat="server" Text="Incl. Attachments" ToolTip="Include Alert and Assignment attachments (may cause duplicates in list)" />
                                &nbsp;&nbsp;
                                <telerik:RadComboBox ID="RadComboBoxCriteria" runat="server" Width="200" DropDownAutoWidth="Enabled" SkinID="RadComboBoxStandard">
                                    <Items>
                                    </Items>
                                </telerik:RadComboBox>
                                <telerik:RadTextBox ID="RadTextBoxSearchCriteria" runat="server" EmptyMessage="Search Text" Width="170"></telerik:RadTextBox>
                                <telerik:RadComboBox ID="RadComboBoxDocumentType" runat="server" DropDownAutoWidth="Enabled" Width="200" SkinID="RadComboBoxStandard">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="[All Types]" Value="0" Selected="true" />
                                    </Items>
                                </telerik:RadComboBox>
                                <telerik:RadComboBox ID="RadComboBoxLabel" runat="server" DropDownAutoWidth="Enabled" Width="200" SkinID="RadComboBoxStandard">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="[All Labels]" Value="0" Selected="true" />
                                    </Items>
                                </telerik:RadComboBox>
                            </ItemTemplate>
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonFind" Value="Search" CommandName="Search" ToolTip="Search for documents" />
                        <telerik:RadToolBarButton Value="RadToolBarButtonSearchSeparator" CommandName="RadToolBarButtonSearchSeparator" IsSeparator="true" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonClear" Value="Clear" CommandName="Clear" ToolTip="Clear/reset search" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonExportExcel" Value="ExportToExcel" ToolTip="Export to Excel" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark" ToolTip="Bookmark" Visible="false" />
                    </Items>
                </telerik:RadToolBar>
    </div>        
    <div class="telerik-aqua-body">
        <telerik:RadGrid ID="RadGridDocumentsAdvancedSearch" runat="server" AllowFilteringByColumn="true" AllowPaging="True" AllowSorting="True"
            EnableHeaderContextMenu="true" AutoGenerateColumns="False" EnableAJAX="false" GridLines="none" PageSize="10" Width="100%"  Ex>
            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
            <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
            <ClientSettings AllowColumnsReorder="False" EnablePostBackOnRowClick="False">
                <Selecting AllowRowSelect="False" />
                <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" />
            </ClientSettings>
            <ExportSettings Excel-Format="Html" FileName="Allocation" IgnorePaging="true" OpenInNewWindow="true" ExportOnlyData="true">
            </ExportSettings>
            <GroupingSettings GroupByFieldsSeparator=" " CaseSensitive="false" />
            <MasterTableView DataKeyNames="DOCUMENT_ID">
                <Columns>
                    <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="GridTemplateColumnLabels" Visible="true" HeaderAbbr="FIXED" AllowFiltering="false">
                        <HeaderStyle CssClass="radgrid-icon-column" />
                        <ItemStyle CssClass="radgrid-icon-column" />
                        <FooterStyle CssClass="radgrid-icon-column" />
                        <HeaderTemplate>
                            <asp:ImageButton ID="ImageButtonColumnPreferences" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon" CausesValidation="false"
                                ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" OnClientClick="RadGridDocumentsAdvancedSearchColumnHeaderMenu(event);" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div id="DivDocumentLabels" runat="server" class="icon-background background-color-sidebar" title="View and edit document details">
                                <asp:ImageButton ID="ImageButtonEditDetails" runat="server" SkinID="ImageButtonEditWhite" />
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText=" " UniqueName="GridTemplateColumnDocumentType" HeaderAbbr="FIXED" HeaderTooltip="Document Type" AllowFiltering="false">
                        <HeaderStyle CssClass="radgrid-icon-column" />
                        <ItemStyle CssClass="radgrid-icon-column" />
                        <FooterStyle CssClass="radgrid-icon-column" />
                        <ItemTemplate>
                            <div id="DivDocumentType" runat="server" class="icon-background background-color-sidebar">
                                <asp:LinkButton ID="LinkButtonDocumentType" runat="server" Text="" ToolTip="" CommandName="Download" CssClass="icon-text" CommandArgument='<%# Eval("DOCUMENT_ID")%>'></asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDocumentHistory" HeaderAbbr="FIXED" HeaderTooltip="Document History" AllowFiltering="false">
                        <HeaderStyle CssClass="radgrid-icon-column" />
                        <ItemStyle CssClass="radgrid-icon-column" />
                        <FooterStyle CssClass="radgrid-icon-column" />
                        <ItemTemplate>
                            <div id="DivDocumentHistory" runat="server" class="icon-background background-color-sidebar" title="Show document history">
                                <asp:LinkButton ID="LinkButtonDocumentHistory" runat="server" Text="H" ToolTip="Show document history" CommandName="ShowHistory" CssClass="icon-text" CommandArgument='<%# Eval("DOCUMENT_ID")%>'></asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAddComments" HeaderAbbr="FIXED" HeaderTooltip="Add comments to document" AllowFiltering="false">
                        <HeaderStyle CssClass="radgrid-icon-column" />
                        <ItemStyle CssClass="radgrid-icon-column" />
                        <FooterStyle CssClass="radgrid-icon-column" />
                        <ItemTemplate>
                            <div id="DivAddComments" runat="server" class="icon-background background-color-sidebar">
                                <asp:ImageButton ID="ImageButtonAddComments" runat="server" SkinID="ImageButtonCommentWhite" ToolTip="Click to add comment to this document" Visible="false" />
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataType="System.String" HeaderText="Filename" UniqueName="GridTemplateColumnFileName" HeaderTooltip="Document filename" HeaderAbbr="FIXED" SortExpression="FILENAME" DataField="FILENAME"
                        FilterControlWidth="150" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButtonDownload" runat="server"></asp:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="FILE_SIZE" DataType="System.Int16" HeaderText="Size" UniqueName="GridBoundColumnFileSize" HeaderTooltip="Document size" SortExpression="FILE_SIZE"
                        FilterControlWidth="65" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DESCRIPTION" DataType="System.String" HeaderText="File Desc." UniqueName="GridBoundColumnDescription" HeaderTooltip="Document description" SortExpression="DESCRIPTION"
                        FilterControlWidth="100" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="150" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="150" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="KEYWORDS" DataType="System.String" HeaderText="Keywords" UniqueName="GridBoundColumnKeywords" HeaderTooltip="Document keywords" SortExpression="KEYWORDS"
                        FilterControlWidth="100" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="USER_CODE" DataType="System.String" HeaderText="By" UniqueName="GridBoundColumnUserCode" HeaderTooltip="Uploaded by" SortExpression="USER_CODE"
                        FilterControlWidth="100" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="UPLOADED_DATE" DataType="System.String" 
                        HeaderText="On" UniqueName="GridBoundColumnUploadedDate" HeaderTooltip="Date and time document was uploaded" 
                        SortExpression="UPLOADED_DATE"
                        FilterControlWidth="85" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="right" CssClass="radgrid-datetime-column" />
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="right" CssClass="radgrid-datetime-column" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="LEVEL" DataType="System.String" HeaderText="Level" UniqueName="GridBoundColumnDocumentLevel" HeaderTooltip="Document Level" HeaderAbbr="FIXED" SortExpression="LEVEL"
                        FilterControlWidth="50" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="OFFICE_CODE" DataType="System.String" HeaderText="Office Code" UniqueName="GridBoundColumnOfficeCode" HeaderTooltip="Office code" SortExpression="OFFICE_CODE" HeaderAbbr="FIXED"
                        FilterControlWidth="60" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="OFFICE_NAME" DataType="System.String" HeaderText="Office Name" UniqueName="GridBoundColumnOfficeDescription" HeaderTooltip="Office name" SortExpression="OFFICE_NAME" HeaderAbbr="FIXED"
                        FilterControlWidth="110" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CL_CODE" DataType="System.String" HeaderText="Client Code" UniqueName="GridBoundColumnClientCode" HeaderTooltip="Client code" SortExpression="CL_CODE" HeaderAbbr="FIXED"
                        FilterControlWidth="65" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CLIENT_NAME" DataType="System.String" HeaderText="Client Name" UniqueName="GridBoundColumnClientName" HeaderTooltip="Client name" SortExpression="CLIENT_NAME" HeaderAbbr="FIXED"
                        FilterControlWidth="110" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DIV_CODE" DataType="System.String" HeaderText="Division Code" UniqueName="GridBoundColumnDivisionCode" HeaderTooltip="Division code" SortExpression="DIV_CODE" HeaderAbbr="FIXED"
                        FilterControlWidth="65" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DIVISION_NAME" DataType="System.String" HeaderText="Division Name" UniqueName="GridBoundColumnDivisionName" HeaderTooltip="Division name" SortExpression="DIVISION_NAME" HeaderAbbr="FIXED"
                        FilterControlWidth="110" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PRD_CODE" DataType="System.String" HeaderText="Product Code" UniqueName="GridBoundColumnProductCode" HeaderTooltip="Product code" SortExpression="PRD_CODE" HeaderAbbr="FIXED"
                        FilterControlWidth="65" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PRODUCT_DESCRIPTION" DataType="System.String" HeaderText="Product Name" UniqueName="GridBoundColumnProductDescription" HeaderTooltip="Product description" SortExpression="PRODUCT_DESCRIPTION" HeaderAbbr="FIXED"
                        FilterControlWidth="110" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CMP_CODE" DataType="System.String" HeaderText="Campaign Code" UniqueName="GridBoundColumnCampaignCode" HeaderTooltip="Campaign code" SortExpression="CMP_CODE" HeaderAbbr="FIXED"
                        FilterControlWidth="65" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CAMPAIGN_NAME" DataType="System.String" HeaderText="Campaign Desc." UniqueName="GridBoundColumnCampaignName" HeaderTooltip="Campaign name" SortExpression="CAMPAIGN_NAME" HeaderAbbr="FIXED"
                        FilterControlWidth="110" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JOB_NUMBER" DataType="System.Int32" HeaderText="Job Number" UniqueName="GridBoundColumnJobNumber" HeaderTooltip="Job number" SortExpression="JOB_NUMBER" HeaderAbbr="FIXED"
                        FilterControlWidth="65" CurrentFilterFunction="EqualTo" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JOB_DESCRIPTION" DataType="System.String" HeaderText="Job Desc." UniqueName="GridBoundColumnJobDescription" HeaderTooltip="Job description" SortExpression="JOB_DESCRIPTION" HeaderAbbr="FIXED"
                        FilterControlWidth="110" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JOB_COMPONENT_NBR" DataType="System.Int16" HeaderText="Component Number" UniqueName="GridBoundColumnJobComponentNumber" HeaderTooltip="Job Component number" SortExpression="JOB_COMPONENT_NBR" HeaderAbbr="FIXED"
                        FilterControlWidth="65" CurrentFilterFunction="EqualTo" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="JOB_COMP_DESCRIPTION" DataType="System.String" HeaderText="Component Desc." UniqueName="GridBoundColumnJobComponentDescription" HeaderTooltip="Job Component description" SortExpression="JOB_COMP_DESCRIPTION" HeaderAbbr="FIXED"
                        FilterControlWidth="110" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="VENDOR_CODE" DataType="System.String" HeaderText="Vendor Code" UniqueName="GridBoundColumnVendorCode" HeaderTooltip="Vendor code" SortExpression="VENDOR_CODE" HeaderAbbr="FIXED"
                        FilterControlWidth="65" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="VENDOR_NAME" DataType="System.String" HeaderText="Vendor Name" UniqueName="GridBoundColumnVendorName" HeaderTooltip="Vendor name" SortExpression="VENDOR_NAME" HeaderAbbr="FIXED"
                        FilterControlWidth="110" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="AP_INVOICE" DataType="System.Int32" HeaderText="Invoice Nbr" UniqueName="GridBoundColumnApInvoice" HeaderTooltip="AP Invoice number" SortExpression="AP_INVOICE" HeaderAbbr="FIXED"
                        FilterControlWidth="110" CurrentFilterFunction="EqualTo" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="AP_INVOICE_DESC" DataType="System.String" HeaderText="Invoice Desc." UniqueName="GridBoundColumnApInvoiceDescription" HeaderTooltip="AP Invoice description" SortExpression="AP_INVOICE_DESC" HeaderAbbr="FIXED"
                        FilterControlWidth="110" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="AP_ID" DataType="System.Int32" HeaderText="Invoice Number" UniqueName="GridBoundColumnApID" Visible="false" HeaderTooltip="" SortExpression="AP_ID" HeaderAbbr="FIXED"
                        FilterControlWidth="110" CurrentFilterFunction="EqualTo" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="AD_NBR" DataType="System.String" HeaderText="Ad Number" UniqueName="GridBoundColumnAdNumber" HeaderTooltip="Ad Number" SortExpression="AD_NBR" HeaderAbbr="FIXED"
                        FilterControlWidth="65" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="AD_NBR_DESC" DataType="System.String" HeaderText="Ad Number Desc." UniqueName="GridBoundColumnAdNumberDescription" HeaderTooltip="Ad Number description" SortExpression="AD_NBR_DESC" HeaderAbbr="FIXED"
                        FilterControlWidth="110" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Top" />
                        <HeaderStyle VerticalAlign="Top"/>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EXPENSE_HEADER_DESC" DataType="System.String" HeaderText="Expense Desc." UniqueName="GridBoundColumnExpenseHeaderDescription" HeaderTooltip="Expense descriptioon" SortExpression="EXPENSE_HEADER_DESC" HeaderAbbr="FIXED"
                        FilterControlWidth="110" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Top" />
                        <HeaderStyle VerticalAlign="Top"/>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EMP_CODE" DataType="System.String" HeaderText="Emp. Code" UniqueName="GridBoundColumnEmployeeCode" HeaderTooltip="Employee code" SortExpression="EMP_CODE" HeaderAbbr="FIXED"
                        FilterControlWidth="65" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Top" />
                        <HeaderStyle VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EMP_FML" DataType="System.String" HeaderText="Employee" UniqueName="GridBoundColumnEmployeeFullName" HeaderTooltip="Employee name" SortExpression="EMP_FML" HeaderAbbr="FIXED"
                        FilterControlWidth="110" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Top" />
                        <HeaderStyle VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CONTRACT_CODE" DataType="System.String" HeaderText="Contract Code" UniqueName="GridBoundColumnContractCode" HeaderTooltip="Contract code" SortExpression="CONTRACT_CODE" HeaderAbbr="FIXED"
                        FilterControlWidth="65" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Top" />
                        <HeaderStyle VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CONTRACT_DESC" DataType="System.String" HeaderText="Contract Desc." UniqueName="GridBoundColumnContractDescription" HeaderTooltip="Contract description" SortExpression="CONTRACT_DESC" HeaderAbbr="FIXED"
                        FilterControlWidth="110" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Top" />
                        <HeaderStyle VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CONTRACT_REPORT_DESC" DataType="System.String" HeaderText="Contract Report Desc." UniqueName="GridBoundColumnContractReportDesc" HeaderTooltip="Contract report description" SortExpression="CONTRACT_REPORT_DESC" HeaderAbbr="FIXED"
                        FilterControlWidth="110" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Top" />
                        <HeaderStyle VerticalAlign="Top"/>
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ALERT_SUBJECT" DataType="System.String" HeaderText="Alert Subject" UniqueName="GridBoundColumnAlertSubject" HeaderTooltip="Alert subject" SortExpression="ALERT_SUBJECT" HeaderAbbr="FIXED"
                        FilterControlWidth="110" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Top" />
                        <HeaderStyle VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DP_TM_CODE" DataType="System.String" HeaderText="Contract Code" UniqueName="GridBoundColumnDepartmentTeamCode" HeaderTooltip="Dept./Team code" SortExpression="DP_TM_CODE" HeaderAbbr="FIXED"
                        FilterControlWidth="65" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Top" />
                        <HeaderStyle VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DP_TM_DESC" DataType="System.String" HeaderText="Contract Desc." UniqueName="GridBoundColumnDepartmentTeamDescription" HeaderTooltip="Dept./Team description" SortExpression="DP_TM_DESC" HeaderAbbr="FIXED"
                        FilterControlWidth="110" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <ItemStyle VerticalAlign="Top" />
                        <HeaderStyle VerticalAlign="Top" />
                    </telerik:GridBoundColumn>
                </Columns>
                <ExpandCollapseColumn Visible="False">
                    <HeaderStyle Width="19px" />
                </ExpandCollapseColumn>
                <RowIndicatorColumn Visible="False">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
</asp:Content>
