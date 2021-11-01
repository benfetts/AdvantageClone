Namespace DTO.GeneralLedger.JournalEntry

    Public Class PostPeriod
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Description
            Month
            Year
            StartDate
            EndDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Posting Period", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
        Public Property Code() As String
        <Required>
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Description() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Fiscal Month")>
        Public Property Month() As Nullable(Of Short)
        <MaxLength(5)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Fiscal Year")>
        Public Property Year() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Starting Date")>
        Public Property StartDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Ending Date")>
        Public Property EndDate() As Nullable(Of Date)

#End Region

#Region " Methods "

        Public Sub New()

            Me.Code = String.Empty
            Me.Description = String.Empty
            Me.Month = 0
            Me.Year = 0
            Me.StartDate = Nothing
            Me.EndDate = Nothing

        End Sub
        Public Sub New(PostPeriod As AdvantageFramework.Database.Entities.PostPeriod)

            Me.Code = PostPeriod.Code
            Me.Description = PostPeriod.Description
            Me.Month = PostPeriod.Month
            Me.Year = PostPeriod.Year
            Me.StartDate = PostPeriod.StartDate
            Me.EndDate = PostPeriod.EndDate

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function

#End Region

    End Class

End Namespace
