<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="TrafficSchedule_TaskDetail_EmployeeUC.ascx.vb"
    Inherits="Webvantage.TrafficSchedule_TaskDetail_EmployeeUC" %>


<script type="text/javascript">
    function SetIf100Perc(tbPercent, tbCompleted) {
        if (tbPercent.value > 99) {
            if (tbCompleted.value == "") {
                var mydate = new Date()
                var year = mydate.getYear()
                if (year < 1000) {
                    year += 1900;
                }
                var day = mydate.getDay()
                var month = mydate.getMonth() + 1
                if (month < 10) {
                    month = "0" + month;
                }
                var daym = mydate.getDate()
                if (daym < 10) {
                    daym = "0" + daym;
                }
                if (tbCompleted.value == "") {
                    tbCompleted.value = month + "/" + daym + "/" + year;
                }
            }
        }
        return true
    }
   
    function isDate(val, format) {
        var date = getDateFromFormat(val, format);
        if (date == 0) { return false; }
        return true;
    }

    function IsInteger(sText) {
        try {

            var ValidChars = "0123456789";
            var IsNumber = true;
            var Char;
            for (i = 0; i < sText.length && IsNumber == true; i++) {
                Char = sText.charAt(i);
                if (ValidChars.indexOf(Char) == -1) {
                    IsNumber = false;
                }
            }
            return IsNumber;
        } catch (err) { }
    }
    function BlockEntry(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 0)
            return false;

        return true;
    }
    function isNumberKey(evt) {
        //alert(" Key " + evt.keyCode + " Entered");
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode < 96 || charCode > 105))
            return false;

        return true;
    }
    function isLessThen101(text) {
       
        if (text.value > 100 || text.value < 0) {
            text.value = ''
            ShowMessage(" Must be between 0 and 100%");
        }

    }
    function Count(text, long) {

        var maxlength = new Number(long); // Change number to your max length.

        if (text.value.length > maxlength) {

            text.value = text.value.substring(0, maxlength);

            ShowMessage(" Only " + long + " chars");

        }
    }
    
</script>

<div style="margin:0px 0px 15px 0px;">
    <div style="display: inline-block;">
        <asp:ImageButton ID="imgBtnEmployees" runat="server" SkinID="ImageButtonAdd" />
    </div>
    <div style="display: inline-block;">
        <asp:TextBox ID="TxtEmployeesList" Visible="false" runat="server" Height="31px" TextMode="MultiLine" Width="342px"></asp:TextBox>
    </div>
    <div style="display: inline-block;">
        <asp:CheckBox ID="chkQuoteHours" runat="server" Text="Show Quoted Hours." AutoPostBack="True" />
    </div>
</div>
<telerik:RadGrid ID="RadGridEmployees2" ShowFooter="true" runat="server" AutoGenerateColumns="False"
    CellPadding="1" CellSpacing="1" EnableAJAX="false" Width="99%">
    <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
    <ClientSettings AllowColumnHide="True" AllowExpandCollapse="True" Selecting-AllowRowSelect="true">
        <Scrolling AllowScroll="False" SaveScrollPosition="true"
            UseStaticHeaders="False" />
        <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
    </ClientSettings>
    <MasterTableView DataKeyNames="ID,EMP_CODE,EMP_NAME" TableLayout="auto">
        <Columns>
            <telerik:GridTemplateColumn DataField="ID" Display="False" UniqueName="ID">
                <ItemTemplate>
                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn DataField="EMP_CODE" Display="False" UniqueName="EMP_CODE">
                <ItemTemplate>
                    <asp:Label ID="lblEmpCode" runat="server" Text='<%#Eval("EMP_CODE") %>'></asp:Label>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn DataField="EMP_NAME" Display="True" HeaderText="Employee&nbsp;"
                UniqueName="EmployeeName">
                <ItemTemplate>
                    <asp:TextBox ID="txtEmployeeName" runat="server" TabIndex="-1" onkeydown="return BlockEntry(event)"
                        Text='<%#Eval("EMP_NAME") %>'></asp:TextBox>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblTotal" runat="server" Text="Totals"></asp:Label>
                </FooterTemplate>
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" Width="150px" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="middle" Width="150px" />
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn Visible="false" HeaderText="Quoted<br />Hours&nbsp;" UniqueName="QuotedHours">
                <ItemTemplate>
                    <asp:TextBox ID="txtQuotedHours" Width="70px" TabIndex="-1" runat="server" Text='0.00'
                        onkeydown="return BlockEntry(event)"></asp:TextBox>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label runat="server" ID="lblQuotedHoursTotal" Text=""></asp:Label>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" Width="10px" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="middle" Width="10px" />
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn DataField="HOURS_ALLOWED" Display="True" HeaderText="Hours<br />Allowed&nbsp;"
                UniqueName="HoursAllowed">
                <ItemTemplate>
                    <asp:TextBox ID="txtHoursAllowed" Width="70px" runat="server" TabIndex="-1" onkeydown="return BlockEntry(event)"
                        Text='<%#Eval("HOURS_ALLOWED") %>'></asp:TextBox>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblHoursAllowedTotal" runat="server" Text=""></asp:Label>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" Width="10px" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="middle" Width="10px" />
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn Display="True" HeaderText="Hours<br />Posted&nbsp;" UniqueName="HoursPosted">
                <ItemTemplate>
                    <asp:TextBox ID="txtHoursPosted" Width="70px" runat="server" TabIndex="-1" onkeydown="return BlockEntry(event)"
                        Text='0.00'></asp:TextBox>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label runat="server" ID="lblHoursPostedTotal" Text=""></asp:Label>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" Width="10px" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="middle" Width="10px" />
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn DataField="Percent_Complete" Display="True" HeaderText="Gut %<br />Complete&nbsp;"
                UniqueName="PercentComplete" ItemStyle-VerticalAlign="Middle">
                <ItemTemplate>
                    <asp:TextBox ID="txtPercentComplete" runat="server"
                        Width="70px" Text='<%#Eval("PERCENT_COMPLETE", "{0:###}") %>' onKeyUp="isLessThen101(this)"></asp:TextBox>
                    <asp:HiddenField ID="HftxtPercentComplete" runat="server" Value='<%# Eval("PERCENT_COMPLETE") %>' />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" Width="10px" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="middle" Width="10px" />
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn DataField="Percent_Complete" Display="True" HeaderText="Actual %<br />Complete&nbsp;"
                UniqueName="ActualPercentComplete" ItemStyle-VerticalAlign="Middle">
                <ItemTemplate>
                    <asp:TextBox ID="txtActualPercentComplete" runat="server"
                        Width="70px" Text='' onkeydown="return BlockEntry(event)"></asp:TextBox>
                    <asp:HiddenField ID="HftxtActualPercentComplete" runat="server" Value='' />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" Width="10px" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="middle" Width="10px" />
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn DataField="Temp_Comp_Date" Display="True" HeaderText="Completed&nbsp;"
                UniqueName="Completed">
                <ItemTemplate>
                    <telerik:RadDatePicker ID="RadDatePickerCompleted" runat="server" SkinID="RadDatePickerStandard">
                        <DateInput DateFormat="d" EmptyMessage="">
                            <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                        </DateInput>
                    </telerik:RadDatePicker>
                    <asp:HiddenField ID="HftxtCompleted" runat="server" Value='<%#Eval("TEMP_COMP_DATE", "{0:d}")%>' />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" Width="30px" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="middle" />
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn DataField="Completed_Comments" Display="True" HeaderText="Completed Comment"
                UniqueName="CompletedComment">
                <ItemTemplate>
                    <asp:TextBox ID="txtCompletedComment" runat="server"
                        Text='<%#Eval("Completed_Comments") %>' Height="35px" TextMode="MultiLine" Wrap="True"></asp:TextBox>
                    <asp:HiddenField ID="HftxtCompletedComment" runat="server" Value='<%# Eval("Completed_Comments") %>' />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" />
                <ItemStyle HorizontalAlign="Left" Height="35px" />
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn Display="True" HeaderText="&nbsp;" UniqueName="colComments">
                <HeaderStyle CssClass="radgrid-icon-column" />
                <ItemStyle CssClass="radgrid-icon-column" />
                <FooterStyle CssClass="radgrid-icon-column" />
                <ItemTemplate>
                    <div id="DivShowComments" runat="server" class="icon-background background-color-sidebar">
                        <asp:ImageButton ID="ImageButtonShowComments" runat="server" SkinID="ImageButtonCommentWhite" CommandArgument='<%#Eval("ID")%>' CommandName="ShowComments" />
                    </div>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
        </Columns>
    </MasterTableView>
</telerik:RadGrid>
<telerik:RadCalendar ID="RadCalendarShared" runat="server" RangeMinDate="1900-01-01" Visible="false">
</telerik:RadCalendar>
<telerik:RadWindowManager ID="RadWindowEmployee" runat="server" EnableViewState="false">
</telerik:RadWindowManager>
