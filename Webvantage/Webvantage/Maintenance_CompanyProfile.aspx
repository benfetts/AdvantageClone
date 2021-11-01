<%@ Page Title="Edit Product" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_CompanyProfile.aspx.vb" Inherits="Webvantage.Maintenance_CompanyProfile" %>

<asp:Content ID="conCompanyProfileContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadScriptBlock ID="RadScriptBlockContent" runat="server">
        <script type="text/javascript">
            function RadNumericTextBoxOnKeyPress(sender, args){
                var separatorPos = sender._textBoxElement.value.indexOf(sender.get_numberFormat().DecimalSeparator);
                if (args.get_keyCharacter().match(/[0-9]/) &&
                    separatorPos != -1 &&
                    sender.get_caretPosition() > separatorPos + sender.get_numberFormat().DecimalDigits)
                    {
                        args.set_cancel(true);
                    }
            }

        </script>
    </telerik:RadScriptBlock>
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolbarCompanyProfile" runat="server" AutoPostBack="True" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonSave" SkinID="RadToolBarButtonSave" Text="" Value="Save"
                    ToolTip="Save" ValidationGroup="Save" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonCancel" SkinID="RadToolBarButtonCancel" Text="Cancel" Value="Cancel" ToolTip="Cancel" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>

    <div class="telerik-aqua-body">
        <div>
                <div style="display: inline-block; width: 600px;">
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Industry:
                        </div>
                        <div class="code-description-description">
                            <telerik:RadComboBox ID="RadComboBoxIndustry" runat="server" TabIndex="30" Width="275px" Enabled="true" SkinID="RadComboBoxStandard">
                            </telerik:RadComboBox>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Specialty:
                        </div>
                        <div class="code-description-description">
                            <telerik:RadComboBox ID="RadComboBoxSpecialty" runat="server" TabIndex="30" Width="275px" Enabled="true" SkinID="RadComboBoxStandard">
                            </telerik:RadComboBox>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Region:
                        </div>
                        <div class="code-description-description">
                            <telerik:RadComboBox ID="RadComboBoxRegion" runat="server" TabIndex="30" Width="275px" Enabled="true" SkinID="RadComboBoxStandard">
                            </telerik:RadComboBox>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Revenue:
                        </div>
                        <div class="code-description-description">
                            <telerik:RadNumericTextBox ID="RadNumericTextBoxRevenue" runat="server" Type="Number">
                                <NumberFormat DecimalDigits="2" KeepTrailingZerosOnFocus="true" />
                                <EnabledStyle HorizontalAlign="Right" />
                                <ClientEvents OnKeyPress="RadNumericTextBoxOnKeyPress" />
                            </telerik:RadNumericTextBox>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            # of Employees:
                        </div>
                        <div class="code-description-description">
                            <telerik:RadNumericTextBox ID="RadNumericTextBoxNumEmployees" runat="server" Type="Number">
                                <NumberFormat GroupSeparator="" DecimalDigits="0" AllowRounding="true" KeepNotRoundedValue="false" />
                                <EnabledStyle HorizontalAlign="Right" />
                                <ClientEvents OnKeyPress="RadNumericTextBoxOnKeyPress" />
                            </telerik:RadNumericTextBox>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                        </div>
                        <div class="code-description-description">
                            <asp:CheckBox ID="CheckBoxCaseStudy" runat="server" Text="Case Study Done" />
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                        </div>
                        <div class="code-description-description">
                            <asp:CheckBox ID="CheckBoxReference" runat="server" Text="Use as Reference" />
                        </div>
                    </div>
                </div>
                <div style="display: inline-block; vertical-align: top;margin:0px 0px 10px 0px">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                        <telerik:RadGrid ID="RadGridCompanyProfileAffiliations" runat="server" AllowPaging="True"
                            AllowSorting="True" GridLines="None" PageSize="3" EnableEmbeddedSkins="True"
                            ShowFooter="False" AutoGenerateColumns="False" Width="375px">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom"></PagerStyle>
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
                </div>
            </div>
            <div>
                <div class="code-description-container">
                    <div class="code-description-label" style="vertical-align:top !important;">
                        Turnover Percent:
                    </div>
                    <div class="code-description-description">
                        <telerik:RadNumericTextBox ID="RadNumericTextBoxTurnoverPercent" runat="server" MinValue="0">
                            <ClientEvents OnKeyPress="RadNumericTextBoxOnKeyPress" />
                            <EnabledStyle HorizontalAlign="Right" />
                            <NumberFormat DecimalDigits="2" AllowRounding="false" KeepTrailingZerosOnFocus="true" />
                        </telerik:RadNumericTextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label" style="vertical-align:top !important;">
                        Type 1:
                    </div>
                    <div class="code-description-description">
                        <telerik:RadComboBox ID="RadComboBoxType1" runat="server" Width="275px" Enabled="true" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label" style="vertical-align:top !important;">
                        Type 2:
                    </div>
                    <div class="code-description-description">
                        <telerik:RadComboBox ID="RadComboBoxType2" runat="server" Width="275px" Enabled="true" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label" style="vertical-align:top !important;">
                        Type 3:
                    </div>
                    <div class="code-description-description">
                        <telerik:RadComboBox ID="RadComboBoxType3" runat="server" Width="275px" Enabled="true" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                </div>
                <div class="code-description-container" style="margin-top:5px;">
                    <div class="code-description-label" style="vertical-align:top !important;">
                        Notes:
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TextBoxNotes" runat="server" Rows="6" Width="805" TextMode="MultiLine" SkinID="TextBoxStandard"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="TextBoxCompanyProfileID" runat="server" Visible="False" SkinID="TextBoxStandard"></asp:TextBox>
                    </div>
                </div>
            </div>
            </div>
    </div>

    
</asp:Content>
