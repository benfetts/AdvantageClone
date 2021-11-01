<%@ Page Title="Client Portal Administration" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Maintenance_ClientPortalAdministration.aspx.vb" Inherits="Webvantage.Maintenance_ClientPortalAdministration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
<telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
        <script language="javascript" type="text/javascript">
            function RowClick(index) {
                return false;
            }
        </script>
        
        <script type="text/javascript">

            function JsOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();

                if (comandName == "Clear") {
                    args.set_cancel(!confirm('Are you sure you want to clear selected rows?'));
                }
            }

        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table border="0" cellpadding="2" cellspacing="0" width="100%">
            <tr>
                <td>
                    <telerik:RadToolBar ID="RadToolbarSchedule" runat="server" AutoPostBack="True" Width="100%"
                        OnClientButtonClicking="JsOnClientButtonClicking">
                        <Items>
                            <telerik:RadToolBarButton IsSeparator="true" />
                            <telerik:RadToolBarButton ID="RadToolbarButtonSaveAll" ImageUrl="Images/disk_blue.png"
                                Text="" Value="Save" DisplayType="TextImage" ToolTip="Save" />
                            <telerik:RadToolBarButton ID="RadToolbarButtonClearSettings" ImageUrl="Images/undo.png" CommandName="Clear"
                                Text="Clear Settings" Value="Clear" DisplayType="TextImage" Hidden="False" ToolTip="Clear Settings" />
                            <telerik:RadToolBarButton IsSeparator="true" />
                        </Items>
                    </telerik:RadToolBar>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadGrid ID="RadGridProfiles" runat="server" AllowMultiRowEdit="False" AllowMultiRowSelection="True"
                        AllowSorting="true" EnableEmbeddedSkins="True" AutoGenerateColumns="False" AllowPaging="true"
                        EnableAJAX="true" GridLines="None" Width="1200px" >
                        <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                        <ClientSettings AllowColumnHide="True">
                            <Scrolling UseStaticHeaders="False" />
                            <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
                            <ClientEvents OnRowClick="RowClick" />
                        </ClientSettings>
                        <PagerStyle Mode="NextPrev" AlwaysVisible="false" Position="Bottom" Height="20px">
                        </PagerStyle>
                        <MasterTableView DataKeyNames="BINARY_IMAGE_ID,CL_CODE" HorizontalAlign="right" Width="1200px">
                            <Columns>
                                <telerik:GridClientSelectColumn UniqueName="ColClientSelect">
                                   <HeaderStyle HorizontalAlign="center" Width="5px" />
                                   <ItemStyle HorizontalAlign="center" Width="5px" />
                                </telerik:GridClientSelectColumn>
                                <telerik:GridBoundColumn DataField="CL_NAME" HeaderText="Client" UniqueName="ColCL_NAME">
                                   <HeaderStyle HorizontalAlign="left" Width="400px" />
                                   <ItemStyle HorizontalAlign="left" Width="400px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CL_CODE" HeaderText="" UniqueName="ColCL_CODE" Visible="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn DataField="" HeaderText="Wallpaper" UniqueName="colWVWallpaper">
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="DropDownListWVWallpaper" runat="server" Width="180px">
                                            <Items>
                                                <telerik:RadComboBoxItem Text="" Value="" />
                                                <telerik:RadComboBoxItem Text="'Tis the Season" Value="blue_ornaments.jpg" />
                                                <telerik:RadComboBoxItem Text="A Place in the Sun" Value="APlaceInTheSun.jpg" />
                                                <telerik:RadComboBoxItem Text="Air Bubbles" Value="blue_lights.jpg" />
                                                <telerik:RadComboBoxItem Text="Are you still up?" Value="AreYouStillUp.jpg" />
                                                <telerik:RadComboBoxItem Text="Autumn's Harvest" Value="HappyThanksgiving.jpg" />
                                                <telerik:RadComboBoxItem Text="Beach" Value="blue_beach.jpg" />
                                                <telerik:RadComboBoxItem Text="Beer Me" Value="wallpaper-813308.jpg" />
                                                <telerik:RadComboBoxItem Text="Berries" Value="blue_berries.jpg" />
                                                <telerik:RadComboBoxItem Text="Black Carbon Fiber" Value="black_carbon.jpg" />
                                                <telerik:RadComboBoxItem Text="Blue Carbon Fiber" Value="blue_carbon.jpg" />
                                                <telerik:RadComboBoxItem Text="Blue Cove" Value="blue_cove.jpg" />
                                                <telerik:RadComboBoxItem Text="Blue Jelly" Value="blue_jelly.jpg" />
                                                <telerik:RadComboBoxItem Text="Blue Ocean" Value="BlueOcean.jpg" />
                                                <telerik:RadComboBoxItem Text="Blue Swirls" Value="blue_swirlies.jpg" />
                                                <telerik:RadComboBoxItem Text="Blue Wave" Value="wallpaper-103927.jpg" />
                                                <telerik:RadComboBoxItem Text="Blue Wisp" Value="wallpaper-704242.jpg" />
                                                <telerik:RadComboBoxItem Text="Blurry" Value="wallpaper-103929.jpg" />
                                                <telerik:RadComboBoxItem Text="Bridge" Value="blue_bridge.jpg" />
                                                <telerik:RadComboBoxItem Text="Bubble Time" Value="wallpaper-147713.jpg" />
                                                <telerik:RadComboBoxItem Text="Burrrrr!!!! (It's Cold)" Value="burrrrrrr.jpg" />
                                                <telerik:RadComboBoxItem Text="Candy Canes" Value="candy_canes.jpg" />
                                                <telerik:RadComboBoxItem Text="Cracks" Value="blue_cracks.jpg" />
                                                <telerik:RadComboBoxItem Text="Cubes" Value="blue_cubes.jpg" />
                                                <telerik:RadComboBoxItem Text="Gust of Wind" Value="green_flowers.jpg" />
                                                <telerik:RadComboBoxItem Text="Grid" Value="blue_3d_grid.jpg" />
                                                <telerik:RadComboBoxItem Text="Have a Seat" Value="have_a_seat.jpg" />
                                                <telerik:RadComboBoxItem Text="Heart Twirl" Value="heart_twir.jpg" />
                                                <telerik:RadComboBoxItem Text="Let the Chips Fall..." Value="let_the_chips_fall.jpg" />
                                                <telerik:RadComboBoxItem Text="Metro" Value="metro1.jpg" />
                                                <telerik:RadComboBoxItem Text="Metro Dark" Value="metro_dark.jpg" />
                                                <telerik:RadComboBoxItem Text="Metros" Value="metro2.jpg" />
                                                <telerik:RadComboBoxItem Text="Midnight Forest" Value="blue_forest.jpg" />
                                                <telerik:RadComboBoxItem Text="Monument Valley" Value="MonumentValley.jpg" />
                                                <telerik:RadComboBoxItem Text="Night Lights" Value="blue_dots.jpg" />
                                                <telerik:RadComboBoxItem Text="O'er the Land of the Free" Value="OldGlory2.jpg" />
                                                <telerik:RadComboBoxItem Text="Old Glory" Value="OldGlory.jpg" Visible="false" />
                                                <telerik:RadComboBoxItem Text="Paneling" Value="wallpaper-16618.jpg" />
                                                <telerik:RadComboBoxItem Text="Petals" Value="sky_flower.jpg" />
                                                <telerik:RadComboBoxItem Text="Pretty Fishies!" Value="PrettyFishies.jpg" />
                                                <telerik:RadComboBoxItem Text="Pretty in Pink" Value="pinkish_flowers.jpg" />
                                                <telerik:RadComboBoxItem Text="Rain" Value="blue_rain.jpg" />
                                                <telerik:RadComboBoxItem Text="Road to Castle Mountain" Value="CastleMountain.jpg" />
                                                <telerik:RadComboBoxItem Text="Splatter" Value="wallpaper-82748.jpg" />
                                                <telerik:RadComboBoxItem Text="Storm" Value="blue_storm.jpg" />
                                                <telerik:RadComboBoxItem Text="Surf's Up" Value="SurfsUp2.jpg" />
                                                <telerik:RadComboBoxItem Text="Tarnished Gold" Value="wallpaper-518742.jpg" />
                                                <telerik:RadComboBoxItem Text="This Seat Is Taken" Value="ThisSeatIsTaken.jpg" />
                                                <telerik:RadComboBoxItem Text="Tranquility" Value="wallpaper-676462.jpg" />
                                                <telerik:RadComboBoxItem Text="Wheat Field" Value="hay_wheet.jpg" />
                                                <telerik:RadComboBoxItem Text="Zig Zag" Value="blue_waves.jpg" />
                                            </Items>
                                        </telerik:RadComboBox>
                                    </ItemTemplate>
                                    <HeaderStyle VerticalAlign="bottom" Width="400px" />
                                    <ItemStyle VerticalAlign="middle" Width="400px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="" HeaderText="Solid Color" UniqueName="colSolidColor">
                                    <ItemTemplate>
                                        <telerik:RadColorPicker ID="RadColorPickerBackground" runat="server" AutoPostBack="True"
                                                KeepInScreenBounds="true" Preset="None" PreviewColor="true" ShowIcon="true" PaletteModes="WebPalette,HSB"
                                                ShowEmptyColor="False">
                                                <%-- Yellows --%>
                                                <telerik:ColorPickerItem Value="#Fefac9" />
                                                <telerik:ColorPickerItem Value="#Fff39d" />
                                                <telerik:ColorPickerItem Value="#Ffe834" />
                                                <telerik:ColorPickerItem Value="#F1d925" />
                                                <telerik:ColorPickerItem Value="#Ccb400" />
                                                <telerik:ColorPickerItem Value="#9f8700" />
                                                <%--  Browns --%>
                                                <telerik:ColorPickerItem Value="#A89a80" />
                                                <telerik:ColorPickerItem Value="#C19859" />
                                                <telerik:ColorPickerItem Value="#Ab8243" />
                                                <telerik:ColorPickerItem Value="#D19049" />
                                                <telerik:ColorPickerItem Value="#Bb7a33" />
                                                <%-- Taupe  --%>
                                                <telerik:ColorPickerItem Value="#A26A2D" />
                                                <telerik:ColorPickerItem Value="#Ebddc3" />
                                                <telerik:ColorPickerItem Value="#D7c6bb" />
                                                <telerik:ColorPickerItem Value="#B1a095" />
                                                <telerik:ColorPickerItem Value="#C0b9c8" />
                                                <telerik:ColorPickerItem Value="#C2aaa0" />
                                                <telerik:ColorPickerItem Value="#9c95a4" />
                                                <telerik:ColorPickerItem Value="#9c847a" />
                                                <telerik:ColorPickerItem Value="#A57474" />
                                                <%-- Orange  --%>
                                                <telerik:ColorPickerItem Value="#Ffca54" />
                                                <telerik:ColorPickerItem Value="#Ffb33d" />
                                                <telerik:ColorPickerItem Value="#Ffa42e" />
                                                <telerik:ColorPickerItem Value="#F07f09" />
                                                <telerik:ColorPickerItem Value="#F79646" />
                                                <telerik:ColorPickerItem Value="#E18030" />
                                                <telerik:ColorPickerItem Value="#Da6900" />
                                                <telerik:ColorPickerItem Value="#C35200" />
                                                <telerik:ColorPickerItem Value="#Ca6919" />
                                                <%-- Reds  --%>
                                                <telerik:ColorPickerItem Value="#C0504d" />
                                                <telerik:ColorPickerItem Value="#C40912" />
                                                <telerik:ColorPickerItem Value="#C44e5b" />
                                                <telerik:ColorPickerItem Value="#D16349" />
                                                <telerik:ColorPickerItem Value="#A4361c" />
                                                <telerik:ColorPickerItem Value="#Ea7481" />
                                                <telerik:ColorPickerItem Value="#Ff6a73" />
                                                <telerik:ColorPickerItem Value="#Ff444d" />
                                                <telerik:ColorPickerItem Value="#E8b7b7" />
                                                <telerik:ColorPickerItem Value="#D2a1a1" />
                                                <%-- Blues  --%>
                                                <telerik:ColorPickerItem Value="#D2ecf0" />
                                                <telerik:ColorPickerItem Value="#A9bfd2" />
                                                <telerik:ColorPickerItem Value="#94b6d2" />
                                                <telerik:ColorPickerItem Value="#A8cdd7" />
                                                <telerik:ColorPickerItem Value="#7c92a5" />
                                                <telerik:ColorPickerItem Value="#738ac8" />
                                                <telerik:ColorPickerItem Value="#4be8ff" />
                                                <telerik:ColorPickerItem Value="#5abaff" />
                                                <telerik:ColorPickerItem Value="#43a3fa" />
                                                <telerik:ColorPickerItem Value="#25c2fe" />
                                                <telerik:ColorPickerItem Value="#0087c3" />
                                                <%-- Greens  --%>
                                                <telerik:ColorPickerItem Value="#9cb084" />
                                                <telerik:ColorPickerItem Value="#869a6e" />
                                                <telerik:ColorPickerItem Value="#99d08d" />
                                                <telerik:ColorPickerItem Value="#73aa67" />
                                                <telerik:ColorPickerItem Value="#8fb08c" />
                                                <telerik:ColorPickerItem Value="#799a76" />
                                                <telerik:ColorPickerItem Value="#7ba79d" />
                                                <telerik:ColorPickerItem Value="#7cca62" />
                                                <telerik:ColorPickerItem Value="#66b44c" />
                                                <telerik:ColorPickerItem Value="#39871f" />
                                                <telerik:ColorPickerItem Value="#A5c249" />
                                                <telerik:ColorPickerItem Value="#8fac33" />
                                                <telerik:ColorPickerItem Value="#627f06" />
                                                <telerik:ColorPickerItem Value="#B0ccb0" />
                                                <telerik:ColorPickerItem Value="#839f83" />
                                                <telerik:ColorPickerItem Value="#B2b5a0" />
                                                <telerik:ColorPickerItem Value="#3fd8c4" />
                                                <telerik:ColorPickerItem Value="#55a157" />
                                                <telerik:ColorPickerItem Value="#D2da7a" />
                                                <telerik:ColorPickerItem Value="#A5ad4d" />
                                                <telerik:ColorPickerItem Value="#8f9871" />
                                                <telerik:ColorPickerItem Value="#Cff57e" />
                                                <telerik:ColorPickerItem Value="#A9cf58" />
                                                <%--  Purples --%>
                                                <telerik:ColorPickerItem Value="#A379bb" />
                                                <telerik:ColorPickerItem Value="#Eb98ee" />
                                                <telerik:ColorPickerItem Value="#D481d7" />
                                                <telerik:ColorPickerItem Value="#E74bca" />
                                                <telerik:ColorPickerItem Value="#B34bca" />
                                                <telerik:ColorPickerItem Value="#9c85c0" />
                                                <telerik:ColorPickerItem Value="#866faa" />
                                                <telerik:ColorPickerItem Value="#Cf6da4" />
                                                <%--  Grays --%>
                                                <telerik:ColorPickerItem Value="#333333" />
                                                <telerik:ColorPickerItem Value="#Eaebde" />
                                                <telerik:ColorPickerItem Value="#Bdbeb1" />
                                                <telerik:ColorPickerItem Value="#D8d8d8" />
                                            </telerik:RadColorPicker>
                                    </ItemTemplate>
                                    <HeaderStyle VerticalAlign="bottom" Width="200px" />
                                    <ItemStyle VerticalAlign="middle" Width="200px" />
                                </telerik:GridTemplateColumn><telerik:GridTemplateColumn DataField="" HeaderText="Background" UniqueName="colBackground">
                                    <ItemTemplate>
                                        <asp:RadioButton id="RadioButtonWallpaper" runat="server" Text="Wallpaper" GroupName="Background" Checked="true" Width="80px"/>
                                        <asp:RadioButton id="RadioButtonSolidColor" runat="server" Text="Solid Color" GroupName="Background"/>
                                    </ItemTemplate>
                                    <HeaderStyle VerticalAlign="bottom" Width="200px" />
                                    <ItemStyle VerticalAlign="middle" Width="200px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="" HeaderText="Theme" UniqueName="colTheme">
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="DropDownListTheme" runat="server" Width="400px">
                                            <Items>
                                                <telerik:RadComboBoxItem Text="" Value="" />
                                                <telerik:RadComboBoxItem Text="Blue" Value="Office2007" ImageUrl="Images/Blue/UiThumbs/Office.jpg" />
                                                <telerik:RadComboBoxItem Text="Metro" Value="Metro" Visible="true" ImageUrl="Images/Blue/UiThumbs/Metro.jpg" />
                                                <telerik:RadComboBoxItem Text="Windows7" Value="Windows7" ImageUrl="Images/Blue/UiThumbs/Windows7.jpg" />
                                                <telerik:RadComboBoxItem Text="Black" Value="Black" ImageUrl="Images/Blue/UiThumbs/Black.jpg"
                                                    Visible="false" />
                                                <telerik:RadComboBoxItem Text="Outlook" Value="Outlook" ImageUrl="Images/Blue/UiThumbs/Outlook.jpg" />
                                                <telerik:RadComboBoxItem Text="Vista" Value="Vista" ImageUrl="Images/Blue/UiThumbs/Vista.jpg" />
                                                <telerik:RadComboBoxItem Text="Silver" Value="Default" ImageUrl="Images/Blue/UiThumbs/Silver.jpg" />
                                                <telerik:RadComboBoxItem Text="Simple" Value="Simple" ImageUrl="Images/Blue/UiThumbs/Simple.jpg" />
                                                <telerik:RadComboBoxItem Text="Brushed" Value="Telerik" ImageUrl="Images/Blue/UiThumbs/Brushed.jpg" />
                                                <telerik:RadComboBoxItem Text="Web Blue" Value="WebBlue" ImageUrl="Images/Blue/UiThumbs/WebBlue.jpg" />
                                                <telerik:RadComboBoxItem Text="Web 2.0" Value="Web20" ImageUrl="Images/Blue/UiThumbs/Web20.jpg" />
                                                <telerik:RadComboBoxItem Text="Forest" Value="Forest" ImageUrl="Images/Blue/UiThumbs/Forest.jpg" />
                                                <telerik:RadComboBoxItem Text="Hay" Value="Hay" ImageUrl="Images/Blue/UiThumbs/Hay.jpg" />
                                                <telerik:RadComboBoxItem Text="Sunset" Value="Sunset" ImageUrl="Images/Blue/UiThumbs/Sunset.jpg" />
                                            </Items>
                                        </telerik:RadComboBox>
                                    </ItemTemplate>
                                    <HeaderStyle VerticalAlign="bottom" Width="200px" />
                                    <ItemStyle VerticalAlign="middle" Width="200px" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Logo<br/>(Maximum size for Logo is 200 KB)<br/>" UniqueName="ColEmpPic" SortExpression="BINARY_IMAGE_LOGO">
                                    <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Width="400px" />
                                    <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Width="400px" />
                                    <ItemTemplate>
                                        <dx:ASPxBinaryImage ID="ASPxBinaryImageCPLogo" runat="server" BinaryStorageMode="Session" Width="200px" Height="100px">
                                                    </dx:ASPxBinaryImage>
                                        <telerik:RadUpload ID="RadUploadCPLogo" runat="server" Width="400px" ControlObjectsVisibility="None">
                                                       </telerik:RadUpload>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Wallpaper (Maximum size for Wallpaper is 400 KB)" UniqueName="ColWallpaper" SortExpression="BINARY_IMAGE_WP">
                                    <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Width="400px" />
                                    <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Width="400px" />
                                    <ItemTemplate>
                                        <dx:ASPxBinaryImage ID="ASPxBinaryImageCPWallpaper" runat="server" BinaryStorageMode="Session" Width="200px" Height="100px">
                                                        </dx:ASPxBinaryImage>
                                        <telerik:RadUpload ID="RadUploadCPWallpaper" runat="server" Width="400px" ControlObjectsVisibility="None">
                                                       </telerik:RadUpload>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <ExpandCollapseColumn Resizable="False" Visible="False">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <RowIndicatorColumn Visible="False">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
    </table>
</asp:Content>
