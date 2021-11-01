Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class OpenPOItem

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            IssueDate
            VendorName
            PONumber
            Description
            LineNumber
            LineDescription
            Quantity
            Rate
            Amount
            MarkupAmount
            Total
            OpenPOAmount
            DetailDescription
            Detailinstructions
        End Enum

#End Region

#Region " Variables "

        Private _IssueDate As Nullable(Of Date) = Nothing
        Private _VendorName As String = Nothing
        Private _PONumber As Integer = Nothing
        Private _Description As String = Nothing
        Private _LineNumber As Integer = Nothing
        Private _LineDescription As String = Nothing
        Private _Quantity As Nullable(Of Integer) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _Amount As Nullable(Of Decimal) = Nothing
        Private _MarkupAmount As Nullable(Of Decimal) = Nothing
        Private _Total As Decimal = Nothing
        Private _OpenPOAmount As Nullable(Of Decimal) = Nothing
        Private _DetailDescription As String = Nothing
        Private _DetailInstructions As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IssueDate() As Nullable(Of Date)
            Get
                IssueDate = _IssueDate
            End Get
            Set(value As Nullable(Of Date))
                _IssueDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(value As String)
                _VendorName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property PONumber() As Integer
            Get
                PONumber = _PONumber
            End Get
            Set(value As Integer)
                _PONumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(value As String)
                _Description = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property LineNumber() As Integer
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Integer)
                _LineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property LineDescription() As String
            Get
                LineDescription = _LineDescription
            End Get
            Set(value As String)
                _LineDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Quantity() As Nullable(Of Integer)
            Get
                Quantity = _Quantity
            End Get
            Set(value As Nullable(Of Integer))
                _Quantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n3")>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _Amount
            End Get
            Set(value As Nullable(Of Decimal))
                _Amount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property MarkupAmount() As Nullable(Of Decimal)
            Get
                MarkupAmount = _MarkupAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _MarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Total() As Decimal
            Get
                Total = _Total
            End Get
            Set(value As Decimal)
                _Total = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property OpenPOAmount() As Nullable(Of Decimal)
            Get
                OpenPOAmount = _OpenPOAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _OpenPOAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DetailDescription() As String
            Get
                DetailDescription = _DetailDescription
            End Get
            Set(value As String)
                _DetailDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DetailInstructions() As String
            Get
                DetailInstructions = _DetailInstructions
            End Get
            Set(value As String)
                _DetailInstructions = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace