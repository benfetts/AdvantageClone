<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Maintenance_ClientEdit.aspx.vb" Inherits="Webvantage.Maintenance_ClientEdit" %>

<asp:Content ID="conClientContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <script type="text/javascript">
        function RefreshPage(radWindowCaller) {
            __doPostBack('onclick#Refresh', 'Refresh');
        };
    </script>

    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolbarClient" runat="server" AutoPostBack="True" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonSave" SkinID="RadToolBarButtonSave" Text="" Value="Save"
                    ToolTip="Save" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonSeparator1" IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonNew" SkinID="RadToolBarButtonNew" Text="New" Value="New" ToolTip="Add New" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonSeparator2" IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonUploadDocument" SkinID="RadToolBarButtonUpload" Text="Upload Documents" Value="Upload"
                    ToolTip="Upload a document" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonDocuments" Text="Documents" Value="ViewDocs"
                    ToolTip="View documents" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonSeparator3" IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarRefresh" SkinID="RadToolBarButtonRefresh" Value="Refresh"
                    ToolTip="Refresh" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark"
                    ToolTip="Bookmark" Visible="true" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
        <ew:CollapsablePanel ID="CollapsablePanelHeader" runat="server" TitleText="Client Information">
        <div class="code-description-container">
            <div class="code-description-label">
                Code:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TextBoxClientCode" runat="server" SkinID="TextBoxCodeSmall"></asp:TextBox>
                <asp:CheckBox ID="CheckBoxIsNewBusiness" runat="server" Text="New Business" />
                <asp:RequiredFieldValidator ID="RFVCode" runat="server" ControlToValidate="TextBoxClientCode"
                    CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                    ErrorMessage="<br />Code is required."></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Name:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TextBoxClientName" runat="server"
                    SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVName" runat="server" ControlToValidate="TextBoxClientName"
                    CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                    ErrorMessage="<br />Name is required."></asp:RequiredFieldValidator>
                <asp:CheckBox ID="CheckBoxIsInactive" runat="server" Text="Inactive" />
            </div>
        </div>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <div id="DivNewClientOptions" runat="server">
                <div class="code-description-container" style="margin-top: 8px; font-size: larger;">
                    New Client Options
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                    </div>
                    <div class="code-description-description">
                        <asp:CheckBox ID="CheckBoxDuplicateForDivision" runat="server" Text="Duplicate for Division" TabIndex="50" AutoPostBack="True" />
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                    </div>
                    <div class="code-description-description">
                        <asp:CheckBox ID="CheckBoxDuplicateForProduct" runat="server" Text="Duplicate for Product" TabIndex="50" AutoPostBack="True" />
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Office:
                    </div>
                    <div class="code-description-description">
                        <telerik:RadComboBox ID="RadComboBoxOffice" runat="server" AutoPostBack="true" TabIndex="30" Width="275px" SkinID="RadComboBoxStandard">
                        </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="RFVOffice" runat="server" ControlToValidate="RadComboBoxOffice"
                            CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="false"
                            ErrorMessage="<br />Office is required."></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelGeneral" runat="server"
        TitleText="General" Collapsed="True">
        <div style="width:600px;">
        <div class="code-description-container">
            <div class="code-description-label">
                Address 1:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TextBoxAddress1" runat="server" Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Address 2:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TextBoxAddress2" runat="server" Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                City:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TextBoxCity" runat="server" Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                County:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TextBoxCounty" runat="server" Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">

            <div class="code-description-label">
                State:
            </div>
            <div class="code-description-code">
                <asp:TextBox ID="TextBoxState" runat="server" Width="60px" SkinID="TextBoxStandard"></asp:TextBox>&nbsp;&nbsp;Zip:&nbsp;&nbsp;<asp:TextBox ID="TextBoxZip" runat="server" Width="155px"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Country:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TextBoxCountry" runat="server" Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
            </div>
            <div class="code-description-description">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <telerik:RadGrid ID="RadGridSortKeys" runat="server" AllowPaging="True"
                        AllowSorting="True" GridLines="None" PageSize="3" EnableEmbeddedSkins="True"
                        ShowFooter="False" AutoGenerateColumns="False" Width="250">
                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px"></PagerStyle>
                        <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="SortKey"
                            InsertItemDisplay="Top">
                            <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSortKey" HeaderText="Sort Option(s)"
                                    SortExpression="Description">
                                    <HeaderStyle Width="175" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemStyle Width="175" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <FooterStyle Width="175" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBoxSortKey" runat="server" MaxLength="20" Text='<%#Eval("SortKey")%>' SkinID="TextBoxStandard"
                                            Width="150"></asp:TextBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBoxSortKeyEditTextBox" runat="server" MaxLength="20" SkinID="TextBoxStandard"
                                            Text='<%#Eval("SortKey")%>' Width="150"></asp:TextBox>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSave">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <EditItemTemplate>
                                        <div class="icon-background background-color-sidebar">
                                            <asp:ImageButton ID="ImageButtonSaveNew" runat="server" SkinID="ImageButtonNewWhite" ToolTip="Click to add this row"
                                                CommandName="SaveNewRow" />
                                        </div>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnCancel">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <ItemTemplate>
                                        <div class="icon-background background-color-delete">
                                            <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite" ToolTip="Click to delete this row"
                                                CommandName="DeleteRow" />
                                        </div>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="icon-background background-color-sidebar">
                                            <asp:ImageButton ID="ImageButtonCancel" runat="server" SkinID="ImageButtonCancelWhite"
                                                ToolTip="Cancel add row" CommandName="CancelAddRow" />
                                        </div>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <RowIndicatorColumn>
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn>
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                        </MasterTableView>
                    </telerik:RadGrid>
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </div>
        </div>

    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelBilling" runat="server"
        TitleText="Billing" Collapsed="True">
            <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <table align="left" border="0" cellpadding="2" cellspacing="0" width="100%">    
                <tr>
                    <td>
                        <table border="0" cellspacing="0" cellpadding="2" width="100%">
                            <tr>
                                <td colspan="2">Billing Address
                                </td>
                            </tr>
                            <tr>
                                <td style="text-decoration: underline"></td>
                                <td align="center">&nbsp;&nbsp;Refresh From&nbsp;<asp:LinkButton ID="LinkButtonBilling_Client" runat="server" Text="Client" TabIndex="-1"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" width="30%">Address 1:</td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxBillingAddress1" runat="server" Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">Address 2:</td>
                                <td>&nbsp;&nbsp;
                                <asp:TextBox ID="TextBoxBillingAddress2" runat="server" Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: right" valign="middle">City:</td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxBillingCity" runat="server" Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: right" valign="middle">County:</td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxBillingCounty" runat="server" Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: right" valign="middle">State:</td>
                                <td align="left" style="width: 70%" valign="middle">
                                    <div style="width: 340px;">
                                        &nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxBillingState" runat="server" Width="60px" SkinID="TextBoxStandard"></asp:TextBox>&nbsp;&nbsp;Zip:&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxBillingZip" runat="server" Width="155px" SkinID="TextBoxStandard"></asp:TextBox>
                                        <div style="width: 340px;">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: right" valign="middle">Country:</td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxBillingCountry" runat="server" Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table border="0" cellspacing="0" cellpadding="2" width="100%">
                            <tr>
                                <td colspan="2">Statement Address
                                </td>
                            </tr>
                            <tr>
                                <td style="text-decoration: underline"></td>
                                <td align="center">&nbsp;&nbsp;Refresh From&nbsp;<asp:LinkButton ID="LinkButtonStatement_Client" runat="server" Text="Client" TabIndex="-1"></asp:LinkButton>
                                    &nbsp;&nbsp;<asp:LinkButton ID="LinkButtonStatement_Billing" runat="server" Text="Billing" TabIndex="-1"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" width="30%">Address 1:</td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxStatementAddress1" runat="server" Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">Address 2:</td>
                                <td>&nbsp;&nbsp;
                                <asp:TextBox ID="TextBoxStatementAddress2" runat="server" Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: right" valign="middle">City:</td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxStatementCity" runat="server" Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: right" valign="middle">County:</td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxStatementCounty" runat="server" Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: right" valign="middle">State:</td>
                                <td align="left" style="width: 70%" valign="middle">
                                    <div style="width: 340px;">
                                        &nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxStatementState" runat="server" Width="60px" SkinID="TextBoxStandard"></asp:TextBox>&nbsp;&nbsp;Zip:&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxStatementZip" runat="server" Width="155px" SkinID="TextBoxStandard"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: right" valign="middle">Country:</td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxStatementCountry" runat="server" Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        <table border="0" cellspacing="0" cellpadding="2" width="100%">
                            <tr>
                                <td align="left" style="text-align: right" valign="middle" width="20%">Fiscal Start Month:
                                </td>
                                <td>&nbsp;&nbsp;
                                    <telerik:RadComboBox ID="RadComboBoxFiscalStartMonth" runat="server" AutoPostBack="false" TabIndex="30" Width="180px" SkinID="RadComboBoxStandard">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: right" valign="middle">Credit Limit:
                                </td>
                                <td>&nbsp;&nbsp;
                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxCreditLimit" runat="server" Type="Number" Style="text-align: right"
                                        Width="180px">
                                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" Step="1" />
                                    </telerik:RadNumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: right" valign="middle">A/R Comment:</td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxARComment" runat="server" SkinID="TextBoxCodeMultiLine" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server" id="TableRowAvalara">
                    <td align="left" colspan="2">Avalara
                        <table border="0" cellspacing="0" cellpadding="2" width="100%">
                            <tr>
                                <td align="left" style="text-align: right" valign="middle" width="20%">Sales Class:
                                </td>
                                <td>&nbsp;&nbsp;
                                    <telerik:RadComboBox ID="RadComboBoxAvalaraSalesClass" runat="server" AutoPostBack="false" TabIndex="30" Width="180px" SkinID="RadComboBoxStandard">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: right" valign="middle" width="20%">Tax Exempt:
                                </td>
                                <td>&nbsp;&nbsp;
                                    <asp:CheckBox ID="CheckBoxAvalaraTaxExempt" runat="server" Text="Tax Exempt" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
                </ContentTemplate>
            </asp:UpdatePanel>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelMediaIntegrationSettings" runat="server"
        TitleText="Media Integration Settings" Collapsed="True">
        <div style="width:600px;">
        <div class="code-description-container">
            <div class="code-description-description">
                <asp:CheckBox ID="CheckBoxDoubleClickEnabled" runat="server" Text="Enable DoubleClick Integration" AutoPostBack="true" />
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                DoubleClick Profile ID:
            </div>
            <div class="code-description-description">
                <telerik:RadNumericTextBox ID="RadNumericTextBoxDoubleClickProfileID" runat="server" Type="Number" Style="text-align: right"
                    Width="180px">
                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" Step="1" />
                </telerik:RadNumericTextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                DoubleClick Report ID:
            </div>
            <div class="code-description-description">
                <telerik:RadNumericTextBox ID="RadNumericTextBoxDoubleClickReportID" runat="server" Type="Number" Style="text-align: right"
                    Width="180px">
                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" Step="1" />
                </telerik:RadNumericTextBox>
            </div>
        </div>        
        </div>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelProduction" runat="server"
        TitleText="Production" Collapsed="True" Visible="false">
        <asp:Panel ID="PanelProductionAssignInvoices" runat="server" GroupingText="Assign Production Invoices By">
            <table align="center" border="0" cellpadding="0" cellspacing="0" width="60%">
                <tr>
                    <td colspan="4" style="height: 10px">&nbsp;
                    </td>
                </tr>
                <tr valign="top" align="left">
                    <td>
                        <asp:RadioButton ID="RadioButtonCampaign" runat="server" Text="Campaign" TabIndex="100" GroupName="prdInvoices" />
                    </td>
                    <td>
                        <asp:RadioButton ID="RadioButtonClient" runat="server" Text="Client" TabIndex="110" GroupName="prdInvoices" />
                    </td>
                    <td>
                        <asp:RadioButton ID="RadioButtonDivision" runat="server" Text="Division" TabIndex="120" GroupName="prdInvoices" />
                    </td>
                    <td>
                        <asp:RadioButton ID="RadioButtonJob" runat="server" Text="Job" TabIndex="130" GroupName="prdInvoices" />
                    </td>
                </tr>
                <tr valign="top" align="left">
                    <td>
                        <asp:RadioButton ID="RadioButtonJobComponent" runat="server" Text="Job Component" TabIndex="140" GroupName="prdInvoices" />
                    </td>
                    <td>
                        <asp:RadioButton ID="RadioButtonProduct" runat="server" Text="Product" TabIndex="150" GroupName="prdInvoices" />
                    </td>
                    <td>
                        <asp:RadioButton ID="RadioButtonProductSalesClass" runat="server" Text="Product / SalesClass" TabIndex="160" GroupName="prdInvoices" />
                    </td>
                    <td>
                        <asp:RadioButton ID="RadioButtonProductClientPO" runat="server" Text="Product / Client PO" TabIndex="170" GroupName="prdInvoices" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
            <caption>Production Invoice Format</caption>
            <tr>
                <td colspan="3" style="height: 10px">&nbsp;
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: right" valign="middle">Type:
                </td>
                <td align="left" style="text-align: left" valign="middle">&nbsp;&nbsp;
                    <telerik:RadComboBox ID="RadComboBoxProdInvType" runat="server" AutoPostBack="true" TabIndex="30" Width="275px" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </td>
                <td>&nbsp;&nbsp;(Standard Format is established and configured in 'Invoice Printing')
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: right" valign="middle">Format:
                </td>
                <td align="left" style="text-align: left" valign="middle" colspan="2">&nbsp;&nbsp;
                    <telerik:RadComboBox ID="RadComboBoxProdInvFormat" runat="server" TabIndex="30" Width="550px" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;
                </td>
            </tr>
        </table>
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="right" width="20%">Attention Line:</td>
                <td align="left">
                    <asp:TextBox ID="TextBoxProdAttentionLine" runat="server" Width="100%" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%">Invoice Footer Comments:</td>
                <td align="left">
                    <asp:TextBox ID="TextBoxProdInvoiceFooter" runat="server" Width="100%" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%">Days to Pay:</td>
                <td align="left">
                    <asp:TextBox ID="TextBoxProdDaysToPay" runat="server" Width="100%" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
            </tr>
        </table>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelMedia" runat="server"
        TitleText="Media" Collapsed="True" Visible="false">
        <asp:Panel ID="PanelMediaAssignInvoices" runat="server" GroupingText="Assign Media Invoices By">
            <table align="center" border="0" cellpadding="0" cellspacing="0" width="60%">
                <tr>
                    <td colspan="4" style="height: 10px">&nbsp;
                    </td>
                </tr>
                <tr valign="top" align="left">
                    <td>
                        <asp:RadioButton ID="RadioButtonOrderType" runat="server" Text="Sales Class" TabIndex="100" GroupName="medInvoices" />
                    </td>
                    <td>
                        <asp:RadioButton ID="RadioButtonMediaMarket" runat="server" Text="Market" TabIndex="110" GroupName="medInvoices" />
                    </td>
                    <td>
                        <asp:RadioButton ID="RadioButtonMediaCampaign" runat="server" Text="Campaign" TabIndex="120" GroupName="medInvoices" />
                    </td>
                    <td>
                        <asp:RadioButton ID="RadioButtonMediaClientPO" runat="server" Text="Client P.O." TabIndex="130" GroupName="medInvoices" />
                    </td>
                    <td>
                        <asp:RadioButton ID="RadioButtonMediaOrderNumber" runat="server" Text="Order #" TabIndex="130" GroupName="medInvoices" />
                    </td>
                    <td>
                        <asp:RadioButton ID="RadioButtonSalesClass" runat="server" Text="Order Type" TabIndex="130" GroupName="medInvoices" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6">&nbsp;
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="right" width="20%">Attention Line:</td>
                <td align="left">
                    <asp:TextBox ID="TextBoxMediaAttention" runat="server" Width="100%" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%">Invoice Footer Comments:</td>
                <td align="left">
                    <asp:TextBox ID="TextBoxMediaInvoiceFooter" runat="server" Width="100%" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%">Days to Pay:</td>
                <td align="left">
                    <asp:TextBox ID="TextBoxMediaDaysToPay" runat="server" Width="100%" SkinID="TextBoxStandard"></asp:TextBox>
                </td>
            </tr>
        </table>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelMediaInvoiceFormat" runat="server"
        TitleText="Media Invoice Format" Collapsed="True" Visible="false">
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
            <caption>Magazine Invoice Format</caption>
            <tr>
                <td colspan="3" style="height: 10px">&nbsp;
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: right" valign="middle">Type:
                </td>
                <td align="left" style="text-align: left" valign="middle">&nbsp;&nbsp;
                    <telerik:RadComboBox ID="RadComboBoxMagazineInvoiceFormat_Type" runat="server" AutoPostBack="true" TabIndex="30" Width="275px" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </td>
                <td>&nbsp;&nbsp;(Standard Format is established and configured in 'Invoice Printing')
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: right" valign="middle">Format:
                </td>
                <td align="left" style="text-align: left" valign="middle" colspan="2">&nbsp;&nbsp;
                    <telerik:RadComboBox ID="RadComboBoxMagazineInvoiceFormat_Format" runat="server" TabIndex="30" Width="550px" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;
                </td>
            </tr>
        </table>
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
            <caption>Newspaper Invoice Format</caption>
            <tr>
                <td colspan="3" style="height: 10px">&nbsp;
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: right" valign="middle">Type:
                </td>
                <td align="left" style="text-align: left" valign="middle">&nbsp;&nbsp;
                    <telerik:RadComboBox ID="RadComboBoxNewspaperInvoiceFormat_Type" runat="server" AutoPostBack="true" TabIndex="30" Width="275px" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </td>
                <td>&nbsp;&nbsp;(Standard Format is established and configured in 'Invoice Printing')
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: right" valign="middle">Format:
                </td>
                <td align="left" style="text-align: left" valign="middle" colspan="2">&nbsp;&nbsp;
                    <telerik:RadComboBox ID="RadComboBoxNewspaperInvoiceFormat_Format" runat="server" TabIndex="30" Width="550px" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;
                </td>
            </tr>
        </table>
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
            <caption>Internet Invoice Format</caption>
            <tr>
                <td colspan="3" style="height: 10px">&nbsp;
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: right" valign="middle">Type:
                </td>
                <td align="left" style="text-align: left" valign="middle">&nbsp;&nbsp;
                    <telerik:RadComboBox ID="RadComboBoxInternetInvoiceFormat_Type" runat="server" AutoPostBack="true" TabIndex="30" Width="275px" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </td>
                <td>&nbsp;&nbsp;(Standard Format is established and configured in 'Invoice Printing')
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: right" valign="middle">Format:
                </td>
                <td align="left" style="text-align: left" valign="middle" colspan="2">&nbsp;&nbsp;
                    <telerik:RadComboBox ID="RadComboBoxInternetInvoiceFormat_Format" runat="server" TabIndex="30" Width="550px" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;
                </td>
            </tr>
        </table>
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
            <caption>Out of Home Invoice Format</caption>
            <tr>
                <td colspan="3" style="height: 10px">&nbsp;
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: right" valign="middle">Type:
                </td>
                <td align="left" style="text-align: left" valign="middle">&nbsp;&nbsp;
                    <telerik:RadComboBox ID="RadComboBoxOutOfHomeInvoiceFormat_Type" runat="server" AutoPostBack="true" TabIndex="30" Width="275px" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </td>
                <td>&nbsp;&nbsp;(Standard Format is established and configured in 'Invoice Printing')
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: right" valign="middle">Format:
                </td>
                <td align="left" style="text-align: left" valign="middle" colspan="2">&nbsp;&nbsp;
                    <telerik:RadComboBox ID="RadComboBoxOutOfHomeInvoiceFormat_Format" runat="server" TabIndex="30" Width="550px" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;
                </td>
            </tr>
        </table>
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
            <caption>Radio Invoice Format</caption>
            <tr>
                <td colspan="3" style="height: 10px">&nbsp;
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: right" valign="middle">Type:
                </td>
                <td align="left" style="text-align: left" valign="middle">&nbsp;&nbsp;
                    <telerik:RadComboBox ID="RadComboBoxRadioInvoiceFormat_Type" runat="server" AutoPostBack="true" TabIndex="30" Width="275px" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </td>
                <td>&nbsp;&nbsp;(Standard Format is established and configured in 'Invoice Printing')
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: right" valign="middle">Format:
                </td>
                <td align="left" style="text-align: left" valign="middle" colspan="2">&nbsp;&nbsp;
                    <telerik:RadComboBox ID="RadComboBoxRadioInvoiceFormat_Format" runat="server" TabIndex="30" Width="550px" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;
                </td>
            </tr>
        </table>
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
            <caption>Television Invoice Format</caption>
            <tr>
                <td colspan="3" style="height: 10px">&nbsp;
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: right" valign="middle">Type:
                </td>
                <td align="left" style="text-align: left" valign="middle">&nbsp;&nbsp;
                    <telerik:RadComboBox ID="RadComboBoxTVInvoiceFormat_Type" runat="server" AutoPostBack="true" TabIndex="30" Width="275px" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </td>
                <td>&nbsp;&nbsp;(Standard Format is established and configured in 'Invoice Printing')
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: right" valign="middle">Format:
                </td>
                <td align="left" style="text-align: left" valign="middle" colspan="2">&nbsp;&nbsp;
                    <telerik:RadComboBox ID="RadComboBoxTVInvoiceFormat_Format" runat="server" TabIndex="30" Width="550px" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;
                </td>
            </tr>
        </table>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelRequiredFields" runat="server"
        TitleText="Required Fields" Collapsed="True" Visible="false">
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
            <caption>User Selected Required Fields</caption>
            <tr>
                <td colspan="3" align="left" style="text-align: left; border-bottom-style: solid;" valign="middle">
                    <asp:CheckBox ID="CheckBoxOverrideAgencySettings" runat="server" Text="Override Agency Settings" TabIndex="50" Font-Underline="False" />
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: left" valign="middle">
                    <asp:CheckBox ID="CheckBoxAccountNumber" runat="server" Text="Account Number" TabIndex="50" />
                </td>
                <td align="left" style="text-align: left" valign="middle">&nbsp;&nbsp;
                    <asp:CheckBox ID="CheckBoxDateOpened" runat="server" Text="Date Opened" TabIndex="50" />
                </td>
                <td>
                    <asp:CheckBox ID="CheckBoxJobLogCustom1" runat="server" Text="Job Log Custom 1" TabIndex="50" />
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: left" valign="middle">
                    <asp:CheckBox ID="CheckBoxAdNumber" runat="server" Text="Ad Number" TabIndex="50" />
                </td>
                <td align="left" style="text-align: left" valign="middle">&nbsp;&nbsp;
                    <asp:CheckBox ID="CheckBoxDeptTeam" runat="server" Text="Dept / Team" TabIndex="50" />
                </td>
                <td>
                    <asp:CheckBox ID="CheckBoxJobLogCustom2" runat="server" Text="Job Log Custom 2" TabIndex="50" />
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: left" valign="middle">
                    <asp:CheckBox ID="CheckBoxAlertGroup" runat="server" Text="Alert Group" TabIndex="50" />
                </td>
                <td align="left" style="text-align: left" valign="middle">&nbsp;&nbsp;
                    <asp:CheckBox ID="CheckBoxDueDate" runat="server" Text="Due Date" TabIndex="50" />
                </td>
                <td>
                    <asp:CheckBox ID="CheckBoxJobLogCustom3" runat="server" Text="Job Log Custom 3" TabIndex="50" />
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: left" valign="middle">
                    <asp:CheckBox ID="CheckBoxBlackplate1" runat="server" Text="Blackplate 1" TabIndex="50" />
                </td>
                <td align="left" style="text-align: left" valign="middle">&nbsp;&nbsp;
                    <asp:CheckBox ID="CheckBoxFormatAdSize" runat="server" Text="Format" TabIndex="50" />
                </td>
                <td>
                    <asp:CheckBox ID="CheckBoxJobLogCustom4" runat="server" Text="Job Log Custom 4" TabIndex="50" />
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: left" valign="middle">
                    <asp:CheckBox ID="CheckBoxBlackplate2" runat="server" Text="Blackplate 2" TabIndex="50" />
                </td>
                <td align="left" style="text-align: left" valign="middle">&nbsp;&nbsp;
                    <asp:CheckBox ID="CheckBoxJobType" runat="server" Text="Job Type" TabIndex="50" />
                </td>
                <td>
                    <asp:CheckBox ID="CheckBoxJobLogCustom5" runat="server" Text="Job Log Custom 5" TabIndex="50" />
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: left" valign="middle">
                    <asp:CheckBox ID="CheckBoxComponentBudget" runat="server" Text="Budget" TabIndex="50" />
                </td>
                <td align="left" style="text-align: left" valign="middle">&nbsp;&nbsp;
                    <asp:CheckBox ID="CheckBoxMarketCode" runat="server" Text="Market" TabIndex="50" />
                </td>
                <td>
                    <asp:CheckBox ID="CheckBoxJobComponentCustom1" runat="server" Text="Job Component Custom 1" TabIndex="50" />
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: left" valign="middle">
                    <asp:CheckBox ID="CheckBoxClientReference" runat="server" Text="Client Reference" TabIndex="50" />
                </td>
                <td align="left" style="text-align: left" valign="middle">&nbsp;&nbsp;
                    <asp:CheckBox ID="CheckBoxPromotion" runat="server" Text="Promotion" TabIndex="50" />
                </td>
                <td>
                    <asp:CheckBox ID="CheckBoxJobComponentCustom2" runat="server" Text="Job Component Custom 2" TabIndex="50" />
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: left" valign="middle">
                    <asp:CheckBox ID="CheckBoxComplexityCode" runat="server" Text="Complexity" TabIndex="50" />
                </td>
                <td align="left" style="text-align: left" valign="middle">&nbsp;&nbsp;
                    <asp:CheckBox ID="CheckBoxSCFormat" runat="server" Text="Sales Class Format" TabIndex="50" />
                </td>
                <td>
                    <asp:CheckBox ID="CheckBoxJobComponentCustom3" runat="server" Text="Job Component Custom 3" TabIndex="50" />
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: left" valign="middle">
                    <asp:CheckBox ID="CheckBoxProductContact" runat="server" Text="Contact" TabIndex="50" />
                </td>
                <td align="left" style="text-align: left" valign="middle">&nbsp;&nbsp;
                    <asp:CheckBox ID="CheckBoxServiceFeeType" runat="server" Text="Service Fee Type" TabIndex="50" />
                </td>
                <td>
                    <asp:CheckBox ID="CheckBoxJobComponentCustom4" runat="server" Text="Job Component Custom 4" TabIndex="50" />
                </td>
            </tr>
            <tr valign="top" align="left">
                <td align="left" style="text-align: left" valign="middle">
                    <asp:CheckBox ID="CheckBoxCoopBillingCode" runat="server" Text="Coop Billing" TabIndex="50" />
                </td>
                <td align="left" style="text-align: left" valign="middle">&nbsp;&nbsp;
                    <asp:CheckBox ID="CheckBoxTaxFlag" runat="server" Text="Tax Code" TabIndex="50" />
                </td>
                <td>
                    <asp:CheckBox ID="CheckBoxJobComponentCustom5" runat="server" Text="Job Component Custom 5" TabIndex="50" />
                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;
                </td>
            </tr>
        </table>
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
            <caption>Jobs and Media</caption>
            <tr valign="top" align="left">
                <td align="left" style="text-align: left" valign="middle">
                    <asp:CheckBox ID="CheckBoxCampaignCode" runat="server" Text="Campaign" TabIndex="50" />
                </td>
                <td align="left" style="text-align: left" valign="middle">&nbsp;&nbsp;
                    <asp:CheckBox ID="CheckBoxFiscalPeriod" runat="server" Text="Fiscal Period" TabIndex="50" />
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;
                </td>
            </tr>
        </table>
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="left" style="text-align: left; border-bottom-style: solid;" valign="middle">
                    <asp:CheckBox ID="CheckBoxRequireProductCategorySelectionInTimesheet" runat="server" Text="Require product category selection in timesheet" TabIndex="50" Font-Underline="False" />
                </td>
            </tr>
            <tr>
                <td align="left" style="text-align: left; border-bottom-style: solid;" valign="middle">
                    <asp:CheckBox ID="CheckBoxRequireTimeComments" runat="server" Text="Require time comments" TabIndex="50" Font-Underline="False" />
                </td>
            </tr>
        </table>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelWebsites" runat="server"
        TitleText="Websites" Collapsed="True">
            <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <telerik:RadGrid ID="RadGridWebsites" runat="server" AllowPaging="True" AllowFilteringByColumn="false"
                AllowSorting="True" GridLines="None" PageSize="5" EnableEmbeddedSkins="True"
                ShowFooter="False" AutoGenerateColumns="False">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px"></PagerStyle>
                <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="ID"
                    InsertItemDisplay="Top">
                    <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                    <Columns>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnWebsiteAddress" HeaderText="Website Address"
                            SortExpression="WebsiteAddress" AllowFiltering="true">
                            <HeaderStyle Width="300" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemStyle Width="300" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <FooterStyle Width="300" VerticalAlign="Middle" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:TextBox ID="TextBoxWebsiteAddress" runat="server" Text='<%#Eval("WebsiteAddress")%>' MaxLength="100"
                                    SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBoxWebsiteAddressEditTextBox" runat="server" MaxLength="100"
                                    Text='<%#Eval("WebsiteAddress")%>' SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                            </EditItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnWebsiteTypeCode" HeaderText="Website Type"
                            SortExpression="WebsiteType" AllowFiltering="false">
                            <HeaderStyle Width="125" VerticalAlign="Middle" HorizontalAlign="Center" />
                            <ItemStyle Width="125" VerticalAlign="Middle" HorizontalAlign="Center" />
                            <FooterStyle Width="125" VerticalAlign="Middle" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <telerik:RadComboBox ID="RadComboBoxWebsiteType" runat="server" AutoPostBack="false" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                    DataTextField="Description" DataValueField="Code" Width="175">
                                </telerik:RadComboBox>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <telerik:RadComboBox ID="RadComboBoxWebsiteTypeEdit" runat="server" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                    AutoPostBack="false" DataTextField="Description" DataValueField="Code" Width="175">
                                </telerik:RadComboBox>
                            </EditItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnWebsiteIsInactive" HeaderText="Inactive" AllowFiltering="false"
                            SortExpression="IsInactive">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background standard-green" style='<%# If(Eval("IsInactive") = True, "display:block;", "display:none;")%>'>
                                    <asp:Image ID="ImageWebsiteIsInactive" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                </div>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="CheckBoxWebsiteIsInactiveEditCheckBox" runat="server" AutoPostBack="false" />
                            </EditItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSave" AllowFiltering="false">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <HeaderTemplate>
                                <asp:ImageButton ID="ImageButtonSaveAll" runat="server" SkinID="ImageButtonSaveAll"
                                    ToolTip="Click to save all rows" CommandName="SaveAll" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImageButtonSave" runat="server" SkinID="ImageButtonSaveWhite"
                                        ToolTip="Click to save this row" CommandName="SaveRow" />
                                </div>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImageButtonSaveNew" runat="server" SkinID="ImageButtonNewWhite"
                                        ToolTip="Click to add this row" CommandName="SaveNewRow" />
                                </div>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ID="ImageButtonSaveAllFooter" runat="server" SkinID="ImageButtonSaveAll"
                                    ToolTip="Click to save all rows" CommandName="SaveAll" />
                            </FooterTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnCancel" AllowFiltering="false">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background background-color-delete">
                                    <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite" ToolTip="Click to delete this row"
                                        CommandName="DeleteRow" />
                                </div>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImageButtonCancel" runat="server" SkinID="ImageButtonCancelWhite"
                                        ToolTip="Cancel add row" CommandName="CancelAddRow" />
                                </div>
                            </EditItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                    <RowIndicatorColumn>
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn>
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                </MasterTableView>
            </telerik:RadGrid>
                </ContentTemplate>
            </asp:UpdatePanel>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelContacts" runat="server"
        TitleText="Contacts" Collapsed="True">
            <asp:UpdatePanel runat="server" ID="UpdatePanel4" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <div style="vertical-align: top;">
                <div>
                    <asp:CheckBox ID="CheckBoxContactsShowInactive" runat="server" Text="Show Inactive" AutoPostBack="True" />
                </div>
                <div>
                    <telerik:RadGrid ID="RadGridContacts" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                        GridLines="None" EnableEmbeddedSkins="True" Width="99%" PageSize="10" AllowSorting="true">
                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px"></PagerStyle>
                        <MasterTableView DataKeyNames="ContactID, Code">
                            <Columns>
                                <telerik:GridTemplateColumn AllowFiltering="false">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <ItemTemplate>
                                        <div class="icon-background background-color-sidebar">
                                            <asp:ImageButton ID="butDetail" runat="server" CommandName="Detail" SkinID="ImageButtonViewWhite" CommandArgument='<%#Eval("ContactID").ToString%>' ToolTip="View Contact" />
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="Code" HeaderText="Code" UniqueName="Code">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Name" HeaderText="Name" UniqueName="Name">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn DataField="IsInactive" HeaderText="Is Inactive" UniqueName="IsInactive">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <ItemTemplate>
                                        <div class="icon-background standard-green" style='<%# If(Eval("IsInactive") = True, "display:block;", "display:none;")%>'>
                                            <asp:Image ID="ImageContactIsInactive" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete" AllowFiltering="false">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <ItemTemplate>
                                        <div class="icon-background background-color-delete">
                                            <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite" ToolTip="Click to delete this row"
                                                CommandName="DeleteRow" />
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
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
                </div>
                <div style="margin-top: 4px;">
                    <asp:Button ID="ButtonAddContact" runat="server" Text="Add Contact" />
                </div>
            </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelDivisionProduct" runat="server"
        TitleText="Division/Product" Collapsed="True">
            <asp:UpdatePanel runat="server" ID="UpdatePanel5" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <div style="vertical-align: top;">
                <fieldset style="">
                    <legend>Division</legend>
                    <div>
                        <asp:CheckBox ID="CheckBoxDivisionShowInactive" runat="server" Text="Show Inactive" AutoPostBack="True" />
                    </div>
                    <div>
                        <telerik:RadGrid ID="RadGridDivisions" runat="server" AllowPaging="true" AutoGenerateColumns="False" AllowMultiRowSelection="false"
                            GridLines="None" EnableEmbeddedSkins="True" Width="99%" PageSize="10" AllowSorting="true" AllowFilteringByColumn="true">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px"></PagerStyle>
                            <MasterTableView DataKeyNames="Code, ClientCode">
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn" AllowFiltering="false">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="18" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="18" />
                                        <ItemTemplate>
                                            <telerik:RadButton ID="RadButtonSelected" runat="server" ButtonType="ToggleButton" ToggleType="CheckBox"
                                                CommandName="SelectDivision" CommandArgument='<%#Eval("Code")%>' OnClick="RadButtonSelected_Click" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="false">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="butDetail" runat="server" CommandName="Detail" SkinID="ImageButtonViewWhite" CommandArgument='<%#Eval("Code").ToString%>' ToolTip="View Division" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="false">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="butCopy" runat="server" CommandName="Copy" SkinID="ImageButtonCopyWhite" CommandArgument='<%#Eval("Code").ToString%>' ToolTip="Copy Division" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="Name" HeaderText="Division" UniqueName="Name">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn DataField="IsInactive" HeaderText="Is Inactive" UniqueName="IsInactive" ReadOnly="true" AllowFiltering="false">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background standard-green" style='<%# If(Eval("IsActive") = False, "display:block;", "display:none;")%>'>
                                                <asp:Image ID="ImageContactIsInactive" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete" AllowFiltering="false">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-delete">
                                                <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite" ToolTip="Click to delete this row"
                                                    CommandName="DeleteRow" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
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
                    </div>
                    <div style="margin-top: 4px;">
                        <asp:Button ID="ButtonAddDivision" runat="server" Text="Add Division" />
                    </div>
                </fieldset>
                <fieldset style="">
                    <legend>Product</legend>
                    <div>
                        <asp:CheckBox ID="CheckBoxProductShowInactive" runat="server" Text="Show Inactive" AutoPostBack="True" />
                    </div>
                    <div>
                        <telerik:RadGrid ID="RadGridProducts" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                            GridLines="None" EnableEmbeddedSkins="True" Width="99%" PageSize="5" AllowSorting="true" AllowFilteringByColumn="true">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px"></PagerStyle>
                            <MasterTableView DataKeyNames="Code, DivisionCode, ClientCode">
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="colDetails" AllowFiltering="false">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="butDetail" runat="server" CommandName="Detail" SkinID="ImageButtonViewWhite" CommandArgument='<%#Eval("Code").ToString%>' ToolTip="View Product" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="false">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="butCopy" runat="server" CommandName="Copy" SkinID="ImageButtonCopyWhite" CommandArgument='<%#Eval("Code").ToString%>' ToolTip="Copy Product" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="Office.Name" HeaderText="Office" UniqueName="OfficeName" AllowFiltering="false">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Division.Name" HeaderText="Division" UniqueName="DivisionName" AllowFiltering="false">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Name" HeaderText="Product" UniqueName="Product">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn DataField="IsInactive" HeaderText="Is Inactive" UniqueName="IsInactive" AllowFiltering="false">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background standard-green" style='<%# If(Eval("IsActive") = False, "display:block;", "display:none;")%>'>
                                                <asp:Image ID="ImageContactIsInactive" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete" AllowFiltering="false">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-delete">
                                                <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite" ToolTip="Click to delete this row"
                                                    CommandName="DeleteRow" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
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
                    </div>
                    <div style="margin-top: 4px;">
                        <asp:Button ID="ButtonAddProduct" runat="server" Text="Add Product" />
                    </div>
                </fieldset>
            </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    </ew:CollapsablePanel>
    </div>
    

</asp:Content>
