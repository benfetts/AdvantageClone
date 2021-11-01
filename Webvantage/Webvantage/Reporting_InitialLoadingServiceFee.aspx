<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_InitialLoadingServiceFee.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.Reporting_InitialLoadingServiceFee"
    Title="Set Initial Criteria" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
	<style type="text/css">
		.bare-list {
			list-style-type: none;
			padding: 0;
			margin: 0;
		}
		.bare-list li {
			-webkit-box-sizing: border-box;
			-moz-box-sizing: border-box;
			box-sizing: border-box;
			white-space: nowrap;
		}
	</style>
    <telerik:RadScriptBlock ID="RadScriptBlockRadWindow" runat="server">
        <script type="text/javascript">
            function returnValue() {
                //Get a reference to the parent (MDI) page 
                var oWnd = GetRadWindow();
                //get a reference to the second RadWindow
                var CallingWindowName = 'Create';
                var CallingWindow = oWnd.get_windowManager().getWindowByName(CallingWindowName);
                // Get a reference to the first RadWindow's content
                var CallingWindowContent = CallingWindow.get_contentFrame().contentWindow;
                //Call the predefined function in Dialog1
                //alert(CallingWindowName + '\n' + CallingWindow + '\n');
                CallingWindowContent.ReloadColumns(oWnd);
                //Close the second RadWindow
                oWnd.close();
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
        
        <telerik:RadToolBar ID="RadToolBarDynamicReportInitialLoading" runat="server" AutoPostBack="true"
            Width="100%">
            <Items>
                <telerik:RadToolBarButton ID="RadToolBarSeparatorFirstSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonOK" runat="server"
                    Text="OK" Value="OK" CommandName="OK" ToolTip="OK" />
                <telerik:RadToolBarButton ID="RadToolBarSeparatorSecondSeparator" runat="server"
                    IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonCancel" runat="server" SkinID="RadToolBarButtonCancel"
                    Text="Cancel" Value="Cancel" CommandName="Cancel" ToolTip="Cancel" />
                <telerik:RadToolBarButton ID="RadToolBarSeparatorThirdSeparator" runat="server" IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>

        <div style="margin-top: 10px;">
            <div class="form-layout label-left label-l">
                <ul>
                    <li>Starting Post Period:</li>
                    <li><telerik:RadComboBox ID="RadComboBoxStart" runat="server" AutoPostBack="false" SkinID="RadComboBoxPostPeriod"></telerik:RadComboBox></li>
                    <li style="margin-left: 20px;"><telerik:RadButton ID="RadButtonYTD" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="YTD"></telerik:RadButton></li>
                    <li><telerik:RadButton ID="RadButton1Year" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="1 Year"></telerik:RadButton></li>
                    <li><telerik:RadButton ID="RadButton2YTD" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="2 YTD"></telerik:RadButton></li>
                </ul>
                <ul>
                    <li>Ending Post Period:</li>
                    <li><telerik:RadComboBox ID="RadComboBoxEnd" runat="server" AutoPostBack="false" SkinID="RadComboBoxPostPeriod"></telerik:RadComboBox></li>
                    <li style="margin-left: 20px;"><telerik:RadButton ID="RadButtonMTD" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="MTD"></telerik:RadButton></li>
                    <li><telerik:RadButton ID="RadButton2Years" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="2 Year"></telerik:RadButton></li>
                </ul>
                <ul>
                    <li style="vertical-align: top;">Option for Fee Time:</li>
                    <li><asp:RadioButton id="RadioButtonNone" runat="server" Text="None" GroupName="Fee"/><br />
                        <asp:RadioButton id="RadioButtonEmployeeDefault" runat="server" Text="Employee Default Department" GroupName="Fee"/><br />
                        <asp:RadioButton id="RadioButtonEmployeeTimeEntry" runat="server" Text="Employee Time Entry Department" GroupName="Fee"/><br />
                        <asp:RadioButton id="RadioButtonJobComponent" runat="server" Text="Job/Component" GroupName="Fee"/></li>
                </ul>
                <div>
                    <fieldset id="FieldsetGroupBy" runat="server">
                        <legend>Group By</legend>
                        <div class="grid-container">
                            <div class="grid-col-1-4">
                                <ul class="bare-list">
                                    <li><asp:CheckBox id="CheckBoxClient" runat="server" Text="Client" /></li>
                                    <li><asp:CheckBox id="CheckBoxSalesClass" runat="server" Text="Sales Class" /></li>
                                    <li><asp:CheckBox id="CheckBoxFunctionHeading" runat="server" Text="Function Heading" /></li>
                                    <li><asp:CheckBox id="CheckBoxPostPeriod" runat="server" Text="Post Period" /></li>
                                </ul>
                            </div>
                            <div class="grid-col-1-4">
                                <ul class="bare-list">
                                    <li><asp:CheckBox id="CheckBoxDivision" runat="server" Text="Division" /></li>
                                    <li><asp:CheckBox id="CheckBoxJobNumber" runat="server" Text="Job Number" /></li>
                                    <li><asp:CheckBox id="CheckBoxConsolidation" runat="server" Text="Consolidation" /></li>                            
                                </ul>
                            </div>
                            <div class="grid-col-1-4">
                                <ul class="bare-list">    
                                    <li><asp:CheckBox id="CheckBoxProduct" runat="server" Text="Product" /></li>
                                    <li><asp:CheckBox id="CheckBoxFeeType" runat="server" Text="Fee Type" /></li>
                                    <li><asp:CheckBox id="CheckBoxEmployee" runat="server" Text="Employee" /></li>  
                                </ul>
                            </div>
                            <div class="grid-col-1-4">
                                <ul class="bare-list">
                                    <li><asp:CheckBox id="CheckBoxCampaign" runat="server" Text="Campaign" /></li>
                                    <li><asp:CheckBox id="CheckBoxFunctionCode" runat="server" Text="Function" /></li>
                                    <li><asp:CheckBox id="CheckBoxDate" runat="server" Text="Date" /></li>
                                </ul>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
        
    <br />
</asp:Content>
