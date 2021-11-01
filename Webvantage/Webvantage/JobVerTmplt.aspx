<%@ Page AutoEventWireup="false" CodeBehind="JobVerTmplt.aspx.vb" Inherits="Webvantage.JobVerTmplt"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Job Version Data Entry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
        <script type="text/javascript">
            function RadToolbarJobVersionTemplateOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();
                if (comandName == "Delete") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                };
            };
            function checkMemoLength(sender, args) {
                var editorText = args.Value;
                args.IsValid = editorText.length < 8000;
            }
            function RefreshPage() {
                __doPostBack('onclick#Refresh', 'Refresh');
            }
        </script>
    </telerik:RadScriptBlock>

    <style type="text/css">       
        .RadComboBox_Metro .rcbInput {
            height: 32px !important;
            font-size: 14px !important;
            font-weight: 600 !important;
            font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;
            color: #767676 !important;
        }
        .RadComboBox_Bootstrap .rcbInput {
            height: 32px !important;
            font-size: 14px !important;
            font-weight: 600 !important;
            font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;
            color: #767676 !important;
        }

        .RadComboBoxDropDown_Metro {
            font-size: 14px !important;
            color: #767676 !important;
        }

        .RadComboBoxDropDown_Bootstrap {
            font-size: 14px !important;
            color: #767676 !important;
        }

        .JVlab {
            font-size: 14px !important;
            font-weight: 600 !important;
            font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;
        }               

        .RadInput_Metro .riTextBox, html body .RadInputMgr_Metro {            
            font-size: 14px !important;
            font-weight: 600 !important;
            font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;
            color: #767676 !important;
        }

        .JVTextbox {
            font-size: 14px !important;
            font-weight: 600 !important;
            font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;
            color: #767676 !important;
            height: 25px !important;
        }

        .tdpad {
            padding-top: 3px !important;
            padding-bottom: 3px !important;
        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolbarJobVersionTemplate" runat="server" AutoPostBack="True"
            TabIndex="-1" OnClientButtonClicking="RadToolbarJobVersionTemplateOnClientButtonClicking"
            Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Text="" CausesValidation="true" Value="Save" ToolTip="Save" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonCopy" SkinID="RadToolBarButtonCopy" Text="Copy" Value="Copy" Enabled="true" ToolTip="Copy job version" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonSep3" IsSeparator="true" Value="Sep3" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonDelete" Value="Delete" CommandName="Delete" CausesValidation="false" ToolTip="Delete" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarDropDown runat="server" ID="RadToolBarButtonPrintSend" Text="Print/Send">
                    <Buttons>
                        <telerik:RadToolBarButton Text="Print" Value="Print" ToolTip="Print" />
                        <telerik:RadToolBarButton Text="Send Alert" Value="SendAlert" ToolTip="Send Alert" />
                        <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonSendAssignment" Text="Send Assignment" Value="SendAssignment" ToolTip="Send Assignment" />
                        <telerik:RadToolBarButton Text="Send Email" Value="SendEmail" ToolTip="Send Email" />
                        <telerik:RadToolBarButton Text="Options" Value="PrintSendOptions" ToolTip="Print/Send Options" />
                    </Buttons>
                </telerik:RadToolBarDropDown>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh" ToolTip="Refresh" />
                <telerik:RadToolBarButton runat="server" SkinID="RadToolBarButtonBookmark" ID="RadToolBarButtonBookmark" Text="" Value="Bookmark" ToolTip="Bookmark" Visible="false" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonCreateJob" Text="Create Job" Value="CreateJob" ToolTip="Create Job" Visible="false" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarButtonCreateComponent" Text="Create Component" Value="CreateComponent" ToolTip="Create Component" Visible="false" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
            <div>
                    <asp:Label ID="lblRequired" runat="server" CssClass="CssRequired" Visible="False" ForeColor="red" Font-Bold="true" TabIndex="-1"></asp:Label>
                </div>
                <div>
                    <asp:Panel ID="PanelHDR" runat="server" Width="100%">
                        <div class="code-description-container">
                            <div class="code-description-label code-description-container-label" style="font-size: 14px; font-weight: 600; font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;">
                                <asp:Label ID="LabelJobLabel" runat="server" Text="Job:"></asp:Label>
                            </div>
                            <div class="code-description-description code-description-container-label" style="font-size: 14px; font-weight: 600; font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;">
                                <asp:Label ID="LabelJob" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label code-description-container-label" style="font-size: 14px; font-weight: 600; font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;">
                                <asp:Label ID="LabelComponent" runat="server" Text="Component:"></asp:Label>
                            </div>
                            <div class="code-description-description code-description-container-label" style="font-size: 14px; font-weight: 600; font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;">
                                <asp:Label ID="LabelJobComponent" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label code-description-container-label" style="font-size: 14px; font-weight: 600; font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;">
                                <asp:Label ID="LabelNumber" runat="server" Text="Number:"></asp:Label>
                            </div>
                            <div class="code-description-description code-description-container-label" style="font-size: 14px; font-weight: 600; font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;">
                                <asp:Label ID="LabelVersionNumber" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                <asp:Label ID="lblVersion" runat="server" Text="Description:" style="font-size: 14px; font-weight: 600; font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;"></asp:Label>
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TextBoxVersionDescription" runat="server" CssClass="RequiredInput" TabIndex="0" SkinID="TextBoxCodeSingleLineDescription" MaxLength="50" style="font-size: 14px; font-weight: 600; font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;color: #767676 !important"  Height="25px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorVersionDescription" runat="server" ControlToValidate="TextBoxVersionDescription" ForeColor="red" ErrorMessage="Version Description is required."></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label code-description-container-label" style="font-size: 14px; font-weight: 600; font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;">
                                <asp:Label ID="LabelTemplateLabel" runat="server" Text="Template:"></asp:Label>
                            </div>
                            <div class="code-description-description code-description-container-label" style="font-size: 14px; font-weight: 600; font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;">
                                <asp:Label ID="LabelTemplate" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="PanelHeaderRequest" runat="server" HorizontalAlign="center" Width="100%">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorVersionDescRequest" runat="server" ControlToValidate="VersionDescRequest" ForeColor="red" ErrorMessage="Version Description is required."></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txtClient"
                            ForeColor="red" Display="Dynamic" EnableClientScript="true" Enabled="true"
                            ErrorMessage="<br />Client is required."></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator2" runat="server" ControlToValidate="txtDivision"
                            ForeColor="red" Display="Dynamic" EnableClientScript="true" Enabled="true"
                            ErrorMessage="<br />Division is required."></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator3" runat="server" ControlToValidate="txtProduct"
                            ForeColor="red" Display="Dynamic" EnableClientScript="true" Enabled="true"
                            ErrorMessage="<br />Product is required."></asp:RequiredFieldValidator>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                <asp:LinkButton ID="hlClient" runat="server" CausesValidation="False" TabIndex="-1">Client:</asp:LinkButton>
                            </div>
                            <div class="code-description-code">
                                <asp:TextBox ID="txtClient" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall" CssClass="RequiredInput"
                                    TabIndex="1"></asp:TextBox>
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TxtClientDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                    Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                <asp:LinkButton ID="hlDivision" runat="server" CausesValidation="False" TabIndex="-1"> Division:</asp:LinkButton>
                            </div>
                            <div class="code-description-code">
                                <asp:TextBox ID="txtDivision" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall" CssClass="RequiredInput"
                                    TabIndex="1"></asp:TextBox>
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TxtDivisionDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                    Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                <asp:LinkButton ID="hlProduct" runat="server" CausesValidation="False" TabIndex="-1">Product:</asp:LinkButton>
                            </div>
                            <div class="code-description-code">
                                <asp:TextBox ID="txtProduct" runat="server" MaxLength="6" SkinID="TextBoxCodeSmall" CssClass="RequiredInput"
                                    TabIndex="2"></asp:TextBox>
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TxtProductDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                    Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                <asp:LinkButton ID="lbJob" runat="server" CausesValidation="False" TabIndex="-1">Job:</asp:LinkButton>
                            </div>
                            <div class="code-description-code">
                                <asp:TextBox ID="TxtJobNum" runat="server" CssClass="RequiredInput" MaxLength="6" TabIndex="3" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="JobNbrRequest" runat="server" TabIndex="-1" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                <asp:LinkButton ID="lbComponent" runat="server" CausesValidation="False" TabIndex="-1">Component:</asp:LinkButton>
                            </div>
                            <div class="code-description-code">
                                <asp:TextBox ID="TxtJobCompNum" runat="server" CssClass="RequiredInput" MaxLength="3" TabIndex="4" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="CompNbrRequest" runat="server" TabIndex="-1" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                Version Number:
                            </div>
                            <div class="code-description-code">
                                <asp:TextBox ID="TextBoxVersionNumberRequest" runat="server" ReadOnly="true" TabIndex="-1" SkinID="TextBoxCodeSmall" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                <asp:Label ID="lblVersionRequest" runat="server" Text="Version Description:"></asp:Label>
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="VersionDescRequest" runat="server" CssClass="RequiredInput" TabIndex="5" SkinID="TextBoxCodeSingleLineDescription" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                        <div id="DivRequestTemplate" runat="server" class="code-description-container">
                            <div class="code-description-label">
                                Template:
                            </div>
                            <div class="code-description-description">
                                <asp:TextBox ID="TmpltCodeRequest" runat="server" ReadOnly="true" TabIndex="-1" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
                <div>
                    <h4>Details</h4>
                    <asp:PlaceHolder ID="PlaceHolderDetails" runat="server"></asp:PlaceHolder>
                </div>
    </div>
    
    <asp:HiddenField ID="hfJobVerID" runat="server" Value="0" />
</asp:Content>
