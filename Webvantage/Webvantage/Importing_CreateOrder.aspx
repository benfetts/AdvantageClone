<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" 
    CodeBehind="Importing_CreateOrder.aspx.vb" Inherits="Webvantage.Importing_CreateOrder" %>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
        <tr>
            <td>
                <telerik:RadToolBar ID="RadToolbarOptions" runat="server" AutoPostBack="True" Width="100%">
                    <Items>
                        <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonSave" runat="server" Text="" CommandName="Save" Value="Save" ToolTip="Save" SkinID="RadToolBarButtonSave" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonCancel" runat="server" Text="Cancel" CommandName="Cancel" Value="Cancel" ToolTip="Cancel" SkinID="RadToolBarButtonCancel" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonSecondSeparator" runat="server" IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonAssignID" runat="server" Text="Assign ID" CommandName="AssignID" Value="AssignID" ToolTip="Assign ID" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellpadding="0" cellspacing="5">
                    <tr id="TrDescription" runat="server">
                        <td>
                            <telerik:RadTextBox ID="RadTextBoxDescription" runat="server" Label="Order Description:" AutoPostBack="false" CssClass="RequiredInput" MaxLength="40"></telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadGrid ID="RadGridOrders" runat="server" AllowMultiRowSelection="false" AutoGenerateColumns="false" GridLines="None" Width="100%" ShowFooter="true" TabIndex="2">
                                <MasterTableView AutoGenerateColumns="false" Width="100%" EditMode="InPlace" ShowFooter="true" TabIndex="3" GroupLoadMode="Client">
                                    <GroupByExpressions>
                                        <telerik:GridGroupByExpression>
                                            <SelectFields>
                                                <telerik:GridGroupByField FieldAlias="MediaType" FieldName="MediaType" HeaderText="Media Type" />
                                            </SelectFields>
                                            <GroupByFields>
                                                <telerik:GridGroupByField FieldName="MediaType" SortOrder="Ascending" />
                                            </GroupByFields>
                                        </telerik:GridGroupByExpression>
                                    </GroupByExpressions>
                                    <Columns>
                                        <telerik:GridTemplateColumn DataField="OrderID" HeaderText="Order ID" UniqueName="GridTemplateColumnOrderID">
                                            <ItemStyle Width="50px" HorizontalAlign="Right" />
                                            <ItemTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxOrderID" runat="server" CssClass="RequiredInput" Width="50px">
                                                    <EnabledStyle HorizontalAlign="Right" />
                                                    <ReadOnlyStyle HorizontalAlign="Right" />
                                                    <FocusedStyle HorizontalAlign="Right" />
                                                    <NumberFormat DecimalDigits ="0" GroupSeparator=''/>
                                                </telerik:RadNumericTextBox>
                                                <asp:HiddenField ID="HiddenFieldKey" runat="server" Value="" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="LineNumber" HeaderText="Line Number" UniqueName="GridTemplateColumnLineNumber">
                                            <ItemStyle Width="50px" HorizontalAlign="Right" />
                                            <ItemTemplate>
                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxLineNumber" runat="server" CssClass="RequiredInput" Width="50px">
                                                    <EnabledStyle HorizontalAlign="Right" />
                                                    <ReadOnlyStyle HorizontalAlign="Right" />
                                                    <FocusedStyle HorizontalAlign="Right" />
                                                    <NumberFormat DecimalDigits ="0" GroupSeparator='' />
                                                </telerik:RadNumericTextBox>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="MediaType" HeaderText="" UniqueName="GridBoundColumnMediaType" Visible="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MediaPlanOrderDescription" HeaderText="Order Description" UniqueName="GridBoundColumnMediaPlanOrderDescription">
                                        </Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ClientCode" HeaderText="Client" UniqueName="GridBoundColumnClientCode"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="DivisionCode" HeaderText="Division" UniqueName="GridBoundColumnDivisionCode"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ProductCode" HeaderText="Product" UniqueName="GridBoundColumnProductCode"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="VendorCode" HeaderText="Vendor" UniqueName="GridBoundColumnVendorCode"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="StartDate" HeaderText="Start Date" UniqueName="GridBoundColumnStartDate" DataType="System.DateTime" DataFormatString="{0:d}" ></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EndDate" HeaderText="End Date" UniqueName="GridBoundColumnEndDate" DataType="System.DateTime" DataFormatString="{0:d}" ></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="NetGross" HeaderText="Net Gross" UniqueName="GridBoundColumnNetGross"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="NetRate" HeaderText="Net Rate" UniqueName="GridBoundColumnNetRate">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="GrossRate" HeaderText="Gross Rate" UniqueName="GridBoundColumnGrossRate">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TotalSpots" HeaderText="Quantity" UniqueName="GridBoundColumnTotalSpots">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CostType" HeaderText="Cost Type" UniqueName="GridBoundColumnCostType"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="SalesClassCode" HeaderText="Sales Class Code" UniqueName="GridBoundColumnSalesClassCode"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Cost" HeaderText="Cost" UniqueName="GridBoundColumnCost">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="NetCharge" HeaderText="Net Charge" UniqueName="GridBoundColumnNetCharge">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="AddAmount" HeaderText="Add Amount" UniqueName="GridBoundColumnAddAmount">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MarkupPercent" HeaderText="Markup Percent" UniqueName="GridBoundColumnMarkupPercent" DataType="System.Decimal" DataFormatString="{0:n3}">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CampaignCode" HeaderText="Campaign Code" UniqueName="GridBoundColumnCampaignCode"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MediaNetAmount" HeaderText="Media Net Amount" UniqueName="GridBoundColumnMediaNetAmount">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="RateType" HeaderText="Rate Type" UniqueName="GridBoundColumnRateType"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MediaPlanOrderComment" HeaderText="Media Plan Order Comment" UniqueName="GridBoundColumnMediaPlanOrderComment"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MediaPlanBuyer" HeaderText="Media Plan Buyer" UniqueName="GridBoundColumnMediaPlanBuyer"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MediaPlanMarketCode" HeaderText="Media Plan Market Code" UniqueName="GridBoundColumnMediaPlanMarketCode"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MediaPlanMarketDescription" HeaderText="Media Plan Market Description" UniqueName="GridBoundColumnMediaPlanMarketDescription"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MediaPlanAdSizeCode" HeaderText="Media Plan Ad Size Code" UniqueName="GridBoundColumnMediaPlanAdSizeCode"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MediaPlanAdSizeDescription" HeaderText="Media Plan Ad Size Description" UniqueName="GridBoundColumnMediaPlanAdSizeDescription"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MediaPlanAdNumber" HeaderText="Media Plan Ad Number" UniqueName="GridBoundColumnMediaPlanAdNumber"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MediaPlanHeadline" HeaderText="Media Plan Headline" UniqueName="GridBoundColumnMediaPlanHeadline"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MediaPlanIssue" HeaderText="Media Plan Issue" UniqueName="GridBoundColumnMediaPlanIssue"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MediaPlanInternetType" HeaderText="Media Plan Internet Type" UniqueName="GridBoundColumnMediaPlanInternetType"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MediaPlanPlacement" HeaderText="Media Plan Placement" UniqueName="GridBoundColumnMediaPlanPlacement"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MediaPlanOutOfHomeType" HeaderText="Media Plan Out Of Home Type" UniqueName="GridBoundColumnMediaPlanOutOfHomeType"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MediaPlanDaypart" HeaderText="Media Plan Daypart" UniqueName="GridBoundColumnMediaPlanDaypart"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MediaPlanStartTime" HeaderText="Media Plan Start Time" UniqueName="GridBoundColumnMediaPlanStartTime"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MediaPlanEndTime" HeaderText="Media Plan End Time" UniqueName="GridBoundColumnMediaPlanEndTime"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MediaPlanLength" HeaderText="Media Plan Length" UniqueName="GridBoundColumnMediaPlanLength"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MediaPlanProgramming" HeaderText="Media Plan Programming" UniqueName="GridBoundColumnMediaPlanProgramming"></Telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="MediaPlanNetworkCode" HeaderText="Media Plan Network Code" UniqueName="GridBoundColumnMediaPlanNetworkCode"></Telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn UniqueName="GridButtonColumnDelete" CommandName="Delete" ButtonType="ImageButton" ImageUrl="~/Images/Icons/Grey/256/delete.png" ButtonCssClass="icon-image" ConfirmText="Are you sure you want to delete?">
                                            
                                        </telerik:GridButtonColumn>
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings AllowExpandCollapse="true"></ClientSettings>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>
