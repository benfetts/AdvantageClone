<%@ Control AutoEventWireup="false" CodeBehind="DesktopInOutBoardAll.ascx.vb" Inherits="Webvantage.DesktopInOutBoardAll" Language="vb" %>
<%@ Register Src="InOutBoard.ascx" TagName="InOutBoard" TagPrefix="custom" %>
<div class="telerik-aqua-body" style="margin-top: 5px!important;">
    <div class="DO-ButtonHeader">
        <div style="padding: 12px 0px 0px 0px; float: left; text-align: left; vertical-align: middle; display: inline-block;">
            <custom:InOutBoard ID="UserControlInOutBoard" runat="server" />
        </div>
        <div style="padding: 12px 0px 0px 0px; float: right; text-align: right; display: inline-block;">
            Group by: 
            <telerik:RadComboBox ID="ddGroupByAll" runat="server" AutoPostBack="true" TabIndex="7" width="220">
                <Items>
                    <telerik:RadComboBoxItem Value="" Text="No Grouping"></telerik:RadComboBoxItem>
                    <telerik:RadComboBoxItem Value="Office" Text="Office"></telerik:RadComboBoxItem>
                    <telerik:RadComboBoxItem Value="Dept" Text="Department"></telerik:RadComboBoxItem>
                    <telerik:RadComboBoxItem Value="OD" Text="Office/Department"></telerik:RadComboBoxItem>
                </Items>
            </telerik:RadComboBox>
            <asp:ImageButton ID="butRefreshAll" runat="server" ImageAlign="AbsMiddle" SkinID="ImageButtonRefresh" ToolTip="Refresh" />
            <asp:ImageButton ID="ImageButtonBookmark" runat="server" ToolTip="Bookmarks" SkinID="ImageButtonBookmark"/>
        </div>
    </div>
    <div class="DO-Container">
        <telerik:RadGrid ID="InOutAllRadGrid" runat="server" AllowSorting="True" TabIndex="-1" AllowPaging="true" PageSize="10"
            EnableAJAX="True" AutoGenerateColumns="False" GridLines="None" EnableViewState="true"
            EnableEmbeddedSkins="True" Width="100%" GroupingSettings-GroupByFieldsSeparator="  ">
            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom"></PagerStyle>
            <ClientSettings>
                <Scrolling AllowScroll="False" UseStaticHeaders="false" />
            </ClientSettings>
            <MasterTableView AllowMultiColumnSorting="True" TabIndex="-1" TableLayout="Auto" DataKeyNames="EMP_CODE, INOUT_REF">
                <Columns>
                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnStatusFlag">
                        <HeaderStyle CssClass="radgrid-icon-column" />
                        <ItemStyle CssClass="radgrid-icon-column" />
                        <FooterStyle CssClass="radgrid-icon-column" />
                        <ItemTemplate>
                            <div class="icon-background background-color-sidebar" runat="server" id="DivFlagColor">
                                <asp:Image ID="ImageFlag" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/user.png" />
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="EMP_CODE" HeaderText="Employee" ReadOnly="True" UniqueName="GridBoundColumnEmployee">
                        <HeaderStyle HorizontalAlign="left" />
                        <ItemStyle HorizontalAlign="left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="INOUT_TIME" HeaderText="In-Out Time" ReadOnly="True" UniqueName="GridBoundColumnInOutTime">
                        <HeaderStyle CssClass="radgrid-datetime-column" />
                        <ItemStyle CssClass="radgrid-datetime-column" />
                    </telerik:GridBoundColumn>
                    <%--<telerik:GridBoundColumn DataField="COMMENT" HeaderText="Comment" ReadOnly="True" UniqueName="GridBoundColumnReason">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>--%>
                    <telerik:GridTemplateColumn DataField="COMMENT" HeaderText="Comment" UniqueName="GridBoundColumnReason" SortExpression="COMMENT" >
                        <HeaderStyle HorizontalAlign="left" />
                        <ItemStyle HorizontalAlign="left" />
                        <ItemTemplate> 
                                <asp:Label ID="LabelComment" runat="server" Text='<%# Eval("COMMENT") %>' Visible="false"></asp:Label>
                                <asp:TextBox ID="TextBoxComment" runat="server" MaxLength="50" Text='<%# Eval("COMMENT") %>' Width="200px" ></asp:TextBox>                        
                        </ItemTemplate> 
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="EXP_RETURN_TIME" HeaderText="Expected Return" UniqueName="GridBoundColumnExpectedReturn" ReadOnly="True">
                        <HeaderStyle CssClass="radgrid-datetime-column" />
                        <ItemStyle CssClass="radgrid-datetime-column" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DEPT" HeaderText="" UniqueName="column7" Visible="false" GroupByExpression="DEPT By Group By DEPT">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSave">
                        <HeaderStyle CssClass="radgrid-icon-column" />
                        <ItemStyle CssClass="radgrid-icon-column" />
                        <FooterStyle CssClass="radgrid-icon-column" />
                        <HeaderTemplate>
                            <asp:ImageButton ID="ImageButtonSaveAll" runat="server" SkinID="ImageButtonSaveAll"
                                ToolTip="Click to save all rows" CommandName="SaveAll" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="icon-background background-color-sidebar">
                                <asp:ImageButton ID="ImageButtonSave" runat="server" SkinID="ImageButtonSaveWhite"
                                    ToolTip="Click to save this row" CommandName="SaveRow" />
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="ImageButtonSaveAllFooter" runat="server" SkinID="ImageButtonSaveAll"
                                ToolTip="Click to save all rows" CommandName="SaveAll" />
                        </FooterTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <ExpandCollapseColumn Visible="False">
                    <HeaderStyle Width="19px" />
                </ExpandCollapseColumn>
                <RowIndicatorColumn Visible="False">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
            </MasterTableView>
            <GroupingSettings GroupByFieldsSeparator=" " />
        </telerik:RadGrid>
    </div>

</div>
