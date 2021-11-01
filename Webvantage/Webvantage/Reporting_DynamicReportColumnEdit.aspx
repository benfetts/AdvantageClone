<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_DynamicReportColumnEdit.aspx.vb" MasterPageFile="~/ChildPage.Master" 
    Inherits="Webvantage.Reporting_DynamicReportColumnEdit" Title="Edit Report Columns" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlockRadWindow" runat="server">
        <script type="text/javascript">
            function returnValue() {
                //Get a reference to the parent (MDI) page 
                var oWnd = GetRadWindow();
                //get a reference to the second RadWindow
                var CallingWindowName = 'Create';
                var CallingWindow = oWnd.get_windowManager().getWindowByName(CallingWindowName);
                // Get a reference to the first RadWindow's content
                var CallingWindowContent = CallingWindow.get_contentFrame().contentWindow;
                //Call the predefined function in Dialog1
                //alert(CallingWindowName + '\n' + CallingWindow + '\n');
                CallingWindowContent.ReloadColumns(oWnd);
                //Close the second RadWindow
                oWnd.close();
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" border="0" cellpadding="0" cellspacing="0" 
        width="100%">
        <tr>
            <td runat="server" id="TdRadToolBarDynamicReportColumnEdit" align="left" valign="top"
                colspan="2">
                <telerik:RadToolBar ID="RadToolBarDynamicReportColumnEdit" runat="server" AutoPostBack="true"
                    Width="100%">
                    <Items>
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorFirstSeparator" runat="server" IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonOK" runat="server"
                            Text="OK" Value="OK" CommandName="OK" ToolTip="OK" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorSecondSeparator" runat="server"
                            IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonCancel" runat="server" SkinID="RadToolBarButtonCancel"
                            Text="" Value="Cancel" CommandName="Cancel" ToolTip="Cancel" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorThirdSeparator" runat="server" IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonReset" runat="server" Text="Reset"
                            Value="Reset" CommandName="Reset" ToolTip="Reset" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorFourthSeparator" runat="server"
                            IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonSelectAll" runat="server" Text="Select All"
                            Value="SelectAll" CommandName="SelectAll" ToolTip="Select All" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorFifthSeparator" runat="server" IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonDeselectAll" runat="server" Text="Deselect All"
                            Value="DeselectAll" CommandName="DeselectAll" ToolTip="Deselect All" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorSixthSeparator" runat="server" IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonShowOnlyVisibleColumns" runat="server"
                            Text="Show Only Visible Columns" Value="ShowOnlyVisibleColumns" CommandName="ShowOnlyVisibleColumns"
                            ToolTip="Show Only Visible Columns" CheckOnClick="true" AllowSelfUnCheck="true" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorSeventhSeparator" runat="server"
                            IsSeparator="true" />
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
                    <telerik:RadGrid ID="RadGridDynamicReportColumns" runat="server" AllowPaging="True"
                        AllowSorting="True" GridLines="None" PageSize="10" EnableEmbeddedSkins="True"
                        ShowFooter="False" AutoGenerateColumns="False" Width="99%">
                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" Height="20px">
                        </PagerStyle>
                        <MasterTableView DataKeyNames="FieldName">
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnIsVisible" HeaderText="Is Visible"
                                    SortExpression="IsVisible">
                                    <HeaderStyle Width="15%" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemStyle Width="15%" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <FooterStyle Width="15%" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBoxIsVisible" runat="server" Checked='<%#Eval("IsVisible") %>'
                                            AutoPostBack="true"  OnCheckedChanged="CheckBoxIsVisible_CheckedChanged"/>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnHeaderText" HeaderText="Header Text"
                                    SortExpression="HeaderText">
                                    <HeaderStyle Width="85%" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemStyle Width="85%" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <FooterStyle Width="85%" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBoxHeaderText" runat="server" CssClass="NoBorderTextBox" Text='<%#Eval("HeaderText") %>' SkinID="TextBoxStandard"
                                            MaxLength="50" AutoPostBack="true" OnTextChanged="TextBoxHeaderText_TextChanged" Width="100%"></asp:TextBox>
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
                    </telerik:RadGrid>
                </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
