Namespace Employee.Presentation

    Public Class TimesheetSelectDayDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _StartDate As Date = Nothing
        Private _EndDate As Date = Nothing
        Private _SelectedDates As Date() = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property StartDate As Date
            Get
                StartDate = _StartDate
            End Get
        End Property
        Private ReadOnly Property EndDate As Date
            Get
                EndDate = _EndDate
            End Get
        End Property
        Private ReadOnly Property SelectedDates As Date()
            Get
                SelectedDates = _SelectedDates
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal StartDate As Date, ByVal EndDate As Date, ByRef SelectedDates As Date())

            ' This call is required by the designer.
            InitializeComponent()

            _StartDate = StartDate
            _EndDate = EndDate
            _SelectedDates = SelectedDates

        End Sub
        Private Sub LoadCheckBoxes()

            'objects
            Dim CurrentDate As Date = Nothing
            Dim Checkbox As AdvantageFramework.WinForm.Presentation.Controls.CheckBox = Nothing
            Dim SubtractFromSize As Integer = Nothing

            CurrentDate = _StartDate

            While CurrentDate <= _EndDate

                If CurrentDate = _StartDate Then

                    Checkbox = CheckBoxForm_DayOne

                ElseIf CurrentDate = _StartDate.AddDays(1) Then

                    Checkbox = CheckBoxForm_DayTwo

                ElseIf CurrentDate = _StartDate.AddDays(2) Then

                    Checkbox = CheckBoxForm_DayThree

                ElseIf CurrentDate = _StartDate.AddDays(3) Then

                    Checkbox = CheckBoxForm_DayFour

                ElseIf CurrentDate = _StartDate.AddDays(4) Then

                    Checkbox = CheckBoxForm_DayFive

                ElseIf CurrentDate = _StartDate.AddDays(5) Then

                    Checkbox = CheckBoxForm_DaySix

                ElseIf CurrentDate = _StartDate.AddDays(6) Then

                    Checkbox = CheckBoxForm_DaySeven

                End If

                If Checkbox IsNot Nothing Then

                    Checkbox.Tag = CurrentDate
                    Checkbox.Text = CurrentDate.ToShortDateString & " (" & CurrentDate.DayOfWeek.ToString & ")"

                End If

                CurrentDate = CurrentDate.AddDays(1)

            End While

            For Each Checkbox In Me.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.CheckBox)()

                If Checkbox.Tag Is Nothing Then

                    Checkbox.Visible = False
                    SubtractFromSize = SubtractFromSize + 26

                End If

            Next

            Me.Size = New System.Drawing.Size(Me.Size.Width, Me.Size.Height - SubtractFromSize)

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal StartDate As Date, ByVal EndDate As Date, ByRef SelectedDates As Date()) As System.Windows.Forms.DialogResult

            'objects
            Dim TimesheetSelectDayDialog As AdvantageFramework.Employee.Presentation.TimesheetSelectDayDialog = Nothing

            TimesheetSelectDayDialog = New AdvantageFramework.Employee.Presentation.TimesheetSelectDayDialog(StartDate, EndDate, SelectedDates)

            ShowFormDialog = TimesheetSelectDayDialog.ShowDialog()

            StartDate = TimesheetSelectDayDialog.StartDate
            EndDate = TimesheetSelectDayDialog.EndDate
            SelectedDates = TimesheetSelectDayDialog.SelectedDates

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub TimesheetSelectDayDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Loaded As Boolean = True

            If _StartDate <> Nothing Then

                If _EndDate = Nothing OrElse _StartDate.AddDays(6) < _EndDate Then

                    _EndDate = _StartDate.AddDays(6)

                End If

                LoadCheckBoxes()

            Else

                Loaded = False

            End If

            If Loaded = False Then

                AdvantageFramework.Navigation.ShowMessageBox("Please select a valid start date!")
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Submit_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Copy.Click

            'objects
            Dim ErrorMessage As String = Nothing
            Dim SelectedDates As Generic.List(Of Date) = Nothing

            SelectedDates = New Generic.List(Of Date)

            For Each Checkbox In Me.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.CheckBox)()

                If Checkbox.Visible AndAlso Checkbox.Checked Then

                    SelectedDates.Add(Checkbox.Tag)

                End If

            Next

            If SelectedDates.Any = True Then

                _SelectedDates = SelectedDates.ToArray

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select at least one date.")

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