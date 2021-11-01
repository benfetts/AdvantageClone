Namespace Importing.Presentation

    Public Class ImportExcludeDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ImportTemplateID As Integer = Nothing
        Private _PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ImportTemplateID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _ImportTemplateID = ImportTemplateID

        End Sub
        Private Sub LoadGrid()

            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
            Dim ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail) = Nothing
            Dim ClassType As System.Type = Nothing
            Dim PropertyDescriptor As ComponentModel.PropertyDescriptor = Nothing
            Dim StringFieldNames As Generic.List(Of String) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, _ImportTemplateID)

                If ImportTemplate IsNot Nothing Then

                    Select Case ImportTemplate.Type

                        Case AdvantageFramework.Importing.ImportTemplateTypes.PTO_Default

                            ClassType = GetType(AdvantageFramework.Database.Entities.ImportPTOStaging)

                    End Select

                    If ClassType IsNot Nothing Then

                        Try

                            _PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(ClassType).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                        Catch ex As Exception

                        End Try

                        ImportTemplateDetails = AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                        StringFieldNames = New Generic.List(Of String)

                        For Each ImportTemplateDetail In ImportTemplateDetails

                            PropertyDescriptor = _PropertyDescriptorsList.Where(Function(Prop) Prop.Name = ImportTemplateDetail.FieldName).SingleOrDefault

                            If PropertyDescriptor IsNot Nothing AndAlso PropertyDescriptor.PropertyType Is GetType(System.String) Then

                                StringFieldNames.Add(ImportTemplateDetail.FieldName)

                            End If

                        Next

                        DataGridViewLeftSection_FieldNames.DataSource = (From Entity In ImportTemplateDetails
                                                                         Where StringFieldNames.Contains(Entity.FieldName)
                                                                         Select New With {.FieldName = Entity.FieldName}).ToList

                        DataGridViewLeftSection_FieldNames.CurrentView.BestFitColumns()

                    End If

                End If

            End Using

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewRightSection_ExcludeValues.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Delete.Enabled = DataGridViewRightSection_ExcludeValues.HasASelectedRow

            End If

        End Sub
        Private Sub LoadExcludeValues()

            Dim FieldName As String = Nothing
            'Dim PropertyDescriptor As ComponentModel.PropertyDescriptor = Nothing
            Dim ImportTemplateExcludeList As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateExclude) = Nothing

            FieldName = DataGridViewLeftSection_FieldNames.GetFirstSelectedRowBookmarkValue(0)

            'PropertyDescriptor = _PropertyDescriptorsList.Where(Function(Prop) Prop.Name = FieldName).SingleOrDefault

            'If PropertyDescriptor.PropertyType Is GetType(System.String) Then

            '    DataGridViewRightSection_ExcludeValues.CurrentView.ObjectType = GetType(System.String)

            'ElseIf PropertyDescriptor.PropertyType Is GetType(System.DateTime) OrElse PropertyDescriptor.PropertyType Is GetType(nullable(Of System.DateTime)) Then

            '    DataGridViewRightSection_ExcludeValues.CurrentView.ObjectType = GetType(System.DateTime)

            'End If

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                ImportTemplateExcludeList = AdvantageFramework.Database.Procedures.ImportTemplateExclude.LoadByImportTemplateIDAndFieldName(DataContext, _ImportTemplateID, FieldName).ToList

            End Using

            DataGridViewRightSection_ExcludeValues.DataSource = ImportTemplateExcludeList

            DataGridViewRightSection_ExcludeValues.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ImportTemplateID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim ImportExcludeDialog As AdvantageFramework.Importing.Presentation.ImportExcludeDialog = Nothing

            ImportExcludeDialog = New AdvantageFramework.Importing.Presentation.ImportExcludeDialog(ImportTemplateID)

            ShowFormDialog = ImportExcludeDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ImportExcludeDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage

            LoadGrid()

            EnableOrDisableActions()

        End Sub
        Private Sub ImportExcludeDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If DataGridViewLeftSection_FieldNames.HasASelectedRow Then

                LoadExcludeValues()

            End If

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewRightSection_ExcludeValues.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ImportTemplateExclude As AdvantageFramework.Database.Entities.ImportTemplateExclude = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewRightSection_ExcludeValues.HasASelectedRow Then

                DataGridViewRightSection_ExcludeValues.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                    Me.FormAction = WinForm.Presentation.FormActions.Deleting

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewRightSection_ExcludeValues.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                                Try

                                    ImportTemplateExclude = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    ImportTemplateExclude = Nothing
                                End Try

                                If ImportTemplateExclude IsNot Nothing Then

                                    DataContext.ImportTemplateExcludes.Attach(ImportTemplateExclude)

                                    If AdvantageFramework.Database.Procedures.ImportTemplateExclude.Delete(DataContext, ImportTemplateExclude) Then

                                        DataGridViewRightSection_ExcludeValues.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.Cursor = Windows.Forms.Cursors.Default
                    Me.FormAction = WinForm.Presentation.FormActions.None

                    If DataGridViewRightSection_ExcludeValues.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub DataGridViewLeftSection_FieldNames_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_FieldNames.SelectionChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadExcludeValues()

            End If

        End Sub
        Private Sub DataGridViewRightSection_ExcludeValues_AddNewRowEvent(RowObject As Object) Handles DataGridViewRightSection_ExcludeValues.AddNewRowEvent

            'objects
            Dim ImportTemplateExclude As AdvantageFramework.Database.Entities.ImportTemplateExclude = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.ImportTemplateExclude Then

                Me.Cursor = Windows.Forms.Cursors.WaitCursor

                ImportTemplateExclude = RowObject

                If ImportTemplateExclude.DatabaseAction = Database.Methods.Action.Inserting Then

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ImportTemplateExclude.DataContext = DataContext

                        ImportTemplateExclude.ImportTemplateID = _ImportTemplateID
                        ImportTemplateExclude.FieldName = DataGridViewLeftSection_FieldNames.GetFirstSelectedRowBookmarkValue(0)

                        AdvantageFramework.Database.Procedures.ImportTemplateExclude.Insert(DataContext, ImportTemplateExclude)

                    End Using

                End If

                Me.Cursor = Windows.Forms.Cursors.Default

            End If

        End Sub
        Private Sub DataGridViewRightSection_ExcludeValues_BeforeAddNewRowEvent(RowObject As Object, ByRef Cancel As Boolean) Handles DataGridViewRightSection_ExcludeValues.BeforeAddNewRowEvent

            Dim ImportTemplateExclude As AdvantageFramework.Database.Entities.ImportTemplateExclude = Nothing
            Dim FieldName As String = Nothing

            ImportTemplateExclude = RowObject

            FieldName = DataGridViewLeftSection_FieldNames.GetFirstSelectedRowBookmarkValue(0)

            If ImportTemplateExclude IsNot Nothing Then

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    If (From Entity In AdvantageFramework.Database.Procedures.ImportTemplateExclude.LoadByImportTemplateIDAndFieldName(DataContext, _ImportTemplateID, FieldName)
                        Where Entity.ExcludeValue.ToUpper = ImportTemplateExclude.ExcludeValue.ToUpper
                        Select Entity).Any Then

                        Cancel = True

                        AdvantageFramework.WinForm.MessageBox.Show("Exclude value already exists!")

                    End If

                End Using

            End If

        End Sub
        Private Sub DataGridViewRightSection_ExcludeValues_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewRightSection_ExcludeValues.InitNewRowEvent

            If TypeOf DataGridViewRightSection_ExcludeValues.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Entities.ImportTemplateExclude Then

                DirectCast(DataGridViewRightSection_ExcludeValues.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.ImportTemplateExclude).DatabaseAction = Database.Methods.Action.Inserting

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRightSection_ExcludeValues_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewRightSection_ExcludeValues.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRightSection_ExcludeValues_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewRightSection_ExcludeValues.ShowingEditorEvent

            If Not DataGridViewRightSection_ExcludeValues.IsNewItemOrAutoFilterRow Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace