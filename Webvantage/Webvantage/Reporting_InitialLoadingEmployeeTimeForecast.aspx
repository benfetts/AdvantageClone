<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_InitialLoadingEmployeeTimeForecast.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.Reporting_InitialLoadingEmployeeTimeForecast"
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
    <div style="margin-top: 10px;" class="style-fixes">
        <div class="form-layout label-left label-l">
            <telerik:RadTabStrip ID="RadTabStripTaskCalendar" runat="server" AutoPostBack="true" MultiPageID="RadMultiPageCalendar"
                Orientation="HorizontalTop" CausesValidation="false"
                Width="100%">
                <Tabs>
                    <telerik:RadTab Text="Options" PageViewID="RadPageViewOptions" Value="0" Selected="true">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="RadMultiPageCalendar" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="RadPageViewOptions" runat="server">
                    <div class="form-layout label-left label-l">
                        <ul>
                            <li><asp:Label id="LabelStartingPostPeriod" runat="server" Text="Post Period:" /></li>
                            <li><telerik:RadComboBox ID="RadComboBoxStart" runat="server" AutoPostBack="false" SkinID="RadComboBoxPostPeriod"></telerik:RadComboBox></li>
                        </ul>
                        <ul>
                            <li><asp:Label id="LabelEmployee" runat="server" Text="Employee:" /></li>
                            <li><telerik:RadComboBox ID="RadComboBoxEmployees" runat="server" AutoPostBack="false" SkinID="RadComboBoxEmployees"></telerik:RadComboBox></li>
                        </ul>
                        <ul>
                            <li><asp:Label id="LabelOffice" runat="server" Text="Office:" /></li>
                            <li><telerik:RadComboBox ID="RadComboBoxOffices" runat="server" AutoPostBack="false" SkinID="RadComboBoxOffices"></telerik:RadComboBox></li>
                        </ul>
                    </div>        
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </div>
    </div>
    
    <br />
</asp:Content>
