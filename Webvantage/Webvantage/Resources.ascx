<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Resources.ascx.vb"
    Inherits="Webvantage.ResourcesUC" %>
<table width="450" border="0" cellspacing="2" cellpadding="0">
    <tr>
        <td width="200" align="left" valign="bottom">Delete Automatic Tasks:
        </td>
        <td width="244" align="left" valign="bottom">
            <asp:CheckBox ID="ChkDeleteAutoTasks" runat="server" Text="" Checked="True" TextAlign="Left"
                ToolTip="Delete tasks that were automatically generated" />
        </td>
    </tr>
    <tr>
        <td>Resource Type:
        </td>
        <td>
            <telerik:RadComboBox ID="DropResourceType" runat="server" AutoPostBack="true" Width="230">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td>Resource:
        </td>
        <td>
            <telerik:RadComboBox ID="DropResources" runat="server" AutoPostBack="true" Width="230">
            </telerik:RadComboBox>
            <asp:ImageButton ID="ImageButtonRefreshTaskGrid" Visible="false" runat="server" CommandName="RefreshTaskGrid"
                ToolTip="Refresh the task grid" ImageAlign="AbsMiddle" SkinID="ImageButtonRefresh" AlternateText="Refresh task grid" />
            <asp:Label ID="LblOverbooked" runat="server" Text="<br/>This Resource is overbooked!  Changes not saved."
                Visible="false" CssClass="warning"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>Priority:
        </td>
        <td>
            <asp:Label ID="LblPriority" runat="server" Text="&nbsp;"></asp:Label>
        </td>
    </tr>
    <tr id="TrLastDate" runat="server">
        <td>Last Date:
        </td>
        <td>
            <asp:Label ID="LblLastDate" runat="server" Text="&nbsp;"></asp:Label>
        </td>
    </tr>
    <tr id="TrLastTime" runat="server">
        <td>Last Time:
        </td>
        <td>
            <asp:Label ID="LblLastTime" runat="server" Text="&nbsp;"></asp:Label>
        </td>
    </tr>
    <tr id="TrLastJobComp" runat="server">
        <td>Last Job/Comp:
        </td>
        <td>
            <asp:Label ID="LblLastJobComp" runat="server" Text="&nbsp;"></asp:Label>
        </td>
    </tr>
    <tr id="TrLastAdNumber" runat="server">
        <td>Last Ad Number:
        </td>
        <td>
            <asp:Label ID="LblLastAdNumber" runat="server" Text="&nbsp;"></asp:Label>
        </td>
    </tr>
</table>