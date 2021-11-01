Namespace Employee.Presentation

    Public Class EmployeeTimesheetSubmitDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EmployeeCode As String = Nothing
        Private _StartDate As Date = Nothing
        Private _EndDate As Date = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
        End Property
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

#End Region

#Region " Methods "

        Private Sub New(ByVal EmployeeCode As String, ByVal StartDate As Date, ByVal EndDate As Date)

            ' This call is required by the designer.
            InitializeComponent()

            _EmployeeCode = EmployeeCode
            _StartDate = StartDate
            _EndDate = EndDate

        End Sub
        Private Sub SetApproval(ByVal Approve As Boolean)

            'objects
            Dim ErrorMessage As String = ""

            For Each DayStatus In DataGridViewForm_Approvals.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.EmployeeTimesheet.Classes.DayStatus)()

                If Approve Then

                    If AdvantageFramework.EmployeeTimesheet.CanSubmitTime(DayStatus.Status) Then

                        AdvantageFramework.EmployeeTimesheet.SubmitForApproval(Me.Session, _EmployeeCode, DayStatus.DayDate, True, True, ErrorMessage)

                    End If

                Else

                    If AdvantageFramework.EmployeeTimesheet.CanUnSubmitTime(DayStatus.Status) Then

                        AdvantageFramework.EmployeeTimesheet.SubmitForApproval(Me.Session, _EmployeeCode, DayStatus.DayDate, False, True, ErrorMessage)

                    End If

                End If

            Next

            If String.IsNullOrEmpty(ErrorMessage) = False Then

                AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

            End If

        End Sub
        Private Sub LoadApprovals()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewForm_Approvals.DataSource = (From Entity In AdvantageFramework.EmployeeTimesheet.LoadDaysByApprovalStatus(DbContext, _EmployeeCode, _StartDate, _EndDate, "").OfType(Of AdvantageFramework.EmployeeTimesheet.Classes.DayStatus)()
                                                         Order By Entity.DayDate Ascending
                                                         Select Entity).ToList

                DataGridViewForm_Approvals.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub EnableOrDisableActions()

            'objects
            Dim SubmitEnabled As Boolean = False
            Dim UnsubmitEnabled As Boolean = False
            Dim CommentsEnabled As Boolean = False
            Dim DayStatus As AdvantageFramework.EmployeeTimesheet.Classes.DayStatus = Nothing
            Dim SelectedRowCounter As Integer = 0

            If DataGridViewForm_Approvals.HasRows Then

                SubmitEnabled = True
                UnsubmitEnabled = True
                CommentsEnabled = True

                For Each DayStatus In DataGridViewForm_Approvals.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.EmployeeTimesheet.Classes.DayStatus)()

                    If AdvantageFramework.EmployeeTimesheet.CanSubmitTime(DayStatus.Status) = False Then

                        SubmitEnabled = False

                    End If

                    If AdvantageFramework.EmployeeTimesheet.CanUnSubmitTime(DayStatus.Status) = False Then

                        UnsubmitEnabled = False

                    End If

                    SelectedRowCounter = SelectedRowCounter + 1

                    If SelectedRowCounter = 1 AndAlso String.IsNullOrWhiteSpace(DayStatus.ApprovalNotes) = False Then

                        CommentsEnabled = True

                    Else

                        CommentsEnabled = False

                    End If

                Next

            End If

            ButtonItemActions_Submit.Enabled = SubmitEnabled
            ButtonItemActions_Unsubmit.Enabled = UnsubmitEnabled
            ButtonItemActions_Comments.Enabled = CommentsEnabled

        End Sub
        Private Function AreAllRowsSelected() As Boolean

            AreAllRowsSelected = (DataGridViewForm_Approvals.CurrentView.SelectedRowsCount = DataGridViewForm_Approvals.CurrentView.RowCount)

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal EmployeeCode As String, ByVal StartDate As Date, ByVal EndDate As Date) As System.Windows.Forms.DialogResult

            'objects
            Dim EmployeeTimesheetSubmitDialog As AdvantageFramework.Employee.Presentation.EmployeeTimesheetSubmitDialog = Nothing

            EmployeeTimesheetSubmitDialog = New AdvantageFramework.Employee.Presentation.EmployeeTimesheetSubmitDialog(EmployeeCode, StartDate, EndDate)

            ShowFormDialog = EmployeeTimesheetSubmitDialog.ShowDialog()

            EmployeeCode = EmployeeTimesheetSubmitDialog.EmployeeCode
            StartDate = EmployeeTimesheetSubmitDialog.StartDate
            EndDate = EmployeeTimesheetSubmitDialog.EndDate

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeTimesheetSubmitDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Loaded As Boolean = True

            DataGridViewForm_Approvals.MultiSelect = True
            DataGridViewForm_Approvals.OptionsView.ShowViewCaption = False

            ButtonItemActions_Comments.Image = AdvantageFramework.My.Resources.NotesImage
            ButtonItemActions_Submit.Image = AdvantageFramework.My.Resources.CheckImage
            ButtonItemActions_Unsubmit.Image = AdvantageFramework.My.Resources.ClearImage

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Session.UserCode)

                Try

                    If AdvantageFramework.Database.Procedures.EmployeeTime.LoadByEmployeeCodeAndDateRange(DbContext, _EmployeeCode, _StartDate, _EndDate).Any Then

                        LoadApprovals()

                    Else

                        Loaded = False

                    End If

                Catch ex As Exception

                End Try

            End Using

            If Loaded = False Then

                AdvantageFramework.Navigation.ShowMessageBox("Error loading employee information.")

                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Submit_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Submit.Click

            Me.ShowWaitForm()

            SetApproval(True)

            If AreAllRowsSelected() Then

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                LoadApprovals()

            End If

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemActions_Unsubmit_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Unsubmit.Click

            Me.ShowWaitForm()

            SetApproval(False)

            If AreAllRowsSelected() Then

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                LoadApprovals()

            End If

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemActions_Comments_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Comments.Click

            'objects
            Dim DayStatus As AdvantageFramework.EmployeeTimesheet.Classes.DayStatus = Nothing

            DayStatus = DataGridViewForm_Approvals.GetFirstSelectedRowDataBoundItem

            If DayStatus IsNot Nothing Then

                AdvantageFramework.WinForm.Presentation.TextBoxInputDialog.ShowFormDialog("Approval Comments", "Comments", DayStatus.ApprovalNotes, Nothing, Nothing, WinForm.Presentation.Controls.TextBox.Type.Default, False)

            End If

        End Sub
        Private Sub ButtonForm_Close_Click(sender As Object, e As System.EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_Approvals_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Approvals.DataSourceChangedEvent

            If DataGridViewForm_Approvals.CurrentView.Columns.Count > 0 Then

                For Each GridColumn In DataGridViewForm_Approvals.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                    If GridColumn.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.DayStatus.Properties.DayDate.ToString Then

                        GridColumn.OptionsColumn.AllowFocus = False

                    End If

                    GridColumn.OptionsColumn.AllowEdit = False

                Next

            End If

        End Sub
        Private Sub DataGridViewForm_Approvals_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Approvals.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace