Namespace Maintenance.Client.Presentation

    Public Class ClientMappingSetupForm

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
            Dim Products As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
            Dim ClientCrossReferences As Generic.List(Of AdvantageFramework.Database.Entities.ClientCrossReference) = Nothing

            If ComboBoxRecordSource_RecordSource.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ClientCrossReferences = New Generic.List(Of AdvantageFramework.Database.Entities.ClientCrossReference)

                        Products = AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext, False, False).ToList

                        For Each CCR In AdvantageFramework.Database.Procedures.ClientCrossReference.LoadByRecordSourceID(DbContext, ComboBoxRecordSource_RecordSource.GetSelectedValue).ToList

                            If String.IsNullOrWhiteSpace(CCR.DivisionCode) AndAlso String.IsNullOrWhiteSpace(CCR.DivisionCode) Then

                                If Products.Any(Function(Entity) Entity.ClientCode = CCR.ClientCode) Then

                                    ClientCrossReferences.Add(CCR)

                                End If

                            ElseIf String.IsNullOrWhiteSpace(CCR.DivisionCode) = False AndAlso String.IsNullOrWhiteSpace(CCR.ProductCode) Then

                                If Products.Any(Function(Entity) Entity.ClientCode = CCR.ClientCode AndAlso Entity.DivisionCode = CCR.DivisionCode) Then

                                    ClientCrossReferences.Add(CCR)

                                End If

                            ElseIf String.IsNullOrWhiteSpace(CCR.DivisionCode) = False AndAlso String.IsNullOrWhiteSpace(CCR.ProductCode) = False Then

                                If Products.Any(Function(Entity) Entity.ClientCode = CCR.ClientCode AndAlso Entity.DivisionCode = CCR.DivisionCode AndAlso Entity.Code = CCR.ProductCode) Then

                                    ClientCrossReferences.Add(CCR)

                                End If

                            End If

                        Next

                        DataGridViewForm_ClientMapping.DataSource = ClientCrossReferences

                    End Using

                End Using

            Else

                DataGridViewForm_ClientMapping.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.ClientCrossReference)

            End If

            DataGridViewForm_ClientMapping.CurrentView.BestFitColumns()

        End Sub
        Private Sub CheckForUnsavedChanges()

            If Me.CheckUserEntryChangedSetting Then

                DataGridViewForm_ClientMapping.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    If Me.Validator Then

                        Me.ShowWaitForm("Saving...")
                        Me.FormAction = WinForm.Presentation.FormActions.Saving
                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                        Try

                            Save()

                        Catch ex As Exception

                        End Try

                        Me.CloseWaitForm()
                        Me.FormAction = WinForm.Presentation.FormActions.None
                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                        Me.ClearChanged()
                        Me.ClearValidations()

                    End If

                End If

            End If

        End Sub
        Private Sub Save()

            'objects
            Dim ClientCrossReferences As Generic.List(Of AdvantageFramework.Database.Entities.ClientCrossReference) = Nothing

            If DataGridViewForm_ClientMapping.HasRows Then

                DataGridViewForm_ClientMapping.CurrentView.CloseEditorForUpdating()

                ClientCrossReferences = DataGridViewForm_ClientMapping.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ClientCrossReference)().ToList


                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each ClientCrossReference In ClientCrossReferences

                        AdvantageFramework.Database.Procedures.ClientCrossReference.Update(DbContext, ClientCrossReference)

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

            If ComboBoxRecordSource_RecordSource.HasASelectedValue Then

                DataGridViewForm_ClientMapping.Enabled = True
                ButtonItemActions_Export.Enabled = True

                If DataGridViewForm_ClientMapping.IsNewItemRow Then

                    ButtonItemActions_Cancel.Enabled = True
                    ButtonItemActions_Save.Enabled = False
                    ButtonItemActions_Delete.Enabled = False

                Else

                    ButtonItemActions_Cancel.Enabled = False
                    ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                    ButtonItemActions_Delete.Enabled = DataGridViewForm_ClientMapping.HasASelectedRow

                End If

            Else

                DataGridViewForm_ClientMapping.Enabled = False
                ButtonItemActions_Export.Enabled = False
                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ClientMappingSetupForm As Presentation.ClientMappingSetupForm = Nothing

            ClientMappingSetupForm = New Presentation.ClientMappingSetupForm()

            ClientMappingSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientMappingSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemRecordSource_Manage.Image = AdvantageFramework.My.Resources.RecordSourceImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ComboBoxRecordSource_RecordSource.ByPassUserEntryChanged = True

            LoadRecordSources()

            LoadGrid()

            EnableOrDisableActions()

        End Sub
        Private Sub ClientMappingSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = False

        End Sub
        Private Sub ClientMappingSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

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

            DataGridViewForm_ClientMapping.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

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
            Dim ClientCrossReference As AdvantageFramework.Database.Entities.ClientCrossReference = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_ClientMapping.HasASelectedRow Then

                DataGridViewForm_ClientMapping.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Deleting...")
                    Me.FormAction = WinForm.Presentation.FormActions.Deleting

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_ClientMapping.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    ClientCrossReference = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    ClientCrossReference = Nothing
                                End Try

                                If ClientCrossReference IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.ClientCrossReference.Delete(DbContext, ClientCrossReference) Then

                                        DataGridViewForm_ClientMapping.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()
                    Me.FormAction = WinForm.Presentation.FormActions.None

                    If DataGridViewForm_ClientMapping.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_ClientMapping.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_ClientMapping_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_ClientMapping.InitNewRowEvent

            If TypeOf DataGridViewForm_ClientMapping.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Entities.ClientCrossReference Then

                DirectCast(DataGridViewForm_ClientMapping.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.ClientCrossReference).RecordSourceID = ComboBoxRecordSource_RecordSource.GetSelectedValue

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_ClientMapping_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_ClientMapping.AddNewRowEvent

            'objects
            Dim ClientCrossReference As AdvantageFramework.Database.Entities.ClientCrossReference = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.ClientCrossReference Then

                Me.ShowWaitForm("Adding...")
                Me.FormAction = WinForm.Presentation.FormActions.Adding

                Try

                    ClientCrossReference = RowObject

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If ClientCrossReference.IsEntityBeingAdded() Then

                            ClientCrossReference.DbContext = DbContext

                            AdvantageFramework.Database.Procedures.ClientCrossReference.Insert(DbContext, ClientCrossReference)

                        End If

                    End Using

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()
                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub DataGridViewForm_ClientMapping_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_ClientMapping.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ComboBoxRecordSource_RecordSource_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxRecordSource_RecordSource.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                CheckForUnsavedChanges()

                Me.ShowWaitForm("Loading...")
                Me.FormAction = WinForm.Presentation.FormActions.Loading

                Try

                    LoadGrid()

                    EnableOrDisableActions()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()
                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
