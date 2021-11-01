<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Media_ATB_Add.aspx.vb" Inherits="Webvantage.Media_ATB_Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
        </script>
    </telerik:RadScriptBlock>
    <div style="margin: 0 auto;">
        <div>
            <asp:Label   ID="LblMSG" runat="server" Text="&nbsp;"></asp:Label>
        </div>
        <div style="display: inline-block;">
            <div class="form-layout">
                <ul>
                    <li><asp:HyperLink ID="HlClient" runat="server" href="" TabIndex="-1">Client:</asp:HyperLink></li>
                    <li><asp:TextBox ID="TxtClientCode" runat="server"  CssClass="RequiredInput" MaxLength="6" TabIndex="1" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>&nbsp;&nbsp;
                        <asp:TextBox ID="TxtClientDescription" runat="server"  ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription" Visible="false"></asp:TextBox>
                    </li>
                </ul>
                <ul>
                    <li><asp:HyperLink ID="HlDivision" runat="server" href="" TabIndex="-1">Division:</asp:HyperLink></li>
                    <li><asp:TextBox ID="TxtDivisionCode" runat="server"  CssClass="RequiredInput" MaxLength="6" TabIndex="2" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>&nbsp;&nbsp;
                        <asp:TextBox ID="TxtDivisionDescription" runat="server"  ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription" Visible="false"></asp:TextBox>
                    </li>
                </ul>
                <ul>
                    <li><asp:HyperLink ID="HlProduct" runat="server" href="" TabIndex="-1">Product:</asp:HyperLink></li>
                    <li><asp:TextBox ID="TxtProductCode" runat="server"  CssClass="RequiredInput" MaxLength="6" TabIndex="3" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>&nbsp;&nbsp;
                        <asp:TextBox ID="TxtProductDescription" runat="server"  ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription" Visible="false"></asp:TextBox>
                    </li>
                </ul>
                <ul>
                    <li>Sales Class:</li>
                    <li><telerik:RadComboBox ID="RadComboBox_SalesClass" runat="server" AutoPostBack="false" TabIndex="4" Width="406px" SkinID="RadComboBoxStandard"></telerik:RadComboBox></li>
                </ul>
                <ul>
                    <li>ATB Number:</li>
                    <li><asp:TextBox ID="TextBox_OrderNumber" runat="server" ReadOnly="true" MaxLength="6" TabIndex="5" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox></li>
                    <li><asp:TextBox ID="TextBox_OrderDescription" runat="server" TabIndex="6" Text="" SkinID="TextBoxCodeSingleLineDescription" CssClass="RequiredInput" MaxLength="40"></asp:TextBox></li>
                </ul>
                <div style="margin-top: 10px; text-align: center;">
                    <asp:Button ID="Button_CreateOrder" runat="server" CausesValidation="False" TabIndex="7" Text="Create ATB" />
                    &nbsp;&nbsp;
                    <asp:Button ID="BtnCancel" runat="server" CausesValidation="False" TabIndex="8" Text="Cancel" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
