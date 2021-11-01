Namespace WinForm.Presentation

    Public Class GenericPropertyGridDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _SelectedObject As Object = Nothing
        Private _PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property SelectedObject() As Object
            Get
                SelectedObject = _SelectedObject
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal Title As String, ByVal SelectedObject As Object, ByVal ShowDescriptionPanel As Boolean)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _SelectedObject = SelectedObject
            Me.Text = Title
            PanelForm_MiddleSection.Visible = ShowDescriptionPanel

        End Sub
        Private Sub SetCellValue(FieldName As String, Value As Object)

            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            Try

                BaseRow = PropertyGridForm_Item.GetRowByFieldName(FieldName)

            Catch ex As Exception

            End Try

            If BaseRow IsNot Nothing Then

                BaseRow.Properties.Value = Value

            End If

        End Sub
        Private Sub BillingSelectionCriteriaEnableRows(UseComboBilling As Boolean)

            If DirectCast(_SelectedObject, AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria).IsProcessed Then

                PropertyGridForm_Item.GetRowByFieldName(AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.UseComboBilling.ToString).Properties.ReadOnly = True
                PropertyGridForm_Item.GetRowByFieldName(AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.ComboAssignInvoicesBy.ToString).Properties.ReadOnly = True
                PropertyGridForm_Item.GetRowByFieldName(AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.ProductionAssignInvoicesBy.ToString).Properties.ReadOnly = True
                PropertyGridForm_Item.GetRowByFieldName(AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.MediaAssignInvoicesBy.ToString).Properties.ReadOnly = True

            Else

                PropertyGridForm_Item.GetRowByFieldName(AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.ComboAssignInvoicesBy.ToString).Properties.ReadOnly = Not UseComboBilling
                PropertyGridForm_Item.GetRowByFieldName(AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.ProductionAssignInvoicesBy.ToString).Properties.ReadOnly = UseComboBilling
                PropertyGridForm_Item.GetRowByFieldName(AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.MediaAssignInvoicesBy.ToString).Properties.ReadOnly = UseComboBilling

            End If

            If UseComboBilling Then

                SetCellValue(AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.ProductionAssignInvoicesBy.ToString, Nothing)
                SetCellValue(AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.MediaAssignInvoicesBy.ToString, Nothing)

            Else

                SetCellValue(AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.ComboAssignInvoicesBy.ToString, AdvantageFramework.Database.Entities.AssignComboInvoicesBy.None)

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal Title As String, ByRef SelectedObject As Object, ByVal ShowDescriptionPanel As Boolean) As Windows.Forms.DialogResult

            'objects
            Dim GenericPropertyGridDialog As AdvantageFramework.WinForm.Presentation.GenericPropertyGridDialog = Nothing

            GenericPropertyGridDialog = New AdvantageFramework.WinForm.Presentation.GenericPropertyGridDialog(Title, SelectedObject, ShowDescriptionPanel)

            ShowFormDialog = GenericPropertyGridDialog.ShowDialog()

            SelectedObject = GenericPropertyGridDialog.SelectedObject

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub GenericPropertyGridDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim ShowOverrideRows As Boolean = False

            Me.ShowUnsavedChangesOnFormClosing = False

            PropertyGridForm_Item.OptionsBehavior.Editable = True
            PropertyGridForm_Item.SelectedObject = _SelectedObject

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If TypeOf _SelectedObject Is AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria Then

                    BillingSelectionCriteriaEnableRows(DirectCast(_SelectedObject, AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria).UseComboBilling)

                    _PostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveARPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                    PropertyGridForm_Item.ValidateAllRows()

                    If DirectCast(_SelectedObject, AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria).ComboAssignInvoicesBy <> 0 OrElse
                            Not String.IsNullOrWhiteSpace(DirectCast(_SelectedObject, AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria).ProductionAssignInvoicesBy) OrElse
                            Not String.IsNullOrWhiteSpace(DirectCast(_SelectedObject, AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria).MediaAssignInvoicesBy) Then

                        ShowOverrideRows = True

                    End If

                    PropertyGridForm_Item.GetRowByFieldName(AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.UseComboBilling.ToString).Visible = ShowOverrideRows
                    PropertyGridForm_Item.GetRowByFieldName(AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.ComboAssignInvoicesBy.ToString).Visible = ShowOverrideRows
                    PropertyGridForm_Item.GetRowByFieldName(AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.ProductionAssignInvoicesBy.ToString).Visible = ShowOverrideRows
                    PropertyGridForm_Item.GetRowByFieldName(AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.MediaAssignInvoicesBy.ToString).Visible = ShowOverrideRows

                    ButtonForm_ShowOverrides.Visible = Not ShowOverrideRows

                ElseIf TypeOf _SelectedObject Is AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptPostPeriodBank Then

                    _PostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveARPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                    ButtonForm_ShowOverrides.Visible = False

                Else

                    ButtonForm_ShowOverrides.Visible = False

                End If

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim IsValid As Boolean = True
            Dim BillingSelectionCriteria As AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria = Nothing
            Dim ImportClientCashReceiptPostPeriodBank As AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptPostPeriodBank = Nothing
            Dim ReportCriteria As AdvantageFramework.DoubleClick.Classes.ReportCriteria = Nothing
            Dim AdvanceBillRevenueRecognition As AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillRevenueRecognition = Nothing

            PropertyGridForm_Item.ValidateAllRows()

            If Me.Validator Then

                If TypeOf _SelectedObject Is AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria Then

                    BillingSelectionCriteria = DirectCast(_SelectedObject, AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria)

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        BillingSelectionCriteria.DbContext = DbContext

                        ErrorMessage = BillingSelectionCriteria.ValidateEntity(IsValid)

                        If Not IsValid Then

                            AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                        ElseIf BillingSelectionCriteria.ShowPostPeriodWarning Then

                            If AdvantageFramework.AccountPayable.IsDateOutsidePostPeriod(DbContext, BillingSelectionCriteria.InvoiceDate, BillingSelectionCriteria.PostPeriodCode) Then

                                If AdvantageFramework.WinForm.MessageBox.Show("The invoice date is outside of normal range based on the posting period selected, are you sure you want to continue?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.No Then

                                    IsValid = False

                                End If

                            End If

                        End If

                    End Using

                ElseIf TypeOf _SelectedObject Is AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptPostPeriodBank Then

                    ImportClientCashReceiptPostPeriodBank = DirectCast(_SelectedObject, AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptPostPeriodBank)

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        ImportClientCashReceiptPostPeriodBank.DbContext = DbContext

                        ErrorMessage = ImportClientCashReceiptPostPeriodBank.ValidateEntity(IsValid)

                        If Not IsValid Then

                            AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                        End If

                    End Using

                ElseIf TypeOf _SelectedObject Is AdvantageFramework.DoubleClick.Classes.ReportCriteria Then

                    ReportCriteria = DirectCast(_SelectedObject, AdvantageFramework.DoubleClick.Classes.ReportCriteria)

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        ReportCriteria.DbContext = DbContext

                        ErrorMessage = ReportCriteria.ValidateEntity(IsValid)

                        If Not IsValid Then

                            AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                        End If

                    End Using

                ElseIf TypeOf _SelectedObject Is AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillRevenueRecognition Then

                    AdvanceBillRevenueRecognition = DirectCast(_SelectedObject, AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillRevenueRecognition)

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        AdvanceBillRevenueRecognition.DbContext = DbContext

                        ErrorMessage = AdvanceBillRevenueRecognition.ValidateEntity(IsValid)

                        If Not IsValid Then

                            AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                        End If

                    End Using

                End If

                If IsValid Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub PropertyGridForm_Item_CellValueChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles PropertyGridForm_Item.CellValueChanged

            If TypeOf _SelectedObject Is AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria Then

                If e.Row.Properties.FieldName = AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.UseComboBilling.ToString Then

                    BillingSelectionCriteriaEnableRows(e.Value)

                End If

            End If

        End Sub
        Private Sub PropertyGridForm_Item_QueryPopupNeedDatasource(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles PropertyGridForm_Item.QueryPopupNeedDatasource

            If TypeOf PropertyGridForm_Item.SelectedObject Is AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria Then

                If FieldName = AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.PostPeriodCode.ToString Then

                    Try

                        Datasource = _PostPeriods

                        OverrideDefaultDatasource = True

                    Catch ex As Exception
                        OverrideDefaultDatasource = False
                        Datasource = False
                    End Try

                End If

            ElseIf TypeOf PropertyGridForm_Item.SelectedObject Is AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptPostPeriodBank Then

                If FieldName = AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.PostPeriodCode.ToString Then

                    Try

                        Datasource = _PostPeriods

                        OverrideDefaultDatasource = True

                    Catch ex As Exception
                        OverrideDefaultDatasource = False
                        Datasource = False
                    End Try

                End If

            ElseIf TypeOf PropertyGridForm_Item.SelectedObject Is AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillRevenueRecognition Then

                Datasource = From Entity In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ProductionAdvancedBillingIncome))
                             Select [Code] = CShort(Entity.Key),
                                    [Description] = Entity.Value

                OverrideDefaultDatasource = True

            End If

        End Sub
        Private Sub ButtonForm_ShowOverrides_Click(sender As Object, e As EventArgs) Handles ButtonForm_ShowOverrides.Click

            PropertyGridForm_Item.GetRowByFieldName(AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.UseComboBilling.ToString).Visible = True
            PropertyGridForm_Item.GetRowByFieldName(AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.ComboAssignInvoicesBy.ToString).Visible = True
            PropertyGridForm_Item.GetRowByFieldName(AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.ProductionAssignInvoicesBy.ToString).Visible = True
            PropertyGridForm_Item.GetRowByFieldName(AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria.Properties.MediaAssignInvoicesBy.ToString).Visible = True

        End Sub

#End Region

#End Region

    End Class

End Namespace
