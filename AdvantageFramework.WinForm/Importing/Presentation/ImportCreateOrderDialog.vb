Namespace Importing.Presentation

	Public Class ImportCreateOrderDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Private _ValidatingDbContext As AdvantageFramework.Database.DbContext = Nothing
		Private _ImportOrders As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
		Private _ShowOrderDescription As Boolean = True
		Private _SaveOrdersToTable As Boolean = True
		Private _CreateOrderOption As AdvantageFramework.MediaPlanning.CreateOrderOptions = MediaPlanning.CreateOrderOptions.Default
		Private _ImportSource As AdvantageFramework.Media.ImportSource = Media.ImportSource.Default

#End Region

#Region " Properties "



#End Region

#Region " Methods "

		Private Sub New(ImportOrders As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder),
						CreateOrderOption As AdvantageFramework.MediaPlanning.CreateOrderOptions,
						ShowOrderDescription As Boolean)

			' This call is required by the designer.
			InitializeComponent()

			' Add any initialization after the InitializeComponent() call.
			_ImportOrders = ImportOrders
			_ShowOrderDescription = ShowOrderDescription
			_CreateOrderOption = CreateOrderOption

		End Sub
		Private Sub LoadGrid()

			'objects
			Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
			Dim VisibleIndex As Integer = 0
			Dim ImportOrders As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing

			If ButtonItemOrderType_NewOnly.Checked Then

				ImportOrders = _ImportOrders.Where(Function(Entity) Entity.OrderNumber.GetValueOrDefault(0) = 0 OrElse (Entity.OrderNumber.GetValueOrDefault(0) <> 0 AndAlso Entity.OrderLineNumber.GetValueOrDefault(0) = 0)).ToList

			Else

				ImportOrders = _ImportOrders.ToList

			End If

			DataGridViewForm_Orders.DataSource = ImportOrders

			For Each GridColumn In DataGridViewForm_Orders.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

				If AdvantageFramework.Media.IsMediaOrderColumnVisible(GridColumn.FieldName, _ShowOrderDescription, _ImportSource) Then

					GridColumn.VisibleIndex = VisibleIndex
					VisibleIndex += 1
					GridColumn.Visible = True

					If _ImportSource = AdvantageFramework.Media.ImportSource.BroadcastWorksheet Then

						If GridColumn.Caption.Contains("Media Plan") Then

							GridColumn.Caption = GridColumn.Caption.Replace("Media Plan", "")

						ElseIf GridColumn.Caption = String.Empty AndAlso GridColumn.FieldName.Contains("MediaPlan") Then

							GridColumn.Caption = AdvantageFramework.StringUtilities.GetNameAsWords(GridColumn.FieldName.Replace("MediaPlan", ""))

						End If

					End If

				Else

					GridColumn.VisibleIndex = -1
					GridColumn.Visible = False

				End If

			Next

            If _ImportSource = AdvantageFramework.Media.ImportSource.MediaPlanning Then

                If _ImportOrders.Any(Function(Entity) Entity.MediaPlanParentPackage = True OrElse String.IsNullOrWhiteSpace(Entity.MediaPlanPackage) = False) = False Then

                    DataGridViewForm_Orders.MakeColumnNotVisible(AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanParentPackage.ToString)
                    DataGridViewForm_Orders.MakeColumnNotVisible(AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanPackage.ToString)

                End If

            End If

        End Sub
		Private Sub ApplyGrouping()

			DataGridViewForm_Orders.OptionsView.ShowGroupedColumns = True
			DataGridViewForm_Orders.Columns(AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaType.ToString).GroupIndex = 0
			DataGridViewForm_Orders.CurrentView.ExpandAllGroups()

		End Sub
		Private Sub EnableOrDisableActions()

			ButtonItemActions_Save.Enabled = DataGridViewForm_Orders.HasRows
			ButtonItemActions_Delete.Enabled = DataGridViewForm_Orders.HasRows

		End Sub
		Private Function WriteFile(ByVal FileStringBuilder As System.Text.StringBuilder, ByVal FullFileName As String) As Boolean

			Dim FileWritten As Boolean = False

			If FileStringBuilder.Length > 0 Then

				Try

					My.Computer.FileSystem.WriteAllText(FullFileName, FileStringBuilder.ToString, False)

				Catch ex As Exception

				End Try

				FileWritten = My.Computer.FileSystem.FileExists(FullFileName)

			Else

				FileWritten = True

			End If

			WriteFile = FileWritten

		End Function
		Private Sub AssignOrderIDs(ValidateRows As Boolean)

			'objects
			Dim ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing

			ImportOrderList = DataGridViewForm_Orders.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Media.Classes.ImportOrder)().ToList

			If AdvantageFramework.Media.AssignOrderID(Me.Session, _CreateOrderOption, ImportOrderList) Then

				DataGridViewForm_Orders.CurrentView.RefreshData()

				If ValidateRows Then

					ValidateAllRows()

				End If

			End If

		End Sub
		Private Sub ValidateAllRows()

			DataGridViewForm_Orders.RunStandardValidation = False
			_ValidatingDbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
			_ValidatingDbContext.Database.Connection.Open()

			DataGridViewForm_Orders.ValidateAllRows()

			_ValidatingDbContext.Database.Connection.Close()
			AdvantageFramework.Database.CloseDbContext(_ValidatingDbContext)
			DataGridViewForm_Orders.RunStandardValidation = True

		End Sub

#Region "  Show Form Methods "

		Public Shared Function ShowFormDialog(ImportOrders As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder),
											  CreateOrderOption As AdvantageFramework.MediaPlanning.CreateOrderOptions,
											  Optional ByVal ShowOrderDescription As Boolean = True) As System.Windows.Forms.DialogResult

			'objects
			Dim ImportCreateOrderDialog As AdvantageFramework.Importing.Presentation.ImportCreateOrderDialog = Nothing

			ImportCreateOrderDialog = New AdvantageFramework.Importing.Presentation.ImportCreateOrderDialog(ImportOrders, CreateOrderOption, ShowOrderDescription)

			ShowFormDialog = ImportCreateOrderDialog.ShowDialog()

		End Function

#End Region

#Region "  Form Event Handlers "

		Private Sub ImportCreateOrderDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

			ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
			ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
			ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage

			If _ImportOrders IsNot Nothing AndAlso _ImportOrders.FirstOrDefault IsNot Nothing Then

				_ImportSource = _ImportOrders.FirstOrDefault.ImportSource

			End If

			Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

				If _ImportSource = Media.ImportSource.MediaPlanning Then

					RibbonBarOptions_OrderTypes.Visible = True
					ButtonItemOrderType_NewAndRevised.Checked = True

				Else

					RibbonBarOptions_OrderTypes.Visible = False

				End If

			End Using

			If _ShowOrderDescription Then

				TextBoxForm_OrderDescription.SetDefaultPropertySettings(DisplayName:="Order Description", IsRequired:=True, MaxLength:=40)
				TextBoxForm_OrderDescription.Text = MonthName(Now.Month) & " Media"

			Else

				DataGridViewForm_Orders.Location = New System.Drawing.Point(4, 5)
				DataGridViewForm_Orders.Height += 30

			End If

			LoadGrid()

			ApplyGrouping()

			AssignOrderIDs(False)

			DataGridViewForm_Orders.CurrentView.BestFitColumns()

			EnableOrDisableActions()

		End Sub
		Private Sub ImportCreateOrderDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

			Me.ShowWaitForm("Validating...")

			ValidateAllRows()

			Me.CloseWaitForm()

		End Sub

#End Region

#Region "  Control Event Handlers "

		Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

			Me.DialogResult = Windows.Forms.DialogResult.Cancel
			Me.Close()

		End Sub
		Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

			'objects
			Dim ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
			Dim ErrorMessage As String = ""
            'Dim DbTransaction As System.Data.Common.DbTransaction = Nothing
            Dim Saved As Boolean = False
            'Dim DirectPostMessage As String = ""
            Dim AllDirectPostMessages As String = ""
            'Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim CancelledImportOrders As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim DialogResultIsOK As Boolean = False

            DataGridViewForm_Orders.CurrentView.CloseEditorForUpdating()

			Me.FormAction = WinForm.Presentation.FormActions.Saving
			Me.ShowWaitForm("Saving...")

            If DataGridViewForm_Orders.CurrentView.CheckForModifiedRows Then

                ValidateAllRows()

            End If

            Me.FormAction = WinForm.Presentation.FormActions.None
			Me.CloseWaitForm()

			If Me.Validator Then

				Me.FormAction = WinForm.Presentation.FormActions.Saving
				Me.ShowWaitForm("Saving...")

				If DataGridViewForm_Orders.HasAnyInvalidRows Then

					Me.FormAction = WinForm.Presentation.FormActions.None
					Me.CloseWaitForm()

					AdvantageFramework.WinForm.MessageBox.Show("Please fix invalid rows.", WinForm.MessageBox.MessageBoxButtons.OK)

				ElseIf _SaveOrdersToTable Then

					ImportOrderList = DataGridViewForm_Orders.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Media.Classes.ImportOrder)().ToList()
					CancelledImportOrders = New Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

                    'Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    '	Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    '                       Try

                    Saved = AdvantageFramework.Importing.SaveOrders(Session, ImportOrderList, ButtonItemOrderType_NewAndRevised.Checked, ButtonItemOrderType_NewOnly.Checked, _ShowOrderDescription, TextBoxForm_OrderDescription.Text, True, False, CancelledImportOrders, AllDirectPostMessages, DialogResultIsOK, ErrorMessage)

                    'DbContext.Database.Connection.Open()
                    'DataContext.Connection.Open()

                    'DbTransaction = DataContext.Connection.BeginTransaction

                    'DataContext.Transaction = DbTransaction

                    'For Each ImportOrder In ImportOrderList

                    '    If (ImportOrder.ImportSource = Media.ImportSource.MediaPlanning AndAlso (ButtonItemOrderType_NewAndRevised.Checked OrElse (ImportOrder.IsRevision = False AndAlso ButtonItemOrderType_NewOnly.Checked))) OrElse
                    '            ImportOrder.ImportSource <> Media.ImportSource.MediaPlanning Then

                    '        Vendor = DbContext.Vendors.SingleOrDefault(Function(Entity) Entity.Code = ImportOrder.VendorCode)

                    '        If Vendor IsNot Nothing Then

                    '            If ImportOrder.MediaType = "I" AndAlso Vendor.InternetCategory.GetValueOrDefault(0) = 0 Then

                    '                Vendor.InternetCategory = 1

                    '            ElseIf ImportOrder.MediaType = "M" AndAlso Vendor.MagazineCategory.GetValueOrDefault(0) = 0 Then

                    '                Vendor.MagazineCategory = 1

                    '            ElseIf ImportOrder.MediaType = "N" AndAlso Vendor.NewspaperCategory.GetValueOrDefault(0) = 0 Then

                    '                Vendor.NewspaperCategory = 1

                    '            ElseIf ImportOrder.MediaType = "O" AndAlso Vendor.OutOfHomeCategory.GetValueOrDefault(0) = 0 Then

                    '                Vendor.OutOfHomeCategory = 1

                    '            ElseIf ImportOrder.MediaType = "R" AndAlso Vendor.RadioCategory.GetValueOrDefault(0) = 0 Then

                    '                Vendor.RadioCategory = 1

                    '            ElseIf ImportOrder.MediaType = "T" AndAlso Vendor.TVCategory.GetValueOrDefault(0) = 0 Then

                    '                Vendor.TVCategory = 1

                    '            End If

                    '        End If

                    '        If AdvantageFramework.Media.CheckForCancelledOrderLine(DbContext, ImportOrder) = False Then

                    '            If AdvantageFramework.Media.CheckForAlreadyOrderedNewOrder(DbContext, ImportOrder) = False Then

                    '                If ImportOrder.MediaType = "R" OrElse ImportOrder.MediaType = "T" Then

                    '                    If AdvantageFramework.Media.CreateBroadcastImportFromImportOrder(DbContext, DataContext, ImportOrder, _ShowOrderDescription, TextBoxForm_OrderDescription.Text) = False Then

                    '                        Throw New Exception("Failed to create orders.")

                    '                    End If

                    '                Else

                    '                    If AdvantageFramework.Media.DirectPostImportOrder(DbContext, DataContext, ImportOrder, _ShowOrderDescription, TextBoxForm_OrderDescription.Text) = False Then

                    '                        Throw New Exception("Failed to create orders.")

                    '                    End If

                    '                End If

                    '            End If

                    '        Else

                    '            ImportOrder.EntityError = "Can't modify a cancelled line."
                    '            CancelledImportOrders.Add(ImportOrder)

                    '        End If

                    '    End If

                    'Next

                    'DbContext.SaveChanges()
                    'DataContext.SubmitChanges()

                    'DbTransaction.Commit()

                    'Saved = True

                    'If ImportOrderList.Any() Then

                    '    If ImportOrderList.Any(Function(Entity) Entity.MediaType = "N") Then

                    '        If AdvantageFramework.Media.ImportOrdersFromDirectPost(DbContext, Me.Session.UserCode, "", "N", DirectPostMessage) = False Then

                    '            AdvantageFramework.Media.ImportOrdersFromDirectPostCleanup(DbContext, Me.Session.UserCode, "", "N", DirectPostMessage)

                    '            ImportOrderList.ForEach(Function(Entity) Entity.EntityError = DirectPostMessage)

                    '            AllDirectPostMessages &= System.Environment.NewLine & DirectPostMessage

                    '        End If

                    '    End If

                    '    If ImportOrderList.Any(Function(Entity) Entity.MediaType = "M") Then

                    '        If AdvantageFramework.Media.ImportOrdersFromDirectPost(DbContext, Me.Session.UserCode, "", "M", DirectPostMessage) = False Then

                    '            AdvantageFramework.Media.ImportOrdersFromDirectPostCleanup(DbContext, Me.Session.UserCode, "", "M", DirectPostMessage)

                    '            ImportOrderList.ForEach(Function(Entity) Entity.EntityError = DirectPostMessage)

                    '            AllDirectPostMessages &= System.Environment.NewLine & DirectPostMessage

                    '        End If

                    '    End If

                    '    If ImportOrderList.Any(Function(Entity) Entity.MediaType = "O") Then

                    '        If AdvantageFramework.Media.ImportOrdersFromDirectPost(DbContext, Me.Session.UserCode, "", "O", DirectPostMessage) = False Then

                    '            AdvantageFramework.Media.ImportOrdersFromDirectPostCleanup(DbContext, Me.Session.UserCode, "", "O", DirectPostMessage)

                    '            ImportOrderList.ForEach(Function(Entity) Entity.EntityError = DirectPostMessage)

                    '            AllDirectPostMessages &= System.Environment.NewLine & DirectPostMessage

                    '        End If

                    '    End If

                    '    If ImportOrderList.Any(Function(Entity) Entity.MediaType = "I") Then

                    '        If AdvantageFramework.Media.ImportOrdersFromDirectPost(DbContext, Me.Session.UserCode, "", "I", DirectPostMessage) = False Then

                    '            AdvantageFramework.Media.ImportOrdersFromDirectPostCleanup(DbContext, Me.Session.UserCode, "", "I", DirectPostMessage)

                    '            ImportOrderList.ForEach(Function(Entity) Entity.EntityError = DirectPostMessage)

                    '            AllDirectPostMessages &= System.Environment.NewLine & DirectPostMessage

                    '        End If

                    '    End If

                    '    If ImportOrderList.Any(Function(Entity) Entity.MediaType = "R") Then

                    '        If AdvantageFramework.Media.ImportOrdersFromDirectPost(DbContext, Me.Session.UserCode, "", "R", DirectPostMessage) = False Then

                    '            AdvantageFramework.Media.ImportOrdersFromDirectPostCleanup(DbContext, Me.Session.UserCode, "", "R", DirectPostMessage)

                    '            ImportOrderList.ForEach(Function(Entity) Entity.EntityError = DirectPostMessage)

                    '            AllDirectPostMessages &= System.Environment.NewLine & DirectPostMessage

                    '        End If

                    '    End If

                    '    If ImportOrderList.Any(Function(Entity) Entity.MediaType = "T") Then

                    '        If AdvantageFramework.Media.ImportOrdersFromDirectPost(DbContext, Me.Session.UserCode, "", "T", DirectPostMessage) = False Then

                    '            AdvantageFramework.Media.ImportOrdersFromDirectPostCleanup(DbContext, Me.Session.UserCode, "", "T", DirectPostMessage)

                    '            ImportOrderList.ForEach(Function(Entity) Entity.EntityError = DirectPostMessage)

                    '            AllDirectPostMessages &= System.Environment.NewLine & DirectPostMessage

                    '        End If

                    '    End If

                    '    If String.IsNullOrWhiteSpace(AllDirectPostMessages) = False Then

                    '        If CancelledImportOrders.Any Then

                    '            AllDirectPostMessages &= System.Environment.NewLine & "Can't modify a cancelled line."

                    '        End If

                    '        AllDirectPostMessages = "An error occured while creating orders. Please contact software support." & System.Environment.NewLine & AllDirectPostMessages

                    '        AdvantageFramework.WinForm.MessageBox.Show(AllDirectPostMessages.Trim)

                    '    Else

                    '        If CancelledImportOrders.Any Then

                    '            AllDirectPostMessages &= "Create orders is complete." & System.Environment.NewLine & "Some order(s) could not be processed because the order/line(s) have been cancelled. The cancelled order/line(s) are noted in the window."

                    '            AdvantageFramework.WinForm.MessageBox.Show(AllDirectPostMessages)

                    '        Else

                    '            AdvantageFramework.WinForm.MessageBox.Show("Create orders is complete.")

                    If DialogResultIsOK Then

                        Me.DialogResult = Windows.Forms.DialogResult.OK

                    End If


                    '        End If

                    '    End If

                    'Else

                    '    AdvantageFramework.WinForm.MessageBox.Show("Order file(s) created, [Direct Post], use the Media Generic Import to finalize order creation.")

                    'End If

                    If CancelledImportOrders.Any OrElse String.IsNullOrWhiteSpace(AllDirectPostMessages) = False Then

                        Me.FormAction = WinForm.Presentation.FormActions.Refreshing
                        Me.ShowWaitForm("Refreshing...")

                        ValidateAllRows()

                        RibbonBarOptions_Actions.SecurityEnabled = False
                        RibbonBarOptions_OrderTypes.SecurityEnabled = False
                        RibbonBarOptions_Actions.Visible = False
                        RibbonBarOptions_OrderTypes.Visible = False

                        RibbonBarFilePanel_System.Visible = True

                        RibbonControlForm_MainRibbon.Refresh()

                    End If

                    '                     Catch ex As Exception
                    '                         If Not Saved Then
                    '                             DbTransaction.Rollback()
                    '                             ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                    '                             ErrorMessage += vbCrLf & ex.Message
                    '                             'ErrorMessage += vbCrLf & vbCrLf & ex.StackTrace
                    '                         End If

                    '                     Finally

                    '                         Me.FormAction = WinForm.Presentation.FormActions.None
                    '	Me.CloseWaitForm()

                    'End Try

                    '               End Using

                    'End Using

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                    If Saved = False AndAlso String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                Else

					Me.FormAction = WinForm.Presentation.FormActions.None
					Me.CloseWaitForm()

					AdvantageFramework.WinForm.MessageBox.Show("No orders to create.")

				End If

			Else

				For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

					ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

				Next

				AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

			End If

		End Sub
		Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

			Me.DialogResult = Windows.Forms.DialogResult.Cancel

		End Sub
		Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

			DataGridViewForm_Orders.CurrentView.DeleteSelectedRows()

			EnableOrDisableActions()

		End Sub
		Private Sub DataGridViewForm_Orders_RowCountChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Orders.RowCountChangedEvent

			EnableOrDisableActions()

		End Sub
		Private Sub DataGridViewForm_Orders_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_Orders.ShowingEditorEvent

			If _SaveOrdersToTable Then

				e.Cancel = True

			ElseIf DataGridViewForm_Orders.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.CostType.ToString Then

				If (DataGridViewForm_Orders.CurrentView.GetRowCellValue(DataGridViewForm_Orders.CurrentView.FocusedRowHandle, AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaType.ToString) = "I" OrElse
						DataGridViewForm_Orders.CurrentView.GetRowCellValue(DataGridViewForm_Orders.CurrentView.FocusedRowHandle, AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaType.ToString) = "N") AndAlso
						DataGridViewForm_Orders.CurrentView.GetRowCellValue(DataGridViewForm_Orders.CurrentView.FocusedRowHandle, AdvantageFramework.Media.Classes.ImportOrder.Properties.TotalSpots.ToString) Is Nothing Then

					e.Cancel = True

				End If

			ElseIf (DataGridViewForm_Orders.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.OrderID.ToString OrElse
					DataGridViewForm_Orders.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Media.Classes.ImportOrder.Properties.LineNumber.ToString) AndAlso
					DataGridViewForm_Orders.CurrentView.GetRowCellValue(DataGridViewForm_Orders.CurrentView.FocusedRowHandle, AdvantageFramework.Media.Classes.ImportOrder.Properties.IsRevision.ToString) = True Then

				e.Cancel = True

			End If

		End Sub
		Private Sub DataGridViewForm_Orders_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_Orders.ValidateRowEvent

			DirectCast(e.Row, AdvantageFramework.BaseClasses.BaseClass).DbContext = _ValidatingDbContext

			If Me.FormAction = WinForm.Presentation.Methods.FormActions.Refreshing Then

				e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.BaseClass).EntityError

			Else

				e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.BaseClass).ValidateEntity(e.Valid)

			End If

			e.Valid = True

		End Sub
		Private Sub ButtonItemOrderType_NewOnly_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemOrderType_NewOnly.CheckedChanged

			If Me.FormShown Then

				If ButtonItemOrderType_NewOnly.Checked Then

					LoadGrid()

					DataGridViewForm_Orders.CurrentView.ExpandAllGroups()

				End If

			End If

		End Sub
		Private Sub ButtonItemOrderType_NewAndRevised_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemOrderType_NewAndRevised.CheckedChanged

			If Me.FormShown Then

				If ButtonItemOrderType_NewAndRevised.Checked Then

					LoadGrid()

					DataGridViewForm_Orders.CurrentView.ExpandAllGroups()

				End If

			End If

		End Sub

#End Region

#End Region

	End Class

End Namespace