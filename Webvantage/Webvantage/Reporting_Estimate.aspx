<%@ Page Title="Estimate Report" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Reporting_Estimate.aspx.vb" Inherits="Webvantage.Reporting_Estimate" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentEstimates" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">    
    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%" class="telerik-aqua-body">
        <%--<tr>
            <td width="1%">
                &nbsp;
            </td>
            <td runat="server" id="TdJobDetailAnalysis" align="left" valign="top" colspan="2">
                <telerik:RadToolBar ID="RadToolBarJobDetailAnalysis" runat="server" AutoPostBack="true"
                    Width="100%">
                    <Items>
                        <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonView" runat="server" SkinID="RadToolBarButtonPrint"
                            Text="View" Value="View" ToolTip="View Report" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonThirdSeparator" runat="server" IsSeparator="true" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>--%>
        <tr>
            <td width="1%">&nbsp;
            </td>
            <td >
                <table width="99%" border="0" cellspacing="2" cellpadding="0">
                    <tr>
                        <td runat="server" id="tdFrom" width="10%">From:
                        </td>
                        <td width="20%">
                            <telerik:RadDatePicker ID="RadDatePickerFrom" runat="server" AutoPostBack="true" SkinID="RadDatePickerStandard">
                            </telerik:RadDatePicker>
                        </td>
                        <td width="20%">
                            <telerik:RadButton ID="RadButtonYTD" runat="server" AutoPostBack="true" ButtonType="StandardButton"
                                Text="YTD">
                            </telerik:RadButton>
                        </td>
                        <td width="20%">
                            <telerik:RadButton ID="RadButton1Year" runat="server" AutoPostBack="true" ButtonType="StandardButton"
                                Text="1 Year">
                            </telerik:RadButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr runat="server" id="trTo">
            <td width="1%">&nbsp;
            </td>
            <td>
                <table width="99%" border="0" cellspacing="2" cellpadding="0">
                    <tr>
                        <td width="10%">To:
                        </td>
                        <td width="20%">
                            <telerik:RadDatePicker ID="RadDatePickerTo" runat="server" AutoPostBack="true" DatePopupButton-Visible="true">
                            </telerik:RadDatePicker>
                        </td>
                        <td width="20%">
                            <telerik:RadButton ID="RadButtonMTD" runat="server" AutoPostBack="true" ButtonType="StandardButton"
                                Text="MTD">
                            </telerik:RadButton>
                        </td>
                        <td width="20%">
                            <telerik:RadButton ID="RadButton2Years" runat="server" AutoPostBack="true" ButtonType="StandardButton"
                                Text="2 Year">
                            </telerik:RadButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>        
    </table>
    <telerik:RadGrid ID="RadGridEstimates" runat="server" AllowPaging="True" AllowSorting="True"
            GridLines="None" PageSize="10" EnableEmbeddedSkins="True" ShowFooter="False"
            AutoGenerateColumns="false" Width="99%" AllowMultiRowSelection="false" Height="500px">
            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" ></PagerStyle>
            <ClientSettings Scrolling-AllowScroll="true" Resizing-AllowColumnResize="false">
            </ClientSettings>
            <MasterTableView DataKeyNames="EstimateNumber,EstimateComponentNumber,QuoteNumber">
                <Columns>
                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnViewReport" AllowFiltering="false">
                        <HeaderStyle CssClass="radgrid-icon-column" />
                        <ItemStyle CssClass="radgrid-icon-column" />
                        <FooterStyle CssClass="radgrid-icon-column" />
                        <ItemTemplate>
                            <div class="icon-background background-color-sidebar">
                            <asp:ImageButton ID="ImageButtonViewReport" runat="server" CommandName="ViewReport"
                                ToolTip="View Report" SkinID="ImageButtonViewWhite" />
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnJobNumber" DataField="JobNumber" HeaderText="Job Number"
                        ReadOnly="true"  SortExpression="JobNumber">
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnJobDescription" DataField="JobDesc"
                        HeaderText="Job Desc" ReadOnly="true" SortExpression="JobDesc">
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnJobComponentNumber" DataField="JobComponentNumber"
                        HeaderText="Job Comp Number" ReadOnly="true" Visible="true" SortExpression="JobComponentNumber">
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnJobCompDesc" DataField="JobCompDesc"
                        HeaderText="Job Comp Desc" ReadOnly="true"  SortExpression="JobCompDesc">
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnEstimate" DataField="Estimate"
                        HeaderText="Estimate" ReadOnly="true" Visible="true" SortExpression="Estimate">
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnEstDesc" DataField="EstDesc"
                        HeaderText="Est Desc" ReadOnly="true" Visible="true" SortExpression="EstDesc">
                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                    </telerik:GridBoundColumn>
                </Columns>
                <RowIndicatorColumn>
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
                <ExpandCollapseColumn>
                    <HeaderStyle Width="20px" />
                </ExpandCollapseColumn>
            </MasterTableView>
        </telerik:RadGrid>
</asp:Content>
