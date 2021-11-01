Namespace WinForm.Presentation.Controls

    Public Class BillingWorksheetProductionControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl

#Region " Constants "

        Const _DropdownWidth = 250

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _FormSettingsLoaded As Boolean = False
        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _SuspendedForLoading As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property UserEntryChanged As Boolean Implements Interfaces.IUserEntryControl.UserEntryChanged
            Get

                Dim EntryChanged As Boolean = False

                If _ByPassUserEntryChanged = False Then

                    For Each Control In Me.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ToList

                        If Control.UserEntryChanged Then

                            EntryChanged = True
                            Exit For

                        End If

                    Next

                End If

                UserEntryChanged = EntryChanged

            End Get
        End Property
        Public WriteOnly Property ByPassUserEntryChanged As Boolean Implements Controls.Interfaces.IUserEntryControl.ByPassUserEntryChanged
            Set(ByVal value As Boolean)

                For Each Control In Me.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ToList

                    Control.ByPassUserEntryChanged = value

                Next

                _ByPassUserEntryChanged = value

            End Set
        End Property
        Public WriteOnly Property SuspendedForLoading As Boolean Implements Interfaces.IUserEntryControl.SuspendedForLoading
            Set(value As Boolean)

                For Each Control In Me.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ToList

                    Control.SuspendedForLoading = value

                Next

                _SuspendedForLoading = value

            End Set
        End Property
        Public ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = GetParameterDictionary()
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.DoubleBuffered = True

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Public Sub ClearChanged() Implements Interfaces.IUserEntryControl.ClearChanged

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub ForceResize()
            DateTimePickerProductionCutoffs_EmployeeTimeDate.Width = _DropdownWidth
            DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.Width = _DropdownWidth
            ComboBoxProductionCutoffs_APPostingPeriod.Width = _DropdownWidth
        End Sub
        Public Sub LoadControl()

            Me.SuspendLayout()

            DateTimePickerProductionCutoffs_EmployeeTimeDate.Value = Now.ToShortDateString
            DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.Value = Now.ToShortDateString

            ComboBoxProductionCutoffs_APPostingPeriod.SetRequired(True)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                ComboBoxProductionCutoffs_APPostingPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                Try

                    ComboBoxProductionCutoffs_APPostingPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code

                Catch ex As Exception
                    ComboBoxProductionCutoffs_APPostingPeriod.SelectedValue = Nothing
                End Try

            End Using

            Me.ResumeLayout()

        End Sub
        Private Function GetJobOptionValue() As Integer

            Dim OptionValue As Integer = 1

            For Each RadioButtonControl In GroupBoxControl_JobOptions.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                If RadioButtonControl.Checked Then

                    OptionValue = CInt(RadioButtonControl.Tag)

                    Exit For

                End If

            Next

            GetJobOptionValue = OptionValue

        End Function
        Private Function GetJobTypeValue() As Integer

            Dim OptionValue As Integer = 1

            For Each RadioButtonControl In GroupBoxControl_JobType.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                If RadioButtonControl.Checked Then

                    OptionValue = CInt(RadioButtonControl.Tag)

                    Exit For

                End If

            Next

            GetJobTypeValue = OptionValue

        End Function
        Private Function GetParameterDictionary() As Generic.Dictionary(Of String, Object)

            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

            ParameterDictionary = New Generic.Dictionary(Of String, Object)

            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.EmployeeDateCutoff.ToString) = DateTimePickerProductionCutoffs_EmployeeTimeDate.GetValue
            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncomeOnlyDateCutoff.ToString) = DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.GetValue
            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.AccountsPayablePostingPeriodCutoff.ToString) = ComboBoxProductionCutoffs_APPostingPeriod.GetSelectedValue

            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.JobType.ToString) = GetJobTypeValue()
            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.JobOption.ToString) = GetJobOptionValue()

            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncludeContingency.ToString) = CheckBoxControl_IncludeContingency.Checked
            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncludeNonBillableTimeDetail.ToString) = CheckBoxControl_IncludeNonBillableTimeDetail.Checked
            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.IncludeNonBillableAPIODetail.ToString) = CheckBoxControl_IncludeNonBillableAPIODetail.Checked
            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.PrintItemDetail.ToString) = CheckBoxControl_PrintItemDetail.Checked

            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.PopulateTimeComments.ToString) = CheckBoxControl_TimeComments.Checked
            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.PopulateAPComments.ToString) = CheckBoxControl_APComments.Checked
            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.PopulateIOComments.ToString) = CheckBoxControl_IOComments.Checked

            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.UserCode.ToString) = _Session.UserCode

            If CheckBoxControl_IncludeNonBillableTimeDetail.Checked Then

                ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.NonBillableTimeStartDate.ToString) = DateTimePickerNonbillableStartDate.GetValue
                ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetInitialCriteria.NonBillableTimeEndDate.ToString) = DateTimePickerNonbillableEndDate.GetValue

            End If

            GetParameterDictionary = ParameterDictionary

        End Function

#Region "  Control Event Handlers "

        Private Sub BillingWorksheetProductionControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            CheckBoxControl_TimeComments.Enabled = False
            CheckBoxControl_APComments.Enabled = False
            CheckBoxControl_IOComments.Enabled = False

            DateTimePickerProductionCutoffs_EmployeeTimeDate.SetRequired(True)
            DateTimePickerProductionCutoffs_IncomeOnlyTimeDate.SetRequired(True)

            DateTimePickerNonbillableStartDate.Value = Now.AddYears(-2).ToShortDateString
            DateTimePickerNonbillableStartDate.Enabled = False

            DateTimePickerNonbillableEndDate.Value = Now.ToShortDateString
            DateTimePickerNonbillableEndDate.Enabled = False

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub CheckBoxControl_IncludeNonBillableTimeDetail_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxControl_IncludeNonBillableTimeDetail.CheckedChangedEx

            DateTimePickerNonbillableStartDate.Enabled = e.NewChecked.Checked
            DateTimePickerNonbillableStartDate.SetRequired(DateTimePickerNonbillableStartDate.Enabled)

            DateTimePickerNonbillableEndDate.Enabled = e.NewChecked.Checked
            DateTimePickerNonbillableEndDate.SetRequired(DateTimePickerNonbillableEndDate.Enabled)

        End Sub
        Private Sub CheckBoxControl_PrintItemDetail_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxControl_PrintItemDetail.CheckedChangedEx

            CheckBoxControl_TimeComments.Enabled = e.NewChecked.Checked
            CheckBoxControl_APComments.Enabled = e.NewChecked.Checked
            CheckBoxControl_IOComments.Enabled = e.NewChecked.Checked

            CheckBoxControl_TimeComments.Checked = e.NewChecked.Checked
            CheckBoxControl_APComments.Checked = e.NewChecked.Checked
            CheckBoxControl_IOComments.Checked = e.NewChecked.Checked

        End Sub

#End Region

#End Region

    End Class

End Namespace
