<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Reporting_DynamicReportEdit.aspx.vb" Inherits="Webvantage.Reporting_DynamicReportEdit" Title="Report Writer" %>

<asp:Content ID="ContentDynamicReports" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    <script type="text/javascript">

        var prm = Sys.WebForms.PageRequestManager.getInstance();
		prm.add_initializeRequest(prm_InitializeRequest);
		prm.add_endRequest(prm_EndRequest);
		function prm_InitializeRequest(sender, args) {
			OpenLoadingPanel();
		}
		function prm_EndRequest(sender, args) {
			CloseLoadingPanel();
		}


        function OpenLoadingPanel() {

            //alert('Test Alert');

            if (cinPanel) {
                cinPanel.Show();
            
            }
		}

		function CloseLoadingPanel() {
			if (cinPanel) {
				cinPanel.Hide();
				// ???? How can I know if call or not this event for let IE open the "open/save dialog"????
				//if (exportInitiated) {
				//	//btn.DoClick();
				//	exportInitiated = false;
				//}
			}
        }

        function Refresh() {            
            setTimeout(function () {
               __doPostBack('onclick#Refresh', 'Refresh');
            }, 0);             

            //cinPanel.Show();
     
        }
        function ReloadColumns(radWindowCaller) {
            setTimeout(function () {
                __doPostBack('onclick#ReloadColumns', 'ReloadColumns');
            }, 0);              

            //cinPanel.Show();
   
        };
        function RefreshGrid(radWindowCaller) {
            setTimeout(function () {
                __doPostBack('onclick#Refresh', 'Refresh');
            }, 0);             

            //cinPanel.Show();
   
        };
        function RefreshPage(radWindowCaller) {
            setTimeout(function () {                
            __doPostBack('onclick#Refresh', 'Refresh');
            }, 0);             

            //cinPanel.Show();
     
        };
        function SaveFromPopUp(radWindowCaller) {
            setTimeout(function () {
                 __doPostBack('onclick#Save', 'Save');
            }, 0);              

            //cinPanel.Show();
   
        };
        function RealPostBack(eventTarget, eventArgument) {
            setTimeout(function () {
                __doPostBack(eventTarget, eventArgument);
            }, 0);               

            //cinPanel.Show();
   
        };
        function HidePopUpWindows(radWindowCaller) {
            setTimeout(function () {                
            __doPostBack('onclick#Refresh', 'HidePopups');
            }, 0);               

            //cinPanel.Show();
   
        };
        function OnClientClose(sender, EventArgs) {
            setTimeout(function () {
                __doPostBack('onclick#Refresh', 'Refresh');
            }, 0);             

            //cinPanel.Show();
   
        };
        function onCellClick(rowIndex, fieldName) {
            ReportGrid.PerformCallback(rowIndex + "|" + fieldName);
        };
        var resizeDashboardTimeout;
        function OnClientValueChanged(e) {
            clearTimeout(resizeDashboardTimeout);
            resizeDashboardTimeout = setTimeout(function () {
                resizeDashboard();
            }, 500);
        };
        function initDashboard() {
            var wrapper = $('#dashboardWrap');
            var wrapperWidth = $('#dashboardWrap').width();
            var windowWidth = $(window).width();
            var wrapperHeight = $('#dashboardWrap').height();
            var windowHeight = $(window).height();
            wrapperData = {
                initialWidth: function () {
                    return $(window).width() - (windowWidth - wrapperWidth);
                },
                initialHeight: function () {
                    return $(window).height() - (windowHeight - wrapperHeight);
                }
            };
            $.data(wrapper[0], 'wrapper', wrapperData);
        };
        function resizeDashboard() {
            var wrapper = $('#dashboardWrap');
            var wrapperData = wrapper.data('wrapper');
            if (wrapperData === undefined) {
                initDashboard();
                wrapperData = wrapper.data('wrapper');
            }
            var currentWidthValue = $find("<%= DashboardWidthRadSlider.ClientID  %>").get_value();
            if (wrapperData) {
                var initialWidth = wrapperData.initialWidth();
                var newWidth = ((initialWidth / 100) * currentWidthValue) + initialWidth;
                $('#dashboardWrap').width(newWidth);
                ReportDashboard.AdjustControl();
            }
        };
        $(window).resize(function () {
            clearTimeout(resizeDashboardTimeout);
            resizeDashboardTimeout = setTimeout(function () {
                resizeDashboard();
            }, 200);
        });
        $(document).ready(function () {

            console.log('document ready');

            ////cinPanel.Show();

            ShowProgress(false);

        })
    </script>
    <%--<dx:ASPxGlobalEvents runat="server" ID="ClientGlobalEvents">  
        <ClientSideEvents BeginCallback="function(s, e) { //cinPanel.Show(); }" EndCallback="function(s, e) { cinPanel.Hide(); }" />  
    </dx:ASPxGlobalEvents> --%>
    <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="cinPanel" ContainerElementID="divParentDiv" Modal="true" Visible="true">
    </dx:ASPxLoadingPanel>
    <div class="telerik-aqua-body" style="margin-top: 5px!important" id="divParentDiv">
        
            <div style="padding: 10px 0px 0px 0px;">
                <telerik:RadTabStrip ID="RadTabStrip" runat="server" MultiPageID="RadMultiPage"
                    SelectedIndex="0" Align="Left" Width="100%">
                    <Tabs>
                        <telerik:RadTab Text="Options">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Printing">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <div class="more-info">
                    Report:
                    <telerik:RadComboBox ID="RadComboBoxDynamicReport" runat="server" AutoPostBack="true" Enabled="false" Width="500">
                    </telerik:RadComboBox>
                </div>
                <telerik:RadMultiPage ID="RadMultiPage" runat="server" SelectedIndex="0" Width="100%">
                    <telerik:RadPageView ID="RadPageViewOptions" runat="server">                        
                            <div class="no-float-menu">
                                <telerik:RadToolBar ID="RadToolBarOptions" runat="server" AutoPostBack="true" Width="100%">
                                    <Items>
                                        <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonSave" runat="server" SkinID="RadToolBarButtonSave"
                                            Text="" Value="Save" CommandName="Save" ToolTip="Save Template" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonFifthSeparator" runat="server" IsSeparator="true" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonSaveAs" runat="server" Text="Save As"
                                            Value="SaveAs" CommandName="SaveAs" ToolTip="Save Template As..." />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonSixthSeparator" runat="server" IsSeparator="true" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonCustomizeColumns" runat="server" Text="Customize Columns"
                                            Value="CustomizeColumns" CommandName="CustomizeColumns" ToolTip="Customize Columns" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonSeventhSeparator" runat="server" IsSeparator="true" />

                                        <telerik:RadToolBarButton ID="RadToolBarButtonShowViewCaption" runat="server" CheckOnClick="true"
                                            Text="Show View Caption" Value="ShowViewCaption" CommandName="ShowViewCaption"
                                            ToolTip="Show View Caption" AllowSelfUnCheck="true" Group="1" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonEightSeparator" runat="server" IsSeparator="true" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonShowGroupByBox" runat="server" CheckOnClick="true"
                                            Text="Show Group By Box" Value="ShowGroupByBox" CommandName="ShowGroupByBox"
                                            ToolTip="Show Group By Box" AllowSelfUnCheck="true" Group="2" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonNinthSeparator" runat="server" IsSeparator="true" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonShowFilterEditor" runat="server" Text="Show Filter Editor"
                                            Value="ShowFilterEditor" CommandName="ShowFilterEditor" ToolTip="Show Filter Editor" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonTenthSeparator" runat="server" IsSeparator="true" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonShowAutoFilterRow" runat="server" CheckOnClick="true"
                                            Text="Show Auto Filter Row" Value="ShowAutoFilterRow" CommandName="ShowAutoFilterRow"
                                            ToolTip="Show Auto Filter Row" AllowSelfUnCheck="true" Group="4" />

                                        <telerik:RadToolBarButton ID="RadToolBarButtonEleventhSeparator" runat="server" IsSeparator="true" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonLoadData" runat="server" Text="Load Data" Value="LoadData" CommandName="LoadData" ToolTip="Load Data" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonTwelvthSeparator" runat="server" IsSeparator="true" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonRefresh" runat="server" Text="Refresh Report Data" Value="Refresh" CommandName="Refresh" ToolTip="Refresh Report Data" />
                                        <telerik:RadToolBarButton ID="RadToolBarButton1" runat="server" IsSeparator="true" />
                                        <telerik:RadToolBarButton Value="RadToolBarButtonLabelUpdate">
                                            <ItemTemplate>
                                                &nbsp;<asp:Label ID="LabelUpdate" runat="server" Font-Size="Small"></asp:Label>
                                            </ItemTemplate>
                                        </telerik:RadToolBarButton>
                                    </Items>
                                </telerik:RadToolBar>
                            </div>                       
                        
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageViewPrinting" runat="server">
                        <div class="no-float-menu">
                            <telerik:RadToolBar ID="RadToolBarPrinting" runat="server" AutoPostBack="true" Width="100%">
                                    <Items>
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintingFirstSeparator" runat="server"
                                            IsSeparator="true" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintToPDF" runat="server" Text="To PDF"
                                            Value="ToPDF" CommandName="ToPDF" ToolTip="Print To PDF" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintingSecondSeparator" runat="server"
                                            IsSeparator="true" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintToXLS" runat="server" Text="To XLS"
                                            Value="ToXLS" CommandName="ToXLS" ToolTip="Print To XLS" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintToXLSValue" runat="server" Text="To XLS (Value)"
                                            Value="ToXLSValue" CommandName="ToXLSValue" ToolTip="Print To XLS (Value)" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintingThirdSeparator" runat="server"
                                            IsSeparator="true" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintToXLSX" runat="server" Text="To XLSX"
                                            Value="ToXLSX" CommandName="ToXLSX" ToolTip="Print To XLSX" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintToXLSXValue" runat="server" Text="To XLSX (Value)"
                                            Value="ToXLSXValue" CommandName="ToXLSXValue" ToolTip="Print To XLSX (Value)" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintingFourthSeparator" runat="server"
                                            IsSeparator="true" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintToRTF" runat="server" Text="To RTF"
                                            Value="ToRTF" CommandName="ToRTF" ToolTip="Print To RTF" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintingFifthSeparator" runat="server"
                                            IsSeparator="true" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintToCSV" runat="server" Text="To CSV"
                                            Value="ToCSV" CommandName="ToCSV" ToolTip="Print To CSV" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintingSixthSeparator" runat="server"
                                            IsSeparator="true" />
                                    </Items>
                                </telerik:RadToolBar>
                        </div>
                        
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </div>
            <div style="padding: 10px 0px 0px 0px;">
                <telerik:RadTabStrip ID="RadTabStripReport" runat="server" MultiPageID="RadMultiPageReport"
                    AutoPostBack="false" SelectedIndex="0" Style="z-index: 1000;">
                    <Tabs>
                        <telerik:RadTab Text="Report" Selected="True">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Dashboard">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
            </div>
        <%--<dx:ASPxCallback ID="ASPxCallback1" runat="server" ClientInstanceName="Callback">
            <ClientSideEvents CallbackComplete="function(s, e) { alert('Hide'); cinPanel.Hide(); }" BeginCallback="function(s, e) { alert('Show'); //cinPanel.Show(); }" />
        </dx:ASPxCallback>--%>
        <div style="padding: 10px 0px 0px 0px;" >
                <%--<dx:ASPxLoadingPanel ID="panel" ClientInstanceName="panel" runat="server" Modal="true">--%>
		
            <telerik:RadMultiPage ID="RadMultiPageReport" runat="server" SelectedIndex="0">
                <telerik:RadPageView ID="RadPageViewDynamicReport" runat="server">
                        
                    <div id="divGrid">
                        <dx:ASPxGridView ID="ASPxGridViewDynamicReport" runat="server" Width="100%" Settings-ShowHorizontalScrollBar="True" ClientInstanceName="ReportGrid"
                            Settings-ShowTitlePanel="False" Settings-ShowVerticalScrollBar="False" Settings-EnableFilterControlPopupMenuScrolling="True"
                            Settings-ShowGroupFooter="VisibleIfExpanded" EnableCallbackCompression="false" SettingsPager-PageSize="25" EnableRowsCache="true">
                            <ClientSideEvents ContextMenu="function(s, e) {if(e.objectType == 'header') 
                                                                        headerMenu.ShowAtPos(ASPxClientUtils.GetEventX(e.htmlEvent), ASPxClientUtils.GetEventY(e.htmlEvent));}" />
                            <SettingsBehavior ColumnResizeMode="Control" AutoExpandAllGroups="True" />
                            <SettingsDetail ExportMode="All" />
                            <Styles AlternatingRow-Enabled="True">
                                <Header Font-Names="Arial" />
                            </Styles>
                            <StylesExport AlternatingRowCell-Enabled="True">
                                <Header Font-Names="Arial" />
                            </StylesExport>

                        </dx:ASPxGridView>
                        <dx:ASPxGridViewExporter ID="ASPxGridViewExporter" runat="server" GridViewID="ASPxGridViewDynamicReport">
                            <Styles AlternatingRowCell-Enabled="True" AlternatingRowCell-BackColor="WhiteSmoke">
                                    
                            </Styles>
                        </dx:ASPxGridViewExporter>
                    </div>
                
                </telerik:RadPageView>
                <telerik:RadPageView ID="RadPageViewDashboard" runat="server">

                    <div id="dashboardWrap" style="height: 700px; overflow: auto;">
                        <dx:ASPxDashboard ID="ASPxDashboardViewer" runat="server" Height="1500px" Width="100%" DashboardId="DRWDashboardID" AllowExportDashboardItems="true" 
                            ClientInstanceName="ReportDashboard" WorkingMode="ViewerOnly" DataRequestOptions-ItemDataRequestMode="BatchRequests" DataRequestOptions-ItemDataLoadingMode="OnDemand"></dx:ASPxDashboard>
                    </div>
                
                    <div style="margin-top: 20px;">
                        <span>Dashboard Width</span>
                        <telerik:RadSlider ID="DashboardWidthRadSlider" runat="server" AnimationDuration="400" ThumbsInteractionMode="Free" Width="400px" Height="50px" OnClientValueChanged="OnClientValueChanged" AutoPostBack="false" MinimumValue="0" MaximumValue="100">
                        </telerik:RadSlider>
                    </div>
                
                </telerik:RadPageView>
            </telerik:RadMultiPage>

        <%--</dx:ASPxLoadingPanel>--%>
        </div>        
    </div>
    
</asp:Content>
