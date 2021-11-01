Namespace Exporting.DataClasses

    <Serializable()>
    Public Class AccountPayableCustom1
        Implements AdvantageFramework.Exporting.Interfaces.IExportData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AccountPayableID
            VendorCode
            VendorAccountNumber
            VendorName
            InvoiceDate
            InvoiceNumber
            InvoiceTotal
            JobComponent
            Department
            BusinessUnit
            Product
            AccountNumber
            Total
            ExportDate
            CurrencyCode
            Include
        End Enum

#End Region

#Region " Variables "

        Private _AccountPayableID As Integer = Nothing
        Private _VendorAccountNumber As String = Nothing
        Private _VendorCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _InvoiceDate As Date = Nothing
        Private _InvoiceNumber As String = Nothing
        Private _InvoiceTotal As Decimal = Nothing
        Private _JobComponent As String = Nothing
        Private _Department As String = Nothing
        Private _BusinessUnit As String = Nothing
        Private _Product As String = Nothing
        Private _AccountNumber As String = Nothing
        Private _Total As Decimal = Nothing
        Private _ExportDate As Nullable(Of Date) = Nothing
        Private _CurrencyCode As String = Nothing
        Private _Include As Boolean = False

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property AccountPayableID() As Integer
            Get
                AccountPayableID = _AccountPayableID
            End Get
            Set(value As Integer)
                _AccountPayableID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property VendorAccountNumber() As String
            Get
                VendorAccountNumber = _VendorAccountNumber
            End Get
            Set(value As String)
                _VendorAccountNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(value As String)
                _VendorName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceDate() As Date
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Date)
                _InvoiceDate = value
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
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property InvoiceTotal() As Decimal
            Get
                InvoiceTotal = _InvoiceTotal
            End Get
            Set(value As Decimal)
                _InvoiceTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property JobComponent As String
            Get
                JobComponent = _JobComponent
            End Get
            Set(value As String)
                _JobComponent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Department() As String
            Get
                Department = _Department
            End Get
            Set(value As String)
                _Department = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property BusinessUnit() As String
            Get
                BusinessUnit = _BusinessUnit
            End Get
            Set(value As String)
                _BusinessUnit = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Product() As String
            Get
                Product = _Product
            End Get
            Set(value As String)
                _Product = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property AccountNumber() As String
            Get
                AccountNumber = _AccountNumber
            End Get
            Set(value As String)
                _AccountNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property Total() As Decimal
            Get
                Total = _Total
            End Get
            Set(value As Decimal)
                _Total = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ExportDate() As Nullable(Of Date)
            Get
                ExportDate = _ExportDate
            End Get
            Set(value As Nullable(Of Date))
                _ExportDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property CurrencyCode() As String
            Get
                CurrencyCode = _CurrencyCode
            End Get
            Set(value As String)
                _CurrencyCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Include() As Boolean
            Get
                Include = _Include
            End Get
            Set(value As Boolean)
                _Include = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
