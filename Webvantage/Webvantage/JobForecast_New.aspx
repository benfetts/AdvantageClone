<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="JobForecast_New.aspx.vb"
    Inherits="Webvantage.JobForecast_New" MasterPageFile="~/ChildPage.Master"
    Title="Add New Job Forecast" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlockHead" runat="server">
        <script type="text/javascript">
            function RadToolBarOnClientButtonClicking(sender, args) {
                if (args.get_item().get_value() === 'SelectForecast') {
                    if ($find('<%= RadGridJobForecasts.ClientID %>').get_selectedItems().length === 0) {
                        args.set_cancel(true);
                        ShowMessage('Please select a revision.');
                    }
                }
            }
            function OnResponseEnd() {
                try {
                    var winTitle = $('#<% = HiddenFieldWindowTitle.ClientID %>').val();
                    if (!winTitle) {
                        winTitle = document.title;
                    }
                    GetRadWindow().set_title(winTitle);
                } catch (err) {

                }
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <telerik:RadToolBar ID="RadToolBarJobForecast" runat="server" AutoPostBack="true"
            Width="100%" OnClientButtonClicking="RadToolBarOnClientButtonClicking">
            <Items>
                <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSave" runat="server" SkinID="RadToolBarButtonSave"
                    Text="" Value="Save" ToolTip="Save new Job Forecast" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSelectForecast" runat="server"
                    Text="Select Forecast" Value="SelectForecast" ToolTip="Select Forecast" />
                <telerik:RadToolBarButton ID="RadToolBarButtonBackSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonBack" runat="server" Text="Previous" Value="Previous" ToolTip="Go to Previous Screen" Visible="false" />
                <telerik:RadToolBarButton ID="RadToolBarButtonThirdSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonCancel" runat="server" SkinID="RadToolBarButtonCancel"
                    Text="Cancel" Value="Cancel" ToolTip="Back to Job Forecast" />
                <telerik:RadToolBarButton ID="RadToolBarButtonFourthSeparator" runat="server" IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
        <div style="margin-top: 10px;">
            <telerik:RadMultiPage ID="RadMultiPageForecast" runat="server" SelectedIndex="0" RenderSelectedPageOnly="false">
                <telerik:RadPageView ID="RadPageViewForecastOptions" runat="server">
                    <div>
                        <div style="margin: 20px auto; text-align:center;">
                            <div style="margin: 10px;">
                                <asp:Button ID="ButtonNewForecast" runat="server" Text="Create New Forecast" Width="300" OnClick="ForecastOptionsButtonClickHandler" />
                            </div>
                            <div style="margin: 10px;">
                                <asp:Button ID="ButtonAddToExisting" runat="server" Text="Add Job Component to Exisiting Forecast" Width="300" OnClick="ForecastOptionsButtonClickHandler" />
                            </div>
                            <div style="margin: 10px;">
                                <asp:Button ID="ButtonCopyForecast" runat="server" Text="Copy Exisiting Forecast" Width="300" OnClick="ForecastOptionsButtonClickHandler" />
                            </div>
                        </div>
                    </div>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewSelectForecast" runat="server" >
                    <div>
                        <div class="more-info" ID="SearchDiv" runat="server">
                            <div style="display: inline-block; margin-bottom: 5px;">
                            <asp:label ID="LabelMonthYear" runat="server" AssociatedControlID="RadMonthYearPicker" Text="Include Forecasts as of:" />
                                <telerik:RadMonthYearPicker ID="RadMonthYearPicker" runat="server" AutoPostBack="true"></telerik:RadMonthYearPicker>
                            </div>
                            &nbsp;&nbsp;&nbsp;
                            <div style="display: inline-block; margin-bottom: 5px;">
                            <telerik:RadComboBox ID="DropDownListAssignedTo" runat="server" AutoPostBack="true"
                                Width="150" DataTextField="Name" DataValueField="Code" Label="Assigned To:" SkinID="RadComboBoxEmployee">
                            </telerik:RadComboBox>
                            </div>
                            <div style="display: inline-block; margin-bottom: 5px;">
                                <asp:CheckBox ID="CheckBoxHighestRevisionOnly" runat="server" Text="Show only Approved or Current Revision" AutoPostBack="true" />
                            </div>
                        </div>
                        <telerik:RadGrid ID="RadGridJobForecasts" runat="server" AllowPaging="True"
                            AllowSorting="true" GridLines="None" PageSize="10" EnableEmbeddedSkins="True"
                            ShowFooter="false" AutoGenerateColumns="false" Width="100%" PagerStyle-Visible="True">
                            <ClientSettings>
                                <Selecting AllowRowSelect="true" />
                            </ClientSettings>
                            <MasterTableView DataKeyNames="JobForecastID, JobForecastRevisionID, AssignedToEmployeeCode">
                                <PagerStyle AlwaysVisible="true" Mode="NextPrevAndNumeric" />
                                <Columns>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnID" HeaderText="ID" Visible="False" DataField="JobForecastID">
                                        <HeaderStyle Width="10" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnDescription" HeaderText="Description" DataField="Description" SortExpression="Description">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnPostPeriodStartDate" HeaderText="Start" DataField="PostPeriodStartDate" DataType="System.DateTime" DataFormatString="{0:MMMM / yyyy}">
                                        <ItemStyle Wrap="false" Width="25" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnPostPeriodStartDate" HeaderText="End" DataField="PostPeriodEndDate" DataType="System.DateTime" DataFormatString="{0:MMMM / yyyy}">
                                        <ItemStyle Wrap="false" Width="25" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnRevisionNumber" HeaderText="Revision" DataField="RevisionNumber">
                                        <HeaderStyle Width="25" VerticalAlign="Middle" HorizontalAlign="Right" />
                                        <ItemStyle Width="25" VerticalAlign="Middle" HorizontalAlign="Right" />
                                        <FooterStyle Width="25" VerticalAlign="Middle" HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnAssignedToEmployeeCode" HeaderText="Assigned to Employee Code" DataField="AssignedToEmployeeCode" Visible="false">
                                        <HeaderStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnAssignedToEmployeeName" HeaderText="Assigned To" DataField="AssignedToEmployeeName">
                                        <HeaderStyle Width="110" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemStyle Width="110" Wrap="false" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle Width="110" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobForecastIsApproved"
                                        HeaderText="Approved" SortExpression="IsApproved">
                                        <HeaderStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle Width="30" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <div id="DivIsApproved" runat="server" class="icon-background standard-green" style='<%# If(Eval("IsApproved") = True, "display:inline-block;", "display:none;") %>'>
                                                <asp:Image ID="ImageIsApproved" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
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
                        </telerik:RadGrid>
                    </div>
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewNew" runat="server">
                    <div>
                        <div class="form-layout label-l">
                            <ul>
                                <li>Description:</li>
                                <li><telerik:RadTextBox ID="RadTextBoxDescription" runat="server" MaxLength="40" SkinID="RadTextBoxCodeSingleLineDescription"  ></telerik:RadTextBox></li>
                            </ul>
                            <ul>
                                <li>Post Period Start:</li>
                                <li><telerik:RadComboBox ID="DropDownListPostPeriodStart" runat="server" AutoPostBack="true" DataTextField="MonthAndYear" DataValueField="Code" SkinID="RadComboBoxPostPeriod">
                                    </telerik:RadComboBox></li>
                            </ul>
                            <ul>
                                <li>Post Period End:</li>
                                <li><telerik:RadComboBox ID="DropDownListPostPeriodEnd" runat="server" AutoPostBack="false" DataTextField="MonthAndYear" DataValueField="Code" SkinID="RadComboBoxPostPeriod">
                                    </telerik:RadComboBox></li>
                            </ul>
                            <ul>
                                <li>Budget:</li>
                                <li><telerik:RadNumericTextBox ID="RadNumericTextBoxBudget" runat="server" AutoPostBack="false" NumberFormat-DecimalDigits="2" EnabledStyle-HorizontalAlign="Right" MaxValue="9999999999999.99" NumberFormat-KeepTrailingZerosOnFocus="true"></telerik:RadNumericTextBox></li>
                            </ul>
                            <ul>
                                <li>Office:</li>
                                <li><telerik:RadComboBox ID="DropDownListOffice" runat="server" AutoPostBack="false" DataTextField="Name" DataValueField="Code" SkinID="RadComboBoxText40">
                                    </telerik:RadComboBox></li>
                            </ul>
                            <ul>
                                <li>Assigned To:</li>
                                <li><telerik:RadComboBox ID="DropDownListEmployee" runat="server" AutoPostBack="false" DataTextField="Name" DataValueField="Code" SkinID="RadComboBoxText40">
                                    </telerik:RadComboBox></li>
                            </ul>
                            <ul>
                                <li>Comments:</li>
                                <li><telerik:RadTextBox ID="RadTextBoxComment" runat="server" TextMode="MultiLine" Resize="Vertical" SkinID="RadTextBoxCodeMultiLine"></telerik:RadTextBox></li>
                            </ul>
                        </div>  
                    </div>
                </telerik:RadPageView>
            </telerik:RadMultiPage>            
        </div>
        <asp:HiddenField ID="HiddenFieldWindowTitle" runat="server" Value="" />
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
