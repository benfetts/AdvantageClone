<%@ Page Title="Add Tasks from Estimate" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Schedule_AddFromEst.aspx.vb" Inherits="Webvantage.Schedule_AddFromEst" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:CheckBox ID="cbIncludeEmployees" runat="server" Text="Include employees assigned to functions?"
                    AutoPostBack="true"  />&nbsp;&nbsp;
                <asp:CheckBox ID="cbIncludeHours" runat="server" Text="Include hours assigned to functions?"
                    AutoPostBack="true"  />
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="RadGridCopyFromQuotes" runat="server" AllowMultiRowSelection="True"
                    AllowSorting="False" AutoGenerateColumns="False" EnableAJAX="False" GridLines="None">
                    <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                    <ClientSettings EnablePostBackOnRowClick="False">
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="TRF_CODE,TRF_ORDER,TRF_DAYS,DEF_TRF_ROLE,TRF_HRS,EST_REV_QUANTITY,MILESTONE,EST_FNC_CODE,EMP_CODE,EMP_NAME">
                        <Columns>
                            <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                <HeaderStyle HorizontalAlign="center" Width="5px" />
                                <ItemStyle HorizontalAlign="center" Width="5px" />
                            </telerik:GridClientSelectColumn>
                            <telerik:GridBoundColumn DataField="TRF_CODE" HeaderText="Task Code" UniqueName="colTRF_CODE">
                                <HeaderStyle HorizontalAlign="left" Width="100px" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="100px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TRF_DESC" HeaderText="Task Description"
                                UniqueName="colTRF_DESC">
                                <HeaderStyle HorizontalAlign="left" Width="150px" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="150px" />
                            </telerik:GridBoundColumn>                            
                            <telerik:GridBoundColumn DataField="EMP_CODE" HeaderText="Employee" UniqueName="colEMP_CODE"
                                Display="false">
                                <HeaderStyle HorizontalAlign="left" Width="50px"/>
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="50px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Employee Name" UniqueName="colEmpName"
                                Display="false">
                                <HeaderStyle HorizontalAlign="left" Width="100px"/>
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="100px"/>
                            </telerik:GridBoundColumn>
                           <%-- <telerik:GridBoundColumn DataField="TRF_HRS" HeaderText="Hours" UniqueName="colTRF_HRS">
                                <HeaderStyle HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="right" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>--%>
                            <telerik:GridTemplateColumn DataField="EST_REV_QUANTITY" display="False" HeaderText="Hours"
                                SortExpression="EST_REV_QUANTITY" UniqueName="colEST_REV_QUANTITY">
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtEST_REV_QUANTITY" runat="server" Style="text-align: right; min-width: 50px;
                                        width: 50px;" MaxLength="6" Text='<%# Eval("EST_REV_QUANTITY") %>' SkinID="TextBoxStandard"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="bottom" Width="50px" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="middle" Width="50px" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="middle" Width="50px" />
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <ExpandCollapseColumn Visible="False">
                            <HeaderStyle Width="19px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <br />
                <asp:Button ID="BtnRefresh" runat="server" Text="Refresh" />
                &nbsp;&nbsp;
                <asp:Button ID="BtnCopy" runat="server" Text="Add Tasks" CommandName="AddFunctions" />
                <br />
                <br />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
