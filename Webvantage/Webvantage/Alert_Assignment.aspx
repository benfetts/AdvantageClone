<%@ Page Title="Assignment" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Alert_Assignment.aspx.vb" Inherits="Webvantage.Alert_Assignment" %>

<%@ Register Src="Alert_AssignmentUC.ascx" TagName="AlertAssignmentUC" TagPrefix="custom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div runat="server" id="DivYes">
        <custom:AlertAssignmentUC ID="AlertAssignmentInfo" runat="server" />
        <div style="display: block; text-align: center;">
            <asp:Button ID="ButtonSendAssignment" runat="server" CausesValidation="False"
                Text="Send Assignment" />
        </div>
    </div>
    <div runat="server" id="DivNo">
        Not available for non routed assignments.
    </div>
</asp:Content>
