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
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property OrderType() As String

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property OrderNumber() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Order Type")>
        Public Property OrderTypeDescription() As String

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

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public ReadOnly Property OrderOptions() As String
            Get
                Dim OptionString As String = String.Empty

                If Me.OrderType = "R" Then

                    If Me.Ethnicity = 0 Then

                        OptionString = "Regular"

                    ElseIf Me.Ethnicity = 1 Then

                        OptionString = "Hispanic"

                    ElseIf Me.Ethnicity = 2 Then

                        OptionString = "Black"

                    End If

                ElseIf Me.OrderType = "T" Then

                    If Me.Ethnicity = 0 Then

                        OptionString = "Regular"

                    ElseIf Me.Ethnicity = 1 Then

                        OptionString = "Hispanic"

                    ElseIf Me.Ethnicity = 2 Then

                        OptionString = "Black"

                    ElseIf Me.Ethnicity = 3 Then

                        OptionString = "Asian"

                    End If

                    If Me.IsOlympic Then

                        OptionString = OptionString & " Olympic Exclusion"

                    End If

                Else

                    OptionString = "N/A"

                End If

                OrderOptions = OptionString

            End Get
        End Property

        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property OrderDuration() As String

        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property Report() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AllMarkets() As Boolean

        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property ClientAlias() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsSuspended() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Cume() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AllStates() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Ethnicity() As Short

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsOlympic() As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(OrderType As String)

            Me.OrderType = OrderType

            If OrderType = "T" Then

                Me.OrderTypeDescription = "Spot TV"

            ElseIf OrderType = "R" Then

                Me.OrderTypeDescription = "Spot Radio"

            ElseIf OrderType = "N" Then

                Me.OrderTypeDescription = "National TV"

            ElseIf OrderType = "C" Then

                Me.OrderTypeDescription = "Radio County"

            End If

        End Sub
        Public Sub New(ClientOrder As Database.Entities.ClientOrder)

            Me.ID = ClientOrder.ID
            Me.ClientID = ClientOrder.ClientID
            Me.OrderType = ClientOrder.OrderType
            Me.OrderNumber = ClientOrder.OrderNumber
            Me.OrderDatetime = ClientOrder.OrderDateTime
            Me.LastChangedDatetime = ClientOrder.LastChangedDateTime
            Me.StartYear = ClientOrder.StartYear
            Me.EndYear = ClientOrder.EndYear
            Me.OrderDuration = ClientOrder.OrderDuration
            Me.Report = ClientOrder.Report
            Me.AllMarkets = ClientOrder.AllMarkets
            Me.ClientAlias = ClientOrder.ClientAlias
            Me.AllStates = ClientOrder.AllStates

            If ClientOrder.OrderType = "T" Then

                Me.OrderTypeDescription = "Spot TV"

            ElseIf ClientOrder.OrderType = "R" Then

                Me.OrderTypeDescription = "Spot Radio"

            ElseIf ClientOrder.OrderType = "N" Then

                Me.OrderTypeDescription = "National TV"

            ElseIf ClientOrder.OrderType = "C" Then

                Me.OrderTypeDescription = "Radio County"

            End If

            Me.IsSuspended = ClientOrder.IsSuspended
            Me.Cume = ClientOrder.Cume
            Me.Ethnicity = ClientOrder.Ethnicity
            Me.IsOlympic = ClientOrder.IsOlympic

        End Sub
        Public Sub SaveToEntity(ByRef ClientOrder As Database.Entities.ClientOrder)

            ClientOrder.ID = Me.ID
            ClientOrder.ClientID = Me.ClientID
            ClientOrder.OrderType = Me.OrderType
            ClientOrder.OrderNumber = Me.OrderNumber
            ClientOrder.OrderDateTime = Me.OrderDatetime
            ClientOrder.LastChangedDateTime = Me.LastChangedDatetime
            ClientOrder.StartYear = Me.StartYear
            ClientOrder.EndYear = Me.EndYear
            ClientOrder.OrderDuration = Me.OrderDuration
            ClientOrder.Report = Me.Report
            ClientOrder.AllMarkets = Me.AllMarkets
            ClientOrder.ClientAlias = Me.ClientAlias
            ClientOrder.IsSuspended = Me.IsSuspended
            ClientOrder.Cume = Me.Cume
            ClientOrder.AllStates = Me.AllStates
            ClientOrder.Ethnicity = Me.Ethnicity
            ClientOrder.IsOlympic = Me.IsOlympic

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
