Namespace BillingCommandCenter.Database.Classes

    <Serializable()>
    Public Class ProductionSelectionByAccountExecutive

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeCode
            EmployeeName
            IsSelected
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsSelected() As Nullable(Of Short)

        Public Property EmployeeCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Account Executive")>
        Public Property EmployeeName() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EmployeeCode.ToString

        End Function

#End Region

    End Class

End Namespace
