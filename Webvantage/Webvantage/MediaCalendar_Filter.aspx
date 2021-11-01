<%@ Page AutoEventWireup="false" CodeBehind="MediaCalendar_Filter.aspx.vb" Inherits="Webvantage.MediaCalendar_Filter"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Media Filter" %>

<%@ Register Src="ReportTypeUC.ascx" TagName="reporttype" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain"
    EnableViewState="true">
    <div class="telerik-aqua-body" style="margin-top: 7px;">
        <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0" style="background: white;">
            <tr>
                <td colspan="3">
                    <telerik:RadTabStrip ID="RadTabStrip" runat="server" AutoPostBack="True" CausesValidation="False"
                        Width="100%"   >
                        <Tabs>
                            <telerik:RadTab ID="Tab1" runat="server" Text="Root Tab">
                            </telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" colspan="3">
                    <table id="Table1" align="center" cellpadding="2" cellspacing="0" width="100%">
                        <tr>
                            <td align="center" class="sub-header sub-header-color" colspan="2">
                                Calendar Options
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:RadioButton ID="rbMediaTraffic" runat="server" AutoPostBack="True" GroupName="Calendar"
                                    Text="Media Traffic Calendar" />
                            </td>
                            <td align="left" nowrap="nowrap" rowspan="2">
                                <asp:CheckBox ID="chkPrint" runat="server" Text="Printable Calendar" Visible="false" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:RadioButton ID="rbMediaSchedule" runat="server" AutoPostBack="True" GroupName="Calendar"
                                    Text="Media Schedule" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table align="center" width="100%" cellspacing="0">
                        <tr>
                            <td align="center" valign="top">
                                <table id="Table5" align="center" cellpadding="2" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" class="sub-header sub-header-color" colspan="2">
                                            Include Options
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                        </td>
                                        <td align="left" nowrap="nowrap">
                                            <asp:CheckBox ID="chkMagazine" runat="server" Text="Include Magazines" Checked="true"
                                                AutoPostBack="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                        </td>
                                        <td align="left" nowrap="nowrap">
                                            <asp:CheckBox ID="chkNewspaper" runat="server" Text="Include Newpapers" Checked="true"
                                                AutoPostBack="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                        </td>
                                        <td align="left" nowrap="nowrap">
                                            <asp:CheckBox ID="chkInternet" runat="server" Text="Include Internet" Checked="true"
                                                AutoPostBack="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                        </td>
                                        <td align="left" nowrap="nowrap">
                                            <asp:CheckBox ID="chkOutOfHome" runat="server" Text="Include Out of Home" Checked="true"
                                                AutoPostBack="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                        </td>
                                        <td align="left" nowrap="nowrap">
                                            <asp:CheckBox ID="chkTelevision" runat="server" Text="Include Television" Checked="true"
                                                AutoPostBack="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                        </td>
                                        <td align="left" nowrap="nowrap">
                                            <asp:CheckBox ID="chkRadio" runat="server" Text="Include Radio" Checked="true" AutoPostBack="True" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <table id="Table10" align="center" cellpadding="2" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" class="sub-header sub-header-color" colspan="2">
                                            Filter Options
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                        </td>
                                        <td align="left" nowrap="nowrap">
                                            <asp:CheckBox ID="chkAcceptedOrders" runat="server" Text="Accepted Orders Only" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                        </td>
                                        <td align="left" nowrap="nowrap">
                                            <asp:CheckBox ID="chkCancelledOrders" runat="server" Text="Include Cancelled Orders/Lines" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table id="Table11" cellpadding="2" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" class="sub-header sub-header-color" colspan="2">
                                            <font color="black"></font>Selection Options
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <table id="Table12" width="100%">
                                                <tr>
                                                    <td>
                                                        <telerik:radpanelbar id="RadPanelbarMediaFilter" runat="server" collapseanimation-duration="200"
                                                            collapseanimation-type="Linear" expandanimation-duration="200" expandanimation-type="Linear"
                                                            width="325px" borderstyle="None">
                                                            <Items>
                                                                <telerik:RadPanelItem runat="server" Expanded="true">
                                                                    <Items>
                                                                        <telerik:RadPanelItem runat="server">
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            <asp:HyperLink ID="hlOffice" runat="server" href=""><span>Office:</span></asp:HyperLink>
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:TextBox ID="txtOffice" runat="server" Width="145px" SkinID="TextBoxStandard"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            <asp:HyperLink ID="hlClient" runat="server" href=""><span>Client:</span></asp:HyperLink>
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:TextBox ID="txtClient" runat="server" Width="145px" SkinID="TextBoxStandard"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            <asp:HyperLink ID="hlDivision" runat="server" href=""><span>Division:</span></asp:HyperLink>
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:TextBox ID="txtDivision" runat="server" Width="145px" SkinID="TextBoxStandard"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            <asp:HyperLink ID="hlProduct" runat="server" href=""><span>Product:</span></asp:HyperLink>
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:TextBox ID="txtProduct" runat="server" Width="145px" SkinID="TextBoxStandard"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            Media Type:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <telerik:RadComboBox ID="ddMediaTypeList" runat="server" SkinID="RadComboBoxStandard">
                                                                                            </telerik:RadComboBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            <asp:HyperLink ID="hlCampaign" runat="server" href=""><span>Campaign:</span></asp:HyperLink>
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:TextBox ID="txtCampaign" runat="server" Width="145px" SkinID="TextBoxStandard"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            Client PO:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:TextBox ID="txtClientPO" runat="server" Width="75px" SkinID="TextBoxStandard"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            Vendor:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <telerik:RadComboBox ID="ddVendorList" runat="server" SkinID="RadComboBoxStandard">
                                                                                            </telerik:RadComboBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            Buyer:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <telerik:RadComboBox ID="ddBuyerList" runat="server" SkinID="RadComboBoxStandard">
                                                                                            </telerik:RadComboBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </telerik:RadPanelItem>
                                                                    </Items>
                                                                </telerik:RadPanelItem>
                                                            </Items>
                                                            <ExpandAnimation Duration="300" Type="Linear" />
                                                            <CollapseAnimation Duration="300" Type="Linear" />
                                                        </telerik:radpanelbar>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <br />
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="center" valign="top">
                    <table align="center" width="100%" cellspacing="0">
                        <tr>
                            <td align="center" valign="top">
                                <table id="Table6" align="center" cellpadding="2" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" class="sub-header sub-header-color">
                                            Display Options (Choose up to five)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                                <asp:CheckBox ID="chkClient" runat="server" Text="Client" />
                                                <br />
                                                <asp:CheckBox ID="chkDivision" runat="server" Text="Division" />
                                                <br />
                                                <asp:CheckBox ID="chkProduct" runat="server" Text="Product" />
                                                <br />
                                                <asp:CheckBox ID="chkType" runat="server" Text="Type" />
                                                <br />
                                                <asp:CheckBox ID="chkMediaType" runat="server" Text="Media Type" />
                                                <br />
                                                <asp:CheckBox ID="chkInsertionLineNum" runat="server" Text="Insertion Order/Line Number" />
                                                <br />
                                                <asp:CheckBox ID="chkVendorCode" runat="server" Text="Vendor Code" />
                                                <br />
                                                <asp:CheckBox ID="chkVendorName" runat="server" Text="Vendor Name" />
                                                <br />
                                                <asp:CheckBox ID="chkJobComponent" runat="server" Text="Job/Component Number" />
                                                <br />
                                                <asp:CheckBox ID="chkCampaignCode" runat="server" Text="Campaign Code" />
                                                <br />
                                                <asp:CheckBox ID="chkCampaignName" runat="server" Text="Campaign Name" />
                                                <br />
                                                <asp:CheckBox ID="chkMarketCode" runat="server" Text="Market Code" />
                                                <br />
                                                <asp:CheckBox ID="chkMarketName" runat="server" Text="Market Name" />
                                                <br />
                                                <asp:CheckBox ID="chkAdSizeLength" runat="server" Text="Ad Size/Length" />
                                                <br />
                                                <asp:CheckBox ID="chkHeadlineProg" runat="server" Text="Headline/Programming" />
                                                <br />
                                                <asp:CheckBox ID="chkExtendedMatDate" runat="server" Text="Extended Material Date" />
                                                <br />
                                                <asp:CheckBox ID="chkCloseDate" runat="server" Text="Close Date" />
                                                <br />
                                                <asp:CheckBox ID="chkExtendedCloseDate" runat="server" Text="Extended Close Date" />
                                                <br />
                                                <asp:CheckBox ID="chkRunDate" runat="server" Text="Run Date" />
                                                <br />
                                                <asp:CheckBox ID="CheckBoxDocuments" runat="server" Text="Documents" />
                                                <br />
                                                <asp:CheckBox ID="chkBillingAmount" runat="server" Text="Billing Amount" />
                                                <br />
                                                <asp:CheckBox ID="chkSpots" runat="server" Text="Spots" />
                                        
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                
                </td>
                <td valign="top">
                    <table align="center" width="100%" cellspacing="0">
                        <tr>
                            <td align="right" valign="top">
                                <table id="Table4" align="center" cellpadding="2" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" class="sub-header sub-header-color" colspan="2">
                                            Media Display By Options (Choose only one)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <table id="Table8" border="0" cellpadding="2" cellspacing="0" align="left">
                                                <tr>
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:CheckBox ID="chkMaterialDueDate" runat="server" Text="Material Due Date" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:CheckBox ID="chkExtendedMaterialDueDate" runat="server" Text="Extended Material Due Date" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:CheckBox ID="chkCloseDateMedia" runat="server" Text="Close Date" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:CheckBox ID="chkExtendedCloseDateMedia" runat="server" Text="Extended Close Date" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" nowrap="nowrap">
                                                        <asp:CheckBox ID="chkRunInsertionDate" runat="server" Text="Run Date(Flight Dates)/Insertion Date " />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" nowrap="nowrap">
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkDisplayFlight" runat="server"
                                                            Text="Display on Start Date Only " />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr visible="false">
                                    </tr>
                                </table>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <table id="Table9" align="center" cellpadding="2" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" colspan="3" valign="top">
                                            <asp:Button ID="butRestore" runat="server" Width="115" Text="Restore Defaults" /><br />
                                            <br />
                                            <asp:Button ID="butSave" runat="server" Width="115" Text="Save" /><br />
                                            <br />
                                            <br />
                                            <asp:Label   ID="lblError" runat="server" CssClass="warning"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    
</asp:Content>
