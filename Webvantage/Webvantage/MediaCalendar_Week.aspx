<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="MediaCalendar_Week.aspx.vb" Inherits="Webvantage.MediaCalendar_Week" Title="Media Calendar (Week View)" %>

<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain"
    EnableViewState="true">
    <table id="Table1" align="center" border="0" cellpadding="0" cellspacing="0" height="100%"
        width="100%">
        <tr>
            <td valign="top">
                <br />
                <table align="Center" border="0" cellpadding="0" cellspacing="0" width="95%">
                    <tr>
                        <td>
                            <telerik:RadTabStrip ID="RadTabStrip" runat="server" AutoPostBack="True" CausesValidation="False"
                                  
                                Width="100%">
                                <Tabs>
                                    <telerik:RadTab ID="Tab1" runat="server" Text="Root Tab">
                                    </telerik:RadTab>
                                </Tabs>
                            </telerik:RadTabStrip>
                        </td>
                    </tr>
                </table>
                <table align="center" border="0" cellpadding="2" cellspacing="0" width="95%">
                    <tr class="ContentHeader ">
                        <td align="left" class="ContentHeaderText" colspan="11" >
                            &nbsp;&nbsp;
                            <asp:Label   ID="lblTitle" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr >
                        <td align="center" class="mediacalHeaderSubBorderLeftMostCell">
                            &nbsp;
                        </td>
                        <td align="center" class="mediacalHeaderSubBorder">
                           Client
                        </td>
                        <td align="center" class="mediacalHeaderSubBorder">
                           Division
                        </td>
                        <td align="center" class="mediacalHeaderSubBorder">
                           Product
                        </td>
                        <td align="center" class="mediacalHeaderSubBorder">
                           Type
                        </td>
                        <td align="center" class="mediacalHeaderSubBorder">
                           Order
                        </td>
                        <td align="center" class="mediacalHeaderSubBorder">
                           Line
                        </td>
                        <td align="center" class="mediacalHeaderSubBorder">
                           Revision
                        </td>
                        <td align="center" class="mediacalHeaderSubBorder">
                           Vendor
                        </td>
                        <td align="center" class="mediacalHeaderSubBorder">
                           Order Desc
                        </td>
                        <td align="center" class="mediacalHeaderSubBorder">
                           Buyer
                        </td>
                    </tr>
                    <asp:Repeater ID="repSunday" runat="server" EnableViewState="False">
                        <HeaderTemplate>
                            <tr>
                                <td class="mediacalHeaderSubBorderBottom" colspan="11">
                                   Sunday
                                </td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr >
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottomLeftMostCell <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <a href="" onclick="Javascript:window.open('MediaCalendar_OrderDetail.aspx?OrdNo=<%# Eval("ORDER_NBR") %>&LineNo=<%# Eval("LINE_NBR") %>&MediaType=<%# Eval("TYPE") %>&RevNo=<%# Eval("REV_NBR") %>&Year=<%# Eval("MEDIA_YEAR") %>', 'PopLookup','screenX=150,left=150,screenY=100,top=100,width=650,height=900,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">
                                        <img align="absmiddle" border="0" src="Images/Icons/Grey/256/magnifying_glass.png" class="icon-image"></a>&nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblClient" runat="server" Text='<%# Eval("CL_CODE") %>' ToolTip='<%# Eval("CL_NAME") %>'></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblDivision" runat="server" Text='<%#Eval("DIV_CODE")%>' ToolTip='<%#Eval("DIV_NAME")%>'></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblProduct" runat="server" Text='<%#Eval("PRD_CODE")%>' ToolTip='<%#Eval("PRD_DESCRIPTION")%>'></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("TYPE")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("ORDER_NBR")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%# Eval("LINE_NBR") %>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("REV_NBR")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("VN_CODE")%>
                                    &nbsp;-&nbsp;<%#Eval("VN_NAME")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("ORDER_DESC")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("BUYER")%>
                                    &nbsp;
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="repMonday" runat="server" EnableViewState="False">
                        <HeaderTemplate>
                            <tr>
                                <td class="mediacalHeaderSubBorderBottom" colspan="11">
                                   Monday
                                </td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr >
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottomLeftMostCell <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <a href="" onclick="Javascript:window.open('MediaCalendar_OrderDetail.aspx?OrdNo=<%# Eval("ORDER_NBR") %>&LineNo=<%# Eval("LINE_NBR") %>&MediaType=<%# Eval("TYPE") %>&RevNo=<%# Eval("REV_NBR") %>&Year=<%# Eval("MEDIA_YEAR") %>', 'PopLookup','screenX=150,left=150,screenY=100,top=100,width=650,height=900,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">
                                        <img align="absmiddle" border="0" src="Images/Icons/Grey/256/magnifying_glass.png" class="icon-image"></a>&nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblClient" runat="server" Text='<%# Eval("CL_CODE") %>' ToolTip='<%# Eval("CL_NAME") %>'></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblDivision" runat="server" Text='<%#Eval("DIV_CODE")%>' ToolTip='<%#Eval("DIV_NAME")%>'></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblProduct" runat="server" Text='<%#Eval("PRD_CODE")%>' ToolTip='<%#Eval("PRD_DESCRIPTION")%>'></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("TYPE")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("ORDER_NBR")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%# Eval("LINE_NBR") %>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("REV_NBR")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("VN_CODE")%>
                                    &nbsp;-&nbsp;<%#Eval("VN_NAME")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("ORDER_DESC")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("BUYER")%>
                                    &nbsp;
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="repTuesday" runat="server" EnableViewState="False">
                        <HeaderTemplate>
                            <tr>
                                <td class="mediacalHeaderSubBorderBottom" colspan="11">
                                   Tuesday
                                </td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr >
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottomLeftMostCell <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <a href="" onclick="Javascript:window.open('MediaCalendar_OrderDetail.aspx?OrdNo=<%# Eval("ORDER_NBR") %>&LineNo=<%# Eval("LINE_NBR") %>&MediaType=<%# Eval("TYPE") %>&RevNo=<%# Eval("REV_NBR") %>&Year=<%# Eval("MEDIA_YEAR") %>', 'PopLookup','screenX=150,left=150,screenY=100,top=100,width=650,height=900,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">
                                        <img align="absmiddle" border="0" src="Images/Icons/Grey/256/magnifying_glass.png" class="icon-image"></a>&nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblClient" runat="server" Text='<%# Eval("CL_CODE") %>' ToolTip='<%# Eval("CL_NAME") %>'></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblDivision" runat="server" Text='<%#Eval("DIV_CODE")%>' ToolTip='<%#Eval("DIV_NAME")%>'></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblProduct" runat="server" Text='<%#Eval("PRD_CODE")%>' ToolTip='<%#Eval("PRD_DESCRIPTION")%>'></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("TYPE")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("ORDER_NBR")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%# Eval("LINE_NBR") %>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("REV_NBR")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("VN_CODE")%>
                                    &nbsp;-&nbsp;<%#Eval("VN_NAME")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("ORDER_DESC")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("BUYER")%>
                                    &nbsp;
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="repWednesday" runat="server" EnableViewState="False">
                        <HeaderTemplate>
                            <tr>
                                <td class="mediacalHeaderSubBorderBottom" colspan="11">
                                   Wednesday
                                </td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr >
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottomLeftMostCell <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <a href="" onclick="Javascript:window.open('MediaCalendar_OrderDetail.aspx?OrdNo=<%# Eval("ORDER_NBR") %>&LineNo=<%# Eval("LINE_NBR") %>&MediaType=<%# Eval("TYPE") %>&RevNo=<%# Eval("REV_NBR") %>&Year=<%# Eval("MEDIA_YEAR") %>', 'PopLookup','screenX=150,left=150,screenY=100,top=100,width=650,height=900,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">
                                        <img align="absmiddle" border="0" src="Images/Icons/Grey/256/magnifying_glass.png" class="icon-image"></a>&nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblClient" runat="server" Text='<%# Eval("CL_CODE") %>' ToolTip='<%# Eval("CL_NAME") %>'></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblDivision" runat="server" Text='<%#Eval("DIV_CODE")%>' ToolTip='<%#Eval("DIV_NAME")%>'></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblProduct" runat="server" Text='<%#Eval("PRD_CODE")%>' ToolTip='<%#Eval("PRD_DESCRIPTION")%>'></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("TYPE")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("ORDER_NBR")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%# Eval("LINE_NBR") %>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("REV_NBR")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("VN_CODE")%>
                                    &nbsp;-&nbsp;<%#Eval("VN_NAME")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("ORDER_DESC")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("BUYER")%>
                                    &nbsp;
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="repThursday" runat="server" EnableViewState="False">
                        <HeaderTemplate>
                            <tr>
                                <td class="mediacalHeaderSubBorderBottom" colspan="11">
                                   Thursday
                                </td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr >
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottomLeftMostCell <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <a href="" onclick="Javascript:window.open('MediaCalendar_OrderDetail.aspx?OrdNo=<%# Eval("ORDER_NBR") %>&LineNo=<%# Eval("LINE_NBR") %>&MediaType=<%# Eval("TYPE") %>&RevNo=<%# Eval("REV_NBR") %>&Year=<%# Eval("MEDIA_YEAR") %>', 'PopLookup','screenX=150,left=150,screenY=100,top=100,width=650,height=900,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">
                                        <img align="absmiddle" border="0" src="Images/Icons/Grey/256/magnifying_glass.png" class="icon-image"></a>&nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblClient" runat="server" Text='<%# Eval("CL_CODE") %>' ToolTip='<%# Eval("CL_NAME") %>'></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblDivision" runat="server" Text='<%#Eval("DIV_CODE")%>' ToolTip='<%#Eval("DIV_NAME")%>'></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblProduct" runat="server" Text='<%#Eval("PRD_CODE")%>' ToolTip='<%#Eval("PRD_DESCRIPTION")%>'></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("TYPE")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("ORDER_NBR")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%# Eval("LINE_NBR") %>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("REV_NBR")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("VN_CODE")%>
                                    &nbsp;-&nbsp;<%#Eval("VN_NAME")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("ORDER_DESC")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("BUYER")%>
                                    &nbsp;
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="repFriday" runat="server" EnableViewState="False">
                        <HeaderTemplate>
                            <tr>
                                <td class="mediacalHeaderSubBorderBottom" colspan="11">
                                   Friday
                                </td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr >
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottomLeftMostCell <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <a href="" onclick="Javascript:window.open('MediaCalendar_OrderDetail.aspx?OrdNo=<%# Eval("ORDER_NBR") %>&LineNo=<%# Eval("LINE_NBR") %>&MediaType=<%# Eval("TYPE") %>&RevNo=<%# Eval("REV_NBR") %>&Year=<%# Eval("MEDIA_YEAR") %>', 'PopLookup','screenX=150,left=150,screenY=100,top=100,width=650,height=900,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">
                                        <img align="absmiddle" border="0" src="Images/Icons/Grey/256/magnifying_glass.png" class="icon-image"></a>&nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblClient" runat="server" Text='<%# Eval("CL_CODE") %>' ToolTip='<%# Eval("CL_NAME") %>'></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblDivision" runat="server" Text='<%#Eval("DIV_CODE")%>' ToolTip='<%#Eval("DIV_NAME")%>'></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblProduct" runat="server" Text='<%#Eval("PRD_CODE")%>' ToolTip='<%#Eval("PRD_DESCRIPTION")%>'></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("TYPE")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("ORDER_NBR")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%# Eval("LINE_NBR") %>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("REV_NBR")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("VN_CODE")%>
                                    &nbsp;-&nbsp;<%#Eval("VN_NAME")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("ORDER_DESC")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("BUYER")%>
                                    &nbsp;
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="repSaturday" runat="server" EnableViewState="False">
                        <HeaderTemplate>
                            <tr>
                                <td class="mediacalHeaderSubBorderBottom" colspan="11">
                                   Saturday
                                </td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr >
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottomLeftMostCell <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <a href="" onclick="Javascript:window.open('MediaCalendar_OrderDetail.aspx?OrdNo=<%# Eval("ORDER_NBR") %>&LineNo=<%# Eval("LINE_NBR") %>&MediaType=<%# Eval("TYPE") %>&RevNo=<%# Eval("REV_NBR") %>&Year=<%# Eval("MEDIA_YEAR") %>', 'PopLookup','screenX=150,left=150,screenY=100,top=100,width=650,height=900,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">
                                        <img align="absmiddle" border="0" src="Images/Icons/Grey/256/magnifying_glass.png" class="icon-image"></a>&nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblClient" runat="server" Text='<%# Eval("CL_CODE") %>' ToolTip='<%# Eval("CL_NAME") %>'></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblDivision" runat="server" Text='<%#Eval("DIV_CODE")%>' ToolTip='<%#Eval("DIV_NAME")%>'></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <asp:Label   ID="lblProduct" runat="server" Text='<%#Eval("PRD_CODE")%>' ToolTip='<%#Eval("PRD_DESCRIPTION")%>'></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("TYPE")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("ORDER_NBR")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%# Eval("LINE_NBR") %>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("REV_NBR")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("VN_CODE")%>
                                    &nbsp;-&nbsp;<%#Eval("VN_NAME")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("ORDER_DESC")%>
                                    &nbsp;
                                </td>
                                <td align="center" bgcolor='<%#SetColor(Eval("TYPE").ToString()) %>' class='mediacalRowBorderBottom <%# SetClass(Eval("MAT_COMP").ToString(),Eval("LINE_CANCELLED").ToString) %>'
                                    valign="middle">
                                    <%#Eval("BUYER")%>
                                    &nbsp;
                                </td>
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
                <asp:TextBox ID="TbMagazine" runat="server" BackColor="#FBD777" ReadOnly="true" Width="12" SkinID="TextBoxStandard"></asp:TextBox>&nbsp;Magazine
            </td>
            <td width="16%">
                <asp:TextBox ID="TbNewspaper" runat="server" BackColor="#EFA367" ReadOnly="true" SkinID="TextBoxStandard"
                    Width="12"></asp:TextBox>&nbsp;Newspaper
            </td>
            <td width="16%">
                <asp:TextBox ID="TbInternet" runat="server" BackColor="#D3BEBE" ReadOnly="true" Width="12" SkinID="TextBoxStandard"></asp:TextBox>&nbsp;Internet
            </td>
            <td width="16%">
                <asp:TextBox ID="TbOutdoor" runat="server" BackColor="#B3DFA7" ReadOnly="true" Width="12" SkinID="TextBoxStandard"></asp:TextBox>&nbsp;Out
                Of Home
            </td>
            <td width="16%">
                <asp:TextBox ID="TbRadio" runat="server" BackColor="#B6CDCD" ReadOnly="true" Width="12" SkinID="TextBoxStandard"></asp:TextBox>&nbsp;Radio
            </td>
            <td width="16%">
                <asp:TextBox ID="TbTelevision" runat="server" BackColor="#DBEFD6" ReadOnly="true" SkinID="TextBoxStandard"
                    Width="12"></asp:TextBox>&nbsp;Television
            </td>
        </tr>
    </table>
</asp:Content>
