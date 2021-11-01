<%@ Page Title="Edit Contract" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_ContractEdit.aspx.vb" Inherits="Webvantage.Maintenance_ContractEdit" %>

<asp:Content ID="conContractContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <script type="text/javascript">
        function CalculateTotal(input, args) {

            var TotalContractValueControl = $find($telerik.$("[id$='RadNumericTextBoxTotalContractValue']").attr('id'));
            //var RetainerControl = $find(RetainerId);                    //get control
            //var RetainerValue = RetainerControl.get_value();             //get value stored in control
            
            var RetainerValue = $find($telerik.$("[id$='RadNumericTextBoxFeeRetainer']").attr('id')).get_value();
            var BonusValue = $find($telerik.$("[id$='RadNumericTextBoxFeeIncentiveBonus']").attr('id')).get_value();
            var RoyaltyValue = $find($telerik.$("[id$='RadNumericTextBoxFeeRoyalty']").attr('id')).get_value();
            var ProjectHourlyValue = $find($telerik.$("[id$='RadNumericTextBoxProjectHourlyTotal']").attr('id')).get_value();
            var MediaCommissionValue = $find($telerik.$("[id$='RadNumericTextBoxMediaCommission']").attr('id')).get_value();
            var ProductionCommissionValue = $find($telerik.$("[id$='RadNumericTextBoxProductionCommission']").attr('id')).get_value();
            var TotalAmount = Number(RetainerValue) + Number(BonusValue) + Number(RoyaltyValue) + Number(ProjectHourlyValue) + Number(MediaCommissionValue) + Number(ProductionCommissionValue);
            //SET QUANTITY
            //quantityControl.set_value(5);                //set value in control

            TotalContractValueControl.set_value(TotalAmount);
            
        }

        function GetServerId(clientId) {

            return clientId.indexOf("_") > -1 ? clientId.replace(/.+_([a-zA-Z0-9]+)$/m, "$1") : clientId;

        }
    </script>
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolbarContract" runat="server" AutoPostBack="True" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonSave" SkinID="RadToolBarButtonSave" Text="" Value="Save"
                    ToolTip="Save" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonNew" SkinID="RadToolBarButtonAdd" Text="New" Value="New" ToolTip="Add New" />
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
                TitleText="Contract Information" >
                <table cellpadding="2" cellspacing="0" width="100%" align="center" border="0">
                    <tr>
                        <td colspan="2" style="height: 10px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                <tr>
                                    <td style="width: 30%; text-align: right">
                                        Code:</td>
                                    <td style="width: 70%">&nbsp;&nbsp;
                                        <asp:TextBox ID="TextBoxContractCode" runat="server" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFVCode" runat="server" ControlToValidate="TextBoxContractCode"
                                            CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                            ErrorMessage="<br />Code is required."></asp:RequiredFieldValidator>&nbsp; &nbsp;
                                        <asp:CheckBox ID="CheckBoxIsNewBusiness" runat="server" Text="New Business" Enabled="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30%; text-align: right">
                                        Name:</td>
                                    <td style="width: 70%">&nbsp;&nbsp;
                                        <asp:TextBox ID="TextBoxContractName" runat="server"
                                            SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFVName" runat="server" ControlToValidate="TextBoxContractName"
                                            CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                            ErrorMessage="<br />Name is required."></asp:RequiredFieldValidator>&nbsp;&nbsp;
                                        <asp:CheckBox ID="CheckBoxIsInactive" runat="server" Text="Inactive" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30%; text-align: right">
                                        Client:</td>
                                    <td style="width: 70%">&nbsp;&nbsp;
                                        <telerik:RadComboBox ID="RadComboBoxClient" runat="server" AutoPostBack="true" TabIndex="30" width="275px" SkinID="RadComboBoxStandard">
                                        </telerik:RadComboBox>
                                        <asp:RequiredFieldValidator ID="RFVClient" runat="server" ControlToValidate="RadComboBoxClient"
                                            CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                            ErrorMessage="<br />Client is required."></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30%; text-align: right">
                                        Division:</td>
                                    <td style="width: 70%">&nbsp;&nbsp;
                                        <telerik:RadComboBox ID="RadComboBoxDivision" runat="server" AutoPostBack="true" TabIndex="30" width="275px" SkinID="RadComboBoxStandard">
                                        </telerik:RadComboBox>
                                        <asp:RequiredFieldValidator ID="RFVDivision" runat="server" ControlToValidate="RadComboBoxDivision"
                                            CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                            ErrorMessage="<br />Division is required."></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30%; text-align: right">
                                        Product:</td>
                                    <td style="width: 70%">&nbsp;&nbsp;
                                        <telerik:RadComboBox ID="RadComboBoxProduct" runat="server" AutoPostBack="true" TabIndex="30" width="275px" SkinID="RadComboBoxStandard">
                                        </telerik:RadComboBox>
                                        <asp:RequiredFieldValidator ID="RFVProduct" runat="server" ControlToValidate="RadComboBoxProduct"
                                            CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                            ErrorMessage="<br />Product is required."></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </ew:CollapsablePanel> 
            <ew:CollapsablePanel ID="CollapsablePanelGeneral" runat="server"
                TitleText="General"  Collapsed="True">
                <table align="left" border="0" cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <asp:panel id="PanelContractOpportunity" runat="server" groupingtext="Contract Opportunity">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="60%">
                                    <tr>
                                        <td colspan="2" style="height: 10px">&nbsp;
                                        </td>
                                    </tr>
                                    <tr valign="top" align="left">
                                        <td>
                                            <asp:RadioButton ID="RadioButtonContract" runat="server" Text="Contract" TabIndex="100" GroupName="CO" />
                                        </td>
                                        <td>
                                            <asp:RadioButton ID="RadioButtonOpportunity" runat="server" Text="Opportunity" TabIndex="110" GroupName="CO" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </asp:panel>
                            <table align="center" border="0" cellpadding="2" cellspacing="0" width="100%">
                                <tr>
                                    <td colspan="2" style="height: 10px">&nbsp;
                                    </td>
                                </tr>
                                <tr valign="top" align="left">
                                    <td align="right">
                                        Start Date:
                                    </td>
                                    <td>&nbsp;
                                        <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" AutoPostBack="True" TabIndex="-1"
                                            DateInput-BackColor="#FFFFE0" SkinID="RadDatePickerStandard">
                                            <DateInput AutoPostBack="True" CssClass="RequiredInput" TabIndex="1">
                                            </DateInput>
                                        </telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorStartDate" runat="server" ControlToValidate="RadDatePickerStartDate"
                                            CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                            ErrorMessage="<br />Start Date is required."></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr valign="top" align="left">
                                    <td align="right">
                                        End Date:
                                    </td>
                                    <td>&nbsp;
                                        <telerik:RadDatePicker ID="RadDatePickerEndDate" runat="server" AutoPostBack="True" DateInput-BackColor="#FFFFE0" TabIndex="-1"
                                            SkinID="RadDatePickerStandard">
                                            <DateInput AutoPostBack="True" CssClass="RequiredInput" Width="80px" TabIndex="2">
                                            </DateInput>
                                        </telerik:RadDatePicker>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEndDate" runat="server" ControlToValidate="RadDatePickerEndDate"
                                            CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                            ErrorMessage="<br />End Date is required."></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table border="0" cellspacing="0" cellpadding="2" width="100%">
                                <tr>
                                    <td style="text-align: right" width="30%">
                                        Address 1:</td>
                                    <td >&nbsp;&nbsp;
                                        <asp:TextBox ID="TextBoxAddress1" runat="server"  Width="250px" ReadOnly="True" TabIndex="-1" SkinID="TextBoxStandard"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        Address 2:</td>
                                    <td >&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBoxAddress2" runat="server"  Width="250px" ReadOnly="True" TabIndex="-1" SkinID="TextBoxStandard"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="text-align: right" valign="middle">City:</td>
                                    <td>&nbsp;&nbsp;
                                        <asp:TextBox ID="TextBoxCity" runat="server"  Width="250px" ReadOnly="True" TabIndex="-1" SkinID="TextBoxStandard"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="text-align: right" valign="middle">County:</td>
                                    <td>&nbsp;&nbsp;
                                        <asp:TextBox ID="TextBoxCounty" runat="server"  Width="250px" ReadOnly="True" TabIndex="-1" SkinID="TextBoxStandard"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="text-align: right" valign="middle">State:</td>
                                    <td align="left" style="width: 70%" valign="middle">&nbsp;&nbsp;
                                        <asp:TextBox ID="TextBoxState" runat="server"  Width="60px" ReadOnly="True" TabIndex="-1" SkinID="TextBoxStandard"></asp:TextBox>&nbsp;&nbsp;Zip:&nbsp;&nbsp;
                                        <asp:TextBox ID="TextBoxZip" runat="server"  width="150px" ReadOnly="True" TabIndex="-1" SkinID="TextBoxStandard"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="text-align: right" valign="middle" >Country:</td>
                                    <td>&nbsp;&nbsp;
                                        <asp:TextBox ID="TextBoxCountry" runat="server"  Width="250px" ReadOnly="True" TabIndex="-1" SkinID="TextBoxStandard"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ew:CollapsablePanel>
            <ew:CollapsablePanel ID="CollapsablePanelRatesTerms" runat="server" 
                TitleText="Rates/Terms" Collapsed="True">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <table align="left" border="0" cellpadding="2" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <asp:panel id="PanelContractType" runat="server" groupingtext="Contract Type">
                                    <table align="left" border="0" cellpadding="2" cellspacing="0" width="60%">
                                        <tr valign="top" align="left">
                                            <td valign="middle" >
                                                <asp:CheckBox ID="CheckBoxFee" runat="server" Text="Fee" />
                                            </td>
                                            <td valign="middle" >
                                                <asp:CheckBox ID="CheckBoxProjectHourly" runat="server" Text="Project / Hourly" />
                                            </td>
                                            <td valign="middle" >
                                                Blended Hourly Rate:
                                            </td>
                                            <td valign="middle" >
                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxBlendedHourlyRate" runat="server" Type="Number" style="text-align:right" 
                                                    Width="100px">
                                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" Step="1" />
                                                </telerik:RadNumericTextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table align="left" border="0" cellpadding="2" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="right">
                                            Fee / Retainer:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="RadNumericTextBoxFeeRetainer" runat="server" Type="Number" style="text-align:right" Width="100px" AutoPostBack="false">
                                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" Step="1" />
                                                <ClientEvents OnValueChanged="CalculateTotal" />
                                            </telerik:RadNumericTextBox>&nbsp;&nbsp;
                                            <asp:LinkButton ID="LinkButtonRefresh" runat="server" Text="Refresh" TabIndex="-1"></asp:LinkButton>
                                        </td>
                                        <td colspan="2" align="right">
                                            Media Commission:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="RadNumericTextBoxMediaCommission" runat="server" Type="Number" style="text-align:right" Width="100px" AutoPostBack="false">
                                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" Step="1" />
                                                <ClientEvents OnValueChanged="CalculateTotal" />
                                            </telerik:RadNumericTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Fee Incentive / Bonus:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="RadNumericTextBoxFeeIncentiveBonus" runat="server" Type="Number" style="text-align:right" Width="100px" AutoPostBack="false">
                                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" Step="1" />
                                                <ClientEvents OnValueChanged="CalculateTotal" />
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td colspan="2" align="right">
                                            Production Commission:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="RadNumericTextBoxProductionCommission" runat="server" Type="Number" style="text-align:right" Width="100px" AutoPostBack="false">
                                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" Step="1" />
                                                <ClientEvents OnValueChanged="CalculateTotal" />
                                            </telerik:RadNumericTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Fee Royalty:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="RadNumericTextBoxFeeRoyalty" runat="server" Type="Number" style="text-align:right" Width="100px" AutoPostBack="false">
                                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" Step="1" />
                                                <ClientEvents OnValueChanged="CalculateTotal" />
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td colspan="2" align="right">
                                            Total Contract Value:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="RadNumericTextBoxTotalContractValue" runat="server" Type="Number" style="text-align:right" Width="100px" ReadOnly="true" TabIndex="-1" >
                                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" Step="1" />
                                            </telerik:RadNumericTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Project / Hourly Total:
                                        </td>
                                        <td>
                                            <telerik:RadNumericTextBox ID="RadNumericTextBoxProjectHourlyTotal" runat="server" Type="Number" style="text-align:right" Width="100px" AutoPostBack="true" OnTextChanged="RadNumericTextBoxProjectHourlyTotal_TextChanged">
                                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" Step="1" />
                                                <ClientEvents OnValueChanged="CalculateTotal" />
                                            </telerik:RadNumericTextBox>&nbsp;&nbsp;Hours:&nbsp;&nbsp;
                                            <telerik:RadNumericTextBox ID="RadNumericTextBoxHours" runat="server" Type="Number" style="text-align:right" Width="100px" AutoPostBack="true" OnTextChanged="RadNumericTextBoxHours_TextChanged" >
                                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" Step="1" />
                                            </telerik:RadNumericTextBox>
                                        </td>
                                        <td colspan="3">                                
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadGrid ID="RadGridContractFees" runat="server" AllowPaging="True"
                                    AllowSorting="True" GridLines="None" PageSize="5" EnableEmbeddedSkins="True"
                                    ShowFooter="true" AutoGenerateColumns="False">
                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px"></PagerStyle>
                                    <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="ServiceFeeTypeID"
                                        InsertItemDisplay="Top">
                                        <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                        <Columns>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnServiceFeeCode" HeaderText="Service Fee Type"
                                                SortExpression="Description">
                                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="200"/>
                                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="200"/>
                                                <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="200"/>
                                                <ItemTemplate>
                                                    <telerik:RadComboBox ID="RadComboBoxServiceFeeCode" runat="server" AutoPostBack="false" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                        DataValueField="ID" DataTextField="Description" Width="200">
                                                    </telerik:RadComboBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox ID="RadComboBoxServiceFeeCodeEdit" runat="server" CssClass="RequiredInput" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                        AutoPostBack="false" DataValueField="ID" DataTextField="Description" Width="200">
                                                    </telerik:RadComboBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnHours" HeaderText="Hours" DataField="Hours"
                                                SortExpression="Hours">
                                                <HeaderStyle Width="120" VerticalAlign="Middle" HorizontalAlign="Right" />
                                                <ItemStyle Width="120" VerticalAlign="Middle" HorizontalAlign="Right" />
                                                <FooterStyle Width="120" VerticalAlign="Middle" HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxFeeHours" runat="server" AutoPostBack="true" Style="text-align: right"
                                                        DbValue='<%# Eval("Hours")%>' Type="Number" OnTextChanged="RadNumericTextBoxFeeHours_TextChanged">
                                                    </telerik:RadNumericTextBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxFeeHoursEdit" runat="server" AutoPostBack="true" Style="text-align: right" CssClass="RequiredInput"
                                                        DbValue='<%#Eval("Hours")%>' Type="Number" OnTextChanged="RadNumericTextBoxFeeHoursEdit_TextChanged">
                                                    </telerik:RadNumericTextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxTotalFeeHours" runat="server" AutoPostBack="false" Style="text-align: right"
                                                        Type="Number" NumberFormat-DecimalDigits="2" ReadOnly="true">
                                                    </telerik:RadNumericTextBox>
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAmount" HeaderText="Amount" DataField="Amount"
                                                SortExpression="Amount">
                                                <HeaderStyle Width="150" VerticalAlign="Middle" HorizontalAlign="Right" />
                                                <ItemStyle Width="150" VerticalAlign="Middle" HorizontalAlign="Right" />
                                                <FooterStyle Width="150" VerticalAlign="Middle" HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxAmount" runat="server" AutoPostBack="true" Style="text-align: right"
                                                        DbValue='<%#Eval("Amount")%>' Type="Number" OnTextChanged="RadNumericTextBoxAmount_TextChanged">
                                                    </telerik:RadNumericTextBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxAmountEdit" runat="server" AutoPostBack="true" Style="text-align: right" CssClass="RequiredInput"
                                                        DbValue='<%#Eval("Amount")%>' Type="Number" OnTextChanged="RadNumericTextBoxAmountEdit_TextChanged">
                                                    </telerik:RadNumericTextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxTotalFeeAmount" runat="server" AutoPostBack="false" Style="text-align: right"
                                                        Type="Number" NumberFormat-DecimalDigits="2" ReadOnly="true">
                                                    </telerik:RadNumericTextBox>
                                                </FooterTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSave">
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
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            </ew:CollapsablePanel>
            <ew:CollapsablePanel ID="CollapsablePanelComments" runat="server"
                TitleText="Comments" Collapsed="true">
                <table align="left" border="0" cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td align="right" width="15%">
                            Billing Rate Comment:
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxBillingRateComment" runat="server"  Width="90%" Rows="5" TextMode="MultiLine" SkinID="TextBoxStandard"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Billing Terms:
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxBillingTerms" runat="server"  Width="90%" Rows="5" TextMode="MultiLine" SkinID="TextBoxStandard"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Estimating Terms:
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxEstimatingTerms" runat="server"  Width="90%" Rows="5" TextMode="MultiLine" SkinID="TextBoxStandard"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Comments:
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxComments" runat="server"  Width="90%" Rows="5" TextMode="MultiLine" SkinID="TextBoxStandard"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </ew:CollapsablePanel>
            <ew:CollapsablePanel ID="CollapsablePanelInternalContacts" runat="server" 
                TitleText="Internal Contacts"  Collapsed="True">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <table align="left" border="0" cellpadding="2" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <telerik:RadGrid ID="RadGridInternalContacts" runat="server" AllowPaging="True"
                                    AllowSorting="True" GridLines="None" PageSize="5" EnableEmbeddedSkins="True"
                                        ShowFooter="true" AutoGenerateColumns="False">
                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px">
                                    </PagerStyle>
                                    <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="EmployeeCode"
                                        InsertItemDisplay="Top">
                                        <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                        <Columns>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnEmployeeCode" HeaderText="Employee Code"
                                                SortExpression="EmployeeCode">
                                                <HeaderStyle  VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemStyle  VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <FooterStyle  VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <telerik:RadComboBox ID="RadComboBoxEmployeeCode" runat="server" AutoPostBack="false" SkinID="RadComboBoxStandard"
                                                        DataValueField="Code" DataTextField="Name" Width="100%">
                                                    </telerik:RadComboBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox ID="RadComboBoxEmployeeCodeEdit" runat="server" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                        AutoPostBack="false" DataValueField="Code" DataTextField="Name" Width="100%" CssClass="RequiredInput">
                                                    </telerik:RadComboBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnIncludeInAlert" HeaderText="Include In Alert"
                                                SortExpression="IncludeInAlert">
                                                <HeaderStyle Width="150" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle Width="150" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <FooterStyle Width="150" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBoxIncludeInAlert" runat="server" AutoPostBack="false" Checked='<%# If(IsDBNull(Eval("IncludeInAlert")), False, Eval("IncludeInAlert"))%>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="CheckBoxIncludeInAlertEdit" runat="server" AutoPostBack="false" Checked='<%# If(IsDBNull(Eval("IncludeInAlert")), False, Eval("IncludeInAlert"))%>' />
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSave">
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
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            </ew:CollapsablePanel>
            <ew:CollapsablePanel ID="CollapsablePanelReports" runat="server" 
                TitleText="Reports"  Collapsed="True">
            <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <table align="left" border="0" cellpadding="2" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <telerik:RadGrid ID="RadGridReports" runat="server" AllowPaging="True"
                                    AllowSorting="True" GridLines="None" PageSize="5" EnableEmbeddedSkins="True"
                                        ShowFooter="true" AutoGenerateColumns="False">
                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px">
                                    </PagerStyle>
                                    <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="ID"
                                        InsertItemDisplay="Top">
                                        <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                        <Columns>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDescription" HeaderText="Description"
                                                SortExpression="Description">
                                                <HeaderStyle  VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <FooterStyle  VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TextBoxDescription" runat="server" MaxLength="100" Text='<%#Eval("Description")%>'
                                                         SkinID="TextBoxStandard" Width="100%"></asp:TextBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBoxDescriptionEdit" runat="server" MaxLength="100" Text='<%#Eval("Description")%>' CssClass="RequiredInput" 
                                                         SkinID="TextBoxStandard" Width="100%"></asp:TextBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnFrequency" HeaderText="Frequency" DataField="CycleCode"
                                                SortExpression="CycleCode" >
                                                <HeaderStyle Width="120" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemStyle Width="120" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <FooterStyle Width="120" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <telerik:RadComboBox ID="RadComboBoxCycleCode" runat="server" AutoPostBack="false" InputCssClass="no-border" 
                                                        DataValueField="Code" DataTextField="Description" SkinID="RadComboBoxText10">
                                                    </telerik:RadComboBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox ID="RadComboBoxCycleCodeEdit" runat="server" InputCssClass="no-border"
                                                        AutoPostBack="false" DataValueField="Code" DataTextField="Description" SkinID="RadComboBoxText10">
                                                    </telerik:RadComboBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnLastCompletedDate" HeaderText="Last Completed Date" DataField="LastCompletedDate"
                                                SortExpression="LastCompletedDate" >
                                                <HeaderStyle Width="120" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemStyle Width="120" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <FooterStyle Width="120" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <telerik:RadDatePicker ID="RadDatePickerLastCompletedDate" runat="server" DbSelectedDate='<%# Bind("LastCompletedDate")%>' SkinID="RadDatePickerStandard" AutoPostBack="true" OnSelectedDateChanged="RadDatePickerLastCompletedDate_SelectedDateChanged">
                                                    </telerik:RadDatePicker>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadDatePicker ID="RadDatePickerLastCompletedDateEdit" runat="server" DbSelectedDate='<%# Bind("LastCompletedDate")%>' SkinID="RadDatePickerStandard" AutoPostBack="true" OnSelectedDateChanged="RadDatePickerLastCompletedDateEdit_SelectedDateChanged">
                                                    </telerik:RadDatePicker>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnNextStartDate" HeaderText="Next Start Date" DataField="NextStartDate"
                                                SortExpression="NextStartDate" >
                                                <HeaderStyle Width="120" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemStyle Width="120" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <FooterStyle Width="120" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <telerik:RadDatePicker ID="RadDatePickerNextStartDate" runat="server" DbSelectedDate='<%# Bind("NextStartDate")%>' SkinID="RadDatePickerStandard">
                                                    </telerik:RadDatePicker>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadDatePicker ID="RadDatePickerNextStartDateEdit" runat="server" DbSelectedDate='<%# Bind("NextStartDate")%>' SkinID="RadDatePickerStandard">
                                                    </telerik:RadDatePicker>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnNotifyInternalContacts" HeaderText="Notify Internal Contacts"
                                                SortExpression="NotifyInternalContacts">
                                                <HeaderStyle Width="80" VerticalAlign="Middle" HorizontalAlign="Right" Wrap="true" />
                                                <ItemStyle Width="80" VerticalAlign="Middle" HorizontalAlign="Right" />
                                                <FooterStyle Width="80" VerticalAlign="Middle" HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBoxNotifyInternalContacts" runat="server" AutoPostBack="false" Checked='<%# If(IsDBNull(Eval("NotifyInternalContacts")), False, Eval("NotifyInternalContacts"))%>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="CheckBoxNotifyInternalContactsEdit" runat="server" AutoPostBack="false" Checked='<%# If(IsDBNull(Eval("NotifyInternalContacts")), False, Eval("NotifyInternalContacts"))%>' />
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnEmployeeCode" HeaderText="Employee Code" DataField="EmployeeCode"
                                                SortExpression="EmployeeCode" >
                                                <HeaderStyle Width="120" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemStyle Width="120" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <FooterStyle Width="120" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <telerik:RadComboBox ID="RadComboBoxEmployeeCode" runat="server" AutoPostBack="false" InputCssClass="no-border"
                                                        DataValueField="Code" DataTextField="Name" SkinID="RadComboBoxText40">
                                                    </telerik:RadComboBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadComboBox ID="RadComboBoxEmployeeCodeEdit" runat="server" InputCssClass="no-border"
                                                        AutoPostBack="false" DataValueField="Code" DataTextField="Name" SkinID="RadComboBoxText40">
                                                    </telerik:RadComboBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAlertDaysPrior" HeaderText="Alert Days Prior" DataField="AlertDaysPrior"
                                                SortExpression="AlertDaysPrior">
                                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxAlertDaysPrior" runat="server" AutoPostBack="false" style="text-align:right"
                                                        DbValue='<%#Eval("AlertDaysPrior")%>' Type="Number" NumberFormat-DecimalDigits="0" MaxValue="999" MaxLength="3" Width="50">
                                                    </telerik:RadNumericTextBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxAlertDaysPriorEdit" runat="server" AutoPostBack="false" style="text-align:right"
                                                        DbValue='<%#Eval("AlertDaysPrior")%>' Type="Number" NumberFormat-DecimalDigits="0" MaxValue="999" MaxLength="3" Width="50">
                                                    </telerik:RadNumericTextBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSendAlertDaysPrior" HeaderText="Send Alert Days Prior" 
                                                SortExpression="SendAlertDaysPrior">
                                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" Wrap="true" />
                                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBoxSendAlertDaysPrior" runat="server" AutoPostBack="false" Checked='<%# If(IsDBNull(Eval("SendAlertDaysPrior")), False, Eval("SendAlertDaysPrior"))%>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="CheckBoxSendAlertDaysPriorEdit" runat="server" AutoPostBack="false" Checked='<%# If(IsDBNull(Eval("SendAlertDaysPrior")), False, Eval("SendAlertDaysPrior"))%>' />
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSendAlertUponCompletion" HeaderText="Send Alert Upon Completion"
                                                SortExpression="SendAlertUponCompletion">
                                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" Wrap="true"/>
                                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBoxSendAlertUponCompletion" runat="server" AutoPostBack="false" Checked='<%# If(IsDBNull(Eval("SendAlertUponCompletion")), False, Eval("SendAlertUponCompletion"))%>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="CheckBoxSendAlertUponCompletionEdit" runat="server" AutoPostBack="false" Checked='<%# If(IsDBNull(Eval("SendAlertUponCompletion")), False, Eval("SendAlertUponCompletion"))%>' />
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnHasDocument" HeaderText="Has Documents"
                                                SortExpression="HasDocuments">
                                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBoxHasDocument" runat="server" AutoPostBack="false" Enabled="false" Checked='<%# If(IsDBNull(Eval("HasDocuments")), False, Eval("HasDocuments"))%>' />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSave">
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
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnUpload">
                                                <HeaderStyle CssClass="radgrid-icon-column" />
                                                <ItemStyle CssClass="radgrid-icon-column" />
                                                <FooterStyle CssClass="radgrid-icon-column" />
                                                <ItemTemplate>
                                                    <div id="DivUpload" runat="server" class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="ImageButtonUpload" runat="server" SkinID="ImageButtonAddWhite" ToolTip="Click to upload document"
                                                            CommandName="UploadDocument" />
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnViewDocuments">
                                                <HeaderStyle CssClass="radgrid-icon-column" />
                                                <ItemStyle CssClass="radgrid-icon-column" />
                                                <FooterStyle CssClass="radgrid-icon-column" />
                                                <ItemTemplate>
                                                    <div id="DivViewDocuments" runat="server" class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="ImageButtonViewDocuments" runat="server" ImageUrl="~/Images/Icons/White/256/documents_empty.png" CssClass="icon-image" ToolTip="View documents"
                                                            CommandName="ViewDocuments" />
                                                    </div>
                                                </ItemTemplate>
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
                </ContentTemplate>
            </asp:UpdatePanel>
            </ew:CollapsablePanel>
            <ew:CollapsablePanel ID="CollapsablePanelValueAdded" runat="server" 
                TitleText="Value Added"  Collapsed="True">
            <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <table align="left" border="0" cellpadding="2" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <telerik:RadGrid ID="RadGridValueAdded" runat="server" AllowPaging="True"
                                    AllowSorting="True" GridLines="None" PageSize="5" EnableEmbeddedSkins="True"
                                        ShowFooter="true" AutoGenerateColumns="False">
                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px">
                                    </PagerStyle>
                                    <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="ID"
                                        InsertItemDisplay="Top">
                                        <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                        <Columns>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDescription" HeaderText="Short Description"
                                                SortExpression="Description">
                                                <HeaderStyle  VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemStyle VerticalAlign="Top" HorizontalAlign="Left" />
                                                <FooterStyle  VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TextBoxDescription" runat="server" MaxLength="100" Text='<%#Eval("Description")%>'
                                                        SkinID="TextBoxStandard" Width="100%"></asp:TextBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBoxDescriptionEdit" runat="server" MaxLength="100" Text='<%#Eval("Description")%>' CssClass="RequiredInput" 
                                                        SkinID="TextBoxStandard" Width="100%"></asp:TextBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnComment" HeaderText="Comment"
                                                SortExpression="Comment">
                                                <HeaderStyle  VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemStyle VerticalAlign="Top" HorizontalAlign="Left" />
                                                <FooterStyle  VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TextBoxComment" runat="server" Text='<%#Eval("Comment")%>' TextMode="MultiLine" Rows="5"
                                                        SkinID="TextBoxStandard" Width="100%"></asp:TextBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBoxCommentEdit" runat="server" Text='<%#Eval("Comment")%>' TextMode="MultiLine" Rows="5"
                                                        SkinID="TextBoxStandard" Width="100%"></asp:TextBox>
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAmount" HeaderText="Amount" DataField="Amount"
                                                SortExpression="Amount">
                                                <HeaderStyle Width="150" VerticalAlign="Middle" HorizontalAlign="Right" />
                                                <ItemStyle Width="150" VerticalAlign="Top" HorizontalAlign="Right" />
                                                <FooterStyle Width="150" VerticalAlign="Middle" HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxValueAddedAmount" runat="server" AutoPostBack="true" style="text-align:right"
                                                        DbValue='<%#Eval("Amount")%>' Type="Number" NumberFormat-DecimalDigits="2" MaxValue="999999999999.99" MaxLength="15" Width="100%" OnTextChanged="RadNumericTextBoxValueAddedAmount_TextChanged" >
                                                    </telerik:RadNumericTextBox>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxValueAddedAmountEdit" runat="server" style="text-align:right"
                                                        DbValue='<%#Eval("Amount")%>' Type="Number" NumberFormat-DecimalDigits="2" MaxValue="999999999999.99" MaxLength="15" Width="100%">
                                                    </telerik:RadNumericTextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                   <telerik:RadNumericTextBox ID="RadNumericTextBoxTotalValueAddedAmount" runat="server" AutoPostBack="false" style="text-align:right"
                                                        Type="Number" NumberFormat-DecimalDigits="2" ReadOnly="true" >
                                                    </telerik:RadNumericTextBox>
                                                 </FooterTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="IsDocumentAURL" HeaderText="IsDocumentAURL" UniqueName="IsDocumentAURL" Visible="false" >
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="40" />
                                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnHasDocument" HeaderText="Has Document"
                                                SortExpression="HasDocument">
                                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemStyle Width="50" VerticalAlign="Top" HorizontalAlign="Left" />
                                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBoxHasDocument" runat="server" AutoPostBack="false" Enabled="false" Checked='<%# If(IsDBNull(Eval("HasDocument")), False, Eval("HasDocument"))%>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="CheckBoxHasDocumentEdit" runat="server" AutoPostBack="false" Enabled="false" Checked='<%# If(IsDBNull(Eval("HasDocument")), False, Eval("HasDocument"))%>' />
                                                </EditItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSave">
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
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnUpload">
                                                <HeaderStyle CssClass="radgrid-icon-column" />
                                                <ItemStyle CssClass="radgrid-icon-column" />
                                                <FooterStyle CssClass="radgrid-icon-column" />
                                                <ItemTemplate>
                                                    <div id="DivUpload" runat="server" class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="ImageButtonUpload" runat="server" SkinID="ImageButtonUploadWhite" ToolTip="Click to upload document"
                                                            CommandName="UploadDocument" />
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDownload">
                                                <HeaderStyle CssClass="radgrid-icon-column" />
                                                <ItemStyle CssClass="radgrid-icon-column" />
                                                <FooterStyle CssClass="radgrid-icon-column" />
                                                <ItemTemplate>
                                                    <div id="DivDownload" runat="server" class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="ImageButtonDownload" runat="server" SkinID="ImageButtonDownloadWhite" ToolTip="Click to download document"
                                                            CommandName="DownloadDocument" />
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnOpenURL">
                                                <HeaderStyle CssClass="radgrid-icon-column" />
                                                <ItemStyle CssClass="radgrid-icon-column" />
                                                <FooterStyle CssClass="radgrid-icon-column" />
                                                <ItemTemplate>
                                                    <div id="DivOpenURL" runat="server" class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="ImageButtonOpenURL" runat="server" SkinID="ImageButtonViewWhite" ToolTip="Click to open link"
                                                            CommandName="OpenURL" />
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDeleteDocument">
                                                <HeaderStyle CssClass="radgrid-icon-column" />
                                                <ItemStyle CssClass="radgrid-icon-column" />
                                                <FooterStyle CssClass="radgrid-icon-column" />
                                                <ItemTemplate>
                                                    <div id="DivDeleteDocument" runat="server" class="icon-background background-color-delete">
                                                        <asp:ImageButton ID="ImageButtonDeleteDocument" runat="server" SkinID="ImageButtonDeleteDocumentWhite" ToolTip="Click to delete document" 
                                                            CommandName="DeleteDocument" />
                                                    </div>
                                                </ItemTemplate>
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
                </ContentTemplate>
            </asp:UpdatePanel>
            </ew:CollapsablePanel>
  </div>
    
</asp:Content>
