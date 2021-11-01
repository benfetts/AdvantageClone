Namespace Maintenance.Client.Presentation

    Public Class ProductCategorySetupForm

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

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewLeftSection_Products.DataSource = AdvantageFramework.Database.Procedures.ProductView.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).ToList

                    DataGridViewLeftSection_Products.CurrentView.BestFitColumns()

                End Using

            End Using

        End Sub
        Private Sub LoadSelectedItemDetails()

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing

            If DataGridViewLeftSection_Products.HasOnlyOneSelectedRow Then

                ClientCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Views.ProductView.Properties.ClientCode.ToString)
                DivisionCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Views.ProductView.Properties.DivisionCode.ToString)
                ProductCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Views.ProductView.Properties.ProductCode.ToString)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewRightSection_ProductCategories.DataSource = AdvantageFramework.Database.Procedures.ProductCategory.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode).ToList

                    DataGridViewRightSection_ProductCategories.CurrentView.BestFitColumns()

                End Using

            Else

                DataGridViewRightSection_ProductCategories.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.ProductCategory)

                DataGridViewRightSection_ProductCategories.CurrentView.BestFitColumns()

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            DataGridViewRightSection_ProductCategories.Enabled = (DataGridViewLeftSection_Products.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            If DataGridViewRightSection_ProductCategories.CurrentView.IsNewItemRow(DataGridViewRightSection_ProductCategories.CurrentView.FocusedRowHandle) Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = DataGridViewRightSection_ProductCategories.HasASelectedRow

            End If

            ButtonItemExport_CurrentView.Enabled = DataGridViewRightSection_ProductCategories.HasRows

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

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ProductCategorySetupForm As AdvantageFramework.Maintenance.Client.Presentation.ProductCategorySetupForm = Nothing

            ProductCategorySetupForm = New AdvantageFramework.Maintenance.Client.Presentation.ProductCategorySetupForm()

            ProductCategorySetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ProductCategorySetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            DataGridViewLeftSection_Products.MultiSelect = False

            DataGridViewRightSection_ProductCategories.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.ProductCategory)

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_Products.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Try

                DataGridViewRightSection_ProductCategories.CurrentView.AFActiveFilterString = "[IsInactive] = 0s Or [IsInactive] Is Null"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub ProductCategorySetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ProductCategorySetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ProductCategorySetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_Products.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ProductCategories As Generic.List(Of AdvantageFramework.Database.Entities.ProductCategory) = Nothing

            If DataGridViewRightSection_ProductCategories.HasRows Then

                DataGridViewRightSection_ProductCategories.CurrentView.CloseEditorForUpdating()

                ProductCategories = DataGridViewRightSection_ProductCategories.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ProductCategory)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each ProductCategory In ProductCategories

                            If AdvantageFramework.Database.Procedures.ProductCategory.Update(DbContext, ProductCategory) = False Then

                                DbContext.UndoChanges(ProductCategory)

                            End If

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewRightSection_ProductCategories.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ProductCategory As AdvantageFramework.Database.Entities.ProductCategory = Nothing
            Dim ProductCategories As Generic.List(Of AdvantageFramework.Database.Entities.ProductCategory) = Nothing

            If DataGridViewRightSection_ProductCategories.HasASelectedRow Then

                DataGridViewRightSection_ProductCategories.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Processing...")

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            ProductCategories = DataGridViewRightSection_ProductCategories.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ProductCategory)().ToList

                            For Each ProductCategory In ProductCategories

                                AdvantageFramework.Database.Procedures.ProductCategory.Delete(DbContext, ProductCategory)

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    LoadSelectedItemDetails()

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemExport_All_Click(sender As Object, e As System.EventArgs) Handles ButtonItemExport_All.Click

            'objects
            Dim ProductCategoriesList As Generic.List(Of AdvantageFramework.Database.Entities.ProductCategory) = Nothing
            Dim ProductCategories As Generic.List(Of AdvantageFramework.Database.Entities.ProductCategory) = Nothing
            Dim ProductViews As Generic.List(Of AdvantageFramework.Database.Views.ProductView) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ProductCategoriesList = New Generic.List(Of AdvantageFramework.Database.Entities.ProductCategory)

                    ProductViews = (From ProductView In AdvantageFramework.Database.Procedures.ProductView.LoadByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode, False).ToList
                                    Join Row In DataGridViewLeftSection_Products.GetAllRowsDataBoundItems() On ProductView.ClientCode Equals Row.ClientCode And ProductView.DivisionCode Equals Row.DivisionCode And ProductView.ProductCode Equals Row.ProductCode
                                    Select ProductView).ToList

                    Try

                        ProductCategoriesList = (From ProductCategory In AdvantageFramework.Database.Procedures.ProductCategory.Load(DbContext).ToList
                                                 Where ProductViews.Where(Function(ProductView) ProductView.ClientCode = ProductCategory.ClientCode AndAlso
                                                                                                ProductView.DivisionCode = ProductCategory.DivisionCode AndAlso
                                                                                                ProductView.ProductCode = ProductCategory.ProductCode).Any = True
                                                 Select ProductCategory).ToList

                    Catch ex As Exception

                    End Try

                    DataGridViewRightSection_AllProductCategories.DataSource = ProductCategoriesList

                    DataGridViewRightSection_AllProductCategories.CurrentView.BestFitColumns()

                    DataGridViewRightSection_AllProductCategories.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

                End Using

            End Using

        End Sub
        Private Sub ButtonItemExport_CurrentView_Click(sender As Object, e As System.EventArgs) Handles ButtonItemExport_CurrentView.Click

            DataGridViewRightSection_ProductCategories.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Copy.Click

            'objects
            Dim ContinueCopy As Boolean = True

            If DataGridViewLeftSection_Products.HasOnlyOneSelectedRow Then

                ContinueCopy = CheckForUnsavedChanges()

            End If

            If ContinueCopy Then

                If AdvantageFramework.Maintenance.Client.Presentation.ProductCategoryCopyDialog.ShowFormDialog() = System.Windows.Forms.DialogResult.OK Then

                    LoadSelectedItemDetails()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewRightSection_ProductCategories.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRightSection_ProductCategories_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewRightSection_ProductCategories.AddNewRowEvent

            'objects
            Dim ProductCategory As AdvantageFramework.Database.Entities.ProductCategory = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.ProductCategory Then

                ClientCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Views.ProductView.Properties.ClientCode.ToString)
                DivisionCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Views.ProductView.Properties.DivisionCode.ToString)
                ProductCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Views.ProductView.Properties.ProductCode.ToString)

                Me.ShowWaitForm("Processing...")

                Try

                    ProductCategory = RowObject

                    ProductCategory.ClientCode = ClientCode
                    ProductCategory.DivisionCode = DivisionCode
                    ProductCategory.ProductCode = ProductCode

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If ProductCategory.IsEntityBeingAdded() Then

                            ProductCategory.DbContext = DbContext

                            If AdvantageFramework.Database.Procedures.ProductCategory.Insert(DbContext, ProductCategory) Then

                                LoadSelectedItemDetails()

                            End If

                        End If

                    End Using

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Products_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_Products.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Products_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewLeftSection_Products.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewRightSection_ProductCategory_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRightSection_ProductCategories.CellValueChangingEvent

            'objects
            Dim ProductCategory As AdvantageFramework.Database.Entities.ProductCategory = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.ProductCategory.Properties.IsInactive.ToString Then

                Try

                    ProductCategory = DataGridViewRightSection_ProductCategories.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    ProductCategory = Nothing
                End Try

                If ProductCategory IsNot Nothing Then

                    Try

                        ProductCategory.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        ProductCategory.IsInactive = ProductCategory.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.ProductCategory.Update(DbContext, ProductCategory)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewRightSection_ProductCategories_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewRightSection_ProductCategories.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
		Private Sub DataGridViewRightSection_ProductCategories_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewRightSection_ProductCategories.InitNewRowEvent

			'objects
			Dim ProductCategory As AdvantageFramework.Database.Entities.ProductCategory = Nothing

			If TypeOf DataGridViewRightSection_ProductCategories.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Entities.ProductCategory Then

				ProductCategory = DataGridViewRightSection_ProductCategories.CurrentView.GetRow(e.RowHandle)

				ProductCategory.ClientCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Views.ProductView.Properties.ClientCode.ToString)
				ProductCategory.DivisionCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Views.ProductView.Properties.DivisionCode.ToString)
				ProductCategory.ProductCode = DataGridViewLeftSection_Products.CurrentView.GetRowCellValue(DataGridViewLeftSection_Products.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Views.ProductView.Properties.ProductCode.ToString)

			End If

			EnableOrDisableActions()

		End Sub

#End Region

#End Region

	End Class

End Namespace