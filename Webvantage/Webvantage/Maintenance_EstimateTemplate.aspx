<%@ Page Title="Estimate Template Maintenance" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_EstimateTemplate.aspx.vb" Inherits="Webvantage.Maintenance_EstimateTemplate" %>

<asp:Content ID="ContentEstimateTemplate" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function RadGridEstimateTemplates_RowDoubleClick(sender, eventArgs) {
                __doPostBack("<%= RadGridEstimateTemplates.UniqueID %>", "IndexOfRowDoubleClicked:" + eventArgs.get_itemIndexHierarchical());
            }
        </script>
    </telerik:RadScriptBlock>
    <div class="telerik-aqua-body">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="75%">
                        <telerik:RadTabStrip ID="RadTabStripEstimateTemplates" runat="server" MultiPageID="RadMultiPageEstimateTemplates"
                            AutoPostBack="true" SelectedIndex="0" Width="500">
                            <Tabs>
                                <telerik:RadTab Text="Estimate Templates">
                                </telerik:RadTab>
                                <telerik:RadTab Text="Estimate Template Detail">
                                </telerik:RadTab>
                            </Tabs>
                        </telerik:RadTabStrip>
                    </td>
                    <td align="right" valign="middle">
                        <asp:CheckBox ID="CheckBoxShowInactive" runat="server" Text="Show Inactive" AutoPostBack="True" />
                        <asp:ImageButton ID="ImageButtonExport" runat="server" SkinID="ImageButtonExportExcel" />&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
            <telerik:RadMultiPage ID="RadMultiPageEstimateTemplates" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="RadPageViewEstimateTemplates" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                        <br />
                        <telerik:RadGrid ID="RadGridEstimateTemplates" runat="server" AllowPaging="True"
                            AllowSorting="True" GridLines="None" PageSize="10"
                            ShowFooter="False" AutoGenerateColumns="False" Width="780">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px"></PagerStyle>
                            <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="Code, Description, IsInactive"
                                InsertItemDisplay="Top">
                                <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTemplateCode" HeaderText="Code"
                                        SortExpression="Code">
                                        <HeaderStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <%# Eval("Code")%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxTemplateCodeEdit" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTemplateDescription" HeaderText="Description"
                                        SortExpression="Description">
                                        <HeaderStyle Width="300" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemStyle Width="300" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle Width="300" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBoxTemplateDescription" runat="server" Text='<%#Eval("Description") %>'
                                                MaxLength="30" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxTemplateDescriptionEdit" runat="server" MaxLength="30" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDefaultComment" HeaderText="Default Estimate Comment"
                                        SortExpression="DefaultComment">
                                        <HeaderStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBoxDefaultComment" runat="server" Text='<%#Eval("DefaultComment")%>' SkinID="TextBoxStandard"
                                                Width="200" TextMode="MultiLine"></asp:TextBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBoxDefaultCommentEdit" runat="server" Width="200" TextMode="MultiLine" SkinID="TextBoxStandard"></asp:TextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnIsInactive" HeaderText="Inactive"
                                        SortExpression="IsInactive">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBoxIsInactive" runat="server" Checked='<%#Eval("IsInactive") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="CheckBoxIsInactiveEdit" runat="server" Checked="false"></asp:CheckBox>
                                        </EditItemTemplate>
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
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-delete">
                                            <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite"
                                                ToolTip="Click to delete this row" CommandName="DeleteRow" />
                                            </div>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImageButtonCancel" runat="server" SkinID="ImageButtonCancelWhite"
                                                    ToolTip="Cancel add row" CommandName="CancelNewRow" />
                                            </div>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <RowIndicatorColumn>
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                            </MasterTableView>
                            <ClientSettings>
                                <ClientEvents OnRowDblClick="RadGridEstimateTemplates_RowDoubleClick" />
                            </ClientSettings>
                        </telerik:RadGrid>
                        <br />
                </ContentTemplate>
            </asp:UpdatePanel>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewEstimateTemplateDetail" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                        <div class="code-description-container">
                            <div class="code-description-label" style="width: 270px;">
                                Estimate Template:
                            </div>
                            <div class="code-description-description">
                                <telerik:RadComboBox ID="DropDownListEstimateTemplates" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard"
                                    Width="200" DataTextField="Code" DataValueField="Code">
                                </telerik:RadComboBox>
                            </div>
                        </div>

                        <div class="code-description-container">
                            <div class="code-description-label" style="width: 270px;">
                                Description:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxEstimateTemplateDescription" runat="server" MaxLength="30"
                                    SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                            </div>
                        </div>

                        <div class="code-description-container">
                            <div class="code-description-label" style="width: 270px;">
                                Copy Details From Template:
                            </div>
                            <div class="code-description-description">
                                <telerik:RadComboBox ID="DropDownListCopyEstimateTemplateDetails" runat="server" SkinID="RadComboBoxStandard"
                                    AutoPostBack="false" Width="200" DataTextField="Code" DataValueField="Code">
                                </telerik:RadComboBox>
                                &nbsp;
                                    <asp:ImageButton ID="ImageButtonCopyEstimateTemplateDetails" runat="server" SkinID="ImageButtonCopy" ToolTip="Copy Details From Template" />
                            </div>
                        </div>

                        <div class="code-description-container">
                            <div class="code-description-label" style="width: 270px;">
                            </div>
                            <div class="code-description-description">
                                <asp:CheckBox ID="CheckBoxIsInactive" runat="server" Text="Inactive" AutoPostBack="True" />
                            </div>
                        </div>


                        <br />
                        <telerik:RadGrid ID="RadGridEstimateTemplateDetails" runat="server" AllowPaging="True"
                            AllowSorting="True" GridLines="None" PageSize="10"
                            ShowFooter="True" AutoGenerateColumns="False" Width="780">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" Height="20px"></PagerStyle>
                            <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="ID" InsertItemDisplay="Top">
                                <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTemplateDetailID" HeaderText="ID"
                                        Visible="false">
                                        <HeaderStyle Width="10" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%# Eval("ID")%>
                                        </ItemTemplate>
                                        <InsertItemTemplate>

                                        </InsertItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTemplateDetailFunction"
                                        HeaderText="Function" SortExpression="Description">
                                        <HeaderStyle Width="225" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle Width="225" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle Width="225" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <telerik:RadComboBox ID="DropDownListTemplateDetailFunction" runat="server" AutoPostBack="true" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                DataTextField="Description" DataValueField="Code" Width="250" OnSelectedIndexChanged="DropDownListTemplateDetailFunctionSelectionChanged">
                                            </telerik:RadComboBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadComboBox ID="DropDownListTemplateDetailFunctionEdit" runat="server" AutoPostBack="true" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                DataTextField="Description" DataValueField="Code" Width="250" OnSelectedIndexChanged="DropDownListTemplateDetailFunctionSelectionChanged">
                                            </telerik:RadComboBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTemplateDetailSuppliedByVendor"
                                        HeaderText="Supplied By" SortExpression="SuppliedBy">
                                        <HeaderStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <telerik:RadComboBox ID="DropDownListTemplateDetailSuppliedByVendor" runat="server" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                AutoPostBack="false" DataTextField="Name" DataValueField="Code" Width="225">
                                            </telerik:RadComboBox>
                                            <telerik:RadComboBox ID="DropDownListTemplateDetailSuppliedByEmployee" runat="server" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                AutoPostBack="false" DataTextField="Name" DataValueField="Code" Width="225">
                                            </telerik:RadComboBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadComboBox ID="DropDownListTemplateDetailSuppliedByVendorEdit" runat="server" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                AutoPostBack="false" DataTextField="Name" DataValueField="Code" Width="225" Visible="false">
                                            </telerik:RadComboBox>
                                            <telerik:RadComboBox ID="DropDownListTemplateDetailSuppliedByEmployeeEdit" runat="server" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                                AutoPostBack="false" DataTextField="Name" DataValueField="Code" Width="225" Visible="false">
                                            </telerik:RadComboBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnTemplateDetailHours" HeaderText="Qty/Hours"
                                        SortExpression="Hours" FooterAggregateFormatString="{0}" Aggregate="Sum" DataField="Hours" >
                                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <telerik:RadNumericTextBox ID="TextBoxTemplateDetailHours" runat="server" Text='<%#Eval("Hours") %>'
                                                Type="Number" Width="80" AutoPostBack="false" MaxLength="10" MaxValue="999999.99"
                                                MinValue="0.00">
                                                <NumberFormat DecimalDigits="2" GroupSeparator="" KeepTrailingZerosOnFocus="true" />
                                                <EnabledStyle HorizontalAlign="Right" />
                                            </telerik:RadNumericTextBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadNumericTextBox ID="TextBoxTemplateDetailHoursEdit" runat="server" Type="Number"
                                                Width="80" MaxLength="10" MaxValue="999999.99" MinValue="0.00">
                                                <NumberFormat DecimalDigits="2" GroupSeparator="" KeepTrailingZerosOnFocus="true" />
                                                <EnabledStyle HorizontalAlign="Right" />
                                            </telerik:RadNumericTextBox>
                                        </EditItemTemplate>
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
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-delete">
                                                <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite"
                                                    ToolTip="Click to delete this row" CommandName="DeleteRow" />
                                            </div>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <div class="icon-background background-color-delete">
                                                <asp:ImageButton ID="ImageButtonCancel" runat="server" SkinID="ImageButtonCancelWhite"
                                                    ToolTip="Cancel add row" CommandName="CancelNewRow" />
                                            </div>
                                        </EditItemTemplate>
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
                        <br />
                </ContentTemplate>
            </asp:UpdatePanel>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
            <telerik:RadWindowManager ID="RadWindowManager" runat="server">
            </telerik:RadWindowManager>
    </div>
    
</asp:Content>
