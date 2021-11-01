<%@ Page Title="Timesheet Details" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Timesheet_Details.aspx.vb" Inherits="Webvantage.Timesheet_Details_Page" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <style>
        /*do not remove this form cite goes back to 16px*/
         Body th, td {
            font-size: 14px!important;
        }
        input[type="checkbox"] {
            background-color: red !important;
        }
    </style>
    <asp:Panel ID="pnlTrafficInfo" runat="server" Width="100%">
        <div>
            <fieldset>
                 <legend>Estimate and Schedule Info</legend>
                 <div style="">
                    <asp:RadioButton ID="rbQvA" runat="server" AutoPostBack="true" GroupName="Traffic"
                    Text="Quote Vs. Actual" />
                    <asp:RadioButton ID="rbTrafficHours" runat="server" AutoPostBack="true" GroupName="Traffic"
                    Text="Schedule Hours" />
                 </div>
                 <div style="margin-left: 5px;">
                     <div style="display:inline-block; border: 0px solid blue; vertical-align: top !important; text-align: center;">
                        <asp:CheckBox ID="cbEmployee" runat="server" AutoPostBack="true"
                            Text="" />
                     </div>
                     <div style="display:inline-block; border: 0px solid red; padding-top: 0px !important; margin-top: 4px; vertical-align: bottom !important;">
                        Employee Only (Displays quoted and actual hours for employee.)
                     </div>
                 </div>  
                <div style="padding-top: 6px; font-size: 13px!important;">
                    <asp:Label ID="LabelThreshold" runat="server" Text=""></asp:Label>
                </div> 
           </fieldset>
        </div>        
    </asp:Panel>
    <asp:Panel ID="pnlQvA" runat="server" Width="100%">
        <div class="timesheet-fixes">
            <fieldset>
                        <legend>Quote Vs. Actual</legend>
                        <table id="Table1" align="center" border="0" cellpadding="2"
                            cellspacing="0" width="100%">
                            <tr>
                                <td align="right" valign="top">Client:
                                </td>
                                <td>
                                    <asp:Label ID="lblClientCode" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblClientName" runat="server">
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblHoursQuoteText" runat="server" Text="Hours Quoted:"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblHoursQuoted" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">Job:
                                </td>
                                <td>
                                    <asp:Label ID="lblJobNumber" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblJobName" runat="server">
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblHoursPostedText" runat="server" Text="Hours Posted:"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblHoursPosted" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">Component:
                                </td>
                                <td>
                                    <asp:Label ID="lblComponentNumber" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblComponentName" runat="server">
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblHoursRemainingText" runat="server" Text="Hours Remaining:"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblHoursRemaining" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">Estimate:
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblEstimate" runat="server">
                                    </asp:Label>
                                    &nbsp;
                                </td>
                                <td align="left" valign="top">&nbsp;
                                </td>
                                <td align="left">&nbsp;
                                </td>
                                <td align="right">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">Quote:
                                </td>
                                <td>
                                    <asp:Label ID="lblQuoteNumber" runat="server"></asp:Label>
                                </td>
                                <td align="left"></td>
                                <td>
                                    <asp:Label ID="lblAmountQuotedText" runat="server" Text="Amount Quoted:"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblAmountQuoted" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">Revision:
                                </td>
                                <td>
                                    <asp:Label ID="lblRevisionNumber" runat="server"></asp:Label>
                                </td>
                                <td align="left"></td>
                                <td>
                                    <asp:Label ID="lblAmountPostedText" runat="server" Text="Amount Posted:"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblAmountPosted" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">Function:
                                </td>
                                <td>
                                    <asp:Label ID="lblFunction" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblFunctionName" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAmountRemainingText" runat="server" Text="Amount Remaining:"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblAmountRemaining" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">Actual Hours:
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="5">
                                    <asp:GridView ID="gvActualHours" runat="server" AutoGenerateColumns="False" FooterStyle-CssClass="RequiredInput"
                                        HeaderStyle-BackColor="AliceBlue" ShowFooter="true" Width="100%" CellPadding="3">
                                        <Columns>
                                            <asp:TemplateField HeaderText="" Visible="True" HeaderStyle-Width="150">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmpCode" runat="server" Text='<%# Eval("EmployeeName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date" HeaderStyle-Width="70"  HeaderStyle-HorizontalAlign="Right"  ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDate" runat="server" Text='<%# Eval("EmployeeDate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField FooterStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="right" ItemStyle-Width="80"
                                                HeaderText="Hours" ItemStyle-HorizontalAlign="right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHours" runat="server" Text='<%# Eval("TotalemployeeHours") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotalHours" runat="server"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField FooterStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="right" ItemStyle-Width="100"
                                                HeaderText="Amount" ItemStyle-HorizontalAlign="right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Comments" HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblComments" runat="server" Text='<%# Eval("Comments") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <asp:Literal ID="LiteralQvAProgressBar" runat="server"></asp:Literal>
                    </fieldset>
        </div>
        
    </asp:Panel>
    <asp:Panel ID="pnlTrafficHours" runat="server" Width="100%">
        <div class="timesheet-fixes">
            <fieldset>
                        <legend>Schedule Hours</legend>
                        <table id="Table2" align="center" border="0" cellpadding="2"
                            cellspacing="0" width="100%">
                            <tr>
                                <td align="right" valign="top">Client:
                                </td>
                                <td>
                                    <asp:Label ID="lblClientCodeTraffic" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblClientNameTraffic" runat="server">
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblHoursAllowedTextTraffic" runat="server" Text="Hours Allowed:"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblHoursAllowedTraffic" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">Job:
                                </td>
                                <td>
                                    <asp:Label ID="lblJobCodeTraffic" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblJobNameTraffic" runat="server">
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblHoursPostedTextTraffic" runat="server" Text="Hours Posted:"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblHoursPostedTraffic" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">Component:
                                </td>
                                <td>
                                    <asp:Label ID="lblComponentNumberTraffic" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblComponentNameTraffic" runat="server">
                                    </asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblHoursRemainingTextTraffic" runat="server" Text="Hours Remaining:"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblHoursRemainingTraffic" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">Assignment:
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblAssignmentDescription" runat="server"></asp:Label>
                                </td>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" colspan="5">Actual Hours:
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="5">
                                    <asp:GridView ID="gvActualHoursTraffic" runat="server" AutoGenerateColumns="False"
                                        FooterStyle-CssClass="RequiredInput" HeaderStyle-BackColor="AliceBlue" ShowFooter="true"
                                        Width="100%" CellPadding="3">
                                        <Columns>
                                            <asp:TemplateField HeaderText="" Visible="True" HeaderStyle-Width="150">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmpCode" runat="server" Text='<%# Eval("EmployeeName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date" HeaderStyle-Width="100" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDate" runat="server" Text='<%# Eval("EmployeeDate")%>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotalTraffic" runat="server" Text="Total"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField FooterStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="right" HeaderStyle-Width="110"
                                                HeaderText="Hours" ItemStyle-HorizontalAlign="right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblActualHours" runat="server" Text='<%# Eval("TotalEmployeeHours") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotalHoursTraffic" runat="server"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Comments" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblComments" runat="server" Text='<%# Eval("Comments") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" colspan="5">Schedule Hours:
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="5">
                                    <asp:GridView ID="gvTrafficHours" runat="server" AutoGenerateColumns="False" FooterStyle-CssClass="RequiredInput"
                                        HeaderStyle-BackColor="AliceBlue" ShowFooter="true" Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTask" runat="server" Text='<%# Eval("FULL_NAME") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotal" runat="server" Text="Total"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField FooterStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="right" HeaderStyle-Width="120"
                                                HeaderText="Hours Allowed" ItemStyle-HorizontalAlign="right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHoursAllowed" runat="server" Text='<%# Eval("TotalJobHours") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotalHours" runat="server"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:Label ID="lblNoTrafficHours" runat="server" Text="No Schedule Hours Assigned!"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:Literal ID="LiteralTrafficProgressBar" runat="server"></asp:Literal>
                    </fieldset>
        </div>
        
    </asp:Panel>
    <div style="text-align:center;margin: 5px;">
        <asp:Button ID="butMarkCompleted" runat="server" Text="Mark Completed" Visible="false" />&nbsp;
    </div>
</asp:Content>
