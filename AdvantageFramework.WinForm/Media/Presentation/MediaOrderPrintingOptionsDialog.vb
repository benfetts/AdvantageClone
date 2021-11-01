Namespace Media.Presentation

    Public Class MediaOrderPrintingOptionsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _OrderPrintSetting As AdvantageFramework.Media.Classes.OrderPrintSetting = Nothing
        Private _OrderPrintSettings As Generic.List(Of AdvantageFramework.Media.Classes.OrderPrintSetting) = Nothing
        Private _IsDaily As Boolean

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(OrderPrintSetting As AdvantageFramework.Media.Classes.OrderPrintSetting)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _OrderPrintSetting = OrderPrintSetting

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim OrderPrintSetting As AdvantageFramework.Media.Classes.OrderPrintSetting = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim Row As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing
            Dim CategoryRow As DevExpress.XtraVerticalGrid.Rows.CategoryRow = Nothing
            Dim CustomInvoice As AdvantageFramework.Reporting.Database.Entities.CustomInvoice = Nothing

            If _OrderPrintSettings IsNot Nothing AndAlso _OrderPrintSettings.Count > 0 Then

                OrderPrintSetting = _OrderPrintSettings(0)

                If OrderPrintSetting IsNot Nothing Then

                    For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Media.Classes.OrderPrintSetting)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                        EntityAttribute = Nothing
                        Row = Nothing

                        Row = GetRowAndInitialize(VerticalGridMediaOrder_Settings, PropertyDescriptor, EntityAttribute)

                        If Row IsNot Nothing Then

                            If Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.LocationID.ToString Then

                                RepositoryItem = CreateSubItemGridLookupEdit(AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.Location,
                                                                             AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.LocationID,
                                                                             EntityAttribute, PropertyDescriptor,
                                                                             Nothing, True)

                            ElseIf Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.ReportFormat.ToString Then

                                If OrderPrintSetting.MediaType = "R" OrElse OrderPrintSetting.MediaType = "T" Then

                                    If (OrderPrintSetting.IsDaily) Then

                                        RepositoryItem = CreateSubItemGridLookupEdit(AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                 AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.ReportFormat,
                                                                                 EntityAttribute, PropertyDescriptor,
                                                                                 GetType(AdvantageFramework.Media.BroadcastMediaOrderFormats), False)

                                    Else

                                        RepositoryItem = CreateSubItemGridLookupEdit(AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                 AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.ReportFormat,
                                                                                 EntityAttribute, PropertyDescriptor,
                                                                                 GetType(AdvantageFramework.Media.BroadcastMediaOrderFormatsWeekly), False)

                                    End If

                                ElseIf OrderPrintSetting.MediaType = "I" Then

                                    RepositoryItem = CreateSubItemGridLookupEdit(AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                 AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.ReportFormat,
                                                                                 EntityAttribute, PropertyDescriptor,
                                                                                 GetType(AdvantageFramework.Media.InternetOrderFormats), False)

                                Else

                                    RepositoryItem = CreateSubItemGridLookupEdit(AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                 AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.ReportFormat,
                                                                                 EntityAttribute, PropertyDescriptor,
                                                                                 GetType(AdvantageFramework.Media.NonBroadcastMediaOrderFormats), False)

                                End If

                                AddHandler CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).EditValueChanged, AddressOf SubItemGridLookUpEditControlType_EditValueChanged

                            ElseIf Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.DateOverride.ToString Then

                                RepositoryItem = CreateSubItemGridLookupEdit(AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.DateOverride,
                                                                                EntityAttribute, PropertyDescriptor,
                                                                                GetType(AdvantageFramework.Media.MediaOrderDateOverrideSettings), False)

                            ElseIf Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.MediaTitleOption.ToString Then

                                RepositoryItem = CreateSubItemGridLookupEdit(AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                            AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.MediaTitleOption,
                                                                            EntityAttribute, PropertyDescriptor,
                                                                            GetType(AdvantageFramework.Media.MediaOrderTitleOptions), False)

                            ElseIf Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.OrderHeaderCommentOption.ToString Then

                                RepositoryItem = CreateSubItemGridLookupEdit(AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                            AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.OrderHeaderCommentOption,
                                                                            EntityAttribute, PropertyDescriptor,
                                                                            GetType(AdvantageFramework.Media.MediaOrderHeaderCommentOption), False)

                            ElseIf Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.ExchangeRate.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateDefaultSubItem(Me.Session, Row.Properties.FieldName, PropertyDescriptor.PropertyType, "n4", GetType(AdvantageFramework.Media.Classes.OrderPrintSetting))

                                If RepositoryItem.GetType.Equals(GetType(AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput)) Then

                                    DirectCast(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = 999999.9999
                                    DirectCast(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 11
                                    DirectCast(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MinValue = 0

                                End If

                            Else

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateDefaultSubItem(Me.Session, Row.Properties.FieldName, PropertyDescriptor.PropertyType, Row.Properties.Format.FormatString, GetType(AdvantageFramework.Media.Classes.OrderPrintSetting))

                            End If

                            If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                If Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Projected.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Actual.ToString Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = OrderPrintSetting.Guaranteed

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Rep1Label.ToString Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not OrderPrintSetting.DefaultLabelFromVendor1

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Rep2Label.ToString Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not OrderPrintSetting.DefaultLabelFromVendor2

                                ElseIf ((OrderPrintSetting.ReportFormat = "4") OrElse (OrderPrintSetting.ReportFormat = "5") OrElse (OrderPrintSetting.ReportFormat = "6")) AndAlso (
                                        Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Programming.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.StartTime.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.EndTime.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Length.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Days.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Daypart.ToString) Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.IncludeFlighting.ToString Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = (OrderPrintSetting.MediaType = "I" AndAlso OrderPrintSetting.ReportFormat = "2")

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.InternetQtyOverrideText.ToString Then

                                    DirectCast(RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit).MaxLength = 15

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.ExchangeRate.ToString Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = OrderPrintSetting.ApplyExchangeRate

                                End If

                            End If

                            If TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                                CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

                            End If

                            VerticalGridMediaOrder_Settings.RepositoryItems.Add(RepositoryItem)

                            Row.Properties.RowEdit = RepositoryItem

                        End If

                    Next

                End If

            End If

            VerticalGridMediaOrder_Settings.DataSource = _OrderPrintSettings

            VerticalGridMediaOrder_Settings.ExpandAllRows()

            VerticalGridMediaOrder_Settings.BestFit()

        End Sub
        Private Function CreateSubItemGridLookupEdit(SubItemGridLookUpEditControlType As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type,
                                                     OrderPrintSettingProperty As AdvantageFramework.Media.Classes.OrderPrintSetting.Properties,
                                                     EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute,
                                                     PropertyDescriptor As System.ComponentModel.PropertyDescriptor,
                                                     EnumType As System.Type, AllowExtraComboItems As Boolean) As DevExpress.XtraEditors.Repository.RepositoryItem

            'objects
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing

            RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, SubItemGridLookUpEditControlType, OrderPrintSettingProperty.ToString, EntityAttribute, PropertyDescriptor, EnumType, AllowExtraComboItems)

            If RepositoryItem IsNot Nothing Then

                CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

            End If

            CreateSubItemGridLookupEdit = RepositoryItem

        End Function
        Protected Sub SubItemGridLookUpEditControlType_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            If _OrderPrintSetting IsNot Nothing Then

                If _OrderPrintSetting.MediaType = "I" Then

                    If DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).EditValue = CStr(AdvantageFramework.Media.InternetOrderFormats.NetOrderWithGrossClientTotals) Then

                        rowAgencyCommission.Enabled = False
                        _OrderPrintSetting.AgencyCommission = False

                    Else

                        rowAgencyCommission.Enabled = True

                    End If

                ElseIf {"M", "N", "O"}.Contains(_OrderPrintSetting.MediaType) = True Then

                    If DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).EditValue = CStr(AdvantageFramework.Media.NonBroadcastMediaOrderFormats.NetOrderWithGrossClientTotals) Then

                        rowAgencyCommission.Enabled = False
                        _OrderPrintSetting.AgencyCommission = False

                    Else

                        rowAgencyCommission.Enabled = True

                    End If

                End If

            End If

        End Sub
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

                If rowIncludeLineMarket.ChildRows IsNot Nothing AndAlso rowIncludeLineMarket.ChildRows.Count > 0 Then

                    GetVerticalGridErrorMessage(VerticalGrid, rowIncludeLineMarket, ErrorMessage)

                End If

                RowErrorMessage = VerticalGrid.GetRowError(rowIncludeLineMarket.Properties)

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

                If rowIncludeLineMarket.ChildRows IsNot Nothing AndAlso rowIncludeLineMarket.ChildRows.Count > 0 Then

                    GetVerticalGridErrorMessage(VerticalGrid, rowIncludeLineMarket, ErrorMessage)

                End If

                RowErrorMessage = VerticalGrid.GetRowError(rowIncludeLineMarket.Properties)

                If String.IsNullOrEmpty(RowErrorMessage) = False Then

                    If ErrorMessage = "" Then

                        ErrorMessage = VerticalGrid.Name.Replace("VerticalGrid", "").Replace("_Settings", "") & " - " & RowErrorMessage

                    Else

                        ErrorMessage &= vbNewLine & VerticalGrid.Name.Replace("VerticalGrid", "").Replace("_Settings", "") & " - " & RowErrorMessage

                    End If

                End If

            Next

        End Sub
        Private Sub EnableDisableInternetFields(FieldName As String, Enabled As Boolean)

            'objects
            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            BaseRow = VerticalGridMediaOrder_Settings.Rows.GetRowByFieldName(FieldName, True)

            If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Enabled

            End If

        End Sub
        Private Sub EnableInternetFieldsByReportFormat(ReportFormat As String)

            If ReportFormat = "1" Then

                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Placement1.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Placement2.ToString, True)

                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.IncludeFlighting.ToString, False)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Type.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Headline.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.URL.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.CopyArea.ToString, True) 'file size
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.TargetAudience.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.AdNumber.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.JobNumber.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.MaterialDueDate.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.SpaceCloseDate.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.MiscInfo.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.OrderCopy.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.MaterialNotes.ToString, True)

                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Projected.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Actual.ToString, True)

                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.IncludeLineMarket.ToString, False)

                rowPlacement2.Properties.Caption = "Package Name"
                rowTargetAudience.Properties.Caption = "Target Audience"

            ElseIf ReportFormat = "2" Then

                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Placement1.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Placement2.ToString, True)

                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.IncludeFlighting.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Type.ToString, False)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Headline.ToString, False)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.URL.ToString, False)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.CopyArea.ToString, False) 'file size
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.TargetAudience.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.AdNumber.ToString, False)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.JobNumber.ToString, False)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.MaterialDueDate.ToString, False)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.SpaceCloseDate.ToString, False)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.MiscInfo.ToString, False)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.OrderCopy.ToString, False)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.MaterialNotes.ToString, False)

                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Projected.ToString, False)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Actual.ToString, False)

                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.IncludeLineMarket.ToString, True)

                rowPlacement2.Properties.Caption = "Package Details"
                rowTargetAudience.Properties.Caption = "Target"

            ElseIf ReportFormat = "3" Then

                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.AgencyCommission.ToString, False)

                'same as format "1" above
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Placement1.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Placement2.ToString, True)

                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.IncludeFlighting.ToString, False)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Type.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Headline.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.URL.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.CopyArea.ToString, True) 'file size
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.TargetAudience.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.AdNumber.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.JobNumber.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.MaterialDueDate.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.SpaceCloseDate.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.MiscInfo.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.OrderCopy.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.MaterialNotes.ToString, True)

                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Projected.ToString, True)
                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Actual.ToString, True)

                EnableDisableInternetFields(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.IncludeLineMarket.ToString, False)
                'same as format "1" above

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(OrderPrintSetting As AdvantageFramework.Media.Classes.OrderPrintSetting) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaOrderPrintingOptionsDialog As MediaOrderPrintingOptionsDialog = Nothing

            MediaOrderPrintingOptionsDialog = New MediaOrderPrintingOptionsDialog(OrderPrintSetting)

            ShowFormDialog = MediaOrderPrintingOptionsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaOrderPrintingOptionsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            _OrderPrintSettings = New Generic.List(Of AdvantageFramework.Media.Classes.OrderPrintSetting)

            If _OrderPrintSetting IsNot Nothing Then

                _OrderPrintSettings.Add(_OrderPrintSetting)

                LabelForm_Format.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Media.MediaTypes), _OrderPrintSetting.MediaType)

                LoadGrid()

                rowBroadcastShowEmptyWeeks.Visible = False
                rowShowLineNumbers.Visible = False
                rowProgramming.Visible = False
                rowStartTime.Visible = False
                rowEndTime.Visible = False
                rowLength.Visible = False
                rowRemarks.Visible = False
                rowProductionSize.Visible = False
                rowType.Visible = False
                rowHeadline.Visible = False
                rowIssue.Visible = False
                rowURL.Visible = False
                rowLocation.Visible = False
                rowCopyArea.Visible = False
                rowPlacement1.Visible = False
                rowPlacement2.Visible = False
                rowTargetAudience.Visible = False
                rowEdition.Visible = False
                rowSection.Visible = False
                rowMaterial.Visible = False
                rowAdNumber.Visible = False
                rowJobNumber.Visible = False
                rowMaterialDueDate.Visible = False
                rowSpaceCloseDate.Visible = False
                rowInstructions.Visible = False
                rowMiscInfo.Visible = False
                rowOrderCopy.Visible = False
                rowMaterialNotes.Visible = False
                rowPositionInfo.Visible = False
                rowCloseInfo.Visible = False
                rowRateInfo.Visible = False
                rowGuaranteed.Visible = False
                rowProjected.Visible = False
                rowActual.Visible = False
                rowCostPer.Visible = False
                rowDays.Visible = False
                rowDaypart.Visible = False
                rowAddedValue.Visible = False
                rowBookends.Visible = False
                rowPrimaryRating.Visible = False
                rowPrimaryCPP.Visible = False
                rowPrintDayDate.Visible = False
                rowPrimaryCPM.Visible = False
                rowPrimaryImpressions.Visible = False
                rowPrimaryAQH.Visible = False
                rowIncludeFlighting.Visible = False
                rowIncludeLineMarket.Visible = False
                rowInternetQtyOverrideText.Visible = False
                rowSeparationPolicy.Visible = False

                If _OrderPrintSetting.MediaType = "I" Then

                    rowType.Visible = True
                    rowHeadline.Visible = True
                    rowURL.Visible = True
                    rowCopyArea.Visible = True
                    rowCopyArea.Properties.Caption = "File Size"
                    rowPlacement1.Visible = True
                    rowPlacement2.Visible = True
                    rowTargetAudience.Visible = True
                    rowAdNumber.Visible = True
                    rowJobNumber.Visible = True
                    rowMaterialDueDate.Visible = True
                    rowSpaceCloseDate.Visible = True
                    rowInstructions.Visible = True
                    rowMiscInfo.Visible = True
                    rowOrderCopy.Visible = True
                    rowMaterialNotes.Visible = True
                    rowGuaranteed.Visible = True
                    rowProjected.Visible = True
                    rowActual.Visible = True
                    rowCostPer.Visible = True
                    rowIncludeFlighting.Visible = True
                    rowIncludeLineMarket.Visible = True
                    rowInternetQtyOverrideText.Visible = True

                    EnableInternetFieldsByReportFormat(rowReportFormat.Properties.Value)

                ElseIf _OrderPrintSetting.MediaType = "M" Then

                    rowProductionSize.Visible = True
                    rowHeadline.Visible = True
                    rowIssue.Visible = True
                    rowMaterial.Visible = True
                    rowAdNumber.Visible = True
                    rowJobNumber.Visible = True
                    rowMaterialDueDate.Visible = True
                    rowSpaceCloseDate.Visible = True
                    rowInstructions.Visible = True
                    rowMiscInfo.Visible = True
                    rowOrderCopy.Visible = True
                    rowMaterialNotes.Visible = True
                    rowPositionInfo.Visible = True
                    rowCloseInfo.Visible = True
                    rowRateInfo.Visible = True

                ElseIf _OrderPrintSetting.MediaType = "N" Then

                    rowProductionSize.Visible = True
                    rowHeadline.Visible = True
                    rowEdition.Visible = True
                    rowSection.Visible = True
                    rowMaterial.Visible = True
                    rowAdNumber.Visible = True
                    rowJobNumber.Visible = True
                    rowMaterialDueDate.Visible = True
                    rowSpaceCloseDate.Visible = True
                    rowInstructions.Visible = True
                    rowMiscInfo.Visible = True
                    rowOrderCopy.Visible = True
                    rowMaterialNotes.Visible = True
                    rowPositionInfo.Visible = True
                    rowCloseInfo.Visible = True
                    rowRateInfo.Visible = True
                    rowPrintDayDate.Visible = True

                ElseIf _OrderPrintSetting.MediaType = "O" Then

                    rowType.Visible = True
                    rowHeadline.Visible = True
                    rowLocation.Visible = True
                    rowCopyArea.Visible = True
                    rowAdNumber.Visible = True
                    rowJobNumber.Visible = True
                    rowMaterialDueDate.Visible = True
                    rowSpaceCloseDate.Visible = True
                    rowInstructions.Visible = True
                    rowMiscInfo.Visible = True
                    rowOrderCopy.Visible = True
                    rowMaterialNotes.Visible = True

                ElseIf _OrderPrintSetting.MediaType = "R" Then

                    rowBroadcastShowEmptyWeeks.Visible = True
                    rowShowLineNumbers.Visible = True
                    rowProgramming.Visible = True
                    rowStartTime.Visible = True
                    rowEndTime.Visible = True
                    rowLength.Visible = True
                    rowRemarks.Visible = True
                    rowDays.Visible = True
                    rowDaypart.Visible = True
                    rowAddedValue.Visible = True
                    rowBookends.Visible = True
                    rowPrimaryRating.Visible = True
                    rowPrimaryCPP.Visible = True
                    rowPrimaryCPM.Visible = True
                    rowPrimaryAQH.Visible = True
                    rowSeparationPolicy.Visible = True

                ElseIf _OrderPrintSetting.MediaType = "T" Then

                    rowBroadcastShowEmptyWeeks.Visible = True
                    rowShowLineNumbers.Visible = True
                    rowProgramming.Visible = True
                    rowStartTime.Visible = True
                    rowEndTime.Visible = True
                    rowLength.Visible = True
                    rowRemarks.Visible = True
                    rowDays.Visible = True
                    rowDaypart.Visible = True
                    rowAddedValue.Visible = True
                    rowBookends.Visible = True
                    rowPrimaryRating.Visible = True
                    rowPrimaryCPP.Visible = True
                    rowPrimaryCPM.Visible = True
                    rowPrimaryImpressions.Visible = True
                    rowSeparationPolicy.Visible = True

                End If

                categoryQuantityRate.Visible = (rowGuaranteed.Visible OrElse rowProjected.Visible OrElse rowActual.Visible OrElse rowCostPer.Visible)

            End If

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext) Then

                    rowApplyExchangeRate.Visible = False
                    rowExchangeRate.Visible = False

                End If

            End Using

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub MediaOrderPrintingOptionsDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        End Sub
        Private Sub MediaOrderPrintingOptionsDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub MediaOrderPrintingOptionsDialog_UserEntryChangedEvent(ByVal Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim OrderPrintSetting As AdvantageFramework.Media.Classes.OrderPrintSetting = Nothing
            Dim MediaOrderPrintSetting As AdvantageFramework.Database.Entities.MediaOrderPrintSetting = Nothing
            Dim ErrorMessage As String = ""

            VerticalGridMediaOrder_Settings.CloseEditor()

            If VerticalGridMediaOrder_Settings.HasRowErrors = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If _OrderPrintSettings IsNot Nothing AndAlso _OrderPrintSettings.Count > 0 Then

                        OrderPrintSetting = _OrderPrintSettings(0)

                        If OrderPrintSetting IsNot Nothing Then

                            MediaOrderPrintSetting = DbContext.MediaOrderPrintSettings.Find(OrderPrintSetting.UserCode, OrderPrintSetting.MediaType)

                            If MediaOrderPrintSetting Is Nothing Then

                                MediaOrderPrintSetting = New AdvantageFramework.Database.Entities.MediaOrderPrintSetting

                                MediaOrderPrintSetting.UserCode = OrderPrintSetting.UserCode
                                MediaOrderPrintSetting.MediaType = OrderPrintSetting.MediaType

                                OrderPrintSetting.Save(MediaOrderPrintSetting)

                                DbContext.Entry(MediaOrderPrintSetting).State = Entity.EntityState.Added

                            Else

                                OrderPrintSetting.Save(MediaOrderPrintSetting)

                                DbContext.Entry(MediaOrderPrintSetting).State = Entity.EntityState.Modified

                            End If

                            Try

                                DbContext.SaveChanges()

                            Catch ex As Exception

                            End Try

                        End If

                    End If

                End Using

                Me.ClearChanged()

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                GetVerticalGridErrorMessage(VerticalGridMediaOrder_Settings, ErrorMessage)

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub VerticalGridMediaOrder_Settings_CellValueChanging(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles VerticalGridMediaOrder_Settings.CellValueChanging

            'objects
            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim CustomInvoice As AdvantageFramework.Reporting.Database.Entities.CustomInvoice = Nothing

            Try

                If e.Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Guaranteed.ToString Then

                    BaseRow = VerticalGridMediaOrder_Settings.Rows.GetRowByFieldName(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Projected.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                    BaseRow = VerticalGridMediaOrder_Settings.Rows.GetRowByFieldName(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Actual.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.DefaultLabelFromVendor1.ToString Then

                    BaseRow = VerticalGridMediaOrder_Settings.Rows.GetRowByFieldName(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Rep1Label.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.DefaultLabelFromVendor2.ToString Then

                    BaseRow = VerticalGridMediaOrder_Settings.Rows.GetRowByFieldName(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.Rep2Label.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.RemoveSignatureLines.ToString Then

                    BaseRow = VerticalGridMediaOrder_Settings.Rows.GetRowByFieldName(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.ExcludeEmployeeSignature.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        End If

                    End If

                    BaseRow = VerticalGridMediaOrder_Settings.Rows.GetRowByFieldName(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.PutSignatureBelowAllComments.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.ReportFormat.ToString Then

                    If _OrderPrintSetting.MediaType = "I" Then

                        EnableInternetFieldsByReportFormat(e.Value)

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.ApplyExchangeRate.ToString Then

                    BaseRow = VerticalGridMediaOrder_Settings.Rows.GetRowByFieldName(AdvantageFramework.Media.Classes.OrderPrintSetting.Properties.ExchangeRate.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 1

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace