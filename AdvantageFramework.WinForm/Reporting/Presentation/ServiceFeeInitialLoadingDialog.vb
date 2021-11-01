Namespace Reporting.Presentation

    Public Class ServiceFeeInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

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
            Dim ServiceFeeInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.ServiceFeeInitialLoadingDialog = Nothing

            ServiceFeeInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.ServiceFeeInitialLoadingDialog(ParameterDictionary)

            ShowFormDialog = ServiceFeeInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = ServiceFeeInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ServiceFeeInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

                    ComboBoxForm_StartingPostPeriod.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.StartingPostPeriodCode.ToString)

                Catch ex As Exception

                End Try

                Try

                    ComboBoxForm_EndingPostPeriod.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.EndingPostPeriodCode.ToString)

                Catch ex As Exception

                End Try

                CheckBoxForm_Campaign.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeCampaign.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeCampaign.ToString) = 1, True, False)
                CheckBoxForm_Client.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeClient.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeClient.ToString) = 1, True, False)
                CheckBoxForm_Division.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDivision.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDivision.ToString) = 1, True, False)
                CheckBoxForm_Product.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeProduct.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeProduct.ToString) = 1, True, False)
                CheckBoxForm_FeeType.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFeeType.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFeeType.ToString) = 1, True, False)
                CheckBoxForm_SalesClass.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeSalesClass.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeSalesClass.ToString) = 1, True, False)
                CheckBoxForm_FunctionCode.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionCode.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionCode.ToString) = 1, True, False)
                CheckBoxForm_FunctionHeading.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionHeading.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionHeading.ToString) = 1, True, False)
                CheckBoxForm_JobNumber.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeJobNumber.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeJobNumber.ToString) = 1, True, False)
                CheckBoxForm_FunctionConsolidation.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeConsolidation.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeConsolidation.ToString) = 1, True, False)
                CheckBoxForm_Employee.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeEmployee.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeEmployee.ToString) = 1, True, False)
                CheckBoxForm_Date.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDate.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDate.ToString) = 1, True, False)
                CheckBoxForm_PostPeriod.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludePostPeriod.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludePostPeriod.ToString) = 1, True, False)

            Else

                CheckBoxForm_Campaign.Checked = True
                CheckBoxForm_Client.Checked = True
                CheckBoxForm_Division.Checked = True
                CheckBoxForm_Product.Checked = True
                CheckBoxForm_FeeType.Checked = True
                CheckBoxForm_SalesClass.Checked = True
                CheckBoxForm_FunctionCode.Checked = True
                CheckBoxForm_FunctionHeading.Checked = True
                CheckBoxForm_JobNumber.Checked = True
                CheckBoxForm_FunctionConsolidation.Checked = True
                CheckBoxForm_Employee.Checked = True
                CheckBoxForm_Date.Checked = True
                CheckBoxForm_PostPeriod.Checked = True

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

                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.StartingPostPeriodCode.ToString) = ComboBoxForm_StartingPostPeriod.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.EndingPostPeriodCode.ToString) = ComboBoxForm_EndingPostPeriod.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.UsedID.ToString) = Me.Session.UserCode
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeCampaign.ToString) = CheckBoxForm_Campaign.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeClient.ToString) = CheckBoxForm_Client.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDivision.ToString) = CheckBoxForm_Division.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeProduct.ToString) = CheckBoxForm_Product.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFeeType.ToString) = CheckBoxForm_FeeType.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeSalesClass.ToString) = CheckBoxForm_SalesClass.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionCode.ToString) = CheckBoxForm_FunctionCode.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionHeading.ToString) = CheckBoxForm_FunctionHeading.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeJobNumber.ToString) = CheckBoxForm_JobNumber.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeConsolidation.ToString) = CheckBoxForm_FunctionConsolidation.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeEmployee.ToString) = CheckBoxForm_Employee.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDate.ToString) = CheckBoxForm_Date.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludePostPeriod.ToString) = CheckBoxForm_PostPeriod.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.DesktopObject.ToString) = 0
                    If RadioButtonForm_EmployeeDefaultDept.Checked = True Then
                        _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = "def"
                    ElseIf RadioButtonForm_EmployeeTimeEntryDept.Checked = True Then
                        _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = "time"
                    ElseIf RadioButtonForm_JobComponent.Checked = True Then
                        _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = "job"
                    Else
                        _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = ""
                    End If

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
						ComboBoxForm_EndingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code
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
        Private Sub ButtonForm_2YTD_Click(sender As Object, e As EventArgs) Handles ButtonForm_2YTD.Click

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
