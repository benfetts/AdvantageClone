<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" 
    CodeBehind="Media_ATB_CreateOrder.aspx.vb" Inherits="Webvantage.Media_ATB_CreateOrder" %>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
        <tr>
            <td>
                <telerik:RadToolBar ID="RadToolbarOptions" runat="server" AutoPostBack="True" Width="100%">
                    <Items>

                        <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonCreate" runat="server" Text="Create" Value="Create" 
                            CommandName="Create" ToolTip="Create"  />
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
                            <fieldset>
                                <legend>Options</legend>
                                <asp:RadioButtonList ID="RadioButtonList_Options" runat="server" AutoPostBack="true" RepeatDirection="Vertical">
                                </asp:RadioButtonList>
                            </fieldset>
                        </td>
                        <td style="width:10px;"></td>
                    </tr>
                    <tr>
                        <td height="5px" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="TrSummaryRecord" runat="server" visible="false">
                        <td style="width:10px;"></td>
                        <td style="width: 580px;">
                            &nbsp;<telerik:RadButton ID="RadButton_SummaryRecord" runat="server" ButtonType="ToggleButton" ToggleType="CheckBox" AutoPostBack="true"
                                    Text="Create an order summary record for a generic Vendor"></telerik:RadButton>
                        </td>
                        <td style="width:10px;"></td>
                    </tr>
                    <tr id="TrVendor" runat="server">
                        <td style="width:10px;"></td>
                        <td style="width: 580px;">
                            &nbsp;<telerik:RadComboBox ID="RadComboBox_Vendor" runat="server" AutoPostBack="false" Width="350px" SkinID="RadComboBoxStandard" EnableLoadOnDemand="true" Filter="Contains" Label="Ad Serving Vendor:">
                                  </telerik:RadComboBox>
                        </td>
                        <td style="width:10px;"></td>
                    </tr>
                    <tr id="TrIncludeMarkup" runat="server">
                        <td style="width:10px;"></td>
                        <td style="width: 580px;">
                            &nbsp;<telerik:RadButton ID="RadButtonIncludeMarkup" runat="server" AutoPostBack="false" ButtonType="ToggleButton" ToggleType="CheckBox" Text="Include Markup Percent on Ad Serving Order/Line?" ></telerik:RadButton>
                        </td>
                        <td style="width:10px;"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>
