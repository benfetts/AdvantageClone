Namespace Maintenance.ProjectManagement.Presentation

    Public Class UserDefinedValueSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedLabelTable As AdvantageFramework.Database.Entities.UserDefinedLabelTables = Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV1
        Private _UserDefinedLabel As AdvantageFramework.Database.Entities.UserDefinedLabel = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property UserDefinedLabelTable As AdvantageFramework.Database.Entities.UserDefinedLabelTables
            Get
                UserDefinedLabelTable = _UserDefinedLabelTable
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal UserDefinedLabelTable As AdvantageFramework.Database.Entities.UserDefinedLabelTables)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _UserDefinedLabelTable = UserDefinedLabelTable

        End Sub
        Private Sub LoadGrid()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV1 Then

                    DataGridViewForm_UserDefinedValues.DataSource = (From UserDefinedValue In AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue1.Load(DbContext)
                                                                     Select UserDefinedValue
                                                                     Order By UserDefinedValue.Code,
                                                                              UserDefinedValue.Description).ToList

                ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV2 Then

                    DataGridViewForm_UserDefinedValues.DataSource = (From UserDefinedValue In AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue2.Load(DbContext)
                                                                     Select UserDefinedValue
                                                                     Order By UserDefinedValue.Code,
                                                                              UserDefinedValue.Description).ToList

                ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV3 Then

                    DataGridViewForm_UserDefinedValues.DataSource = (From UserDefinedValue In AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue3.Load(DbContext)
                                                                     Select UserDefinedValue
                                                                     Order By UserDefinedValue.Code,
                                                                              UserDefinedValue.Description).ToList

                ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV4 Then

                    DataGridViewForm_UserDefinedValues.DataSource = (From UserDefinedValue In AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue4.Load(DbContext)
                                                                     Select UserDefinedValue
                                                                     Order By UserDefinedValue.Code,
                                                                              UserDefinedValue.Description).ToList

                ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV5 Then

                    DataGridViewForm_UserDefinedValues.DataSource = (From UserDefinedValue In AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue5.Load(DbContext)
                                                                     Select UserDefinedValue
                                                                     Order By UserDefinedValue.Code,
                                                                              UserDefinedValue.Description).ToList

                ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV1 Then

                    DataGridViewForm_UserDefinedValues.DataSource = (From UserDefinedValue In AdvantageFramework.Database.Procedures.JobUserDefinedValue1.Load(DbContext)
                                                                     Select UserDefinedValue
                                                                     Order By UserDefinedValue.Code,
                                                                              UserDefinedValue.Description).ToList

                ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV2 Then

                    DataGridViewForm_UserDefinedValues.DataSource = (From UserDefinedValue In AdvantageFramework.Database.Procedures.JobUserDefinedValue2.Load(DbContext)
                                                                     Select UserDefinedValue
                                                                     Order By UserDefinedValue.Code,
                                                                              UserDefinedValue.Description).ToList

                ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV3 Then

                    DataGridViewForm_UserDefinedValues.DataSource = (From UserDefinedValue In AdvantageFramework.Database.Procedures.JobUserDefinedValue3.Load(DbContext)
                                                                     Select UserDefinedValue
                                                                     Order By UserDefinedValue.Code,
                                                                              UserDefinedValue.Description).ToList

                ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV4 Then

                    DataGridViewForm_UserDefinedValues.DataSource = (From UserDefinedValue In AdvantageFramework.Database.Procedures.JobUserDefinedValue4.Load(DbContext)
                                                                     Select UserDefinedValue
                                                                     Order By UserDefinedValue.Code,
                                                                              UserDefinedValue.Description).ToList

                ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV5 Then

                    DataGridViewForm_UserDefinedValues.DataSource = (From UserDefinedValue In AdvantageFramework.Database.Procedures.JobUserDefinedValue5.Load(DbContext)
                                                                     Select UserDefinedValue
                                                                     Order By UserDefinedValue.Code,
                                                                              UserDefinedValue.Description).ToList

                End If

            End Using

            DataGridViewForm_UserDefinedValues.CurrentView.BestFitColumns()

        End Sub
        Private Sub AddNewRowEventJobComponentUserDefinedValue1(ByVal JobComponentUserDefinedValue1 As AdvantageFramework.Database.Entities.JobComponentUserDefinedValue1)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If JobComponentUserDefinedValue1.IsEntityBeingAdded() Then

                    JobComponentUserDefinedValue1.DbContext = DbContext

                    AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue1.Insert(DbContext, JobComponentUserDefinedValue1)

                End If

            End Using

        End Sub
        Private Sub AddNewRowEventJobComponentUserDefinedValue2(ByVal JobComponentUserDefinedValue2 As AdvantageFramework.Database.Entities.JobComponentUserDefinedValue2)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If JobComponentUserDefinedValue2.IsEntityBeingAdded() Then

                    JobComponentUserDefinedValue2.DbContext = DbContext

                    AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue2.Insert(DbContext, JobComponentUserDefinedValue2)

                End If

            End Using

        End Sub
        Private Sub AddNewRowEventJobComponentUserDefinedValue3(ByVal JobComponentUserDefinedValue3 As AdvantageFramework.Database.Entities.JobComponentUserDefinedValue3)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If JobComponentUserDefinedValue3.IsEntityBeingAdded() Then

                    JobComponentUserDefinedValue3.DbContext = DbContext

                    AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue3.Insert(DbContext, JobComponentUserDefinedValue3)

                End If

            End Using

        End Sub
        Private Sub AddNewRowEventJobComponentUserDefinedValue4(ByVal JobComponentUserDefinedValue4 As AdvantageFramework.Database.Entities.JobComponentUserDefinedValue4)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If JobComponentUserDefinedValue4.IsEntityBeingAdded() Then

                    JobComponentUserDefinedValue4.DbContext = DbContext

                    AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue4.Insert(DbContext, JobComponentUserDefinedValue4)

                End If

            End Using

        End Sub
        Private Sub AddNewRowEventJobComponentUserDefinedValue5(ByVal JobComponentUserDefinedValue5 As AdvantageFramework.Database.Entities.JobComponentUserDefinedValue5)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If JobComponentUserDefinedValue5.IsEntityBeingAdded() Then

                    JobComponentUserDefinedValue5.DbContext = DbContext

                    AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue5.Insert(DbContext, JobComponentUserDefinedValue5)

                End If

            End Using

        End Sub
        Private Sub AddNewRowEventJobUserDefinedValue1(ByVal JobUserDefinedValue1 As AdvantageFramework.Database.Entities.JobUserDefinedValue1)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If JobUserDefinedValue1.IsEntityBeingAdded() Then

                    JobUserDefinedValue1.DbContext = DbContext

                    JobUserDefinedValue1.IsInactive = 0

                    AdvantageFramework.Database.Procedures.JobUserDefinedValue1.Insert(DbContext, JobUserDefinedValue1)

                End If

            End Using

        End Sub
        Private Sub AddNewRowEventJobUserDefinedValue2(ByVal JobUserDefinedValue2 As AdvantageFramework.Database.Entities.JobUserDefinedValue2)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If JobUserDefinedValue2.IsEntityBeingAdded() Then

                    JobUserDefinedValue2.DbContext = DbContext

                    AdvantageFramework.Database.Procedures.JobUserDefinedValue2.Insert(DbContext, JobUserDefinedValue2)

                End If

            End Using

        End Sub
        Private Sub AddNewRowEventJobUserDefinedValue3(ByVal JobUserDefinedValue3 As AdvantageFramework.Database.Entities.JobUserDefinedValue3)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If JobUserDefinedValue3.IsEntityBeingAdded() Then

                    JobUserDefinedValue3.DbContext = DbContext

                    AdvantageFramework.Database.Procedures.JobUserDefinedValue3.Insert(DbContext, JobUserDefinedValue3)

                End If

            End Using

        End Sub
        Private Sub AddNewRowEventJobUserDefinedValue4(ByVal JobUserDefinedValue4 As AdvantageFramework.Database.Entities.JobUserDefinedValue4)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If JobUserDefinedValue4.IsEntityBeingAdded() Then

                    JobUserDefinedValue4.DbContext = DbContext

                    AdvantageFramework.Database.Procedures.JobUserDefinedValue4.Insert(DbContext, JobUserDefinedValue4)

                End If

            End Using

        End Sub
        Private Sub AddNewRowEventJobUserDefinedValue5(ByVal JobUserDefinedValue5 As AdvantageFramework.Database.Entities.JobUserDefinedValue5)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If JobUserDefinedValue5.IsEntityBeingAdded() Then

                    JobUserDefinedValue5.DbContext = DbContext

                    AdvantageFramework.Database.Procedures.JobUserDefinedValue5.Insert(DbContext, JobUserDefinedValue5)

                End If

            End Using

        End Sub
        Private Sub UpdateJobComponentUserDefinedValue1Inactive(ByRef Saved As Boolean, ByVal JobComponentUserDefinedValue1 As AdvantageFramework.Database.Entities.JobComponentUserDefinedValue1, ByVal Value As Object)

            If JobComponentUserDefinedValue1 IsNot Nothing Then

                Try

                    JobComponentUserDefinedValue1.IsInactive = Convert.ToInt16(Value)

                Catch ex As Exception
                    JobComponentUserDefinedValue1.IsInactive = JobComponentUserDefinedValue1.IsInactive
                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Saved = AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue1.Update(DbContext, JobComponentUserDefinedValue1)

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            End If

        End Sub
        Private Sub UpdateJobComponentUserDefinedValue2Inactive(ByRef Saved As Boolean, ByVal JobComponentUserDefinedValue2 As AdvantageFramework.Database.Entities.JobComponentUserDefinedValue2, ByVal Value As Object)

            If JobComponentUserDefinedValue2 IsNot Nothing Then

                Try

                    JobComponentUserDefinedValue2.IsInactive = Convert.ToInt16(Value)

                Catch ex As Exception
                    JobComponentUserDefinedValue2.IsInactive = JobComponentUserDefinedValue2.IsInactive
                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Saved = AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue2.Update(DbContext, JobComponentUserDefinedValue2)

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            End If

        End Sub
        Private Sub UpdateJobComponentUserDefinedValue3Inactive(ByRef Saved As Boolean, ByVal JobComponentUserDefinedValue3 As AdvantageFramework.Database.Entities.JobComponentUserDefinedValue3, ByVal Value As Object)

            If JobComponentUserDefinedValue3 IsNot Nothing Then

                Try

                    JobComponentUserDefinedValue3.IsInactive = Convert.ToInt16(Value)

                Catch ex As Exception
                    JobComponentUserDefinedValue3.IsInactive = JobComponentUserDefinedValue3.IsInactive
                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Saved = AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue3.Update(DbContext, JobComponentUserDefinedValue3)

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            End If

        End Sub
        Private Sub UpdateJobComponentUserDefinedValue4Inactive(ByRef Saved As Boolean, ByVal JobComponentUserDefinedValue4 As AdvantageFramework.Database.Entities.JobComponentUserDefinedValue4, ByVal Value As Object)

            If JobComponentUserDefinedValue4 IsNot Nothing Then

                Try

                    JobComponentUserDefinedValue4.IsInactive = Convert.ToInt16(Value)

                Catch ex As Exception
                    JobComponentUserDefinedValue4.IsInactive = JobComponentUserDefinedValue4.IsInactive
                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Saved = AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue4.Update(DbContext, JobComponentUserDefinedValue4)

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            End If

        End Sub
        Private Sub UpdateJobComponentUserDefinedValue5Inactive(ByRef Saved As Boolean, ByVal JobComponentUserDefinedValue5 As AdvantageFramework.Database.Entities.JobComponentUserDefinedValue5, ByVal Value As Object)

            If JobComponentUserDefinedValue5 IsNot Nothing Then

                Try

                    JobComponentUserDefinedValue5.IsInactive = Convert.ToInt16(Value)

                Catch ex As Exception
                    JobComponentUserDefinedValue5.IsInactive = JobComponentUserDefinedValue5.IsInactive
                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Saved = AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue5.Update(DbContext, JobComponentUserDefinedValue5)

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            End If

        End Sub
        Private Sub UpdateJobUserDefinedValue1Inactive(ByRef Saved As Boolean, ByVal JobUserDefinedValue1 As AdvantageFramework.Database.Entities.JobUserDefinedValue1, ByVal Value As Object)

            If JobUserDefinedValue1 IsNot Nothing Then

                Try

                    JobUserDefinedValue1.IsInactive = Convert.ToInt16(Value)

                Catch ex As Exception
                    JobUserDefinedValue1.IsInactive = JobUserDefinedValue1.IsInactive
                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Saved = AdvantageFramework.Database.Procedures.JobUserDefinedValue1.Update(DbContext, JobUserDefinedValue1)

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            End If

        End Sub
        Private Sub UpdateJobUserDefinedValue2Inactive(ByRef Saved As Boolean, ByVal JobUserDefinedValue2 As AdvantageFramework.Database.Entities.JobUserDefinedValue2, ByVal Value As Object)

            If JobUserDefinedValue2 IsNot Nothing Then

                Try

                    JobUserDefinedValue2.IsInactive = Convert.ToInt16(Value)

                Catch ex As Exception
                    JobUserDefinedValue2.IsInactive = JobUserDefinedValue2.IsInactive
                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Saved = AdvantageFramework.Database.Procedures.JobUserDefinedValue2.Update(DbContext, JobUserDefinedValue2)

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            End If

        End Sub
        Private Sub UpdateJobUserDefinedValue3Inactive(ByRef Saved As Boolean, ByVal JobUserDefinedValue3 As AdvantageFramework.Database.Entities.JobUserDefinedValue3, ByVal Value As Object)

            If JobUserDefinedValue3 IsNot Nothing Then

                Try

                    JobUserDefinedValue3.IsInactive = Convert.ToInt16(Value)

                Catch ex As Exception
                    JobUserDefinedValue3.IsInactive = JobUserDefinedValue3.IsInactive
                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Saved = AdvantageFramework.Database.Procedures.JobUserDefinedValue3.Update(DbContext, JobUserDefinedValue3)

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            End If

        End Sub
        Private Sub UpdateJobUserDefinedValue4Inactive(ByRef Saved As Boolean, ByVal JobUserDefinedValue4 As AdvantageFramework.Database.Entities.JobUserDefinedValue4, ByVal Value As Object)

            If JobUserDefinedValue4 IsNot Nothing Then

                Try

                    JobUserDefinedValue4.IsInactive = Convert.ToInt16(Value)

                Catch ex As Exception
                    JobUserDefinedValue4.IsInactive = JobUserDefinedValue4.IsInactive
                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Saved = AdvantageFramework.Database.Procedures.JobUserDefinedValue4.Update(DbContext, JobUserDefinedValue4)

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            End If

        End Sub
        Private Sub UpdateJobUserDefinedValue5Inactive(ByRef Saved As Boolean, ByVal JobUserDefinedValue5 As AdvantageFramework.Database.Entities.JobUserDefinedValue5, ByVal Value As Object)

            If JobUserDefinedValue5 IsNot Nothing Then

                Try

                    JobUserDefinedValue5.IsInactive = Convert.ToInt16(Value)

                Catch ex As Exception
                    JobUserDefinedValue5.IsInactive = JobUserDefinedValue5.IsInactive
                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Saved = AdvantageFramework.Database.Procedures.JobUserDefinedValue5.Update(DbContext, JobUserDefinedValue5)

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_UserDefinedValues.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_UserDefinedValues.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm(ByVal UserDefinedLabelTable As AdvantageFramework.Database.Entities.UserDefinedLabelTables)

            'objects
            Dim UserDefinedValueSetupForm As AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm = Nothing

            UserDefinedValueSetupForm = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm(UserDefinedLabelTable)

            UserDefinedValueSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub UserDefinedValueSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            CheckBoxForm_UseLookup.ByPassUserEntryChanged = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                TextBoxForm_Label.SetPropertySettings(AdvantageFramework.Database.Entities.UserDefinedLabel.Properties.Label)

                _UserDefinedLabel = AdvantageFramework.Database.Procedures.UserDefinedLabel.LoadByUserDefinedLabelTable(DbContext, _UserDefinedLabelTable.ToString)

                If _UserDefinedLabel IsNot Nothing Then

                    TextBoxForm_Label.Text = _UserDefinedLabel.Label
                    CheckBoxForm_UseLookup.Checked = Not _UserDefinedLabel.IsEditable.GetValueOrDefault(True)

                Else

                    _UserDefinedLabel = New AdvantageFramework.Database.Entities.UserDefinedLabel

                    _UserDefinedLabel.DbContext = DbContext
                    _UserDefinedLabel.AssociatedTable = _UserDefinedLabelTable.ToString
                    _UserDefinedLabel.Label = Nothing
                    _UserDefinedLabel.IsEditable = Not CheckBoxForm_UseLookup.Checked
                    _UserDefinedLabel.ValidationRule = Nothing

                    AdvantageFramework.Database.Procedures.UserDefinedLabel.Insert(DbContext, _UserDefinedLabel)

                End If

                If _UserDefinedLabel.Label Is Nothing OrElse _UserDefinedLabel.Label = "" Then

                    If _UserDefinedLabelTable.ToString.Contains("JOB_CMP") Then

                        Me.Text = "Job Component Custom " & AdvantageFramework.StringUtilities.RemoveAllNonNumeric(_UserDefinedLabelTable.ToString) & " Maintenance"

                    Else

                        Me.Text = "Job Custom " & AdvantageFramework.StringUtilities.RemoveAllNonNumeric(_UserDefinedLabelTable.ToString) & " Maintenance"

                    End If

                Else

                    Me.Text = _UserDefinedLabel.Label & " Maintenance"

                End If

                DataGridViewForm_UserDefinedValues.Enabled = CheckBoxForm_UseLookup.Checked

                If CheckBoxForm_UseLookup.Checked Then

                    LoadGrid()

                Else

                    DataGridViewForm_UserDefinedValues.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue1)

                    DataGridViewForm_UserDefinedValues.CurrentView.BestFitColumns()

                End If

                DataGridViewForm_UserDefinedValues.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

            End Using

        End Sub
        Private Sub UserDefinedValueSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub UserDefinedValueSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_UserDefinedValues.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim JobUserDefinedValues1 As Generic.List(Of AdvantageFramework.Database.Entities.JobUserDefinedValue1) = Nothing
            Dim JobUserDefinedValues2 As Generic.List(Of AdvantageFramework.Database.Entities.JobUserDefinedValue2) = Nothing
            Dim JobUserDefinedValues3 As Generic.List(Of AdvantageFramework.Database.Entities.JobUserDefinedValue3) = Nothing
            Dim JobUserDefinedValues4 As Generic.List(Of AdvantageFramework.Database.Entities.JobUserDefinedValue4) = Nothing
            Dim JobUserDefinedValues5 As Generic.List(Of AdvantageFramework.Database.Entities.JobUserDefinedValue5) = Nothing
            Dim JobComponentUserDefinedValues1 As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue1) = Nothing
            Dim JobComponentUserDefinedValues2 As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue2) = Nothing
            Dim JobComponentUserDefinedValues3 As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue3) = Nothing
            Dim JobComponentUserDefinedValues4 As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue4) = Nothing
            Dim JobComponentUserDefinedValues5 As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue5) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If TextBoxForm_Label.Text.Trim = "" Then

                    _UserDefinedLabel.Label = Nothing

                Else

                    _UserDefinedLabel.Label = TextBoxForm_Label.Text

                End If

                _UserDefinedLabel.IsEditable = Not CheckBoxForm_UseLookup.Checked

                AdvantageFramework.Database.Procedures.UserDefinedLabel.Update(DbContext, _UserDefinedLabel)

            End Using

            If DataGridViewForm_UserDefinedValues.Enabled AndAlso DataGridViewForm_UserDefinedValues.HasRows Then

                DataGridViewForm_UserDefinedValues.CurrentView.CloseEditorForUpdating()

                If _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV1 Then

                    JobComponentUserDefinedValues1 = DataGridViewForm_UserDefinedValues.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue1)().ToList

                ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV2 Then

                    JobComponentUserDefinedValues2 = DataGridViewForm_UserDefinedValues.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue2)().ToList

                ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV3 Then

                    JobComponentUserDefinedValues3 = DataGridViewForm_UserDefinedValues.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue3)().ToList

                ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV4 Then

                    JobComponentUserDefinedValues4 = DataGridViewForm_UserDefinedValues.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue4)().ToList

                ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV5 Then

                    JobComponentUserDefinedValues5 = DataGridViewForm_UserDefinedValues.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue5)().ToList

                ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV1 Then

                    JobUserDefinedValues1 = DataGridViewForm_UserDefinedValues.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobUserDefinedValue1)().ToList

                ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV2 Then

                    JobUserDefinedValues2 = DataGridViewForm_UserDefinedValues.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobUserDefinedValue2)().ToList

                ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV3 Then

                    JobUserDefinedValues3 = DataGridViewForm_UserDefinedValues.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobUserDefinedValue3)().ToList

                ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV4 Then

                    JobUserDefinedValues4 = DataGridViewForm_UserDefinedValues.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobUserDefinedValue4)().ToList

                ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV5 Then

                    JobUserDefinedValues5 = DataGridViewForm_UserDefinedValues.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobUserDefinedValue5)().ToList

                End If

                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV1 Then

                            For Each UserDefinedValue In JobComponentUserDefinedValues1

                                If AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue1.Update(DbContext, UserDefinedValue) = False Then

                                    DbContext.UndoChanges(UserDefinedValue)

                                End If

                            Next

                        ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV2 Then

                            For Each UserDefinedValue In JobComponentUserDefinedValues2

                                If AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue2.Update(DbContext, UserDefinedValue) = False Then

                                    DbContext.UndoChanges(UserDefinedValue)

                                End If

                            Next

                        ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV3 Then

                            For Each UserDefinedValue In JobComponentUserDefinedValues3

                                If AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue3.Update(DbContext, UserDefinedValue) = False Then

                                    DbContext.UndoChanges(UserDefinedValue)

                                End If

                            Next

                        ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV4 Then

                            For Each UserDefinedValue In JobComponentUserDefinedValues4

                                If AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue4.Update(DbContext, UserDefinedValue) = False Then

                                    DbContext.UndoChanges(UserDefinedValue)

                                End If

                            Next

                        ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV5 Then

                            For Each UserDefinedValue In JobComponentUserDefinedValues5

                                If AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue5.Update(DbContext, UserDefinedValue) = False Then

                                    DbContext.UndoChanges(UserDefinedValue)

                                End If

                            Next

                        ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV1 Then

                            For Each UserDefinedValue In JobUserDefinedValues1

                                If AdvantageFramework.Database.Procedures.JobUserDefinedValue1.Update(DbContext, UserDefinedValue) = False Then

                                    DbContext.UndoChanges(UserDefinedValue)

                                End If

                            Next

                        ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV2 Then

                            For Each UserDefinedValue In JobUserDefinedValues2

                                If AdvantageFramework.Database.Procedures.JobUserDefinedValue2.Update(DbContext, UserDefinedValue) = False Then

                                    DbContext.UndoChanges(UserDefinedValue)

                                End If

                            Next

                        ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV3 Then

                            For Each UserDefinedValue In JobUserDefinedValues3

                                If AdvantageFramework.Database.Procedures.JobUserDefinedValue3.Update(DbContext, UserDefinedValue) = False Then

                                    DbContext.UndoChanges(UserDefinedValue)

                                End If

                            Next

                        ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV4 Then

                            For Each UserDefinedValue In JobUserDefinedValues4

                                If AdvantageFramework.Database.Procedures.JobUserDefinedValue4.Update(DbContext, UserDefinedValue) = False Then

                                    DbContext.UndoChanges(UserDefinedValue)

                                End If

                            Next

                        ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV5 Then

                            For Each UserDefinedValue In JobUserDefinedValues5

                                If AdvantageFramework.Database.Procedures.JobUserDefinedValue5.Update(DbContext, UserDefinedValue) = False Then

                                    DbContext.UndoChanges(UserDefinedValue)

                                End If

                            Next

                        End If

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_UserDefinedValues.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

            Me.ClearChanged()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim JobUserDefinedValues1 As Generic.List(Of AdvantageFramework.Database.Entities.JobUserDefinedValue1) = Nothing
            Dim JobUserDefinedValues2 As Generic.List(Of AdvantageFramework.Database.Entities.JobUserDefinedValue2) = Nothing
            Dim JobUserDefinedValues3 As Generic.List(Of AdvantageFramework.Database.Entities.JobUserDefinedValue3) = Nothing
            Dim JobUserDefinedValues4 As Generic.List(Of AdvantageFramework.Database.Entities.JobUserDefinedValue4) = Nothing
            Dim JobUserDefinedValues5 As Generic.List(Of AdvantageFramework.Database.Entities.JobUserDefinedValue5) = Nothing
            Dim JobComponentUserDefinedValues1 As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue1) = Nothing
            Dim JobComponentUserDefinedValues2 As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue2) = Nothing
            Dim JobComponentUserDefinedValues3 As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue3) = Nothing
            Dim JobComponentUserDefinedValues4 As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue4) = Nothing
            Dim JobComponentUserDefinedValues5 As Generic.List(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue5) = Nothing

            If DataGridViewForm_UserDefinedValues.HasASelectedRow Then

                DataGridViewForm_UserDefinedValues.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Deleting...")
                    Me.FormAction = WinForm.Presentation.FormActions.Deleting

                    Try

                        If _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV1 Then

                            JobComponentUserDefinedValues1 = DataGridViewForm_UserDefinedValues.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue1)().ToList

                        ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV2 Then

                            JobComponentUserDefinedValues2 = DataGridViewForm_UserDefinedValues.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue2)().ToList

                        ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV3 Then

                            JobComponentUserDefinedValues3 = DataGridViewForm_UserDefinedValues.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue3)().ToList

                        ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV4 Then

                            JobComponentUserDefinedValues4 = DataGridViewForm_UserDefinedValues.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue4)().ToList

                        ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV5 Then

                            JobComponentUserDefinedValues5 = DataGridViewForm_UserDefinedValues.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue5)().ToList

                        ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV1 Then

                            JobUserDefinedValues1 = DataGridViewForm_UserDefinedValues.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobUserDefinedValue1)().ToList

                        ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV2 Then

                            JobUserDefinedValues2 = DataGridViewForm_UserDefinedValues.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobUserDefinedValue2)().ToList

                        ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV3 Then

                            JobUserDefinedValues3 = DataGridViewForm_UserDefinedValues.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobUserDefinedValue3)().ToList

                        ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV4 Then

                            JobUserDefinedValues4 = DataGridViewForm_UserDefinedValues.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobUserDefinedValue4)().ToList

                        ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV5 Then

                            JobUserDefinedValues5 = DataGridViewForm_UserDefinedValues.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobUserDefinedValue5)().ToList

                        End If

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            If _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV1 Then

                                For Each UserDefinedValue In JobComponentUserDefinedValues1

                                    If AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue1.Delete(DbContext, UserDefinedValue) Then

                                        DataGridViewForm_UserDefinedValues.CurrentView.DeleteFromDataSource(UserDefinedValue)

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("The '" & UserDefinedValue.Code & " - " & UserDefinedValue.Description & "' is in use and cannot be deleted.")

                                    End If

                                Next

                            ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV2 Then

                                For Each UserDefinedValue In JobComponentUserDefinedValues2

                                    If AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue2.Delete(DbContext, UserDefinedValue) Then

                                        DataGridViewForm_UserDefinedValues.CurrentView.DeleteFromDataSource(UserDefinedValue)

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("The '" & UserDefinedValue.Code & " - " & UserDefinedValue.Description & "' is in use and cannot be deleted.")

                                    End If

                                Next

                            ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV3 Then

                                For Each UserDefinedValue In JobComponentUserDefinedValues3

                                    If AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue3.Delete(DbContext, UserDefinedValue) Then

                                        DataGridViewForm_UserDefinedValues.CurrentView.DeleteFromDataSource(UserDefinedValue)

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("The '" & UserDefinedValue.Code & " - " & UserDefinedValue.Description & "' is in use and cannot be deleted.")

                                    End If

                                Next

                            ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV4 Then

                                For Each UserDefinedValue In JobComponentUserDefinedValues4

                                    If AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue4.Delete(DbContext, UserDefinedValue) Then

                                        DataGridViewForm_UserDefinedValues.CurrentView.DeleteFromDataSource(UserDefinedValue)

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("The '" & UserDefinedValue.Code & " - " & UserDefinedValue.Description & "' is in use and cannot be deleted.")

                                    End If

                                Next

                            ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV5 Then

                                For Each UserDefinedValue In JobComponentUserDefinedValues5

                                    If AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue5.Delete(DbContext, UserDefinedValue) Then

                                        DataGridViewForm_UserDefinedValues.CurrentView.DeleteFromDataSource(UserDefinedValue)

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("The '" & UserDefinedValue.Code & " - " & UserDefinedValue.Description & "' is in use and cannot be deleted.")

                                    End If

                                Next

                            ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV1 Then

                                For Each UserDefinedValue In JobUserDefinedValues1

                                    If AdvantageFramework.Database.Procedures.JobUserDefinedValue1.Delete(DbContext, UserDefinedValue) Then

                                        DataGridViewForm_UserDefinedValues.CurrentView.DeleteFromDataSource(UserDefinedValue)

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("The '" & UserDefinedValue.Code & " - " & UserDefinedValue.Description & "' is in use and cannot be deleted.")

                                    End If

                                Next

                            ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV2 Then

                                For Each UserDefinedValue In JobUserDefinedValues2

                                    If AdvantageFramework.Database.Procedures.JobUserDefinedValue2.Delete(DbContext, UserDefinedValue) Then

                                        DataGridViewForm_UserDefinedValues.CurrentView.DeleteFromDataSource(UserDefinedValue)

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("The '" & UserDefinedValue.Code & " - " & UserDefinedValue.Description & "' is in use and cannot be deleted.")

                                    End If

                                Next

                            ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV3 Then

                                For Each UserDefinedValue In JobUserDefinedValues3

                                    If AdvantageFramework.Database.Procedures.JobUserDefinedValue3.Delete(DbContext, UserDefinedValue) Then

                                        DataGridViewForm_UserDefinedValues.CurrentView.DeleteFromDataSource(UserDefinedValue)

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("The '" & UserDefinedValue.Code & " - " & UserDefinedValue.Description & "' is in use and cannot be deleted.")

                                    End If

                                Next

                            ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV4 Then

                                For Each UserDefinedValue In JobUserDefinedValues4

                                    If AdvantageFramework.Database.Procedures.JobUserDefinedValue4.Delete(DbContext, UserDefinedValue) Then

                                        DataGridViewForm_UserDefinedValues.CurrentView.DeleteFromDataSource(UserDefinedValue)

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("The '" & UserDefinedValue.Code & " - " & UserDefinedValue.Description & "' is in use and cannot be deleted.")

                                    End If

                                Next

                            ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV5 Then

                                For Each UserDefinedValue In JobUserDefinedValues5

                                    If AdvantageFramework.Database.Procedures.JobUserDefinedValue5.Delete(DbContext, UserDefinedValue) Then

                                        DataGridViewForm_UserDefinedValues.CurrentView.DeleteFromDataSource(UserDefinedValue)

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("The '" & UserDefinedValue.Code & " - " & UserDefinedValue.Description & "' is in use and cannot be deleted.")

                                    End If

                                Next

                            End If

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()
                    Me.FormAction = WinForm.Presentation.FormActions.None

                    If DataGridViewForm_UserDefinedValues.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_UserDefinedValues.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_UserDefinedValues_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_UserDefinedValues.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_UserDefinedValue_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_UserDefinedValues.AddNewRowEvent

            Me.ShowWaitForm("Adding...")

            Try

                If TypeOf RowObject Is AdvantageFramework.Database.Entities.JobUserDefinedValue1 Then

                    AddNewRowEventJobUserDefinedValue1(RowObject)

                ElseIf TypeOf RowObject Is AdvantageFramework.Database.Entities.JobUserDefinedValue2 Then

                    AddNewRowEventJobUserDefinedValue2(RowObject)

                ElseIf TypeOf RowObject Is AdvantageFramework.Database.Entities.JobUserDefinedValue3 Then

                    AddNewRowEventJobUserDefinedValue3(RowObject)

                ElseIf TypeOf RowObject Is AdvantageFramework.Database.Entities.JobUserDefinedValue4 Then

                    AddNewRowEventJobUserDefinedValue4(RowObject)

                ElseIf TypeOf RowObject Is AdvantageFramework.Database.Entities.JobUserDefinedValue5 Then

                    AddNewRowEventJobUserDefinedValue5(RowObject)

                ElseIf TypeOf RowObject Is AdvantageFramework.Database.Entities.JobComponentUserDefinedValue1 Then

                    AddNewRowEventJobComponentUserDefinedValue1(RowObject)

                ElseIf TypeOf RowObject Is AdvantageFramework.Database.Entities.JobComponentUserDefinedValue2 Then

                    AddNewRowEventJobComponentUserDefinedValue2(RowObject)

                ElseIf TypeOf RowObject Is AdvantageFramework.Database.Entities.JobComponentUserDefinedValue3 Then

                    AddNewRowEventJobComponentUserDefinedValue3(RowObject)

                ElseIf TypeOf RowObject Is AdvantageFramework.Database.Entities.JobComponentUserDefinedValue4 Then

                    AddNewRowEventJobComponentUserDefinedValue4(RowObject)

                ElseIf TypeOf RowObject Is AdvantageFramework.Database.Entities.JobComponentUserDefinedValue5 Then

                    AddNewRowEventJobComponentUserDefinedValue5(RowObject)

                End If

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

        End Sub
        Private Sub DataGridViewForm_UserDefinedValues_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_UserDefinedValues.CellValueChangingEvent

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.JobUserDefinedValue1.Properties.IsInactive.ToString Then

                Try

                    If TypeOf DataGridViewForm_UserDefinedValues.GetFirstSelectedRowDataBoundItem Is AdvantageFramework.Database.Entities.JobUserDefinedValue1 Then

                        UpdateJobUserDefinedValue1Inactive(Saved, DataGridViewForm_UserDefinedValues.GetFirstSelectedRowDataBoundItem, e.Value)

                    ElseIf TypeOf DataGridViewForm_UserDefinedValues.GetFirstSelectedRowDataBoundItem Is AdvantageFramework.Database.Entities.JobUserDefinedValue2 Then

                        UpdateJobUserDefinedValue2Inactive(Saved, DataGridViewForm_UserDefinedValues.GetFirstSelectedRowDataBoundItem, e.Value)

                    ElseIf TypeOf DataGridViewForm_UserDefinedValues.GetFirstSelectedRowDataBoundItem Is AdvantageFramework.Database.Entities.JobUserDefinedValue3 Then

                        UpdateJobUserDefinedValue3Inactive(Saved, DataGridViewForm_UserDefinedValues.GetFirstSelectedRowDataBoundItem, e.Value)

                    ElseIf TypeOf DataGridViewForm_UserDefinedValues.GetFirstSelectedRowDataBoundItem Is AdvantageFramework.Database.Entities.JobUserDefinedValue4 Then

                        UpdateJobUserDefinedValue4Inactive(Saved, DataGridViewForm_UserDefinedValues.GetFirstSelectedRowDataBoundItem, e.Value)

                    ElseIf TypeOf DataGridViewForm_UserDefinedValues.GetFirstSelectedRowDataBoundItem Is AdvantageFramework.Database.Entities.JobUserDefinedValue5 Then

                        UpdateJobUserDefinedValue5Inactive(Saved, DataGridViewForm_UserDefinedValues.GetFirstSelectedRowDataBoundItem, e.Value)

                    ElseIf TypeOf DataGridViewForm_UserDefinedValues.GetFirstSelectedRowDataBoundItem Is AdvantageFramework.Database.Entities.JobComponentUserDefinedValue1 Then

                        UpdateJobComponentUserDefinedValue1Inactive(Saved, DataGridViewForm_UserDefinedValues.GetFirstSelectedRowDataBoundItem, e.Value)

                    ElseIf TypeOf DataGridViewForm_UserDefinedValues.GetFirstSelectedRowDataBoundItem Is AdvantageFramework.Database.Entities.JobComponentUserDefinedValue2 Then

                        UpdateJobComponentUserDefinedValue2Inactive(Saved, DataGridViewForm_UserDefinedValues.GetFirstSelectedRowDataBoundItem, e.Value)

                    ElseIf TypeOf DataGridViewForm_UserDefinedValues.GetFirstSelectedRowDataBoundItem Is AdvantageFramework.Database.Entities.JobComponentUserDefinedValue3 Then

                        UpdateJobComponentUserDefinedValue3Inactive(Saved, DataGridViewForm_UserDefinedValues.GetFirstSelectedRowDataBoundItem, e.Value)

                    ElseIf TypeOf DataGridViewForm_UserDefinedValues.GetFirstSelectedRowDataBoundItem Is AdvantageFramework.Database.Entities.JobComponentUserDefinedValue4 Then

                        UpdateJobComponentUserDefinedValue4Inactive(Saved, DataGridViewForm_UserDefinedValues.GetFirstSelectedRowDataBoundItem, e.Value)

                    ElseIf TypeOf DataGridViewForm_UserDefinedValues.GetFirstSelectedRowDataBoundItem Is AdvantageFramework.Database.Entities.JobComponentUserDefinedValue5 Then

                        UpdateJobComponentUserDefinedValue5Inactive(Saved, DataGridViewForm_UserDefinedValues.GetFirstSelectedRowDataBoundItem, e.Value)

                    End If

                    Saved = True

                Catch ex As Exception
                    Saved = False
                End Try

            End If

        End Sub
        Private Sub DataGridViewForm_UserDefinedValues_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_UserDefinedValues.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub CheckBoxForm_UseLookup_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxForm_UseLookup.CheckedChanged

            If _UserDefinedLabel IsNot Nothing AndAlso Me.FormShown Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If _UserDefinedLabel.Label IsNot Nothing AndAlso _UserDefinedLabel.Label <> "" Then

                        _UserDefinedLabel.IsEditable = Not CheckBoxForm_UseLookup.Checked

                        AdvantageFramework.Database.Procedures.UserDefinedLabel.Update(DbContext, _UserDefinedLabel)

                    End If

                End Using

                DataGridViewForm_UserDefinedValues.Enabled = CheckBoxForm_UseLookup.Checked

            End If

        End Sub
        Private Sub CheckBoxForm_UseLookup_CheckedChanging(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxForm_UseLookup.CheckedChanging

            If _UserDefinedLabel IsNot Nothing AndAlso Me.FormShown Then

                If _UserDefinedLabel.Label IsNot Nothing AndAlso _UserDefinedLabel.Label <> "" Then

                    If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you wish to change this setting? If you click ""OK"", all data associated with this custom field will be immediately cleared on all jobs.", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.OKCancel) = AdvantageFramework.WinForm.MessageBox.DialogResults.OK Then

                        e.Cancel = False

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            If _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV1 Then

                                AdvantageFramework.Database.Procedures.JobComponent.ClearUserDefinedValue(DbContext, _UserDefinedLabelTable)

                                AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue1.DeleteAll(DbContext)

                                DataGridViewForm_UserDefinedValues.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue1)

                            ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV2 Then

                                AdvantageFramework.Database.Procedures.JobComponent.ClearUserDefinedValue(DbContext, _UserDefinedLabelTable)

                                AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue2.DeleteAll(DbContext)

                                DataGridViewForm_UserDefinedValues.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue2)

                            ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV3 Then

                                AdvantageFramework.Database.Procedures.JobComponent.ClearUserDefinedValue(DbContext, _UserDefinedLabelTable)

                                AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue3.DeleteAll(DbContext)

                                DataGridViewForm_UserDefinedValues.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue3)

                            ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV4 Then

                                AdvantageFramework.Database.Procedures.JobComponent.ClearUserDefinedValue(DbContext, _UserDefinedLabelTable)

                                AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue4.DeleteAll(DbContext)

                                DataGridViewForm_UserDefinedValues.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue4)

                            ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV5 Then

                                AdvantageFramework.Database.Procedures.JobComponent.ClearUserDefinedValue(DbContext, _UserDefinedLabelTable)

                                AdvantageFramework.Database.Procedures.JobComponentUserDefinedValue5.DeleteAll(DbContext)

                                DataGridViewForm_UserDefinedValues.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.JobComponentUserDefinedValue5)

                            ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV1 Then

                                AdvantageFramework.Database.Procedures.Job.ClearUserDefinedValue(DbContext, _UserDefinedLabelTable)

                                AdvantageFramework.Database.Procedures.JobUserDefinedValue1.DeleteAll(DbContext)

                                DataGridViewForm_UserDefinedValues.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.JobUserDefinedValue1)

                            ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV2 Then

                                AdvantageFramework.Database.Procedures.Job.ClearUserDefinedValue(DbContext, _UserDefinedLabelTable)

                                AdvantageFramework.Database.Procedures.JobUserDefinedValue2.DeleteAll(DbContext)

                                DataGridViewForm_UserDefinedValues.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.JobUserDefinedValue2)

                            ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV3 Then

                                AdvantageFramework.Database.Procedures.Job.ClearUserDefinedValue(DbContext, _UserDefinedLabelTable)

                                AdvantageFramework.Database.Procedures.JobUserDefinedValue3.DeleteAll(DbContext)

                                DataGridViewForm_UserDefinedValues.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.JobUserDefinedValue3)

                            ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV4 Then

                                AdvantageFramework.Database.Procedures.Job.ClearUserDefinedValue(DbContext, _UserDefinedLabelTable)

                                AdvantageFramework.Database.Procedures.JobUserDefinedValue4.DeleteAll(DbContext)

                                DataGridViewForm_UserDefinedValues.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.JobUserDefinedValue4)

                            ElseIf _UserDefinedLabelTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV5 Then

                                AdvantageFramework.Database.Procedures.Job.ClearUserDefinedValue(DbContext, _UserDefinedLabelTable)

                                AdvantageFramework.Database.Procedures.JobUserDefinedValue5.DeleteAll(DbContext)

                                DataGridViewForm_UserDefinedValues.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.JobUserDefinedValue5)

                            End If

                        End Using

                    Else

                        e.Cancel = True

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace