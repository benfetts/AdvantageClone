<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Event_Type.ascx.vb"
    Inherits="Webvantage.Event_Type" %>
<telerik:RadComboBox ID="RadComboBoxEventType" runat="server"  CssClass="RequiredInput"
    EnableViewState="true" Width="175">
    <Items>
        <telerik:RadComboBoxItem Text="[Please select]" Value="0" />
        <telerik:RadComboBoxItem Text="Fixed" Value="1" />
        <telerik:RadComboBoxItem Text="Flex" Value="2" />
        <telerik:RadComboBoxItem Text="Pre-emptable" Value="3" />
        <telerik:RadComboBoxItem Text="Hold" Value="4" />
    </Items>
</telerik:RadComboBox>