<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EmployeeTimeForecast_AddIndirectCategories.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Add Employee Time Forecast Indirect Categories"
    Inherits="Webvantage.EmployeeTimeForecast_AddIndirectCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td colspan="2">
                    <%--&nbsp;&nbsp;Employee Time Forecast Indirect Categories--%>
                </td>
            </tr>
            <tr>
                <td runat="server" id="TdRadToolBarEmployeeTimeForecastIndirectCategory" align="left"
                    valign="top" colspan="2">
                    <telerik:RadToolBar ID="RadToolBarEmployeeTimeForecastIndirectCategory" runat="server"
                        AutoPostBack="true" Width="100%">
                        <Items>
                            <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
                            <telerik:RadToolBarButton ID="RadToolBarButtonDone" runat="server" 
                                Text="Done" Value="Done" ToolTip="Finished add\remove indirect categories" />
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
                            <td align="left" valign="bottom" width="285">
                               Available Indirect Categories
                            </td>
                            <td width="285" align="left" valign="bottom">
                               Current Indirect Categories
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                <telerik:RadListBox ID="RadListBoxAvailableIndirectCategories" runat="server" Width="285"
                                    AutoPostBack="false" Height="400" SelectionMode="Multiple" AllowTransfer="true"
                                    TransferToID="RadListBoxCurrentIndirectCategories" AutoPostBackOnTransfer="false"
                                    AllowReorder="False" EnableDragAndDrop="true" DataValueField="Code" DataTextField="Description">
                                </telerik:RadListBox>
                            </td>
                            <td align="left" valign="top">
                                <telerik:RadListBox ID="RadListBoxCurrentIndirectCategories" runat="server" Width="285"
                                    AutoPostBack="false" Height="400" SelectionMode="Multiple" AllowReorder="false"
                                    AutoPostBackOnTransfer="false" EnableDragAndDrop="true" DataValueField="Code"
                                    DataTextField="Description">
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
