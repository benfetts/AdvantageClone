<%@ Control AutoEventWireup="false" Codebehind="DesktopClock.ascx.vb" Inherits="Webvantage.DesktopClock"
    Language="vb" %>
<div class="DO-Container">
            <asp:Panel ID="PanelFlashClock" runat="server">
                <telerik:RadCodeBlock ID="RadCodeBlockFlashObject" runat="server" EnableViewState="false">
                    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="<%= Request.Url.Scheme %>://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0"
                        height="150" title="Clock" width="150">
                        <param name="movie" value="Flash/clock.swf" />
                        <param name="quality" value="high" />
                        <param name="wmode" value="transparent" />
                        <embed height="150" pluginspage="<%= Request.Url.Scheme %>://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash"
                            quality="high" src="Flash/clock.swf" type="application/x-shockwave-flash" width="150"></embed>
                    </object>
                </telerik:RadCodeBlock>
            </asp:Panel>
            <asp:Panel ID="PanelHTML5Clock" runat="server">
                <canvas id="clockid" class="CoolClock:swissRail:85"></canvas>
            </asp:Panel>
            <div id="js_clock">
                <script  type="text/javascript">
                    function js_clock() {
                        var clock_time = new Date();
                        var clock_hours = clock_time.getHours();
                        var clock_minutes = clock_time.getMinutes();
                        var clock_seconds = clock_time.getSeconds();
                        var clock_suffix = "AM";
                        if (clock_hours > 11) { clock_suffix = "PM"; clock_hours = clock_hours - 12; }
                        if (clock_hours == 0) { clock_hours = 12; }
                        if (clock_hours < 10) { clock_hours = "0" + clock_hours; }
                        if (clock_minutes < 10) { clock_minutes = "0" + clock_minutes; }
                        if (clock_seconds < 10) { clock_seconds = "0" + clock_seconds; }
                        var clock_div = document.getElementById('js_clock');
                        clock_div.innerHTML = clock_hours + ":" + clock_minutes + ":" + clock_seconds + " " + clock_suffix; 
                        setTimeout("js_clock()", 1000); 
                    } 
                    js_clock();
                </script>
            </div>
             <asp:Literal ID="litDate" runat="server"></asp:Literal>
</div>