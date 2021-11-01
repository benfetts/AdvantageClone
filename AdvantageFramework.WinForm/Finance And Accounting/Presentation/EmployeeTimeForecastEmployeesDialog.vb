Namespace FinanceAndAccounting.Presentation

	Public Class EmployeeTimeForecastEmployeesDialog

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

                    EmployeeTimeForecastOfficeDetail = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail).Include("EmployeeTimeForecastOfficeDetailEmployees").
                                                                                                                                                                    Include("EmployeeTimeForecastOfficeDetailEmployees.Employee").
                                                                                                                                                                    Include("EmployeeTimeForecastOfficeDetailEmployees.Employee.DepartmentTeam")
                                                        Where Entity.ID = _EmployeeTimeForecastOfficeDetailID
                                                        Select Entity).SingleOrDefault

                Catch ex As Exception
					EmployeeTimeForecastOfficeDetail = Nothing
				End Try

			End Using

			LoadEmployeeTimeForecastOfficeDetail = EmployeeTimeForecastOfficeDetail

		End Function
		Private Sub LoadAvailableEmployees(Optional ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing)

			'objects
			Dim AvailableEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

			If Me.FormShown AndAlso ComboBoxForm_Office.HasASelectedValue Then

				If EmployeeTimeForecastOfficeDetail Is Nothing Then

					EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

				End If

				Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

					If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

						AvailableEmployeesList = AdvantageFramework.EmployeeTimeForecast.LoadAvailableEmployeesOnEmployeeTimeForecastOfficeDetailByOfficeCode(DbContext, EmployeeTimeForecastOfficeDetail, ComboBoxForm_Office.SelectedValue)

					End If

				End Using

			End If

			If AvailableEmployeesList IsNot Nothing Then

                DataGridViewForm_AvailableEmployees.DataSource = AvailableEmployeesList.Select(Function(Employee) New With {.Code = Employee.Code,
                                                                                                                            .Name = Employee.ToString,
                                                                                                                            .DepartmentTeam = If(Employee.DepartmentTeam IsNot Nothing, Employee.DepartmentTeam.Description, String.Empty)}).ToList

            Else

                DataGridViewForm_AvailableEmployees.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.Employee)().Select(Function(Employee) New With {.Code = Employee.Code,
                                                                                                                                                                       .Name = Employee.ToString,
                                                                                                                                                                       .DepartmentTeam = If(Employee.DepartmentTeam IsNot Nothing, Employee.DepartmentTeam.Description, String.Empty)}).ToList

            End If

			DataGridViewForm_AvailableEmployees.CurrentView.BestFitColumns()

		End Sub
		Private Sub LoadCurrentEmployees(Optional ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing)

			'objects
			Dim CurrentEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

			If EmployeeTimeForecastOfficeDetail Is Nothing Then

				EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

			End If

			If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

				CurrentEmployeesList = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Select(Function(EmployeeTimeForecastOfficeDetailEmployee) EmployeeTimeForecastOfficeDetailEmployee.Employee).ToList

			End If

			If CurrentEmployeesList IsNot Nothing Then

                DataGridViewForm_CurrentEmployees.DataSource = CurrentEmployeesList.Select(Function(Employee) New With {.Code = Employee.Code,
                                                                                                                        .Name = Employee.ToString,
                                                                                                                        .DepartmentTeam = If(Employee.DepartmentTeam IsNot Nothing, Employee.DepartmentTeam.Description, String.Empty)}).ToList

            Else

                DataGridViewForm_CurrentEmployees.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.Employee)().Select(Function(Employee) New With {.Code = Employee.Code,
                                                                                                                                                                     .Name = Employee.ToString,
                                                                                                                                                                     .DepartmentTeam = If(Employee.DepartmentTeam IsNot Nothing, Employee.DepartmentTeam.Description, String.Empty)}).ToList

            End If

			DataGridViewForm_CurrentEmployees.CurrentView.BestFitColumns()

		End Sub
		Private Sub AddEmployeesToEmployeeTimeForecast(ByVal SelectedEmployeeCodes As IEnumerable(Of String))

			'objects
			Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
			Dim CurrentEmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
			Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
			Dim EmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
			Dim UseEmployeeTitleBillingRate As Boolean = False
			Dim EmployeeCode As String = ""

			If SelectedEmployeeCodes IsNot Nothing Then

				Me.ShowWaitForm()
				Me.ShowWaitForm("Adding Employee(s) to Employee Time Forecast...")
				AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

				Try

					EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

					If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

						Try

							Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

								UseEmployeeTitleBillingRate = AdvantageFramework.EmployeeTimeForecast.LoadUseEmployeeTitleBillingRateSetting(DataContext)

							End Using

						Catch ex As Exception
							UseEmployeeTitleBillingRate = False
						End Try

						Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

							CurrentEmployeesList = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Select(Function(EmployeeTimeForecastOfficeDetailEmployee) EmployeeTimeForecastOfficeDetailEmployee.Employee).ToList

							EmployeesList = AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).ToList

							For Each EmployeeCode In SelectedEmployeeCodes

								Try

									Employee = (From Entity In CurrentEmployeesList
												Where Entity.Code = EmployeeCode
												Select Entity).SingleOrDefault


								Catch ex As Exception
									Employee = Nothing
								End Try

								If Employee Is Nothing Then

									Try

										Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

									Catch ex As Exception
										Employee = Nothing
									End Try

								End If

								AdvantageFramework.EmployeeTimeForecast.InsertEmployeeInEmployeeTimeForecastOfficeDetail(DbContext, Me.Session.ConnectionString, EmployeeTimeForecastOfficeDetail, Employee, True, 0, True, 0, UseEmployeeTitleBillingRate)

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

					LoadCurrentEmployees()

				Catch ex As Exception

				End Try

				Try

					LoadAvailableEmployees()

				Catch ex As Exception

				End Try

				Me.CloseWaitForm()

			End If

		End Sub

#Region "  Show Form Methods "

		Public Shared Function ShowFormDialog(ByVal EmployeeTimeForecastOfficeDetailID As Integer) As System.Windows.Forms.DialogResult

			'objects
			Dim EmployeeTimeForecastEmployeesDialog As AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastEmployeesDialog = Nothing

			EmployeeTimeForecastEmployeesDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastEmployeesDialog(EmployeeTimeForecastOfficeDetailID)

			ShowFormDialog = EmployeeTimeForecastEmployeesDialog.ShowDialog()

		End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeTimeForecastEmployeesDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
            Dim OfficeList As Generic.List(Of AdvantageFramework.Database.Entities.Office) = Nothing

            DataGridViewForm_AvailableEmployees.OptionsView.ShowFooter = False
            DataGridViewForm_CurrentEmployees.OptionsView.ShowFooter = False

            EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

            If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        OfficeList = AdvantageFramework.Database.Procedures.Office.LoadWithOfficeLimits(DbContext, Me.Session).OrderBy(Function(Office) Office.Name).ToList

                        ComboBoxForm_Office.DataSource = OfficeList

                        ComboBoxForm_Office.SelectedValue = EmployeeTimeForecastOfficeDetail.OfficeCode

                        LoadCurrentEmployees(EmployeeTimeForecastOfficeDetail)

                    End Using

                End Using

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Employee Time Forecast you are trying to access is not valid.")
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

            ButtonForm_AddAllEmployees.Enabled = DataGridViewForm_AvailableEmployees.HasRows
            ButtonForm_AddEmployee.Enabled = DataGridViewForm_AvailableEmployees.HasASelectedRow

            ButtonForm_RemoveEmployee.Enabled = DataGridViewForm_CurrentEmployees.HasASelectedRow

        End Sub
        Private Sub EmployeeTimeForecastEmployeesDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            LoadAvailableEmployees()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ComboBoxForm_Office_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_Office.SelectedValueChanged

			If Me.FormShown Then

				LoadAvailableEmployees()

			End If

		End Sub
		Private Sub DataGridViewForm_AvailableEmployees_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_AvailableEmployees.SelectionChangedEvent

			ButtonForm_AddAllEmployees.Enabled = DataGridViewForm_AvailableEmployees.HasRows
			ButtonForm_AddEmployee.Enabled = DataGridViewForm_AvailableEmployees.HasASelectedRow

		End Sub
		Private Sub DataGridViewForm_CurrentEmployees_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_CurrentEmployees.SelectionChangedEvent

			ButtonForm_RemoveEmployee.Enabled = DataGridViewForm_CurrentEmployees.HasASelectedRow

		End Sub
		Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

			Me.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.Close()

		End Sub
		Private Sub ButtonForm_AddAllEmployees_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_AddAllEmployees.Click

			'objects
			Dim SelectedEmployeeCodes As IEnumerable(Of String) = Nothing

			If DataGridViewForm_AvailableEmployees.HasRows Then

				SelectedEmployeeCodes = DataGridViewForm_AvailableEmployees.GetAllRowsBookmarkValues.OfType(Of String)()

				AddEmployeesToEmployeeTimeForecast(SelectedEmployeeCodes)

			End If

		End Sub
		Private Sub ButtonForm_AddEmployee_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_AddEmployee.Click

			'objects
			Dim SelectedEmployeeCodes As IEnumerable(Of String) = Nothing

			If DataGridViewForm_AvailableEmployees.HasASelectedRow Then

				SelectedEmployeeCodes = DataGridViewForm_AvailableEmployees.GetAllSelectedRowsBookmarkValues.OfType(Of String)()

				AddEmployeesToEmployeeTimeForecast(SelectedEmployeeCodes)

			End If

		End Sub
		Private Sub ButtonForm_RemoveEmployee_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_RemoveEmployee.Click

			'objects
			Dim SelectedEmployeeCodes As IEnumerable(Of String) = Nothing
			Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
			Dim EmployeeTimeForecastOfficeDetailEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee = Nothing
			Dim CurrentEmployeesList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee) = Nothing
			Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
			Dim EmployeeCode As String = ""

			If DataGridViewForm_CurrentEmployees.HasASelectedRow Then

				SelectedEmployeeCodes = DataGridViewForm_CurrentEmployees.GetAllSelectedRowsBookmarkValues.OfType(Of String)()

				Me.ShowWaitForm()
				Me.ShowWaitForm("Removing Employee(s) from Employee Time Forecast...")
				AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

				Try

					EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

					If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

						CurrentEmployeesList = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.ToList

						Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

							For Each EmployeeCode In SelectedEmployeeCodes

								Try

									EmployeeTimeForecastOfficeDetailEmployee = (From Entity In CurrentEmployeesList
																				Where Entity.EmployeeCode = EmployeeCode
																				Select Entity).SingleOrDefault

								Catch ex As Exception
									EmployeeTimeForecastOfficeDetailEmployee = Nothing
								End Try

								If EmployeeTimeForecastOfficeDetailEmployee IsNot Nothing Then

									AdvantageFramework.EmployeeTimeForecast.DeleteEmployeeFromEmployeeTimeForecastOfficeDetail(DbContext, EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailEmployee)

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

					LoadCurrentEmployees()

				Catch ex As Exception

				End Try

				Try

					LoadAvailableEmployees()

				Catch ex As Exception

				End Try

				Me.CloseWaitForm()

			End If

		End Sub

#End Region

#End Region

	End Class

End Namespace