<%@ Page Title="Edit Product" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_AddDiary.aspx.vb" Inherits="Webvantage.Maintenance_AddDiary" %>

<asp:Content ID="conProductContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <script type="text/javascript">
        function AEDefaultExists(sender, args) {

            ShowMessage('Only one default A/E is allowed.');

            args.set_cancel(true);

        }
        function InactiveConfirm(sender, args) {

            args.set_cancel(!window.confirm('This A/E is the default A/E.  Marking this A/E inactive will remove the default status.  Do you want to continue?'));

        }
        function DefaultConfirm(sender, args) {

            args.set_cancel(!window.confirm('This A/E is inactive.  Marking this A/E as the default will activate the A/E.  Do you want to continue?'));

        }
    </script>
    <div >
        <telerik:RadToolBar ID="RadToolbarProduct" runat="server" AutoPostBack="True" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonSave" SkinID="RadToolBarButtonSave" Text="" Value="Save"
                    ToolTip="Save" ValidationGroup="Save" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonNew" SkinID="RadToolBarButtonNew" Text="New" Value="New" ToolTip="Add New" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonUploadDocument" SkinID="RadToolBarButtonUpload" Text="Upload Documents" Value="Upload"
                    ToolTip="Upload a document" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonDocuments" Text="Documents" Value="ViewDocs"
                    ToolTip="View documents" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarRefresh" SkinID="RadToolBarButtonRefresh" Value="Refresh"
                    ToolTip="Refresh" />
                <telerik:RadToolBarButton SkinId="RadToolBarButtonBookmark" Text="" Value="Bookmark"
                    ToolTip="Bookmark" Visible="true" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div >
    </div>
    <ew:CollapsablePanel ID="CollapsablePanelHeader" runat="server"
        TitleText="Product Information" >
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <table cellpadding="2" cellspacing="0" width="100%" align="center" border="0">
                <tr>
                    <td colspan="2" style="height: 10px">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="2">
                            <tr>
                                <td style="width: 30%; text-align: right">Code:</td>
                                <td style="width: 70%">&nbsp;&nbsp;
                                <asp:TextBox ID="TextBoxProductCode" runat="server" SkinID="TextBoxCodeSmall" ValidationGroup="Save"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVCode" runat="server" ControlToValidate="TextBoxProductCode" ValidationGroup="Save"
                                        CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                        ErrorMessage="<br />Code is required."></asp:RequiredFieldValidator>&nbsp; &nbsp;
                                <asp:CheckBox ID="CheckBoxIsNewBusiness" runat="server" Text="New Business" Enabled="False" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%; text-align: right">Name:</td>
                                <td style="width: 70%">&nbsp;&nbsp;
                                <asp:TextBox ID="TextBoxProductName" runat="server"  ValidationGroup="Save" SkinID="TextBoxStandard"
                                    Width="275px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVName" runat="server" ControlToValidate="TextBoxProductName" ValidationGroup="Save"
                                        CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                        ErrorMessage="<br />Name is required."></asp:RequiredFieldValidator>&nbsp;&nbsp;
                                <asp:CheckBox ID="CheckBoxIsInactive" runat="server" Text="Inactive" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%; text-align: right">Client:</td>
                                <td style="width: 70%">&nbsp;&nbsp;
                                <telerik:RadComboBox ID="RadComboBoxClient" runat="server" AutoPostBack="True" TabIndex="30" Width="275px" OnSelectedIndexChanged="RadComboBoxClient_SelectedIndexChanged" CausesValidation="false" ValidationGroup="Save" SkinID="RadComboBoxStandard">
                                </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="RFVClient" runat="server" ControlToValidate="RadComboBoxClient" ValidationGroup="Save"
                                        CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                        ErrorMessage="<br />Client is required."></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%; text-align: right">Division:</td>
                                <td style="width: 70%">&nbsp;&nbsp;
                                <telerik:RadComboBox ID="RadComboBoxDivision" runat="server" AutoPostBack="false" TabIndex="30" Width="275px" ValidationGroup="Save" SkinID="RadComboBoxStandard">
                                </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="RFVDivision" runat="server" ControlToValidate="RadComboBoxDivision" ValidationGroup="Save"
                                        CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                        ErrorMessage="<br />Division is required."></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 30%; text-align: right">Office:</td>
                                <td style="width: 70%">&nbsp;&nbsp;
                                <telerik:RadComboBox ID="RadComboBoxOffice" runat="server" AutoPostBack="false" TabIndex="30" Width="275px" ValidationGroup="Save" SkinID="RadComboBoxStandard">
                                </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="RFVOffice" runat="server" ControlToValidate="RadComboBoxOffice" ValidationGroup="Save"
                                        CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                        ErrorMessage="<br />Office is required."></asp:RequiredFieldValidator>
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
                </ContentTemplate>
            </asp:UpdatePanel>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelAddresses" runat="server"
        TitleText="Addresses"  Collapsed="True">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <table align="left" border="0" cellpadding="2" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <table border="0" cellspacing="0" cellpadding="2" width="100%">
                            <tr>
                                <td style="text-decoration: underline">Billing Address
                                </td>
                                <td align="center">&nbsp;&nbsp;Refresh From&nbsp;<asp:LinkButton ID="LinkButtonBilling_Client" runat="server" Text="Client" TabIndex="-1"></asp:LinkButton>
                                    &nbsp;&nbsp;<asp:LinkButton ID="LinkButtonBilling_Division" runat="server" Text="Division" TabIndex="-1"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" width="30%">Address 1:</td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxBillingAddress1" runat="server"  Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">Address 2:</td>
                                <td>&nbsp;&nbsp;
                                <asp:TextBox ID="TextBoxBillingAddress2" runat="server"  Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: right" valign="middle">City:</td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxBillingCity" runat="server"  Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: right" valign="middle">County:</td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxBillingCounty" runat="server"  Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: right" valign="middle">State:</td>
                                <td align="left" style="width: 70%" valign="middle">&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxBillingState" runat="server"  Width="60px" SkinID="TextBoxStandard"></asp:TextBox>&nbsp;&nbsp;Zip:&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxBillingZip" runat="server"  Width="155px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: right" valign="middle">Country:</td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxBillingCountry" runat="server"  Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table border="0" cellspacing="0" cellpadding="2" width="100%">
                            <tr>
                                <td style="text-decoration: underline">Statement Address
                                </td>
                                <td align="center">&nbsp;&nbsp;Refresh From&nbsp;<asp:LinkButton ID="LinkButtonStatement_Client" runat="server" Text="Client" TabIndex="-1"></asp:LinkButton>
                                    &nbsp;&nbsp;<asp:LinkButton ID="LinkButtonStatement_Division" runat="server" Text="Division" TabIndex="-1"></asp:LinkButton>
                                    &nbsp;&nbsp;<asp:LinkButton ID="LinkButtonStatement_Billing" runat="server" Text="Billing" TabIndex="-1"></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" width="30%">Address 1:</td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxStatementAddress1" runat="server"  Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">Address 2:</td>
                                <td>&nbsp;&nbsp;
                                <asp:TextBox ID="TextBoxStatementAddress2" runat="server"  Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: right" valign="middle">City:</td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxStatementCity" runat="server"  Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: right" valign="middle">County:</td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxStatementCounty" runat="server"  Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: right" valign="middle">State:</td>
                                <td align="left" style="width: 70%" valign="middle">&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxStatementState" runat="server"  Width="60px" SkinID="TextBoxStandard"></asp:TextBox>&nbsp;&nbsp;Zip:&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxStatementZip" runat="server"  Width="155px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="text-align: right" valign="middle">Country:</td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxStatementCountry" runat="server"  Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table border="0" cellspacing="0" cellpadding="2" width="100%">
                            <tr>
                                <td style="text-align: right" width="10%">Phone:
                                </td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxBillingPhone" runat="server"  SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                                <td style="text-align: right" width="10%">Ext:
                                </td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxBillingPhoneExt" runat="server"  Width="95px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" width="10%">Fax:
                                </td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxBillingFax" runat="server"  SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                                <td style="text-align: right" width="10%">Ext:
                                </td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxBillingFaxExt" runat="server"  Width="95px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table border="0" cellspacing="0" cellpadding="2" width="100%">
                            <tr>
                                <td style="text-align: right" width="10%">Phone:
                                </td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxStatementPhone" runat="server" SkinID="TextBoxStandard" ></asp:TextBox>
                                </td>
                                <td style="text-align: right" width="10%">Ext:
                                </td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxStatementPhoneExt" runat="server"  Width="95px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" width="10%">Fax:
                                </td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxStatementFax" runat="server" SkinID="TextBoxStandard" ></asp:TextBox>
                                </td>
                                <td style="text-align: right" width="10%">Ext:
                                </td>
                                <td>&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxStatementFaxExt" runat="server"  Width="95px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
                </ContentTemplate>
            </asp:UpdatePanel>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelOptions" runat="server"
        TitleText="Options" Collapsed="True">
        <table align="center" border="0" cellpadding="2" cellspacing="0" width="95%">
            <tr>
                <td style="width: 30%; text-align: right">Attention Line:
                </td>
                <td>&nbsp;&nbsp;<asp:TextBox ID="TextBoxAttentionLine" runat="server"
                    SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">Currency:
                </td>
                <td>&nbsp;&nbsp;<telerik:RadComboBox ID="RadComboBoxCurrency" runat="server" AutoPostBack="true" TabIndex="30" Width="275px" Enabled="false" SkinID="RadComboBoxStandard">
                </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td>
                    <table align="center" width="100%" border="0" cellspacing="0" cellpadding="2">
                        <caption>User Defined Fields</caption>
                        <tr>
                            <td>&nbsp;&nbsp;
                                <asp:TextBox ID="TextBoxUserDefinedField1" runat="server"  Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="30%">&nbsp;&nbsp;
                                <asp:TextBox ID="TextBoxUserDefinedField2" runat="server"  Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;&nbsp;
                                <asp:TextBox ID="TextBoxUserDefinedField3" runat="server"  Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;&nbsp;
                                <asp:TextBox ID="TextBoxUserDefinedField4" runat="server"  Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
            <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                        <br />
                        <telerik:RadGrid ID="RadGridSortKeys" runat="server" AllowPaging="True"
                            AllowSorting="True" GridLines="None" PageSize="3" EnableEmbeddedSkins="True"
                            ShowFooter="False" AutoGenerateColumns="False" Width="275px">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" ></PagerStyle>
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
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
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
                        <br />
                </ContentTemplate>
            </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelAccountExecutives" runat="server"
        TitleText="Account Executives" Collapsed="True">
            <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td colspan="2">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="95%">
                            <tr>
                                <td valign="top" align="center" width="30%">Available<br />
                                    <br />
                                    <telerik:RadGrid ID="RadGridEmployees" runat="server" AllowPaging="true" PageSize="10"
                                        AllowSorting="True" GridLines="None" EnableEmbeddedSkins="True" AllowMultiRowSelection="true"
                                        ShowFooter="False" AutoGenerateColumns="False" Width="275px">
                                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" ></PagerStyle>
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="true" />
                                        </ClientSettings>
                                        <MasterTableView CommandItemDisplay="None" DataKeyNames="Code">
                                            <Columns>
                                                <telerik:GridClientSelectColumn />
                                                <telerik:GridBoundColumn DataField="Code" UniqueName="Code" HeaderText="Code"
                                                    SortExpression="Code" ReadOnly="true">
                                                    <HeaderStyle Width="80" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                    <ItemStyle Width="80" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                    <FooterStyle Width="80" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Name" UniqueName="Name" HeaderText="Name"
                                                    SortExpression="Name" ReadOnly="true">
                                                    <HeaderStyle Width="175" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                    <ItemStyle Width="175" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                    <FooterStyle Width="175" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                            </Columns>
                                            <RowIndicatorColumn>
                                                <HeaderStyle Width="20px" />
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn>
                                                <HeaderStyle Width="20px" />
                                            </ExpandCollapseColumn>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                                <td align="center" width="5%">
                                    <asp:ImageButton ID="ImageButtonAddAccountExecutive" runat="server" SkinID="ImageButtonAdd"
                                        CausesValidation="False" /><br />
                                    <br />
                                    <asp:ImageButton ID="ImageButtonRemoveAccountExecutive" runat="server" SkinID="ImageButtonRemove"
                                        CausesValidation="False" />
                                </td>
                                <td valign="top" align="center" width="65%">Assigned<br />
                                    <br />
                                    <telerik:RadGrid ID="RadGridAccountExecutives" runat="server" AllowPaging="true" PageSize="10"
                                        AllowSorting="True" GridLines="None" EnableEmbeddedSkins="True" AllowMultiRowSelection="true"
                                        ShowFooter="False" AutoGenerateColumns="False" Width="100%">
                                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" ></PagerStyle>
                                        <ClientSettings>
                                            <Selecting AllowRowSelect="true" />
                                        </ClientSettings>
                                        <MasterTableView CommandItemDisplay="None" DataKeyNames="EmployeeCode" EditMode="InPlace">
                                            <Columns>
                                                <telerik:GridClientSelectColumn />
                                                <telerik:GridBoundColumn DataField="EmployeeCode" UniqueName="EmployeeCode" HeaderText="Employee Code"
                                                    SortExpression="EmployeeCode" ReadOnly="true">
                                                    <HeaderStyle Width="80" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                    <ItemStyle Width="80" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                    <FooterStyle Width="80" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Employee" UniqueName="Employee" HeaderText="Employee"
                                                    SortExpression="Employee" ReadOnly="true">
                                                    <HeaderStyle Width="175" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                    <ItemStyle Width="175" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                    <FooterStyle Width="175" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn UniqueName="IsDefault" HeaderText="Is Default"
                                                    SortExpression="IsDefault">
                                                    <HeaderStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                    <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                    <FooterStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                    <%--<ItemTemplate>
                                                        <telerik:RadButton ID="RadButtonIsDefault" runat="server" ButtonType="ToggleButton" Checked='<%#Eval("IsDefault")%>' ToggleType="CheckBox"
                                                            OnClientClicking='<%#AssignAEDefaultJavascript(Eval("IsDefault"), Eval("IsInactive"), Eval("EmployeeCode"))%>' CommandArgument='<%#Eval("EmployeeCode")%>' OnClick="RadButtonIsDefault_Click" />
                                                    </ItemTemplate>--%>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridCheckBoxColumn DataField="Terminated" UniqueName="Terminated" HeaderText="Terminated"
                                                    SortExpression="Terminated" ReadOnly="true">
                                                    <HeaderStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                    <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                    <FooterStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                </telerik:GridCheckBoxColumn>
                                                <telerik:GridTemplateColumn UniqueName="IsInactive" HeaderText="Is Inactive"
                                                    SortExpression="IsInactive">
                                                    <HeaderStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                    <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                    <FooterStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                    <%--<ItemTemplate>
                                                        <telerik:RadButton ID="RadButtonIsInactive" runat="server" ButtonType="ToggleButton" Checked='<%#Eval("IsInactive")%>' ToggleType="CheckBox"
                                                            OnClientClicking='<%#AssignInactiveJavascript(Eval("IsDefault"), Eval("IsInactive"))%>' CommandArgument='<%#Eval("EmployeeCode")%>' OnClick="RadButtonIsInactive_Click" />
                                                    </ItemTemplate>--%>
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
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;
                    </td>
                </tr>
            </table>
                </ContentTemplate>
            </asp:UpdatePanel>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelContacts" runat="server"
        TitleText="Contacts"  Collapsed="True">
        <table cellpadding="2" cellspacing="0" width="95%" align="center" border="0">
            <tr>
                <td>
            <asp:UpdatePanel runat="server" ID="UpdatePanel4" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                        <br />
                        <telerik:RadGrid ID="RadGridContacts" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                            GridLines="None" EnableEmbeddedSkins="True" Width="99%" PageSize="10" AllowSorting="true">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" ></PagerStyle>
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
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="160" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="160" />
                                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="160" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn DataField="IsInactive" HeaderText="Is Inactive" UniqueName="IsInactive">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBoxContactIsInactive" runat="server" Enabled="false" AutoPostBack="false" Checked='<%#Eval("IsInactive") %>' />
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
                </ContentTemplate>
            </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <br />
                    <asp:Button ID="ButtonAddContact" runat="server" Text="Add Contact" />
                    <br />
                </td>
            </tr>
        </table>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelCompanyProfile" runat="server"
        TitleText="Company Profile" Collapsed="True">
        <table align="center" border="0" cellpadding="2" cellspacing="0" width="100%">
            <tr>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="2">
                        <tr>
                            <td width="20%" align="right">Industry:
                            </td>
                            <td>&nbsp;&nbsp;
                                <telerik:RadComboBox ID="RadComboBoxIndustry" runat="server" TabIndex="30" Width="275px" Enabled="true" SkinID="RadComboBoxStandard">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Specialty:
                            </td>
                            <td width="30%">&nbsp;&nbsp;
                                <telerik:RadComboBox ID="RadComboBoxSpecialty" runat="server" TabIndex="30" Width="275px" Enabled="true" SkinID="RadComboBoxStandard">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Region:
                            </td>
                            <td>&nbsp;&nbsp;
                                <telerik:RadComboBox ID="RadComboBoxRegion" runat="server" TabIndex="30" Width="275px" Enabled="true" SkinID="RadComboBoxStandard">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Revenue:
                            </td>
                            <td>&nbsp;&nbsp;
                                <telerik:RadNumericTextBox ID="RadNumericTextBoxRevenue" runat="server" Type="Number" Style="text-align: right"></telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="middle">&nbsp;&nbsp;
                                # of Employees:
                            </td>
                            <td>&nbsp;&nbsp;
                                <telerik:RadNumericTextBox ID="RadNumericTextBoxNumEmployees" runat="server" Type="Number" Style="text-align: right">
                                    <NumberFormat GroupSeparator="" DecimalDigits="0" AllowRounding="true" KeepNotRoundedValue="false" />
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">&nbsp;
                            </td>
                            <td>&nbsp;&nbsp;
                                <asp:CheckBox ID="CheckBoxCaseStudy" runat="server" Text="Case Study Done" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">&nbsp;
                            </td>
                            <td>&nbsp;&nbsp;
                                <asp:CheckBox ID="CheckBoxReference" runat="server" Text="Use as Reference" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
            <asp:UpdatePanel runat="server" ID="UpdatePanel5" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                        <br />
                        <telerik:RadGrid ID="RadGridCompanyProfileAffiliations" runat="server" AllowPaging="True"
                            AllowSorting="True" GridLines="None" PageSize="3" EnableEmbeddedSkins="True"
                            ShowFooter="False" AutoGenerateColumns="False" Width="375px">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" ></PagerStyle>
                            <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="ID"
                                InsertItemDisplay="Top">
                                <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAffiliation" HeaderText="Affiliation"
                                        SortExpression="Affiliation.Name" AllowFiltering="false">
                                        <HeaderStyle Width="300" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemStyle Width="300" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle Width="300" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <telerik:RadComboBox ID="RadComboBoxAffiliation" runat="server" AutoPostBack="false" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                DataTextField="Description" DataValueField="ID" Width="275">
                                            </telerik:RadComboBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadComboBox ID="RadComboBoxAffiliationEdit" runat="server" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                AutoPostBack="false" DataTextField="Description" DataValueField="ID" Width="275">
                                            </telerik:RadComboBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSave" AllowFiltering="false">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <EditItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImageButtonSaveNew" runat="server" SkinID="ImageButtonNewWhite" ToolTip="Click to add this row" CommandName="SaveNewRow" />
                                            </div>
                                        </EditItemTemplate>
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
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table width="95%" border="0" cellspacing="0" cellpadding="2">
                        <tr>
                            <td width="15%" align="right">Notes:
                            </td>
                            <td>&nbsp;&nbsp;
                                <asp:TextBox ID="TextBoxNotes" runat="server"  Rows="3" Width="80%" MultiLine="true" SkinID="TextBoxStandard"></asp:TextBox>
                                <asp:TextBox ID="TextBoxCompanyProfileID" runat="server"  Visible="False" SkinID="TextBoxStandard"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelActivitySummary" runat="server" 
        TitleText="Activity Summary"  Collapsed="True">
        <table align="center" border="0" cellpadding="2" cellspacing="0" width="100%">
            <tr>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="2">
                        <tr>
                            <td width="20%" align="right">Lead Date:
                            </td>
                            <td>&nbsp;&nbsp;
                                <telerik:RadDatePicker ID="RadDatePickerLeadDate" runat="server" SkinID="RadDatePickerStandard">
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Source:
                            </td>
                            <td width="30%">&nbsp;&nbsp;
                                <telerik:RadComboBox ID="RadComboBoxSource" runat="server" TabIndex="30" Width="275px" Enabled="true" SkinID="RadComboBoxStandard">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Last Activity Date:
                            </td>
                            <td>&nbsp;&nbsp;
                                <asp:TextBox ID="TextBoxLastActivityDate" runat="server" Enabled="false" ReadOnly="true" SkinID="TextBoxStandard">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Last Contact Date:
                            </td>
                            <td>&nbsp;&nbsp;
                                <telerik:RadDatePicker ID="RadDatePickerLastContactDate" runat="server" SkinID="RadDatePickerStandard">
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Sold Date:
                            </td>
                            <td>&nbsp;&nbsp;
                                <telerik:RadDatePicker ID="RadDatePickerSoldDate" runat="server" SkinID="RadDatePickerStandard">
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Lost Date:
                            </td>
                            <td>&nbsp;&nbsp;
                                <telerik:RadDatePicker ID="RadDatePickerLostDate" runat="server" SkinID="RadDatePickerStandard">
                                </telerik:RadDatePicker>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="middle">&nbsp;&nbsp; Probability:
                            </td>
                            <td>&nbsp;&nbsp;
                                <telerik:RadNumericTextBox ID="RadNumericTextBoxProbability" runat="server" Type="Number" Style="text-align: right">
                                    <NumberFormat GroupSeparator="" DecimalDigits="0" AllowRounding="true" KeepNotRoundedValue="false" />
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Rating:</td>
                            <td>&nbsp;&nbsp;
                                <telerik:RadComboBox ID="RadComboBoxRating" runat="server" TabIndex="30" Width="275px" Enabled="true" SkinID="RadComboBoxStandard">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">Current Provider:</td>
                            <td>&nbsp;&nbsp;
                                <asp:TextBox ID="TextBoxCurrentProvider" runat="server" SkinID="TextBoxStandard">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr id="RowTotalOpportunity" runat="server">
                            <td align="right">Total Opportunity:</td>
                            <td>&nbsp;&nbsp;
                                <telerik:RadNumericTextBox ID="RadNumericTextBoxTotalOpportunity" runat="server" ReadOnly="True">
                                    <NumberFormat GroupSeparator="" DecimalDigits="2" />
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
            <asp:UpdatePanel runat="server" ID="UpdatePanel6" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                        <br />
                        <telerik:RadGrid ID="RadGridCompetitors" runat="server" AllowPaging="True"
                            AllowSorting="True" GridLines="None" PageSize="3" EnableEmbeddedSkins="True"
                            ShowFooter="False" AutoGenerateColumns="False" Width="375px">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" ></PagerStyle>
                            <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="ID"
                                InsertItemDisplay="Top">
                                <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnCompetitor" HeaderText="Competitor"
                                        SortExpression="Competitor.Name" AllowFiltering="false">
                                        <HeaderStyle Width="300" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemStyle Width="300" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle Width="300" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <telerik:RadComboBox ID="RadComboBoxCompetitor" runat="server" AutoPostBack="false" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                DataTextField="Description" DataValueField="ID" Width="275">
                                            </telerik:RadComboBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadComboBox ID="RadComboBoxCompetitorEdit" runat="server" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                AutoPostBack="false" DataTextField="Description" DataValueField="ID" Width="275">
                                            </telerik:RadComboBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSave" AllowFiltering="false">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <EditItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImageButtonSaveNew" runat="server" SkinID="ImageButtonNewWhite"
                                                    ToolTip="Click to add this row" CommandName="SaveNewRow" />
                                            </div>
                                        </EditItemTemplate>
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
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="TextBoxActivityID" runat="server"  Visible="False" SkinID="TextBoxStandard"></asp:TextBox>
                    <telerik:RadGrid ID="RadGridActivitySummary" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                        GridLines="None" EnableEmbeddedSkins="True" Width="99%" PageSize="10" AllowSorting="true">
                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" ></PagerStyle>
                        <MasterTableView DataKeyNames="AlertID">
                            <Columns>
                                <telerik:GridTemplateColumn AllowFiltering="false">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <ItemTemplate>
                                        <div class="icon-background background-color-sidebar">
                                            <asp:ImageButton ID="ImageButtonEdit" runat="server" CommandName="EditDiary" SkinID="ImageButtonEditWhite" ToolTip="Edit Diary" />
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="ActivityDate" HeaderText="Activity Date" UniqueName="ActivityDate" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EmployeeName" HeaderText="Employee Name" UniqueName="EmployeeName" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ActivityType" HeaderText="Activity Type" UniqueName="ActivityType" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Subject" HeaderText="Subject" UniqueName="Subject" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="25%" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="25%" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="25%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Body" HeaderText="Body" UniqueName="Body" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="25%" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="25%" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="25%" />
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
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <br />
                    <asp:Button ID="ButtonAddDiary" runat="server" Text="Add Diary" />
                    <br />
                </td>
            </tr>
        </table>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelContracts" runat="server"
        TitleText="Contracts/Opportunities"  Collapsed="True">
        <table cellpadding="2" cellspacing="0" width="95%" align="center" border="0">
            <tr>
                <td>
                    <telerik:RadGrid ID="RadGridContracts" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                        GridLines="None" EnableEmbeddedSkins="True" Width="99%" PageSize="10" AllowSorting="true">
                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" ></PagerStyle>
                        <MasterTableView DataKeyNames="ID">
                            <Columns>
                                <telerik:GridTemplateColumn AllowFiltering="false">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <ItemTemplate>
                                        <div class="icon-background background-color-sidebar">
                                            <asp:ImageButton ID="butDetail" runat="server" CommandName="Detail" SkinID="ImageButtonViewWhite" CommandArgument='<%#Eval("ID").ToString%>' ToolTip="View Contract" />
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="Code" HeaderText="Code" UniqueName="Code">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Description" HeaderText="Description" UniqueName="Description">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="160" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="160" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="160" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn DataField="IsContract" HeaderText="Is Contract" UniqueName="IsContract">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBoxContactIsContract" runat="server" Enabled="false" AutoPostBack="false" Checked='<%#Eval("IsContract")%>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="IsInactive" HeaderText="Is Inactive" UniqueName="IsInactive">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBoxContactIsInactive" runat="server" Enabled="false" AutoPostBack="false" Checked='<%#Eval("IsInactive")%>' />
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
                </td>
            </tr>
            <tr>
                <td align="center">
                    <br />
                    <asp:Button ID="ButtonAddContract" runat="server" Text="Add Contract" />
                    <br />
                </td>
            </tr>
        </table>
    </ew:CollapsablePanel>
</asp:Content>
