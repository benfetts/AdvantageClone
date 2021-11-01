<%@ Page AutoEventWireup="false" CodeBehind="ServiceFeeDetailPrint.aspx.vb" Inherits="Webvantage.ServiceFeeDetailPrint"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Service Fee" %>
<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="ContentDashboard" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">    
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">  
            <tr>
                <td colspan="2" align="left" >
                    &nbsp;<asp:Label ID="lblTitle" runat="server" Text="Service Fee"></asp:Label>
                </td>
            </tr>          
            <tr>
                <td valign="top">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="98%">
                        <tr>
                            <td colspan="4">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top" colspan="2">
                                            <telerik:RadGrid ID="RadGridServiceFee" runat="server" AllowPaging="false" AllowSorting="True"
                                                Width="100%" AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True"
                                                EnableHeaderContextMenu="true" ShowFooter="true">
                                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" ></PagerStyle>      
                                                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                    <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown"  />
                                                    <Selecting AllowRowSelect="True" />
                                                </ClientSettings>
                                                <MasterTableView AllowMultiColumnSorting="true" Width="100%" DataKeyNames="CampaignID,JobNumber,ComponentNumber,JobComponent,ComponentDescription,PostPeriodCode,FunctionCode,FunctionHeading,FunctionConsolidation">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="ClientDescription" HeaderText="Client" UniqueName="c">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>            
                                                        <telerik:GridBoundColumn DataField="DivisionDescription" HeaderText="Division" UniqueName="cd" Display="false">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="ProductDescription" HeaderText="Product" UniqueName="cdp" Display="false">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>            
                                                        <telerik:GridBoundColumn DataField="ServiceFeeTypeDescription" HeaderText="Fee Type" UniqueName="fee" Display="false">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>            
                                                        <telerik:GridBoundColumn DataField="CampaignName" HeaderText="Campaign" UniqueName="campaign" Display="false">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>            
                                                        <telerik:GridBoundColumn DataField="JobNumber" HeaderText="Job/Component" UniqueName="jc" Display="false">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>            
                                                        <telerik:GridBoundColumn DataField="FunctionDescription" HeaderText="Function" UniqueName="func" Display="false">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>            
                                                        <telerik:GridBoundColumn DataField="FunctionHeading" HeaderText="Function Heading" UniqueName="funchead" Display="false">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>            
                                                        <telerik:GridBoundColumn DataField="FunctionConsolidation" HeaderText="Consolidation" UniqueName="consol" Display="false">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>            
                                                        <telerik:GridBoundColumn DataField="PostPeriodCode" HeaderText="Post Period" UniqueName="pp" Display="false">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FeeAmount" HeaderText="Fee Billed" UniqueName="column36" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Hours" HeaderText="Actual Hours" UniqueName="column34" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Amount" HeaderText="Actual Amount" UniqueName="column35" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="VarianceAmount" HeaderText="Variance" UniqueName="taskcolumn" DataFormatString="{0:#,##0.00}">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
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
                                        <td align="center" valign="top" colspan="2">
                                            <telerik:RadGrid ID="RadGridServiceFeeEmp" runat="server" AllowPaging="false" AllowSorting="True"
                                                Width="100%" AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True"
                                                EnableHeaderContextMenu="true" ShowFooter="true">
                                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" ></PagerStyle>
                                                <MasterTableView AllowMultiColumnSorting="true" Width="100%" DataKeyNames="JobComponent,ComponentDescription">
                                                    <Columns>
                                                        <telerik:GridBoundColumn DataField="ClientDescription" HeaderText="Client" UniqueName="c">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>            
                                                        <telerik:GridBoundColumn DataField="DivisionDescription" HeaderText="Division" UniqueName="cd" Display="false">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="ProductDescription" HeaderText="Product" UniqueName="cdp" Display="false">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>            
                                                        <telerik:GridBoundColumn DataField="ServiceFeeTypeDescription" HeaderText="Fee Type" UniqueName="fee" Display="false">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>            
                                                        <telerik:GridBoundColumn DataField="CampaignName" HeaderText="Campaign" UniqueName="campaign" Display="false">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>            
                                                        <telerik:GridBoundColumn DataField="JobNumber" HeaderText="Job/Component" UniqueName="jc" Display="false">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>            
                                                        <telerik:GridBoundColumn DataField="FunctionDescription" HeaderText="Function" UniqueName="func" Display="false">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>            
                                                        <telerik:GridBoundColumn DataField="FunctionHeading" HeaderText="Function Heading" UniqueName="funchead" Display="false">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>            
                                                        <telerik:GridBoundColumn DataField="FunctionConsolidation" HeaderText="Consolidation" UniqueName="consol" Display="false">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>            
                                                        <telerik:GridBoundColumn DataField="PostPeriodCode" HeaderText="Post Period" UniqueName="pp" Display="false">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>                                                                    
                                                        <telerik:GridBoundColumn DataField="EmployeeName" HeaderText="Employee" UniqueName="emp" Display="false">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>            
                                                        <telerik:GridBoundColumn DataField="FeeDate" HeaderText="Date" UniqueName="empdate" Display="false">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="FeeAmount" HeaderText="Fee Billed" UniqueName="column36" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Hours" HeaderText="Actual Hours" UniqueName="column34" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="Amount" HeaderText="Actual Amount" UniqueName="column35" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="VarianceAmount" HeaderText="Variance" UniqueName="taskcolumn" DataFormatString="{0:#,##0.00}">
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                        </telerik:GridBoundColumn>
                                                    </Columns>
                                                    <ExpandCollapseColumn Visible="False">
                                                        <HeaderStyle Width="19px" />
                                                    </ExpandCollapseColumn>
                                                    <RowIndicatorColumn Visible="False">
                                                        <HeaderStyle Width="20px" />
                                                    </RowIndicatorColumn>
                                                </MasterTableView>
                                                <ClientSettings>
                                                    <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" />
                                                </ClientSettings>
                                            </telerik:RadGrid>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadGrid ID="RadGridWrapper" runat="server" ShowHeader="false" Visible="false"
                        BorderStyle="None">
                        <ExportSettings OpenInNewWindow="true" />
                        <MasterTableView AutoGenerateColumns="true">
                            <ItemTemplate>
                                <telerik:RadGrid ID="RadGridServiceFee" runat="server"
                                    Width="100%" GridLines="None" OnNeedDataSource="RadGridSerFee_NeedDataSource" ShowFooter="true" OnItemDataBound="RadGridSerFee_ItemDataBound">
                                    <ExportSettings ExportOnlyData="true" OpenInNewWindow="true" />
                                    <MasterTableView AutoGenerateColumns="False" Width="100%" DataKeyNames="CampaignID,JobNumber,ComponentNumber,JobComponent,ComponentDescription,PostPeriodCode,FunctionCode,FunctionHeading,FunctionConsolidation">
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="ClientDescription" HeaderText="Client" UniqueName="c">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DivisionDescription" HeaderText="Division" UniqueName="cd" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ProductDescription" HeaderText="Product" UniqueName="cdp" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ServiceFeeTypeDescription" HeaderText="Fee Type" UniqueName="fee" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CampaignName" HeaderText="Campaign" UniqueName="campaign" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="JobNumber" HeaderText="Job/Component" UniqueName="jc" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FunctionDescription" HeaderText="Function" UniqueName="func" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FunctionHeading" HeaderText="Function Heading" UniqueName="funchead" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FunctionConsolidation" HeaderText="Consolidation" UniqueName="consol" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PostPeriodCode" HeaderText="Post Period" UniqueName="pp" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FeeAmount" HeaderText="Fee Billed" UniqueName="column36" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Hours" HeaderText="Actual Hours" UniqueName="column34" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Amount" HeaderText="Actual Amount" UniqueName="column35" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="VarianceAmount" HeaderText="Variance" UniqueName="taskcolumn" DataFormatString="{0:#,##0.00}">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                                <br />
                                <telerik:RadGrid ID="RadGridServiceFeeEmp" runat="server"
                                    Width="100%" GridLines="None" OnNeedDataSource="RadGridSerFeeEmp_NeedDataSource" ShowFooter="true" OnItemDataBound="RadGridSerFeeEmp_ItemDataBound">
                                    <ExportSettings ExportOnlyData="true" OpenInNewWindow="true" />
                                    <MasterTableView AutoGenerateColumns="False" Width="100%" DataKeyNames="JobComponent,ComponentDescription">
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="ClientDescription" HeaderText="Client" UniqueName="c">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DivisionDescription" HeaderText="Division" UniqueName="cd" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ProductDescription" HeaderText="Product" UniqueName="cdp" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EmployeeName" HeaderText="Employee" UniqueName="emp" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FeeDate" HeaderText="Date" UniqueName="empdate" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FeeAmount" HeaderText="Fee Billed" UniqueName="column36" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Hours" HeaderText="Actual Hours" UniqueName="column34" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Amount" HeaderText="Actual Amount" UniqueName="column35" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="VarianceAmount" HeaderText="Variance" UniqueName="taskcolumn" DataFormatString="{0:#,##0.00}">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                                <br />
                            </ItemTemplate>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
        <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
        
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
