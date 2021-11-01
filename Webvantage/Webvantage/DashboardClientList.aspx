<%@ Page AutoEventWireup="false" CodeBehind="DashboardClientList.aspx.vb" Inherits="Webvantage.DashboardClientList"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Dashboard" %>

<asp:Content ID="ContentDashboard" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <table align="left" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="left" valign="top" width="5%">
                                        <telerik:RadToolBar ID="RadToolbarData" runat="server"  
                                            AutoPostBack="True" Width="100%">
                                            <Items>
                                            </Items>
                                        </telerik:RadToolBar>
                                    </td>
                                    <td align="left" valign="top" width="45%">
                                        <telerik:RadToolBar ID="RadToolbarDashProject" runat="server" 
                                             AutoPostBack="True" Width="100%">
                                            <Items>
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Year to Date" Value="YeartoDate" ToolTip="Calculate Data year to Date"
                                                    CheckOnClick="true" Checked="true" AllowSelfUnCheck="true" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Month" Value="Month" ToolTip="Calculate Data by Month"
                                                    CheckOnClick="true" Checked="true" AllowSelfUnCheck="true" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton runat="server">
                                                    <ItemTemplate>
                                                        &nbsp;Month:
                                                        <telerik:RadComboBox ID="DropDownListMonth" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard">
                                                        </telerik:RadComboBox>
                                                        &nbsp;
                                                    </ItemTemplate>
                                                </telerik:RadToolBarButton>
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton runat="server">
                                                    <ItemTemplate>
                                                        &nbsp;Week:
                                                        <telerik:RadComboBox ID="DropDownListWeek" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard">
                                                        </telerik:RadComboBox>
                                                        &nbsp;
                                                    </ItemTemplate>
                                                </telerik:RadToolBarButton>
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                            </Items>
                                        </telerik:RadToolBar>
                                    </td>
                                    <td align="left" valign="top" width="50%">
                                        <telerik:RadToolBar ID="RadToolbarPE" runat="server"  
                                            Width="100%">
                                            <Items>
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton runat="server">
                                                    <ItemTemplate>
                                                        &nbsp;Summary Level:
                                                        <telerik:RadComboBox ID="DropDownListLevel" runat="server" AutoPostBack="true" SkinID="RadComboBoxText20" >
                                                            <Items>
                                                             <telerik:RadComboBoxItem Value="C" Text="Client"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="CD" Text="Client/Division"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="CDP" Text="Client/Division/Product"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="AE" Text="Account Executive"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="dept" Text="Department"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="SC" Text="Sales Class"></telerik:RadComboBoxItem>
                                                            <telerik:RadComboBoxItem Value="JT" Text="Job Type"></telerik:RadComboBoxItem>
                                                           </Items>
                                                        </telerik:RadComboBox>
                                                        &nbsp;
                                                    </ItemTemplate>
                                                </telerik:RadToolBarButton>
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="" Value="Print" SkinID="RadToolBarButtonPrint" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton SkinID="RadToolBarButtonExportExcel" ToolTip="Export to Excel" Value="Export" />
                                            </Items>
                                        </telerik:RadToolBar>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" colspan="3">
                                        <telerik:RadToolBar ID="RadToolbarNav" runat="server"  
                                            AutoPostBack="True" Width="100%">
                                            <Items>
                                                <telerik:RadToolBarButton Text="Selection" Value="Filter" ToolTip="Selection" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Summary" Value="Summary" ToolTip="Summary" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Year" Value="Year" ToolTip="Year" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Month" Value="Month" ToolTip="Month" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                                <telerik:RadToolBarButton Text="Week" Value="Week" ToolTip="Week" />
                                                <telerik:RadToolBarButton IsSeparator="true" />
                                            </Items>
                                        </telerik:RadToolBar>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="60%" valign="top">
                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <telerik:RadGrid ID="RadGridProjects" runat="server" AutoGenerateColumns="false"
                                            GridLines="None" EnableEmbeddedSkins="True" HorizontalAlign="Center" AllowSorting="true"
                                            ShowFooter="true">
                                            <MasterTableView DataKeyNames="JOB,JOB_COMPONENT_NBR">
                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="JOB" HeaderText="Job" UniqueName="column1" ItemStyle-HorizontalAlign="Left"
                                                        HeaderStyle-Width="50px">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="JOB_DESC" HeaderText="Description" UniqueName="column3"
                                                        Visible="false">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="JOB_COMPONENT_NBR" HeaderText="Component" UniqueName="column4"
                                                        Visible="false">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="JOB_COMP_DESC" HeaderText="Description" UniqueName="column11">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="SC_CODE" HeaderText="" UniqueName="column5" Visible="false">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="SC_DESCRIPTION" HeaderText="Sales Class" UniqueName="column36">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="JOB_TYPE" HeaderText="" UniqueName="column6"
                                                        Visible="false">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="JT_DESC" HeaderText="Job Type" UniqueName="column26">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="DP_TM_CODE" HeaderText="" UniqueName="column6"
                                                        Visible="false">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="DP_TM_DESC" HeaderText="Department" UniqueName="column6">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="TRF_CODE" HeaderText="" UniqueName="column6"
                                                        Visible="false">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="TRF_DESCRIPTION" HeaderText="Status" UniqueName="column16">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="JOB_COMP_DATE" HeaderText="Opened Date" UniqueName="column15">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="JOB_FIRST_USE_DATE" HeaderText="Due Date" UniqueName="column25">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="COMPLETED_DATE" HeaderText="Completed Date" UniqueName="column35">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="HOURS" HeaderText="Hours" UniqueName="column35">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="DOLLARS" HeaderText="Dollars" UniqueName="column35">
                                                    </telerik:GridBoundColumn>
                                                </Columns>
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
    </table>
</asp:Content>
