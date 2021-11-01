<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="FilenameBuilder.ascx.vb" Inherits="Webvantage.FilenameBuilder" %>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="560">
    Example:<br />
    <asp:Label ID="LabelExample" runat="server" Text=""></asp:Label><asp:LinkButton ID="LinkButtonEdit" runat="server" Text="Edit"></asp:LinkButton>
    <asp:Panel ID="PanelEdit" runat="server">
        <br />
        File name builder:<br />
        <asp:TextBox ID="TextBoxEdit" runat="server" Width="520"></asp:TextBox><asp:LinkButton ID="LinkButtonSave" runat="server" Text="Save"></asp:LinkButton>
        <br />
        Available Keywords:<br />
        <telerik:RadListBox ID="RadListBoxKeywords" runat="server" Width="525" Height="141">
            <Items>
                <telerik:RadListBoxItem Text="#OfficeCode#" Value="#OfficeCode#" />
                <telerik:RadListBoxItem Text="#ClientCode#" Value="#ClientCode#" />
                <telerik:RadListBoxItem Text="#DivisionCode#" Value="#DivisionCode#" />
                <telerik:RadListBoxItem Text="#ProductCode#" Value="#ProductCode#" />
                <telerik:RadListBoxItem Text="#OfficeName#" Value="#OfficeName#" />
                <telerik:RadListBoxItem Text="#ClientName#" Value="#ClientName#" />
                <telerik:RadListBoxItem Text="#DivisionName#" Value="#DivisionName#" />
                <telerik:RadListBoxItem Text="#ProductName#" Value="#ProductName#" />
                <telerik:RadListBoxItem Text="#JobNumber#" Value="#JobNumber#" />
                <telerik:RadListBoxItem Text="#ComponentNumber#" Value="#ComponentNumber#" />
                <telerik:RadListBoxItem Text="#JobDescription#" Value="#JobDescription#" />
                <telerik:RadListBoxItem Text="#ComponentDescription#" Value="#ComponentDescription#" />
            </Items>
        </telerik:RadListBox>
    </asp:Panel>
</telerik:RadAjaxPanel>
