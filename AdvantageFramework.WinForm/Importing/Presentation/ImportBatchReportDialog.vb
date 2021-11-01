Namespace Importing.Presentation

    Public Class ImportBatchReportDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ImportType As AdvantageFramework.Importing.Methods.ImportType = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal ImportType As AdvantageFramework.Importing.ImportType)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            ComboBoxForm_Batch.ByPassUserEntryChanged = True

            _ImportType = ImportType

            LabelForm_ImportType.Text = ImportType.ToString

        End Sub
        Private Sub LoadBatches()

            Dim BatchNameList As IEnumerable(Of String) = Nothing
            Dim BatchDictionary As Generic.Dictionary(Of Date, String) = Nothing
            Dim BatchDateTime As String = Nothing
            Dim BatchDate As Date = Nothing

            BatchDictionary = New Generic.Dictionary(Of Date, String)

            If Me.FormAction <> AdvantageFramework.WinForm.Presentation.FormActions.Loading Then

                ComboBoxForm_Batch.Text = Nothing

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Select Case _ImportType

                        Case AdvantageFramework.Importing.ImportType.Client

                            BatchNameList = (From Entity In AdvantageFramework.Database.Procedures.Client.Load(DbContext)
                                             Where Entity.BatchName IsNot Nothing
                                             Select Entity.BatchName).Distinct.ToList

                        Case AdvantageFramework.Importing.ImportType.Division

                            BatchNameList = (From Entity In AdvantageFramework.Database.Procedures.Division.Load(DbContext)
                                             Where Entity.BatchName IsNot Nothing
                                             Select Entity.BatchName).Distinct.ToList

                        Case AdvantageFramework.Importing.ImportType.Product

                            BatchNameList = (From Entity In AdvantageFramework.Database.Procedures.Product.Load(DbContext)
                                             Where Entity.BatchName IsNot Nothing
                                             Select Entity.BatchName).Distinct.ToList

                    End Select

                    For Each BatchName In BatchNameList

                        BatchDateTime = Mid(BatchName, InStrRev(BatchName, "_") + 1)

                        BatchDate = New Date(Mid(BatchDateTime, 5, 4), Mid(BatchDateTime, 1, 2), Mid(BatchDateTime, 3, 2), Mid(BatchDateTime, 9, 2), Mid(BatchDateTime, 11, 2), Mid(BatchDateTime, 13, 2))

                        BatchDictionary.Add(BatchDate, BatchName)

                    Next

                    ComboBoxForm_Batch.DataSource = BatchDictionary.OrderByDescending(Function(BD) BD.Key).Select(Function(BD) BD.Value).ToList()

                End Using

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ImportType As AdvantageFramework.Importing.Methods.ImportType, ByRef BatchName As String) As Windows.Forms.DialogResult

            'objects
            Dim ImportBatchReportDialog As AdvantageFramework.Importing.Presentation.ImportBatchReportDialog = Nothing

            ImportBatchReportDialog = New AdvantageFramework.Importing.Presentation.ImportBatchReportDialog(ImportType)

            ShowFormDialog = ImportBatchReportDialog.ShowDialog()

            BatchName = ImportBatchReportDialog.ComboBoxForm_Batch.GetSelectedValue

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ImportBatchReportDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Me.ByPassUserEntryChanged = True

            Me.ComboBoxForm_Batch.ByPassUserEntryChanged = True

            ComboBoxForm_Batch.SetRequired(True)

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            LoadBatches()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Dim IsValid As Boolean = False
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                ErrorMessage = ErrorMessage.Replace("Default", "Batch")

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace