Namespace WinForm.Presentation

    Public Class FolderBrowserDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Folder As String = ""
        Private _FileFilters As Generic.List(Of AdvantageFramework.FileSystem.FileFilters) = Nothing
        Private _Files As String() = Nothing
        Private _FileNameMustBeginWith As String = Nothing
        Private _ExcludeFileNamesBeginningWithList As Generic.List(Of String) = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property Files As String()
            Get
                Files = _Files
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal Folder As String, ByVal FileFilters As Generic.List(Of AdvantageFramework.FileSystem.FileFilters), ByVal MultiSelect As Boolean, Optional ByVal FileNameMustBeginWith As String = Nothing, Optional ByVal ExcludeFileNamesBeginningWithList As Generic.List(Of String) = Nothing, Optional ByVal AllowDirectorySelection As Boolean = False)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _Folder = Folder
            _FileFilters = FileFilters
            DataGridViewForm_Files.MultiSelect = MultiSelect
            _FileNameMustBeginWith = FileNameMustBeginWith
            _ExcludeFileNamesBeginningWithList = ExcludeFileNamesBeginningWithList

            TextBoxForm_CurrentDirectory.StartingFolderName = Folder
            TextBoxForm_CurrentDirectory.Text = Folder
            TextBoxForm_CurrentDirectory.Enabled = AllowDirectorySelection

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim FileInfoList As Generic.List(Of System.IO.FileInfo) = Nothing
            Dim FileRemoved As Boolean = False
            Dim RemoveFile As Boolean = False

            If My.Computer.FileSystem.DirectoryExists(_Folder) Then

                FileInfoList = My.Computer.FileSystem.GetDirectoryInfo(_Folder).GetFiles().ToList

                For Each FileInfo In FileInfoList.ToList

                    FileRemoved = False

                    If _FileFilters IsNot Nothing AndAlso _FileFilters.Count > 0 Then

                        RemoveFile = True

                        For Each FileFilter In _FileFilters

                            If FileFilter = FileSystem.FileFilters.Default Then

                                RemoveFile = False

                            ElseIf FileFilter = FileSystem.FileFilters.BUYandDATandTXT AndAlso (FileInfo.Extension.ToUpper.EndsWith(FileSystem.FileFilters.BUY.ToString.ToUpper) OrElse FileInfo.Extension.ToUpper.EndsWith(FileSystem.FileFilters.DAT.ToString.ToUpper) OrElse FileInfo.Extension.ToUpper.EndsWith(FileSystem.FileFilters.TXT.ToString.ToUpper)) Then

                                RemoveFile = False
                                Exit For

                            ElseIf FileFilter = FileSystem.FileFilters.XMLandSCXandPRP AndAlso (FileInfo.Extension.ToUpper.EndsWith(FileSystem.FileFilters.XML.ToString.ToUpper) OrElse
                                    FileInfo.Extension.ToUpper.EndsWith(FileSystem.FileFilters.SCX.ToString.ToUpper) OrElse FileInfo.Extension.ToUpper.EndsWith(FileSystem.FileFilters.PRP.ToString.ToUpper)) Then

                                RemoveFile = False
                                Exit For

                            Else

                                If FileInfo.Extension.ToUpper.EndsWith(FileFilter.ToString.ToUpper) Then

                                    RemoveFile = False
                                    Exit For

                                End If

                            End If

                        Next

                        If RemoveFile Then

                            FileRemoved = FileInfoList.Remove(FileInfo)

                        End If

                    End If

                    If FileRemoved = False Then

                        If _FileNameMustBeginWith IsNot Nothing AndAlso FileInfo.ToString.ToUpper.StartsWith(_FileNameMustBeginWith.ToUpper) = False Then

                            FileInfoList.Remove(FileInfo)

                        ElseIf _ExcludeFileNamesBeginningWithList IsNot Nothing Then

                            For Each ExcludeFile In _ExcludeFileNamesBeginningWithList

                                If FileInfo.ToString.ToUpper.StartsWith(ExcludeFile.ToUpper) Then

                                    FileInfoList.Remove(FileInfo)

                                End If

                            Next

                        End If

                    End If

                Next

            Else

                FileInfoList = New Generic.List(Of System.IO.FileInfo)

            End If

            DataGridViewForm_Files.DataSource = (From FileInfo In FileInfoList
                                                 Select New With {.File = FileInfo.Name,
                                                                  .FullName = FileInfo.FullName}).ToList

            DataGridViewForm_Files.CurrentView.BestFitColumns()

            If DataGridViewForm_Files.Columns("FullName") IsNot Nothing Then

                If DataGridViewForm_Files.Columns("FullName").Visible Then

                    DataGridViewForm_Files.Columns("FullName").Visible = False

                End If

            End If

            ButtonForm_Select.Enabled = DataGridViewForm_Files.HasASelectedRow

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal Folder As String, ByVal FileFilters As Generic.List(Of AdvantageFramework.FileSystem.FileFilters), ByVal MultiSelect As Boolean, ByRef Files() As String,
                                              Optional ByVal FileNameMustBeginWith As String = Nothing, Optional ByVal ExcludeFileNamesBeginningWithList As Generic.List(Of String) = Nothing, Optional ByVal AllowDirectorySelection As Boolean = False) As Windows.Forms.DialogResult

            'objects
            Dim FolderBrowserDialog As AdvantageFramework.WinForm.Presentation.FolderBrowserDialog = Nothing

            FolderBrowserDialog = New AdvantageFramework.WinForm.Presentation.FolderBrowserDialog(Folder, FileFilters, MultiSelect, FileNameMustBeginWith, ExcludeFileNamesBeginningWithList, AllowDirectorySelection)

            ShowFormDialog = FolderBrowserDialog.ShowDialog()

            Files = FolderBrowserDialog.Files

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub FolderBrowserDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            LoadGrid()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewForm_Files_Click(sender As Object, e As System.EventArgs) Handles DataGridViewForm_Files.Click

            ButtonForm_Select.Enabled = DataGridViewForm_Files.HasASelectedRow

        End Sub
        Private Sub DataGridViewForm_Files_RowDoubleClickEvent() Handles DataGridViewForm_Files.RowDoubleClickEvent

            ButtonForm_Select.PerformClick()

        End Sub
        Private Sub DataGridViewForm_Files_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Files.SelectionChangedEvent

            ButtonForm_Select.Enabled = DataGridViewForm_Files.HasASelectedRow

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_Select_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Select.Click

            If DataGridViewForm_Files.HasASelectedRow Then

                _Files = DataGridViewForm_Files.GetAllSelectedRowsCellValues(1).OfType(Of String).ToArray

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        End Sub
        Private Sub TextBoxForm_CurrentDirectory_TextChanged(sender As Object, e As EventArgs) Handles TextBoxForm_CurrentDirectory.TextChanged

            If Me.FormShown Then

                TextBoxForm_CurrentDirectory.StartingFolderName = TextBoxForm_CurrentDirectory.GetText

                _Folder = TextBoxForm_CurrentDirectory.GetText

                LoadGrid()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
