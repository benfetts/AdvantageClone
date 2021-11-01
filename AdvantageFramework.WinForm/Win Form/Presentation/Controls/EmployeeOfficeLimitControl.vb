Namespace WinForm.Presentation.Controls

    Public Class EmployeeOfficeLimitControl

        Public Event OfficesChangedEvent()

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

        Public ReadOnly Property HasLimitedOffices As Boolean
            Get
                HasLimitedOffices = DataGridViewRightSection_SelectedOffices.HasRows
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

                        DataGridViewLeftSection_AvailableOffices.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Core.Office))
                        DataGridViewRightSection_SelectedOffices.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Core.Office))

                    End Using

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadOffices()

            'objects
            Dim EmployeeOffices As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing
            Dim EmployeeOfficeCodesList As Generic.List(Of String) = Nothing
            Dim EmployeeOfficeCodes As String() = Nothing
            Dim AddOffice As Boolean = False

            If _EmployeeCodes IsNot Nothing AndAlso _EmployeeCodes.Count > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    EmployeeOffices = (From Entity In AdvantageFramework.Database.Procedures.EmployeeOffice.Load(DbContext).ToList
                                       Where _EmployeeCodes.Contains(Entity.EmployeeCode) = True
                                       Select Entity).ToList

                    Try

                        EmployeeOfficeCodes = EmployeeOffices.Select(Function(Entity) Entity.OfficeCode).Distinct.ToArray

                    Catch ex As Exception
                        EmployeeOfficeCodes = Nothing
                    End Try

                    EmployeeOfficeCodesList = New Generic.List(Of String)

                    If EmployeeOfficeCodes IsNot Nothing AndAlso EmployeeOfficeCodes.Length > 0 Then

                        For Each OfficeCode In EmployeeOfficeCodes

                            AddOffice = True

                            For Each EmployeeCode In _EmployeeCodes

                                If EmployeeOffices.Any(Function(Entity) Entity.OfficeCode = OfficeCode AndAlso Entity.EmployeeCode = EmployeeCode) = False Then

                                    AddOffice = False
                                    Exit For

                                End If

                            Next

                            If AddOffice Then

                                EmployeeOfficeCodesList.Add(OfficeCode)

                            End If

                        Next

                    End If

                    EmployeeOfficeCodes = EmployeeOfficeCodesList.ToArray

                    Try

                        DataGridViewLeftSection_AvailableOffices.DataSource = (From Office In AdvantageFramework.Database.Procedures.Office.LoadCore(DbContext)
                                                                               Where EmployeeOfficeCodes.Contains(Office.Code) = False
                                                                               Select Office).ToList

                        DataGridViewLeftSection_AvailableOffices.CurrentView.BestFitColumns()

                    Catch ex As Exception
                        DataGridViewLeftSection_AvailableOffices.DataSource = New Generic.List(Of AdvantageFramework.Database.Core.Office)
                    End Try

                    Try

                        DataGridViewRightSection_SelectedOffices.DataSource = (From Office In AdvantageFramework.Database.Procedures.Office.LoadCore(DbContext)
                                                                               Where EmployeeOfficeCodes.Contains(Office.Code) = True
                                                                               Select Office).ToList

                        DataGridViewRightSection_SelectedOffices.CurrentView.BestFitColumns()

                    Catch ex As Exception
                        DataGridViewLeftSection_AvailableOffices.DataSource = New Generic.List(Of AdvantageFramework.Database.Core.Office)
                    End Try

                End Using

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonRightSection_AddOffice.Enabled = DataGridViewLeftSection_AvailableOffices.HasASelectedRow
            ButtonRightSection_RemoveOffice.Enabled = DataGridViewRightSection_SelectedOffices.HasASelectedRow

        End Sub

#Region " Public "

        Public Function LoadControl(ByVal EmployeeCodes As Generic.List(Of String)) As Boolean

            'objects
            Dim Loaded As Boolean = True

            _EmployeeCodes = EmployeeCodes

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _EmployeeCodes IsNot Nothing AndAlso _EmployeeCodes.Count > 0 Then

                    LoadOffices()

                Else

                    Loaded = False

                End If

            End Using

            'Try

            '    DataGridViewLeftSection_AvailableOffices.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            'Catch ex As Exception

            'End Try

            'Try

            '    DataGridViewRightSection_SelectedOffices.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            'Catch ex As Exception

            'End Try

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub ClearControl()

            _IsControlClearing = True

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            _IsControlClearing = False

        End Sub
        Public Sub CopyOfficeLimits(ByVal CopyToEmployee As Boolean)

            Dim SelectedEmployeeCode As String = Nothing
            Dim Employees As IEnumerable = Nothing
            Dim EmployeeOffices As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing
            Dim EmployeeOffice As AdvantageFramework.Database.Entities.EmployeeOffice = Nothing

            If CopyToEmployee Then

                If Me.HasLimitedOffices Then

                    If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.Employee, True, True, Employees, True, "Copy To Employees") = Windows.Forms.DialogResult.OK Then

                        AdvantageFramework.WinForm.Presentation.ShowWaitForm("Copying...")

                        Try

                            If Employees IsNot Nothing Then

                                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                    For Each EmployeeCode In _EmployeeCodes

                                        EmployeeOffices = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, EmployeeCode).ToList

                                        For Each SelectedEmployeeCode In (From Entity In Employees
                                                                          Select Entity.Code).ToList

                                            If SelectedEmployeeCode IsNot Nothing Then

                                                For Each EmpOffice In EmployeeOffices

                                                    If AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, SelectedEmployeeCode).Any(Function(EO) EO.OfficeCode = EmpOffice.OfficeCode) = False Then

                                                        EmployeeOffice = New AdvantageFramework.Database.Entities.EmployeeOffice

                                                        EmployeeOffice.DbContext = DbContext
                                                        EmployeeOffice.EmployeeCode = SelectedEmployeeCode
                                                        EmployeeOffice.OfficeCode = EmpOffice.OfficeCode

                                                        AdvantageFramework.Database.Procedures.EmployeeOffice.Insert(DbContext, EmployeeOffice)

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

                    AdvantageFramework.WinForm.Presentation.ShowWaitForm()
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

                                EmployeeOffices = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, SelectedEmployeeCode).ToList

                                For Each EmployeeCode In _EmployeeCodes

                                    For Each EmpOffice In EmployeeOffices

                                        If AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, EmployeeCode).Any(Function(EO) EO.OfficeCode = EmpOffice.OfficeCode) = False Then

                                            EmployeeOffice = New AdvantageFramework.Database.Entities.EmployeeOffice

                                            EmployeeOffice.DbContext = DbContext
                                            EmployeeOffice.EmployeeCode = EmployeeCode
                                            EmployeeOffice.OfficeCode = EmpOffice.OfficeCode

                                            AdvantageFramework.Database.Procedures.EmployeeOffice.Insert(DbContext, EmployeeOffice)

                                        End If

                                    Next

                                Next

                            End Using

                            LoadOffices()

                        End If

                    Catch ex As Exception

                    End Try

                    RaiseEvent OfficesChangedEvent()

                    AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                End If

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub EmployeeOfficeLimitControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub ButtonRightSection_AddOffice_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_AddOffice.Click

            Dim OfficeCode As String = Nothing
            Dim EmployeeOffice As AdvantageFramework.Database.Entities.EmployeeOffice = Nothing
            Dim EmployeeOffices As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing

            If DataGridViewLeftSection_AvailableOffices.HasASelectedRow Then

                AdvantageFramework.WinForm.Presentation.ShowWaitForm()
                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Processing...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        EmployeeOffices = AdvantageFramework.Database.Procedures.EmployeeOffice.Load(DbContext).ToList

                        For Each OfficeCode In DataGridViewLeftSection_AvailableOffices.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToList

                            For Each EmployeeCode In _EmployeeCodes

                                If EmployeeOffices.Any(Function(Entity) Entity.OfficeCode = OfficeCode AndAlso Entity.EmployeeCode = EmployeeCode) = False Then

                                    EmployeeOffice = New AdvantageFramework.Database.Entities.EmployeeOffice

                                    EmployeeOffice.DbContext = DbContext
                                    EmployeeOffice.OfficeCode = OfficeCode
                                    EmployeeOffice.EmployeeCode = EmployeeCode

                                    AdvantageFramework.Database.Procedures.EmployeeOffice.Insert(DbContext, EmployeeOffice)

                                End If

                            Next

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Loading...")

                Try

                    LoadOffices()

                Catch ex As Exception

                End Try

                RaiseEvent OfficesChangedEvent()

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveOffice_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_RemoveOffice.Click

            Dim OfficeCode As String = Nothing
            Dim EmployeeOffice As AdvantageFramework.Database.Entities.EmployeeOffice = Nothing

            If DataGridViewRightSection_SelectedOffices.HasASelectedRow Then

                AdvantageFramework.WinForm.Presentation.ShowWaitForm()
                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Processing...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        For Each OfficeCode In DataGridViewRightSection_SelectedOffices.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToList

                            For Each EmployeeCode In _EmployeeCodes

                                Try

                                    EmployeeOffice = (From Entity In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, EmployeeCode)
                                                      Where Entity.OfficeCode = OfficeCode
                                                      Select Entity).FirstOrDefault

                                Catch ex As Exception
                                    EmployeeOffice = Nothing
                                End Try

                                If EmployeeOffice IsNot Nothing Then

                                    AdvantageFramework.Database.Procedures.EmployeeOffice.Delete(DbContext, EmployeeOffice)

                                End If

                            Next

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Loading...")

                Try

                    LoadOffices()

                Catch ex As Exception

                End Try

                RaiseEvent OfficesChangedEvent()

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_AvailableOffices_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewLeftSection_AvailableOffices.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRightSection_SelectedOffices_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewRightSection_SelectedOffices.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
