<%@ Page AutoEventWireup="false" CodeBehind="ServiceFeeDetail.aspx.vb" Inherits="Webvantage.ServiceFeeDetail"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Service Fee" %>

<asp:Content ID="ContentDashboard" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">    
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="no-float-menu" style="padding: 0;">
                    <telerik:radtoolbar id="RadToolbarServiceFee" runat="server" autopostback="true" width="100%">
                        <Items>                
                            <telerik:RadToolBarButton ID="RadToolBarButtonPrint" SkinID="RadToolBarButtonPrint" CausesValidation="true"
                                CommandName="Print" Value="Print" Hidden="False" ToolTip="Print" />
                           <telerik:RadToolBarButton ID="RadToolBarButtonExport" SkinID="RadToolBarButtonExportExcel" CausesValidation="true"
                               CommandName="ExportExcel" Value="ExportExcel" Hidden="False" ToolTip="Export to a spreadsheet" />
                        </Items>
                    </telerik:radtoolbar>
                </td>
            </tr>
        </table>
        <div class="telerik-aqua-body style-fixes">
            <table  border="0" cellpadding="0" cellspacing="0" width="100%">
            
                        <tr >
                            <td valign="top">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="98%">
                                    <tr>
                                        <td colspan="4">
                                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="left" >
                                                        <fieldset>
                                                        <legend>Group By Options</legend>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox id="CheckboxCampaign" runat="server" Text="Campaign" AutoPostBack="true"/><br />
                                                                    <asp:CheckBox id="CheckboxJobComponent" runat="server" Text="Job/Component" AutoPostBack="true"/><br />
                                                                    <asp:CheckBox id="CheckboxPostPeriod" runat="server" Text="Post Period" AutoPostBack="true"/>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox id="CheckboxFunction" runat="server" Text="Function" AutoPostBack="true"/><br />
                                                                    <asp:CheckBox id="CheckboxFunctionHeading" runat="server" Text="Function Heading" AutoPostBack="true"/><br />
                                                                    <asp:CheckBox id="CheckboxFunctionConsolidation" runat="server" Text="Consolidation" AutoPostBack="true" />
                                                                </td>
                                                            </tr>
                                                        </table> 
                                                        </fieldset>                                              
                                                    </td>
                                                </tr>                                    
                                                <tr>
                                                    <td align="center" valign="top" colspan="2">
                                                        <telerik:RadGrid ID="RadGridServiceFee" runat="server" AllowPaging="True" AllowSorting="True"
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
                                                <asp:Panel ID="PanelEmployee" runat="server">
                                                <tr>
                                                    <td>
                                                    <fieldset>
                                                        <legend><strong>Group By Options</strong></legend>
                                                        <table>
                                                            <tr>
                                                                <td align="left" >
                                                                    <asp:CheckBox id="CheckboxEmployee" runat="server" Text="Employee" AutoPostBack="true"/><br />
                                                                    <asp:CheckBox id="CheckboxEmployeeDate" runat="server" Text="Employee/Date" AutoPostBack="true"/>
                                                                </td>
                                                            </tr>
                                                        </table> 
                                                    </fieldset> 
                                                    </td>       
                                                </tr>
                                                <tr>
                                                    <td align="center" valign="top" colspan="2">
                                                        <telerik:RadGrid ID="RadGridServiceFeeEmp" runat="server" AllowPaging="True" AllowSorting="True"
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
                                                </asp:Panel>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
