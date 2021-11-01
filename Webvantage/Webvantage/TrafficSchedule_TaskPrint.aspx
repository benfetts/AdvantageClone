<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TrafficSchedule_TaskPrint.aspx.vb" EnableEventValidation="false" ValidateRequest="false"
    MasterPageFile="~/ChildPage.Master" Title="" Inherits="Webvantage.TrafficSchedule_TaskPrint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table border="0" cellpadding="0" cellspacing="2" width="100%">
        <tr>
            <td align="Left" colspan="3" style="border-bottom-style: solid">
                &nbsp;<asp:Label   ID="Label1" runat="server"  
                    Text="Task Detail Report"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle" width="27%">
                <span>Client:</span>
            </td>
            <td width="2%">
                &nbsp;
            </td>
            <td width="71%">
                <asp:Label   ID="lblClient" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <span>Division:</span>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label   ID="lblDivision" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <span>Product:</span>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label   ID="lblProduct" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <span>Job:</span>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label   ID="lblJob" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <span>Component:</span>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label   ID="lblJobComp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <span>Account Executive:</span>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label   ID="lblAE" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <span>Job Start Date:</span>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label   ID="lblJobStartDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <span>Job Due Date:</span>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label   ID="lblJobDueDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <span>Job Status:</span>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label   ID="lblJobStatus" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <span>Comments:</span>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label   ID="lblJobComments" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="2" width="810">
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span>Phase: </span>
                        </td>
                        <td width="2%">
                            &nbsp;
                        </td>
                        <td width="70%">
                            <telerik:RadComboBox ID="DropPhase" runat="server" SkinID="RadComboBoxStandard">
                            </telerik:RadComboBox>
                            <asp:TextBox runat="server" ID="txtPhase" Visible="false" ReadOnly="true" SkinID="TextBoxStandard"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle" width="28%" class="Hlink">
                            <asp:HyperLink ID="hlTaskCode" runat="server" href="">Task:</asp:HyperLink>
                            <span runat="server" id="aTask" visible="false">Task:</span>
                        </td>
                        <td width="2%">
                            &nbsp;
                        </td>
                        <td width="70%">
                            <asp:TextBox ID="TxtTaskCode" runat="server" Width="75px" MaxLength="10" AutoPostBack="True" SkinID="TextBoxStandard"></asp:TextBox>&nbsp;
                            <asp:TextBox ID="TxtTaskDescription" runat="server" Text="" Width="225px" TabIndex="-1" SkinID="TextBoxStandard"
                                MaxLength="40"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span>Task Status:</span>
                        </td>
                        <td width="2%">
                            &nbsp;
                        </td>
                        <td width="70%">
                            <telerik:RadComboBox ID="DropTaskStatus" runat="server" SkinID="RadComboBoxStandard">
                                <Items>
                                    <telerik:RadComboBoxItem Value="P" Text="Projected"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Value="A" Text="Active"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Value="H" Text="High Priority"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Value="L" Text="Low Priority"></telerik:RadComboBoxItem>
                                </Items>
                            </telerik:RadComboBox>
                            <asp:TextBox runat="server" ID="txtTaskStatus" Visible="false" ReadOnly="true" SkinID="TextBoxStandard"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span>Start Date:</span>
                        </td>
                        <td width="2%">
                            &nbsp;
                        </td>
                        <td width="70%">
                            <asp:TextBox ID="TxtStartDate" runat="server" Width="75px" MaxLength="10" SkinID="TextBoxStandard"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span>Due Date:</span>
                        </td>
                        <td width="2%">
                            &nbsp;
                        </td>
                        <td width="70%">
                            <asp:TextBox ID="TxtDueDate" runat="server" Width="75px" MaxLength="10" SkinID="TextBoxStandard"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span>Temp Complete (All):</span>
                        </td>
                        <td width="2%">
                            &nbsp;
                        </td>
                        <td width="70%">
                            <asp:TextBox ID="txtTempComplete" runat="server" Width="75px" MaxLength="10" SkinID="TextBoxStandard"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span>Time Due:</span>
                        </td>
                        <td width="2%">
                            &nbsp;
                        </td>
                        <td width="70%">
                            <asp:TextBox ID="TxtTimeDue" runat="server" Width="72px" MaxLength="10" SkinID="TextBoxStandard"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span>Completed Date:</span>
                        </td>
                        <td width="2%">
                            &nbsp;
                        </td>
                        <td width="70%">
                            <asp:TextBox ID="TxtDateCompleted" runat="server" Width="75px" MaxLength="10" SkinID="TextBoxStandard"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span>Task Comments:</span>
                        </td>
                        <td width="2%">
                            &nbsp;
                        </td>
                        <td width="70%">
                            <asp:TextBox ID="TxtTaskComments" runat="server" Height="64px" TextMode="MultiLine" SkinID="TextBoxStandard"
                                Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span>Due Date Comments:</span>
                        </td>
                        <td width="2%">
                            &nbsp;
                        </td>
                        <td width="70%">
                            <asp:TextBox ID="TxtDueDateComments" runat="server" Height="64px" TextMode="MultiLine" SkinID="TextBoxStandard"
                                Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span>Revised Due Date Comments:</span>
                        </td>
                        <td width="2%">
                            &nbsp;
                        </td>
                        <td width="70%">
                            <asp:TextBox ID="TxtRevisionDateComments" runat="server" Height="64px" TextMode="MultiLine" SkinID="TextBoxStandard"
                                Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <asp:LinkButton ID="LkBtnContacts" runat="server" Font-Size="8.5pt" Visible="false"><span>Client Contacts:</span></asp:LinkButton>
                            <span runat="server" id="aContact">Client Contacts:</span>
                        </td>
                        <td width="2%">
                            &nbsp;
                        </td>
                        <td width="70%">
                            <asp:TextBox ID="TxtClientContacts" runat="server" Height="31px" TextMode="MultiLine" SkinID="TextBoxStandard"
                                Width="342px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <table border="0" cellpadding="0" cellspacing="2" width="810">
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span>Order:</span>
                        </td>
                        <td width="2%">
                            &nbsp;
                        </td>
                        <td width="70%">
                            <asp:TextBox ID="TxtOrder" runat="server" onkeydown="return isNumberKey(event)" MaxLength="4" SkinID="TextBoxStandard"
                                TabIndex="1" Width="30px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span>Days (Duration):</span>
                        </td>
                        <td width="2%">
                            &nbsp;
                        </td>
                        <td width="70%">
                            <asp:TextBox ID="TxtDays" runat="server" onkeydown="return isNumberKey(event)" Width="30px" SkinID="TextBoxStandard"
                                MaxLength="3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span>Default Hours Allowed:</span>
                        </td>
                        <td width="2%">
                            &nbsp;
                        </td>
                        <td width="70%">
                            <asp:TextBox ID="TxtHoursAllowed" runat="server" onkeydown="return isNumberKey(event)" SkinID="TextBoxStandard"
                                Width="50px" MaxLength="6"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span>Milestone?:</span>
                        </td>
                        <td width="2%">
                            &nbsp;
                        </td>
                        <td width="70%">
                            <asp:CheckBox ID="ChkMilestone" runat="server" />
                            <asp:TextBox runat="server" ID="txtMileStone" Visible="false" ReadOnly="true" SkinID="TextBoxStandard"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span>Estimate Function:</span>
                        </td>
                        <td width="2%">
                            &nbsp;
                        </td>
                        <td width="70%">
                            <telerik:RadComboBox ID="dropEstFnc" runat="server" SkinID="RadComboBoxStandard">
                            </telerik:RadComboBox>
                            <asp:TextBox runat="server" ID="txtEstFnc" Visible="false" ReadOnly="true" SkinID="TextBoxStandard"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span>Original Due Date:</span>
                        </td>
                        <td width="2%">
                            &nbsp;
                        </td>
                        <td width="70%">
                            <asp:TextBox ID="TxtOriginalDueDate" runat="server" onkeydown="return BlockEntry(event)" SkinID="TextBoxStandard"
                                ReadOnly="True" TabIndex="-1" Width="75px" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="middle" width="28%">
                            <span>Locked?:</span>
                        </td>
                        <td width="2%">
                        </td>
                        <td width="70%">
                            <asp:CheckBox ID="ChkLocked" runat="server" />
                            <asp:TextBox runat="server" ID="txtLocked" Visible="false" ReadOnly="true" SkinID="TextBoxStandard"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <telerik:RadGrid ID="RadGridEmployees" ShowFooter="true" runat="server" AutoGenerateColumns="False"
                    CellPadding="1" CellSpacing="1" 
                    EnableAJAX="false" Width="99%">
                    <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                    <ClientSettings AllowColumnHide="True" AllowExpandCollapse="True" Selecting-AllowRowSelect="true">
                        <Scrolling AllowScroll="False" SaveScrollPosition="true"
                            UseStaticHeaders="False" />
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="ID,EMP_CODE,EMP_NAME" TableLayout="auto">
                        <Columns>
                            <telerik:GridTemplateColumn DataField="ID" Display="False" UniqueName="ID">
                                <ItemTemplate>
                                    <asp:Label   ID="lblID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="EMP_CODE" Display="False" UniqueName="EMP_CODE">
                                <ItemTemplate>
                                    <asp:Label   ID="lblEmpCode" runat="server" Text='<%#Eval("EMP_CODE") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="EMP_NAME" Display="True" HeaderText="Employee&nbsp;"
                                UniqueName="EmployeeName">
                                <ItemTemplate>
                                    <%--<asp:Label   ID="lblEmployeeName" runat="server" Width="100px" Text='<%#Eval("EMP_NAME") %>'></asp:Label>--%>
                                    <asp:TextBox ID="txtEmployeeName" runat="server" TabIndex="-1" onkeydown="return BlockEntry(event)" SkinID="TextBoxStandard"
                                        Text='<%#Eval("EMP_NAME") %>'></asp:TextBox>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label   ID="lblTotal" runat="server" Text="Totals"></asp:Label>
                                </FooterTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" Width="150px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="middle" Width="150px" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="HOURS_ALLOWED" Display="True" HeaderText="Hours<br />Allowed&nbsp;"
                                UniqueName="HoursAllowed">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHoursAllowedGrid" Width="50px" runat="server" TabIndex="-1" onkeydown="return BlockEntry(event)" SkinID="TextBoxStandard"
                                        Text='<%#Eval("HOURS_ALLOWED") %>'></asp:TextBox>
                                    <%--<asp:Label   ID="lblHoursAllowed" runat="server" Text='<%#Eval("HOURS_ALLOWED") %>'></asp:Label>--%>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label   ID="lblHoursAllowedTotal" runat="server" Text=""></asp:Label>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Bottom" BorderStyle="Solid" />
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" Width="10px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="middle" Width="10px" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Visible="true" HeaderText="Quoted<br />Hours&nbsp;" UniqueName="QuotedHours">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtQuotedHours" Width="50px" TabIndex="-1" runat="server" Text='0.00' SkinID="TextBoxStandard"
                                        onkeydown="return BlockEntry(event)"></asp:TextBox>
                                    <%-- <asp:Label   ID="lblQuotedHours" runat="server" Text='0'></asp:Label>--%>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label   runat="server" ID="lblQuotedHoursTotal" Text=""></asp:Label>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Bottom" BorderStyle="Solid" />
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" Width="10px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="middle" Width="10px" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Display="True" HeaderText="Hours<br />Posted&nbsp;" UniqueName="HoursPosted">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtHoursPosted" Width="50px" runat="server" TabIndex="-1" onkeydown="return BlockEntry(event)" SkinID="TextBoxStandard"
                                        Text='0.00'></asp:TextBox>
                                    <%-- <asp:Label   ID="lblHoursPosted" runat="server" Text='0'></asp:Label>--%>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label   runat="server" ID="lblHoursPostedTotal" Text=""></asp:Label>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Bottom" BorderStyle="Solid" />
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" Width="10px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="middle" Width="10px" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="Percent_Complete" Display="True" HeaderText="%<br />Complete&nbsp;"
                                UniqueName="PercentComplete" ItemStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPercentComplete" runat="server" Width="50px" Text='<%#Eval("Percent_Complete","{0:###}") %>' SkinID="TextBoxStandard"
                                        onKeyUp="isLessThen101(this)"></asp:TextBox>
                                    <asp:HiddenField ID="HftxtPercentComplete" runat="server" Value='<%# Eval("Percent_Complete") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" Width="10px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="middle" Width="10px" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="Temp_Comp_Date" Display="True" HeaderText="Completed&nbsp;"
                                UniqueName="Completed">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCompleted" Width="75px" runat="server" Text='<%#Eval("Temp_Comp_Date","{0:d}") %>' SkinID="TextBoxStandard"></asp:TextBox>
                                    <asp:HiddenField ID="HftxtCompleted" runat="server" Value='<%# Eval("Temp_Comp_Date") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" Width="30px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="middle" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="Completed_Comments" Display="True" HeaderText="Completed Comment"
                                UniqueName="CompletedComment">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCompletedComment" runat="server" Text='<%#Eval("Completed_Comments") %>' SkinID="TextBoxStandard"
                                        Height="35px" TextMode="MultiLine" Wrap="True" Width="100%"></asp:TextBox>
                                    <asp:HiddenField ID="HftxtCompletedComment" runat="server" Value='<%# Eval("Completed_Comments") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" />
                                <ItemStyle HorizontalAlign="Left" Height="35px" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Display="False" HeaderText="&nbsp;" UniqueName="colComments">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivShowComments" runat="server" class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonShowComments" runat="server" SkinID="ImageButtonCommentWhite" CommandArgument='<%#Eval("ID")%>' CommandName="ShowComments" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <telerik:RadGrid ID="RadGridComments" runat="server" AutoGenerateColumns="False"
                    CellPadding="1" CellSpacing="1" 
                    EnableAJAX="false" Width="99%" AllowSorting="True">
                    <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                    <ClientSettings AllowColumnHide="True" AllowExpandCollapse="True" Selecting-AllowRowSelect="true">
                        <Scrolling AllowScroll="false" SaveScrollPosition="true"
                            UseStaticHeaders="False" />
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="ID,JOB_NUMBER,JOB_COMPONENT_NBR,SEQ_NBR,EMP_CODE"
                        TableLayout="auto">
                        <Columns>
                            <telerik:GridTemplateColumn DataField="ID" Display="False" UniqueName="ID">
                                <ItemTemplate>
                                    <asp:Label   ID="Label1" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="JOB_NUMBER" Display="False" HeaderText="JOB_NUMBER"
                                UniqueName="JobNumber">
                                <ItemTemplate>
                                    <asp:Label   ID="lblJobNumber" runat="server" Text='<%#Eval("JOB_NUMBER") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="JOB_COMPONENT_NBR" Display="False" HeaderText="JOB_COMPONENT_NBR"
                                UniqueName="JobComponentNumber">
                                <ItemTemplate>
                                    <asp:Label   ID="lblJobComponentNumber" runat="server" Text='<%#Eval("JOB_COMPONENT_NBR") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="SEQ_NBR" Display="False" HeaderText="SEQ_NBR"
                                UniqueName="SEQNBR">
                                <ItemTemplate>
                                    <asp:Label   ID="lblSEQNBR" runat="server" Text='<%#Eval("SEQ_NBR") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="EMP_CODE" Display="False" UniqueName="EMP_CODE">
                                <ItemTemplate>
                                    <asp:Label   ID="Label2" runat="server" Text='<%#Eval("EMP_CODE") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="CREATE_USER" Display="True" HeaderText="Employee"
                                UniqueName="Employee" SortExpression="CREATE_USER">
                                <ItemTemplate>
                                    <asp:Label   ID="lblEmployee" runat="server" Text='<%#Eval("CREATE_USER") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" Width="100px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="top" Width="100px" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="CREATE_DATE" Display="True" HeaderText="Date"
                                UniqueName="CreateDate" SortExpression="CREATE_DATE">
                                <ItemTemplate>
                                    <asp:Label   ID="lblCreateDate" runat="server" Text='<%#Eval("CREATE_DATE","{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" Width="75px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="top" Width="75px" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="CREATE_TIME" Display="True" HeaderText="Time"
                                UniqueName="CreateTime" SortExpression="CREATE_TIME">
                                <ItemTemplate>
                                    <asp:Label   ID="lblCreateTime" runat="server" Text='<%#Eval("CREATE_TIME","{0:HH:mm tt}") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" Width="75px" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="top" Width="75px" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="COMMENT" Display="True" HeaderText="Comment"
                                UniqueName="Comment">
                                <ItemTemplate>
                                    <asp:Label   ID="lblComment" runat="server" Text='<%#Eval("COMMENT") %>' Width="100%"
                                        Height="100%"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="top" />
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="center" valign="middle">
                <br />
                <input onclick="window.print()" size="20" type="button" value="Print" />&nbsp;&nbsp;
                <input onclick="window.close()" type="button" value="Close" />
            </td>
        </tr>
    </table>
</asp:Content>
