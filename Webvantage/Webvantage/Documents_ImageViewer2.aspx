<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Documents_ImageViewer2.aspx.vb" Inherits="Webvantage.Documents_ImageViewer2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadImageEditor ID="RadImageEditor1" runat="server" AllowedSavingLocation="Server">
        <Tools>
            <telerik:ImageEditorToolGroup>
                <telerik:ImageEditorTool CommandName="Save" />
                <telerik:ImageEditorTool CommandName="AddText" />
                <telerik:ImageEditorTool CommandName="Reset" />
            </telerik:ImageEditorToolGroup>
        </Tools>
    </telerik:RadImageEditor>
    <script type="text/javascript">
        Telerik.Web.UI.ImageEditor.CommandList.DBSave = function (imageEditor, commandName, args) {
            var commandText = "DBSave";
            var commandArgument = "";
            imageEditor.editImageOnServer(commandName, commandText, commandArgument, callbackFunction)
        }
        function callbackFunction(clientData, serveData) {
        }
    </script>
    <telerik:RadGrid ID="RadGridImageComments" runat="server" AllowPaging="false" AllowSorting="false"
        GridLines="None" PageSize="10" EnableEmbeddedSkins="True" ShowFooter="false"
        AutoGenerateColumns="false" Width="100%" PagerStyle-Visible="false">
        <MasterTableView DataKeyNames="ID,UserCode,UserCodeCP">
            <Columns>
                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnID" HeaderText="ID" Visible="false">
                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                    <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                    <ItemTemplate>
                        <%# Eval("ID")%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnUserCode" HeaderText="User Code">
                    <HeaderStyle Width="10" VerticalAlign="Middle" HorizontalAlign="Left" Wrap="false" />
                    <ItemStyle Width="10" VerticalAlign="Middle" HorizontalAlign="Left" Wrap="false" />
                    <FooterStyle Width="10" VerticalAlign="Middle" HorizontalAlign="Left" Wrap="false" />
                    <ItemTemplate>
                        <%# Eval("UserCode")%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDate" HeaderText="Date">
                    <HeaderStyle Width="25" VerticalAlign="Middle" HorizontalAlign="Left" Wrap="false" />
                    <ItemStyle Width="25" VerticalAlign="Middle" HorizontalAlign="Left" Wrap="false" />
                    <FooterStyle Width="25" VerticalAlign="Middle" HorizontalAlign="Left" Wrap="false" />
                    <ItemTemplate>
                        <%# Eval("CreatedDate")%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnComment" HeaderText="Comment">
                    <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" Wrap="false" />
                    <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" Wrap="false" />
                    <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Left" Wrap="false" />
                    <ItemTemplate>
                        <%# Eval("Comment")%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete">
                    <HeaderStyle CssClass="radgrid-icon-column" />
                    <ItemStyle CssClass="radgrid-icon-column" />
                    <FooterStyle CssClass="radgrid-icon-column" />
                    <ItemTemplate>
                        <div class="icon-background background-color-delete">
                        <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite"
                            ToolTip="Click to delete this comment" CommandName="DeleteRow" />
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            <RowIndicatorColumn>
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn>
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>
