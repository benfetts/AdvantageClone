<%@ Page Title="Stopwatch" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Timesheet_Stopwatch.aspx.vb" Inherits="Webvantage.Timesheet_Stopwatch" %>

<%@ OutputCache Location="None" VaryByParam="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script type="text/html" src="Jscripts/date.min.js"></script>
    <script type="text/javascript">

        //function disableTimesheetOnCancel() {
        //    var oWnd = GetRadWindow();
        //    var timesheetWindow = oWnd.get_windowManager().getWindowByName('Timesheet');

        //    if (timesheetWindow !== null) {
        //        timesheetWindow.get_contentFrame().contentWindow.disableTimesheetButtons();
        //        timesheetWindow.reload();
        //    }
        //};

        function CountUp(JsDateString, JsServerTime, id) {
            //console.log(JsDateString);
            //console.log(JsServerTime);
            this.beginDate = new Date(JsDateString);
            this.serverTime = new Date(JsServerTime);
            this.countainer = document.getElementById(id);
            this.numOfDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
            this.borrowed = 0, this.years = 0, this.months = 0, this.days = 0;
            this.hours = 0, this.minutes = 0, this.seconds = 0;
            var initialWorkstationDate = new Date();
            this.workstationOffset = 0;
            this.workstationOffset = initialWorkstationDate - this.serverTime;

            this.updateNumOfDays();
            this.updateCounter();
            //console.log(this.serverTime);
            //console.log(initialWorkstationDate);
            //console.log(this.workstationOffset);
            var testDate = new Date();
            //console.log(testDate.getTime() + this.workstationOffset);
            testDate = new Date(testDate.getTime() + this.workstationOffset);
            //console.log(testDate);
        };
        CountUp.prototype.updateNumOfDays = function () {
            var dateNow = this.serverTime;
            var currYear = dateNow.getFullYear();
            if ((currYear % 4 == 0 && currYear % 100 != 0) || currYear % 400 == 0) {
                this.numOfDays[1] = 29;
            }
            var self = this;
            setTimeout(function () { self.updateNumOfDays(); }, (new Date((currYear + 1), 1, 2) - dateNow));
        };
        CountUp.prototype.datePartDiff = function (then, now, MAX) {
            var diff = now - then - this.borrowed;
            this.borrowed = 0;
            if (diff > -1) return diff;
            this.borrowed = 1;
            return (MAX + diff);
        };
        CountUp.prototype.calculate = function () {
            var currDate = new Date();
            currDate = new Date(currDate.getTime() - this.workstationOffset);

            var prevDate = this.beginDate;
            this.seconds = this.datePartDiff(prevDate.getSeconds(), currDate.getSeconds(), 60);
            this.minutes = this.datePartDiff(prevDate.getMinutes(), currDate.getMinutes(), 60);
            this.hours = this.datePartDiff(prevDate.getHours(), currDate.getHours(), 24);
            this.days = this.datePartDiff(prevDate.getDate(), currDate.getDate(), this.numOfDays[currDate.getMonth()]);
            this.months = this.datePartDiff(prevDate.getMonth(), currDate.getMonth(), 12);
            this.years = this.datePartDiff(prevDate.getFullYear(), currDate.getFullYear(), 0);
        };
        CountUp.prototype.addLeadingZero = function (value) {
            return value < 10 ? ("0" + value) : value;
        };
        CountUp.prototype.formatTime = function () {
            this.seconds = this.addLeadingZero(this.seconds);
            this.minutes = this.addLeadingZero(this.minutes);
            this.hours = this.addLeadingZero(this.hours);
        };
        CountUp.prototype.updateCounter = function () {

            this.calculate();
            this.formatTime();

            var display = '';

            display = "Stopwatch has been running for:<br />";
            if ((this.months == 11 && this.days == 29) || (this.minutes == 0 && this.seconds <= 59)) {
                display = display + "Less than a minute."
            }
            else {
                if (this.years > 0) {
                    display = display + this.years + (this.years == 1 ? " year,  " : " years,  ")
                }
                if (this.months > 0) {
                    display = display + this.months + (this.months == 1 ? " month,  " : " months,  ")
                }
                if (this.days > 0) {
                    display = display + this.days + (this.days == 1 ? " day,  " : " days,  ")
                }
                if (this.hours > 0) {
                    display = display + this.hours + (this.hours == 1 ? " hour,  " : " hours,  ")
                }
                if (this.minutes > 0) {
                    display = display + this.minutes + (this.minutes == 1 ? " minute,  " : " minutes,  ")
                }
                if (this.seconds >= 0) {
                    display = display + this.seconds + (this.seconds == 1 ? " second.  " : " seconds.  ")
                }
            };
            if (display.indexOf("11 months") > -1 || display.indexOf("30 days") > -1 || (display.indexOf("30 days") > -1 && display.indexOf("23 hours") > -1)) {
                display = "Stopwatch has been running for:<br />Less than a minute.";
            };
            var PassItThroughAgain;
            PassItThroughAgain = display;
            if (PassItThroughAgain.indexOf("11 months") > -1 || PassItThroughAgain.indexOf("30 days") > -1 || (PassItThroughAgain.indexOf("30 days") > -1 && PassItThroughAgain.indexOf("23 hours") > -1)) {
                PassItThroughAgain = "Stopwatch has been running for:<br />Less than a minute.";
            }
            this.countainer.innerHTML = display;
            var self = this;
            setTimeout(function () { self.updateCounter(); }, 1000);
        };
    </script>
    <asp:Literal ID="LiteralStartTimer" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table border="0" style="width: 100%; margin: 0; padding: 0; border: 0">
        <tr id="TrCounter" runat="server">
            <td style="text-align: center; vertical-align: middle; width: 58px;">
                <div class="icon-background background-color-delete">
                    <asp:ImageButton ID="ImageButtonStop" runat="server" SkinID="ImageButtonStopwatchStopWhite" />
                </div>
            </td>
            <td>
                <h2 id="counter">Please wait.
                </h2>
                <h3>
                    <asp:Label ID="LabelJobDescription" runat="server" Text=""></asp:Label>
                </h3>
                Comment:<br />
                <asp:TextBox ID="TextBoxComment" runat="server" TextMode="MultiLine" Width="400" Height="40" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
        <tr id="TrTimeOver" runat="server">
            <td colspan="2">
                <fieldset>
                    <legend>
                        <asp:Image ID="Image1" runat="server" SkinID="ImageButtonWarning" />&nbsp;Warning
                    </legend>
                    The stopwatch can only record your time for up to 24 hours!<br />
                    Would you like to:
                    <br />
                    <ul>
                        <li>
                            <asp:LinkButton ID="LinkButtonClearStopwatch" runat="server" Text="Clear the stopwatch"></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="LinkButtonViewInTimesheet" runat="server" Text="View entry"></asp:LinkButton>
                        </li>
                    </ul>
                </fieldset>
            </td>
        </tr>
        <tr id="TrButtons" runat="server">
            <td colspan="2" style="text-align: center; vertical-align: middle;">
                <br />
                <div style="width: 100%; text-align: right;">
                    <asp:Button ID="ButtonCancelStopwatch" runat="server" Text="Cancel Stopwatch" />
                    <asp:Button ID="ButtonViewEntry" runat="server" Text="View entry" />
                    <asp:Button ID="ButtonStop" runat="server" Text="Stop Stopwatch" />
                </div>
            </td>
        </tr>
        <tr id="TrNoStopwatch" runat="server">
            <td colspan="2" style="text-align: center; vertical-align: middle;">
                <h2>
                    No stopwatch running please close this window.
                </h2>
            </td>
        </tr>
    </table>
</asp:Content>
