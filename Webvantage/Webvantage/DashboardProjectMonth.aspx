<%@ Page AutoEventWireup="false" CodeBehind="DashboardProjectMonth.aspx.vb" Inherits="Webvantage.DashboardProjectMonth"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Dashboard" %>

<asp:Content ID="ContentDashboard" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
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
                                            </Items>
                                        </telerik:RadToolBar>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="2">
                                        <telerik:RadToolBar ID="RadToolbarProject" runat="server"  
                                            AutoPostBack="True" Width="100%">
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
                                                <telerik:RadToolBarButton Text="Detail" Value="Detail" ToolTip="Detail" />
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
        <tr>
            <td valign="top">
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td colspan="4" align="center">
                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="center" valign="top" colspan="2">
                                        <asp:PlaceHolder ID="PlaceHolderGraph" runat="server"></asp:PlaceHolder>
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
        svg > g > g:nth-child(3) > g:nth-child(4) > g {
            cursor: pointer;
        }
    </style>

    <telerik:RadScriptBlock ID="RadScriptBlockFooter" runat="server">
        <script type="text/javascript">
            function RadHtmlChartOnSeriesClick(e) {
                var dataItem = e.dataItem;
                var url = e.sender.element[0].attributes['SERIES_CLICK_URL'].value;
                var fields = e.sender.element[0].attributes['FIELDS'].value.split(",");
                for (var i = 0; i < fields.length; i++) {
                    if (url.indexOf('[' + fields[i] + ']') > -1) {
                        url = url.replace('[' + fields[i] + ']', dataItem[fields[i]]);
                    }
                }
                window.location.assign(url);
            }
        </script>
    </telerik:RadScriptBlock>

</asp:Content>
