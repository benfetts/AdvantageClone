<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Maintenance_ProfileAdministration.aspx.vb" Inherits="Webvantage.Maintenance_ProfileAdministration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
        <script type="text/javascript">
            function RowClick(index) {
                return false;
            }
        </script>

        <script type="text/javascript">

            function JsOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();

                if (comandName == "Clear") {
                    ////args.set_cancel(!confirm('Are you sure you want to clear selected rows?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to clear selected rows?");
                }
            }

        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
    <div  style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
        <telerik:RadToolBar ID="RadToolbarSchedule" runat="server" AutoPostBack="True" Width="100%"
            OnClientButtonClicking="JsOnClientButtonClicking">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonSaveAll" SkinID="RadToolBarButtonSave"
                    Text="" Value="Save" DisplayType="TextImage" ToolTip="Save" />
                <telerik:RadToolBarButton ID="RadToolbarButtonClearSettings" SkinID="RadToolBarButtonClear" CommandName="Clear"
                    Text="Clear Settings" Value="Clear" DisplayType="TextImage" Hidden="False" ToolTip="Clear Settings" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="Bookmark" Value="Bookmark" ToolTip="Bookmark" />
                <telerik:RadToolBarButton Text="Fix Thumbnails" Value="FixThumbs" CommandName="FixThumbs" ToolTip="Resizes all employee images down to 100px" visible="false"></telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>

    <div class="telerik-aqua-body">
        <telerik:RadGrid ID="RadGridProfiles" runat="server" AllowMultiRowEdit="False" AllowMultiRowSelection="True" AllowFilteringByColumn="true"
            AllowSorting="true" EnableEmbeddedSkins="True" AutoGenerateColumns="False" AllowPaging="true"
            EnableAJAX="true" GridLines="None">
            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
            <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
            <ClientSettings AllowColumnsReorder="False" EnablePostBackOnRowClick="False">
                <Selecting AllowRowSelect="True" />
                <ClientEvents />
            </ClientSettings>
            <GroupingSettings GroupByFieldsSeparator=" " CaseSensitive="false" />
            <MasterTableView DataKeyNames="EMP_PICTURE_ID,EMP_CODE" HorizontalAlign="right">
                <Columns>
                    <telerik:GridClientSelectColumn UniqueName="ColClientSelect">
                        <HeaderStyle HorizontalAlign="center" Width="5px" />
                        <ItemStyle HorizontalAlign="center" Width="5px" />
                    </telerik:GridClientSelectColumn>
                    <telerik:GridBoundColumn DataField="EMP_NAME" HeaderText="Employee" UniqueName="ColEMP_NAME" SortExpression="EMP_NAME" Visible="false"
                        FilterControlWidth="200" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EMP_FNAME" HeaderText="First Name" UniqueName="ColFIRST_NAME" SortExpression="EMP_FNAME"
                        FilterControlWidth="120" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EMP_MI" HeaderText="MI" UniqueName="ColMI" SortExpression="EMP_MI"
                        FilterControlWidth="40" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Left" Width="10" />
                        <ItemStyle HorizontalAlign="Left" Width="10" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EMP_LNAME" HeaderText="Last Name" UniqueName="ColLAST_NAME" SortExpression="EMP_LNAME"
                        FilterControlWidth="120" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn HeaderText="Nickname" UniqueName="ColNickName" SortExpression="EMP_NICKNAME"
                        FilterControlWidth="120" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:TextBox ID="TextBoxNickname" runat="server" MaxLength="10" Text='<%# Eval("EMP_NICKNAME") %>' Width="120" SkinID="TextBoxStandard"></asp:TextBox>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Image<div style='font-size:x-small;'>* Maximum size: 500KB<br/>** Allowed file types: .jpg, .jpeg, .gif, .png, .bmp<div/>" UniqueName="ColEmpPic" SortExpression="EMP_IMAGE" AllowFiltering="false">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <div>
                                <div style="display: inline-block; vertical-align: top;">
                                    <dx:ASPxBinaryImage ID="ASPxBinaryImageEmp" runat="server" CssClass="wv-employee-img-thumbnail-xxlg" BinaryStorageMode="Session" EmptyImage-Url="~/Images/Icons/Grey/256/user.png">
                                    </dx:ASPxBinaryImage>
                                </div>
                                <div style="display: inline-block; vertical-align: top;">
                                    <telerik:RadAsyncUpload ID="RadUploadEmployee" runat="server" Width="250" ControlObjectsVisibility="None">
                                    </telerik:RadAsyncUpload>
                                    <br />
                                    <asp:LinkButton ID="LinkButtonRemoveEmployeePicture" runat="server" Text="Remove" CommandName="Remove" CommandArgument='<%# Eval("EMP_CODE") %>'></asp:LinkButton>
                                </div>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Wallpaper (Maximum size for wallpaper is 400 KB)" UniqueName="ColWallpaper" SortExpression="EMP_WALLPAPER" Display="false" Visible="false">
                        <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="left" />
                        <ItemTemplate>
                            <dx:ASPxBinaryImage ID="ASPxBinaryImageWP" runat="server" BinaryStorageMode="Session" Width="200px" Height="100px">
                            </dx:ASPxBinaryImage>
                            <telerik:RadAsyncUpload ID="RadUploadWP" runat="server" Width="250" ControlObjectsVisibility="None">
                            </telerik:RadAsyncUpload>
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
    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
