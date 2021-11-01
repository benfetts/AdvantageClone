<%@ Page AutoEventWireup="false" CodeBehind="VendorQuote_Versions.aspx.vb" Inherits="Webvantage.VendorQuote_Versions"
    MasterPageFile="~/ChildPage.Master" Title="" Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadSplitter ID="RadSplitterHeader" runat="server" Height="1200px"
        Orientation="Horizontal" Width="100%">
        <telerik:RadPane ID="RadPaneTop" runat="server" Height="300px"
            Scrolling="none">
            <telerik:RadToolBar ID="RadToolBarQuote" runat="server" AutoPostBack="true" Width="100%">
                <Items>
                    <telerik:RadToolBarButton IsSeparator="True" Value="Sep1" />
                    <telerik:RadToolBarButton Value="Add" ToolTip="Add Quotes" SkinID="RadToolBarButtonAdd" TabIndex="1000" />
                    <telerik:RadToolBarButton IsSeparator="True" Value="Sep2" />
                </Items>
            </telerik:RadToolBar>  
            <div>&nbsp;</div>
            <div>
                <asp:Label ID="lblMSG" runat="server" CssClass="warning" Text=""></asp:Label>
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
                        <asp:TextBox ID="TxtClientDescription" runat="server" ReadOnly="true" TabIndex="-1"
                            Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
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
                        <asp:TextBox ID="TxtDivisionDescription" runat="server" ReadOnly="true" TabIndex="-1"
                            Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
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
                        <asp:TextBox ID="TxtProductDescription" runat="server" ReadOnly="true" TabIndex="-1"
                            Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div style="display: inline-block;">
                <div class="code-description-container">
                    <div class="code-description-label">
                       Estimate:
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtEstimate" runat="server" CssClass="RequiredInput" TabIndex="3"
                            Text="" SkinID="TextBoxCodeSmall" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtEstimateDescription" runat="server" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Component:
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtEstimateComponent" runat="server" CssClass="RequiredInput" TabIndex="4"
                            Text="" SkinID="TextBoxCodeSmall" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtEstimateComponentDescription" runat="server" TabIndex="-1" Text=""
                            SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
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

            <%--<table border="0" cellpadding="0" cellspacing="0" width="100%">
                <br />
                <tr>
                    <td align="center" colspan="2" valign="middle">
                        
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="50%">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="right" valign="middle" width="23%">
                                    <span>Client: </span>
                                </td>
                                <td width="2%">
                                    &nbsp;
                                </td>
                                <td width="75%">
                                    <asp:TextBox ID="" runat="server" MaxLength="6" TabIndex="1" Text=""
                                        SkinID="TextBoxCodeSmall"></asp:TextBox>&nbsp;
                                    <asp:TextBox ID="" runat="server" ReadOnly="true" TabIndex="-1"
                                        Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle">
                                    <span>Division:</span>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="" runat="server" MaxLength="6" TabIndex="1" Text=""
                                        SkinID="TextBoxCodeSmall"></asp:TextBox>&nbsp;
                                    <asp:TextBox ID="" runat="server" ReadOnly="true" TabIndex="-1"
                                        Text="" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle">
                                    <span>Product:</span>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="" runat="server" MaxLength="6" TabIndex="2" Text=""
                                        SkinID="TextBoxCodeSmall"></asp:TextBox>&nbsp;
                                    <asp:TextBox ID="" runat="server" ReadOnly="true" TabIndex="-1"
                                        Text="" ></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top" width="50%">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="right" valign="middle" width="23%">
                                    <span>Estimate:</span>
                                </td>
                                <td width="2%">
                                    &nbsp;
                                </td>
                                <td width="75%">
                                    <asp:TextBox ID="" runat="server" CssClass="RequiredInput" TabIndex="3"
                                        Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>&nbsp;
                                    <asp:TextBox ID="" runat="server" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="23%">
                                    <span>Component:</span>
                                </td>
                                <td width="2%">
                                    &nbsp;
                                </td>
                                <td width="75%">
                                    <asp:TextBox ID="" runat="server" CssClass="RequiredInput" TabIndex="4"
                                        Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>&nbsp;
                                    <asp:TextBox ID="" runat="server" TabIndex="-1" Text=""
                                        SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="23%">
                                    <span>
                                        <asp:HyperLink ID="" runat="server" Visible="false" href="">Quote:</asp:HyperLink></span>
                                </td>
                                <td width="2%">
                                    &nbsp;
                                </td>
                                <td width="75%">
                                    <asp:TextBox ID="" runat="server" CssClass="RequiredInput" TabIndex="4" Text=""
                                        SkinID="TextBoxCodeSmall" Visible="false"></asp:TextBox>&nbsp;
                                    <asp:TextBox ID="" runat="server" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"
                                        Visible="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="23%">
                                    <span>
                                        </span>
                                </td>
                                <td width="2%">
                                    &nbsp;
                                </td>
                                <td width="75%">
                                    <asp:TextBox ID="" runat="server" CssClass="RequiredInput" MaxLength="6"
                                        TabIndex="3" Text="" SkinID="TextBoxCodeSmall" Visible="false"></asp:TextBox>&nbsp;
                                    <asp:TextBox ID="" runat="server" ReadOnly="true" TabIndex="-1"
                                        Text="" SkinID="TextBoxCodeSingleLineDescription" Visible="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle">
                                    <span>
                                        </span>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="" runat="server" CssClass="RequiredInput" MaxLength="6"
                                        TabIndex="4" Text="" SkinID="TextBoxCodeSmall" Visible="false"></asp:TextBox>&nbsp;
                                    <asp:TextBox ID="" runat="server" ReadOnly="true" TabIndex="-1"
                                        Text="" SkinID="TextBoxCodeSingleLineDescription" Visible="false"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <br />
                        <asp:Button ID="BtnRefresh" runat="server" Text="Refresh" Visible="false" />
                        &nbsp;&nbsp;
                        <asp:Button ID="BtnCopy" runat="server" Text="Add Quotes" />
                    </td>
                </tr>
            </table>--%>
        </telerik:RadPane>
        <telerik:RadSplitBar ID="RadSplitbarTopBottom" runat="server" CollapseMode="Forward" />
        <telerik:RadPane ID="RadPaneBottom" runat="server" Height="" Scrolling="Y">
            <telerik:RadGrid ID="RadGridQuote" runat="server" AllowMultiRowSelection="True" AllowSorting="False"
                AutoGenerateColumns="False" EnableAJAX="False" GridLines="None" Width="100%">
                <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                <ClientSettings EnablePostBackOnRowClick="False">
                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                </ClientSettings>
                <MasterTableView DataKeyNames="EST_QUOTE_NBR, EST_REV_NBR, EST_QUOTE_DESC">
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="center" />
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="EST_QUOTE_NBR" HeaderText="Quote" UniqueName="colEST_QUOTE_NBR">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="100" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EST_QUOTE_DESC" HeaderText="Description" UniqueName="colEST_QUOTE_DESC">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EST_REV_NBR" HeaderText="" UniqueName="colEST_REV_NBR"
                            Visible="false">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="100" />
                        </telerik:GridBoundColumn>
                    </Columns>
                    <ExpandCollapseColumn Visible="False">
                        <HeaderStyle Width="19px" />
                    </ExpandCollapseColumn>
                    <RowIndicatorColumn Visible="False">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                </MasterTableView>
            </telerik:RadGrid>
        </telerik:RadPane>
    </telerik:RadSplitter>
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
</asp:Content>