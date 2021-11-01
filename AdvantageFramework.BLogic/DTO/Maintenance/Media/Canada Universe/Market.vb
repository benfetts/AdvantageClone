Namespace DTO.Maintenance.Media.CanadaUniverse

    Public Class Market
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Description
            IsInactive
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <MaxLength(10)>
        Public Property Code() As String
        <Required>
        <MaxLength(40)>
        Public Property Description() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsInactive() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.Code = String.Empty
            Me.Description = String.Empty
            Me.IsInactive = False

        End Sub
        Public Sub New(Market As AdvantageFramework.Database.Entities.Market)

            Me.Code = Market.Code
            Me.Description = Market.Description
            Me.IsInactive = If(Market.IsInactive.GetValueOrDefault(0) = 0, False, True)

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function

#End Region

    End Class

End Namespace
