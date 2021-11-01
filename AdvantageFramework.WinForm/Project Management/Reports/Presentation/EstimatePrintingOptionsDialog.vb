Namespace ProjectManagement.Reports.Presentation

    Public Class EstimatePrintingOptionsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EstimatePrintingDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
        Private _EstimatePrintingSetting As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
        Private _EstimatePrintingSettingClass As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
        Private _EstimatePrintingSettings As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting) = Nothing
        Private _CustomInvoiceSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.CustomInvoiceSetting) = Nothing
        Private _EstimateFormatType As AdvantageFramework.Estimate.Printing.EstimateFormatTypes = Nothing
        Private _ShowEstimateOptions As Boolean = False
        Private _ClientLevel As String = ""
        Private _ClientCodes As Generic.List(Of String) = Nothing
        Private _ProductCodes As Generic.List(Of String) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(EstimateFormatType As AdvantageFramework.Estimate.Printing.EstimateFormatTypes, EstimatePrintingSetting As AdvantageFramework.Database.Entities.EstimatePrintingSetting, ClientCodes As Generic.List(Of String), ProductCodes As Generic.List(Of String), ShowEstimateOptions As Boolean, ClientLevel As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ClientCodes = ClientCodes
            _ProductCodes = ProductCodes
            _EstimatePrintingSetting = EstimatePrintingSetting
            _ShowEstimateOptions = ShowEstimateOptions
            _ClientLevel = ClientLevel
            _EstimateFormatType = EstimateFormatType
            '_ClientCodes = ClientCodes

        End Sub
        Private Sub New(EstimateFormatType As AdvantageFramework.Estimate.Printing.EstimateFormatTypes, EstimatePrintingSettingClass As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting, ClientCodes As Generic.List(Of String), ProductCodes As Generic.List(Of String), ShowEstimateOptions As Boolean, ClientLevel As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ClientCodes = ClientCodes
            _ProductCodes = ProductCodes
            _ClientLevel = ClientLevel
            _ShowEstimateOptions = ShowEstimateOptions
            _EstimatePrintingSettingClass = EstimatePrintingSettingClass
            _EstimateFormatType = EstimateFormatType
            '_ClientCodes = ClientCodes

        End Sub

        Private Sub LoadProductionOptions()

            _EstimatePrintingSettings = New Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting)

            If _EstimatePrintingDefault IsNot Nothing Then

                _EstimatePrintingSettings.Add(New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting(_EstimatePrintingDefault))

            ElseIf _EstimatePrintingSettingClass IsNot Nothing Then

                _EstimatePrintingSettings.Add(New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting(_EstimatePrintingSettingClass))

            Else

                _EstimatePrintingSettings.Add(New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting())

            End If

            'If _EstimateFormatType = AdvantageFramework.Estimate.Printing.EstimateFormatTypes.Standard OrElse _
            '       _EstimateFormatType = AdvantageFramework.Estimate.Printing.EstimateFormatTypes.ClientDefault OrElse _
            '       _EstimateFormatType = AdvantageFramework.Estimate.Printing.EstimateFormatTypes.ProductDefault OrElse _
            '       _EstimateFormatType = AdvantageFramework.Estimate.Printing.EstimateFormatTypes.UserDefault Then

            '    _EstimatePrintingSettings = New Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting)

            '    If _EstimatePrintingDefault IsNot Nothing Then

            '        _EstimatePrintingSettings.Add(New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting(_EstimatePrintingDefault))

            '    ElseIf _EstimatePrintingSettingClass IsNot Nothing Then

            '        _EstimatePrintingSettings.Add(New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting(_EstimatePrintingSettingClass))

            '    Else

            '        _EstimatePrintingSettings.Add(New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting())

            '    End If

            'End If

        End Sub

        Private Sub LoadProductionTab()
            Try
            'objects
                Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim Row As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing
                Dim CategoryRow As DevExpress.XtraVerticalGrid.Rows.CategoryRow = Nothing
                Dim CustomEstimate As AdvantageFramework.Reporting.Database.Entities.EstimateReport = Nothing

            If _EstimatePrintingSettings IsNot Nothing AndAlso _EstimatePrintingSettings.Count > 0 Then

                EstimatePrintingSetting = _EstimatePrintingSettings(0)

                If EstimatePrintingSetting IsNot Nothing Then

                        For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                            EntityAttribute = Nothing
                            Row = Nothing

                            Row = GetRowAndInitialize(VerticalGridProduction_Settings, PropertyDescriptor, EntityAttribute)

                            If Row IsNot Nothing Then



                                If Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.LocationCode.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.Location, _
                                                                                                                                  AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.LocationCode.ToString, EntityAttribute, PropertyDescriptor, Nothing, True)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = EstimatePrintingSetting.UseLocationOptions

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.CDPAddressOption.ToString Then 'Address

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable, _
                                                                                                                                  AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.CDPAddressOption.ToString, EntityAttribute, PropertyDescriptor, _
                                                                                                                                  GetType(AdvantageFramework.Estimate.Printing.AddressBlockTypes), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.ReportFormat.ToString Then 'Format

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject, _
                                                                                                                                  AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.ReportFormat.ToString, EntityAttribute, PropertyDescriptor, _
                                                                                                                                  GetType(AdvantageFramework.Estimate.Printing.ReportFormats), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.GroupingOptionFunctionOption.ToString Then 'Function

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable, _
                                                                                                                                  AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.GroupingOptionFunctionOption.ToString, EntityAttribute, PropertyDescriptor, _
                                                                                                                                  GetType(AdvantageFramework.Estimate.Printing.FunctionOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.GroupingOptionGroupOption.ToString Then 'Group

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject, _
                                                                                                                              AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.GroupingOptionGroupOption.ToString, EntityAttribute, PropertyDescriptor, _
                                                                                                                              GetType(AdvantageFramework.Estimate.Printing.GroupOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.GroupingOptionSortOption.ToString Then 'Sort

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable, _
                                                                                                                                  AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.GroupingOptionSortOption.ToString, EntityAttribute, PropertyDescriptor, _
                                                                                                                                  GetType(AdvantageFramework.Estimate.Printing.SortOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.SummaryLevel.ToString Then 'Summary Level

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable, _
                                                                                                                                  AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.SummaryLevel.ToString, EntityAttribute, PropertyDescriptor, _
                                                                                                                                  GetType(AdvantageFramework.Estimate.Printing.SummaryOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.Signature.ToString Then 'Signature

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject, _
                                                                                                                                  AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.Signature.ToString, EntityAttribute, PropertyDescriptor, _
                                                                                                                                  GetType(AdvantageFramework.Estimate.Printing.Signatures), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.ContactType.ToString Then 'Contact Type

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable, _
                                                                                                                                  AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.ContactType.ToString, EntityAttribute, PropertyDescriptor, _
                                                                                                                                  GetType(AdvantageFramework.Estimate.Printing.ContactType), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.DateToPrint.ToString Then 'Date

                                    If EstimatePrintingSetting.DateToPrint = 0 Then

                                        Row.Properties.Value = Date.Now.ToShortDateString

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.CustomEstimateID.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EstimateCustomID, _
                                                                                                                                  AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.CustomEstimateID.ToString, _
                                                                                                                                  EntityAttribute, PropertyDescriptor, Nothing, True)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = WinForm.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                Else

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateDefaultSubItem(Me.Session, Row.Properties.FieldName, PropertyDescriptor.PropertyType, Row.Properties.Format.FormatString, GetType(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting))

                                End If

                                If Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.ReportTitle.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox).MaxLength = 30

                                ElseIf (Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.GroupingOptionInsideDescription.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.GroupingOptionOutsideDescription.ToString) AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = If(EstimatePrintingSetting.GroupingOptionGroupOption = AdvantageFramework.Estimate.Printing.GroupOptions.InsideOutside.ToString, True, False)
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox).MaxLength = 50

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.TotalsShowContingencySeparately.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = If(EstimatePrintingSetting.TotalsIncludeContingency = True, True, False)

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.PrintQuantityTotals.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = If(EstimatePrintingSetting.IncludeQuantityHours = True, True, False)

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.DatePrint.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then 'Date

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = If(EstimatePrintingSetting.DateToPrint = False, True, False)

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeRate.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    If EstimatePrintingSetting.GroupingOptionFunctionOption = "2" Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                                    ElseIf EstimatePrintingSetting.GroupingOptionFunctionOption = "1" AndAlso EstimatePrintingSetting.ConsolidationOverride = False Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                                    ElseIf EstimatePrintingSetting.ReportFormat = "2" Or
                                           EstimatePrintingSetting.ReportFormat = "3" Or
                                           EstimatePrintingSetting.ReportFormat = "4" Or
                                           EstimatePrintingSetting.ReportFormat = "5" Or
                                           EstimatePrintingSetting.ReportFormat = "6" Or
                                           EstimatePrintingSetting.ReportFormat = "7" Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                                    Else

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeRateMarkup.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    If EstimatePrintingSetting.GroupingOptionFunctionOption = "2" Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                                    ElseIf EstimatePrintingSetting.GroupingOptionFunctionOption = "1" AndAlso EstimatePrintingSetting.ConsolidationOverride = False Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                                    ElseIf EstimatePrintingSetting.ReportFormat = "2" Or
                                           EstimatePrintingSetting.ReportFormat = "3" Or
                                           EstimatePrintingSetting.ReportFormat = "4" Or
                                           EstimatePrintingSetting.ReportFormat = "5" Or
                                           EstimatePrintingSetting.ReportFormat = "6" Or
                                           EstimatePrintingSetting.ReportFormat = "7" Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                                    Else

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeQuantityHours.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    If EstimatePrintingSetting.ReportFormat = "2" Or
                                           EstimatePrintingSetting.ReportFormat = "3" Or
                                           EstimatePrintingSetting.ReportFormat = "4" Or
                                           EstimatePrintingSetting.ReportFormat = "5" Or
                                           EstimatePrintingSetting.ReportFormat = "6" Or
                                           EstimatePrintingSetting.ReportFormat = "7" Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                                    Else

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.PrintQuantityTotals.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    If EstimatePrintingSetting.ReportFormat = "2" Or
                                           EstimatePrintingSetting.ReportFormat = "3" Or
                                           EstimatePrintingSetting.ReportFormat = "4" Or
                                           EstimatePrintingSetting.ReportFormat = "5" Or
                                           EstimatePrintingSetting.ReportFormat = "6" Or
                                           EstimatePrintingSetting.ReportFormat = "7" Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                                    Else

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeNonBillable.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    If EstimatePrintingSetting.ReportFormat = "2" Or _
                                           EstimatePrintingSetting.ReportFormat = "5" Or _
                                           EstimatePrintingSetting.ReportFormat = "6" Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                                    Else

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.HideRevision.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    If EstimatePrintingSetting.ReportFormat = "2" Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                                    Else

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeEstimateQuoteComment.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    If EstimatePrintingSetting.ReportFormat = "2" Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                                    Else

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeEstimateFunctionComment.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    If EstimatePrintingSetting.ReportFormat = "2" Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                                    Else

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeSuppliedByNotes.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    If EstimatePrintingSetting.ReportFormat = "2" Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                                    Else

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeEstimateRevisionComment.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    If EstimatePrintingSetting.ReportFormat = "2" Or _
                                        EstimatePrintingSetting.ReportFormat = "3" Or _
                                           EstimatePrintingSetting.ReportFormat = "4" Or _
                                           EstimatePrintingSetting.ReportFormat = "5" Or _
                                           EstimatePrintingSetting.ReportFormat = "6" Or _
                                           EstimatePrintingSetting.ReportFormat = "7" Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                                    Else

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.PrintAdNumber.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    If EstimatePrintingSetting.ReportFormat = "3" Or _
                                           EstimatePrintingSetting.ReportFormat = "4" Or _
                                           EstimatePrintingSetting.ReportFormat = "5" Or _
                                           EstimatePrintingSetting.ReportFormat = "6" Or _
                                           EstimatePrintingSetting.ReportFormat = "7" Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                                    Else

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.ReportFormat.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    If EstimatePrintingSetting.CustomEstimateID > 0 Then

                                        Try

                                            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                                CustomEstimate = AdvantageFramework.Reporting.Database.Procedures.EstimateReport.LoadByEstimateReportID(ReportingDbContext, EstimatePrintingSetting.CustomEstimateID)

                                                If CustomEstimate IsNot Nothing Then

                                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = CShort(CustomEstimate.EstimateReportType)

                                                End If

                                            End Using

                                        Catch ex As Exception
                                            CustomEstimate = Nothing
                                        End Try

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                                    Else

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                                    End If

                                    If EstimatePrintingSetting.ReportFormat = "2" Or
                                       EstimatePrintingSetting.ReportFormat = "3" Or
                                       EstimatePrintingSetting.ReportFormat = "4" Or
                                       EstimatePrintingSetting.ReportFormat = "5" Or
                                       EstimatePrintingSetting.ReportFormat = "6" Or
                                       EstimatePrintingSetting.ReportFormat = "7" Then



                                    Else



                                    End If

                                End If

                                VerticalGridProduction_Settings.RepositoryItems.Add(RepositoryItem)

                                Row.Properties.RowEdit = RepositoryItem

                            End If

                        Next

                    End If

                End If

                VerticalGridProduction_Settings.DataSource = _EstimatePrintingSettings

                VerticalGridProduction_Settings.ExpandAllRows()

                VerticalGridProduction_Settings.BestFit()


            Catch ex As Exception

            End Try
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
        Private Function LoadEstimatePrintingSettings(DataContext As AdvantageFramework.Database.DataContext, SaveToAgency As Boolean, SaveToClients As Boolean, SaveToProducts As Boolean, SaveToUser As Boolean) As Generic.List(Of AdvantageFramework.Database.Entities.EstimatePrintingSetting)

            'objects
            Dim EstimatePrintingSettings As Generic.List(Of AdvantageFramework.Database.Entities.EstimatePrintingSetting) = Nothing

            Try

                If _EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then

                    If SaveToAgency AndAlso SaveToClients AndAlso SaveToProducts AndAlso SaveToUser Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients AndAlso SaveToProducts AndAlso SaveToUser Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToAgency AndAlso SaveToClients = False AndAlso SaveToProducts AndAlso SaveToUser Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients = False AndAlso SaveToProducts AndAlso SaveToUser Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToAgency AndAlso SaveToClients AndAlso SaveToProducts = False AndAlso SaveToUser Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients AndAlso SaveToProducts = False AndAlso SaveToUser Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToAgency AndAlso SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToUser Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToUser Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToAgency AndAlso SaveToClients AndAlso SaveToProducts AndAlso SaveToUser = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients AndAlso SaveToProducts AndAlso SaveToUser = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3).ToList

                    ElseIf SaveToAgency AndAlso SaveToClients = False AndAlso SaveToProducts AndAlso SaveToUser = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 3).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients = False AndAlso SaveToProducts AndAlso SaveToUser = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 3).ToList

                    ElseIf SaveToAgency AndAlso SaveToClients AndAlso SaveToProducts = False AndAlso SaveToUser = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients AndAlso SaveToProducts = False AndAlso SaveToUser = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToAgency AndAlso SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToUser = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToUser = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0).ToList

                    End If

                ElseIf _EstimateFormatType = Estimate.Printing.EstimateFormatTypes.Agency Then

                    If SaveToClients AndAlso SaveToProducts AndAlso SaveToUser Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToClients = False AndAlso SaveToProducts AndAlso SaveToUser Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToClients AndAlso SaveToProducts = False AndAlso SaveToUser Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToClients AndAlso SaveToProducts AndAlso SaveToUser = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3).ToList

                    ElseIf SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToUser Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToClients = False AndAlso SaveToProducts AndAlso SaveToUser = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 3).ToList

                    ElseIf SaveToClients AndAlso SaveToProducts = False AndAlso SaveToUser = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToUser = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1).ToList

                    End If

                ElseIf _EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then

                    If SaveToClients AndAlso SaveToProducts AndAlso SaveToAgency Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToClients = False AndAlso SaveToProducts AndAlso SaveToAgency Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToClients AndAlso SaveToProducts = False AndAlso SaveToAgency Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToClients AndAlso SaveToProducts AndAlso SaveToAgency = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToAgency Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToClients = False AndAlso SaveToProducts AndAlso SaveToAgency = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToClients AndAlso SaveToProducts = False AndAlso SaveToAgency = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToAgency = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 4).ToList

                    End If

                ElseIf _EstimateFormatType = Estimate.Printing.EstimateFormatTypes.OneTime Then

                    If SaveToAgency AndAlso SaveToClients AndAlso SaveToProducts AndAlso SaveToUser Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients AndAlso SaveToProducts AndAlso SaveToUser Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToAgency AndAlso SaveToClients = False AndAlso SaveToProducts AndAlso SaveToUser Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients = False AndAlso SaveToProducts AndAlso SaveToUser Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 3 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToAgency AndAlso SaveToClients AndAlso SaveToProducts = False AndAlso SaveToUser Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients AndAlso SaveToProducts = False AndAlso SaveToUser Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToAgency AndAlso SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToUser Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToUser Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 4).ToList

                    ElseIf SaveToAgency AndAlso SaveToClients AndAlso SaveToProducts AndAlso SaveToUser = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients AndAlso SaveToProducts AndAlso SaveToUser = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 2 OrElse Entity.ClientOrDefault = 3).ToList

                    ElseIf SaveToAgency AndAlso SaveToClients = False AndAlso SaveToProducts AndAlso SaveToUser = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 3).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients = False AndAlso SaveToProducts AndAlso SaveToUser = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 3).ToList

                    ElseIf SaveToAgency AndAlso SaveToClients AndAlso SaveToProducts = False AndAlso SaveToUser = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients AndAlso SaveToProducts = False AndAlso SaveToUser = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToAgency AndAlso SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToUser = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients = False AndAlso SaveToProducts = False AndAlso SaveToUser = False Then

                        EstimatePrintingSettings = DataContext.EstimatePrintingSetting.Where(Function(Entity) Entity.ClientOrDefault = 0).ToList

                    End If

                End If



            Catch ex As Exception
                EstimatePrintingSettings = New Generic.List(Of AdvantageFramework.Database.Entities.EstimatePrintingSetting)
            End Try

            If SaveToClients Then

                For Each EstimatePrintingSetting In EstimatePrintingSettings.Where(Function(Entity) Entity.ClientOrDefault = 2).ToList

                    If _ClientCodes IsNot Nothing AndAlso _ClientCodes.Contains(EstimatePrintingSetting.ClientCode) = False Then

                        EstimatePrintingSettings.Remove(EstimatePrintingSetting)

                    End If

                Next

            End If

            If SaveToClients Then

                For Each ClientCode In _ClientCodes

                    If EstimatePrintingSettings.Any(Function(Entity) Entity.ClientOrDefault = 2 AndAlso Entity.ClientCode = ClientCode) = False Then

                        EstimatePrintingSettings.Add(New AdvantageFramework.Database.Entities.EstimatePrintingSetting() With {.ClientOrDefault = 2,
                                                                                                                                .ClientCode = ClientCode})

                    End If

                Next

            End If

            If SaveToProducts Then

                For Each EstimatePrintingSetting In EstimatePrintingSettings.Where(Function(Entity) Entity.ClientOrDefault = 3).ToList

                    If _ProductCodes IsNot Nothing AndAlso _ProductCodes.Contains(EstimatePrintingSetting.ClientCode & "|" & EstimatePrintingSetting.DivisionCode & "|" & EstimatePrintingSetting.ProductCode) = False Then

                        EstimatePrintingSettings.Remove(EstimatePrintingSetting)

                    End If

                Next

            End If

            If SaveToProducts Then

                For Each ProductCode In _ProductCodes

                    Dim cdp() As String = ProductCode.Split("|")

                    If EstimatePrintingSettings.Any(Function(Entity) Entity.ClientOrDefault = 3 AndAlso Entity.ClientCode & "|" & Entity.DivisionCode & "|" & Entity.ProductCode = ProductCode) = False Then

                        EstimatePrintingSettings.Add(New AdvantageFramework.Database.Entities.EstimatePrintingSetting() With {.ClientOrDefault = 3,
                                                                                                                                .ClientCode = cdp(0),
                                                                                                                                .DivisionCode = cdp(1),
                                                                                                                                .ProductCode = cdp(2)})

                    End If

                Next

            End If

            If SaveToUser Then

                For Each EstimatePrintingSetting In EstimatePrintingSettings.Where(Function(Entity) Entity.ClientOrDefault = 4).ToList

                    If Session.UserCode <> EstimatePrintingSetting.UserID Then

                        EstimatePrintingSettings.Remove(EstimatePrintingSetting)

                    End If

                Next

            End If

            If SaveToUser Then

                If EstimatePrintingSettings.Any(Function(Entity) Entity.ClientOrDefault = 4 AndAlso Entity.UserID = Session.UserCode) = False Then

                    EstimatePrintingSettings.Add(New AdvantageFramework.Database.Entities.EstimatePrintingSetting() With {.ClientOrDefault = 4,
                                                                                                                            .UserID = Session.UserCode})

                End If

            End If

            LoadEstimatePrintingSettings = EstimatePrintingSettings

        End Function
        Private Sub SaveEstimateDefaults(SaveToAgency As Boolean, SaveToClients As Boolean, SaveToProducts As Boolean, SaveToUser As Boolean)

            'objects
            Dim EstimatePrintDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _EstimatePrintingSettings IsNot Nothing AndAlso _EstimatePrintingSettings.Count > 0 Then

                    EstimatePrintingSetting = _EstimatePrintingSettings(0)

                    If EstimatePrintingSetting IsNot Nothing Then

                        For Each EstimatePrintDefault In LoadEstimatePrintingSettings(DataContext, SaveToAgency, SaveToClients, SaveToProducts, SaveToUser)

                            EstimatePrintingSetting.Save(EstimatePrintDefault)

                        Next

                        If _EstimatePrintingSetting IsNot Nothing Then

                            EstimatePrintingSetting.Save(_EstimatePrintingSetting)

                        End If

                    End If

                End If

                Try

                    AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Update(DataContext, EstimatePrintDefault)

                Catch ex As Exception

                End Try

            End Using

        End Sub
        Private Sub SaveEstimatePrintingSettings(SaveToAgency As Boolean, SaveToClients As Boolean, SaveToProducts As Boolean, SaveToUser As Boolean)

            'objects
            Dim EstimatePrintDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _EstimatePrintingSettings IsNot Nothing AndAlso _EstimatePrintingSettings.Count > 0 Then

                    EstimatePrintingSetting = _EstimatePrintingSettings(0)

                    If EstimatePrintingSetting IsNot Nothing Then

                        For Each EstimatePrintDefault In LoadEstimatePrintingSettings(DataContext, SaveToAgency, SaveToClients, SaveToProducts, SaveToUser)

                            EstimatePrintingSetting.Save(EstimatePrintDefault)

                        Next

                        EstimatePrintingSetting.Save(EstimatePrintDefault)

                    End If

                End If

                Try

                    AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Update(DataContext, EstimatePrintDefault)

                Catch ex As Exception

                End Try

            End Using

        End Sub

        Private Sub AddFormatHeaderToPrintout(ByRef CompositeLink As DevExpress.XtraPrintingLinks.CompositeLink, HeaderText As String)

            'objects
            Dim HeaderLink As AdvantageFramework.Reporting.Reports.CustomLink = Nothing

            HeaderLink = New AdvantageFramework.Reporting.Reports.CustomLink

            HeaderLink.Tag = HeaderText

            AddHandler HeaderLink.CreateDetailArea, AddressOf HeaderLink_CreateDetailArea

            CompositeLink.Links.Add(HeaderLink)

        End Sub
        Private Sub AddVerticalGridToPrintout(ByRef CompositeLink As DevExpress.XtraPrintingLinks.CompositeLink, VerticalGrid As DevExpress.XtraVerticalGrid.VGridControl, HeaderText As String)

            'objects
            Dim HeaderLink As AdvantageFramework.Reporting.Reports.CustomLink = Nothing
            Dim PrintableComponentLink As DevExpress.XtraPrinting.PrintableComponentLink = Nothing

            HeaderLink = New AdvantageFramework.Reporting.Reports.CustomLink

            HeaderLink.Tag = HeaderText

            AddHandler HeaderLink.CreateDetailArea, AddressOf HeaderLink_CreateDetailArea

            CompositeLink.Links.Add(HeaderLink)

            PrintableComponentLink = New DevExpress.XtraPrinting.PrintableComponentLink(CompositeLink.PrintingSystem)

            PrintableComponentLink.Component = VerticalGrid

            CompositeLink.Links.Add(PrintableComponentLink)

        End Sub
        Private Sub HeaderLink_CreateDetailArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs)

            'objects
            Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing

            Try

                TextBrick = CreateTextBrick(0, 0, e.Graph.ClientPageSize.Width, 15)

                TextBrick.Text = CType(sender, AdvantageFramework.Reporting.Reports.CustomLink).Tag

                e.Graph.DrawBrick(TextBrick)

            Catch ex As Exception

            End Try

        End Sub
        Private Function CreateTextBrick(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer) As DevExpress.XtraPrinting.TextBrick

            'objects
            Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing

            TextBrick = New DevExpress.XtraPrinting.TextBrick

            TextBrick.Rect = New System.Drawing.Rectangle(X, Y, Width, Height)
            TextBrick.BackColor = System.Drawing.Color.White
            TextBrick.BorderWidth = 0
            TextBrick.BorderStyle = DevExpress.XtraPrinting.BrickBorderStyle.Inset
            TextBrick.Font = New System.Drawing.Font("Tahoma", TextBrick.Font.Size)

            CreateTextBrick = TextBrick

        End Function


#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(EstimateFormatType As AdvantageFramework.Estimate.Printing.EstimateFormatTypes, EstimateDefaultPrintingSetting As AdvantageFramework.Database.Entities.EstimatePrintingSetting, ClientCodes As Generic.List(Of String), ProductCodes As Generic.List(Of String), ShowEstimateOptions As Boolean, ClientLevel As String) As System.Windows.Forms.DialogResult

            'objects
            Dim EstimatePrintingOptionsDialog As EstimatePrintingOptionsDialog = Nothing

            EstimatePrintingOptionsDialog = New EstimatePrintingOptionsDialog(EstimateFormatType, EstimateDefaultPrintingSetting, ClientCodes, ProductCodes, ShowEstimateOptions, ClientLevel)

            ShowFormDialog = EstimatePrintingOptionsDialog.ShowDialog()

        End Function
        Public Shared Function ShowFormDialog(EstimateFormatType As AdvantageFramework.Estimate.Printing.EstimateFormatTypes, EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting, ClientCodes As Generic.List(Of String), ProductCodes As Generic.List(Of String), ShowEstimateOptions As Boolean, ClientLevel As String) As System.Windows.Forms.DialogResult

            'objects
            Dim EstimatePrintingOptionsDialog As EstimatePrintingOptionsDialog = Nothing

            EstimatePrintingOptionsDialog = New EstimatePrintingOptionsDialog(EstimateFormatType, EstimatePrintingSetting, ClientCodes, ProductCodes, ShowEstimateOptions, ClientLevel)

            ShowFormDialog = EstimatePrintingOptionsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EstimatePrintingOptionsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemSaveOptions_Agency.Image = AdvantageFramework.My.Resources.AgencyImage
            ButtonItemSaveOptions_Clients.Image = AdvantageFramework.My.Resources.ClientImage
            ButtonItemSaveOptions_Products.Image = AdvantageFramework.My.Resources.ProductImage
            ButtonItem_User.Image = AdvantageFramework.My.Resources.UserImage

            VerticalGridProduction_Settings.OptionsBehavior.Editable = True
            VerticalGridProduction_Settings.OptionsView.ShowRootCategories = True
            VerticalGridProduction_Settings.OptionsBehavior.UseDefaultEditorsCollection = True

            TabItem_Estimate.Visible = _ShowEstimateOptions

            If TabItem_Estimate.Visible Then

                TabControlForm_Options.SelectedTab = TabItem_Estimate

            Else

                'TabControlForm_Options.SelectedTab = TabItemOptions_MediaTab

            End If

            If _EstimateFormatType = Estimate.Printing.EstimateFormatTypes.ClientDefault Then

                If _ClientCodes IsNot Nothing AndAlso _ClientCodes.Count = 1 AndAlso _ClientLevel = "Client" Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _ClientCodes(0))

                    End Using

                    If Client IsNot Nothing Then

                        LabelForm_Format.Text = "Client - " & Client.Name & " Standard Format"

                    Else

                        LabelForm_Format.Text = "Client - " & _ClientCodes(0) & " Standard Format"

                    End If

                    ButtonItemSaveOptions_Clients.Checked = True
                    ButtonItemSaveOptions_Clients.Visible = False

                ElseIf _ProductCodes IsNot Nothing AndAlso _ProductCodes.Count = 1 AndAlso _ClientLevel = "Product" Then

                    Dim cdp() As String = _ProductCodes(0).Split("|")

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, cdp(0), cdp(1), cdp(2))

                    End Using

                    If Product IsNot Nothing Then

                        LabelForm_Format.Text = "Product - " & Product.Name & " Standard Format"

                    Else

                        LabelForm_Format.Text = "Product - " & Product.Code & " Standard Format"

                    End If

                    ButtonItemSaveOptions_Products.Checked = True
                    ButtonItemSaveOptions_Products.Visible = False

                Else

                    LabelForm_Format.Text = "Agency Standard Format"

                End If

                ButtonItem_User.Visible = True

            ElseIf _EstimateFormatType = Estimate.Printing.EstimateFormatTypes.UserDefault Then

                LabelForm_Format.Text = "User Standard Format"

                ButtonItem_User.Checked = True
                ButtonItem_User.Visible = False
                If _ClientCodes IsNot Nothing AndAlso _ClientCodes.Count = 1 Then
                    ButtonItemSaveOptions_Clients.Visible = True
                Else
                    ButtonItemSaveOptions_Clients.Visible = False
                End If
                If _ProductCodes IsNot Nothing AndAlso _ProductCodes.Count = 1 Then
                    ButtonItemSaveOptions_Products.Visible = True
                Else
                    ButtonItemSaveOptions_Products.Visible = False
                End If

            ElseIf _EstimateFormatType = Estimate.Printing.EstimateFormatTypes.Agency Then

                LabelForm_Format.Text = "Agency Standard Format"

                If _ClientCodes IsNot Nothing AndAlso _ClientCodes.Count = 1 Then
                    ButtonItemSaveOptions_Clients.Visible = True
                Else
                    ButtonItemSaveOptions_Clients.Visible = False
                End If
                If _ProductCodes IsNot Nothing AndAlso _ProductCodes.Count = 1 Then
                    ButtonItemSaveOptions_Products.Visible = True
                Else
                    ButtonItemSaveOptions_Products.Visible = False
                End If
                ButtonItem_User.Visible = True

                ButtonItemSaveOptions_Agency.Checked = True
                ButtonItemSaveOptions_Agency.Visible = False

            ElseIf _EstimateFormatType = Estimate.Printing.EstimateFormatTypes.OneTime Then

                LabelForm_Format.Text = "One-Time Format"

                If _ClientCodes IsNot Nothing AndAlso _ClientCodes.Count = 1 Then
                    ButtonItemSaveOptions_Clients.Visible = True
                Else
                    ButtonItemSaveOptions_Clients.Visible = False
                End If
                If _ProductCodes IsNot Nothing AndAlso _ProductCodes.Count = 1 Then
                    ButtonItemSaveOptions_Products.Visible = True
                Else
                    ButtonItemSaveOptions_Products.Visible = False
                End If
                ButtonItem_User.Visible = True

                ButtonItemSaveOptions_Agency.Visible = True

            End If

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadProductionOptions()

            Catch ex As Exception

            End Try


            Try

                LoadProductionTab()

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub EstimatePrintingOptionsDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub EstimatePrintingOptionsDialog_UserEntryChangedEvent(ByVal Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim EstimatePrintDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim EstimatePrintDefaultNew As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim EstimatePrintingSettings As Generic.List(Of AdvantageFramework.Database.Entities.EstimatePrintingSetting) = Nothing
            Dim ErrorMessage As String = ""
            Dim RowErrorMessage As String = ""

            VerticalGridProduction_Settings.CloseEditor()

            If VerticalGridProduction_Settings.HasRowErrors = False Then

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    EstimatePrintingSettings = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Load(DataContext).ToList

                    If _EstimatePrintingSettings IsNot Nothing AndAlso _EstimatePrintingSettings.Count > 0 Then

                        EstimatePrintingSetting = _EstimatePrintingSettings(0)

                        If EstimatePrintingSetting IsNot Nothing Then

                            If EstimatePrintingSetting.LocationCode Is Nothing Then
                                EstimatePrintingSetting.LocationCode = ""
                                EstimatePrintingSetting.LogoPath = ""
                            End If

                            For Each EstimatePrintDefault In LoadEstimatePrintingSettings(DataContext, ButtonItemSaveOptions_Agency.Checked, ButtonItemSaveOptions_Clients.Checked, ButtonItemSaveOptions_Products.Checked, ButtonItem_User.Checked)

                                ' DataContext.UpdateObject(EstimatePrintDefault)
                                If EstimatePrintDefault.ID = 0 Then
                                    EstimatePrintingSetting.Update(EstimatePrintDefault, EstimatePrintingSetting)
                                    AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Insert(DataContext, EstimatePrintDefault)
                                Else
                                    EstimatePrintingSetting.Update(EstimatePrintDefault, EstimatePrintingSetting)
                                End If

                                EstimatePrintingSetting.Save(EstimatePrintDefault)

                            Next

                            If _EstimatePrintingDefault IsNot Nothing Then

                                EstimatePrintingSetting.Save(_EstimatePrintingDefault)

                            ElseIf _EstimatePrintingSettingClass IsNot Nothing Then

                                EstimatePrintingSetting.Save(_EstimatePrintingSettingClass)

                            ElseIf EstimatePrintingSettings.Count = 0 Then

                                _EstimatePrintingDefault = New AdvantageFramework.Database.Entities.EstimatePrintingSetting()
                                EstimatePrintingSetting.Update(_EstimatePrintingDefault, EstimatePrintingSetting)
                                _EstimatePrintingDefault.ClientOrDefault = 0
                                AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Insert(DataContext, _EstimatePrintingDefault)
                                _EstimatePrintingDefault = New AdvantageFramework.Database.Entities.EstimatePrintingSetting()
                                EstimatePrintingSetting.Update(_EstimatePrintingDefault, EstimatePrintingSetting)
                                _EstimatePrintingDefault.ClientOrDefault = 1
                                AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Insert(DataContext, _EstimatePrintingDefault)

                            End If

                        End If

                    End If

                    Try

                        '_EstimatePrintingSettingClass.DatePrint = EstimatePrintingSetting.DatePrint
                        AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Update(DataContext, EstimatePrintDefault)

                    Catch ex As Exception

                    End Try

                End Using

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each Row In VerticalGridProduction_Settings.Rows.OfType(Of DevExpress.XtraVerticalGrid.Rows.BaseRow).ToList

                    RowErrorMessage = VerticalGridProduction_Settings.GetRowError(Row.Properties)

                    If String.IsNullOrEmpty(RowErrorMessage) = False Then

                        If ErrorMessage = "" Then

                            ErrorMessage = RowErrorMessage

                        Else

                            ErrorMessage &= vbNewLine & RowErrorMessage

                        End If

                    End If

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

        Private Sub VerticalGridProduction_Settings_CellValueChanging(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles VerticalGridProduction_Settings.CellValueChanging
            'objects
            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim BaseRow2 As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim BaseRow3 As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim BaseRow4 As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim BaseRow5 As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim BaseRow6 As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim BaseRow7 As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim BaseRow8 As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim BaseRow9 As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim BaseRow10 As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim BaseRow11 As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim BaseRow12 As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim BaseRow13 As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim BaseRow14 As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim EstimateReport As AdvantageFramework.Reporting.Database.Entities.EstimateReport = Nothing

            _UserEntryChanged = True

            Me.RaiseUserEntryChangedEvent(Nothing)

            Try

                If e.Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.UseLocationOptions.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.LocationCode.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = Nothing

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.GroupingOptionGroupOption.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.GroupingOptionInsideDescription.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = AdvantageFramework.Estimate.Printing.GroupOptions.InsideOutside Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.GroupingOptionOutsideDescription.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = AdvantageFramework.Estimate.Printing.GroupOptions.InsideOutside Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.GroupingOptionFunctionOption.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeRate.ToString, True)
                    BaseRow2 = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.ConsolidationOverride.ToString, True)
                    BaseRow3 = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeRateMarkup.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = AdvantageFramework.Estimate.Printing.FunctionOptions.ConsolidationCode Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        ElseIf e.Value = AdvantageFramework.Estimate.Printing.FunctionOptions.FunctionCode And BaseRow2.Properties.Value = 0 Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        End If

                    End If

                    If BaseRow3 IsNot Nothing AndAlso TypeOf BaseRow3 Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = AdvantageFramework.Estimate.Printing.FunctionOptions.ConsolidationCode Then

                            CType(BaseRow3, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow3, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        ElseIf e.Value = AdvantageFramework.Estimate.Printing.FunctionOptions.FunctionCode And BaseRow2.Properties.Value = 0 Then

                            CType(BaseRow3, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow3, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        Else

                            CType(BaseRow3, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow3, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.TotalsIncludeContingency.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.TotalsShowContingencySeparately.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = Nothing

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeQuantityHours.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.PrintQuantityTotals.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = Nothing

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.DisplayQuantity.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.DisplayHours.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = Nothing

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.DisplayHours.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.DisplayQuantity.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = Nothing

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeRate.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeRateMarkup.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = Nothing

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeRateMarkup.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeRate.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = Nothing

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.DateToPrint.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.DatePrint.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = Nothing

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.ConsolidationOverride.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.GroupingOptionFunctionOption.ToString, True)
                    BaseRow2 = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeRate.ToString, True)
                    BaseRow3 = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeRateMarkup.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = False AndAlso CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 1 Then

                            CType(BaseRow2, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow3, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow2, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0
                            CType(BaseRow3, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        Else

                            CType(BaseRow2, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow3, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.CustomEstimateID.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.ReportFormat.ToString, True)
                    'BaseRow2 = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.PrintQuantityTotals.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If IsNumeric(e.Value) AndAlso CInt(e.Value) > 0 Then

                            Try

                                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                    EstimateReport = AdvantageFramework.Reporting.Database.Procedures.EstimateReport.LoadByEstimateReportID(ReportingDbContext, CInt(e.Value))

                                End Using

                            Catch ex As Exception
                                EstimateReport = Nothing
                            End Try

                            If EstimateReport IsNot Nothing Then

                                CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = CShort(EstimateReport.EstimateReportType)

                            End If

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            'CType(BaseRow2, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            'CType(BaseRow2, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            'CType(BaseRow2, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            'CType(BaseRow2, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = Nothing

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.CDPAddressOption.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.ContactType.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 4 AndAlso BaseRow.Properties.Value = 1 Then

                            BaseRow.Properties.Value = 0

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.ContactType.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.CDPAddressOption.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 1 AndAlso BaseRow.Properties.Value = 4 Then

                            e.Row.Properties.Value = 0

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.ReportFormat.ToString Then

                    Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

                    SubItemGridLookUpEditControl = CType(VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.GroupingOptionGroupOption.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.RowEdit

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeRate.ToString, True)
                    BaseRow2 = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeQuantityHours.ToString, True)
                    BaseRow13 = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.DisplayQuantity.ToString, True)
                    BaseRow14 = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.DisplayHours.ToString, True)
                    BaseRow3 = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeNonBillable.ToString, True)
                    BaseRow4 = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeEstimateRevisionComment.ToString, True)
                    BaseRow5 = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.HideRevision.ToString, True)
                    BaseRow6 = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.PrintAdNumber.ToString, True)
                    BaseRow7 = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeEstimateQuoteComment.ToString, True)
                    BaseRow8 = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeEstimateFunctionComment.ToString, True)
                    BaseRow9 = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeSuppliedByNotes.ToString, True)
                    BaseRow10 = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.PrintQuantityTotals.ToString, True)
                    BaseRow11 = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.GroupingOptionGroupOption.ToString, True)
                    BaseRow12 = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.IncludeRateMarkup.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = AdvantageFramework.Estimate.Printing.ReportFormats.SideBySideQuote Or
                           e.Value = AdvantageFramework.Estimate.Printing.ReportFormats.RevisionComparisonWithVariance Or
                           e.Value = AdvantageFramework.Estimate.Printing.ReportFormats.RevisionComparison Or
                           e.Value = AdvantageFramework.Estimate.Printing.ReportFormats.RevisionComparisonNoActual Or
                           e.Value = AdvantageFramework.Estimate.Printing.ReportFormats.RevisionComparisonPrevLastRevisions Or
                           e.Value = AdvantageFramework.Estimate.Printing.ReportFormats.RevisionComparisonWithVarianceNoActual Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow12, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow2, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow10, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow13, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow14, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0
                            CType(BaseRow12, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0
                            CType(BaseRow2, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0
                            CType(BaseRow10, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0
                            CType(BaseRow13, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0
                            CType(BaseRow14, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0
                            CType(BaseRow12, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow12, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0
                            CType(BaseRow2, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow2, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0
                            CType(BaseRow10, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow10, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0
                            CType(BaseRow13, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow13, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0
                            CType(BaseRow14, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow14, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        End If

                        If e.Value = AdvantageFramework.Estimate.Printing.ReportFormats.SideBySideQuote Or
                           e.Value = AdvantageFramework.Estimate.Printing.ReportFormats.RevisionComparisonNoActual Or
                           e.Value = AdvantageFramework.Estimate.Printing.ReportFormats.RevisionComparisonWithVarianceNoActual Then

                            CType(BaseRow3, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow3, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        Else

                            CType(BaseRow3, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow3, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        End If

                        If e.Value = AdvantageFramework.Estimate.Printing.ReportFormats.RevisionComparisonWithVariance Or
                           e.Value = AdvantageFramework.Estimate.Printing.ReportFormats.RevisionComparison Or
                           e.Value = AdvantageFramework.Estimate.Printing.ReportFormats.RevisionComparisonNoActual Or
                           e.Value = AdvantageFramework.Estimate.Printing.ReportFormats.RevisionComparisonPrevLastRevisions Or
                           e.Value = AdvantageFramework.Estimate.Printing.ReportFormats.RevisionComparisonWithVarianceNoActual Then

                            SubItemGridLookUpEditControl.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Estimate.Printing.GroupOptions)).Where(Function(Entity) Entity.Code <> 4)

                            VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.GroupingOptionGroupOption.ToString, True).Properties.Value = 1

                            CType(BaseRow4, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow4, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0
                            CType(BaseRow6, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow6, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        Else

                            CType(BaseRow4, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow4, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0
                            CType(BaseRow6, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow6, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        End If

                        If e.Value = AdvantageFramework.Estimate.Printing.ReportFormats.SideBySideQuote Then

                            CType(BaseRow4, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow4, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0
                            CType(BaseRow5, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow5, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0
                            CType(BaseRow7, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow7, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0
                            CType(BaseRow8, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow8, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0
                            CType(BaseRow9, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow9, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                            SubItemGridLookUpEditControl.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Estimate.Printing.GroupOptions)).Where(Function(Entity) Entity.Code <> 4)

                            VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.GroupingOptionGroupOption.ToString, True).Properties.Value = 1

                        Else

                            CType(BaseRow4, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow4, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0
                            CType(BaseRow5, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow5, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0
                            CType(BaseRow7, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow7, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0
                            CType(BaseRow8, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow8, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0
                            CType(BaseRow9, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow9, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        End If

                        If e.Value = AdvantageFramework.Estimate.Printing.ReportFormats.OneQuotePerPage Then

                            SubItemGridLookUpEditControl.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Estimate.Printing.GroupOptions))

                            VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting.Properties.GroupingOptionGroupOption.ToString, True).Properties.Value = 1

                        End If

                    End If

                End If

                'VerticalGridForm_Settings.ShowEditor()

            Catch ex As Exception

            End Try
        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            'objects
            Dim PrintingSystem As DevExpress.XtraPrinting.PrintingSystem = Nothing
            Dim CompositeLink As DevExpress.XtraPrintingLinks.CompositeLink = Nothing
            Dim HeaderLink As AdvantageFramework.Reporting.Reports.CustomLink = Nothing
            Dim PrintableComponentLink As DevExpress.XtraPrinting.PrintableComponentLink = Nothing
            Dim ImagesList As Generic.List(Of System.Drawing.Image) = Nothing
            Dim Image As System.Drawing.Image = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Description As String = ""

            PrintingSystem = New DevExpress.XtraPrinting.PrintingSystem
            CompositeLink = New DevExpress.XtraPrintingLinks.CompositeLink(PrintingSystem)

            Description = "Estimate Settings"


            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Agency IsNot Nothing Then

                    If Agency.IsASP = 1 Then

                        If My.Computer.FileSystem.DirectoryExists(Agency.ImportPath) Then

                            If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\") = False Then

                                My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\")

                            End If

                        End If

						PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = Description & "_" & Now.ToShortDateString.Replace("/", " ").Replace(".", " ") & " " & Now.ToString("HH mm ss")
						PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(Agency.ImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\")
                        PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                        PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                        PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(Session, If(String.IsNullOrWhiteSpace(Agency.ImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\"), Description))

                        'PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
                        PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                    End If

                End If

            End Using

            AddFormatHeaderToPrintout(CompositeLink, LabelForm_Format.Text)
            AddVerticalGridToPrintout(CompositeLink, VerticalGridProduction_Settings, "Estimate Settings")

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ImagesList = New Generic.List(Of System.Drawing.Image)

                For Each ImageEntity In AdvantageFramework.Database.Procedures.Image.Load(DbContext).ToList

                    MemoryStream = New System.IO.MemoryStream(ImageEntity.Bytes)

                    ImagesList.Add(System.Drawing.Image.FromStream(MemoryStream))

                    Try

                        MemoryStream.Close()
                        MemoryStream.Dispose()

                        MemoryStream = Nothing

                    Catch ex As Exception
                        MemoryStream = Nothing
                    End Try

                Next

            End Using

            CompositeLink.Landscape = False

            CompositeLink.PrintingSystem.ExportOptions.PrintPreview.DefaultSendFormat = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXls
            CompositeLink.PrintingSystem.ExportOptions.PrintPreview.DefaultExportFormat = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXls
            CompositeLink.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.FileSystem.CreateValidFileName(Description)

            If ImagesList IsNot Nothing Then

                For Each Image In ImagesList

                    CompositeLink.Images.Add(Image)

                Next

            End If

            CompositeLink.ShowRibbonPreviewDialog(Me.DefaultLookAndFeel.LookAndFeel)

        End Sub

#End Region

#End Region

    End Class

End Namespace