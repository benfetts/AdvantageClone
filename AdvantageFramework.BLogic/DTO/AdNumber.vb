Namespace DTO

    Public Class AdNumber
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Number
            Description
            ExpirationDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Number() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Description() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExpirationDate() As Nullable(Of Date)

#End Region

#Region " Methods "

        Public Sub New()


        End Sub
        Public Sub New(Ad As AdvantageFramework.Database.Entities.Ad)

            Me.Number = Ad.Number
            Me.Description = Ad.Description
            Me.ExpirationDate = Ad.ExpirationDate

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Number & " - " & Me.Description

        End Function

#End Region

    End Class

End Namespace
