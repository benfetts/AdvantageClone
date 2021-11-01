<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Timesheet_SupervisorApproval_Timesheet.aspx.vb"
    Inherits="Webvantage.Timesheet_SupervisorApproval" MasterPageFile="~/ChildPage.Master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentMain" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <table style="width: 500px; border: 0px solid black;" align="center">
            <tr>
                <td style="text-align: left; vertical-align: middle;">Day
                </td>
                <td style="width: 120px; text-align: center; vertical-align: middle;">Status
                </td>
                <td style="width: 20px; text-align: right; vertical-align: middle;">&nbsp;
                </td>
                <td style="width: 120px; text-align: center; vertical-align: middle;">Action
                </td>
            </tr>
            <tr>
                <td colspan="4" style="border-bottom:1px solid #cecece;"></td>
            </tr>
            <tr runat="server" id="TrSunday" style="height: 30px;">
                <td style="text-align: left; vertical-align: middle;">
                    <asp:Label ID="LabelSundayText" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="HfSunday" runat="server" />
                </td>
                <td style="text-align: center; vertical-align: middle;">
                    <asp:Label ID="LblSunday" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: center; vertical-align: middle;padding-bottom:10px;">
                    <asp:ImageButton ID="ImgBtnSundayNotes" runat="server" SkinID="ImageButtonEdit" />
                </td>
                <td style="text-align: center; vertical-align: middle;">
                    <asp:LinkButton ID="LnkBtnSunday" runat="server"></asp:LinkButton>
                </td>
            </tr>
            <tr runat="server" id="TrMonday" style="height: 30px;">
                <td style="text-align: left; vertical-align: middle;">
                    <asp:Label ID="LabelMondayText" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="HfMonday" runat="server" />
                </td>
                <td style="text-align: center; vertical-align: middle;">
                    <asp:Label ID="LblMonday" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: center; vertical-align: middle; padding-bottom: 10px;">
                    <asp:ImageButton ID="ImgBtnMondayNotes" runat="server" SkinID="ImageButtonEdit" />
                </td>
                <td style="text-align: center; vertical-align: middle;">
                    <asp:LinkButton ID="LnkBtnMonday" runat="server"></asp:LinkButton>
                </td>
            </tr>
            <tr runat="server" id="TrTuesday" style="height: 30px;">
                <td style="text-align: left; vertical-align: middle;">
                    <asp:Label ID="LabelTuesdayText" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="HfTuesday" runat="server" />
                </td>
                <td style="text-align: center; vertical-align: middle;">
                    <asp:Label ID="LblTuesday" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: center; vertical-align: middle; padding-bottom: 10px;">
                    <asp:ImageButton ID="ImgBtnTuesdayNotes" runat="server" SkinID="ImageButtonEdit" />
                </td>
                <td style="text-align: center; vertical-align: middle;">
                    <asp:LinkButton ID="LnkBtnTuesday" runat="server"></asp:LinkButton>
                </td>
            </tr>
            <tr runat="server" id="TrWednesday" style="height: 30px;">
                <td style="text-align: left; vertical-align: middle;">
                    <asp:Label ID="LabelWednesdayText" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="HfWednesday" runat="server" />
                </td>
                <td style="text-align: center; vertical-align: middle;">
                    <asp:Label ID="LblWednesday" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: center; vertical-align: middle; padding-bottom: 10px;">
                    <asp:ImageButton ID="ImgBtnWednesdayNotes" runat="server" SkinID="ImageButtonEdit" />
                </td>
                <td style="text-align: center; vertical-align: middle;">
                    <asp:LinkButton ID="LnkBtnWednesday" runat="server"></asp:LinkButton>
                </td>
            </tr>
            <tr runat="server" id="TrThursday" style="height: 30px;">
                <td style="text-align: left; vertical-align: middle;">
                    <asp:Label ID="LabelThursdayText" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="HfThursday" runat="server" />
                </td>
                <td style="text-align: center; vertical-align: middle;">
                    <asp:Label ID="LblThursday" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: center; vertical-align: middle; padding-bottom: 10px;">
                    <asp:ImageButton ID="ImgBtnThursdayNotes" runat="server" SkinID="ImageButtonEdit" />
                </td>
                <td style="text-align: center; vertical-align: middle;">
                    <asp:LinkButton ID="LnkBtnThursday" runat="server"></asp:LinkButton>
                </td>
            </tr>
            <tr runat="server" id="TrFriday" style="height: 30px;">
                <td style="text-align: left; vertical-align: middle;">
                    <asp:Label ID="LabelFridayText" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="HfFriday" runat="server" />
                </td>
                <td style="text-align: center; vertical-align: middle;">
                    <asp:Label ID="LblFriday" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: center; vertical-align: middle; padding-bottom: 10px;">
                    <asp:ImageButton ID="ImgBtnFridayNotes" runat="server" SkinID="ImageButtonEdit" />
                </td>
                <td style="text-align: center; vertical-align: middle;">
                    <asp:LinkButton ID="LnkBtnFriday" runat="server"></asp:LinkButton>
                </td>
            </tr>
            <tr runat="server" id="TrSaturday" style="height: 30px;">
                <td style="text-align: left; vertical-align: middle;">
                    <asp:Label ID="LabelSaturdayText" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="HfSaturday" runat="server" />
                </td>
                <td style="text-align: center; vertical-align: middle;">
                    <asp:Label ID="LblSaturday" runat="server" Text=""></asp:Label>
                </td>
                <td style="text-align: center; vertical-align: middle; padding-bottom: 10px;">
                    <asp:ImageButton ID="ImgBtnSaturdayNotes" runat="server" SkinID="ImageButtonEdit" />
                </td>
                <td style="text-align: center; vertical-align: middle;">
                    <asp:LinkButton ID="LnkBtnSaturday" runat="server"></asp:LinkButton>
                </td>
            </tr>
        </table>
        <div class="bottom-buttons">
            <asp:Button ID="BtnSubmitAll" runat="server" Text="Submit All" />&nbsp;
            <asp:Button ID="BtnUnSubmitAll" runat="server" Text="Un-submit All" />&nbsp;
            <asp:Button ID="BtnClose" runat="server" Text="Close" />
        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
