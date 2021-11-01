<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="jobspecs.aspx.vb" Inherits="Webvantage.jobspecs"
    MasterPageFile="~/ChildPage.Master" Title="Specifications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script type="text/javascript">
        function contentCall() {
            ShowMessage("hello from jobspecs!");
        };
        function checkLength(field, len) {
            if (field.value.length > len) {
                // too long...trim it!
                field.value = field.value.substring(0, len);
            };
        };
        function stopRKey(evt) {
            var evt = (evt) ? evt : ((event) ? event : null);
            var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
            if ((evt.keyCode == 13) && (node.type != "textarea")) {
                return false;
            };
        };
        function RowClick(index) {
            return false;
        };
        document.onkeypress = stopRKey;
    </script>

    <link rel="stylesheet" href="Content/kendo/current/kendo.common.min.css" />
    <link rel="stylesheet" href="Content/kendo/current/kendo.bootstrap.min.css" />
    <%--
        This is messing up button and textbox heights...
        <link href="Content/bootstrap.css" rel="stylesheet" />
    --%>
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <script type="text/javascript" src="Scripts/angular.min.js"></script>
    <script type="text/javascript" src="Scripts/angular-ui/ui-bootstrap-tpls.min.js"></script>
    <script type="text/javascript" src="Scripts/kendo/current/kendo.all.min.js"></script>
    <script type="text/javascript" src="app/js/app.js"></script>
    <script type="text/javascript" src="app/js/services.js"></script>
    <script type="text/javascript" src="app/js/controllers/jobJacket.js"></script>
    <script type="text/javascript" src="app/js/controllers/jobJacketModal.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#jobJacketGeneratedFormContainer a.JobTemplatePopupLink").click(function (e) {
                var currentLink = e.toElement;
                var currentTextArea = $(currentLink).closest('tr').find('textarea')
                var currentScope = angular.element(currentLink).scope();
                currentScope.open($(currentLink).text(), currentTextArea);
                e.preventDefault();
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Panel ID="PnlContainer" runat="server">
        <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
            <script type="text/javascript">
                function JsOnClientButtonClicking(sender, args) {
                    var comandName = args.get_item().get_value();
                    if (comandName == "DelRow") {
                        ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                        radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                    }
                    if (comandName == "ClearAll") {
                        ////args.set_cancel(!confirm('Are you sure you want to clear all assignments?'));
                        radToolBarConfirm(sender, args, "Are you sure you want to clear all assignments?");
                    }
                }
                function confirmRows() {
                    ShowMessage("No rows were selected for deletion.");
                }
            </script>
        </telerik:RadScriptBlock>
        <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
            <telerik:RadToolBar ID="RadToolBarJobSpecs" runat="server" AutoPostBack="true" OnClientButtonClicking="JsOnClientButtonClicking"
                Width="100%">
                <Items>
                    <telerik:RadToolBarButton IsSeparator="True" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Text="" Value="Save"
                        ToolTip="Save this Job Spec" CausesValidation="true" />
                    <telerik:RadToolBarButton IsSeparator="True" />
                    <telerik:RadToolBarButton Text="New Version" Value="NewVer"
                        ToolTip="New Version" />
                    <telerik:RadToolBarButton IsSeparator="True" />
                    <telerik:RadToolBarButton Text="Copy Version" Value="CopyVer"
                        ToolTip="Copy Version" />
                    <telerik:RadToolBarButton IsSeparator="True" />
                    <telerik:RadToolBarButton Text="Copy Revision" Value="CopyRev"
                        ToolTip="Copy Revision" />
                    <telerik:RadToolBarButton IsSeparator="True" />
                    <telerik:RadToolBarButton Text="Add Row" Value="AddRow"
                        ToolTip="Add Row" />
                    <telerik:RadToolBarButton IsSeparator="True" />
                    <telerik:RadToolBarButton Text="Delete Row" Value="DelRow"
                        ToolTip="Delete Row" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarDropDown Text="Print/Send">
                        <Buttons>
                            <telerik:RadToolBarButton Text="Print" Value="Print" ToolTip="Print" />
                            <telerik:RadToolBarButton Text="Send Alert" Value="SendAlert" ToolTip="Send Alert" />
                            <telerik:RadToolBarButton Text="Send Assignment" Value="SendAssignment" ToolTip="Send Assignment" />
                            <telerik:RadToolBarButton Text="Send Email" Value="SendEmail" ToolTip="Send Email" />
                            <telerik:RadToolBarButton Text="Options" Value="PrintSendOptions" ToolTip="Print/Send Options" />
                        </Buttons>
                    </telerik:RadToolBarDropDown>
                    <telerik:RadToolBarButton IsSeparator="true" Value="PrintSendSeparator" />
                    <telerik:RadToolBarButton Value="startSpell" Text=" " Visible="false" Enabled="false"
                        ToolTip="Spell Check" />
                    <telerik:RadToolBarButton IsSeparator="True" Visible="false" />
                    <telerik:RadToolBarButton Text="Approve" Value="Approve"
                        ToolTip="Approve" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonPrint"
                        Text="Print/Send" Value="PrintSendOptions" ToolTip="Print/Send" />
                    <telerik:RadToolBarButton IsSeparator="True" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh"
                        ToolTip="Refresh" />
                    <telerik:RadToolBarButton IsSeparator="True" />
                </Items>
            </telerik:RadToolBar>
        </div>
        <div class="telerik-aqua-body">
             <div class="code-description-container">
                        <div class="code-description-label">
                            Template:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="LabelTemplate" runat="server" Text=""></asp:Label>
                        </div>
                    </div>

                    <div class="code-description-container">
                        <div class="code-description-label">
                            Version:
                        </div>
                        <div class="code-description-description">
                            <telerik:RadComboBox ID="ddVersion" runat="server" AutoPostBack="True" TabIndex="-1" SkinID="RadComboBoxText5">
                            </telerik:RadComboBox>
                            <asp:Button ID="ButtonDeleteVersion" runat="server" Text="Delete Version" CommandName="Delete Version" />
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Revision:
                        </div>
                        <div class="code-description-description">
                            <telerik:RadComboBox ID="ddRevision" runat="server" AutoPostBack="True" TabIndex="-1" SkinID="RadComboBoxText5">
                            </telerik:RadComboBox>
                            <asp:Button ID="ButtonDeleteRevision" runat="server" Text="Delete Revision" CommandName="Delete Revision" />
                            &nbsp;&nbsp;<asp:LinkButton ID="hlApproved" runat="server" Font-Underline="true"
                                ForeColor="red" TabIndex="-1">
                            </asp:LinkButton>
                            <asp:Label ID="lblApproved" runat="server" ForeColor="red" TabIndex="-1"></asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Description:
                        </div>
                        <div class="code-description-description">
                            <asp:TextBox ID="txtDesc" runat="server" Width="413" MaxLength="60" TabIndex="1" SkinID="TextBoxStandard">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Reason:
                        </div>
                        <div class="code-description-description">
                            <asp:TextBox ID="txtReason" runat="server" BackColor="LightGray" Width="413" MaxLength="254" SkinID="TextBoxStandard"
                                ReadOnly="true" TextMode="MultiLine">
                            </asp:TextBox>
                        </div>
                    </div>
                    <asp:Panel ID="pnlPlaceHolder" runat="server" Width="100%">
                        <div ng-app="webvantageApp">
                            <div id="jobJacketGeneratedFormContainer" ng-controller="jobJacketController">
                                <br />
                                <asp:PlaceHolder ID="PlaceHolderMain" runat="server"></asp:PlaceHolder>
                            </div>
                        </div>
                    </asp:Panel>
                    <ew:CollapsablePanel ID="CollapsablePanelQty" runat="server"
                        TitleText="Quantity" Visible="false">
                        <telerik:RadToolBar ID="RadToolBarQty" runat="server" AutoPostBack="true" OnClientButtonClicking="JsOnClientButtonClicking"
                            Width="100%">
                            <Items>
                                <telerik:RadToolBarButton IsSeparator="True" />
                                <telerik:RadToolBarButton Text="Add Row" Value="AddRow"
                                    ToolTip="Add Row" />
                                <telerik:RadToolBarButton IsSeparator="True" />
                                <telerik:RadToolBarButton Text="Delete Row" Value="DelRow"
                                    ToolTip="Delete Row" />
                                <telerik:RadToolBarButton IsSeparator="True" />
                            </Items>
                        </telerik:RadToolBar>
                        <telerik:RadGrid ID="RadGridQuantity" runat="server" AllowMultiRowSelection="true"
                            HorizontalAlign="Center" AutoGenerateColumns="False" GridLines="None"
                            AllowSorting="true" EnableAJAX="false"
                            MasterTableView-ShowFooter="true" EnableEmbeddedSkins="True">
                            <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                            <ClientSettings AllowColumnHide="True" AllowExpandCollapse="True">
                                <Scrolling AllowScroll="false" SaveScrollPosition="true" UseStaticHeaders="False" />
                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
                            </ClientSettings>
                            <MasterTableView DataKeyNames="EstimateNumber,CompNum,QuoteNum,RevNum,SeqNum" TableLayout="auto">
                                <Columns>
                                    <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="10px" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10px" />
                                    </telerik:GridClientSelectColumn>
                                    <telerik:GridTemplateColumn DataField="Quantity" HeaderText="Quantity" UniqueName="colQuantity">
                                        <HeaderStyle HorizontalAlign="left" VerticalAlign="bottom" />
                                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle"  />
                                        <FooterStyle HorizontalAlign="left" VerticalAlign="middle"  />
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtQuantity" runat="server" Text='<%# Eval("Quantity") %>' SkinID="TextBoxCodeSmall"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="EstimateNumber" HeaderText="Estimate Number" SortExpression="EstimateNumber"
                                        UniqueName="EstimateNumber">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CompNum" HeaderText="Comp Num" SortExpression="CompNum"
                                        UniqueName="CompNum">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="QuoteNum" HeaderText="Quote Num" SortExpression="QuoteNum"
                                        UniqueName="QuoteNum">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="RevNum" HeaderText="Rev Num" SortExpression="RevNum"
                                        UniqueName="RevNum">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="SeqNum" HeaderText="" SortExpression="SeqNum"
                                        UniqueName="SeqNum" Visible="false">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <ExpandCollapseColumn Resizable="False" Visible="False">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <RowIndicatorColumn Visible="False">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <AlternatingItemStyle BackColor="#E9E9E9"></AlternatingItemStyle>
                                <FooterStyle Font-Names="Times New Roman" />
                            </MasterTableView>
                        </telerik:RadGrid>
                    </ew:CollapsablePanel>
                    <ew:CollapsablePanel ID="CollapsablePanelVendor" runat="server" TitleText="Vendor" Width="100%" Visible="false">
                        <telerik:RadToolBar ID="RadToolBarVendor" runat="server" AutoPostBack="true" OnClientButtonClicking="JsOnClientButtonClicking"
                            Width="100%">
                            <Items>
                                <telerik:RadToolBarButton IsSeparator="True" />
                                <telerik:RadToolBarButton Text="Add Row" Value="AddRow"
                                    ToolTip="Add Row" />
                                <telerik:RadToolBarButton IsSeparator="True" />
                                <telerik:RadToolBarButton Text="Delete Row" Value="DelRow"
                                    ToolTip="Delete Row" />
                                <telerik:RadToolBarButton IsSeparator="True" />
                            </Items>
                        </telerik:RadToolBar>
                        <telerik:RadGrid ID="RadGridVendor" runat="server" AllowMultiRowEdit="False" AllowMultiRowSelection="True"
                            AllowSorting="true" EnableEmbeddedSkins="True" AutoGenerateColumns="False" AllowPaging="false"
                            EnableAJAX="true" GridLines="None" Width="100%">
                            <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                            <ClientSettings AllowColumnHide="True">
                                <Scrolling UseStaticHeaders="False" />
                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
                                <ClientEvents OnRowClick="RowClick" />
                            </ClientSettings>
                            <MasterTableView DataKeyNames="SPEC_ID" TableLayout="auto">
                                <Columns>
                                    <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="10px" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10px" />
                                    </telerik:GridClientSelectColumn>
                                    <telerik:GridTemplateColumn UniqueName="colDetails">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <HeaderTemplate>
                                            &nbsp;
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="imgbtnEdit" runat="server" AlternateText="Edit Row" CommandArgument='<%#Eval("SPEC_ID")%>'
                                                    CommandName="EditRow" SkinID="ImageButtonViewWhite" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Vendor" HeaderText="Vendor" UniqueName="colVendor">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtVendor" runat="server" Text='<%# Eval("Vendor") %>' SkinID="TextBoxCodeSmall"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Publication_Name" HeaderText="Publication Name" UniqueName="colPublication_Name">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtPublication_Name" runat="server" Text='<%# Eval("Publication_Name") %>' Width="200px" SkinID="TextBoxStandard"
                                                ReadOnly="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Close Date" UniqueName="colClose_Date">
                                        <ItemTemplate>
                                            <telerik:RadDatePicker ID="RadDatePickerClose_Date" runat="server"
                                                SkinID="RadDatePickerStandard">
                                                <DateInput DateFormat="d" EmptyMessage="">
                                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                </DateInput>
                                            </telerik:RadDatePicker>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Run Date" UniqueName="colRun_Date">
                                        <ItemTemplate>
                                            <telerik:RadDatePicker ID="RadDatePickerRun_Date" runat="server"
                                                SkinID="RadDatePickerStandard">
                                                <DateInput DateFormat="d" EmptyMessage="">
                                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                </DateInput>
                                            </telerik:RadDatePicker>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Ext Date" UniqueName="colExt_Date">
                                        <ItemTemplate>
                                            <telerik:RadDatePicker ID="RadDatePickerExt_Date" runat="server"
                                                SkinID="RadDatePickerStandard">
                                                <DateInput DateFormat="d" EmptyMessage="">
                                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                </DateInput>
                                            </telerik:RadDatePicker>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="AdSize" HeaderText="Ad Size"
                                        UniqueName="colAdSize">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtAdSize" runat="server" MaxLength="6" Text='<%#Eval("AdSize") %>'
                                                SkinID="TextBoxCodeSmall"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="" HeaderText="" UniqueName="colAdSize_Lookup">
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Size_Desc" HeaderText="Size Desc"
                                        UniqueName="colSize_Desc">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtSize_Desc" runat="server" MaxLength="6" Text='<%#Eval("Size_Desc") %>'
                                                SkinID="TextBoxCodeSmall" ReadOnly="true"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Bleed_Size" HeaderText="Bleed Size"
                                        UniqueName="colBleed_Size">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtBleed_Size" runat="server" MaxLength="40" Text='<%#Eval("Bleed_Size") %>'
                                                SkinID="TextBoxCodeSmall"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Trim_Size" HeaderText="Trim Size"
                                        UniqueName="colTrim_Size">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtTrim_Size" runat="server" MaxLength="40" Text='<%#Eval("Trim_Size") %>'
                                                SkinID="TextBoxCodeSmall"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Live_Area" HeaderText="Live Area"
                                        UniqueName="colLive_Area">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtLive_Area" runat="server" MaxLength="40" Text='<%#Eval("Live_Area") %>'
                                                SkinID="TextBoxCodeSmall"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Screen" HeaderText="Screen"
                                        UniqueName="colScreen">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtScreen" runat="server" MaxLength="20" Text='<%# Eval("Screen") %>' SkinID="TextBoxCodeSmall"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Color" HeaderText="Color"
                                        UniqueName="colColor">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtColor" runat="server" MaxLength="20" Text='<%# Eval("Color") %>' SkinID="TextBoxCodeSmall"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Status" HeaderText="Status"
                                        UniqueName="colStatus">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtStatus" runat="server" Text='<%# Eval("Status") %>' Width="90px"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="" HeaderText="" UniqueName="colStatus_Lookup">
                                        <HeaderStyle HorizontalAlign="left" VerticalAlign="bottom" />
                                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                        <FooterStyle HorizontalAlign="left" VerticalAlign="middle" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImgBtnStatus" runat="server" SkinID="ImageButtonFindWhite"
                                                    AlternateText="Lookup Status" ToolTip="Lookup Status" CommandName="Status" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Region" HeaderText="Region"
                                        UniqueName="colRegion">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtRegion" runat="server" Text='<%# Eval("Region") %>' Width="90px"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="" HeaderText="" UniqueName="colRegion_Lookup">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImgBtnRegion" runat="server" SkinID="ImageButtonFindWhite"
                                                    AlternateText="Lookup Region" ToolTip="Lookup Region" CommandName="Region" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Density" HeaderText="Density"
                                        UniqueName="colDensity">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtDensity" runat="server" MaxLength="25" Text='<%# Eval("Density") %>' SkinID="TextBoxCodeSmall"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Film" HeaderText="Film"
                                        UniqueName="colFilm">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtFilm" runat="server" MaxLength="25" Text='<%# Eval("Film") %>' SkinID="TextBoxCodeSmall"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Shipping Comments" UniqueName="colShipping_Comments">
                                        <HeaderStyle CssClass="radgrid-textarea-column" />
                                        <ItemStyle CssClass="radgrid-textarea-column" />
                                        <FooterStyle CssClass="radgrid-textarea-column" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtShipping_Comments" runat="server" Text='<%#Eval("Shipping_Comments")%>' SkinID="TextBoxStandard"
                                                TextMode="multiLine" CssClass="radgrid-textarea"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Special Instructions" UniqueName="colSpecial_Instructions">
                                        <HeaderStyle CssClass="radgrid-textarea-column" />
                                        <ItemStyle CssClass="radgrid-textarea-column" />
                                        <FooterStyle CssClass="radgrid-textarea-column" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtSpecial_Instructions" runat="server" Text='<%#Eval("Special_Instructions")%>' SkinID="TextBoxStandard"
                                                TextMode="multiLine" CssClass="radgrid-textarea"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <ExpandCollapseColumn Resizable="False" Visible="False">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <RowIndicatorColumn Visible="False">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <AlternatingItemStyle BackColor="#E9E9E9"></AlternatingItemStyle>
                                <FooterStyle Font-Names="Times New Roman" />
                            </MasterTableView>
                        </telerik:RadGrid>
                        <div style="display:none !important">
                            <telerik:RadCalendar ID="RadCalendarShared" runat="server" RangeMinDate="1900-01-01">
                            </telerik:RadCalendar>
                        </div>
                    </ew:CollapsablePanel>
                    <ew:CollapsablePanel ID="CollapsablePanelVendor2" runat="server"
                        TitleText="Vendor" Visible="false">
                        <telerik:RadToolBar ID="RadToolBarVendor2" runat="server" AutoPostBack="true" OnClientButtonClicking="JsOnClientButtonClicking"
                            Width="100%">
                            <Items>
                                <telerik:RadToolBarButton IsSeparator="True" />
                                <telerik:RadToolBarButton Text="Add Row" Value="AddRow"
                                    ToolTip="Add Row" />
                                <telerik:RadToolBarButton IsSeparator="True" />
                                <telerik:RadToolBarButton Text="Delete Row" Value="DelRow"
                                    ToolTip="Delete Row" />
                                <telerik:RadToolBarButton IsSeparator="True" />
                            </Items>
                        </telerik:RadToolBar>
                        <telerik:RadGrid ID="RadGridVendor2" runat="server" AllowMultiRowSelection="true"
                            HorizontalAlign="Center" AutoGenerateColumns="False" GridLines="None"
                            AllowSorting="true" EnableAJAX="false"
                            MasterTableView-ShowFooter="true" EnableEmbeddedSkins="True">
                            <FilterMenu>
                                <CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
                            </FilterMenu>
                            <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                            <ClientSettings AllowColumnHide="True" AllowExpandCollapse="True">
                                <Scrolling AllowScroll="false" SaveScrollPosition="true" UseStaticHeaders="False" />
                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
                                <ClientEvents OnRowSelecting="CancelNonInputSelect" OnRowDeselecting="CancelNonInputSelect" />
                            </ClientSettings>
                            <HeaderContextMenu>
                                <CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation>
                            </HeaderContextMenu>
                            <MasterTableView DataKeyNames="SPEC_ID" TableLayout="auto">
                                <Columns>
                                    <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="10px" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10px" />
                                    </telerik:GridClientSelectColumn>
                                    <telerik:GridTemplateColumn UniqueName="colDetails">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <HeaderTemplate>
                                            &nbsp;
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="imgbtnEdit" runat="server" AlternateText="Edit Row" CommandArgument='<%#Eval("SPEC_ID")%>'
                                                    CommandName="EditRow" SkinID="ImageButtonViewWhite" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Vendor" HeaderText="Vendor" UniqueName="colVendor"
                                        Display="False">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtVendor" runat="server" Text='<%# Eval("Vendor") %>' Width="70px" SkinID="TextBoxStandard"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="AdSize" HeaderText="Ad Size"
                                        UniqueName="colAdSize">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtAdSize" runat="server" MaxLength="6" Text='<%#Eval("AdSize") %>' SkinID="TextBoxStandard"
                                                Width="70px"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="" HeaderText="" UniqueName="colAdSize_Lookup">
                                        <HeaderStyle HorizontalAlign="left" VerticalAlign="bottom" />
                                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                        <FooterStyle HorizontalAlign="left" VerticalAlign="middle" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImgBtnAdSize" runat="server" SkinID="ImageButtonFindWhite"
                                                    AlternateText="Lookup Ad Size" ToolTip="Lookup Ad Size" CommandName="AdSize" CommandArgument='<%#Eval("Vendor") %>' />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Size_Desc" HeaderText="Size Desc"
                                        UniqueName="colSize_Desc">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtSize_Desc" runat="server" Text='<%#Eval("Size_Desc") %>' SkinID="TextBoxStandard"
                                                ReadOnly="True" Width="200px"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Outdoor_Company" HeaderText="Outdoor Company"
                                        UniqueName="colOutdoor_Company">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtOutdoor_Company" runat="server" Text='<%#Eval("Outdoor_Company") %>' SkinID="TextBoxStandard"
                                                ReadOnly="True" Width="250px"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Location_of_Sign" HeaderText="Location of Sign"
                                        UniqueName="colLocation_of_Sign">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtLocation_of_Sign" runat="server" Text='<%#Eval("Location_of_Sign") %>' SkinID="TextBoxStandard"
                                                Width="250px" MaxLength="40"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Overall_Size" HeaderText="Overall Size"
                                        UniqueName="colOverall_Size">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtOverall_Size" runat="server" Text='<%#Eval("Overall_Size") %>' SkinID="TextBoxStandard"
                                                Width="250px" MaxLength="40"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="Copy_Area" HeaderText="Copy Area"
                                        UniqueName="colCopy_Area">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtCopy_Area" runat="server" Text='<%# Eval("Copy_Area") %>' Width="250px" MaxLength="40" SkinID="TextBoxStandard"></asp:TextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <ExpandCollapseColumn Resizable="False" Visible="False">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <RowIndicatorColumn Visible="False">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <AlternatingItemStyle BackColor="#E9E9E9"></AlternatingItemStyle>
                                <FooterStyle Font-Names="Times New Roman" />
                            </MasterTableView>
                        </telerik:RadGrid>
                    </ew:CollapsablePanel>
                    <div class="centered">
                        <asp:Button ID="btnSave" runat="server" Width="115" Text="Save" Visible="false" CausesValidation="false" />&nbsp;
                        <asp:Button ID="btnPrint" runat="server" Width="115" Text="Print" Visible="false" />
                    </div>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
                BorderWidth="1px" CellPadding="2" GridLines="None" Visible="true">
                <FooterStyle BackColor="Tan" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <HeaderStyle BackColor="Tan" />
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
            </asp:GridView>
            <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <FooterStyle BackColor="#507CD1" ForeColor="White" />
                <SelectedRowStyle BackColor="#D1DDF1" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <EditRowStyle BackColor="#2461BF" />
            </asp:GridView>
            <asp:GridView ID="GridView3" runat="server" BackColor="Green" BorderColor="#336666"
                BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#336666" ForeColor="White" />
                <RowStyle BackColor="White" ForeColor="#333333" />
            </asp:GridView>
            <asp:Label ID="LblDebug" runat="server" Text="" Visible="false"></asp:Label>
            <asp:Label ID="InjectScriptLabel" runat="server"></asp:Label>
        </div>
    </asp:Panel>
   
</asp:Content>
