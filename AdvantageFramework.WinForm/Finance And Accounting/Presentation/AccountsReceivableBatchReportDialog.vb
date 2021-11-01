Namespace FinanceAndAccounting.Presentation

    Public Class AccountsReceivableBatchReportDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _UserCode As String = Nothing
        Protected _BatchNameSelected As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property UserCode As String
            Get
                UserCode = _UserCode
            End Get
        End Property
        Private ReadOnly Property BatchNameSelected As String
            Get
                BatchNameSelected = _BatchNameSelected
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(UserCode As String)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _UserCode = UserCode

            Me.ByPassUserEntryChanged = True

            ComboBoxForm_User.ByPassUserEntryChanged = True
            ComboBoxForm_Batch.ByPassUserEntryChanged = True

        End Sub
        Private Sub LoadBatchesForUser()

            Dim BatchNameList As IEnumerable(Of String) = Nothing
            Dim BatchDictionary As Generic.Dictionary(Of Date, String) = Nothing
            Dim BatchDateTime As String = Nothing
            Dim BatchDate As Date = Nothing
            Dim UserCode As String = Nothing

            If Me.FormAction <> AdvantageFramework.WinForm.Presentation.FormActions.Loading AndAlso ComboBoxForm_User.HasASelectedValue Then

                ComboBoxForm_Batch.DataSource = Nothing

                UserCode = ComboBoxForm_User.GetSelectedValue

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    BatchNameList = (From Entity In AdvantageFramework.Database.Procedures.AccountReceivable.Load(DbContext)
                                     Where Entity.BatchName IsNot Nothing AndAlso
                                           Entity.UserCode.ToUpper = UserCode.ToUpper
                                     Select Entity.BatchName).Distinct.ToList

                End Using

                BatchDictionary = New Generic.Dictionary(Of Date, String)

                For Each BatchName In BatchNameList

                    BatchDateTime = Mid(BatchName, InStrRev(BatchName, "_") + 1)

                    BatchDate = New Date(Mid(BatchDateTime, 5, 4), Mid(BatchDateTime, 1, 2), Mid(BatchDateTime, 3, 2), Mid(BatchDateTime, 9, 2), Mid(BatchDateTime, 11, 2), Mid(BatchDateTime, 13, 2))

                    BatchDictionary.Add(BatchDate, BatchName)

                Next

                ComboBoxForm_Batch.DataSource = BatchDictionary.OrderByDescending(Function(BD) BD.Key).Select(Function(BD) BD.Value).ToList()

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef UserCode As String, ByRef BatchName As String) As Windows.Forms.DialogResult

            'objects
            Dim AccountsReceivableBatchReportDialog As AdvantageFramework.FinanceAndAccounting.Presentation.AccountsReceivableBatchReportDialog = Nothing

            AccountsReceivableBatchReportDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.AccountsReceivableBatchReportDialog(UserCode)

            ShowFormDialog = AccountsReceivableBatchReportDialog.ShowDialog()

            BatchName = AccountsReceivableBatchReportDialog.BatchNameSelected
            UserCode = AccountsReceivableBatchReportDialog.UserCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AccountsReceivableBatchReportDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim UserList As IEnumerable(Of String) = Nothing

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            ComboBoxForm_Batch.SetRequired(True)
            ComboBoxForm_User.SetRequired(True)

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                UserList = (From Entity In AdvantageFramework.Database.Procedures.AccountReceivable.Load(DbContext)
                            Where Entity.BatchName IsNot Nothing
                            Select Entity.UserCode.ToUpper).Distinct.ToList

                Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ComboBoxForm_User.DataSource = AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext).Where(Function(User) UserList.Contains(User.UserCode.ToUpper)).OrderBy(Function(User) User.UserCode.ToUpper).ToList

                End Using

            End Using

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub AccountsReceivableBatchReportDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If ComboBoxForm_User.Items.Count > 0 Then

                ComboBoxForm_User.SelectedIndex = 0

                LoadBatchesForUser()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Dim IsValid As Boolean = False
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                _UserCode = ComboBoxForm_User.GetSelectedValue
                _BatchNameSelected = ComboBoxForm_Batch.GetSelectedValue

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

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
        Private Sub ComboBoxForm_User_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_User.SelectedValueChanged

            LoadBatchesForUser()

        End Sub

#End Region

#End Region

    End Class

End Namespace