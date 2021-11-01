Namespace WinForm.Presentation.BaseForms

    Public Class BaseSettingsForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _SettingModuleID As Integer = -1
        Protected WithEvents _ToolTipController As DevExpress.Utils.ToolTipController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Protected Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.DoubleBuffered = True

        End Sub
        Private Sub CreateDateEditControl(ByRef EditorRow As DevExpress.XtraVerticalGrid.Rows.EditorRow, ByRef Setting As AdvantageFramework.Database.Entities.Setting, ByRef SettingDatabaseType As AdvantageFramework.Database.Entities.SettingDatabaseType)

            'objects
            Dim RepositoryItemDateEdit As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit = Nothing

            RepositoryItemDateEdit = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit

            RepositoryItemDateEdit.Name = Setting.Code
            RepositoryItemDateEdit.AllowNullInput = True

            AddHandler RepositoryItemDateEdit.EditValueChanged, AddressOf RepositoryItemDateEdit_EditValueChanged

            EditorRow.Properties.RowEdit = RepositoryItemDateEdit

            If Setting.Value IsNot Nothing Then

                EditorRow.Properties.Value = Setting.Value

            End If

        End Sub
        Private Sub RepositoryItemDateEdit_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            If TypeOf sender.Tag Is DevExpress.XtraEditors.Repository.RepositoryItemDateEdit Then

                Me.ShowWaitForm("Saving...")

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, DirectCast(sender.Tag, DevExpress.XtraEditors.Repository.RepositoryItemDateEdit).Name)

                    If Setting IsNot Nothing Then

                        Setting.Value = DirectCast(sender, DevExpress.XtraEditors.DateEdit).EditValue

                        If AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting) Then


                        End If

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub CreateComboBoxControl(ByRef EditorRow As DevExpress.XtraVerticalGrid.Rows.EditorRow, DbContext As AdvantageFramework.Database.DbContext,
                                          Setting As AdvantageFramework.Database.Entities.Setting, ByRef SettingValuesList As Generic.List(Of AdvantageFramework.Database.Entities.SettingValue))

            'objects
            Dim RepositoryItemComboBox As DevExpress.XtraEditors.Repository.RepositoryItemComboBox = Nothing
            Dim DefaultSettingValue As AdvantageFramework.Database.Entities.SettingValue = Nothing
            Dim SettingValue As AdvantageFramework.Database.Entities.SettingValue = Nothing
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

            RepositoryItemComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox

            RepositoryItemComboBox.Name = Setting.Code

            RepositoryItemComboBox.AutoComplete = True

            If Setting.Code = AdvantageFramework.Agency.Settings.JR_DFLT_CONTACT.ToString Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        Employees = AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).ToList

                    Catch ex As Exception
                        Employees = Nothing
                    End Try

                End Using

                If Employees IsNot Nothing Then

                    For Each SV In SettingValuesList

                        If Employees.Any(Function(Entity) Entity.Code = SV.Value) Then

                            RepositoryItemComboBox.Items.Add(SV)

                        End If

                    Next

                End If

            Else

                For Each SV In SettingValuesList

                    RepositoryItemComboBox.Items.Add(SV)

                Next

            End If

            If Setting.DefaultValue Is Nothing Then

                RepositoryItemComboBox.Items.Insert(0, "[Please select]")
                RepositoryItemComboBox.AllowNullInput = DevExpress.Utils.DefaultBoolean.True

            Else

                RepositoryItemComboBox.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

            End If

            AddHandler RepositoryItemComboBox.EditValueChanged, AddressOf RepositoryItemComboBox_EditValueChanged

            EditorRow.Properties.RowEdit = RepositoryItemComboBox

            Try

                DefaultSettingValue = SettingValuesList.SingleOrDefault(Function(SV) SV.Value = Setting.DefaultValue)

            Catch ex As Exception
                DefaultSettingValue = Nothing
            End Try

            If DefaultSettingValue IsNot Nothing AndAlso Setting.Value Is Nothing Then

                EditorRow.Properties.Value = DefaultSettingValue

            ElseIf Setting.Value IsNot Nothing Then

                Try

                    SettingValue = SettingValuesList.SingleOrDefault(Function(SV) SV.Value = Setting.Value)

                Catch ex As Exception
                    SettingValue = Nothing
                End Try

                If SettingValue IsNot Nothing Then

                    EditorRow.Properties.Value = SettingValue

                Else

                    EditorRow.Properties.Value = "[Please select]"

                End If

            Else

                EditorRow.Properties.Value = "[Please select]"

            End If

        End Sub
        Private Sub CreateButtonEditControl(ByRef EditorRow As DevExpress.XtraVerticalGrid.Rows.EditorRow, ByRef Setting As AdvantageFramework.Database.Entities.Setting, ByRef SettingDatabaseType As AdvantageFramework.Database.Entities.SettingDatabaseType)

            'objects
            Dim RepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = Nothing
            Dim RepositoryItemMemoEdit As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit = Nothing

            If Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_EMAILBODY.ToString OrElse
                    Setting.Code = AdvantageFramework.Agency.Settings.VEN_COST_COL_TERMS.ToString OrElse
                    Setting.Code = AdvantageFramework.Agency.Settings.VCCREM_EMAILBODY.ToString OrElse
                    Setting.Code = AdvantageFramework.Agency.Settings.VCCREM_LETTER.ToString Then

                RepositoryItemMemoEdit = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit

                RepositoryItemMemoEdit.Name = Setting.Code

                If SettingDatabaseType IsNot Nothing Then

                    RepositoryItemMemoEdit.MaxLength = SettingDatabaseType.Precision.GetValueOrDefault(0)

                End If

                RepositoryItemMemoEdit.LinesCount = 5

                AddHandler RepositoryItemMemoEdit.Validating, AddressOf RepositoryItemMemoEdit_Validating

                EditorRow.Properties.RowEdit = RepositoryItemMemoEdit

                EditorRow.Properties.Value = Setting.Value

            Else

                RepositoryItemButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

                RepositoryItemButtonEdit.Name = Setting.Code

                RepositoryItemButtonEdit.Buttons.Clear()

                If SettingDatabaseType IsNot Nothing Then

                    RepositoryItemButtonEdit.MaxLength = SettingDatabaseType.Precision.GetValueOrDefault(0)

                End If

                If Setting.Code = AdvantageFramework.Agency.Settings.AGY_BLD_PPD_START.ToString OrElse
                        Setting.Code = AdvantageFramework.Agency.Settings.AGY_BLD_PPD_END.ToString OrElse
                        Setting.Code = AdvantageFramework.Agency.Settings.AGY_1099_CONTACT.ToString Then

                    AddEllipsisButton(RepositoryItemButtonEdit)

                End If

                If Setting.Code = AdvantageFramework.Agency.Settings.PROOFHQ_SA_PASSWORD.ToString OrElse
                        Setting.Code = AdvantageFramework.Agency.Settings.VCC_SA_PASSWORD.ToString OrElse
                        Setting.Code = AdvantageFramework.Agency.Settings.CS_SA_PASSWORD.ToString OrElse
                        Setting.Code = AdvantageFramework.Agency.Settings.NIELSEN_DB_PASSWORD.ToString OrElse
                        Setting.Code = AdvantageFramework.Agency.Settings.NATIONAL_DB_PASSWORD.ToString Then

                    RepositoryItemButtonEdit.UseSystemPasswordChar = True

                End If

                AddHandler RepositoryItemButtonEdit.Validating, AddressOf RepositoryItemButtonEdit_Validating
                AddHandler RepositoryItemButtonEdit.ButtonClick, AddressOf RepositoryItemButtonEdit_ButtonClick

                EditorRow.Properties.RowEdit = RepositoryItemButtonEdit

                If Setting.Code = AdvantageFramework.Agency.Settings.CSCORE_AS_CLIENT_ID.ToString Then

                    EditorRow.Properties.ReadOnly = True

                    If String.IsNullOrWhiteSpace(Setting.Value) Then

                        EditorRow.Properties.Value = "Not Licensed"

                    Else

                        EditorRow.Properties.Value = "Licensed"

                    End If

                Else

                    EditorRow.Properties.Value = Setting.Value

                End If

            End If

        End Sub
        Private Sub CreateSpinEditControl(ByRef EditorRow As DevExpress.XtraVerticalGrid.Rows.EditorRow, ByRef Setting As AdvantageFramework.Database.Entities.Setting, ByRef SettingDatabaseType As AdvantageFramework.Database.Entities.SettingDatabaseType)

            'objects
            Dim RepositoryItemSpinEdit As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit = Nothing

            RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

            RepositoryItemSpinEdit.Name = Setting.Code

            RepositoryItemSpinEdit.MaxValue = Setting.MaximumValue.GetValueOrDefault(0)
            RepositoryItemSpinEdit.MinValue = Setting.MinimumValue.GetValueOrDefault(0)

            RepositoryItemSpinEdit.MaxLength = SettingDatabaseType.Precision.GetValueOrDefault(0)

            RepositoryItemSpinEdit.Mask.EditMask = "f" & SettingDatabaseType.Scale.GetValueOrDefault(0)
            RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
            RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric

            RepositoryItemSpinEdit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near

            RepositoryItemSpinEdit.Appearance.Options.UseTextOptions = True

            RepositoryItemSpinEdit.IsFloatValue = True

            AddHandler RepositoryItemSpinEdit.Validating, AddressOf RepositoryItemSpinEdit_Validating
            AddHandler RepositoryItemSpinEdit.EditValueChanged, AddressOf RepositoryItemSpinEdit_EditValueChanged

            EditorRow.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            EditorRow.Appearance.Options.UseTextOptions = True

            EditorRow.Properties.RowEdit = RepositoryItemSpinEdit

            If Setting.Value Is Nothing Then

                If Setting.DefaultValue Is Nothing Then

                    RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                    EditorRow.Properties.Value = Nothing

                Else

                    EditorRow.Properties.Value = CDec(FormatNumber(Setting.DefaultValue, SettingDatabaseType.Scale.GetValueOrDefault(0)))

                End If

            Else

                EditorRow.Properties.Value = CDec(FormatNumber(Setting.Value, SettingDatabaseType.Scale.GetValueOrDefault(0)))

            End If

        End Sub
        Private Sub CreateCheckEditControl(ByRef EditorRow As DevExpress.XtraVerticalGrid.Rows.EditorRow, ByRef Setting As AdvantageFramework.Database.Entities.Setting, ByRef SettingDatabaseType As AdvantageFramework.Database.Entities.SettingDatabaseType)

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

            RepositoryItemCheckEdit.Name = Setting.Code

            AddHandler RepositoryItemCheckEdit.EditValueChanged, AddressOf RepositoryItemCheckEdit_EditValueChanged

            EditorRow.Properties.RowEdit = RepositoryItemCheckEdit

            If Setting.Code = AdvantageFramework.Agency.Settings.CS_ENABLED.ToString Then

                If TypeOf Setting.Value Is Boolean Then

                    EditorRow.Properties.Value = Setting.Value

                Else

                    If IsNumeric(Setting.Value) AndAlso CLng(Setting.Value) = 1 Then

                        EditorRow.Properties.Value = True

                    Else

                        EditorRow.Properties.Value = False

                    End If

                End If

            ElseIf Setting.Code = AdvantageFramework.Agency.Settings.QB_ENABLED.ToString Then

                If TypeOf Setting.Value Is Boolean Then

                    EditorRow.Properties.Value = Setting.Value

                Else

                    If IsNumeric(Setting.Value) AndAlso CLng(Setting.Value) = 1 Then

                        EditorRow.Properties.Value = True

                    Else

                        EditorRow.Properties.Value = False

                    End If

                End If

                EditorRow.Properties.ReadOnly = True

            Else

                If TypeOf Setting.Value Is Boolean Then

                    EditorRow.Properties.Value = Setting.Value

                Else

                    If IsNumeric(Setting.Value) AndAlso CLng(Setting.Value) = 1 Then

                        EditorRow.Properties.Value = True

                    Else

                        EditorRow.Properties.Value = False

                    End If

                End If

            End If

        End Sub
        Private Sub CreateHyperLinkEditControl(ByRef EditorRow As DevExpress.XtraVerticalGrid.Rows.EditorRow, ByRef Setting As AdvantageFramework.Database.Entities.Setting, ByRef SettingDatabaseType As AdvantageFramework.Database.Entities.SettingDatabaseType)

            'objects
            Dim RepositoryItemHyperLinkEdit As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit = Nothing

            RepositoryItemHyperLinkEdit = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit

            RepositoryItemHyperLinkEdit.Name = Setting.Code
            RepositoryItemHyperLinkEdit.SingleClick = True
            RepositoryItemHyperLinkEdit.ReadOnly = True

            If SettingDatabaseType IsNot Nothing Then

                RepositoryItemHyperLinkEdit.MaxLength = SettingDatabaseType.Precision.GetValueOrDefault(0)

            End If

            EditorRow.Properties.RowEdit = RepositoryItemHyperLinkEdit

            EditorRow.Properties.Value = Setting.Value

        End Sub
        Private Sub CreatePropertyGrid()

            'objects
            Dim CategoryRow As DevExpress.XtraVerticalGrid.Rows.CategoryRow = Nothing
            Dim EditorRow As DevExpress.XtraVerticalGrid.Rows.EditorRow = Nothing
            Dim SettingDatabaseType As AdvantageFramework.Database.Entities.SettingDatabaseType = Nothing
            Dim SettingValuesList As Generic.List(Of AdvantageFramework.Database.Entities.SettingValue) = Nothing
            Dim SubCategoryRow As DevExpress.XtraVerticalGrid.Rows.CategoryRow = Nothing
            Dim IsAgencyASP As Boolean = False

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                    For Each SettingModuleTab In AdvantageFramework.Database.Procedures.SettingModuleTab.LoadBySettingModuleID(DataContext, _SettingModuleID)

                        CategoryRow = New DevExpress.XtraVerticalGrid.Rows.CategoryRow(SettingModuleTab.Description)

                        For Each SettingModuleGroup In AdvantageFramework.Database.Procedures.SettingModuleGroup.LoadBySettingModuleIDAndSettingModuleTabID(DataContext, _SettingModuleID, SettingModuleTab.ID)

                            SubCategoryRow = New DevExpress.XtraVerticalGrid.Rows.CategoryRow(SettingModuleGroup.Description)

                            CreatePropertyGridRow(DataContext, DbContext, SubCategoryRow, SettingModuleTab.ID, SettingModuleGroup.ID, IsAgencyASP)

                            CategoryRow.ChildRows.Add(SubCategoryRow)

                        Next

                        CreatePropertyGridRow(DataContext, DbContext, CategoryRow, SettingModuleTab.ID, Nothing, IsAgencyASP)

                        VGridControlForm_Settings.Rows.Add(CategoryRow)

                    Next

                End Using

            End Using

        End Sub
        Private Sub CreatePropertyGridRow(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal CategoryRow As DevExpress.XtraVerticalGrid.Rows.CategoryRow,
                                          ByVal SettingModuleTabID As Integer, ByVal SettingModuleGroupID As Object,
                                          IsAgencyASP As Boolean)

            'objects
            Dim EditorRow As DevExpress.XtraVerticalGrid.Rows.EditorRow = Nothing
            Dim SettingDatabaseType As AdvantageFramework.Database.Entities.SettingDatabaseType = Nothing
            Dim SettingValuesList As Generic.List(Of AdvantageFramework.Database.Entities.SettingValue) = Nothing
            Dim SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing
            Dim AdditionalCategoryRow As DevExpress.XtraVerticalGrid.Rows.CategoryRow = Nothing
            Dim SettingCheck As AdvantageFramework.Database.Entities.Setting = Nothing

            If SettingModuleGroupID = Nothing Then

                SettingsList = AdvantageFramework.Database.Procedures.Setting.LoadBySettingModuleIDAndSettingModuleTabID(DataContext, _SettingModuleID, SettingModuleTabID).Where(Function(Setting) Setting.SettingModuleGroupID Is Nothing).ToList

            Else

                SettingsList = AdvantageFramework.Database.Procedures.Setting.LoadBySettingModuleIDAndSettingModuleTabIDAndSettingModuleGroupID(DataContext, _SettingModuleID, SettingModuleTabID, SettingModuleGroupID).ToList

            End If

            For Each Setting In SettingsList

                EditorRow = New DevExpress.XtraVerticalGrid.Rows.EditorRow

                EditorRow.Properties.Caption = Setting.Description
                EditorRow.Properties.FieldName = Setting.Code

                Select Case Setting.Code

                    Case "USE_PHASE", "TRF_CALC_CONCUR_DT"

                        EditorRow.Properties.Caption &= "*"

                    Case "TRF_SCHEDULE_BY"

                        EditorRow.Properties.Caption = EditorRow.Properties.Caption.Replace("due date", "due date*")

                    Case AdvantageFramework.Agency.Settings.NIELSEN_DB_SERVER.ToString, AdvantageFramework.Agency.Settings.NIELSEN_DB_NAME.ToString,
                            AdvantageFramework.Agency.Settings.NIELSEN_DB_USER.ToString, AdvantageFramework.Agency.Settings.NIELSEN_DB_PASSWORD.ToString,
                            AdvantageFramework.Agency.Settings.NIELSEN_WINDOWS_AUTH.ToString, AdvantageFramework.Agency.Settings.EASTLAN_ENABLED.ToString,
                            AdvantageFramework.Agency.Settings.NATIONAL_DB_SERVER.ToString, AdvantageFramework.Agency.Settings.NATIONAL_DB_NAME.ToString,
                            AdvantageFramework.Agency.Settings.NATIONAL_DB_USER.ToString, AdvantageFramework.Agency.Settings.NATIONAL_DB_PASSWORD.ToString,
                            AdvantageFramework.Agency.Settings.NATIONAL_WIN_AUTH.ToString

                        EditorRow.Properties.ReadOnly = IsAgencyASP

                    Case AdvantageFramework.Agency.Settings.DC_ENABLED.ToString

                        EditorRow.Properties.ReadOnly = IsAgencyASP

                        SettingCheck = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.DC_OAUTH2_TOKEN.ToString)

                        If Setting.Value = 1 AndAlso SettingCheck IsNot Nothing AndAlso String.IsNullOrWhiteSpace(SettingCheck.Value) Then

                            Setting.Value = 0

                        End If

                    Case AdvantageFramework.Agency.Settings.DC_PROFILE_ID.ToString, AdvantageFramework.Agency.Settings.DC_REPORT_ID.ToString, AdvantageFramework.Agency.Settings.DC_HELP.ToString

                        EditorRow.Properties.ReadOnly = IsAgencyASP

                End Select

                SettingDatabaseType = AdvantageFramework.Database.Procedures.SettingDatabaseType.LoadBySettingDatabaseTypeID(DataContext, Setting.SettingDatabaseTypeID.GetValueOrDefault(0))

                If SettingDatabaseType IsNot Nothing Then

                    Select Case SettingDatabaseType.DatabaseTypeID

                        Case 1

                            SettingValuesList = AdvantageFramework.Database.Procedures.SettingValue.LoadBySettingCode(DataContext, Setting.Code).ToList

                            If SettingValuesList.Count > 0 Then

                                CreateComboBoxControl(EditorRow, DbContext, Setting, SettingValuesList)

                            Else

                                If Setting.Code = "DC_HELP" Then

                                    CreateHyperLinkEditControl(EditorRow, Setting, SettingDatabaseType)

                                Else

                                    CreateButtonEditControl(EditorRow, Setting, SettingDatabaseType)

                                End If

                            End If

                        Case 5, 2, 3

                            SettingValuesList = AdvantageFramework.Database.Procedures.SettingValue.LoadBySettingCode(DataContext, Setting.Code).ToList

                            If SettingValuesList.Count > 0 Then

                                CreateComboBoxControl(EditorRow, DbContext, Setting, SettingValuesList)

                            Else

                                CreateSpinEditControl(EditorRow, Setting, SettingDatabaseType)

                            End If

                        Case 7

                            CreateCheckEditControl(EditorRow, Setting, SettingDatabaseType)

                        Case 4

                            CreateDateEditControl(EditorRow, Setting, SettingDatabaseType)

                    End Select

                Else

                    SettingValuesList = AdvantageFramework.Database.Procedures.SettingValue.LoadBySettingCode(DataContext, Setting.Code).ToList

                    If SettingValuesList.Count > 0 Then

                        CreateComboBoxControl(EditorRow, DbContext, Setting, SettingValuesList)

                    Else

                        CreateButtonEditControl(EditorRow, Setting, Nothing)

                    End If

                End If

                CategoryRow.ChildRows.Add(EditorRow)

            Next

            'project schedule disclaimer
            If _SettingModuleID = 0 AndAlso SettingModuleTabID = 1 Then

                AdditionalCategoryRow = New DevExpress.XtraVerticalGrid.Rows.CategoryRow("* Not Applicable when using Predecessor")

                With AdditionalCategoryRow.Appearance

                    .ForeColor = DevExpress.Skins.CommonSkins.GetSkin(VGridControlForm_Settings.LookAndFeel).Colors.GetColor(DevExpress.Skins.CommonColors.ControlText)
                    .Options.UseFont = True
                    .Options.UseForeColor = True

                End With

                CategoryRow.ChildRows.Add(AdditionalCategoryRow)

            End If

        End Sub
        Private Sub AddEllipsisButton(ByRef RepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit)

            If CheckForExistingButton(RepositoryItemButtonEdit, DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) = False Then

                RepositoryItemButtonEdit.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis))

            End If

        End Sub
        Private Function CheckForExistingButton(ByRef RepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit, ByVal ButtonPredefines As DevExpress.XtraEditors.Controls.ButtonPredefines) As Boolean

            'objects
            Dim ButtonExists As Boolean = False

            For Each EditorButton In RepositoryItemButtonEdit.Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)()

                If EditorButton.Kind = ButtonPredefines Then

                    ButtonExists = True
                    Exit For

                End If

            Next

            CheckForExistingButton = ButtonExists

        End Function
        Private Sub SetCellValue(FieldName As String, Value As Object)

            'objects
            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            Try

                BaseRow = VGridControlForm_Settings.GetRowByFieldName(FieldName)

            Catch ex As Exception

            End Try

            If BaseRow IsNot Nothing Then

                BaseRow.Properties.Value = Value

            End If

        End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub BaseSettingsForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            If Me.DesignMode = False Then

                ButtonItemActions_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage

                CreatePropertyGrid()

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

                _ToolTipController = New DevExpress.Utils.ToolTipController()
                VGridControlForm_Settings.ToolTipController = _ToolTipController

            End If

        End Sub
        Private Sub BaseSettingsForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            VGridControlForm_Settings.BestFit()

            If _SettingModuleID = 8 Then

                VCC_Shown()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub _ToolTipController_GetActiveObjectInfo(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles _ToolTipController.GetActiveObjectInfo

            'objects
            Dim VGridControl As DevExpress.XtraVerticalGrid.VGridControl = Nothing
            Dim VGridHitInfo As DevExpress.XtraVerticalGrid.VGridHitInfo = Nothing
            Dim RowValue As Object = Nothing
            Dim ToolTipText As String = Nothing
            Dim ToolTipControlInfo As DevExpress.Utils.ToolTipControlInfo = Nothing

            If e.SelectedControl Is VGridControlForm_Settings Then

                Try

                    VGridControl = TryCast(e.SelectedControl, DevExpress.XtraVerticalGrid.VGridControl)

                    If VGridControl IsNot Nothing Then

                        VGridHitInfo = VGridControl.CalcHitInfo(e.ControlMousePosition)

                        If VGridHitInfo IsNot Nothing AndAlso VGridHitInfo.Row IsNot Nothing Then

                            If VGridHitInfo.Row.Name = "row" & AdvantageFramework.Agency.Settings.DC_HELP.ToString Then

                                RowValue = "Click here to log into DCM and find the Profile ID that corresponds with the Email Address login."
                                ToolTipText = RowValue

                            End If

                        End If

                        If String.IsNullOrEmpty(ToolTipText) = False Then

                            ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(RowValue, ToolTipText)

                        End If

                    End If

                Catch ex As Exception

                Finally
                    e.Info = ToolTipControlInfo
                End Try

            End If

        End Sub
        Private Sub RepositoryItemButtonEdit_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            If TypeOf sender.Tag Is DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit Then

                If DirectCast(sender.Tag, DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit).Name = AdvantageFramework.Agency.Settings.AGY_BLD_PPD_START.ToString OrElse
                        DirectCast(sender.Tag, DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit).Name = AdvantageFramework.Agency.Settings.AGY_BLD_PPD_END.ToString Then

                    RepositoryItemButtonEdit_PostPeriod_ButtonClick(sender, e)

                ElseIf DirectCast(sender.Tag, DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit).Name = AdvantageFramework.Agency.Settings.AGY_1099_CONTACT.ToString Then

                    RepositoryItemButtonEdit_EmployeeCode_ButtonClick(sender, e)

                End If

            End If

        End Sub
        Private Sub RepositoryItemCheckEdit_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            If TypeOf sender.Tag Is DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit Then

                If DirectCast(sender.Tag, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).Name = AdvantageFramework.Agency.Settings.DC_ENABLED.ToString Then

                    RepositoryItemCheckEdit_IntegrationSettings_EditValueChanged(sender, e)

                End If

                Me.ShowWaitForm("Saving...")

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, DirectCast(sender.Tag, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).Name)

                    If Setting IsNot Nothing Then

                        If DirectCast(sender, DevExpress.XtraEditors.CheckEdit).EditValue Then

                            Setting.Value = 1

                        Else

                            Setting.Value = 0

                        End If

                        AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub RepositoryItemSpinEdit_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            If TypeOf sender.Tag Is DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit Then

                If DirectCast(sender.Tag, DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit).Name = AdvantageFramework.Agency.Settings.DC_PROFILE_ID.ToString Then

                    RepositoryItemSpinEdit_IntegrationSettings_EditValueChanged(sender, e)

                End If

            End If

        End Sub
        Private Sub RepositoryItemSpinEdit_Validating(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            If TypeOf sender.Tag Is DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit Then

                Me.ShowWaitForm("Saving...")

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, DirectCast(sender.Tag, DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit).Name)

                    If Setting IsNot Nothing Then

                        Setting.Value = DirectCast(sender, DevExpress.XtraEditors.SpinEdit).EditValue

                        AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub RepositoryItemMemoEdit_Validating(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            If TypeOf sender.Tag Is DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit Then

                Me.ShowWaitForm("Saving...")

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, DirectCast(sender.Tag, DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit).Name)

                        If Setting IsNot Nothing Then

                            Setting.Value = DirectCast(sender, DevExpress.XtraEditors.MemoEdit).EditValue

                            AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

                        End If

                    End Using

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub RepositoryItemButtonEdit_Validating(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim IsValid As Boolean = True

            If TypeOf sender.Tag Is DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit Then

                Me.ShowWaitForm("Saving...")

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, DirectCast(sender.Tag, DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit).Name)

                        If Setting IsNot Nothing Then

                            If Setting.Code = AdvantageFramework.Agency.Settings.AGY_BLD_PPD_START.ToString OrElse
                                    Setting.Code = AdvantageFramework.Agency.Settings.AGY_BLD_PPD_END.ToString Then

                                PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(DbContext, DirectCast(sender, DevExpress.XtraEditors.ButtonEdit).EditValue)

                                If PostPeriod IsNot Nothing Then

                                    Setting.Value = DirectCast(sender, DevExpress.XtraEditors.ButtonEdit).EditValue

                                Else

                                    AdvantageFramework.WinForm.MessageBox.Show("Please enter a valid post period.")
                                    IsValid = False

                                End If

                            ElseIf Setting.Code = AdvantageFramework.Agency.Settings.AGY_1099_CONTACT.ToString Then

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, DirectCast(sender, DevExpress.XtraEditors.ButtonEdit).EditValue)

                                If Employee IsNot Nothing Then

                                    Setting.Value = DirectCast(sender, DevExpress.XtraEditors.ButtonEdit).EditValue

                                Else

                                    AdvantageFramework.WinForm.MessageBox.Show("Please enter a valid employee code.")
                                    IsValid = False

                                End If

                            ElseIf Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_FROMEMAIL.ToString Then

                                If String.IsNullOrWhiteSpace(DirectCast(sender, DevExpress.XtraEditors.ButtonEdit).EditValue) = False Then

                                    If AdvantageFramework.StringUtilities.IsValidEmailAddress(DirectCast(sender, DevExpress.XtraEditors.ButtonEdit).EditValue) Then

                                        Setting.Value = DirectCast(sender, DevExpress.XtraEditors.ButtonEdit).EditValue

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("Please enter a valid email address.")
                                        IsValid = False

                                    End If

                                Else

                                    Setting.Value = DirectCast(sender, DevExpress.XtraEditors.ButtonEdit).EditValue

                                End If

                            ElseIf Setting.Code = AdvantageFramework.Agency.Settings.INVPRT_REPLYTO.ToString Then

                                If String.IsNullOrWhiteSpace(DirectCast(sender, DevExpress.XtraEditors.ButtonEdit).EditValue) = False Then

                                    If AdvantageFramework.StringUtilities.IsValidEmailAddress(DirectCast(sender, DevExpress.XtraEditors.ButtonEdit).EditValue) Then

                                        Setting.Value = DirectCast(sender, DevExpress.XtraEditors.ButtonEdit).EditValue

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("Please enter a valid email address.")
                                        IsValid = False

                                    End If

                                Else

                                    Setting.Value = DirectCast(sender, DevExpress.XtraEditors.ButtonEdit).EditValue

                                End If

                                'ElseIf Setting.Code = AdvantageFramework.Agency.Settings.CSCORE_CLIENT_ID.ToString OrElse
                                '        Setting.Code = AdvantageFramework.Agency.Settings.CSCORE_CLIENT_SECRET.ToString Then

                                '    Setting.Value = AdvantageFramework.StringUtilities.RijndaelSimpleEncrypt(DirectCast(sender, DevExpress.XtraEditors.ButtonEdit).EditValue)

                            Else

                                Setting.Value = DirectCast(sender, DevExpress.XtraEditors.ButtonEdit).EditValue

                            End If

                            If IsValid Then

                                AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

                            End If

                        End If

                    End Using

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub RepositoryItemComboBox_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Status As AdvantageFramework.Database.Entities.Status = Nothing
            Dim SettingValuesList As Generic.List(Of AdvantageFramework.Database.Entities.SettingValue) = Nothing
            Dim DefaultSettingValue As AdvantageFramework.Database.Entities.SettingValue = Nothing
            Dim PreviousSettingValue As Object = Nothing

            If TypeOf sender.Tag Is DevExpress.XtraEditors.Repository.RepositoryItemComboBox Then

                Me.ShowWaitForm("Saving...")

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, DirectCast(sender.Tag, DevExpress.XtraEditors.Repository.RepositoryItemComboBox).Name)

                    If Setting IsNot Nothing Then

                        PreviousSettingValue = Setting.Value

                        If TypeOf DirectCast(sender, DevExpress.XtraEditors.ComboBoxEdit).EditValue Is AdvantageFramework.Database.Entities.SettingValue Then

                            Setting.Value = DirectCast(sender, DevExpress.XtraEditors.ComboBoxEdit).EditValue.Value

                        Else

                            If Setting.DefaultValue IsNot Nothing Then

                                SettingValuesList = AdvantageFramework.Database.Procedures.SettingValue.LoadBySettingCode(DataContext, Setting.Code).ToList

                                If SettingValuesList.Count > 0 Then

                                    Try

                                        DefaultSettingValue = SettingValuesList.SingleOrDefault(Function(SettingValue) SettingValue.Value = Setting.DefaultValue)

                                    Catch ex As Exception
                                        DefaultSettingValue = Nothing
                                    End Try

                                    If DefaultSettingValue IsNot Nothing Then

                                        DirectCast(sender, DevExpress.XtraEditors.ComboBoxEdit).EditValue = DefaultSettingValue
                                        Setting.Value = DefaultSettingValue.Value

                                    Else

                                        Setting.Value = Nothing

                                    End If

                                Else

                                    Setting.Value = Nothing

                                End If

                            Else

                                Setting.Value = Nothing

                            End If

                        End If

                        If AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting) Then

                            If Setting.Code = AdvantageFramework.Agency.Settings.TRF_DFLT_STATUS.ToString AndAlso PreviousSettingValue <> Setting.Value Then

                                Try

                                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                        Status = AdvantageFramework.Database.Procedures.Status.LoadByStatusCode(DbContext, PreviousSettingValue)

                                        If Status IsNot Nothing Then

                                            If Status.IsInactive.GetValueOrDefault(0) = 1 Then

                                                AdvantageFramework.Database.Procedures.SettingValue.DeleteBySettingCodeAndLookupValue(DataContext, AdvantageFramework.Agency.Settings.TRF_DFLT_STATUS.ToString, Status.Code)

                                                Try

                                                    DirectCast(sender, DevExpress.XtraEditors.ComboBoxEdit).Properties.Items.Remove(DirectCast(sender, DevExpress.XtraEditors.ComboBoxEdit).OldEditValue)

                                                Catch ex As Exception

                                                End Try

                                            End If

                                        End If

                                    End Using

                                Catch ex As Exception

                                End Try

                            End If

                        End If

                        If Setting.Code = AdvantageFramework.Agency.Settings.VCC_PROVIDER.ToString AndAlso DirectCast(sender, DevExpress.XtraEditors.ComboBoxEdit).EditValue.GetType Is GetType(AdvantageFramework.Database.Entities.SettingValue) Then

                            SetVisibleRows(DirectCast(sender, DevExpress.XtraEditors.ComboBoxEdit).EditValue)

                        End If

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_RestoreDefaults_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_RestoreDefaults.Click

            'objects
            Dim SettingDatabaseType As AdvantageFramework.Database.Entities.SettingDatabaseType = Nothing

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to load defaults?  If you do, all current values will be discarded.", MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.Yes Then

                Me.ShowWaitForm("Restoring...")

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each Setting In AdvantageFramework.Database.Procedures.Setting.LoadBySettingModuleID(DataContext, _SettingModuleID)

                            SettingDatabaseType = AdvantageFramework.Database.Procedures.SettingDatabaseType.LoadBySettingDatabaseTypeID(DataContext, Setting.SettingDatabaseTypeID.GetValueOrDefault(0))

                            If SettingDatabaseType IsNot Nothing Then

                                Select Case SettingDatabaseType.DatabaseTypeID

                                    Case 5

                                        Setting.Value = CDec(FormatNumber(Setting.DefaultValue, SettingDatabaseType.Scale.GetValueOrDefault(0)))

                                    Case Else

                                        Setting.Value = Setting.DefaultValue

                                End Select

                            Else

                                Setting.Value = Setting.DefaultValue

                            End If

                            AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

                        Next

                    End Using

                End Using

                VGridControlForm_Settings.Rows.Clear()

                CreatePropertyGrid()

                Me.CloseWaitForm()

            End If

        End Sub

#Region "   Post Period "

        Private Sub RepositoryItemButtonEdit_PostPeriod_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedPostPeriods As IEnumerable = Nothing
            Dim PostPeriodCode As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.PostPeriod, True, False, SelectedPostPeriods) = Windows.Forms.DialogResult.OK Then

                    If SelectedPostPeriods IsNot Nothing Then

                        Try

                            PostPeriodCode = (From Entity In SelectedPostPeriods
                                              Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            PostPeriodCode = Nothing
                        Finally

                            Try

                                If PostPeriodCode <> Nothing Then

                                    DirectCast(sender, DevExpress.XtraEditors.ButtonEdit).EditValue = PostPeriodCode

                                End If

                            Catch ex As Exception

                            End Try

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   Employee Code "

        Private Sub RepositoryItemButtonEdit_EmployeeCode_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim SelectedEmployeeCodes As IEnumerable = Nothing
            Dim EmployeeCode As String = Nothing

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.Employee, True, True, SelectedEmployeeCodes) = Windows.Forms.DialogResult.OK Then

                    If SelectedEmployeeCodes IsNot Nothing Then

                        Try

                            EmployeeCode = (From Entity In SelectedEmployeeCodes
                                            Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            EmployeeCode = Nothing
                        Finally

                            Try

                                If EmployeeCode <> Nothing Then

                                    DirectCast(sender, DevExpress.XtraEditors.ButtonEdit).EditValue = EmployeeCode

                                End If

                            Catch ex As Exception

                            End Try

                        End Try

                    End If

                End If

            End If

        End Sub

#End Region

#Region "   VCC Settings "

        Private Sub VCC_Shown()

            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            Try

                BaseRow = VGridControlForm_Settings.GetRowByFieldName(AdvantageFramework.Agency.Settings.VCC_PROVIDER.ToString)

                If BaseRow IsNot Nothing AndAlso BaseRow.Properties.Value.GetType Is GetType(AdvantageFramework.Database.Entities.SettingValue) Then

                    SetVisibleRows(DirectCast(BaseRow.Properties.Value, AdvantageFramework.Database.Entities.SettingValue))

                End If

            Catch ex As Exception
                BaseRow = Nothing
            End Try

        End Sub
        Private Sub SetRowReadOnly(FieldName As String, IsReadOnly As Boolean)

            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            Try

                BaseRow = VGridControlForm_Settings.GetRowByFieldName(FieldName)

            Catch ex As Exception
                BaseRow = Nothing
            End Try

            If BaseRow IsNot Nothing Then

                BaseRow.Properties.ReadOnly = IsReadOnly

            End If

        End Sub
        Private Sub SetRowMaxLength(FieldName As String, MaxLength As Integer)

            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            Try

                BaseRow = VGridControlForm_Settings.GetRowByFieldName(FieldName)

            Catch ex As Exception
                BaseRow = Nothing
            End Try

            If BaseRow IsNot Nothing Then

                If TypeOf BaseRow.Properties.RowEdit Is DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit Then

                    DirectCast(BaseRow.Properties.RowEdit, DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit).MaxLength = MaxLength

                End If

            End If

        End Sub
        Private Function GetMaxLengthBySettingCode(Code As String, DefaultMaxLength As Integer) As Integer

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim SettingDatabaseType As AdvantageFramework.Database.Entities.SettingDatabaseType = Nothing
            Dim MaxLength As Integer = 0

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.VCC_SA_USERNAME.ToString)

                If Setting IsNot Nothing Then

                    SettingDatabaseType = AdvantageFramework.Database.Procedures.SettingDatabaseType.LoadBySettingDatabaseTypeID(DataContext, Setting.SettingDatabaseTypeID.GetValueOrDefault(0))

                    If SettingDatabaseType IsNot Nothing Then

                        MaxLength = SettingDatabaseType.Precision.GetValueOrDefault(0)

                    End If

                Else

                    MaxLength = DefaultMaxLength

                End If

            End Using

            GetMaxLengthBySettingCode = MaxLength

        End Function
        Private Sub SetVisibleRows(VCCProvider As AdvantageFramework.Database.Entities.SettingValue)

            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            If VCCProvider.Value = AdvantageFramework.VCC.VCCProviders.EFS Then

                SetRowReadOnly(AdvantageFramework.Agency.Settings.VCC_ACCOUNT_ID.ToString, False)
                SetRowReadOnly(AdvantageFramework.Agency.Settings.VCC_COMPANY_ID.ToString, False)
                SetRowReadOnly(AdvantageFramework.Agency.Settings.VCC_OUTSOURCE_ID.ToString, False)

                SetRowMaxLength(AdvantageFramework.Agency.Settings.VCC_SA_PASSWORD.ToString, GetMaxLengthBySettingCode(AdvantageFramework.Agency.Settings.VCC_SA_USERNAME.ToString, 15))
                SetRowMaxLength(AdvantageFramework.Agency.Settings.VCC_SA_PASSWORD.ToString, GetMaxLengthBySettingCode(AdvantageFramework.Agency.Settings.VCC_SA_PASSWORD.ToString, 12))

            ElseIf VCCProvider.Value = AdvantageFramework.VCC.VCCProviders.CSI Then

                SetRowReadOnly(AdvantageFramework.Agency.Settings.VCC_ACCOUNT_ID.ToString, True)
                SetRowReadOnly(AdvantageFramework.Agency.Settings.VCC_COMPANY_ID.ToString, True)
                SetRowReadOnly(AdvantageFramework.Agency.Settings.VCC_OUTSOURCE_ID.ToString, True)

                SetRowMaxLength(AdvantageFramework.Agency.Settings.VCC_SA_USERNAME.ToString, 100)
                SetRowMaxLength(AdvantageFramework.Agency.Settings.VCC_SA_PASSWORD.ToString, 50)

            End If

            Try

                BaseRow = VGridControlForm_Settings.GetRowByFieldName(AdvantageFramework.Agency.Settings.VCC_PROVIDER.ToString)

            Catch ex As Exception
                BaseRow = Nothing
            End Try

            If BaseRow IsNot Nothing Then

                BaseRow.Properties.Value = VCCProvider

            End If

        End Sub

#End Region

#Region "   Integration Settings "

        Private Sub AuthorizeGoogleServices()

            'objects
            Dim AuthorizationCode As String = Nothing
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing
            Dim ServiceType As GoogleServices.Service.ServiceTypes = GoogleServices.Service.ServiceTypes.DoubleClick

            Try

                Service = AdvantageFramework.GoogleServices.Service.InitializeDoubleClick(Me.Session, False)

                If Service IsNot Nothing Then

                    Service.Authorize()

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub DeauthorizeGoogleServices()

            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing

            Me.ShowWaitForm("Processing...")

            Try

                Service = AdvantageFramework.GoogleServices.Service.InitializeDoubleClick(Me.Session, False)

                If Service IsNot Nothing Then

                    Service.Deauthorize()

                End If

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

        End Sub
        Private Sub RepositoryItemCheckEdit_IntegrationSettings_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            If DirectCast(sender, DevExpress.XtraEditors.CheckEdit).EditValue Then

                AuthorizeGoogleServices()

            Else

                DeauthorizeGoogleServices()

            End If

        End Sub
        Private Sub RepositoryItemSpinEdit_IntegrationSettings_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            If DirectCast(sender.Tag, DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit).Name = AdvantageFramework.Agency.Settings.DC_PROFILE_ID.ToString Then

                SetCellValue(AdvantageFramework.Agency.Settings.DC_ENABLED.ToString, False)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.DC_ENABLED.ToString)

                    If Setting IsNot Nothing Then

                        Setting.Value = False

                        AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

                    End If

                End Using

            End If

        End Sub
        Private Sub VGridControlForm_Settings_CustomDrawRowValueCell(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CustomDrawRowValueCellEventArgs) Handles VGridControlForm_Settings.CustomDrawRowValueCell

            If e.Row.Properties.RowEditName = AdvantageFramework.Agency.Settings.DC_HELP.ToString Then

                e.Appearance.ForeColor = System.Drawing.Color.Blue

            End If

        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace
