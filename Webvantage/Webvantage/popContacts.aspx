<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="popContacts.aspx.vb" Inherits="Webvantage.popContacts"
    MasterPageFile="~/ChildPage.Master" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlockMain" runat="server">
        <script type="text/javascript">
            function RefreshPage() {
                __doPostBack('onclick#Refresh', 'Refresh');
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr align="center" valign="top">
            <td>
                <telerik:RadGrid ID="RadGridContacts" runat="server" AutoGenerateColumns="False"
                    GridLines="None" EnableEmbeddedSkins="True" Width="99%">
                    <MasterTableView DataKeyNames="CDP_CONTACT_ID, code,CONT_EXTENTION,CONT_FAX_EXTENTION">
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="colDetails">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                     <asp:ImageButton ID="butDetail" runat="server" CommandName="Detail" SkinID="ImageButtonViewWhite" />
                                   </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="description" HeaderText="Contact" UniqueName="column1">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="code2" HeaderText="" UniqueName="column2" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CDP_CONTACT_ID" HeaderText="" UniqueName="column4"
                                Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CONT_TITLE" HeaderText="Title" UniqueName="column56">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CONT_TELEPHONE" HeaderText="Telephone" UniqueName="column55">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CELL_PHONE" HeaderText="Cell Phone" UniqueName="column6">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CONT_FAX" HeaderText="Fax" UniqueName="column7">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EMAIL_ADDRESS" HeaderText="Email Address" UniqueName="column8">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CONT_EXTENTION" HeaderText="" UniqueName="column9"
                                ItemStyle-HorizontalAlign="Left" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CONT_FAX_EXTENTION" HeaderText="" UniqueName="column10"
                                ItemStyle-HorizontalAlign="Left" Visible="false">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Resizable="False" Visible="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <EditFormSettings>
                            <PopUpSettings ScrollBars="None" />
                        </EditFormSettings>
                    </MasterTableView>
                </telerik:RadGrid>
                <asp:Label   ID="LabelAddress" runat="server" Text="Address Option:"></asp:Label>
                <asp:RadioButton ID="RadioButtonClient" runat="server" Text="Client" GroupName="Address"
                    AutoPostBack="True" />
                <asp:RadioButton ID="RadioButtonDivision" runat="server" Text="Division" GroupName="Address"
                    AutoPostBack="True" />
                <asp:RadioButton ID="RadioButtonProduct" runat="server" Text="Product" GroupName="Address"
                    AutoPostBack="True" />
                <telerik:RadGrid ID="RadGridCDP" runat="server" AutoGenerateColumns="False" GridLines="None"
                    EnableEmbeddedSkins="True" Width="99%">
                    <MasterTableView DataKeyNames="CL_CODE,DIV_CODE,PRD_CODE,CL_SADDRESS2,DIV_SADDRESS2,PRD_STATE_ADDR2">
                        <Columns>
                            <telerik:GridBoundColumn DataField="CL_NAME" HeaderText="Client" UniqueName="column1"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DIV_NAME" HeaderText="Division" UniqueName="column2"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PRD_DESCRIPTION" HeaderText="Product" UniqueName="column3"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CL_SADDRESS1" HeaderText="Address" UniqueName="column4"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CL_SADDRESS2" HeaderText="Address 2" UniqueName="column5"
                                ItemStyle-HorizontalAlign="Left" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CL_SCITY" HeaderText="City" UniqueName="column6"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CL_SSTATE" HeaderText="State" UniqueName="column7"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CL_SZIP" HeaderText="Zip" UniqueName="column8"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DIV_SADDRESS1" HeaderText="Address" UniqueName="column9"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DIV_SADDRESS2" HeaderText="Address 2" UniqueName="column10"
                                ItemStyle-HorizontalAlign="Left" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DIV_SCITY" HeaderText="City" UniqueName="column11"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DIV_SSTATE" HeaderText="State" UniqueName="column12"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DIV_SZIP" HeaderText="Zip" UniqueName="column13"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PRD_STATE_ADDR1" HeaderText="Address" UniqueName="column14"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PRD_STATE_ADDR2" HeaderText="Address 2" UniqueName="column15"
                                ItemStyle-HorizontalAlign="Left" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PRD_STATE_CITY" HeaderText="City" UniqueName="column16"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PRD_STATE_STATE" HeaderText="State" UniqueName="column17"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PRD_STATE_ZIP" HeaderText="Zip" UniqueName="column18"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PRD_STATE_TELEPHON" HeaderText="Phone" UniqueName="column19"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Resizable="False" Visible="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <EditFormSettings>
                            <PopUpSettings ScrollBars="None" />
                        </EditFormSettings>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
        <asp:Panel ID="PanelJPC" runat="server">
            <tr>
                <td align="left" class="DesktopObjectHeader ContentHeaderText" colspan="2">
                    &nbsp;&nbsp;Job Processing Control
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td width="2%">
                                &nbsp;
                            </td>
                            <td valign="top">
                                <span>Processing Control:</span>
                            </td>
                        </tr>
                        <tr>
                            <td width="2%">
                                &nbsp;
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RadioButtonListJPC" runat="server" RepeatDirection="Vertical"
                                    RepeatColumns="3"  Width="500px">
                                    <asp:ListItem Text="All Processing" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="No Processing" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Closed" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="Archive" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="A/P, Time, I/O and Billing" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="A/P, Time and Billing" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="A/P, I/O and Billing" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="Time, I/O and Billing" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="A/P and Billing" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Time and Billing" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="I/O and Billing" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="Billing Only" Value="5"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="2%">
                                &nbsp;
                            </td>
                            <td valign="top">
                                <span>Process Comment:</span>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxProcessComment" runat="server" Height="100px" TabIndex="8" SkinID="TextBoxStandard"
                                    Text="" TextMode="MultiLine" Width="600px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="2%">
                                &nbsp;
                            </td>
                            <td colspan="2">
                                <span>Last Changed:</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="2%">
                                &nbsp;
                            </td>
                            <td height="22px" align="right">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span>By:</span>&nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:Label   ID="LabelBy" runat="server" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="2%">
                                &nbsp;
                            </td>
                            <td height="22px" align="right">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span>Date:</span>&nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:Label   ID="LabelDate" runat="server" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="2%">
                                &nbsp;
                            </td>
                            <td height="22px" align="right">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span>Changed From:</span>&nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:Label   ID="LabelChangedFrom" runat="server" ></asp:Label>
                                <asp:HiddenField ID="HiddenFieldJPC" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </asp:Panel>
        <tr>
            <td colspan="2" align="center">
                <br />
                <asp:Button ID="ButtonUpdateJPC" runat="server" Text="Save" Visible="false" />
                <asp:Button ID="ButtonAddContact" runat="server" Text="Add Contact" />&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Close" OnClientClick="CloseThisWindow();" Visible="false" /><br />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
