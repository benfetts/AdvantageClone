<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_InitialLoadingMediaTrafficInstructions.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.Reporting_InitialLoadingMediaTrafficInstructions"
    Title="Set Initial Criteria" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
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
    <table align="center" border="0" cellpadding="0" cellspacing="0"
        width="100%">
        <tr>
            <td runat="server" id="TdRadToolBarDynamicReportInitialLoading" align="left" valign="top"
                colspan="2">
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
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" colspan="2">
                <telerik:RadTabStrip ID="RadTabStripTaskCalendar" runat="server" AutoPostBack="true" MultiPageID="RadMultiPageCalendar"
                    Orientation="HorizontalTop" CausesValidation="false"
                    Width="100%">
                    <Tabs>
                        <telerik:RadTab Text="Options" PageViewID="RadPageViewOptions" Value="0">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPageCalendar" runat="server" SelectedIndex="0">   
                    <telerik:RadPageView ID="RadPageViewOptions" runat="server">
                        <table id="TablePageViewOptions" align="center" cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td valign="top">
                                     <fieldset id="FieldsetMediaTraffic" runat="server">
                                      <legend id="legend"><asp:label ID="LabelLegend" runat="server">Traffic Starting Date Range</asp:label></legend>
                                          <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                              <tr>
                                                  <td>
                                                      <asp:Label ID="lblFrom" runat="server" Text="From: "></asp:Label>&nbsp;                                                                    
                                                  </td>
                                                  <td>
                                                      <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" SkinID="RadDatePickerStandard" AutoPostBack="true">
                                                                      <DateInput DateFormat="d" EmptyMessage="">
                                                                          <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                                      </DateInput>
                                                                      <Calendar ID="CalendarStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                                          <SpecialDays>
                                                                              <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                                              </telerik:RadCalendarDay>
                                                                          </SpecialDays>
                                                                      </Calendar>
                                                                  </telerik:RadDatePicker>
                                                  </td>                                                  
                                                  <td>
                                                    <asp:CheckBox id="CheckBoxIncludeInactiveWorksheets" runat="server" Text="Include Inactive Media Broadcast Worksheets" AutoPostBack="true" />                                                    
                                                  </td>  
                                              </tr>
                                              <tr>
                                                  <td>
                                                      <asp:Label ID="lblTo" runat="server" Text="To: "></asp:Label>&nbsp;
                                                  </td>
                                                  <td>
                                                      <telerik:RadDatePicker ID="RadDatePickerEndDate" runat="server" MinDate="1950-01-01" AutoPostBack="true"
                                                                      DatePopupButton-ToolTip="Show calendar" MaxDate="2050-01-01" SkinID="RadDatePickerStandard">
                                                                      <DateInput DateFormat="d" EmptyMessage="">
                                                                          <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                                      </DateInput>
                                                                      <Calendar ID="CalendarEndDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                                          <SpecialDays>
                                                                              <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                                              </telerik:RadCalendarDay>
                                                                          </SpecialDays>
                                                                      </Calendar>
                                                                  </telerik:RadDatePicker>
                                                  </td>
                                                  <td>
                                                       <asp:CheckBox id="CheckBoxIncludeAllMediaTrafficRevisions" runat="server" Text="Include All Media Traffic Revisions" AutoPostBack="true" />
                                                  </td>
                                              </tr>
                                          </table>
                                      </fieldset>
                                </td>
                            </tr>
                        </table>            
                        <telerik:RadGrid ID="RadGridMediaBroadcastWorksheets" runat="server" AutoGenerateColumns="False" GridLines="None"
                            EnableEmbeddedSkins="True" Width="100%" AllowMultiRowSelection="true">
                            <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                <Selecting AllowRowSelect="True" />
                            </ClientSettings>
                            <MasterTableView DataKeyNames="MediaBroadcastWorksheetMarketID,IsCable,IsInactive">
                                <Columns>
                                    <telerik:GridBoundColumn DataField="MediaBroadcastWorksheetID" HeaderText="WS ID" UniqueName="column1"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Name" HeaderText="Name" UniqueName="column2"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="StartDate" HeaderText="Start Date" UniqueName="column3" DataFormatString="{0:d}"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="EndDate" HeaderText="End Date" UniqueName="column4" DataFormatString="{0:d}"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="MarketCode" HeaderText="Market Code" UniqueName="column5"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="MarketDescription" HeaderText="Market Description" UniqueName="column6"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="IsCable" HeaderText="Is Cable" UniqueName="column7"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ClientCode" HeaderText="Client Code" UniqueName="column11"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ClientName" HeaderText="Client Name" UniqueName="column12"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DivisionCode" HeaderText="Division Code" UniqueName="column8"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DivisionName" HeaderText="Division Name" UniqueName="column13"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ProductCode" HeaderText="Product Code" UniqueName="column9"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ProductName" HeaderText="Product Name" UniqueName="column14"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="IsInactive" HeaderText="Is Inactive" UniqueName="column10"></telerik:GridBoundColumn>
                                </Columns>
                                <RowIndicatorColumn Visible="False">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn Resizable="False" Visible="False">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <EditFormSettings>
                                    <PopUpSettings ScrollBars="None" />
                                </EditFormSettings>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </telerik:RadPageView>    
                </telerik:RadMultiPage>
            </td>
        </tr>

    </table>
    <br />
</asp:Content>
