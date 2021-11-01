Namespace Maintenance.Accounting.Presentation

    Public Class AvalaraProductMappingSetupForm

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
            Dim UseJobSalesClass As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewForm_AvalaraProductMapping.DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.AvaTax.Classes.AvalaraProductMapping)("exec advsp_avalara_get_product_mappings").ToList
                UseJobSalesClass = AdvantageFramework.Agency.GetOptionAvaTaxUseJobSalesClass(DbContext)

            End Using

            If DataGridViewForm_AvalaraProductMapping.Columns(AdvantageFramework.AvaTax.Classes.AvalaraProductMapping.Properties.AvalaraTaxDescription.ToString) IsNot Nothing Then

                DataGridViewForm_AvalaraProductMapping.Columns(AdvantageFramework.AvaTax.Classes.AvalaraProductMapping.Properties.AvalaraTaxDescription.ToString).OptionsColumn.AllowEdit = False

            End If

            If DataGridViewForm_AvalaraProductMapping.Columns(AdvantageFramework.AvaTax.Classes.AvalaraProductMapping.Properties.SalesClassDescription.ToString) IsNot Nothing Then

                DataGridViewForm_AvalaraProductMapping.Columns(AdvantageFramework.AvaTax.Classes.AvalaraProductMapping.Properties.SalesClassDescription.ToString).OptionsColumn.AllowFocus = False

            End If

            If DataGridViewForm_AvalaraProductMapping.Columns(AdvantageFramework.AvaTax.Classes.AvalaraProductMapping.Properties.FunctionDescription.ToString) IsNot Nothing Then

                DataGridViewForm_AvalaraProductMapping.Columns(AdvantageFramework.AvaTax.Classes.AvalaraProductMapping.Properties.FunctionDescription.ToString).OptionsColumn.AllowFocus = False

            End If

            If DataGridViewForm_AvalaraProductMapping.Columns(AdvantageFramework.AvaTax.Classes.AvalaraProductMapping.Properties.SalesClassCode.ToString) IsNot Nothing AndAlso UseJobSalesClass Then

                DataGridViewForm_AvalaraProductMapping.Columns(AdvantageFramework.AvaTax.Classes.AvalaraProductMapping.Properties.SalesClassCode.ToString).Caption = "Job Sales Class"

            End If

            DataGridViewForm_AvalaraProductMapping.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_AvalaraProductMapping.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewForm_AvalaraProductMapping.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AvalaraProductMappingSetupForm As Presentation.AvalaraProductMappingSetupForm = Nothing

            AvalaraProductMappingSetupForm = New Presentation.AvalaraProductMappingSetupForm()

            AvalaraProductMappingSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AvalaraProductMappingSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            DataGridViewForm_AvalaraProductMapping.AutoFilterLookupColumns = True

            LoadGrid()

        End Sub
        Private Sub AvalaraProductMappingSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub AvalaraProductMappingSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_AvalaraProductMapping.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim AvalaraProductMappings As Generic.List(Of AdvantageFramework.AvaTax.Classes.AvalaraProductMapping) = Nothing
            Dim AvalaraProductMapping As AdvantageFramework.Database.Entities.AvalaraProductMapping = Nothing

            If DataGridViewForm_AvalaraProductMapping.HasRows Then

                DataGridViewForm_AvalaraProductMapping.CurrentView.CloseEditorForUpdating()

                AvalaraProductMappings = DataGridViewForm_AvalaraProductMapping.GetAllModifiedRows.OfType(Of AdvantageFramework.AvaTax.Classes.AvalaraProductMapping)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each APM In AvalaraProductMappings

                                AvalaraProductMapping = AdvantageFramework.Database.Procedures.AvalaraProductMapping.LoadByID(DataContext, APM.ID)

                                If AvalaraProductMapping IsNot Nothing Then

                                    AvalaraProductMapping.DbContext = DbContext

                                    AvalaraProductMapping.SalesClassCode = APM.SalesClassCode
                                    AvalaraProductMapping.FunctionCode = APM.FunctionCode
                                    AvalaraProductMapping.AvalaraTaxID = APM.AvalaraTaxID

                                    AdvantageFramework.Database.Procedures.AvalaraProductMapping.Update(DataContext, AvalaraProductMapping)

                                End If

                            Next

                        End Using

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_AvalaraProductMapping.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim AvalaraProductMappingClass As AdvantageFramework.AvaTax.Classes.AvalaraProductMapping = Nothing
            Dim AvalaraProductMapping As AdvantageFramework.Database.Entities.AvalaraProductMapping = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_AvalaraProductMapping.HasASelectedRow Then

                DataGridViewForm_AvalaraProductMapping.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_AvalaraProductMapping.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    AvalaraProductMappingClass = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    AvalaraProductMappingClass = Nothing
                                End Try

                                If AvalaraProductMappingClass IsNot Nothing Then

                                    AvalaraProductMapping = AdvantageFramework.Database.Procedures.AvalaraProductMapping.LoadByID(DataContext, AvalaraProductMappingClass.ID)

                                    If AvalaraProductMapping IsNot Nothing Then

                                        If AdvantageFramework.Database.Procedures.AvalaraProductMapping.Delete(DataContext, AvalaraProductMapping) Then

                                            DataGridViewForm_AvalaraProductMapping.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                        End If

                                    Else

                                        DataGridViewForm_AvalaraProductMapping.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If DataGridViewForm_AvalaraProductMapping.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_AvalaraProductMapping.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_AvalaraProductMapping_ColumnValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs, ViaCellValueChangedEvent As Boolean) Handles DataGridViewForm_AvalaraProductMapping.ColumnValueChangedEvent

            Dim AvalaraProductMapping As AdvantageFramework.AvaTax.Classes.AvalaraProductMapping = Nothing
            Dim AvalaraTax As AdvantageFramework.Database.Entities.AvalaraTax = Nothing
            Dim SalesClass As AdvantageFramework.Database.Entities.SalesClass = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If e.Column.FieldName = AdvantageFramework.AvaTax.Classes.AvalaraProductMapping.Properties.AvalaraTaxID.ToString AndAlso ViaCellValueChangedEvent = False Then

                AvalaraProductMapping = DataGridViewForm_AvalaraProductMapping.CurrentView.GetRow(e.RowHandle)

                If e.Value IsNot Nothing Then

                    Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        AvalaraTax = AdvantageFramework.Database.Procedures.AvalaraTax.LoadByID(DataContext, e.Value)

                        If AvalaraTax IsNot Nothing Then

                            AvalaraProductMapping.AvalaraTaxDescription = AvalaraTax.Description

                        End If

                    End Using

                Else

                    AvalaraProductMapping.AvalaraTaxDescription = Nothing

                End If

                DataGridViewForm_AvalaraProductMapping.CurrentView.RefreshRowCell(e.RowHandle, DataGridViewForm_AvalaraProductMapping.CurrentView.Columns(AdvantageFramework.AvaTax.Classes.AvalaraProductMapping.Properties.AvalaraTaxDescription.ToString))

            ElseIf e.Column.FieldName = AdvantageFramework.AvaTax.Classes.AvalaraProductMapping.Properties.SalesClassCode.ToString AndAlso ViaCellValueChangedEvent = False Then

                AvalaraProductMapping = DataGridViewForm_AvalaraProductMapping.CurrentView.GetRow(e.RowHandle)

                If Not String.IsNullOrWhiteSpace(e.Value) Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        SalesClass = AdvantageFramework.Database.Procedures.SalesClass.LoadBySalesClassCode(DbContext, e.Value)

                        If SalesClass IsNot Nothing Then

                            AvalaraProductMapping.SalesClassDescription = SalesClass.Description

                        End If

                    End Using

                Else

                    AvalaraProductMapping.SalesClassDescription = ""

                End If

                DataGridViewForm_AvalaraProductMapping.CurrentView.RefreshRowCell(e.RowHandle, DataGridViewForm_AvalaraProductMapping.CurrentView.Columns(AdvantageFramework.AvaTax.Classes.AvalaraProductMapping.Properties.SalesClassDescription.ToString))

            End If

        End Sub
        Private Sub DataGridViewForm_AvalaraProductMapping_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_AvalaraProductMapping.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_AvalaraProductMapping_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_AvalaraProductMapping.AddNewRowEvent

            'objects
            Dim AvalaraProductMappingClass As AdvantageFramework.AvaTax.Classes.AvalaraProductMapping = Nothing
            Dim AvalaraProductMapping As AdvantageFramework.Database.Entities.AvalaraProductMapping = Nothing

            If TypeOf RowObject Is AdvantageFramework.AvaTax.Classes.AvalaraProductMapping Then

                Me.ShowWaitForm("Processing...")

                AvalaraProductMappingClass = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        AvalaraProductMapping = New AdvantageFramework.Database.Entities.AvalaraProductMapping
                        AvalaraProductMapping.DataContext = DataContext
                        AvalaraProductMapping.DbContext = DbContext

                        AvalaraProductMapping.SalesClassCode = AvalaraProductMappingClass.SalesClassCode
                        AvalaraProductMapping.FunctionCode = AvalaraProductMappingClass.FunctionCode
                        AvalaraProductMapping.AvalaraTaxID = AvalaraProductMappingClass.AvalaraTaxID

                        If AdvantageFramework.Database.Procedures.AvalaraProductMapping.Insert(DataContext, AvalaraProductMapping) Then

                            AvalaraProductMappingClass.ID = AvalaraProductMapping.ID

                        End If

                    End Using

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_AvalaraProductMapping_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_AvalaraProductMapping.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_AvalaraProductMapping_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_AvalaraProductMapping.QueryPopupNeedDatasourceEvent

            If FieldName = AdvantageFramework.AvaTax.Classes.AvalaraProductMapping.Properties.SalesClassCode.ToString Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    OverrideDefaultDatasource = True

                    Datasource = AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext).ToList

                End Using

            ElseIf FieldName = AdvantageFramework.AvaTax.Classes.AvalaraProductMapping.Properties.FunctionCode.ToString Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    OverrideDefaultDatasource = True

                    Datasource = AdvantageFramework.Database.Procedures.Function.LoadForSubItemGridLookupEditAllActiveBillableTypes(DbContext)

                End Using

            ElseIf FieldName = AdvantageFramework.AvaTax.Classes.AvalaraProductMapping.Properties.AvalaraTaxID.ToString Then

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    OverrideDefaultDatasource = True

                    Datasource = AdvantageFramework.Database.Procedures.AvalaraTax.LoadAllActive(DataContext).ToList

                End Using

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace