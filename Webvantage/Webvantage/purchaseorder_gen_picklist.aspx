<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="purchaseorder_gen_picklist.aspx.vb"
    Inherits="Webvantage.purchaseorder_gen_picklist" MasterPageFile="~/ChildPage.Master"
    Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table>
        <tr>
            <td style="width: 500px">
                Search List
            </td>
        </tr>
        <tr>
            <td style="width: 500px">
                <asp:TextBox ID="txtLookup" runat="server" EnableViewState="True" Width="391px" AutoPostBack="True" SkinID="TextBoxStandard"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 500px; background-color: white;">
                <div style="overflow: auto; width: 395px; height: 236px; background-color: white;">
                    <asp:GridView ID="gv_list" runat="server" AutoGenerateColumns="False" CellPadding="1"
                        EmptyDataText="(None)" GridLines="Vertical" ShowHeader="False" DataKeyNames="CODE1,VALUE1,VALUE2,VALUE3,VALUE4,VALUE5,VALUE6,VALUE7"
                        Width="95%" BackColor="White">
                        <SelectedRowStyle ForeColor="White" BackColor="RoyalBlue" />
                        <EmptyDataTemplate>
                            <asp:Image ID="img_nodata" AlternateText="No Matches." ImageUrl="images/nomatchpage.png"
                                runat="server" />
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtn_select_code" CommandName="Select" Text='<%#Eval("CODE1")%>'
                                        runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtn_select_value" CommandName="Select" Text='<%#Eval("VALUE1")%>'
                                        runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="80%" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle BackColor="DodgerBlue" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="1" style="width: 500px">
                <hr />
                &nbsp;<asp:ImageButton ID="ibtn_back" runat="server" AlternateText="Back to Top."
                    CausesValidation="False" SkinID="ImageButtonPrevious" />
                <asp:LinkButton ID="lbtn_top" runat="server">Top</asp:LinkButton>
                <asp:ImageButton ID="ibtn_refresh" runat="server" AlternateText="Refresh the List."
                    CausesValidation="False" SkinID="ImageButtonRefresh" Visible="False" />
                <asp:ImageButton ID="ibtn_search" runat="server" AlternateText="Start text search."
                    CausesValidation="False" SkinID="ImageButtonFind" Visible="False" />
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 55px">
                <table width="98%">
                    <tr>
                        <td style="width: 55%" align="center">
                            <button id="btn_Select" causesvalidation="false" onclick="JavaScript:returnValue();"
                                runat="server">
                                Select</button>
                        </td>
                        <td style="width: 45%">
                            <button id="btnClose" causesvalidation="false" onclick="JavaScript:window.close();">
                                Cancel</button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left">&nbsp;
            </td>
        </tr>
    </table>
    <asp:Label   ID="lbl_control" runat="server" Visible="False"></asp:Label>
    <asp:Label   ID="lbl_type" runat="server" Visible="False"></asp:Label>
    <asp:RadioButtonList ID="rbl_options" runat="server" Font-Size="XX-Small" AutoPostBack="True"
        CellPadding="0" CellSpacing="0" Visible="False">
    </asp:RadioButtonList>
    <asp:TextBox ID="txtValue2" runat="server" BorderStyle="none" ForeColor="white" BackColor="Transparent" />
    <asp:TextBox ID="txtCode" runat="server" BackColor="Transparent" ForeColor="White"
        ReadOnly="True" Width="77px" BorderStyle="None">..</asp:TextBox>
    <asp:TextBox ID="txtValue" runat="server" BackColor="Transparent" ForeColor="White"
        ReadOnly="True" Width="193px" BorderStyle="None">..</asp:TextBox>
    <asp:TextBox ID="txtValue3" runat="server" BorderStyle="none" ForeColor="white" BackColor="Transparent" />
    <asp:TextBox ID="txtValue4" runat="server" BorderStyle="none" ForeColor="white" BackColor="Transparent" />
    <asp:TextBox ID="txtValue5" runat="server" BorderStyle="none" ForeColor="white" BackColor="Transparent" />
    <asp:TextBox ID="txtValue6" runat="server" BorderStyle="none" ForeColor="white" BackColor="Transparent" />
    <asp:TextBox ID="txtValue7" runat="server" BorderStyle="none" ForeColor="white" BackColor="Transparent" />
    <asp:TextBox ID="txtStr" runat="server" BorderStyle="none" ForeColor="white" BackColor="Transparent" />
</asp:Content>
