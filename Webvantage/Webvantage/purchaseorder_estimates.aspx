<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="purchaseorder_estimates.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.purchaseorder_estimates"
    Title="Webvantage PO Estimate View" %>

<%@ Register Src="purchaseorder_job_comp_list.ascx" TagName="purchaseorder_job_comp_list"
    TagPrefix="uc2" %>
<%@ Register Src="purchaseorder_base_info.ascx" TagName="purchaseorder_base_info"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table cellpadding="0" cellspacing="0" style="width: 68%; height: 542px; background-color: white">
        <tr>
            <td>
                <uc1:purchaseorder_base_info id="Purchaseorder_base_info1" runat="server">
                </uc1:purchaseorder_base_info>
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
                <telerik:RadTabStrip ID="RadTabStripPOEstimates" runat="server" AutoPostBack="True"
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
            </td>
        </tr>
        <tr>
            <td valign="top">
                <div style="overflow: auto; width: 814px; height: 233px">
                    <asp:GridView ID="gvEstimateItems" runat="server" AutoGenerateColumns="false" DataKeyNames="JOB_NUMBER,JOB_COMPONENT_NBR,FNC_CODE,FNC_DESCRIPTION,EST_REV_QUANTITY,EST_REV_RATE,EST_REV_EXT_AMT,EST_REV_COMM_PCT,EXT_MARKUP_AMT,LINE_TOTAL,VENDOR_NAME,CL_CODE,DIV_CODE,PRD_CODE,USE_CPM"
                        EmptyDataText="Select a Job, Component, and (optional) Function Code." Width="97%"
                        ShowFooter="True">
                        <SelectedRowStyle BackColor="AliceBlue" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image ID="select" runat="server" ImageUrl="images/square_blueS.gif" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="JOB_NUMBER" HeaderText="Job Nbr." />
                            <asp:BoundField DataField="ESTIMATE_NUMBER" HeaderText="Est Nbr" />
                            <asp:BoundField DataField="EST_COMPONENT_NBR" HeaderText="Est Comp Nbr" />
                            <asp:BoundField DataField="EST_QUOTE_NBR" HeaderText="Qte Nbr" />
                            <asp:BoundField DataField="EST_REV_NBR" HeaderText="Rev Nbr" />
                            <asp:BoundField DataField="FNC_DESCRIPTION" HeaderText="Function" />
                            <asp:BoundField DataField="EST_REV_QUANTITY" HeaderText="Qty.">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EST_REV_RATE" DataFormatString="{0:F3}" HeaderText="Rate">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="right" FooterStyle-HorizontalAlign="right" FooterStyle-Font-Bold="true">
                                <HeaderTemplate>
                                    Ext Amt
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%# GetColumnAmount(10, Eval("EST_REV_EXT_AMT"))%>
                                </ItemTemplate>
                                <FooterTemplate>
                                    -----------<br />
                                    <%# String.Format("{0:#,##0.00}", CDbl(GetColumnTotal(10)))%>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EST_REV_COMM_PCT" HeaderText="Markup%">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EXT_MARKUP_AMT" DataFormatString="{0:n}" HeaderText="Markup Amt">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="right" FooterStyle-HorizontalAlign="right" FooterStyle-Font-Bold="true">
                                <HeaderTemplate>
                                    Total
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%# GetColumnAmount(13, Eval("LINE_TOTAL"))%>
                                </ItemTemplate>
                                <FooterTemplate>
                                    -----------<br />
                                    <%# String.Format("{0:#,##0.00}", CDbl(GetColumnTotal(13)))%>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="VENDOR_NAME" HeaderText="Use Vendor" />
                            <asp:TemplateField ItemStyle-HorizontalAlign="right" FooterStyle-HorizontalAlign="right" FooterStyle-Font-Bold="true" ItemStyle-Font-Italic="true">
                                <HeaderTemplate>
                                    PO Used(NET)
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%# GetColumnAmount(15, Eval("PO_EXIST_AMT"))%>
                                </ItemTemplate>
                                <FooterTemplate>
                                    -----------<br />
                                    <%# String.Format("{0:#,##0.00}", CDbl(GetColumnTotal(15)))%>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="BALANCE" DataFormatString="{0:n}" HeaderText="Balance(NET)">
                                <ItemStyle Font-Italic="True" HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle BackColor="LightSkyBlue" />
                    </asp:GridView>
                    &nbsp;</div>
            </td>
        </tr>
        <tr>
            <td class="sub-header sub-header-color" valign="top">
               <span style="color: #ffffff">Summarize Purchase Order Expenditures for Referenced
                    Jobs</span>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <button id="btnClose" causesvalidation="false" onclick="JavaScript:window.close();"
                    type="button">
                    Cancel</button>
            </td>
        </tr>
    </table>
</asp:Content>


