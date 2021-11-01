<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="purchaseorder_funct_summ.aspx.vb"
    Title="Purchase Order Function and Job Summary" Inherits="Webvantage.purchaseorder_funct_summ"
    MasterPageFile="~/ChildPage.Master" %>

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
                <telerik:radtabstrip id="RadTabStripPOFunctionSummary" runat="server" autopostback="True" causesvalidation="False">
                     <Tabs>
                         <telerik:radtab Text="Job and Functions" Value="1">
                         </telerik:radtab>
                         <telerik:radtab Text="A/P Invoices" Value="2">
                         </telerik:radtab>
                         <telerik:radtab  Text="Estimates">
                         </telerik:radtab>
                     </Tabs>
                 </telerik:radtabstrip>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:RadioButtonList ID="rbl_options" runat="server" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="2">Show Job Components referenced on this Purchase Order</asp:ListItem>
                    <asp:ListItem Value="1">Show all Job Components for all related Purchase Orders</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td valign="top" style="height: 144px">
                <br />
                <div style="overflow: auto; width: 679px; height: 147px">
                    <asp:GridView ID="gv_JobTotals" AutoGenerateColumns="false" runat="server" DataKeyNames="PO_NUMBER,JOB_NUMBER"
                        BorderStyle="None" CellSpacing="1" GridLines="Vertical" Width="80%">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="2%">
                                <ItemTemplate>
                                    <asp:Image ID="img_bullet" ImageUrl="images/square_blueS.gif" runat="server" />
                                    <asp:HiddenField ID="hfPONumber" runat="server" Value='<%#Eval("PO_NUMBER").ToString%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="JOB_NUMBER" HeaderText="Job#">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CL_CODE" HeaderText="Client">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PO_PAD" HeaderText="PO#">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="JOB_TOTAL" HeaderText="Amount" DataFormatString="{0:n}">
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
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
            <td valign="top">
                <div style="overflow: auto; width: 814px; height: 500px">
                    <asp:GridView ID="gv_polist" AutoGenerateColumns="false" runat="server" DataKeyNames="PO_NUMBER,JOB_NUMBER,JOB_COMPONENT_NBR"
                        BorderStyle="None" CellSpacing="1" GridLines="Vertical" Width="100%">
                        <HeaderStyle BackColor="LightSkyBlue" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image ID="img_bullet" ImageUrl="images/square_blueS.gif" runat="server" />
                                    <asp:HiddenField ID="hfPONumber" runat="server" Value='<%#Eval("PO_NUMBER").ToString%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="JOB_AND_COMP" HeaderText="Job/Comp#" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="FNC_DESCRIPTION" HeaderText="Function" />
                            <asp:BoundField DataField="EXT_AMOUNT" HeaderText="Amount" DataFormatString="{0:n}"
                                ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="PO_PAD" HeaderText="PO#" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="ORDER_DATE" HeaderText="PO Date" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="VN_NAME" HeaderText="Vendor" />
                            <asp:BoundField DataField="EMP_CODE" HeaderText="Issue By" />
                        </Columns>
                    </asp:GridView>
                </div>
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