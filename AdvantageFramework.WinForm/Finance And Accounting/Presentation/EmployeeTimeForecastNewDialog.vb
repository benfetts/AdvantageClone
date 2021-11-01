Namespace FinanceAndAccounting.Presentation

    Public Class EmployeeTimeForecastNewDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EmployeeTimeForecastID As Integer = 0
        Private _OfficeCode As String = ""
        Private _AssignedToEmployeeCode As String = ""

#End Region

#Region " Properties "

        Private ReadOnly Property EmployeeTimeForecastID As Integer
            Get
                EmployeeTimeForecastID = _EmployeeTimeForecastID
            End Get
        End Property
        Private ReadOnly Property OfficeCode As String
            Get
                OfficeCode = _OfficeCode
            End Get
        End Property
        Private ReadOnly Property AssignedToEmployeeCode As String
            Get
                AssignedToEmployeeCode = _AssignedToEmployeeCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

        End Sub
        Private Sub LoadCopyFromForecasts()

            'objects
            Dim EmployeeTimeForecastID As Integer = 0
            Dim AssignedEmployee As String = ""

            If ComboBoxForm_Office.HasASelectedValue Then

                EmployeeTimeForecastID = ComboBoxForm_EmployeeTimeForecasts.GetSelectedValue
                AssignedEmployee = ComboBoxForm_AssignedEmployee.GetSelectedValue

                ComboBoxForm_EmployeeTimeForecasts.ResetText()
                ComboBoxForm_AssignedEmployee.ResetText()

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ComboBoxForm_EmployeeTimeForecasts.DataSource = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByOfficeCode(DbContext, ComboBoxForm_Office.SelectedValue).ToList
                        ComboBoxForm_AssignedEmployee.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUserandOffice(DbContext, SecurityDbContext, Me.Session.UserCode, Me.Session.User.EmployeeCode).ToList.Where(Function(Entity) Entity.OfficeCode = ComboBoxForm_Office.SelectedValue).ToList

                    End Using

                End Using

                ComboBoxForm_EmployeeTimeForecasts.SelectedValue = EmployeeTimeForecastID
                ComboBoxForm_AssignedEmployee.SelectedValue = AssignedEmployee

            Else

                ComboBoxForm_EmployeeTimeForecasts.DataSource = Nothing
                ComboBoxForm_AssignedEmployee.DataSource = Nothing

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef EmployeeTimeForecastID As Integer = 0, Optional ByRef OfficeCode As String = "", Optional ByRef AssignedToEmployeeCode As String = "") As System.Windows.Forms.DialogResult

            'objects
            Dim EmployeeTimeForecastNewDialog As AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastNewDialog = Nothing

            EmployeeTimeForecastNewDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastNewDialog

            ShowFormDialog = EmployeeTimeForecastNewDialog.ShowDialog()

            If ShowFormDialog = System.Windows.Forms.DialogResult.OK Then

                EmployeeTimeForecastID = EmployeeTimeForecastNewDialog.EmployeeTimeForecastID
                OfficeCode = EmployeeTimeForecastNewDialog.OfficeCode
                AssignedToEmployeeCode = EmployeeTimeForecastNewDialog.AssignedToEmployeeCode

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeTimeForecastNewDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                TextBoxForm_Description.SetPropertySettings(AdvantageFramework.Database.Entities.EmployeeTimeForecast.Properties.Description)
                ComboBoxForm_Office.SetPropertySettings(AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail.Properties.OfficeCode)
                ComboBoxForm_PostPeriod.SetPropertySettings(AdvantageFramework.Database.Entities.EmployeeTimeForecast.Properties.PostPeriodCode)
                ComboBoxForm_AssignedEmployee.SetPropertySettings(AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail.Properties.AssignedToEmployeeCode)

                ComboBoxForm_Office.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me.Session).ToList

                CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)
                PostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).ToList

                If CurrentPostPeriod Is Nothing Then

                    PostPeriods = PostPeriods.Where(Function(Entity) Entity.GLStatus Is Nothing OrElse ((Entity.Month >= Now.Month AndAlso Entity.Year = Now.Year) OrElse Entity.Year > Now.Year)).ToList

                Else

                    PostPeriods = PostPeriods.Where(Function(Entity) Entity.GLStatus Is Nothing OrElse ((Entity.Month >= CurrentPostPeriod.Month AndAlso Entity.Year = CurrentPostPeriod.Year) OrElse Entity.Year > CurrentPostPeriod.Year)).ToList

                End If

                ComboBoxForm_PostPeriod.DataSource = PostPeriods.OrderByDescending(Function(Entity) Entity.Code).ToList

                ComboBoxForm_EmployeeTimeForecasts.Enabled = CheckBoxForm_CopyFrom.Checked
                CheckBoxForm_UpdateEmployeeRates.Enabled = CheckBoxForm_CopyFrom.Checked
                CheckBoxForm_UpdateRevenueAmounts.Enabled = CheckBoxForm_CopyFrom.Checked
                CheckBoxForm_ExcludeHoursEnteredInCopy.Enabled = CheckBoxForm_CopyFrom.Checked

            End Using

        End Sub
        Private Sub EmployeeTimeForecastNewDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            TextBoxForm_Description.Focus()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim Save As Boolean = True
            Dim EmployeeTimeForecast As AdvantageFramework.Database.Entities.EmployeeTimeForecast = Nothing
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If CheckBoxForm_CopyFrom.Checked AndAlso ComboBoxForm_EmployeeTimeForecasts.HasASelectedValue = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please select forecast to copy from.")

                Else

                    Me.ShowWaitForm("Processing...")

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            If AdvantageFramework.EmployeeTimeForecast.InsertOfficeDetail(DbContext, TextBoxForm_Description.Text, ComboBoxForm_PostPeriod.SelectedValue, ComboBoxForm_Office.SelectedValue, ComboBoxForm_AssignedEmployee.SelectedValue, EmployeeTimeForecast, EmployeeTimeForecastOfficeDetail) Then

                                _EmployeeTimeForecastID = EmployeeTimeForecast.ID
                                _OfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode
                                _AssignedToEmployeeCode = EmployeeTimeForecastOfficeDetail.AssignedToEmployeeCode

                                If CheckBoxForm_CopyFrom.Checked AndAlso ComboBoxForm_EmployeeTimeForecasts.HasASelectedValue Then

                                    AdvantageFramework.EmployeeTimeForecast.CopyEmployeeTimeForecastValues(DbContext, Me.Session.ConnectionString,
                                                                                                           EmployeeTimeForecastOfficeDetail.ID, ComboBoxForm_EmployeeTimeForecasts.SelectedValue,
                                                                                                           CheckBoxForm_UpdateEmployeeRates.Checked, CheckBoxForm_UpdateRevenueAmounts.Checked, CheckBoxForm_ExcludeHoursEnteredInCopy.Checked)

                                End If

                                Me.DialogResult = Windows.Forms.DialogResult.OK
                                Me.Close()

                            End If

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ComboBoxForm_Office_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_Office.SelectedValueChanged

            If Me.FormShown Then

                LoadCopyFromForecasts()

            End If

        End Sub
        Private Sub CheckBoxForm_CopyFrom_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxForm_CopyFrom.CheckedChanged

            If Me.FormShown Then

                ComboBoxForm_EmployeeTimeForecasts.Enabled = CheckBoxForm_CopyFrom.Checked
                CheckBoxForm_UpdateEmployeeRates.Enabled = CheckBoxForm_CopyFrom.Checked
                CheckBoxForm_UpdateRevenueAmounts.Enabled = CheckBoxForm_CopyFrom.Checked
                CheckBoxForm_ExcludeHoursEnteredInCopy.Enabled = CheckBoxForm_CopyFrom.Checked

                If CheckBoxForm_CopyFrom.Checked Then

                    LoadCopyFromForecasts()

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
