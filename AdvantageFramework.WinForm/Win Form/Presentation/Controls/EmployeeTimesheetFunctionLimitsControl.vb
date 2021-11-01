Namespace WinForm.Presentation.Controls

    Public Class EmployeeTimesheetFunctionLimitsControl

        Public Event FunctionsChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _EmployeeCodes As Generic.List(Of String) = Nothing
        Private _IsControlClearing As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property HasLimitedFunctions As Boolean
            Get
                HasLimitedFunctions = DataGridViewRightSection_SelectedFunctions.HasRows
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso _
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        DataGridViewLeftSection_AvailableFunctions.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Core.Function))
                        DataGridViewRightSection_SelectedFunctions.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Core.Function))

                    End Using

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadFunctions()

            'objects
            Dim EmployeeTimesheetFunctions As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimesheetFunction) = Nothing
            Dim EmployeeFunctionCodesList As Generic.List(Of String) = Nothing
            Dim EmployeeFunctionCodes As String() = Nothing
            Dim AddFunction As Boolean = False

            If _EmployeeCodes IsNot Nothing AndAlso _EmployeeCodes.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    EmployeeTimesheetFunctions = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimesheetFunction.Load(DbContext).ToList
                                                  Where _EmployeeCodes.Contains(Entity.EmployeeCode) = True
                                                  Select Entity).ToList

                    Try

                        EmployeeFunctionCodes = EmployeeTimesheetFunctions.Select(Function(Entity) Entity.FunctionCode).Distinct.ToArray

                    Catch ex As Exception
                        EmployeeFunctionCodes = Nothing
                    End Try

                    EmployeeFunctionCodesList = New Generic.List(Of String)

                    If EmployeeFunctionCodes IsNot Nothing AndAlso EmployeeFunctionCodes.Length > 0 Then

                        For Each EmployeeFunctionCode In EmployeeFunctionCodes

                            AddFunction = True

                            For Each EmployeeCode In _EmployeeCodes

                                If EmployeeTimesheetFunctions.Any(Function(Entity) Entity.FunctionCode = EmployeeFunctionCode AndAlso Entity.EmployeeCode = EmployeeCode) = False Then

                                    AddFunction = False
                                    Exit For

                                End If

                            Next

                            If AddFunction Then

                                EmployeeFunctionCodesList.Add(EmployeeFunctionCode)

                            End If

                        Next

                    End If

                    EmployeeFunctionCodes = EmployeeFunctionCodesList.ToArray

                    Try

                        DataGridViewLeftSection_AvailableFunctions.DataSource = (From [Function] In AdvantageFramework.Database.Procedures.Function.LoadCore(DbContext)
                                                                                 Where EmployeeFunctionCodes.Contains([Function].Code) = False AndAlso
                                                                                       ([Function].IsInactive Is Nothing OrElse [Function].IsInactive = 0) AndAlso
                                                                                        [Function].Type = "E"
                                                                                 Select New With {.[Code] = [Function].Code,
                                                                                                  .[Description] = [Function].Description,
                                                                                                  .[Type] = [Function].Type,
                                                                                                  .[IsInactive] = CBool([Function].IsInactive.GetValueOrDefault(0))}).ToList

                    Catch ex As Exception
                        DataGridViewLeftSection_AvailableFunctions.DataSource = New Generic.List(Of AdvantageFramework.Database.Core.Function)
                    End Try

                    Try

                        DataGridViewRightSection_SelectedFunctions.DataSource = (From [Function] In AdvantageFramework.Database.Procedures.Function.LoadCore(DbContext)
                                                                                 Where EmployeeFunctionCodes.Contains([Function].Code) = True
                                                                                 Select New With {.[Code] = [Function].Code,
                                                                                                  .[Description] = [Function].Description,
                                                                                                  .[Type] = [Function].Type,
                                                                                                  .[IsInactive] = CBool([Function].IsInactive.GetValueOrDefault(0))}).ToList

                    Catch ex As Exception
                        DataGridViewLeftSection_AvailableFunctions.DataSource = New Generic.List(Of AdvantageFramework.Database.Core.Function)
                    End Try

                    ModifyColumns()

                    DataGridViewRightSection_SelectedFunctions.CurrentView.BestFitColumns()
                    DataGridViewLeftSection_AvailableFunctions.CurrentView.BestFitColumns()

                End Using

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonRightSection_AddFunction.Enabled = DataGridViewLeftSection_AvailableFunctions.HasASelectedRow
            ButtonRightSection_RemoveFunction.Enabled = DataGridViewRightSection_SelectedFunctions.HasASelectedRow

        End Sub
        Private Sub ModifyColumns()

            For Each GridColumn In DataGridViewLeftSection_AvailableFunctions.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                If GridColumn.FieldName <> AdvantageFramework.Database.Core.Function.Properties.Code.ToString AndAlso
                   GridColumn.FieldName <> AdvantageFramework.Database.Core.Function.Properties.Description.ToString AndAlso
                   GridColumn.FieldName <> AdvantageFramework.Database.Core.Function.Properties.IsInactive.ToString Then

                    GridColumn.Visible = False

                End If

            Next

            For Each GridColumn In DataGridViewRightSection_SelectedFunctions.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                If GridColumn.FieldName <> AdvantageFramework.Database.Core.Function.Properties.Code.ToString AndAlso
                   GridColumn.FieldName <> AdvantageFramework.Database.Core.Function.Properties.Description.ToString AndAlso
                   GridColumn.FieldName <> AdvantageFramework.Database.Core.Function.Properties.IsInactive.ToString Then

                    GridColumn.Visible = False

                End If

            Next

        End Sub

#Region " Public "

        Public Function LoadControl(ByVal EmployeeCodes As Generic.List(Of String)) As Boolean

            'objects
            Dim Loaded As Boolean = True

            _EmployeeCodes = EmployeeCodes

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _EmployeeCodes IsNot Nothing AndAlso _EmployeeCodes.Count > 0 Then

                    LoadFunctions()

                Else

                    Loaded = False

                End If

            End Using

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub ClearControl()

            _IsControlClearing = True

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            _IsControlClearing = False

        End Sub
        Public Sub CopyFunctionLimits(ByVal CopyToEmployee As Boolean)

            Dim SelectedEmployeeCode As String = Nothing
            Dim Employees As IEnumerable = Nothing
            Dim EmployeeTimesheetFunctions As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimesheetFunction) = Nothing
            Dim EmployeeTimesheetFunction As AdvantageFramework.Database.Entities.EmployeeTimesheetFunction = Nothing

            If CopyToEmployee Then

                If Me.HasLimitedFunctions Then

                    If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.Employee, True, True, Employees, True, "Copy To Employees") = Windows.Forms.DialogResult.OK Then

                        AdvantageFramework.WinForm.Presentation.ShowWaitForm()
                        AdvantageFramework.WinForm.Presentation.ShowWaitForm("Copying...")

                        Try

                            If Employees IsNot Nothing Then

                                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                    For Each EmployeeCode In _EmployeeCodes

                                        EmployeeTimesheetFunctions = AdvantageFramework.Database.Procedures.EmployeeTimesheetFunction.LoadByEmployeeCode(DbContext, EmployeeCode).ToList

                                        For Each SelectedEmployeeCode In (From Entity In Employees
                                                                          Select Entity.Code).ToList

                                            If SelectedEmployeeCode IsNot Nothing Then

                                                For Each ETF In EmployeeTimesheetFunctions

                                                    If AdvantageFramework.Database.Procedures.EmployeeTimesheetFunction.LoadByEmployeeCode(DbContext, SelectedEmployeeCode).Any(Function(ETSF) ETSF.FunctionCode = ETF.FunctionCode) = False Then

                                                        EmployeeTimesheetFunction = New AdvantageFramework.Database.Entities.EmployeeTimesheetFunction

                                                        EmployeeTimesheetFunction.DbContext = DbContext
                                                        EmployeeTimesheetFunction.EmployeeCode = SelectedEmployeeCode
                                                        EmployeeTimesheetFunction.FunctionCode = ETF.FunctionCode

                                                        AdvantageFramework.Database.Procedures.EmployeeTimesheetFunction.Insert(DbContext, EmployeeTimesheetFunction)

                                                    End If

                                                Next

                                            End If

                                        Next

                                    Next

                                End Using

                            End If

                        Catch ex As Exception

                        End Try

                        AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                    End If

                End If

            Else

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.Employee, True, True, Employees, False, "Copy From Employee") = Windows.Forms.DialogResult.OK Then

                    AdvantageFramework.WinForm.Presentation.ShowWaitForm("Copying...")

                    Try

                        Try

                            SelectedEmployeeCode = (From Entity In Employees
                                                    Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            SelectedEmployeeCode = Nothing
                        End Try

                        If SelectedEmployeeCode IsNot Nothing Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                EmployeeTimesheetFunctions = AdvantageFramework.Database.Procedures.EmployeeTimesheetFunction.LoadByEmployeeCode(DbContext, SelectedEmployeeCode).ToList

                                For Each EmployeeCode In _EmployeeCodes

                                    For Each ETF In EmployeeTimesheetFunctions

                                        If AdvantageFramework.Database.Procedures.EmployeeTimesheetFunction.LoadByEmployeeCode(DbContext, EmployeeCode).Any(Function(ETSF) ETSF.FunctionCode = ETF.FunctionCode) = False Then

                                            EmployeeTimesheetFunction = New AdvantageFramework.Database.Entities.EmployeeTimesheetFunction

                                            EmployeeTimesheetFunction.DbContext = DbContext
                                            EmployeeTimesheetFunction.EmployeeCode = EmployeeCode
                                            EmployeeTimesheetFunction.FunctionCode = ETF.FunctionCode

                                            AdvantageFramework.Database.Procedures.EmployeeTimesheetFunction.Insert(DbContext, EmployeeTimesheetFunction)

                                        End If

                                    Next

                                Next

                            End Using

                            LoadFunctions()

                        End If

                    Catch ex As Exception

                    End Try

                    RaiseEvent FunctionsChangedEvent()

                    AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                End If

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub EmployeeTimesheetFunctionLimitsControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub ButtonRightSection_AddFunction_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_AddFunction.Click

            Dim FunctionCode As String = String.Empty
            Dim FunctionCodes() As String = Nothing
            Dim EmployeeTimesheetFunction As AdvantageFramework.Database.Entities.EmployeeTimesheetFunction = Nothing
            Dim EmployeeTimesheetFunctions As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimesheetFunction) = Nothing

            If DataGridViewLeftSection_AvailableFunctions.HasASelectedRow Then

                AdvantageFramework.WinForm.Presentation.ShowWaitForm()
                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Processing...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        DbContext.Database.Connection.Open()
                        DbContext.Configuration.AutoDetectChangesEnabled = False
                        'EmployeeTimesheetFunctions = AdvantageFramework.Database.Procedures.EmployeeTimesheetFunction.Load(DbContext).ToList

                        FunctionCodes = DataGridViewLeftSection_AvailableFunctions.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.EMP_TS_FNC WHERE EMP_CODE IN ({0}) AND FNC_CODE IN ({1})", "'" & Join(_EmployeeCodes.ToArray, "','") & "'", "'" & Join(FunctionCodes, "','") & "'"))

                        For Each FunctionCode In FunctionCodes

                            For Each EmployeeCode In _EmployeeCodes '

                                'DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.EMP_TS_FNC WHERE EMP_CODE = '{0}' AND FNC_CODE = '{1}'", EmployeeCode, FunctionCode))

                                'If EmployeeTimesheetFunctions.Any(Function(Entity) Entity.FunctionCode = FunctionCode AndAlso Entity.EmployeeCode = EmployeeCode) = False Then

                                EmployeeTimesheetFunction = New AdvantageFramework.Database.Entities.EmployeeTimesheetFunction

                                'EmployeeTimesheetFunction.DbContext = DbContext
                                EmployeeTimesheetFunction.FunctionCode = FunctionCode
                                EmployeeTimesheetFunction.EmployeeCode = EmployeeCode

                                DbContext.EmployeeTimesheetFunctions.Add(EmployeeTimesheetFunction)

                                'AdvantageFramework.Database.Procedures.EmployeeTimesheetFunction.Insert(DbContext, EmployeeTimesheetFunction)

                                'End If

                            Next

                        Next

                        DbContext.Configuration.AutoDetectChangesEnabled = True

                        DbContext.SaveChanges()

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Loading...")

                Try

                    LoadFunctions()

                Catch ex As Exception

                End Try

                RaiseEvent FunctionsChangedEvent()

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveFunction_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_RemoveFunction.Click

            Dim FunctionCode As String = Nothing
            Dim FunctionCodes() As String = Nothing
            Dim EmployeeTimesheetFunction As AdvantageFramework.Database.Entities.EmployeeTimesheetFunction = Nothing

            If DataGridViewRightSection_SelectedFunctions.HasASelectedRow Then

                AdvantageFramework.WinForm.Presentation.ShowWaitForm()
                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Processing...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        FunctionCodes = DataGridViewRightSection_SelectedFunctions.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.EMP_TS_FNC WHERE EMP_CODE IN ({0}) AND FNC_CODE IN ({1})", "'" & Join(_EmployeeCodes.ToArray, "','") & "'", "'" & Join(FunctionCodes, "','") & "'"))

                        'For Each FunctionCode In DataGridViewRightSection_SelectedFunctions.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToList

                        '    For Each EmployeeCode In _EmployeeCodes

                        '        Try

                        '            EmployeeTimesheetFunction = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimesheetFunction.LoadByEmployeeCode(DbContext, EmployeeCode)
                        '                                         Where Entity.FunctionCode = FunctionCode
                        '                                         Select Entity).FirstOrDefault

                        '        Catch ex As Exception
                        '            EmployeeTimesheetFunction = Nothing
                        '        End Try

                        '        If EmployeeTimesheetFunction IsNot Nothing Then

                        '            AdvantageFramework.Database.Procedures.EmployeeTimesheetFunction.Delete(DbContext, EmployeeTimesheetFunction)

                        '        End If

                        '    Next

                        'Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Loading...")

                Try

                    LoadFunctions()

                Catch ex As Exception

                End Try

                RaiseEvent FunctionsChangedEvent()

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_AvailableFunctions_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewLeftSection_AvailableFunctions.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRightSection_SelectedFunctions_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewRightSection_SelectedFunctions.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
