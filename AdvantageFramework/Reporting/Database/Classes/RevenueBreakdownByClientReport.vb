Namespace Reporting.Database.Classes

    <Serializable>
    Public Class RevenueBreakdownByClientReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            ClientName
            MediaType
            Category
            ServiceType
            ServiceTypeDescription
            Amount
        End Enum

#End Region

#Region " Variables "

        Private _ID As System.Guid = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _MediaType As String = Nothing
        Private _Category As String = Nothing
        Private _ServiceType As String = Nothing
        Private _ServiceTypeDescription As String = Nothing
        Private _Amount As Decimal = Nothing

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
        Public Property Category() As String
            Get
                Category = _Category
            End Get
            Set(ByVal value As String)
                _Category = value
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
        Public Property ServiceType() As String
            Get
                ServiceType = _ServiceType
            End Get
            Set(ByVal value As String)
                _ServiceType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ServiceTypeDescription() As String
            Get
                ServiceTypeDescription = _ServiceTypeDescription
            End Get
            Set(ByVal value As String)
                _ServiceTypeDescription = value
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

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
