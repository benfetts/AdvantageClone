<%@ Page Title="My Dashboard Definition" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Maintenance_MyObjectsDefinition.aspx.vb" Inherits="Webvantage.Maintenance_MyObjectsDefinition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">

    <style type="text/css">       
        .RadListBox_Metro  {
            font: normal 12px "Segoe UI",Arial,Helvetica,sans-serif !important;
        }
        .RadListBox_Bootstrap .rlbText {
            font: normal 12px "Segoe UI",Arial,Helvetica,sans-serif !important;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <div class="telerik-aqua-body">
            <table border="0" cellspacing="8" cellpadding="4">
                        <tr>
                            <td colspan="3">Object type:
                               <asp:RadioButtonList ID="RadioButtonListObjectType" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatLayout="Flow">
                               </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <telerik:RadListBox ID="RadListBoxObjects" runat="server" AutoPostBack="true" Width="300" EnableEmbeddedSkins="true">
                                </telerik:RadListBox>
                            </td>
                            <td>&nbsp;</td>
                            <td valign="top">
                                <telerik:RadGrid ID="RadGridMyObjectSettings" runat="server" AllowPaging="True" AllowSorting="True" ShowHeader="false"
                                    GridLines="None" PageSize="10" EnableEmbeddedSkins="True" ShowFooter="False" 
                                    AutoGenerateColumns="False" Width="420">
                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom" ></PagerStyle>
                                    <MasterTableView CommandItemDisplay="None" EditMode="InPlace"
                                        DataKeyNames="Id, Object.Id, Definition.Id, Definition.IsStatic"
                                        InsertItemDisplay="Top">
                                        <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                                        <Columns>
                                            <telerik:GridBoundColumn UniqueName="GridBoundColumnDefinitionDescription" SortExpression="Definition.Description" DataField="Definition.Description" HeaderText="">
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnChecked" HeaderText="" SortExpression="Checked">
                                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="20" />
                                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="20" />
                                                <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" Width="20" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBoxIsChecked" runat="server" AutoPostBack="true" Checked='<%#Eval("Checked")%>' OnCheckedChanged="CheckBoxIsChecked_CheckedChanged" />
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
                                    <ClientSettings>
                                        <ClientEvents />
                                    </ClientSettings>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                    </table>
                    <telerik:RadGrid ID="RadGridTest" runat="server" AutoGenerateColumns="true" visible="False"></telerik:RadGrid>
        </div>
        
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
