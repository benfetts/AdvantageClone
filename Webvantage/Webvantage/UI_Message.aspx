<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="UI_Message.aspx.vb" Inherits="Webvantage.UI_Message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="padding: 10px;padding-top:25px;">
        <telerik:RadMultiPage ID="RadMultiPageMessages" runat="server">
            <telerik:RadPageView ID="RadPageViewSetColors" runat="server">
                <div>
                    <div style="float: left;width:60px;">
                        <asp:ImageButton ID="ImageButtonPalette" runat="server" ImageUrl="~/Images/Icons/Color/256/painters_palette2.png" Height="48" Width="48" OnClientClick="OpenRadWindow('Colors','MySettings_Colors.aspx');return false;" />      
                    </div>
                    <div style="float: left;width:450px;">
                        <div style="font-weight: 700; font-size: 18px;margin-bottom:15px;">
                            Did you know you can change the colors of the workspace and the sidebars?
                        </div>
                        <div>
                            Just go to "<asp:LinkButton ID="LinkButtonMySettings" runat="server" Text="My Settings" OnClientClick="OpenRadWindow('','MySettings.aspx');return false;"></asp:LinkButton>" or use the palette icon next to your name in the user sidebar!
                        </div>

                    </div>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageViewMobileApps" runat="server">
                <div>
                    <div style="float: left; width: 450px;">
                        <div style="font-weight: 700; font-size: 18px; margin-bottom: 15px;">
                            Did you know there is an Advantage mobile app?
                        </div>
                        <div>
                            <div>
                                <a href="https://play.google.com/store/apps/details?id=app.id_97dea075d743478ca7802bff9d28df20">
                                    <img alt="Android app on Google Play"
                                        src="https://developer.android.com/images/brand/en_app_rgb_wo_45.png" />
                                </a>
                            </div>
                            <div>
                                <a href="https://itunes.apple.com/us/app/advantage-software-mobile/id966676849?mt=8&uo=6&at=&ct=" target="itunes_store" 
                                    style="display: inline-block; overflow: hidden; background: url(http://linkmaker.itunes.apple.com/images/badges/en-us/badge_appstore-lrg.png) no-repeat; 
                                    width: 165px; height: 40px; @media only screen{background-image: url(http://linkmaker.itunes.apple.com/images/badges/en-us/badge_appstore-lrg.svg);}"></a>                            

                            </div>
                        </div>
                    </div>
                </div>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
        <div style="width: 90%; padding: 15px; overflow: hidden;margin-top:10px;">
            <div style="float: left; margin-right: 10px;">
                <telerik:RadButton ID="RadButtonRemindMeLater" runat="server" Text="Remind me again tomorrow."></telerik:RadButton>
            </div>
            <div style="float: left;">
                <telerik:RadButton ID="RadButtonDontBother" runat="server" Text="I got it; don't bother me again!"></telerik:RadButton>
            </div>
        </div>
    </div>
</asp:Content>
