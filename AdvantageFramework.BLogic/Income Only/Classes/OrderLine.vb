Namespace IncomeOnly.Classes

    <Serializable()>
    Public Class OrderLine

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            OrderNumber
            LineNumber
            Description
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Order")>
        Public Property OrderNumber As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Line")>
        Public Property LineNumber As Nullable(Of Short)
        Public Property Description As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
