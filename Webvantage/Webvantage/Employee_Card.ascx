<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Employee_Card.ascx.vb" Inherits="Webvantage.Employee_Card" %>
<div id="DivEmployee" runat="server">
    <div id="DivFlipper" runat="server">
        <div id="DivFront" runat="server">
            <div class="card employee-card" style="">
                <div style="padding: 5px;">
                    <div style="float: left; padding: 6px 0px 0px 0px;">
                        <dx:ASPxBinaryImage ID="ASPxBinaryImageEmp" runat="server" CssClass="wv-employee-img-thumbnail-xxlg" BinaryStorageMode="Session"
                            EmptyImage-Url="~/Images/Icons/Grey/256/user.png">
                        </dx:ASPxBinaryImage>
                    </div>
                    <div style="float: left; margin: 0px 0px 20px 4px;">
                        <div style="font-size: 20px;">
                            <asp:Label ID="LabelProjectManager" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="LabelTitle" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="LabelTaskCount" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="LabelTotalHours" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="LabelActualHours" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="LabelHoursGraph" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card-action-bar card-bottom-header card-bottom-header-bg" style="">
                    <div class="card-bottom-header-text">
                        <div style="display:inline-block;">
                            <asp:Label ID="LabelEmployeeName" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="DivBack" runat="server" class="back">
            <div class="card employee-card">
                <div style="padding: 5px;">
                    <div style="float: left; margin: 0px 0px 0px 4px;" id="DivEmployeeInfo" runat="server">
                        <div style="font-size: 20px;">
                            <asp:Label ID="LabelBackFullName" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="LabelBackNickName" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="LabelBackEmail" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="LabelBackCellPhone" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="LabelBackDefaultRole" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
