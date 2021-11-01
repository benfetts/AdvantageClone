<%@ Page AutoEventWireup="false" CodeBehind="BillingApproval_Approval.aspx.vb" Inherits="Webvantage.BillingApproval_Approval"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Billing Approval View" %>

<asp:Content ID="ContentBABatch" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <!-- RadToolTip Script -->
        <script type="text/javascript">
            function DisplayDetails() {
                var divDetails = document.getElementById('divDetails');
                divDetails.style.display = "inline";
            };

            function CloseActiveToolTip() {
                setTimeout(function () {
                    var controller = Telerik.Web.UI.RadToolTipController.getInstance();
                    var tooltip = controller.get_activeToolTip();
                    if (tooltip) tooltip.hide();
                }, 1000);
            };
        </script>
    </telerik:RadScriptBlock>
    <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" Animation="None" RenderMode="Classic"
        Height="100px" ManualClose="false" Modal="false" OnAjaxUpdate="OnAjaxUpdate"
        Position="BottomRight" RelativeTo="Element" ShowEvent="OnMouseOver" Sticky="true"
        Width="550px">
    </telerik:RadToolTipManager>
    <telerik:RadToolTipManager ID="RadToolTipManager2" runat="server" Animation="None" RenderMode="Classic"
        Height="75px" ManualClose="true" Modal="true" OnAjaxUpdate="OnAjaxUpdate2" Position="MiddleLeft"
        RelativeTo="Element" ShowEvent="OnMouseOver" Sticky="true" Width="560px">
    </telerik:RadToolTipManager>
    <telerik:RadScriptBlock ID="RadScriptBlock3" runat="server">
        <script type="text/javascript">
            function JsOnClientButtonClicking(sender, args) {
                var commandName = args.get_item().get_commandName();
                if (commandName == "Delete") {
                    ////args.set_cancel(!confirm("Are you sure you want to delete?"));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                };
                if (commandName == "CreateApprovals") {
                    ////args.set_cancel(!confirm("This will automatically create Approvals for any Client(s) on the Batch that do not have an existing Approval.\nContinue?\n\n"));
                    radToolBarConfirm(sender, args, "This will automatically create Approvals for any Client(s) on the Batch that do not have an existing Approval.\nContinue?\n\n");
                };
                if (commandName == "Approve_Warn") {
                    ////args.set_cancel(!confirm("Approval has unapproved jobs.\nApprove anyway?\n\n"));
                    radToolBarConfirm(sender, args, "Approval has unapproved jobs.\nApprove anyway?\n\n");
                }
                if (commandName == "Approve_Disallow") {
                    ShowMessage("Please approve all jobs first.");
                    args.set_cancel(true);
                    return false;
                }
            };
        </script>
    </telerik:RadScriptBlock>
    <div class="no-float-menu">
        <asp:HiddenField ID="HiddenFieldHasUnapprovedJobs" runat="server" Value="0" />
        <telerik:RadToolBar ID="RadToolbarBillingApproval" runat="server" AutoPostBack="true" OnClientButtonClicking="JsOnClientButtonClicking" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonNew" Text="New" Value="New" ToolTip="New Approval" />
                <telerik:RadToolBarButton Visible="true" Text="Create Approvals"
                    CommandName="CreateApprovals" Value="CreateApprovals" 
                    ToolTip="Automatically create Approvals for this Batch's missing Clients" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Approved" Value="Finish" CommandName="Finish" CheckOnClick="true" AllowSelfUnCheck="true" Checked="false" ToolTip="Mark batch as Approved" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Alert" Value="Alert" ToolTip="Send notifications" />
                <telerik:RadToolBarButton Value="Refresh" CommandName="Refresh" SkinID="RadToolBarButtonRefresh"></telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton>
                    <ItemTemplate>
                        &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Current Status:&nbsp;"></asp:Label>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Value="RadToolBarButtonLblCurrentStatus">
                    <ItemTemplate>
                        <asp:Label ID="LblCurrentStatus" runat="server" Text="&nbsp;"></asp:Label>&nbsp;&nbsp;
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton>
                    <ItemTemplate>
                        &nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" Text="Alert Status:&nbsp;"></asp:Label>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Value="RadToolBarButtonLblAlertStatus">
                    <ItemTemplate>
                        <asp:Label ID="LblAlertStatus" runat="server" Text="&nbsp;"></asp:Label>&nbsp;&nbsp;
                    </ItemTemplate>
                </telerik:RadToolBarButton>
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
        <ew:CollapsablePanel ID="CollapsablePanelHeader" runat="server" TitleText="Batch Information">
                <asp:Label ID="LblMSG" runat="server" CssClass="warning" Text=""></asp:Label>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:Label ID="LblBatchIDTitle" runat="server" Text="Batch ID:"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <asp:Label ID="LblBatchID" runat="server" Text="[New]"></asp:Label>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Batch Description:
                    </div>
                    <div class="code-description-description">
                        <asp:Label ID="LblBatchDescription" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Batch Date:
                    </div>
                    <div class="code-description-code">
                        <asp:Label ID="LblBatchDate" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="code-description-description">
                        <asp:Label ID="LblJobList" runat="server" Text="Job List" Visible="true" CssClass="underline" style="cursor:pointer;"></asp:Label>
                    </div>
                </div>
            </ew:CollapsablePanel>
            <ew:CollapsablePanel ID="CollapsablePanelSelectionCriteria" runat="server" TitleText="Approvals">
                <telerik:RadGrid ID="RadGridApprovalsList" runat="server" AllowPaging="False" AllowSorting="True"
                    AutoGenerateColumns="False" EnableEmbeddedSkins="True" EnableAJAX="False" EnableAJAXLoadingTemplate="False"
                    Visible="True">
                    <MasterTableView NoMasterRecordsText="No records found" DataKeyNames="BA_ID">
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="View" UniqueName="ColVIEW">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImgBtnViewApproval" runat="server" AlternateText="View approval record"
                                        CommandArgument='<%#Eval("BA_ID")%>' CommandName="ViewApproval" ImageAlign="AbsMiddle"
                                        SkinID="ImageButtonViewWhite" ToolTip="View approval record" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="BA_ID" DataFormatString="{0:000000}" HeaderText="BA ID"
                                UniqueName="ColBA_ID">
                                <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="40px" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="40px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CLIENT_CODE_NAME" HeaderText="Client" UniqueName="ColCLIENT_CODE_NAME">
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BA_CL_DESC" HeaderText="Billing Approval Description"
                                UniqueName="ColBA_CL_DESC">
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete" HeaderText="">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <HeaderTemplate>
                                        <asp:ImageButton ID="ImageButtonDelete" runat="server" CommandName="Delete" AlternateText="Delete"
                                            ToolTip="Delete" ImageAlign="Top" SkinID="ImageButtonDelete" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBoxDeleteRow" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </ew:CollapsablePanel>
    </div>
    
</asp:Content>
