<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="LocationOverride.aspx.vb" Inherits="Webvantage.LocationOverride" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    
    <div>
        <div class="form-layout label-s">
            <ul>
                <li>Location:</li>
                <li><asp:Label ID="LabelLocationName" runat="server" /></li>
            </ul>
            <ul>
                <li>Logo:</li>
                <li><asp:RadioButton ID="RadioButtonShowLogo" runat="server" Text="Show" GroupName="LocationLogo" ClientIDMode="Static" />
                    <asp:RadioButton ID="RadioButtonHideLogo" runat="server" Text="Hide" GroupName="LocationLogo" />
                </li>
            </ul>
            <div style="margin-top: 10px; white-space: nowrap; text-align: center;">
                <div style="display:inline-block; text-align:left;" ID="HeaderOptionsDiv" runat="server">
                    <fieldset>
                        <legend>Header</legend>
                        <div>
                            <div style="margin-bottom: 5px; border-bottom: 1px solid #cccccc;"><asp:CheckBox ID="CheckBoxLocationHeader" runat="server" Text="Print Header" ClientIDMode="Static" /></div>
                            <ul style="list-style:none; margin: 0; padding:0; display: inline-block;">
                                <li style="display: inline-block; margin-right: 10px;">
                                    <asp:CheckBox ID="CheckBoxLocationHeaderName" runat="server" Text="Name" ClientIDMode="Static"  /><br />
                                    <asp:CheckBox ID="CheckBoxLocationHeaderAddress1" runat="server" Text="Addr 1" ClientIDMode="Static"  /><br />
                                    <asp:CheckBox ID="CheckBoxLocationHeaderAddress2" runat="server" Text="Addr 2"  ClientIDMode="Static" />
                                </li>
                                <li style="display: inline-block; margin-right: 10px;">
                                    <asp:CheckBox ID="CheckBoxLocationHeaderCity" runat="server" Text="City" ClientIDMode="Static"  /><br />
                                    <asp:CheckBox ID="CheckBoxLocationHeaderState" runat="server" Text="State" ClientIDMode="Static"  /><br />
                                    <asp:CheckBox ID="CheckBoxLocationHeaderZip" runat="server" Text="Zip" ClientIDMode="Static"  /></li>
                                <li style="display: inline-block;">
                                    <asp:CheckBox ID="CheckBoxLocationHeaderPhone" runat="server" Text="Phone" ClientIDMode="Static"  /><br />
                                    <asp:CheckBox ID="CheckBoxLocationHeaderFax" runat="server" Text="Fax"  ClientIDMode="Static" /><br />
                                    <asp:CheckBox ID="CheckBoxLocationHeaderEmail" runat="server" Text="Email" ClientIDMode="Static"  /></li>
                            </ul>
                        </div>
                    </fieldset>
                </div>
                <div style="display:inline-block; text-align:left;" ID="FooterOptionsDiv" runat="server">
                    <fieldset>
                        <legend>Footer</legend>
                        <div>
                            <div style="margin-bottom: 5px; border-bottom: 1px solid #cccccc;"><asp:CheckBox ID="CheckBoxLocationFooter" runat="server" Text="Print Footer" /></div>
                            <ul style="list-style:none; margin: 0; padding:0; display: inline-block;">
                                <li style="display: inline-block; margin-right: 10px;">
                                    <asp:CheckBox ID="CheckBoxLocationFooterName" runat="server" Text="Name" /><br />
                                    <asp:CheckBox ID="CheckBoxLocationFooterAddress1" runat="server" Text="Addr 1" /><br />
                                    <asp:CheckBox ID="CheckBoxLocationFooterAddress2" runat="server" Text="Addr 2" />
                                </li>
                                <li style="display: inline-block; margin-right: 10px;">
                                    <asp:CheckBox ID="CheckBoxLocationFooterCity" runat="server" Text="City" /><br />
                                    <asp:CheckBox ID="CheckBoxLocationFooterState" runat="server" Text="State" /><br />
                                    <asp:CheckBox ID="CheckBoxLocationFooterZip" runat="server" Text="Zip" /></li>
                                <li style="display: inline-block;">
                                    <asp:CheckBox ID="CheckBoxLocationFooterPhone" runat="server" Text="Phone" /><br />
                                    <asp:CheckBox ID="CheckBoxLocationFooterFax" runat="server" Text="Fax" /><br />
                                    <asp:CheckBox ID="CheckBoxLocationFooterEmail" runat="server" Text="Email" /></li>
                            </ul>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
        <div style="clear: both; text-align: right; padding-top: 10px;">
            <telerik:RadButton ID="RadButtonLocationOK" runat="server" Text="OK"></telerik:RadButton>
            <telerik:RadButton ID="RadButtonLocationCancel" runat="server" Text="Cancel"></telerik:RadButton>
        </div>
    </div>

</asp:Content>
