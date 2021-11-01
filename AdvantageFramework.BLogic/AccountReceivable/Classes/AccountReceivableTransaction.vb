Namespace AccountReceivable.Classes

    <Serializable()>
    Public Class AccountReceivableTransaction
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            GLSourceCode
            Transaction
            PostPeriodCode
            TransactionDate
            UserCode
        End Enum

#End Region

#Region " Variables "

        Private _GLSourceCode As String = Nothing
        Private _Transaction As Integer = Nothing
        Private _PostPeriodCode As String = Nothing
        Private _TransactionDate As Date = Nothing
        Private _UserCode As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLSourceCode() As String
            Get
                GLSourceCode = _GLSourceCode
            End Get
            Set(value As String)
                _GLSourceCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Transaction() As Integer
            Get
                Transaction = _Transaction
            End Get
            Set(value As Integer)
                _Transaction = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Post Period")>
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set(value As String)
                _PostPeriodCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property TransactionDate() As Date
            Get
                TransactionDate = _TransactionDate
            End Get
            Set(value As Date)
                _TransactionDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property UserCode() As String
            Get
                UserCode = _UserCode
            End Get
            Set(value As String)
                _UserCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLTransaction As Integer)

            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing

            GeneralLedger = AdvantageFramework.Database.Procedures.GeneralLedger.LoadByTransaction(DbContext, GLTransaction)

            If GeneralLedger IsNot Nothing Then

                _GLSourceCode = GeneralLedger.GLSourceCode
                _Transaction = GeneralLedger.Transaction
                _PostPeriodCode = GeneralLedger.PostPeriodCode
                _TransactionDate = GeneralLedger.EnteredDate
                _UserCode = GeneralLedger.UserCode

            End If

        End Sub

#End Region

    End Class

End Namespace

