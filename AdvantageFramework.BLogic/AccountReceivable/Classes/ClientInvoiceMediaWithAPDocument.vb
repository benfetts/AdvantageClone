Namespace AccountReceivable.Classes

    <Serializable()>
    Public Class ClientInvoiceMediaWithAPDocument

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            InvoiceNumber
            SequenceNumber
            Type
            AccountPayableID
        End Enum

#End Region

#Region " Variables "

        Private _InvoiceNumber As Integer = Nothing
        Private _SequenceNumber As Short = Nothing
        Private _Type As String = Nothing
        Private _AccountPayableID As Integer = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property InvoiceNumber() As Integer
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(value As Integer)
                _InvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Seq Nbr")>
        Public Property SequenceNumber() As Short
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(value As Short)
                _SequenceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Type() As String
            Get
                Type = _Type
            End Get
            Set(value As String)
                _Type = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AccountPayableID() As Integer
            Get
                AccountPayableID = _AccountPayableID
            End Get
            Set(value As Integer)
                _AccountPayableID = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace

