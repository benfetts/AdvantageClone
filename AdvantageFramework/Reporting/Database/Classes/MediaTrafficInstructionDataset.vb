Namespace Reporting.Database.Classes

    <Serializable>
    Public Class MediaTrafficInstructionDataset

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
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
            LastStatus
            HasDocuments
            Documents
            AdNumberDescription
            AdNumberExpirationDate
            AdNumberIsInactive
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property InstructionDescription As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property InstructionNumber As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property RevisionNumber As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Schedule As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ScheduleFlightRange As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property InstructionDates As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AgencyName As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Buyer As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientDivision As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Product As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Market As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property OrderNumber As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CableNetworkGroup As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CreativeGroupName As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DetailDayPart As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DetailStartTime As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DetailEndTime As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DetailAdNumber As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DetailCreativeTitle As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DetailLocation As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DetailBookendName As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property DetailPosition As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property DetailLength As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property DetailRotation As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DetailComment As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property LastStatus As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property HasDocuments As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Documents As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AdNumberDescription As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AdNumberExpirationDate As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AdNumberIsInactive As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
