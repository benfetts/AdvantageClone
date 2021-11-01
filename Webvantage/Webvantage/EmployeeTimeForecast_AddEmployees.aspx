<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EmployeeTimeForecast_AddEmployees.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Add Employee Time Forecast Employees" Inherits="Webvantage.EmployeeTimeForecast_AddEmployees" %>

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
                   <%-- &nbsp;&nbsp;Employee Time Forecast Employees--%>
                </td>
            </tr>
            <tr>
                <td runat="server" id="TdRadToolBarEmployeeTimeForecastEmployee" align="left" valign="top"
                    colspan="2">
                    <telerik:RadToolBar ID="RadToolBarEmployeeTimeForecastEmployee" runat="server" AutoPostBack="true" Width="100%">
                        <Items>
                            <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true"/>
                            <telerik:RadToolBarButton ID="RadToolBarButtonDone" runat="server" 
                                Text="Done" Value="Done" ToolTip="Finished add\remove employees" />
                            <telerik:RadToolBarButton ID="RadToolBarButtonSecondSeparator" runat="server" IsSeparator="true"/>
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
                            <td align="left" valign="bottom" width="20%">
                               Office
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="bottom" width="20%">
                                <telerik:RadComboBox ID="DropDownListOffice" runat="server" AutoPostBack="true" Width="100%" SkinID="RadComboBoxStandard"
                                    DataTextField="Name" DataValueField="Code" >
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                    </table>
                    <table width="99%" border="0" cellspacing="2" cellpadding="0">
                        <tr>
                            <td align="left" valign="bottom" width="285">
                               Available Employees
                            </td>
                            <td width="285" align="left" valign="bottom">
                               Current Employees
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                <telerik:RadListBox ID="RadListBoxAvailableEmployees" runat="server" Width="100%"
                                    AutoPostBack="false" Height="375" SelectionMode="Multiple" AllowTransfer="true"
                                    TransferToID="RadListBoxCurrentEmployees" AutoPostBackOnTransfer="true"
                                    AllowReorder="False" EnableDragAndDrop="false" DataValueField="Code" DataTextField="Name" >
                                    <ButtonSettings TransferButtons="TransferAllFrom,TransferFrom" />
                                </telerik:RadListBox>
                            </td>
                            <td align="left" valign="top">
                                <telerik:RadListBox ID="RadListBoxCurrentEmployees" runat="server" Width="100%"
                                    AutoPostBack="false" Height="375" SelectionMode="Multiple" AllowReorder="false"
                                    AutoPostBackOnTransfer="false" AutoPostBackOnDelete="true" EnableDragAndDrop="false"
                                    AllowDelete="true" AllowTransfer="false" DataValueField="Code" DataTextField="Name" >
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
