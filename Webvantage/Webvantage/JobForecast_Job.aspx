<%@ Page Title="Job Forecast" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="JobForecast_Job.aspx.vb" Inherits="Webvantage.JobForecast_Job" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="ContentJobForecastHead" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    
    <telerik:RadScriptBlock ID="RadScriptBlockJobForecast" runat="server">

        <script type="text/javascript">

            function findGridDataItem(rntb){
                var itemID = $(rntb.get_element()).closest('tr')[0].id;
                var dataItems = $find('<%= RadGridJobForecastJobDetails.ClientID %>').get_masterTableView().get_dataItems();
                for (var i = 0; i < dataItems.length; i++) {
                    if (dataItems[i].get_element().id === itemID) {
                        return dataItems[i];
                    }
                }
            }

            function updateAmount(sender, args) {
                var vals = sender.get_id().split("_");
                var gridColName = vals[vals.length - 1];
                var a = findGridDataItem(sender);
                var dataItem = findGridDataItem(sender);
                var jobForecastJobID = dataItem.getDataKeyValue('JobForecastJobID');
                var gridCol = $find('<%= RadGridJobForecastJobDetails.ClientID%>').get_masterTableView().getColumnByUniqueName(gridColName);
                if (gridCol) {
                    var dataField = gridCol.get_dataField();
                    var postPeriod = dataItem.getDataKeyValue('PostPeriodCode');
                    var billOrRev = dataField.indexOf('Billing') > -1 ? 0 : 1;
                    var data = {
                        JobForecastJobID: jobForecastJobID,
                        PostPeriodCode: postPeriod,
                        Amount: !isNaN(parseFloat(sender.get_value())) ? parseFloat(sender.get_value()) : null,
                        BillingOrRevenue: billOrRev
                    };
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: '<%= Webvantage.Controllers.FinanceAndAccounting.JobForecastController.BaseRoute %>UpdatePostPeriodAmount',
                        dataType: "json",
                        data: JSON.stringify(data),
                        success: function (result) {
                            if (result.Status === 400) { //failed
                                if (result.Message) {
                                    ShowMessage(result.Message);
                                } else {
                                    ShowMessage('Error updating amount!');
                                }
                                $find('<%= RadGridJobForecastJobDetails.ClientID%>').get_masterTableView().rebind();
                            }
                            //setDataItemBudget(dataItem, result.Budget);
                        },
                        error: function (msg) {
                            ShowMessage('Error updating amount!');
                        }
                    });
                }
            }
                        
        </script>
        
    </telerik:RadScriptBlock>

</asp:Content>

<asp:Content ID="ContentJobForecast" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
        <telerik:RadToolBar ID="RadToolBarJobForecast" runat="server" AutoPostBack="true"
        Width="100%" Visible="true">
        <Items>
            <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonNew" runat="server" SkinID="RadToolBarButtonNew"
                Text="New" Value="New" ToolTip="Create new Job Forecast" />
            <telerik:RadToolBarButton ID="RadToolBarButtonSecondSeparator" runat="server" IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonSettings" runat="server" SkinID="RadToolBarButtonSettings"
                Text="Settings" Value="Settings" ToolTip="Open Job Forecast Settings" Visible="false" />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolbarButtonRefresh" runat="server" SkinID="RadToolBarButtonRefresh" Value="refresh" ToolTip="Refresh" />
            <telerik:RadToolBarButton ID="RadToolBarButtonThirdSeparator" runat="server" IsSeparator="true" Visible="false" />
        </Items>
    </telerik:RadToolBar>
    </div>

    <div class="telerik-aqua-body">
            <div>
                <telerik:RadGrid ID="RadGridJobForecastJobDetails" runat="server" AllowPaging="false"
                    AllowSorting="true" GridLines="None" PageSize="10" EnableEmbeddedSkins="True"
                    ShowFooter="false" AutoGenerateColumns="false" Width="500px" PagerStyle-Visible="false"  
                    AllowMultiRowEdit="true" Visible="true">
                    <MasterTableView CommandItemDisplay="None" AllowSorting="true" EditMode="InPlace" GroupLoadMode="Client" Width="100%" 
                        DataKeyNames="JobForecastRevisionID, ID, JobForecastJobID" ClientDataKeyNames="JobForecastJobID, PostPeriodCode" ShowGroupFooter="false">
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnViewJobForecast">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonView" runat="server" SkinID="ImageButtonViewWhite" ToolTip="Click to View" CommandName="View" TabIndex="-1" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnPostPeriod" HeaderText="Post Period" DataField="PostPeriodCode" ReadOnly="true"></telerik:GridBoundColumn>
                            <telerik:GridNumericColumn UniqueName="GridNumericColumnBillingAmount" HeaderText="Billing" DataField="BillingAmount" Aggregate="Sum" FooterAggregateFormatString="{0:N2}">
                            </telerik:GridNumericColumn>
                            <telerik:GridNumericColumn UniqueName="GridNumericColumnRevenueAmount" HeaderText="Revenue" DataField="RevenueAmount"></telerik:GridNumericColumn>
                        </Columns>
                        <GroupByExpressions>
                            <telerik:GridGroupByExpression>
                                <SelectFields>
                                    <telerik:GridGroupByField FieldName="JobForecastDescription" FieldAlias="JobForecastDescription"  />
                                    <telerik:GridGroupByField FieldName="RevisionNumber" FieldAlias="RevisionNumber" />
                                </SelectFields>
                                <GroupByFields>
                                    <telerik:GridGroupByField FieldName="GroupOrder" SortOrder="Ascending" />
                                    <telerik:GridGroupByField FieldName="JobForecastRevisionID" SortOrder="None"/>
                                </GroupByFields>
                            </telerik:GridGroupByExpression>
                        </GroupByExpressions>
                        <GroupHeaderTemplate>
                        
                        </GroupHeaderTemplate>
                        <RowIndicatorColumn>
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn>
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                    </MasterTableView>
                    <ClientSettings>
                        <ClientEvents OnGridCreated="OnGridCreated" />
                    </ClientSettings>
                </telerik:RadGrid>
            </div>
    
        <script type="text/javascript">
            function OnGridCreated() {
                var rowCount = 0;
                $('.rgEditRow').each(function () {
                    var cssClass = 'rgRow';
                    if (rowCount % 2) {
                        cssClass = 'rgAltRow';
                    }
                    $(this).removeClass('rgEditRow').addClass(cssClass);
                    rowCount += 1;
                });
            };
        </script>
    </div>


</asp:Content>
