Namespace Employee.Presentation

    Public Class TimesheetSearchDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DateToSelect As Date = Nothing
        Private _EmployeeCode As String = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property DateToSelect As Date
            Get
                DateToSelect = _DateToSelect
            End Get
        End Property
        Public ReadOnly Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal EmployeeCode As String, ByRef DateToSelect As Date)

            ' This call is required by the designer.
            InitializeComponent()

            _EmployeeCode = EmployeeCode
            _DateToSelect = DateToSelect

        End Sub
        Private Sub LoadTime()

            'objects
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing

            If String.IsNullOrEmpty(_EmployeeCode) = False Then

                StartDate = DateTimePickerSearch_From.Value.Date
                EndDate = DateTimePickerSearch_To.Value.Date

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewForm_Time.DataSource = AdvantageFramework.EmployeeTimesheet.LoadDaysByApprovalStatus(DbContext, _EmployeeCode, StartDate, EndDate, ComboBox_ShowTime.ComboBoxEx.SelectedValue)
                    DataGridViewForm_Time.CurrentView.BestFitColumns()

                End Using

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            'objects
            Dim DayApprovalType As AdvantageFramework.EmployeeTimesheet.DayApprovalType = Nothing

            If DataGridViewForm_Time.HasOnlyOneSelectedRow Then

                DayApprovalType = CInt(DataGridViewForm_Time.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.DayStatus.Properties.Status.ToString))

                ButtonItemActions_Open.Enabled = True
                ButtonItemActions_Submit.Enabled = AdvantageFramework.EmployeeTimesheet.CanSubmitTime(DayApprovalType)
                ButtonItemActions_Unsubmit.Enabled = AdvantageFramework.EmployeeTimesheet.CanUnSubmitTime(DayApprovalType)

            Else

                ButtonItemActions_Open.Enabled = False
                ButtonItemActions_Submit.Enabled = False
                ButtonItemActions_Unsubmit.Enabled = False

            End If

        End Sub

        Private Sub LoadStatus()

            Try

                ComboBox_ShowTime.ComboBoxEx.DisplayMember = "Code"
                ComboBox_ShowTime.ComboBoxEx.ValueMember = "Name"

                With Me.ComboBox_ShowTime.Items

                    .Add(New DevComponents.DotNetBar.ComboBoxItem(CType(AdvantageFramework.Timesheet.TimesheetApprovalType.AllTime, Integer).ToString(), "All Time"))

                    Dim m As New AdvantageFramework.Timesheet.TimesheetSettings(Me.Session.ConnectionString, Me.Session.UserCode)

                    If m.IsApprovalActive(_EmployeeCode) = True Then

                        .Add(New DevComponents.DotNetBar.ComboBoxItem(CType(AdvantageFramework.Timesheet.TimesheetApprovalType.NotSubmitted, Integer).ToString(), "Not Submitted"))
                        .Add(New DevComponents.DotNetBar.ComboBoxItem(CType(AdvantageFramework.Timesheet.TimesheetApprovalType.Pending, Integer).ToString(), "Pending Approval"))
                        .Add(New DevComponents.DotNetBar.ComboBoxItem(CType(AdvantageFramework.Timesheet.TimesheetApprovalType.Denied, Integer).ToString(), "Denied"))
                        .Add(New DevComponents.DotNetBar.ComboBoxItem(CType(AdvantageFramework.Timesheet.TimesheetApprovalType.Approved, Integer).ToString(), "Approved"))

                    Else

                        .Add(New DevComponents.DotNetBar.ComboBoxItem(CType(AdvantageFramework.Timesheet.TimesheetApprovalType.Entered, Integer).ToString(), "Entered"))

                    End If

                    .Add(New DevComponents.DotNetBar.ComboBoxItem(CType(AdvantageFramework.Timesheet.TimesheetApprovalType.Missing, Integer).ToString(), "Missing"))

                End With

            Catch ex As Exception



            End Try




        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal EmployeeCode As String, Optional ByRef DateToSelect As Date = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim TimesheetSearchDialog As AdvantageFramework.Employee.Presentation.TimesheetSearchDialog = Nothing

            TimesheetSearchDialog = New AdvantageFramework.Employee.Presentation.TimesheetSearchDialog(EmployeeCode, DateToSelect)

            ShowFormDialog = TimesheetSearchDialog.ShowDialog()

            DateToSelect = TimesheetSearchDialog.DateToSelect

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub TimesheetSearchDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Loaded As Boolean = True
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim TimeList As String() = Nothing

            DateTimePickerSearch_From.ByPassUserEntryChanged = True
            DateTimePickerSearch_To.ByPassUserEntryChanged = True

            ButtonItemSearch_Search.Image = AdvantageFramework.My.Resources.DashboardAndQueryImage
            ButtonItemActions_Submit.Image = AdvantageFramework.My.Resources.CheckImage
            ButtonItemActions_Unsubmit.Image = AdvantageFramework.My.Resources.UndoImage
            ButtonItemActions_Open.Image = AdvantageFramework.My.Resources.RevisionImage

            DataGridViewForm_Time.MultiSelect = False
            DataGridViewForm_Time.AutoUpdateViewCaption = False

            DateTimePickerSearch_From.Value = System.DateTime.Today.AddDays(-29)
            DateTimePickerSearch_To.Value = System.DateTime.Today

            LoadStatus()

            'ComboBox_ShowTime.DataSource = (From Entity In TimeList
            '                                Select [Code] = [Enum].GetName(GetType(System.DayOfWeek), Entity).ToLower.Substring(0, 3),
            '                                       [Description] = [Enum].GetName(GetType(System.DayOfWeek), Entity)).ToList

            If String.IsNullOrEmpty(EmployeeCode) = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                    If Employee IsNot Nothing Then

                        DataGridViewForm_Time.CurrentView.ViewCaption = "Time for " & Employee.ToString()
                        DataGridViewForm_Time.DataSource = New Generic.List(Of AdvantageFramework.EmployeeTimesheet.Classes.DayStatus)

                    Else

                        Loaded = False

                    End If

                End Using

            Else

                Loaded = False

            End If

            If Loaded = False Then

                AdvantageFramework.Navigation.ShowMessageBox("There was a problem loading details for the selected employee.")

                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Open_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Open.Click

            If DataGridViewForm_Time.HasOnlyOneSelectedRow Then

                _DateToSelect = CDate(DataGridViewForm_Time.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.DayStatus.Properties.DayDate.ToString))

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                AdvantageFramework.Navigation.ShowMessageBox("Please select a day.")

            End If

        End Sub
        Private Sub ButtonItemSearch_Search_Click(sender As Object, e As System.EventArgs) Handles ButtonItemSearch_Search.Click

            'objects
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim ErrorMessage As String = Nothing

            If DateTimePickerSearch_From.ValueObject IsNot Nothing AndAlso DateTimePickerSearch_To.ValueObject IsNot Nothing Then

                StartDate = DateTimePickerSearch_From.Value
                EndDate = DateTimePickerSearch_To.ValueObject

                If StartDate < EndDate Then

                    LoadTime()

                Else

                    ErrorMessage = "Please select a valid start & end date."

                End If

            Else

                ErrorMessage = "Please select a valid start & end date."

            End If

            If String.IsNullOrEmpty(ErrorMessage) = False Then

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_Time_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Time.DataSourceChangedEvent

            If DataGridViewForm_Time.Columns.Count > 0 Then

                If DataGridViewForm_Time.Columns(AdvantageFramework.EmployeeTimesheet.Classes.DayStatus.Properties.PercentOfStandardHours.ToString) IsNot Nothing Then

                    DataGridViewForm_Time.Columns(AdvantageFramework.EmployeeTimesheet.Classes.DayStatus.Properties.PercentOfStandardHours.ToString).Visible = True
                    DataGridViewForm_Time.Columns(AdvantageFramework.EmployeeTimesheet.Classes.DayStatus.Properties.PercentOfStandardHours.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    DataGridViewForm_Time.Columns(AdvantageFramework.EmployeeTimesheet.Classes.DayStatus.Properties.PercentOfStandardHours.ToString).DisplayFormat.FormatString = "P"

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Time_RowDoubleClickEvent() Handles DataGridViewForm_Time.RowDoubleClickEvent

            If DataGridViewForm_Time.HasOnlyOneSelectedRow Then

                ButtonItemActions_Open.RaiseClick()

            End If

        End Sub
        Private Sub DataGridViewForm_Time_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Time.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Submit_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Submit.Click

            'objects
            Dim SelectedDate As Date = Nothing
            Dim ErrorMessage As String = Nothing

            If DataGridViewForm_Time.HasOnlyOneSelectedRow Then

                SelectedDate = DataGridViewForm_Time.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.DayStatus.Properties.DayDate.ToString)

                If SelectedDate <> Nothing Then

                    If AdvantageFramework.EmployeeTimesheet.SubmitForApproval(Me.Session, _EmployeeCode, SelectedDate, True, True, ErrorMessage) Then

                        LoadTime()
                        EnableOrDisableActions()

                    End If

                End If

            Else

                ErrorMessage = "Please select a time record to submit."

            End If

            If String.IsNullOrEmpty(ErrorMessage) = False Then

                AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Unsubmit_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Unsubmit.Click

            'objects
            Dim SelectedDate As Date = Nothing
            Dim ErrorMessage As String = Nothing

            If DataGridViewForm_Time.HasOnlyOneSelectedRow Then

                SelectedDate = DataGridViewForm_Time.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.DayStatus.Properties.DayDate.ToString)

                If SelectedDate <> Nothing Then

                    If AdvantageFramework.EmployeeTimesheet.SubmitForApproval(Me.Session, _EmployeeCode, SelectedDate, False, True, ErrorMessage) Then

                        LoadTime()
                        EnableOrDisableActions()

                    End If

                End If

            Else

                ErrorMessage = "Please select a time record to unsubmit."

            End If

            If String.IsNullOrEmpty(ErrorMessage) = False Then

                AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace