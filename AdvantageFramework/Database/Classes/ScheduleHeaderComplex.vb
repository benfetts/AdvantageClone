Namespace Database.Classes

    <Serializable()>
    Public Class ScheduleHeaderComplex

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ScheduleID
            OfficeCode
            OfficeName
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            CampaignID
            CampaignCode
            CampaignName
            SalesClassCode
            SalesClassDescription
            AccountExecutiveEmployeeCode
            AccountExecutiveEmployeeName
            ManagerEmployeeCode
            ManagerEmployeeName
            StatusCode
            StatusDescription
            StartDate
            JobFirstUseDate
            CompletedDate
            GutPercentComplete
            Comments
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ScheduleID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Office", IsReadOnlyColumn:=True)>
        Public Property OfficeCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property OfficeName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client", IsReadOnlyColumn:=True)>
        Public Property ClientCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property ClientName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Division", IsReadOnlyColumn:=True)>
        Public Property DivisionCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property DivisionName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product", IsReadOnlyColumn:=True)>
        Public Property ProductCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property ProductDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job", IsReadOnlyColumn:=True)>
        Public Property JobNumber() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property JobDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Component", IsReadOnlyColumn:=True)>
        Public Property JobComponentNumber() As Short

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property JobComponentDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CampaignID() As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Campaign", IsReadOnlyColumn:=True)>
        Public Property CampaignCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property CampaignName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Sales Class", IsReadOnlyColumn:=True)>
        Public Property SalesClassCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property SalesClassDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="A/E", IsReadOnlyColumn:=True)>
        Public Property AccountExecutiveEmployeeCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="A/E Name", IsReadOnlyColumn:=True)>
        Public Property AccountExecutiveEmployeeName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Manager", IsReadOnlyColumn:=True)>
        Public Property ManagerEmployeeCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Manager Name", IsReadOnlyColumn:=True)>
        Public Property ManagerEmployeeName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Status", PropertyType:=BaseClasses.PropertyTypes.Status)>
        Public Property StatusCode() As String

        Public Property StatusDescription() As String

        Public Property StartDate() As Nullable(Of Date)

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Due Date")>
        Public Property JobFirstUseDate() As Nullable(Of Date)

        Public Property CompletedDate() As Nullable(Of Date)

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Gut % Complete")>
        Public Property GutPercentComplete() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.Memo)>
        Public Property Comments() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ScheduleID.ToString

        End Function

#End Region

    End Class

End Namespace
