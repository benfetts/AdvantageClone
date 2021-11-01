<%@ Page Title="Expense Reports" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Expense_V2.aspx.vb" Inherits="Webvantage.Expense_V2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolbarExpense" runat="server" AutoPostBack="True" Width="100%">
        <Items>
            <telerik:RadToolBarButton runat="server">
                <ItemTemplate>
                    Employee Code:&nbsp;&nbsp;
                </ItemTemplate>
            </telerik:RadToolBarButton>
            <telerik:RadToolBarButton runat="server">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox_EmployeeCode" runat="server" SkinID="TextBoxCodeSmall" AutoPostBack="true"></asp:TextBox>
                </ItemTemplate>
            </telerik:RadToolBarButton>
            <telerik:RadToolBarButton runat="server">
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton_EmployeeCodeLookup" runat="server" SkinID="ImageButtonFind" />
                </ItemTemplate>
            </telerik:RadToolBarButton>
            <telerik:RadToolBarButton runat="server">
                <ItemTemplate>
                    &nbsp;&nbsp;Month/Year
                </ItemTemplate>
            </telerik:RadToolBarButton>
            <telerik:RadToolBarButton runat="server">
                <ItemTemplate>
                    <telerik:RadComboBox ID="RadComboBox_Month" runat="server" AutoPostBack="true" SkinID="RadComboBoxMonth" ZIndex="99999999">
                    </telerik:RadComboBox>
                </ItemTemplate>
            </telerik:RadToolBarButton>
            <telerik:RadToolBarButton runat="server">
                <ItemTemplate>
                    <telerik:RadComboBox ID="RadComboBox_Year" runat="server" AutoPostBack="true" SkinID="RadComboBoxYear" ZIndex="99999999">
                    </telerik:RadComboBox>
                </ItemTemplate>
            </telerik:RadToolBarButton>
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh"
                ToolTip="Refresh" />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonNew" Text="New Expense Report" Value="NewExpense"
                Hidden="False" ToolTip="New Expense Report" />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton SkinId="RadToolBarButtonBookmark" Text="" Value="Bookmark"
                ToolTip="Bookmark" Visible="false" />
        </Items>
    </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                <telerik:RadGrid ID="RadGridExpense" runat="server" AllowPaging="False" AllowSorting="True"
                    AutoGenerateColumns="False" EnableAJAX="True" EnableAJAXLoadingTemplate="False"
                    EnableEmbeddedSkins="True" Visible="True">
                    <MasterTableView DataKeyNames="InvoiceNumber">
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="" UniqueName="colViewEdit">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonViewEdit" runat="server" CommandName="ViewDetails" CssClass="icon-image" CommandArgument='<%# Eval("InvoiceNumber")%>' />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="InvoiceNumber" HeaderText="Invoice Number" UniqueName="colINV_NBR">
                                <HeaderStyle HorizontalAlign="right" VerticalAlign="middle" Width="85" />
                                <ItemStyle HorizontalAlign="right" VerticalAlign="middle" Width="85" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="InvoiceDate" HeaderText="Report Date" UniqueName="colINV_DATE">
                                <HeaderStyle HorizontalAlign="right" VerticalAlign="middle" Width="70" />
                                <ItemStyle HorizontalAlign="right" VerticalAlign="middle" Width="70" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CreatedDate" HeaderText="Created Date" UniqueName="colINV_DATE" DataType="System.DateTime" DataFormatString="{0:d}">
                                <HeaderStyle HorizontalAlign="right" VerticalAlign="middle" Width="110" />
                                <ItemStyle HorizontalAlign="right" VerticalAlign="middle" Width="110" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Description" HeaderText="Description" UniqueName="colEXP_DESC" MaxLength="30">
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn DataField="DetailStatus" HeaderText="Status" UniqueName="colSTATUS">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivStatus" runat="server" class="icon-background background-color-sidebar">
                                        <asp:Image ID="StatusImage" runat="server" ImageUrl="~/Images/Icons/White/256/user.png" CssClass="icon-image" />
                                        <telerik:RadToolTip ID="RadToolTipExpenseStatus" runat="server" TargetControlID="StatusImage" ShowEvent="OnMouseOver" RelativeTo="Element">
                                            <asp:label ID="LabelStatusInfo" runat="server"></asp:label>
                                        </telerik:RadToolTip>
                                    </div>
                                    <div>
                                        <asp:Literal ID="LiteralDetailStatus" runat="server" Text='<%# Eval("DetailStatus")%>' />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="TotalNonBillable" HeaderText="Total Non Billable" DataType="System.Decimal"  DataFormatString="{0:F2}">
                                <HeaderStyle HorizontalAlign="right" VerticalAlign="middle" Width="90" />
                                <ItemStyle HorizontalAlign="right" VerticalAlign="middle" Width="90" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TotalBillable" HeaderText="Total Billable" DataType="System.Decimal"  DataFormatString="{0:F2}">
                                <HeaderStyle HorizontalAlign="right" VerticalAlign="middle" Width="90" />
                                <ItemStyle HorizontalAlign="right" VerticalAlign="middle" Width="90" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TotalAmount" HeaderText="Total Expenses" DataType="System.Decimal"  DataFormatString="{0:F2}">
                                <HeaderStyle HorizontalAlign="right" VerticalAlign="middle" Width="90" />
                                <ItemStyle HorizontalAlign="right" VerticalAlign="middle" Width="90" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn1" HeaderText="Paid" SortExpression="Paid">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background standard-green" id="paidDiv" runat="server">
                                        <asp:ImageButton ID="ImageButtonPaid" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CommandName="Paid" CssClass="icon-image" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>
    
</asp:Content>
