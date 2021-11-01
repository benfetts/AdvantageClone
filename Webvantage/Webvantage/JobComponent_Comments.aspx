<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="JobComponent_Comments.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.JobComponent_Comments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadGrid ID="RadGridAlertComments" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        Width="98%" EnableAJAX="false" GridLines="None" EnableEmbeddedSkins="True">
        <MasterTableView>
            <Columns>
                <telerik:GridBoundColumn DataField="COMMENT" HeaderText="Comment" UniqueName="ColCOMMENT">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="EMP_FML" HeaderText="By" UniqueName="ColEMP_FML">
                    <HeaderStyle Width="150px" />
                    <ItemStyle Width="150px" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="GENERATED_DATE" DataFormatString="{0:G}"
                    HeaderText="Added" UniqueName="column2">
                    <HeaderStyle Width="110px" HorizontalAlign="Right" VerticalAlign="Middle" />
                    <ItemStyle Width="110px" HorizontalAlign="Right" VerticalAlign="Middle" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="USER_CODE" HeaderText="Comments" UniqueName="column3"
                    Visible="False">
                </telerik:GridBoundColumn>
            </Columns>
            <ExpandCollapseColumn Visible="False">
                <HeaderStyle Width="19px" />
            </ExpandCollapseColumn>
            <RowIndicatorColumn Visible="False">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <EditItemStyle VerticalAlign="Top" />
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>