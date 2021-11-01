<%@ Page Title="Copy Project Schedule" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="TrafficSchedule_CopyFrom.aspx.vb" Inherits="Webvantage.TrafficSchedule_CopyFrom" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
<style>
    label {
        margin-right: 40px !important;
    }
</style>
    <div class="code-description-container">
        <div class="code-description-label">
            <asp:HyperLink ID="HlClient" runat="server" href="">Client:</asp:HyperLink>
        </div>
        <div class="code-description-code">
            <asp:TextBox ID="TxtClientCode" runat="server" MaxLength="6"
                TabIndex="1" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
        </div>
        <div class="code-description-description">
            <asp:TextBox ID="TxtClientDescription" runat="server" ReadOnly="true"
                TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
        </div>
    </div>
    <div class="code-description-container">
        <div class="code-description-label">
            <asp:HyperLink ID="HlDivision" runat="server" href="">Division:</asp:HyperLink>
        </div>
        <div class="code-description-code">
            <asp:TextBox ID="TxtDivisionCode" runat="server" MaxLength="6"
                TabIndex="1" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
        </div>
        <div class="code-description-description">
            <asp:TextBox ID="TxtDivisionDescription" runat="server" ReadOnly="true"
                TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
        </div>
    </div>
    <div class="code-description-container">
        <div class="code-description-label">
            <asp:HyperLink ID="HlProduct" runat="server" href="">Product:</asp:HyperLink>
        </div>
        <div class="code-description-code">
            <asp:TextBox ID="TxtProductCode" runat="server" MaxLength="6"
                TabIndex="2" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
        </div>
        <div class="code-description-description">
            <asp:TextBox ID="TxtProductDescription" runat="server" ReadOnly="true"
                TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
        </div>
    </div>
    <div class="code-description-container">
        <div class="code-description-label">
            <asp:HyperLink ID="HlJob" runat="server" href="">Job:</asp:HyperLink>
        </div>
        <div class="code-description-code">
            <asp:TextBox ID="TxtJobNum" runat="server" CssClass="RequiredInput"
                MaxLength="6" TabIndex="3" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
        </div>
        <div class="code-description-description">
            <asp:TextBox ID="TxtJobDescription" runat="server" ReadOnly="true"
                TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
        </div>
    </div>
    <div class="code-description-container">
        <div class="code-description-label">
            <asp:HyperLink ID="HlComponent" runat="server" href="">Component:</asp:HyperLink>
        </div>
        <div class="code-description-code">
            <asp:TextBox ID="TxtJobCompNum" runat="server" CssClass="RequiredInput"
                MaxLength="6" TabIndex="4" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
        </div>
        <div class="code-description-description">
            <asp:TextBox ID="TxtJobCompDescription" runat="server" ReadOnly="true"
                TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
        </div>
    </div>
    <div class="code-description-container">
        <div class="code-description-label">
            <asp:HyperLink ID="HlJobType" runat="server" href="">Job Type:</asp:HyperLink>
        </div>
        <div class="code-description-code">
            <asp:TextBox ID="TxtJobType" runat="server" MaxLength="10"
                TabIndex="4" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
        </div>
        <div class="code-description-description">
            <asp:TextBox ID="TxtJobTypeDescription" runat="server" ReadOnly="true"
                TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
        </div>
    </div>
    <div class="code-description-container">
        <div class="code-description-label">
        </div>
        <div class="code-description-description">
            <asp:CheckBoxList ID="CheckBoxListCopyOptions" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
            </asp:CheckBoxList>
        </div>
    </div>
    <div class="bottom-buttons">
        <asp:Button ID="BtnRefresh" runat="server" Text="Refresh" />
        &nbsp;&nbsp;
        <asp:Button ID="BtnCopy" runat="server" Text="Copy" />
    </div>
    <telerik:RadGrid ID="RadGridCopyFromSchedules" runat="server" AllowMultiRowSelection="True"
        AllowSorting="False" AutoGenerateColumns="False" EnableAJAX="False" GridLines="None"
        Width="98%">
        <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
        <ClientSettings EnablePostBackOnRowClick="False">
            <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
        </ClientSettings>
        <MasterTableView DataKeyNames="ROWID">
            <Columns>
                <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                    <HeaderStyle HorizontalAlign="center" />
                    <ItemStyle HorizontalAlign="center" />
                </telerik:GridClientSelectColumn>
                <telerik:GridBoundColumn DataField="LEVEL" HeaderText="Level" UniqueName="colLEVEL">
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PHASE_DESC" HeaderText="Phase" UniqueName="colPHASE_DESC">
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TASK_CODE" HeaderText="Task Code" UniqueName="colFNC_CODE">
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TASK_DESCRIPTION" HeaderText="Task Description" UniqueName="colTRF_DESC">
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn DataField="TRF_PRESET_ORDER" HeaderText="Order" UniqueName="colTRF_PRESET_ORDER">
                    <HeaderStyle HorizontalAlign="center" />
                    <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                    <ItemTemplate>
                        <asp:TextBox ID="TxtJOB_ORDER" runat="server" MaxLength="3" SkinID="TextBoxStandard"
                            Text='<%#Eval("JOB_ORDER") %>' Width="30px"></asp:TextBox>
                        <asp:HiddenField ID="HFPhaseID" runat="server" Value='<%#Eval("TRAFFIC_PHASE_ID") %>' />
                        <asp:HiddenField ID="HFRoleCode" runat="server" Value='<%#Eval("TRF_ROLE") %>' />
                        <asp:HiddenField ID="HFSeqNum" runat="server" Value='<%#Eval("SEQ_NBR") %>' />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="TRF_PRESET_DAYS" HeaderText="Days" UniqueName="colTRF_PRESET_DAYS">
                    <HeaderStyle HorizontalAlign="center" />
                    <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                    <ItemTemplate>
                        <asp:TextBox ID="TxtJOB_DAYS" runat="server" MaxLength="3" SkinID="TextBoxStandard"
                            Text='<%#Eval("JOB_DAYS") %>' Width="30px"></asp:TextBox>
                        <asp:HiddenField ID="HFStartDate" runat="server" Value='<%#Eval("TASK_START_DATE") %>' />
                        <asp:HiddenField ID="HFRevisedDueDate" runat="server" Value='<%#Eval("JOB_REVISED_DATE") %>' />
                        <asp:HiddenField ID="HFJobDueDate" runat="server" Value='<%#Eval("JOB_DUE_DATE") %>' />
                        <asp:HiddenField ID="HFTimeDue" runat="server" Value='<%#Eval("REVISED_DUE_TIME") %>' />
                        <asp:HiddenField ID="HFDateCompleted" runat="server" Value='<%#Eval("JOB_COMPLETED_DATE") %>' />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="TRF_PRESET_HRS" HeaderText="Hours" UniqueName="colTRF_PRESET_HRS">
                    <HeaderStyle HorizontalAlign="center" />
                    <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                    <ItemTemplate>
                        <asp:TextBox ID="TxtJOB_HRS" runat="server" MaxLength="6" SkinID="TextBoxStandard"
                            Text='<%#Eval("JOB_HRS") %>' Width="50px"></asp:TextBox>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="MILESTONE" HeaderText="M/S" UniqueName="colMILESTONE">
                    <HeaderStyle HorizontalAlign="center" />
                    <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                    <ItemTemplate>
                        <asp:CheckBox ID="ChkMILESTONE" runat="server" />
                        <asp:HiddenField ID="HfSEQ_NBR" runat="server" Value='<%#Eval("SEQ_NBR") %>' />
                        <asp:HiddenField ID="HfEstimateFunction" runat="server" Value='<%#Eval("FNC_EST") %>' />
                        <asp:HiddenField ID="HfDEFAULT_EMP" runat="server" Value='<%#Eval("EMP_CODE") %>' />
                        <asp:HiddenField ID="HFTaskStatus" runat="server" Value='<%#Eval("TASK_STATUS") %>' />
                        <asp:HiddenField ID="HFFunctionComments" runat="server" Value='<%#Eval("FNC_COMMENTS") %>' />
                        <asp:HiddenField ID="HFDueDateComments" runat="server" Value='<%#Eval("DUE_DATE_COMMENTS") %>' />
                        <asp:HiddenField ID="HFRevDateComments" runat="server" Value='<%#Eval("REV_DATE_COMMENTS") %>' />
                        <asp:HiddenField ID="HiddenFieldParentTaskSeq" runat="server" Value='<%#Eval("PARENT_TASK_SEQ")%>' />
                        <asp:HiddenField ID="HiddenFieldGridOrder" runat="server" Value='<%#Eval("GRID_ORDER")%>' />
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
</asp:Content>
