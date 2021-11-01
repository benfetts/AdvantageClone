Namespace Database.Classes

    <Serializable()>
    Public Class EmployeeTimesheetTask

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            TaskDescription
            FunctionCode
            JobRevisedDate
            JobNumber
            JobDescription
            JobCompNumber
            JobCompDescription
            JobHours
            SequenceNumber
            FunctionInactive
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ClientCode() As String

        Public Property ClientName() As String

        Public Property DivisionCode() As String

        Public Property DivisionName() As String

        Public Property ProductCode() As String

        Public Property ProductDescription() As String

        Public Property JobNumber() As Integer

        Public Property JobDescription() As String

        Public Property JobCompNumber() As Short

        Public Property JobCompDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Task")>
        Public Property TaskDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Work Code")>
        Public Property FunctionCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property JobRevisedDate() As Nullable(Of Date)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property JobHours() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SequenceNumber() As Short

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FunctionInactive() As Nullable(Of Short)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCode.ToString

        End Function

#End Region

    End Class

End Namespace
