<%@ Page Title="New Project Schedule Template" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="TrafficScheduleTemplate_New.aspx.vb" Inherits="Webvantage.TrafficScheduleTemplate_New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <style>
        .RadInput_Metro, .RadInputMgr_Metro {
            margin: 8px 0;
        }
        .RadToolBar {
            max-width: 980px!important;
        }
    </style>
    <telerik:RadToolBar ID="RadToolBarTrafficScheduleTemplateNew" runat="server" Width="100%">
        <Items>
            <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Text="" Value="save" ToolTip="Save" />
        </Items>
    </telerik:RadToolBar>
    <div style="margin: 8px;">
        <asp:Label ID="LabelTextBoxDescriptors" runat="server" Text="Template Name:"></asp:Label><br />
        <telerik:RadTextBox ID="RadTextBoxCode" runat="server" MaxLength="6"></telerik:RadTextBox>
        <telerik:RadTextBox ID="RadTextBoxNameDescription" runat="server"></telerik:RadTextBox>
    </div>
</asp:Content>
