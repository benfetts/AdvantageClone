<%@ Page AutoEventWireup="false" CodeBehind="Estimating_PrintSettings.aspx.vb" Inherits="Webvantage.Estimating_PrintSettings"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Print Estimate" %>

<%@ Register Src="ReportTypeUC.ascx" TagName="reporttype" TagPrefix="uc2" %>
<asp:Content ID="ContentMain" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadTabStrip ID="RadTabStripTaskEstimatePrint" runat="server" AutoPostBack="true" MultiPageID="RadMultiPageEstimatePrint"
        Orientation="HorizontalTop" CausesValidation="false"
        Width="100%">
        <Tabs>
            <telerik:RadTab Text="Standard" PageViewID="RadPageViewStandard" Value="0">
            </telerik:RadTab>
            <telerik:RadTab Text="Custom" PageViewID="RadPageViewCustom" Value="1">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage ID="RadMultiPageEstimatePrint" runat="server" SelectedIndex="0">        
        <telerik:RadPageView ID="RadPageViewStandard" runat="server">
            <div class="estimate-container-print">
                <div id="DivToolbar" runat="server" style="width: 100%;">
                <telerik:RadToolBar ID="RadToolbarEstimatingPrint" runat="server" AutoPostBack="True"
                    Width="100%">
                    <Items>
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonPrint" Value="Print" ToolTip="Print" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAlert" Value="SendAlert" ToolTip="Send Alert" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAssignment" Value="SendAssignment" ToolTip="Send Assignment" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonEmail" Value="SendEmail" ToolTip="Send Email" />
                        <telerik:RadToolBarButton Value="Save" ToolTip="Save Settings" SkinID="RadToolBarButtonSave" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton>
                            <ItemTemplate>
                                &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Save To:"></asp:Label>
                            </ItemTemplate>
                        </telerik:RadToolBarButton>                           
                        <telerik:RadToolBarButton ID="RadToolBarButtonClientSave" Value="ClientSave" Text="Client" ToolTip="Save to Client" CheckOnClick="true" PostBack="False" Group="ClientSave" AllowSelfUnCheck="true"/>
                        <telerik:RadToolBarButton ID="RadToolBarButtonProductSave" Value="ProductSave" Text="Product" ToolTip="Save to Product" CheckOnClick="true" PostBack="False" Group="ProductSave" AllowSelfUnCheck="true"/>
                        <telerik:RadToolBarButton ID="RadToolBarButtonUserSave" Value="UserSave" Text="User" ToolTip="Save to User" CheckOnClick="true" PostBack="False" Group="UserSave" AllowSelfUnCheck="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonAgencySave" Value="AgencySave" Text="Agency" ToolTip="Save to Agency" CheckOnClick="true" PostBack="False" Group="AgencySave" AllowSelfUnCheck="true" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton >
                            <ItemTemplate>
                                &nbsp;&nbsp;<asp:Label ID="LabelFormat" runat="server" Text="Use Format:"></asp:Label>
                            </ItemTemplate>
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton ID="RadToolBarButtonClient" Value="Client" Text="Client" ToolTip="Client Settings" Group="Settings" AllowSelfUnCheck="true" CheckOnClick="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonProduct" Value="Product" Text="Product" ToolTip="Product Settings" Group="Settings" AllowSelfUnCheck="true" CheckOnClick="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonUser" Value="User" Text="User" ToolTip="User Settings" Group="Settings" AllowSelfUnCheck="true" CheckOnClick="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonAgency" Value="Agency" Text="Agency" ToolTip="Agency Settings" Group="Settings" AllowSelfUnCheck="true" CheckOnClick="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonOneTime" Value="OneTime" Text="One-Time" ToolTip="One-Time Settings" Group="Settings" AllowSelfUnCheck="true" CheckOnClick="true" />
                        <telerik:RadToolBarButton IsSeparator="true" />     
                        <telerik:RadToolBarButton id="RadToolbarButtonDate">
                            <ItemTemplate>
                                <telerik:RadDatePicker ID="RadDatePickerDate" runat="server"
                                    SkinID="RadDatePickerStandard">
                                    <DateInput DateFormat="d" EmptyMessage="">
                                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                    </DateInput>
                                    <Calendar ID="Calendar2" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                        <SpecialDays>
                                            <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                            </telerik:RadCalendarDay>
                                        </SpecialDays>
                                    </Calendar>
                                </telerik:RadDatePicker>
                            </ItemTemplate>
                        </telerik:RadToolBarButton>   
                        <telerik:RadToolBarButton ID="RadToolBarButtonDateChange" Value="ChangeDate" Text="Change Date" ToolTip="Click to replace the estimate date with the date selected for printing."/>   
                        
                    </Items>
                </telerik:RadToolBar>
            </div>            
            <div class="sub-header sub-header-color">
                Estimate to Print
            </div>
            <div style="vertical-align: middle" >
            <div style="display: inline-block;" id="divCDP" runat="server">
                <div class="code-description-container">
                    <div class="code-description-label">
                        Client:
                    </div>
                    <div class="code-description-code">
                        <asp:Label ID="LabelClient" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                        <asp:Label ID="LabelClientName" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Division:
                    </div>
                    <div class="code-description-code">
                        <asp:Label ID="LabelDivision" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                        <asp:Label ID="LabelDivisionName" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Product:
                    </div>
                    <div class="code-description-code">
                        <asp:Label ID="LabelProduct" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                        <asp:Label ID="LabelProductName" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        &nbsp;
                    </div>
                    <div class="code-description-code">
                        &nbsp;
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        &nbsp;
                    </div>
                    <div class="code-description-code">
                        &nbsp;
                    </div>
                </div>
            </div>
            <div style="display: inline-block;">
                <div class="code-description-container">
                    <div class="code-description-label">
                        Estimate:
                    </div>
                    <div class="code-description-code">
                        <asp:Label ID="LabelEstimate" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                        <asp:Label ID="LabelEstimateDesc" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Component:
                    </div>
                    <div class="code-description-code">
                        <asp:Label ID="LabelEstimateComp" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                        <asp:Label ID="LabelEstimateCompDesc" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="code-description-container" id="divJob" runat="server">
                    <div class="code-description-label">
                        Job:
                    </div>
                    <div class="code-description-code">
                        <asp:Label ID="LabelJob" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                        <asp:Label ID="LabelJobDesc" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="code-description-container" id="divComponent" runat="server">
                    <div class="code-description-label">
                        Component:
                    </div>
                    <div class="code-description-code">
                        <asp:Label ID="LabelJobComp" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                        <asp:Label ID="LabelJobCompDesc" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="code-description-container" id="divEstimateDate" runat="server">
                    <div class="code-description-label">
                        Estimate Date:
                    </div>
                    <div class="code-description-code">
                        <asp:Label ID="LabelEstimateDate" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
            <div>
                <telerik:RadGrid ID="RadGridQuotes" runat="server" AllowMultiRowSelection="True"
                    AllowSorting="False" AutoGenerateColumns="False" EnableAJAX="False" GridLines="None"
                    Width="75%" Title="Components/Quotes">
                    <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                    <ClientSettings EnablePostBackOnRowClick="False">
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="EstimateNumber,EstimateComponentNumber">
                        <Columns>
                            <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                <HeaderStyle HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="center" />
                            </telerik:GridClientSelectColumn>
                            <telerik:GridBoundColumn DataField="QuoteNumber" HeaderText="Quote" UniqueName="colEST_QUOTE_NBR">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="QuoteDesc" HeaderText="Description" UniqueName="colEST_QUOTE_DESC">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="" UniqueName="colComp" Visible="false">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hfEstimateComp" runat="server" Value='<%# Eval("EstimateComponentNumber")%>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <ExpandCollapseColumn Visible="False">
                            <HeaderStyle Width="19px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
            </div>
            <div class="sub-header sub-header-color">
                Output Options
            </div>
            <div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelUseLocation" runat="server" Text="Use Location Print Options:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonUseLocationPrintOptions" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container">            
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelLocation" runat="server" Text="Location:"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <telerik:RadComboBox ID="RadComboBoxLocation" runat="server" Width="329px" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                    </div>
                </div>
                <div class="code-description-container">            
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelCustomEstimate" runat="server" Text="Custom Estimate:"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <telerik:RadComboBox ID="RadComboBoxCustomEstimate" runat="server" Width="329px" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                    </div>
                </div>
                <div class="code-description-container">            
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelFileFormat" runat="server" Text="File Format:"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <telerik:RadComboBox ID="RadComboBoxFileFormat" runat="server" Width="329px" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                    </div>
                </div>
                <div class="code-description-container">            
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelShowWatermark" runat="server" Text="Show as Draft until Approved:"></asp:Label>
                    </div>
                    <div class="code-description-code">                       
                        <telerik:RadButton ID="RadButtonShowWatermark" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton"></telerik:RadButton>
                    </div>
                </div>
            </div>
            <div class="sub-header sub-header-color">
                Header Options
            </div>
            <div>        
                <div class="code-description-container">            
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelReportTitle" runat="server" Text="Report Title:"></asp:Label>
                    </div>
                    <div class="code-description-description-text">
                        <telerik:RadTextBox ID="RadTextBoxReportTitle" runat="server" Width="350px" MaxLength="30"></telerik:RadTextBox>
                    </div>
                </div>           
            </div>
            <h4>
                Header
            </h4>
            <div class="sub-header sub-header-color" style="padding: 0px 0px 0px 0px">
                &nbsp;&nbsp;Address Block
            </div>
            <div>
                 <div class="code-description-container" style="padding: 10px 0px 0px 0px">            
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelAdressBlock" runat="server" Text="Address Block Type:"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <telerik:RadComboBox ID="RadComboBoxAddressBlock" runat="server" Width="350px" AutoPostBack="True" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelPrintClientName" runat="server" Text="Print Client Name:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonPrintClientName" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                       <asp:Label ID="LabelPrintDivisionName" runat="server" Text="Print Division Name:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonPrintDivisionName" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelPrintProductNam" runat="server" Text="Print Product Name:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonPrintProductName" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelShowCodes" runat="server" Text="Show Codes:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonShowCodes" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelPrintContactAfterAddress" runat="server" Text="Print Contact After Address:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonPrintContactAfterAddress" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container">            
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelContactType" runat="server" Text="Contact Type:"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <telerik:RadComboBox ID="RadComboBoxContactType" runat="server" Width="350px" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                    </div>
                </div>
            </div>    
            <div class="sub-header sub-header-color">
                &nbsp;&nbsp;Include Fields
            </div>
            <div>
                 <div class="code-description-container">            
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelClientReference" runat="server" Text="Client Reference:"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonClientReference" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelAccountExecutive" runat="server" Text="Account Executive:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonAccountExecutive" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                       <asp:Label ID="LabelSalesClass" runat="server" Text="Sales Class:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonSalesClass" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelJobDueDate" runat="server" Text="Job Due Date:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonJobDueDate" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelIncludeAdNumber" runat="server" Text="Include Ad Number:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonIncludeAdNumber" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelEstimateQuantity" runat="server" Text="Estimate Quantity:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonEstimateQuantity" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container">            
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelHideRevisionInfo" runat="server" Text="Hide Revision Info:"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonHideRevisionInfo" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelIncludeCostPerUnit" runat="server" Text="Include Cost Per Unit:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonIncludeCostPerUnit" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container">            
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelIncludeCostPerThousand" runat="server" Text="Include Cost Per Thousand:"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonIncludeCostPerThousand" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
            </div>  
            <div class="sub-header sub-header-color">
                &nbsp;&nbsp;Comments
            </div>
            <div>
                 <div class="code-description-container">            
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelEstimateComment" runat="server" Text="Estimate Comment:"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonEstimateComment" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelEstimateComponentComment" runat="server" Text="Estimate Component Comment:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonEstimateComponentComment" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                       <asp:Label ID="LabelQuoteComment" runat="server" Text="Quote Comment:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonQuoteComment" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelRevisionComment" runat="server" Text="Revision Comment:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonRevisionComment" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelFunctionComment" runat="server" Text="Function Comment:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonFunctionComment" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelSuppliedByNotes" runat="server" Text="Supplied By Notes:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonSuppliedByNotes" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
            </div>
            <div class="sub-header sub-header-color">
                Job Options
            </div>
            <div>
                 <div class="code-description-container">            
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelHideJobNumberandDescription" runat="server" Text="Hide Job Number and Description:"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonHideJobNumberandDescription" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelHideComponentNumberandDescription" runat="server" Text="Hide Component Number and Description:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonHideComponentNumberandDescription" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
            </div>
            <h4>
                Detail, Sorting & Grouping
            </h4>
            <div class="sub-header sub-header-color">
                &nbsp;&nbsp;Report Format Options
            </div>
            <div>
                 <div class="code-description-container">            
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelFormatType" runat="server" Text="Format Type:"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <telerik:RadComboBox ID="RadComboBoxFormatType" runat="server" Width="350px" AutoPostBack="True" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelIncludeQuantityHours" runat="server" Text="Include Quantity/Hours:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonIncludeQuantityHours" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="True"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelIncludeQuantityHoursTotal" runat="server" Text="Include Quantity/Hours Total:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonIncludeQuantityHoursTotal" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>                
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelDisplayQuantity" runat="server" Text="Display Quantity/Hours as Quantity:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonDisplayQuantity" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="True"></telerik:RadButton>
                    </div>
                </div>             
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelDisplayHours" runat="server" Text="Display Quantity/Hours as Hours:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonDisplayHours" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="True"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                       <asp:Label ID="LabelIncludeRate" runat="server" Text="Include Rate:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonIncludeRate" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="True"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                       <asp:Label ID="LabelIncludeRatewithMarkup" runat="server" Text="Include Rate w/Markup:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonIncludeRatewithMarkup" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="True"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelIncludeNonBillableActuals" runat="server" Text="Include Non Billable Actuals:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonIncludeNonBillableActuals" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelIncludeContingency" runat="server" Text="Include Contingency:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonIncludeContingency" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="True"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container">            
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelSummaryLevel" runat="server" Text="Summary Level:"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <telerik:RadComboBox ID="RadComboBoxSummaryLevel" runat="server" AutoPostBack="True" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                    </div>
                </div>
            </div>
            <div class="sub-header sub-header-color">
                &nbsp;&nbsp;Grouping Options
            </div>
            <div>
                 <div class="code-description-container">            
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelOption" runat="server" Text="Option:"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <telerik:RadComboBox ID="RadComboBoxOption" runat="server" Width="250px" AutoPostBack="True" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelInsideDescription" runat="server" Text="Inside Description:"></asp:Label>
                    </div>          
                    <div class="code-description-description-text">
                        <telerik:RadTextBox ID="RadTextBoxInsideDescription" runat="server" Width="350px"></telerik:RadTextBox>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                       <asp:Label ID="LabelOutsideDescription" runat="server" Text="Outside Description:"></asp:Label>
                    </div>          
                    <div class="code-description-description-text">
                        <telerik:RadTextBox ID="RadTextBoxOutsideDescription" runat="server" Width="350px"></telerik:RadTextBox>
                    </div>
                </div>
            </div>
            <div class="sub-header sub-header-color">
                &nbsp;&nbsp;Function Options
            </div>
            <div>
                <div class="code-description-container">            
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelSortOption" runat="server" Text="Sort Option:"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <telerik:RadComboBox ID="RadComboBoxSortOption" runat="server" Width="350px" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                    </div>
                </div>
                <div class="code-description-container">            
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelPrintOption" runat="server" Text="Print Option:"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <telerik:RadComboBox ID="RadComboBoxPrintOption" runat="server" Width="350px" AutoPostBack="True" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                    </div>
                </div>        
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelShowZeroFunctionAmounts" runat="server" Text="Show Zero Function Amounts:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonShowZeroFunctionAmounts" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>        
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelExcludeEmployeeTimeFunctions" runat="server" Text="Exclude Employee Time Functions:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonExcludeEmployeeTimeFunctions" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>        
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelExcludeVendorFunctions" runat="server" Text="Exclude Vendor Functions:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonExcludeVendorFunctions" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>        
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelExcludeIncomeOnlyFunctions" runat="server" Text="Exclude Income Only Functions:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonExcludeIncomeOnlyFunctions" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>        
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelExcludeNonBillableFunctions" runat="server" Text="Exclude Non Billable Functions:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonExcludeNonBillableFunctions" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>        
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelOverrideConsolidation" runat="server" Text="Override Consolidation:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonOverrideConsolidation" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="true"></telerik:RadButton>
                    </div>
                </div>
            </div>   
            <h4>
                Totals and Footer
            </h4>
            <div class="sub-header sub-header-color">
                &nbsp;&nbsp;Total Options
            </div>
            <div>
                 <div class="code-description-container">            
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelShowTaxSeparately" runat="server" Text="Show Tax Separately:"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonShowTaxSeparately" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelIndicateTaxableFunctions" runat="server" Text="Indicate Taxable Functions:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonIndicateTaxableFunctions" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                       <asp:Label ID="LabelShowCommissionSeparately" runat="server" Text="Show Commission Separately:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonShowCommissionSeparately" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelIndicateCommissionSeparately" runat="server" Text="Indicate Commission Separately:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonIndicateCommissionSeparately" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelShowContingencySeparately" runat="server" Text="Show Contingency Separately:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonShowContingencySeparately" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelSubtotalsOnly" runat="server" Text="Subtotals Only:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonSubtotalsOnly" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
            </div>
            <div class="sub-header sub-header-color">
                &nbsp;&nbsp;Footer Comments
            </div>
            <div>
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelDefaultFooterComments" runat="server" Text="Default Footer Comments:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonDefaultFooterComments" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton" AutoPostBack="False"></telerik:RadButton>
                    </div>
                </div>
            </div>
            <div class="sub-header sub-header-color">
                &nbsp;&nbsp;Signature
            </div>
            <div>
                <div class="code-description-container">            
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelSignature" runat="server" Text="Signature:"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <telerik:RadComboBox ID="RadComboBoxSignature" runat="server" Width="350px" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                    </div>
                </div>        
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelExcludeEmployeeSignature" runat="server" Text="Exclude Employee Signature:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonExcludeEmployeeSignature" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton"></telerik:RadButton>
                    </div>
                </div>        
                <div class="code-description-container"> 
                    <div class="code-description-label-xxxl">
                        <asp:Label ID="LabelExcludeDateFromSignature" runat="server" Text="Exclude Date From Signature:"></asp:Label>
                    </div>          
                    <div class="code-description-code">
                        <telerik:RadButton ID="RadButtonExcludeDateFromSignature" runat="server" Text="" ShowButton="True" ToggleType="CheckBox" ButtonType="ToggleButton"></telerik:RadButton>
                    </div>
                </div>
            </div>       
            </div>
             
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageViewCustom" runat="server">
             <script type="text/javascript">
                function showhide(id) {
                    if (document.getElementById) {
                        obj = document.getElementById(id);
                        if (obj.style.display == "none") {
                            obj.style.display = "";
                        } else {
                            obj.style.display = "none";
                        }
                    }
                }
                function disableobject(id1, id2, id3, id4, id5, id6, id7, id8, id9, id10, id11, id12, id13, id14) {
                    if (document.getElementById) {
                        obj = document.getElementById(id1);
                        obj2 = document.getElementById(id2);
                        obj3 = document.getElementById(id3);
                        obj4 = document.getElementById(id4);
                        obj5 = document.getElementById(id5);
                        obj6 = document.getElementById(id6);
                        obj7 = document.getElementById(id7);
                        obj8 = document.getElementById(id8);
                        obj9 = document.getElementById(id9);
                        obj10 = document.getElementById(id10);
                        obj11 = document.getElementById(id11);
                        obj12 = document.getElementById(id12);
                        obj13 = document.getElementById(id13);
                        obj14 = document.getElementById(id14);
                        if (obj.checked) {
                            obj2.disabled = true;
                            obj3.disabled = true;
                            obj4.disabled = true;
                            obj5.disabled = true;
                            obj6.disabled = true;
                            obj7.disabled = true;
                            obj8.disabled = true;
                            obj9.disabled = true;
                            obj10.disabled = true;
                            obj11.disabled = true;
                            obj12.disabled = true;
                            obj13.disabled = true;
                            obj14.disabled = true;
                        } else {
                            obj2.disabled = false;
                            obj3.disabled = false;
                            obj4.disabled = false;
                            obj5.disabled = false;
                            obj6.disabled = false;
                            obj7.disabled = false;
                            obj8.disabled = false;
                            obj9.disabled = false;
                            obj10.disabled = false;
                            obj11.disabled = false;
                            obj12.disabled = false;
                            obj13.disabled = false;
                            obj14.disabled = false;
                        }

                    }
                }
                function enableobject(id1, id2, id3, id4, id5, id6, id7, id8, id9, id10, id11, id12, id13, id14) {
                    if (document.getElementById) {
                        obj = document.getElementById(id1);
                        obj2 = document.getElementById(id2);
                        obj3 = document.getElementById(id3);
                        obj4 = document.getElementById(id4);
                        obj5 = document.getElementById(id5);
                        obj6 = document.getElementById(id6);
                        obj7 = document.getElementById(id7);
                        obj8 = document.getElementById(id8);
                        obj9 = document.getElementById(id9);
                        obj10 = document.getElementById(id10);
                        obj11 = document.getElementById(id11);
                        obj12 = document.getElementById(id12);
                        obj13 = document.getElementById(id13);
                        obj14 = document.getElementById(id14);
                        if (obj.checked) {
                            obj2.disabled = false;
                            obj3.disabled = false;
                            obj4.disabled = false;
                            obj5.disabled = false;
                            obj6.disabled = false;
                            obj7.disabled = false;
                            obj8.disabled = false;
                            obj9.disabled = false;
                            obj10.disabled = false;
                            obj11.disabled = false;
                            obj12.disabled = false;
                            obj13.disabled = false;
                            obj14.disabled = false;
                        } else {
                            obj2.disabled = true;
                            obj3.disabled = true;
                            obj4.disabled = true;
                            obj5.disabled = true;
                            obj6.disabled = true;
                            obj7.disabled = true;
                            obj8.disabled = true;
                            obj9.disabled = true;
                            obj10.disabled = true;
                            obj11.disabled = true;
                            obj12.disabled = true;
                            obj13.disabled = true;
                            obj14.disabled = true;
                        }

                    }
                }
                function enableobjectIO(id1, id2, id3, id4, id5, id6, id7, id8) {
                    if (document.getElementById) {
                        obj = document.getElementById(id1);
                        obj2 = document.getElementById(id2);
                        obj3 = document.getElementById(id3);
                        obj4 = document.getElementById(id4);
                        obj5 = document.getElementById(id5);
                        obj6 = document.getElementById(id6);
                        obj7 = document.getElementById(id7);
                        obj8 = document.getElementById(id8);
                        if (obj.checked) {
                            obj2.disabled = false;
                            obj3.disabled = false;
                            obj4.disabled = false;
                            obj5.disabled = false;
                            obj6.disabled = false;
                            obj7.disabled = false;
                            obj8.disabled = false;
                        } else {
                            obj2.disabled = true;
                            obj3.disabled = true;
                            obj4.disabled = true;
                            obj5.disabled = true;
                            obj6.disabled = false;
                            obj7.disabled = false;
                            obj8.disabled = false;
                        }

                    }
                }
                function enableobjectCont(id1, id2) {
                    if (document.getElementById) {
                        obj = document.getElementById(id1);
                        obj2 = document.getElementById(id2);
                        if (obj.checked) {
                            obj2.disabled = false;
                        } else {
                            obj2.disabled = true;
                        }

                    }
                }
                function enableobjectFH(id1, id2) {
                    if (document.getElementById) {
                        obj = document.getElementById(id1);
                        obj2 = document.getElementById(id2);
                        if (obj.checked) {
                            obj2.disabled = true;
                        } else {
                            obj2.disabled = false;
                        }

                    }
                }
                function disableobjectRate(id1, id2) {
                    if (document.getElementById) {
                        obj = document.getElementById(id1);
                        obj2 = document.getElementById(id2);
                        if (obj.checked) {
                            obj2.disabled = true;
                        } else {
                            obj2.disabled = false;
                        }

                    }
                }
                function enableobjectRate(id1, id2, id3) {
                    if (document.getElementById) {
                        obj = document.getElementById(id1);
                        obj2 = document.getElementById(id2);
                        obj3 = document.getElementById(id3);
                        if (obj.checked) {
                            if (obj3.checked) {
                                obj2.disabled = true;
                            } else {
                                obj2.disabled = false;
                            }
                        } else {
                            obj2.disabled = true;
                        }

                    }
                }
            </script>            
            <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
                <tr>
                    <td>
                        <div id="Div1" runat="server" style="width: 100%;">
                            <telerik:RadToolBar ID="RadToolbarEstimatePrintCustom" runat="server" AutoPostBack="True"
                                Width="100%">
                                <Items>
                                    <telerik:RadToolBarButton IsSeparator="true" />
                                    <telerik:RadToolBarButton SkinID="RadToolBarButtonPrint" Value="Print" ToolTip="Print" />
                                    <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAlert" Value="SendAlert" ToolTip="Send Alert" />
                                    <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAssignment" Value="SendAssignment" ToolTip="Send Assignment" />
                                    <telerik:RadToolBarButton SkinID="RadToolBarButtonEmail" Value="SendEmail" ToolTip="Send Email" />
                                    <telerik:RadToolBarButton Value="Save" ToolTip="Save Settings" SkinID="RadToolBarButtonSave" />
                                    <telerik:RadToolBarButton IsSeparator="true" />
                                </Items>
                            </telerik:RadToolBar>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="sub-header sub-header-color">
                        &nbsp;&nbsp;&nbsp;Estimate to Print
                    </td>
                </tr>
                <tr>
                    <td class="table-fixes">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="left" valign="top" width="50%">
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="middle" width="28%">
                                                <span>
                                                    <asp:Label   ID="lblClient" runat="server">Client:</asp:Label>
                                                </span>
                                            </td>
                                            <td width="2%">
                                                &nbsp;
                                            </td>
                                            <td width="70%">
                                                <asp:Label   ID="LabelClientCode" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                                                <asp:Label   ID="LabelClientDescription" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="middle">
                                                <span>
                                                    <asp:Label   ID="lblDivision" runat="server">Division:</asp:Label></span>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:Label   ID="LabelDivisionCode" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                                                <asp:Label   ID="LabelDivisionDescription" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="middle">
                                                <span>
                                                    <asp:Label   ID="lblProduct" runat="server">Product:</asp:Label></span>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:Label   ID="LabelProductCode" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                                                <asp:Label   ID="LabelProductDescription" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="left" valign="top" width="50%">
                                    <table align="center" border="0" cellpadding="0" cellspacing="2" width="100%">
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="middle" width="28%">
                                                <span>
                                                    <asp:Label   ID="lblEstimate" runat="server">Estimate:</asp:Label></span>
                                            </td>
                                            <td width="2%">
                                                &nbsp;
                                            </td>
                                            <td width="70%">
                                                <asp:Label   ID="LabelEstimateNumber" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                                                <asp:Label   ID="LabelEstimateDescription" runat="server" Text=""></asp:Label>
                                                <asp:HiddenField ID="hfCreateDate" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="middle" width="28%">
                                                <span>
                                                    <asp:Label   ID="lblEstimateComponent" runat="server">Component:</asp:Label></span>
                                            </td>
                                            <td width="2%">
                                                &nbsp;
                                            </td>
                                            <td width="70%">
                                                <asp:Label   ID="LabelEstimateComponentNumber" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                                                <asp:Label   ID="LabelEstimateComponentDescription" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="middle" width="28%">
                                                <span>
                                                    <asp:Label   ID="lblJob" runat="server">Job:</asp:Label></span>
                                            </td>
                                            <td width="2%">
                                                &nbsp;
                                            </td>
                                            <td width="70%">
                                                <asp:Label   ID="LabelJobNumber" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                                                <asp:Label   ID="LabelJobDescription" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="middle">
                                                <span>
                                                    <asp:Label   ID="lblComponent" runat="server">Component:</asp:Label></span>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:Label   ID="LabelJobComponentNumber" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                                                <asp:Label   ID="LabelJobComponentDescription" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td colspan="3" align="center">
                                                <br />
                                                <telerik:RadGrid ID="RadGridEstQuote" runat="server" AllowMultiRowSelection="True"
                                                    AllowSorting="False" AutoGenerateColumns="False" EnableAJAX="False" GridLines="None"
                                                    Width="75%" Title="Components/Quotes">
                                                    <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                                                    <ClientSettings EnablePostBackOnRowClick="False">
                                                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                                                    </ClientSettings>
                                                    <MasterTableView DataKeyNames="EstimateNumber,EstimateComponentNumber">
                                                        <Columns>
                                                            <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                                                <HeaderStyle HorizontalAlign="center" />
                                                                <ItemStyle HorizontalAlign="center" />
                                                            </telerik:GridClientSelectColumn>
                                                            <telerik:GridBoundColumn DataField="QuoteNumber" HeaderText="Quote" UniqueName="colEST_QUOTE_NBR">
                                                                <HeaderStyle HorizontalAlign="left" />
                                                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="QuoteDesc" HeaderText="Description" UniqueName="colEST_QUOTE_DESC">
                                                                <HeaderStyle HorizontalAlign="left" />
                                                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn HeaderText="" UniqueName="colComp" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hfEstimateComp" runat="server" Value='<%# Eval("EstimateComponentNumber")%>' />
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                        </Columns>
                                                        <ExpandCollapseColumn Visible="False">
                                                            <HeaderStyle Width="19px" />
                                                        </ExpandCollapseColumn>
                                                        <RowIndicatorColumn Visible="False">
                                                            <HeaderStyle Width="20px" />
                                                        </RowIndicatorColumn>
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="sub-header sub-header-color">
                        &nbsp;&nbsp;&nbsp;Output Format
                    </td>
                </tr>
                <tr>
                    <td style="height: 45px">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="4" height="5px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 159px;" align="right">
                                    <asp:Label   ID="Label50" runat="server" Text="Report Format:"></asp:Label>
                                </td>
                                <td style="width: 432px;">
                                    &nbsp;<telerik:RadComboBox ID="ddReportFormat" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard"
                                        Width="350px">
                                        <Items>                                            
                                            <telerik:RadComboBoxItem Text="008 - Campaign Estimate Totals by Estimate Component"
                                                Value="008"></telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="009 - Campaign Estimate by Function Heading" Value="009">
                                            </telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="300 - SSX - Campaign Estimate" Value="SS1"></telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="301 - SSX - Estimate" Value="SS2"></telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="302 - Quarry - Campaign Estimate" Value="QUR"></telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="303 - All Components, Subtotal Components" Value="Mars">
                                            </telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="304 - Original/Final Comparison w/Var, No Actual"
                                                Value="304"></telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="305 - Original/Final Comparison, No Actual" Value="305">
                                            </telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="306 - Infinity Estimate" Value="Infinity">
                                            </telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="307 - BWD Estimate Form" Value="BWD">
                                            </telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="308 - BWD Client Estimate Form" Value="BWD2">
                                            </telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="309 - TPN Custom Estimate Form" Value="TPN">
                                            </telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="310 - TPN Custom Estimate Form 2" Value="TPN2">
                                            </telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="311 - Tap Campaign Estimate" Value="TAP">
                                            </telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="312 - Tap Campaign Estimate (Job) " Value="TAP2">
                                            </telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="313 - Revision Comparison w/Var, Prev/Last Revisions" Value="313">
                                            </telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="314 - Side by Side Quote with Function Comments" Value="314">
                                            </telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="315 - GYKA Estimate" Value="315">
                                            </telerik:RadComboBoxItem>
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td style="width: 105px;" align="right">
                                    <asp:Label   ID="Label5" runat="server" Text="Address Options:"></asp:Label>
                                </td>
                                <td rowspan="3" align="left" valign="top">
                                    <asp:RadioButtonList ID="rbCDPAddress" runat="server">
                                        <asp:ListItem Value="Client" Selected="True">Client Address</asp:ListItem>
                                        <asp:ListItem Value="Division">Division Address</asp:ListItem>
                                        <asp:ListItem Value="Product">Product Address</asp:ListItem>
                                        <asp:ListItem Value="Contact">Client Contact Address</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 159px;" align="right">
                                    <asp:Label   ID="Label7" runat="server" Text="Signature Format:"></asp:Label>
                                </td>
                                <td style="width: 432px;">
                                    &nbsp;<telerik:RadComboBox ID="ddSignature" runat="server" AutoPostBack="true" Width="350px" SkinID="RadComboBoxStandard">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="None" Value="0"></telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="001 - Standard Signature" Value="1"></telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="002 - Agency, 2 Client Signatures" Value="2"></telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="003 - Agency Name, Client Authorization" Value="3">
                                            </telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="004 - Agency, 5 Client Signatures" Value="4"></telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="005 - Standard Signature with Client PO Line" Value="5">
                                            </telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="006 - Agency, 2 Client w/Titles" Value="6" Visible="false">
                                            </telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="007 - Agency and Client Signature" Value="7">
                                            </telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="008 - Manager, AE, and Client Signature" Value="8">
                                            </telerik:RadComboBoxItem>
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                                <td style="width: 105px;" align="right">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 159px;" align="right">
                                    &nbsp;
                                </td>
                                <td style="width: 432px;">
                                    &nbsp;<asp:CheckBox ID="CheckBoxExcludeSignatures" runat="server" Text="Exclude Employee Signatures" />
                                </td>
                                <td style="width: 105px;" align="right">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 159px;" align="right">
                                    <asp:Label   ID="Label1" runat="server" Text="Report Title:"></asp:Label>
                                </td>
                                <td style="width: 432px;">
                                    &nbsp;<asp:TextBox ID="txtReportTitle" runat="server" MaxLength="30" Width="388px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                                <td style="width: 105px;" align="right">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" height="5px">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="sub-header sub-header-color">
                        &nbsp;&nbsp;&nbsp;Location
                    </td>
                </tr>
                <tr>
                    <td style="height: 45px">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 159px;" align="right">
                                    <asp:Label   ID="Label3" runat="server" Text="Location ID:"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;<telerik:RadComboBox ID="dl_location" runat="server" Width="329px" DataTextField="LOC_NAME" SkinID="RadComboBoxStandard"
                                        DataValueField="LOCATION_ID">
                                    </telerik:RadComboBox>
                                </td>
                                <td style="width: 159px;" align="right">
                                    <asp:Label   ID="Label6" runat="server" Text="File Format:"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;<telerik:RadComboBox ID="ddlFormat" runat="server" SkinID="RadComboBoxStandard">
                                    </telerik:RadComboBox>
                                    <%--<uc2:reporttype ID="Reporttype2" runat="server" />--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <asp:Panel ID="pnlExclude" runat="server" Visible="false">
                    <tr>
                        <td class="sub-header sub-header-color">
                            &nbsp;&nbsp;&nbsp;Print Options
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxEmp" runat="server" Text="Exclude Employee Time Functions"
                                            Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxVen" runat="server" Text="Exclude Vendor Functions"
                                            Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxIO" runat="server" Text="Exclude Income Only Functions"
                                            Width="336px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </asp:Panel>
                <asp:Panel ID="PanelOtherOptions" runat="server" Visible="false">
                    <tr>
                        <td class="sub-header sub-header-color">
                            &nbsp;&nbsp;&nbsp;Print Options
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxCampaignSummary" runat="server" Text="Include Campaign Summary"
                                            Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxVendor" runat="server" Text="Show Vendor Description"
                                            Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxFunctionComment" runat="server"
                                            Text="Include Function Comment" Width="336px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </asp:Panel>
                <asp:Panel ID="pnlOptions" runat="server">
                    <tr>
                        <td class="sub-header sub-header-color">
                            &nbsp;&nbsp;&nbsp;Print Options
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td style="width: 50px">
                                        &nbsp;
                                    </td>
                                    <td colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbUsePrintedDate" runat="server"
                                            Text="Use Printed Date" />
                                        <asp:Panel ID="pnlDate" runat="server">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Date:&nbsp;&nbsp;
                                            <telerik:RadDatePicker ID="RadDatePickerPrintedDate" runat="server" 
                                                  SkinID="RadDatePickerStandard">
                                                <DateInput DateFormat="d" EmptyMessage="">
                                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                </DateInput>
                                                <Calendar ID="Calendar1" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                    <SpecialDays>
                                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                        </telerik:RadCalendarDay>
                                                    </SpecialDays>
                                                </Calendar>
                                            </telerik:RadDatePicker>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <asp:Panel ID="PnlCheck" runat="server">
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td class="sub-header sub-header-color" colspan="2">
                                        <asp:Label   ID="lblEstGroupOptions" runat="server" Text="Estimate Grouping Options:" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbCombineComps" runat="server" Text="Combine Estimate components"
                                            AutoPostBack="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td class="sub-header sub-header-color" colspan="2">
                                        <asp:Label   ID="lblFunctionOptions" runat="server" Text="Function Options:" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td colspan="2">
                                        <table width="95%">
                                            <tr>
                                                <td colspan="2">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbOverride" runat="server" Text="Override product consolidation setting" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 190px">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbFunctionCode" runat="server" Text="Function Code"
                                                        GroupName="Function" /><br />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbConsolidationCode" runat="server"
                                                        Text="Consolidation Code" GroupName="Function" /><br />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbTotalOnly" runat="server" Text="Total Only"
                                                        GroupName="Function" />
                                                </td>
                                                <td align="left" valign="top" style="width: 951px">
                                                    <asp:RadioButton ID="rbRate" runat="server" Text="Rate" GroupName="Function" /><br />
                                                    <asp:RadioButton ID="rbNone" runat="server" Text="None" GroupName="Function" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td class="sub-header sub-header-color" colspan="2">
                                        <asp:Label   ID="lblTaxOptions" runat="server" Text="Tax Options:" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbShowTax" runat="server" Text="Show Tax Separately" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbIndicateTax" runat="server" Text="Indicate Taxable Functions" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td colspan="2" class="sub-header sub-header-color">
                                        <asp:Label   ID="lblCommMarkup" runat="server" Text="Comm/Markup Options:" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbShowComm" runat="server" Text="Show Comm/MU Separately"
                                            Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbIndicateCommMU" runat="server"
                                            Text="Indicate Comm/MU Functions" Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td class="sub-header sub-header-color" colspan="2">
                                        <asp:Label   ID="Label56" runat="server" Text="Contingency Options:" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbIncludeCont" runat="server" Text="Include Contingency"
                                            Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbShowCont" runat="server" Text="Show Contingency Separately" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td colspan="2" class="sub-header sub-header-color">
                                        <asp:Label   ID="lblAddressOptions" runat="server" Text="Address Block Options:" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbPrintClientName" runat="server"
                                            Text="Print Client Name" Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbPrintDivisionName" runat="server"
                                            Text="Print Division Name" Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbPrintProductName" runat="server"
                                            Text="Print Product Name" Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td colspan="2" class="sub-header sub-header-color">
                                        <asp:Label   ID="lblComment" runat="server" Text="Comment Options:" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbEstimateComment" runat="server"
                                            Text="Estimate Comment" Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbEstimateCompComment" runat="server"
                                            Text="Estimate Component Comment" Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbQuoteComment" runat="server" Text="Quote Comment"
                                            Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbRevisionComment" runat="server"
                                            Text="Revision Comment" Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbFunctionComment" runat="server"
                                            Text="Function Comment" Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbSuppliedByNotes" runat="server"
                                            Text="Supplied By Notes" Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbDefaultFooterComment" runat="server"
                                            Text="Default Footer Comment" Width="336px" /><br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtDefauldFooterComment" SkinID="TextBoxStandard"
                                            runat="server" TextMode="MultiLine" Width="500px" Height="50px" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td colspan="2" class="sub-header sub-header-color">
                                        <asp:Label   ID="lblOther" runat="server" Text="Other:" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbHideCompDesc" runat="server" Text="Hide Component Description"
                                            Width="500px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbHideRevision" runat="server" Text="Hide Revision Info"
                                            Width="500px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbClientReference" runat="server"
                                            Text="Client Reference" Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbAEName" runat="server" Text="AE Name"
                                            Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbSalesClass" runat="server" Text="Sales Class"
                                            Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbJobDueDate" runat="server" Text="Job Due Date"
                                            Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbAdNumber" runat="server" Text="Ad Number"
                                            Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbEstimateQuantity" runat="server"
                                            Text="Estimate Quantity" Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbSuppresZero" runat="server" Text="Suppress Zero Functions"
                                            Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbIncludeNonBillable" runat="server"
                                            Text="Include Nonbillable Actuals" Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbIncludeQtyHrs" runat="server" Text="Include Qty/Hrs"
                                            Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbIncludeRate" runat="server" Text="Include Rate"
                                            Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbSubtotalsOnly" runat="server" Text="Subtotals Only"
                                            Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbIncludeCPU" runat="server" Text="Include Cost Per Unit"
                                            Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbIncludeCPM" runat="server" Text="Include Cost Per Thousand"
                                            Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbExcludeEmpSig" runat="server" Text="Exclude Employee Signature"
                                            Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxExcludeEmpTime" runat="server"
                                            Text="Exclude Employee Time Functions" Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxExcludeVendor" runat="server"
                                            Text="Exclude Vendor Functions" Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxExcludeIO" runat="server"
                                            Text="Exclude Income Only Functions" Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td align="left" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxExcludeNonBillableFunctions" runat="server"
                                            Text="Exclude NonBillable Functions" Width="336px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td colspan="2" class="sub-header sub-header-color">
                                        <asp:Label   ID="lblGroupby" runat="server" Text="Group By:" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbNoneGroupby" runat="server"
                                            Text="None" GroupName="FunctionGroupBy" /><br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbFunctionType" runat="server"
                                            Text="Function Type" GroupName="FunctionGroupBy" /><br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbFunctionHeading" runat="server"
                                            Text="Function Heading" GroupName="FunctionGroupBy" /><br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbFunctionHeadingTO" runat="server"
                                            Text="Function Heading Total Only" GroupName="FunctionGroupBy" /><br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbInsideOutside" runat="server"
                                            Text="Inside/Outside" GroupName="FunctionGroupBy" /><br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbPhase" runat="server" Text="Phase"
                                            GroupName="FunctionGroupBy" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label   ID="lblInsideDesc" runat="server" Text="Inside Desc:"></asp:Label>&nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtInsideDesc" runat="server" SkinID="TextBoxStandard"></asp:TextBox><br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label   ID="lblOutsideDesc" runat="server" Text="Outside Desc:"></asp:Label>
                                        <asp:TextBox ID="txtOutsideDesc" runat="server" SkinID="TextBoxStandard"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td colspan="2" class="sub-header sub-header-color">
                                        <asp:Label   ID="lblSortBy" runat="server" Text="Sort By:" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px">
                                    </td>
                                    <td colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbFunctionCodeSort" runat="server"
                                            Text="Function Code" GroupName="FunctionSortBy" /><br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbFunctionOrderSort" runat="server"
                                            Text="Function Order" GroupName="FunctionSortBy" />
                                    </td>
                                </tr>
                                </asp:Panel>
                            </table>
                        </td>
                    </tr>
                </asp:Panel>
                <tr>
                    <td>
                        <asp:Label   ID="lbl_msg" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
    </telerik:RadMultiPage>

   
</asp:Content>
