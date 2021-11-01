<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LookUp_AdNumber.aspx.vb" Inherits="Webvantage.LookUp_AdNumber"
    MasterPageFile="~/ChildPage.Master" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">

            function CloseThisWindow() {
                try {
                    //CloseThisWindow();
                } catch (e) {
                    console.log(e);
                }
                try {
                    var oWnd = GetRadWindow();
                    if (oWnd) {
                        oWnd.close();
                    }
                } catch (e) {
                    console.log(e);
                }
            }

                        function returnValue() {
                var oWnd = GetRadWindow();
                var CallingWindowName = '';
                if (typeof oWnd.get_windowManager !== 'undefined') {
                    var CallingWindow = null;
                    var controlsToSet = "";
                    var CallingWindowContent;
                    controlsToSet = document.getElementById("ctl00_ContentPlaceHolderMain_HiddenFieldControlsToSet").value;
                    try {
                        if (oWnd.get_windowManager()) {
                            CallingWindow = oWnd.get_windowManager().getWindowByName(CallingWindowName);
                        }
                    } catch (e) {
                        CallingWindow = null;
                    }
                    if (!CallingWindow) {
                        console.log("Browser Window?", oWnd.BrowserWindow);
                        CallingWindowContent = oWnd.BrowserWindow;
                        //controlsToSet = controlsToSet.replace("CallingWindowContent.document.getElementById('", "$('#");
                        if (CallingWindowContent) {
                            eval(controlsToSet);
                        }                        
                    } else {
                        CallingWindowContent = CallingWindow.get_contentFrame().contentWindow;
                        var ContentPageHiddenField = CallingWindowContent.document.getElementById("ctl00_ContentPlaceHolderMain_ContentPageHiddenFieldLookupPassthrough");
                        try {
                            if (ContentPageHiddenField) {
                                cts = controlsToSet;
                                ContentPageHiddenField.value = cts;
                                CallingWindowContent.setIFrameContentControls();
                            } else {
                                eval(controlsToSet);
                            }
                        }
                        catch (e) {
                            console.log(e);
                        }
                    }
                    oWnd.close();
                }
                else {
                    controlsToSet = document.getElementById("ctl00_ContentPlaceHolderMain_HiddenFieldControlsToSet").value;
                    controlsToSet = controlsToSet.replace("ctl00_ContentPlaceHolderMain_colpnlJobComponentInformation3_TxtValue_Ad_","ctl00_ContentPlaceHolderMain_colpnlJobComponentInformation3_TxtValue_Ad_#_JOB_COMPONENTAD_NBR");
                    controlsToSet = controlsToSet.replace("CallingWindowContent.document.getElementById('", "$('#");

                    CallingWindowContent = oWnd.BrowserWindow.Parent.frame;
                    if (CallingWindowContent) {
                        eval(controlsToSet);
                    }                        

                    oWnd.close();
                }
            }

        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
    <asp:HiddenField ID="HfRegEx" runat="server" Value="^[a-zA-Z0-9\s\-]*$" />
    <asp:HiddenField ID="HiddenFieldControlsToSet" runat="server" Value="" />
    <asp:MultiView ID="MultiViewAdNumber" runat="server">
        <asp:View ID="ViewGrid" runat="server">
            <div >
                <telerik:RadToolBar ID="RadToolbarAdNumber" runat="server" Width="100%">
                    <Items>
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonNew" Text="New Ad Number" Value="NewAdNumber" ToolTip="Add new Ad Number" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonCancel" Text="Cancel new Ad Number" Value="Cancel" ToolTip="Cancel new Ad Number" />
                    </Items>
                </telerik:RadToolBar>
            </div>
            <div >
            </div>
            <div class="more-info">
                <asp:CheckBox ID="ChkShowThumbnail" runat="server" Text="Show thumbnails" Checked="false"
                    AutoPostBack="true" />
                <asp:CheckBox ID="ChkShowInactive" runat="server" Text="Show inactive" Checked="false"
                    AutoPostBack="true" />
            </div>
            <telerik:RadGrid ID="RadGridAdNumbers" runat="server" AllowMultiRowSelection="False"
                AllowPaging="True" AllowSorting="true" AutoGenerateColumns="False" EnableAJAX="False"
                EnableAJAXLoadingTemplate="False" EnableOutsideScripts="true" GroupingEnabled="true" AllowFilteringByColumn="true"
                PageSize="10" ShowFooter="True" Visible="True" Width="99%">
                <ClientSettings EnablePostBackOnRowClick="true">
                    <Selecting AllowRowSelect="true" EnableDragToSelectRows="True" />
                </ClientSettings>
                <MasterTableView GroupsDefaultExpanded="true" NoMasterRecordsText="No records found"
                    DataKeyNames="AD_NBR">
                    <Columns>
                        <telerik:GridTemplateColumn UniqueName="ColSelect" AllowFiltering="false">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="20px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" />
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" Width="20px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="LBtnSelect" runat="server" CommandName="SelectAdNumber" CommandArgument='<%#Eval("CMD_ARG")%>'>Select</asp:LinkButton>
                                <asp:HiddenField ID="HfAdNumber" runat="server" Value='<%#Eval("AD_NBR")%>' />
                                <asp:HiddenField ID="HfActive" runat="server" Value='<%#Eval("ACTIVE")%>' />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="ColEdit" AllowFiltering="false">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="20px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" />
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" Width="20px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="LBtnEdit" runat="server" CommandName="EditAdNumber" CommandArgument='<%#Eval("AD_NBR")%>'>Edit</asp:LinkButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="ColUpload" AllowFiltering="false">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImgBtnUpload" runat="server" AlternateText="Upload a document" ToolTip="Upload a document" SkinID="ImageButtonUploadWhite" CommandName="Upload" CommandArgument='<%#Eval("AD_NBR")%>' />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn UniqueName="ColAD_NBR" SortExpression="AD_NBR" DataField="AD_NBR" HeaderText="Ad Number"
                            FilterControlWidth="85" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="80px" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="80px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="ColAD_NBR_DESC" SortExpression="AD_NBR_DESC" DataField="AD_NBR_DESC" HeaderText="Description"
                            FilterControlWidth="200" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="225px" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="225px" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="225px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn UniqueName="ColColor" AllowFiltering="false">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Image ID="ImgSpacer" runat="server" ImageUrl="~/Images/spacer.gif" /><asp:HiddenField ID="HfColor" runat="server" Value='<%#Eval("COLOR")%>' />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="ColFILENAME" SortExpression="FILENAME" HeaderText="Filename"
                            FilterControlWidth="200" CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="225px" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="225px" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="225px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="LBtnDownload" runat="server" Text='<%#Eval("FILENAME")%>' CommandName="Download"
                                    CommandArgument='<%#Eval("DOCUMENT_ID")%>'></asp:LinkButton>&nbsp;
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="ColThumbNail" Display="false" Visible="false" AllowFiltering="false">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="20px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="20px" />
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" Width="20px" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgBtnThumbnail" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/Ad_Number_Upload.png"
                                    ToolTip="Click to add a document" AlternateText="Click to add a document" CommandName="ThumbnailClick"
                                    CommandArgument='<%#Eval("DOCUMENT_ID")%>' />
                                <asp:HiddenField ID="HfDocumentId" runat="server" Value='<%#Eval("DOCUMENT_ID")%>' />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                    <RowIndicatorColumn Visible="False">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Resizable="False" Visible="False">
                    </ExpandCollapseColumn>
                </MasterTableView>
            </telerik:RadGrid>
        </asp:View>
        <asp:View ID="ViewInsertEdit" runat="server">
            <asp:HiddenField ID="HfInsertEdit_AdNumber" runat="server" />
            <div class="row-padding">
                <div class="code-description-container">
                <div class="code-description-label">
                    Ad Number:
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtInsertEdit_AdNumber" runat="server" TabIndex="1" CssClass="RequiredInput" SkinID="TextBoxStandard"
                        MaxLength="30" Width="275px"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Description:
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtInsertEdit_AdNumberDescription" runat="server" CssClass="RequiredInput" SkinID="TextBoxStandard"
                        TextMode="MultiLine" Height="45px" TabIndex="1" Width="275px"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HlInsertEdit_Client" runat="server" href="" TabIndex="-1"><span>Client:</span></asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtInsertEdit_ClientCode" runat="server" MaxLength="6" TabIndex="7" SkinID="TextBoxStandard"
                        Text="" Width="63px"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtInsertEdit_ClientDescription" runat="server" ReadOnly="true"
                        TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Blackplate 1:
                </div>
                <div class="code-description-description">
                    <telerik:RadComboBox ID="DropInsertEdit_Blackplate1" runat="server" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Blackplate 2:
                </div>
                <div class="code-description-description">
                    <telerik:RadComboBox ID="DropInsertEdit_Blackplate2" runat="server" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Color:
                </div>
                <div class="code-description-description">
                    <telerik:RadColorPicker ID="RadColorPickerInsertEdit_AdNumberColor" runat="server" Columns="12" Width="400px">
                        <%-- Yellows --%>
                        <telerik:ColorPickerItem Value="#Fefac9" />
                        <telerik:ColorPickerItem Value="#Fff39d" />
                        <%--<telerik:ColorPickerItem Value="#Fff4b" />--%>
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
                        <%--<telerik:ColorPickerItem Value="#Da1f28" />--%>
                        <telerik:ColorPickerItem Value="#Ff6a73" />
                        <telerik:ColorPickerItem Value="#Ff444d" />
                        <telerik:ColorPickerItem Value="#E8b7b7" />
                        <telerik:ColorPickerItem Value="#D2a1a1" />
                        <%-- Blues  --%>
                        <%--<telerik:ColorPickerItem Value="#D6ecff" />--%>
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
                        <%--<telerik:ColorPickerItem Value="#9bbb59" />
                            <telerik:ColorPickerItem Value="#6e8e2c" />--%>
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
                        <%--<telerik:ColorPickerItem Value="#Ac66bb" />--%>
                        <telerik:ColorPickerItem Value="#Cf6da4" />
                        <%--  Grays --%>
                        <telerik:ColorPickerItem Value="#Eaebde" />
                        <telerik:ColorPickerItem Value="#Bdbeb1" />
                        <telerik:ColorPickerItem Value="#D8d8d8" />
                        <%--<telerik:ColorPickerItem Value="#F2f2f2" />--%>
                    </telerik:RadColorPicker>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Inactive:
                </div>
                <div class="code-description-description">
                    <asp:CheckBox ID="ChkInsertEdit_Inactive" runat="server" />
                </div>
            </div>
            </div>
            

            <div style="text-align: center;">
                <asp:Button ID="BtnInsertEditSave" runat="server" Text="Save" />
                &nbsp;&nbsp;
                <asp:Button ID="BtnInsertEditCancel" runat="server" Text="Cancel" />
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>
