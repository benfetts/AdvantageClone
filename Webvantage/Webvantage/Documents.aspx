<%@ Page AutoEventWireup="false" CodeBehind="Documents.aspx.vb" Inherits="Webvantage.DocumentsPage"
    Language="vb" MasterPageFile="~/ChildPage.Master" %>
<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain"
    EnableViewState="true">
    <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
        <script type="text/javascript">

            function RadToolbarDocumentManagerJsOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();
                if (comandName == "Delete") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                }
                if (comandName == "AdvancedSearch") {
                    OpenRadWindow('Advanced Document Search', 'Documents_AdvancedSearch.aspx', 0, 0);
                }
                if (comandName == "StorageLabel") {
                    return false;
                }
                if (comandName == "CloseWindow") {
                    window.close();
                }
                if (comandName == "ConfirmTest") {
                    //radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                    console.log("confirm test", ShowKendoConfirm("TEST"))
                    //ShowKendoConfirm("TEST").done(function () {
                    //    console.log("YES")
                    //}).fail(function () {
                    //    console.log("NO")
                    //})
                }

            };
            function RadGridDocumentsColumnHeaderMenu(ev) {
                var grid = $find("<%= RadGridDocuments.ClientID%>");
                grid.get_masterTableView().get_columns()[0].showHeaderMenu(ev, 30, 40);
            };
            function loadFileImage(documentId, image) {
                try {
                    //alert("loadFileImage()")
                    window.setTimeout(function () {
                        //var data = {
                        //    DocumentID: documentId
                        //};
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: 'Utilities/Document/DownloadImageSourceAsBase64',
                            //dataType: "json",
                            //data: JSON.stringify(data),
                            data: documentId,
                            success: function (result) {
                                if (result) {
                                    ShowMessage(result.Filename);
                                    ShowMessage(result.ImageString);
                                }
                            },
                            error: function (msg) {
                            }
                        });
                    }, 1);
                } catch (e) {
                }
            }
        </script>
        <style>
            .thumbnail {
                height: 100px !important;
                width: auto !important;
            }
        </style>
    </telerik:RadScriptBlock>
    <div class="no-float-menu">
    <telerik:RadToolBar ID="RadToolbarDocumentManager" runat="server" OnClientButtonClicking="RadToolbarDocumentManagerJsOnClientButtonClicking"
            width="100%">
            <Items>
                <telerik:RadToolBarButton Text="Label View" Value="LabelView" CommandName="LabelView" ToolTip="Label View" Visible="True" />
                <telerik:RadToolBarButton IsSeparator="true" Value="LabelViewSeparator" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonUpload" Value="Upload"
                    ToolTip="Upload a document" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonDownload" Value="Download"
                    ToolTip="Download this document" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonDelete" Text="Delete" Value="Delete" CommandName="Delete" Enabled="false"
                    ToolTip="Delete selected file" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh"
                    ToolTip="Refresh file list" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Value="RadToolBarButtonSearch">
                    <ItemTemplate>
                        <asp:TextBox ID="SearchCriteriaTextBox" runat="server" Width="125px" SkinID="TextBoxStandard"></asp:TextBox>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton SkinID="RadToolBarButtonFind" Text="Search" Value="Search" CommandName="Search"
                    ToolTip="Search" />
                <telerik:RadToolBarButton Text="Clear" SkinID="RadToolBarButtonClear" Value="ClearSearch"
                    ToolTip="Clears the search text box" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Advanced Search" Value="AdvancedSearch"
                    CommandName="AdvancedSearch" ToolTip="Go to Advanced Search" />
                <telerik:RadToolBarButton IsSeparator="true" Value="ProofHQDownloadSeparator" Visible="false" />
                <telerik:RadToolBarButton Text="Upload to Proof HQ" Value="ProofHQUpload"
                    ToolTip="Upload document to Proof HQ" Visible="false" Enabled="false" />
                <telerik:RadToolBarButton Text="Download From Proof HQ" Value="ProofHQDownload"
                    ToolTip="Download document from Proof HQ" Visible="false" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonThumbnails" Value="ShowThumbnails" CommandName="ShowThumbnails" CheckOnClick="true" AllowSelfUnCheck="true" Checked="false" CausesValidation="false" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ImageUrl="Images/Icons/Grey/256/data.png" Text="" Value="StorageLabel" CommandName="StorageLabel"
                    ToolTip="" />
               <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="Bookmark" Value="Bookmark" ToolTip="Bookmark" />
                <telerik:RadToolBarButton Text="Confirm Test" Value="ConfirmTest" Visible="false"
                    CommandName="ConfirmTest" ToolTip="Confirm Test" />
            </Items>
        </telerik:RadToolBar>
    </div>
    
<%--    <telerik:RadToolTipManager ID="RadToolTipManagerLabels" runat="server" Animation="None" RenderMode="Classic"
        AutoTooltipify="false" Height="400" ManualClose="true" Modal="true" OnAjaxUpdate="OnAjaxUpdate" ContentScrolling="Auto"
        Position="BottomLeft" RelativeTo="Element" ShowEvent="OnClick" Sticky="true" Width="250">
    </telerik:RadToolTipManager>--%>
    <div class="telerik-aqua-body">
        <div class="two-col-leftcolumn" style="padding-top: 10px; border: 1px solid transparent!important;">
            <div class="card">
                <div class="card-content" style="margin-bottom: 20px;">
                    <asp:Panel ID="Panel_FilterFields" runat="server">
                        <div>
                            <div style="padding: 0px 0px 10px 0px;">
                                <div>
                                    Level:
                                </div>
                                <div>
                                    <telerik:RadComboBox ID="DocLevelDropDownList" runat="server" AutoPostBack="true" Width="165px" SkinID="RadComboBoxStandard">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Please Select" Value=""></telerik:RadComboBoxItem>
                                        </Items>
                                    </telerik:RadComboBox>
                                </div>
                            </div>
                            <div id="TrDesktopObject" runat="server">
                                <div>
                                    Desktop Object:
                                </div>
                                <div>
                                    <telerik:RadComboBox ID="ddlDesktopObject" runat="server" AutoPostBack="true" Width="165px" SkinID="RadComboBoxStandard">
                                        <Items>
                                        </Items>
                                    </telerik:RadComboBox>
                                </div>
                            </div>
                            <div id="TrOffice" runat="server">
                                <div>
                                    <asp:HyperLink ID="hlOffice" runat="server" href="">Office:</asp:HyperLink>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtOffice" runat="server" Width="145px" ClientIDMode="Static" SkinID="TextBoxStandard"></asp:TextBox>
                                </div>
                            </div>
                            <div id="TrClient" runat="server">
                                <div>
                                    <asp:HyperLink ID="hlClient" runat="server" href="">Client:</asp:HyperLink>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtClient" runat="server" Width="145px" ClientIDMode="Static" SkinID="TextBoxStandard"></asp:TextBox>
                                </div>
                            </div>
                            <div id="TrDivision" runat="server">
                                <div>
                                    <asp:HyperLink ID="hlDivision" runat="server" href="">Division:</asp:HyperLink>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtDivision" runat="server" Width="145px" ClientIDMode="Static" SkinID="TextBoxStandard"></asp:TextBox>
                                </div>
                            </div>
                            <div id="TrProduct" runat="server">
                                <div>
                                    <asp:HyperLink ID="hlProduct" runat="server" href="">Product:</asp:HyperLink>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtProduct" runat="server" Width="145px" ClientIDMode="Static" SkinID="TextBoxStandard"></asp:TextBox>
                                </div>
                            </div>
                            <div id="TrCampaign" runat="server">
                                <div>
                                    <asp:HyperLink ID="hlCampaign" runat="server" href="">Campaign:</asp:HyperLink>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtCampaign" runat="server" Width="145px" ClientIDMode="Static" SkinID="TextBoxStandard"></asp:TextBox>
                                    <asp:TextBox ID="txtCampaignID" runat="server" Visible="false" SkinID="TextBoxStandard"></asp:TextBox>
                                    <asp:HiddenField ID="hfCampaignID" runat="server" ClientIDMode="Static" />
                                </div>
                            </div>
                            <div id="TrJob" runat="server">
                                <div>
                                    <asp:HyperLink ID="hlJob" runat="server" href="">Job:</asp:HyperLink>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtJob" runat="server" Width="145px" ClientIDMode="Static" SkinID="TextBoxStandard"></asp:TextBox>
                                </div>
                            </div>
                            <div id="TrComponent" runat="server">
                                <div>
                                    <asp:HyperLink ID="hlComponent" runat="server" href="">Component:</asp:HyperLink>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtComponent" runat="server" Width="145px" ClientIDMode="Static" SkinID="TextBoxStandard"></asp:TextBox>
                                </div>
                            </div>
                            <div id="TrVendor" runat="server">
                                <div>
                                    <asp:HyperLink ID="hlVendor" runat="server" href="">Vendor:</asp:HyperLink>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtVendor" runat="server" Width="145px" SkinID="TextBoxStandard"></asp:TextBox>
                                </div>
                            </div>
                            <div id="TrAPInvoice" runat="server">
                                <div>
                                    <asp:HyperLink ID="hlAPInvoice" runat="server" href="">Inv Number:</asp:HyperLink>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtAPInvoice" runat="server" Width="145px" SkinID="TextBoxStandard"></asp:TextBox>
                                </div>
                            </div>
                            <div id="TrDept" runat="server">
                                <div>
                                    <asp:HyperLink ID="hlDept" runat="server" href="">Dept:</asp:HyperLink>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtDept" runat="server" Width="145px" SkinID="TextBoxStandard"></asp:TextBox>
                                </div>
                            </div>
                            <div id="TrAdNumber" runat="server">
                                <div>
                                    <asp:HyperLink ID="hlAdNumber" runat="server" href="">Ad Number:</asp:HyperLink>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtAdNumber" runat="server" Width="145px" SkinID="TextBoxStandard"></asp:TextBox>
                                </div>
                            </div>
                            <div id="TrEmp" runat="server">
                                <div>
                                    <asp:HyperLink ID="hlEmp" runat="server" href="">Employee:</asp:HyperLink>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtEmp" runat="server" MaxLength="6" Width="145px" SkinID="TextBoxStandard"></asp:TextBox>
                                </div>
                            </div>
                            <div id="TrExInv" runat="server">
                                <div>
                                    <asp:HyperLink ID="hlExInv" runat="server" href="">Inv Number:</asp:HyperLink>
                                </div>
                                <div>
                                    <asp:TextBox ID="txtExInv" runat="server" Width="145px" SkinID="TextBoxStandard"></asp:TextBox>
                                </div>
                            </div>
                            <div id="Div_AccountsReceivableInvoice" runat="server">
                             <div>
                                    <asp:HyperLink ID="HyperLink_AccountsReceivableClient" runat="server" href="" ClientIDMode="Static">Client:</asp:HyperLink>
                                </div>
                                <div>
                                    <asp:TextBox ID="TextBox_AccountsReceivableClient" runat="server" Width="145px" ClientIDMode="Static" SkinID="TextBoxStandard"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:HyperLink ID="HyperLink_AccountsReceivableInvoice" runat="server" href="">Inv Number:</asp:HyperLink>
                                </div>
                                <div>
                                    <asp:TextBox ID="TextBox_AccountsReceivableInvoice" runat="server" Width="145px" ClientIDMode="Static" SkinID="TextBoxStandard"></asp:TextBox>
                                </div>
                            </div>
                            <div style="padding: 10px 0px 0px 0px;">
                                <div>
                                    <asp:Button ID="ApplyFilterButton" runat="server" Text="Apply" />
                                    <asp:Button ID="ClearFilterButton" runat="server" Text="Clear" />
                                </div>
                            </div>
                        </div>
                    </asp:Panel>

                </div>
                <div class="card-action-bar card-bottom-header card-bottom-header-bg">
                    <div class="card-bottom-header-text">
                        Find
                    </div>
                </div>
            </div>
        </div>
        <div class="two-col-rightcolumn" style="padding: 8px 0px 0px 4px;">
            <telerik:RadGrid ID="RadGridDocuments" runat="server" AllowMultiRowSelection="true" AllowSorting="True"
                AutoGenerateColumns="False" GridLines="None" ShowGroupPanel="False" ShowHeader="true">
                <ClientSettings AllowColumnsReorder="False" AllowDragToGroup="False">
                    <Resizing AllowColumnResize="false" EnableRealTimeResize="False" />
                    <Selecting AllowRowSelect="true" UseClientSelectColumnOnly="True" />
                </ClientSettings>
                <MasterTableView AllowMultiColumnSorting="true">
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="CheckBoxTemplateColumn" HeaderAbbr="FIXED">
                            <HeaderStyle CssClass="radgrid-icon-column"  />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="SelectCheckBox" runat="server" AutoPostBack="True" OnCheckedChanged="ToggleRowSelection" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
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
                        <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="GridTemplateColumnDocumentType">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div id="DivDocumentType" runat="server" class="icon-background background-color-sidebar">
                                    <asp:LinkButton ID="LinkButtonDocumentType" runat="server" Text="" ToolTip=""
                                        CommandName="Download" CssClass="icon-text" CommandArgument='<%# Eval("DOCUMENT_ID")%>'></asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="LEVEL" HeaderText="Level" UniqueName="GridBoundColumnLevel">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn GroupByExpression="FILENAME Filename Group By FILENAME"
                            HeaderText="Filename" SortExpression="FILENAME" UniqueName="GridTemplateColumnFileName">
                            <HeaderStyle CssClass="radgrid-description-column" />
                            <ItemStyle CssClass="radgrid-description-column" />
                            <FooterStyle CssClass="radgrid-description-column" />
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButtonDownload" runat="server" Text='<%#Eval("FILENAME")%>' CommandName="Download" CommandArgument='<%# Eval("DOCUMENT_ID")%>'></asp:LinkButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="DESCRIPTION" HeaderText="File Description" UniqueName="GridTemplateColumnDescription">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <ItemStyle CssClass="radgrid-description-column" />
                            <ItemTemplate>
                                <asp:Label ID="LabelDescription" runat="server" Text='<%#Eval("DESCRIPTION")%>' ToolTip='<%#Eval("DESCRIPTION")%>'></asp:Label>              
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="DOCUMENT_TYPE_DESC" HeaderText="Type" UniqueName="GridBoundColumnType">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FILE_SIZE" DataFormatString="{0:#,### KB}" HeaderText="Size"
                            UniqueName="GridBoundColumnFileSize">
                            <HeaderStyle Width="90" HorizontalAlign="Right" VerticalAlign="Middle" />
                            <ItemStyle Width="90" HorizontalAlign="Right" VerticalAlign="Middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="USER_CODE" HeaderText="Uploaded By" UniqueName="GridBoundColumnUserCode">
                            <HeaderStyle Width="90" HorizontalAlign="Right" VerticalAlign="Middle" />
                            <ItemStyle Width="90" HorizontalAlign="Right" VerticalAlign="Middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="UPLOADED_DATE" HeaderText="Date/Time" UniqueName="GridBoundColumnUploadedDate">
                            <HeaderStyle CssClass="radgrid-datetime-column" />
                            <ItemStyle CssClass="radgrid-datetime-column" />
                            <FooterStyle CssClass="radgrid-datetime-column" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn HeaderText="Private" UniqueName="colChkPrivate">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <telerik:RadButton ID="RadButtonPrivate" runat="server" ButtonType="ToggleButton" ToggleType="CheckBox" AutoPostBack="false" Checked='<%# SetCheckBox(Eval("PRIVATE_FLAG"))%>' ReadOnly="true">
                                </telerik:RadButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAddComments">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div id="DivAddComments" runat="server" class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImageButtonAddComments" runat="server" SkinID="ImageButtonCommentWhite" oolTip="Click to add comment to this document" Visible="false" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnHistory">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div id="DivDocumentHistory" runat="server" class="icon-background background-color-sidebar">
                                    <asp:LinkButton ID="LinkButtonDocumentHistory" runat="server" Text="H" ToolTip="Show document history" CommandName="ShowHistory" CssClass="icon-text" CommandArgument='<%# Eval("DOCUMENT_ID")%>'></asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnProofHQ" Visible="false">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div id="DivProofHQ" runat="server" class="icon-background background-color-sidebar">
                                    <asp:LinkButton ID="LinkButtonProofHQ" runat="server" Text="PHQ" ToolTip="Click to go to Proof HQ" CommandName="ProofHQLink" CssClass="icon-text-three" CommandArgument='<%# Eval("DOCUMENT_ID")%>'></asp:LinkButton>
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
                    <NoRecordsTemplate>
                        There are no files in this folder.
                    </NoRecordsTemplate>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </div>
    <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
</asp:Content>
