Namespace Maintenance.General.Presentation

    Public Class ImageSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _AgencyLogoPath As String = ""
        Protected _IsAgencyASP As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewForm_Image.DataSource = AdvantageFramework.Database.Procedures.Image.Load(DbContext).ToList

            End Using

            DataGridViewForm_Image.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Add.Enabled = True
            ButtonItemActions_Delete.Enabled = DataGridViewForm_Image.HasASelectedRow
            ButtonItemActions_View.Enabled = DataGridViewForm_Image.HasOnlyOneSelectedRow

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As System.Windows.Forms.DialogResult

            'objects
            Dim ImageSetupForm As AdvantageFramework.Maintenance.General.Presentation.ImageSetupForm = Nothing

            ImageSetupForm = New AdvantageFramework.Maintenance.General.Presentation.ImageSetupForm()

            ShowFormDialog = ImageSetupForm.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ImageSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_View.Image = AdvantageFramework.My.Resources.ViewImage

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                _IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                If _IsAgencyASP Then

                    _AgencyLogoPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadLogoPath(DbContext), "\")

                End If

            End Using

            LoadGrid()

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim File As String = ""
            Dim Files() As String = Nothing
            Dim FileInfo As System.IO.FileInfo = Nothing
            Dim Image As AdvantageFramework.Database.Entities.Image = Nothing
            Dim ReloadGrid As Boolean = False

            If _IsAgencyASP Then

                AdvantageFramework.WinForm.Presentation.FolderBrowserDialog.ShowFormDialog(_AgencyLogoPath, Nothing, False, Files)

                If Files IsNot Nothing AndAlso Files.Count > 0 Then

                    If Files IsNot Nothing AndAlso Files.Count > 0 Then

                        Try

                            File = Files(0)

                        Catch ex As Exception
                            File = ""
                        End Try

                    End If

                End If

            Else

                File = AdvantageFramework.WinForm.Presentation.SelectFileToOpen("", , "Select Image")

            End If

            If String.IsNullOrEmpty(File) = False Then

                If System.IO.File.Exists(File) Then

                    If AdvantageFramework.FileSystem.IsValidImage(File) Then

                        FileInfo = New System.IO.FileInfo(File)

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Image = New AdvantageFramework.Database.Entities.Image

                            Image.Name = FileInfo.Name
                            Image.Description = ""
                            Image.Bytes = My.Computer.FileSystem.ReadAllBytes(File)

                            ReloadGrid = AdvantageFramework.Database.Procedures.Image.Insert(DbContext, Image)

                        End Using

                        If ReloadGrid Then

                            LoadGrid()
                            EnableOrDisableActions()

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please select a valid image file.")

                    End If


                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a valid file.")

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim Image As AdvantageFramework.Database.Entities.Image = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_Image.HasASelectedRow Then

                DataGridViewForm_Image.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_Image.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    Image = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    Image = Nothing
                                End Try

                                If Image IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.Image.Delete(DbContext, Image) Then

                                        DataGridViewForm_Image.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_Image.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_View_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_View.Click

            'objects
            Dim Image As AdvantageFramework.Database.Entities.Image = Nothing

            If DataGridViewForm_Image.HasOnlyOneSelectedRow Then

                Try

                    Image = DataGridViewForm_Image.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    Image = Nothing
                End Try

                If Image IsNot Nothing Then

                    AdvantageFramework.WinForm.Presentation.ImageDialog.ShowFormDialog(Image.Name, Image.Bytes)

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Image_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Image.CellValueChangingEvent

            'objects
            Dim Image As AdvantageFramework.Database.Entities.Image = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.Image.Properties.Description.ToString Then

                Try

                    Image = DataGridViewForm_Image.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    Image = Nothing
                End Try

                If Image IsNot Nothing Then

                    Try

                        Image.Description = e.Value

                    Catch ex As Exception
                        Image.Description = Image.Description
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.Image.Update(DbContext, Image)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Image_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewForm_Image.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace