<%@ Page Title="Add Functions" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Estimating_AddRow.aspx.vb" Inherits="Webvantage.Estimating_AddRow" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

     <script type="text/javascript">
         function SelectTextBoxContent(id) {
             document.getElementById(id).focus();
             document.getElementById(id).select();
         }
    </script>
    <script type="text/javascript">
        function CancelNonInputSelect(sender, args) {

            var e = args.get_domEvent();
            //IE - srcElement, Others - target  
            var targetElement = e.srcElement || e.target;


            //this condition is needed if multi row selection is enabled for the grid  
            if (typeof (targetElement) != "undefined") {
                //is the clicked element an input checkbox? <input type="checkbox"...>  
                if (targetElement.tagName.toLowerCase() != "input" &&
                                    (!targetElement.type || targetElement.type.toLowerCase() != "checkbox"))// && currentClickEvent)  
                {

                    //cancel the event  
                    args.set_cancel(true);
                }
            }
            else
                args.set_cancel(true);
        }
        function CheckTheRow(ControlClientId) {
            document.getElementById(ControlClientId).checked = true;
        }

    </script>
    <table align="center" border="0" cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td align="right" valign="middle" >
                <asp:Button ID="BtnAddTasks" runat="server"  Text="Add Functions" />&nbsp;&nbsp;                
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" valign="middle">
                <telerik:RadGrid ID="RadGridQuickAdd" runat="server" AllowMultiRowSelection="True"
                    AllowSorting="True" AutoGenerateColumns="False" enableajax="False" GridLines="None"
                    Width="100%" AllowFilteringByColumn="true" GroupingSettings-CaseSensitive="false">
                    <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                    <ClientSettings EnablePostBackOnRowClick="False">
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                        <ClientEvents OnRowSelecting="CancelNonInputSelect" OnRowDeselecting="CancelNonInputSelect" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="FNC_CODE">
                        <Columns>
                            <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                <HeaderStyle HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="center" />
                            </telerik:GridClientSelectColumn>
                            <telerik:GridTemplateColumn DataField="" HeaderText="Row Qty" UniqueName="ColROW_QTY"
                                AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="center" Width="32px" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="32px" />
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtROW_QTY" runat="server"  SkinID="TextBoxStandard"
                                        MaxLength="2" Style="text-align: right" Text="" Width="50"></asp:TextBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="FNC_TYPE" HeaderText="Type" UniqueName="colFNC_TYPE" CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                ShowFilterIcon="True" FilterDelay="1250" FilterControlWidth="30px" HeaderStyle-Width="30px" ItemStyle-Width="30px">
                                <HeaderStyle HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FNC_CODE" HeaderText="Function" UniqueName="colFNC_CODE" CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                ShowFilterIcon="True" FilterDelay="1250" FilterControlWidth="75%">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FNC_DESCRIPTION" HeaderText="Description" UniqueName="colFNC_DESCRIPTION" CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                ShowFilterIcon="True" FilterDelay="1250" FilterControlWidth="75%">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn DataField="SUPPLIED_BY" HeaderText="Supplied By" UniqueName="colSUPPLIED_BY" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="65px"/>
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtSUPPLIED_BY" runat="server" SkinID="TextBoxStandard"
                                        MaxLength="6" Text='<%#Eval("SUPPLIED_BY") %>' Width="70px"></asp:TextBox>
                                    <asp:HiddenField ID="HfFunctionType" runat="server" Value='<%#Eval("FNC_TYPE") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="" HeaderText="" UniqueName="colSUPPLIED_BY_LOOKUP" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="bottom"  />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle"  />
                                <FooterStyle HorizontalAlign="left" VerticalAlign="middle"  />
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgBtnSuppliedBy" runat="server" SkinID="ImageButtonFind"
                                        AlternateText="Lookup supplied by" ToolTip="Lookup supplied by" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="HRS_QTY" HeaderText="Qty/Hrs" UniqueName="colHRS_QTY" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtHRS_QTY" runat="server" Style="text-align: right" SkinID="TextBoxStandard"
                                        MaxLength="17" Text='<%#Eval("HRS_QTY") %>' Width="80px"></asp:TextBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="NET_AMOUNT" HeaderText="Amount" UniqueName="colNET_AMOUNT" Visible="false" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtNET_AMOUNT" runat="server"  SkinID="TextBoxStandard"
                                        MaxLength="15" Text='<%#Eval("NET_AMOUNT") %>' Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="FNC_HEADING_DESC" HeaderText="Heading" UniqueName="colFNC_HEADING_DESC" CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                ShowFilterIcon="True" FilterDelay="1250" FilterControlWidth="75%">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
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
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>

</asp:Content>
