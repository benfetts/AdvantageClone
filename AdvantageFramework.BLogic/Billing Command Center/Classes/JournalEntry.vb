Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class JournalEntry

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            GLTransaction
            GLSequenceNumber
            GLACode
            GLDescription
            PostPeriodCode
            Amount
            Remark
            ClientCode
            DivisionCode
            ProductCode
        End Enum

#End Region

#Region " Variables "

        Private _GLTransaction As Integer = Nothing
        Private _GLSequenceNumber As Short = Nothing
        Private _GLACode As String = Nothing
        Private _GLDescription As String = Nothing
        Private _PostPeriodCode As String = Nothing
        Private _Amount As Double = Nothing
        Private _Remark As String = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLTransaction() As Integer
            Get
                GLTransaction = _GLTransaction
            End Get
            Set(value As Integer)
                _GLTransaction = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="GL SEQ")>
        Public Property GLSequenceNumber() As Short
            Get
                GLSequenceNumber = _GLSequenceNumber
            End Get
            Set(value As Short)
                _GLSequenceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLACode() As String
            Get
                GLACode = _GLACode
            End Get
            Set(value As String)
                _GLACode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLDescription() As String
            Get
                GLDescription = _GLDescription
            End Get
            Set(value As String)
                _GLDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set(value As String)
                _PostPeriodCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Amount() As Double
            Get
                Amount = _Amount
            End Get
            Set(value As Double)
                _Amount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Remark() As String
            Get
                Remark = _Remark
            End Get
            Set(value As String)
                _Remark = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
