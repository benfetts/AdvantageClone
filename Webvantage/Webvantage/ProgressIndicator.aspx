<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="ProgressIndicator.aspx.vb" Inherits="Webvantage.ProgressIndicator" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script>

            var ctr = 1;
            var ctrMax = 100; // how many is up to you-how long does your end page take?
            var intervalId;

            function Begin() {
                //set this page's window.location.href to the target page
                window.location.href = "<%= Request.QueryString("destPage")%>";
                // but make it wait while we do our progress...
                intervalId = window.setInterval("ctr=UpdateIndicator(ctr, ctrMax)", 500);
            };
            function End() {
                // once the interval is cleared, we yield to the result page (which has been running)
                window.clearInterval(intervalId);
            };
            function UpdateIndicator(curCtr, ctrMaxIterations) {
                curCtr += 1;
                if (curCtr <= ctrMaxIterations) {
                    indicator.style.width = curCtr * 10 + "px";
                    return curCtr;
                }
                else {
                    indicator.style.width = 0;
                    return 1;
                };
            };
        </script>
    </telerik:RadScriptBlock>
    <div style="height: 100%; width: 100%;">
        <div>
            <asp:Label ID="LblTitle" runat="server" Text=""></asp:Label>
            <asp:Label ID="LblText" runat="server" Text=""></asp:Label>
            <!-- for js -->
            <div style="width:50%;text-align:center;">
                <div id="indicator" style="background-color:red;height:40px;width:0%;"></div>
            </div>
        </div>
    </div>
</asp:Content>
