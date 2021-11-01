Namespace Maintenance.Client.Presentation

    Public Class ClientTypesSetupForm

#Region " Constants "



#End Region

#Region " Enum "

        Protected Enum ClientType
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Client Type 1")>
            ClientType1 = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Client Type 2")>
            ClientType2 = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Client Type 3")>
            ClientType3 = 3
        End Enum

#End Region

#Region " Variables "

        Private _ClientType As ClientType = ClientType.ClientType1

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

                Select Case _ClientType

                    Case ClientType.ClientType1

                        DataGridViewForm_ClientType.DataSource = AdvantageFramework.Database.Procedures.ClientType1.Load(DbContext).ToList
                        DataGridViewForm_ClientType.CurrentView.ViewCaption = DataGridViewForm_ClientType.CurrentView.RowCount & " Client Type 1(s)"

                    Case ClientType.ClientType2

                        DataGridViewForm_ClientType.DataSource = AdvantageFramework.Database.Procedures.ClientType2.Load(DbContext).ToList
                        DataGridViewForm_ClientType.CurrentView.ViewCaption = DataGridViewForm_ClientType.CurrentView.RowCount & " Client Type 2(s)"

                    Case ClientType.ClientType3

                        DataGridViewForm_ClientType.DataSource = AdvantageFramework.Database.Procedures.ClientType3.Load(DbContext).ToList
                        DataGridViewForm_ClientType.CurrentView.ViewCaption = DataGridViewForm_ClientType.CurrentView.RowCount & " Client Type 3(s)"

                End Select

            End Using

            DataGridViewForm_ClientType.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_ClientType.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_ClientType.HasASelectedRow

            End If

        End Sub
        Public Function CheckForUnsavedChanges() As Boolean

            Dim IsOkay As Boolean = True

            If Me.UserEntryChanged Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    If Not DataGridViewForm_ClientType.HasAnyInvalidRows Then

                        Me.ShowWaitForm("Saving...")

                        Save()

                        Me.CloseWaitForm()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Fix errors in grid.")

                        IsOkay = False

                    End If

                Else

                    AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Sub ChangeView()

            Static PreviousSelectedIndex As Integer

            If Me.FormAction <> AdvantageFramework.WinForm.Presentation.FormActions.Loading Then

                If CheckForUnsavedChanges() Then

                    If ComboBoxItemActions_View.SelectedIndex = 0 Then

                        _ClientType = ClientType.ClientType1

                        LoadGrid()

                        PreviousSelectedIndex = 0

                    ElseIf ComboBoxItemActions_View.SelectedIndex = 1 Then

                        _ClientType = ClientType.ClientType2

                        LoadGrid()

                        PreviousSelectedIndex = 1

                    ElseIf ComboBoxItemActions_View.SelectedIndex = 2 Then

                        _ClientType = ClientType.ClientType3

                        LoadGrid()

                        PreviousSelectedIndex = 2

                    End If

                    EnableOrDisableActions()

                Else

                    ComboBoxItemActions_View.SelectedIndex = PreviousSelectedIndex

                End If

            End If

            Me.ClearValidations()
            Me.ClearChanged()

        End Sub
        Private Sub Save()

            'objects
            Dim ClientType1s As Generic.List(Of AdvantageFramework.Database.Entities.ClientType1) = Nothing
            Dim ClientType2s As Generic.List(Of AdvantageFramework.Database.Entities.ClientType2) = Nothing
            Dim ClientType3s As Generic.List(Of AdvantageFramework.Database.Entities.ClientType3) = Nothing

            If DataGridViewForm_ClientType.HasRows Then

                DataGridViewForm_ClientType.CurrentView.CloseEditorForUpdating()

                Select Case _ClientType

                    Case ClientType.ClientType1

                        ClientType1s = DataGridViewForm_ClientType.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ClientType1)().ToList

                    Case ClientType.ClientType2

                        ClientType2s = DataGridViewForm_ClientType.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ClientType2)().ToList

                    Case ClientType.ClientType3

                        ClientType3s = DataGridViewForm_ClientType.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ClientType3)().ToList

                End Select

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Select Case _ClientType

                            Case ClientType.ClientType1

                                For Each ClientType1 In ClientType1s

                                    AdvantageFramework.Database.Procedures.ClientType1.Update(DbContext, ClientType1)

                                Next

                            Case ClientType.ClientType2

                                For Each ClientType2 In ClientType2s

                                    AdvantageFramework.Database.Procedures.ClientType2.Update(DbContext, ClientType2)

                                Next

                            Case ClientType.ClientType3

                                For Each ClientType3 In ClientType3s

                                    AdvantageFramework.Database.Procedures.ClientType3.Update(DbContext, ClientType3)

                                Next

                        End Select

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_ClientType.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub Delete()

            'objects
            Dim ClientType1 As AdvantageFramework.Database.Entities.ClientType1 = Nothing
            Dim ClientType2 As AdvantageFramework.Database.Entities.ClientType2 = Nothing
            Dim ClientType3 As AdvantageFramework.Database.Entities.ClientType3 = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_ClientType.HasASelectedRow Then

                DataGridViewForm_ClientType.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_ClientType.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Select Case _ClientType

                                    Case ClientType.ClientType1

                                        Try

                                            ClientType1 = RowHandleAndDataBoundItem.Value

                                        Catch ex As Exception
                                            ClientType1 = Nothing
                                        End Try

                                        If ClientType1 IsNot Nothing Then

                                            If AdvantageFramework.Database.Procedures.ClientType1.Delete(DbContext, ClientType1) Then

                                                DataGridViewForm_ClientType.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                            End If

                                        End If

                                    Case ClientType.ClientType2

                                        Try

                                            ClientType2 = RowHandleAndDataBoundItem.Value

                                        Catch ex As Exception
                                            ClientType2 = Nothing
                                        End Try

                                        If ClientType2 IsNot Nothing Then

                                            If AdvantageFramework.Database.Procedures.ClientType2.Delete(DbContext, ClientType2) Then

                                                DataGridViewForm_ClientType.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                            End If

                                        End If

                                    Case ClientType.ClientType3

                                        Try

                                            ClientType3 = RowHandleAndDataBoundItem.Value

                                        Catch ex As Exception
                                            ClientType3 = Nothing
                                        End Try

                                        If ClientType3 IsNot Nothing Then

                                            If AdvantageFramework.Database.Procedures.ClientType3.Delete(DbContext, ClientType3) Then

                                                DataGridViewForm_ClientType.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                            End If

                                        End If

                                End Select

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_ClientType.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub

#Region " ClientType1 "

        Private Sub DataGridViewForm_ClientType1_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)

            Dim ClientType1 As AdvantageFramework.Database.Entities.ClientType1 = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.ClientType1.Properties.IsInactive.ToString Then

                Try

                    ClientType1 = DataGridViewForm_ClientType.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    ClientType1 = Nothing
                End Try

                If ClientType1 IsNot Nothing Then

                    Try

                        ClientType1.IsInactive = e.Value

                    Catch ex As Exception
                        ClientType1.IsInactive = ClientType1.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.ClientType1.Update(DbContext, ClientType1)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_ClientType1_AddNewRowEvent(ByVal RowObject As Object)

            'objects
            Dim ClientType1 As AdvantageFramework.Database.Entities.ClientType1 = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.ClientType1 Then

                Me.ShowWaitForm("Processing...")

                ClientType1 = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If ClientType1.IsEntityBeingAdded() Then

                        ClientType1.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.ClientType1.Insert(DbContext, ClientType1)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub

#End Region

#Region " ClientType2 "

        Private Sub DataGridViewForm_ClientType2_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)

            Dim ClientType2 As AdvantageFramework.Database.Entities.ClientType2 = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.ClientType2.Properties.IsInactive.ToString Then

                Try

                    ClientType2 = DataGridViewForm_ClientType.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    ClientType2 = Nothing
                End Try

                If ClientType2 IsNot Nothing Then

                    Try

                        ClientType2.IsInactive = e.Value

                    Catch ex As Exception
                        ClientType2.IsInactive = ClientType2.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.ClientType2.Update(DbContext, ClientType2)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_ClientType2_AddNewRowEvent(ByVal RowObject As Object)

            'objects
            Dim ClientType2 As AdvantageFramework.Database.Entities.ClientType2 = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.ClientType2 Then

                Me.ShowWaitForm("Processing...")

                ClientType2 = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If ClientType2.IsEntityBeingAdded() Then

                        ClientType2.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.ClientType2.Insert(DbContext, ClientType2)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub

#End Region

#Region " ClientType3 "

        Private Sub DataGridViewForm_ClientType3_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)

            Dim ClientType3 As AdvantageFramework.Database.Entities.ClientType3 = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.ClientType3.Properties.IsInactive.ToString Then

                Try

                    ClientType3 = DataGridViewForm_ClientType.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    ClientType3 = Nothing
                End Try

                If ClientType3 IsNot Nothing Then

                    Try

                        ClientType3.IsInactive = e.Value

                    Catch ex As Exception
                        ClientType3.IsInactive = ClientType3.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.ClientType3.Update(DbContext, ClientType3)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_ClientType3_AddNewRowEvent(ByVal RowObject As Object)

            'objects
            Dim ClientType3 As AdvantageFramework.Database.Entities.ClientType3 = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.ClientType3 Then

                Me.ShowWaitForm("Processing...")

                ClientType3 = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If ClientType3.IsEntityBeingAdded() Then

                        ClientType3.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.ClientType3.Insert(DbContext, ClientType3)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub

#End Region

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ClientTypesSetupForm As Presentation.ClientTypesSetupForm = Nothing

            ClientTypesSetupForm = New Presentation.ClientTypesSetupForm()

            ClientTypesSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientTypesSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ComboBoxItemActions_View.Items.AddRange((From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(ClientType))
                                                     Select Entity.Description).ToArray)

            ComboBoxItemActions_View.SelectedIndex = 0

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            LoadGrid()

            DataGridViewForm_ClientType.CurrentView.AFActiveFilterString = "[IsInactive] = False"

        End Sub
        Private Sub ClientTypesSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ClientTypesSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            Select Case _ClientType

                Case ClientType.ClientType1

                    DataGridViewForm_ClientType.Print(DefaultLookAndFeel.LookAndFeel, ClientType.ClientType1.ToString)

                Case ClientType.ClientType2

                    DataGridViewForm_ClientType.Print(DefaultLookAndFeel.LookAndFeel, ClientType.ClientType2.ToString)

                Case ClientType.ClientType3

                    DataGridViewForm_ClientType.Print(DefaultLookAndFeel.LookAndFeel, ClientType.ClientType3.ToString)

            End Select

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            Delete()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_ClientType.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_ClientType_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_ClientType.CellValueChangingEvent

            Select Case _ClientType

                Case ClientType.ClientType1

                    DataGridViewForm_ClientType1_CellValueChangingEvent(Saved, e)

                Case ClientType.ClientType2

                    DataGridViewForm_ClientType2_CellValueChangingEvent(Saved, e)

                Case ClientType.ClientType3

                    DataGridViewForm_ClientType3_CellValueChangingEvent(Saved, e)

            End Select

        End Sub
        Private Sub DataGridViewForm_ClientType_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_ClientType.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_ClientType_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_ClientType.AddNewRowEvent

            Select Case _ClientType

                Case ClientType.ClientType1

                    DataGridViewForm_ClientType1_AddNewRowEvent(RowObject)

                Case ClientType.ClientType2

                    DataGridViewForm_ClientType2_AddNewRowEvent(RowObject)

                Case ClientType.ClientType3

                    DataGridViewForm_ClientType3_AddNewRowEvent(RowObject)

            End Select

        End Sub
        Private Sub DataGridViewForm_ClientType_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_ClientType.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ComboBoxItemActions_View_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItemActions_View.SelectedIndexChanged

            ChangeView()

        End Sub

#End Region

#End Region

    End Class

End Namespace