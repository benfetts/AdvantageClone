Public Interface IComboInvoice

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    WriteOnly Property Session As AdvantageFramework.Security.Session
    WriteOnly Property InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting
    WriteOnly Property InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting
    WriteOnly Property AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting
    WriteOnly Property OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting
    WriteOnly Property AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice
    WriteOnly Property IsDraft As Boolean
	WriteOnly Property MediaType As String
	WriteOnly Property ApplyExchangeRate As Short
	WriteOnly Property ExchangeRateAmount As Decimal

#End Region

#Region " Methods "

	Sub SetParameterValues()

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

End Interface
