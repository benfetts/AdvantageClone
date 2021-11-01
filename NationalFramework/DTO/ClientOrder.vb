Namespace DTO

    Public Class ClientOrder
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientID
            OrderType
            OrderNumber
            OrderDatetime
            LastChangedDatetime
            StartYear
            EndYear
            OrderDuration
            Report
            AllMarkets
            ClientAlias
            IsSuspended
            Cume
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ClientID() As Integer

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property OrderNumber() As Integer

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property OrderDatetime() As Date

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property LastChangedDatetime() As Date

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property StartYear() As Short

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property EndYear() As Short

        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property OrderDuration() As String

        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property Report() As String

        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property ClientAlias() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsSuspended() As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ClientOrder As Database.Entities.ClientOrder)

            Me.ID = ClientOrder.ID
            Me.ClientID = ClientOrder.ClientID
            Me.OrderNumber = ClientOrder.OrderNumber
            Me.OrderDatetime = ClientOrder.OrderDateTime
            Me.LastChangedDatetime = ClientOrder.LastChangedDateTime
            Me.StartYear = ClientOrder.StartYear
            Me.EndYear = ClientOrder.EndYear
            Me.OrderDuration = ClientOrder.OrderDuration
            Me.Report = ClientOrder.Report
            Me.ClientAlias = ClientOrder.ClientAlias
            Me.IsSuspended = ClientOrder.IsSuspended

        End Sub
        Public Sub SaveToEntity(ByRef ClientOrder As Database.Entities.ClientOrder)

            ClientOrder.ID = Me.ID
            ClientOrder.ClientID = Me.ClientID
            ClientOrder.OrderNumber = Me.OrderNumber
            ClientOrder.OrderDateTime = Me.OrderDatetime
            ClientOrder.LastChangedDateTime = Me.LastChangedDatetime
            ClientOrder.StartYear = Me.StartYear
            ClientOrder.EndYear = Me.EndYear
            ClientOrder.OrderDuration = Me.OrderDuration
            ClientOrder.Report = Me.Report
            ClientOrder.ClientAlias = Me.ClientAlias
            ClientOrder.IsSuspended = Me.IsSuspended

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
