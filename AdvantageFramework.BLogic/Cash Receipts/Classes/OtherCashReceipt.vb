Namespace CashReceipts.Classes

    <Serializable()>
    Public Class OtherCashReceipt

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            SequenceNumber
            Bank
            CheckNumber
            PostPeriodCode
            CheckDate
            CheckAmount
            DepositDate
            GLACode
            Description
        End Enum

#End Region

#Region " Variables "

        Private _OtherCashReceipt As AdvantageFramework.Database.Entities.OtherCashReceipt = Nothing
        Private _BankName As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _OtherCashReceipt.ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property SequenceNumber() As Short
            Get
                SequenceNumber = _OtherCashReceipt.SequenceNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Bank() As String
            Get
                Bank = _BankName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property CheckNumber() As String
            Get
                CheckNumber = _OtherCashReceipt.CheckNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property PostPeriodCode() As String
            Get
                PostPeriodCode = _OtherCashReceipt.PostPeriodCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property CheckDate() As Date
            Get
                CheckDate = _OtherCashReceipt.CheckDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property CheckAmount() As Decimal
            Get
                CheckAmount = _OtherCashReceipt.CheckAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DepositDate() As Nullable(Of Date)
            Get
                DepositDate = _OtherCashReceipt.DepositDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property GLACode() As String
            Get
                GLACode = _OtherCashReceipt.GLACode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Description() As String
            Get
                Description = _OtherCashReceipt.Description
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal OtherCashReceipt As AdvantageFramework.Database.Entities.OtherCashReceipt)

            _OtherCashReceipt = OtherCashReceipt

            If OtherCashReceipt.Bank IsNot Nothing Then

                _BankName = OtherCashReceipt.Bank.ToString

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace

