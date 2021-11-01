<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="purchaseorder_memos.aspx.vb" Inherits="Webvantage.purchaseorder_memos"
    Title="Purchase Order Instructions" %>

<%@ Register Src="purchaseorder_base_info.ascx" TagName="purchaseorder_base_info"
    TagPrefix="uc2" %>
<%@ Register Src="purchaseorder_memo_nav.ascx" TagName="purchaseorder_memo_nav" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <script runat="server">
    Sub SetChangeStatus(ByVal sender As Object, ByVal e As EventArgs)
        lbl_changestat.Text = "Changed"
    End Sub
    </script>
    <script type="text/javascript">
        function getMessage() {
            var ans;

            if (document.forms[0]._ctl0_ContentPlaceHolderMain_current_tab.value == '1' && document.forms[0]._ctl0_ContentPlaceHolderMain_txt_memo.length != 0) {

                ans = window.confirm('Clear custom Footer and return to Agency Default?');
                if (ans == true) {
                    document.forms[0]._ctl0_ContentPlaceHolderMain_confirm_clear_flg.value = '1';
                }
                else {
                    document.forms[0]._ctl0_ContentPlaceHolderMain_confirm_clear_flg.value = '0';
                }
            }

        }
    </script>
    <table align="center" cellpadding="0" cellspacing="0" width="95%">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="right">
                            <asp:Button ID="butback" runat="server" CausesValidation="False" Text="Back" Width="76px" Visible="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <uc2:purchaseorder_base_info ID="Purchaseorder_base_info1" runat="server"></uc2:purchaseorder_base_info>
            </td>
        </tr>
        <tr>
            <td >
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="background-color: white;" colspan="2">
                <telerik:RadTabStrip ID="RadTabStripAR" runat="server" AutoPostBack="True" CausesValidation="False"
                      Width="100%">
                    <Tabs>
                        <telerik:RadTab ID="TabMainInstructions" runat="server"
                            Text="Main Instructions">
                        </telerik:RadTab>
                        <telerik:RadTab ID="TabDeliverInstructions" runat="server"
                            Text="Delivery Instructions">
                        </telerik:RadTab>
                        <telerik:RadTab ID="TabFooterComments" runat="server"
                            Text="Footer Comments">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
            </td>
        </tr>
        <tr>
            <td align="left" class="sub-header sub-header-color">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label   ID="lbl_memo_selection" runat="server" Text="error-no selection"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 407px;" align="center" valign="top">
                <table width="100%">
                    <tr>
                        <td style="width: 19px">
                        </td>
                        <td style="width: 705px">
                            <asp:Panel ID="pnl_confirm" runat="server" HorizontalAlign="Center" Visible="False"
                                Width="75%">
                                <table cellpadding="0" cellspacing="0" width="100%" style="background-color: #c0ddfd">
                                    <tr>
                                        <td colspan="1" style="height: 13px; width: 34px;">
                                        </td>
                                        <td colspan="2" >
                                           Save your Changes before continuing?
                                        </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="2" style="width: 34px">
                                            <img src="images/up_down_question.png" alt="?" />
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 16px">
                                            <asp:LinkButton ID="lbtn_no" runat="server" Font-Size="Larger">Continue Without Saving</asp:LinkButton>
                                        </td>
                                        <td style="height: 16px">
                                            <asp:LinkButton ID="lbtn_yes" runat="server" Font-Size="Larger">Save Changes</asp:LinkButton>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 19px; height: 15px">
                        </td>
                        <td align="left" style="width: 705px">
                            <telerik:RadTabStrip ID="TS_Footer_Options" runat="server" CausesValidation="False"
                                AutoPostBack="True">
                            </telerik:RadTabStrip>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 19px; height: 15px">
                            &nbsp;
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txt_memo" runat="server" MaxLength="4000" Rows="20" TextMode="MultiLine" SkinID="TextBoxStandard"
                                Width="690px" OnTextChanged="SetChangeStatus"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <%--<td align="right" colspan="2">--%>
                        <%--<%   '<radSP:RadSpell ID="spell1" runat="server" ControlToCheck="txt_memo"  OnClientCheckCancelled="spellCancelled" />%>--%>
                        <%--<telerik:RadPanelbar ID="RadPanelbar1" runat="server" CausesValidation="False">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Text="Cut &amp; Paste Est. Comments" >
                                        <Items>
                                            <telerik:RadPanelItem runat="server" Text="Estimate Log Comment" Value="est_log_comment">
                                            </telerik:RadPanelItem>
                                            <telerik:RadPanelItem runat="server" Text="Estimate Component Comment" Value="est_comp_comment">
                                            </telerik:RadPanelItem>
                                            <telerik:RadPanelItem runat="server" Text="Estimate Quote Comment" Value="est_qte_comment">
                                            </telerik:RadPanelItem>
                                            <telerik:RadPanelItem runat="server" Text="Estimate Revision Comment" Value="est_rev_comment">
                                            </telerik:RadPanelItem>
                                        </Items>
                                    </telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelbar>--%>
                        <%-- </td> --%>
                        <td style="width: 8px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="" align="left">
                            <asp:Label   ID="lbl_pagemode" runat="server" Text="edit" Visible="False"></asp:Label>
                            <asp:Label   ID="lbl_changestat" runat="server" Text="Unchanged" Visible="False"></asp:Label>
                            <asp:Label   ID="lbl_direct_to" runat="server" Visible="False"></asp:Label>
                            <asp:Label   ID="lbl_ponumber" runat="server" Visible="False"></asp:Label>
                            <input type="text" id="confirm_clear_flg" value="2" runat="server" maxlength="1"
                                size="1" style="display: none" />
                            <input type="text" id="current_tab" value="0" runat="server" maxlength="1" size="1"
                                style="display: none" />
                            <input type="text" id="custom_mode" value="NO" runat="server" maxlength="3" size="3"
                                style="display: none" />
                        </td>
                    </tr>
                </table>
                <asp:Label   ID="lbl_update_column" runat="server" Text="po_main_instruct" Visible="False"></asp:Label>
                <asp:Button ID="btn_save" runat="server" Text="Save" />
            </td>
        </tr>
    </table>
</asp:Content>
