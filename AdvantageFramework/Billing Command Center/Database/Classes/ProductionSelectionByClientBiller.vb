Namespace BillingCommandCenter.Database.Classes

    <Serializable()>
    Public Class ProductionSelectionByClientBiller

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            BillerEmployeeCode
            ClientBiller
            IsSelected
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsSelected() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BillerEmployeeCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientBiller() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientBiller.ToString

        End Function

#End Region

    End Class

End Namespace
