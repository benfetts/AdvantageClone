Namespace Maintenance.ProjectManagement.Presentation

    Public Class SalesClassFormatSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



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

                DataGridViewLeftSection_SalesClasses.DataSource = AdvantageFramework.Database.Procedures.SalesClass.Load(DbContext)

            End Using

            DataGridViewLeftSection_SalesClasses.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            Dim SalesClassCode As String = Nothing

            If DataGridViewLeftSection_SalesClasses.HasOnlyOneSelectedRow Then

                SalesClassCode = DataGridViewLeftSection_SalesClasses.CurrentView.GetRowCellValue(DataGridViewLeftSection_SalesClasses.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.SalesClass.Properties.Code.ToString)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewRightSection_SalesClassFormats.DataSource = AdvantageFramework.Database.Procedures.SalesClassFormat.LoadBySalesClassCode(DbContext, SalesClassCode).ToList

                End Using

            Else

                DataGridViewRightSection_SalesClassFormats.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.SalesClassFormat)

            End If

            DataGridViewRightSection_SalesClassFormats.CurrentView.BestFitColumns()

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            ButtonItemActions_Save.RaiseClick()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Sub EnableOrDisableActions()

            DataGridViewRightSection_SalesClassFormats.Enabled = DataGridViewLeftSection_SalesClasses.HasOnlyOneSelectedRow
            ButtonItemExport_All.Enabled = True

            If DataGridViewRightSection_SalesClassFormats.Enabled Then

                ButtonItemExport_CurrentView.Enabled = True

                If DataGridViewRightSection_SalesClassFormats.IsNewItemRow Then

                    ButtonItemActions_Cancel.Enabled = True
                    ButtonItemActions_Save.Enabled = False
                    ButtonItemActions_Delete.Enabled = False

                Else

                    ButtonItemActions_Cancel.Enabled = False
                    ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                    ButtonItemActions_Delete.Enabled = DataGridViewRightSection_SalesClassFormats.HasASelectedRow

                End If

            Else

                ButtonItemExport_CurrentView.Enabled = False

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim SalesClassFormatSetupForm As AdvantageFramework.Maintenance.ProjectManagement.Presentation.SalesClassFormatSetupForm = Nothing

            SalesClassFormatSetupForm = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.SalesClassFormatSetupForm

            SalesClassFormatSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub SalesClassFormatSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            DataGridViewLeftSection_SalesClasses.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_SalesClasses.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Try

                DataGridViewRightSection_SalesClassFormats.CurrentView.AFActiveFilterString = "[IsInactive] = 1"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub SalesClassFormatSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub SalesClassFormatSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ClientSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_SalesClasses.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemExport_All_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_All.Click

            'objects
            Dim SalesClassFormatList As Generic.List(Of AdvantageFramework.Database.Entities.SalesClassFormat) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SalesClassFormatList = New Generic.List(Of AdvantageFramework.Database.Entities.SalesClassFormat)

                For Each SalesClass In AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext).Include("SalesClassFormats").ToList

                    SalesClassFormatList.AddRange(SalesClass.SalesClassFormats.ToList)

                Next

                DataGridViewRightSection_AllSalesClassFormats.DataSource = (From SalesClassFormat In SalesClassFormatList
                                                                            Select [SalesClass] = SalesClassFormat.SalesClass.ToString,
                                                                                   [Code] = SalesClassFormat.Code,
                                                                                   [Description] = SalesClassFormat.Description,
                                                                                   [IsInactive] = Not CBool(SalesClassFormat.IsInactive.GetValueOrDefault(0))).ToList

                If DataGridViewRightSection_AllSalesClassFormats.Columns("SalesClass") IsNot Nothing Then

                    DataGridViewRightSection_AllSalesClassFormats.Columns("SalesClass").Visible = True
                    DataGridViewRightSection_AllSalesClassFormats.Columns("SalesClass").Group()

                End If

                If DataGridViewRightSection_AllSalesClassFormats.Columns("IsInactive") IsNot Nothing Then

                    DataGridViewRightSection_AllSalesClassFormats.Columns("IsInactive").ColumnEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemCheckBox(False, GetType(Boolean))

                End If

                DataGridViewRightSection_AllSalesClassFormats.OptionsView.ShowViewCaption = False

                DataGridViewRightSection_AllSalesClassFormats.CurrentView.BestFitColumns()

                DataGridViewRightSection_AllSalesClassFormats.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

            End Using

        End Sub
        Private Sub ButtonItemExport_CurrentView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_CurrentView.Click

            'objects
            Dim SalesClassFormatList As Generic.List(Of AdvantageFramework.Database.Entities.SalesClassFormat) = Nothing
            Dim SelectedSalesClass As AdvantageFramework.Database.Entities.SalesClass = Nothing
            Dim SalesClassCode As String = ""

            If DataGridViewLeftSection_SalesClasses.HasOnlyOneSelectedRow Then

                SalesClassCode = DataGridViewLeftSection_SalesClasses.GetFirstSelectedRowBookmarkValue

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    SalesClassFormatList = New Generic.List(Of AdvantageFramework.Database.Entities.SalesClassFormat)

                    Try

                        SelectedSalesClass = (From Entity In AdvantageFramework.Database.Procedures.SalesClass.Load(DbContext).Include("SalesClassFormats")
                                              Where Entity.Code = SalesClassCode
                                              Select Entity).SingleOrDefault

                    Catch ex As Exception
                        SelectedSalesClass = Nothing
                    End Try

                    If SelectedSalesClass IsNot Nothing Then

                        SalesClassFormatList.AddRange(SelectedSalesClass.SalesClassFormats.ToList)

                    End If
                    
                    DataGridViewRightSection_AllSalesClassFormats.DataSource = (From SalesClassFormat In SalesClassFormatList
                                                                                Select [SalesClass] = SalesClassFormat.SalesClass.ToString,
                                                                                       [Code] = SalesClassFormat.Code,
                                                                                       [Description] = SalesClassFormat.Description,
                                                                                       [IsInactive] = Not CBool(SalesClassFormat.IsInactive.GetValueOrDefault(0))).ToList

                    If DataGridViewRightSection_AllSalesClassFormats.Columns("SalesClass") IsNot Nothing Then

                        DataGridViewRightSection_AllSalesClassFormats.Columns("SalesClass").Visible = True
                        DataGridViewRightSection_AllSalesClassFormats.Columns("SalesClass").Group()

                    End If

                    If DataGridViewRightSection_AllSalesClassFormats.Columns("IsInactive") IsNot Nothing Then

                        DataGridViewRightSection_AllSalesClassFormats.Columns("IsInactive").ColumnEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemCheckBox(False, GetType(Boolean))

                    End If

                    DataGridViewRightSection_AllSalesClassFormats.OptionsView.ShowViewCaption = False

                    DataGridViewRightSection_AllSalesClassFormats.CurrentView.BestFitColumns()

                    DataGridViewRightSection_AllSalesClassFormats.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

                End Using

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim SalesClassFormats As Generic.List(Of AdvantageFramework.Database.Entities.SalesClassFormat) = Nothing

            If DataGridViewLeftSection_SalesClasses.HasOnlyOneSelectedRow AndAlso DataGridViewRightSection_SalesClassFormats.HasRows Then

                DataGridViewRightSection_SalesClassFormats.CurrentView.CloseEditorForUpdating()

                SalesClassFormats = DataGridViewRightSection_SalesClassFormats.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.SalesClassFormat)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each SalesClassFormat In SalesClassFormats

                            AdvantageFramework.Database.Procedures.SalesClassFormat.Update(DbContext, SalesClassFormat)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewLeftSection_SalesClasses.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim SalesClassFormat As AdvantageFramework.Database.Entities.SalesClassFormat = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewLeftSection_SalesClasses.HasOnlyOneSelectedRow AndAlso DataGridViewRightSection_SalesClassFormats.HasASelectedRow Then

                DataGridViewRightSection_SalesClassFormats.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewRightSection_SalesClassFormats.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    SalesClassFormat = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    SalesClassFormat = Nothing
                                End Try

                                If SalesClassFormat IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.SalesClassFormat.Delete(DbContext, SalesClassFormat) Then

                                        DataGridViewRightSection_SalesClassFormats.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewRightSection_SalesClassFormats.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewRightSection_SalesClassFormats.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewLeftSection_SalesClasses_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_SalesClasses.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_SalesClasses_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_SalesClasses.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewRightSection_SalesClassFormats_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewRightSection_SalesClassFormats.InitNewRowEvent

            'objects
            Dim SalesClassFormat As AdvantageFramework.Database.Entities.SalesClassFormat = Nothing

            Try

                If TypeOf DataGridViewRightSection_SalesClassFormats.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Entities.SalesClassFormat Then

                    SalesClassFormat = DataGridViewRightSection_SalesClassFormats.CurrentView.GetRow(e.RowHandle)

                    SalesClassFormat.SalesClassCode = DataGridViewLeftSection_SalesClasses.CurrentView.GetRowCellValue(DataGridViewLeftSection_SalesClasses.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.SalesClass.Properties.Code.ToString)

                End If

            Catch ex As Exception

            End Try

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRightSection_SalesClassFormats_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewRightSection_SalesClassFormats.AddNewRowEvent

            'objects
            Dim SalesClassFormat As AdvantageFramework.Database.Entities.SalesClassFormat = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.SalesClassFormat Then

                Me.ShowWaitForm("Processing...")

                Try

                    SalesClassFormat = RowObject

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If SalesClassFormat.IsEntityBeingAdded() Then

                            SalesClassFormat.DbContext = DbContext

                            AdvantageFramework.Database.Procedures.SalesClassFormat.Insert(DbContext, SalesClassFormat)

                        End If

                    End Using

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewRightSection_SalesClassFormats_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRightSection_SalesClassFormats.CellValueChangingEvent

            'objects
            Dim SalesClassFormat As AdvantageFramework.Database.Entities.SalesClassFormat = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.SalesClassFormat.Properties.IsInactive.ToString Then

                Try

                    SalesClassFormat = DataGridViewRightSection_SalesClassFormats.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    SalesClassFormat = Nothing
                End Try

                If SalesClassFormat IsNot Nothing Then

                    Try

                        SalesClassFormat.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        SalesClassFormat.IsInactive = SalesClassFormat.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.SalesClassFormat.Update(DbContext, SalesClassFormat)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewRightSection_SalesClassFormats_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewRightSection_SalesClassFormats.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
