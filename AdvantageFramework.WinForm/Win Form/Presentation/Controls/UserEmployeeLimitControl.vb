Namespace WinForm.Presentation.Controls

    Public Class UserEmployeeLimitControl

        Public Event EmployeesChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _UserCodes As Generic.List(Of String) = Nothing
        Private _IsControlClearing As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property HasLimitedEmployees As Boolean
            Get
                HasLimitedEmployees = DataGridViewRightSection_SelectedEmployees.HasRows
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            ''AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        'DataGridViewLeftSection_AvailableEmployees.ClearDatasource(New Generic.List(Of AdvantageFramework.Security.Database.Views.SecurityEmployee))
                        'DataGridViewRightSection_SelectedEmployees.ClearDatasource(New Generic.List(Of AdvantageFramework.Security.Database.Views.SecurityEmployee))

                    End Using

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadEmployees()

            'objects
            Dim AllUserEmployeeAccessesList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserEmployeeAccess) = Nothing
            Dim AvailableEmployeeList As Generic.List(Of AdvantageFramework.Security.Database.Views.Employee) = Nothing
            Dim Employee As AdvantageFramework.Security.Database.Views.Employee = Nothing
            Dim AllEmployeeAccessesList As Generic.List(Of Generic.List(Of AdvantageFramework.Security.Database.Entities.UserEmployeeAccess)) = Nothing
            Dim AddEmployeeAccess As Boolean = True
            Dim FinalEmployeeAccessesList As Generic.List(Of AdvantageFramework.Security.Database.Views.Employee) = Nothing
            Dim UserCode As String = Nothing
            Dim EmployeeList As Generic.List(Of AdvantageFramework.Security.Database.Views.Employee) = Nothing
            Dim EmployeeCodes As Generic.List(Of String) = Nothing
            Dim HasLimitedOfficeCodes As Boolean = False
            Dim AccessibleOfficeCodes As Generic.List(Of String) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _UserCodes IsNot Nothing AndAlso _UserCodes.Count > 0 Then

                        EmployeeCodes = AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext).Where(Function(Entity) _UserCodes.Contains(Entity.UserCode)).Select(Function(Entity) Entity.EmployeeCode).Distinct.ToList

                        AllEmployeeAccessesList = New Generic.List(Of Generic.List(Of AdvantageFramework.Security.Database.Entities.UserEmployeeAccess))

                        AllUserEmployeeAccessesList = AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.Load(SecurityDbContext).ToList

                        For Each UserCode In _UserCodes

                            AllEmployeeAccessesList.Add(AllUserEmployeeAccessesList.Where(Function(UEA) UEA.UserCode = UserCode).ToList)

                        Next

                        FinalEmployeeAccessesList = New Generic.List(Of AdvantageFramework.Security.Database.Views.Employee)

                        EmployeeList = AdvantageFramework.Security.Database.Procedures.EmployeeView.Load(SecurityDbContext).Include("Department").Include("Office").ToList

                        For Each Employee In EmployeeList

                            AddEmployeeAccess = True

                            For Each UserEmployeeAccessesList In AllEmployeeAccessesList

                                If UserEmployeeAccessesList.Any(Function(UserEmployeeAccess) UserEmployeeAccess.EmployeeCode = Employee.Code) = False Then

                                    AddEmployeeAccess = False
                                    Exit For

                                End If

                            Next

                            If AddEmployeeAccess Then

                                FinalEmployeeAccessesList.Add(Employee)

                            End If

                        Next

                        AvailableEmployeeList = New Generic.List(Of AdvantageFramework.Security.Database.Views.Employee)

                        Try

                            HasLimitedOfficeCodes = SecurityDbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.EMP_OFFICE WHERE EMP_CODE IN ('{0}')", Join(EmployeeCodes.ToArray, "', '"))).FirstOrDefault

                        Catch ex As Exception
                            HasLimitedOfficeCodes = False
                        End Try

                        Try

                            AccessibleOfficeCodes = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT
		                                                                                                                    O.OFFICE_CODE
	                                                                                                                    FROM 
		                                                                                                                    [dbo].[EMPLOYEE] AS E CROSS JOIN 
		                                                                                                                    [dbo].[OFFICE] AS O LEFT OUTER JOIN 
		                                                                                                                    [dbo].[EMP_OFFICE] AS EO ON EO.EMP_CODE = E.EMP_CODE
	                                                                                                                    WHERE
		                                                                                                                    E.EMP_CODE IN ('{0}') AND
		                                                                                                                    (EO.OFFICE_CODE = O.OFFICE_CODE OR
		                                                                                                                     (O.OFFICE_CODE IS NOT NULL AND 
		                                                                                                                      EO.OFFICE_CODE IS NULL))", Join(EmployeeCodes.ToArray, "', '"))).ToList

                        Catch ex As Exception
                            AccessibleOfficeCodes = New Generic.List(Of String)
                        End Try

                        If AccessibleOfficeCodes IsNot Nothing Then

                            AccessibleOfficeCodes = AccessibleOfficeCodes.Distinct.ToList

                        End If

                        For Each Employee In EmployeeList

                            If FinalEmployeeAccessesList.Any(Function(UserEmployeeAccess) UserEmployeeAccess.Code = Employee.Code) = False AndAlso
                                    (HasLimitedOfficeCodes = False OrElse AccessibleOfficeCodes.Contains(Employee.OfficeCode)) Then

                                AvailableEmployeeList.Add(Employee)

                            End If

                        Next

                        ButtonRightSection_AddEmployee.Enabled = True
                        ButtonRightSection_RemoveEmployee.Enabled = True

                    Else

                        FinalEmployeeAccessesList = New Generic.List(Of AdvantageFramework.Security.Database.Views.Employee)

                        AvailableEmployeeList = AdvantageFramework.Security.Database.Procedures.EmployeeView.LoadWithOfficeLimits(SecurityDbContext, _Session).ToList

                        ButtonRightSection_AddEmployee.Enabled = False
                        ButtonRightSection_RemoveEmployee.Enabled = False

                    End If

                    DataGridViewRightSection_SelectedEmployees.DataSource = FinalEmployeeAccessesList.Select(Function(Entity) New With {.[Code] = Entity.Code,
                                                                                                                                        .[Name] = If(Entity.MiddleInitial IsNot Nothing AndAlso Entity.MiddleInitial <> "", Entity.FirstName & " " & Entity.MiddleInitial & ". " & Entity.LastName, Entity.FirstName & " " & Entity.LastName),
                                                                                                                                        .[OfficeCode] = Entity.OfficeCode,
                                                                                                                                        .[OfficeName] = If(Entity.Office IsNot Nothing, Entity.Office.Name, Nothing),
                                                                                                                                        .[DepartmentCode] = Entity.DepartmentCode,
                                                                                                                                        .[DepartmentName] = If(Entity.Department IsNot Nothing, Entity.Department.Description, Nothing)}).ToList

                    DataGridViewLeftSection_AvailableEmployees.DataSource = AvailableEmployeeList.Where(Function(Entity) Entity.TerminationDate Is Nothing).Select(Function(Entity) New With {.[Code] = Entity.Code,
                                                                                                                                                                                              .[Name] = If(Entity.MiddleInitial IsNot Nothing AndAlso Entity.MiddleInitial <> "", Entity.FirstName & " " & Entity.MiddleInitial & ". " & Entity.LastName, Entity.FirstName & " " & Entity.LastName),
                                                                                                                                                                                              .[OfficeCode] = Entity.OfficeCode,
                                                                                                                                                                                              .[OfficeName] = If(Entity.Office IsNot Nothing, Entity.Office.Name, Nothing),
                                                                                                                                                                                              .[DepartmentCode] = Entity.DepartmentCode,
                                                                                                                                                                                              .[DepartmentName] = If(Entity.Department IsNot Nothing, Entity.Department.Description, Nothing)}).ToList

                    DataGridViewLeftSection_AvailableEmployees.CurrentView.BestFitColumns()
                    DataGridViewRightSection_SelectedEmployees.CurrentView.BestFitColumns()

                End Using

            End Using

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonRightSection_AddEmployee.Enabled = DataGridViewLeftSection_AvailableEmployees.HasASelectedRow
            ButtonRightSection_RemoveEmployee.Enabled = DataGridViewRightSection_SelectedEmployees.HasASelectedRow

        End Sub

#Region " Public "

        Public Function LoadControl(ByVal UserCodes As Generic.List(Of String)) As Boolean

            'objects
            Dim Loaded As Boolean = True

            _UserCodes = UserCodes

            If _UserCodes IsNot Nothing AndAlso _UserCodes.Count > 0 Then

                LoadEmployees()

            Else

                Loaded = False

                End If

                EnableOrDisableActions()

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

                LoadControl = Loaded

        End Function
        Public Sub ClearControl()

            _IsControlClearing = True

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            _IsControlClearing = False

        End Sub
        Public Sub CopyEmployeeLimits(ByVal CopyToUser As Boolean)

            Dim SelectedUserCode As String = Nothing
            Dim Users As IEnumerable = Nothing
            Dim UserEmployeeAccesses As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserEmployeeAccess) = Nothing
            Dim UserEmployeeAccess As AdvantageFramework.Security.Database.Entities.UserEmployeeAccess = Nothing

            If CopyToUser Then

                If Me.HasLimitedEmployees Then

                    If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.User, True, True, Users, True, "Copy To Users") = Windows.Forms.DialogResult.OK Then

                        AdvantageFramework.WinForm.Presentation.ShowWaitForm("Copying...")

                        Try

                            If Users IsNot Nothing Then

                                Using DbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                    For Each UserCode In _UserCodes

                                        UserEmployeeAccesses = AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCode(DbContext, UserCode).ToList

                                        For Each SelectedUserCode In Users.OfType(Of Object).Select(Function(Entity) Entity.UserCode).ToList

                                            If SelectedUserCode IsNot Nothing Then

                                                For Each UserEA In UserEmployeeAccesses

                                                    If AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCode(DbContext, SelectedUserCode).Any(Function(UEA) UEA.EmployeeCode = UserEA.EmployeeCode) = False Then

                                                        UserEmployeeAccess = New AdvantageFramework.Security.Database.Entities.UserEmployeeAccess

                                                        UserEmployeeAccess.DbContext = DbContext
                                                        UserEmployeeAccess.UserCode = SelectedUserCode
                                                        UserEmployeeAccess.EmployeeCode = UserEA.EmployeeCode

                                                        AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.Insert(DbContext, UserEmployeeAccess)

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

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.User, True, True, Users, False, "Copy From User") = Windows.Forms.DialogResult.OK Then

                    AdvantageFramework.WinForm.Presentation.ShowWaitForm()
                    AdvantageFramework.WinForm.Presentation.ShowWaitForm("Copying...")

                    Try

                        Try

                            SelectedUserCode = Users.OfType(Of Object).Select(Function(Entity) Entity.UserCode).FirstOrDefault

                        Catch ex As Exception
                            SelectedUserCode = Nothing
                        End Try

                        If SelectedUserCode IsNot Nothing Then

                            Using DbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                UserEmployeeAccesses = AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCode(DbContext, SelectedUserCode).ToList

                                For Each UserCode In _UserCodes

                                    For Each UserEA In UserEmployeeAccesses

                                        If AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCode(DbContext, UserCode).Any(Function(UEA) UEA.EmployeeCode = UserEA.EmployeeCode) = False Then

                                            UserEmployeeAccess = New AdvantageFramework.Security.Database.Entities.UserEmployeeAccess

                                            UserEmployeeAccess.DbContext = DbContext
                                            UserEmployeeAccess.UserCode = UserCode
                                            UserEmployeeAccess.EmployeeCode = UserEA.EmployeeCode

                                            AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.Insert(DbContext, UserEmployeeAccess)

                                        End If

                                    Next

                                Next

                            End Using

                            LoadEmployees()

                        End If

                    Catch ex As Exception

                    End Try

                    RaiseEvent EmployeesChangedEvent()

                    AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                End If

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub UserEmployeeLimitControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            DataGridViewLeftSection_AvailableEmployees.OptionsView.ShowFooter = False
            DataGridViewRightSection_SelectedEmployees.OptionsView.ShowFooter = False

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub ButtonRightSection_AddEmployee_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_AddEmployee.Click

            'objects
            Dim EmployeeCode As String = ""
            Dim EmployeeCodeList As Generic.List(Of String) = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim UserEmployeeAccesses As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserEmployeeAccess) = Nothing

            If DataGridViewLeftSection_AvailableEmployees.HasASelectedRow Then

                EmployeeCodeList = DataGridViewLeftSection_AvailableEmployees.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToList

                AdvantageFramework.WinForm.Presentation.ShowWaitForm()
                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Processing...")

                Try

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        UserEmployeeAccesses = AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.Load(SecurityDbContext).ToList

                        For Each UserCode In _UserCodes

                            User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, UserCode)

                            For Each EmployeeCode In EmployeeCodeList

                                If UserEmployeeAccesses.Any(Function(Entity) Entity.UserCode = UserCode AndAlso Entity.EmployeeCode = EmployeeCode) = False Then

                                    AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.Insert(SecurityDbContext, UserCode, EmployeeCode, Nothing)

                                End If

                            Next

                            If AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCode(SecurityDbContext, UserCode).Any AndAlso
                                    AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCodeAndEmployeeCode(SecurityDbContext, UserCode, User.EmployeeCode) Is Nothing Then

                                AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.Insert(SecurityDbContext, UserCode, User.EmployeeCode, Nothing)

                            End If

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Loading...")

                Try

                    LoadEmployees()

                Catch ex As Exception

                End Try

                RaiseEvent EmployeesChangedEvent()

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveEmployee_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_RemoveEmployee.Click

            'objects
            Dim EmployeeCode As String = ""
            Dim UserEmployeeAccess As AdvantageFramework.Security.Database.Entities.UserEmployeeAccess = Nothing
            Dim UserEmployeeAccessList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserEmployeeAccess) = Nothing
            Dim EmployeeCodeList As Generic.List(Of String) = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing

            If DataGridViewRightSection_SelectedEmployees.HasASelectedRow Then

                EmployeeCodeList = DataGridViewRightSection_SelectedEmployees.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToList

                AdvantageFramework.WinForm.Presentation.ShowWaitForm()
                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Processing...")

                Try

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        For Each UserCode In _UserCodes

                            User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, UserCode)

                            For Each EmployeeCode In EmployeeCodeList

                                UserEmployeeAccess = AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCodeAndEmployeeCode(SecurityDbContext, UserCode, EmployeeCode)

                                If UserEmployeeAccess IsNot Nothing Then

                                    AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.Delete(SecurityDbContext, UserEmployeeAccess)

                                End If

                            Next

                            UserEmployeeAccessList = AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCode(SecurityDbContext, UserCode).ToList

                            If UserEmployeeAccessList.Count = 1 Then

                                If UserEmployeeAccessList(0).UserCode = UserCode AndAlso UserEmployeeAccessList(0).EmployeeCode = User.EmployeeCode Then

                                    AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.Delete(SecurityDbContext, UserEmployeeAccessList(0))

                                End If

                            End If

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Loading...")

                Try

                    LoadEmployees()

                Catch ex As Exception

                End Try

                RaiseEvent EmployeesChangedEvent()

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_AvailableEmployees_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewLeftSection_AvailableEmployees.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRightSection_SelectedEmployees_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewRightSection_SelectedEmployees.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
