Namespace DTO.Maintenance.General.Location

    Public Class LocationDetails

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Name
            Address
            Address2
            City
            State
            Zip
            Phone
            Fax
            Email
            LocationFooter
            LogoLocation
            PrintHeader
            PrintNameHeader
            PrintAddressHeader
            PrintAddress2Header
            PrintCityHeader
            PrintStateHeader
            PrintZipHeader
            PrintPhoneHeader
            PrintFaxHeader
            PrintEmailHeader
            PrintFooter
            PrintNameFooter
            PrintAddressFooter
            PrintAddress2Footer
            PrintCityFooter
            PrintStateFooter
            PrintZipFooter
            PrintPhoneFooter
            PrintFaxFooter
            PrintEmailFooter
            LogoPath
            LogoLandscapePath
            FooterLogoLocation
            FooterLogoPath
            FooterLogoLandscape
            HeaderLogoLandscapeId
            HeaderLogoPortraitId
            FooterLogoLandscapeId
            FooterLogoPortraitId
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ID As String = String.Empty
        Public Property Name As String = String.Empty
        Public Property Address1 As String = String.Empty
        Public Property Address2 As String = String.Empty
        Public Property City As String = String.Empty
        Public Property State As String = String.Empty
        Public Property Zip As String = String.Empty
        Public Property Phone As String = String.Empty
        Public Property Fax As String = String.Empty
        Public Property Email As String = String.Empty
        Public Property LocationFooter As String = String.Empty
        Public Property LogoLocation As String = String.Empty
        Public Property PrintHeader As System.Nullable(Of Boolean) = False
        Public Property PrintAddressHeader As System.Nullable(Of Boolean) = False
        Public Property PrintAddress2Header As System.Nullable(Of Boolean) = False
        Public Property PrintCityHeader As System.Nullable(Of Boolean) = False
        Public Property PrintStateHeader As System.Nullable(Of Boolean) = False
        Public Property PrintZipHeader As System.Nullable(Of Boolean) = False
        Public Property PrintNameHeader As System.Nullable(Of Boolean) = False
        Public Property PrintPhoneHeader As System.Nullable(Of Boolean) = False
        Public Property PrintFaxHeader As System.Nullable(Of Boolean) = False
        Public Property PrintEmailHeader As System.Nullable(Of Boolean) = False
        Public Property PrintFooter As System.Nullable(Of Boolean) = False
        Public Property PrintNameFooter As System.Nullable(Of Boolean) = False
        Public Property PrintAddressFooter As System.Nullable(Of Boolean) = False
        Public Property PrintAddress2Footer As System.Nullable(Of Boolean) = False
        Public Property PrintCityFooter As System.Nullable(Of Boolean) = False
        Public Property PrintStateFooter As System.Nullable(Of Boolean) = False
        Public Property PrintZipFooter As System.Nullable(Of Boolean) = False
        Public Property PrintPhoneFooter As System.Nullable(Of Boolean) = False
        Public Property PrintFaxFooter As System.Nullable(Of Boolean) = False
        Public Property PrintEmailFooter As System.Nullable(Of Boolean) = False
        Public Property LogoPath As String = String.Empty
        Public Property LogoLandscapePath As String = String.Empty
        Public Property FooterLogoLocation As String = String.Empty
        Public Property FooterLogoPath As String = String.Empty
        Public Property FooterLogoLandscape As String = String.Empty
        Public Property HeaderLogoLandscapeId As Integer = 0
        Public Property HeaderLogoPortraitId As Integer = 0
        Public Property FooterLogoLandscapeId As Integer = 0
        Public Property FooterLogoPortraitId As Integer = 0

#End Region

#Region " Methods "

        Sub New()



        End Sub

#End Region

    End Class

End Namespace
