<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EmployeePictureUC.ascx.vb" Inherits="Webvantage.EmployeePictureUC" %>
<div>
    <div id="DivImageContainer" runat="server">
        <dx:ASPxBinaryImage ID="ASPxBinaryImageEmployee" runat="server" CssClass="wv-employee-img-thumbnail-lg" BinaryStorageMode="Session"
            EmptyImage-Url="~/Images/Icons/Color/256/user.png">
        </dx:ASPxBinaryImage>
    </div>
    <div id="DivNoImageTextContainer" runat="server">
        <div id="DivNoImageText" runat="server">
            <asp:Literal ID="LiteralNoImageText" runat="server"></asp:Literal>
        </div>
    </div>
</div>
