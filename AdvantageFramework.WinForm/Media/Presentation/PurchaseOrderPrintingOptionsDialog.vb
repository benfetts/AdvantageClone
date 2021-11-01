Namespace Media.Presentation

    Public Class PurchaseOrderPrintingOptionsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.POPrintOptionsViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.POPrintOptionsController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadViewModel()

            'objects
            Dim PurchaseOrderPrintDefault As AdvantageFramework.DTO.PurchaseOrderPrintDefault = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim Row As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing

            _ViewModel = _Controller.Load()

            If _ViewModel.PurchaseOrderPrintDefaults IsNot Nothing AndAlso _ViewModel.PurchaseOrderPrintDefaults.Count > 0 Then

                PurchaseOrderPrintDefault = _ViewModel.PurchaseOrderPrintDefaults.Item(0)

                If PurchaseOrderPrintDefault IsNot Nothing Then

                    For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.DTO.PurchaseOrderPrintDefault)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                        EntityAttribute = Nothing
                        Row = Nothing

                        Row = GetRowAndInitialize(VerticalGridPurchaseOrder_Settings, PropertyDescriptor, EntityAttribute)

                        If Row IsNot Nothing Then

                            If Row.Properties.FieldName = AdvantageFramework.DTO.PurchaseOrderPrintDefault.Properties.LocationID.ToString Then

                                RepositoryItem = CreateSubItemGridLookupEdit(AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.Location,
                                                                             AdvantageFramework.DTO.PurchaseOrderPrintDefault.Properties.LocationID,
                                                                             EntityAttribute, PropertyDescriptor,
                                                                             Nothing, True)

                            ElseIf Row.Properties.FieldName = AdvantageFramework.DTO.PurchaseOrderPrintDefault.Properties.ReportFormat.ToString Then

                                RepositoryItem = CreateSubItemGridLookupEdit(AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                             AdvantageFramework.DTO.PurchaseOrderPrintDefault.Properties.ReportFormat,
                                                                             EntityAttribute, PropertyDescriptor,
                                                                             GetType(AdvantageFramework.Reporting.PurchaseOrderReports), False)

                            ElseIf Row.Properties.FieldName = AdvantageFramework.DTO.PurchaseOrderPrintDefault.Properties.DateToPrint.ToString Then

                                RepositoryItem = CreateSubItemGridLookupEdit(AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                            AdvantageFramework.DTO.PurchaseOrderPrintDefault.Properties.DateToPrint,
                                                                            EntityAttribute, PropertyDescriptor,
                                                                            GetType(AdvantageFramework.Media.PurchaseOrderDateOverrideSettings), False)

                            Else

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateDefaultSubItem(Me.Session, Row.Properties.FieldName, PropertyDescriptor.PropertyType, Row.Properties.Format.FormatString, GetType(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting))

                            End If

                            If TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                                CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

                            End If

                            VerticalGridPurchaseOrder_Settings.RepositoryItems.Add(RepositoryItem)

                            Row.Properties.RowEdit = RepositoryItem

                        End If

                    Next

                End If

            End If

            VerticalGridPurchaseOrder_Settings.DataSource = _ViewModel.PurchaseOrderPrintDefaults

            VerticalGridPurchaseOrder_Settings.ExpandAllRows()

            VerticalGridPurchaseOrder_Settings.BestFit()

        End Sub
        Private Function CreateSubItemGridLookupEdit(SubItemGridLookUpEditControlType As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type,
                                                     PurchaseOrderPrintSettingProperty As AdvantageFramework.DTO.PurchaseOrderPrintDefault.Properties,
                                                     EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute,
                                                     PropertyDescriptor As System.ComponentModel.PropertyDescriptor,
                                                     EnumType As System.Type, AllowExtraComboItems As Boolean) As DevExpress.XtraEditors.Repository.RepositoryItem

            'objects
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing

            RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, SubItemGridLookUpEditControlType, PurchaseOrderPrintSettingProperty.ToString, EntityAttribute, PropertyDescriptor, EnumType, AllowExtraComboItems)

            If RepositoryItem IsNot Nothing Then

                CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

            End If

            CreateSubItemGridLookupEdit = RepositoryItem

        End Function
        Private Function GetRowAndInitialize(VerticalGrid As DevExpress.XtraVerticalGrid.VGridControl, PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByRef EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute) As DevExpress.XtraVerticalGrid.Rows.BaseRow

            'objects
            Dim Row As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            Try

                Row = VerticalGrid.Rows.GetRowByFieldName(PropertyDescriptor.Name, True)

            Catch ex As Exception
                Row = Nothing
            End Try

            If Row IsNot Nothing Then

                Try

                    EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                Catch ex As Exception
                    EntityAttribute = Nothing
                End Try

                If EntityAttribute IsNot Nothing Then

                    If EntityAttribute.DisplayFormat <> "" Then

                        If EntityAttribute.DisplayFormat.StartsWith("c") OrElse EntityAttribute.DisplayFormat.StartsWith("n") Then

                            Row.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric

                        ElseIf EntityAttribute.DisplayFormat.StartsWith("d") Then

                            Row.Properties.Format.FormatType = DevExpress.Utils.FormatType.DateTime

                        End If

                        Row.Properties.Format.FormatString = EntityAttribute.DisplayFormat

                    End If

                End If

                Row.OptionsRow.AllowMove = False
                Row.OptionsRow.AllowMoveToCustomizationForm = False
                Row.OptionsRow.ShowInCustomizationForm = False

            End If

            GetRowAndInitialize = Row

        End Function
        Private Sub GetVerticalGridErrorMessage(ByVal VerticalGrid As DevExpress.XtraVerticalGrid.VGridControl, ByVal ParentRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByRef ErrorMessage As String)

            'objects
            Dim RowErrorMessage As String = ""

            For Each Row In ParentRow.ChildRows

                RowErrorMessage = ""

                If Row.ChildRows IsNot Nothing AndAlso Row.ChildRows.Count > 0 Then

                    GetVerticalGridErrorMessage(VerticalGrid, Row, ErrorMessage)

                End If

                RowErrorMessage = VerticalGrid.GetRowError(Row.Properties)

                If String.IsNullOrEmpty(RowErrorMessage) = False Then

                    If ErrorMessage = "" Then

                        ErrorMessage = VerticalGrid.Name.Replace("VerticalGrid", "").Replace("_Settings", "") & " - " & RowErrorMessage

                    Else

                        ErrorMessage &= vbNewLine & VerticalGrid.Name.Replace("VerticalGrid", "").Replace("_Settings", "") & " - " & RowErrorMessage

                    End If

                End If

            Next

        End Sub
        Private Sub GetVerticalGridErrorMessage(ByVal VerticalGrid As DevExpress.XtraVerticalGrid.VGridControl, ByRef ErrorMessage As String)

            'objects
            Dim RowErrorMessage As String = ""

            For Each Row In VerticalGrid.Rows.OfType(Of DevExpress.XtraVerticalGrid.Rows.BaseRow).ToList

                If Row.ChildRows IsNot Nothing AndAlso Row.ChildRows.Count > 0 Then

                    GetVerticalGridErrorMessage(VerticalGrid, Row, ErrorMessage)

                End If

                RowErrorMessage = VerticalGrid.GetRowError(Row.Properties)

                If String.IsNullOrEmpty(RowErrorMessage) = False Then

                    If ErrorMessage = "" Then

                        ErrorMessage = VerticalGrid.Name.Replace("VerticalGrid", "").Replace("_Settings", "") & " - " & RowErrorMessage

                    Else

                        ErrorMessage &= vbNewLine & VerticalGrid.Name.Replace("VerticalGrid", "").Replace("_Settings", "") & " - " & RowErrorMessage

                    End If

                End If

            Next

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.PurchaseOrderPrintDefaults = DirectCast(VerticalGridPurchaseOrder_Settings.DataSource, Generic.List(Of AdvantageFramework.DTO.PurchaseOrderPrintDefault))

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As System.Windows.Forms.DialogResult

            'objects
            Dim PurchaseOrderPrintingOptionsDialog As PurchaseOrderPrintingOptionsDialog = Nothing

            PurchaseOrderPrintingOptionsDialog = New PurchaseOrderPrintingOptionsDialog()

            ShowFormDialog = PurchaseOrderPrintingOptionsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub PurchaseOrderPrintingOptionsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            _Controller = New AdvantageFramework.Controller.Media.POPrintOptionsController(Me.Session)

        End Sub
        Private Sub PurchaseOrderPrintingOptionsDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub
        Private Sub PurchaseOrderPrintingOptionsDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub PurchaseOrderPrintingOptionsDialog_UserEntryChangedEvent(ByVal Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            VerticalGridPurchaseOrder_Settings.CloseEditor()

            If VerticalGridPurchaseOrder_Settings.HasRowErrors = False Then

                SaveViewModel()

                _Controller.Save(_ViewModel)

                Me.ClearChanged()

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                GetVerticalGridErrorMessage(VerticalGridPurchaseOrder_Settings, ErrorMessage)

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub VerticalGridPurchaseOrder_Settings_CellValueChanging(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles VerticalGridPurchaseOrder_Settings.CellValueChanging

            'objects
            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            If e.Row.Properties.FieldName = AdvantageFramework.DTO.PurchaseOrderPrintDefault.Properties.UseEmployeeSignature.ToString Then

                BaseRow = VerticalGridPurchaseOrder_Settings.Rows.GetRowByFieldName(AdvantageFramework.DTO.PurchaseOrderPrintDefault.Properties.UseUserSignature.ToString, True)

                If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                    If e.Value = True Then

                        VerticalGridPurchaseOrder_Settings.SetCellValue(rowUseLoggedInUserSignature, VerticalGridPurchaseOrder_Settings.FocusedRecord, False)

                        CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                    Else

                        CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace