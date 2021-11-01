Namespace AccountPayable.Classes

    <Serializable()>
    Public Class AccountPayablePurchaseOrderDetail
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            LineNumber
            LineDescription
            GLACode
            Quantity
            Rate
            ExtendedAmount
            IsComplete
            Comment
            POBalance
        End Enum

#End Region

#Region " Variables "

        Private _LineNumber As Integer = 0
        Private _LineDescription As String = Nothing
        Private _GLACode As String = Nothing
        Private _Quantity As Nullable(Of Integer) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _ExtendedAmount As Nullable(Of Decimal) = Nothing
        Private _IsComplete As Boolean = False
        Private _Comment As String = Nothing
        Private _POBalance As Decimal = 0

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LineNumber() As Integer
            Get
                LineNumber = _LineNumber
            End Get
            Set(ByVal value As Integer)
                _LineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Description")>
        Public Property LineDescription() As String
            Get
                LineDescription = _LineDescription
            End Get
            Set(ByVal value As String)
                _LineDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Detail Description")>
        Public Property Comment() As String
            Get
                Comment = _Comment
            End Get
            Set(ByVal value As String)
                _Comment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Quantity() As Nullable(Of Decimal)
            Get
                Quantity = _Quantity
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n4")>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _ExtendedAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ExtendedAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property MarkedComplete() As Boolean
            Get
                MarkedComplete = _IsComplete
            End Get
            Set(ByVal value As Boolean)
                _IsComplete = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account")>
        Public Property GLACode() As String
            Get
                GLACode = _GLACode
            End Get
            Set(ByVal value As String)
                _GLACode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="PO Balance")>
        Public Property POBalance() As Nullable(Of Decimal)
            Get
                POBalance = _POBalance
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _POBalance = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail)

            Dim PreviouslyApplied As Decimal = 0

            _LineNumber = PurchaseOrderDetail.LineNumber
            _LineDescription = PurchaseOrderDetail.LineDescription
            _GLACode = PurchaseOrderDetail.GLACode
            _Quantity = PurchaseOrderDetail.Quantity
            _Rate = PurchaseOrderDetail.Rate
            _ExtendedAmount = PurchaseOrderDetail.ExtendedAmount
            _IsComplete = CBool(PurchaseOrderDetail.IsComplete.GetValueOrDefault(0))
            _Comment = PurchaseOrderDetail.Description

            If PurchaseOrderDetail.JobNumber IsNot Nothing Then

                Try

                    PreviouslyApplied = AdvantageFramework.Database.Procedures.AccountPayableProduction.LoadAllActiveByPONumberAndPODetailLineNumber(DbContext, PurchaseOrderDetail.PurchaseOrderNumber, PurchaseOrderDetail.LineNumber).Sum(Function(P) P.ExtendedAmount)

                Catch ex As Exception
                    PreviouslyApplied = 0
                End Try

            Else

                Try

                    PreviouslyApplied = AdvantageFramework.Database.Procedures.AccountPayableGLDistribution.LoadAllActiveByPONumberAndPODetailLineNumber(DbContext, PurchaseOrderDetail.PurchaseOrderNumber, PurchaseOrderDetail.LineNumber).Sum(Function(P) P.Amount)

                Catch ex As Exception
                    PreviouslyApplied = 0
                End Try

            End If

            _POBalance = PurchaseOrderDetail.ExtendedAmount.GetValueOrDefault(0) - PreviouslyApplied

        End Sub

#End Region

    End Class

End Namespace


