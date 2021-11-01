<%@ Control AutoEventWireup="false" CodeBehind="DesktopMyQvA.ascx.vb" EnableViewState="true"
    Inherits="Webvantage.DesktopMyQvA" Language="vb" %>

<telerik:RadScriptBlock ID="sbControl_ScriptBlock" runat="server">
    <script type="text/javascript">

        function RadGridMyQVAColumnPreferences(event) {

            var grid = $find("<%= RadGridQVA.ClientID %>");

            grid.get_masterTableView().get_columns()[0].showHeaderMenu(event, 10, 10);

        }

    </script>
</telerik:RadScriptBlock>
<div class="DO-ButtonHeader">
    <div style="float: left; width: 90%; text-align: left; vertical-align: middle">
        <asp:ImageButton ID="butPrint" runat="server" SkinID="ImageButtonPrint" />
        <asp:ImageButton ID="butExport" runat="server" SkinID="ImageButtonExportExcel" ToolTip="Export to Excel" />
        <asp:ImageButton ID="ImageButtonFilter" runat="server" SkinID="ImageButtonFilter" />
        <asp:ImageButton ID="ImageButtonBookmark" runat="server" ToolTip="Bookmarks" SkinID="ImageButtonBookmark"/>
    </div>
    <div style="float: right; width: 10%; text-align: right;">
        <asp:ImageButton ID="butRefresh" runat="server" SkinID="ImageButtonRefresh" ToolTip="Refresh" />
    </div>
</div>
<div class="DO-Container">
    <asp:Label ID="LblMSG" runat="server" CssClass="CssRequired" Visible="True" Text="&nbsp;"></asp:Label>
    <ew:CollapsablePanel ID="CollapsablePanelFilter" runat="server" SkinID="CollapsablePanelDesktopObjectFilter" Collapsed="true" Visible="false">
        <div style="font-size: larger; margin: -7px 0px 0px 0px !important;">
            Filter
        </div>
        <table width="480" border="0" cellpadding="0" cellspacing="2" id="TableFilterMyQvA">
            <tr>
                <td width="56" valign="middle">
                    <asp:Label ID="label3" runat="server" Text="Type:" />
                </td>
                <td width="171" valign="middle">
                    <telerik:RadComboBox ID="ddType" runat="server" AutoPostBack="true" EnableViewState="true" Width="180">
                        <Items>
                            <telerik:RadComboBoxItem Value="False" Text="All"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Value="True" Text="Time Only" ></telerik:RadComboBoxItem>
                        </Items>
                    </telerik:RadComboBox>
                </td>
                <td width="245" valign="middle">
                    <asp:Label ID="Label4" runat="server" Text="Threshold:" />
                    &nbsp;
                                <telerik:RadNumericTextBox ID="RadNumericTextBoxThreshold" runat="server" Value="100" MaxValue="100"
                                    Type="Number" MaxLength="3" MinValue="0" Width="35px">
                                    <NumberFormat DecimalDigits="0" GroupSeparator="" />
                                    <EnabledStyle HorizontalAlign="Right" />
                                </telerik:RadNumericTextBox>
                    %
                </td>
            </tr>
            <tr>
                <td valign="middle">
                    <asp:Label ID="Label5" runat="server" Text="Search:" />
                </td>
                <td valign="middle">
                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="imgbtnSearch" runat="server" SkinID="ImageButtonFind" ToolTip="Search" />
                </td>
                <td valign="middle">&nbsp;
                </td>
            </tr>
            <tr>
                <td valign="middle">
                    <asp:Label ID="labelcl" runat="server" Text="Client:" />
                </td>
                <td valign="middle">
                    <telerik:RadComboBox ID="ClientDropDownList" runat="server" AutoPostBack="True" width="220">
                    </telerik:RadComboBox>
                </td>
                <td valign="middle">
                    <asp:CheckBox ID="cbExcludeClientApproval" runat="server" Text="Exclude jobs without Client Approval"
                        AutoPostBack="true" />
                </td>
            </tr>
            <tr>
                <td valign="middle">
                    <asp:Label ID="Label1" runat="server" Text="Division:" />
                </td>
                <td valign="middle">
                    <telerik:RadComboBox ID="DivisionDropDownList" runat="server" AutoPostBack="true" width="220"
                        Enabled="false">
                    </telerik:RadComboBox>
                </td>
                <td valign="middle">
                    <asp:CheckBox ID="cbExcludeInternalApproval" runat="server" Text="Exclude jobs without Internal Approval"
                        AutoPostBack="true" />
                </td>
            </tr>
            <tr>
                <td valign="middle">
                    <asp:Label ID="Label2" runat="server" Text="Product:" />
                </td>
                <td valign="middle">
                    <telerik:RadComboBox ID="ProductDropDownList" runat="server" AutoPostBack="true" width="220"
                        Enabled="false">
                    </telerik:RadComboBox>
                </td>
                <td valign="middle">
                    <asp:CheckBox ID="cbAllProcessing" runat="server" Text="Include 'All Processing' jobs only"
                        AutoPostBack="true" />
                </td>
            </tr>
        </table>
    </ew:CollapsablePanel>
    <telerik:RadGrid ID="RadGridQVA" runat="server" AllowPaging="True" AllowSorting="True"
        EnableViewState="True" Width="100%" AutoGenerateColumns="False" GridLines="None"
        EnableEmbeddedSkins="True" EnableHeaderContextMenu="true">
        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
        <MasterTableView AllowMultiColumnSorting="true" DataKeyNames="JOB_NUMBER, JOB_COMPONENT_NBR">
            <Columns>
                <telerik:GridBoundColumn DataField="JOB_NUMBER" HeaderText="JOB_NUMBER" UniqueName="columnJOB_NUMBER">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40" />
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOB_COMPONENT_NBR" HeaderText="JOB_COMPONENT_NBR" UniqueName="columnJOB_COMPONENT_NBR">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40" />
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn UniqueName="colDetails" HeaderAbbr="FIXED">
                    <HeaderStyle CssClass="radgrid-icon-column" />
                    <ItemStyle CssClass="radgrid-icon-column" />
                    <FooterStyle CssClass="radgrid-icon-column" />
                    <HeaderTemplate>
                        <asp:ImageButton ID="ImageButtonColumnPreferences" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon"
                            ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" OnClientClick="RadGridMyQVAColumnPreferences(event);" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HiddenField ID="HfJobNumber" runat="server" Value='<%# Eval("JOB_NUMBER") %>' />
                        <asp:HiddenField ID="HfJobCompNumber" runat="server" Value='<%# Eval("JOB_COMPONENT_NBR") %>' />
                        <div class="icon-background background-color-sidebar">
                            <asp:ImageButton ID="ImageButtonViewDetails" runat="server" ImageAlign="AbsMiddle" CssClass="icon-image" CommandName="Detail"
                                SkinID="ImageButtonViewWhite" ToolTip="View QvA Summary" />
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="CDP" HeaderText="Client" UniqueName="column">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="110" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="110" />
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="110" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn DataField="JobAndComp" HeaderText="Project" UniqueName="column2"
                    SortExpression="JobAndComp" HeaderAbbr="FIXED">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:LinkButton ID="ViewLinkButton" runat="server" Visible="true" ToolTip='<%# Eval("JobAndComp") %>'></asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="FIRST_USE_DATE" HeaderText="Due Date" DataFormatString="{0:d}"
                    UniqueName="DueDate" Display="false">
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="QUOTED_HRS" HeaderText="Quote Qty/Hrs" UniqueName="QuoteHours"
                    DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="ACTUAL_HRS" HeaderText="Actual Qty/Hrs" UniqueName="ActualHours"
                    DataFormatString="{0:#,##0.00}">
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Quoted" HeaderText="Quote Total" DataFormatString="{0:#,##0.00}"
                    UniqueName="column3">
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Actual" HeaderText="Actual Total" DataFormatString="{0:#,##0.00}"
                    UniqueName="column4">
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PERCENT_QUOTED" HeaderText="% of Quote (Hours)"
                    DataFormatString="{0:#,##0.00}%" UniqueName="PercentOfQuoted">
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PERCENT_QUOTED_AMT" HeaderText="% of Quote (Amount)"
                    DataFormatString="{0:#,##0.00}%" UniqueName="PercentOfQuotedAmt">
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn UniqueName="Flag" HeaderAbbr="FIXED">
                    <HeaderStyle CssClass="radgrid-icon-column" />
                    <ItemStyle CssClass="radgrid-icon-column" />
                    <FooterStyle CssClass="radgrid-icon-column" />
                    <ItemTemplate>
                        <div class="icon-background background-color-sidebar" runat="server" id="DivFlagColor">
                            <asp:Image ID="ImageFlag" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/signal_flag.png" />
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
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
</div>
