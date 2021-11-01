<%@ Page Title="Comment Details" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Alert_DigitalAssetReview_Comment.aspx.vb" Inherits="Webvantage.Alert_DigitalAssetReview_Comment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <div style="width: 100%;">
            <div style="width: 100%;text-align:center; padding:0px;margin: 20px 0px 10px 0px;">
                <asp:Image ID="ImageMarkup" runat="server" />
            </div>
            <div style="margin: 0px 0px 20px 0px;">
                <h4>Comment</h4>
                <div style="margin: 0px 0px 0px 20px;">
                    <div>
                        <asp:Label ID="LabelComment" runat="server" Text=""></asp:Label>
                    </div>
                    <div style="font-size: small;">
                        &nbsp;&nbsp;&nbsp;&nbsp;-&nbsp;&nbsp;<asp:Label ID="LabelCommentBy" runat="server" Text=""></asp:Label>
                   </div>
                </div>
            </div>
            <div>
                <h4 >Replies</h4>
                <div style="margin: 0px 0px 0px 20px;">
                    <table style="width:600px; margin-left: -3px;margin-bottom:10px;">
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBoxAddReply" runat="server" Width="470" SkinID="TextBoxStandard"></asp:TextBox>
                                <asp:Button ID="ButtonAddReply" runat="server" Text="Add Reply" />
                            </td>
                        </tr>
                    </table>
                    <div>
                        <telerik:RadGrid ID="RadGridReplies" runat="server" ShowHeader="false" ShowFooter="false">
                            <ClientSettings EnablePostBackOnRowClick="true">
                                <Selecting AllowRowSelect="true" />
                            </ClientSettings>
                            <MasterTableView AutoGenerateColumns="False" NoMasterRecordsText="No replies" DataKeyNames="CommentReplyId, Id, CreatedBy, IsDraft">
                                <RowIndicatorColumn Visible="True">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn Resizable="False" Visible="False">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumn" Visible="True">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <FooterStyle HorizontalAlign="Left" />
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="font-style: italic;">
                                                <div>
                                                    <%# Eval("Comment") %>
                                                </div>
                                                <div style="font-size: small;">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;-&nbsp;&nbsp;<%# Eval("FullName") %> @ <asp:Label ID="LabelCreatedDate" runat="server" Text='<%# Eval("CreatedDate") %>'></asp:Label>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </div>
                </div>
            </div>
        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
