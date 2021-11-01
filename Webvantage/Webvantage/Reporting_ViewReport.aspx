<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Reporting_ViewReport.aspx.vb" Inherits="Webvantage.Reporting_ViewReport" %>

<%@ Register Assembly="DevExpress.XtraReports.v20.1.Web.WebForms, Version=20.1.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<asp:Content ID="ContentViewReport" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock" runat="server">
        <script type="text/javascript">

    function init(s) {
            var createFrameElement = s.viewer.printHelper.createFrameElement;
            s.viewer.printHelper.createFrameElement = function (name) {
                var frameElement = createFrameElement.call(this, name);
                if(ASPx.Browser.Chrome) {
                    frameElement.addEventListener("load", function (e) {
                        if (frameElement.contentDocument.contentType !== "text/html")
                            frameElement.contentWindow.print();
                    });
                }
                return frameElement;
            }
    }
            
            function ReportToolbar_ButtonClick(s, e) {

                if (e.item.name == "Back") {   
                    
                     window.location.href = "<%= _BackButtonURL %>";
                  
                }
                if (e.item.name == "Filter") {

                    window.location.href = "Reporting_FilterReport.aspx?Type=1";

                }
            }

        </script>
    </telerik:RadScriptBlock>
    <table align="center" border="0" cellpadding="0" cellspacing="0"
        width="100%">
        <tr>
            <td runat="server" align="left" valign="top" colspan="2">
                <%-- <dx:ReportToolbar ID="ReportToolbar" runat='server' ShowDefaultButtons='false' ReportViewer="<%#ReportViewer%>" ClientSideEvents-ItemClick="ReportToolbar_ButtonClick" >
                    <Items>
                        <dx:ReportToolbarButton ItemKind='Search' />
                        <dx:ReportToolbarSeparator />
                        <dx:ReportToolbarButton ItemKind='PrintReport' />
                        <dx:ReportToolbarButton ItemKind='PrintPage' />
                        <dx:ReportToolbarSeparator />
                        <dx:ReportToolbarButton Enabled='False' ItemKind='FirstPage' />
                        <dx:ReportToolbarButton Enabled='False' ItemKind='PreviousPage' />
                        <dx:ReportToolbarLabel ItemKind='PageLabel' />
                        <dx:ReportToolbarComboBox ItemKind='PageNumber' Width='65px'>
                        </dx:ReportToolbarComboBox>
                        <dx:ReportToolbarLabel ItemKind='OfLabel' />
                        <dx:ReportToolbarTextBox IsReadOnly='True' ItemKind='PageCount' />
                        <dx:ReportToolbarButton ItemKind='NextPage' />
                        <dx:ReportToolbarButton ItemKind='LastPage' />
                        <dx:ReportToolbarSeparator />
                        <dx:ReportToolbarButton ItemKind='SaveToDisk' />
                        <dx:ReportToolbarButton ItemKind='SaveToWindow' />
                        <dx:ReportToolbarComboBox ItemKind='SaveFormat' Width='70px'>
                            <Elements>
                                <dx:ListElement Value='pdf' />
                                <dx:ListElement Value='xls' />
                                <dx:ListElement Value='xlsx' />
                                <dx:ListElement Value='rtf' />
                                <dx:ListElement Value='mht' />
                                <dx:ListElement Value='html' />
                                <dx:ListElement Value='txt' />
                                <dx:ListElement Value='csv' />
                                <dx:ListElement Value='png' />
                            </Elements>
                        </dx:ReportToolbarComboBox>
                        <dx:ReportToolbarButton Name="Filter" ItemKind="Custom" Text="Filter" ImageUrl=""/>
                        <dx:ReportToolbarButton Name="ExpandAll" ItemKind="Custom" Text="Expand All" ImageUrl=""/>
                        <dx:ReportToolbarButton Name="CollapseAll" ItemKind="Custom" Text="Collapse All" ImageUrl=""/>
                        <dx:ReportToolbarButton Name="Back" ItemKind="Custom" Text="Back" SkinID="RadToolBarButtonClear"/>
                    </Items>
                    <Styles>
                        <LabelStyle>
                            <Margins MarginLeft='3px' MarginRight='3px' />
                        </LabelStyle>
                    </Styles>
                </dx:ReportToolbar>
                <dx:ReportViewer ID="ReportViewer" runat="server" EnableCallbackCompression="false" >
                </dx:ReportViewer>--%>
                <%--<dx:ASPxWebDocumentViewer ID="ASPxWebDocumentViewer" runat="server"></dx:ASPxWebDocumentViewer>--%>
                <dx:ASPxDocumentViewer ID="ASPxDocumentViewer" runat="server" ClientSideEvents-ToolbarItemClick="ReportToolbar_ButtonClick" StylesSplitter-ToolbarPaneHeight="35px">
                    <ClientSideEvents Init="init" />
                    <SettingsReportViewer UseIFrame="false" ShouldDisposeReport="false" EnableReportMargins="true" />
                    <ToolbarItems>
                        <dx:ReportToolbarButton ItemKind="Search" />
                        <dx:ReportToolbarSeparator />
                        <dx:ReportToolbarButton ItemKind="PrintReport" />
                        <dx:ReportToolbarButton ItemKind="PrintPage" />
                        <dx:ReportToolbarSeparator />
                        <dx:ReportToolbarButton Enabled="False" ItemKind="FirstPage" />
                        <dx:ReportToolbarButton Enabled="False" ItemKind="PreviousPage" />
                        <dx:ReportToolbarLabel ItemKind="PageLabel" />
                        <dx:ReportToolbarComboBox ItemKind="PageNumber" Width="65px">
                        </dx:ReportToolbarComboBox>
                        <dx:ReportToolbarLabel ItemKind="OfLabel" />
                        <dx:ReportToolbarTextBox IsReadOnly="True" ItemKind="PageCount" />
                        <dx:ReportToolbarButton ItemKind="NextPage" />
                        <dx:ReportToolbarButton ItemKind="LastPage" />
                        <dx:ReportToolbarSeparator />
                        <dx:ReportToolbarButton ItemKind="SaveToDisk" />
                        <dx:ReportToolbarButton ItemKind="SaveToWindow" />
                        <dx:ReportToolbarComboBox ItemKind="SaveFormat" Width="70px">
                            <Elements>
                                <dx:ListElement Value="pdf" />
                                <dx:ListElement Value="xls" />
                                <dx:ListElement Value="xlsx" />
                                <dx:ListElement Value="rtf" />
                                <dx:ListElement Value="mht" />
                                <dx:ListElement Value="html" />
                                <dx:ListElement Value="txt" />
                                <dx:ListElement Value="csv" />
                                <dx:ListElement Value="png" />
                            </Elements>
                        </dx:ReportToolbarComboBox>
                        <dx:ReportToolbarButton Name="Filter" ItemKind="Custom" Text="Filter" />
                        <dx:ReportToolbarButton Name="ExpandAll" ItemKind="Custom" Text="Expand All" />
                        <dx:ReportToolbarButton Name="CollapseAll" ItemKind="Custom" Text="Collapse All" />
                        <dx:ReportToolbarButton Name="Back" ItemKind="Custom" Text="Back" />
                    </ToolbarItems>
                </dx:ASPxDocumentViewer>
            </td>
        </tr>
        <tr class="ContentHeader">
            <td colspan="2">
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
