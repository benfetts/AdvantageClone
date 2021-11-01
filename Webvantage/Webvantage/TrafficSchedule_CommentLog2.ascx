<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="TrafficSchedule_CommentLog2.ascx.vb" Inherits="Webvantage.TrafficSchedule_CommentLog2" %>


<script type="text/javascript">
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
    function isNumberKey(evt) {
        //alert(" Key " + evt.keyCode + " Entered");
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode < 96 || charCode > 105))
            return false;

        return true;
    }
    function Count(text, long) {

        var maxlength = new Number(long); // Change number to your max length.

        if (text.value.length > maxlength) {

            text.value = text.value.substring(0, maxlength);

            ShowMessage(" Only " + long + " chars");

        }

    }

</script>
 <table cellpadding="0" cellspacing="0"   width="100%">
    <tr>
    <td>
<table border="0" cellpadding="0" cellspacing="2" width="810">
    <tr>
        <td>
           <%-- <asp:Label   ID="lblAddComment" runat="server" Text="Add Comment"></asp:Label>--%>
        </td>
    </tr>
    <tr>
        <td align="left" colspan="3" valign="middle" visible="false">
            <asp:TextBox ID="TxtAddComment" runat="server"  Height="64px"
                TextMode="MultiLine" Width="75%"></asp:TextBox>&nbsp;
            <asp:Button runat="server" ID="btnSave"   Text="Add Comment" />
        </td>
    </tr>
</table>


<telerik:RadGrid ID="RadGridComments2" runat="server" AutoGenerateColumns="False" 
   CellPadding="1" CellSpacing="1" 
    EnableAJAX="false" Width="99%" AllowSorting="True" >
    <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
    <ClientSettings AllowColumnHide="True" AllowExpandCollapse="True" Selecting-AllowRowSelect="true">
        <Scrolling AllowScroll="false" SaveScrollPosition="true"
            UseStaticHeaders="False" />
        <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
    </ClientSettings>
    <MasterTableView DataKeyNames="ID,JOB_NUMBER,JOB_COMPONENT_NBR,SEQ_NBR,EMP_CODE"
        TableLayout="auto">
        <Columns>
            <telerik:GridTemplateColumn DataField="ID" Display="False" UniqueName="ID">
                <ItemTemplate>
                    <asp:Label   ID="lblID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn DataField="JOB_NUMBER" Display="False" HeaderText="JOB_NUMBER"
                UniqueName="JobNumber">
                <ItemTemplate>
                    <asp:Label   ID="lblJobNumber" runat="server" Text='<%#Eval("JOB_NUMBER") %>'></asp:Label>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn DataField="JOB_COMPONENT_NBR" Display="False" HeaderText="JOB_COMPONENT_NBR"
                UniqueName="JobComponentNumber">
                <ItemTemplate>
                    <asp:Label   ID="lblJobComponentNumber" runat="server" Text='<%#Eval("JOB_COMPONENT_NBR") %>'></asp:Label>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn DataField="SEQ_NBR" Display="False" HeaderText="SEQ_NBR"
                UniqueName="SEQNBR">
                <ItemTemplate>
                    <asp:Label   ID="lblSEQNBR" runat="server" Text='<%#Eval("SEQ_NBR") %>'></asp:Label>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn DataField="EMP_CODE" Display="False" UniqueName="EMP_CODE">
                <ItemTemplate>
                    <asp:Label   ID="lblEmpCode" runat="server" Text='<%#Eval("EMP_CODE") %>'></asp:Label>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn DataField="CREATE_USER" Display="True" HeaderText="Employee"
                UniqueName="Employee" SortExpression="CREATE_USER">
                <ItemTemplate>
                    <asp:Label   ID="lblEmployee" runat="server" Text='<%#Eval("CREATE_USER") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" Width="100px" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="top" Width="100px" />
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn DataField="CREATE_DATE" Display="True" HeaderText="Date"
                UniqueName="CreateDate" SortExpression="CREATE_DATE">
                <ItemTemplate>
                    <asp:Label   ID="lblCreateDate" runat="server" Text='<%#Eval("CREATE_DATE","{0:d}") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" Width="75px" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="top" Width="75px" />
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn DataField="CREATE_TIME" Display="True" HeaderText="Time"
                UniqueName="CreateTime" SortExpression="CREATE_TIME">
                <ItemTemplate>
                    <asp:Label   ID="lblCreateTime" runat="server" Text='<%#Eval("CREATE_TIME","{0:HH:mm tt}") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" Width="75px" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="top" Width="75px" />
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn DataField="COMMENT"  Display="True" HeaderText="Comment" UniqueName="Comment">
                <ItemTemplate>
                <asp:Label   ID="lblComment" runat="server" Text='<%#Eval("COMMENT") %>' Width="100%" Height="100%"></asp:Label>
                   
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="top" />
            </telerik:GridTemplateColumn>
        </Columns>
    </MasterTableView>
</telerik:RadGrid>
</td>
</tr>
</table>
<telerik:RadWindowManager ID="RadWindowCommentLog" runat="server"  >
</telerik:RadWindowManager>
