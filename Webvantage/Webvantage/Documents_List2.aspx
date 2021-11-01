<%@ Page Title="Documents" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Documents_List2.aspx.vb" Inherits="Webvantage.Documents_List2" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
        <script type="text/javascript">
            function RadToolbarInvoiceDocumentsJsOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();
                if (comandName == "Delete") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                }
            }
            function returnValue() {
                //Get a reference to the parent (MDI) page 
                var oWnd = GetRadWindow();
                //get a reference to the second RadWindow
                var CallingWindowName = '<%= Me.OpenerRadWindowName %>';
                var CallingWindow = oWnd.get_windowManager().getWindowByName(CallingWindowName);
                // Get a reference to the first RadWindow's content
                var CallingWindowContent = CallingWindow.get_contentFrame().contentWindow;
                //Call the predefined function in Dialog1
                var controlsToSet = "";
                controlsToSet = document.getElementById("<%= HiddenFieldControlsToSet.ClientID%>").value;
                var ContentPageHiddenField = CallingWindowContent.document.getElementById("ctl00_ContentPlaceHolderMain_ContentPageHiddenFieldLookupPassthrough");

                if (ContentPageHiddenField) {
                    cts = controlsToSet;
                    ContentPageHiddenField.value = cts;
                    CallingWindowContent.setIFrameContentControls();
                } else {
                    eval(controlsToSet);
                };
                //Close the second RadWindow
                //oWnd.close();
            }

            function closeWindow() {
                var oWnd = $find('<%=RadWindowLookUp.ClientID %>');

                oWnd.Close();
            }

<%--            function OpenRadWindow(title,WindowURL, WindowHeight,WindowWidth,whoknows) {
                try {
                    if (typeof WindowURL === 'undefined') {
                        alert('No page to navigate');
                        return false;
                    }
                    if (typeof OpenerWindowName === 'undefined') {
                        OpenerWindowName = '';
                    }
                    if (typeof WindowHeight === 'undefined') {
                        WindowHeight = 700;
                    }
                    if (typeof WindowWidth === 'undefined') {
                        WindowWidth = 620;
                    }

                    WindowHeight = 550;
                    WindowWidth = 550;

                    var WindowNameParam = '';
                    if (WindowURL.indexOf(".aspx?") > -1) {
                        WindowNameParam = "&opener=" + OpenerWindowName;
                    } else {
                        if (WindowURL.indexOf("?") === -1) {
                            WindowNameParam = "?";
                        } else {
                            WindowNameParam = "&";
                        }
                        WindowNameParam += "opener=" + OpenerWindowName;
                    }
                    var mainContentHeight = window.innerHeight;
                    var mainContentWidth = window.innerWidth;
                    if (WindowHeight >= mainContentHeight) {
                        WindowHeight = mainContentHeight - 10;
                    }
                    if (WindowWidth >= mainContentWidth) {
                        WindowWidth = mainContentWidth - 10;
                    }
                    var oWnd = $find('<%=RadWindowLookUp.ClientID %>');
                    window.setTimeout(function () {
                        oWnd.setActive(true);
                        oWnd.set_height(WindowHeight);
                        oWnd.set_width(WindowWidth);
                        oWnd.set_modal(true);
                        oWnd.set_visibleTitlebar(true);
                        oWnd.set_visibleStatusbar(false);
                        oWnd.set_behaviors(Telerik.Web.UI.WindowBehaviors.Resize + Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Close);
                        oWnd.moveTo(((window.innerWidth - WindowWidth) / 2), 0);
                        oWnd.setUrl(WindowURL);
                        oWnd.Parent = this;
                        oWnd.show();
                    }, 1);
                } catch (err) {
                    alert("Error opening window\n" + err);
                }
            }--%>

            function refreshGrid(){
                __doPostBack('onclick#RebindGrid', 'RebindGrid');
            }
        </script>
        <style>
            .thumbnail {
                height: 100px !important;
                width: auto !important;
            }
        </style>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadToolBar ID="RadToolbarInvoiceDocuments" runat="server" AutoPostBack="True" Width="100%" OnClientButtonClicking="RadToolbarInvoiceDocumentsJsOnClientButtonClicking">
        <Items>
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonUpload" runat="server" SkinID="RadToolBarButtonUpload" Visible="false"
                Text="" Value="Upload" CommandName="Upload" ToolTip="Upload a document" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonDownload"
                Text="" Value="Download" CommandName="Download" ToolTip="Download this document" />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton ID="RadToolBarButtonDelete" runat="server" SkinID="RadToolBarButtonDelete" Value="Delete" CommandName="Delete" ToolTip="Delete selected file" Visible="false" />
            <telerik:RadToolBarButton ID="RadToolBarButtonDeleteSeparator" runat="server" IsSeparator="true" Visible="false" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh" CommandName="Refresh" ToolTip="Refresh file list" />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonThumbnails" Value="ShowThumbnails" CommandName="ShowThumbnails" CheckOnClick="true" AllowSelfUnCheck="true" Checked="false" CausesValidation="false" />     <telerik:RadToolBarButton SkinId="RadToolBarButtonBookmark" Text="" Value="Bookmark"
                ToolTip="Bookmark" Visible="false" />
            <telerik:RadToolBarButton IsSeparator="true" Value="BookmarkSeparator" Visible="false" />
        </Items>
    </telerik:RadToolBar>
    <table style="width:100%;">
        <tr>
            <td style="width:100%;">
    <telerik:RadGrid ID="RadgridInvoiceDocuments" runat="server" AllowMultiRowSelection="True" AllowSorting="True"
        AutoGenerateColumns="False" GridLines="None"
        Width="100%" ShowGroupPanel="False" >

        <MasterTableView AllowMultiColumnSorting="true" Width="100%" DataKeyNames="ID">
            <Columns>
                <telerik:GridClientSelectColumn>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </telerik:GridClientSelectColumn>
                <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="GridTemplateColumnThumbnail" HeaderAbbr="FIXED">
                    <HeaderStyle Width="100" />
                    <ItemStyle Width="100" />
                    <FooterStyle Width="100" />
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonThumbnail" runat="server" CssClass="thumbnail" Visible="false" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="GridTemplateColumnLabels" Visible="true">
                    <HeaderStyle CssClass="radgrid-icon-column" />
                    <ItemStyle CssClass="radgrid-icon-column" />
                    <FooterStyle CssClass="radgrid-icon-column" />
                    <ItemTemplate>
                        <div id="DivDocumentLabels" runat="server" class="icon-background background-color-sidebar">
                            <asp:ImageButton ID="ImageButtonEditDetails" runat="server" SkinID="ImageButtonEditWhite" />
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="GridTemplateColumnDocumentIcon">
                    <HeaderStyle CssClass="radgrid-icon-column" />
                    <ItemStyle CssClass="radgrid-icon-column" />
                    <FooterStyle CssClass="radgrid-icon-column" />
                    <ItemTemplate>
                        <div id="DivDocumentType" runat="server" class="icon-background background-color-sidebar">
                            <asp:LinkButton ID="LinkButtonDocumentType" runat="server" Text="" ToolTip="" CommandName="Download" CssClass="icon-text" CommandArgument='<%# Eval("ID")%>'></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn GroupByExpression="FileName Filename Group By FileName"
                    HeaderText="Filename" SortExpression="FileName" UniqueName="GridTemplateColumnFileName">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="210" />
                    <ItemStyle CssClass="radgrid-description-column" />
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonDownload" runat="server" CommandName="Download" Text=""></asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="Description" HeaderText="Description" UniqueName="GridBoundColumnDescription">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemStyle CssClass="radgrid-description-column" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="DocumentTypeDescription" HeaderText="Type" UniqueName="GridBoundColumnDocumentType">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FileSize" DataFormatString="{0:#,### KB}" HeaderText="Size"
                    UniqueName="GridBoundColumnFileSize">
                    <HeaderStyle Width="70" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle Width="70" HorizontalAlign="Center" VerticalAlign="Middle" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="UserCode" HeaderText="Uploaded By" UniqueName="UserNameColumn">
                    <HeaderStyle Width="90" HorizontalAlign="Right" VerticalAlign="Middle" />
                    <ItemStyle Width="90" HorizontalAlign="Right" VerticalAlign="Middle" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="UploadedDate" HeaderText="Date/Time" UniqueName="GridBoundColumnUploadedDate">
                    <HeaderStyle Width="140" HorizontalAlign="Right" VerticalAlign="Middle" />
                    <ItemStyle CssClass="radgrid-datetime-column" VerticalAlign="Middle" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="Private" UniqueName="GridTemplateColumnIsPrivate">
                    <HeaderStyle CssClass="radgrid-icon-column" />
                    <ItemStyle CssClass="radgrid-icon-column" />
                    <FooterStyle CssClass="radgrid-icon-column" />
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBoxIsPrivate" runat="server" Checked='<%# Webvantage.MiscFN.IntToBool(Eval("IsPrivate"))%>'
                            Enabled="false" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAddComments">
                    <HeaderStyle CssClass="radgrid-icon-column" />
                    <ItemStyle CssClass="radgrid-icon-column" />
                    <FooterStyle CssClass="radgrid-icon-column" />
                    <ItemTemplate>
                        <div id="DivAddComments" runat="server" class="icon-background background-color-sidebar">
                            <asp:ImageButton ID="ImageButtonAddComments" runat="server" SkinID="ImageButtonCommentWhite" ToolTip="Click to add comment to this document" Visible="false" />
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnHistory">
                    <HeaderStyle CssClass="radgrid-icon-column" />
                    <ItemStyle CssClass="radgrid-icon-column" />
                    <FooterStyle CssClass="radgrid-icon-column" />
                    <ItemTemplate>
                        <div id="DivDocumentHistory" runat="server" class="icon-background background-color-sidebar">
                            <asp:LinkButton ID="LinkButtonDocumentHistory" runat="server" Text="H" ToolTip="Show document history" CommandName="ShowHistory" CssClass="icon-text" CommandArgument='<%# Eval("ID")%>'></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            <ExpandCollapseColumn Visible="False">
                <HeaderStyle Width="19px" />
            </ExpandCollapseColumn>
            <RowIndicatorColumn Visible="False">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
        </MasterTableView>
        <ClientSettings AllowColumnsReorder="True" AllowDragToGroup="False" >
            <Resizing AllowColumnResize="false" EnableRealTimeResize="True" />
            <Selecting AllowRowSelect="true" />
        </ClientSettings>
    </telerik:RadGrid>

            </td>
        </tr>
    </table>
        <telerik:RadWindow ID="RadWindowLookUp" runat="server" VisibleStatusbar="false" VisibleOnPageLoad="false">
        </telerik:RadWindow>
    <asp:HiddenField ID="HiddenFieldControlsToSet" runat="server" Value="" />
</asp:Content>
