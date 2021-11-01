Namespace Maintenance.Media.Presentation

    Public Class AdSizeSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _IsDCEnabled As Boolean = False
        Private _ProfileID As Long? = Nothing 'just need an arbitrary ProfileID since sizes are universal across profiles

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

                DataGridViewForm_AdSize.DataSource = AdvantageFramework.Database.Procedures.AdSize.Load(DbContext).ToList

            End Using

            If _IsDCEnabled = False AndAlso DataGridViewForm_AdSize.CurrentView.Columns(AdvantageFramework.Database.Entities.AdSize.Properties.AdServerSizeID.ToString) IsNot Nothing Then

                DataGridViewForm_AdSize.CurrentView.Columns(AdvantageFramework.Database.Entities.AdSize.Properties.AdServerSizeID.ToString).Visible = False

            End If

            DataGridViewForm_AdSize.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_AdSize.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_AdSize.HasASelectedRow

            End If

        End Sub
        Private Sub SetIABStandardSizes()

            'objects
            Dim AdServerSizeDictionary As Dictionary(Of Long, String) = Nothing
            Dim AdSize As AdvantageFramework.Database.Entities.AdSize = Nothing
            Dim AddUpdateFailed As Boolean = False
            Dim ErrorMessage As String = ""
            Dim Sizes As Generic.List(Of String) = Nothing
            Dim DuplicateSizes As Generic.List(Of String) = Nothing
            Dim DuplicatesFound As Boolean = False

            If AdvantageFramework.GoogleServices.Service.DoubleClickGetSizes(Session, False, _ProfileID, AdServerSizeDictionary, ErrorMessage) Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Sizes = New Generic.List(Of String)

                    DuplicateSizes = New Generic.List(Of String)

                    For Each Item In AdServerSizeDictionary

                        If (From Entity In DbContext.GetQuery(Of Database.Entities.AdSize)
                            Where Entity.MediaType = "I" AndAlso
                                  Entity.Description.ToLower = Item.Value.ToLower AndAlso
                                  (Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0)
                            Select Entity).Count = 1 Then

                            AdSize = (From Entity In DbContext.GetQuery(Of Database.Entities.AdSize)
                                      Where Entity.MediaType = "I" AndAlso
                                        Entity.Description.ToLower = Item.Value.ToLower AndAlso
                                        (Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0)
                                      Select Entity).SingleOrDefault

                            If AdSize IsNot Nothing Then

                                AdSize.AdServerSizeID = Item.Key

                                If AdvantageFramework.Database.Procedures.AdSize.Update(DbContext, AdSize, ErrorMessage) = False Then

                                    AddUpdateFailed = True
                                    Sizes.Add(Item.Value)

                                End If

                            Else

                                AdSize = New AdvantageFramework.Database.Entities.AdSize
                                AdSize.DbContext = DbContext

                                AdSize.MediaType = "I"
                                AdSize.Code = Item.Value.Replace(" x ", "")
                                AdSize.Description = Item.Value
                                AdSize.AdServerSizeID = Item.Key
                                AdSize.IsInactive = 0

                                If AdvantageFramework.Database.Procedures.AdSize.Insert(DbContext, AdSize, ErrorMessage) = False Then

                                    AddUpdateFailed = True
                                    Sizes.Add(Item.Value)

                                End If

                            End If

                        ElseIf (From Entity In DbContext.GetQuery(Of Database.Entities.AdSize)
                                Where Entity.MediaType = "I" AndAlso
                                      Entity.Description.ToLower = Item.Value.ToLower AndAlso
                                      (Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0)
                                Select Entity).Count > 1 Then

                            DuplicatesFound = True
                            DuplicateSizes.Add(Item.Value)

                        End If

                    Next

                    If AddUpdateFailed Then

                        AdvantageFramework.WinForm.MessageBox.Show("Could not add the following:" & String.Join(", ", Sizes.ToList))

                    End If

                    If DuplicatesFound Then

                        AdvantageFramework.WinForm.MessageBox.Show("Duplicate ad size descriptions found.  Could not add the following:" & String.Join(", ", DuplicateSizes.ToList))

                    End If

                End Using

            Else

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub SetNonIABStandardSizes()

            'objects
            Dim AdServerSizeDictionary As Dictionary(Of Long, String) = Nothing
            Dim AddUpdateFailed As Boolean = False
            Dim ErrorMessage As String = ""
            Dim Sizes As Generic.List(Of String) = Nothing

            If AdvantageFramework.GoogleServices.Service.DoubleClickGetNonIABStandardSizes(Session, False, _ProfileID, AdServerSizeDictionary, ErrorMessage) Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Sizes = New Generic.List(Of String)

                    For Each AdSize In AdvantageFramework.Database.Procedures.AdSize.LoadAllActive(DbContext).Where(Function(Entity) Entity.MediaType = "I").ToList

                        If Not AdSize.AdServerSizeID.HasValue Then

                            If AdServerSizeDictionary.Where(Function(ASSD) ASSD.Value.ToLower = AdSize.Description.ToLower).Count = 1 Then

                                AdSize.AdServerSizeID = AdServerSizeDictionary.Where(Function(ASSD) ASSD.Value.ToLower = AdSize.Description.ToLower).Single.Key

                                If AdvantageFramework.Database.Procedures.AdSize.Update(DbContext, AdSize, ErrorMessage) = False Then

                                    AddUpdateFailed = True
                                    Sizes.Add(AdSize.Description)

                                End If

                            End If

                        End If

                    Next

                    If AddUpdateFailed Then

                        AdvantageFramework.WinForm.MessageBox.Show("Could not update the following:" & String.Join(", ", Sizes.ToList))

                    End If

                End Using

            Else

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AdSizeSetupForm As Presentation.AdSizeSetupForm = Nothing

            AdSizeSetupForm = New Presentation.AdSizeSetupForm()

            AdSizeSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AdSizeSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemAdServerData_AddUpdate.Image = AdvantageFramework.My.Resources.AdServerImage

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                _IsDCEnabled = AdvantageFramework.DoubleClick.IsDoubleClickEnabledByAgencyOrAnyClient(DataContext)

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    _ProfileID = DbContext.Database.SqlQuery(Of Long)("exec advsp_doubleclick_get_profileid_for_adsizes").FirstOrDefault

                End Using

                RibbonBarOptions_AdServerData.Visible = _IsDCEnabled

            End Using

            LoadGrid()

            DataGridViewForm_AdSize.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

        End Sub
        Private Sub AdSizeSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub AdSizeSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_AdSize.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim AdSizes As Generic.List(Of AdvantageFramework.Database.Entities.AdSize) = Nothing

            If DataGridViewForm_AdSize.HasRows Then

                DataGridViewForm_AdSize.CurrentView.CloseEditorForUpdating()

                AdSizes = DataGridViewForm_AdSize.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.AdSize)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each AdSize In AdSizes

                            AdvantageFramework.Database.Procedures.AdSize.Update(DbContext, AdSize)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_AdSize.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim AdSize As AdvantageFramework.Database.Entities.AdSize = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_AdSize.HasASelectedRow Then

                DataGridViewForm_AdSize.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_AdSize.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    AdSize = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    AdSize = Nothing
                                End Try

                                If AdSize IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.AdSize.Delete(DbContext, AdSize) Then

                                        DataGridViewForm_AdSize.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_AdSize.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_AdSize.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemAdServerData_AddUpdate_Click(sender As Object, e As EventArgs) Handles ButtonItemAdServerData_AddUpdate.Click

            If AdvantageFramework.WinForm.MessageBox.Show("You are about to add / update ad server size IDs.  Do you want to continue?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Confirm", MessageBoxDefaultButton:=Windows.Forms.MessageBoxDefaultButton.Button2) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                Me.ShowWaitForm()

                SetIABStandardSizes()

                SetNonIABStandardSizes()

                LoadGrid()

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_AdSize_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_AdSize.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_AdSize_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_AdSize.AddNewRowEvent

            'objects
            Dim AdSize As AdvantageFramework.Database.Entities.AdSize = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.AdSize Then

                Me.ShowWaitForm("Processing...")

                AdSize = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If AdSize.IsEntityBeingAdded() Then

                        AdSize.DbContext = DbContext

                        If AdSize.IsInactive.HasValue = False Then

                            AdSize.IsInactive = 0

                        End If

                        AdvantageFramework.Database.Procedures.AdSize.Insert(DbContext, AdSize)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_AdSize_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_AdSize.CellValueChangingEvent

            'objects
            Dim AdSize As AdvantageFramework.Database.Entities.AdSize = Nothing
            Dim NewAdSize As AdvantageFramework.Database.Entities.AdSize = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.AdSize.Properties.IsInactive.ToString Then

                Try

                    AdSize = DataGridViewForm_AdSize.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    AdSize = Nothing
                End Try

                If AdSize IsNot Nothing Then

                    Try

                        AdSize.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        AdSize.IsInactive = AdSize.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.AdSize.Update(DbContext, AdSize)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            ElseIf e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.AdSize.Properties.MediaType.ToString Then

                Try

                    AdSize = DataGridViewForm_AdSize.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    AdSize = Nothing
                End Try

                If AdSize IsNot Nothing Then

                    NewAdSize = New AdvantageFramework.Database.Entities.AdSize

                    Try

                        NewAdSize.Code = AdSize.Code
                        NewAdSize.Description = AdSize.Description
                        NewAdSize.MediaType = e.Value
                        NewAdSize.IsInactive = AdSize.IsInactive

                    Catch ex As Exception
                        NewAdSize = Nothing
                    End Try

                    If NewAdSize IsNot Nothing Then

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                If AdvantageFramework.Database.Procedures.AdSize.Delete(DbContext, AdSize) Then

                                    NewAdSize.DbContext = DbContext

                                    Saved = AdvantageFramework.Database.Procedures.AdSize.Insert(DbContext, NewAdSize)

                                End If

                            End Using

                        Catch ex As Exception

                        End Try

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                        If Saved = False Then

                            AdvantageFramework.WinForm.MessageBox.Show("This Ad Size is in use and cannot be modified.")

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_AdSize_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_AdSize.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_AdSize_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_AdSize.ShowingEditorEvent

            Dim AdSize As AdvantageFramework.Database.Entities.AdSize = Nothing

            If Not DataGridViewForm_AdSize.IsNewItemRow(DataGridViewForm_AdSize.CurrentView.FocusedRowHandle) Then

                If DataGridViewForm_AdSize.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.AdSize.Properties.MediaType.ToString OrElse
                        DataGridViewForm_AdSize.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.AdSize.Properties.Code.ToString OrElse
                        DataGridViewForm_AdSize.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.AdSize.Properties.AdServerSizeID.ToString Then

                    e.Cancel = True

                ElseIf DataGridViewForm_AdSize.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.AdSize.Properties.Description.ToString Then

                    AdSize = DataGridViewForm_AdSize.CurrentView.GetRow(DataGridViewForm_AdSize.CurrentView.FocusedRowHandle)

                    If AdSize IsNot Nothing Then

                        e.Cancel = AdSize.AdServerSizeID.HasValue

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
