<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Estimating_JobSpecs.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="" Inherits="Webvantage.Estimating_JobSpecs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
        <asp:Label   ID="lblMSG" runat="server" CssClass="CssRequired"></asp:Label>
        <table cellpadding="0" cellspacing="0" width="100%" >
            <tr>
                <td valign="top">
                    <asp:Panel ID="pnlJobSpecs" runat="server" Width="100%">
                    <table width="100%">                        
                        <tr>                            
                            <td align="center">
                                <telerik:RadGrid ID="RadGridEstimateJS" runat="server" AllowMultiRowSelection="false"
                                    AutoGenerateColumns="False" GridLines="None" Width="100%">
                                    <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                                    <ClientSettings AllowColumnHide="True" AllowExpandCollapse="True">
                                        <Scrolling UseStaticHeaders="False" />
                                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
                                    </ClientSettings>
                                    <MasterTableView DataKeyNames="SPEC_VER,SPEC_REV,SEQ_NBR" Width="100%">
                                        <Columns>
                                            <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                                <HeaderStyle HorizontalAlign="Center" Width="5px" />
                                                <ItemStyle HorizontalAlign="Center" Width="5px" />
                                            </telerik:GridClientSelectColumn>                                            
                                            <telerik:GridBoundColumn DataField="SPEC_VER" HeaderText="Version" SortExpression="SPEC_VER" UniqueName="SPEC_VER">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="SPEC_VER_DESC" HeaderText="Description" SortExpression="SPEC_VER_DESC" UniqueName="SPEC_VER_DESC">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="SPEC_REV" HeaderText="Revision" SortExpression="SPEC_REV" UniqueName="SPEC_REV">
                                                <HeaderStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="JOB_QTY" HeaderText="Quantity" SortExpression="JOB_QTY" UniqueName="JOB_QTY">
                                                <HeaderStyle HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>                                            
                                        </Columns>
                                        <ExpandCollapseColumn Resizable="False" Visible="False">
                                            <HeaderStyle Width="20px" />
                                        </ExpandCollapseColumn>
                                        <RowIndicatorColumn Visible="False">
                                            <HeaderStyle Width="20px" />
                                        </RowIndicatorColumn>
                                    </MasterTableView>                    
                                </telerik:RadGrid>
                            </td>                            
                        </tr>                                                 
                    </table>
                    </asp:Panel>
                    <table width="100%">
                        <tr align="center">                            
                            <td align="center">
                                <asp:Button ID="SaveButton" runat="server"  Text="Select" />&nbsp;
                                <asp:Button ID="btnUpdate" runat="server"  Text="Update" />&nbsp;
                                <asp:Button id="CancelButton2" runat="server" Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>        
        <asp:Label   ID="InjectScriptLabel" runat="server"></asp:Label>
</asp:Content>
