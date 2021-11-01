Namespace Maintenance.Accounting.Presentation

    Public Class VendorMappingSetupForm

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

            'objects
            Dim VendorCodes As Generic.List(Of String) = Nothing

            If ComboBoxRecordSource_RecordSource.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    VendorCodes = AdvantageFramework.Database.Procedures.Vendor.LoadWithOfficeLimits(DbContext, Me.Session).Select(Function(Entity) Entity.Code).ToList

                    If ComboBoxRecordSource_RecordSource.SelectedItem.Name = "DoubleClick" Then

                        DataGridViewForm_VendorDCMMapping.DataSource = (From Entity In DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorDCMMapping)("exec [advsp_vendor_dcm_mapping_load]").ToList
                                                                        Where VendorCodes.Contains(Entity.VendorCode)
                                                                        Select Entity).ToList

                        DataGridViewForm_VendorDCMMapping.CurrentView.BestFitColumns()

                    Else

                        DataGridViewForm_VendorMapping.DataSource = (From Entity In AdvantageFramework.Database.Procedures.VendorCrossReference.LoadByRecordSourceID(DbContext, ComboBoxRecordSource_RecordSource.GetSelectedValue)
                                                                     Where VendorCodes.Contains(Entity.VendorCode)
                                                                     Select Entity).ToList

                    End If

                End Using

            Else

                If ComboBoxRecordSource_RecordSource.SelectedItem.Name = "DoubleClick" Then

                    DataGridViewForm_VendorDCMMapping.DataSource = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorDCMMapping)

                Else

                    DataGridViewForm_VendorMapping.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.VendorCrossReference)

                End If

            End If

            DataGridViewForm_VendorMapping.CurrentView.BestFitColumns()

        End Sub
        Private Sub Save()

            'objects
            Dim VendorCrossReferences As Generic.List(Of AdvantageFramework.Database.Entities.VendorCrossReference) = Nothing

            If DataGridViewForm_VendorMapping.HasRows Then

                DataGridViewForm_VendorMapping.CurrentView.CloseEditorForUpdating()

                VendorCrossReferences = DataGridViewForm_VendorMapping.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.VendorCrossReference)().ToList

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each VendorCrossReference In VendorCrossReferences

                        AdvantageFramework.Database.Procedures.VendorCrossReference.Update(DbContext, VendorCrossReference)

                    Next

                End Using

            End If

        End Sub
        Private Sub LoadRecordSources(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim QuickBooksRecordSourceID As Integer = -1

            If AdvantageFramework.Quickbooks.IsQuickBooksEnabled(DbContext) Then

                QuickBooksRecordSourceID = AdvantageFramework.Quickbooks.GetQuickBooksRecordSourceID(DbContext)

            End If

            ComboBoxRecordSource_RecordSource.DataSource = (From Entity In AdvantageFramework.Database.Procedures.RecordSource.Load(DbContext)
                                                            Where Entity.ID <> QuickBooksRecordSourceID
                                                            Select Entity).ToList

        End Sub
        Private Sub LoadRecordSources()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                LoadRecordSources(DbContext)

            End Using

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Export.Enabled = ComboBoxRecordSource_RecordSource.HasASelectedValue

            If DataGridViewForm_VendorMapping.Visible Then

                If ComboBoxRecordSource_RecordSource.HasASelectedValue Then

                    DataGridViewForm_VendorMapping.Enabled = True

                Else

                    If DataGridViewForm_VendorMapping.IsNewItemRow Then

                        DataGridViewForm_VendorMapping.CancelNewItemRow()

                    End If

                    DataGridViewForm_VendorMapping.CurrentView.CloseEditorForUpdating()

                    DataGridViewForm_VendorMapping.Enabled = False

                End If

                If DataGridViewForm_VendorMapping.IsNewItemRow Then

                    ButtonItemActions_Cancel.Enabled = True
                    ButtonItemActions_Save.Enabled = False
                    ButtonItemActions_Delete.Enabled = False

                Else

                    ButtonItemActions_Cancel.Enabled = False
                    ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                    ButtonItemActions_Delete.Enabled = DataGridViewForm_VendorMapping.HasASelectedRow

                End If

            ElseIf DataGridViewForm_VendorDCMMapping.Visible Then

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = DataGridViewForm_VendorDCMMapping.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim VendorMappingSetupForm As Presentation.VendorMappingSetupForm = Nothing

            VendorMappingSetupForm = New Presentation.VendorMappingSetupForm()

            VendorMappingSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub VendorMappingSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemRecordSource_Manage.Image = AdvantageFramework.My.Resources.RecordSourceImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ComboBoxRecordSource_RecordSource.ByPassUserEntryChanged = True

            LoadRecordSources()

            LoadGrid()

        End Sub
        Private Sub VendorMappingSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            EnableOrDisableActions()

        End Sub
        Private Sub VendorMappingSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = False

        End Sub
        Private Sub VendorMappingSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemRecordSource_Manage_Click(sender As Object, e As EventArgs) Handles ButtonItemRecordSource_Manage.Click

            'objects
            Dim RecordSourceID As Integer = 0
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting AndAlso ButtonItemActions_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = False

                    Me.ShowWaitForm("Saving...")
                    Me.FormAction = WinForm.Presentation.FormActions.Saving
                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Save()

                        IsOkay = True

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                        IsOkay = False
                    End Try

                    Me.CloseWaitForm()
                    Me.FormAction = WinForm.Presentation.FormActions.None
                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                    If IsOkay Then

                        Me.ClearChanged()

                    End If

                    If IsOkay = False Then

                        If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                            IsOkay = True

                        End If

                    End If

                End If

            End If

            If IsOkay Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.RecordSource, False, False, Title:="Manage Record Sources") = Windows.Forms.DialogResult.OK Then

                    If ComboBoxRecordSource_RecordSource.HasASelectedValue Then

                        RecordSourceID = ComboBoxRecordSource_RecordSource.GetSelectedValue

                    End If

                    Me.ShowWaitForm("Loading...")
                    Me.FormAction = WinForm.Presentation.FormActions.Loading

                    Try

                        LoadRecordSources()

                        If RecordSourceID <> 0 Then

                            ComboBoxRecordSource_RecordSource.SelectedValue = RecordSourceID

                        End If

                    Catch ex As Exception

                    End Try

                    If ComboBoxRecordSource_RecordSource.HasASelectedValue Then

                        Try

                            LoadGrid()

                        Catch ex As Exception

                        End Try

                    End If

                    Me.CloseWaitForm()
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            If DataGridViewForm_VendorMapping.Visible Then

                DataGridViewForm_VendorMapping.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

            ElseIf DataGridViewForm_VendorDCMMapping.Visible Then

                DataGridViewForm_VendorDCMMapping.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim IsOkay As Boolean = False

            Me.ShowWaitForm("Saving...")
            Me.FormAction = WinForm.Presentation.FormActions.Saving
            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

            Try

                Save()

                IsOkay = True

            Catch ex As Exception
                AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                IsOkay = False
            End Try

            Me.CloseWaitForm()
            Me.FormAction = WinForm.Presentation.FormActions.None
            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            If IsOkay Then

                Me.ClearChanged()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim VendorCrossReference As AdvantageFramework.Database.Entities.VendorCrossReference = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim VendorDCMMappingID As Integer = 0

            If DataGridViewForm_VendorMapping.Visible = True AndAlso DataGridViewForm_VendorMapping.HasASelectedRow Then

                DataGridViewForm_VendorMapping.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Deleting...")
                    Me.FormAction = WinForm.Presentation.FormActions.Deleting

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_VendorMapping.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    VendorCrossReference = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    VendorCrossReference = Nothing
                                End Try

                                If VendorCrossReference IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.VendorCrossReference.Delete(DbContext, VendorCrossReference) Then

                                        DataGridViewForm_VendorMapping.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()
                    Me.FormAction = WinForm.Presentation.FormActions.None

                    If DataGridViewForm_VendorMapping.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            ElseIf DataGridViewForm_VendorDCMMapping.Visible = True AndAlso DataGridViewForm_VendorDCMMapping.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Deleting...")
                    Me.FormAction = WinForm.Presentation.FormActions.Deleting

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_VendorDCMMapping.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    VendorDCMMappingID = DirectCast(RowHandleAndDataBoundItem.Value, AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorDCMMapping).ID

                                    If AdvantageFramework.Database.Procedures.VendorDCMMapping.DeleteByID(DbContext, VendorDCMMappingID) Then

                                        DataGridViewForm_VendorDCMMapping.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                Catch ex As Exception

                                End Try

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()
                    Me.FormAction = WinForm.Presentation.FormActions.None

                    If DataGridViewForm_VendorDCMMapping.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_VendorMapping.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_VendorMapping_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_VendorMapping.InitNewRowEvent

            If TypeOf DataGridViewForm_VendorMapping.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Entities.VendorCrossReference Then

                DirectCast(DataGridViewForm_VendorMapping.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.VendorCrossReference).RecordSourceID = ComboBoxRecordSource_RecordSource.GetSelectedValue

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_VendorMapping_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_VendorMapping.AddNewRowEvent

            'objects
            Dim VendorCrossReference As AdvantageFramework.Database.Entities.VendorCrossReference = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.VendorCrossReference Then

                Me.ShowWaitForm("Adding...")
                Me.FormAction = WinForm.Presentation.FormActions.Adding

                Try

                    VendorCrossReference = RowObject

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If VendorCrossReference.IsEntityBeingAdded() Then

                            VendorCrossReference.DbContext = DbContext

                            AdvantageFramework.Database.Procedures.VendorCrossReference.Insert(DbContext, VendorCrossReference)

                        End If

                    End Using

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()
                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub DataGridViewForm_VendorMapping_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_VendorMapping.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ComboBoxRecordSource_RecordSource_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxRecordSource_RecordSource.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.ShowWaitForm("Loading...")
                Me.FormAction = WinForm.Presentation.FormActions.Loading

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                If ComboBoxRecordSource_RecordSource.SelectedItem.Name = "DoubleClick" Then

                    DataGridViewForm_VendorDCMMapping.Visible = True
                    DataGridViewForm_VendorMapping.Visible = False

                Else

                    DataGridViewForm_VendorDCMMapping.Visible = False
                    DataGridViewForm_VendorMapping.Visible = True

                End If

                EnableOrDisableActions()

                Me.CloseWaitForm()
                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub DataGridViewForm_VendorDCMMapping_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_VendorDCMMapping.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
