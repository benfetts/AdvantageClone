<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="JobForecast_Print.aspx.vb" Inherits="Webvantage.JobForecast_Print" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlockHeader" runat="server">
        
        <script type="text/javascript">

            function overrideLocationDefaults(sender, args) {
                OpenRadWindow('', 'LocationOverride.aspx?Footer=0&App=' + <%= Webvantage.LocationOverride.OverrideFromApp.JobForecast %>, 250, 400, true, 100, null, true, '')
            }

        </script>

    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <div>
        <telerik:RadToolBar ID="RadToolBarPOPrintOptions" runat="server" AutoPostBack="True"
            Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonExportExcel" ID="RadToolBarButtonExportToExcel" runat="server" Value="ExportToExcel" ToolTip="Export to Excel"  />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" ToolTip="Save Settings" Value="Save" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>

    <div style="margin-top: 10px;">
        <div class="sub-header sub-header-color">
            Options
        </div>
        <div class="form-layout" style="margin-top: 10px;">
            <ul>
                <li>Location:</li>
                <li><telerik:RadComboBox ID="RadComboBoxLocation" runat="server" DataTextField="Name" DataValueField="ID" SkinID="RadComboBoxText40" AutoPostBack="true">
                    </telerik:RadComboBox></li>
                <li><telerik:RadButton ID="RadButtonOverrideLocation" runat="server" Text="..." AutoPostBack="false" OnClientClicked="overrideLocationDefaults"></telerik:RadButton></li>
            </ul>
        </div>
    </div>
</asp:Content>
