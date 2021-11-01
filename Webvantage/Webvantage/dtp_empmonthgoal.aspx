<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="dtp_empmonthgoal.aspx.vb" Inherits="Webvantage.dtp_empmonthgoal" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" cellpadding="2" cellspacing="0" height="300" width="385">
        <tr>
            <td>
                &nbsp;&nbsp;Billable Hours Goal
            </td>
        </tr>
        <tr>
            <td align="center" valign="top" colspan="2">
                <telerik:RadRadialGauge runat="server" ID="RadRadialGaugeBillableHoursGoal" Width="300" Height="300">
                    <Pointer Value="0">
                        <Cap Size="0.1" />
                    </Pointer>
                    <Scale Min="0" Max="160" MajorUnit="40">
                        <Labels Format="{0} hours" />
                        <Ranges>
                            <telerik:GaugeRange Color="#DC3545" From="0" To="40" />
                            <telerik:GaugeRange Color="#FD7E14" From="40" To="80" />
                            <telerik:GaugeRange Color="#FFC107" From="80" To="120" />
                            <telerik:GaugeRange Color="#5CB85C" From="120" To="160" />
                        </Ranges>
                    </Scale>
                </telerik:RadRadialGauge>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top" colspan="2">
                <telerik:RadGrid ID="RadGridDisplay" runat="server" ShowHeader="false" ShowFooter="false"
                    EnableViewState="false" AllowSorting="true" AutoGenerateColumns="false" GridLines="None"
                    EnableEmbeddedSkins="True">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Description" HeaderText="&nbsp;" SortExpression="Description"
                                UniqueName="ColText">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Value" HeaderText="&nbsp;" SortExpression="Value"
                                UniqueName="ColValue">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
</asp:Content>
