<%@ Page Title="Project Schedule Gantt" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="TrafficSchedule_Gantt.aspx.vb" Inherits="Webvantage.TrafficSchedule_Gantt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">

    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">

            function JsOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();

                //if (comandName == "Print") {
                //    chart1.SaveToDisk('pdf');
                //}
                if (comandName == "CalculateDates") {
                    ////args.set_cancel(!confirm('This job is a predecessor.  All jobs associated with this job will be calculated.  Are you sure you want to calculate?'));
                    radToolBarConfirm(sender, args, "This job is a predecessor.  All jobs associated with this job will be calculated.  Are you sure you want to calculate?");
                }
            }

        </script>
        <script type="text/javascript"><!--
    window.onload = function () {
        _aspxAttachEventToDocument(ASPxClientTouchUI.touchMouseDownEventName, OnMouseDown);
        _aspxAttachEventToDocument(ASPxClientTouchUI.touchMouseUpEventName, OnMouseUp);
        _aspxAttachEventToDocument(ASPxClientTouchUI.touchMouseMoveEventName, OnMouseMove);
        _aspxPreventElementDragAndSelect(chart.GetMainDOMElement(), false);
    }
    function CalculateRelativeX(x, clickedElement) {
        var left = _aspxGetAbsoluteX(clickedElement);
        return Math.abs(x - left);
    }
    function CalculateRelativeY(y, clickedElement) {
        var top = _aspxGetAbsoluteY(clickedElement);
        return Math.abs(y - top);
    }
    var series = null;
    var seriesPoint = null;
    var coords = null;
    var draggingIndex = -1;
    var dragging = false;
    function ProcessEvent(evt) {
        if (series == null)
            draggingIndex = -1;

        var srcElement = _aspxGetEventSource(evt);
        if (!ASPxClientUtils.GetIsParent(chart.GetMainDOMElement(), srcElement))
            return false;

        var x = CalculateRelativeX(_aspxGetEventX(evt), chart.GetMainDOMElement());
        var y = CalculateRelativeY(_aspxGetEventY(evt), chart.GetMainDOMElement());
        var diagram = chart.GetChart().diagram;
        coords = diagram.PointToDiagram(x, y);

        if (coords.isEmpty)
            return dragging;

        return dragging || BeginDrag(x, y);
    }
    function BeginDrag(x, y) {
        series = null;
        seriesPoint = null;

        var hitInfo = chart.HitTest(x, y);
        for (var i = 0; i < hitInfo.length; i++) {
            if ((hitInfo[i].object instanceof ASPxClientSeries) && (hitInfo[i].additionalObject instanceof ASPxClientSeriesPoint)) {
                series = hitInfo[i].object;
                seriesPoint = hitInfo[i].additionalObject;
                //if (series.name.indexOf('Current Plan') != -1) {
                draggingIndex = GetDraggingIndex();
                return draggingIndex != -1;
                //}
            }
        }
        return false;
    }
    function GetDraggingIndex() {
        if (coords.dateTimeValue.getTime() == seriesPoint.values[0].getTime()) return 0;
        if (coords.dateTimeValue.getTime() == seriesPoint.values[1].getTime()) return 1;
        return -1;
    }
    function OnMouseDown(evt) {
        if (_aspxGetIsLeftButtonPressed(evt))
            dragging = ProcessEvent(evt);
        if (dragging) {
            var x = _aspxGetEventX(evt) + 5;
            var y = _aspxGetEventY(evt) + 10;
            DraggingToolTip.ShowAtPos(x, y);
            UpdateDraggingText();
        }
        if (!__aspxTouchUI && (!__aspxIE || __aspxBrowserVersion >= 9)) {
            evt.preventDefault();
            return false;
        }
    }
    function OnMouseUp(evt) {
        if (dragging) {
            dragging = false;
            //var parameter = series.name + ";" + seriesPoint.argument + ";" + draggingIndex + ";" + GetDateString(seriesPoint.values[draggingIndex]);
            var parameter = seriesPoint.argument + ";" + draggingIndex + ";" + GetDateString(seriesPoint.values[draggingIndex]);
            chart.PerformCallback(parameter + ';' + seriesPoint.series.name);
            DraggingToolTip.Hide();
            //document.getElementById('DraggingToolTip').style.visibility = 'hidden';
        }
    }
    function OnMouseMove(evt) {
        if (ProcessEvent(evt)) {
            chart.SetCursor('e-resize');
            if (dragging && draggingIndex >= 0 && !coords.IsEmpty()) {
                seriesPoint.values[draggingIndex] = coords.dateTimeValue;
                UpdateDraggingText();
            }
            if (ASPxClientTouchUI.isTouchEvent(evt))
                evt.preventDefault();
        }
        else
            chart.SetCursor('');
    }
    function UpdateDraggingText() {
        DraggingToolTip.SetContentHTML("<span>" + GetDateString(coords.dateTimeValue) + "</span>");
    }
    function GetDateString(date) {
        return (date.getUTCMonth() + 1) + "/" + date.getUTCDate() + "/" + date.getUTCFullYear();
    }
    //--></script>

    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td>
                <telerik:RadToolBar ID="RadToolbarGantt" runat="server" AutoPostBack="True" Width="100%"
                    OnClientButtonClicking="JsOnClientButtonClicking">
                    <Items>
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonCalculateDates" ImageUrl="Images/percent.png"
                            Text="Calculate" Value="CalculateDates" CommandName="CalculateDates" DisplayType="TextImage"
                            ToolTip="Calculate due dates" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonMonth" AllowSelfUnCheck="true" CheckOnClick="true"
                            Text="Month" Value="Month" ToolTip="Month View" Group="Scale" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonWeek" AllowSelfUnCheck="true" CheckOnClick="true"
                            Text="Week" Value="Week" ToolTip="Week View" Group="Scale" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonDay" AllowSelfUnCheck="true" CheckOnClick="true"
                            Text="Day" Value="Day" ToolTip="Day View" Group="Scale" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonShowPhase" AllowSelfUnCheck="true" CheckOnClick="true"
                            Text="Phase" Value="Phase" ToolTip="Show Phase" Group="Phase" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonShowLabels" AllowSelfUnCheck="true" CheckOnClick="true"
                            Text="Labels" Value="ShowLabels" ToolTip="Show Labels" Group="Label" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonShowJobs" AllowSelfUnCheck="true" CheckOnClick="true"
                            Text="Related Jobs" Value="ShowJobs" ToolTip="Show Related Jobs" Group="Job" />
                        <telerik:RadToolBarButton ID="RadToolbarTemplateButtonPrint" SkinID="RadToolBarButtonPrint"
                            Text="" Value="Print" DisplayType="TextImage" ToolTip="Print" CommandName="Print" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolbarTemplateButtonRefresh" SkinID="RadToolBarButtonRefresh" Value="Refresh" DisplayType="TextImage" ToolTip="Refresh" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" ClientInstanceName="chart1"
                    Width="1100px" EnableClientSideAPI="True" EnableClientSidePointToDiagram="True" 
                    EnableViewState="False" SaveStateOnCallbacks="false" EnableCallBacks="true"
                    BinaryStorageMode="Session"
                    ToolTipEnabled="false" CrosshairEnabled="False" ShowLoadingPanel="False">
                </dxchartsui:WebChartControl>
                <asp:PlaceHolder ID="phGantt" runat="server"></asp:PlaceHolder>
                <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" ClientInstanceName="DraggingToolTip"
                    CloseAction="None" EnableAnimation="False" EnableHotTrack="False" ShowHeader="False" PopupHorizontalAlign="Center" Height="1px" PopupVerticalAlign="TopSides" Width="1px">
                    <ContentStyle>
                        <Paddings Padding="0px" />
                    </ContentStyle>
                    <Border BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                </dx:ASPxPopupControl>
            </td>
        </tr>
    </table>
</asp:Content>
