Namespace GeneralLedger.Maintenance.Presentation

    Public Class CreatePostPeriodDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "


#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As System.Windows.Forms.DialogResult

            'objects
            Dim CreatePostPeriodDialog As AdvantageFramework.GeneralLedger.Maintenance.Presentation.CreatePostPeriodDialog = Nothing

            CreatePostPeriodDialog = New AdvantageFramework.GeneralLedger.Maintenance.Presentation.CreatePostPeriodDialog()

            ShowFormDialog = CreatePostPeriodDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub CreatePostPeriodDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                NumericInputForm_Year.SetPropertySettings(AdvantageFramework.Database.Entities.PostPeriod.Properties.Year)
                NumericInputForm_Year.Properties.MaxValue = 9999
                NumericInputForm_Year.Properties.MinValue = 0
                NumericInputForm_Year.Properties.Buttons.Clear()
                NumericInputForm_Year.SetRequired(True)

                Try

                    NumericInputForm_Year.EditValue = (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext)
                                                       Select Entity.Year).Max + 1

                Catch ex As Exception
                    NumericInputForm_Year.EditValue = Nothing
                End Try

                RadioButtonControlForm_Open.Checked = True

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim YearEndPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig = Nothing
            Dim Status As String = Nothing
            Dim ActualMonth As Integer = Nothing
            Dim FiscalYear As Integer = Nothing
            Dim CodeYear As Integer = Nothing
            Dim CodeMonth As String = Nothing
            Dim DateYear As Integer = Nothing

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If RadioButtonControlForm_Closed.Checked Then

                        Status = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.PostPeriodStatus.Closed).Code

                    ElseIf RadioButtonControlForm_Open.Checked Then

                        Status = Nothing

                    End If

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        GeneralLedgerConfig = AdvantageFramework.Database.Procedures.GeneralLedgerConfig.Load(DbContext)

                    End Using

                    FiscalYear = CInt(NumericInputForm_Year.EditValue)

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For FiscalMonth = 1 To 12

                            PostPeriod = New AdvantageFramework.Database.Entities.PostPeriod

                            PostPeriod.DbContext = DbContext
                            PostPeriod.Year = FiscalYear
                            PostPeriod.GLStatus = Status
                            PostPeriod.ARStatus = Status
                            PostPeriod.APStatus = Status
                            PostPeriod.EmployeeTimeStatus = Status
                            PostPeriod.UserCode = Me.Session.UserCode
                            PostPeriod.EnteredDate = System.DateTime.Today
                            PostPeriod.Month = CShort(FiscalMonth)

                            If GeneralLedgerConfig.FiscalYearStartMonth <> CLng(AdvantageFramework.DateUtilities.Months.January) Then

                                CodeYear = FiscalYear
                                ActualMonth = FiscalMonth + GeneralLedgerConfig.FiscalYearStartMonth - 1
                                DateYear = FiscalYear

                                If ActualMonth > 12 Then

                                    ActualMonth = ActualMonth - 12

                                End If

                                If GeneralLedgerConfig.PostingPeriodFormat.GetValueOrDefault(0) = 0 OrElse GeneralLedgerConfig.PostingPeriodFormat = AdvantageFramework.Database.Entities.PostPeriodFormats.MMEqualToCalendarMonth Then

                                    CodeMonth = ActualMonth

                                ElseIf GeneralLedgerConfig.PostingPeriodFormat = AdvantageFramework.Database.Entities.PostPeriodFormats.MMNotEqualToCalendarMonth Then

                                    CodeMonth = FiscalMonth

                                End If

                                If GeneralLedgerConfig.PostingPeriodYear = AdvantageFramework.Database.Entities.PostPeriodFiscalYearFormats.FiscalYearBeginsInCurrentCalendarYear Then

                                    If ActualMonth < GeneralLedgerConfig.FiscalYearStartMonth Then

                                        DateYear = FiscalYear + 1

                                        If GeneralLedgerConfig.PostingPeriodFormat = AdvantageFramework.Database.Entities.PostPeriodFormats.MMEqualToCalendarMonth Then

                                            CodeYear = DateYear

                                        End If

                                    End If

                                ElseIf GeneralLedgerConfig.PostingPeriodYear = AdvantageFramework.Database.Entities.PostPeriodFiscalYearFormats.FiscalYearBeginsInPreviousCalendarYear Then

                                    If ActualMonth >= GeneralLedgerConfig.FiscalYearStartMonth Then

                                        DateYear = FiscalYear - 1

                                        If GeneralLedgerConfig.PostingPeriodFormat = AdvantageFramework.Database.Entities.PostPeriodFormats.MMEqualToCalendarMonth Then

                                            CodeYear = DateYear

                                        End If

                                    End If

                                End If

                            Else

                                CodeMonth = FiscalMonth
                                ActualMonth = FiscalMonth
                                CodeYear = FiscalYear
                                DateYear = FiscalYear

                            End If

                            PostPeriod.Description = [Enum].GetName(GetType(AdvantageFramework.DateUtilities.Months), ActualMonth).ToString
                            PostPeriod.Code = CodeYear.ToString & AdvantageFramework.StringUtilities.PadWithCharacter(CodeMonth, 2, "0", True)
                            PostPeriod.StartDate = New System.DateTime(DateYear, ActualMonth, 1)
                            PostPeriod.EndDate = New System.DateTime(DateYear, ActualMonth, 1).AddMonths(1).AddDays(-1)

                            If AdvantageFramework.Database.Procedures.PostPeriod.Insert(DbContext, PostPeriod) = False Then

                                DbContext.UndoChanges(PostPeriod)

                            End If

                        Next

                        YearEndPostPeriod = New AdvantageFramework.Database.Entities.PostPeriod

                        YearEndPostPeriod.DbContext = DbContext
                        YearEndPostPeriod.Code = NumericInputForm_Year.EditValue.ToString & "YE"
                        YearEndPostPeriod.Year = NumericInputForm_Year.EditValue.ToString
                        YearEndPostPeriod.Month = 99
                        YearEndPostPeriod.Description = "Year End"
                        YearEndPostPeriod.EnteredDate = System.DateTime.Today
                        YearEndPostPeriod.UserCode = Me.Session.UserCode
                        YearEndPostPeriod.GLStatus = Status
                        YearEndPostPeriod.ARStatus = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.PostPeriodStatus.Closed).Code
                        YearEndPostPeriod.APStatus = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.PostPeriodStatus.Closed).Code
                        YearEndPostPeriod.EmployeeTimeStatus = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.PostPeriodStatus.Closed).Code

                        AdvantageFramework.Database.Procedures.PostPeriod.Insert(DbContext, YearEndPostPeriod)

                    End Using

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace
