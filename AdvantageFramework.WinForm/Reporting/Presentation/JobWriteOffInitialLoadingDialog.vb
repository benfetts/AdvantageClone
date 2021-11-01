Namespace Reporting.Presentation

    Public Class JobWriteOffInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim JobWriteOffInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.JobWriteOffInitialLoadingDialog = Nothing

            JobWriteOffInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.JobWriteOffInitialLoadingDialog(ParameterDictionary)

            ShowFormDialog = JobWriteOffInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = JobWriteOffInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub JobWriteOffInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ComboBoxForm_StartingPostPeriod.SetRequired(True)
            ComboBoxForm_EndingPostPeriod.SetRequired(True)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_StartingPostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                ComboBoxForm_EndingPostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                Try
                    ComboBoxForm_StartingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code
                Catch ex As Exception
                    ComboBoxForm_StartingPostPeriod.SelectedValue = Nothing
                End Try
                Try
                    ComboBoxForm_EndingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code
                Catch ex As Exception
                    ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
                End Try

            End Using

            If _ParameterDictionary IsNot Nothing Then

                Try

                    ComboBoxForm_StartingPostPeriod.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.CashAnaylsisParameters.StartingPostPeriodCode.ToString)

                Catch ex As Exception

                End Try

                Try

                    ComboBoxForm_EndingPostPeriod.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.CashAnaylsisParameters.EndingPostPeriodCode.ToString)

                Catch ex As Exception

                End Try

                CheckBoxForm_EmployeeTime.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.JobWriteOffParameters.IncludeEmployeeTime.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.JobWriteOffParameters.IncludeEmployeeTime.ToString) = 1, True, False)
                CheckBoxForm_Vendor.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.JobWriteOffParameters.IncludeVendor.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.JobWriteOffParameters.IncludeVendor.ToString) = 1, True, False)
                CheckBoxForm_IncomeOnly.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.JobWriteOffParameters.IncludeIncomeOnly.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.JobWriteOffParameters.IncludeIncomeOnly.ToString) = 1, True, False)

            Else

                CheckBoxForm_EmployeeTime.Checked = True
                CheckBoxForm_Vendor.Checked = True
                CheckBoxForm_IncomeOnly.Checked = True

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If ComboBoxForm_StartingPostPeriod.SelectedValue <= ComboBoxForm_EndingPostPeriod.SelectedValue Then

                    If _ParameterDictionary Is Nothing Then

                        _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.JobWriteOffParameters.StartingPostPeriodCode.ToString) = ComboBoxForm_StartingPostPeriod.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.JobWriteOffParameters.EndingPostPeriodCode.ToString) = ComboBoxForm_EndingPostPeriod.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.JobWriteOffParameters.IncludeEmployeeTime.ToString) = CheckBoxForm_EmployeeTime.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.JobWriteOffParameters.IncludeVendor.ToString) = CheckBoxForm_Vendor.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.JobWriteOffParameters.IncludeIncomeOnly.ToString) = CheckBoxForm_IncomeOnly.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.JobWriteOffParameters.GroupByComponent.ToString) = CheckBoxForm_Component.Checked

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a starting post period that is before the ending post period.")

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
        Private Sub ButtonForm_YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_YTD.Click

            Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)
                    PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadFirstPeriodByYear(DbContext, CurrentPostPeriod.Year)

                    Try
                        Me.ComboBoxForm_StartingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, PostPeriod.Month.GetValueOrDefault(1), PostPeriod.Year.ToString).Code
                    Catch ex As Exception
                        ComboBoxForm_StartingPostPeriod.SelectedValue = Nothing
                    End Try
                    Try
                        Me.ComboBoxForm_EndingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code
                    Catch ex As Exception
                        ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
                    End Try

                End Using

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonForm_MTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_MTD.Click

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try
                        ComboBoxForm_StartingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code
                    Catch ex As Exception
                        ComboBoxForm_StartingPostPeriod.SelectedValue = Nothing
                    End Try
                    Try
                        ComboBoxForm_EndingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code
                    Catch ex As Exception
                        ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
                    End Try

                End Using

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonForm_1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_1Year.Click

            Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim Month As Integer = 0
            Dim Year As Integer = 0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)

                    If CurrentPostPeriod IsNot Nothing Then

                        Month = CInt(CurrentPostPeriod.Month.GetValueOrDefault(1))
                        Year = CInt(CurrentPostPeriod.Year) - 1

                    End If

                    Try
                        ComboBoxForm_StartingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Month, Year).Code
                    Catch ex As Exception
                        ComboBoxForm_StartingPostPeriod.SelectedValue = Nothing
                    End Try

                    Try
                        ComboBoxForm_EndingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code
                    Catch ex As Exception
                        ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
                    End Try

                End Using

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonForm_2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_2Years.Click

            Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim Month As Integer = 0
            Dim Year As Integer = 0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)

                    If CurrentPostPeriod IsNot Nothing Then

                        Month = CInt(CurrentPostPeriod.Month.GetValueOrDefault(1))
                        Year = CInt(CurrentPostPeriod.Year) - 2

                    End If

                    Try
                        ComboBoxForm_StartingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Month, Year).Code
                    Catch ex As Exception
                        ComboBoxForm_StartingPostPeriod.SelectedValue = Nothing
                    End Try

                    Try
                        ComboBoxForm_EndingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code
                    Catch ex As Exception
                        ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
                    End Try

                End Using

            Catch ex As Exception

            End Try

        End Sub
        Private Sub Button2YTD_Click(sender As Object, e As EventArgs) Handles Button2YTD.Click

            Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)
                    PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadFirstPeriodByYear(DbContext, CurrentPostPeriod.Year)

                    Try
                        ComboBoxForm_StartingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, PostPeriod.Month.GetValueOrDefault(1), CInt(PostPeriod.Year) - 1).Code
                    Catch ex As Exception
                        ComboBoxForm_StartingPostPeriod.SelectedValue = Nothing
                    End Try

                    Try
                        ComboBoxForm_EndingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code
                    Catch ex As Exception
                        ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
                    End Try

                End Using

            Catch ex As Exception

            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace
