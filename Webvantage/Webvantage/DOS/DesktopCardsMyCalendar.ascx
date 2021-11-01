<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopCardsMyCalendar.ascx.vb" Inherits="Webvantage.DesktopCardsMyCalendar" %>
<%@ Register Src="DesktopCardDayNavigator.ascx" TagName="DayNavigator" TagPrefix="WV" %>
<%@ Register Src="~/UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>
    <div style="width:100%;text-align:right;">
        <WV:DayNavigator ID="DayNavigator" runat="server" Visible="True" />
    </div>
<div style="display:none !important;">
    <asp:ImageButton ID="ImageButtonRefreshDesktopCardsMyCalendar" runat="server" ImageAlign="AbsMiddle" SkinID="ImageButtonRefresh" ToolTip="Refresh" />
</div>
<br />
    <div style="border: 0px solid white;display:inline;">
        <asp:Repeater ID="RepeaterMyCalendar" runat="server">
            <HeaderTemplate>
                <div class="card-container" style="margin-left:-10px !important; background-color: #FAFAFA !important;">
            </HeaderTemplate>
            <ItemTemplate>
                    <div id="DivCard" runat="server" class="card" >
                        <div id="DivCardContent" runat="server" class="card-content">
                            <div style="cursor:pointer;">
                                <div id="DivDisplay" runat="server">
                                    <div style="font-weight: bold;">
                                        <asp:Label ID="LabelDisplay" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div id="HeaderTimespan" runat="server">
                                    <div style="font-weight: bold;">
                                        <asp:Label ID="LabelTimespan" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div id="DivTaskDetails" runat="server">
                                    <asp:Label ID="LabelDetails" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div id="DivActionBar" runat="server" class="card-bottom-header">
                            <div style="display: block;">
                                <div style="display: inline-block; padding: 6px 0px 0px 8px; color: #808080;">
                                    <asp:Literal ID="LiteralActionBarText" runat="server" Text=""></asp:Literal>
                                </div>
                                <div class="card-action-bar" style="overflow: hidden !important;">
                                    <asp:ImageButton ID="ImageButtonBookmark" runat="server" CssClass="card-action-icon" ImageUrl="~/Images/Icons/Color/256/book_bookmark.png" ToolTip="Bookmark" Visible="false" />
                                    <asp:ImageButton ID="ImageButtonViewWorkItem" runat="server" CssClass="card-action-icon" ImageUrl="~/Images/Icons/Color/256/users_relation2.png" ToolTip="View Work Item" Visible="false" />
                                    <asp:ImageButton ID="ImageButtonMarkTempComplete" runat="server" CssClass="card-action-icon" ImageUrl="~/Images/Icons/Color/256/check.png" ToolTip="Mark temp complete" />
                                    <asp:ImageButton ID="ImageButtonAddTime" runat="server" CssClass="card-action-icon" ImageUrl="~/Images/Icons/Color/256/clock.png" ToolTip="Add Time" />
                                    <asp:ImageButton ID="ImageButtonStartStopwatch" runat="server" CssClass="card-action-icon" ImageUrl="~/Images/Icons/Color/256/stopwatch.png" ToolTip="Start Stopwatch" />
                                </div>
                            </div>
                        </div>
                        <asp:HiddenField ID="HiddenFieldJobNumber" runat="server" Value='<%#Eval("JOB_NUMBER")%>' />
                        <asp:HiddenField ID="HiddenFieldJobComponentNumber" runat="server" Value='<%#Eval("JOB_COMPONENT_NBR")%>' />
                        <asp:HiddenField ID="HiddenFieldTaskSequenceNumber" runat="server" Value='<%#Eval("TASK_SEQ_NBR")%>' />
                        <asp:HiddenField ID="HiddenFieldEventTaskID" runat="server" Value='<%#Eval("NON_TASK_ID")%>' />
                        <asp:HiddenField ID="HiddenFieldTaskNonTaskDisplay" runat="server" Value='<%#Eval("TASK_NON_TASK_DISPLAY")%>' />
                        <asp:HiddenField ID="HiddenFieldJobComponentDescription" runat="server" Value='<%#Eval("JOB_COMP_DESC")%>' />
                    </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
       <div style="text-align: center; margin:10px 0px 0px 0px;">
            <asp:ImageButton ID="ImageButtonAdd" runat="server" ImageUrl="~/Images/Icons/Grey/256/add.png" ToolTip="Click to add a new calendar activity" 
                Height="36" Width="36"/>
        </div>
    </div>
    <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
