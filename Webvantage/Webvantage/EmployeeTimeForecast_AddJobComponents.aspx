<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EmployeeTimeForecast_AddJobComponents.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Add Employee Time Forecast Job Components" Inherits="Webvantage.EmployeeTimeForecast_AddJobComponents" %>

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
                    <%--&nbsp;&nbsp;Employee Time Forecast Job Components--%>
                </td>
            </tr>
            <tr>
                <td runat="server" id="TdRadToolBarEmployeeTimeForecastJobComponent" align="left" valign="top"
                    colspan="2">
                    <telerik:RadToolBar ID="RadToolBarEmployeeTimeForecastJobComponent"  runat="server" AutoPostBack="true" Width="100%">
                        <Items>
                            <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true"/>
                            <telerik:RadToolBarButton ID="RadToolBarButtonDone" runat="server"
                                Text="Done" Value="Done" ToolTip="Finished add\remove job components" />
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
                            <td align="left" valign="bottom" width="34%">
                               Client
                            </td>
                            <td align="left" valign="bottom" width="33%">
                               Division
                            </td>
                            <td align="left" valign="bottom" width="33%">
                               Product
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="bottom" width="34%">
                                <telerik:RadComboBox ID="DropDownListClient" runat="server" AutoPostBack="true" Width="100%" SkinID="RadComboBoxStandard"
                                    DataTextField="Name" DataValueField="Code" >
                                </telerik:RadComboBox>
                            </td>
                            <td align="left" valign="bottom" width="33%">
                                <telerik:RadComboBox ID="DropDownListDivision" runat="server" AutoPostBack="true" Width="100%" SkinID="RadComboBoxStandard"
                                    DataTextField="Name" DataValueField="Code" >
                                </telerik:RadComboBox>
                            </td>
                            <td align="left" valign="bottom" width="33%">
                                <telerik:RadComboBox ID="DropDownListProduct" runat="server" AutoPostBack="true" Width="100%" SkinID="RadComboBoxStandard"
                                    DataTextField="Name" DataValueField="Code" >
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                    </table>
                    <table width="99%" border="0" cellspacing="2" cellpadding="0">
                        <tr>
                            <td align="left" valign="bottom" width="50%">
                               Available Job Components
                            </td>
                            <td align="left" valign="bottom" width="50%">
                               Current Job Components
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                <telerik:RadListBox ID="RadListBoxAvailableJobComponents" runat="server" Width="100%"
                                    AutoPostBack="false" Height="425" SelectionMode="Multiple" AllowTransfer="true"
                                    TransferToID="RadListBoxCurrentJobComponents" AutoPostBackOnTransfer="true"
                                    AllowReorder="False" EnableDragAndDrop="false" DataValueField="ID" DataTextField="Description" ButtonSettings-HorizontalAlign="Center" ButtonSettings-AreaHeight="30px" ButtonSettings-AreaWidth="30px">
                                    <ButtonSettings TransferButtons="TransferAllFrom,TransferFrom" />
                                </telerik:RadListBox>
                            </td>
                            <td align="left" valign="top">
                                <telerik:RadListBox ID="RadListBoxCurrentJobComponents" runat="server" Width="100%"
                                    AutoPostBack="false" Height="425" SelectionMode="Multiple" AllowReorder="false"
                                    AutoPostBackOnTransfer="false" AutoPostBackOnDelete="true" EnableDragAndDrop="false" DataValueField="ID" DataTextField="Description"
                                    AllowDelete="true" AllowTransfer="false">
                                    <ButtonSettings ShowDelete="true" ShowTransfer="false" ShowTransferAll="false"/>
                                </telerik:RadListBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CheckBoxShowJobsForAllOffices" runat="server" AutoPostBack="true" Text="Show Jobs for All Offices:" Checked="false" />
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
