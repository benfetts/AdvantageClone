Namespace Maintenance.Accounting.Presentation

    Public Class FunctionSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _IsFirstLoad As Boolean = False
        Private _RepositoryItemImageCheckEdit_NewItemRow As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

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

                BandedDataGridViewForm_Function.DataSource = (From Entity In AdvantageFramework.Database.Procedures.FunctionView.Load(DbContext).ToList
                                                              Select New AdvantageFramework.Database.Classes.Function(Entity)).ToList

            End Using

            BandedDataGridViewForm_Function.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If BandedDataGridViewForm_Function.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = BandedDataGridViewForm_Function.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim FunctionSetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.FunctionSetupForm = Nothing

            FunctionSetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.FunctionSetupForm()

            FunctionSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub FunctionSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            'objects
            Dim RateFlagSettingGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim BlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim LastBlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            _RepositoryItemImageCheckEdit_NewItemRow = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

            _RepositoryItemImageCheckEdit_NewItemRow.ValueChecked = Convert.ToInt16(1)
            _RepositoryItemImageCheckEdit_NewItemRow.ValueUnchecked = Convert.ToInt16(0)
            _RepositoryItemImageCheckEdit_NewItemRow.ValueGrayed = Nothing
            _RepositoryItemImageCheckEdit_NewItemRow.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
            _RepositoryItemImageCheckEdit_NewItemRow.PictureChecked = AdvantageFramework.My.Resources.SmallRedCircleImage
            _RepositoryItemImageCheckEdit_NewItemRow.PictureGrayed = AdvantageFramework.My.Resources.SmallRedCircleImage
            _RepositoryItemImageCheckEdit_NewItemRow.PictureUnchecked = AdvantageFramework.My.Resources.SmallRedCircleImage
            _RepositoryItemImageCheckEdit_NewItemRow.ReadOnly = True

            BandedDataGridViewForm_Function.GridControl.RepositoryItems.Add(_RepositoryItemImageCheckEdit_NewItemRow)

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage

            BlankGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            BlankGridBand.Caption = " "
            BlankGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            BlankGridBand.AppearanceHeader.Options.UseTextOptions = True

            RateFlagSettingGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            RateFlagSettingGridBand.Caption = "Rate/Flag Settings (View Only)"
            RateFlagSettingGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            RateFlagSettingGridBand.AppearanceHeader.Options.UseTextOptions = True

            LastBlankGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            LastBlankGridBand.Caption = " "
            LastBlankGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            LastBlankGridBand.AppearanceHeader.Options.UseTextOptions = True

            BandedDataGridViewForm_Function.CurrentView.Bands.Add(BlankGridBand)
            BandedDataGridViewForm_Function.CurrentView.Bands.Add(RateFlagSettingGridBand)
            BandedDataGridViewForm_Function.CurrentView.Bands.Add(LastBlankGridBand)

            BandedDataGridViewForm_Function.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Classes.Function))

            BandedDataGridViewForm_Function.ItemDescription = "Function(s)"

            For Each GridColumn In BandedDataGridViewForm_Function.Columns

                If GridColumn.FieldName = AdvantageFramework.Database.Views.FunctionView.Properties.TaxCommissionFlag.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Views.FunctionView.Properties.TaxCommissionOnlyFlag.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Views.FunctionView.Properties.BillingRate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Views.FunctionView.Properties.TaxFlag.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Views.FunctionView.Properties.CommissionFlag.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Views.FunctionView.Properties.NonBillableFlag.ToString Then

                    RateFlagSettingGridBand.Columns.Add(GridColumn)

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Views.FunctionView.Properties.IsInactive.ToString Then

                    LastBlankGridBand.Columns.Add(GridColumn)

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.Function.Properties.NonBillableClientGLACode.ToString Then

                    If TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, Me.Session))

                        End Using

                    End If

                ElseIf GridColumn.FieldName = AdvantageFramework.Database.Classes.Function.Properties.OverheadGLACode.ToString Then

                    If TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            CType(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, Me.Session))

                        End Using

                    End If

                Else

                    BlankGridBand.Columns.Add(GridColumn)

                    If GridColumn.FieldName = AdvantageFramework.Database.Views.FunctionView.Properties.FeeFlag.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.Database.Views.FunctionView.Properties.FeeReconcile.ToString Then

                        GridColumn.Visible = False

                    End If

                End If

            Next

            LoadGrid()

            BandedDataGridViewForm_Function.CurrentView.AFActiveFilterString = "[IsInactive] = 0s"

        End Sub
        Private Sub FunctionSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub FunctionSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            BandedDataGridViewForm_Function.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim Functions As Generic.List(Of AdvantageFramework.Database.Classes.Function) = Nothing
            Dim FunctionView As AdvantageFramework.Database.Views.FunctionView = Nothing

            If BandedDataGridViewForm_Function.HasRows Then

                BandedDataGridViewForm_Function.CurrentView.CloseEditorForUpdating()

                Functions = BandedDataGridViewForm_Function.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.Function).ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each [Function] In Functions

                            FunctionView = [Function].GetEntity()

                            If FunctionView IsNot Nothing Then

                                FunctionView.DbContext = DbContext

                                AdvantageFramework.Database.Procedures.FunctionView.Update(DbContext, FunctionView)

                            End If

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    BandedDataGridViewForm_Function.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim [Function] As AdvantageFramework.Database.Classes.Function = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If BandedDataGridViewForm_Function.HasASelectedRow Then

                BandedDataGridViewForm_Function.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Deleting..")
                    Me.FormAction = WinForm.Presentation.FormActions.Deleting

                    Try

                        RowHandlesAndDataBoundItems = BandedDataGridViewForm_Function.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                                Try

                                    [Function] = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    [Function] = Nothing
                                End Try

                                If [Function] IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.FunctionView.Delete(DbContext, [Function].GetEntity()) Then

                                        BandedDataGridViewForm_Function.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()
                    Me.FormAction = WinForm.Presentation.FormActions.None

                    If BandedDataGridViewForm_Function.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            BandedDataGridViewForm_Function.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub BandedDataGridViewForm_Function_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles BandedDataGridViewForm_Function.InitNewRowEvent

            'objects
            Dim [Function] As AdvantageFramework.Database.Classes.Function = Nothing

            Try

                If TypeOf BandedDataGridViewForm_Function.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Classes.Function Then

                    [Function] = BandedDataGridViewForm_Function.CurrentView.GetRow(e.RowHandle)

                    [Function].IsInactive = 0

                End If

            Catch ex As Exception

            End Try

            EnableOrDisableActions()

        End Sub
        Private Sub BandedDataGridViewForm_Function_AddNewRowEvent(ByVal RowObject As Object) Handles BandedDataGridViewForm_Function.AddNewRowEvent

            'objects
            Dim [Function] As AdvantageFramework.Database.Classes.Function = Nothing
            Dim FunctionView As AdvantageFramework.Database.Views.FunctionView = Nothing
            Dim BillingRateDetail As AdvantageFramework.Database.Entities.BillingRateDetail = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.Function Then

                Me.ShowWaitForm("Processing...")

                [Function] = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    FunctionView = [Function].GetEntity()

                    If FunctionView IsNot Nothing Then

                        FunctionView.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.FunctionView.Insert(DbContext, FunctionView) Then

                            [Function].SetExists()

                            BillingRateDetail = New AdvantageFramework.Database.Entities.BillingRateDetail

                            BillingRateDetail.DbContext = DbContext
                            BillingRateDetail.FunctionCode = [Function].Code
                            BillingRateDetail.RateAmount = 0
                            BillingRateDetail.IsNonBillable = 0
                            BillingRateDetail.IsTaxCommission = 0
                            BillingRateDetail.IsCommission = 0
                            BillingRateDetail.IsTax = 0

                            If [Function].Type = AdvantageFramework.Database.Entities.FunctionTypes.E.ToString Then

                                BillingRateDetail.IsFeeTime = 0

                            End If

                            BillingRateDetail.BillingRateLevelID = (From Entity In AdvantageFramework.Database.Procedures.BillingRateLevel.Load(DbContext).ToList
                                                                    Where Entity.IsRequired = 1 AndAlso
                                                                          Entity.IsFunctionIncluded = 1 AndAlso
                                                                          Entity.Description.ToUpper = "FUNCTION"
                                                                    Select Entity.ID).FirstOrDefault

                            AdvantageFramework.Database.Procedures.BillingRateDetail.Insert(DbContext, BillingRateDetail)

                        End If

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub BandedDataGridViewForm_Function_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles BandedDataGridViewForm_Function.CellValueChangingEvent

            'objects
            Dim [Function] As AdvantageFramework.Database.Classes.Function = Nothing
            Dim FunctionView As AdvantageFramework.Database.Views.FunctionView = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso
                   e.Column.FieldName = AdvantageFramework.Database.Classes.Function.Properties.IsInactive.ToString OrElse
                   e.Column.FieldName = AdvantageFramework.Database.Classes.Function.Properties.CPMFlag.ToString OrElse
                   e.Column.FieldName = AdvantageFramework.Database.Classes.Function.Properties.EmployeeExpenseFlag.ToString Then

                Try

                    [Function] = BandedDataGridViewForm_Function.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    [Function] = Nothing
                End Try

                If [Function] IsNot Nothing Then

                    Select Case e.Column.FieldName

                        Case AdvantageFramework.Database.Classes.Function.Properties.IsInactive.ToString

                            Try

                                [Function].IsInactive = Convert.ToInt16(e.Value)

                            Catch ex As Exception
                                [Function].IsInactive = [Function].IsInactive
                            End Try

                        Case AdvantageFramework.Database.Classes.Function.Properties.CPMFlag.ToString

                            Try

                                [Function].CPMFlag = Convert.ToInt16(e.Value)

                            Catch ex As Exception
                                [Function].CPMFlag = [Function].CPMFlag
                            End Try

                        Case AdvantageFramework.Database.Classes.Function.Properties.EmployeeExpenseFlag.ToString

                            Try

                                [Function].EmployeeExpenseFlag = Convert.ToInt16(e.Value)

                            Catch ex As Exception
                                [Function].EmployeeExpenseFlag = [Function].EmployeeExpenseFlag
                            End Try

                    End Select

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            FunctionView = [Function].GetEntity()

                            If FunctionView IsNot Nothing Then

                                FunctionView.DbContext = DbContext

                                Saved = AdvantageFramework.Database.Procedures.FunctionView.Update(DbContext, FunctionView)

                            End If

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_Function_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles BandedDataGridViewForm_Function.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub BandedDataGridViewForm_Function_CustomRowCellEditEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles BandedDataGridViewForm_Function.CustomRowCellEditEvent

			If BandedDataGridViewForm_Function.CurrentView.IsNewItemRow(e.RowHandle) Then

                If e.Column.FieldName = AdvantageFramework.Database.Classes.Function.Properties.TaxFlag.ToString OrElse
                   e.Column.FieldName = AdvantageFramework.Database.Classes.Function.Properties.CommissionFlag.ToString OrElse
                   e.Column.FieldName = AdvantageFramework.Database.Classes.Function.Properties.TaxCommissionFlag.ToString OrElse
                   e.Column.FieldName = AdvantageFramework.Database.Classes.Function.Properties.TaxCommissionOnlyFlag.ToString OrElse
                   e.Column.FieldName = AdvantageFramework.Database.Classes.Function.Properties.NonBillableFlag.ToString Then

                    e.RepositoryItem = _RepositoryItemImageCheckEdit_NewItemRow

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewForm_Function_ShownEditorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles BandedDataGridViewForm_Function.ShownEditorEvent

            'objects
            Dim [Function] As AdvantageFramework.Database.Classes.Function = Nothing
            Dim LookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim CloseEditor As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If BandedDataGridViewForm_Function.CurrentView.IsNewItemRow(BandedDataGridViewForm_Function.CurrentView.FocusedRowHandle) = False Then

                    If BandedDataGridViewForm_Function.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Views.FunctionView.Properties.Type.ToString Then

                        Try

                            [Function] = BandedDataGridViewForm_Function.CurrentView.GetRow(BandedDataGridViewForm_Function.CurrentView.FocusedRowHandle)

                        Catch ex As Exception
                            [Function] = Nothing
                        End Try

                        If TypeOf BandedDataGridViewForm_Function.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                            LookUpEdit = BandedDataGridViewForm_Function.CurrentView.ActiveEditor

                            If AdvantageFramework.Database.Procedures.FunctionView.IsFunctionInUse(DbContext, [Function].GetEntity()) Then

                                BandedDataGridViewForm_Function.CurrentView.CloseEditor()

                                BandedDataGridViewForm_Function.CurrentView.FocusedColumn = BandedDataGridViewForm_Function.CurrentView.Columns(AdvantageFramework.Database.Classes.Function.Properties.DepartmentTeamCode.ToString)

                            End If

                        End If

                    ElseIf BandedDataGridViewForm_Function.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.Function.Properties.NonBillableClientGLACode.ToString Then

                        Try

                            [Function] = BandedDataGridViewForm_Function.CurrentView.GetRow(BandedDataGridViewForm_Function.CurrentView.FocusedRowHandle)

                        Catch ex As Exception
                            [Function] = Nothing
                        End Try

                        If [Function] IsNot Nothing Then

                            Try

                                If [Function].Type.ToUpper <> "V" Then

                                    BandedDataGridViewForm_Function.CurrentView.CloseEditor()

                                End If

                            Catch ex As Exception

                            End Try

                        End If

                    ElseIf BandedDataGridViewForm_Function.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.Function.Properties.EmployeeExpenseFlag.ToString Then

                        Try

                            [Function] = BandedDataGridViewForm_Function.CurrentView.GetRow(BandedDataGridViewForm_Function.CurrentView.FocusedRowHandle)

                        Catch ex As Exception
                            [Function] = Nothing
                        End Try

                        If [Function] IsNot Nothing Then

                            Try

                                If [Function].Type.ToUpper <> "V" Then

                                    BandedDataGridViewForm_Function.CurrentView.CloseEditor()

                                End If

                            Catch ex As Exception

                            End Try

                        End If

                    End If

                Else

                    If BandedDataGridViewForm_Function.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.Function.Properties.NonBillableClientGLACode.ToString Then

                        Try

                            [Function] = BandedDataGridViewForm_Function.CurrentView.GetRow(BandedDataGridViewForm_Function.CurrentView.FocusedRowHandle)

                        Catch ex As Exception
                            [Function] = Nothing
                        End Try

                        If [Function] IsNot Nothing Then

                            Try

                                If [Function].Type.ToUpper <> "V" Then

                                    BandedDataGridViewForm_Function.CurrentView.CloseEditor()

                                End If

                            Catch ex As Exception

                            End Try

                        End If

                    ElseIf BandedDataGridViewForm_Function.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.Function.Properties.EmployeeExpenseFlag.ToString Then

                        Try

                            [Function] = BandedDataGridViewForm_Function.CurrentView.GetRow(BandedDataGridViewForm_Function.CurrentView.FocusedRowHandle)

                        Catch ex As Exception
                            [Function] = Nothing
                        End Try

                        If [Function] IsNot Nothing Then

                            Try

                                If [Function].Type.ToUpper <> "V" Then

                                    BandedDataGridViewForm_Function.CurrentView.CloseEditor()

                                End If

                            Catch ex As Exception

                            End Try

                        End If

                    End If

                End If

            End Using

        End Sub
        Private Sub BandedDataGridViewForm_Function_NewItemRowCellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles BandedDataGridViewForm_Function.NewItemRowCellValueChangedEvent

            If e.Column.FieldName = AdvantageFramework.Database.Classes.Function.Properties.Type.ToString Then

                If e.Value <> "V" Then

                    BandedDataGridViewForm_Function.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.Function.Properties.NonBillableClientGLACode.ToString, Nothing)
                    BandedDataGridViewForm_Function.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.Function.Properties.EmployeeExpenseFlag.ToString, Nothing)

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
