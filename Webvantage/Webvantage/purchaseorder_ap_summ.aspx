<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="purchaseorder_ap_summ.aspx.vb"
    Inherits="Webvantage.purchaseorder_ap_summ" MasterPageFile="~/ChildPage.Master"
    Title="Purchase Order Summary" %>

<%@ Register Src="purchaseorder_base_info.ascx" TagName="purchaseorder_base_info"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" cellpadding="0" cellspacing="0" width="95%">
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
                <telerik:RadTabStrip ID="TS_Display_Sources" runat="server" AutoPostBack="True" CausesValidation="False">
                    <Tabs>
                        <telerik:RadTab ID="Tab1" runat="server" Text="Job and Functions">
                        </telerik:RadTab>
                        <telerik:RadTab ID="Tab2" runat="server" Text="A/P Invoices">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Text="Estimates">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label   ID="lbl_title" runat="server" Text="Summary"></asp:Label>
                &nbsp;&nbsp; &nbsp;<asp:LinkButton ID="lbtn_trans_view" runat="server">Transaction View</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <div style="overflow: auto; width: 814px; height: 233px">
                    <asp:GridView ID="gv_polist" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                        CellSpacing="1" DataKeyNames="PO_NUMBER,LINE_NUMBER" GridLines="Vertical" Width="96%"
                        ShowFooter="True">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image ID="select" runat="server" ImageUrl="images/square_blueS.gif" />
                                    <asp:HiddenField ID="hfPONumber" runat="server" Value='<%#Eval("PO_NBR").ToString%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PO_NUMBER" HeaderText="PO/Line"></asp:BoundField>
                            <asp:BoundField DataField="CL_CODE" HeaderText="Client Code" ItemStyle-Width="5%" />
                            <asp:BoundField DataField="JOBANDCOMP" HeaderText="Job/Comp#"></asp:BoundField>
                            <asp:BoundField DataField="FNC_CODE" HeaderText="Function" />
                            <asp:BoundField DataField="PO_QTY" HeaderText="PO Qty" />
                            <asp:TemplateField ItemStyle-HorizontalAlign="right" FooterStyle-HorizontalAlign="right" FooterStyle-Font-Bold="true">
                                <HeaderTemplate>
                                    PO Amount
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%#GetColumnAmount(5, Eval("PO_EXT_AMOUNT").ToString)%>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <%'#String.Format("{0:#,##0.00}", CDbl(GetColumnTotal(5).ToString))%>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="INV_DATE" HeaderText="Invoice Date" ItemStyle-Width="5%" />
                            <asp:BoundField DataField="AP_INV_VCHR" HeaderText="Invoice Number" ItemStyle-Width="5%" />
                            <asp:BoundField DataField="AP_PROD_QUANTITY" HeaderText="Invoice Qty" ItemStyle-Width="5%" />
                            <asp:TemplateField ItemStyle-HorizontalAlign="right" FooterStyle-HorizontalAlign="right" FooterStyle-Font-Bold="true">
                                <HeaderTemplate>
                                    Invoice Amount
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%#GetColumnAmount(6, Eval("AP_PROD_EXT_AMT").ToString)%>
                                </ItemTemplate>
                                <FooterTemplate>
                                    ---------------<br />
                                    <%#String.Format("{0:#,##0.00}", CDbl(GetColumnTotal(6).ToString))%>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="VARIANCE_AMOUNT" HeaderText="Variance">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:CheckBoxField HeaderText="Complete" DataField="PO_COMPLETE">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CheckBoxField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate>
                                    Billable</HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Image ID="img_nonbill" ImageUrl='<%#GetNonBillableFlagIcon(Eval("NONBILL")) %>'
                                        runat="server" />
                                </ItemTemplate>
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
            <td valign="top" align="center"><br />
                <button id="btnClose" causesvalidation="false" onclick="JavaScript:window.close();">
                    Cancel</button>
            </td>
        </tr>
    </table>
</asp:Content>