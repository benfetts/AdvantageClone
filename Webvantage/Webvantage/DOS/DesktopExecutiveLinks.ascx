<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopExecutiveLinks.ascx.vb"
    Inherits="Webvantage.DesktopExecutiveLinks" %>
<asp:Label ID="lblMsg" runat="server" CssClass="warning"></asp:Label>
<div class="DO-ButtonHeader">
    <div style="float: left; width: 90%; text-align: left;">
        Type:&nbsp;<telerik:RadComboBox ID="ddlType" runat="server" AutoPostBack="True" Width="120">
        </telerik:RadComboBox>
    </div>
    <div style="float: right; width: 10%; text-align: right;">
        <asp:ImageButton ID="butRefreshExecutive" runat="server" ImageAlign="AbsMiddle"
            SkinID="ImageButtonRefresh" ToolTip="Refresh" />
    </div>
</div>
<div class="DO-Container" style="clear:both;">
    <telerik:RadGrid ID="RadGridExecutive" runat="server" AllowPaging="True" AllowSorting="True"
        EnableViewState="true" PageSize="5" Width="100%" AutoGenerateColumns="False"
        GridLines="None" EnableEmbeddedSkins="True">
        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" ></PagerStyle>
        <MasterTableView AllowMultiColumnSorting="true" Width="100%">
            <GroupHeaderItemStyle VerticalAlign="Top" />
            <Columns>
                <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="GridTemplateColumnAlertImage">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <div id="DivAlert" runat="server" class="icon-background background-color-sidebar">
                            <asp:ImageButton ID="ImageButtonAlert" runat="server" />
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="GridTemplateColumnDocImage">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <div id="DivDocumentType" runat="server" class="icon-background background-color-sidebar">
                            <asp:LinkButton ID="LinkButtonDocumentType" runat="server" Text="" ToolTip="" CommandName="Download" CssClass="icon-text" CommandArgument='<%# Eval("DOCUMENT_ID")%>'></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="DESCRIPTION" HeaderText="Description" UniqueName="GridBoundColumnDescription">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="USER_NAME" HeaderText="Uploaded By" UniqueName="GridBoundColumnUploadedBy">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="UPLOADED_DATE" HeaderText="Date" UniqueName="GridTemplateColumnUploadedDate">
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="MIME_TYPE" HeaderText="" UniqueName="GridBoundColumnMimeType"
                    Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="REPOSITORY_FILENAME" HeaderText="" UniqueName="GridBoundColumnFilename"
                    Visible="false">
                </telerik:GridBoundColumn>
            </Columns>
            <ExpandCollapseColumn Visible="False">
                <HeaderStyle Width="19px" />
            </ExpandCollapseColumn>
            <RowIndicatorColumn Visible="False">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <NoRecordsTemplate>
                There are no files in this folder.
            </NoRecordsTemplate>
        </MasterTableView>
    </telerik:RadGrid>
</div>
