'Namespace ViewModels.Maintenance.General

'    <Serializable()>
'    Public Class LogoMaintenance

'        Public Property Location As LocationViewModel

'        Public Property HeaderPortrait As LogoViewModel
'        Public Property HeaderLandscape As LogoViewModel
'        Public Property FooterPortrait As LogoViewModel
'        Public Property FooterLandscape As LogoViewModel

'        Sub New()

'            Me.Location = New LocationViewModel
'            Me.HeaderPortrait = New LogoViewModel
'            Me.HeaderLandscape = New LogoViewModel
'            Me.FooterPortrait = New LogoViewModel
'            Me.FooterLandscape = New LogoViewModel

'        End Sub

'    End Class

'    <Serializable()>
'    Public Class LocationViewModel

'#Region " Constants "



'#End Region

'#Region " Enum "

'        Public Enum Properties

'            ID
'            Name
'            'Address
'            'Address2
'            'City
'            'State
'            'Zip
'            'Phone
'            'Fax
'            'Email
'            'LocationFooter
'            'LogoLocation
'            'PrintHeader
'            'PrintNameHeader
'            'PrintAddressHeader
'            'PrintAddress2Header
'            'PrintCityHeader
'            'PrintStateHeader
'            'PrintZipHeader
'            'PrintPhoneHeader
'            'PrintFaxHeader
'            'PrintEmailHeader
'            'PrintFooter
'            'PrintNameFooter
'            'PrintAddressFooter
'            'PrintAddress2Footer
'            'PrintCityFooter
'            'PrintStateFooter
'            'PrintZipFooter
'            'PrintPhoneFooter
'            'PrintFaxFooter
'            'PrintEmailFooter
'            'LogoPath
'            'LogoLandscapePath
'            'FooterLogoLocation
'            'FooterLogoPath
'            'FooterLogoLandscape

'        End Enum

'#End Region

'#Region " Variables "



'#End Region

'#Region " Properties "

'        Public Property ID As String = String.Empty
'        Public Property Name As String = String.Empty
'        'Public Property Address2 As String = String.Empty
'        'Public Property City As String = String.Empty
'        'Public Property State As String = String.Empty
'        'Public Property Zip As String = String.Empty
'        'Public Property Phone As String = String.Empty
'        'Public Property Fax As String = String.Empty
'        'Public Property Email As String = String.Empty

'        'Public Property LocationFooter As String = String.Empty
'        'Public Property LogoLocation As String = String.Empty

'        'Public Property PrintHeader As System.Nullable(Of Boolean) = False
'        'Public Property PrintAddressHeader As System.Nullable(Of Boolean) = False
'        'Public Property PrintAddress2Header As System.Nullable(Of Boolean) = False
'        'Public Property PrintCityHeader As System.Nullable(Of Boolean) = False
'        'Public Property PrintStateHeader As System.Nullable(Of Boolean) = False
'        'Public Property PrintZipHeader As System.Nullable(Of Boolean) = False
'        'Public Property PrintPhoneHeader As System.Nullable(Of Boolean) = False
'        'Public Property PrintFaxHeader As System.Nullable(Of Boolean) = False
'        'Public Property PrintEmailHeader As System.Nullable(Of Boolean) = False

'        'Public Property PrintFooter As System.Nullable(Of Boolean) = False
'        'Public Property PrintNameFooter As System.Nullable(Of Boolean) = False
'        'Public Property PrintAddressFooter As System.Nullable(Of Boolean) = False
'        'Public Property PrintAddress2Footer As System.Nullable(Of Boolean) = False
'        'Public Property PrintCityFooter As System.Nullable(Of Boolean) = False
'        'Public Property PrintStateFooter As System.Nullable(Of Boolean) = False
'        'Public Property PrintZipFooter As System.Nullable(Of Boolean) = False
'        'Public Property PrintPhoneFooter As System.Nullable(Of Boolean) = False
'        'Public Property PrintFaxFooter As System.Nullable(Of Boolean) = False
'        'Public Property PrintEmailFooter As System.Nullable(Of Boolean) = False

'        'Public Property LogoPath As String = String.Empty
'        'Public Property LogoLandscapePath As String = String.Empty
'        'Public Property FooterLogoLocation As String = String.Empty
'        'Public Property FooterLogoPath As String = String.Empty
'        'Public Property FooterLogoLandscape As String = String.Empty

'#End Region

'#Region " Methods "

'        Sub New()

'        End Sub

'#End Region

'    End Class

'    <Serializable()>
'    Public Class LogoViewModel

'#Region " Constants "



'#End Region

'#Region " Enum "

'        Public Enum Properties

'            ID
'            LocationID
'            LogoTypeID
'            Image
'            Thumbnail
'            IsActive
'            CreateDate
'            UserCode

'        End Enum


'#End Region

'#Region " Variables "



'#End Region

'#Region " Properties "

'        Public Property ID As Integer
'        Public Property LocationID As String
'        Public Property LogoTypeID As Integer
'        Public Property Image As Byte()
'        Public Property Thumbnail As Byte()
'        Public Property IsActive As Nullable(Of Boolean)
'        Public Property CreateDate As Nullable(Of Date)
'        Public Property UserCode As String

'#End Region

'#Region " Methods "

'        Sub New()

'        End Sub

'#End Region

'    End Class

'End Namespace
