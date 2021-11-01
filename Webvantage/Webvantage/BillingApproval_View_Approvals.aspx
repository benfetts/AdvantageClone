<%@ Page AutoEventWireup="false" CodeBehind="BillingApproval_View_Approvals.aspx.vb"
    Inherits="Webvantage.BillingApproval_View_Approvals" Language="vb" MasterPageFile="~/ChildPage.Master"
    Title="Billing Approval - Batch Selection" %>

<asp:Content ID="ContentBillingApprovalView" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <script type="text/javascript">
        function RebindGrid() {
            $find('<%= RadGridBillingApproval.ClientID %>').get_masterTableView().rebind();
        }
        function RadToolbarBatchViewOnClientButtonClicking(sender, args) {
            var commandName = args.get_item().get_commandName();
            if (commandName == "Bookmark") {
                ////args.set_cancel(!confirm("Bookmarking a batch selection page will bypass password entry for this assigned employee.\n\nContinue?"));
                radToolBarConfirm(sender, args, "Bookmarking a batch selection page will bypass password entry for this assigned employee.\n\nContinue?");
            }
        }
    </script>
    <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" Animation="None" RenderMode="Classic"
        AutoTooltipify="false" Height="75px" ManualClose="true" Modal="true" OnAjaxUpdate="OnAjaxUpdate"
        Position="MiddleLeft" RelativeTo="Element" ShowEvent="OnMouseOver" Sticky="true"
        Width="560px">
    </telerik:RadToolTipManager>
    <div class="no-float-menu">
    <telerik:RadToolBar ID="RadToolbarBatchView" runat="server" AutoPostBack="True" Width="100%" OnClientButtonClicking="RadToolbarBatchViewOnClientButtonClicking">
        <Items>
            <telerik:RadToolBarButton>
                <ItemTemplate>
                    &nbsp;&nbsp;Month/Year</ItemTemplate>
            </telerik:RadToolBarButton>
            <telerik:RadToolBarButton Value="RadToolBarButtonNav">
                <ItemTemplate>
                    <telerik:RadComboBox ID="RadComboBoxMonth" runat="server" SkinID="RadComboBoxMonth" AutoPostBack="true">
                    </telerik:RadComboBox>
                    <telerik:RadComboBox ID="RadComboBoxYear" runat="server" SkinID="RadComboBoxYear" AutoPostBack="true">
                    </telerik:RadComboBox>
                </ItemTemplate>
            </telerik:RadToolBarButton>
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh" ToolTip="Refresh" />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark" CommandName="Bookmark" ToolTip="Bookmark" Visible="false" />
        </Items>
    </telerik:RadToolBar>
     </div>
    <div class="telerik-aqua-body">
        <telerik:RadGrid ID="RadGridBillingApproval" runat="server" AllowPaging="False" AllowSorting="True"
                AutoGenerateColumns="False" EnableAJAX="False" EnableAJAXLoadingTemplate="False"
                EnableEmbeddedSkins="True" Visible="True">
                <MasterTableView NoMasterRecordsText="No records found">
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="" UniqueName="ColVIEW" SortExpression="BA_BATCH_ID">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                 <asp:ImageButton ID="ImgBtnViewBatch" runat="server" AlternateText="View batch record"
                                    CommandArgument='<%#Eval("BA_BATCH_ID")%>' CommandName="ViewBatch" SkinID="ImageButtonViewWhite" ToolTip="View batch record" />
                               </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="BA_BATCH_ID" HeaderText="Batch ID" UniqueName="ColBA_BATCH_ID" DataFormatString="{0:000000}" SortExpression="BA_BATCH_ID">
                            <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="60px" />
                            <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="60px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="BA_BATCH_DESC" HeaderText="Batch Description" UniqueName="ColBA_BATCH_DESC" SortExpression="BA_BATCH_DESC">
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="BATCH_DATE" HeaderText="Batch Date" UniqueName="ColBATCH_DATE" SortExpression="BATCH_DATE">
                            <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="110px" />
                            <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="110px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CREATE_USER" HeaderText="Created By" UniqueName="ColCREATE_USER" SortExpression="CREATE_USER">
                            <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="150px" />
                            <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="150px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ASSIGNED_EMP_NAME" HeaderText="Assigned Employee" UniqueName="ColASSIGNED_EMP_NAME" SortExpression="ASSIGNED_EMP_NAME">
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn HeaderText="Job<br />Count" UniqueName="ColJOB_COUNT" SortExpression="JOB_COUNT">
                            <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="30px" />
                            <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="30px" />
                            <ItemTemplate>
                                <asp:Label ID="LblJOB_COUNT" runat="server" Text='<%#Eval("JOB_COUNT")%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="STATUS" HeaderText="Status" UniqueName="ColSTATUS" SortExpression="STATUS">
                            <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="85px" />
                            <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="85px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn HeaderText="" UniqueName="ColStatusIcon" SortExpression="STATUS">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <asp:HiddenField ID="HfBA_EXISTS" runat="server" Value='<%#Eval("BA_EXISTS")%>' />
                                <asp:HiddenField ID="HfAPPROVED" runat="server" Value='<%#Eval("APPROVED")%>' />
                                <asp:HiddenField ID="HfFINISHED" runat="server" Value='<%#Eval("FINISHED")%>' />
                                <div id="DivStatusColor" runat="server" class="icon-background background-color-sidebar">
                                    <asp:Image ID="ImageStatus" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/progress_bar.png" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="ALERT_STATUS" HeaderText="" UniqueName="ColALERTS" SortExpression="ALERT_STATUS">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div id="DivAlertStatus" runat="server" class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImageButtonAlertStatus" runat="server" CommandName="AlertList" CommandArgument='<%#Eval("BA_BATCH_ID")%>' SkinID="ImageButtonAlertsWhite" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
    </div>
    
</asp:Content>
