<%@ Page AutoEventWireup="false" CodeBehind="mediacomments.aspx.vb" Inherits="Webvantage.mediacomments"
    MasterPageFile="~/ChildPage.Master" Title="" Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Panel runat="server" ID="apnlMagazine" Width="100%">
        <asp:Panel runat="server" ID="apnlMagOrder" Width="100%">
            <asp:DataList ID="dlMagOrderComment" runat="server" Width="100%">
                <ItemTemplate>
                    <table id="Table1" align="center" border="0" bordercolor="black" cellpadding="2"
                        cellspacing="0" width="100%">
                        <tr>
                            <td align="middle" class="sub-header sub-header-color ContentHeaderText" colspan="2">
                                &nbsp;&nbsp;Order Comments
                            </td>
                        </tr>
                        <tr>
                            <td width="30%" align="right" valign="top">
                               Order Comments:
                            </td>
                            <td width="70%" align="left">
                                <asp:Label   runat="server" ID="lblOrderComments" Text='<%# Eval("ORDER_COMMENT")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               In House Comments:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblInHouseComments" Text='<%# Eval("HOUSE_COMMENT")%>'>
                                </asp:Label>
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
        <asp:Panel runat="server" ID="apnlMagOrderLine" Width="100%">
            <asp:DataList ID="dlMagOrderLineComment" runat="server" Width="100%">
                <ItemTemplate>
                    <table id="Table1" align="center" border="0" bordercolor="black" cellpadding="2"
                        cellspacing="0" width="100%">
                        <tr>
                            <td align="middle" class="sub-header sub-header-color ContentHeaderText" colspan="2">
                                &nbsp;&nbsp;Line Comments
                            </td>
                        </tr>
                        <tr>
                            <td width="30%" align="right" valign="top">
                               Instructions:
                            </td>
                            <td width="70%" align="left">
                                <asp:Label   runat="server" ID="lblInstructions" Text='<%# Eval("INSTRUCTIONS")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Order Copy:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblOrderCopy" Text='<%# Eval("ORDER_COPY")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Material Notes:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblMaterialNotes" Text='<%# Eval("MATL_NOTES")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Position Info:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblPositionInfo" Text='<%# Eval("POSITION_INFO")%>'>
                                </asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Close Info:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblCloseInfo" Text='<%# Eval("CLOSE_INFO")%>'>
                                </asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Rate Info:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblRateInfo" Text='<%# Eval("RATE_INFO")%>'>
                                </asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Misc Info:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblMiscInfo" Text='<%# Eval("MISC_INFO")%>'>
                                </asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               In House Comments:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblInHouseComments2" Text='<%# Eval("IN_HOUSE_CMTS")%>'>
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
    </asp:Panel>
    <asp:Panel runat="server" ID="apnlNewspaper" Width="100%">
        <asp:Panel runat="server" ID="apnlNewsOrder" Width="100%">
            <asp:DataList ID="dlNewsOrderComment" runat="server" Width="100%">
                <ItemTemplate>
                    <table id="Table1" align="center" border="0" bordercolor="black" cellpadding="2"
                        cellspacing="0" width="100%">
                        <tr>
                            <td align="middle" class="sub-header sub-header-color ContentHeaderText" colspan="2">
                                &nbsp;&nbsp;Order Comments
                            </td>
                        </tr>
                        <tr>
                            <td width="30%" align="right" valign="top">
                               Order Comments:
                            </td>
                            <td width="70%" align="left">
                                <asp:Label   runat="server" ID="lblOrderComments" Text='<%# Eval("ORDER_COMMENT")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               In House Comments:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblInHouseComments" Text='<%# Eval("HOUSE_COMMENT")%>'>
                                </asp:Label>
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
        <asp:Panel runat="server" ID="apnlNewsOrderLine" Width="100%">
            <asp:DataList ID="dlNewsOrderLineComment" runat="server" Width="100%">
                <ItemTemplate>
                    <table id="Table1" align="center" border="0" bordercolor="black" cellpadding="2"
                        cellspacing="0" width="100%">
                        <tr>
                            <td align="middle" class="sub-header sub-header-color ContentHeaderText" colspan="2">
                                &nbsp;&nbsp;Line Comments
                            </td>
                        </tr>
                        <tr>
                            <td width="30%" align="right" valign="top">
                               Instructions:
                            </td>
                            <td width="70%" align="left">
                                <asp:Label   runat="server" ID="lblInstructions" Text='<%# Eval("INSTRUCTIONS")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Order Copy:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblOrderCopy" Text='<%# Eval("ORDER_COPY")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Material Notes:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblMaterialNotes" Text='<%# Eval("MATL_NOTES")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Position Info:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblPositionInfo" Text='<%# Eval("POSITION_INFO")%>'>
                                </asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Close Info:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblCloseInfo" Text='<%# Eval("CLOSE_INFO")%>'>
                                </asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Rate Info:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblRateInfo" Text='<%# Eval("RATE_INFO")%>'>
                                </asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Misc Info:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblMiscInfo" Text='<%# Eval("MISC_INFO")%>'>
                                </asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               In House Comments:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblInHouseComments2" Text='<%# Eval("IN_HOUSE_CMTS")%>'>
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
    </asp:Panel>
    <asp:Panel runat="server" ID="apnlInternet" Width="100%">
        <asp:Panel runat="server" ID="apnlInternetOrder" Width="100%">
            <asp:DataList ID="dlInternetOrderComment" runat="server" Width="100%">
                <ItemTemplate>
                    <table id="Table1" align="center" border="0" bordercolor="black" cellpadding="2"
                        cellspacing="0" width="100%">
                        <tr>
                            <td align="middle" class="sub-header sub-header-color ContentHeaderText" colspan="2">
                                &nbsp;&nbsp;Order Comments
                            </td>
                        </tr>
                        <tr>
                            <td width="30%" align="right" valign="top">
                               Order Comments:
                            </td>
                            <td width="70%" align="left">
                                <asp:Label   runat="server" ID="lblOrderComments" Text='<%# Eval("ORDER_COMMENT")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               In House Comments:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblInHouseComments" Text='<%# Eval("HOUSE_COMMENT")%>'>
                                </asp:Label>
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
        <asp:Panel runat="server" ID="apnlInternetOrderLine" Width="100%">
            <asp:DataList ID="dlInternetOrderLineComment" runat="server" Width="100%">
                <ItemTemplate>
                    <table id="Table1" align="center" border="0" bordercolor="black" cellpadding="2"
                        cellspacing="0" width="100%">
                        <tr>
                            <td align="middle" class="sub-header sub-header-color ContentHeaderText" colspan="2">
                                &nbsp;&nbsp;Line Comments
                            </td>
                        </tr>
                        <tr>
                            <td width="30%" align="right" valign="top">
                               Instructions:
                            </td>
                            <td width="70%" align="left">
                                <asp:Label   runat="server" ID="lblInstructions" Text='<%# Eval("INSTRUCTIONS")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Misc Info:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblMiscInfo" Text='<%# Eval("MISC_INFO")%>'>
                                </asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Order Copy:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblOrderCopy" Text='<%# Eval("ORDER_COPY")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Material Notes:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblMaterialNotes" Text='<%# Eval("MATL_NOTES")%>'>
                                </asp:Label>
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
    </asp:Panel>
    <asp:Panel runat="server" ID="apnlOutdoor" Width="100%">
        <asp:Panel runat="server" ID="apnlOutOrder" Width="100%">
            <asp:DataList ID="dlOutOrderComment" runat="server" Width="100%">
                <ItemTemplate>
                    <table id="Table1" align="center" border="0" bordercolor="black" cellpadding="2"
                        cellspacing="0" width="100%">
                        <tr>
                            <td align="middle" class="sub-header sub-header-color ContentHeaderText" colspan="2">
                                &nbsp;&nbsp;Order Comments
                            </td>
                        </tr>
                        <tr>
                            <td width="30%" align="right" valign="top">
                               Order Comments:
                            </td>
                            <td width="70%" align="left">
                                <asp:Label   runat="server" ID="lblOrderComments" Text='<%# Eval("ORDER_COMMENT")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               In House Comments:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblInHouseComments" Text='<%# Eval("HOUSE_COMMENT")%>'>
                                </asp:Label>
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
        <asp:Panel runat="server" ID="apnlOutOrderLine" Width="100%">
            <asp:DataList ID="dlOutOrderLineComment" runat="server" Width="100%">
                <ItemTemplate>
                    <table id="Table1" align="center" border="0" bordercolor="black" cellpadding="2"
                        cellspacing="0" width="100%">
                        <tr>
                            <td align="middle" class="sub-header sub-header-color ContentHeaderText" colspan="2">
                                &nbsp;&nbsp;Line Comments
                            </td>
                        </tr>
                        <tr>
                            <td width="30%" align="right" valign="top">
                               Instructions:
                            </td>
                            <td width="70%" align="left">
                                <asp:Label   runat="server" ID="lblInstructions" Text='<%# Eval("INSTRUCTIONS")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Order Copy:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblOrderCopy" Text='<%# Eval("ORDER_COPY")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Material Notes:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblMaterialNotes" Text='<%# Eval("MATL_NOTES")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Misc Info:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblMiscInfo" Text='<%# Eval("MISC_INFO")%>'>
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
    </asp:Panel>
    <asp:Panel runat="server" ID="apnlRadio" Width="100%">
        <asp:Panel runat="server" ID="apnlRadioOrder" Width="100%">
            <asp:DataList ID="dlRadioOrderComment" runat="server" Width="100%">
                <ItemTemplate>
                    <table id="Table1" align="center" border="0" bordercolor="black" cellpadding="2"
                        cellspacing="0" width="100%">
                        <tr>
                            <td align="middle" class="sub-header sub-header-color ContentHeaderText" colspan="2">
                                &nbsp;&nbsp;Order Comments
                            </td>
                        </tr>
                        <tr>
                            <td width="30%" align="right" valign="top">
                               Order Comments:
                            </td>
                            <td width="70%" align="left">
                                <asp:Label   runat="server" ID="lblOrderComments" Text='<%# Eval("ORDER_COMMENT")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               In House Comments:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblInHouseComments" Text='<%# Eval("HOUSE_COMMENT")%>'>
                                </asp:Label>
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
        <asp:Panel runat="server" ID="apnlRadioOrderLine" Width="100%">
            <asp:DataList ID="dlRadioOrderLineComment" runat="server" Width="100%">
                <ItemTemplate>
                    <table id="Table1" align="center" border="0" bordercolor="black" cellpadding="2"
                        cellspacing="0" width="100%">
                        <tr>
                            <td align="middle" class="sub-header sub-header-color ContentHeaderText" colspan="2">
                                &nbsp;&nbsp;Line Comments
                            </td>
                        </tr>
                            <tr>
                                <td width="30%" align="right" valign="top">
                                   Instructions:
                                </td>
                                <td width="70%" align="left">
                                    <asp:Label   runat="server" ID="lblInstructions" Text='<%# Eval("INSTRUCTIONS")%>'>
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                   Material Notes:
                                </td>
                                <td align="left">
                                    <asp:Label   runat="server" ID="Label1" Text='<%# Eval("MATL_NOTES")%>'>
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                   In House Comments:
                                </td>
                                <td align="left">
                                    <asp:Label   runat="server" ID="Label2" Text='<%# Eval("HOUSE_COMMENT")%>'>
                                    </asp:Label>
                                </td>
                            </tr>                
                        <tr>
                            <td align="right" valign="top">
                               Close Info:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblCloseInfo" Text='<%# Eval("CLOSE_INFO")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Misc Info:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblMiscInfo" Text='<%# Eval("MISC_INFO")%>'>
                                </asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Rate Info:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblRateInfo" Text='<%# Eval("RATE_INFO")%>'>
                                </asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Position Info:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblPositionInfo" Text='<%# Eval("POSITION_INFO")%>'>
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
    </asp:Panel>
    <asp:Panel runat="server" ID="apnlTV" Width="100%">
        <asp:Panel runat="server" ID="apnlTVOrder" Width="100%">
            <asp:DataList ID="dlTVOrderComment" runat="server" Width="100%">
                <ItemTemplate>
                    <table id="Table1" align="center" border="0" bordercolor="black" cellpadding="2"
                        cellspacing="0" width="100%">
                        <tr>
                            <td align="middle" class="sub-header sub-header-color ContentHeaderText" colspan="2">
                                &nbsp;&nbsp;Order Comments
                            </td>
                        </tr>
                        <tr>
                            <td width="30%" align="right" valign="top">
                               Order Comments:
                            </td>
                            <td width="70%" align="left">
                                <asp:Label   runat="server" ID="lblOrderComments" Text='<%# Eval("ORDER_COMMENT")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               In House Comments:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblInHouseComments" Text='<%# Eval("HOUSE_COMMENT")%>'>
                                </asp:Label>
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
        <asp:Panel runat="server" ID="apnlTVOrderLine" Width="100%">
            <asp:DataList ID="dlTVOrderLineComment" runat="server" Width="100%">
                <ItemTemplate>
                    <table id="Table1" align="center" border="0" bordercolor="black" cellpadding="2"
                        cellspacing="0" width="100%">
                        <tr>
                            <td align="middle" class="sub-header sub-header-color ContentHeaderText" colspan="2">
                                &nbsp;&nbsp;Line Comments
                            </td>
                        </tr>
                            <tr>
                                <td width="30%" align="right" valign="top">
                                   Instructions:
                                </td>
                                <td width="70%" align="left">
                                    <asp:Label   runat="server" ID="lblInstructions" Text='<%# Eval("INSTRUCTIONS")%>'>
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                   Material Notes:
                                </td>
                                <td align="left">
                                    <asp:Label   runat="server" ID="Label1" Text='<%# Eval("MATL_NOTES")%>'>
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                   In House Comments:
                                </td>
                                <td align="left">
                                    <asp:Label   runat="server" ID="Label2" Text='<%# Eval("HOUSE_COMMENT")%>'>
                                    </asp:Label>
                                </td>
                            </tr>                       
                        <tr>
                            <td align="right" valign="top">
                               Close Info:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblCloseInfo" Text='<%# Eval("CLOSE_INFO")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Misc Info:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblMiscInfo" Text='<%# Eval("MISC_INFO")%>'>
                                </asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Rate Info:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblRateInfo" Text='<%# Eval("RATE_INFO")%>'>
                                </asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Position Info:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblPositionInfo" Text='<%# Eval("POSITION_INFO")%>'>
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
    </asp:Panel>
    <div align="center">
        <input onclick="window.close()" type="button" value="Close" /></div>
</asp:Content>