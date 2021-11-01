Namespace WinForm.Presentation.Controls

    Public Class ScheduleControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl

        Public Event ScheduleChanged()

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum RepeatMinutes As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "5 Minutes")>
            FiveMinutes = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("10", "10 Minutes")>
            TenMinutes = 10
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("15", "15 Minutes")>
            FifteenMinutes = 15
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("20", "20 Minutes")>
            TwentyMinutes = 20
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("25", "25 Minutes")>
            TwentyFiveMinutes = 25
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("30", "30 Minutes")>
            HalfHour = 30
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("60", "1 Hour")>
            OneHour = 60
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("120", "2 Hours")>
            TwoHours = 120
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("180", "3 Hours")>
            ThreeHours = 180
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("240", "4 Hours")>
            FourHours = 240
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("300", "5 Hours")>
            FiveHours = 300
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("360", "6 Hours")>
            SixHours = 360
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("420", "7 Hours")>
            SevenHours = 420
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("480", "8 Hours")>
            EightHours = 480
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("540", "9 Hours")>
            NineHours = 540
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("600", "10 Hours")>
            TenHours = 600
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("660", "11 Hours")>
            ElevenHours = 660
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("720", "12 Hours")>
            TwelveHours = 720
        End Enum

#End Region

#Region " Variables "

        Protected _FormSettingsLoaded As Boolean = False
        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Protected _ReadOnly As Boolean = False
        Protected _UserEntryChanged As Boolean = False
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _SuspendedForLoading As Boolean = False

#End Region

#Region " Properties "

        Public Property [ReadOnly] As Boolean
            Get
                [ReadOnly] = _ReadOnly
            End Get
            Set(ByVal value As Boolean)
                _ReadOnly = value
                SetReadOnly()
            End Set
        End Property
        Public Shadows Property TabStop As Boolean
            Get
                TabStop = MyBase.TabStop
            End Get
            Set(ByVal value As Boolean)
                MyBase.TabStop = value
                SetTabStop()
            End Set
        End Property
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
        Public Sub LoadControl(Schedule As AdvantageFramework.Services.Classes.Schedule)

            DateTimePickerControl_RunAtTime.ButtonDropDown.Visible = True

            ComboBoxControl_RepeatEvery.DisplayName = "Repeat Every"
            ComboBoxControl_RepeatEvery.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(RepeatMinutes))

            DateTimePickerControl_RunAtTime.ValueObject = Schedule.RunAt

            If String.IsNullOrWhiteSpace(Schedule.Frequency) OrElse Schedule.Frequency = "Daily" Then

                RadioButtonFrequency_Daily.Checked = True

            ElseIf Schedule.Frequency = "Weekly" Then

                RadioButtonFrequency_Weekly.Checked = True

            End If

            CheckBoxFrequency_Sunday.Checked = Schedule.ProcessSunday
            CheckBoxFrequency_Monday.Checked = Schedule.ProcessMonday
            CheckBoxFrequency_Tuesday.Checked = Schedule.ProcessTuesday
            CheckBoxFrequency_Wednesday.Checked = Schedule.ProcessWednesday
            CheckBoxFrequency_Thursday.Checked = Schedule.ProcessThursday
            CheckBoxFrequency_Friday.Checked = Schedule.ProcessFriday
            CheckBoxFrequency_Saturday.Checked = Schedule.ProcessSaturday

            If String.IsNullOrWhiteSpace(Schedule.RepeatEvery) Then

                CheckBoxControl_RepeatEvery.Checked = False
                ComboBoxControl_RepeatEvery.Enabled = False

            Else

                CheckBoxControl_RepeatEvery.Checked = True
                ComboBoxControl_RepeatEvery.SelectedValue = Schedule.RepeatEvery
                ComboBoxControl_RepeatEvery.Enabled = True

            End If

            Me.ClearChanged()

        End Sub
        Public Function GetSettings() As AdvantageFramework.Services.Classes.Schedule

            Dim Schedule As AdvantageFramework.Services.Classes.Schedule = Nothing

            Schedule = New AdvantageFramework.Services.Classes.Schedule

            Schedule.RunAt = DateTimePickerControl_RunAtTime.GetValue

            If RadioButtonFrequency_Daily.Checked Then

                Schedule.Frequency = "Daily"

            ElseIf RadioButtonFrequency_Weekly.Checked Then

                Schedule.Frequency = "Weekly"

            End If

            Schedule.ProcessSunday = CheckBoxFrequency_Sunday.Checked
            Schedule.ProcessMonday = CheckBoxFrequency_Monday.Checked
            Schedule.ProcessTuesday = CheckBoxFrequency_Tuesday.Checked
            Schedule.ProcessWednesday = CheckBoxFrequency_Wednesday.Checked
            Schedule.ProcessThursday = CheckBoxFrequency_Thursday.Checked
            Schedule.ProcessFriday = CheckBoxFrequency_Friday.Checked
            Schedule.ProcessSaturday = CheckBoxFrequency_Saturday.Checked

            If CheckBoxControl_RepeatEvery.Checked Then

                Schedule.RepeatEvery = ComboBoxControl_RepeatEvery.GetSelectedValue

            End If

            GetSettings = Schedule

        End Function
        Public Sub ClearControl()

            DateTimePickerControl_RunAtTime.ValueObject = Nothing
            RadioButtonFrequency_Daily.Checked = True
            CheckBoxControl_RepeatEvery.Checked = False

        End Sub
        Protected Sub SetReadOnly()

            DateTimePickerControl_RunAtTime.ReadOnly = _ReadOnly
            GroupBoxControl_Frequency.Enabled = Not _ReadOnly
            CheckBoxControl_RepeatEvery.AutoCheck = Not _ReadOnly
            ComboBoxControl_RepeatEvery.ReadOnly = _ReadOnly

        End Sub
        Protected Sub SetTabStop()

            DateTimePickerControl_RunAtTime.TabStop = MyBase.TabStop
            GroupBoxControl_Frequency.TabStop = MyBase.TabStop
            CheckBoxControl_RepeatEvery.TabStop = MyBase.TabStop
            ComboBoxControl_RepeatEvery.ReadOnly = MyBase.TabStop

        End Sub
        Public Sub ClearChanged() Implements Interfaces.IUserEntryControl.ClearChanged

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me.GroupBoxControl_Frequency)
            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Private Sub EnableWeekdayCheckboxes(Enabled As Boolean)

            For Each CheckBox In GroupBoxControl_Frequency.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.CheckBox)

                CheckBox.Checked = Not Enabled
                CheckBox.Enabled = Enabled

            Next

        End Sub
        Private Sub CheckBoxFrequency_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

            RaiseEvent ScheduleChanged()

        End Sub

#Region "  Control Event Handlers "

        Private Sub ScheduleControl_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated

            AddHandler CheckBoxFrequency_Sunday.CheckedChangedEx, AddressOf CheckBoxFrequency_CheckedChangedEx
            AddHandler CheckBoxFrequency_Monday.CheckedChangedEx, AddressOf CheckBoxFrequency_CheckedChangedEx
            AddHandler CheckBoxFrequency_Tuesday.CheckedChangedEx, AddressOf CheckBoxFrequency_CheckedChangedEx
            AddHandler CheckBoxFrequency_Wednesday.CheckedChangedEx, AddressOf CheckBoxFrequency_CheckedChangedEx
            AddHandler CheckBoxFrequency_Thursday.CheckedChangedEx, AddressOf CheckBoxFrequency_CheckedChangedEx
            AddHandler CheckBoxFrequency_Friday.CheckedChangedEx, AddressOf CheckBoxFrequency_CheckedChangedEx
            AddHandler CheckBoxFrequency_Saturday.CheckedChangedEx, AddressOf CheckBoxFrequency_CheckedChangedEx

        End Sub
        Private Sub ScheduleControl_HandleDestroyed(sender As Object, e As EventArgs) Handles Me.HandleDestroyed

            RemoveHandler CheckBoxFrequency_Sunday.CheckedChangedEx, AddressOf CheckBoxFrequency_CheckedChangedEx
            RemoveHandler CheckBoxFrequency_Monday.CheckedChangedEx, AddressOf CheckBoxFrequency_CheckedChangedEx
            RemoveHandler CheckBoxFrequency_Tuesday.CheckedChangedEx, AddressOf CheckBoxFrequency_CheckedChangedEx
            RemoveHandler CheckBoxFrequency_Wednesday.CheckedChangedEx, AddressOf CheckBoxFrequency_CheckedChangedEx
            RemoveHandler CheckBoxFrequency_Thursday.CheckedChangedEx, AddressOf CheckBoxFrequency_CheckedChangedEx
            RemoveHandler CheckBoxFrequency_Friday.CheckedChangedEx, AddressOf CheckBoxFrequency_CheckedChangedEx
            RemoveHandler CheckBoxFrequency_Saturday.CheckedChangedEx, AddressOf CheckBoxFrequency_CheckedChangedEx

        End Sub
        Private Sub ScheduleControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub CheckBoxControl_RepeatEvery_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxControl_RepeatEvery.CheckedChangedEx

            ComboBoxControl_RepeatEvery.Enabled = e.NewChecked.Checked

            RaiseEvent ScheduleChanged()

        End Sub
        Private Sub ComboBoxControl_RepeatEvery_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxControl_RepeatEvery.SelectedValueChanged

            RaiseEvent ScheduleChanged()

        End Sub
        Private Sub DateTimePickerControl_RunAtTime_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerControl_RunAtTime.ValueChanged

            RaiseEvent ScheduleChanged()

        End Sub
        Private Sub RadioButtonFrequency_Daily_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonFrequency_Daily.CheckedChanged

            If RadioButtonFrequency_Daily.Checked Then

                EnableWeekdayCheckboxes(False)

            End If

            RaiseEvent ScheduleChanged()

        End Sub
        Private Sub RadioButtonFrequency_Weekly_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonFrequency_Weekly.CheckedChanged

            If RadioButtonFrequency_Weekly.Checked Then

                EnableWeekdayCheckboxes(True)

            End If

            RaiseEvent ScheduleChanged()

        End Sub

#End Region

#End Region

    End Class

End Namespace
