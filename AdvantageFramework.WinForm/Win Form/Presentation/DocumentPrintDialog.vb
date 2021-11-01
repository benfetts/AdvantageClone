Namespace WinForm.Presentation

    Public Class DocumentPrintDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal ClientCode As String, ByVal DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document))

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ClientCode = ClientCode
            _DocumentList = DocumentList

            DataGridViewForm_Documents.ByPassUserEntryChanged = True
            DataGridViewForm_Documents.OptionsCustomization.AllowFilter = False

        End Sub
        Private Sub LoadDocuments()

            'objects
            Dim AccountPayableIDs() As Long = Nothing
            Dim AccountPayableList As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayable) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document) = Nothing

            DocumentList = _DocumentList

            If CheckBoxItemInclude_APDocuments.Checked = False Then

                DocumentList = DocumentList.Where(Function(DL) DL.DocumentLevel <> Database.Entities.DocumentLevel.AccountPayableInvoice).ToList

            End If

            If CheckBoxItemInclude_ExpenseDocuments.Checked = False Then

                DocumentList = DocumentList.Where(Function(DL) DL.DocumentLevel <> Database.Entities.DocumentLevel.ExpenseReceipts).ToList

            End If

            AccountPayableIDs = (From Document In DocumentList _
                                 Where (Document.DocumentLevel = Database.Entities.DocumentLevel.AccountPayableInvoice AndAlso _
                                        String.IsNullOrWhiteSpace(Document.DocumentLevelSetting.AccountPayableID) = False) OrElse _
                                       String.IsNullOrWhiteSpace(Document.DocumentLevelSetting.AccountPayableID) = False _
                                 Select CLng(Document.DocumentLevelSetting.AccountPayableID)).ToArray

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AccountPayableList = (From AP In AdvantageFramework.Database.Procedures.AccountPayable.Load(DbContext)
                                      Where AccountPayableIDs.Contains(AP.ID) AndAlso
                                            AP.Modified Is Nothing AndAlso
                                            AP.Deleted Is Nothing
                                      Select AP).ToList

                DataGridViewForm_Documents.DataSource = (From Entity In DocumentList
                                                         Group Join AP In AccountPayableList On Entity.DocumentLevelSetting.AccountPayableID Equals AP.ID.ToString Into Group
                                                         From AP In Group.DefaultIfEmpty()
                                                         Select New With {.ID = Entity.ID,
                                                                          .InvoiceNumber = Entity.DocumentLevelSetting.AccountReceivableInvoiceNumber,
                                                                          .SeqNbr = Entity.DocumentLevelSetting.AccountReceivableSequenceNumber,
                                                                          .Type = Entity.DocumentLevelSetting.AccountReceivableType,
                                                                          .APInvoiceNumber = If(AP IsNot Nothing, AP.InvoiceNumber, Nothing),
                                                                          .APInvoiceDate = If(AP IsNot Nothing, AP.InvoiceDate.ToShortDateString, Nothing),
                                                                          .DocumentLevel = Entity.DocumentLevelName,
                                                                          .FileName = Entity.FileName,
                                                                          .Description = Entity.Description,
                                                                          .UploadedBy = Entity.UserCode,
                                                                          .UploadedDate = Entity.UploadedDate.ToString("G"),
                                                                          .IsPrivate = CBool(Entity.IsPrivate.GetValueOrDefault(0)),
                                                                          .Sort = If(Entity.DocumentLevel = Database.Entities.DocumentLevel.AccountReceivableInvoice, 0, (If(Entity.DocumentLevel = Database.Entities.DocumentLevel.AccountPayableInvoice, 1, 2)))}).OrderBy(Function(Entity) Entity.Sort).ToList

            End Using

            If DataGridViewForm_Documents.Columns("ID") IsNot Nothing Then

                DataGridViewForm_Documents.Columns("ID").Visible = False

            End If

            If DataGridViewForm_Documents.Columns("APInvoiceNumber") IsNot Nothing Then

                DataGridViewForm_Documents.Columns("APInvoiceNumber").Caption = "AP Invoice Number"

            End If

            If DataGridViewForm_Documents.Columns("UploadedDate") IsNot Nothing Then

                DataGridViewForm_Documents.Columns("UploadedDate").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                DataGridViewForm_Documents.Columns("UploadedDate").DisplayFormat.FormatString = "G"
                DataGridViewForm_Documents.Columns("UploadedDate").SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

            End If

            If DataGridViewForm_Documents.Columns("Sort") IsNot Nothing Then

                DataGridViewForm_Documents.Columns("Sort").Visible = False

            End If

            ApplyGrouping()

            DataGridViewForm_Documents.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Package.Enabled = DataGridViewForm_Documents.HasASelectedRow

        End Sub
        Private Sub ApplyGrouping()

            Try

                DataGridViewForm_Documents.OptionsView.ShowGroupedColumns = True
                DataGridViewForm_Documents.Columns("InvoiceNumber").GroupIndex = 0
                DataGridViewForm_Documents.CurrentView.ExpandAllGroups()

            Catch ex As Exception

            End Try

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ClientCode As String, ByVal DocumentList As Generic.List(Of AdvantageFramework.DocumentManager.Classes.Document)) As System.Windows.Forms.DialogResult

            'objects
            Dim DocumentPrintDialog As AdvantageFramework.WinForm.Presentation.DocumentPrintDialog = Nothing

            DocumentPrintDialog = New AdvantageFramework.WinForm.Presentation.DocumentPrintDialog(ClientCode, DocumentList)

            ShowFormDialog = DocumentPrintDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub DocumentPrintDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Package.Image = AdvantageFramework.My.Resources.DocumentPackageImage

            CheckBoxItemInclude_APDocuments.Checked = True
            CheckBoxItemInclude_ExpenseDocuments.Checked = True

            DataGridViewForm_Documents.OptionsMenu.EnableColumnMenu = False
            DataGridViewForm_Documents.MultiSelect = True
            DataGridViewForm_Documents.ShowSelectDeselectAllButtons = True

            LoadDocuments()

        End Sub
        Private Sub DocumentPrintDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            ButtonItemPackageOptions_OneZip.Checked = True

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Package_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Package.Click

            'objects
            Dim DocumentIDs As IEnumerable(Of Integer) = Nothing
            Dim DocumentList As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim SaveToLocation As String = ""
            Dim SavedFileName As String = ""
            Dim Counter As Integer = 0
            Dim ContinueSave As Boolean = False
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim InvoiceDocumentList As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim InvoiceNumbers As IEnumerable(Of Integer) = Nothing

            DocumentIDs = (From ObjectValue In DataGridViewForm_Documents.GetAllSelectedRowsBookmarkValues(0)
                           Select DirectCast(ObjectValue, Integer)).ToList

            DocumentList = New Generic.List(Of AdvantageFramework.Database.Entities.Document)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each DocumentID In DocumentIDs

                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                    If Document IsNot Nothing Then

                        DocumentList.Add(Document)

                    End If

                Next

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _ClientCode)

            End Using

            If DocumentList IsNot Nothing AndAlso DocumentList.Count > 0 Then

                If Agency.IsASP.GetValueOrDefault(0) = 0 Then

                    If AdvantageFramework.WinForm.Presentation.BrowseForFolder(SaveToLocation) Then

                        ContinueSave = True

                    End If

                Else

                    SaveToLocation = AdvantageFramework.FileSystem.LoadHostedClientDownloadLocation(Agency)

                    ContinueSave = True

                End If

                If ContinueSave Then

                    Try

                        Me.ShowWaitForm("Packaging files ...")

                        If ButtonItemPackageOptions_OneZip.Checked Then

                            Using ZipFile = New Ionic.Zip.ZipFile

                                AdvantageFramework.DocumentManager.CreateZipPackage(Agency, DocumentList, ZipFile)

                                If Client IsNot Nothing Then

                                    SavedFileName = SaveToLocation & "\" & Client.Code & "-" & Client.Name & "-" & Format(Now, "yyyyMMdd")

                                Else

                                    SavedFileName = SaveToLocation & "\" & _ClientCode & "-" & Format(Now, "yyyyMMdd")

                                End If

                                Do While New System.IO.FileInfo(SavedFileName & ".zip").Exists

                                    SavedFileName = SavedFileName & "(" & Counter & ")"

                                    Counter = Counter + 1

                                Loop

                                SavedFileName = SavedFileName & ".zip"

                                ZipFile.Save(SavedFileName)

                            End Using

                        Else

                            InvoiceNumbers = (From ObjectValue In DataGridViewForm_Documents.GetAllSelectedRowsBookmarkValues(1)
                                              Select DirectCast(ObjectValue, Integer)).Distinct

                            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                For Each InvoiceNumber In InvoiceNumbers

                                    InvoiceDocumentList = New Generic.List(Of AdvantageFramework.Database.Entities.Document)

                                    For Each ObjectValue In DataGridViewForm_Documents.GetAllSelectedRowsDataBoundItems()

                                        If ObjectValue.InvoiceNumber = InvoiceNumber Then

                                            Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, ObjectValue.ID)

                                            If Document IsNot Nothing Then

                                                InvoiceDocumentList.Add(Document)

                                            End If

                                        End If

                                    Next

                                    Using ZipFile = New Ionic.Zip.ZipFile

                                        AdvantageFramework.DocumentManager.CreateZipPackage(Agency, InvoiceDocumentList, ZipFile)

                                        If Client IsNot Nothing Then

                                            SavedFileName = SaveToLocation & "\" & Client.Code & "-" & Client.Name & "-" & Format(Now, "yyyyMMdd") & "-" & InvoiceNumber

                                        Else

                                            SavedFileName = SaveToLocation & "\" & _ClientCode & "-" & Format(Now, "yyyyMMdd") & "-" & InvoiceNumber

                                        End If

                                        Do While New System.IO.FileInfo(SavedFileName & ".zip").Exists

                                            SavedFileName = SavedFileName & "(" & Counter & ")"

                                            Counter = Counter + 1

                                        Loop

                                        SavedFileName = SavedFileName & ".zip"

                                        ZipFile.Save(SavedFileName)

                                    End Using

                                Next

                            End Using

                        End If

                        AdvantageFramework.WinForm.MessageBox.Show("Package file(s) created.")

                    Catch ex As Exception

                        AdvantageFramework.WinForm.MessageBox.Show("Package file creation failed." & vbCrLf & ex.Message)

                    Finally

                        Me.CloseWaitForm()

                    End Try

                End If
                
            End If

        End Sub
        Private Sub DataGridViewForm_Documents_CustomColumnSortEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs) Handles DataGridViewForm_Documents.CustomColumnSortEvent

            If e.Column.FieldName = "UploadedDate" AndAlso e.Value1 IsNot Nothing AndAlso e.Value2 IsNot Nothing Then

                e.Handled = True

                If Convert.ToDateTime(e.Value1) > Convert.ToDateTime(e.Value2) Then

                    e.Result = 1

                Else

                    If Convert.ToDateTime(e.Value1) = Convert.ToDateTime(e.Value2) Then

                        e.Result = Comparer(Of DateTime).Default.Compare(Convert.ToDateTime(e.Value1), Convert.ToDateTime(e.Value2))

                    Else

                        e.Result = -1

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Documents_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Documents.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub CheckBoxItemInclude_APDocuments_CheckedChanged(sender As Object, e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles CheckBoxItemInclude_APDocuments.CheckedChanged

            If Me.FormShown Then

                LoadDocuments()

            End If

        End Sub
        Private Sub CheckBoxItemInclude_ExpenseDocuments_CheckedChanged(sender As Object, e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles CheckBoxItemInclude_ExpenseDocuments.CheckedChanged

            If Me.FormShown Then

                LoadDocuments()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace