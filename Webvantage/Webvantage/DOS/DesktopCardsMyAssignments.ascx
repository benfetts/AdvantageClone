<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopCardsMyAssignments.ascx.vb" Inherits="Webvantage.DesktopCardsMyAssignments" %>
<%@ Register Src="~/UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>
<style>
    .thumbnail-column {
        display: inline-block; 
        clear: both; 
        vertical-align: top;
    }
    .no-thumbnail-column {
        display: none;
    }
    .card-text-with-thumbnail {
        display: inline-block; 
        clear: both; 
        width: 190px; 
        vertical-align: top;
    }
    .card-text-no-thumbnail {
    }
    .reviewer-active {
        color: #4CAF50;
        font-weight: bold;
    }
    .data-pager {
        background-color: #FAFAFA !important;
    }
    .pager-count {
        margin: 9px 0px 0px 11px;
    }
</style>
<script>
    function refreshUpdatePanel() {
        console.log("DesktopCardsMyAssignments!  refreshUpdatePanel")
        __doPostBack("<%=UpdatePanelDO.ClientID %>","");
    }
</script>
<asp:UpdatePanel ID="UpdatePanelDO" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
        <div class="DO-ButtonHeader">
            <div style="float: left; width: 75%; text-align: left; vertical-align: top;">
                <div style="display: none !important; vertical-align: top; padding: 0px 0px 0px 0px; border: solid 0px red;">
                    <asp:Label ID="LabelTitle" runat="server" Text="" Visible="false" CssClass="dfltws-content-title"></asp:Label>
                </div>
                <div id="DivSortOptions" runat="server" style="display: inline-block; vertical-align: top; padding: 10px 0px 0px 20px; border: solid 0px blue;">
                    <telerik:RadComboBox ID="RadComboBoxSortOptions" runat="server" AutoPostBack="true">
                    </telerik:RadComboBox>
                </div>
            </div>
            <div style="float: right; width: 25%; text-align: right; margin: 6px 0px 0px 0px;">
                <asp:ImageButton ID="ImageButtonRefreshDesktopCardsMyAssignments" runat="server" ImageAlign="AbsMiddle" SkinID="ImageButtonRefresh" ToolTip="Refresh" />
                <asp:ImageButton ID="ImageButtonSettings" runat="server" SkinID="ImageButtonSettings" OnClientClick="OpenRadWindow('','Maintenance_DesktopCards.aspx', 300, 500, false);return false;" ToolTip="Optional settings for dashboard cards" />
            </div>
        </div>
        <telerik:RadListView ID="RadListViewAlertAssignmentsDirty" runat="server" RenderMode="Classic" AllowPaging="true" AllowNaturalSort="true" CssClass="card-control-bg"
            ItemPlaceholderID="DataGroupPlaceHolderGroup" GroupAggregatesScope="AllItems" AllowMultiFieldSorting="true" PageSize="50"
            DataKeyNames="ALERT_ID, JOB_NUMBER, JOB_COMPONENT_NBR, IS_ASSIGNMENT, CS_PROJECT_ID, CS_REVIEW_ID, SPRINT_ID">
            <ClientSettings AllowItemsDragDrop="true">
                <ClientEvents OnItemDragging="RadListViewAlertAssignmentsDirtyOnItemDragging"></ClientEvents>
            </ClientSettings>
            <ItemTemplate>
                <div id="DivAlertAssignmentCard" runat="server" class="card alert-card rlvI">
                    <div id="DivCardContent" runat="server" class="card-content">
                        <div id="DivThumbnail" runat="server" class="no-thumbnail-column">
                            <asp:ImageButton ID="ImageButtonThumbnail" runat="server" CommandName="ViewDetails" ToolTip="View details" AlternateText="View details" />
                        </div>
                        <div id="DivCardText" runat="server" class="card-text-no-thumbnail">
                            <div id="HeaderState" runat="server" style="cursor: pointer;">
                                <div style="font-weight: bold;">
                                    <asp:Label ID="LabelState" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div id="DivDetails" runat="server" style="cursor: pointer;">
                                <div id="HeaderSubject" runat="server" style="cursor: pointer;">
                                    <asp:Label ID="LabelSubject" runat="server" ToolTip='<%# DataBinder.Eval(Container.DataItem, "SUBJECT") %>'></asp:Label>
                                </div>
                                <div id="DivJobInformation" runat="server">
                                    <asp:Label ID="LabelJobInformation" runat="server" Text=""></asp:Label>
                                </div>
                                <div id="DivClientName" runat="server">
                                    <asp:Label ID="LabelClientName" runat="server"></asp:Label>
                                </div>
                                <div>
                                    <div id="DivDueDate" runat="server" style="display: inline-block;">
                                        Due:
                                        <asp:Label ID="LabelDueDate" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div id="DivDueTime" runat="server" style="display: inline-block;">
                                        <asp:Label ID="LabelDueTime" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div id="DivReviewersCompleted" runat="server">
                                    Completed:
                                    <asp:Label ID="LabelReviewersCompleted" runat="server" Text="0/0"></asp:Label>
                                    <asp:Label ID="LabelReviewerActive" runat="server" Text=", Active" CssClass="reviewer-active" ToolTip="You are active"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="DivActionBar" runat="server" class="card-bottom-header">
                        <div style="display: inline-block; padding: 6px 0px 0px 8px;">
                            <telerik:RadListViewItemDragHandle ID="RadListViewItemDragHandleAlertAssignmentCard" runat="server" ToolTip="Drag this icon and drop it on the same icon or text of a different card to change priority" CssClass="RadListViewDragItem"></telerik:RadListViewItemDragHandle>
                        </div>
                        <div class="card-action-bar" style="overflow: hidden !important;">
                            <asp:ImageButton ID="ImageButtonFeedbackSummary" runat="server" CssClass="card-action-icon" ImageUrl="~/Images/Icons/Color/256/document_pulse.png" ToolTip="Download feedback summary for review" Visible="false" />
                            <asp:ImageButton ID="ImageButtonCompleteDismiss" runat="server" CssClass="card-action-icon" ImageUrl="~/Images/Icons/Color/256/checkbox.png" ToolTip="Re-Assign" />
                            <asp:ImageButton ID="ImageButtonBookmark" runat="server" CssClass="card-action-icon" ImageUrl="~/Images/Icons/Color/256/book_bookmark.png" ToolTip="Bookmark" Visible="false" />
                            <asp:ImageButton ID="ImageButtonReAssign" runat="server" CssClass="card-action-icon" ImageUrl="~/Images/Icons/Color/256/users_relation2.png" ToolTip="Re-Assign" />
                            <asp:ImageButton ID="ImageButtonComments" runat="server" CssClass="card-action-icon" ImageUrl="~/Images/Icons/Color/256/messages.png" ToolTip="Comments" />
                            <asp:ImageButton ID="ImageButtonAddTime" runat="server" CssClass="card-action-icon" ImageUrl="~/Images/Icons/Color/256/clock.png" ToolTip="Add Time" />
                            <asp:ImageButton ID="ImageButtonStartStopwatch" runat="server" CssClass="card-action-icon" ImageUrl="~/Images/Icons/Color/256/stopwatch.png" ToolTip="Start Stopwatch" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <LayoutTemplate>
                <div id="dirty-card-container" class="card-container" style="width: 100%; background-color: #FAFAFA !important;">
                    <asp:PlaceHolder ID="PlaceHolderAlertAssignments" runat="server"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>
            <GroupSeparatorTemplate>
            </GroupSeparatorTemplate>
            <EmptyDataTemplate>
            </EmptyDataTemplate>
            <DataGroups>
                <telerik:ListViewDataGroup GroupField="END_SELECT_CLAUSE" DataGroupPlaceholderID="PlaceHolderAlertAssignments" SortOrder="Ascending">
                    <DataGroupTemplate>
                        <asp:Panel runat="server" ID="PanelGroup" CssClass="card-group clear-fix" GroupingText='<%# CType(Container, RadListViewDataGroupItem).DataGroupKey %>'>
                            <asp:PlaceHolder runat="server" ID="DataGroupPlaceHolderGroup"></asp:PlaceHolder>
                        </asp:Panel>
                    </DataGroupTemplate>
                </telerik:ListViewDataGroup>
            </DataGroups>
        </telerik:RadListView>
        <div class="dash-pager-container">
            <telerik:RadDataPager ID="RadDataPagerAlertAssignments" runat="server" PagedControlID="RadListViewAlertAssignmentsDirty" PageSize="50" Skin="Bootstrap" CssClass="data-pager">
                <Fields>
                    <telerik:RadDataPagerButtonField FieldType="FirstPrev" />
                    <%--            <telerik:RadDataPagerButtonField FieldType="Numeric" PageButtonCount="5" />--%>
                    <telerik:RadDataPagerButtonField FieldType="NextLast" />
                    <telerik:RadDataPagerPageSizeField PageSizeComboWidth="69" PageSizeText="Page size: " PageSizes="10; 20; 50; 100; 150; 200" />
                    <%--            <telerik:RadDataPagerGoToPageField CurrentPageText="Page: " TotalPageText="of" SubmitButtonText="Go" />
                    <telerik:RadDataPagerTemplatePageField>
                        <PagerTemplate>
                            <div class="pager-count">
                                Items
                                            <asp:Label runat="server" ID="CurrentPageLabel" Text="<%# Container.Owner.StartRowIndex + 1%>" />
                                to
                                            <asp:Label runat="server" ID="TotalPagesLabel" Text="<%# IIf(Container.Owner.TotalRowCount > (Container.Owner.StartRowIndex + Container.Owner.PageSize), Container.Owner.StartRowIndex + Container.Owner.PageSize, Container.Owner.TotalRowCount) %>" />
                                of
                                            <asp:Label runat="server" ID="TotalItemsLabel" Text="<%# Container.Owner.TotalRowCount%>" />
                            </div>
                        </PagerTemplate>
                    </telerik:RadDataPagerTemplatePageField>--%>
                </Fields>
            </telerik:RadDataPager>
        </div>
        <asp:HiddenField ID="HiddenFieldRecordCount" Value="" runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>


<custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
<telerik:RadScriptBlock ID="RadScriptBlockFooter" runat="server">
    <script type="text/javascript">
        function RadListViewAlertAssignmentsDirtyOnItemDragging(sender, args) {
            var dragElement = args.get_domEvent().srcElement;
            var evt = args.get_domEvent();
            var container = $(dragElement).closest('div[id*=DivUserAlerts], div[id*=DivUserAssignments]');
            if (container.length > 0) {
                var scrollY = container[0].scrollHeight;
                var containerY = container.height();
                if (scrollY !== containerY) {
                    var scrollPosY = container.scrollTop();
                    var offset = container.offset();
                    var mousePosY = evt.pageY - offset.top;
                    var containerTop = container.offset().top + 60;
                    if (mousePosY >= (containerY - 60)) {
                        container.scrollTop(container.scrollTop() + 5);
                    } else if (mousePosY <= 60) {
                        container.scrollTop(container.scrollTop() - 5);
                    }
                }
            } 
        }

    </script>
    <style type="text/css">
        .rlvDraggedItem {
            z-index: 999999 !important;
        }
    </style>
</telerik:RadScriptBlock>
