<%@ Page AutoEventWireup="false" CodeBehind="BillingApproval_View.aspx.vb" Inherits="Webvantage.BillingApproval_View"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="" %>

<asp:Content ID="ContentBillingApprovalView" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <script type="text/javascript">
        function RefreshGrid(radWindowCaller) {
            __doPostBack('onclick#Refresh', 'Refresh');
        };
        function SaveFromPopUp(radWindowCaller) {
            __doPostBack('onclick#Save', 'Save');
        };
        function realPostBack(eventTarget, eventArgument) {
            __doPostBack(eventTarget, eventArgument);
        };
        function HidePopUpWindows(radWindowCaller) {
            __doPostBack('onclick#Refresh', 'HidePopups');
        };
             function RebindGrid() {
                $find('<%= RadGridBillingApproval.ClientID %>').get_masterTableView().rebind();
            }
    </script>
    <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" Animation="None" RenderMode="Classic"
        AutoTooltipify="false" Height="75px" ManualClose="true" Modal="true" OnAjaxUpdate="OnAjaxUpdate"
        Position="BottomLeft" RelativeTo="Element" ShowEvent="OnMouseOver" Sticky="true"
        Width="560px">
    </telerik:RadToolTipManager>
    <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
        <telerik:RadToolBar ID="RadToolbarBatch" runat="server" AutoPostBack="True" Width="100%">
            <Items>
                <telerik:RadToolBarButton SkinID="RadToolBarButtonNew" Text="New Batch" Value="NewBatch"
                    ToolTip="Create a new Batch" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="Bookmark" Value="Bookmark" ToolTip="Bookmark" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh"
                    Value="RefreshSearch" ToolTip="Refresh/Search" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton>
                    <ItemTemplate>
                        Month/Year:
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Value="RadToolBarButtonNav">
                    <ItemTemplate>
                        <telerik:RadComboBox ID="RadComboBoxMonth" runat="server" SkinID="RadComboBoxMonth" AutoPostBack="true" ZIndex="999999">
                        </telerik:RadComboBox>
                        <telerik:RadComboBox ID="RadComboBoxYear" runat="server" SkinID="RadComboBoxYear" AutoPostBack="true" ZIndex="999999">
                        </telerik:RadComboBox>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton>
                    <ItemTemplate>
                        Batch ID:
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Value="RadToolBarButtonBatchId">
                    <ItemTemplate>
                        <telerik:RadNumericTextBox ID="RadNumericTextBoxBatchId" runat="server" Type="Number" MinValue="0" Style="text-align: right"
                            Width="100">
                            <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" Step="1" />
                            <NumberFormat DecimalDigits="0" />
                        </telerik:RadNumericTextBox>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                
                
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
        <asp:Label ID="LblMSG" runat="server" CssClass="CssRequired" Text="&nbsp;&nbsp;&nbsp;Batch does not exist.<br/>" Visible="false"></asp:Label>
            <ew:CollapsablePanel ID="CollapsablePanelMyBatches" runat="server" TitleText="My Batches"  Width="100%">
                <telerik:RadGrid ID="RadGridBillingApproval" runat="server" AllowPaging="False" AllowSorting="True" AutoGenerateColumns="False" EnableAJAX="False" EnableAJAXLoadingTemplate="False" Visible="True" Width="100%" EnableViewState="false">
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
                            <telerik:GridBoundColumn DataField="BA_BATCH_ID" DataFormatString="{0:000000}" HeaderText="Batch ID" SortExpression="BA_BATCH_ID" UniqueName="ColBA_BATCH_ID">
                                <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="60px" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="60px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BA_BATCH_DESC" HeaderText="Batch Description" SortExpression="BA_BATCH_DESC" UniqueName="ColBA_BATCH_DESC">
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" Width="475px" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="475px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BATCH_DATE" DataFormatString="{0:d}" SortExpression="BATCH_DATE" HeaderText="Batch Date" UniqueName="ColBATCH_DATE">
                                <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="110px" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="110px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CREATE_USER" HeaderText="Created By" UniqueName="ColCREATE_USER" SortExpression="CREATE_USER">
                                <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="150px" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="150px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ASSIGNED_EMP_NAME" HeaderText="Assigned Employee" SortExpression="ASSIGNED_EMP_NAME" UniqueName="ColASSIGNED_EMP_NAME">
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" Width="275px" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="275px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Job Count" UniqueName="ColJOB_COUNT" SortExpression="JOB_COUNT">
                                <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="75px" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="75px" />
                                <ItemTemplate>
                                    <asp:Label ID="LblJOB_COUNT" runat="server" Text='<%#Eval("JOB_COUNT")%>' CssClass="underline"></asp:Label>
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
            </ew:CollapsablePanel>
            <ew:CollapsablePanel ID="CollapsablePanelMyUnfinishedBatches" runat="server" TitleText="Unfinished Batches">
                <telerik:RadGrid ID="RadGridMyUnfinishedBatches" runat="server" AllowPaging="False" AllowSorting="True" AutoGenerateColumns="False" EnableAJAX="False" EnableAJAXLoadingTemplate="False" Visible="True" EnableViewState="false">
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
                            <telerik:GridBoundColumn DataField="BA_BATCH_ID" DataFormatString="{0:000000}" HeaderText="Batch ID" SortExpression="BA_BATCH_ID" UniqueName="ColBA_BATCH_ID">
                                <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="60px" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="60px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BA_BATCH_DESC" HeaderText="Batch Description" SortExpression="BA_BATCH_DESC" UniqueName="ColBA_BATCH_DESC">
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" Width="475px" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="475px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BATCH_DATE" DataFormatString="{0:d}" SortExpression="BATCH_DATE" HeaderText="Batch Date" UniqueName="ColBATCH_DATE">
                                <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="110px" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="110px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CREATE_USER" HeaderText="Created By" UniqueName="ColCREATE_USER" SortExpression="CREATE_USER">
                                <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="150px" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="150px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ASSIGNED_EMP_NAME" HeaderText="Assigned Employee" SortExpression="ASSIGNED_EMP_NAME" UniqueName="ColASSIGNED_EMP_NAME">
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" Width="275px" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="275px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Job Count" UniqueName="ColJOB_COUNT" SortExpression="JOB_COUNT">
                                <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="75px" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="75px" />
                                <ItemTemplate>
                                    <asp:Label ID="LblJOB_COUNT" runat="server" Text='<%#Eval("JOB_COUNT")%>' CssClass="underline"></asp:Label>
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
                            <telerik:GridTemplateColumn DataField="ALERTS" HeaderText="" UniqueName="ColALERTS" SortExpression="ALERTS">
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
            </ew:CollapsablePanel>
            <ew:CollapsablePanel ID="CollapsablePanelOtherInformation" runat="server" TitleText="Batches Created By Other Users">
                <telerik:RadGrid ID="RadGridBillingApprovalOtherUsers" runat="server" AllowPaging="False" AllowSorting="True" AutoGenerateColumns="False" EnableAJAX="False" EnableAJAXLoadingTemplate="False" Visible="True">
                    <PagerStyle Mode="NextPrevAndNumeric" NextPageText="&amp;gt;" PrevPageText="&amp;lt;" />
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
                            <telerik:GridBoundColumn DataField="BA_BATCH_ID" DataFormatString="{0:000000}" HeaderText="Batch ID" SortExpression="BA_BATCH_ID" UniqueName="ColBA_BATCH_ID">
                                <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="60px" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="60px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BA_BATCH_DESC" HeaderText="Batch Description" SortExpression="BA_BATCH_DESC" UniqueName="ColBA_BATCH_DESC">
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" Width="475px" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="475px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BATCH_DATE" DataFormatString="{0:d}" SortExpression="BATCH_DATE" HeaderText="Batch Date" UniqueName="ColBATCH_DATE">
                                <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="110px" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="110px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CREATE_USER" HeaderText="Created By" UniqueName="ColCREATE_USER" SortExpression="CREATE_USER">
                                <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="150px" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="150px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ASSIGNED_EMP_NAME" HeaderText="Assigned Employee" SortExpression="ASSIGNED_EMP_NAME" UniqueName="ColASSIGNED_EMP_NAME">
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" Width="275px" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="275px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Job Count" UniqueName="ColJOB_COUNT" SortExpression="JOB_COUNT">
                                <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="75px" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="75px" />
                                <ItemTemplate>
                                    <asp:Label ID="LblJOB_COUNT" runat="server" Text='<%#Eval("JOB_COUNT")%>' CssClass="underline"></asp:Label>
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
                            <telerik:GridTemplateColumn DataField="ALERTS" HeaderText="" UniqueName="ColALERTS" SortExpression="ALERTS">
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
            </ew:CollapsablePanel>
    </div>
    
</asp:Content>
