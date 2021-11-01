<%@ Page Title="Edit Division" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_DivisionEdit.aspx.vb" Inherits="Webvantage.Maintenance_DivisionEdit" %>

<asp:Content ID="conDivisionContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolbarDivision" runat="server" AutoPostBack="True" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonSave" SkinID="RadToolBarButtonSave" Text="" Value="Save"
                    ToolTip="Save" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonNew" SkinID="RadToolBarButtonNew" Text="New" Value="New" ToolTip="Add New" CausesValidation="false" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonUploadDocument" SkinID="RadToolBarButtonUpload" Text="Upload Documents" Value="Upload"
                    ToolTip="Upload a document" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonDocuments" Text="View Documents" Value="ViewDocs"
                    ToolTip="View documents" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarRefresh" SkinID="RadToolBarButtonRefresh" Value="Refresh"
                    ToolTip="Refresh" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
        <ew:CollapsablePanel ID="CollapsablePanelHeader" runat="server"
            TitleText="Division Information">
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
                                        <asp:TextBox ID="TextBoxDivisionCode" runat="server" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFVCode" runat="server" ControlToValidate="TextBoxDivisionCode"
                                            CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                            ErrorMessage="<br />Code is required."></asp:RequiredFieldValidator>&nbsp; &nbsp;
                                        <asp:CheckBox ID="CheckBoxIsNewBusiness" runat="server" Text="New Business" Enabled="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30%; text-align: right">Name:</td>
                                    <td style="width: 70%">&nbsp;&nbsp;
                                        <asp:TextBox ID="TextBoxDivisionName" runat="server"
                                            SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFVName" runat="server" ControlToValidate="TextBoxDivisionName"
                                            CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                            ErrorMessage="<br />Name is required."></asp:RequiredFieldValidator>&nbsp;&nbsp;
                                        <asp:CheckBox ID="CheckBoxIsInactive" runat="server" Text="Inactive" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30%; text-align: right">Client:</td>
                                    <td style="width: 70%">&nbsp;&nbsp;
                                        <telerik:RadComboBox ID="RadComboBoxClient" runat="server" AutoPostBack="true" TabIndex="30" Width="275px" CausesValidation="false" OnSelectedIndexChanged="RadComboBoxClient_SelectedIndexChanged" SkinID="RadComboBoxStandard">
                                        </telerik:RadComboBox>
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
            TitleText="Addresses" Collapsed="True">
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
                                        </div>

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
                                    <td style="text-decoration: underline">Statement Address
                                    </td>
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
                </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelOptions" runat="server"
            TitleText="Options" Collapsed="True">
            <table align="left" border="0" cellpadding="2" cellspacing="0" width="100%">
                <tr>
                    <td style="width: 30%; text-align: right">Attention Line:
                    </td>
                    <td>&nbsp;&nbsp;<asp:TextBox ID="TextBoxAttentionLine" runat="server"
                        SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
            <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                            <br />
                            <telerik:RadGrid ID="RadGridSortKeys" runat="server" AllowPaging="True"
                                AllowSorting="True" GridLines="None" PageSize="3" EnableEmbeddedSkins="True"
                                ShowFooter="False" AutoGenerateColumns="False" Width="400px">
                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom"></PagerStyle>
                                <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="SortKey"
                                    InsertItemDisplay="Top">
                                    <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                    <Columns>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSortKey" HeaderText="Sort Option(s)"
                                            SortExpression="SortKey">
                                            <HeaderStyle Width="" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemStyle Width="" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <FooterStyle Width="" VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxSortKey" runat="server" MaxLength="20" Text='<%#Eval("SortKey")%>'
                                                    SkinID="TextBoxStandard" Width="275"></asp:TextBox>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBoxSortKeyEditTextBox" runat="server" MaxLength="20"
                                                     SkinID="TextBoxStandard" Text='<%#Eval("SortKey")%>' Width="275"></asp:TextBox>
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
                            <br />
                </ContentTemplate>
            </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelContacts" runat="server"
            TitleText="Contacts" Collapsed="True">
            <asp:UpdatePanel runat="server" ID="UpdatePanel4" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                <br />
                <table cellpadding="2" cellspacing="0" width="100%" align="center" border="0">
                    <tr>
                        <td align="right" valign="middle">
                            <asp:CheckBox ID="CheckBoxContactsShowInactive" runat="server" Text="Show Inactive" AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadGrid ID="RadGridContacts" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                                GridLines="None" EnableEmbeddedSkins="True" Width="99%" PageSize="10" AllowSorting="true">
                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom"></PagerStyle>
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
                                                <div class="icon-background standard-green" style='<%# If(Eval("IsInactive") = True, "display:block;", "display:none;")%>'>
                                                    <asp:Image ID="ImageIsInactive" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelProducts" runat="server"
            TitleText="Products" Collapsed="True">
            <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                <br />
                <table align="center" border="0" cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td align="right" valign="middle">
                            <asp:CheckBox ID="CheckBoxProductShowInactive" runat="server" Text="Show Inactive" AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadGrid ID="RadGridProducts" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                                GridLines="None" EnableEmbeddedSkins="True" Width="99%" PageSize="10" AllowSorting="true">
                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom"></PagerStyle>
                                <MasterTableView DataKeyNames="Code, DivisionCode, ClientCode">
                                    <Columns>
                                        <telerik:GridTemplateColumn UniqueName="colDetails">
                                            <HeaderStyle CssClass="radgrid-icon-column" />
                                            <ItemStyle CssClass="radgrid-icon-column" />
                                            <FooterStyle CssClass="radgrid-icon-column" />
                                            <ItemTemplate>
                                                <div class="icon-background background-color-sidebar">
                                                    <asp:ImageButton ID="butDetail" runat="server" CommandName="Detail" SkinID="ImageButtonViewWhite" CommandArgument='<%#Eval("Code").ToString%>' ToolTip="View Product" />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="Office.Name" HeaderText="Office" UniqueName="OfficeName">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Name" HeaderText="Product" UniqueName="ProductName">
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn DataField="IsInactive" HeaderText="Is Inactive" UniqueName="IsInactive">
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80" />
                                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80" />
                                            <ItemTemplate>
                                                <div class="icon-background standard-green" style='<%# If(CBool(Eval("IsActive")) = false, "display:block;", "display:none;")%>'>
                                                    <asp:Image ID="ImagContactIsInactive" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
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
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <asp:Button ID="ButtonAddProduct" runat="server" Text="Add Product" />
                            <br />
                        </td>
                    </tr>
                </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </ew:CollapsablePanel>
    </div>
    
</asp:Content>
