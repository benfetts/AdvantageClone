Namespace Controller.FinanceAndAccounting.Exports

    Public Class VATExportController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "

        Private Enum OutputFields
            DocumentType
            SequencialNumberVK
            SequencialNumberAK
            TransactionDate
            InvoiceNumber
            SupplierInvoiceNumber
            DocumentIndicator
            OwnReference
            ReferenceInvoiceNumber
            ReferenceInvoiceDate
            ReferenceTaxableBasis
            ReferenceVAT
            AutoFatturaNumber
            InvoiceDate
            Currency
            Currency2
            Currency3
            ExchangeRateDate
            Discount
            DateOfSupply
            VATCode
            VATCodeScheme
            VATCodeDescription
            CreditNoteOriginalDocument
            CreditNoteReason
            VATDate
            InvoiceReceiptDate
            IncomingPostingDate
            OutsourcingPartyType
            OutsourcingPartyName
            OutsourcingPartyAddress
            OutsourcingPartyVRN
            SupplierID
            SupplierName
            SupplierPrivatePersonFirstName
            SupplierPrivatePersonLastName
            SupplierStreet
            SupplierHouseNumber
            SupplierZip
            SupplierCity
            SupplierCountry
            SupplierTelephone
            SupplierFax
            SupplierVATNumberUsed
            SupplierCountryVATNumberUsed
            SupplierVatNumberType
            SupplierDeductionType
            SupplierSpecialType
            SupplierFiscalNumber
            SupplierFiscalNumberIssuedBy
            SupplierFiscalRepresentativeName
            SupplierFiscalRepresentativePrivatePersonFirstName
            SupplierFiscalRepresentativePrivatePersonLastName
            SupplierFiscalRepresentativeStreet
            SupplierFiscalRepresentativeHouseNumber
            SupplierFiscalRepresentativeZip
            SupplierFiscalRepresentativeCity
            SupplierFiscalRepresentativeCountry
            SupplierFiscalRepresentativeTelephone
            SupplierFiscalRepresentativeFax
            SupplierFiscalRepresentativeEmail
            SupplierFiscalRepresentativeVATNumber
            SupplierFiscalRepresentativeTaxNumber
            SupplierFixedEstablishmentStreet
            SupplierFixedEstablishmentHouseNumber
            SupplierFixedEstablishmentZip
            SupplierFixedEstablishmentCity
            SupplierFixedEstablishmentCountry
            SupplierFixedEstablishmentTelephone
            SupplierFixedEstablishmentFax
            SupplierFixedEstablishmentEmail
            CustomerID
            CustomerName
            CustomerPrivatePersonFirstName
            CustomerPrivatePersonLastName
            CustomerStreet
            CustomerHouseNumber
            CustomerZip
            CustomerCity
            CustomerCountry
            CustomerTelephone
            CustomerFax
            CustomerVATNumberUsed
            CustomerCountryVATNumberUsed
            CustomerVatNumberType
            CustomerDeductionType
            CustomerSpecialType
            CustomerFiscalNumber
            CustomerFiscalNumberIssuedBy
            CustomerFiscalRepresentativeName
            CustomerFiscalRepresentativePrivatePersonFirstName
            CustomerFiscalRepresentativePrivatePersonLastName
            CustomerFiscalRepresentativeStreet
            CustomerFiscalRepresentativeHouseNumber
            CustomerFiscalRepresentativeZip
            CustomerFiscalRepresentativeCity
            CustomerFiscalRepresentativeCountry
            CustomerFiscalRepresentativeTelephone
            CustomerFiscalRepresentativeFax
            CustomerFiscalRepresentativeEmail
            CustomerFiscalRepresentativeVATNumber
            CustomerFiscalRepresentativeTaxNumber
            CustomerFixedEstablishmentStreet
            CustomerFixedEstablishmentHouseNumber
            CustomerFixedEstablishmentZip
            CustomerFixedEstablishmentCity
            CustomerFixedEstablishmentCountry
            CustomerFixedEstablishmentTelephone
            CustomerFixedEstablishmentFax
            CustomerFixedEstablishmentEmail
            Description
            ExemptionReason
            ItemClassification
            TaxableBasis
            ValueVAT
            SalesVATDueReverseCharge
            TotalValueLine
            AmountVATDeducted
            AmountVATReverseCharged
            TaxableBasisCurrency2
            ValueVATCurrency2
            SalesVATDueReverseChargeCurrency2
            TotalValueLineCurrency2
            AmountVATDeductedCurrency2
            AmountVATReverseChargedCurrency2
            TaxableBasisCurrency3
            ValueVATCurrency3
            SalesVATDueReverseChargeCurrency3
            TotalValueLineCurrency3
            AmountVATDeductedCurrency3
            AmountVATReverseChargedCurrency3
            OutOfVAT
            Quantity
            Unit
            ItemIdentifier
            CountryDispatch
            CountryArrival
            ShipToCity
            ShipToZIP
            ShipToStreet
            ShipToStreetNumber
            ShipFromCity
            ShipFromZIP
            ShipFromStreet
            ShipFromStreetNumber
            CountryOperation
            Installation
            Transporter
            CountryEUImportation
            EUImporter
            DeliveryConditions
            PlaceOfDelivery
            Triangulation
            AdditionalDocumentReference
            ReportingType
            TransactionType
            AdditionalTransactionType
            IntrastatCode
            AdditionalIntrastatCode
            ExtrastatCode
            AdditionalDescription
            Quantity1
            Unit1
            Quantity2
            Unit2
            CommercialValue
            StatisticalValue
            CommercialValueCurrency2
            StatisticalValueCurrency2
            CommercialValueCurrency3
            StatisticalValueCurrency3
            ModeOfTransport
            ItemType
            RegionDispatch
            HarbourDispatch
            RegionArrival
            HarbourArrival
            CountryOrigin
            ServiceCode
            NationalityTransportVehicle
            AccountNumber
            CashRegisterNumber
            AccountNumberTaxableBasis
            AccountNumberVAT
            AccountNumberDeductibleVAT
            AccountNumberNonDeductibleVAT
            AccountNumberReversedVAT
            RefundNatureOfItem
            RefundDescription
            RefundDescriptionLanguage
            ImportDocumentNumber
            ImportReferenceInformation
            ScannedDocumentFileName
            ScannedDocumentFileDescription
            ClearingDate
            ClearingDocumentNumber
            ClearingDocumentAmount
            ClearingDocumentCurrency
            ClearingDocumentAccountInformation
            ClearingDocumentPayementMethod
            NationalityTransportMeans
            CountryCustomsDeclaration
            InternalModeOfTransport
            EUCountryDispatch
            EUCountryArrival
            Container
            EORINRPSI
            EORINRPSIAgent
            CustomsProcedureCode
            PreferentialTreatment
            StatisticalProcedure
        End Enum
        Private Enum AdvantageDataFields
            DocumentType
            TransactionDate
            InvoiceNumber
            SupplierInvoiceNumber
            DocumentIndicator
            InvoiceDate
            Currency
            VATCode
            SupplierID
            SupplierName
            SupplierCountry
            SupplierVATNumberUsed
            SupplierCountryVATNumberUsed
            CustomerID
            CustomerName
            CustomerCountry
            CustomerVATNumberUsed
            CustomerCountryVATNumberUsed
            TaxableBasis
            ValueVAT
            SalesVATDueReverseCharge
            TotalValueLine
            AmountVATDeducted
            AmountVATReverseCharged
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Function GetSetting(DataContext As AdvantageFramework.Database.DataContext, SettingCode As String) As Object

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, SettingCode)

            If Setting IsNot Nothing Then

                GetSetting = Setting.Value

            Else

                GetSetting = Nothing

            End If

        End Function
        Private Sub SaveSetting(DataContext As AdvantageFramework.Database.DataContext, SettingCode As String, Value As Object)

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, SettingCode)

            If Setting IsNot Nothing Then

                Setting.Value = Value

                AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            End If

        End Sub

#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Export(VATExportViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.Exports.VATExportViewModel, ByRef ErrorMessage As String) As Boolean

            Dim Exported As Boolean = False
            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim FileName As String = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim StreamWriter As System.IO.StreamWriter = Nothing
            Dim Fields As Array = Nothing
            Dim Field As String = Nothing

            Try

                PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.DTO.FinanceAndAccounting.VATExportRow)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                Fields = System.Enum.GetNames(GetType(OutputFields))

                FileName = System.IO.Path.Combine(VATExportViewModel.OutputFolder, "VAT_" & VATExportViewModel.PostPeriodCodeStart & "_" & VATExportViewModel.PostPeriodCodeEnd & "_" & Session.UserCode & "_" & Format(Now, "yyyyMMddhhmmss") & ".txt")

                StreamWriter = New System.IO.StreamWriter(FileName)

                'header row
                StreamWriter.Write("First Line")
                StreamWriter.WriteLine()

                'column headers
                For Each Field In Fields

                    StreamWriter.Write(Field & vbTab)

                Next
                StreamWriter.WriteLine()

                'column data
                For Each VATExportRow In VATExportViewModel.VATExportRows

                    For Each Field In Fields

                        PropertyDescriptor = PropertyDescriptors.Where(Function(PD) PD.Name = Field).FirstOrDefault

                        If PropertyDescriptor IsNot Nothing Then

                            If Field = OutputFields.TransactionDate.ToString OrElse Field = OutputFields.InvoiceDate.ToString Then

                                StreamWriter.Write(CDate(PropertyDescriptor.GetValue(VATExportRow)).ToString("yyyy-MM-dd") & vbTab)

                            Else

                                StreamWriter.Write(CStr(PropertyDescriptor.GetValue(VATExportRow)) & vbTab)

                            End If

                        Else

                            StreamWriter.Write("" & vbTab)

                        End If

                    Next

                    StreamWriter.WriteLine()

                Next

                StreamWriter.Flush()
                StreamWriter.Close()
                StreamWriter.Dispose()

                Exported = True

                If VATExportViewModel.IsAgencyASP Then

                    If Not AdvantageFramework.Email.SendASPReportDownloadEmail(Session, FileName) Then

                        ErrorMessage = "File exported successfully but email link could not be sent to your email."

                        Exported = False

                    End If

                End If

            Catch ex As Exception
                ErrorMessage = ex.Message
            Finally
                Export = Exported
            End Try

        End Function
        Public Function Load() As AdvantageFramework.ViewModels.FinanceAndAccounting.Exports.VATExportViewModel

            'objects
            Dim VATExportViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.Exports.VATExportViewModel = Nothing

            VATExportViewModel = New AdvantageFramework.ViewModels.FinanceAndAccounting.Exports.VATExportViewModel

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                VATExportViewModel.IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                If VATExportViewModel.IsAgencyASP Then

                    VATExportViewModel.AgencyImportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext), "\") & "Reports"

                End If

                VATExportViewModel.PostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(PP) PP.Code).ToList

                VATExportViewModel.CurrencyCodes = AdvantageFramework.Database.Procedures.CurrencyCode.LoadAllActive(DbContext).ToList

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    VATExportViewModel.PostPeriodCodeStart = GetSetting(DataContext, AdvantageFramework.Agency.Settings.VAT_PPSTART.ToString)

                    VATExportViewModel.PostPeriodCodeEnd = GetSetting(DataContext, AdvantageFramework.Agency.Settings.VAT_PPEND.ToString)

                    VATExportViewModel.AgencyVATNumber = GetSetting(DataContext, AdvantageFramework.Agency.Settings.VAT_AGENCY_VATNUMBER.ToString)

                    VATExportViewModel.CurrencyCode = GetSetting(DataContext, AdvantageFramework.Agency.Settings.VAT_CURRENCY_CODE.ToString)

                    VATExportViewModel.OutputFolder = GetSetting(DataContext, AdvantageFramework.Agency.Settings.VAT_OUTPUT_DIRECTORY.ToString)

                End Using

            End Using

            Load = VATExportViewModel

        End Function
        Public Function Process(ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.Exports.VATExportViewModel, ByRef ErrorMessage As String) As Boolean

            Dim Processed As Boolean = False

            Try

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    SaveSetting(DataContext, AdvantageFramework.Agency.Settings.VAT_PPSTART.ToString, ViewModel.PostPeriodCodeStart)
                    SaveSetting(DataContext, AdvantageFramework.Agency.Settings.VAT_PPEND.ToString, ViewModel.PostPeriodCodeEnd)
                    SaveSetting(DataContext, AdvantageFramework.Agency.Settings.VAT_AGENCY_VATNUMBER.ToString, ViewModel.AgencyVATNumber)
                    SaveSetting(DataContext, AdvantageFramework.Agency.Settings.VAT_CURRENCY_CODE.ToString, ViewModel.CurrencyCode)
                    SaveSetting(DataContext, AdvantageFramework.Agency.Settings.VAT_OUTPUT_DIRECTORY.ToString, ViewModel.OutputFolder)

                    ViewModel.VATExportRows = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.VATExportRow)

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        ViewModel.VATExportRows = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.FinanceAndAccounting.VATExportRow)(String.Format("exec advsp_avalara_vat_export '{0}', '{1}', '{2}', '{3}'",
                                                    ViewModel.PostPeriodCodeStart, ViewModel.PostPeriodCodeEnd, ViewModel.CurrencyCode, ViewModel.AgencyVATNumber)).ToList

                        For Each VATExportRow In ViewModel.VATExportRows

                            Me.SetRequiredFields(VATExportRow)

                            Me.ValidateDTO(DbContext, DataContext, VATExportRow, True)

                        Next

                    End Using

                    Processed = True

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message
            Finally
                Process = Processed
            End Try

        End Function
        Public Overrides Sub SetRequiredFields(ByRef DTO As AdvantageFramework.DTO.BaseClass)

            'objects
            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(DTO).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            If DTO.GetType.Equals(GetType(AdvantageFramework.DTO.FinanceAndAccounting.VATExportRow)) Then

                For Each PropertyDescriptor In PropertyDescriptors

                    Select Case PropertyDescriptor.Name

                        Case AdvantageFramework.DTO.FinanceAndAccounting.VATExportRow.Properties.SupplierInvoiceNumber.ToString

                            DTO.SetRequired(PropertyDescriptor, DirectCast(DTO, AdvantageFramework.DTO.FinanceAndAccounting.VATExportRow).Source = "P")

                    End Select

                Next

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
