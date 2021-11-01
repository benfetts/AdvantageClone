Namespace Exporting.DataClasses

    <Serializable()>
    Public Class AccountPayableAnswersOnDemand
        Implements AdvantageFramework.Exporting.Interfaces.IExportData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AccountPayableID
            HeaderRecordIdentifier
            VendorCode
            InvoiceNumber
            InvoiceDate
            DueDate
            InvoiceDescription
            TotalPayable
            PostingMonthYear
            DetailRecordIdentifier
            ClientCode
            DivisionCode
            ProductCode
            DistributedGLAccount
            DistributedAmount
            NegativeDistributedAmount
            PositiveDistributedAmount
            SignIndicator
        End Enum

#End Region

#Region " Variables "

        Private _AccountPayableID As Integer = Nothing
        Private _HeaderRecordIdentifier As String = Nothing
        Private _VendorCode As String = Nothing
        Private _InvoiceNumber As String = Nothing
        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _DueDate As Nullable(Of Date) = Nothing
        Private _InvoiceDescription As String = Nothing
        Private _TotalPayable As Decimal = Nothing
        Private _PostingMonthYear As String = Nothing
        Private _DetailRecordIdentifier As String = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _DistributedGLAccount As String = Nothing
        Private _DistributedAmount As Nullable(Of Decimal) = Nothing
        Private _EntryDate As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "
        
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property AccountPayableID() As Integer
            Get
                AccountPayableID = _AccountPayableID
            End Get
            Set(value As Integer)
                _AccountPayableID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Header ID")>
        Public Property HeaderRecordIdentifier() As String
            Get
                HeaderRecordIdentifier = _HeaderRecordIdentifier
            End Get
            Set(value As String)
                _HeaderRecordIdentifier = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property InvoiceNumber() As String
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(value As String)
                _InvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Nullable(Of Date))
                _InvoiceDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property DueDate() As Nullable(Of Date)
            Get
                DueDate = _DueDate
            End Get
            Set(value As Nullable(Of Date))
                _DueDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property InvoiceDescription() As String
            Get
                InvoiceDescription = _InvoiceDescription
            End Get
            Set(value As String)
                _InvoiceDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property TotalPayable As Decimal
            Get
                TotalPayable = _TotalPayable
            End Get
            Set(value As Decimal)
                _TotalPayable = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
                Public Property PostingMonthYear() As String
            Get
                PostingMonthYear = _PostingMonthYear
            End Get
            Set(value As String)
                _PostingMonthYear = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Detail ID")>
        Public Property DetailRecordIdentifier() As String
            Get
                DetailRecordIdentifier = _DetailRecordIdentifier
            End Get
            Set(value As String)
                _DetailRecordIdentifier = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Detail GL Account")>
        Public Property DistributedGLAccount() As String
            Get
                DistributedGLAccount = _DistributedGLAccount
            End Get
            Set(value As String)
                _DistributedGLAccount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True, ShowColumnInGrid:=False, CustomColumnCaption:="Detail Amount")>
        Public Property DistributedAmount() As Nullable(Of Decimal)
            Get
                DistributedAmount = _DistributedAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _DistributedAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Negative Detail Amount")>
        Public ReadOnly Property NegativeDistributedAmount() As Nullable(Of Decimal)
            Get
                NegativeDistributedAmount = If(_DistributedAmount < 0, _DistributedAmount, Nothing)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Positive Detail Amount")>
        Public ReadOnly Property PositiveDistributedAmount() As Nullable(Of Decimal)
            Get
                PositiveDistributedAmount = If(_DistributedAmount >= 0, _DistributedAmount, Nothing)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property SignIndicator() As Short
            Get
                SignIndicator = If(_DistributedAmount >= 0, 0, 1)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, IsReadOnlyColumn:=True)>
        Public Property EntryDate() As Nullable(Of Date)
            Get
                EntryDate = _EntryDate
            End Get
            Set(value As Nullable(Of Date))
                _EntryDate = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
