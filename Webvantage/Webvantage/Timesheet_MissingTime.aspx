<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Timesheet_MissingTime.aspx.vb" Inherits="Webvantage.Timesheet_MissingTime" MasterPageFile="~/ChildPage.Master" Title="Missing/Denied Time" %>

<asp:Content ID="ContentMissingTime" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <div id="DivMissingTime" runat="server">
        <h4 id="MissingTimeHeader" runat="server">Missing Time</h4>
        <telerik:RadGrid ID="RadGridMissingTime" runat="server" AllowPaging="false" AllowSorting="False"
            AutoGenerateColumns="False" GridLines="None" PageSize="20">
            <MasterTableView HorizontalAlign="Left">
                <GroupByExpressions>
                    <telerik:GridGroupByExpression>
                        <SelectFields>
                            <telerik:GridGroupByField FieldName="WEEKOFDATE" HeaderText="Week Of" FormatString="{0:d}"
                                SortOrder="None" />
                        </SelectFields>
                        <GroupByFields>
                            <telerik:GridGroupByField FieldName="WEEKOFDATE" SortOrder="None" />
                        </GroupByFields>
                    </telerik:GridGroupByExpression>
                </GroupByExpressions>
                <Columns>
                    <telerik:GridBoundColumn DataField="DAYOFWEEK" HeaderText="Day" UniqueName="DAYOFWEEK">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="90" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="90" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="90" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn DataField="WORKDATE" DataType="System.DateTime" HeaderText="Date"
                        UniqueName="ColDayDisplay">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="225" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="225" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="225" />
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButtonDisplay" runat="server" CommandName="OpenTimesheet"
                                CommandArgument='<%# CType(Eval("WORKDATE"), Date).ToShortDateString() %>' Text='<%# CType(Eval("WORKDATE"), Date).ToLongDateString() %>'>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="STANDARD_HRS" HeaderText="Standard Hours" UniqueName="STANDARD_HRS"
                        DataFormatString="{0:#,##0.00}">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="HOURS_WORKED" HeaderText="Hours Worked" UniqueName="HOURS_WORKED"
                        DataFormatString="{0:#,##0.00}">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="VARIANCE" HeaderText="Variance" UniqueName="VARIANCE"
                        DataFormatString="{0:#,##0.00}">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                    </telerik:GridBoundColumn>
                </Columns>
                <ExpandCollapseColumn Visible="False">
                    <HeaderStyle Width="19px" />
                </ExpandCollapseColumn>
                <RowIndicatorColumn Visible="False">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
            </MasterTableView>
            <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
            <AlternatingItemStyle VerticalAlign="Top" />
        </telerik:RadGrid>
    </div>
    <div id="DivDeniedTime" runat="server">
        <h4 id="DeniedTimeHeader" runat="server">Denied Time</h4>
        <telerik:RadGrid ID="RadGridDeniedTime" runat="server" AllowPaging="false" AllowSorting="False"
            AutoGenerateColumns="False" GridLines="None" PageSize="20">
            <MasterTableView HorizontalAlign="Left">
                <GroupByExpressions>
                    <telerik:GridGroupByExpression>
                        <SelectFields>
                            <telerik:GridGroupByField FieldName="WEEKOFDATE" HeaderText="Week Of" FormatString="{0:d}"
                                SortOrder="None" />
                        </SelectFields>
                        <GroupByFields>
                            <telerik:GridGroupByField FieldName="WEEKOFDATE" SortOrder="None" />
                        </GroupByFields>
                    </telerik:GridGroupByExpression>
                </GroupByExpressions>
                <Columns>
                    <telerik:GridBoundColumn DataField="DAYOFWEEK" HeaderText="Day" UniqueName="DAYOFWEEK">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="90" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="90" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="90" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn DataField="EMP_DATE" DataType="System.DateTime" HeaderText="Date"
                        UniqueName="ColDayDisplay">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="225" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="225" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="225" />
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButtonDisplay" runat="server" CommandName="OpenTimesheet"
                                CommandArgument='<%# CType(Eval("EMP_DATE"), Date).ToShortDateString() %>' Text='<%# CType(Eval("EMP_DATE"), Date).ToLongDateString() %>'>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="EMP_DTL_HRS" HeaderText="Employee Hours" UniqueName="EMP_DTL_HRS"
                        DataFormatString="{0:#,##0.00}">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="100" />
                    </telerik:GridBoundColumn>
                </Columns>
                <ExpandCollapseColumn Visible="False">
                    <HeaderStyle Width="19px" />
                </ExpandCollapseColumn>
                <RowIndicatorColumn Visible="False">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
            </MasterTableView>
            <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
            <AlternatingItemStyle VerticalAlign="Top" />
        </telerik:RadGrid>
    </div>
</asp:Content>