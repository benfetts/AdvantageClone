Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class InvoicePrintingComboSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ComboInvoicePrintingOptionsID
            IsOneTime
            Type
            ClientCode
            AddressBlockType
            LocationCode
            'CustomFormatName
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
            ShowCodes
            ContactType
            IncludeInvoiceDueDate
            PageSetting
            PageHeaderComment
            PageFooterComment
            PageHeaderLogoPath
            PageHeaderLogoPathLandscape
            PageFooterLogoPath
            PageFooterLogoPathLandscape
            ShowPageHeaderLogo
            ShowPageFooterLogo
        End Enum

#End Region

#Region " Variables "

        Private _ComboInvoicePrintingOptionsID As Nullable(Of Integer) = Nothing
        Private _IsOneTime As Nullable(Of Boolean) = Nothing
        Private _Type As Nullable(Of Short) = Nothing
        Private _ClientCode As String = Nothing
        Private _AddressBlockType As Nullable(Of Short) = Nothing
        Private _LocationCode As String = Nothing
        'Private _CustomFormatName As String = Nothing
        Private _ApplyExchangeRate As Nullable(Of Short) = Nothing
        Private _ExchangeRateAmount As Nullable(Of Decimal) = Nothing
        Private _PrintClientName As Boolean = Nothing
        Private _PrintDivisionName As Nullable(Of Boolean) = Nothing
        Private _PrintProductDescription As Nullable(Of Boolean) = Nothing
        Private _PrintContactAfterAddress As Nullable(Of Boolean) = Nothing
        Private _UseInvoiceCategoryDescription As Nullable(Of Boolean) = Nothing
        Private _InvoiceTitle As String = Nothing
        Private _InvoiceFooterCommentType As Nullable(Of Short) = Nothing
        Private _InvoiceFooterComment As String = Nothing
        Private _ShowCodes As Boolean = Nothing
        Private _ContactType As Integer = 0
        Private _IncludeInvoiceDueDate As Boolean = Nothing
        Private _PageHeaderComment As String = Nothing
        Private _PageFooterComment As String = Nothing
        Private _PageHeaderLogoPath As String = Nothing
        Private _PageHeaderLogoPathLandscape As String = Nothing
        Private _PageFooterLogoPath As String = Nothing
        Private _PageFooterLogoPathLandscape As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ComboInvoicePrintingOptionsID() As Nullable(Of Integer)
            Get
                ComboInvoicePrintingOptionsID = _ComboInvoicePrintingOptionsID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _ComboInvoicePrintingOptionsID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsOneTime() As Nullable(Of Boolean)
            Get
                IsOneTime = _IsOneTime
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _IsOneTime = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Type() As Nullable(Of Short)
            Get
                Type = _Type
            End Get
            Set(ByVal value As Nullable(Of Short))
                _Type = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AddressBlockType() As Nullable(Of Short)
            Get
                AddressBlockType = _AddressBlockType
            End Get
            Set(ByVal value As Nullable(Of Short))
                _AddressBlockType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LocationCode() As String
            Get
                LocationCode = _LocationCode
            End Get
            Set(ByVal value As String)
                _LocationCode = value
            End Set
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property CustomFormatName() As String
        '    Get
        '        CustomFormatName = _CustomFormatName
        '    End Get
        '    Set(ByVal value As String)
        '        _CustomFormatName = value
        '    End Set
        'End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ApplyExchangeRate() As Nullable(Of Short)
            Get
                ApplyExchangeRate = _ApplyExchangeRate
            End Get
            Set(ByVal value As Nullable(Of Short))
                _ApplyExchangeRate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExchangeRateAmount() As Nullable(Of Decimal)
            Get
                ExchangeRateAmount = _ExchangeRateAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ExchangeRateAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintClientName() As Boolean
            Get
                PrintClientName = _PrintClientName
            End Get
            Set(value As Boolean)
                _PrintClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintDivisionName() As Nullable(Of Boolean)
            Get
                PrintDivisionName = _PrintDivisionName
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _PrintDivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintProductDescription() As Nullable(Of Boolean)
            Get
                PrintProductDescription = _PrintProductDescription
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _PrintProductDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintContactAfterAddress() As Nullable(Of Boolean)
            Get
                PrintContactAfterAddress = _PrintContactAfterAddress
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _PrintContactAfterAddress = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property UseInvoiceCategoryDescription() As Nullable(Of Boolean)
            Get
                UseInvoiceCategoryDescription = _UseInvoiceCategoryDescription
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _UseInvoiceCategoryDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceTitle() As String
            Get
                InvoiceTitle = _InvoiceTitle
            End Get
            Set(ByVal value As String)
                _InvoiceTitle = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceFooterCommentType() As Nullable(Of Short)
            Get
                InvoiceFooterCommentType = _InvoiceFooterCommentType
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InvoiceFooterCommentType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceFooterComment() As String
            Get
                InvoiceFooterComment = _InvoiceFooterComment
            End Get
            Set(ByVal value As String)
                _InvoiceFooterComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowCodes() As Boolean
            Get
                ShowCodes = _ShowCodes
            End Get
            Set(value As Boolean)
                _ShowCodes = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ContactType() As Integer
            Get
                ContactType = _ContactType
            End Get
            Set(value As Integer)
                _ContactType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeInvoiceDueDate() As Boolean
            Get
                IncludeInvoiceDueDate = _IncludeInvoiceDueDate
            End Get
            Set(value As Boolean)
                _IncludeInvoiceDueDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageSetting() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageHeaderComment() As String
            Get
                PageHeaderComment = _PageHeaderComment
            End Get
            Set(ByVal value As String)
                _PageHeaderComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageFooterComment() As String
            Get
                PageFooterComment = _PageFooterComment
            End Get
            Set(ByVal value As String)
                _PageFooterComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageHeaderLogoPath() As String
            Get
                PageHeaderLogoPath = _PageHeaderLogoPath
            End Get
            Set(ByVal value As String)
                _PageHeaderLogoPath = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageHeaderLogoPathLandscape() As String
            Get
                PageHeaderLogoPathLandscape = _PageHeaderLogoPathLandscape
            End Get
            Set(ByVal value As String)
                _PageHeaderLogoPathLandscape = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageFooterLogoPath() As String
            Get
                PageFooterLogoPath = _PageFooterLogoPath
            End Get
            Set(ByVal value As String)
                _PageFooterLogoPath = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageFooterLogoPathLandscape() As String
            Get
                PageFooterLogoPathLandscape = _PageFooterLogoPathLandscape
            End Get
            Set(ByVal value As String)
                _PageFooterLogoPathLandscape = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowPageHeaderLogo() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowPageFooterLogo() As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.IsOneTime.ToString

        End Function

#End Region

    End Class

End Namespace
