Namespace FinanceAndAccounting.Presentation

    Public Class EmployeeTimeForecastAlternateEmployeesDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EmployeeTimeForecastOfficeDetailID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal EmployeeTimeForecastOfficeDetailID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID

        End Sub
        Private Function LoadEmployeeTimeForecastOfficeDetail() As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail

            'objects
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    EmployeeTimeForecastOfficeDetail = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail).Include("EmployeeTimeForecastOfficeDetailAlternateEmployees").
                                                                                                                                                                    Include("EmployeeTimeForecastOfficeDetailAlternateEmployees.EmployeeTitle")
                                                        Where Entity.ID = _EmployeeTimeForecastOfficeDetailID
                                                        Select Entity).SingleOrDefault

                Catch ex As Exception
                    EmployeeTimeForecastOfficeDetail = Nothing
                End Try

            End Using

            LoadEmployeeTimeForecastOfficeDetail = EmployeeTimeForecastOfficeDetail

        End Function
        Private Sub LoadCurrentAlternateEmployees(Optional ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing)

            'objects
            Dim CurrentAlternateEmployeesList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee) = Nothing

            If EmployeeTimeForecastOfficeDetail Is Nothing Then

                EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

            End If

            If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                CurrentAlternateEmployeesList = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.ToList

            End If

            If CurrentAlternateEmployeesList IsNot Nothing Then

                DataGridViewForm_CurrentAlternateEmployees.DataSource = CurrentAlternateEmployeesList

            Else

                DataGridViewForm_CurrentAlternateEmployees.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee)

            End If

            DataGridViewForm_CurrentAlternateEmployees.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal EmployeeTimeForecastOfficeDetailID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim EmployeeTimeForecastAlternateEmployeesDialog As AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastAlternateEmployeesDialog = Nothing

            EmployeeTimeForecastAlternateEmployeesDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastAlternateEmployeesDialog(EmployeeTimeForecastOfficeDetailID)

            ShowFormDialog = EmployeeTimeForecastAlternateEmployeesDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeTimeForecastAlternateEmployeesDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing

            DataGridViewForm_CurrentAlternateEmployees.OptionsView.ShowFooter = False
            DataGridViewForm_CurrentAlternateEmployees.OptionsView.ShowViewCaption = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                TextBoxForm_Description.SetPropertySettings(AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee.Properties.Description)
                ComboBoxForm_EmployeeTitle.SetPropertySettings(AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee.Properties.EmployeeTitleID)
                ComboBoxForm_Office.SetPropertySettings(AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee.Properties.OfficeCode)

            End Using

            EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

            If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ComboBoxForm_EmployeeTitle.DataSource = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadAllActive(DbContext)
                    ComboBoxForm_Office.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me.Session).OrderBy(Function(Office) Office.Name).ToList

                    LoadCurrentAlternateEmployees(EmployeeTimeForecastOfficeDetail)

                End Using

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Employee Time Forecast you are trying to access is not valid.")
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

            ButtonForm_RemoveAlternateEmployee.Enabled = DataGridViewForm_CurrentAlternateEmployees.HasASelectedRow

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewForm_CurrentAlternateEmployees_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_CurrentAlternateEmployees.SelectionChangedEvent

            ButtonForm_RemoveAlternateEmployee.Enabled = DataGridViewForm_CurrentAlternateEmployees.HasASelectedRow

        End Sub
        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

                If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If AdvantageFramework.EmployeeTimeForecast.InsertAlternateEmployeeInEmployeeTimeForecastOfficeDetail(DbContext, _EmployeeTimeForecastOfficeDetailID, ComboBoxForm_EmployeeTitle.GetSelectedValue, TextBoxForm_Description.Text, ComboBoxForm_Office.GetSelectedValue, True, NumericInputForm_BillRate.Value, True, NumericInputForm_CostRate.Value) Then

                            EmployeeTimeForecastOfficeDetail.ModifiedDate = Now
                            EmployeeTimeForecastOfficeDetail.ModifiedByUserCode = DbContext.UserCode

                            AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Update(DbContext, EmployeeTimeForecastOfficeDetail)

                            LoadCurrentAlternateEmployees()

                        End If

                    End Using

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_RemoveAlternateEmployee_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_RemoveAlternateEmployee.Click

            'objects
            Dim SelectedAlternateEmployeeIDs As IEnumerable(Of Integer) = Nothing
            Dim AlternateEmployeeID As Integer = 0
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
            Dim EmployeeTimeForecastOfficeDetailAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee = Nothing

            If DataGridViewForm_CurrentAlternateEmployees.HasASelectedRow Then

                SelectedAlternateEmployeeIDs = DataGridViewForm_CurrentAlternateEmployees.GetAllSelectedRowsBookmarkValues.OfType(Of Integer)()

                Me.ShowWaitForm()
                Me.ShowWaitForm("Removing Alternate Employee(s) from Employee Time Forecast...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each AlternateEmployeeID In SelectedAlternateEmployeeIDs

                                Try

                                    EmployeeTimeForecastOfficeDetailAlternateEmployee = (From Entity In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees
                                                                                         Where Entity.ID = AlternateEmployeeID
                                                                                         Select Entity).SingleOrDefault

                                Catch ex As Exception
                                    EmployeeTimeForecastOfficeDetailAlternateEmployee = Nothing
                                End Try

                                If EmployeeTimeForecastOfficeDetailAlternateEmployee IsNot Nothing Then

                                    AdvantageFramework.EmployeeTimeForecast.DeleteAlternateEmployeeFromEmployeeTimeForecastOfficeDetail(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailAlternateEmployee)

                                End If

                            Next

                            EmployeeTimeForecastOfficeDetail.ModifiedDate = Now
                            EmployeeTimeForecastOfficeDetail.ModifiedByUserCode = DbContext.UserCode

                            AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Update(DbContext, EmployeeTimeForecastOfficeDetail)

                        End Using

                    End If

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False
                Me.ShowWaitForm("Loading...")

                Try

                    LoadCurrentAlternateEmployees()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace