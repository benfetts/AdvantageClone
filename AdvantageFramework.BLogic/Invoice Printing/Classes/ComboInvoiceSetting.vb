Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class ComboInvoiceSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ComboInvoicePrintingOptionsID
            AddressBlockType
            LocationCode
            CustomFormatName
            ApplyExchangeRate
            ExchangeRateAmount
            PrintClientName
            PrintDivisionName
            PrintProductDescription
            PrintContactAfterAddress
            UseInvoiceCategoryDescription
            InvoiceTitle
            InvoiceFooterCommentType
            InvoiceFooterComment
            ContactType
            ShowCodes
            IncludeInvoiceDueDate
            PageSetting
        End Enum

#End Region

#Region " Variables "

        Private _ComboInvoicePrintingOptionsID As Integer = 0
        Private _AddressBlockType As Short = 1
        Private _LocationCode As String = Nothing
        Private _CustomFormatName As String = ""
        Private _ApplyExchangeRate As Boolean = False
        Private _ExchangeRateAmount As System.Nullable(Of Decimal) = 0
        Private _PrintClientName As Boolean = False
        Private _PrintDivisionName As Boolean = False
        Private _PrintProductDescription As Boolean = False
        Private _PrintContactAfterAddress As Boolean = False
        Private _UseInvoiceCategoryDescription As Boolean = False
        Private _InvoiceTitle As String = ""
        Private _InvoiceFooterCommentType As Short = 1
        Private _InvoiceFooterComment As String = ""
        Private _ShowCodes As Boolean = False
        Private _ContactType As Integer = 0
        Private _IncludeInvoiceDueDate As Boolean = False

        Private _ComboInvoiceDefault As AdvantageFramework.Database.Entities.ComboInvoiceDefault = Nothing
        Private _InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
        System.ComponentModel.Browsable(False)>
        Public Property ComboInvoicePrintingOptionsID() As Long
            Get
                ComboInvoicePrintingOptionsID = _ComboInvoicePrintingOptionsID
            End Get
            Set(ByVal value As Long)
                _ComboInvoicePrintingOptionsID = value
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
		'<System.Runtime.Serialization.DataMemberAttribute(),
		'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		'System.ComponentModel.DataAnnotations.MaxLength(50),
		'System.ComponentModel.Browsable(False)>
		'Public Property CustomFormatName() As String
		'    Get
		'        CustomFormatName = _CustomFormatName
		'    End Get
		'    Set(ByVal value As String)
		'        _CustomFormatName = value
		'    End Set
		'End Property
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
		System.ComponentModel.DisplayName("Print Client Name")>
		Public Property PrintClientName() As Boolean
			Get
				PrintClientName = _PrintClientName
			End Get
			Set(value As Boolean)
				_PrintClientName = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Print Division Name")>
		Public Property PrintDivisionName() As Boolean
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
		Public Property PrintProductDescription() As Boolean
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
		Public Property PrintContactAfterAddress() As Boolean
			Get
				PrintContactAfterAddress = _PrintContactAfterAddress
			End Get
			Set(ByVal value As Boolean)
				_PrintContactAfterAddress = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.Category("Title")>
		Public Property UseInvoiceCategoryDescription() As Boolean
			Get
				UseInvoiceCategoryDescription = _UseInvoiceCategoryDescription
			End Get
			Set(ByVal value As Boolean)
				_UseInvoiceCategoryDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DataAnnotations.MaxLength(20),
		System.ComponentModel.Category("Title")>
		Public Property InvoiceTitle() As String
			Get
				InvoiceTitle = _InvoiceTitle
			End Get
			Set(ByVal value As String)
				_InvoiceTitle = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Type")>
		Public Property InvoiceFooterCommentType() As Short
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
		Public Property InvoiceFooterComment() As String
            Get
                InvoiceFooterComment = _InvoiceFooterComment
            End Get
            Set(ByVal value As String)
                _InvoiceFooterComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
        System.ComponentModel.DisplayName("Show Codes")>
        Public Property ShowCodes() As Boolean
            Get
                ShowCodes = _ShowCodes
            End Get
            Set(value As Boolean)
                _ShowCodes = value
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
        System.ComponentModel.DisplayName("Invoice Due Date")>
        Public Property IncludeInvoiceDueDate() As Boolean
            Get
                IncludeInvoiceDueDate = _IncludeInvoiceDueDate
            End Get
            Set(ByVal value As Boolean)
                _IncludeInvoiceDueDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
        System.ComponentModel.DisplayName("Page Setting")>
        Public Property PageSetting() As Short

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal ComboInvoiceDefault As AdvantageFramework.Database.Entities.ComboInvoiceDefault)

            Me.ComboInvoicePrintingOptionsID = ComboInvoiceDefault.ID

            Me.AddressBlockType = ComboInvoiceDefault.AddressBlockType.GetValueOrDefault(1)
            Me.LocationCode = ComboInvoiceDefault.LocationCode
            'Me.CustomFormatName = ComboInvoiceDefault.CustomFormatName
            Me.ApplyExchangeRate = If(ComboInvoiceDefault.ApplyExchangeRate.GetValueOrDefault(1) = 2, True, False)
            Me.ExchangeRateAmount = ComboInvoiceDefault.ExchangeRateAmount.GetValueOrDefault(1)
            Me.PrintClientName = ComboInvoiceDefault.PrintClientName
            Me.PrintDivisionName = ComboInvoiceDefault.PrintDivisionName
            Me.PrintProductDescription = ComboInvoiceDefault.PrintProductDescription
            Me.PrintContactAfterAddress = ComboInvoiceDefault.PrintContactAfterAddress
            Me.UseInvoiceCategoryDescription = ComboInvoiceDefault.UseInvoiceCategoryDescription
            Me.InvoiceTitle = ComboInvoiceDefault.InvoiceTitle
            Me.InvoiceFooterCommentType = ComboInvoiceDefault.InvoiceFooterCommentType
            Me.InvoiceFooterComment = ComboInvoiceDefault.InvoiceFooterComment
            Me.ShowCodes = ComboInvoiceDefault.ShowCodes
            Me.ContactType = ComboInvoiceDefault.ContactType
            Me.IncludeInvoiceDueDate = ComboInvoiceDefault.IncludeInvoiceDueDate
            Me.PageSetting = ComboInvoiceDefault.PageSetting

            _ComboInvoiceDefault = ComboInvoiceDefault

        End Sub
        Public Sub New(ByVal InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting)

            Me.ComboInvoicePrintingOptionsID = InvoicePrintingComboSetting.ComboInvoicePrintingOptionsID.GetValueOrDefault(0)

            Me.AddressBlockType = InvoicePrintingComboSetting.AddressBlockType.GetValueOrDefault(1)
            Me.LocationCode = InvoicePrintingComboSetting.LocationCode
            'Me.CustomFormatName = InvoicePrintingComboSetting.CustomFormatName
            Me.ApplyExchangeRate = If(InvoicePrintingComboSetting.ApplyExchangeRate.GetValueOrDefault(1) = 2, True, False)
            Me.ExchangeRateAmount = InvoicePrintingComboSetting.ExchangeRateAmount.GetValueOrDefault(1)
            Me.PrintClientName = InvoicePrintingComboSetting.PrintClientName
            Me.PrintDivisionName = InvoicePrintingComboSetting.PrintDivisionName.GetValueOrDefault(False)
            Me.PrintProductDescription = InvoicePrintingComboSetting.PrintProductDescription.GetValueOrDefault(False)
            Me.PrintContactAfterAddress = InvoicePrintingComboSetting.PrintContactAfterAddress.GetValueOrDefault(False)
            Me.UseInvoiceCategoryDescription = InvoicePrintingComboSetting.UseInvoiceCategoryDescription.GetValueOrDefault(False)
            Me.InvoiceTitle = InvoicePrintingComboSetting.InvoiceTitle
            Me.InvoiceFooterCommentType = InvoicePrintingComboSetting.InvoiceFooterCommentType.GetValueOrDefault(1)
            Me.InvoiceFooterComment = InvoicePrintingComboSetting.InvoiceFooterComment
            Me.ShowCodes = InvoicePrintingComboSetting.ShowCodes
            Me.ContactType = InvoicePrintingComboSetting.ContactType
            Me.IncludeInvoiceDueDate = InvoicePrintingComboSetting.IncludeInvoiceDueDate
            Me.PageSetting = InvoicePrintingComboSetting.PageSetting

            _InvoicePrintingComboSetting = InvoicePrintingComboSetting

        End Sub
        Public Function GetEntity() As Object

            If _InvoicePrintingComboSetting IsNot Nothing Then

                GetEntity = _InvoicePrintingComboSetting

            ElseIf _ComboInvoiceDefault IsNot Nothing Then

                GetEntity = _ComboInvoiceDefault

            Else

                GetEntity = Nothing

            End If

        End Function
        Public Function SaveAndGetEntity() As Object

            Save()

            If _InvoicePrintingComboSetting IsNot Nothing Then

                SaveAndGetEntity = _InvoicePrintingComboSetting

            ElseIf _ComboInvoiceDefault IsNot Nothing Then

                SaveAndGetEntity = _ComboInvoiceDefault

            Else

                SaveAndGetEntity = Nothing

            End If

        End Function
        Public Sub Save()

            If _InvoicePrintingComboSetting IsNot Nothing Then

                Save(_InvoicePrintingComboSetting)

            ElseIf _ComboInvoiceDefault IsNot Nothing Then

                Save(_ComboInvoiceDefault)

            End If

        End Sub
        Public Sub Save(ByVal InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting)

            InvoicePrintingComboSetting.AddressBlockType = Me.AddressBlockType
            InvoicePrintingComboSetting.LocationCode = Me.LocationCode
            InvoicePrintingComboSetting.ApplyExchangeRate = If(Me.ApplyExchangeRate, 2, 1)
            InvoicePrintingComboSetting.ExchangeRateAmount = Me.ExchangeRateAmount
            InvoicePrintingComboSetting.PrintClientName = Me.PrintClientName
            InvoicePrintingComboSetting.PrintDivisionName = Me.PrintDivisionName
            InvoicePrintingComboSetting.PrintProductDescription = Me.PrintProductDescription
            InvoicePrintingComboSetting.PrintContactAfterAddress = Me.PrintContactAfterAddress
            InvoicePrintingComboSetting.UseInvoiceCategoryDescription = Me.UseInvoiceCategoryDescription
            InvoicePrintingComboSetting.InvoiceTitle = Me.InvoiceTitle
            InvoicePrintingComboSetting.InvoiceFooterCommentType = Me.InvoiceFooterCommentType
            InvoicePrintingComboSetting.InvoiceFooterComment = Me.InvoiceFooterComment
            InvoicePrintingComboSetting.ShowCodes = Me.ShowCodes
            InvoicePrintingComboSetting.ContactType = Me.ContactType
            InvoicePrintingComboSetting.IncludeInvoiceDueDate = Me.IncludeInvoiceDueDate
            InvoicePrintingComboSetting.PageSetting = Me.PageSetting

        End Sub
        Public Sub Save(ByVal ComboInvoiceDefault As AdvantageFramework.Database.Entities.ComboInvoiceDefault)

            ComboInvoiceDefault.AddressBlockType = Me.AddressBlockType
            ComboInvoiceDefault.LocationCode = Me.LocationCode
            ComboInvoiceDefault.ApplyExchangeRate = Convert.ToInt16(If(Me.ApplyExchangeRate = True, 2, 1))
            ComboInvoiceDefault.ExchangeRateAmount = Me.ExchangeRateAmount
            ComboInvoiceDefault.PrintClientName = Me.PrintClientName
            ComboInvoiceDefault.PrintDivisionName = Me.PrintDivisionName
            ComboInvoiceDefault.PrintProductDescription = Me.PrintProductDescription
            ComboInvoiceDefault.PrintContactAfterAddress = Me.PrintContactAfterAddress
            ComboInvoiceDefault.UseInvoiceCategoryDescription = Me.UseInvoiceCategoryDescription
            ComboInvoiceDefault.InvoiceTitle = Me.InvoiceTitle
            ComboInvoiceDefault.InvoiceFooterCommentType = Me.InvoiceFooterCommentType
            ComboInvoiceDefault.InvoiceFooterComment = Me.InvoiceFooterComment
            ComboInvoiceDefault.ShowCodes = Me.ShowCodes
            ComboInvoiceDefault.ContactType = Me.ContactType
            ComboInvoiceDefault.IncludeInvoiceDueDate = Me.IncludeInvoiceDueDate
            ComboInvoiceDefault.PageSetting = Me.PageSetting

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ComboInvoicePrintingOptionsID.ToString

        End Function

#End Region

    End Class

End Namespace
