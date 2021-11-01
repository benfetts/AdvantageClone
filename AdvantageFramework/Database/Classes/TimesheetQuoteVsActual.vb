Namespace Database.Classes

    <Serializable()>
    Public Class TimesheetQuoteVsActual

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobNumber
            JobComponentNumber
            EmployeeCode
            EmployeeDate
            FunctionCode
            FunctionDescription
            TotalEmployeeHours
            Amount
            Comments
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property JobNumber() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property JobComponentNumber() As Short

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Date")>
        Public Property EmployeeDate() As Nullable(Of Date)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Hours")>
        Public Property TotalEmployeeHours() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property Amount() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property Comments() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.JobNumber.ToString

        End Function

#End Region

    End Class

End Namespace
