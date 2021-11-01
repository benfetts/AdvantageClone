Namespace Importing.Presentation

    Public Class GeneralLedgerBatchReportDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _UserCode As String = Nothing
        Protected _BatchNameSelected As String = Nothing
        Protected _GLSourceCodes As IEnumerable(Of String) = Nothing

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
        Private ReadOnly Property GLSourceCodes As IEnumerable(Of String)
            Get
                GLSourceCodes = _GLSourceCodes
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes, UserCode As String)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _UserCode = UserCode

            Me.ByPassUserEntryChanged = True

            ComboBoxForm_User.ByPassUserEntryChanged = True
            ComboBoxForm_Batch.ByPassUserEntryChanged = True

            If ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_Default Then

                _GLSourceCodes = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.GLSourceStandard))
                                  Select Entity.Code).ToArray

            ElseIf ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_MOGLIFACE Then

                _GLSourceCodes = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.GLSourceMOGLIFACE))
                                  Select Entity.Code).ToArray

            End If

        End Sub
        Private Sub LoadBatchesForUser()

            Dim UserCode As String = Nothing
            Dim BatchDates As IEnumerable(Of Date) = Nothing
            Dim BatchDictionary As Generic.Dictionary(Of Date, String) = Nothing

            If Me.FormAction <> AdvantageFramework.WinForm.Presentation.FormActions.Loading AndAlso ComboBoxForm_User.HasASelectedValue Then

                BatchDictionary = New Generic.Dictionary(Of Date, String)

                ComboBoxForm_Batch.DataSource = Nothing

                UserCode = ComboBoxForm_User.GetSelectedValue

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    BatchDates = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedger.Load(DbContext)
                                  Where Entity.BatchDate IsNot Nothing AndAlso
                                        Entity.UserCode.ToUpper = UserCode.ToUpper AndAlso
                                        _GLSourceCodes.Contains(Entity.GLSourceCode)
                                  Select Entity.BatchDate.Value).Distinct.ToList

                End Using

                For Each BatchDate In BatchDates

                    BatchDictionary.Add(BatchDate, BatchDate.ToShortDateString)

                Next

                ComboBoxForm_Batch.DataSource = BatchDictionary.OrderByDescending(Function(BD) BD.Key).Select(Function(BD) BD.Key).ToList()

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes,
                                              ByRef UserCode As String, ByRef BatchDate As Date, ByRef GLSourceCodes As IEnumerable(Of String)) As Windows.Forms.DialogResult

            'objects
            Dim GeneralLedgerBatchReportDialog As AdvantageFramework.Importing.Presentation.GeneralLedgerBatchReportDialog = Nothing

            GeneralLedgerBatchReportDialog = New AdvantageFramework.Importing.Presentation.GeneralLedgerBatchReportDialog(ImportTemplateType, UserCode)

            ShowFormDialog = GeneralLedgerBatchReportDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                BatchDate = GeneralLedgerBatchReportDialog.BatchNameSelected
                UserCode = GeneralLedgerBatchReportDialog.UserCode
                GLSourceCodes = GeneralLedgerBatchReportDialog.GLSourceCodes

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub GeneralLedgerBatchReportDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim UserList As IEnumerable(Of String) = Nothing

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            ComboBoxForm_Batch.SetRequired(True)
            ComboBoxForm_User.SetRequired(True)

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                UserList = AdvantageFramework.Database.Procedures.GeneralLedger.LoadGeneralLedgerImportBatchUsers(DbContext, _GLSourceCodes).ToList

                Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ComboBoxForm_User.DataSource = AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext).Where(Function(User) UserList.Contains(User.UserCode.ToUpper)).OrderBy(Function(User) User.UserCode).ToList

                End Using

            End Using

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub GeneralLedgerBatchReportDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

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