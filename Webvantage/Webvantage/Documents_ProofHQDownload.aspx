<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Documents_ProofHQDownload.aspx.vb" Inherits="Webvantage.Documents_ProofHQDownload" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div >
        <telerik:RadToolBar ID="RadToolbarSearch" runat="server" AutoPostBack="true"
            Width="100%">
            <Items>
                <telerik:RadToolBarButton runat="server">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBoxSearch" runat="server" Width="200px" SkinID="TextBoxStandard"></asp:TextBox>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Search" Value="Search" CommandName="Search" ToolTip="Search for documents" SkinID="RadToolBarButtonFind" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div >
    </div>
    <table width="100%" border="0" cellspacing="2" cellpadding="0" style="padding-left: 6px; padding-top: 4px; padding-right: 6px; padding-bottom: 4px;">
        <tr>
            <td>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <telerik:RadGrid ID="RadGridProofHQFiles" runat="server" AllowPaging="false"
                        AllowSorting="true" GridLines="None" PageSize="10" EnableEmbeddedSkins="True"
                        ShowFooter="false" AutoGenerateColumns="false" Width="100%" PagerStyle-Visible="false">
                        <MasterTableView DataKeyNames="FileID">
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDownload">
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButtonDownload" runat="server" ImageUrl="~/Images/ProofHQDownloadSmallImage.png"
                                            ToolTip="Click to Download" CommandName="Download" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn UniqueName="FileID" DataField="FileID" HeaderText="FileID" Visible="false"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="FileName" DataField="FileName" HeaderText="File Name"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Folder" DataField="Folder" HeaderText="Folder"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Version" DataField="Version" HeaderText="Version"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Owner" DataField="Owner" HeaderText="Owner"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Decision" DataField="Decision" HeaderText="Decision"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="FileSize" DataField="FileSize" HeaderText="File Size"></telerik:GridBoundColumn>
                            </Columns>
                            <RowIndicatorColumn>
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn>
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                        </MasterTableView>
                    </telerik:RadGrid>
                </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
