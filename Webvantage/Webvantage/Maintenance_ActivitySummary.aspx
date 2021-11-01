<%@ Page Title="Activity Summary" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_ActivitySummary.aspx.vb" Inherits="Webvantage.Maintenance_ActivitySummary" %>

<asp:Content ID="conActivitySummaryContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolbarActivitySummary" runat="server" AutoPostBack="True" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonSave" SkinID="RadToolBarButtonSave" Text="" Value="Save"
                    ToolTip="Save" ValidationGroup="Save" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonCancel" SkinID="RadToolBarButtonCancel" Text="Cancel" Value="Cancel" ToolTip="Cancel" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonAddDiary" runat="server"
                        Text="Add Diary" Value="AddDiary" ToolTip="Add New Diary Entry" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSeparator7" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonAddActivity" runat="server"
                        Text="Add Activity" Value="AddActivity" ToolTip="Add New Activity" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSeparator8" runat="server" IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
        <div style="">
            <div style="display:inline-block;width:600px;">
                <div class="code-description-container">
                    <div class="code-description-label">
                        New Business:
                    </div>
                    <div class="code-description-description">
                        <asp:CheckBox ID="CheckBoxIsNewBusiness" runat="server" Text="" Enabled="false" Visible="false" />
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Lead Date:
                    </div>
                    <div class="code-description-description">
                        <telerik:RadDatePicker ID="RadDatePickerLeadDate" runat="server">
                        </telerik:RadDatePicker>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Source:
                    </div>
                    <div class="code-description-description">
                        <telerik:RadComboBox ID="RadComboBoxSource" runat="server" TabIndex="30" Width="275px" Enabled="true" SkinID="RadComboBoxStandard">
                        </telerik:RadComboBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Last Activity Date:
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TextBoxLastActivityDate" runat="server" Enabled="false" ReadOnly="true" SkinID="TextBoxStandard">
                        </asp:TextBox>
                    </div>
                </div>

                <div class="code-description-container">
                    <div class="code-description-label">
                        Last Contact Date:
                    </div>
                    <div class="code-description-description">
                        <telerik:RadDatePicker ID="RadDatePickerLastContactDate" runat="server" SkinID="RadDatePickerStandard">
                        </telerik:RadDatePicker>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Sold Date:
                    </div>
                    <div class="code-description-description">
                        <telerik:RadDatePicker ID="RadDatePickerSoldDate" runat="server" SkinID="RadDatePickerStandard">
                        </telerik:RadDatePicker>
                    </div>
                </div>

                <div class="code-description-container">
                    <div class="code-description-label">
                        Lost Date:
                    </div>
                    <div class="code-description-description">
                        <telerik:RadDatePicker ID="RadDatePickerLostDate" runat="server" SkinID="RadDatePickerStandard">
                        </telerik:RadDatePicker>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Probability:
                    </div>
                    <div class="code-description-description">
                        <telerik:RadNumericTextBox ID="RadNumericTextBoxProbability" runat="server" Type="Number" Style="text-align: right">
                            <NumberFormat GroupSeparator="" DecimalDigits="0" AllowRounding="true" KeepNotRoundedValue="false" />
                        </telerik:RadNumericTextBox>
                    </div>
                </div>

                <div class="code-description-container">
                    <div class="code-description-label">
                        Rating:
                    </div>
                    <div class="code-description-description">
                        <telerik:RadComboBox ID="RadComboBoxRating" runat="server" TabIndex="30" Width="275px" Enabled="true" SkinID="RadComboBoxStandard">
                        </telerik:RadComboBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Current Provider:
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TextBoxCurrentProvider" runat="server" SkinID="TextBoxStandard">
                        </asp:TextBox>
                    </div>
                </div>

                <div class="code-description-container" id="RowTotalOpportunity" runat="server">
                    <div class="code-description-label">
                        Total Opportunity:
                    </div>
                    <div class="code-description-description">
                        <telerik:RadNumericTextBox ID="RadNumericTextBoxTotalOpportunity" runat="server" ReadOnly="True">
                            <NumberFormat GroupSeparator="" DecimalDigits="2" />
                        </telerik:RadNumericTextBox>
                    </div>
                </div>

            </div>
            <div style="display: inline-block;vertical-align:top;">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <telerik:RadGrid ID="RadGridCompetitors" runat="server" AllowPaging="True"
                        AllowSorting="True" GridLines="None" PageSize="3" EnableEmbeddedSkins="True"
                        ShowFooter="False" AutoGenerateColumns="False" Width="375px">
                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom"></PagerStyle>
                        <MasterTableView CommandItemDisplay="None" EditMode="InPlace" DataKeyNames="ID"
                            InsertItemDisplay="Top">
                            <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnCompetitor" HeaderText="Competitor"
                                    SortExpression="Competitor.Name" AllowFiltering="false">
                                    <HeaderStyle Width="300" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemStyle Width="300" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <FooterStyle Width="300" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="RadComboBoxCompetitor" runat="server" AutoPostBack="false" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                            DataTextField="Description" DataValueField="ID" Width="275">
                                        </telerik:RadComboBox>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <telerik:RadComboBox ID="RadComboBoxCompetitorEdit" runat="server" InputCssClass="no-border" SkinID="RadComboBoxStandard"
                                            AutoPostBack="false" DataTextField="Description" DataValueField="ID" Width="275">
                                        </telerik:RadComboBox>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSave" AllowFiltering="false">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <EditItemTemplate>
                                        <div class="icon-background background-color-sidebar">
                                            <asp:ImageButton ID="ImageButtonSaveNew" runat="server" SkinID="ImageButtonNewWhite"
                                                ToolTip="Click to add this row" CommandName="SaveNewRow" />
                                        </div>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnCancel" AllowFiltering="false">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <ItemTemplate>
                                        <div class="icon-background background-color-delete">
                                            <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite" ToolTip="Click to delete this row"
                                                CommandName="DeleteRow" />
                                        </div>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <div class="icon-background background-color-sidebar">
                                            <asp:ImageButton ID="ImageButtonCancel" runat="server" SkinID="ImageButtonCancelWhite"
                                                ToolTip="Cancel add row" CommandName="CancelAddRow" />
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
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </div>
        <div>
            <asp:TextBox ID="TextBoxActivityID" runat="server" Visible="False" SkinID="TextBoxStandard"></asp:TextBox>
        </div>
        <div style="margin:10px 0px 0px 0px;">
            <telerik:RadGrid ID="RadGridActivitySummary" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                GridLines="None" EnableEmbeddedSkins="True" Width="99%" PageSize="10" AllowSorting="true">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom"></PagerStyle>
                <MasterTableView DataKeyNames="AlertID">
                    <Columns>
                        <telerik:GridTemplateColumn AllowFiltering="false">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImageButtonEdit" runat="server" CommandName="EditDiary" SkinID="ImageButtonEditWhite" ToolTip="Edit Diary" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="ActivityDate" HeaderText="Activity Date" UniqueName="ActivityDate" ReadOnly="true">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EmployeeName" HeaderText="Employee Name" UniqueName="EmployeeName" ReadOnly="true">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20%" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ActivityType" HeaderText="Activity Type" UniqueName="ActivityType" ReadOnly="true">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="AllDay" HeaderText="All Day" UniqueName="AllDay" ReadOnly="true">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="10%" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Subject" HeaderText="Subject" UniqueName="Subject" ReadOnly="true">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="25%" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="25%" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="25%" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Body" HeaderText="Body" UniqueName="Body" ReadOnly="true">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="25%" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="25%" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="25%" />
                        </telerik:GridBoundColumn>
                    </Columns>
                    <RowIndicatorColumn Visible="False">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Resizable="False" Visible="False">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <EditFormSettings>
                        <PopUpSettings ScrollBars="None" />
                    </EditFormSettings>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
        <div class="code-description-container">
            <asp:Button ID="ButtonAddDiary" runat="server" Text="Add Diary" Visible="false" />
            <asp:Button ID="ButtonAddActivity" runat="server" Text="Add Activity" Visible="false" />
        </div>
    </div>
    <script>
        function Refresh() {
            __doPostBack('onclick#Refresh', 'Refresh');
        }
    </script>
   
</asp:Content>
