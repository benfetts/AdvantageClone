<%@ Page AutoEventWireup="false" CodeBehind="Estimating_AddNew.aspx.vb" Inherits="Webvantage.Estimating_AddNew"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="New Estimate" %>

<asp:Content ID="ContentMain" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function clearcomp() {
                document.forms[0].<%=Me.TxtJobCompNum.ClientID %>.value = '';
                document.forms[0].<%=Me.TxtJobCompDescription.ClientID %>.value = '';
            };
            function clearjob(){
                document.forms[0].<%=Me.TxtJobNum.ClientID %>.value = '';
                document.forms[0].<%=Me.TxtJobCompNum.ClientID %>.value = '';
                document.forms[0].<%=Me.TxtJobDescription.ClientID %>.value = '';
                document.forms[0].<%=Me.TxtJobCompDescription.ClientID %>.value = '';
            };
            function copytext() {
                document.getElementById("ctl00_ContentPlaceHolderMain_txtEstimateCompDescription").value = document.getElementById("ctl00_ContentPlaceHolderMain_TxtEstimateDescription").value;
            };
            function disableSC() {
                document.getElementById("ctl00_ContentPlaceHolderMain_HlSalesClass").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolderMain_HlSalesClass").onclick = '';
            };
        </script>
    </telerik:RadScriptBlock>
    <div class="telerik-aqua-body" style="margin-top: 5px!important;">
     <div id="DivHeader" style="margin: 15px">
            <asp:Label ID="LblMSG" runat="server" Text=""></asp:Label>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HlClient" runat="server" href="" TabIndex="-1">Client:</asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtClientCode" runat="server" CssClass="RequiredInput"
                        MaxLength="6" TabIndex="1" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtClientDescription" runat="server" ReadOnly="true"
                        TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HlDivision" runat="server" href="" TabIndex="-1">Division:</asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtDivisionCode" runat="server" CssClass="RequiredInput"
                        MaxLength="6" TabIndex="2" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtDivisionDescription" runat="server" ReadOnly="true"
                        TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HlProduct" runat="server" href="" TabIndex="-1">Product:</asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtProductCode" runat="server" CssClass="RequiredInput"
                        MaxLength="6" TabIndex="2" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtProductDescription" runat="server" ReadOnly="true"
                        TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HlJob" runat="server" href="" TabIndex="-1">Job:</asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtJobNum" runat="server" MaxLength="6" TabIndex="4"
                        Text="" SkinID="TextBoxCodeSmall" AutoPostBack="True"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtJobDescription" runat="server" ReadOnly="true"
                        TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HlComponent" runat="server" href="" TabIndex="-1">Component:</asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtJobCompNum" runat="server" MaxLength="3"
                        TabIndex="5" Text="" SkinID="TextBoxCodeSmall" AutoPostBack="True"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtJobCompDescription" runat="server" ReadOnly="true"
                        TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    <asp:HiddenField ID="hfContactCodeID" runat="server" />
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="hlCampaign" runat="server" href="" TabIndex="-1">Campaign:</asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtCampaign" runat="server"
                        MaxLength="10" TabIndex="6" Text="" SkinID="TextBoxCodeSmall" AutoPostBack="True"></asp:TextBox>
                    <asp:HiddenField runat="server" ID="HiddenFieldCampaignID" />
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtCampaignDescription" runat="server" ReadOnly="true"
                        TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HlSalesClass" runat="server" href="" TabIndex="-1">Sales Class:</asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtSalesClass" runat="server" CssClass="RequiredInput"
                        MaxLength="10" TabIndex="6" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtSalesClassDescription" runat="server" ReadOnly="true"
                        TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:Label ID="lblEstimateDescription" runat="server" Text="Est Desc:"></asp:Label>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtEstimateDescription" runat="server" CssClass="RequiredInput"
                        MaxLength="60" TabIndex="6" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:Label ID="lblEstimateCompDescription" runat="server" Text="Comp Desc:"></asp:Label>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="txtEstimateCompDescription" runat="server" CssClass="RequiredInput"
                        MaxLength="60" TabIndex="6" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                </div>
                <div class="code-description-description">
                    <asp:Button ID="BtnCreateEstimate" runat="server" CausesValidation="False" TabIndex="7" Text="Create Estimate" />
                    &nbsp;&nbsp;
                    <asp:Button ID="BtnCancel" runat="server" CausesValidation="False" TabIndex="8" Text="Cancel" />
                </div>
            </div>
        </div>
        <ew:CollapsablePanel ID="CollapsablePanelHeader" runat="server" TitleText="Copy Source" Collapsed="true">
            <asp:Panel ID="PnlCopySource" runat="server" DefaultButton="BtnCreateEstimate" Width="95%">
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlClientSource" runat="server" href="" TabIndex="-1">Client:</asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtClientSource" runat="server" MaxLength="6"
                            TabIndex="9" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtClientSourceDesc" runat="server" ReadOnly="true"
                            TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlDivisionSource" runat="server" href="" TabIndex="-1">Division:</asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtDivisionSource" runat="server" MaxLength="6"
                            TabIndex="10" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtDivisionSourceDesc" runat="server" ReadOnly="true"
                            TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlProductSource" runat="server" href="" TabIndex="-1">Product:</asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtProductSource" runat="server" MaxLength="6"
                            TabIndex="11" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtProductSourceDesc" runat="server" ReadOnly="true"
                            TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlJobType" runat="server" href="" TabIndex="-1">Job Type:</asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtJobTypeSource" runat="server" MaxLength="6"
                            TabIndex="12" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtJobTypeSourceDesc" runat="server" ReadOnly="true"
                            TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlEstimateSource" runat="server" href="" TabIndex="-1">Estimate:</asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtEstimateSource" runat="server" MaxLength="6"
                            TabIndex="13" Text="" SkinID="TextBoxCodeSmall" CssClass="RequiredInput"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtEstimateSourceDesc" runat="server" ReadOnly="true"
                            TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                    </div>
                    <div class="code-description-description">
                        <asp:CheckBox ID="cbRecalculate" runat="server" Text="Recalculate?" />
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                    </div>     
                    <div class="code-description-description">
                        <asp:Button ID="btnCompQuote" runat="server" CausesValidation="False"
                            TabIndex="14" Text="Get Components/Quotes" />
                        &nbsp;&nbsp;<asp:Button ID="btnCopyEstimate" runat="server" CausesValidation="False"
                            TabIndex="15" Text="Copy Estimate" />
                    </div>
                </div>
            </asp:Panel>
            <telerik:RadGrid ID="RadGridEstCopy" runat="server" AllowMultiRowSelection="True" AllowSorting="False"
                AutoGenerateColumns="False" EnableAJAX="False" GridLines="None" Title="Components/Quotes">
                <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                <ClientSettings EnablePostBackOnRowClick="False">
                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                </ClientSettings>
                <MasterTableView DataKeyNames="ESTIMATE_NUMBER,EST_COMPONENT_NBR">
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="center" />
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="EST_QUOTE_NBR" HeaderText="Quote" UniqueName="colEST_QUOTE_NBR">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EST_QUOTE_DESC" HeaderText="Description" UniqueName="colEST_QUOTE_DESC">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn HeaderText="" UniqueName="colComp" Visible="false">
                            <ItemTemplate>
                                <asp:HiddenField ID="hfEstimateComp" runat="server" Value='<%# Eval("EST_COMPONENT_NBR") %>' />
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
            </telerik:RadGrid>
        </ew:CollapsablePanel>
    </div>
   
</asp:Content>
