@ModelType Webvantage.Controllers.Account.ActionsViewViewModel

@Code Layout = "~/Views/Shared/_LayoutPageBase.vbhtml" End Code

<style>
    .action-list {
    }
    .action-item {
        margin: 0px 0px 8px 0px;
    }
    #settings-container1 {
        background: white;
        border: 1px solid #ccc;
        border-radius: 6px;
        margin: 15px auto 15px auto;
        min-height: 500px !important;
        box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05);
        padding: 0px !important;
    }
    #settings-container1 .control-label {
        margin: 10px 10px 10px 0;
    }
    #settings-container1 #profile-preview {
        max-width: 275px;
        margin-top: 11px;
    }
    #settings-container1 #profile-preview #nav-feature {
        height: 100px;
        border-top-left-radius: 6px;
        border-top-right-radius: 6px;
    }
    #settings-container1 #profile-preview dd {
        font-size: 18px;
    }
    #settings-container1 #nav-menu-content-wrap {
        padding-top: 70px;
        background: #dbdbdb;
        border-bottom-left-radius: 6px;
        border-bottom-right-radius: 6px;
    }
    #settings-container1 #nav-feature #nav-feature-user {
        left: 86.5px;
    }
    #settings-container1 #nav-feature .nav-feature-button {
        position: absolute;
        left: 34.25px;
        top: 92px;
    }
    #settings-container1 h4 {
        border-bottom: 0;
        margin: 10px 0;
    }
    #settings-container1 .settings-section {
        margin: 14px 0;
        padding-left: 10px;
        padding-right: 10px;
        padding-bottom: 10px;
    }
    #settings-container1 .settings-section h5 {
        margin: 10px 0;
    }
    #settings-container1 .settings-section h5 span {
        line-height: 16px;
        padding: 2px;
    }
    #settings-container1 .settings-section ul li {
        margin: 8px 0;
    }
    #settings-container1 .advanced-search {
        background: #ffffff;
        border-radius: 6px;
        border: #ccc solid 1px;
        margin-top: 10px;
        padding: 10px 5px;
        max-width: 850px;
    }
    #settings-container1 .k-multiselect {
        max-width: 350px;
    }
    #settings-container1 .settings-section {
        background: #f6f6f6;
        border: 1px #ccc solid;
        border-radius: 4px;
    }
    #settings-container1 #profile-preview {
        box-shadow: inset 0 2px 0 rgba(255, 255, 255, 0.2), 0 5px 6px rgba(0, 0, 0, 0.05);
        margin-top: 13px;
    }
</style>
<span id="popupNotification"></span>
<div style="margin: 10px 0 0 0;">
    <div class="alert alert-warning" role="alert" style="">
        <strong><span>You are here because you signed in with a user that is a SQL Server server administrator (role: serveradmin/advan_admin)</span></strong>
    </div>
    <div id="TopToolBar" class="wv-bar k-toolbar k-widget k-toolbar-resizable"
         style="width: 100%;background-color: #E5E5E5;padding: 8px 0px 8px 0px;border-bottom: 1px solid #CCC;box-shadow: inset 0 1px 0 rgba(255,255,255,.2), 0 1px 2px rgba(0,0,0,.05);margin: 5px auto; overflow: hidden; height: 34px !important;">
        <ul class="list-inline" style="margin-bottom: 0; padding-left: 8px;">
            <li id="lockAllListItem" style="padding:0">
                <button class="k-button wv-icon-button wv-neutral " onclick="lockAllClick()" style="width: 80px !important;" title="Lock all users"><span style="font-size: 12px;">Lock All</span></button>
            </li>
            <li id="unLockAllListItem" style="padding:0">
                <button class="k-button wv-icon-button wv-neutral " onclick="unLockAllClick()" style="width: 80px !important;" title="Unlock all users"><span style="font-size: 12px;">Unlock All</span></button>
            </li>
            <li id="clearAllListItem" style="padding:0">
                <button class="k-button wv-icon-button wv-neutral " onclick="clearAllClick()" style="width: 135px !important;" title="Clear passwords for all users"><span style="font-size: 12px;">Clear All Passwords</span></button>
            </li>
        </ul>
    </div>


    @Code If String.IsNullOrWhiteSpace(Model.ErrorMessage) = False Then
@<div>
    <div id="errorMessage" class="alert alert-warning" role="alert"
         style="display:block; margin-bottom: 0 !important; position: relative; margin-top: 15px;">
        <strong>Warning</strong><span style="margin: 0;">@Html.Raw(Model.ErrorMessage)</span>
    </div>
</div> End If
        If Model.ShowSeedForm = False Then
            Dim GridBuilder = Html.EJ().Grid(Of AdvantageFramework.Security.Classes.PasswordUser)("Grid")
            Dim WrapSettings As New Syncfusion.JavaScript.Models.TextWrapSettings

            WrapSettings.WrapMode = WrapMode.Both

            GridBuilder.Datasource(Model.PasswordUsers)
            GridBuilder.Columns(Sub(Column)
                                    Column.Field("UserCode").HeaderText("User ID").Width(90).AllowGrouping(False).AllowFiltering(True).Add()
                                    Column.Field("EmployeeCode").HeaderText("Employee Code").Width(90).AllowGrouping(False).AllowFiltering(True).Add()
                                    Column.Field("FullName").HeaderText("Employee").Template("#tmpltEmployee").Width(275).AllowGrouping(False).AllowFiltering(True).Add()
                                    Column.Field("Password").HeaderText("Password").Template("#tmpltPassword").AllowGrouping(False).AllowFiltering(False).Add()
                                    Column.HeaderText("Actions").Template("#tmpltActions").AllowGrouping(False).AllowFiltering(False).Width(150).Add()
                                End Sub)
            GridBuilder.AllowMultiSorting(False)
            GridBuilder.AllowSelection(False)
            GridBuilder.AllowSorting(False)
            GridBuilder.AllowTextWrap(True)
            GridBuilder.AllowGrouping(False)
            GridBuilder.AllowFiltering(True)
            GridBuilder.GroupSettings(Sub(settings)
                                          settings.ShowDropArea(False)
                                          settings.ShowToggleButton(False)
                                      End Sub)
            GridBuilder.EnableToolbarItems(False)
            GridBuilder.ClientSideEvents(Sub(Events)
                                             'Events.ActionBegin("gridActionBegin")
                                             'Events.QueryCellInfo("gridQueryCellInfo")
                                         End Sub)
            GridBuilder.Render()
@<div style="height: 10px;"></div>

                @<div id="gridButtonContainer" style="float: right; display: none; padding-right: 0px; margin-bottom: 10px;">
                    <div id="gridButtonsContainer" Class="k-button-group">
                        <button id="gridDone" class="k-button k-primary" title="Return to Sign In" onclick="newUserCancelClick()">Return to Sign In</button>
                    </div>
                </div> Else
@<div style="">
    <div>
    </div>
    <div id="settings-container1">
        <div style="margin: 12px 0px 0px 8px;">There are no users.  Please create one.</div>
        <div class="col-md-12">
            <div class="settings-section">
                <h5>User</h5>
                <div class="wv-form-group">
                    <label>Code:</label>
                    <input type="text" id="userCodeTextbox" class="e-textbox" maxlength="100" />
                </div>
            </div>
            <div class="settings-section">
                <h5>Department</h5>
                @Code If Model.Departments IsNot Nothing AndAlso Model.Departments.Count > 0 Then

    @<div id="departmentDropDownContainer">

        @Html.EJ().DropDownList("Departments").Width("100%").Datasource(Model.Departments).DropDownListFields(Function(F)
                                                                                                                       Return F.Value("Code").Text("Name")
                                                                                                                   End Function).Enabled(True)

    </div> Else

@<div id="departmentInputContainer">
    <div class="wv-form-group">
        <label>Code:</label>
        <input type="text" id="departmentCodeTextbox" class="e-textbox" maxlength="6" />
    </div>
    <div Class="wv-form-group">
        <Label> Description :    </Label>
        <input type="text" id="departmentDescriptionTextbox" Class="e-textbox" maxlength="30" />
    </div>
</div> End If End Code

            </div>
            <div Class="settings-section">
                <h5> Employee</h5>
                @Code If Model.Employees IsNot Nothing AndAlso Model.Employees.Count > 0 Then

    @<div id="employeeDropDownContainer">
        @Html.EJ().DropDownList("Employees").Width("100%").Datasource(Model.Employees).DropDownListFields(Function(F)
                                                                                                                   Return F.Value("Code").Text("Name")
                                                                                                               End Function).Enabled(True)
    </div> Else

@<div id="employeeInputContainer">
    <div class="wv-form-group">
        <label>Code:</label>
        <input type="text" id="employeeCodeTextbox" class="e-textbox" maxlength="6" />
    </div>
    <div Class="wv-form-group">
        <Label> First:</Label>
        <input type="text" id="employeeFirstNameTextbox" Class="e-textbox" maxlength="30" />
    </div>
    <div Class="wv-form-group">
        <Label> MI:</Label>
        <input type="text" id="employeeMiddleInitialTextbox" Class="e-textbox" maxlength="1" />
    </div>
    <div Class="wv-form-group">
        <Label> Last:</Label>
        <input type="text" id="employeeLastNameTextbox" Class="e-textbox" maxlength="30" />
    </div>
</div> End If End Code
            </div>
        </div>
    </div>
    <div style="">
        <div id="buttonContainer" style="float: right; display: block; padding-right: 0px;">
            <div id="buttonsContainer" class="k-button-group">
                <button id="newUserCancel" class="k-button" title="Cancel" onclick="newUserCancelClick()">Cancel</button>
                <button id="newUserSave" class="k-button k-primary" title="Save" onclick="newUserSaveClick()">Save</button>
            </div>
            <div id="buttonWaitContainer" class="k-button-group" style="display: none;">
                <img src="~/CSS/Material/PleaseWait/spinner.gif" />
            </div>
        </div>
        <br />
        <br />
        <br />
    </div>
</div> End If End Code
</div>
<div id="scriptTemplates" style="display: none;">
    <script id="tmpltActions" type="text/template">
        <div id="actionContainer_{{:ID}}" style="width: 100%; vertical-align:top !important;">
            <div style="vertical-align: top !important;">
                <ul class="action-list" style="">
                    <li class="action-item"><a href="#" onclick="saveClick(this); return false;" title="Save the password you set for this user." data-bind="{{:ID}}">Save</a></li>
                    <li class="action-item"><a href="#" onclick="clearClick(this); return false;" title="Clear user password.  User will have to set new next sign on." data-bind="{{:ID}}">Clear</a></li>
                    <li id="unLockListItem_{{:ID}}" class="action-item" style="{{if IsLocked == false}}display:none;{{/if}}"><span data-bind="{{:ID}}" onclick="unLockClick(this); return false;" class="wvi wvi-lock1" style="cursor: pointer; color: #E53E3E;" title="Currently locked.  Click to unlock!"></span></li>
                    <li id="lockListItem_{{:ID}}" class="action-item" style="{{if IsLocked == true}}display:none;{{/if}}"><span data-bind="{{:ID}}" onclick="lockClick(this); return false;" class="wvi wvi-lock_open" style="cursor: pointer; color: #5CB85C;" title="Currently unlocked.  Click to lock!"></span></li>
                </ul>
            </div>
            <div style="">
                <span id="msg_{{:ID}}"></span>
            </div>
        </div>
    </script>
    <script id="tmpltPassword" type="text/template">
        <div class="form-group" style="width:100%;">
            <div>
                New Password
            </div>
            <div>
                <input id="txtPwd_{{:ID}}"
                       value="{{:Password}}"
                       onblur=""
                       onfocus="this.select()"
                       class="e-textbox"
                       type="password"
                       style="width: 300px;" />
            </div>
        </div>
        <div class="form-group" style="width:100%;">
            <div>
                Confirm
            </div>
            <div>
                <input id="txtPwd2_{{:ID}}"
                       value="{{:Password}}"
                       onblur=""
                       onfocus="this.select()"
                       class="e-textbox"
                       type="password"
                       style="width: 300px;" />
            </div>
        </div>
    </script>
    <script id="tmpltEmployee" type="text/template">
        <div title="{{:FullName}}">
            <div style="display:inline-block;">
                {{:FullName}}
            </div>
        </div>
    </script>
</div>
<script>
    var showSeedForm = false;
    var hasDepts = false;
    var hasEmps = false;
    showSeedForm = @Html.Raw(Model.ShowSeedForm.ToString.ToLower);
    hasDepts = @Html.Raw(Model.HasDepartments.ToString.ToLower);
    hasEmps = @Html.Raw(Model.HasEmployees.ToString.ToLower);
</script>
@Scripts.Render("~/JScripts/account.gm.actions.mvc.min.js")
