<%@ Page Title="Chat Room Details" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Chat_RoomDetails.aspx.vb" Inherits="Webvantage.Chat_RoomDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <script type="text/javascript" src="Scripts/angular.min.js"></script>
    <script type="text/javascript" src="Scripts/angular-ui/ui-bootstrap-tpls.min.js"></script>
    <script type="text/javascript" src="Scripts/kendo/current/kendo.all.min.js"></script>
    <script type="text/javascript" src="app/js/app.js"></script>
    <script type="text/javascript" src="app/js/services.js"></script>
    <script type="text/javascript" src="app/js/controllers/standardLookup.js"></script>
    <script type="text/javascript" src="app/js/controllers/kendoGridLookupModal.js"></script>
    <script type="text/javascript" src="Scripts/jquery.signalR-2.4.2.min.js"></script>
    <script src="signalr/hubs"></script>
    <script type="text/javascript">
        function RadToolBarChatRoomActionsOnClientButtonClicking(sender, args) {
            var commandName = args.get_item().get_commandName();
            if (commandName == "DiscardDeleteRoom") {
                ////args.set_cancel(!confirm('Are you sure you want to delete this room?\n'));
                radToolBarConfirm(sender, args, "Are you sure you want to delete this room?");
            }
            else if (commandName == "SaveRoom") {
                var currentScope = angular.element($('#TextBoxClientCode')).scope();
                currentScope.validateLookUps();
                args.set_cancel(true);
            }
            else if (commandName == "ViewAllSavedChats") {
                OpenRadWindow('Saved Chat Rooms', 'Chat_List.aspx', 500, 750, false);
            }
        }
        function processLookupSelection(selectedItem) {
            var currentScope = angular.element($('#TextBoxClientCode')).scope();
            currentScope.processLookupSelection(selectedItem);
            currentScope.$apply();
        };
        function processAurLookupToAngular(args) {
            if (args) {
                console.log(args)
                var clientCodeTextBox = $('#TextBoxClientCode');
                var currentScope = angular.element(clientCodeTextBox).scope();
                if (currentScope) {
                    currentScope.suppressDefaultDivision = true;
                    currentScope.suppressDefaultProduct = true;
                    if (args.ClientCode) {
                        currentScope.clientCode = args.ClientCode;
                    }
                    if (args.ClientName) {
                        currentScope.clientName = args.ClientName;
                    }
                    if (args.DivisionCode) {
                        currentScope.divisionCode = args.DivisionCode;
                    }
                    if (args.DivisionName) {
                        currentScope.divisionName = args.DivisionName;
                    }
                    if (args.ProductCode) {
                        currentScope.productCode = args.ProductCode;
                    }
                    if (args.ProductDescription) {
                        currentScope.productDescription = args.ProductDescription;
                    }
                    if (args.JobNumber) {
                        currentScope.jobNumber = args.JobNumber;
                    }
                    if (args.JobDescription) {
                        currentScope.jobDescription = args.JobDescription;
                    }
                    if (args.JobComponentNumber) {
                        currentScope.jobComponentNumber = args.JobComponentNumber;
                    }
                    if (args.JobComponentDescription) {
                        currentScope.jobComponentDescription = args.JobComponentDescription;
                    }
                    currentScope.$apply();
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadToolBar ID="RadToolBarChatRoomActions" runat="server" Width="100%" OnClientButtonClicking="RadToolBarChatRoomActionsOnClientButtonClicking">
        <Items>
            <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Text="" Value="SaveRoom" CommandName="SaveRoom"></telerik:RadToolBarButton>
            <telerik:RadToolBarButton SkinID="RadToolBarButtonDelete" Text="" Value="DiscardDeleteRoom" CommandName="DiscardDeleteRoom"></telerik:RadToolBarButton>
            <telerik:RadToolBarButton Text="View Saved" Value="ViewAllSavedChats" CommandName="ViewAllSavedChats" ToolTip="View all your saved chat rooms/conversations."></telerik:RadToolBarButton>
        </Items>
    </telerik:RadToolBar>
    <div ng-app="webvantageApp">
        <h4>Room</h4>
        <div class="code-description-container">
            <div class="code-description-label">
                Name
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TextBoxRoomName" runat="server" SkinID="TextBoxCodeSingleLineDescription" ToolTip="The name of your room/conversation" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRoomName" runat="server" ErrorMessage="Room name is required" ControlToValidate="TextBoxRoomName"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label" style="vertical-align:top;">
                Description
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TextBoxRoomDescription" runat="server" SkinID="TextBoxCodeMultiLine" TextMode="MultiLine" ToolTip="A description for your room/conversation"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label" style="vertical-align: top;">
                Private
            </div>
            <div class="code-description-description">
                <asp:CheckBox ID="CheckBoxIsPrivate" runat="server" ToolTip="Only you and those participating in the conversation will see this room in the 'Available rooms' list." />
            </div>
        </div>
        <div ng-controller="standardLookupController">
            <h4>Associate with</h4>
            <div class="code-description-container" style="margin-top:4px;">
                <div class="code-description-label">
                    <asp:HyperLink ID="HyperLinkClientLabel" runat="server" Text="Client"></asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TextBoxClientCode" runat="server" SkinID="TextBoxCodeSmall" ng-model="clientCode" ng-dblclick="open('Client')" ng-blur="getNameOrDescription('Client');" ng-keyup="clearDescription('Client');" ClientIDMode="Static" MaxLength="6"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TextBoxClientName" runat="server" SkinID="TextBoxCodeSingleLineDescription" ReadOnly="true" ng-model="clientName" TabIndex="-1"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HyperLinkDivisionLabel" runat="server" Text="Division"></asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TextBoxDivisionCode" runat="server" SkinID="TextBoxCodeSmall" ng-model="divisionCode" ng-dblclick="open('Division')" ng-blur="getNameOrDescription('Division');" ng-keyup="clearDescription('Division');" ClientIDMode="Static" MaxLength="6"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TextBoxDivisionName" runat="server" SkinID="TextBoxCodeSingleLineDescription" ReadOnly="true" ng-model="divisionName" TabIndex="-1"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HyperLinkProductLabel" runat="server" Text="Product"></asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TextBoxProductCode" runat="server" SkinID="TextBoxCodeSmall" ng-model="productCode" ng-dblclick="open('Product')" ng-blur="getNameOrDescription('Product');" ng-keyup="clearDescription('Product');" ClientIDMode="Static" MaxLength="6"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TextBoxProductDescription" runat="server" SkinID="TextBoxCodeSingleLineDescription" ReadOnly="true" ng-model="productDescription" TabIndex="-1"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HyperLinkJobLabel" runat="server" Text="Job"></asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TextBoxJobNumber" runat="server" SkinID="TextBoxCodeSmall" ng-model="jobNumber" ng-dblclick="open('Job')" ng-blur="getNameOrDescription('Job');" ng-keyup="clearDescription('Job');" ClientIDMode="Static" MaxLength="6"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TextBoxJobDescription" runat="server" SkinID="TextBoxCodeSingleLineDescription" ReadOnly="true" ng-model="jobDescription" TabIndex="-1"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HyperLinkJobComponentLabel" runat="server" Text="Job Component"></asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TextBoxJobComponentNumber" runat="server" SkinID="TextBoxCodeSmall" ng-model="jobComponentNumber" ng-dblclick="open('JobComponent')" ng-blur="getJobComponentDescription()" ng-keyup="clearDescription('JobComponent');" ng-focus="getDefaultJobComponentNumber(true);" ClientIDMode="Static" MaxLength="3"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TextBoxJobComponentDescription" runat="server" SkinID="TextBoxCodeSingleLineDescription" ReadOnly="true" ng-model="jobComponentDescription" TabIndex="-1"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container" style="display: none !important;">
                <div class="code-description-label">
                    <asp:HyperLink ID="HyperLinkTask" runat="server" Text="Task Code"></asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TextBoxTaskCode" runat="server" SkinID="TextBoxCodeSmall" MaxLength="10"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TextBoxTaskDescription" runat="server" SkinID="TextBoxCodeSingleLineDescription" ReadOnly="true" TabIndex="-1"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container" style="display:none !important;">
                <div class="code-description-label">
                    <asp:HyperLink ID="HyperLinkAlertAssignmentLabel" runat="server" Text=""></asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TextBoxAlertAssignmentID" runat="server" SkinID="TextBoxCodeSmall"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TextBoxAlertAssignmentSubject" runat="server" SkinID="TextBoxCodeSingleLineDescription" TabIndex="-1"></asp:TextBox>
                </div>
            </div>
        </div>
        <div id="DivChatLog" runat="server" style="width: 99%;">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                <div>
                    <asp:CheckBox ID="CheckBoxHideSystemMessages" runat="server" Text="Hide system messages" AutoPostBack="true" Checked="true" />
                </div>
                <telerik:RadGrid ID="RadGridChatRoomLog" runat="server" AllowMultiRowSelection="True" AllowSorting="True" AutoGenerateColumns="False" GridLines="None" ShowGroupPanel="False" Width="100%">
                    <ClientSettings AllowColumnsReorder="False" AllowDragToGroup="False">
                        <Resizing AllowColumnResize="True" EnableRealTimeResize="True" />
                        <Selecting AllowRowSelect="False" />
                    </ClientSettings>
                    <ExportSettings IgnorePaging="true" OpenInNewWindow="true" ExportOnlyData="true" HideStructureColumns="true">
                        <Pdf PageHeight="210mm" PageWidth="297mm" DefaultFontFamily="Arial Unicode MS" PageBottomMargin="20mm"
                            PageTopMargin="20mm" PageLeftMargin="20mm" PageRightMargin="20mm" />
                    </ExportSettings>
                    <MasterTableView AllowMultiColumnSorting="true" CommandItemDisplay="None" DataKeyNames="ID" Width="100%">
                        <CommandItemSettings ShowAddNewRecordButton="false" ShowRefreshButton="false" RefreshText="Refresh" ShowExportToExcelButton="false" ShowExportToWordButton="false" ShowExportToPdfButton="false" />
                        <Columns>
                            <telerik:GridBoundColumn DataField="Message" HeaderText="Message" UniqueName="GridBoundColumnMessage">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="UserCode" HeaderText="By" UniqueName="GridBoundColumnUserCode">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-usercode-column" Width="80" />
                                <ItemStyle Width="80" CssClass="radgrid-usercode-column" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="MessageDate" HeaderText="On" UniqueName="GridBoundColumnMessageDate" DataFormatString="{0:G}">
                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="right" CssClass="radgrid-datetime-column" Width="180" />
                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="right" CssClass="radgrid-datetime-column" Width="180" />
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
