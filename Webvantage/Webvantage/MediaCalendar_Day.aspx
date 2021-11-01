<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="MediaCalendar_Day.aspx.vb" Inherits="Webvantage.MediaCalendar_Day"
    Title="Media Calendar Day" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain" EnableViewState="true">
                        <div style="margin:10px 0px 0px 0px; width:90%">
                            <telerik:RadTabStrip ID="RadTabStrip" runat="server" AutoPostBack="True" CausesValidation="False"
                                  
                                 Width="100%">
                                <Tabs>
                                    <telerik:RadTab ID="Tab1" runat="server" Text="Root Tab">
                                    </telerik:RadTab>
                                </Tabs>
                            </telerik:RadTabStrip>
                        </div>

    <table id="Table1" align="center" border="0" cellpadding="0" cellspacing="0" height="100%" width="100%">
        <tr>
            <td valign="top">
                <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
                    <tr >
                        <td align="center" class="mediacalHeaderSubBorderLeftMostCell">
                            &nbsp;</td>
                        <td align="center" class="mediacalHeaderSubBorder">
                           Client</td>
                        <td align="center" class="mediacalHeaderSubBorder">
                           Division</td>
                        <td align="center" class="mediacalHeaderSubBorder">
                           Product</td>
                        <td align="center" class="mediacalHeaderSubBorder">
                           Type</td>
                        <td align="center" class="mediacalHeaderSubBorder">
                           Order</td>
                        <td align="center" class="mediacalHeaderSubBorder">
                           Line</td>
                        <td align="center" class="mediacalHeaderSubBorder">
                           Revision</td>
                        <td align="center" class="mediacalHeaderSubBorder">
                           Vendor</td>
                        <td align="center" class="mediacalHeaderSubBorder">
                           Order Desc</td>
                        <td align="center" class="mediacalHeaderSubBorder">
                           Buyer</td>
                    </tr>
                    <asp:Repeater ID="repMediaDay" runat="server" EnableViewState="False">
                        <ItemTemplate>
                            <tr >
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>'
                                    class='mediacalRowBorderBottomLeftMostCell <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <a href="" onclick="Javascript:window.open('MediaCalendar_OrderDetail.aspx?OrdNo=<%# Eval("ORDER_NBR") %>&LineNo=<%# Eval("LINE_NBR") %>&MediaType=<%# Eval("TYPE") %>&RevNo=<%# Eval("REV_NBR") %>&Year=<%# Eval("MEDIA_YEAR") %>', 'PopLookup','screenX=150,left=150,screenY=100,top=100,width=650,height=900,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">
                                        <img align="absmiddle" border="0" src="Images/Icons/Grey/256/magnifying_glass.png" class="icon-image"></a>&nbsp;</td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>'
                                    class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblClient" runat="server" Text='<%# Eval("CL_CODE") %>'
                                        ToolTip='<%# Eval("CL_NAME") %>'></asp:Label>
                                    &nbsp;</td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>'
                                    class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblDivision" runat="server" Text='<%#Eval("DIV_CODE")%>'
                                        ToolTip='<%#Eval("DIV_NAME")%>'></asp:Label>
                                    &nbsp;</td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>'
                                    class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblProduct" runat="server" Text='<%#Eval("PRD_CODE")%>'
                                        ToolTip='<%#Eval("PRD_DESCRIPTION")%>'></asp:Label>
                                    &nbsp;</td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>'
                                    class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("TYPE")%>
                                    &nbsp;</td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>'
                                    class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("ORDER_NBR")%>
                                    &nbsp;</td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>'
                                    class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%# Eval("LINE_NBR") %>
                                    &nbsp;</td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>'
                                    class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("REV_NBR")%>
                                    &nbsp;</td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>'
                                    class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("VN_CODE")%>
                                    &nbsp;-&nbsp;<%#Eval("VN_NAME")%>
                                    &nbsp;</td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>'
                                    class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("ORDER_DESC")%>
                                    &nbsp;</td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>'
                                    class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("BUYER")%>
                                    &nbsp;</td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
    </table>
    <table align="center" border="0" cellpadding="0" cellspacing="2" style="display: none;"
        width="80%">
        <tr>
            <td width="16%">
                <asp:TextBox ID="TbMagazine" runat="server" BackColor="#FBD777"  SkinID="TextBoxStandard"
                    ReadOnly="true" Width="12"></asp:TextBox>&nbsp;Magazine</td>
            <td width="16%">
                <asp:TextBox ID="TbNewspaper" runat="server" BackColor="#EFA367"  SkinID="TextBoxStandard"
                    ReadOnly="true" Width="12"></asp:TextBox>&nbsp;Newspaper</td>
            <td width="16%">
                <asp:TextBox ID="TbInternet" runat="server" BackColor="#D3BEBE"  SkinID="TextBoxStandard"
                    ReadOnly="true" Width="12"></asp:TextBox>&nbsp;Internet</td>
            <td width="16%">
                <asp:TextBox ID="TbOutdoor" runat="server" BackColor="#B3DFA7"  SkinID="TextBoxStandard"
                    ReadOnly="true" Width="12"></asp:TextBox>&nbsp;Out Of Home</td>
            <td width="16%">
                <asp:TextBox ID="TbRadio" runat="server" BackColor="#B6CDCD"  SkinID="TextBoxStandard"
                    ReadOnly="true" Width="12"></asp:TextBox>&nbsp;Radio</td>
            <td width="16%">
                <asp:TextBox ID="TbTelevision" runat="server" BackColor="#DBEFD6"  SkinID="TextBoxStandard"
                    ReadOnly="true" Width="12"></asp:TextBox>&nbsp;Television</td>
        </tr>
    </table>
</asp:Content>
