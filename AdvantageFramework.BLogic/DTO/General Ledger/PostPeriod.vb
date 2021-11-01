Namespace DTO.GeneralLedger

    Public Class PostPeriod
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Code
            Description
            Month
            Year
            StartDate
            EndDate
            UserCode
            EnteredDate
            ModifiedDate
            ARStatus
            GLStatus
            APStatus
            EmployeeTimeStatus
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
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
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="User")>
        Public Property UserCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Date Entered")>
        Public Property EnteredDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Date Modified")>
        Public Property ModifiedDate() As Nullable(Of Date)
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="A/R Status", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.PostPeriodStatus)>
        Public Property ARStatus() As String
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Status", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.PostPeriodStatus)>
        Public Property GLStatus() As String
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="A/P Status", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.PostPeriodStatus)>
        Public Property APStatus() As String
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Emp Time Status", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.PostPeriodStatus)>
        Public Property EmployeeTimeStatus() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.Code = String.Empty
            Me.Description = String.Empty
            Me.Month = 0
            Me.Year = 0
            Me.StartDate = Nothing
            Me.EndDate = Nothing
            Me.UserCode = Nothing
            Me.EnteredDate = Nothing
            Me.ModifiedDate = Nothing
            Me.ARStatus = Nothing
            Me.GLStatus = Nothing
            Me.APStatus = Nothing
            Me.EmployeeTimeStatus = Nothing

        End Sub
        Public Sub New(PostPeriod As AdvantageFramework.Database.Entities.PostPeriod)

            Me.ID = PostPeriod.ID
            Me.Code = PostPeriod.Code
            Me.Description = PostPeriod.Description
            Me.Month = PostPeriod.Month
            Me.Year = PostPeriod.Year
            Me.StartDate = PostPeriod.StartDate
            Me.EndDate = PostPeriod.EndDate
            Me.UserCode = PostPeriod.UserCode
            Me.EnteredDate = PostPeriod.EnteredDate
            Me.ModifiedDate = PostPeriod.ModifiedDate
            Me.ARStatus = PostPeriod.ARStatus
            Me.GLStatus = PostPeriod.GLStatus
            Me.APStatus = PostPeriod.APStatus
            Me.EmployeeTimeStatus = PostPeriod.EmployeeTimeStatus

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function

#End Region

    End Class

End Namespace
