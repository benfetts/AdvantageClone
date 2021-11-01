Namespace WinForm.Presentation.Controls

    Public Class DateTimePicker
        Inherits DevComponents.Editors.DateTimeAdv.DateTimeInput
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum [Type]
            [Default]
            TimeOnly
            ShortDate
            ShortDateAndTime
        End Enum

#End Region

#Region " Variables "

        Protected _ControlType As DateTimePicker.Type = DateTimePicker.Type.Default
        Protected _IsRequired As Boolean = False
        Protected _DisplayName As String = ""
        Protected _FormSettingsLoaded As Boolean = False
        Protected _ErrorIconAlignment As System.Windows.Forms.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Protected _UserEntryChanged As Boolean = False
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _ReadOnly As Boolean = False
        Protected _SuspendedForLoading As Boolean = False
        Protected _OriginalInputButtonSettings As Hashtable = Nothing
        Protected _ShowingButtons As Boolean = False
        Protected _TabOnEnter As Boolean = True

#End Region

#Region " Properties "

        Public ReadOnly Property UserEntryChanged As Boolean Implements Interfaces.IUserEntryControl.UserEntryChanged
            Get
                UserEntryChanged = _UserEntryChanged
            End Get
        End Property
        Public WriteOnly Property ByPassUserEntryChanged As Boolean Implements Controls.Interfaces.IUserEntryControl.ByPassUserEntryChanged
            Set(ByVal value As Boolean)
                _ByPassUserEntryChanged = value
            End Set
        End Property
        Public WriteOnly Property SuspendedForLoading As Boolean Implements Controls.Interfaces.IUserEntryControl.SuspendedForLoading
            Set(value As Boolean)
                _SuspendedForLoading = value
            End Set
        End Property
        Public Property ControlType() As DateTimePicker.Type
            Get
                ControlType = _ControlType
            End Get
            Set(ByVal value As DateTimePicker.Type)
                _ControlType = value
                SetControlType()
            End Set
        End Property
        Public Property ErrorIconAlignment() As System.Windows.Forms.ErrorIconAlignment
            Get
                ErrorIconAlignment = _ErrorIconAlignment
            End Get
            Set(ByVal value As System.Windows.Forms.ErrorIconAlignment)
                _ErrorIconAlignment = value
            End Set
        End Property
        Public Property [ReadOnly] As Boolean
            Get
                [ReadOnly] = _ReadOnly
            End Get
            Set(ByVal value As Boolean)

                _ReadOnly = value

                Me.Enabled = Not _ReadOnly

                _ShowingButtons = True

                If _ReadOnly Then

                    Me.ButtonClear.Visible = False
                    Me.ButtonCustom.Visible = False
                    Me.ButtonCustom2.Visible = False
                    Me.ButtonDropDown.Visible = False
                    Me.ButtonFreeText.Visible = False

                Else

                    Me.ButtonClear.Visible = If(Me.ButtonClear IsNot Nothing, _OriginalInputButtonSettings(Me.ButtonClear.GetHashCode), False)
                    Me.ButtonCustom.Visible = If(Me.ButtonCustom IsNot Nothing, _OriginalInputButtonSettings(Me.ButtonCustom.GetHashCode), False)
                    Me.ButtonCustom2.Visible = If(Me.ButtonCustom2 IsNot Nothing, _OriginalInputButtonSettings(Me.ButtonCustom2.GetHashCode), False)
                    Me.ButtonDropDown.Visible = If(Me.ButtonDropDown IsNot Nothing, _OriginalInputButtonSettings(Me.ButtonDropDown.GetHashCode), False)
                    Me.ButtonFreeText.Visible = If(Me.ButtonFreeText IsNot Nothing, _OriginalInputButtonSettings(Me.ButtonFreeText.GetHashCode), False)

                End If

                _ShowingButtons = False

            End Set
        End Property
        Public Property DisplayName As String
            Get
                DisplayName = _DisplayName
            End Get
            Set(ByVal value As String)
                _DisplayName = value
            End Set
        End Property
        Public Property TabOnEnter() As Boolean
            Get
                TabOnEnter = _TabOnEnter
            End Get
            Set(ByVal value As Boolean)
                _TabOnEnter = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.Size = New System.Drawing.Size(75, 20)
            Me.AllowEmptyState = True
            Me.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.FocusHighlightEnabled = True
            Me.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.CustomFormat = ""
            Me.MinDate = #1/1/1900#
            Me.MaxDate = #6/6/2079#
            Me.FreeTextEntryMode = True
            Me.AutoResolveFreeTextEntries = False
            Me.FocusHighlightColor = System.Drawing.Color.FromArgb(255, 230, 141)
            Me.GetFreeTextBox.BackColor = System.Drawing.Color.FromArgb(255, 230, 141)
            Me.DisabledForeColor = System.Drawing.SystemColors.WindowText

            Me.DoubleBuffered = True

            _OriginalInputButtonSettings = New Hashtable

        End Sub
        Public Sub ClearChanged() Implements Interfaces.IUserEntryControl.ClearChanged

            _UserEntryChanged = False

        End Sub
        Protected Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form) Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl.LoadFormSettings

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.ErrorProvider.SetIconAlignment(Me, _ErrorIconAlignment)

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Public Sub SetPropertySettings(ByVal PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor), ByVal EnumProperty As [Enum], Optional ByVal CustomDisplayName As String = "")

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                PropertyDescriptor = PropertyDescriptorsList.SingleOrDefault(Function(PropDesc) PropDesc.Name.ToUpper = EnumProperty.ToString.ToUpper)

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            SetPropertySettings(PropertyDescriptor, CustomDisplayName)

        End Sub
        Public Sub SetPropertySettings(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, Optional ByVal CustomDisplayName As String = "")

            'objects
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            If PropertyDescriptor IsNot Nothing Then

                _DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(PropertyDescriptor.Name)

                Try

                    EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                Catch ex As Exception
                    EntityAttribute = Nothing
                Finally

                    If EntityAttribute IsNot Nothing Then

                        SetRequired(EntityAttribute.IsRequired)

                    End If

                End Try

            End If

            If CustomDisplayName <> "" Then

                _DisplayName = CustomDisplayName

            End If

        End Sub
        Public Sub SetPropertySettings(ByVal EnumProperty As [Enum], Optional ByVal CustomDisplayName As String = "")

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(System.ComponentModel.TypeDescriptor.GetReflectionType(EnumProperty.GetType).DeclaringType).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(PropDesc) PropDesc.Name.ToUpper = EnumProperty.ToString.ToUpper).SingleOrDefault

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            SetPropertySettings(PropertyDescriptor, CustomDisplayName)

        End Sub
        Public Sub SetRequired(ByVal IsRequired As Boolean)

            _IsRequired = IsRequired

            If _IsRequired AndAlso Me.BackgroundStyle IsNot Nothing Then

                Me.BackgroundStyle.BackColor = Drawing.Color.Cyan

            Else

                Me.BackgroundStyle.BackColor = Drawing.Color.White

            End If

        End Sub
        Protected Sub SetControlType()

            Select Case _ControlType

                Case DateTimePicker.Type.Default

                    Me.CustomFormat = ""
                    Me.Format = DevComponents.Editors.eDateTimePickerFormat.Short
                    Me.Value = Now
                    Me.ButtonDropDown.Visible = True
                    Me.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Auto
                    Me.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.System

                Case DateTimePicker.Type.TimeOnly

                    Me.CustomFormat = ""
                    Me.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
                    Me.Value = Now
                    Me.ButtonDropDown.Visible = False
                    Me.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector
                    Me.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time12H

                Case DateTimePicker.Type.ShortDate

                    Me.CustomFormat = ""
                    Me.Format = DevComponents.Editors.eDateTimePickerFormat.Short
                    Me.ButtonDropDown.Visible = True
                    Me.Value = Now
                    Me.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
                    Me.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.System

                Case DateTimePicker.Type.ShortDateAndTime

                    Me.CustomFormat = My.Application.Culture.DateTimeFormat.ShortDatePattern & " " & My.Application.Culture.DateTimeFormat.ShortTimePattern
                    Me.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
                    Me.ButtonDropDown.Visible = True
                    Me.Value = Now
                    Me.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both
                    Me.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time12H

            End Select

        End Sub
        Protected Sub OnFreeTextBoxEnter(ByVal sender As Object, ByVal e As System.EventArgs)

            If Me.Value <> Nothing Then

                If Me.ControlType = Type.TimeOnly Then

                    Me.GetFreeTextBox.Text = Me.Value.ToShortTimeString

                ElseIf Me.ControlType = DateTimePicker.Type.ShortDate OrElse Me.ControlType = Type.Default Then

                    Me.GetFreeTextBox.Text = Me.Value.ToShortDateString

                End If

            End If

        End Sub
        Protected Sub OnFreeTextBoxKeydown(sender As Object, e As Windows.Forms.KeyEventArgs)

            If _TabOnEnter Then

                If e.KeyCode = System.Windows.Forms.Keys.Enter AndAlso e.Shift = False Then

                    System.Windows.Forms.SendKeys.Send("{TAB}")
                    'below does not work
                    'Me.FindForm.SelectNextControl(Me, True, True, True, True)

                ElseIf e.KeyCode = System.Windows.Forms.Keys.Enter AndAlso e.Shift = True Then

                    Me.FindForm.SelectNextControl(Me, False, True, True, True)

                End If

            End If

            If e.KeyCode = System.Windows.Forms.Keys.Enter Then

                e.SuppressKeyPress = True

            End If

        End Sub
        Protected Friend Function Validate(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim Name As String = ""

            Try

                If _IsRequired Then

                    If Me.Text.Trim = "" OrElse Me.ValueObject Is Nothing Then

                        If _DisplayName <> "" Then

                            ErrorMessage = _DisplayName & " is required."

                        Else

                            Try

                                Name = AdvantageFramework.StringUtilities.GetNameAsWords(Me.Name.Substring(Me.Name.IndexOf("_") + 1))

                            Catch ex As Exception
                                Name = ""
                            End Try

                            ErrorMessage = Name & " is required."

                        End If

                        IsValid = False

                    End If

                End If

            Catch ex As Exception
                IsValid = False
            Finally
                Validate = IsValid
            End Try

        End Function
        Public Function GetValue() As Object

            Dim Value As Object = Nothing

            If Me.Value <> Nothing Then

                Try

                    Value = Convert.ToDateTime(Me.Value)

                Catch ex As Exception
                    Value = Nothing
                End Try

            End If

            GetValue = Value

        End Function
        Public Shadows Sub Show()

            Me.Visible = True

        End Sub
        Public Shadows Sub Hide()

            Me.Visible = False

        End Sub
        Private Sub InitializeComponent()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DateTimePicker
            '
            '
            '
            '
            Me.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.MonthCalendar.BackgroundStyle.Class = ""
            Me.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.MonthCalendar.CommandsBackgroundStyle.Class = ""
            Me.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.MonthCalendar.DisplayMonth = New Date(2012, 9, 1, 0, 0, 0, 0)
            Me.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.MonthCalendar.NavigationBackgroundStyle.Class = ""
            Me.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.Value = New Date(2012, 9, 1, 0, 0, 0, 0)
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Protected Overrides Sub OnInputButtonSettingsChanged(inputButtonSettings As DevComponents.Editors.InputButtonSettings)

            MyBase.OnInputButtonSettingsChanged(inputButtonSettings)

            If _ShowingButtons = False AndAlso inputButtonSettings.ItemReference IsNot Nothing Then

                _OriginalInputButtonSettings(inputButtonSettings.GetHashCode) = inputButtonSettings.Visible

            End If

        End Sub

#Region "  Control Event Handlers "

        Private Sub DateTimePicker_ConvertFreeTextEntry(ByVal sender As Object, ByVal e As DevComponents.Editors.FreeTextEntryConversionEventArgs) Handles Me.ConvertFreeTextEntry

            'objects
            Dim Text As String = ""
            Dim IsValidTime As Boolean = False

            If e.ValueEntered <> "" Then

                If Me.ControlType = DateTimePicker.Type.ShortDate OrElse Me.ControlType = Type.Default Then

                    Text = AdvantageFramework.DateUtilities.ConvertStringToShortDateString(e.ValueEntered)

                    If Text <> "" AndAlso IsDate(Text) Then

                        Me.Tag = Text
                        e.ControlValue = CDate(Text)
                        e.IsValueConverted = True

                    Else

                        Me.Tag = Nothing
                        e.ControlValue = Nothing
                        e.IsValueConverted = False

                        Me.IsPopupCalendarOpen = True
                        Me.Focus()
                        Me.MonthCalendar.Focus()

                    End If

                ElseIf Me.ControlType = DateTimePicker.Type.TimeOnly Then

                    Try

                        Text = DateAndTime.TimeValue(e.ValueEntered).ToShortTimeString

                        IsValidTime = True

                    Catch ex As Exception
                        IsValidTime = False
                    End Try

                    If Text <> "" AndAlso IsValidTime Then

                        Me.Tag = Text
                        e.ControlValue = CDate(Now.ToShortDateString & " " & Text)
                        e.IsValueConverted = True

                    Else

                        Me.Tag = Nothing
                        e.ControlValue = Nothing
                        e.IsValueConverted = False

                        Me.IsPopupCalendarOpen = True
                        Me.Focus()
                        Me.MonthCalendar.Focus()

                    End If

                ElseIf Me.ControlType = DateTimePicker.Type.ShortDateAndTime Then

                    Try

                        Text = DateAndTime.DateValue(e.ValueEntered).ToShortDateString & " " & DateAndTime.TimeValue(e.ValueEntered).ToShortTimeString

                        IsValidTime = True

                    Catch ex As Exception
                        IsValidTime = False
                    End Try

                    If Text <> "" AndAlso IsValidTime Then

                        Me.Tag = Text
                        e.ControlValue = CDate(Text)
                        e.IsValueConverted = True

                    Else

                        Me.Tag = Nothing
                        e.ControlValue = Nothing
                        e.IsValueConverted = False

                        Me.IsPopupCalendarOpen = True
                        Me.Focus()
                        Me.MonthCalendar.Focus()

                    End If

                End If

            End If

        End Sub
        Private Sub DateTimePicker_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated

            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings
            AddHandler Me.GetFreeTextBox.Enter, AddressOf OnFreeTextBoxEnter
            AddHandler Me.GetFreeTextBox.KeyDown, AddressOf OnFreeTextBoxKeydown

        End Sub
        Private Sub DateTimePicker_HandleDestroyed(sender As Object, e As EventArgs) Handles Me.HandleDestroyed

            'RemoveHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings
            RemoveHandler Me.GetFreeTextBox.Enter, AddressOf OnFreeTextBoxEnter
            RemoveHandler Me.GetFreeTextBox.KeyDown, AddressOf OnFreeTextBoxKeydown

            MyBase.Dispose()

        End Sub
        Private Sub DateTimePicker_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ValueChanged

            If Me.IsFreeTextEntryVisible AndAlso Me.ValueObject Is Nothing Then

                Me.Text = ""

            End If

            If _ByPassUserEntryChanged = False AndAlso _SuspendedForLoading = False Then

                _UserEntryChanged = True

                AdvantageFramework.WinForm.Presentation.Controls.UserEntryChanged(Me)

            End If

        End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
