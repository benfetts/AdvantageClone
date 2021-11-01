Namespace WinForm.Presentation.Controls

    Public Class BillingWorksheetMediaControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl

#Region " Constants "



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
        Public Sub LoadControl()

            Me.SuspendLayout()

            ComboBoxControl_SelectBy.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.BillingCommandCenter.MediaDateToUse), False)
            ComboBoxControl_SelectBy.SetRequired(True)

            ComboBoxMediaBroadcast_MonthFrom.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.AbbreviatedMonths))
            ComboBoxMediaBroadcast_MonthTo.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.AbbreviatedMonths))

            NumericInputMediaBroadcast_YearFrom.Properties.MinValue = 1980
            NumericInputMediaBroadcast_YearFrom.Properties.MaxValue = 2078
            NumericInputMediaBroadcast_YearFrom.Properties.MaxLength = 4
            NumericInputMediaBroadcast_YearFrom.SetPropertySettings(DisplayName:="Year From")
            NumericInputMediaBroadcast_YearFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True

            NumericInputMediaBroadcast_YearTo.Properties.MinValue = 1980
            NumericInputMediaBroadcast_YearTo.Properties.MaxValue = 2078
            NumericInputMediaBroadcast_YearTo.Properties.MaxLength = 4
            NumericInputMediaBroadcast_YearTo.SetPropertySettings(DisplayName:="Year To")
            NumericInputMediaBroadcast_YearTo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True

            DateTimePickerMediaType_DateFrom.ValueObject = DateSerial(Now.Year, Now.Month, 1)
            DateTimePickerMediaType_DateTo.ValueObject = DateSerial(Now.Year, Now.Month + 1, 0)

            DateTimePickerJobMedia_DateFrom.ValueObject = Nothing
            DateTimePickerJobMedia_DateTo.ValueObject = Nothing

            ComboBoxMediaBroadcast_MonthFrom.SelectedValue = CLng(Now.Month)
            ComboBoxMediaBroadcast_MonthTo.SelectedValue = CLng(Now.Month)

            NumericInputMediaBroadcast_YearFrom.EditValue = Now.Year
            NumericInputMediaBroadcast_YearTo.EditValue = Now.Year

            CheckBoxControl_OmitZeroUnbilledAmounts.Checked = True

            EnableOrDisableActions()

            Me.ResumeLayout()

        End Sub
        Private Function GetParameterDictionary() As Generic.Dictionary(Of String, Object)

            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

            ParameterDictionary = New Generic.Dictionary(Of String, Object)

            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.DateToUse.ToString) = ComboBoxControl_SelectBy.GetSelectedValue

            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.Newspaper.ToString) = CheckBoxMediaType_Newspaper.Checked
            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.Magazine.ToString) = CheckBoxMediaType_Magazine.Checked
            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.OutOfHome.ToString) = CheckBoxMediaType_OutOfHome.Checked
            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.Internet.ToString) = CheckBoxMediaType_Internet.Checked
            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.RadioDaily.ToString) = CheckBoxMediaType_RadioDaily.Checked
            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.TVDaily.ToString) = CheckBoxMediaType_TelevisionDaily.Checked
            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.MediaStartDate.ToString) = DateTimePickerMediaType_DateFrom.GetValue
            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.MediaEndDate.ToString) = DateTimePickerMediaType_DateTo.GetValue

            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.RadioMonthly.ToString) = CheckBoxMediaBroadcast_Radio.Checked
            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.TVMonthly.ToString) = CheckBoxMediaBroadcast_Television.Checked

            If CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked Then

                ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.BroadcastStartDate.ToString) = DateSerial(NumericInputMediaBroadcast_YearFrom.GetValue, ComboBoxMediaBroadcast_MonthFrom.GetSelectedValue, 1)
                ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.BroadcastEndDate.ToString) = DateSerial(NumericInputMediaBroadcast_YearTo.GetValue, ComboBoxMediaBroadcast_MonthTo.GetSelectedValue, 1)

            Else

                ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.BroadcastStartDate.ToString) = Nothing
                ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.BroadcastEndDate.ToString) = Nothing

            End If

            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.JobMediaDateFrom.ToString) = DateTimePickerJobMedia_DateFrom.GetValue
            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.JobMediaDateTo.ToString) = DateTimePickerJobMedia_DateTo.GetValue

            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.IncludeUnbilledOrdersOnly.ToString) = CheckBoxControl_IncludeUnbilledOrdersOnly.Checked
            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.IncludeSpotsWithZeroBillingAmounts.ToString) = CheckBoxxControl_IncludeSpots.Checked
            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.OmitZeroUnbilledAmounts.ToString) = CheckBoxControl_OmitZeroUnbilledAmounts.Checked

            ParameterDictionary(AdvantageFramework.Reporting.BillingWorksheetMediaInitialCriteria.UserCode.ToString) = _Session.UserCode

            GetParameterDictionary = ParameterDictionary

        End Function
        Private Function IsMediaTypeChecked() As Boolean

            'objects
            Dim MediaTypeIsChecked As Boolean = False

            For Each CheckBox In GroupBoxControl_Types.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.CheckBox)()

                If CheckBox.Checked Then

                    MediaTypeIsChecked = True
                    Exit For

                End If

            Next

            IsMediaTypeChecked = MediaTypeIsChecked

        End Function
        Private Sub EnableDisableMediaGroup()

            If IsMediaTypeChecked() OrElse CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked Then

                CheckBoxControl_IncludeUnbilledOrdersOnly.Checked = True

            Else

                CheckBoxControl_IncludeUnbilledOrdersOnly.Checked = False

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            'objects
            Dim MediaTypeIsChecked As Boolean = False
            Dim SelectMediaByJobMediaDateToBill As Boolean = False

            MediaTypeIsChecked = IsMediaTypeChecked()

            DateTimePickerMediaType_DateFrom.SetRequired(ComboBoxControl_SelectBy.SelectedValue <> 3 AndAlso MediaTypeIsChecked)
            DateTimePickerMediaType_DateTo.SetRequired(ComboBoxControl_SelectBy.SelectedValue <> 3 AndAlso MediaTypeIsChecked)

            ComboBoxMediaBroadcast_MonthFrom.SetRequired(ComboBoxControl_SelectBy.SelectedValue <> 3 AndAlso (CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked))
            ComboBoxMediaBroadcast_MonthTo.SetRequired(ComboBoxControl_SelectBy.SelectedValue <> 3 AndAlso (CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked))
            NumericInputMediaBroadcast_YearFrom.SetRequired(ComboBoxControl_SelectBy.SelectedValue <> 3 AndAlso (CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked))
            NumericInputMediaBroadcast_YearTo.SetRequired(ComboBoxControl_SelectBy.SelectedValue <> 3 AndAlso (CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked))

            CheckBoxxControl_IncludeSpots.AutoCheck = CheckBoxMediaType_RadioDaily.Checked OrElse CheckBoxMediaType_TelevisionDaily.Checked OrElse
                        CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked

            If ComboBoxControl_SelectBy.SelectedValue = 3 Then

                SelectMediaByJobMediaDateToBill = True

            End If

            GroupBoxControl_JobMediaDateToBillDateRange.Enabled = SelectMediaByJobMediaDateToBill
            DateTimePickerJobMedia_DateFrom.SetRequired(SelectMediaByJobMediaDateToBill)
            DateTimePickerJobMedia_DateTo.SetRequired(SelectMediaByJobMediaDateToBill)

            DateTimePickerMediaType_DateFrom.Enabled = Not SelectMediaByJobMediaDateToBill
            DateTimePickerMediaType_DateTo.Enabled = Not SelectMediaByJobMediaDateToBill
            ComboBoxMediaBroadcast_MonthFrom.Enabled = Not SelectMediaByJobMediaDateToBill
            ComboBoxMediaBroadcast_MonthTo.Enabled = Not SelectMediaByJobMediaDateToBill
            NumericInputMediaBroadcast_YearFrom.Enabled = Not SelectMediaByJobMediaDateToBill
            NumericInputMediaBroadcast_YearTo.Enabled = Not SelectMediaByJobMediaDateToBill

        End Sub
        Private Sub CheckBoxMediaType_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

            EnableDisableMediaGroup()

            EnableOrDisableActions()

        End Sub
        Private Sub CheckBoxMediaBroadcast_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

            If Not (CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked) Then

                'Me.ClearValidations()

            End If

            If CheckBoxMediaType_RadioDaily.Checked = False AndAlso CheckBoxMediaType_TelevisionDaily.Checked = False AndAlso
                        CheckBoxMediaBroadcast_Radio.Checked = False AndAlso CheckBoxMediaBroadcast_Television.Checked = False Then

                CheckBoxxControl_IncludeSpots.Checked = False

            End If

            EnableDisableMediaGroup()

            EnableOrDisableActions()

        End Sub
        Public Function ValidateControl(ByRef ErrorMessage As String) As Boolean

            Dim IsValid As Boolean = True

            ErrorMessage = ""

            If (CheckBoxMediaType_Internet.Checked OrElse CheckBoxMediaType_Magazine.Checked OrElse CheckBoxMediaType_Newspaper.Checked OrElse
                    CheckBoxMediaType_OutOfHome.Checked OrElse CheckBoxMediaType_RadioDaily.Checked OrElse CheckBoxMediaType_TelevisionDaily.Checked OrElse
                    CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked) = False Then

                ErrorMessage = "Please select at least one media type." & vbCrLf

                IsValid = False

            End If

            If (CheckBoxMediaType_Internet.Checked OrElse CheckBoxMediaType_Magazine.Checked OrElse CheckBoxMediaType_Newspaper.Checked OrElse
                    CheckBoxMediaType_OutOfHome.Checked OrElse CheckBoxMediaType_RadioDaily.Checked OrElse CheckBoxMediaType_TelevisionDaily.Checked) AndAlso
                    DateTimePickerMediaType_DateFrom.Enabled AndAlso DateTimePickerMediaType_DateTo.Enabled AndAlso DateTimePickerMediaType_DateFrom.GetValue > DateTimePickerMediaType_DateTo.GetValue Then

                ErrorMessage = "The date from is greater than the date to." & vbCrLf

                IsValid = False

            End If

            If DateTimePickerJobMedia_DateFrom.Enabled AndAlso DateTimePickerJobMedia_DateTo.Enabled AndAlso DateTimePickerJobMedia_DateFrom.GetValue > DateTimePickerJobMedia_DateTo.GetValue Then

                ErrorMessage = "The date from is greater than the date to." & vbCrLf

                IsValid = False

            End If

            If (CheckBoxMediaBroadcast_Radio.Checked OrElse CheckBoxMediaBroadcast_Television.Checked) AndAlso ComboBoxMediaBroadcast_MonthFrom.Enabled AndAlso ComboBoxMediaBroadcast_MonthTo.Enabled AndAlso
                    DateSerial(NumericInputMediaBroadcast_YearFrom.GetValue, ComboBoxMediaBroadcast_MonthFrom.GetSelectedValue, 1) > DateSerial(NumericInputMediaBroadcast_YearTo.GetValue, ComboBoxMediaBroadcast_MonthTo.GetSelectedValue, 1) Then

                ErrorMessage += "The broadcast start date is greater than the broadcast end date." & vbCrLf

                IsValid = False

            End If

            ValidateControl = IsValid

        End Function

#Region "  Control Event Handlers "

        Private Sub BillingWorksheetMediaControl_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

            RemoveHandler CheckBoxMediaType_Newspaper.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            RemoveHandler CheckBoxMediaType_Magazine.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            RemoveHandler CheckBoxMediaType_OutOfHome.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            RemoveHandler CheckBoxMediaType_Internet.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            RemoveHandler CheckBoxMediaType_RadioDaily.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            RemoveHandler CheckBoxMediaType_TelevisionDaily.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx

            RemoveHandler CheckBoxMediaBroadcast_Radio.CheckedChangedEx, AddressOf CheckBoxMediaBroadcast_CheckedChangedEx
            RemoveHandler CheckBoxMediaBroadcast_Television.CheckedChangedEx, AddressOf CheckBoxMediaBroadcast_CheckedChangedEx
            RemoveHandler CheckBoxMediaType_RadioDaily.CheckedChangedEx, AddressOf CheckBoxMediaBroadcast_CheckedChangedEx
            RemoveHandler CheckBoxMediaType_TelevisionDaily.CheckedChangedEx, AddressOf CheckBoxMediaBroadcast_CheckedChangedEx

        End Sub
        Private Sub BillingWorksheetMediaControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            AddHandler CheckBoxMediaType_Newspaper.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            AddHandler CheckBoxMediaType_Magazine.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            AddHandler CheckBoxMediaType_OutOfHome.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            AddHandler CheckBoxMediaType_Internet.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            AddHandler CheckBoxMediaType_RadioDaily.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            AddHandler CheckBoxMediaType_TelevisionDaily.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx

            AddHandler CheckBoxMediaBroadcast_Radio.CheckedChangedEx, AddressOf CheckBoxMediaBroadcast_CheckedChangedEx
            AddHandler CheckBoxMediaBroadcast_Television.CheckedChangedEx, AddressOf CheckBoxMediaBroadcast_CheckedChangedEx
            AddHandler CheckBoxMediaType_RadioDaily.CheckedChangedEx, AddressOf CheckBoxMediaBroadcast_CheckedChangedEx
            AddHandler CheckBoxMediaType_TelevisionDaily.CheckedChangedEx, AddressOf CheckBoxMediaBroadcast_CheckedChangedEx

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub ComboBoxControl_SelectBy_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxControl_SelectBy.SelectedValueChanged

            EnableOrDisableActions()

        End Sub
        Private Sub DateTimePickerJobMedia_DateFrom_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerJobMedia_DateFrom.ValueChanged

            If DateTimePickerJobMedia_DateFrom.ValueObject IsNot Nothing Then

                If DateTimePickerJobMedia_DateFrom.ValueObject IsNot Nothing AndAlso (DateTimePickerJobMedia_DateTo.ValueObject Is Nothing OrElse DateTimePickerJobMedia_DateFrom.GetValue > DateTimePickerJobMedia_DateTo.GetValue) Then

                    DateTimePickerJobMedia_DateTo.Value = DateAdd(DateInterval.Day, 6, DateTimePickerJobMedia_DateFrom.Value)

                End If

            End If

        End Sub
        Private Sub DateTimePickerJobMedia_DateTo_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerJobMedia_DateTo.ValueChanged

            If DateTimePickerJobMedia_DateTo.ValueObject IsNot Nothing Then

                If DateTimePickerJobMedia_DateTo.ValueObject IsNot Nothing AndAlso (DateTimePickerJobMedia_DateFrom.ValueObject Is Nothing OrElse DateTimePickerJobMedia_DateTo.GetValue < DateTimePickerJobMedia_DateFrom.GetValue) Then

                    DateTimePickerJobMedia_DateFrom.Value = DateAdd(DateInterval.Day, -6, DateTimePickerJobMedia_DateTo.Value)

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
