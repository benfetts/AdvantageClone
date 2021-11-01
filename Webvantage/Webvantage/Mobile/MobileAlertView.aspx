<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MobileAlertView.aspx.vb"
    Inherits="Webvantage.MobileAlertView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Webvantage Mobile</title>
    
    
    <link href="~/CSS/MobileBB.min.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
    <meta name="viewport" content="width=320px" />  
    <meta name="viewport" content="initial-scale=1 user-scalable=yes" />
</head>
<body style="width: auto; height: auto">
    <form id="form1" runat="server">
        <div id="divNormalAlerts" runat="server">
            <table id="tblMobileHeader" runat="server" width="200">
                <tr>
                    <td style="width: 60px;">
                        <asp:Button runat="server" ID="btnBack" Text="Back" ForeColor="blue" BorderStyle="Solid"
                            BorderWidth="1px" Font-Size="XX-Small" />
                    </td>
                    <td style="width: 60px;">
                        <asp:Button runat="server" ID="btnLogout" Text="Logout" ToolTip="Logout" ForeColor="blue"
                            BorderStyle="Solid" BorderWidth="1px" Font-Size="XX-Small"></asp:Button>
                    </td>
                </tr>
            </table>
            <table id="tblNormalAlerts" runat="server" visible="true">
          
                <tr>
                    <td>
                        Alert Type:
                        <asp:Label   ID="lblNAlertType" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Office:
                        <asp:Label   ID="lblNOfficeCode" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Client:
                        <asp:Label   ID="lblNClientCode" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Division:
                        <asp:Label   ID="lblNDivisionCode" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                        Product:
                        <asp:Label   ID="lblNProduct" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Campaign:
                        <asp:Label   ID="lblNCampaignCode" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Job:
                        <asp:Label   ID="lblNJobNumber" runat="server"></asp:Label>
                       
                    </td>
                </tr>
                <tr>
                    <td>
                        Component:
                        <asp:Label   ID="lblNComponentNumber" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                        Generated:
                        <asp:Label   ID="lblNGenerated" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                        Priority:
                        <asp:Label   ID="lblPriority" runat="server"></asp:Label>
                    </td>
                </tr>
                
                 <tr>
                    <td>
                        Category:
                        <asp:Label   ID="lblNCategory" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                        Subject:
                        <asp:Label   ID="lblNSubject" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Details:</td>
                </tr>
                </table>
                
                        <asp:Label   ID="lblNDetails" runat="server" Width="800px" ></asp:Label>
                
                <table runat="server" id="tblGrids">
                <tr>
                    <td>
                        Comments:</td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvComments" runat="server" CellPadding="5" ForeColor="#333333"
                            GridLines="both" AutoGenerateColumns="false">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="Comment" HeaderText="Comments" />
                                <asp:BoundField DataField="EmployeeName" HeaderText="By" ItemStyle-Width="150px" />
                                <asp:BoundField DataField="Generated" ItemStyle-Width="150px" DataFormatString="{0:g}"
                                    HeaderText="Added" />
                                <asp:BoundField DataField="USER_CODE" HeaderText="Comments" Visible="false" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        Attachments:</td>
                </tr>
                <tr>
                    <td>
                     <asp:GridView ID="gvAttachments" runat="server" CellPadding="5" ForeColor="#333333"
                            GridLines="both" AutoGenerateColumns="false" OnRowCommand="gvAttachments_RowCommand">
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField SortExpression="">
                                    <HeaderStyle Width="20px" />
                                    <ItemStyle Width="20px" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="DocumentIconImageButton" runat="server" />
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Filename"  SortExpression="RealFilename">
                                    <HeaderStyle />
                                    <ItemStyle Wrap="True"  />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="DownloadLinkButton" runat="server"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="FILE_SIZE" DataFormatString="{0:#,### KB}" HeaderText="Size"
                                    HtmlEncode="false" />
                                <asp:BoundField DataField="UserName" HeaderText="Added By" />
                                <asp:BoundField DataField="AddedDate" DataFormatString="{0:G}"
                                    HeaderText="Added Date" />
                                <asp:BoundField DataField="USER_CODE" Visible="false" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                  <tr>
            <td>
                <asp:Label   ID="lblFileMessage" runat="server"></asp:Label>
            </td>
            </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Recipient List:</td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grdRecipients" runat="server" AutoGenerateColumns="False" BackColor="White"
                            CellPadding="2" GridLines="None" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="empCode" HeaderText="Code">
                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UserName" HeaderText="Name">
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                    <HeaderStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataTemplate>
                                There are no recipients for this alert.
                            </EmptyDataTemplate>
                            <AlternatingRowStyle BackColor="#E0E0E0" />
                            <RowStyle BackColor="White" />
                            <HeaderStyle CssClass="sub-header sub-header-color" />
                        </asp:GridView>
                        <asp:GridView ID="grdRecipientsCP" runat="server" AutoGenerateColumns="False" BackColor="White"
                            CellPadding="2" GridLines="None" ShowHeader="false" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="CONT_CODE">
                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CONT_FML">
                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                    <HeaderStyle HorizontalAlign="Left" Width="200px" />
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataTemplate>
                            </EmptyDataTemplate>
                            <AlternatingRowStyle BackColor="#E0E0E0" />
                            <RowStyle BackColor="White" />
                            <HeaderStyle CssClass="sub-header sub-header-color" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        Comment Entry:</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label   ID="lblStatus" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtNCommentEntry" Width="200px" Height="100px" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="lbNAddComment" runat="server">Add Comment</asp:LinkButton>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="lbNEmailToRecipients" runat="server">Alert Recipients</asp:LinkButton>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="lbNDismissAlert" runat="server">Dismiss</asp:LinkButton>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="lbAApprove" Visible="false" runat="server">Approve</asp:LinkButton>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="lbADeny" Visible="false" runat="server">Deny</asp:LinkButton>&nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
