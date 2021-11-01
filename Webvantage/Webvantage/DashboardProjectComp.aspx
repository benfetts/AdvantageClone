<%@ Page AutoEventWireup="false" CodeBehind="DashboardProjectComp.aspx.vb" Inherits="Webvantage.DashboardProjectComp"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Dashboard" %>

<asp:Content ID="ContentDashboard" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript"><!--
            FusionCharts.printManager.enabled(true);
            //        FusionCharts.addEventListener(
            //          FusionChartsEvents.PrintReadyStateChange,
            //          function (identifier, parameter) {
            //              if (parameter.ready) {
            //                  radalert("Chart is now ready for printing.");
            //              }
            //          });
    // -->
        </script>
    </telerik:RadScriptBlock>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <div style="max-width: 97%; width: 100%; padding: 0; margin-left: auto; margin-right: auto;">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left">
                                            <table align="left" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="left" valign="top" width="5%">
                                                        <telerik:RadToolBar ID="RadToolbarData" runat="server" AutoPostBack="True" Width="100%">
                                                            <Items>
                                                            </Items>
                                                        </telerik:RadToolBar>
                                                    </td>
                                                    <td align="left" valign="top" width="45%">
                                                        <telerik:RadToolBar ID="RadToolbarDashProject" runat="server" AutoPostBack="True"
                                                            Width="100%">
                                                            <Items>
                                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                                <telerik:RadToolBarButton Text="Year to Date" Value="YeartoDate" ToolTip="Calculate Data year to Date"
                                                                    CheckOnClick="true" Checked="true" AllowSelfUnCheck="true" />
                                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                                <telerik:RadToolBarButton Text="Month" Value="Month" ToolTip="Calculate Data by Month"
                                                                    CheckOnClick="true" Checked="true" AllowSelfUnCheck="true" />
                                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                                <telerik:RadToolBarButton runat="server">
                                                                    <ItemTemplate>
                                                                        &nbsp;Month:
                                                                        <telerik:RadComboBox ID="DropDownListMonth" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard">
                                                                        </telerik:RadComboBox>
                                                                        &nbsp;
                                                                    </ItemTemplate>
                                                                </telerik:RadToolBarButton>
                                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                                <telerik:RadToolBarButton runat="server">
                                                                    <ItemTemplate>
                                                                        &nbsp;Week:
                                                                        <telerik:RadComboBox ID="DropDownListWeek" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard">
                                                                        </telerik:RadComboBox>
                                                                        &nbsp;
                                                                    </ItemTemplate>
                                                                </telerik:RadToolBarButton>
                                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                            </Items>
                                                        </telerik:RadToolBar>
                                                    </td>
                                                    <td align="left" valign="top" width="50%">
                                                        <telerik:RadToolBar ID="RadToolbarPE" runat="server" Width="100%">
                                                            <Items>
                                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                                <telerik:RadToolBarButton runat="server">
                                                                    <ItemTemplate>
                                                                        &nbsp;Summary Level:
                                                                        <telerik:RadComboBox ID="DropDownListLevel" runat="server" AutoPostBack="true" Width="190" SkinID="RadComboBoxStandard">
                                                                            <Items>
                                                                             <telerik:RadComboBoxItem Value="C" Text="Client"></telerik:RadComboBoxItem>
                                                                            <telerik:RadComboBoxItem Value="CD" Text="Client/Division"></telerik:RadComboBoxItem>
                                                                            <telerik:RadComboBoxItem Value="CDP" Text="Client/Division/Product"></telerik:RadComboBoxItem>
                                                                            <telerik:RadComboBoxItem Value="AE" Text="Account Executive"></telerik:RadComboBoxItem>
                                                                            <telerik:RadComboBoxItem Value="dept" Text="Department"></telerik:RadComboBoxItem>
                                                                            <telerik:RadComboBoxItem Value="SC" Text="Sales Class"></telerik:RadComboBoxItem>
                                                                            <telerik:RadComboBoxItem Value="JT" Text="Job Type"></telerik:RadComboBoxItem>
                                                                           </Items>
                                                                        </telerik:RadComboBox>
                                                                        &nbsp;
                                                                    </ItemTemplate>
                                                                </telerik:RadToolBarButton>
                                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                                <telerik:RadToolBarButton Text="" Value="Print" SkinID="RadToolBarButtonPrint" />
                                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                                <telerik:RadToolBarButton SkinID="RadToolBarButtonExportExcel" ToolTip="Export to Excel" Value="Export" />
                                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                                <telerik:RadToolBarButton runat="server">
                                                                    <ItemTemplate>
                                                                        &nbsp;<asp:CheckBox ID="CheckBoxPrintAll" runat="server" Text="Print All" AutoPostBack="true" />&nbsp;
                                                                    </ItemTemplate>
                                                                </telerik:RadToolBarButton>
                                                            </Items>
                                                        </telerik:RadToolBar>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" valign="top" colspan="2">
                                                        <telerik:RadToolBar ID="RadToolbarProject" runat="server" AutoPostBack="True" Width="100%">
                                                            <Items>
                                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                                <telerik:RadToolBarButton Text="Projects Created" CheckOnClick="true" Checked="true"
                                                                    AllowSelfUnCheck="true" Value="Created" />
                                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                                <telerik:RadToolBarButton Text="Projects Completed" CheckOnClick="true" Checked="true"
                                                                    AllowSelfUnCheck="true" Value="Completed" />
                                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                                <telerik:RadToolBarButton Text="Projects Due" CheckOnClick="true" Checked="true"
                                                                    AllowSelfUnCheck="true" Value="Due" />
                                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                                <telerik:RadToolBarButton Text="Projects Pending" CheckOnClick="true" Checked="true"
                                                                    AllowSelfUnCheck="true" Value="Pending" />
                                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                                <telerik:RadToolBarButton Text="Projects Cancelled" CheckOnClick="true" Checked="true"
                                                                    AllowSelfUnCheck="true" Value="Cancelled" />
                                                            </Items>
                                                        </telerik:RadToolBar>
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <telerik:RadToolBar ID="RadToolbarNav" runat="server" AutoPostBack="True" Width="100%">
                                                            <Items>
                                                                <telerik:RadToolBarButton Text="Selection" Value="Filter" ToolTip="Selection" />
                                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                                <telerik:RadToolBarButton Text="Summary" Value="Summary" ToolTip="Summary" />
                                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                                <telerik:RadToolBarButton Text="Year" Value="Year" ToolTip="Year" />
                                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                                <telerik:RadToolBarButton Text="Month" Value="Month" ToolTip="Month" />
                                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                                <telerik:RadToolBarButton Text="Week" Value="Week" ToolTip="Week" />
                                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                                <telerik:RadToolBarButton Text="Detail" Value="ProjectDetail" ToolTip="Detail" />
                                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                            </Items>
                                                        </telerik:RadToolBar>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
        </div>
        

        <style type="text/css">
            .chart-box {
                width: 100%;
                padding: 10px;
                float: left;
                box-sizing: border-box;
                -moz-box-sizing: border-box;
                -webkit-box-sizing: border-box;
            }
            .chart-box > div {
                border: 1px solid #ccc;
                padding: 5px;
                position: relative;
                padding-top: 10px;
            }
            .chart-box .chart-box-label {
                font-weight: bold; 
                position:absolute; 
                top: -10px; 
                left: 10px; 
                background: white; 
                padding-left: 5px; 
                padding-right: 5px;
            }
            .chart-box g text {
                cursor: pointer;
            }
            .chart-box svg g:nth-child(2){
                cursor: pointer;
            }
        </style>
        <div class="telerik-aqua-body" >
             <div style="margin-top: 20px; margin-bottom: 20px;">
            <div class="chart-box">
                <div>
                    <div class="chart-box-label"><asp:Label ID="LabelByLevel" runat="server" Text="Projects"></asp:Label></div>
                    <div id="chartPH" style="height: 400px;">
                        <telerik:RadHtmlChart ID="RadHtmlChartPieSelection" runat="server">
                            <ClientEvents OnSeriesClick='RadHtmlChartOnSeriesClick' />
                        </telerik:RadHtmlChart>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <telerik:RadGrid ID="RadGridComps" runat="server" AutoGenerateColumns="false" GridLines="None"
                EnableEmbeddedSkins="True" HorizontalAlign="Center" AllowSorting="true" ShowFooter="true">
                <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                    <Selecting AllowRowSelect="True" />
                </ClientSettings>
                <MasterTableView HorizontalAlign="center" UseAllDataFields="true" DataKeyNames="CODE">
                </MasterTableView>
            </telerik:RadGrid>
        </div>
        </div>
       

                </ContentTemplate>
            </asp:UpdatePanel>

    <telerik:RadScriptBlock ID="rcb1" runat="server">
        <script type="text/javascript">
            function RadHtmlChartOnSeriesClick(e) {
                var attributes = e.sender.element[0].attributes;
                var url = attributes.SERIES_CLICK_URL.value;
                var dataItem = e.dataItem;
                var fields = attributes['FIELDS'].value.split(",");
                for (var i = 0; i < fields.length; i++) {
                    if (url.indexOf('[' + fields[i] + ']') > -1) {
                        var fieldVal = dataItem[fields[i]];
                        fieldVal = fieldVal.toString().replace("&", "andcode");
                        url = url.replace('[' + fields[i] + ']', fieldVal);
                    }
                }
                window.location.assign(url);
            }
            $(window).resize(function () {
                $find('<%= RadHtmlChartPieSelection.ClientID%>').get_kendoWidget().resize();
            });
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
