<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CreativeBrief.aspx.vb"
    Inherits="Webvantage.CreativeBrief" MasterPageFile="~/ChildPage.Master" Title="Creative Brief" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
        <script type="text/javascript">
            function blur() {
            }

            function OpenCreativeBrief(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'OpenCreativeBrief');
            }

            function CloseApprovedPopup(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'CloseApprovedPopup');
            }
            function JsOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();
                if (comandName == "Delete") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                }
            }
            function RefreshPage() {       
                setTimeout(function () {
                  __doPostBack('onclick#Refresh', 'Refresh');
                }, 0);    
                
            };
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
        <telerik:RadToolBar ID="RadToolbarCreativeBrief" runat="server" AutoPostBack="true"
            OnClientButtonClicking="JsOnClientButtonClicking" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" Value="SaveSeparator" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Text="" CausesValidation="true"
                    Value="Save" ToolTip="Save" />
                <telerik:RadToolBarButton IsSeparator="true" Value="DeleteSeparator" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonDelete" Value="Delete"
                    CommandName="Delete" ToolTip="Delete" />
                <telerik:RadToolBarDropDown Text="Print/Send">
                    <Buttons>
                        <telerik:RadToolBarButton Text="Print" Value="Print" ToolTip="Print" />
                        <telerik:RadToolBarButton Text="Send Alert" Value="SendAlert" ToolTip="Send Alert" />
                        <telerik:RadToolBarButton Text="Send Assignment" Value="SendAssignment" ToolTip="Send Assignment" />
                        <telerik:RadToolBarButton Text="Send Email" Value="SendEmail" ToolTip="Send Email" />
                        <telerik:RadToolBarButton Text="Options" Value="PrintSendOptions" ToolTip="Print/Send Options" />
                    </Buttons>
                </telerik:RadToolBarDropDown>
                <telerik:RadToolBarButton Text="Approve" Value="Approve"
                    ToolTip="Approve" />
                <telerik:RadToolBarButton ID="RadToolBarButtonPrint"
                    Text="Print/Send" Value="PrintSendOptions" ToolTip="Print/Send" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh"
                    ToolTip="Refresh" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
        <div style="display: block; text-align: right; vertical-align: middle;">
                <asp:LinkButton ID="ApprVerBut" runat="server" BorderStyle="None" Text="Approved Version  "
                    CssClass="warning" Font-Underline="true"></asp:LinkButton>
            </div>
            <asp:Panel ID="Panel1" runat="server" HorizontalAlign="center" Width="100%" Height="100%">
                <asp:Panel ID="pnlPlaceHolder" runat="server" Width="100%">
                    <asp:PlaceHolder ID="PlaceSub" runat="server"></asp:PlaceHolder>
                </asp:Panel>
            </asp:Panel>
    </div>
    
</asp:Content>
