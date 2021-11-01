<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_DynamicReportTemplates.aspx.vb"
    Inherits="Webvantage.Reporting_DynamicReportTemplates" Title="Report Templates"
    MasterPageFile="~/ChildPage.Master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlockSub" runat="server">
        <script type="text/javascript">
            function JsOnClientButtonClicking(sender, args) {
                var CommandName = args.get_item().get_commandName();
                if (CommandName == "Delete") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                }
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" border="0" cellpadding="0" cellspacing="0" 
        width="100%">
        <tr>
            <td runat="server" id="TdRadToolBarDynamicReportTemplates" align="left" valign="top"
                colspan="2">
                <telerik:RadToolBar ID="RadToolBarDynamicReportTemplates" runat="server" AutoPostBack="true"
                    Width="100%" OnClientButtonClicking="JsOnClientButtonClicking">
                    <Items>
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorFirstSeparator" runat="server" IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonSelect" runat="server" Text="Select"
                            Value="Select" CommandName="Select" ToolTip="Select Report Template" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonDelete" runat="server" Text="Delete"
                            Value="Delete" CommandName="Delete" ToolTip="Delete Report Template" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorSecondSeparator" runat="server"
                            IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonCancel" runat="server" Text="Cancel"
                            Value="Cancel" CommandName="Cancel" ToolTip="Cancel" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonClose" runat="server" Text="Close"
                            Value="Close" CommandName="Close" ToolTip="Close" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorThirdSeparator" runat="server" IsSeparator="true" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td width="1%">
                &nbsp;
            </td>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td width="1%">
                &nbsp;
            </td>
            <td>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <telerik:RadGrid ID="RadGridDynamicReportTemplates" runat="server" AllowPaging="True"
                        AllowSorting="True" GridLines="None" PageSize="10" EnableEmbeddedSkins="True"
                        ShowFooter="False" AutoGenerateColumns="False" Width="99%" AllowMultiRowSelection="false">
                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" Height="20px">
                        </PagerStyle>
                        <ClientSettings Scrolling-AllowScroll="true" Resizing-AllowColumnResize="false">
                        </ClientSettings>
                        <MasterTableView DataKeyNames="ID">
                            <Columns>
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
                                    <ItemStyle Width="100px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                    <FooterStyle Width="100px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                    <ItemTemplate>
                                        <%# Eval("Type")%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnCreatedBy" HeaderText="Created By"
                                    SortExpression="CreatedBy">
                                    <HeaderStyle Width="50px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle Width="50px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                    <FooterStyle Width="50px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                    <ItemTemplate>
                                        <%# Eval("CreatedBy")%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnCreatedDate" HeaderText="Created Date"
                                    SortExpression="CreatedDate">
                                    <HeaderStyle Width="120px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle Width="120px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                    <FooterStyle Width="120px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                    <ItemTemplate>
                                        <%# Eval("CreatedDate")%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnUpdatedBy" HeaderText="Updated By"
                                    SortExpression="UpdatedBy">
                                    <HeaderStyle Width="50px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle Width="50px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                    <FooterStyle Width="50px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                    <ItemTemplate>
                                        <%# Eval("UpdatedBy")%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnUpdatedDate" HeaderText="Updated Date"
                                    SortExpression="UpdatedDate">
                                    <HeaderStyle Width="120px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle Width="120px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                    <FooterStyle Width="120px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                                    <ItemTemplate>
                                        <%# Eval("UpdatedDate")%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSave">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <HeaderTemplate>
                                            <asp:ImageButton ID="ImageButtonSaveAll" runat="server" SkinID="ImageButtonSaveAll"
                                                ToolTip="Click to save all rows" CommandName="SaveAll" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="icon-background background-color-sidebar">
                                            <asp:ImageButton ID="ImageButtonSave" runat="server" SkinID="ImageButtonSaveWhite"
                                                ToolTip="Click to save this row" CommandName="SaveRow" />
                                        </div>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="icon-background background-color-sidebar">
                                            <asp:ImageButton ID="ImageButtonSaveNew" runat="server" SkinID="ImageButtonNewWhite"
                                                ToolTip="Click to add this row" CommandName="SaveNewRow" />
                                        </div>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                            <asp:ImageButton ID="ImageButtonSaveAllFooter" runat="server" SkinID="ImageButtonSaveAll"
                                                ToolTip="Click to save all rows" CommandName="SaveAll" />
                                    </FooterTemplate>
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
                            <Selecting AllowRowSelect="true" />
                        </ClientSettings>
                    </telerik:RadGrid>
                </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td width="1%">
                &nbsp;
            </td>
            <td>
                <br />
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
