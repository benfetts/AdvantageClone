<%@ Control AutoEventWireup="false" CodeBehind="purchaseordernav.ascx.vb" Inherits="Webvantage.purchaseordernav"
    Language="vb" %>
<%@ Register Src="ReportTypeUC.ascx" TagName="reporttype" TagPrefix="uc1" %>
<telerik:RadToolBar ID="RadToolbarPurchseOrderNav" runat="server" AutoPostBack="True"
    Width="100%" OnClientButtonClicking="PoNavOnClientButtonClicking" OnClientButtonClicked="click_handler">
    <Items>
        <telerik:RadToolBarButton IsSeparator="true" />
        <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Text="" CausesValidation="true"
            Value="SelSave" Hidden="False" ToolTip="Save this Purchase Order" />
        <telerik:RadToolBarButton IsSeparator="true" />
        <telerik:RadToolBarButton SkinID="RadToolBarButtonFind" Text="Search" Value="SelPOList"
            ToolTip="Purchase Order Search" />
        <telerik:RadToolBarButton IsSeparator="true" />
        <telerik:RadToolBarButton SkinID="RadToolBarButtonNew" Text="New PO" Value="SelNew"
            ToolTip="New Purchase Order" />
        <telerik:RadToolBarButton IsSeparator="true" />
        <telerik:RadToolBarButton Text="Copy" Value="SelCopy" SkinID="RadToolBarButtonCopy"
            ToolTip="Create another Purchase Order based on this one" />
        <telerik:RadToolBarButton IsSeparator="true" />
        <telerik:RadToolBarButton Text="Revise" Value="SelRevision"
            ToolTip="Increment Revision Number on this Purchase Order" />
        <telerik:RadToolBarButton IsSeparator="true" />
        <telerik:RadToolBarButton Text="Void" Value="SelVoid"
            ToolTip="Void this Purchase Order" CommandArgument="0" />

        <telerik:RadToolBarButton IsSeparator="true" />
        <telerik:RadToolBarButton SkinID="RadToolBarButtonAlerts" Value="Alerts" ToolTip="Alerts" Visible="false" />
        <telerik:RadToolBarButton IsSeparator="true" />
        <telerik:RadToolBarDropDown Text="Print/Send" ID="PrintSendDropDown" runat="server">
            <Buttons>
                <telerik:RadToolBarButton Text="Print" Value="Print" ToolTip="Print" />
                <telerik:RadToolBarButton Text="Send Alert" Value="SendAlert" ToolTip="Send Alert" />
                <telerik:RadToolBarButton Text="Send Assignment" Value="SendAssignment" ToolTip="Send Assignment" />
                <telerik:RadToolBarButton Text="Send Email" Value="SendEmail" ToolTip="Send Email" />
                <telerik:RadToolBarButton Text="Options" Value="PrintSendOptions" ToolTip="Print/Send Options" />
            </Buttons>
        </telerik:RadToolBarDropDown>
        <telerik:RadToolBarButton IsSeparator="true" />
        <telerik:RadToolBarButton ImageUrl="Images/unread.png" Text="Send" Value="SelSend"
            ToolTip="Send this Purchase Order to the Vendor" Visible="false" />
        <telerik:RadToolBarButton SkinID="RadToolBarButtonClear" Text="Back" Value="SelBack2"
            ToolTip="Back" Visible="false" />
        <telerik:RadToolBarButton IsSeparator="true" />
        <telerik:RadToolBarButton Text="Cancel Approval" Value="CancelApproval"
            Hidden="False" ToolTip="Cancel Approval for this Purchase Order" />
        <telerik:RadToolBarButton Text="Mark Complete" Value="MarkComplete" 
            Hidden="False" ToolTip="Mark P.O. as Complete" />
        <telerik:RadToolBarButton Text="Mark Not Complete" Value="MarkNotComplete" 
            Hidden="False" ToolTip="Mark P.O. as Not Complete"/>
        <telerik:RadToolBarButton IsSeparator="true" />
        <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="SelRefresh"
            ToolTip="Refresh" />
        <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark" ToolTip="Bookmark" />
        <telerik:RadToolBarSplitButton DropDownWidth="125">
            <Buttons>
                <telerik:RadToolBarButton Text="WV Link" Value="WvPermaLink" CommandName="WvPermaLink" ToolTip="Create Webvantage link for use in other systems" Visible="True" />
                <telerik:RadToolBarButton Text="CP Link" Value="CpPermaLink" CommandName="CpPermaLink" ToolTip="Create Client Portal link for use in other systems" Visible="True" />
            </Buttons>
        </telerik:RadToolBarSplitButton>
        <telerik:RadToolBarButton IsSeparator="true" />
    </Items>
</telerik:RadToolBar>
<input id="txtPONumber" runat="server" maxlength="15" style="display: none" type="text"
    value="-1" />
<script type="text/javascript">

    function PoNavOnClientButtonClicking(sender, args) {
        var itemValue = args.get_item().get_value();
        if (itemValue === "SelVoid") {
            if (voidPO) {
                var item = args.get_item();
                if (item.get_commandArgument() === '1') {
                    //void po! 
                    item.set_commandArgument("0");
                } else {
                    args.set_cancel(true);
                    voidPO((function () {
                        item.set_commandArgument("1");
                        item.click();
                    }));
                }
            } else {
                args.set_cancel(!confirm('Are you sure you want to Void this Purchase Order? If yes, it will be marked as voided and will no longer be available for use.'));
            }
        }
        var commandName = args.get_item().get_commandName();
        if (commandName == "WvPermaLink") {
            <%=Me.WebvantageLink%>
            args.set_cancel(true);
        }
        if (commandName == "CpPermaLink") {
            <%=Me.ClientPortalLink%>
            args.set_cancel(true);
        }

    }
    

    function confirmCallBackFn(arg) {          
        if (arg == true) {
            __doPostBack('onclick#Any','Any');
        }    
    }   
    
    function click_handler(sender, e) {
        var itemValue = e.get_item().get_value();
       if (itemValue === 'Sel') {
           var p = document.forms(0).ctl00_ContentPlaceHolderMain_Purchaseordernav1_txtPONumber.value;
           PopupEstimateWindow(p, 570, 830);
       }
       if (itemValue === 'SelSend') {
           var p = document.forms(0).ctl00_ContentPlaceHolderMain_Purchaseordernav1_txtPONumber.value;
           PopupSendWindow(p, 800, 800);
       }
   }

    function PopupEstimateWindow(ponum,h,w){
        var url="purchaseorder_funct_summ.aspx?calledfrom=custom&po_number=" + ponum; 
        window.open(url, "external", "width=" + w +",height=" + h + ",resizable=no,scrollbars=no,status=no,location=no,toolbar=no,menubar=no");
    }
           
    function PopupSendWindow(ponum,h,w){
        var url="purchaseorder_alert.aspx?calledfrom=custom&alert_funct=email_po&ref_id=" + ponum; 
        window.open(url, "external", "width=" + w +",height=" + h + ",resizable=no,scrollbars=no,status=no,location=no,toolbar=no,menubar=no");
    }

</script>
