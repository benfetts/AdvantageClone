Namespace Reporting.Database.Classes

    <Serializable>
    Public Class SalesAndCostOfSalesByClientReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            SalesOrCostOfSales
            ClientCode
            ClientName
            MediaType
            GLACode
            MappedAccount
            TargetAccount
            Amount
            AbsoluteAmount
            DebitOrCredit
        End Enum

#End Region

#Region " Variables "

        Private _ID As System.Guid = Nothing
        Private _SalesOrCostOfSales As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _MediaType As String = Nothing
        Private _GLACode As String = Nothing
        Private _MappedAccount As String = Nothing
        Private _TargetAccount As String = Nothing
        Private _Amount As Decimal = Nothing
        Private _AbsoluteAmount As Decimal = Nothing
        Private _DebitOrCredit As String = Nothing
#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
            Get
                ID = _ID
            End Get
            Set(ByVal value As System.Guid)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesOrCostOfSales() As String
            Get
                SalesOrCostOfSales = _SalesOrCostOfSales
            End Get
            Set(ByVal value As String)
                _SalesOrCostOfSales = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(ByVal value As String)
                _ClientName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaType() As String
            Get
                MediaType = _MediaType
            End Get
            Set(ByVal value As String)
                _MediaType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLACode() As String
            Get
                GLACode = _GLACode
            End Get
            Set(ByVal value As String)
                _GLACode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MappedAccount() As String
            Get
                MappedAccount = _MappedAccount
            End Get
            Set(ByVal value As String)
                _MappedAccount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TargetAccount() As String
            Get
                TargetAccount = _TargetAccount
            End Get
            Set(ByVal value As String)
                _TargetAccount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _Amount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Amount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property AbsoluteAmount() As Nullable(Of Decimal)
            Get
                AbsoluteAmount = _AbsoluteAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AbsoluteAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DebitOrCredit() As String
            Get
                DebitOrCredit = _DebitOrCredit
            End Get
            Set(ByVal value As String)
                _DebitOrCredit = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
