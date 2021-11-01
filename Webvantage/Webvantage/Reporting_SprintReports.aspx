<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_SprintReports.aspx.vb"
    Inherits="Webvantage.Reporting_SprintReports" Title="Resource Allocation By Week Report Templates"
    MasterPageFile="~/ChildPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" border="0" cellpadding="0" cellspacing="0" 
        width="100%">
        <tr>
            <td runat="server" id="TdRadToolBarDynamicReportTemplates" align="left" valign="top"
                colspan="2" class="no-float-menu">
                <telerik:RadToolBar ID="RadToolBarDynamicReportTemplates" runat="server" AutoPostBack="true"
                    Width="100%">
                    <Items>
                        <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonAdd" runat="server" Text="Add"
                            Value="Add" CommandName="Add" ToolTip="Add Dynamic Report" SkinID="RadToolBarButtonNew" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonSecondSeparator" runat="server"
                            IsSeparator="true" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
    </table>
    <div class="telerik-aqua-body">
        <table  align="center" border="0" cellpadding="0" cellspacing="0" 
        width="100%">
                <tr>
                    <td width="1%">&nbsp;
                    </td>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td width="1%">&nbsp;
                    </td>
                    <td colspan="2">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="100px">Report Category:
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="RadComboBoxReportCategory" runat="server" AutoPostBack="true"
                                        Width="50%" DataTextField="Description" DataValueField="ID">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="1%">&nbsp;
                    </td>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td width="1%">&nbsp;
                    </td>
                    <td>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                            <telerik:RadGrid ID="RadGridDynamicReportTemplates" runat="server" AllowPaging="True"
                                AllowSorting="True" GridLines="None" PageSize="10" EnableEmbeddedSkins="True"
                                ShowFooter="False" AutoGenerateColumns="False" Width="99%" Height="500px" AllowMultiRowSelection="false">
                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" ></PagerStyle>
                                <ClientSettings Scrolling-AllowScroll="true" Resizing-AllowColumnResize="false">
                                </ClientSettings>
                                <MasterTableView DataKeyNames="ID, DatasetTypeID">
                                    <Columns>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnView">
                                            <HeaderStyle CssClass="radgrid-icon-column" />
                                            <ItemStyle CssClass="radgrid-icon-column" />
                                            <FooterStyle CssClass="radgrid-icon-column" />
                                            <ItemTemplate>
                                                <div class="icon-background background-color-sidebar">
                                                    <asp:ImageButton ID="ImageButtonView" runat="server" SkinID="ImageButtonViewWhite"
                                                    ToolTip="Click to View Report" CommandName="ViewReport" />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnEdit">
                                            <HeaderStyle CssClass="radgrid-icon-column" />
                                            <ItemStyle CssClass="radgrid-icon-column" />
                                            <FooterStyle CssClass="radgrid-icon-column" />
                                            <ItemTemplate>
                                                <div class="icon-background background-color-sidebar">
                                                    <asp:ImageButton ID="ImageButtonEdit" runat="server" SkinID="ImageButtonEditWhite" ToolTip="Click to Edit Report" CommandName="EditReport" />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnReportCategory" HeaderText="Report Category"
                                            SortExpression="ReportCategory">
                                            <HeaderStyle Width="50px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Width="50px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                            <FooterStyle Width="50px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                            <ItemTemplate>
                                                <telerik:RadComboBox ID="DropDownListReportCategory" runat="server" AutoPostBack="false" InputCssClass="no-border"
                                                    DataTextField="Description" DataValueField="ID" DropDownAutoWidth="Enabled">
                                                </telerik:RadComboBox>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDescription" HeaderText="Description"
                                            SortExpression="Description">
                                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                            <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBoxDescription" runat="server" Text='<%#Eval("Description") %>' SkinID="TextBoxStandard"
                                                    MaxLength="50" Width="99%"></asp:TextBox>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnType" HeaderText="Type"
                                            SortExpression="Type">
                                            <HeaderStyle Width="100px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Width="100px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="True" />
                                            <FooterStyle Width="100px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                            <ItemTemplate>
                                                <%#Eval("DatasetType")%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTypeID" HeaderText="Type ID"
                                            SortExpression="TypeID" Visible="false">
                                            <HeaderStyle Width="100px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Width="100px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="True" />
                                            <FooterStyle Width="100px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                            <ItemTemplate>
                                                <%#Eval("DatasetTypeID")%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnCreatedBy" HeaderText="Created By"
                                            SortExpression="CreatedBy">
                                            <HeaderStyle Width="50px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Width="50px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="True" />
                                            <FooterStyle Width="50px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                            <ItemTemplate>
                                                <%#Eval("CreatedByUserCode")%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnCreatedDate" HeaderText="Created Date"
                                            SortExpression="CreatedDate">
                                            <HeaderStyle Width="75px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Width="75px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="True" />
                                            <FooterStyle Width="75px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                            <ItemTemplate>
                                                <%#FormatDateTime(Eval("CreatedDate"), DateFormat.ShortDate)%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnUpdatedBy" HeaderText="Updated By"
                                            SortExpression="UpdatedBy">
                                            <HeaderStyle Width="50px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Width="50px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="True" />
                                            <FooterStyle Width="50px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                            <ItemTemplate>
                                                <%#Eval("UpdatedByUserCode")%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnUpdatedDate" HeaderText="Updated Date"
                                            SortExpression="UpdatedDate">
                                            <HeaderStyle Width="75px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                            <ItemStyle Width="75px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="True" />
                                            <FooterStyle Width="75px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                            <ItemTemplate>
                                                <%#FormatDateTime(Eval("UpdatedDate"), DateFormat.ShortDate)%>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSave">
                                            <HeaderStyle CssClass="radgrid-icon-column" />
                                            <ItemStyle CssClass="radgrid-icon-column" />
                                            <FooterStyle CssClass="radgrid-icon-column" />
                                            <HeaderTemplate>
                                                    <asp:ImageButton ID="ImageButtonSaveAll" runat="server" SkinID="ImageButtonSaveAll"
                                                        ToolTip="Click to save all rows" CommandName="SaveAllReports" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div class="icon-background background-color-sidebar">
                                                    <asp:ImageButton ID="ImageButtonSave" runat="server" SkinID="ImageButtonSaveWhite"
                                                        ToolTip="Click to save this row" CommandName="SaveReport" />
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                    <asp:ImageButton ID="ImageButtonSaveAllRowsFooter" runat="server" SkinID="ImageButtonSaveAll"
                                                        ToolTip="Click to save all rows" CommandName="SaveAllReports" />
                                            </FooterTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete">
                                            <HeaderStyle CssClass="radgrid-icon-column" />
                                            <ItemStyle CssClass="radgrid-icon-column" />
                                            <FooterStyle CssClass="radgrid-icon-column" />
                                            <ItemTemplate>
                                                <div class="icon-background background-color-delete">
                                                <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite"
                                                    ToolTip="Click to delete this row" CommandName="DeleteReport" />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <RowIndicatorColumn>
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn>
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                </MasterTableView>
                                <ClientSettings EnableRowHoverStyle="true">
                                </ClientSettings>
                            </telerik:RadGrid>
                </ContentTemplate>
            </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td width="1%">&nbsp;
                    </td>
                    <td>
                        <br />
                    </td>
                </tr>
            </table>
            <br />
    </div>
    
</asp:Content>
