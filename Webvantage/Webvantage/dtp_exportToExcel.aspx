<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="dtp_exportToExcel.aspx.vb" Inherits="Webvantage.dtp_exportToExcel" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table border="0" cellpadding="6" cellspacing="0" width="100%">
        <tr>
            <td align="left" colspan="10">
                &nbsp;&nbsp;<asp:Label   ID="lblTitle" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="PVRadG" runat="server" AllowPaging="false" AllowSorting="True"
                    AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True" Width="98%">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" Height="20px">
                    </PagerStyle>
                    <MasterTableView AllowMultiColumnSorting="true">
                        <Columns>
                            <telerik:GridBoundColumn DataField="CDP" HeaderText="Client" UniqueName="CDP" HeaderStyle-VerticalAlign="Bottom">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JobAndComp" HeaderText="Project" UniqueName="JobAndComp"
                                HeaderStyle-VerticalAlign="Bottom">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="AcctExec" HeaderText="AE" UniqueName="AcctExec"
                                HeaderStyle-VerticalAlign="Bottom">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JC_START_DATE" ItemStyle-Width="100px" HeaderText="Start Date"
                                UniqueName="openClosed" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_FIRST_USE_DATE" ItemStyle-Width="100px" HeaderText="Due/Completed"
                                HeaderStyle-VerticalAlign="Bottom" UniqueName="DueActualDate" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Status" ItemStyle-Width="65px" HeaderText="Status"
                                HeaderStyle-VerticalAlign="Bottom" UniqueName="GridBoundColumnStatus">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CL_CODE" UniqueName="CL_CODE" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DIV_CODE" UniqueName="DIV_CODE" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PRD_CODE" UniqueName="PRD_CODE" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PROCESS_DATE" UniqueName="PROCESS_DATE" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="COMPLETED_DATE" UniqueName="COMPLETED_DATE" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_PROCESS_CONTRL" UniqueName="JOB_PROCESS_CONTRL"
                                Visible="false">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                <telerik:RadGrid ID="HVRadGrid" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True" Width="97%">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" Height="20px">
                    </PagerStyle>
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="GROUPING" HeaderText="Description" UniqueName="GROUPING">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="HOURS_POSTED" DataFormatString="{0:#,##0.00}"
                                ItemStyle-HorizontalAlign="Right" HeaderText="Hours<br/>Posted" UniqueName="HOURS_POSTED">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BILLED_AMT" DataFormatString="{0:#,##0.00}" HeaderText="Billed<br/>Amount"
                                UniqueName="BILLED_AMT">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="UNBILLED_AMT" DataFormatString="{0:#,##0.00}"
                                ItemStyle-HorizontalAlign="Right" HeaderText="Unbilled<br/>Amount" UniqueName="UNBILLED_AMT">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NON_BILLABLE" DataFormatString="{0:#,##0.00}"
                                HeaderText="Non<br/>Billable" UniqueName="NON_BILLABLE">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ADJUSTED_AMT" DataFormatString="{0:#,##0.00}"
                                HeaderText="Adjusted<br/>Amount" UniqueName="ADJUSTED_AMT">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="QUOTED_HRS" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right"
                                HeaderText="Quoted Hours" UniqueName="QUOTED_HRS">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="QVA_VARIANCE" DataFormatString="{0:#,##0.00}"
                                ItemStyle-HorizontalAlign="Right" HeaderText="QvA Variance" UniqueName="QVA_VARIANCE">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="HRS_ALLOWED" DataFormatString="{0:#,##0.00}"
                                ItemStyle-HorizontalAlign="Right" HeaderText="Hours Allowed" UniqueName="HRS_ALLOWED">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="HRS_VARIANCE" DataFormatString="{0:#,##0.00}"
                                ItemStyle-HorizontalAlign="Right" HeaderText="Hours Variance" UniqueName="HRS_VARIANCE">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                        </Columns>
                        <ExpandCollapseColumn Visible="False" Resizable="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
</asp:Content>