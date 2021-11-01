Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class CustomInvoiceSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ProductionInvoicePrintingOptionsID
            MediaInvoiceSettingID
            UseLocationPrintOptions
            LocationCode
            AddressBlockType
            ApplyExchangeRate
            ExchangeRateAmount
            CustomFormatName
            MediaType
        End Enum

#End Region

#Region " Variables "

        Private _ProductionInvoicePrintingOptionsID As Integer = 0
        Private _MediaInvoiceSettingID As Integer = 0
        Private _UseLocationPrintOptions As Boolean = False
        Private _LocationCode As String = Nothing
        Private _AddressBlockType As Short = 1
        Private _ApplyExchangeRate As Boolean = False
        Private _ExchangeRateAmount As System.Nullable(Of Decimal) = 0
        Private _CustomFormatName As String = ""
        Private _MediaType As AdvantageFramework.InvoicePrinting.MediaTypes = -1

        Private _ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
        Private _InvoicePrintingSetting As InvoicePrintingSetting = Nothing
        Private _MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
        Private _InvoicePrintingMediaSetting As InvoicePrintingMediaSetting = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.Browsable(False)> _
        Public Property ProductionInvoicePrintingOptionsID() As Long
            Get
                ProductionInvoicePrintingOptionsID = _ProductionInvoicePrintingOptionsID
            End Get
            Set(ByVal value As Long)
                _ProductionInvoicePrintingOptionsID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.Browsable(False)> _
        Public Property MediaInvoiceSettingID() As Long
            Get
                MediaInvoiceSettingID = _MediaInvoiceSettingID
            End Get
            Set(ByVal value As Long)
                _MediaInvoiceSettingID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.Category("")> _
        Public Property UseLocationPrintOptions() As Boolean
            Get
                UseLocationPrintOptions = _UseLocationPrintOptions
            End Get
            Set(ByVal value As Boolean)
                _UseLocationPrintOptions = value
            End Set
        End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.LocationID),
		System.ComponentModel.DataAnnotations.MaxLength(50),
		System.ComponentModel.DisplayName("Location"),
		System.ComponentModel.Category("")>
		Public Property LocationCode() As String
			Get
				LocationCode = _LocationCode
			End Get
			Set(ByVal value As String)
				_LocationCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Address Block Type")>
		Public Property AddressBlockType() As Short
			Get
				AddressBlockType = _AddressBlockType
			End Get
			Set(ByVal value As Short)
				_AddressBlockType = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.Category("Header")>
		Public Property ApplyExchangeRate() As Boolean
			Get
				ApplyExchangeRate = _ApplyExchangeRate
			End Get
			Set(ByVal value As Boolean)
				_ApplyExchangeRate = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.Category("Header")>
		Public Property ExchangeRateAmount() As System.Nullable(Of Decimal)
			Get
				ExchangeRateAmount = _ExchangeRateAmount
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_ExchangeRateAmount = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DataAnnotations.MaxLength(50)>
		Public Property CustomFormatName() As String
			Get
				CustomFormatName = _CustomFormatName
			End Get
			Set(ByVal value As String)
				_CustomFormatName = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DataAnnotations.MaxLength(50),
		System.ComponentModel.Browsable(False)>
		Public ReadOnly Property MediaType() As AdvantageFramework.InvoicePrinting.MediaTypes
            Get
                MediaType = _MediaType
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal MediaType As AdvantageFramework.InvoicePrinting.MediaTypes, ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

            Me.MediaInvoiceSettingID = MediaInvoiceDefault.ID
            Me.UseLocationPrintOptions = If(MediaInvoiceDefault.UseLocationPrintOptions.GetValueOrDefault(1) = 2, True, False)
            Me.LocationCode = MediaInvoiceDefault.LocationCode
            Me.AddressBlockType = MediaInvoiceDefault.AddressBlockType.GetValueOrDefault(1)
            Me.ApplyExchangeRate = If(MediaInvoiceDefault.ApplyExchangeRate.GetValueOrDefault(1) = 2, True, False)
            Me.ExchangeRateAmount = MediaInvoiceDefault.ExchangeRateAmount.GetValueOrDefault(1)

            If _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.Magazine Then

                Me.CustomFormatName = MediaInvoiceDefault.MagazineCustomFormat

            ElseIf _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.Newspaper Then

                Me.CustomFormatName = MediaInvoiceDefault.NewspaperCustomFormat

            ElseIf _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.Internet Then

                Me.CustomFormatName = MediaInvoiceDefault.InternetCustomFormat

            ElseIf _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.Outdoor Then

                Me.CustomFormatName = MediaInvoiceDefault.OutOfHomeCustomFormat

            ElseIf _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.Radio Then

                Me.CustomFormatName = MediaInvoiceDefault.RadioCustomFormat

            ElseIf _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.TV Then

                Me.CustomFormatName = MediaInvoiceDefault.TVCustomFormat

            End If

            _MediaInvoiceDefault = MediaInvoiceDefault
            _MediaType = MediaType

        End Sub
        Public Sub New(ByVal MediaType As AdvantageFramework.InvoicePrinting.MediaTypes, ByVal InvoicePrintingMediaSetting As InvoicePrintingMediaSetting)

            Me.MediaInvoiceSettingID = InvoicePrintingMediaSetting.MediaInvoiceSettingID
            Me.UseLocationPrintOptions = If(InvoicePrintingMediaSetting.UseLocationPrintOptions.GetValueOrDefault(False), True, False)
            Me.LocationCode = InvoicePrintingMediaSetting.LocationCode
            Me.AddressBlockType = InvoicePrintingMediaSetting.AddressBlockType.GetValueOrDefault(1)
            Me.ApplyExchangeRate = If(InvoicePrintingMediaSetting.ApplyExchangeRate.GetValueOrDefault(1) = 2, True, False)
            Me.ExchangeRateAmount = InvoicePrintingMediaSetting.ExchangeRateAmount.GetValueOrDefault(1)

            If _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.Magazine Then

                Me.CustomFormatName = InvoicePrintingMediaSetting.MagazineCustomFormatName

            ElseIf _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.Newspaper Then

                Me.CustomFormatName = InvoicePrintingMediaSetting.NewspaperCustomFormatName

            ElseIf _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.Internet Then

                Me.CustomFormatName = InvoicePrintingMediaSetting.InternetCustomFormatName

            ElseIf _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.Outdoor Then

                Me.CustomFormatName = InvoicePrintingMediaSetting.OutdoorCustomFormatName

            ElseIf _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.Radio Then

                Me.CustomFormatName = InvoicePrintingMediaSetting.RadioCustomFormatName

            ElseIf _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.TV Then

                Me.CustomFormatName = InvoicePrintingMediaSetting.TVCustomFormatName

            End If

            _InvoicePrintingMediaSetting = InvoicePrintingMediaSetting
            _MediaType = MediaType

        End Sub
        Public Sub New(ByVal ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault)

            Me.ProductionInvoicePrintingOptionsID = ProductionInvoiceDefault.ID
            Me.UseLocationPrintOptions = If(ProductionInvoiceDefault.UseLocationPrintOptions.GetValueOrDefault(1) = 2, True, False)
            Me.LocationCode = ProductionInvoiceDefault.LocationCode
            Me.AddressBlockType = ProductionInvoiceDefault.AddressBlockType.GetValueOrDefault(1)
            Me.ApplyExchangeRate = If(ProductionInvoiceDefault.ApplyExchangeRate.GetValueOrDefault(1) = 2, True, False)
            Me.ExchangeRateAmount = ProductionInvoiceDefault.ExchangeRateAmount.GetValueOrDefault(1)
            Me.CustomFormatName = ProductionInvoiceDefault.CustomFormatName

            _ProductionInvoiceDefault = ProductionInvoiceDefault

        End Sub
        Public Sub New(ByVal InvoicePrintingSetting As InvoicePrintingSetting)

            Me.ProductionInvoicePrintingOptionsID = InvoicePrintingSetting.ProductionInvoicePrintingOptionsID
            Me.UseLocationPrintOptions = If(InvoicePrintingSetting.UseLocationPrintOptions.GetValueOrDefault(False), True, False)
            Me.LocationCode = InvoicePrintingSetting.LocationCode
            Me.AddressBlockType = InvoicePrintingSetting.AddressBlockType.GetValueOrDefault(1)
            Me.ApplyExchangeRate = If(InvoicePrintingSetting.ApplyExchangeRate.GetValueOrDefault(1) = 2, True, False)
            Me.ExchangeRateAmount = InvoicePrintingSetting.ExchangeRateAmount.GetValueOrDefault(1)
            Me.CustomFormatName = InvoicePrintingSetting.CustomFormatName

            _InvoicePrintingSetting = InvoicePrintingSetting

        End Sub
        Public Function GetEntity() As Object

            If _InvoicePrintingSetting IsNot Nothing Then

                GetEntity = _InvoicePrintingSetting

            ElseIf _ProductionInvoiceDefault IsNot Nothing Then

                GetEntity = _ProductionInvoiceDefault

            ElseIf _InvoicePrintingMediaSetting IsNot Nothing Then

                GetEntity = _InvoicePrintingMediaSetting

            ElseIf _MediaInvoiceDefault IsNot Nothing Then

                GetEntity = _MediaInvoiceDefault

            Else

                GetEntity = Nothing

            End If

        End Function
        Public Function SaveAndGetEntity() As Object

            Save()

            If _InvoicePrintingSetting IsNot Nothing Then

                SaveAndGetEntity = _InvoicePrintingSetting

            ElseIf _ProductionInvoiceDefault IsNot Nothing Then

                SaveAndGetEntity = _ProductionInvoiceDefault

            ElseIf _InvoicePrintingMediaSetting IsNot Nothing Then

                SaveAndGetEntity = _InvoicePrintingMediaSetting

            ElseIf _MediaInvoiceDefault IsNot Nothing Then

                SaveAndGetEntity = _MediaInvoiceDefault

            Else

                SaveAndGetEntity = Nothing

            End If

        End Function
        Public Sub Save()

            If _InvoicePrintingSetting IsNot Nothing Then

                Save(_InvoicePrintingSetting)

            ElseIf _ProductionInvoiceDefault IsNot Nothing Then

                Save(_ProductionInvoiceDefault)

            ElseIf _InvoicePrintingMediaSetting IsNot Nothing Then

                Save(_InvoicePrintingMediaSetting)

            ElseIf _MediaInvoiceDefault IsNot Nothing Then

                Save(_MediaInvoiceDefault)

            End If

        End Sub
        Public Sub Save(ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

            MediaInvoiceDefault.UseLocationPrintOptions = If(Me.UseLocationPrintOptions, 2, 1)
            MediaInvoiceDefault.LocationCode = Me.LocationCode
            MediaInvoiceDefault.AddressBlockType = Me.AddressBlockType
            MediaInvoiceDefault.ApplyExchangeRate = Convert.ToInt16(Me.ApplyExchangeRate)
            MediaInvoiceDefault.ExchangeRateAmount = Me.ExchangeRateAmount

            If _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.Magazine Then

                MediaInvoiceDefault.MagazineCustomFormat = Me.CustomFormatName

            ElseIf _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.Newspaper Then

                MediaInvoiceDefault.NewspaperCustomFormat = Me.CustomFormatName

            ElseIf _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.Internet Then

                MediaInvoiceDefault.InternetCustomFormat = Me.CustomFormatName

            ElseIf _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.Outdoor Then

                MediaInvoiceDefault.OutOfHomeCustomFormat = Me.CustomFormatName

            ElseIf _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.Radio Then

                MediaInvoiceDefault.RadioCustomFormat = Me.CustomFormatName

            ElseIf _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.TV Then

                MediaInvoiceDefault.TVCustomFormat = Me.CustomFormatName

            End If

        End Sub
        Public Sub Save(ByVal InvoicePrintingMediaSetting As InvoicePrintingMediaSetting)

            InvoicePrintingMediaSetting.UseLocationPrintOptions = Me.UseLocationPrintOptions
            InvoicePrintingMediaSetting.LocationCode = Me.LocationCode
            InvoicePrintingMediaSetting.AddressBlockType = Me.AddressBlockType
            InvoicePrintingMediaSetting.ApplyExchangeRate = Me.ApplyExchangeRate
            InvoicePrintingMediaSetting.ExchangeRateAmount = Me.ExchangeRateAmount.GetValueOrDefault(1)

            If _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.Magazine Then

                InvoicePrintingMediaSetting.MagazineCustomFormatName = Me.CustomFormatName

            ElseIf _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.Newspaper Then

                InvoicePrintingMediaSetting.NewspaperCustomFormatName = Me.CustomFormatName

            ElseIf _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.Internet Then

                InvoicePrintingMediaSetting.InternetCustomFormatName = Me.CustomFormatName

            ElseIf _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.Outdoor Then

                InvoicePrintingMediaSetting.OutdoorCustomFormatName = Me.CustomFormatName

            ElseIf _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.Radio Then

                InvoicePrintingMediaSetting.RadioCustomFormatName = Me.CustomFormatName

            ElseIf _MediaType = AdvantageFramework.InvoicePrinting.MediaTypes.TV Then

                InvoicePrintingMediaSetting.TVCustomFormatName = Me.CustomFormatName

            End If

        End Sub
        Public Sub Save(ByVal ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault)

            ProductionInvoiceDefault.UseLocationPrintOptions = If(Me.UseLocationPrintOptions, 2, 1)
            ProductionInvoiceDefault.LocationCode = Me.LocationCode
            ProductionInvoiceDefault.AddressBlockType = Me.AddressBlockType
            ProductionInvoiceDefault.ApplyExchangeRate = Convert.ToInt16(Me.ApplyExchangeRate)
            ProductionInvoiceDefault.ExchangeRateAmount = Me.ExchangeRateAmount
            ProductionInvoiceDefault.CustomFormatName = Me.CustomFormatName

        End Sub
        Public Sub Save(ByVal InvoicePrintingSetting As InvoicePrintingSetting)

            InvoicePrintingSetting.UseLocationPrintOptions = Me.UseLocationPrintOptions
            InvoicePrintingSetting.LocationCode = Me.LocationCode
            InvoicePrintingSetting.AddressBlockType = Me.AddressBlockType
            InvoicePrintingSetting.ApplyExchangeRate = Me.ApplyExchangeRate
            InvoicePrintingSetting.ExchangeRateAmount = Me.ExchangeRateAmount.GetValueOrDefault(1)
            InvoicePrintingSetting.CustomFormatName = Me.CustomFormatName

        End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
