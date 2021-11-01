Namespace Reporting.Database.Classes

    <Serializable>
    Public Class MediaTrafficInstructionReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            InstructionDescription
            InstructionNumber
            RevisionNumber
            Schedule
            ScheduleFlightRange
            InstructionDates
            AgencyName
            Buyer
            ClientDivision
            Product
            Market
            OrderNumber
            CableNetworkGroup
            CreativeGroupName
            DetailDayPart
            DetailStartTime
            DetailEndTime
            DetailAdNumber
            DetailCreativeTitle
            DetailLocation
            DetailBookendName
            DetailPosition
            DetailLength
            DetailRotation
            DetailComment
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property InstructionDescription As String

        Public Property InstructionNumber As Integer

        Public Property RevisionNumber As Integer

        Public Property Schedule As String

        Public Property ScheduleFlightRange As String

        Public Property InstructionDates As String

        Public Property AgencyName As String

        Public Property Buyer As String

        Public Property ClientDivision As String

        Public Property Product As String

        Public Property Market As String

        Public Property OrderNumber As Nullable(Of Integer)

        Public Property CableNetworkGroup As String

        Public Property CreativeGroupName As String

        Public Property DetailDayPart As String

        Public Property DetailStartTime As String

        Public Property DetailEndTime As String

        Public Property DetailAdNumber As String

        Public Property DetailCreativeTitle As String

        Public Property DetailLocation As String

        Public Property DetailBookendName As String

        Public Property DetailPosition As Nullable(Of Short)

        Public Property DetailLength As Nullable(Of Short)

        Public Property DetailRotation As Nullable(Of Short)

        Public Property DetailComment As String

        Public Property LocationHeader As String

        Public Property LocationFooter As String

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
