<%@ Page AutoEventWireup="false" CodeBehind="Estimating.aspx.vb" Inherits="Webvantage.Estimating"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Estimate" %>
<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>

<asp:Content ID="ContentEstimate" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadScriptBlock ID="RadScriptBlock3" runat="server">
        <script type="text/javascript">
            function DisplayDetails() {
                var divDetails = document.getElementById('divDetails');

                divDetails.style.display = "inline";
            };
            function confirmRows() {
                ShowMessage("No rows were selected for deletion.")
            };
            function showhide(id) {
                if (document.getElementById) {
                    obj = document.getElementById(id);
                    if (obj.style.display == "none") {
                        obj.style.display = "";
                    } else {
                        obj.style.display = "none";
                    };
                };
            };
            function enableobject(type, id1, id2, estcomp, client, division, product, sales, job) {
                if (document.getElementById) {
                    obj = document.getElementById(id1);
                    obj2 = document.getElementById(id2);
                    objclient = document.getElementById(client).value;
                    objdivision = document.getElementById(division).value;
                    objproduct = document.getElementById(product).value;
                    if (obj.value == '') {
                        obj2.disabled = false;
                        if (type == 'joblink') {
                            var url = 'LookUp.aspx?form=estimatejc&type=jobestimate&client=' + objclient + '&division=' + objdivision + '&product=' + objproduct;
                            obj2.setAttribute("onclick", "OpenRadWindowLookup(url)");
                        };
                        var a = 1;
                    } else {
                        obj2.disabled = true;
                        obj2.onclick = '';
                    };
                };
            };
            function JsRadToolbarEstimateOnClientButtonClicking(sender, args) {
                var commandName = args.get_item().get_commandName();
                if (commandName == "DelEst" || commandName == "DelQuote" || commandName == "DelComp") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                };
                if (commandName == "WvPermaLink") {
                    <%=Me.WebvantageLink%>
                    args.set_cancel(true);
                }
                if (commandName == "CpPermaLink") {
                    <%=Me.ClientPortalLink%>
                    args.set_cancel(true);
                }
            };

            function refreshPage() {
                    _doPostBack("#onclick:Refresh", "Refresh");
            }

            function mngRequestStarted(ajaxManager, eventArgs) 
            { 
                if (eventArgs.get_eventTarget().indexOf("imgbtnEdit") != -1) {
                    eventArgs.set_enableAjax(false); 
                }
                    
            } 

        </script>
    </telerik:RadScriptBlock>
    <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
        <telerik:RadToolBar ID="RadToolbarEstimate" runat="server" AutoPostBack="true" OnClientButtonClicking="JsRadToolbarEstimateOnClientButtonClicking"
            Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Text="" Value="SaveAll"
                    ToolTip="Save this estimate" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonFind" Text="Search" Value="Search"
                    ToolTip="Estimate Search" />
                <telerik:RadToolBarButton IsSeparator="true" Value="SeparatorSearch" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonCopy" Text="Copy" Value="Copy" ToolTip="Copy estimate" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="New Estimate" Value="NewEstimate"
                    ToolTip="Add New Estimate" />
                <telerik:RadToolBarButton Text="New Component" Value="NewComp"
                    ToolTip="Add New Component" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Delete Estimate" Value="DelEst"
                    ToolTip="Delete Estimate" CommandName="DelEst" />
                <telerik:RadToolBarButton Text="Delete Component" Value="DelComp"
                    ToolTip="Delete Component" CommandName="DelComp" />
                <telerik:RadToolBarButton ID="RadToolBarButtonPrint"
                    Text="Print/Send" Value="PrintSendOptions" ToolTip="Print/Send" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonAlerts" Value="Alerts" ToolTip="Alerts" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAlert" Text="" Value="Notify"
                    Visible="False" ToolTip="New Alert" />
                <telerik:RadToolBarButton IsSeparator="true" Value="SeparatorJob" />
                <telerik:RadToolBarButton Text="Create Job" Value="CreateJob" ToolTip="Create Job" />
                <telerik:RadToolBarDropDown Text="Print/Send2">
                    <Buttons>
                        <telerik:RadToolBarButton Text="Print" Value="Print" ToolTip="Print" />
                        <telerik:RadToolBarButton Text="Send Alert" Value="SendAlert" ToolTip="Send Alert" />
                        <telerik:RadToolBarButton Text="Send Assignment" Value="SendAssignment" ToolTip="Send Assignment" />
                        <telerik:RadToolBarButton Text="Send Email" Value="SendEmail" ToolTip="Send Email" />
                        <telerik:RadToolBarButton Text="Options" Value="PrintSendOptions" ToolTip="Print/Send Options" />
                        <telerik:RadToolBarButton Value="RadToolBarButtonPrintSendAllComponents">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBoxPrintSendAllComponents" runat="server" Text="All Components" ToolTip="Print/Send all Components for this Estimate" Checked="true" />
                            </ItemTemplate>
                        </telerik:RadToolBarButton>
                    </Buttons>
                </telerik:RadToolBarDropDown>
                <telerik:RadToolBarButton IsSeparator="true" Value="PrintSendSeparator" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="Bookmark" Value="Bookmark" ToolTip="Bookmark" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="RefreshAll"
                    ToolTip="Refresh" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark" ToolTip="Bookmark" Visible="false" />
                <telerik:RadToolBarSplitButton Visible="false" DropDownWidth="125">
                    <Buttons>
                        <telerik:RadToolBarButton Text="WV Link" Value="WvPermaLink" CommandName="WvPermaLink" ToolTip="Create Webvantage link for use in other systems" Visible="True" />
                        <telerik:RadToolBarButton Text="CP Link" Value="CpPermaLink" CommandName="CpPermaLink" ToolTip="Create Client Portal link for use in other systems" Visible="True" />
                    </Buttons>
                </telerik:RadToolBarSplitButton>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Remove Job" Value="RemoveJob" ToolTip="Remove job from estimate." />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
        <ew:CollapsablePanel ID="CollapsablePanelHeader" runat="server" TitleText="Estimate Information">
            <div style="text-align: right">
                <asp:Label ID="LblRush" runat="server" CssClass="RUSH" Text="RUSH&nbsp;&nbsp;" Visible="false"></asp:Label>
            </div>
            <div style="display: inline-block;" id="divCDP" runat="server">
                <div class="code-description-container">
                    <div class="code-description-label">
                        Client:
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtClientCode" runat="server" TabIndex="1" Text="" SkinID="TextBoxCodeSmall"
                            MaxLength="6" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtClientDescription" runat="server" ReadOnly="true" TabIndex="-1" SkinID="TextBoxStandard"
                            Text="" Width="300px"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Division:
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtDivisionCode" runat="server" TabIndex="2" Text="" SkinID="TextBoxCodeSmall"
                            MaxLength="6" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtDivisionDescription" runat="server" ReadOnly="true" TabIndex="-1" SkinID="TextBoxStandard"
                            Text="" Width="300px"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Product:
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtProductCode" runat="server" TabIndex="3" Text="" SkinID="TextBoxCodeSmall"
                            MaxLength="6" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtProductDescription" runat="server" ReadOnly="true" TabIndex="-1" SkinID="TextBoxStandard"
                            Text="" Width="300px"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        &nbsp;
                    </div>
                    <div class="code-description-code">
                        &nbsp;
                    </div>
                    <div class="code-description-description">
                        &nbsp;
                    </div>
                </div>
            </div>
            <div style="display: inline-block;">
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:RadioButton ID="rbEstimate" runat="server" Text="" GroupName="rbEstJob" Visible="false" />
                        <asp:LinkButton ID="LbEstimate" runat="server">Estimate:</asp:LinkButton>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtEstimate" runat="server" CssClass="RequiredInput" TabIndex="3"
                            Text="" SkinID="TextBoxCodeSmall" MaxLength="6" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtEstimateDescription" runat="server" TabIndex="-1" Text="" Width="300px" SkinID="TextBoxStandard"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:LinkButton ID="LbEstimateComponent" runat="server">Component:</asp:LinkButton>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtEstimateComponent" runat="server" CssClass="RequiredInput" TabIndex="3"
                            Text="" SkinID="TextBoxCodeSmall" MaxLength="3" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtEstimateComponentDescription" runat="server" TabIndex="-1" Text="" SkinID="TextBoxStandard"
                            Width="300px"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container" id="divJob" runat="server">
                    <div class="code-description-label">
                        <asp:RadioButton ID="rbJob" runat="server" Text="" GroupName="rbEstJob" Visible="false" />
                        <asp:HyperLink ID="HlJob" runat="server" href="">Job:</asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtJobNum" runat="server" CssClass="RequiredInput" TabIndex="6" Text=""
                            SkinID="TextBoxCodeSmall" MaxLength="6"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtJobDescription" runat="server" ReadOnly="true" TabIndex="-1" SkinID="TextBoxStandard"
                            Text="" Width="300px"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container" id="divComponent" runat="server">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlComponent" runat="server" href="">Component:</asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtJobCompNum" runat="server" CssClass="RequiredInput" TabIndex="7"
                            Text="" SkinID="TextBoxCodeSmall" MaxLength="3" AutoPostBack="True"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtJobCompDescription" runat="server" ReadOnly="true" TabIndex="-1" SkinID="TextBoxStandard"
                            Text="" Width="300px"></asp:TextBox>
                    </div>
                </div>
            </div>
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelComments" runat="server" TitleText="Comments">
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="left" valign="top">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="right" valign="top" width="13%">
                                    <span>Estimate:</span>
                                </td>
                                <td align="left" valign="top" width="2%">&nbsp;
                                </td>
                                <td align="left" valign="top" width="80%">
                                    <telerik:RadEditor ID="RadEditorEstimateComment" runat="server" ToolsFile="~/RadEditorToolbars.xml" NewLineBr="true" NewLineMode="Br" OnClientLoad="RadEditorOnClientLoad" StripFormattingOptions="MsWord"
                                         ContentAreaCssFile="~/CSS/RadEditorContentArea.min.css" EditModes="Design" ContentAreaMode="Div" Width="98%" Height="420" AutoResizeHeight="True" OnClientCommandExecuted="RadEditorOnClientCommandExecuted">
                                    </telerik:RadEditor>
                                </td>
                                <td align="left" valign="top" width="5%">
                                    <asp:ImageButton ID="imgbtnSpecsEst" runat="server" SkinID="ImageButtonInsert" ToolTip="Insert Specifications" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>&nbsp;<br /></td>
                            </tr>
                        </table>
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="right" valign="top" width="13%">
                                    <span>Component:</span>
                                </td>
                                <td align="left" valign="top" width="2%">&nbsp;
                                </td>
                                <td align="left" valign="top" width="80%">
                                    <telerik:RadEditor ID="RadEditorComponentComment" runat="server" ToolsFile="~/RadEditorToolbars.xml" NewLineBr="true" NewLineMode="Br" OnClientLoad="RadEditorOnClientLoad" StripFormattingOptions="MsWord"
                                        ContentAreaCssFile="~/CSS/RadEditorContentArea.min.css" EditModes="Design" ContentAreaMode="Div" Width="98%" Height="420" AutoResizeHeight="True" OnClientCommandExecuted="RadEditorOnClientCommandExecuted">
                                    </telerik:RadEditor>
                                </td>
                                <td align="left" valign="top" width="5%">
                                    <asp:ImageButton ID="imgbtnSpecsComp" runat="server" SkinID="ImageButtonInsert" ToolTip="Insert Specifications" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelCommentsFooter" runat="server" TitleText="Footer Comments">
            <div style="padding-left: 15%;">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <asp:RadioButtonList ID="RadioButtonListFooterComment" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" AutoPostBack="true">
                        <asp:ListItem Text="Use Agency Defined Text" Value="default"></asp:ListItem>
                        <asp:ListItem Text="Use Standard Comment Text" Value="standard"></asp:ListItem>
                        <asp:ListItem Text="Use Customized Text" Value="custom"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:TextBox ID="TextBoxFooterCommentDefault" runat="server" Height="70px" TabIndex="10" Text="" TextMode="MultiLine"
                        Width="650px" ReadOnly="true"></asp:TextBox>
                    <asp:TextBox ID="TextBoxFooterCommentStandard" runat="server" Height="70px" TabIndex="10" Text="" TextMode="MultiLine"
                        Width="650px" ReadOnly="true"></asp:TextBox>
                    <telerik:RadEditor ID="RadEditorFooterCommentCustom" runat="server" Height="310" ToolsFile="~/RadEditorToolbars.xml" NewLineBr="true" NewLineMode="Br" OnClientLoad="RadEditorOnClientLoad" StripFormattingOptions="MsWord"
                        ContentAreaCssFile="~/CSS/RadEditorContentArea.min.css" Width="90%" EditModes="Design" ContentAreaMode="Div" OnClientCommandExecuted="RadEditorOnClientCommandExecuted">
                    </telerik:RadEditor>
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelOtherInformation" runat="server"
            TitleText="Other Information">
            <div style="display: inline-block;">
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:Label ID="lblCampaign" runat="server">Campaign:</asp:Label>
                        <asp:HyperLink ID="HlCampaign" runat="server" href="">Campaign:</asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtCampaignCode" runat="server" TabIndex="10" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtCampaignDescription" runat="server" ReadOnly="true" TabIndex="-1" SkinID="TextBoxStandard"
                            Text="" Width="300px"></asp:TextBox>
                        <asp:HiddenField ID="HiddenfieldCampaignID" runat="server" />
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:Label ID="LabelSalesClass" runat="server" Visible="false"></asp:Label>
                        <asp:HyperLink ID="HlSalesClass" runat="server" href=""></asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtSalesClassCode" runat="server" TabIndex="11" Text="" SkinID="TextBoxCodeSmall"
                            MaxLength="6"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtSalesClassDescription" runat="server" ReadOnly="true" TabIndex="-1" SkinID="TextBoxStandard"
                            Text="" Width="300px"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        &nbsp;
                    </div>
                    <div class="code-description-code">
                        &nbsp;
                    </div>
                    <div class="code-description-description">
                        &nbsp;
                    </div>
                </div>
            </div>
            <div style="display: inline-block;">
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlContact" runat="server" href="">Contact:</asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtContactCode" runat="server" TabIndex="13" Text="" SkinID="TextBoxCodeSmall"
                            MaxLength="6"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtContactDescription" runat="server" ReadOnly="true" TabIndex="-1" SkinID="TextBoxStandard"
                            Text="" Width="300px"></asp:TextBox>
                        <asp:HiddenField ID="HfContactCodeID" runat="server" />
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Client Ref:
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtClientRef" runat="server" ReadOnly="true" TabIndex="14" Text="" SkinID="TextBoxStandard"
                            Width="375px"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Markup %:
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="txtMarkupPercent" runat="server" TabIndex="15" Text="" Width="75px" SkinID="TextBoxStandard"
                            MaxLength="12"></asp:TextBox>
                    </div>
                </div>
            </div>
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelQuotes" runat="server" TitleText="Quotes">
            <asp:Panel ID="PanelEstimateQuote" runat="server" Width="100%">
                <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
                    <script type="text/javascript">
                        function JsRadToolbarEstimateGridOnClientButtonClicking(sender, args) {
                            var comandName = args.get_item().get_commandName();
                            if (comandName == "DelQuote") {
                                ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                                radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                            };
                        };
                    </script>
                </telerik:RadScriptBlock>
                <telerik:RadToolBar ID="RadToolbarEstimateGrid" runat="server" AutoPostBack="true"
                    OnClientButtonClicking="JsRadToolbarEstimateGridOnClientButtonClicking" Width="100%">
                    <Items>
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonAdd" Value="NewQuote"
                            ToolTip="Add New Quote" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonDelete" Value="DelQuote"
                            ToolTip="Delete selected quotes" CommandName="DelQuote" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonCopy" Text="Copy" Value="CopyQuote"
                            Enabled="true" ToolTip="Copy selected quotes" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton Text="Vendor Quote Requests"
                            Value="VendorQuote" Enabled="true" ToolTip="Vendor Quote Requests" />
                    </Items>
                </telerik:RadToolBar>
                <telerik:RadGrid ID="RadGridEstimate" runat="server" AllowMultiRowSelection="True"
                    AutoGenerateColumns="False" GridLines="None" CssClass="grid-width">
                    <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                    <ClientSettings EnablePostBackOnRowClick="true">
                        <Scrolling UseStaticHeaders="False" />
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="true" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="EST_QUOTE_NBR,EST_REV_NBR,EST_QUOTE_DESC" CssClass="grid-width">
                        <Columns>
                            <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                <HeaderStyle HorizontalAlign="Center" Width="5px" />
                                <ItemStyle HorizontalAlign="Center" Width="5px" />
                            </telerik:GridClientSelectColumn>
                            <telerik:GridTemplateColumn UniqueName="colDetails">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="imgbtnEdit" runat="server" AlternateText="Edit Row" CommandArgument='<%#Eval("EST_QUOTE_NBR")%>'
                                            CommandName="EditRow" SkinID="ImageButtonViewWhite" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="EST_QUOTE_NBR" HeaderText="Quote" SortExpression="EST_QUOTE_NBR"
                                UniqueName="EST_QUOTE_NBR">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EST_QUOTE_DESC" HeaderText="Description" SortExpression="EST_QUOTE_DESC"
                                UniqueName="EST_QUOTE_DESC">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EST_REV_NBR" HeaderText="Rev" SortExpression="EST_REV_NBR"
                                UniqueName="EST_REV_NBR">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SUM_AMOUNT" HeaderText="Amount" SortExpression="SUM_AMOUNT"
                                UniqueName="SUM_AMOUNT">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="QUOTE_W_CONTINGENCY" HeaderText="Total With Contingency" SortExpression="QUOTE_W_CONTINGENCY"
                                UniqueName="QUOTE_W_CONTINGENCY">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_QTY" HeaderText="Quantity" SortExpression="JOB_QTY"
                                UniqueName="JOB_QTY">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CPU" HeaderText="CPU" SortExpression="CPU" UniqueName="CPU">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EST_APPR_BY" HeaderText="Approved By" SortExpression="EST_APPR_BY"
                                UniqueName="EST_APPR_BY">
                                <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                <ItemStyle HorizontalAlign="Center" Width="150px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivClientApproved" runat="server" class="icon-background standard-green">
                                        <asp:Image ID="ImageClientApproved" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Client approved" Visible="false" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="EST_APPR_BY_INT" HeaderText="Internally Approved By"
                                SortExpression="EST_APPR_BY_INT" UniqueName="EST_APPR_BY_INT">
                                <HeaderStyle HorizontalAlign="Center" Width="170px" />
                                <ItemStyle HorizontalAlign="Center" Width="170px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivInternalApproved" runat="server" class="icon-background standard-green">
                                        <asp:Image ID="ImageInternalApproved" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Internal approved" Visible="false" />
                                    </div>
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
            </asp:Panel>
            <asp:Panel ID="PanelVendorRequest" runat="server" Width="100%">
                <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
                    <script type="text/javascript">
                        function JsRadToolbarVendorGridOnClientButtonClicking(sender, args) {
                            var comandName = args.get_item().get_commandName();
                            if (comandName == "DelRequest") {
                                ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                                radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                            };
                        };
                    </script>
                </telerik:RadScriptBlock>
                <telerik:RadToolBar ID="RadToolbarVendorGrid" runat="server" AutoPostBack="true"
                    OnClientButtonClicking="JsRadToolbarVendorGridOnClientButtonClicking" Width="99%">
                    <Items>
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton Text="New Request" Value="NewRequest"
                            ToolTip="Add New Request" />
                        <telerik:RadToolBarButton Text="Delete Request" Value="DelRequest"
                            ToolTip="Delete selected request" CommandName="DelRequest" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton Text="Copy Request" Value="CopyRequest"
                            Enabled="true" ToolTip="Copy selected request" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton Text="Quotes" Value="QuoteDisplay"
                            Enabled="true" ToolTip="Quotes" />
                    </Items>
                </telerik:RadToolBar>
                <telerik:RadGrid ID="RadGridVendorRequest" runat="server" AllowMultiRowSelection="True"
                    AutoGenerateColumns="False" GridLines="None" CssClass="grid-width">
                    <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                    <ClientSettings>
                        <Scrolling UseStaticHeaders="False" />
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="ESTIMATE_NUMBER, EST_COMPONENT_NBR, VENDOR_QTE_NBR, APPROVED" CssClass="grid-width">
                        <Columns>
                            <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                <HeaderStyle HorizontalAlign="Center" Width="5px" />
                                <ItemStyle HorizontalAlign="Center" Width="5px" />
                            </telerik:GridClientSelectColumn>
                            <telerik:GridTemplateColumn UniqueName="colDetails">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="imgbtnEdit2" runat="server" AlternateText="Edit Row" CommandArgument='<%#Eval("ESTIMATE_NUMBER")%>'
                                            CommandName="EditRow" SkinID="ImageButtonViewWhite" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="ESTIMATE_NUMBER" HeaderText="RFQ #" SortExpression="ESTIMATE_NUMBER"
                                UniqueName="RFQ">
                                <HeaderStyle HorizontalAlign="center" Width="90px" />
                                <ItemStyle HorizontalAlign="center" Width="90px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EST_COMPONENT_NBR" HeaderText="" SortExpression="EST_COMPONENT_NBR"
                                UniqueName="EST_COMPONENT_NBR" Display="false">
                                <HeaderStyle HorizontalAlign="Right" Width="5px" />
                                <ItemStyle HorizontalAlign="Right" Width="5px"  />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="VENDOR_QTE_NBR" HeaderText="" SortExpression="VENDOR_QTE_NBR"
                                UniqueName="VENDOR_QTE_NBR" Display="false">
                                <HeaderStyle HorizontalAlign="Right" Width="5px"  />
                                <ItemStyle HorizontalAlign="Right" Width="5px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="VENDOR_QTE_DESC" HeaderText="Description" SortExpression="VENDOR_QTE_DESC"
                                UniqueName="VENDOR_QTE_DESC">
                                <HeaderStyle HorizontalAlign="Left" Width="200px" />
                                <ItemStyle HorizontalAlign="Left" Width="200px"/>
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CREATE_DATE" HeaderText="Date" SortExpression="CREATE_DATE"
                                UniqueName="CREATE_DATE">
                                <HeaderStyle HorizontalAlign="Right" Width="50px" />
                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Submitted" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" UniqueName="GridTemplateColumnSUBMITTED">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background standard-green" style='<%# If(Eval("SUBMITTED").ToString.ToUpper() = "YES", "display:block;", "display:none;")%>'>
                                        <asp:Image ID="ImageSubmitted" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Replies" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" UniqueName="GridTemplateColumnREPLIES">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background standard-green" style='<%# If(Eval("REPLIES").ToString.ToUpper() = "YES", "display:block;", "display:none;")%>'>
                                        <asp:Image ID="ImageReplies" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Approved" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" UniqueName="GridTemplateColumnAPPROVED">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivVendorApproved" runat="server" class="icon-background standard-green">
                                        <asp:Image ID="ImageVendorApproved" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Vendor approved" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="APPROVED" HeaderText="" SortExpression="APPROVED"
                                UniqueName="APPROVED" Display="false">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                        </Columns>
                        <ExpandCollapseColumn Resizable="False" Visible="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                    </MasterTableView>
                </telerik:RadGrid>
            </asp:Panel>
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelQuoteComparison" runat="server" TitleText="Quotes" Visible="false">
            <telerik:RadGrid ID="RadGridQuoteComparison" runat="server" AllowMultiRowSelection="false"
                Visible="false" AutoGenerateColumns="true" GridLines="None" Width="100%" ItemStyle-HorizontalAlign="Left"
                MasterTableView-ShowFooter="true">
                <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                <ClientSettings AllowColumnHide="True" AllowExpandCollapse="True">
                    <Scrolling UseStaticHeaders="False" />
                </ClientSettings>
            </telerik:RadGrid>
        </ew:CollapsablePanel>
    </div>

    <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
</asp:Content>
