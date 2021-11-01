<%@ Page AutoEventWireup="false" CodeBehind="DashboardClientTime.aspx.vb" Inherits="Webvantage.DashboardClientTime"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Dashboard" %>

<asp:Content ID="ContentDashboard" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function StopPropagation(e) {
                if (!e) {
                    e = window.event;
                }

                e.cancelBubble = true;
            }

        </script>
    </telerik:RadScriptBlock>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="left">
                                <table align="left" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" valign="top" width="5%">
                                            <telerik:RadToolBar ID="RadToolbarData" runat="server"  
                                                AutoPostBack="True" Width="100%">
                                                <Items>
                                                </Items>
                                            </telerik:RadToolBar>
                                        </td>
                                        <td align="left" valign="top" width="45%">
                                            <telerik:RadToolBar ID="RadToolbarDashProject" runat="server" 
                                                 AutoPostBack="True" Width="100%">
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
                                            <telerik:RadToolBar ID="RadToolbarPE" runat="server"  
                                                Width="100%">
                                                <Items>
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                    <telerik:RadToolBarButton runat="server">
                                                        <ItemTemplate>
                                                            &nbsp;Summary Level:
                                                            <telerik:RadComboBox ID="DropDownListLevel" runat="server" AutoPostBack="true" SkinID="RadComboBoxText25" >
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
                                        <td align="left" valign="top" colspan="3">
                                            <telerik:RadToolBar ID="RadToolbarNav" runat="server"  
                                                AutoPostBack="True" Width="100%">
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

        </style>
        
        <div style="margin-top: 20px; margin-bottom: 20px;">
            <div class="chart-box">
                <div>
                    <div class="chart-box-label"><asp:Label ID="LabelProject" runat="server" Text="Actual Hours"></asp:Label></div>
                    <div>
                        <telerik:RadHtmlChart ID="RadHtmlChartHoursPieChart" runat="server">

                        </telerik:RadHtmlChart>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <div class="chart-box">
                <div>
                    <div class="chart-box-label"><asp:Label ID="LabelByLevel" runat="server" Text="Actual Dollars"></asp:Label></div>
                    <div>
                        <telerik:RadHtmlChart ID="RadHtmlChartDollarsPieChart" runat="server">

                        </telerik:RadHtmlChart>
                    </div>
                </div>
            </div>
        </div>

                </ContentTemplate>
            </asp:UpdatePanel>
    
    <script type="text/javascript">
        $(window).resize(function () {
            $('[data-role=chart]').each(function () {
                $find($(this).attr('id')).get_kendoWidget().resize();
            });
        });
    </script>

</asp:Content>
