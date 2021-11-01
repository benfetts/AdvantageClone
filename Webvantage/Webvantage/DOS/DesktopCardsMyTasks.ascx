<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopCardsMyTasks.ascx.vb" Inherits="Webvantage.DesktopCardsMyTasks" %>
<%@ Register Src="~/UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>
<style>
    .comment {
        display:block;
        position:relative;
        clear:both;
        font-style: italic !important;
        font-size: small !important;
        max-height: 48px !important;
        overflow-x:hidden;
        overflow-y:auto;
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
        //console.log("Hello from DesktopCardsMyTasks!")
        __doPostBack("<%= UpdatePanelDO.ClientID %>","");
    }
</script>
<asp:UpdatePanel ID="UpdatePanelDO" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
        <asp:Panel ID="PanelHeader" runat="server" CssClass="DO-ButtonHeader" DefaultButton="ImageButtonSearch">
            <div style="float: left; width: 75%; text-align: left;">
                <div style="display: inline-block; margin: 0px 0px 0px 0px; border: solid 0px red;">
                    <div style="display: none !important; border: solid 0px red;">
                        <asp:Label ID="LabelTitle" runat="server" Text="Tasks" Visible="false" CssClass="dfltws-content-title"></asp:Label>
                    </div>
                    <div style="display: inline-block; vertical-align: top; padding: 10px 0px 0px 15px; border: solid 0px red;">
                        <telerik:RadComboBox ID="RadComboBoxSortOptions" runat="server" AutoPostBack="true" Width="162">
                        </telerik:RadComboBox>
                    </div>
                    <div style="display: inline-block; vertical-align: top; padding: 10px 0px 0px 19px; border: solid 0px red; min-width: 200px;">
                        <div style="display: inline-block; vertical-align: top; padding: 0px 0px 0px 0px; border: solid 0px red;">
                            <asp:TextBox ID="TextBoxSearch" runat="server" Width="160"></asp:TextBox>
                        </div>
                        <div style="display: inline-block; vertical-align: top; padding: 0px 0px 0px 0px; border: solid 0px red;">
                            <asp:ImageButton ID="ImageButtonSearch" runat="server" SkinID="ImageButtonFind" />
                        </div>
                        <div style="display: none; vertical-align: top; padding: 10px 0px 0px 0px; border: solid 0px red;">
                            <asp:CheckBox ID="CheckBoxOverdue" runat="server" Text="Overdue" AutoPostBack="true" />
                        </div>
                    </div>
                </div>
            </div>
            <div style="float: right; width: 25%; text-align: right; min-width: 25px; margin: 6px 0px 0px 0px;">
                <asp:ImageButton ID="ImageButtonRefreshDesktopCardsMyTasks" runat="server" ImageAlign="AbsMiddle" SkinID="ImageButtonRefresh" ToolTip="Refresh" />
                <asp:ImageButton ID="ImageButtonSettings" runat="server" SkinID="ImageButtonSettings" OnClientClick="OpenRadWindow('','Maintenance_DesktopCards.aspx', 300, 500, false);return false;" ToolTip="Optional settings for dashboard cards" />
            </div>
        </asp:Panel>
        <telerik:RadListView ID="RadListViewTasksDirty" runat="server" RenderMode="Classic" CssClass="card-control-bg" AllowPaging="true" PageSize="50"
            ItemPlaceholderID="DataGroupPlaceHolderGroup" GroupAggregatesScope="AllItems" AllowMultiFieldSorting="true"
            DataKeyNames="JobNo,JobComp,SeqNo,EVENT_TASK_ID, ALERT_ID">
            <ClientSettings AllowItemsDragDrop="true">
                <ClientEvents OnItemDragging="RadListViewTasksDirtyOnItemDragging"></ClientEvents>
            </ClientSettings>
            <ItemTemplate>
                <div id="DivTaskCard" runat="server" class="card task-card rlvI">
                    <div id="DivCardContent" runat="server" class="card-content">
                        <div id="HeaderTaskDescription" runat="server">
                            <div style="font-weight: bold;">
                                <asp:Label ID="LabelTaskDescription" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Task") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="task-details" id="DivTaskDetails" runat="server">
                            <div style="">
                                <div class="comment">
                                    <asp:Label ID="LabelTaskComment" runat="server"></asp:Label>
                                </div>
                                <asp:Label ID="LabelClientName" runat="server"></asp:Label>
                                <asp:Label ID="LabelJobData" runat="server"></asp:Label>
                            </div>
                            <div id="DivDateContainer" runat="server">
                                <asp:Label ID="LabelStartDate" runat="server"></asp:Label>
                                <asp:Label ID="LabelDueDate" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div id="DivActionBar" runat="server" class="card-bottom-header">
                        <div style="display: inline-block; padding: 6px 0px 0px 8px;">
                            <telerik:RadListViewItemDragHandle ID="RadListViewItemDragHandleTaskCard" runat="server" ToolTip="Drag this icon and drop it on the same icon or text of a different card to change priority" CssClass="RadListViewDragItem"></telerik:RadListViewItemDragHandle>
                        </div>
                        <div class="card-action-bar" style="overflow: hidden !important;">
                            <asp:ImageButton ID="ImageButtonBookmark" runat="server" CssClass="card-action-icon" ImageUrl="~/Images/Icons/Color/256/book_bookmark.png" ToolTip="Bookmark" CommandName="Bookmark" Visible="false" />
                            <asp:ImageButton ID="ImageButtonMarkTempComplete" runat="server" CssClass="card-action-icon" ImageUrl="~/Images/Icons/Color/256/check.png" ToolTip="Mark temp complete" CommandName="MarkTempComplete" />
                            <asp:ImageButton ID="ImageButtonAddTime" runat="server" CssClass="card-action-icon" ImageUrl="~/Images/Icons/Color/256/clock.png" ToolTip="Add Time" CommandName="AddTime" />
                            <asp:ImageButton ID="ImageButtonStartStopwatch" runat="server" CssClass="card-action-icon" ImageUrl="~/Images/Icons/Color/256/stopwatch.png" ToolTip="Start Stopwatch" CommandName="StartStopwatch" />
                        </div>
                    </div>
                    <asp:HiddenField ID="HiddenFieldJobNumber" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "JobNo") %>' />
                    <asp:HiddenField ID="HiddenFieldJobComponentNumber" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "JobComp") %>' />
                    <asp:HiddenField ID="HiddenFieldTaskSequenceNumber" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "SeqNo") %>' />
                    <asp:HiddenField ID="HiddenFieldEventTaskID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "EVENT_TASK_ID") %>' />
                    <asp:HiddenField ID="HiddenFieldTaskDescription" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Task") %>' />
                    <asp:HiddenField ID="HiddenFieldJobData" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "JobData") %>' />
                </div>
            </ItemTemplate>
            <LayoutTemplate>
                <div id="task-card-container" class="card-container" style="width: 100%; background-color: #FAFAFA !important;">
                    <asp:PlaceHolder ID="PlaceHolderTasks" runat="server"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>
            <GroupSeparatorTemplate>
            </GroupSeparatorTemplate>
            <EmptyDataTemplate>
            </EmptyDataTemplate>
            <DataGroups>
                <telerik:ListViewDataGroup GroupField="END_SELECT_CLAUSE" DataGroupPlaceholderID="PlaceHolderTasks" SortOrder="Ascending">
                    <DataGroupTemplate>
                        <asp:Panel runat="server" ID="PanelGroup" CssClass="card-group" GroupingText='<%# CType(Container, RadListViewDataGroupItem).DataGroupKey %>'>
                            <asp:PlaceHolder runat="server" ID="DataGroupPlaceHolderGroup"></asp:PlaceHolder>
                        </asp:Panel>
                    </DataGroupTemplate>
                </telerik:ListViewDataGroup>
            </DataGroups>
        </telerik:RadListView>
        <div class="dash-pager-container">
            <telerik:RadDataPager ID="RadDataPagerTasks" runat="server" PagedControlID="RadListViewTasksDirty" PageSize="50" Skin="Bootstrap" CssClass="data-pager">
                <Fields>
                    <telerik:RadDataPagerButtonField FieldType="FirstPrev" />
                    <telerik:RadDataPagerButtonField FieldType="NextLast" />
                    <telerik:RadDataPagerPageSizeField PageSizeComboWidth="69" PageSizeText="Page size: " PageSizes="10; 20; 50; 100; 150; 200" />
                </Fields>
            </telerik:RadDataPager>
        </div>
        <asp:HiddenField ID="HiddenFieldRecordCount" Value="0" runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>

<custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
<telerik:RadScriptBlock ID="RadScriptBlockFooter" runat="server">
    <script type="text/javascript">
        
        function RadListViewTasksDirtyOnItemDragging(sender, args) {
            var dragElement = args.get_domEvent().srcElement;
            var evt = args.get_domEvent();
            var container = $(dragElement).closest('div[id*=DivDefaultWorkspaceLeftMiddle], div[id*=DivUserTasks]');
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
