<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="dtp_agencyGoals_graph_print.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.dtp_agencyGoals_graph_print" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" border="0" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td align="Left">
                <asp:Label   ID="Label1" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label   ID="lblType" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <telerik:RadHtmlChart ID="RadHtmlChartAgencyGoals" runat="server" Width="90%" Height="500" Transitions="true">
                    <PlotArea>
                        <XAxis>
                            <Items>
                            </Items>
                        </XAxis>
                        <YAxis>
                            <LabelsAppearance DataFormatString="{0:C0} M"></LabelsAppearance>
                        </YAxis>
                        <Series>
                            <telerik:ColumnSeries Name="">
                                <SeriesItems>
                                </SeriesItems>
                                <TooltipsAppearance Color="White">
                                    <ClientTemplate>
                                        #=category#, #= kendo.format(\'{0:C2}\', value)# M 
                                    </ClientTemplate>
                                </TooltipsAppearance>
                                <LabelsAppearance DataFormatString="{0:C} M" />
                            </telerik:ColumnSeries>
                        </Series>
                    </PlotArea>
                </telerik:RadHtmlChart>
            </td>
        </tr>
    </table>
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
</asp:Content>
