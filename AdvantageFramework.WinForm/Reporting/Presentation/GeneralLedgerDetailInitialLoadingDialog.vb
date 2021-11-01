Namespace Reporting.Presentation

    Public Class GeneralLedgerDetailInitialLoadingDialog

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

        Private Sub New(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary
            _DynamicReport = DynamicReport

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim GeneralLedgerDetailInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.GeneralLedgerDetailInitialLoadingDialog = Nothing

            GeneralLedgerDetailInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.GeneralLedgerDetailInitialLoadingDialog(DynamicReport, ParameterDictionary)

            ShowFormDialog = GeneralLedgerDetailInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = GeneralLedgerDetailInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub GeneralLedgerDetailInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ComboBoxForm_StartingPostPeriod.SetRequired(True)
            ComboBoxForm_EndingPostPeriod.SetRequired(True)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_StartingPostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                ComboBoxForm_EndingPostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                ComboBoxForm_RecordSource.DataSource = AdvantageFramework.Database.Procedures.RecordSource.Load(DbContext)

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

                If _ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.GeneralLedgerDetailParameters.StartingPostPeriodCode.ToString) AndAlso
                        IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerDetailParameters.StartingPostPeriodCode.ToString)) = False Then

                    Try

                        ComboBoxForm_StartingPostPeriod.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerDetailParameters.StartingPostPeriodCode.ToString)

                    Catch ex As Exception
                        ComboBoxForm_StartingPostPeriod.SelectedValue = Nothing
                    End Try

                End If

                If _ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.GeneralLedgerDetailParameters.EndingPostPeriodCode.ToString) AndAlso
                        IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerDetailParameters.EndingPostPeriodCode.ToString)) = False Then

                    Try

                        ComboBoxForm_EndingPostPeriod.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerDetailParameters.EndingPostPeriodCode.ToString)

                    Catch ex As Exception
                        ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
                    End Try

                End If

                If _ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.GeneralLedgerDetailParameters.RecordSourceID.ToString) AndAlso
                        IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerDetailParameters.RecordSourceID.ToString)) = False Then

                    Try

                        ComboBoxForm_RecordSource.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerDetailParameters.RecordSourceID.ToString)

                    Catch ex As Exception
                        ComboBoxForm_RecordSource.SelectedValue = Nothing
                    End Try

                End If

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

                    _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerDetailParameters.StartingPostPeriodCode.ToString) = ComboBoxForm_StartingPostPeriod.GetSelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerDetailParameters.EndingPostPeriodCode.ToString) = ComboBoxForm_EndingPostPeriod.GetSelectedValue

                    If ComboBoxForm_RecordSource.HasASelectedValue Then

                        _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerDetailParameters.RecordSourceID.ToString) = ComboBoxForm_RecordSource.GetSelectedValue

                    Else

                        _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerDetailParameters.RecordSourceID.ToString) = 0

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.GeneralLedgerDetailParameters.IncludeInactiveAccounts.ToString) = CheckBoxForm_IncludeInactiveAccounts.Checked

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

						ComboBoxForm_StartingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, PostPeriod.Month.GetValueOrDefault(1), PostPeriod.Year.ToString).Code

					Catch ex As Exception
                        ComboBoxForm_StartingPostPeriod.SelectedValue = Nothing
                    End Try

                    Try

                        ComboBoxForm_EndingPostPeriod.SelectedValue = CurrentPostPeriod.Code

                    Catch ex As Exception
                        ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
                    End Try

                End Using

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonForm_MTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_MTD.Click

            Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)

                    Try

                        ComboBoxForm_StartingPostPeriod.SelectedValue = CurrentPostPeriod.Code

                    Catch ex As Exception
                        ComboBoxForm_StartingPostPeriod.SelectedValue = Nothing
                    End Try

                    Try

                        ComboBoxForm_EndingPostPeriod.SelectedValue = CurrentPostPeriod.Code

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

                        ComboBoxForm_EndingPostPeriod.SelectedValue = CurrentPostPeriod.Code

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

                        ComboBoxForm_EndingPostPeriod.SelectedValue = CurrentPostPeriod.Code

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
