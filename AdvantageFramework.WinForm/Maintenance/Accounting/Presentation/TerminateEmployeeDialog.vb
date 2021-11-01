Namespace Maintenance.Accounting.Presentation

    Public Class TerminateEmployeeDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EmployeeCode As String = Nothing
        Private _IsTerminated As Boolean = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
        End Property
        Private ReadOnly Property IsTerminated As Boolean
            Get
                IsTerminated = _IsTerminated
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef EmployeeCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _EmployeeCode = EmployeeCode

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef EmployeeCode As String) As System.Windows.Forms.DialogResult

            'objects
            Dim TerminateEmployeeDialog As AdvantageFramework.Maintenance.Accounting.Presentation.TerminateEmployeeDialog = Nothing

            TerminateEmployeeDialog = New AdvantageFramework.Maintenance.Accounting.Presentation.TerminateEmployeeDialog(EmployeeCode)

            ShowFormDialog = TerminateEmployeeDialog.ShowDialog()

            EmployeeCode = TerminateEmployeeDialog.EmployeeCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub TerminateEmployeeDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ' objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _EmployeeCode <> "" Then

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                    If Employee IsNot Nothing Then

                        ButtonForm_OK.Enabled = True

                        LabelForm_EmployeeName.Text = Employee.FirstName & " " & Employee.MiddleInitial & " " & Employee.LastName

                        If Employee.TerminationDate IsNot Nothing Then

                            _IsTerminated = True
                            CheckBoxForm_RemoveSecuritySettings.Visible = False
                            DateTimePickerForm_TerminationDate.ValueObject = Nothing
                            LabelForm_UnTerminate.Visible = True

                        Else

                            LabelForm_UnTerminate.Visible = False
                            DateTimePickerForm_TerminationDate.ValueObject = System.DateTime.Today
                            DateTimePickerForm_TerminationDate.SetRequired(True)
                            CheckBoxForm_RemoveSecuritySettings.Checked = True
                            CheckBoxForm_RemoveSecuritySettings.Visible = True

                        End If

                    Else

                        ButtonForm_OK.Enabled = False

                        AdvantageFramework.WinForm.MessageBox.Show("The employee you are trying to teminate does not exist.", WinForm.MessageBox.MessageBoxButtons.OK)

                    End If

                Else

                    ButtonForm_OK.Enabled = False

                    AdvantageFramework.WinForm.MessageBox.Show("The employee you are trying to teminate does not exist.", WinForm.MessageBox.MessageBoxButtons.OK)

                End If

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim RemoveSecuritySettings As Boolean = Nothing
            Dim ErrorText As String = ""

            If Me.Validator Then

                Me.ShowWaitForm("Terminating...")

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                        If Employee IsNot Nothing Then

                            If _IsTerminated Then

                                RemoveSecuritySettings = False
                                Employee.TerminationDate = DateTimePickerForm_TerminationDate.ValueObject

                            Else

                                RemoveSecuritySettings = CheckBoxForm_RemoveSecuritySettings.Checked
                                Employee.TerminationDate = DateTimePickerForm_TerminationDate.ValueObject

                            End If

                            If AdvantageFramework.Database.Procedures.EmployeeView.Terminate(DbContext, DataContext, Employee, RemoveSecuritySettings, ErrorText) Then

                                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                Me.Close()

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show(ErrorText)

                            End If

                        End If

                    End Using

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DateTimePickerForm_TerminationDate_ValueObjectChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerForm_TerminationDate.ValueObjectChanged

            If _IsTerminated Then

                If DateTimePickerForm_TerminationDate.ValueObject = Nothing Then

                    LabelForm_UnTerminate.Visible = True

                Else

                    LabelForm_UnTerminate.Visible = False

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace