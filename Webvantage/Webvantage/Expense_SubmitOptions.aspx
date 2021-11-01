<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Expense_SubmitOptions.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="" Inherits="Webvantage.Expense_SubmitOptions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    
    <script type="text/javascript">

        $(document).ready(function(){
            //var oWindow = GetRadWindow();
            //if (oWindow) {
            //    var contentWidth = $('#content').width() + 20;
            //    if (contentWidth > oWindow.get_width()) {
            //        oWindow.set_width(contentWidth);
            //    }
            //}
        });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <div style="margin-top: 10px; white-space: nowrap;" id="content">
        <div class="form-layout label-l">
            <ul>
                <li>Employee:</li>
                <li><asp:Label ID="Label_ExpenseEmployee" runat="server" /></li>
            </ul>
            <ul>
                <li>Supervisor:</li>
                <li><asp:Label ID="Label_Supervisor" runat="server" /></li>
            </ul>
            <ul>
                <li>Alternate Approver:</li>
                <li><asp:Label ID="Label_AlternateApprover" runat="server" /></li>
            </ul>
            <ul>
                <li>Select Approver:</li>
                <li><telerik:RadComboBox ID="RadComboBox_Employees" runat="server" DataValueField="Code" DataTextField="Name" EmptyMessage="[Please select]" SkinID="RadComboBoxEmployee" >
                </telerik:RadComboBox></li>
            </ul>
            <ul>
                <li>&nbsp;</li>
                <li><asp:CheckBox runat="server" ID="CheckBox_IncludeReceiptsInEmailAndAlert" Text="Include receipts in Email and Alert" Checked="true" /></li>
            </ul>
        </div>
        <div style="text-align: right; margin-top:20px;">
            <asp:Button ID="Button_Submit" runat="server" Text="Submit" />&nbsp;&nbsp;
            <asp:Button ID="Button_Cancel" runat="server" Text="Cancel" OnClientClick="CloseThisWindow();" />
        </div>
    </div>

</asp:Content>
