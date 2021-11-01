<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EmployeeTimeForecast_AddAlternateEmployees.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Add Employee Time Forecast Alternate Employees" Inherits="Webvantage.EmployeeTimeForecast_AddAlternateEmployees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <table align="center" border="0" cellpadding="0" cellspacing="0" 
            width="100%">
            <tr >
                <td align="left"  valign="middle"
                    colspan="2">
                    <%--&nbsp;&nbsp;Employee Time Forecast Alternate Employees--%>
                </td>
            </tr>
            <tr>
                <td runat="server" id="TdRadToolBarEmployeeTimeForecastAlternateEmployee" align="left"
                    valign="top" colspan="2">
                    <telerik:RadToolBar ID="RadToolBarEmployeeTimeForecastAlternateEmployee" runat="server" AutoPostBack="true" Width="100%">
                        <Items>
                            <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
                            <telerik:RadToolBarButton ID="RadToolBarButtonDone" runat="server" 
                                Text="Done" Value="Done" ToolTip="Finished add\remove alternate employees" />
                            <telerik:RadToolBarButton ID="RadToolBarButtonSecondSeparator" runat="server" IsSeparator="true" />
                        </Items>
                    </telerik:RadToolBar>
                </td>
            </tr>
            <tr>
                <td width="1%">
                    &nbsp;
                </td>
                <td>
                    <table width="99%" border="0" cellspacing="2" cellpadding="0">
                        <tr>
                            <td align="left" valign="bottom" width="50%">
                               <strong>Alternate Employee Details</strong>
                            </td>
                            <td align="left" valign="bottom" width="50%">
                               <strong>Current Alternate Employees</strong>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                <table width="99%" border="0" cellspacing="2" cellpadding="0">
                                    <tr>
                                        <td align="left" valign="bottom" width="32%">
                                           Employee Title:
                                        </td>
                                        <td align="left" valign="bottom" width="68%">
                                            <telerik:RadComboBox ID="DropDownListEmployeeTitle" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard"
                                                Width="100%" DataTextField="Description" DataValueField="ID" >
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="bottom" width="32%">
                                           Description:
                                        </td>
                                        <td align="left" valign="bottom" width="68%">
                                            <asp:TextBox ID="TextBoxDescription" runat="server" Text=""  SkinID="TextBoxStandard"
                                                Width="100%" AutoPostBack="false">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="bottom" width="32%">
                                           Office:
                                        </td>
                                        <td align="left" valign="bottom" width="68%">
                                            <telerik:RadComboBox ID="DropDownListOffice" runat="server" AutoPostBack="true" Width="100%" SkinID="RadComboBoxStandard"
                                                DataTextField="Name" DataValueField="Code" >
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="bottom" width="32%">
                                           Bill Rate:
                                        </td>
                                        <td align="left" valign="bottom" width="68%">
                                            <telerik:RadNumericTextBox ID="RadNumericTextBoxBillRate" runat="server" Value="0.00"
                                                Type="Currency" Width="25%" AutoPostBack="false" MaxLength="12" MinValue="0.00"
                                                >
                                                <NumberFormat DecimalDigits="2" GroupSeparator="," KeepTrailingZerosOnFocus="true" />
                                                <EnabledStyle HorizontalAlign="Right" />
                                            </telerik:RadNumericTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="bottom" width="32%">
                                           Cost Rate:
                                        </td>
                                        <td align="left" valign="bottom" width="68%">
                                            <telerik:RadNumericTextBox ID="RadNumericTextBoxCostRate" runat="server" Value="0.00"
                                                Type="Currency" Width="25%" AutoPostBack="false" MaxLength="12" MinValue="0.00"
                                                >
                                                <NumberFormat DecimalDigits="2" GroupSeparator="," KeepTrailingZerosOnFocus="true" />
                                                <EnabledStyle HorizontalAlign="Right" />
                                            </telerik:RadNumericTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="bottom" width="32%">
                                            &nbsp;
                                        </td>
                                        <td align="right" valign="bottom" width="68%">
                                            <telerik:RadButton ID="RadButtonAddNewAlternateEmployee" runat="server" Text="Add New Alternate Employee" Width="100%">
                                            </telerik:RadButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="left" valign="top">
                                <telerik:RadListBox ID="RadListBoxCurrentAlternateEmployees" runat="server" Width="100%"
                                    AutoPostBack="false" Height="375" SelectionMode="Multiple" AllowReorder="false"
                                    AutoPostBackOnTransfer="false" AutoPostBackOnDelete="true" EnableDragAndDrop="false"
                                    AllowDelete="true" AllowTransfer="false" DataValueField="ID" DataTextField="Description">
                                    <ButtonSettings ShowDelete="true" ShowTransfer="false" ShowTransferAll="false" />
                                </telerik:RadListBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
        </table>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
