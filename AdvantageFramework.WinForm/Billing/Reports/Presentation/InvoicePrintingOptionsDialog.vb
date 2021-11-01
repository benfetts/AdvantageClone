Namespace Billing.Reports.Presentation

    Public Class InvoicePrintingOptionsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes = AdvantageFramework.InvoicePrinting.InvoiceFormatTypes.Agency
        Private _ProductionInvoiceSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting) = Nothing
        Private _MediaInvoiceSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting) = Nothing
        Private _ComboInvoiceSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting) = Nothing
        Private _InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
        Private _InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
        Private _InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting = Nothing
        Private _ClientCodes As Generic.List(Of String) = Nothing
        Private _IsDraft As Boolean = False
        Private _ShowComboOptions As Boolean = False
        Private _ShowProductionOptions As Boolean = False
        Private _ShowMagazineOptions As Boolean = False
        Private _ShowNewspaperOptions As Boolean = False
        Private _ShowInternetOptions As Boolean = False
        Private _ShowOutdoorOptions As Boolean = False
        Private _ShowRadioOptions As Boolean = False
        Private _ShowTVOptions As Boolean = False
        Private _MagazineColumnPropertyDescriptions As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
        Private _NewspaperColumnPropertyDescriptions As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
        Private _InternetColumnPropertyDescriptions As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
        Private _OutdoorColumnPropertyDescriptions As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
        Private _RadioColumnPropertyDescriptions As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
        Private _TVColumnPropertyDescriptions As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
        Private _HasSelectedInvoice As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes, InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting,
                        InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting, InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting,
                        ClientCodes As Generic.List(Of String), IsDraft As Boolean, ShowProductionOptions As Boolean, ShowMagazineOptions As Boolean, ShowNewspaperOptions As Boolean, ShowInternetOptions As Boolean,
                        ShowOutdoorOptions As Boolean, ShowRadioOptions As Boolean, ShowTVOptions As Boolean, ShowComboOptions As Boolean, HasSelectedInvoice As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _InvoiceFormatType = InvoiceFormatType
            _InvoicePrintingSetting = InvoicePrintingSetting
            _InvoicePrintingMediaSetting = InvoicePrintingMediaSetting
            _InvoicePrintingComboSetting = InvoicePrintingComboSetting
            _ClientCodes = ClientCodes
            _IsDraft = IsDraft
            _ShowProductionOptions = ShowProductionOptions
            _ShowMagazineOptions = ShowMagazineOptions
            _ShowNewspaperOptions = ShowNewspaperOptions
            _ShowInternetOptions = ShowInternetOptions
            _ShowOutdoorOptions = ShowOutdoorOptions
            _ShowRadioOptions = ShowRadioOptions
            _ShowTVOptions = ShowTVOptions
            _ShowComboOptions = ShowComboOptions
            _HasSelectedInvoice = HasSelectedInvoice

        End Sub
        Private Sub LoadProductionOptions()

            _ProductionInvoiceSettings = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting)

            If _InvoicePrintingSetting IsNot Nothing Then

                _ProductionInvoiceSettings.Add(New AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting(_InvoicePrintingSetting))

            End If

            'If _InvoiceFormatType = AdvantageFramework.InvoicePrinting.InvoiceFormatTypes.Custom_Legacy Then

            '    If _ProductionInvoiceDefault IsNot Nothing Then

            '        _CustomInvoiceSettings.Add(New AdvantageFramework.InvoicePrinting.Classes.CustomInvoiceSetting(_ProductionInvoiceDefault))

            '    ElseIf _InvoicePrintingSetting IsNot Nothing Then

            '        _CustomInvoiceSettings.Add(New AdvantageFramework.InvoicePrinting.Classes.CustomInvoiceSetting(_InvoicePrintingSetting))

            '    End If

            'ElseIf _InvoiceFormatType = AdvantageFramework.InvoicePrinting.InvoiceFormatTypes.Standard OrElse _InvoiceFormatType = AdvantageFramework.InvoicePrinting.InvoiceFormatTypes.ClientDefault Then

            '    _ProductionInvoiceSettings = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting)

            '    If _ProductionInvoiceDefault IsNot Nothing Then

            '        _ProductionInvoiceSettings.Add(New AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting(_ProductionInvoiceDefault))

            '    ElseIf _InvoicePrintingSetting IsNot Nothing Then

            '        _ProductionInvoiceSettings.Add(New AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting(_InvoicePrintingSetting))

            '    End If

            'End If

        End Sub
        Private Sub LoadMediaOptions()

            _MediaInvoiceSettings = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting)

            If _InvoicePrintingMediaSetting IsNot Nothing Then

                _MediaInvoiceSettings.Add(New AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting(_InvoicePrintingMediaSetting))

            End If

            'If _InvoiceFormatType = AdvantageFramework.InvoicePrinting.InvoiceFormatTypes.Custom_Legacy Then

            '    If _MediaInvoiceDefault IsNot Nothing Then

            '        _CustomInvoiceSettings.Add(New AdvantageFramework.InvoicePrinting.Classes.CustomInvoiceSetting(AdvantageFramework.InvoicePrinting.MediaTypes.Magazine, _MediaInvoiceDefault))
            '        _CustomInvoiceSettings.Add(New AdvantageFramework.InvoicePrinting.Classes.CustomInvoiceSetting(AdvantageFramework.InvoicePrinting.MediaTypes.Newspaper, _MediaInvoiceDefault))
            '        _CustomInvoiceSettings.Add(New AdvantageFramework.InvoicePrinting.Classes.CustomInvoiceSetting(AdvantageFramework.InvoicePrinting.MediaTypes.Internet, _MediaInvoiceDefault))
            '        _CustomInvoiceSettings.Add(New AdvantageFramework.InvoicePrinting.Classes.CustomInvoiceSetting(AdvantageFramework.InvoicePrinting.MediaTypes.Outdoor, _MediaInvoiceDefault))
            '        _CustomInvoiceSettings.Add(New AdvantageFramework.InvoicePrinting.Classes.CustomInvoiceSetting(AdvantageFramework.InvoicePrinting.MediaTypes.Radio, _MediaInvoiceDefault))
            '        _CustomInvoiceSettings.Add(New AdvantageFramework.InvoicePrinting.Classes.CustomInvoiceSetting(AdvantageFramework.InvoicePrinting.MediaTypes.TV, _MediaInvoiceDefault))

            '    ElseIf _InvoicePrintingMediaSetting IsNot Nothing Then

            '        _CustomInvoiceSettings.Add(New AdvantageFramework.InvoicePrinting.Classes.CustomInvoiceSetting(AdvantageFramework.InvoicePrinting.MediaTypes.Magazine, _InvoicePrintingMediaSetting))
            '        _CustomInvoiceSettings.Add(New AdvantageFramework.InvoicePrinting.Classes.CustomInvoiceSetting(AdvantageFramework.InvoicePrinting.MediaTypes.Newspaper, _InvoicePrintingMediaSetting))
            '        _CustomInvoiceSettings.Add(New AdvantageFramework.InvoicePrinting.Classes.CustomInvoiceSetting(AdvantageFramework.InvoicePrinting.MediaTypes.Internet, _InvoicePrintingMediaSetting))
            '        _CustomInvoiceSettings.Add(New AdvantageFramework.InvoicePrinting.Classes.CustomInvoiceSetting(AdvantageFramework.InvoicePrinting.MediaTypes.Outdoor, _InvoicePrintingMediaSetting))
            '        _CustomInvoiceSettings.Add(New AdvantageFramework.InvoicePrinting.Classes.CustomInvoiceSetting(AdvantageFramework.InvoicePrinting.MediaTypes.Radio, _InvoicePrintingMediaSetting))
            '        _CustomInvoiceSettings.Add(New AdvantageFramework.InvoicePrinting.Classes.CustomInvoiceSetting(AdvantageFramework.InvoicePrinting.MediaTypes.TV, _InvoicePrintingMediaSetting))

            '    End If

            'ElseIf _InvoiceFormatType = AdvantageFramework.InvoicePrinting.InvoiceFormatTypes.Standard OrElse _InvoiceFormatType = AdvantageFramework.InvoicePrinting.InvoiceFormatTypes.ClientDefault Then

            '    _MediaInvoiceSettings = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting)

            '    If _MediaInvoiceDefault IsNot Nothing Then

            '        _MediaInvoiceSettings.Add(New AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting(_MediaInvoiceDefault))

            '    ElseIf _InvoicePrintingMediaSetting IsNot Nothing Then

            '        _MediaInvoiceSettings.Add(New AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting(_InvoicePrintingMediaSetting))

            '    End If

            'End If

        End Sub
        Private Sub LoadComboOptions()

            _ComboInvoiceSettings = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting)

            If _InvoicePrintingComboSetting IsNot Nothing Then

                _ComboInvoiceSettings.Add(New AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting(_InvoicePrintingComboSetting))

            End If


        End Sub
        Private Sub LoadProductionTab()

            'objects
            Dim ProductionInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim Row As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing
            Dim CategoryRow As DevExpress.XtraVerticalGrid.Rows.CategoryRow = Nothing
            Dim CustomInvoice As AdvantageFramework.Reporting.Database.Entities.CustomInvoice = Nothing
            Dim EnumObjectsList As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing

            If _ProductionInvoiceSettings IsNot Nothing AndAlso _ProductionInvoiceSettings.Count > 0 Then

                ProductionInvoiceSetting = _ProductionInvoiceSettings(0)

                If ProductionInvoiceSetting IsNot Nothing Then

                    For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                        EntityAttribute = Nothing
                        Row = Nothing

                        Row = GetRowAndInitialize(VerticalGridProduction_Settings, PropertyDescriptor, EntityAttribute)

                        If Row IsNot Nothing Then

                            If Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.LocationCode.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.Location,
                                                                                                                              AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.LocationCode.ToString, EntityAttribute, PropertyDescriptor, Nothing, True)

                                If RepositoryItem IsNot Nothing Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                End If

                                If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = ProductionInvoiceSetting.UseLocationPrintOptions

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.AddressBlockType.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                              AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.AddressBlockType.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                              GetType(AdvantageFramework.InvoicePrinting.AddressBlockTypes), False)

                                If RepositoryItem IsNot Nothing Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.ReportFormatType.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                              AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.ReportFormatType.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                              GetType(AdvantageFramework.InvoicePrinting.ReportFormatTypes), False)

                                If RepositoryItem IsNot Nothing Then

                                    EnumObjectsList = New Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)

                                    EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.InvoicePrinting.ReportFormatTypes.CurrentOnly))
                                    EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.InvoicePrinting.ReportFormatTypes.CurrentTTD))
                                    EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.InvoicePrinting.ReportFormatTypes.EstimateCurrentTTD))
                                    EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.InvoicePrinting.ReportFormatTypes.EstimatePriorCurrentTTD))
                                    EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.InvoicePrinting.ReportFormatTypes.NetCommissionTaxTotal))
                                    EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.InvoicePrinting.ReportFormatTypes.GrandTotalOnly))
                                    EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.InvoicePrinting.ReportFormatTypes.JobDescriptionRollUp))
                                    EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.InvoicePrinting.ReportFormatTypes.JobDescriptionRollUpComment))

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).DataSource = EnumObjectsList.Select(Function(EnumObject) New With {.[Code] = Convert.ChangeType(EnumObject.Code, PropertyDescriptor.PropertyType),
                                                                                                                                                                                                            .[Description] = EnumObject.Description}).ToList
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                End If

                                If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = (ProductionInvoiceSetting.CustomInvoiceID.GetValueOrDefault(0) = 0)

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.SummaryLevel.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                              AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.SummaryLevel.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                              GetType(AdvantageFramework.InvoicePrinting.SummaryLevels), False)

                                If RepositoryItem IsNot Nothing Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                End If

                                If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = (ProductionInvoiceSetting.CustomInvoiceID.GetValueOrDefault(0) = 0)

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.GroupingOptionType.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                              AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.GroupingOptionType.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                              GetType(AdvantageFramework.InvoicePrinting.GroupingOptionTypes), False)

                                If RepositoryItem IsNot Nothing Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.SortFunctionByType.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                              AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.SortFunctionByType.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                              GetType(AdvantageFramework.InvoicePrinting.SortFunctionByTypes), False)

                                If RepositoryItem IsNot Nothing Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.PrintFunctionType.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                              AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.PrintFunctionType.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                              GetType(AdvantageFramework.InvoicePrinting.PrintFunctionTypes), False)

                                If RepositoryItem IsNot Nothing Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.InvoiceFooterCommentType.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                              AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.InvoiceFooterCommentType.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                              GetType(AdvantageFramework.InvoicePrinting.InvoiceFooterCommentTypes), False)

                                If RepositoryItem IsNot Nothing Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.BackupReportColumnOption.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                              AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.BackupReportColumnOption.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                              GetType(AdvantageFramework.InvoicePrinting.BackupReportColumnOptions), False)

                                If RepositoryItem IsNot Nothing Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.CustomInvoiceID.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.ProductionCustomInvoiceID,
                                                                                                                              AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.CustomInvoiceID.ToString,
                                                                                                                              EntityAttribute, PropertyDescriptor, Nothing, True)

                                If RepositoryItem IsNot Nothing Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = WinForm.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                End If

                                'If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                '    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Visible = (_InvoiceFormatType = InvoicePrinting.InvoiceFormatTypes.Custom_Enhanced)

                                'End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.ClientPOLocation.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                              AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.ClientPOLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                              GetType(AdvantageFramework.InvoicePrinting.ClientPOLocations), False)

                                If RepositoryItem IsNot Nothing Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                End If

                                If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = ProductionInvoiceSetting.IncludeClientPO

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.TaxTotalLocation.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                              AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.TaxTotalLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                              GetType(AdvantageFramework.InvoicePrinting.TaxTotalLocations), False)

                                If RepositoryItem IsNot Nothing Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                End If

                                If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = ProductionInvoiceSetting.TotalsShowTaxSeparately

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.ClientRefLocation.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                              AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.ClientRefLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                              GetType(AdvantageFramework.InvoicePrinting.ClientReferenceLocations), False)

                                If RepositoryItem IsNot Nothing Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                End If

                                If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = ProductionInvoiceSetting.IncludeClientReference

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.SalesClassLocation.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                              AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.SalesClassLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                              GetType(AdvantageFramework.InvoicePrinting.SalesClassLocations), False)

                                If RepositoryItem IsNot Nothing Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                End If

                                If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = ProductionInvoiceSetting.IncludeSalesClass

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.CampaignLocation.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                              AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.CampaignLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                              GetType(AdvantageFramework.InvoicePrinting.CampaignLocations), False)

                                If RepositoryItem IsNot Nothing Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                End If

                                If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = ProductionInvoiceSetting.ShowCampaign

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.HeaderGroupBy.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                              AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.HeaderGroupBy.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                              GetType(AdvantageFramework.InvoicePrinting.HeaderGroupByOptions), False)

                                If RepositoryItem IsNot Nothing Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.ContactType.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                              AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.ContactType.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                              GetType(AdvantageFramework.InvoicePrinting.AddressContactTypes), False)

                                If RepositoryItem IsNot Nothing Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.ExchangeRateAmount.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateDefaultSubItem(Me.Session, Row.Properties.FieldName, PropertyDescriptor.PropertyType, "n4", GetType(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting))

                            Else

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateDefaultSubItem(Me.Session, Row.Properties.FieldName, PropertyDescriptor.PropertyType, Row.Properties.Format.FormatString, GetType(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting))

                            End If

                            If Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.ExchangeRateAmount.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = ProductionInvoiceSetting.ApplyExchangeRate

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.IncludeBillingComment.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.UseInvoiceCategoryDescription.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                'CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.IncludeInvoiceDueDate.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.InvoiceTitle.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not ProductionInvoiceSetting.UseInvoiceCategoryDescription
                                'CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft
                                CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox).MaxLength = 20

                            ElseIf (Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.GroupingOptionInsideDescription.ToString OrElse
                                     Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.GroupingOptionOutsideDescription.ToString) AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = If(ProductionInvoiceSetting.GroupingOptionType = AdvantageFramework.InvoicePrinting.GroupingOptionTypes.InsideOutsideAndFunction OrElse ProductionInvoiceSetting.GroupingOptionType = AdvantageFramework.InvoicePrinting.GroupingOptionTypes.InsideOutsideTotalOnly, True, False)
                                CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox).MaxLength = 50

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.InvoiceFooterComment.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = If(ProductionInvoiceSetting.InvoiceFooterCommentType = AdvantageFramework.InvoicePrinting.InvoiceFooterCommentTypes.UserDefined, True, False)
                                CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox).MaxLength = 50

                            ElseIf (Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.BackupReportColumnOption.ToString OrElse
                                     Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.BackupReportCommentOptionEmployeeTimeFunction.ToString OrElse
                                     Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.BackupReportCommentOptionAccountsPayableFunction.ToString OrElse
                                     Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.BackupReportCommentOptionIncomeOnlyFunction.ToString OrElse
                                     Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.BreakupByJobComponent.ToString) AndAlso
                                     TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = ProductionInvoiceSetting.IncludeBackupReport

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.ReportFormatType.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                If ProductionInvoiceSetting.CustomInvoiceID.GetValueOrDefault(0) > 0 Then

                                    Try

                                        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                            CustomInvoice = AdvantageFramework.Reporting.Database.Procedures.CustomInvoice.LoadByCustomInvoiceID(ReportingDbContext, ProductionInvoiceSetting.CustomInvoiceID.GetValueOrDefault(0))

                                        End Using

                                    Catch ex As Exception
                                        CustomInvoice = Nothing
                                    End Try

                                    If CustomInvoice IsNot Nothing Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = CShort(CustomInvoice.Type)

                                    End If

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                                Else

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.TotalsShowBillingHistory.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                If ProductionInvoiceSetting.SummaryLevel = AdvantageFramework.InvoicePrinting.SummaryLevels.Job OrElse
                                        ProductionInvoiceSetting.SummaryLevel = AdvantageFramework.InvoicePrinting.SummaryLevels.Invoice Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                                Else

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.HideComponentNumberAndDescription.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not ProductionInvoiceSetting.HideJobInfo

                            End If

                            If TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                                CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

                            End If

                            VerticalGridProduction_Settings.RepositoryItems.Add(RepositoryItem)

                            Row.Properties.RowEdit = RepositoryItem

                        End If

                    Next

                End If

            End If

            VerticalGridProduction_Settings.DataSource = _ProductionInvoiceSettings

            VerticalGridProduction_Settings.ExpandAllRows()

            VerticalGridProduction_Settings.BestFit()

        End Sub
        Private Sub LoadMediaTab()

            'objects
            Dim MediaInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting = Nothing
            Dim MediaInvoiceHeaderFooterSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting = Nothing
            Dim MediaInvoiceHeaderFooterSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting) = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim Row As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing
            Dim CategoryRow As DevExpress.XtraVerticalGrid.Rows.CategoryRow = Nothing

            MediaInvoiceHeaderFooterSettings = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting)

            If _MediaInvoiceSettings IsNot Nothing AndAlso _MediaInvoiceSettings.Count > 0 Then

                MediaInvoiceSetting = _MediaInvoiceSettings(0)

                If MediaInvoiceSetting IsNot Nothing Then

                    MediaInvoiceHeaderFooterSetting = MediaInvoiceSetting.MediaInvoiceHeaderFooterSetting

                    If MediaInvoiceHeaderFooterSetting IsNot Nothing Then

                        MediaInvoiceHeaderFooterSettings.Add(MediaInvoiceHeaderFooterSetting)

                        For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                            EntityAttribute = Nothing
                            Row = Nothing

                            Row = GetRowAndInitialize(VerticalGridMedia_Settings, PropertyDescriptor, EntityAttribute)

                            If Row IsNot Nothing Then

                                If Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.LocationCode.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.Location,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.LocationCode.ToString, EntityAttribute, PropertyDescriptor, Nothing, True)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceHeaderFooterSetting.UseLocationPrintOptions

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.AddressBlockType.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.AddressBlockType.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaAddressBlockTypes), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.InvoiceFooterCommentType.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.InvoiceFooterCommentType.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.InvoiceFooterCommentTypes), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.ContactType.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.ContactType.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaAddressContactTypes), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.ExchangeRateAmount.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateDefaultSubItem(Me.Session, Row.Properties.FieldName, PropertyDescriptor.PropertyType, "n4", GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting))

                                Else

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateDefaultSubItem(Me.Session, Row.Properties.FieldName, PropertyDescriptor.PropertyType, Row.Properties.Format.FormatString, GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting))

                                End If

                                If Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.IncludeBillingComment.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.ExchangeRateAmount.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceHeaderFooterSetting.ApplyExchangeRate

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.InvoiceFooterComment.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = If(MediaInvoiceHeaderFooterSetting.InvoiceFooterCommentType = AdvantageFramework.InvoicePrinting.InvoiceFooterCommentTypes.UserDefined, True, False)
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox).MaxLength = 50

                                End If

                                If TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

                                End If

                                VerticalGridMedia_Settings.RepositoryItems.Add(RepositoryItem)

                                Row.Properties.RowEdit = RepositoryItem

                            End If

                        Next

                    End If

                End If

            End If

            VerticalGridMedia_Settings.DataSource = MediaInvoiceHeaderFooterSettings

            VerticalGridMedia_Settings.ExpandAllRows()

            VerticalGridMedia_Settings.BestFit()

        End Sub
        Private Sub LoadMagazineTab()

            'objects
            Dim MediaInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting = Nothing
            Dim MediaInvoiceMagazineSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting = Nothing
            Dim MediaInvoiceMagazineSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting) = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim Row As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing
            Dim CategoryRow As DevExpress.XtraVerticalGrid.Rows.CategoryRow = Nothing

            MediaInvoiceMagazineSettings = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting)
            _MagazineColumnPropertyDescriptions = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList.Where(Function(Prop) Prop.Attributes.OfType(Of System.ComponentModel.CategoryAttribute).Any).ToList

            If _MediaInvoiceSettings IsNot Nothing AndAlso _MediaInvoiceSettings.Count > 0 Then

                MediaInvoiceSetting = _MediaInvoiceSettings(0)

                If MediaInvoiceSetting IsNot Nothing Then

                    MediaInvoiceMagazineSetting = MediaInvoiceSetting.MediaInvoiceMagazineSetting

                    If MediaInvoiceMagazineSetting IsNot Nothing Then

                        MediaInvoiceMagazineSettings.Add(MediaInvoiceMagazineSetting)

                        For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                            EntityAttribute = Nothing
                            Row = Nothing

                            Row = GetRowAndInitialize(VerticalGridMagazine_Settings, PropertyDescriptor, EntityAttribute)

                            If Row IsNot Nothing Then

                                If Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineOrderNumberColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.OrderNumberOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineLineNumberColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.OrderLineNumberOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceMagazineSetting.MagazineShowLineDetail

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineVendorNameColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineShowVendorCode.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.NonBroadcastVendorOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineOrderMonthsColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineNetAmountColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineCommissionAmountColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineTaxAmountColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineBillAmountColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazinePriorBillAmountColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineBilledToDateAmountColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.NonBroadcastAmountsOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineHeadlineColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineInsertDatesColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineMaterialColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineAdNumberColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineEditorialIssueColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineAdSizeColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineJobComponentNumberColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineJobDescriptionColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineComponentDescriptionColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineOrderDetailCommentColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineOrderHouseDetailCommentColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineCloseDateColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.NonBroadcastLineOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineExtraChargesColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineExtraChargesColumn.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.ExtraChargesOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineHeaderGroupBy.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineHeaderGroupBy.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaOrderGroupBy), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).RemoveFromDataSource("6")
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineClientPOLocation.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineClientPOLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaClientPOLocations), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceMagazineSetting.MagazineShowClientPO

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineSalesClassLocation.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineSalesClassLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaSalesClassLocations), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceMagazineSetting.MagazineShowSalesClass

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineCampaignLocation.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineCampaignLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaCampaignLocations), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceMagazineSetting.MagazineShowCampaign

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineShowLineDetail.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineShowLineDetail.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaShowLineDetails), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineSortLinesBy.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineSortLinesBy.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaSortLinesBy), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineCustomInvoiceID.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.MediaCustomInvoiceID,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineCustomInvoiceID.ToString,
                                                                                                                                  EntityAttribute, PropertyDescriptor, Nothing, True)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = WinForm.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                Else

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateDefaultSubItem(Me.Session, Row.Properties.FieldName, PropertyDescriptor.PropertyType, Row.Properties.Format.FormatString, GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting))

                                End If

                                If Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineInvoiceTitle.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not MediaInvoiceMagazineSetting.MagazineUseInvoiceCategoryDescription
                                    'CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox).MaxLength = 20

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineUseInvoiceCategoryDescription.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    'CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazinePrintInvoiceDueDate.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineShowTaxSeparately.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = (MediaInvoiceMagazineSetting.MagazineTaxAmountColumn = 0)

                                    If CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineShowCommissionSeparately.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = (MediaInvoiceMagazineSetting.MagazineCommissionAmountColumn = 0)

                                End If

                                If TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

                                End If

                                VerticalGridMagazine_Settings.RepositoryItems.Add(RepositoryItem)

                                Row.Properties.RowEdit = RepositoryItem

                            End If

                        Next

                    End If

                End If

            End If

            VerticalGridMagazine_Settings.DataSource = MediaInvoiceMagazineSettings

            VerticalGridMagazine_Settings.ExpandAllRows()

            VerticalGridMagazine_Settings.BestFit()

        End Sub
        Private Sub LoadNewspaperTab()

            'objects
            Dim MediaInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting = Nothing
            Dim MediaInvoiceNewspaperSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting = Nothing
            Dim MediaInvoiceNewspaperSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting) = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim Row As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing
            Dim CategoryRow As DevExpress.XtraVerticalGrid.Rows.CategoryRow = Nothing

            MediaInvoiceNewspaperSettings = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting)
            _NewspaperColumnPropertyDescriptions = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList.Where(Function(Prop) Prop.Attributes.OfType(Of System.ComponentModel.CategoryAttribute).Any).ToList

            If _MediaInvoiceSettings IsNot Nothing AndAlso _MediaInvoiceSettings.Count > 0 Then

                MediaInvoiceSetting = _MediaInvoiceSettings(0)

                If MediaInvoiceSetting IsNot Nothing Then

                    MediaInvoiceNewspaperSetting = MediaInvoiceSetting.MediaInvoiceNewspaperSetting

                    If MediaInvoiceNewspaperSetting IsNot Nothing Then

                        MediaInvoiceNewspaperSettings.Add(MediaInvoiceNewspaperSetting)

                        For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                            EntityAttribute = Nothing
                            Row = Nothing

                            Row = GetRowAndInitialize(VerticalGridNewspaper_Settings, PropertyDescriptor, EntityAttribute)

                            If Row IsNot Nothing Then

                                If Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperOrderNumberColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.OrderNumberOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperLineNumberColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.OrderLineNumberOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceNewspaperSetting.NewspaperShowLineDetail

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperVendorNameColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperShowVendorCode.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.NonBroadcastVendorOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperOrderMonthsColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperNetAmountColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperCommissionAmountColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperTaxAmountColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperBillAmountColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperPriorBillAmountColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperBilledToDateAmountColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.NonBroadcastAmountsOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperHeadlineColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperInsertDatesColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperMaterialColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperAdNumberColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperEditorialIssueColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperSectionColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperQuantityColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperAdSizeColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperJobComponentNumberColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperJobDescriptionColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperComponentDescriptionColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperOrderDetailCommentColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperOrderHouseDetailCommentColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperCloseDateColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.NonBroadcastLineOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperExtraChargesColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperExtraChargesColumn.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.ExtraChargesOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperHeaderGroupBy.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperHeaderGroupBy.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaOrderGroupBy), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).RemoveFromDataSource("6")
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperClientPOLocation.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperClientPOLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaClientPOLocations), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceNewspaperSetting.NewspaperShowClientPO

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperSalesClassLocation.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperSalesClassLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaSalesClassLocations), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceNewspaperSetting.NewspaperShowSalesClass

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperCampaignLocation.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperCampaignLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaCampaignLocations), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceNewspaperSetting.NewspaperShowCampaign

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperShowLineDetail.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperShowLineDetail.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaShowLineDetails), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperSortLinesBy.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperSortLinesBy.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaSortLinesBy), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperCustomInvoiceID.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.MediaCustomInvoiceID,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperCustomInvoiceID.ToString,
                                                                                                                                  EntityAttribute, PropertyDescriptor, Nothing, True)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = WinForm.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                Else

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateDefaultSubItem(Me.Session, Row.Properties.FieldName, PropertyDescriptor.PropertyType, Row.Properties.Format.FormatString, GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting))

                                End If

                                If Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperInvoiceTitle.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not MediaInvoiceNewspaperSetting.NewspaperUseInvoiceCategoryDescription
                                    'CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox).MaxLength = 20

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperUseInvoiceCategoryDescription.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    'CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperPrintInvoiceDueDate.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperShowTaxSeparately.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = (MediaInvoiceNewspaperSetting.NewspaperTaxAmountColumn = 0)

                                    If CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperShowCommissionSeparately.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = (MediaInvoiceNewspaperSetting.NewspaperCommissionAmountColumn = 0)

                                End If

                                If TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

                                End If

                                VerticalGridNewspaper_Settings.RepositoryItems.Add(RepositoryItem)

                                Row.Properties.RowEdit = RepositoryItem

                            End If

                        Next

                    End If

                End If

            End If

            VerticalGridNewspaper_Settings.DataSource = MediaInvoiceNewspaperSettings

            VerticalGridNewspaper_Settings.ExpandAllRows()

            VerticalGridNewspaper_Settings.BestFit()

        End Sub
        Private Sub LoadInternetTab()

            'objects
            Dim MediaInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting = Nothing
            Dim MediaInvoiceInternetSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting = Nothing
            Dim MediaInvoiceInternetSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting) = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim Row As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing
            Dim CategoryRow As DevExpress.XtraVerticalGrid.Rows.CategoryRow = Nothing

            MediaInvoiceInternetSettings = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting)
            _InternetColumnPropertyDescriptions = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList.Where(Function(Prop) Prop.Attributes.OfType(Of System.ComponentModel.CategoryAttribute).Any).ToList

            If _MediaInvoiceSettings IsNot Nothing AndAlso _MediaInvoiceSettings.Count > 0 Then

                MediaInvoiceSetting = _MediaInvoiceSettings(0)

                If MediaInvoiceSetting IsNot Nothing Then

                    MediaInvoiceInternetSetting = MediaInvoiceSetting.MediaInvoiceInternetSetting

                    If MediaInvoiceInternetSetting IsNot Nothing Then

                        MediaInvoiceInternetSettings.Add(MediaInvoiceInternetSetting)

                        For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                            EntityAttribute = Nothing
                            Row = Nothing

                            Row = GetRowAndInitialize(VerticalGridInternet_Settings, PropertyDescriptor, EntityAttribute)

                            If Row IsNot Nothing Then

                                If Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetOrderNumberColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.OrderNumberOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetLineNumberColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.OrderLineNumberOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceInternetSetting.InternetShowLineDetail

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetVendorNameColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowVendorCode.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.NonBroadcastVendorOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetOrderMonthsColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetNetAmountColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCommissionAmountColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetTaxAmountColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetBillAmountColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetPriorBillAmountColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetBilledToDateAmountColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.NonBroadcastAmountsOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetHeadlineColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetStartDatesColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetEndDatesColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCreativeSizeColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetAdNumberColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetURLColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetInternetTypeColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetJobComponentNumberColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetJobDescriptionColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetComponentDescriptionColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCloseDateColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.NonBroadcastLineOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetExtraChargesColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetExtraChargesColumn.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.ExtraChargesOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetHeaderGroupBy.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetHeaderGroupBy.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaOrderGroupBy), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetClientPOLocation.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetClientPOLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaClientPOLocations), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceInternetSetting.InternetShowClientPO

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetSalesClassLocation.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetSalesClassLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaSalesClassLocations), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceInternetSetting.InternetShowSalesClass

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCampaignLocation.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCampaignLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaCampaignLocations), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceInternetSetting.InternetShowCampaign

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowLineDetail.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowLineDetail.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaShowLineDetails), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetSortLinesBy.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetSortLinesBy.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaSortLinesBy), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCustomInvoiceID.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.MediaCustomInvoiceID,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCustomInvoiceID.ToString,
                                                                                                                                  EntityAttribute, PropertyDescriptor, Nothing, True)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = WinForm.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                Else

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateDefaultSubItem(Me.Session, Row.Properties.FieldName, PropertyDescriptor.PropertyType, Row.Properties.Format.FormatString, GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting))

                                End If

                                If Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetInvoiceTitle.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not MediaInvoiceInternetSetting.InternetUseInvoiceCategoryDescription
                                    'CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox).MaxLength = 20

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetUseInvoiceCategoryDescription.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    'CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetPrintInvoiceDueDate.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowTaxSeparately.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = (MediaInvoiceInternetSetting.InternetTaxAmountColumn = 0)

                                    If CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowCommissionSeparately.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = (MediaInvoiceInternetSetting.InternetCommissionAmountColumn = 0)

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetHeaderGroupBy.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    If CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = AdvantageFramework.InvoicePrinting.MediaOrderGroupBy.GroupByVendorInvoiceCategory Then


                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetClientPOLocation.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetSalesClassLocation.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCampaignLocation.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowOrderComment.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowOrderHouseComment.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowCampaignComment.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowOrderDescription.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowOrderSubtotals.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowLineDetail.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetOrderNumberColumn.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetVendorNameColumn.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowVendorCode.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetOrderMonthsColumn.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowZeroLineAmounts.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetSortLinesBy.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetLineNumberColumn.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetHeadlineColumn.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetStartDatesColumn.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetEndDatesColumn.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCreativeSizeColumn.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetAdNumberColumn.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetURLColumn.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetInternetTypeColumn.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCloseDateColumn.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetJobComponentNumberColumn.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetJobDescriptionColumn.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetComponentDescriptionColumn.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetExtraChargesColumn.ToString OrElse
                                         Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowBillingHistory.ToString Then

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = (MediaInvoiceInternetSetting.InternetHeaderGroupBy <> AdvantageFramework.InvoicePrinting.MediaOrderGroupBy.GroupByVendorInvoiceCategory)

                                    End If

                                End If

                                If TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

                                End If

                                VerticalGridInternet_Settings.RepositoryItems.Add(RepositoryItem)

                                Row.Properties.RowEdit = RepositoryItem

                            End If

                        Next

                    End If

                End If

            End If

            VerticalGridInternet_Settings.DataSource = MediaInvoiceInternetSettings

            VerticalGridInternet_Settings.ExpandAllRows()

            VerticalGridInternet_Settings.BestFit()

        End Sub
        Private Sub LoadOutdoorTab()

            'objects
            Dim MediaInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting = Nothing
            Dim MediaInvoiceOutdoorSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting = Nothing
            Dim MediaInvoiceOutdoorSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting) = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim Row As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing
            Dim CategoryRow As DevExpress.XtraVerticalGrid.Rows.CategoryRow = Nothing

            MediaInvoiceOutdoorSettings = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting)
            _OutdoorColumnPropertyDescriptions = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList.Where(Function(Prop) Prop.Attributes.OfType(Of System.ComponentModel.CategoryAttribute).Any).ToList

            If _MediaInvoiceSettings IsNot Nothing AndAlso _MediaInvoiceSettings.Count > 0 Then

                MediaInvoiceSetting = _MediaInvoiceSettings(0)

                If MediaInvoiceSetting IsNot Nothing Then

                    MediaInvoiceOutdoorSetting = MediaInvoiceSetting.MediaInvoiceOutdoorSetting

                    If MediaInvoiceOutdoorSetting IsNot Nothing Then

                        MediaInvoiceOutdoorSettings.Add(MediaInvoiceOutdoorSetting)

                        For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                            EntityAttribute = Nothing
                            Row = Nothing

                            Row = GetRowAndInitialize(VerticalGridOutdoor_Settings, PropertyDescriptor, EntityAttribute)

                            If Row IsNot Nothing Then

                                If Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorOrderNumberColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.OrderNumberOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorLineNumberColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.OrderLineNumberOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceOutdoorSetting.OutdoorShowLineDetail

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorVendorNameColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorShowVendorCode.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.NonBroadcastVendorOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorOrderMonthsColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorNetAmountColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorCommissionAmountColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorTaxAmountColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorBillAmountColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorPriorBillAmountColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorBilledToDateAmountColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.NonBroadcastAmountsOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorHeadlineColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorInsertDatesColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorCopyAreaColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorAdNumberColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorLocationColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorOutdoorTypeColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorSizeColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorJobComponentNumberColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorJobDescriptionColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorComponentDescriptionColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorCloseDateColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorEndDateColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.NonBroadcastLineOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorExtraChargesColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorExtraChargesColumn.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.ExtraChargesOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorHeaderGroupBy.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorHeaderGroupBy.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaOrderGroupBy), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).RemoveFromDataSource("6")
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorClientPOLocation.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorClientPOLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaClientPOLocations), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceOutdoorSetting.OutdoorShowClientPO

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorSalesClassLocation.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorSalesClassLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaSalesClassLocations), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceOutdoorSetting.OutdoorShowSalesClass

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorCampaignLocation.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorCampaignLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaCampaignLocations), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceOutdoorSetting.OutdoorShowCampaign

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorShowLineDetail.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorShowLineDetail.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaShowLineDetails), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorSortLinesBy.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorSortLinesBy.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaSortLinesBy), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorCustomInvoiceID.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.MediaCustomInvoiceID,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorCustomInvoiceID.ToString,
                                                                                                                                  EntityAttribute, PropertyDescriptor, Nothing, True)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = WinForm.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                Else

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateDefaultSubItem(Me.Session, Row.Properties.FieldName, PropertyDescriptor.PropertyType, Row.Properties.Format.FormatString, GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting))

                                End If

                                If Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorInvoiceTitle.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not MediaInvoiceOutdoorSetting.OutdoorUseInvoiceCategoryDescription
                                    'CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox).MaxLength = 20

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorUseInvoiceCategoryDescription.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    'CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorPrintInvoiceDueDate.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorShowTaxSeparately.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = (MediaInvoiceOutdoorSetting.OutdoorTaxAmountColumn = 0)

                                    If CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorShowCommissionSeparately.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = (MediaInvoiceOutdoorSetting.OutdoorCommissionAmountColumn = 0)

                                End If

                                If TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

                                End If

                                VerticalGridOutdoor_Settings.RepositoryItems.Add(RepositoryItem)

                                Row.Properties.RowEdit = RepositoryItem

                            End If

                        Next

                    End If

                End If

            End If

            VerticalGridOutdoor_Settings.DataSource = MediaInvoiceOutdoorSettings

            VerticalGridOutdoor_Settings.ExpandAllRows()

            VerticalGridOutdoor_Settings.BestFit()

        End Sub
        Private Sub LoadRadioTab()

            'objects
            Dim MediaInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting = Nothing
            Dim MediaInvoiceRadioSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting = Nothing
            Dim MediaInvoiceRadioSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting) = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim Row As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing
            Dim CategoryRow As DevExpress.XtraVerticalGrid.Rows.CategoryRow = Nothing

            MediaInvoiceRadioSettings = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting)
            _RadioColumnPropertyDescriptions = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList.Where(Function(Prop) Prop.Attributes.OfType(Of System.ComponentModel.CategoryAttribute).Any).ToList

            If _MediaInvoiceSettings IsNot Nothing AndAlso _MediaInvoiceSettings.Count > 0 Then

                MediaInvoiceSetting = _MediaInvoiceSettings(0)

                If MediaInvoiceSetting IsNot Nothing Then

                    MediaInvoiceRadioSetting = MediaInvoiceSetting.MediaInvoiceRadioSetting

                    If MediaInvoiceRadioSetting IsNot Nothing Then

                        MediaInvoiceRadioSettings.Add(MediaInvoiceRadioSetting)

                        For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                            EntityAttribute = Nothing
                            Row = Nothing

                            Row = GetRowAndInitialize(VerticalGridRadio_Settings, PropertyDescriptor, EntityAttribute)

                            If Row IsNot Nothing Then

                                If Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioOrderNumberColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.OrderNumberOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioLineNumberColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.OrderLineNumberOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceRadioSetting.RadioShowLineDetail

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioVendorNameColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioShowVendorCode.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.BroadcastVendorOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioOrderMonthsColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioNetAmountColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioCommissionAmountColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioTaxAmountColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioBillAmountColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioPriorBillAmountColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioBilledToDateAmountColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.BroadcastAmountsOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioProgramColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioSpotLengthColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioTagColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioStartEndTimesColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioNumberOfSpotsColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioRemarksColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioJobComponentNumberColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioJobDescriptionColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioComponentDescriptionColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioOrderDetailCommentColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioOrderHouseDetailCommentColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioCloseDateColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.BroadcastLineOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioExtraChargesColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioExtraChargesColumn.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.ExtraChargesOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioHeaderGroupBy.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioHeaderGroupBy.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaOrderGroupBy), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).RemoveFromDataSource("6")
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioClientPOLocation.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioClientPOLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaClientPOLocations), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceRadioSetting.RadioShowClientPO

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioSalesClassLocation.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioSalesClassLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaSalesClassLocations), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceRadioSetting.RadioShowSalesClass

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioCampaignLocation.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioCampaignLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaCampaignLocations), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceRadioSetting.RadioShowCampaign

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioShowLineDetail.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioShowLineDetail.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaShowLineDetails), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioSortLinesBy.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioSortLinesBy.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaSortLinesBy), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioCustomInvoiceID.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.MediaCustomInvoiceID,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioCustomInvoiceID.ToString,
                                                                                                                                  EntityAttribute, PropertyDescriptor, Nothing, True)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = WinForm.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                Else

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateDefaultSubItem(Me.Session, Row.Properties.FieldName, PropertyDescriptor.PropertyType, Row.Properties.Format.FormatString, GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting))

                                End If

                                If Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioInvoiceTitle.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not MediaInvoiceRadioSetting.RadioUseInvoiceCategoryDescription
                                    'CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox).MaxLength = 20

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioUseInvoiceCategoryDescription.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    'CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioPrintInvoiceDueDate.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioShowTaxSeparately.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = (MediaInvoiceRadioSetting.RadioTaxAmountColumn = 0)

                                    If CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioShowCommissionSeparately.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = (MediaInvoiceRadioSetting.RadioCommissionAmountColumn = 0)

                                End If

                                If TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

                                End If

                                VerticalGridRadio_Settings.RepositoryItems.Add(RepositoryItem)

                                Row.Properties.RowEdit = RepositoryItem

                            End If

                        Next

                    End If

                End If

            End If

            VerticalGridRadio_Settings.DataSource = MediaInvoiceRadioSettings

            VerticalGridRadio_Settings.ExpandAllRows()

            VerticalGridRadio_Settings.BestFit()

        End Sub
        Private Sub LoadTVTab()

            'objects
            Dim MediaInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting = Nothing
            Dim MediaInvoiceTVSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting = Nothing
            Dim MediaInvoiceTVSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting) = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim Row As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing
            Dim CategoryRow As DevExpress.XtraVerticalGrid.Rows.CategoryRow = Nothing

            MediaInvoiceTVSettings = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting)
            _TVColumnPropertyDescriptions = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList.Where(Function(Prop) Prop.Attributes.OfType(Of System.ComponentModel.CategoryAttribute).Any).ToList

            If _MediaInvoiceSettings IsNot Nothing AndAlso _MediaInvoiceSettings.Count > 0 Then

                MediaInvoiceSetting = _MediaInvoiceSettings(0)

                If MediaInvoiceSetting IsNot Nothing Then

                    MediaInvoiceTVSetting = MediaInvoiceSetting.MediaInvoiceTVSetting

                    If MediaInvoiceTVSetting IsNot Nothing Then

                        MediaInvoiceTVSettings.Add(MediaInvoiceTVSetting)

                        For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                            EntityAttribute = Nothing
                            Row = Nothing

                            Row = GetRowAndInitialize(VerticalGridTV_Settings, PropertyDescriptor, EntityAttribute)

                            If Row IsNot Nothing Then

                                If Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVOrderNumberColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.OrderNumberOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVLineNumberColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.OrderLineNumberOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceTVSetting.TVShowLineDetail

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVVendorNameColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVShowVendorCode.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.BroadcastVendorOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVOrderMonthsColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVNetAmountColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVCommissionAmountColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVTaxAmountColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVBillAmountColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVPriorBillAmountColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVBilledToDateAmountColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.BroadcastAmountsOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVProgramColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVSpotLengthColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVTagColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVStartEndTimesColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVNumberOfSpotsColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVRemarksColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVJobComponentNumberColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVJobDescriptionColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVComponentDescriptionColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVOrderDetailCommentColumn.ToString OrElse
                                        Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVOrderHouseDetailCommentColumn.ToString OrElse Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVCloseDateColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  Row.Properties.FieldName, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.BroadcastLineOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVExtraChargesColumn.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVExtraChargesColumn.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.ExtraChargesOptions), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVHeaderGroupBy.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVHeaderGroupBy.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaOrderGroupBy), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).RemoveFromDataSource("6")
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVClientPOLocation.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVClientPOLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaClientPOLocations), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceTVSetting.TVShowClientPO

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVSalesClassLocation.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVSalesClassLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaSalesClassLocations), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceTVSetting.TVShowSalesClass

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVCampaignLocation.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVCampaignLocation.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaCampaignLocations), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                    If TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = MediaInvoiceTVSetting.TVShowCampaign

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVShowLineDetail.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVShowLineDetail.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaShowLineDetails), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVSortLinesBy.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVSortLinesBy.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                                  GetType(AdvantageFramework.InvoicePrinting.MediaSortLinesBy), False)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVCustomInvoiceID.ToString Then

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.MediaCustomInvoiceID,
                                                                                                                                  AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVCustomInvoiceID.ToString,
                                                                                                                                  EntityAttribute, PropertyDescriptor, Nothing, True)

                                    If RepositoryItem IsNot Nothing Then

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).ExtraComboBoxItem = WinForm.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None

                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                        CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                    End If

                                Else

                                    RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateDefaultSubItem(Me.Session, Row.Properties.FieldName, PropertyDescriptor.PropertyType, Row.Properties.Format.FormatString, GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting))

                                End If

                                If Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVInvoiceTitle.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not MediaInvoiceTVSetting.TVUseInvoiceCategoryDescription
                                    'CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox).MaxLength = 20

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVUseInvoiceCategoryDescription.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    ' CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVPrintInvoiceDueDate.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVShowTaxSeparately.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = (MediaInvoiceTVSetting.TVTaxAmountColumn = 0)

                                    If CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False Then

                                        CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                                    End If

                                ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVShowCommissionSeparately.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                    CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = (MediaInvoiceTVSetting.TVCommissionAmountColumn = 0)

                                End If

                                If TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

                                End If

                                VerticalGridTV_Settings.RepositoryItems.Add(RepositoryItem)

                                Row.Properties.RowEdit = RepositoryItem

                            End If

                        Next

                    End If

                End If

            End If

            VerticalGridTV_Settings.DataSource = MediaInvoiceTVSettings

            VerticalGridTV_Settings.ExpandAllRows()

            VerticalGridTV_Settings.BestFit()

        End Sub
        Private Sub LoadComboTab()

            'objects
            Dim ComboInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim Row As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItem = Nothing
            Dim CategoryRow As DevExpress.XtraVerticalGrid.Rows.CategoryRow = Nothing
            Dim CustomInvoice As AdvantageFramework.Reporting.Database.Entities.CustomInvoice = Nothing

            If _ComboInvoiceSettings IsNot Nothing AndAlso _ComboInvoiceSettings.Count > 0 Then

                ComboInvoiceSetting = _ComboInvoiceSettings(0)

                If ComboInvoiceSetting IsNot Nothing Then

                    For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                        EntityAttribute = Nothing
                        Row = Nothing

                        Row = GetRowAndInitialize(VerticalGridCombo_Settings, PropertyDescriptor, EntityAttribute)

                        If Row IsNot Nothing Then

                            If Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.LocationCode.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.Location,
                                                                                                                              AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.LocationCode.ToString, EntityAttribute, PropertyDescriptor, Nothing, True)

                                If RepositoryItem IsNot Nothing Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.AddressBlockType.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                              AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.AddressBlockType.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                              GetType(AdvantageFramework.InvoicePrinting.AddressBlockTypes), False)

                                If RepositoryItem IsNot Nothing Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.InvoiceFooterCommentType.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                              AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.InvoiceFooterCommentType.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                              GetType(AdvantageFramework.InvoicePrinting.InvoiceFooterCommentTypes), False)

                                If RepositoryItem IsNot Nothing Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.ContactType.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumObject,
                                                                                                                              AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.ContactType.ToString, EntityAttribute, PropertyDescriptor,
                                                                                                                              GetType(AdvantageFramework.InvoicePrinting.AddressContactTypes), False)

                                If RepositoryItem IsNot Nothing Then

                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).LoadDefaultDataSourceView()
                                    CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowMouseWheel = False

                                End If

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.ExchangeRateAmount.ToString Then

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateDefaultSubItem(Me.Session, Row.Properties.FieldName, PropertyDescriptor.PropertyType, "n4", GetType(AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting))

                            Else

                                RepositoryItem = AdvantageFramework.WinForm.Presentation.Controls.CreateDefaultSubItem(Me.Session, Row.Properties.FieldName, PropertyDescriptor.PropertyType, Row.Properties.Format.FormatString, GetType(AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting))

                            End If

                            If Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.ExchangeRateAmount.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = ComboInvoiceSetting.ApplyExchangeRate

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.InvoiceTitle.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not ComboInvoiceSetting.UseInvoiceCategoryDescription
                                'CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft
                                CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox).MaxLength = 20

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.UseInvoiceCategoryDescription.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                'CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = Not _IsDraft

                            ElseIf Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.InvoiceFooterComment.ToString AndAlso TypeOf Row Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                                CType(Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = If(ComboInvoiceSetting.InvoiceFooterCommentType = AdvantageFramework.InvoicePrinting.InvoiceFooterCommentTypes.UserDefined, True, False)
                                CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox).MaxLength = 50

                            End If

                            If TypeOf RepositoryItem Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                                CType(RepositoryItem, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

                            End If

                            VerticalGridCombo_Settings.RepositoryItems.Add(RepositoryItem)

                            Row.Properties.RowEdit = RepositoryItem

                        End If

                    Next

                End If

            End If

            VerticalGridCombo_Settings.DataSource = _ComboInvoiceSettings

            VerticalGridCombo_Settings.ExpandAllRows()

            VerticalGridCombo_Settings.BestFit()

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
        Private Function LoadProductionInvoiceDefaults(DbContext As AdvantageFramework.Database.DbContext, SaveToAgency As Boolean, SaveToClients As Boolean, SaveToOneTime As Boolean) As Generic.List(Of AdvantageFramework.Database.Entities.ProductionInvoiceDefault)

            'objects
            Dim ProductionInvoiceDefaults As Generic.List(Of AdvantageFramework.Database.Entities.ProductionInvoiceDefault) = Nothing

            Try

                If _InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                    If SaveToAgency AndAlso SaveToOneTime Then

                        ProductionInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ProductionInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToAgency AndAlso SaveToOneTime = False Then

                        ProductionInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ProductionInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToOneTime Then

                        ProductionInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ProductionInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 2).ToList

                    Else

                        ProductionInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ProductionInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 2).ToList

                    End If

                ElseIf _InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.Agency Then

                    If SaveToClients AndAlso SaveToOneTime Then

                        ProductionInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ProductionInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToClients AndAlso SaveToOneTime = False Then

                        ProductionInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ProductionInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToClients = False AndAlso SaveToOneTime Then

                        ProductionInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ProductionInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1).ToList

                    Else

                        ProductionInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ProductionInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 1).ToList

                    End If

                ElseIf _InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.OneTime Then

                    If SaveToAgency AndAlso SaveToClients Then

                        ProductionInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ProductionInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients Then

                        ProductionInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ProductionInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToAgency AndAlso SaveToClients = False Then

                        ProductionInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ProductionInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients = False Then

                        ProductionInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ProductionInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0).ToList

                    End If

                End If

            Catch ex As Exception
                ProductionInvoiceDefaults = New Generic.List(Of AdvantageFramework.Database.Entities.ProductionInvoiceDefault)
            End Try

            If SaveToClients Then

                For Each ProductionInvoiceDefault In ProductionInvoiceDefaults.Where(Function(Entity) Entity.ClientOrDefault = 2).ToList

                    If _ClientCodes IsNot Nothing AndAlso _ClientCodes.Contains(ProductionInvoiceDefault.ClientCode) = False Then

                        ProductionInvoiceDefaults.Remove(ProductionInvoiceDefault)

                    End If

                Next

            End If

            If SaveToClients AndAlso _ClientCodes IsNot Nothing Then

                For Each ClientCode In _ClientCodes

                    If ProductionInvoiceDefaults.Any(Function(Entity) Entity.ClientOrDefault = 2 AndAlso Entity.ClientCode = ClientCode) = False Then

                        ProductionInvoiceDefaults.Add(New AdvantageFramework.Database.Entities.ProductionInvoiceDefault() With {.ClientOrDefault = 2,
                                                                                                                                .ClientCode = ClientCode})

                    End If

                Next

            End If

            LoadProductionInvoiceDefaults = ProductionInvoiceDefaults

        End Function
        Private Function LoadMediaInvoiceDefaults(DbContext As AdvantageFramework.Database.DbContext, SaveToAgency As Boolean, SaveToClients As Boolean, SaveToOneTime As Boolean) As Generic.List(Of AdvantageFramework.Database.Entities.MediaInvoiceDefault)

            'objects
            Dim MediaInvoiceDefaults As Generic.List(Of AdvantageFramework.Database.Entities.MediaInvoiceDefault) = Nothing

            Try

                If _InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                    If SaveToAgency AndAlso SaveToOneTime Then

                        MediaInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToAgency AndAlso SaveToOneTime = False Then

                        MediaInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToOneTime Then

                        MediaInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 2).ToList

                    Else

                        MediaInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 2).ToList

                    End If

                ElseIf _InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.Agency Then

                    If SaveToClients AndAlso SaveToOneTime Then

                        MediaInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToClients AndAlso SaveToOneTime = False Then

                        MediaInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToClients = False AndAlso SaveToOneTime Then

                        MediaInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1).ToList

                    Else

                        MediaInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 1).ToList

                    End If

                ElseIf _InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.OneTime Then

                    If SaveToAgency AndAlso SaveToClients Then

                        MediaInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients Then

                        MediaInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToAgency AndAlso SaveToClients = False Then

                        MediaInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients = False Then

                        MediaInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0).ToList

                    End If

                End If

            Catch ex As Exception
                MediaInvoiceDefaults = New Generic.List(Of AdvantageFramework.Database.Entities.MediaInvoiceDefault)
            End Try

            If SaveToClients Then

                For Each MediaInvoiceDefault In MediaInvoiceDefaults.Where(Function(Entity) Entity.ClientOrDefault = 2).ToList

                    If _ClientCodes IsNot Nothing AndAlso _ClientCodes.Contains(MediaInvoiceDefault.ClientCode) = False Then

                        MediaInvoiceDefaults.Remove(MediaInvoiceDefault)

                    End If

                Next

            End If

            If SaveToClients AndAlso _ClientCodes IsNot Nothing Then

                For Each ClientCode In _ClientCodes

                    If MediaInvoiceDefaults.Any(Function(Entity) Entity.ClientOrDefault = 2 AndAlso Entity.ClientCode = ClientCode) = False Then

                        MediaInvoiceDefaults.Add(New AdvantageFramework.Database.Entities.MediaInvoiceDefault() With {.ClientOrDefault = 2,
                                                                                                                      .ClientCode = ClientCode})

                    End If

                Next

            End If

            LoadMediaInvoiceDefaults = MediaInvoiceDefaults

        End Function
        Private Function LoadComboInvoiceDefaults(DbContext As AdvantageFramework.Database.DbContext, SaveToAgency As Boolean, SaveToClients As Boolean, SaveToOneTime As Boolean) As Generic.List(Of AdvantageFramework.Database.Entities.ComboInvoiceDefault)

            'objects
            Dim ComboInvoiceDefaults As Generic.List(Of AdvantageFramework.Database.Entities.ComboInvoiceDefault) = Nothing

            Try

                If _InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault Then

                    If SaveToAgency AndAlso SaveToOneTime Then

                        ComboInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ComboInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToAgency AndAlso SaveToOneTime = False Then

                        ComboInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ComboInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToOneTime Then

                        ComboInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ComboInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 2).ToList

                    Else

                        ComboInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ComboInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 2).ToList

                    End If

                ElseIf _InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.Agency Then

                    If SaveToClients AndAlso SaveToOneTime Then

                        ComboInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ComboInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToClients AndAlso SaveToOneTime = False Then

                        ComboInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ComboInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToClients = False AndAlso SaveToOneTime Then

                        ComboInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ComboInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1).ToList

                    Else

                        ComboInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ComboInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 1).ToList

                    End If

                ElseIf _InvoiceFormatType = InvoicePrinting.Methods.InvoiceFormatTypes.OneTime Then

                    If SaveToAgency AndAlso SaveToClients Then

                        ComboInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ComboInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients Then

                        ComboInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ComboInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 2).ToList

                    ElseIf SaveToAgency AndAlso SaveToClients = False Then

                        ComboInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ComboInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0 OrElse Entity.ClientOrDefault = 1).ToList

                    ElseIf SaveToAgency = False AndAlso SaveToClients = False Then

                        ComboInvoiceDefaults = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ComboInvoiceDefault).Where(Function(Entity) Entity.ClientOrDefault = 0).ToList

                    End If

                End If

            Catch ex As Exception
                ComboInvoiceDefaults = New Generic.List(Of AdvantageFramework.Database.Entities.ComboInvoiceDefault)
            End Try

            If SaveToClients Then

                For Each ComboInvoiceDefault In ComboInvoiceDefaults.Where(Function(Entity) Entity.ClientOrDefault = 2).ToList

                    If _ClientCodes IsNot Nothing AndAlso _ClientCodes.Contains(ComboInvoiceDefault.ClientCode) = False Then

                        ComboInvoiceDefaults.Remove(ComboInvoiceDefault)

                    End If

                Next

            End If

            If SaveToClients AndAlso _ClientCodes IsNot Nothing Then

                For Each ClientCode In _ClientCodes

                    If ComboInvoiceDefaults.Any(Function(Entity) Entity.ClientOrDefault = 2 AndAlso Entity.ClientCode = ClientCode) = False Then

                        ComboInvoiceDefaults.Add(New AdvantageFramework.Database.Entities.ComboInvoiceDefault() With {.ClientOrDefault = 2,
                                                                                                                         .ClientCode = ClientCode})

                    End If

                Next

            End If

            LoadComboInvoiceDefaults = ComboInvoiceDefaults

        End Function
        Private Sub SaveInvoiceDefaults(SaveToAgency As Boolean, SaveToClients As Boolean, SaveToOneTime As Boolean)

            'objects
            Dim ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
            Dim MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
            Dim ProductionInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting = Nothing
            Dim MediaInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _ProductionInvoiceSettings IsNot Nothing AndAlso _ProductionInvoiceSettings.Count > 0 Then

                    ProductionInvoiceSetting = _ProductionInvoiceSettings(0)

                    If ProductionInvoiceSetting IsNot Nothing Then

                        For Each ProductionInvoiceDefault In LoadProductionInvoiceDefaults(DbContext, SaveToAgency, SaveToClients, SaveToOneTime)

                            ProductionInvoiceSetting.Save(ProductionInvoiceDefault)

                        Next

                        If _InvoicePrintingSetting IsNot Nothing Then

                            ProductionInvoiceSetting.Save(_InvoicePrintingSetting)

                        End If

                    End If

                End If

                If _MediaInvoiceSettings IsNot Nothing AndAlso _MediaInvoiceSettings.Count > 0 Then

                    MediaInvoiceSetting = _MediaInvoiceSettings(0)

                    If MediaInvoiceSetting IsNot Nothing Then

                        For Each MediaInvoiceDefault In LoadMediaInvoiceDefaults(DbContext, SaveToAgency, SaveToClients, SaveToOneTime)

                            MediaInvoiceSetting.Save(MediaInvoiceDefault)

                        Next

                        If _InvoicePrintingMediaSetting IsNot Nothing Then

                            MediaInvoiceSetting.Save(_InvoicePrintingMediaSetting)

                        End If

                    End If

                End If

                Try

                    DbContext.SaveChanges()

                Catch ex As Exception

                End Try

            End Using

        End Sub
        Private Sub SaveInvoicePrintingSettings(SaveToAgency As Boolean, SaveToClients As Boolean, SaveToOneTime As Boolean)

            'objects
            Dim ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
            Dim MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
            Dim ProductionInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting = Nothing
            Dim MediaInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _ProductionInvoiceSettings IsNot Nothing AndAlso _ProductionInvoiceSettings.Count > 0 Then

                    ProductionInvoiceSetting = _ProductionInvoiceSettings(0)

                    If ProductionInvoiceSetting IsNot Nothing Then

                        For Each ProductionInvoiceDefault In LoadProductionInvoiceDefaults(DbContext, SaveToAgency, SaveToClients, SaveToOneTime)

                            ProductionInvoiceSetting.Save(ProductionInvoiceDefault)

                        Next

                    End If

                End If

                If _MediaInvoiceSettings IsNot Nothing AndAlso _MediaInvoiceSettings.Count > 0 Then

                    MediaInvoiceSetting = _MediaInvoiceSettings(0)

                    If MediaInvoiceSetting IsNot Nothing Then

                        For Each MediaInvoiceDefault In LoadMediaInvoiceDefaults(DbContext, SaveToAgency, SaveToClients, SaveToOneTime)

                            MediaInvoiceSetting.Save(MediaInvoiceDefault)

                        Next

                    End If

                End If

                Try

                    DbContext.SaveChanges()

                Catch ex As Exception

                End Try

            End Using

        End Sub
        Private Sub GetVerticalGridErrorMessage(ByVal VerticalGrid As DevExpress.XtraVerticalGrid.VGridControl, ByVal ParentRow As DevExpress.XtraVerticalGrid.Rows.BaseRow, ByRef ErrorMessage As String)

            'objects
            Dim RowErrorMessage As String = ""

            For Each Row As DevExpress.XtraVerticalGrid.Rows.BaseRow In ParentRow.ChildRows

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

            For Each Row As DevExpress.XtraVerticalGrid.Rows.BaseRow In VerticalGrid.Rows.OfType(Of DevExpress.XtraVerticalGrid.Rows.BaseRow).ToList

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
        Private Sub CheckAllValues(ByVal VerticalGrid As DevExpress.XtraVerticalGrid.VGridControl, ByVal PropertyDescriptions As Generic.List(Of System.ComponentModel.PropertyDescriptor), ByVal FieldName As String, ByVal NewColumnValue As Short)

            'objects
            Dim HasMoreThanOneRow As Boolean = False
            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim BaseRows As Generic.List(Of DevExpress.XtraVerticalGrid.Rows.BaseRow) = Nothing
            Dim ExtraRowCount As Integer = 0

            For ColumnValue As Short = 1 To 7 Step 1

                HasMoreThanOneRow = False
                ExtraRowCount = 0

                BaseRows = CheckColumnValue(VerticalGrid, PropertyDescriptions, FieldName, ColumnValue)

                If BaseRows IsNot Nothing Then

                    If ColumnValue = NewColumnValue Then

                        ExtraRowCount = 1

                    End If

                    HasMoreThanOneRow = (BaseRows.Count + ExtraRowCount > 1)

                    If HasMoreThanOneRow = False AndAlso BaseRows.Count = 0 AndAlso ExtraRowCount = 1 Then

                        VerticalGrid.SetRowError(VerticalGrid.FocusedRow.Properties, "")

                    End If

                    For Each BaseRow In BaseRows

                        If HasMoreThanOneRow = True Then

                            VerticalGrid.SetRowError(BaseRow.Properties, "Column " & NewColumnValue & " is already in use.")

                        Else

                            VerticalGrid.SetRowError(BaseRow.Properties, "")

                        End If

                    Next

                End If

            Next

            If NewColumnValue = 0 OrElse NewColumnValue = 8 Then

                VerticalGrid.SetRowError(VerticalGrid.FocusedRow.Properties, "")

            End If

        End Sub
        Private Function CheckColumnValue(ByVal VerticalGrid As DevExpress.XtraVerticalGrid.VGridControl, ByVal PropertyDescriptions As Generic.List(Of System.ComponentModel.PropertyDescriptor), ByVal FieldName As String, ByVal ColumnValue As Short) As Generic.List(Of DevExpress.XtraVerticalGrid.Rows.BaseRow)

            'objects
            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim BaseRows As Generic.List(Of DevExpress.XtraVerticalGrid.Rows.BaseRow) = Nothing

            BaseRows = New Generic.List(Of DevExpress.XtraVerticalGrid.Rows.BaseRow)

            If ColumnValue > 0 AndAlso ColumnValue < 8 Then

                For Each PropertyDescriptor In PropertyDescriptions

                    If PropertyDescriptor.Name <> FieldName Then

                        BaseRow = VerticalGrid.Rows.GetRowByFieldName(PropertyDescriptor.Name, True)

                        If BaseRow IsNot Nothing AndAlso BaseRow.Properties IsNot Nothing AndAlso BaseRow.Properties.Value = ColumnValue Then

                            BaseRows.Add(BaseRow)

                        End If

                    End If

                Next

            End If

            CheckColumnValue = BaseRows

        End Function
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
        Private Sub AddFormatHeaderToPrintout(ByRef CompositeLink As DevExpress.XtraPrintingLinks.CompositeLink, HeaderText As String)

            'objects
            Dim HeaderLink As AdvantageFramework.Reporting.Reports.CustomLink = Nothing

            HeaderLink = New AdvantageFramework.Reporting.Reports.CustomLink

            HeaderLink.Tag = HeaderText

            AddHandler HeaderLink.CreateDetailArea, AddressOf HeaderLink_CreateDetailArea

            CompositeLink.Links.Add(HeaderLink)

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

        Public Shared Function ShowFormDialog(InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes, InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting,
                                              InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting, InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting,
                                              ClientCodes As Generic.List(Of String), IsDraft As Boolean, ShowProductionOptions As Boolean, ShowMagazineOptions As Boolean, ShowNewspaperOptions As Boolean,
                                              ShowInternetOptions As Boolean, ShowOutdoorOptions As Boolean, ShowRadioOptions As Boolean, ShowTVOptions As Boolean, ShowComboOptions As Boolean,
                                              HasSelectedInvoice As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim InvoicePrintingOptionsDialog As InvoicePrintingOptionsDialog = Nothing

            InvoicePrintingOptionsDialog = New InvoicePrintingOptionsDialog(InvoiceFormatType, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting, ClientCodes, IsDraft,
                                                                            ShowProductionOptions, ShowMagazineOptions, ShowNewspaperOptions, ShowInternetOptions, ShowOutdoorOptions, ShowRadioOptions,
                                                                            ShowTVOptions, ShowComboOptions, HasSelectedInvoice)

            ShowFormDialog = InvoicePrintingOptionsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub InvoicePrintingOptionsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
            Dim MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
            Dim ComboInvoiceDefault As AdvantageFramework.Database.Entities.ComboInvoiceDefault = Nothing
            Dim ProductionInvoiceDefaultID As Integer = 0
            Dim MediaInvoiceDefaultID As Integer = 0
            Dim ComboInvoiceDefaultID As Integer = 0
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemSaveOptions_Agency.Image = AdvantageFramework.My.Resources.AgencyImage
            ButtonItemSaveOptions_Clients.Image = AdvantageFramework.My.Resources.ClientImage
            ButtonItemSaveOptions_OneTime.Image = AdvantageFramework.My.Resources.InvoicePropertiesImage
            ButtonItemSaveOptions_Products.Image = AdvantageFramework.My.Resources.ProductImage

            If _InvoiceFormatType = InvoicePrinting.InvoiceFormatTypes.ClientDefault Then

                If _ClientCodes IsNot Nothing AndAlso _ClientCodes.Count = 1 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _ClientCodes(0))

                    End Using

                    If Client IsNot Nothing Then

                        LabelForm_Format.Text = "Client - " & Client.Name & " Standard Format"

                    Else

                        LabelForm_Format.Text = "Client - " & _ClientCodes(0) & " Standard Format"

                    End If

                Else

                    LabelForm_Format.Text = "Agency Standard Format"

                End If

                ButtonItemSaveOptions_Clients.Checked = True
                ButtonItemSaveOptions_Clients.Visible = False

                ButtonItemSaveOptions_Agency.Visible = True
                ButtonItemSaveOptions_OneTime.Visible = True

            ElseIf _InvoiceFormatType = InvoicePrinting.InvoiceFormatTypes.Agency Then

                LabelForm_Format.Text = "Agency Standard Format"

                ButtonItemSaveOptions_Clients.Visible = True
                ButtonItemSaveOptions_OneTime.Visible = True

                ButtonItemSaveOptions_Agency.Checked = True
                ButtonItemSaveOptions_Agency.Visible = False

            ElseIf _InvoiceFormatType = InvoicePrinting.InvoiceFormatTypes.OneTime Then

                LabelForm_Format.Text = "One-Time Format"

                ButtonItemSaveOptions_Clients.Visible = True
                ButtonItemSaveOptions_Agency.Visible = True

                ButtonItemSaveOptions_OneTime.Checked = True
                ButtonItemSaveOptions_OneTime.Visible = False

            End If

            ButtonItemSaveOptions_Products.Visible = False

            VerticalGridProduction_Settings.OptionsBehavior.Editable = True
            VerticalGridProduction_Settings.OptionsView.ShowRootCategories = True
            VerticalGridProduction_Settings.OptionsBehavior.UseDefaultEditorsCollection = True
            VerticalGridProduction_Settings.OptionsBehavior.RecordsMouseWheel = False

            VerticalGridMedia_Settings.OptionsBehavior.Editable = True
            VerticalGridMedia_Settings.OptionsView.ShowRootCategories = True
            VerticalGridMedia_Settings.OptionsBehavior.UseDefaultEditorsCollection = True
            VerticalGridMedia_Settings.OptionsBehavior.RecordsMouseWheel = False

            VerticalGridMagazine_Settings.OptionsBehavior.Editable = True
            VerticalGridMagazine_Settings.OptionsView.ShowRootCategories = True
            VerticalGridMagazine_Settings.OptionsBehavior.UseDefaultEditorsCollection = True
            VerticalGridMagazine_Settings.OptionsBehavior.RecordsMouseWheel = False

            VerticalGridNewspaper_Settings.OptionsBehavior.Editable = True
            VerticalGridNewspaper_Settings.OptionsView.ShowRootCategories = True
            VerticalGridNewspaper_Settings.OptionsBehavior.UseDefaultEditorsCollection = True
            VerticalGridProduction_Settings.OptionsBehavior.RecordsMouseWheel = False

            VerticalGridInternet_Settings.OptionsBehavior.Editable = True
            VerticalGridInternet_Settings.OptionsView.ShowRootCategories = True
            VerticalGridInternet_Settings.OptionsBehavior.UseDefaultEditorsCollection = True
            VerticalGridInternet_Settings.OptionsBehavior.RecordsMouseWheel = False

            VerticalGridOutdoor_Settings.OptionsBehavior.Editable = True
            VerticalGridOutdoor_Settings.OptionsView.ShowRootCategories = True
            VerticalGridOutdoor_Settings.OptionsBehavior.UseDefaultEditorsCollection = True
            VerticalGridOutdoor_Settings.OptionsBehavior.RecordsMouseWheel = False

            VerticalGridRadio_Settings.OptionsBehavior.Editable = True
            VerticalGridRadio_Settings.OptionsView.ShowRootCategories = True
            VerticalGridRadio_Settings.OptionsBehavior.UseDefaultEditorsCollection = True
            VerticalGridRadio_Settings.OptionsBehavior.RecordsMouseWheel = False

            VerticalGridTV_Settings.OptionsBehavior.Editable = True
            VerticalGridTV_Settings.OptionsView.ShowRootCategories = True
            VerticalGridTV_Settings.OptionsBehavior.UseDefaultEditorsCollection = True
            VerticalGridTV_Settings.OptionsBehavior.RecordsMouseWheel = False

            VerticalGridCombo_Settings.OptionsBehavior.Editable = True
            VerticalGridCombo_Settings.OptionsView.ShowRootCategories = True
            VerticalGridCombo_Settings.OptionsBehavior.UseDefaultEditorsCollection = True
            VerticalGridCombo_Settings.OptionsBehavior.RecordsMouseWheel = False

            TabItemOptions_ProductionTab.Visible = _ShowProductionOptions
            TabItemOptions_MediaTab.Visible = (_ShowMagazineOptions OrElse _ShowNewspaperOptions OrElse _ShowInternetOptions OrElse _ShowOutdoorOptions OrElse _ShowRadioOptions OrElse _ShowTVOptions)
            TabItemOptions_MagazineTab.Visible = _ShowMagazineOptions
            TabItemOptions_NewspaperTab.Visible = _ShowNewspaperOptions
            TabItemOptions_InternetTab.Visible = _ShowInternetOptions
            TabItemOptions_OutdoorTab.Visible = _ShowOutdoorOptions
            TabItemOptions_RadioTab.Visible = _ShowRadioOptions
            TabItemOptions_TVTab.Visible = _ShowTVOptions
            TabItemOptions_ComboTab.Visible = _ShowComboOptions

            If TabItemOptions_ComboTab.Visible Then

                TabControlForm_Options.SelectedTab = TabItemOptions_ComboTab

            ElseIf TabItemOptions_ProductionTab.Visible Then

                TabControlForm_Options.SelectedTab = TabItemOptions_ProductionTab

            ElseIf TabItemOptions_MediaTab.Visible Then

                TabControlForm_Options.SelectedTab = TabItemOptions_MediaTab

            End If

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _InvoicePrintingSetting IsNot Nothing Then

                    ProductionInvoiceDefaultID = _InvoicePrintingSetting.ProductionInvoicePrintingOptionsID.GetValueOrDefault(0)

                    Try

                        ProductionInvoiceDefault = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ProductionInvoiceDefault).SingleOrDefault(Function(Entity) Entity.ID = ProductionInvoiceDefaultID)

                    Catch ex As Exception
                        ProductionInvoiceDefault = Nothing
                    End Try

                    If ProductionInvoiceDefault IsNot Nothing Then

                        _InvoicePrintingSetting.LocationCode = ProductionInvoiceDefault.LocationCode

                    End If

                End If

                If _InvoicePrintingMediaSetting IsNot Nothing Then

                    MediaInvoiceDefaultID = _InvoicePrintingMediaSetting.MediaInvoiceSettingID.GetValueOrDefault(0)

                    Try

                        MediaInvoiceDefault = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaInvoiceDefault).SingleOrDefault(Function(Entity) Entity.ID = MediaInvoiceDefaultID)

                    Catch ex As Exception
                        MediaInvoiceDefault = Nothing
                    End Try

                    If MediaInvoiceDefault IsNot Nothing Then

                        _InvoicePrintingMediaSetting.LocationCode = MediaInvoiceDefault.LocationCode

                    End If

                End If

                If _InvoicePrintingComboSetting IsNot Nothing Then

                    ComboInvoiceDefaultID = _InvoicePrintingComboSetting.ComboInvoicePrintingOptionsID.GetValueOrDefault(0)

                    Try

                        ComboInvoiceDefault = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ComboInvoiceDefault).SingleOrDefault(Function(Entity) Entity.ID = ComboInvoiceDefaultID)

                    Catch ex As Exception
                        ComboInvoiceDefault = Nothing
                    End Try

                    If ComboInvoiceDefault IsNot Nothing Then

                        _InvoicePrintingComboSetting.LocationCode = ComboInvoiceDefault.LocationCode

                    End If

                End If

            End Using

            Try

                LoadProductionOptions()

            Catch ex As Exception

            End Try

            Try

                LoadMediaOptions()

            Catch ex As Exception

            End Try

            Try

                LoadComboOptions()

            Catch ex As Exception

            End Try

            Try

                LoadProductionTab()

                LoadMediaTab()

                LoadComboTab()

                LoadMagazineTab()

                LoadNewspaperTab()

                LoadInternetTab()

                LoadOutdoorTab()

                LoadRadioTab()

                LoadTVTab()

            Catch ex As Exception

            End Try

            If TabItemOptions_ComboTab.Visible Then

                rowLocationCode.Enabled = (_HasSelectedInvoice = False)
                rowUseLocationPrintOptions.Enabled = (_HasSelectedInvoice = False)
                rowLocationCode.Enabled = (_HasSelectedInvoice = False)
                rowCustomInvoiceID.Enabled = (_HasSelectedInvoice = False)
                rowApplyExchangeRate.Enabled = (_HasSelectedInvoice = False)
                rowExchangeRateAmount.Enabled = (_HasSelectedInvoice = False)
                rowHideExchangeRateMessage.Enabled = (_HasSelectedInvoice = False)
                rowAddressBlockType.Enabled = (_HasSelectedInvoice = False)
                rowPrintClientName.Enabled = (_HasSelectedInvoice = False)
                rowPrintDivisionName.Enabled = (_HasSelectedInvoice = False)
                rowPrintProductDescription.Enabled = (_HasSelectedInvoice = False)
                rowPrintContactAfterAddress.Enabled = (_HasSelectedInvoice = False)
                rowContactType.Enabled = (_HasSelectedInvoice = False)
                rowShowCodes.Enabled = (_HasSelectedInvoice = False)
                rowInvoiceFooterCommentType.Enabled = (_HasSelectedInvoice = False)
                rowInvoiceFooterComment.Enabled = (_HasSelectedInvoice = False)
                rowUseInvoiceCategoryDescription.Enabled = (_HasSelectedInvoice = False)
                rowInvoiceTitle.Enabled = (_HasSelectedInvoice = False)

                rowIncludeInvoiceDueDate.Enabled = (_HasSelectedInvoice = False)
                'rowIncludeClientReference.Enabled = (_HasSelectedInvoice = False)
                'rowClientRefLocation.Enabled = (_HasSelectedInvoice = False)
                'rowIncludeClientPO.Enabled = (_HasSelectedInvoice = False)
                'rowIncludeAccountExecutive.Enabled = (_HasSelectedInvoice = False)
                'rowClientPOLocation.Enabled = (_HasSelectedInvoice = False)
                'rowIncludeSalesClass.Enabled = (_HasSelectedInvoice = False)
                'rowSalesClassLocation.Enabled = (_HasSelectedInvoice = False)
                'rowShowCampaign.Enabled = (_HasSelectedInvoice = False)
                'rowCampaignLocation.Enabled = (_HasSelectedInvoice = False)

                rowIncludeBackupReport.Enabled = (_HasSelectedInvoice = False)
                rowBackupReportColumnOption.Enabled = (_HasSelectedInvoice = False)
                rowBackupReportCommentOptionEmployeeTimeFunction.Enabled = (_HasSelectedInvoice = False)
                rowBackupReportCommentOptionAccountsPayableFunction.Enabled = (_HasSelectedInvoice = False)
                rowBackupReportCommentOptionIncomeOnlyFunction.Enabled = (_HasSelectedInvoice = False)
                rowBackupReportBreakupByJobComponent.Enabled = (_HasSelectedInvoice = False)

                rowUseLocationPrintOptions1.Enabled = (_HasSelectedInvoice = False)
                rowLocationCode1.Enabled = (_HasSelectedInvoice = False)
                rowApplyExchangeRate1.Enabled = (_HasSelectedInvoice = False)
                rowExchangeRateAmount1.Enabled = (_HasSelectedInvoice = False)
                rowHideExchangeRateMessage1.Enabled = (_HasSelectedInvoice = False)
                rowAddressBlockType1.Enabled = (_HasSelectedInvoice = False)
                rowPrintClientName1.Enabled = (_HasSelectedInvoice = False)
                rowPrintDivisionName1.Enabled = (_HasSelectedInvoice = False)
                rowPrintProductDescription1.Enabled = (_HasSelectedInvoice = False)
                rowPrintContactAfterAddress1.Enabled = (_HasSelectedInvoice = False)
                rowContactType1.Enabled = (_HasSelectedInvoice = False)
                rowShowCodes1.Enabled = (_HasSelectedInvoice = False)
                rowInvoiceFooterCommentType1.Enabled = (_HasSelectedInvoice = False)
                rowInvoiceFooterComment1.Enabled = (_HasSelectedInvoice = False)

                rowMagazineUseInvoiceCategoryDescription.Enabled = (_HasSelectedInvoice = False)
                rowMagazineInvoiceTitle.Enabled = (_HasSelectedInvoice = False)
                rowMagazinePrintInvoiceDueDate.Enabled = (_HasSelectedInvoice = False)
                rowMagazineCustomInvoiceID.Enabled = (_HasSelectedInvoice = False)
                'rowMagazineShowClientPO.Enabled = (_HasSelectedInvoice = False)
                'rowMagazineClientPOLocation.Enabled = (_HasSelectedInvoice = False)
                'rowMagazineShowSalesClass.Enabled = (_HasSelectedInvoice = False)
                'rowMagazineSalesClassLocation.Enabled = (_HasSelectedInvoice = False)
                'rowMagazineShowCampaign.Enabled = (_HasSelectedInvoice = False)
                'rowMagazineCampaignLocation.Enabled = (_HasSelectedInvoice = False)

                rowNewspaperUseInvoiceCategoryDescription.Enabled = (_HasSelectedInvoice = False)
                rowNewspaperInvoiceTitle.Enabled = (_HasSelectedInvoice = False)
                rowNewspaperPrintInvoiceDueDate.Enabled = (_HasSelectedInvoice = False)
                rowNewspaperCustomInvoiceID.Enabled = (_HasSelectedInvoice = False)
                'rowNewspaperShowClientPO.Enabled = (_HasSelectedInvoice = False)
                'rowNewspaperClientPOLocation.Enabled = (_HasSelectedInvoice = False)
                'rowNewspaperShowSalesClass.Enabled = (_HasSelectedInvoice = False)
                'rowNewspaperSalesClassLocation.Enabled = (_HasSelectedInvoice = False)
                'rowNewspaperShowCampaign.Enabled = (_HasSelectedInvoice = False)
                'rowNewspaperCampaignLocation.Enabled = (_HasSelectedInvoice = False)

                rowInternetUseInvoiceCategoryDescription.Enabled = (_HasSelectedInvoice = False)
                rowInternetInvoiceTitle.Enabled = (_HasSelectedInvoice = False)
                rowInternetPrintInvoiceDueDate.Enabled = (_HasSelectedInvoice = False)
                rowInternetCustomInvoiceID.Enabled = (_HasSelectedInvoice = False)
                'rowInternetShowClientPO.Enabled = (_HasSelectedInvoice = False)
                'rowInternetClientPOLocation.Enabled = (_HasSelectedInvoice = False)
                'rowInternetShowSalesClass.Enabled = (_HasSelectedInvoice = False)
                'rowInternetSalesClassLocation.Enabled = (_HasSelectedInvoice = False)
                'rowInternetShowCampaign.Enabled = (_HasSelectedInvoice = False)
                'rowInternetCampaignLocation.Enabled = (_HasSelectedInvoice = False)

                rowOutdoorUseInvoiceCategoryDescription.Enabled = (_HasSelectedInvoice = False)
                rowOutdoorInvoiceTitle.Enabled = (_HasSelectedInvoice = False)
                rowOutdoorPrintInvoiceDueDate.Enabled = (_HasSelectedInvoice = False)
                rowOutdoorCustomInvoiceID.Enabled = (_HasSelectedInvoice = False)
                'rowOutdoorShowClientPO.Enabled = (_HasSelectedInvoice = False)
                'rowOutdoorClientPOLocation.Enabled = (_HasSelectedInvoice = False)
                'rowOutdoorShowSalesClass.Enabled = (_HasSelectedInvoice = False)
                'rowOutdoorSalesClassLocation.Enabled = (_HasSelectedInvoice = False)
                'rowOutdoorShowCampaign.Enabled = (_HasSelectedInvoice = False)
                'rowOutdoorCampaignLocation.Enabled = (_HasSelectedInvoice = False)

                rowRadioUseInvoiceCategoryDescription.Enabled = (_HasSelectedInvoice = False)
                rowRadioInvoiceTitle.Enabled = (_HasSelectedInvoice = False)
                rowRadioPrintInvoiceDueDate.Enabled = (_HasSelectedInvoice = False)
                rowRadioCustomInvoiceID.Enabled = (_HasSelectedInvoice = False)
                'rowRadioShowClientPO.Enabled = (_HasSelectedInvoice = False)
                'rowRadioClientPOLocation.Enabled = (_HasSelectedInvoice = False)
                'rowRadioShowSalesClass.Enabled = (_HasSelectedInvoice = False)
                'rowRadioSalesClassLocation.Enabled = (_HasSelectedInvoice = False)
                'rowRadioShowCampaign.Enabled = (_HasSelectedInvoice = False)
                'rowRadioCampaignLocation.Enabled = (_HasSelectedInvoice = False)

                rowTVUseInvoiceCategoryDescription.Enabled = (_HasSelectedInvoice = False)
                rowTVInvoiceTitle.Enabled = (_HasSelectedInvoice = False)
                rowTVPrintInvoiceDueDate.Enabled = (_HasSelectedInvoice = False)
                rowTVCustomInvoiceID.Enabled = (_HasSelectedInvoice = False)
                'rowTVShowClientPO.Enabled = (_HasSelectedInvoice = False)
                'rowTVClientPOLocation.Enabled = (_HasSelectedInvoice = False)
                'rowTVShowSalesClass.Enabled = (_HasSelectedInvoice = False)
                'rowTVSalesClassLocation.Enabled = (_HasSelectedInvoice = False)
                'rowTVShowCampaign.Enabled = (_HasSelectedInvoice = False)
                'rowTVCampaignLocation.Enabled = (_HasSelectedInvoice = False)

            End If

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext) Then

                    rowComboApplyExchangeRate.Visible = False
                    rowComboExchangeRateAmount.Visible = False

                    rowApplyExchangeRate.Visible = False
                    rowExchangeRateAmount.Visible = False

                    rowApplyExchangeRate1.Visible = False
                    rowExchangeRateAmount1.Visible = False

                End If

            End Using

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub InvoicePrintingOptionsDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            RibbonBarOptions_SaveOptions.ResetCachedContentSize()

            RibbonBarOptions_SaveOptions.Refresh()

            RibbonBarOptions_SaveOptions.Width = RibbonBarOptions_Actions.GetAutoSizeWidth

            RibbonBarOptions_SaveOptions.Refresh()

        End Sub
        Private Sub InvoicePrintingOptionsDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub InvoicePrintingOptionsDialog_UserEntryChangedEvent(ByVal Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

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

            If TabControlForm_Options.SelectedTab Is TabItemOptions_ComboTab Then

                Description = "Combo Settings"

            ElseIf TabControlForm_Options.SelectedTab Is TabItemOptions_ProductionTab Then

                Description = "Production Settings"

            ElseIf TabControlForm_Options.SelectedTab Is TabItemOptions_MediaTab Then

                Description = "Media Settings"

            ElseIf TabControlForm_Options.SelectedTab Is TabItemOptions_MagazineTab Then

                Description = "Magazine Settings"

            ElseIf TabControlForm_Options.SelectedTab Is TabItemOptions_NewspaperTab Then

                Description = "Newspaper Settings"

            ElseIf TabControlForm_Options.SelectedTab Is TabItemOptions_InternetTab Then

                Description = "Internet Settings"

            ElseIf TabControlForm_Options.SelectedTab Is TabItemOptions_OutdoorTab Then

                Description = "Outdoor Settings"

            ElseIf TabControlForm_Options.SelectedTab Is TabItemOptions_RadioTab Then

                Description = "Radio Settings"

            ElseIf TabControlForm_Options.SelectedTab Is TabItemOptions_TVTab Then

                Description = "TV Settings"

            End If

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

            If TabControlForm_Options.SelectedTab Is TabItemOptions_ComboTab Then

                AddVerticalGridToPrintout(CompositeLink, VerticalGridCombo_Settings, "Combo Settings")
                AddVerticalGridToPrintout(CompositeLink, VerticalGridProduction_Settings, "Production Settings")
                AddVerticalGridToPrintout(CompositeLink, VerticalGridMedia_Settings, "Media Settings")
                AddVerticalGridToPrintout(CompositeLink, VerticalGridMagazine_Settings, "Magazine Settings")
                AddVerticalGridToPrintout(CompositeLink, VerticalGridNewspaper_Settings, "Newspaper Settings")
                AddVerticalGridToPrintout(CompositeLink, VerticalGridInternet_Settings, "Internet Settings")
                AddVerticalGridToPrintout(CompositeLink, VerticalGridOutdoor_Settings, "Outdoor Settings")
                AddVerticalGridToPrintout(CompositeLink, VerticalGridRadio_Settings, "Radio Settings")
                AddVerticalGridToPrintout(CompositeLink, VerticalGridTV_Settings, "TV Settings")

            ElseIf TabControlForm_Options.SelectedTab Is TabItemOptions_ProductionTab Then

                AddVerticalGridToPrintout(CompositeLink, VerticalGridProduction_Settings, "Production Settings")

            ElseIf TabControlForm_Options.SelectedTab Is TabItemOptions_MediaTab Then

                AddVerticalGridToPrintout(CompositeLink, VerticalGridMedia_Settings, "Media Settings")
                AddVerticalGridToPrintout(CompositeLink, VerticalGridMagazine_Settings, "Magazine Settings")
                AddVerticalGridToPrintout(CompositeLink, VerticalGridNewspaper_Settings, "Newspaper Settings")
                AddVerticalGridToPrintout(CompositeLink, VerticalGridInternet_Settings, "Internet Settings")
                AddVerticalGridToPrintout(CompositeLink, VerticalGridOutdoor_Settings, "Outdoor Settings")
                AddVerticalGridToPrintout(CompositeLink, VerticalGridRadio_Settings, "Radio Settings")
                AddVerticalGridToPrintout(CompositeLink, VerticalGridTV_Settings, "TV Settings")

            ElseIf TabControlForm_Options.SelectedTab Is TabItemOptions_MagazineTab Then

                AddVerticalGridToPrintout(CompositeLink, VerticalGridMedia_Settings, "Media Settings")
                AddVerticalGridToPrintout(CompositeLink, VerticalGridMagazine_Settings, "Magazine Settings")

            ElseIf TabControlForm_Options.SelectedTab Is TabItemOptions_NewspaperTab Then

                AddVerticalGridToPrintout(CompositeLink, VerticalGridMedia_Settings, "Media Settings")
                AddVerticalGridToPrintout(CompositeLink, VerticalGridNewspaper_Settings, "Newspaper Settings")

            ElseIf TabControlForm_Options.SelectedTab Is TabItemOptions_InternetTab Then

                AddVerticalGridToPrintout(CompositeLink, VerticalGridMedia_Settings, "Media Settings")
                AddVerticalGridToPrintout(CompositeLink, VerticalGridInternet_Settings, "Internet Settings")

            ElseIf TabControlForm_Options.SelectedTab Is TabItemOptions_OutdoorTab Then

                AddVerticalGridToPrintout(CompositeLink, VerticalGridMedia_Settings, "Media Settings")
                AddVerticalGridToPrintout(CompositeLink, VerticalGridOutdoor_Settings, "Outdoor Settings")

            ElseIf TabControlForm_Options.SelectedTab Is TabItemOptions_RadioTab Then

                AddVerticalGridToPrintout(CompositeLink, VerticalGridMedia_Settings, "Media Settings")
                AddVerticalGridToPrintout(CompositeLink, VerticalGridRadio_Settings, "Radio Settings")

            ElseIf TabControlForm_Options.SelectedTab Is TabItemOptions_TVTab Then

                AddVerticalGridToPrintout(CompositeLink, VerticalGridMedia_Settings, "Media Settings")
                AddVerticalGridToPrintout(CompositeLink, VerticalGridTV_Settings, "TV Settings")

            End If

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
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ProductionInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting = Nothing
            Dim MediaInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting = Nothing
            Dim ComboInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting = Nothing
            Dim ProductionInvoiceDefaults As Generic.List(Of AdvantageFramework.Database.Entities.ProductionInvoiceDefault) = Nothing
            Dim MediaInvoiceDefaults As Generic.List(Of AdvantageFramework.Database.Entities.MediaInvoiceDefault) = Nothing
            Dim ComboInvoiceDefaults As Generic.List(Of AdvantageFramework.Database.Entities.ComboInvoiceDefault) = Nothing
            Dim ErrorMessage As String = ""

            VerticalGridProduction_Settings.CloseEditor()
            VerticalGridMedia_Settings.CloseEditor()
            VerticalGridMagazine_Settings.CloseEditor()
            VerticalGridNewspaper_Settings.CloseEditor()
            VerticalGridInternet_Settings.CloseEditor()
            VerticalGridOutdoor_Settings.CloseEditor()
            VerticalGridRadio_Settings.CloseEditor()
            VerticalGridTV_Settings.CloseEditor()
            VerticalGridCombo_Settings.CloseEditor()

            If VerticalGridProduction_Settings.HasRowErrors = False AndAlso VerticalGridMedia_Settings.HasRowErrors = False AndAlso
                    VerticalGridMagazine_Settings.HasRowErrors = False AndAlso VerticalGridNewspaper_Settings.HasRowErrors = False AndAlso
                    VerticalGridInternet_Settings.HasRowErrors = False AndAlso VerticalGridOutdoor_Settings.HasRowErrors = False AndAlso
                    VerticalGridRadio_Settings.HasRowErrors = False AndAlso VerticalGridTV_Settings.HasRowErrors = False AndAlso
                    VerticalGridCombo_Settings.HasRowErrors = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If _ShowProductionOptions AndAlso _ProductionInvoiceSettings IsNot Nothing AndAlso _ProductionInvoiceSettings.Count > 0 Then

                        ProductionInvoiceSetting = _ProductionInvoiceSettings(0)

                        If ProductionInvoiceSetting IsNot Nothing Then

                            For Each ProductionInvoiceDefault In LoadProductionInvoiceDefaults(DbContext, ButtonItemSaveOptions_Agency.Checked, ButtonItemSaveOptions_Clients.Checked, ButtonItemSaveOptions_OneTime.Checked)

                                If ProductionInvoiceDefault.IsEntityBeingAdded() Then

                                    DbContext.ProductionInvoiceDefaults.Add(ProductionInvoiceDefault)

                                Else

                                    DbContext.UpdateObject(ProductionInvoiceDefault)

                                End If

                                ProductionInvoiceSetting.Save(ProductionInvoiceDefault)

                            Next

                            If _InvoicePrintingSetting IsNot Nothing Then

                                ProductionInvoiceSetting.Save(_InvoicePrintingSetting)

                            End If

                        End If

                    End If

                    If (_ShowInternetOptions OrElse _ShowMagazineOptions OrElse _ShowNewspaperOptions OrElse _ShowOutdoorOptions OrElse _ShowRadioOptions OrElse _ShowTVOptions) AndAlso
                            _MediaInvoiceSettings IsNot Nothing AndAlso _MediaInvoiceSettings.Count > 0 Then

                        MediaInvoiceSetting = _MediaInvoiceSettings(0)

                        If MediaInvoiceSetting IsNot Nothing Then

                            For Each MediaInvoiceDefault In LoadMediaInvoiceDefaults(DbContext, ButtonItemSaveOptions_Agency.Checked, ButtonItemSaveOptions_Clients.Checked, ButtonItemSaveOptions_OneTime.Checked)

                                If MediaInvoiceDefault.IsEntityBeingAdded() Then

                                    DbContext.MediaInvoiceDefaults.Add(MediaInvoiceDefault)

                                Else

                                    DbContext.UpdateObject(MediaInvoiceDefault)

                                End If

                                MediaInvoiceSetting.Save(MediaInvoiceDefault)

                            Next

                            If _InvoicePrintingMediaSetting IsNot Nothing Then

                                MediaInvoiceSetting.Save(_InvoicePrintingMediaSetting)

                            End If

                        End If

                    End If

                    If _ShowComboOptions AndAlso _ComboInvoiceSettings IsNot Nothing AndAlso _ComboInvoiceSettings.Count > 0 Then

                        ComboInvoiceSetting = _ComboInvoiceSettings(0)

                        If ComboInvoiceSetting IsNot Nothing Then

                            For Each ComboInvoiceDefault In LoadComboInvoiceDefaults(DbContext, ButtonItemSaveOptions_Agency.Checked, ButtonItemSaveOptions_Clients.Checked, ButtonItemSaveOptions_OneTime.Checked)

                                If ComboInvoiceDefault.ID = 0 Then

                                    DbContext.ComboInvoiceDefaults.Add(ComboInvoiceDefault)

                                Else

                                    DbContext.Entry(ComboInvoiceDefault).State = Entity.EntityState.Modified

                                End If

                                ComboInvoiceSetting.Save(ComboInvoiceDefault)

                            Next

                            If _InvoicePrintingComboSetting IsNot Nothing Then

                                ComboInvoiceSetting.Save(_InvoicePrintingComboSetting)

                            End If

                        End If

                    End If

                    Try

                        DbContext.SaveChanges()

                    Catch ex As Exception

                    End Try

                End Using

                Me.ClearChanged()

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                GetVerticalGridErrorMessage(VerticalGridProduction_Settings, ErrorMessage)
                GetVerticalGridErrorMessage(VerticalGridMedia_Settings, ErrorMessage)
                GetVerticalGridErrorMessage(VerticalGridMagazine_Settings, ErrorMessage)
                GetVerticalGridErrorMessage(VerticalGridNewspaper_Settings, ErrorMessage)
                GetVerticalGridErrorMessage(VerticalGridInternet_Settings, ErrorMessage)
                GetVerticalGridErrorMessage(VerticalGridOutdoor_Settings, ErrorMessage)
                GetVerticalGridErrorMessage(VerticalGridRadio_Settings, ErrorMessage)
                GetVerticalGridErrorMessage(VerticalGridTV_Settings, ErrorMessage)
                GetVerticalGridErrorMessage(VerticalGridCombo_Settings, ErrorMessage)

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
            Dim CustomInvoice As AdvantageFramework.Reporting.Database.Entities.CustomInvoice = Nothing

            Try

                If e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.UseLocationPrintOptions.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.LocationCode.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = Nothing

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.ApplyExchangeRate.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.ExchangeRateAmount.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 1

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.UseInvoiceCategoryDescription.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.InvoiceTitle.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.GroupingOptionType.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.GroupingOptionInsideDescription.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = AdvantageFramework.InvoicePrinting.GroupingOptionTypes.InsideOutsideAndFunction OrElse e.Value = AdvantageFramework.InvoicePrinting.GroupingOptionTypes.InsideOutsideTotalOnly Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.GroupingOptionOutsideDescription.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = AdvantageFramework.InvoicePrinting.GroupingOptionTypes.InsideOutsideAndFunction OrElse e.Value = AdvantageFramework.InvoicePrinting.GroupingOptionTypes.InsideOutsideTotalOnly Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.InvoiceFooterCommentType.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.InvoiceFooterComment.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = AdvantageFramework.InvoicePrinting.InvoiceFooterCommentTypes.UserDefined Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = Nothing

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.IncludeBackupReport.ToString Then

                    Try

                        BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.BackupReportColumnOption.ToString, True)

                    Catch ex As Exception
                        BaseRow = Nothing
                    End Try

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = e.Value

                    End If

                    Try

                        BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.BackupReportCommentOptionEmployeeTimeFunction.ToString, True)

                    Catch ex As Exception
                        BaseRow = Nothing
                    End Try

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = e.Value

                    End If

                    Try

                        BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.BackupReportCommentOptionAccountsPayableFunction.ToString, True)

                    Catch ex As Exception
                        BaseRow = Nothing
                    End Try

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = e.Value

                    End If

                    Try

                        BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.BackupReportCommentOptionIncomeOnlyFunction.ToString, True)

                    Catch ex As Exception
                        BaseRow = Nothing
                    End Try

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = e.Value

                    End If

                    Try

                        BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.BreakupByJobComponent.ToString, True)

                    Catch ex As Exception
                        BaseRow = Nothing
                    End Try

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = e.Value

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.CustomInvoiceID.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.ReportFormatType.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If IsNumeric(e.Value) AndAlso CInt(e.Value) > 0 Then

                            Try

                                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                    CustomInvoice = AdvantageFramework.Reporting.Database.Procedures.CustomInvoice.LoadByCustomInvoiceID(ReportingDbContext, CInt(e.Value))

                                End Using

                            Catch ex As Exception
                                CustomInvoice = Nothing
                            End Try

                            If CustomInvoice IsNot Nothing Then

                                CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = CShort(CustomInvoice.Type)

                            End If

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.HideJobInfo.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.HideComponentNumberAndDescription.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.TotalsShowTaxSeparately.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.TaxTotalLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.IncludeClientPO.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.ClientPOLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.IncludeClientReference.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.ClientRefLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.IncludeSalesClass.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.SalesClassLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.ShowCampaign.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.CampaignLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.AddressBlockType.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.ContactType.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 4 AndAlso CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 1 Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.ContactType.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.AddressBlockType.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 1 AndAlso CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 4 Then

                            VerticalGridProduction_Settings.ActiveEditor.EditValue = VerticalGridProduction_Settings.ActiveEditor.OldEditValue
                            CType(e.Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = VerticalGridProduction_Settings.ActiveEditor.OldEditValue
                            VerticalGridProduction_Settings.RefreshDataSource()

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.SummaryLevel.ToString Then

                    BaseRow = VerticalGridProduction_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting.Properties.TotalsShowBillingHistory.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = AdvantageFramework.InvoicePrinting.SummaryLevels.Job OrElse
                                e.Value = AdvantageFramework.InvoicePrinting.SummaryLevels.Invoice Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        End If

                    End If

                End If

                'VerticalGridForm_Settings.ShowEditor()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub VerticalGridMedia_Settings_CellValueChanging(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles VerticalGridMedia_Settings.CellValueChanging

            'objects
            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            Try

                If e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.UseLocationPrintOptions.ToString Then

                    BaseRow = VerticalGridMedia_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.LocationCode.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = Nothing

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.ApplyExchangeRate.ToString Then

                    BaseRow = VerticalGridMedia_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.ExchangeRateAmount.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 1

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.InvoiceFooterCommentType.ToString Then

                    BaseRow = VerticalGridMedia_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.InvoiceFooterComment.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = AdvantageFramework.InvoicePrinting.InvoiceFooterCommentTypes.UserDefined Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = Nothing

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.AddressBlockType.ToString Then

                    BaseRow = VerticalGridMedia_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.ContactType.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 4 AndAlso BaseRow.Properties.Value = 1 Then

                            BaseRow.Properties.Value = 0

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.ContactType.ToString Then

                    BaseRow = VerticalGridMedia_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceHeaderFooterSetting.Properties.AddressBlockType.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 1 AndAlso BaseRow.Properties.Value = 4 Then

                            e.Row.Properties.Value = 0

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub VerticalGridMagazine_Settings_CellValueChanging(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles VerticalGridMagazine_Settings.CellValueChanging

            'objects
            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim RowValue As Short = -1

            Try

                If e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineUseInvoiceCategoryDescription.ToString Then

                    BaseRow = VerticalGridMagazine_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineInvoiceTitle.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineTaxAmountColumn.ToString Then

                    BaseRow = VerticalGridMagazine_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineShowTaxSeparately.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 0 Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineCommissionAmountColumn.ToString Then

                    BaseRow = VerticalGridMagazine_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineShowCommissionSeparately.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 0 Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineShowClientPO.ToString Then

                    BaseRow = VerticalGridMagazine_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineClientPOLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineShowSalesClass.ToString Then

                    BaseRow = VerticalGridMagazine_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineSalesClassLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineShowCampaign.ToString Then

                    BaseRow = VerticalGridMagazine_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineCampaignLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineShowLineDetail.ToString Then

                    BaseRow = VerticalGridMagazine_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineLineNumberColumn.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 1 Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

            If IsNumeric(e.Value) Then

                If e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineOrderMonthsColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineNetAmountColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineCommissionAmountColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineTaxAmountColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineBillAmountColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazinePriorBillAmountColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineBilledToDateAmountColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineHeadlineColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineInsertDatesColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineMaterialColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineAdNumberColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineEditorialIssueColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineAdSizeColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineJobComponentNumberColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineJobDescriptionColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineComponentDescriptionColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineOrderDetailCommentColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineOrderHouseDetailCommentColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineLineNumberColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting.Properties.MagazineCloseDateColumn.ToString Then

                    CheckAllValues(VerticalGridMagazine_Settings, _MagazineColumnPropertyDescriptions, e.Row.Properties.FieldName, e.Value)

                End If

            End If

        End Sub
        Private Sub VerticalGridNewspaper_Settings_CellValueChanging(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles VerticalGridNewspaper_Settings.CellValueChanging

            'objects
            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            Try

                If e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperUseInvoiceCategoryDescription.ToString Then

                    BaseRow = VerticalGridNewspaper_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperInvoiceTitle.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperTaxAmountColumn.ToString Then

                    BaseRow = VerticalGridNewspaper_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperShowTaxSeparately.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 0 Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperCommissionAmountColumn.ToString Then

                    BaseRow = VerticalGridNewspaper_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperShowCommissionSeparately.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 0 Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperShowClientPO.ToString Then

                    BaseRow = VerticalGridNewspaper_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperClientPOLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperShowSalesClass.ToString Then

                    BaseRow = VerticalGridNewspaper_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperSalesClassLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperShowCampaign.ToString Then

                    BaseRow = VerticalGridNewspaper_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperCampaignLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperShowLineDetail.ToString Then

                    BaseRow = VerticalGridNewspaper_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperLineNumberColumn.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 1 Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

            If IsNumeric(e.Value) Then

                If e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperOrderMonthsColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperNetAmountColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperCommissionAmountColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperTaxAmountColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperBillAmountColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperPriorBillAmountColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperBilledToDateAmountColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperHeadlineColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperInsertDatesColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperMaterialColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperAdNumberColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperEditorialIssueColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperAdSizeColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperJobComponentNumberColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperJobDescriptionColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperComponentDescriptionColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperOrderDetailCommentColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperOrderHouseDetailCommentColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperLineNumberColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting.Properties.NewspaperCloseDateColumn.ToString Then

                    CheckAllValues(VerticalGridNewspaper_Settings, _NewspaperColumnPropertyDescriptions, e.Row.Properties.FieldName, e.Value)

                End If

            End If

        End Sub
        Private Sub VerticalGridInternet_Settings_CellValueChanging(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles VerticalGridInternet_Settings.CellValueChanging

            'objects
            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            Try

                If e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetUseInvoiceCategoryDescription.ToString Then

                    BaseRow = VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetInvoiceTitle.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetTaxAmountColumn.ToString Then

                    BaseRow = VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowTaxSeparately.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 0 Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCommissionAmountColumn.ToString Then

                    BaseRow = VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowCommissionSeparately.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 0 Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowClientPO.ToString Then

                    BaseRow = VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetClientPOLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = (VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetHeaderGroupBy.ToString, True).Properties.Value <> AdvantageFramework.InvoicePrinting.MediaOrderGroupBy.GroupByVendorInvoiceCategory)

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowSalesClass.ToString Then

                    BaseRow = VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetSalesClassLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = (VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetHeaderGroupBy.ToString, True).Properties.Value <> AdvantageFramework.InvoicePrinting.MediaOrderGroupBy.GroupByVendorInvoiceCategory)

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowCampaign.ToString Then

                    BaseRow = VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCampaignLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = (VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetHeaderGroupBy.ToString, True).Properties.Value <> AdvantageFramework.InvoicePrinting.MediaOrderGroupBy.GroupByVendorInvoiceCategory)

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowLineDetail.ToString Then

                    BaseRow = VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetLineNumberColumn.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 1 Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetHeaderGroupBy.ToString Then

                    If e.Value = 6 Then

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetClientPOLocation.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetClientPOLocation.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 1

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetSalesClassLocation.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetSalesClassLocation.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 1

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCampaignLocation.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCampaignLocation.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 1

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowOrderComment.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowOrderComment.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowOrderHouseComment.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowOrderHouseComment.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowCampaignComment.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowCampaignComment.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowOrderDescription.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowOrderDescription.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowOrderSubtotals.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowOrderSubtotals.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowLineDetail.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetOrderNumberColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetOrderNumberColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetVendorNameColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetVendorNameColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowVendorCode.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowVendorCode.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetOrderMonthsColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetOrderMonthsColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowZeroLineAmounts.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowZeroLineAmounts.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetSortLinesBy.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetLineNumberColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetLineNumberColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetHeadlineColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetHeadlineColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetStartDatesColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetStartDatesColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetEndDatesColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetEndDatesColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCreativeSizeColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCreativeSizeColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetAdNumberColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetAdNumberColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetURLColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetURLColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetInternetTypeColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetInternetTypeColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCloseDateColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCloseDateColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetJobComponentNumberColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetJobComponentNumberColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetJobDescriptionColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetJobDescriptionColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetComponentDescriptionColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetComponentDescriptionColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetExtraChargesColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetExtraChargesColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowBillingHistory.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowBillingHistory.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                    Else

                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetClientPOLocation.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetSalesClassLocation.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCampaignLocation.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowOrderComment.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowOrderHouseComment.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowCampaignComment.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowOrderDescription.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowOrderSubtotals.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowLineDetail.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetOrderNumberColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetVendorNameColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowVendorCode.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetOrderMonthsColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowZeroLineAmounts.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetSortLinesBy.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetLineNumberColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetHeadlineColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetStartDatesColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetEndDatesColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCreativeSizeColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetAdNumberColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetURLColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetInternetTypeColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCloseDateColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetJobComponentNumberColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetJobDescriptionColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetComponentDescriptionColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetExtraChargesColumn.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                        CType(VerticalGridInternet_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetShowBillingHistory.ToString, True), DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                    End If

                End If

            Catch ex As Exception

            End Try

            If IsNumeric(e.Value) Then

                If e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetOrderMonthsColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetNetAmountColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCommissionAmountColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetTaxAmountColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetBillAmountColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetPriorBillAmountColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetBilledToDateAmountColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetHeadlineColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetStartDatesColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetEndDatesColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetAdNumberColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetURLColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCreativeSizeColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetJobComponentNumberColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetJobDescriptionColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetComponentDescriptionColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetLineNumberColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting.Properties.InternetCloseDateColumn.ToString Then

                    CheckAllValues(VerticalGridInternet_Settings, _InternetColumnPropertyDescriptions, e.Row.Properties.FieldName, e.Value)

                End If

            End If

        End Sub
        Private Sub VerticalGridOutdoor_Settings_CellValueChanging(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles VerticalGridOutdoor_Settings.CellValueChanging

            'objects
            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            Try

                If e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorUseInvoiceCategoryDescription.ToString Then

                    BaseRow = VerticalGridOutdoor_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorInvoiceTitle.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorTaxAmountColumn.ToString Then

                    BaseRow = VerticalGridOutdoor_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorShowTaxSeparately.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 0 Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorCommissionAmountColumn.ToString Then

                    BaseRow = VerticalGridOutdoor_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorShowCommissionSeparately.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 0 Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorShowClientPO.ToString Then

                    BaseRow = VerticalGridOutdoor_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorClientPOLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorShowSalesClass.ToString Then

                    BaseRow = VerticalGridOutdoor_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorSalesClassLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorShowCampaign.ToString Then

                    BaseRow = VerticalGridOutdoor_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorCampaignLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorShowLineDetail.ToString Then

                    BaseRow = VerticalGridOutdoor_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorLineNumberColumn.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 1 Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

            If IsNumeric(e.Value) Then

                If e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorOrderMonthsColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorNetAmountColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorCommissionAmountColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorTaxAmountColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorBillAmountColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorPriorBillAmountColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorBilledToDateAmountColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorHeadlineColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorInsertDatesColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorCopyAreaColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorAdNumberColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorLocationColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorOutdoorTypeColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorJobComponentNumberColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorJobDescriptionColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorComponentDescriptionColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorSizeColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorLineNumberColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorCloseDateColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting.Properties.OutdoorEndDateColumn.ToString Then

                    CheckAllValues(VerticalGridOutdoor_Settings, _OutdoorColumnPropertyDescriptions, e.Row.Properties.FieldName, e.Value)

                End If

            End If

        End Sub
        Private Sub VerticalGridRadio_Settings_CellValueChanging(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles VerticalGridRadio_Settings.CellValueChanging

            'objects
            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            Try

                If e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioUseInvoiceCategoryDescription.ToString Then

                    BaseRow = VerticalGridRadio_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioInvoiceTitle.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioShowLineDetail.ToString Then

                    BaseRow = VerticalGridRadio_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioLineNumberColumn.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 1 Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioTaxAmountColumn.ToString Then

                    BaseRow = VerticalGridRadio_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioShowTaxSeparately.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 0 Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioCommissionAmountColumn.ToString Then

                    BaseRow = VerticalGridRadio_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioShowCommissionSeparately.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 0 Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioShowClientPO.ToString Then

                    BaseRow = VerticalGridRadio_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioClientPOLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioShowSalesClass.ToString Then

                    BaseRow = VerticalGridRadio_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioSalesClassLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioShowCampaign.ToString Then

                    BaseRow = VerticalGridRadio_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioCampaignLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

            If IsNumeric(e.Value) Then

                If e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioOrderMonthsColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioNetAmountColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioCommissionAmountColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioTaxAmountColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioBillAmountColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioPriorBillAmountColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioBilledToDateAmountColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioSpotLengthColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioTagColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioStartEndTimesColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioNumberOfSpotsColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioRemarksColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioProgramColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioJobComponentNumberColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioJobDescriptionColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioComponentDescriptionColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioOrderDetailCommentColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioOrderHouseDetailCommentColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioLineNumberColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting.Properties.RadioCloseDateColumn.ToString Then

                    CheckAllValues(VerticalGridRadio_Settings, _RadioColumnPropertyDescriptions, e.Row.Properties.FieldName, e.Value)

                End If

            End If

        End Sub
        Private Sub VerticalGridTV_Settings_CellValueChanging(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles VerticalGridTV_Settings.CellValueChanging

            'objects
            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            Try

                If e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVUseInvoiceCategoryDescription.ToString Then

                    BaseRow = VerticalGridTV_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVInvoiceTitle.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVShowLineDetail.ToString Then

                    BaseRow = VerticalGridTV_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVLineNumberColumn.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 1 Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVTaxAmountColumn.ToString Then

                    BaseRow = VerticalGridTV_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVShowTaxSeparately.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 0 Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVCommissionAmountColumn.ToString Then

                    BaseRow = VerticalGridTV_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVShowCommissionSeparately.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 0 Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVShowClientPO.ToString Then

                    BaseRow = VerticalGridTV_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVClientPOLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVShowSalesClass.ToString Then

                    BaseRow = VerticalGridTV_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVSalesClassLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVShowCampaign.ToString Then

                    BaseRow = VerticalGridTV_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVCampaignLocation.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

            If IsNumeric(e.Value) Then

                If e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVOrderMonthsColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVNetAmountColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVCommissionAmountColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVTaxAmountColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVBillAmountColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVPriorBillAmountColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVBilledToDateAmountColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVSpotLengthColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVTagColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVStartEndTimesColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVNumberOfSpotsColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVRemarksColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVProgramColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVJobComponentNumberColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVJobDescriptionColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVComponentDescriptionColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVOrderDetailCommentColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVOrderHouseDetailCommentColumn.ToString OrElse
                        e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVLineNumberColumn.ToString OrElse e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting.Properties.TVCloseDateColumn.ToString Then

                    CheckAllValues(VerticalGridTV_Settings, _TVColumnPropertyDescriptions, e.Row.Properties.FieldName, e.Value)

                End If

            End If

        End Sub
        Private Sub VerticalGridCombo_Settings_CellValueChanging(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles VerticalGridCombo_Settings.CellValueChanging

            'objects
            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim CustomInvoice As AdvantageFramework.Reporting.Database.Entities.CustomInvoice = Nothing

            Try

                If e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.ApplyExchangeRate.ToString Then

                    BaseRow = VerticalGridCombo_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.ExchangeRateAmount.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 1

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.UseInvoiceCategoryDescription.ToString Then

                    BaseRow = VerticalGridCombo_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.InvoiceTitle.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = True Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.InvoiceFooterCommentType.ToString Then

                    BaseRow = VerticalGridCombo_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.InvoiceFooterComment.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = AdvantageFramework.InvoicePrinting.InvoiceFooterCommentTypes.UserDefined Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = True
                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = Nothing

                        Else

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Enabled = False

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.AddressBlockType.ToString Then

                    BaseRow = VerticalGridCombo_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.ContactType.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 4 AndAlso CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 1 Then

                            CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 0

                        End If

                    End If

                ElseIf e.Row.Properties.FieldName = AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.ContactType.ToString Then

                    BaseRow = VerticalGridCombo_Settings.Rows.GetRowByFieldName(AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting.Properties.AddressBlockType.ToString, True)

                    If BaseRow IsNot Nothing AndAlso TypeOf BaseRow Is DevExpress.XtraVerticalGrid.Rows.EditorRow Then

                        If e.Value = 1 AndAlso CType(BaseRow, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = 4 Then

                            VerticalGridCombo_Settings.ActiveEditor.EditValue = VerticalGridCombo_Settings.ActiveEditor.OldEditValue
                            CType(e.Row, DevExpress.XtraVerticalGrid.Rows.EditorRow).Properties.Value = VerticalGridCombo_Settings.ActiveEditor.OldEditValue
                            VerticalGridCombo_Settings.RefreshDataSource()

                        End If

                    End If

                End If

                'VerticalGridForm_Settings.ShowEditor()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemSaveOptions_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemSaveOptions_OneTime.CheckedChanged, ButtonItemSaveOptions_Clients.CheckedChanged, ButtonItemSaveOptions_Agency.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                _UserEntryChanged = True

                Me.RaiseUserEntryChangedEvent(Nothing)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
