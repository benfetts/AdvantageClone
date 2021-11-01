Namespace DTO

    Public Class ClientOrderState
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientOrderID
            State
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ClientOrderID() As Integer

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=AdvantageFramework.BaseClasses.Methods.PropertyTypes.NielsenCountyState)>
        Public Property State() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ClientOrderState As Database.Entities.ClientOrderState)

            Me.ID = ClientOrderState.ID
            Me.ClientOrderID = ClientOrderState.ClientOrderID
            Me.State = ClientOrderState.State

        End Sub
        Public Sub SaveToEntity(ByRef ClientOrderState As Database.Entities.ClientOrderState)

            ClientOrderState.ID = Me.ID
            ClientOrderState.ClientOrderID = Me.ClientOrderID
            ClientOrderState.State = Me.State

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
