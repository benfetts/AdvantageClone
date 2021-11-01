Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class MediaInvoiceHeaderFooterSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaInvoiceSettingID
            CustomFormatName
            UseLocationPrintOptions
            LocationCode
            AddressBlockType
            PrintDivisionName
            PrintProductDescription
            PrintContactAfterAddress
            ContactType
            ShowCodes
            IncludeBillingComment
            ApplyExchangeRate
            ExchangeRateAmount
            InvoiceFooterCommentType
			InvoiceFooterComment
			PrintClientName
        End Enum

#End Region

#Region " Variables "

        Private _MediaInvoiceSettingID As Integer = 0
        Private _CustomFormatName As String = ""
        Private _UseLocationPrintOptions As Boolean = False
        Private _LocationCode As String = Nothing
        Private _AddressBlockType As Short = 1
        Private _PrintDivisionName As Boolean = False
        Private _PrintProductDescription As Boolean = False
        Private _PrintContactAfterAddress As Boolean = False
        Private _ContactType As Integer = 0
        Private _IncludeBillingComment As Boolean = False
        Private _ApplyExchangeRate As Boolean = False
        Private _ExchangeRateAmount As System.Nullable(Of Decimal) = 1
        Private _HideExchangeRateMessage As Boolean = False
        Private _InvoiceFooterCommentType As Short = 1
        Private _InvoiceFooterComment As String = ""
		'Private _CustomInvoiceID As Nullable(Of Integer) = Nothing
		Private _PrintClientName As Boolean = False
        Private _ShowCodes As Boolean = False

        Private _MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
        Private _InvoicePrintingMediaSetting As InvoicePrintingMediaSetting = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.Browsable(False)> _
        Public Property MediaInvoiceSettingID As Long
            Get
                MediaInvoiceSettingID = _MediaInvoiceSettingID
            End Get
            Set(ByVal value As Long)
                _MediaInvoiceSettingID = value
            End Set
        End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DataAnnotations.MaxLength(50),
		System.ComponentModel.Browsable(False)>
		Public Property CustomFormatName As String
			Get
				CustomFormatName = _CustomFormatName
			End Get
			Set(ByVal value As String)
				_CustomFormatName = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.Category("")>
		Public Property UseLocationPrintOptions As Boolean
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
		Public Property LocationCode As String
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
		Public Property AddressBlockType As Short
			Get
				AddressBlockType = _AddressBlockType
			End Get
			Set(ByVal value As Short)
				_AddressBlockType = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Print Division Name")>
		Public Property PrintDivisionName As Boolean
			Get
				PrintDivisionName = _PrintDivisionName
			End Get
			Set(ByVal value As Boolean)
				_PrintDivisionName = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Print Product Description")>
		Public Property PrintProductDescription As Boolean
			Get
				PrintProductDescription = _PrintProductDescription
			End Get
			Set(ByVal value As Boolean)
				_PrintProductDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Print Contact After Address")>
		Public Property PrintContactAfterAddress As Boolean
			Get
				PrintContactAfterAddress = _PrintContactAfterAddress
			End Get
			Set(ByVal value As Boolean)
				_PrintContactAfterAddress = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Contact Type")>
		Public Property ContactType() As Integer
			Get
				ContactType = _ContactType
			End Get
			Set(value As Integer)
				_ContactType = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Billing Comment")>
		Public Property IncludeBillingComment As Boolean
			Get
				IncludeBillingComment = _IncludeBillingComment
			End Get
			Set(ByVal value As Boolean)
				_IncludeBillingComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.Category("Header")>
		Public Property ApplyExchangeRate As Boolean
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
        Public Property ExchangeRateAmount As System.Nullable(Of Decimal)
            Get
                ExchangeRateAmount = _ExchangeRateAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _ExchangeRateAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
        System.ComponentModel.Category("Header")>
        Public Property HideExchangeRateMessage As Boolean
            Get
                HideExchangeRateMessage = _HideExchangeRateMessage
            End Get
            Set(ByVal value As Boolean)
                _HideExchangeRateMessage = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Type")>
		Public Property InvoiceFooterCommentType As Short
			Get
				InvoiceFooterCommentType = _InvoiceFooterCommentType
			End Get
			Set(ByVal value As Short)
				_InvoiceFooterCommentType = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DataAnnotations.MaxLength(50),
		System.ComponentModel.DisplayName("Comment")>
		Public Property InvoiceFooterComment As String
			Get
				InvoiceFooterComment = _InvoiceFooterComment
			End Get
			Set(ByVal value As String)
				_InvoiceFooterComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Print Client Name")> _
        Public Property PrintClientName() As Boolean
            Get
                PrintClientName = _PrintClientName
            End Get
            Set(ByVal value As Boolean)
                _PrintClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Show Codes")> _
        Public Property ShowCodes() As Boolean
            Get
                ShowCodes = _ShowCodes
            End Get
            Set(ByVal value As Boolean)
                _ShowCodes = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

            Me.MediaInvoiceSettingID = MediaInvoiceDefault.ID
            Me.CustomFormatName = MediaInvoiceDefault.CustomFormatName
            Me.UseLocationPrintOptions = If(MediaInvoiceDefault.UseLocationPrintOptions.GetValueOrDefault(1) = 2, True, False)
            Me.LocationCode = MediaInvoiceDefault.LocationCode
            Me.AddressBlockType = MediaInvoiceDefault.AddressBlockType.GetValueOrDefault(1)
            Me.PrintDivisionName = Convert.ToBoolean(MediaInvoiceDefault.PrintDivisionName.GetValueOrDefault(0))
            Me.PrintProductDescription = Convert.ToBoolean(MediaInvoiceDefault.PrintProductDescription.GetValueOrDefault(0))
            Me.PrintContactAfterAddress = Convert.ToBoolean(MediaInvoiceDefault.PrintContactAfterAddress.GetValueOrDefault(0))
            Me.ContactType = MediaInvoiceDefault.ContactType
            Me.IncludeBillingComment = Convert.ToBoolean(MediaInvoiceDefault.IncludeBillingComment.GetValueOrDefault(0))
            Me.ApplyExchangeRate = If(MediaInvoiceDefault.ApplyExchangeRate.GetValueOrDefault(1) = 2, True, False)
            Me.ExchangeRateAmount = MediaInvoiceDefault.ExchangeRateAmount.GetValueOrDefault(1)
            Me.HideExchangeRateMessage = MediaInvoiceDefault.HideExchangeRateMessage
            Me.InvoiceFooterCommentType = MediaInvoiceDefault.InvoiceFooterCommentType.GetValueOrDefault(1)
			Me.InvoiceFooterComment = MediaInvoiceDefault.InvoiceFooterComment
			Me.PrintClientName = MediaInvoiceDefault.PrintClientName
            Me.ShowCodes = MediaInvoiceDefault.ShowCodes

            _MediaInvoiceDefault = MediaInvoiceDefault

        End Sub
        Public Sub New(ByVal InvoicePrintingMediaSetting As InvoicePrintingMediaSetting)

            Me.MediaInvoiceSettingID = InvoicePrintingMediaSetting.MediaInvoiceSettingID.GetValueOrDefault(0)
            Me.CustomFormatName = InvoicePrintingMediaSetting.CustomFormatName
            Me.UseLocationPrintOptions = InvoicePrintingMediaSetting.UseLocationPrintOptions.GetValueOrDefault(False)
            Me.LocationCode = InvoicePrintingMediaSetting.LocationCode
            Me.AddressBlockType = InvoicePrintingMediaSetting.AddressBlockType.GetValueOrDefault(1)
            Me.PrintDivisionName = InvoicePrintingMediaSetting.PrintDivisionName.GetValueOrDefault(False)
            Me.PrintProductDescription = InvoicePrintingMediaSetting.PrintProductDescription.GetValueOrDefault(False)
            Me.PrintContactAfterAddress = InvoicePrintingMediaSetting.PrintContactAfterAddress.GetValueOrDefault(False)
            Me.ContactType = InvoicePrintingMediaSetting.ContactType
            Me.IncludeBillingComment = InvoicePrintingMediaSetting.IncludeBillingComment.GetValueOrDefault(False)
            Me.ApplyExchangeRate = If(InvoicePrintingMediaSetting.ApplyExchangeRate.GetValueOrDefault(1) = 2, True, False)
            Me.ExchangeRateAmount = InvoicePrintingMediaSetting.ExchangeRateAmount.GetValueOrDefault(1)
            Me.HideExchangeRateMessage = InvoicePrintingMediaSetting.HideExchangeRateMessage
            Me.InvoiceFooterCommentType = InvoicePrintingMediaSetting.InvoiceFooterCommentType.GetValueOrDefault(1)
			Me.InvoiceFooterComment = InvoicePrintingMediaSetting.InvoiceFooterComment
			Me.PrintClientName = InvoicePrintingMediaSetting.PrintClientName
            Me.ShowCodes = InvoicePrintingMediaSetting.ShowCodes

            _InvoicePrintingMediaSetting = InvoicePrintingMediaSetting

        End Sub
        Public Function GetEntity() As Object

            If _InvoicePrintingMediaSetting IsNot Nothing Then

                GetEntity = _InvoicePrintingMediaSetting

            ElseIf _MediaInvoiceDefault IsNot Nothing Then

                GetEntity = _MediaInvoiceDefault

            Else

                GetEntity = Nothing

            End If

        End Function
        Public Function SaveAndGetEntity() As Object

            Save()

            If _InvoicePrintingMediaSetting IsNot Nothing Then

                SaveAndGetEntity = _InvoicePrintingMediaSetting

            ElseIf _MediaInvoiceDefault IsNot Nothing Then

                SaveAndGetEntity = _MediaInvoiceDefault

            Else

                SaveAndGetEntity = Nothing

            End If

        End Function
        Public Sub Save()

            If _InvoicePrintingMediaSetting IsNot Nothing Then

                Save(_InvoicePrintingMediaSetting)

            ElseIf _MediaInvoiceDefault IsNot Nothing Then

                Save(_MediaInvoiceDefault)

            End If

        End Sub
        Public Sub Save(ByVal InvoicePrintingMediaSetting As InvoicePrintingMediaSetting)

            InvoicePrintingMediaSetting.UseLocationPrintOptions = Me.UseLocationPrintOptions
            InvoicePrintingMediaSetting.LocationCode = Me.LocationCode
            InvoicePrintingMediaSetting.AddressBlockType = Me.AddressBlockType
            InvoicePrintingMediaSetting.PrintDivisionName = Me.PrintDivisionName
            InvoicePrintingMediaSetting.PrintProductDescription = Me.PrintProductDescription
            InvoicePrintingMediaSetting.PrintContactAfterAddress = Me.PrintContactAfterAddress
            InvoicePrintingMediaSetting.ContactType = Me.ContactType
            InvoicePrintingMediaSetting.IncludeBillingComment = Me.IncludeBillingComment
            InvoicePrintingMediaSetting.ApplyExchangeRate = Convert.ToInt16(If(Me.ApplyExchangeRate, 2, 1))
            InvoicePrintingMediaSetting.ExchangeRateAmount = Me.ExchangeRateAmount.GetValueOrDefault(1)
            InvoicePrintingMediaSetting.HideExchangeRateMessage = Me.HideExchangeRateMessage
            InvoicePrintingMediaSetting.InvoiceFooterCommentType = Me.InvoiceFooterCommentType
			InvoicePrintingMediaSetting.InvoiceFooterComment = Me.InvoiceFooterComment
			InvoicePrintingMediaSetting.PrintClientName = Me.PrintClientName
            InvoicePrintingMediaSetting.ShowCodes = Me.ShowCodes

        End Sub
        Public Sub Save(ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

            MediaInvoiceDefault.UseLocationPrintOptions = If(Me.UseLocationPrintOptions, 2, 1)
            MediaInvoiceDefault.LocationCode = Me.LocationCode
            MediaInvoiceDefault.AddressBlockType = Me.AddressBlockType
            MediaInvoiceDefault.PrintDivisionName = Convert.ToInt16(Me.PrintDivisionName)
            MediaInvoiceDefault.PrintProductDescription = Convert.ToInt16(Me.PrintProductDescription)
            MediaInvoiceDefault.PrintContactAfterAddress = Convert.ToInt16(Me.PrintContactAfterAddress)
            MediaInvoiceDefault.ContactType = Me.ContactType
            MediaInvoiceDefault.IncludeBillingComment = Convert.ToInt16(Me.IncludeBillingComment)
            MediaInvoiceDefault.ApplyExchangeRate = Convert.ToInt16(If(Me.ApplyExchangeRate, 2, 1))
            MediaInvoiceDefault.ExchangeRateAmount = Me.ExchangeRateAmount.GetValueOrDefault(1)
            MediaInvoiceDefault.HideExchangeRateMessage = Me.HideExchangeRateMessage
            MediaInvoiceDefault.InvoiceFooterCommentType = Me.InvoiceFooterCommentType
			MediaInvoiceDefault.InvoiceFooterComment = Me.InvoiceFooterComment
			MediaInvoiceDefault.PrintClientName = Me.PrintClientName
            MediaInvoiceDefault.ShowCodes = Me.ShowCodes

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.MediaInvoiceSettingID.ToString

        End Function

#End Region

    End Class

End Namespace
