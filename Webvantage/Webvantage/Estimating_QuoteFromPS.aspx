<%@ Page AutoEventWireup="false" CodeBehind="Estimating_QuoteFromPS.aspx.vb" Inherits="Webvantage.Estimating_QuoteFromPS"
    MasterPageFile="~/ChildPage.Master" Title="" Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="300px">
                            <asp:CheckBox id="cbIncludeEmployees" runat="server" Text="Include employees assigned to tasks?" AutoPostBack="true" />
                        </td>
                        <td>
                            <asp:CheckBox id="CheckBoxIncludeTaskComments" runat="server" Text="Include Task Comments" AutoPostBack="true" />
                        </td>
                        <td>
                            <asp:RadioButton ID="RadioButtonDefault" runat="server" Text="Default Hours" GroupName="Hours" AutoPostBack="true" />
                            <asp:RadioButton ID="RadioButtonDisbursed" runat="server" Text="Disbursed Hours" GroupName="Hours" Checked="true" AutoPostBack="true" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <telerik:RadGrid ID="RadGridCopyFromQuotes" runat="server" AllowMultiRowSelection="True" AllowSorting="False"
                                AutoGenerateColumns="False" EnableAJAX="False" GridLines="None" 
                                Width="98%">
                                <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                                <ClientSettings  EnablePostBackOnRowClick="False" >
                                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                                </ClientSettings>
                                <MasterTableView DataKeyNames="FNC_EST, FNC_CODE, FNC_SEQ_NBR">
                                    <Columns>
                                        <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                            <HeaderStyle HorizontalAlign="center" />
                                            <ItemStyle HorizontalAlign="center" />                                        
                                        </telerik:GridClientSelectColumn>                                     
                                        <telerik:GridBoundColumn DataField="SEQ_NBR" HeaderText="Order" UniqueName="colSEQ_NBR">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="right" VerticalAlign="middle" Width="30" />
                                        </telerik:GridBoundColumn>                                   
                                        <telerik:GridBoundColumn DataField="FNC_EST" HeaderText="Function" UniqueName="colFNC_CODE">
                                            <HeaderStyle HorizontalAlign="left" />
                                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="100" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FNC_DESCRIPTION" HeaderText="Function Description" UniqueName="colFNC_DESC">
                                            <HeaderStyle HorizontalAlign="left" />
                                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EMP_CODE" HeaderText="Employee" UniqueName="colEMP_CODE" Display="false">
                                            <HeaderStyle HorizontalAlign="center" />
                                            <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />                                        
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Employee Name" UniqueName="colEmpName" Display="false">
                                            <HeaderStyle HorizontalAlign="center" />
                                            <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />                                        
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="JOB_HRS" HeaderText="Hours" UniqueName="colJOB_HRS" Display="false">
                                            <HeaderStyle HorizontalAlign="center" />
                                            <ItemStyle HorizontalAlign="right" VerticalAlign="middle" />                                        
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="HOURS" HeaderText="Hours" UniqueName="colHOURS">
                                            <HeaderStyle HorizontalAlign="center" />
                                            <ItemStyle HorizontalAlign="right" VerticalAlign="middle" />                                        
                                        </telerik:GridBoundColumn>                                                                       
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
                            <asp:Button ID="BtnRefresh" runat="server"  Text="Refresh" />
                            &nbsp;&nbsp;
                            <asp:Button ID="BtnCopy" runat="server"  Text="Add Functions" CommandName="AddFunctions" />
                            <br /> 
                            <br /> 
                            <br /> 
                        </td>
                    </tr>                            
                </table>
        <asp:Literal ID="LitScript" runat="server"></asp:Literal>
</asp:Content>
    
