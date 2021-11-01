<%@ Page Title="Email Recipients" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="LookUp_EmailRecipients.aspx.vb" Inherits="Webvantage.LookUp_EmailRecipients" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">

            function returnValue() {
                //Get a reference to the parent (MDI) page 
                var oWnd = GetRadWindow();
                //get a reference to the second RadWindow
                var CallingWindowName = '<%= Me.OpenerRadWindowName %>';

                if (typeof oWnd.get_windowManager !== 'undefined' && !oWnd.BrowserWindow) {
                    var CallingWindow = oWnd.get_windowManager().getWindowByName(CallingWindowName);

                    if (!CallingWindow) {
                        var windows = oWnd.get_windowManager().get_windows();
                        for (var i = 0; i < windows.length; i++) {
                            var s;
                            s = windows[i].get_navigateUrl()
                            var arCurr = new Array();
                            arCurr = s.split('.');
                            s = arCurr[0];
                            if (s.indexOf("Review") > 0) {
                                CallingWindow = windows[i];
                            }
                            if (s == 'Alert_New') {
                                CallingWindow = windows[i];
                            }
                        }
                    }
                    if (CallingWindow) {
                        //alert(CallingWindow)
                        // Get a reference to the first RadWindow's content
                        var CallingWindowContent = CallingWindow.get_contentFrame().contentWindow;
                        //Call the predefined function in Dialog1                
                    <%= Me.ControlsToSet %>
                        //Close the second RadWindow
                        oWnd.close();
                    }
                }
                else {
                    //var CallingWindow = ;
                    var CallingWindowContent = { document: oWnd.Parent.document };

                    <%= Me.ControlsToSet %>

                    oWnd.Close();
                }
            }

            function cancelClick() {
                try {
                    //CloseThisWindow();
                } catch (e) {
                    console.log(e);
                }
                try {
                    var oWnd = GetRadWindow();
                    if (oWnd) {
                        oWnd.close();
                    }
                } catch (e) {
                    console.log(e);
                }
            }

            function setLookupReturnData(data) {
                var obj = JSON.parse(data);
                for (var prop in obj) {
                    if (prop === 'ClientCode' || prop === 'EmployeeCode' || prop === 'VendorCode') {
                        $('#<%= txtCode.ClientID%>').val(obj[prop]);
                    }
                    if (prop === 'ClientName' || prop === 'EmployeeName' || prop === 'VendorName') {
                        $('#<%= txtName.ClientID%>').val(obj[prop]);
                    }
                    if (prop === 'DivisionCode') {
                        $('#<%= txtCodeDiv.ClientID%>').val(obj[prop]);
                    }
                    if (prop === 'DivisionName') {
                        $('#<%= txtNameDiv.ClientID%>').val(obj[prop]);
                    }
                    if (prop === 'ProductCode') {
                        $('#<%= txtCodePrd.ClientID%>').val(obj[prop]);
                    }
                    if (prop === 'ProductName') {
                        $('#<%= txtNamePrd.ClientID%>').val(obj[prop]);
                    }
                }
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <div style="margin: 10px 0px 0px 0px;">
            <div class="form-layout">
                <ul>
                    <li>Recipient Type:</li>
                    <li>
                        <telerik:RadComboBox ID="ddFilter" runat="server" AutoPostBack="true" SkinID="RadComboBoxText25">
                        </telerik:RadComboBox>
                    </li>
                </ul>
                <ul>
                    <li><span>
                        <asp:HyperLink ID="hlLookup" runat="server" Text="Employee:" href=""></asp:HyperLink></span></li>
                    <li>
                        <asp:TextBox ID="txtCode" runat="server" SkinID="TextBoxCodeSmall" AutoPostBack="true" OnTextChanged="txtCode_TextChanged"></asp:TextBox></li>
                    <li>
                        <asp:TextBox ID="txtName" runat="server" Width="248px" ReadOnly="true" SkinID="TextBoxStandard"></asp:TextBox></li>
                </ul>
                <ul id="secondLevelLookup" runat="server" visible="false">
                    <li><span>
                        <asp:HyperLink ID="hlDivision" runat="server" Text="Division:" href=""></asp:HyperLink></span></li>
                    <li>
                        <asp:TextBox ID="txtCodeDiv" runat="server" SkinID="TextBoxCodeSmall" AutoPostBack="true" OnTextChanged="txtCodeDiv_TextChanged"></asp:TextBox></li>
                    <li>
                        <asp:TextBox ID="txtNameDiv" runat="server" Width="248px" ReadOnly="true" SkinID="TextBoxStandard"></asp:TextBox></li>
                </ul>
                <ul id="thirdLevelLookup" runat="server" visible="false">
                    <li><span>
                        <asp:HyperLink ID="hlProduct" runat="server" Text="Product:" href=""></asp:HyperLink></span></li>
                    <li>
                        <asp:TextBox ID="txtCodePrd" runat="server" SkinID="TextBoxCodeSmall" AutoPostBack="true" OnTextChanged="txtCodePrd_TextChanged"></asp:TextBox></li>
                    <li>
                        <asp:TextBox ID="txtNamePrd" runat="server" Width="248px" ReadOnly="true" SkinID="TextBoxStandard"></asp:TextBox></li>
                </ul>
                <ul>
                    <li>&nbsp;</li>
                    <li>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" /></li>
                    <li>
                        <asp:Button ID="btnClear" runat="server" Text="Clear" /></li>
                </ul>
            </div>
            <div>
                <div class="grid-container">
                    <div id="GridArea" class="grid-col-1-2">
                        <telerik:RadGrid ID="radGridEmpRecipients" runat="server" AllowPaging="True" AllowSorting="True"
                            AllowMultiRowSelection="true" AutoGenerateColumns="False" GridLines="none"
                            ClientSettings-EnableClientKeyValues="true" GroupingSettings-GroupByFieldsSeparator="  " PageSize="10"
                            Height="400">
                            <ClientSettings>
                                <Selecting AllowRowSelect="true" />
                            </ClientSettings>
                            <PagerStyle Mode="NextPrevAndNumeric" NextPageText="&amp;gt;" PrevPageText="&amp;lt;" />
                            <MasterTableView HorizontalAlign="Left" DataKeyNames="CODE,FML,EMAIL">
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Emp Code">
                                        <ItemStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblCode" runat="server" Text='<%#Eval("CODE").ToString%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Name">
                                        <ItemStyle Width="200px" />
                                        <HeaderStyle Width="200px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("FML").ToString%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Address">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("EMAIL").ToString%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <FilterItemStyle VerticalAlign="Top" Wrap="False" />
                                <ExpandCollapseColumn Visible="False">
                                    <HeaderStyle Width="19px" />
                                </ExpandCollapseColumn>
                                <PagerStyle Mode="NextPrevAndNumeric" />
                                <RowIndicatorColumn Visible="False">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                            </MasterTableView>
                            <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
                            <AlternatingItemStyle VerticalAlign="Top" />
                            <FilterItemStyle HorizontalAlign="Left" Wrap="False" />
                            <ClientSettings AllowColumnsReorder="True">
                                <Scrolling AllowScroll="true" ScrollHeight="100%" />
                            </ClientSettings>
                            <GroupingSettings GroupByFieldsSeparator=" " />
                        </telerik:RadGrid>
                        <telerik:RadGrid ID="radGridClientRecipients" runat="server" AllowPaging="True" AllowSorting="True"
                            AllowMultiRowSelection="true" AutoGenerateColumns="False" GridLines="None"
                            ClientSettings-EnableClientKeyValues="true" GroupingSettings-GroupByFieldsSeparator="  "
                            Height="400" PageSize="10">
                            <PagerStyle Mode="NextPrevAndNumeric" NextPageText="&amp;gt;" PrevPageText="&amp;lt;" />
                            <ClientSettings>
                                <Selecting AllowRowSelect="true" />
                            </ClientSettings>
                            <MasterTableView HorizontalAlign="Left" DataKeyNames="CL_CODE,CONT_CODE,FML,EMAIL">
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Client Code">
                                        <ItemStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblClientCode" runat="server" Text='<%#Eval("CL_CODE").ToString%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Cont Code">
                                        <ItemStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblContactCode" runat="server" Text='<%#Eval("CONT_CODE").ToString%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Name">
                                        <ItemStyle Width="200px" />
                                        <HeaderStyle Width="200px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("FML").ToString%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Address">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("EMAIL").ToString%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <FilterItemStyle VerticalAlign="Top" Wrap="False" />
                                <ExpandCollapseColumn Visible="False">
                                    <HeaderStyle Width="19px" />
                                </ExpandCollapseColumn>
                                <PagerStyle Mode="NextPrevAndNumeric" />
                                <RowIndicatorColumn Visible="False">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                            </MasterTableView>
                            <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
                            <AlternatingItemStyle VerticalAlign="Top" />
                            <FilterItemStyle HorizontalAlign="Left" Wrap="False" />
                            <ClientSettings AllowColumnsReorder="True">
                                <Scrolling AllowScroll="True" ScrollHeight="100%" />
                            </ClientSettings>
                            <GroupingSettings GroupByFieldsSeparator=" " />
                        </telerik:RadGrid>
                        <telerik:RadGrid ID="radGridProductRecipients" runat="server" AllowPaging="True"
                            AllowSorting="True" AllowMultiRowSelection="true" AutoGenerateColumns="False"
                            Height="400" GridLines="None" ClientSettings-EnableClientKeyValues="true" GroupingSettings-GroupByFieldsSeparator="  " PageSize="10">
                            <PagerStyle Mode="NextPrevAndNumeric" NextPageText="&amp;gt;" PrevPageText="&amp;lt;" />
                            <ClientSettings>
                                <Selecting AllowRowSelect="true" />
                            </ClientSettings>
                            <MasterTableView HorizontalAlign="Left" DataKeyNames="CL_CODE,DIV_CODE,PRD_CODE,CONT_CODE,FML,EMAIL">
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Client Code">
                                        <ItemStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblClientCode" runat="server" Text='<%#Eval("CL_CODE").ToString%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Div Code">
                                        <ItemStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblDivisionCode" runat="server" Text='<%#Eval("DIV_CODE").ToString%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Prod Code">
                                        <ItemStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblProductCode" runat="server" Text='<%#Eval("PRD_CODE").ToString%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Cont Code">
                                        <ItemStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblContactCode" runat="server" Text='<%#Eval("CONT_CODE").ToString%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Name">
                                        <ItemStyle Width="200px" />
                                        <HeaderStyle Width="200px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("FML").ToString%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Address">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("EMAIL").ToString%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <FilterItemStyle VerticalAlign="Top" Wrap="False" />
                                <ExpandCollapseColumn Visible="False">
                                    <HeaderStyle Width="19px" />
                                </ExpandCollapseColumn>
                                <PagerStyle Mode="NextPrevAndNumeric" />
                                <RowIndicatorColumn Visible="False">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                            </MasterTableView>
                            <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
                            <AlternatingItemStyle VerticalAlign="Top" />
                            <FilterItemStyle HorizontalAlign="Left" Wrap="False" />
                            <ClientSettings AllowColumnsReorder="True">
                                <Scrolling AllowScroll="True" ScrollHeight="100%" />
                            </ClientSettings>
                            <GroupingSettings GroupByFieldsSeparator=" " />
                        </telerik:RadGrid>
                        <telerik:RadGrid ID="radGridVendorContacts" runat="server" AllowPaging="True" AllowSorting="True"
                            AllowMultiRowSelection="true" AutoGenerateColumns="False" GridLines="None"
                            ClientSettings-EnableClientKeyValues="true" GroupingSettings-GroupByFieldsSeparator="  "
                            Height="400" PageSize="10">
                            <PagerStyle Mode="NextPrevAndNumeric" NextPageText="&amp;gt;" PrevPageText="&amp;lt;" />
                            <ClientSettings>
                                <Selecting AllowRowSelect="true" />
                            </ClientSettings>
                            <MasterTableView HorizontalAlign="Left" DataKeyNames="VN_CODE,VC_CODE,FML,EMAIL">
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Vendor Code">
                                        <ItemStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendorCode" runat="server" Text='<%#Eval("VN_CODE").ToString%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Cont Code">
                                        <ItemStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblContactCode" runat="server" Text='<%#Eval("VC_CODE").ToString%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Name">
                                        <ItemStyle Width="200px" />
                                        <HeaderStyle Width="200px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("FML").ToString%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Address">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("EMAIL").ToString%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <FilterItemStyle VerticalAlign="Top" Wrap="False" />
                                <ExpandCollapseColumn Visible="False">
                                    <HeaderStyle Width="19px" />
                                </ExpandCollapseColumn>
                                <PagerStyle Mode="NextPrevAndNumeric" />
                                <RowIndicatorColumn Visible="False">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                            </MasterTableView>
                            <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
                            <AlternatingItemStyle VerticalAlign="Top" />
                            <FilterItemStyle HorizontalAlign="Left" Wrap="False" />
                            <ClientSettings AllowColumnsReorder="True">
                                <Scrolling AllowScroll="True" ScrollHeight="100%" />
                            </ClientSettings>
                            <GroupingSettings GroupByFieldsSeparator=" " />
                        </telerik:RadGrid>
                        <telerik:RadGrid ID="radGridVendorReps" runat="server" AllowPaging="True" AllowSorting="True"
                            AllowMultiRowSelection="true" AutoGenerateColumns="False" GridLines="None"
                            ClientSettings-EnableClientKeyValues="true" GroupingSettings-GroupByFieldsSeparator="  "
                            Height="400" PageSize="10">
                            <PagerStyle Mode="NextPrevAndNumeric" NextPageText="&amp;gt;" PrevPageText="&amp;lt;" />
                            <ClientSettings>
                                <Selecting AllowRowSelect="true" />
                            </ClientSettings>
                            <MasterTableView HorizontalAlign="Left" DataKeyNames="VN_CODE,VR_CODE,FML,EMAIL">
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Vendor Code">
                                        <ItemStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblVendorCode" runat="server" Text='<%#Eval("VN_CODE").ToString%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Rep Code">
                                        <ItemStyle Width="100px" />
                                        <HeaderStyle Width="100px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblContactCode" runat="server" Text='<%#Eval("VR_CODE").ToString%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Name">
                                        <ItemStyle Width="200px" />
                                        <HeaderStyle Width="200px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("FML").ToString%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Address">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("EMAIL").ToString%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <FilterItemStyle VerticalAlign="Top" Wrap="False" />
                                <ExpandCollapseColumn Visible="False">
                                    <HeaderStyle Width="19px" />
                                </ExpandCollapseColumn>
                                <PagerStyle Mode="NextPrevAndNumeric" />
                                <RowIndicatorColumn Visible="False">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                            </MasterTableView>
                            <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
                            <AlternatingItemStyle VerticalAlign="Top" />
                            <FilterItemStyle HorizontalAlign="Left" Wrap="False" />
                            <ClientSettings AllowColumnsReorder="True">
                                <Scrolling AllowScroll="True" ScrollHeight="100%" />
                            </ClientSettings>
                            <GroupingSettings GroupByFieldsSeparator=" " />
                        </telerik:RadGrid>
                        <asp:CheckBox ID="cbSelectAll" runat="server" Text="Select All" AutoPostBack="true" />
                        <asp:CheckBox ID="cbInclude" runat="server" Text="Include Individuals without e-mail addresses" AutoPostBack="true" />
                    </div>
                    <div class="grid-col-1-2">
                        <div>
                            <div style="float: left; margin-right: 10px;">
                                <asp:Button ID="btnTo" runat="server" Text="To:" /><br />
                                <br />
                                <asp:Button ID="btnRemoveTo" runat="server" Text="Remove" />
                            </div>
                            <div style="float: left;">
                                <telerik:RadListBox ID="RadListBoxTo" runat="server" Width="300" Height="100" SelectionMode="Multiple">
                                </telerik:RadListBox>
                                <input id="txtToContacts" runat="server" name="txtDivision" type="hidden" />
                            </div>
                        </div>
                        <div id="DivCC" runat="server" style="clear: both; padding-top: 5px;">
                            <div style="float: left; margin-right: 10px;">
                                <asp:Button ID="btnCc" runat="server" Text="Cc:" /><br />
                                <br />
                                <asp:Button ID="btnRemoveCc" runat="server" Text="Remove" />
                            </div>
                            <div style="float: left;">
                                <telerik:RadListBox ID="lbCc" runat="server" Width="300" Height="100" SelectionMode="Multiple">
                                </telerik:RadListBox>
                                <input id="txtCcContacts" runat="server" name="txtOffice" type="hidden" />
                            </div>
                        </div>
                        <div id="DivBCC" runat="server" style="clear: both; padding-top: 5px;">
                            <div style="float: left; margin-right: 10px;">
                                <asp:Button ID="btnBcc" runat="server" Text="Bcc:" /><br />
                                <br />
                                <asp:Button ID="btnRemoveBcc" runat="server" Text="Remove" />
                            </div>
                            <div style="float: left;">
                                <telerik:RadListBox ID="lbBcc" runat="server" Width="300" Height="100" SelectionMode="Multiple">
                                </telerik:RadListBox>
                                <input id="txtBccContacts" runat="server" name="txtClient" type="hidden" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    <div class="centered">
        <asp:Button ID="btnOk" runat="server" Text="Ok" />&nbsp;&nbsp;
        <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" OnClientClick="cancelClick();"/>
    </div>
</asp:Content>
