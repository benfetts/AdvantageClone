Namespace BillingCommandCenter.Database.Classes

    <Serializable()>
    Public Class ProductionSelectionBySalesClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            SalesClassCode
            SalesClassDescription
            IsSelected
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsSelected() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SalesClassCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SalesClassDescription() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.SalesClassCode.ToString

        End Function

#End Region

    End Class

End Namespace
