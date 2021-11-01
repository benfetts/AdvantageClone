<%@ Page AutoEventWireup="false" CodeBehind="mediavendorrep.aspx.vb" Inherits="Webvantage.mediavendorrep"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Panel runat="server" ID="apnlVendorRep" Width="100%">
        <asp:DataList ID="dlVendorRep" runat="server" Width="100%">
            <ItemTemplate>
                <table id="Table1" align="center" border="0" bordercolor="black" cellpadding="2"
                    cellspacing="0" width="100%">
                    <tr>
                        <td align="middle" class="sub-header sub-header-color ContentHeaderText" colspan="2">
                            &nbsp;&nbsp;Vendor Rep Info
                        </td>
                    </tr>
                    <tr>
                        <td width="30%" align="right" valign="top">
                           Rep:
                        </td>
                        <td width="70%" align="left">
                            <asp:Label   runat="server" ID="lblRep" Text='<%# Eval("VR_CODE").ToString() + "|" + Eval("VR_FNAME").ToString() + " " +  Eval("VR_LNAME")%>'>
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                           Firm:
                        </td>
                        <td align="left">
                            <asp:Label   runat="server" ID="lblFirm" Text='<%# Eval("VR_FIRM_NAME")%>'>
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                           Address:
                        </td>
                        <td align="left">
                            <asp:Label   runat="server" ID="lblAddress" Text='<%# Eval("VR_ADDRESS1") + "|" + Eval("VR_ADDRESS2") %>'>
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                           City:
                        </td>
                        <td align="left">
                            <asp:Label   runat="server" ID="lblCity" Text='<%# Eval("VR_CITY")%>'>
                            </asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                           County:
                        </td>
                        <td align="left">
                            <asp:Label   runat="server" ID="lblCounty" Text='<%# Eval("VR_COUNTY")%>'>
                            </asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                           State:
                        </td>
                        <td align="left">
                            <asp:Label   runat="server" ID="lblState" Text='<%# Eval("VR_STATE")%>'>
                            </asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                           Zip:
                        </td>
                        <td align="left">
                            <asp:Label   runat="server" ID="lblZip" Text='<%# Eval("VR_ZIP")%>'>
                            </asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                           Country:
                        </td>
                        <td align="left">
                            <asp:Label   runat="server" ID="lblCountry" Text='<%# Eval("VR_COUNTRY")%>'>
                            </asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                           Phone #:
                        </td>
                        <td align="left">
                            <asp:Label   runat="server" ID="lblPhone" Text='<%# Eval("VR_TELEPHONE") + " ext " + Databinder.Eval(Container.DataItem, "VR_EXTENTION")%>'>
                            </asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                           Fax #:
                        </td>
                        <td align="left">
                            <asp:Label   runat="server" ID="lblFax" Text='<%# Eval("VR_FAX") + " ext " + Databinder.Eval(Container.DataItem, "VR_FAX_EXTENTION")%>'>
                            </asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                           Email:
                        </td>
                        <td align="left">
                            <asp:Label   runat="server" ID="lblEmail" Text='<%# Eval("EMAIL_ADDRESS")%>'>
                            </asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <br />
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>
    <div align="center">
        <input onclick="window.close()" type="button" value="Close" /></div>
</asp:Content>