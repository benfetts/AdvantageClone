<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="MediaOrder_AddToJobComponent.aspx.vb" Inherits="Webvantage.MediaOrder_AddToJobComponent" %>
<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlockMain" runat="server">
        <script type="text/javascript">
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
    <div style="width: 100%;">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <div style="display: inline-block; width: 50%;">
                <telerik:RadListBox ID="RadListBoxMediaOrdersCurrentlyInJob" runat="server" Width="100%" Height="180"
                    SelectionMode="Multiple" AllowTransfer="true" TransferToID="RadListBoxStatesInTemplate"
                    AutoPostBackOnTransfer="true" AllowReorder="False" EnableDragAndDrop="true">
                </telerik:RadListBox>
            </div>
            <div style="display: inline-block; width: 50%;">
                <telerik:RadListBox ID="RadListBoxAvailableMediaOrders" runat="server" Width="100%" AutoPostBack="true"
                    Height="180" SelectionMode="Multiple" AllowReorder="true" AutoPostBackOnReorder="true"
                    EnableDragAndDrop="true">
                </telerik:RadListBox>
            </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>
</asp:Content>
