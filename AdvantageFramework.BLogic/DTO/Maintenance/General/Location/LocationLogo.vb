Namespace DTO.Maintenance.General.Location

    Public Class LocationLogo

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            LocationID
            ShowHeaderLogo
            ShowFooterLogo
            HeaderPortrait
            HeaderLandscape
            FooterPortrait
            FooterLandscape
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property LocationID As String = Nothing
        Public Property ShowHeaderLogo As String = Nothing
        Public Property ShowFooterLogo As String = Nothing
        Public Property HeaderPortrait As LocationLogoDetails = Nothing
        Public Property HeaderLandscape As LocationLogoDetails = Nothing
        Public Property FooterPortrait As LocationLogoDetails = Nothing
        Public Property FooterLandscape As LocationLogoDetails = Nothing

#End Region

#Region " Methods "

        Sub New()



        End Sub

#End Region

    End Class

End Namespace
