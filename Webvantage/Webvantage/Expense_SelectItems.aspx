<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Expense_SelectItems.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="" Inherits="Webvantage.Expense_SelectItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
<table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
    <tr>
        <td align="left" valign="top">
            <telerik:RadToolBar ID="RadToolBarExpense" runat="server" AutoPostBack="true" Width="100%">
                <Items>
                    <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonSave" runat="server" Text="" Value="Save" CommandName="Save" ToolTip="Save" SkinID="RadToolBarButtonSave" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonLastSeparator" runat="server" IsSeparator="true" />
                </Items>
            </telerik:RadToolBar>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td>
            Select expense item(s) associated to the document. (optional)
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadGrid ID="RadGrid_ExpenseItems" runat="server" AllowPaging="True" AllowSorting="True" GridLines="None" PageSize="10" 
                ShowFooter="False" AutoGenerateColumns="False" EnableAJAX="True" EnableAJAXLoadingTemplate="False" AllowMultiRowSelection="true">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" Height="20px">
                </PagerStyle>
                <ClientSettings>
                    <Selecting AllowRowSelect="true" UseClientSelectColumnOnly="true" />
                </ClientSettings>
                <MasterTableView DataKeyNames="ID">
                    <Columns>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSelected" HeaderText=""
                            SortExpression="Selected">
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                            <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBoxSelected" runat="server" Checked='<%#Eval("Selected")%>'
                                    AutoPostBack="true" OnCheckedChanged="CheckBoxSelected_CheckedChanged"/>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn UniqueName="ItemDate" DataField="ItemDate" HeaderText="Item Date"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Description" DataField="Description" HeaderText="Description"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="ClientCode" DataField="ClientCode" HeaderText="Client"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="DivisionCode" DataField="DivisionCode" HeaderText="Division"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="ProductCode" DataField="ProductCode" HeaderText="Product"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="JobNumber" DataField="JobNumber" HeaderText="Job"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="JobComponentNumber" DataField="JobComponentNumber" HeaderText="Job Comp"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="FunctionCode" DataField="FunctionCode" HeaderText="Function"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Quantity" DataField="Quantity" HeaderText="Quantity"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Rate" DataField="Rate" HeaderText="Rate"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Amount" DataField="Amount" HeaderText="Amount"></telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </td>
    </tr>
</table>
    
</asp:Content>
