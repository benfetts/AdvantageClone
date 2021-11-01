<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_InitialLoadingJobWriteOff.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.Reporting_InitialLoadingJobWriteOff"
    Title="Set Initial Criteria" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlockRadWindow" runat="server">
        <script type="text/javascript">
            function returnValue() {
                //Get a reference to the parent (MDI) page 
                var oWnd = GetRadWindow();
                //get a reference to the second RadWindow
                var CallingWindowName = 'Create';
                var CallingWindow = oWnd.get_windowManager().getWindowByName(CallingWindowName);
                // Get a reference to the first RadWindow's content
                var CallingWindowContent = CallingWindow.get_contentFrame().contentWindow;
                //Call the predefined function in Dialog1
                //alert(CallingWindowName + '\n' + CallingWindow + '\n');
                CallingWindowContent.ReloadColumns(oWnd);
                //Close the second RadWindow
                oWnd.close();
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadToolBar ID="RadToolBarDynamicReportInitialLoading" runat="server" AutoPostBack="true"
        Width="100%">
        <Items>
            <telerik:RadToolBarButton ID="RadToolBarSeparatorFirstSeparator" runat="server" IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonOK" runat="server"
                Text="OK" Value="OK" CommandName="OK" ToolTip="OK" />
            <telerik:RadToolBarButton ID="RadToolBarSeparatorSecondSeparator" runat="server"
                IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonCancel" runat="server" SkinID="RadToolBarButtonCancel"
                Text="Cancel" Value="Cancel" CommandName="Cancel" ToolTip="Cancel" />
            <telerik:RadToolBarButton ID="RadToolBarSeparatorThirdSeparator" runat="server" IsSeparator="true" />
        </Items>
    </telerik:RadToolBar>
    <div style="margin-top: 10px;">
        <div class="form-layout label-left label-l">
            <ul>
                <li>Starting Post Period:</li>
                <li><telerik:RadComboBox ID="RadComboBoxStart" runat="server" AutoPostBack="false" SkinID="RadComboBoxPostPeriod"></telerik:RadComboBox></li>
                <li style="margin-left: 20px;"><telerik:RadButton ID="RadButtonYTD" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="YTD" Width="70"></telerik:RadButton></li>
                <li><telerik:RadButton ID="RadButton1Year" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="1 Year" Width="70"></telerik:RadButton></li>
                <li><telerik:RadButton ID="RadButton2YTD" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="2 YTD" Width="70"></telerik:RadButton></li>
            </ul>
            <ul>
                <li>Ending Post Period:</li>
                <li><telerik:RadComboBox ID="RadComboBoxEnd" runat="server" AutoPostBack="false" SkinID="RadComboBoxPostPeriod"></telerik:RadComboBox></li>
                <li style="margin-left: 20px;"><telerik:RadButton ID="RadButtonMTD" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="MTD" Width="70"></telerik:RadButton></li>
                <li><telerik:RadButton ID="RadButton2Years" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="2 Year" Width="70"></telerik:RadButton></li>
            </ul>
        </div>
        <div style="margin-top: 10px;">
            <fieldset id="Fieldset1" runat="server">
                <legend>Include Options</legend>
                <div class="grid-container">
                    <div class="grid-col-1-4"><asp:CheckBox id="CheckBoxEmployeeTime" runat="server" Text="Employee Time" /></div>
                    <div class="grid-col-1-4"><asp:CheckBox id="CheckBoxVendor" runat="server" Text="Vendor" /></div>
                    <div class="grid-col-1-4"><asp:CheckBox id="CheckBoxIncomeOnly" runat="server" Text="Income Only" /></div>
                    <div class="grid-col-1-4">&nbsp;</div>
                </div>
            </fieldset>
        </div>
        <div style="margin-top: 10px;">
            <fieldset id="FieldsetGroupBy" runat="server">
                <legend>Group By</legend>
                <div class="grid-container">
                    <div class="grid-col-1-4"><asp:CheckBox id="CheckBoxGroupByComponent" runat="server" Text="Component" /></div>
                    <div class="grid-col-1-4"></div>
                    <div class="grid-col-1-4"></div>
                    <div class="grid-col-1-4"></div>
                </div>
            </fieldset>
        </div>
    </div>
    <br />
</asp:Content>
