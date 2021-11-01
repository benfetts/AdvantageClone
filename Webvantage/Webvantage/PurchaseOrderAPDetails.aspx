<%@ Page AutoEventWireup="false" CodeBehind="PurchaseOrderAPDetails.aspx.vb" Inherits="Webvantage.PurchaseOrderAPDetails" 
    Language="vb"MasterPageFile="~/ChildPage.Master" Title="" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <style type="text/css">
        #ApDetail {
            border-collapse: collapse;
        }
        #ApDetail td{
            border: 1px solid gray;
            border-collapse: collapse;
            padding: 5px;
        }
        #ApDetail td:nth-child(odd){
            font-weight: bold;
            background-color: lightgray;
            width: 17%;
        }
        #ApDetail td:nth-child(even){
            width: 16%;
            font-weight: normal;
        }
    </style>
    <telerik:RadScriptBlock ID="RadScriptBlockMain" runat="server">
    </telerik:RadScriptBlock>
    <table cellpadding="2" cellspacing="0" border="0" width="100%">
        <tr>
            <td colspan="3">
                <telerik:RadGrid ID="RadGrid_APDetails" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" GridLines="none" PageSize="12" ShowFooter="false">
                    <PagerStyle Mode="NextPrevAndNumeric" NextPageText="&amp;gt;" PrevPageText="&amp;lt;" />
                    <MasterTableView HorizontalAlign="Left">
                        <Columns>
                            <telerik:GridBoundColumn DataField="InvoiceNumber" DataType="System.String" HeaderText="Invoice Number" SortExpression="InvoiceNumber" UniqueName="InvoiceNumber">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="InvoiceDate" DataFormatString="{0:d}" DataType="System.DateTime" HeaderText="Invoice Date" SortExpression="InvoiceDate" UniqueName="InvoiceDate">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="InvoiceAmount" DataType="System.Decimal" HeaderText="Invoice Amount" SortExpression="InvoiceAmount" UniqueName="InvoiceAmount">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FunctionCode" DataType="System.String" HeaderText="Function Code" SortExpression="FunctionCode" UniqueName="FunctionCode">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FunctionDescription" DataType="System.String" HeaderText="Function Description" SortExpression="FunctionDescription" UniqueName="FunctionDescription">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn DataField="NonbillableFlag" DataType="System.Int16" HeaderText="Non Bill" SortExpression="NonbillableFlag" UniqueName="NonbillableFlag">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox_NonbillableFlag" runat="server" Enabled="false" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="GeneralLedgerCode" DataType="System.String" HeaderText="G/L Account" SortExpression="GeneralLedgerCode" UniqueName="GeneralLedgerCode">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Quantity" DataType="System.Decimal" HeaderText="Quantity" SortExpression="Quantity" UniqueName="Quantity">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Rate" DataType="System.Decimal" HeaderText="Rate" SortExpression="Rate" UniqueName="Rate">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Amount" DataType="System.Decimal" HeaderText="Amount" SortExpression="Amount" UniqueName="Amount">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
        <tr>
            <td colspan="3" height="10px"></td>
        </tr>
        <tr>
            <td colspan="3">
                <table cellspacing="0" cellpadding="0" border="0" width="100%" id="ApDetail">
                    <tr>
                        <td>PO Quantity:</td>
                        <td><asp:Label ID="Label_POQuantity" runat="server"></asp:Label></td>
                        <td>Estimate Quantity:</td>
                        <td><asp:Label ID="Label_EstimateQuantity" runat="server"></asp:Label></td>
                        <td>Actual Variance:</td>
                        <td><asp:Label ID="Label_ActualVariance" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>PO Rate:</td>
                        <td><asp:Label ID="Label_PORate" runat="server"></asp:Label></td>
                        <td>Estimate Rate:</td>
                        <td><asp:Label ID="Label_EstimateRate" runat="server"></asp:Label></td>
                        <td>Estimate Variance:</td>
                        <td><asp:Label ID="Label_EstimateVariance" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>PO Amount:</td>
                        <td><asp:Label ID="Label_POAmount" runat="server"></asp:Label></td>
                        <td>Estimate Amount:</td>
                        <td><asp:Label ID="Label_EstimateAmount" runat="server"></asp:Label></td>
                        <td style="border: none; background: none;">&nbsp;</td>
                        <td style="border: none;">&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
