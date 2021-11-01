<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="purchaseorder_trans_summ.aspx.vb"
    Inherits="Webvantage.purchaseorder_trans_summ" MasterPageFile="~/ChildPage.Master"
    Title=">Purchase Order Summary" %>

<%@ Register Src="purchaseorder_base_info.ascx" TagName="purchaseorder_base_info"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table cellpadding="0" cellspacing="0" style="background-color: white; width: 68%;
        height: 542px;">
        <tr>
            <td>
                <uc1:purchaseorder_base_info ID="Purchaseorder_base_info1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="sub-header sub-header-color">
               <span style="color: #ffffff">Summarize Purchase Order Functions / Referenced
                    Job Components</span>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <telerik:RadTabStrip ID="RadTabStripPOTransactionSummary" runat="server" AutoPostBack="True"
                    CausesValidation="False">
                    <Tabs>
                        <telerik:RadTab Text="Job and Functions">
                        </telerik:RadTab>
                        <telerik:RadTab Text="A/P Invoices">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Estimates">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label   ID="lbl_title" runat="server" Text="Summary"></asp:Label>
                &nbsp; &nbsp;
                <asp:LinkButton ID="lbtn_inv_dtl_view" runat="server">Invoice Detail View</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td valign="top" style="height: 303px">
                <div style="overflow: auto; width: 814px; height: 233px">
                    <asp:GridView ID="gv_polist" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                        CellSpacing="1" DataKeyNames="PO_NUMBER,LINE_NUMBER" GridLines="Vertical" Width="96%"
                        ShowFooter="True" CellPadding="1">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image ID="select" runat="server" ImageUrl="images/square_blueS.gif" />
                                    <asp:HiddenField ID="hfPONumber" runat="server" Value='<%#Eval("PO_NUMBER").ToString%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SRC" HeaderText="Source"></asp:BoundField>
                            <asp:BoundField DataField="REF_NUMBER" HeaderText="Reference"></asp:BoundField>
                            <asp:BoundField DataField="CL_CODE" HeaderText="Client Code">
                                <ItemStyle Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="JOBANDCOMP" HeaderText="Job/Comp#"></asp:BoundField>
                            <asp:BoundField DataField="FNC_CODE" HeaderText="Function" />
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Qty
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%#GetColumnAmount(4, Eval("SUMQTY").ToString(),0)%>
                                    <%#Eval("QTY") %>
                                </ItemTemplate>
                                <FooterTemplate>
                                    Qty<br />
                                        Balance<br />
                                    ----------<br />
                                    <%#String.Format("{0:#,##0.00}", CDbl(GetColumnTotal(4).ToString))%>
                                </FooterTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                                <FooterStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Amount
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%#GetColumnAmount(5, Eval("SUMAMOUNT").ToString(), 0)%>
                                    <%#Eval("AMOUNT") %>
                                </ItemTemplate>
                                <FooterTemplate>
                                    Balance<br />
                                    ----------<br />
                                    <%#String.Format("{0:#,##0.00}", CDbl(GetColumnTotal(5).ToString))%>
                                </FooterTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                                <FooterStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="INV_DATE" HeaderText="Invoice Date">
                                <ItemStyle Width="5%" />
                            </asp:BoundField>
                            <asp:CheckBoxField HeaderText="Complete" DataField="PO_COMPLETE">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CheckBoxField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Billable</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Image ID="img_nonbill" ImageUrl='<%#GetNonBillableFlagIcon(Eval("NONBILL")) %>'
                                        runat="server" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BackColor="LightSkyBlue" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top" class="sub-header sub-header-color">
               <span style="color: #ffffff">Summarize Purchase Order Expenditures for Referenced
                    Jobs</span>
            </td>
        </tr>
        <tr>
            <td valign="top" align="center">
                <button id="btnClose" causesvalidation="false" onclick="JavaScript:window.close();">
                    Cancel</button>
            </td>
        </tr>
    </table>
</asp:Content>