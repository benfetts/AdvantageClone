Namespace DTO.Media.SpotTVPuertoRico

    Public Class StationOrderNumber
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            NPRStationID
            OrderNumber
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property NPRStationID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OrderNumber() As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
