<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" 
    CodeBehind="Media_ATB_OrderDetails.aspx.vb" Inherits="Webvantage.Media_ATB_OrderDetails" %>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
        <tr>
            <td>
                <telerik:RadToolBar ID="RadToolbarOptions" runat="server" AutoPostBack="True" Width="100%">
                    <Items>

                        <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonClose" runat="server" Text="Close" Value="Close" 
                            CommandName="Close" ToolTip="Close" SkinID="RadToolBarButtonCancel" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonSecondSeparator" runat="server" IsSeparator="true" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellpadding="0" cellspacing="5">
                    <tr>
                        <td height="5px" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width:10px;"></td>
                        <td style="width: 580px;">
                            <telerik:RadGrid ID="RadGridOrderDetails" runat="server" AutoGenerateColumns="false" AllowMultiRowSelection="false" GridLines="None" Width="100%" ShowFooter="false" TabIndex="2">
                                <MasterTableView AutoGenerateColumns="false" Width="100%" ShowFooter="false" TabIndex="3">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="Vendor" HeaderText="Vendor" UniqueName="GridBoundColumnVendor" DataType="System.String"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="OrderID" HeaderText="Order ID" UniqueName="GridBoundColumnOrderID" DataType="System.Int32"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="OrderLineID" HeaderText="Order Line ID" UniqueName="GridBoundColumnOrderLineID" DataType="System.Int32"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="OrderNumber" HeaderText="Order Number" UniqueName="GridBoundColumnOrderNumber" DataType="System.Int32"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="OrderLineNumber" HeaderText="Order Line Number" UniqueName="GridBoundColumnOrderLineNumber" DataType="System.Int32"></telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                        <td style="width:10px;"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>
