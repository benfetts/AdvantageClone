<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="purchaseorder_memo_disp.aspx.vb"
    Inherits="Webvantage.purchaseorder_memo_disp" MasterPageFile="~/ChildPage.Master"
    Title="Purchase Order Job Estimate Comments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlockHeader" runat="server">
    <script type="text/javascript">

        /* Do not remove!! */
        function CallFunctionOnParentPage(functionName) {
            var oWindow = GetRadWindow();
            if (oWindow) {
                oWindow.BrowserWindow.Frame.contentWindow[functionName](oWindow);
                oWindow.BrowserWindow.Frame.contentWindow.CloseWindow();
            }
            //var callingWindow = oWindow.BrowserWindow.GetRadWindow('purchaseorder_dtl.aspx');
            //if (callingWindow) {
            //    callingWindow.BrowserWindow.Frame.contentWindow[functionName](oWindow);
            //    //callingWindow.get_contentFrame().contentWindow[functionName](oWindow);
            //    oWindow.close();
            //}
        }

    </script>
</telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <div style="margin-top: 10px; ">
            <div style="display:inline; margin-right: 10px;">
                <telerik:RadListBox ID="lbSpecs" runat="server" Width="150px" Height="300px" SelectionMode="Multiple"
                    AutoPostBack="true">
                    <Items>
                        <telerik:RadListBoxItem Text="Estimate Log" Value="est_log_comment"></telerik:RadListBoxItem>
                        <telerik:RadListBoxItem Text="Estimate Component" Value="est_comp_comment"></telerik:RadListBoxItem>
                        <telerik:RadListBoxItem Text="Estimate Quote" Value="est_qte_comment"></telerik:RadListBoxItem>
                        <telerik:RadListBoxItem Text="Estimate Revision" Value="est_rev_comment"></telerik:RadListBoxItem>
                        <telerik:RadListBoxItem Text="Function Comment" Value="est_funct_comment"></telerik:RadListBoxItem>
                        <telerik:RadListBoxItem Text="Supplied By Notes" Value="supply_by_notes"></telerik:RadListBoxItem>
                    </Items>
                </telerik:RadListBox>
            </div>
            <div style="display:inline;">
                <telerik:RadTextBox ID="RadTextBoxSpecs" runat="server" TextMode="MultiLine" Height="300px" Width="460px" Visible="true"></telerik:RadTextBox>
            </div>
        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    <div style="text-align: center; margin-top:10px;">
        <asp:Button ID="SaveButton" runat="server" Text="Select" />&nbsp;&nbsp;&nbsp;
        <asp:Button ID="CancelButton" runat="server" Text="Cancel" />
    </div>
        
        
    <input id="txtType" maxlength="50" type="text" runat="server" value="main_del_instruct"
        style="display: none" />
    <input id="txtRefID" maxlength="10" type="text" runat="server" value="-1" style="display: none" />
    <input id="txtRefID2" maxlength="10" type="text" runat="server" value="-1" style="display: none" />
    <input id="fn_code" maxlength="10" type="text" runat="server" style="display: none" />
    <input id="seq_nbr" maxlength="10" type="text" runat="server" style="display: none" />
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>

</asp:Content>
