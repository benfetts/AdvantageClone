Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.LOCATIONS")>
    Public Class Location
        Inherits AdvantageFramework.BaseClasses.EntityBase

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
        End Enum

#End Region

#Region " Variables "

        Private _ID As String = ""
        Private _Name As String = ""
        Private _Address As String = ""
        Private _Address2 As String = ""
        Private _City As String = ""
        Private _State As String = ""
        Private _Zip As String = ""
        Private _Phone As String = ""
        Private _Fax As String = ""
        Private _Email As String = ""
        Private _LocationFooter As String = ""
        Private _LogoLocation As String = ""
        Private _PrintHeader As System.Nullable(Of Long) = 0
        Private _PrintNameHeader As System.Nullable(Of Long) = 0
        Private _PrintAddressHeader As System.Nullable(Of Long) = 0
        Private _PrintAddress2Header As System.Nullable(Of Long) = 0
        Private _PrintCityHeader As System.Nullable(Of Long) = 0
        Private _PrintStateHeader As System.Nullable(Of Long) = 0
        Private _PrintZipHeader As System.Nullable(Of Long) = 0
        Private _PrintPhoneHeader As System.Nullable(Of Long) = 0
        Private _PrintFaxHeader As System.Nullable(Of Long) = 0
        Private _PrintEmailHeader As System.Nullable(Of Long) = 0
        Private _PrintFooter As System.Nullable(Of Long) = 0
        Private _PrintNameFooter As System.Nullable(Of Long) = 0
        Private _PrintAddressFooter As System.Nullable(Of Long) = 0
        Private _PrintAddress2Footer As System.Nullable(Of Long) = 0
        Private _PrintCityFooter As System.Nullable(Of Long) = 0
        Private _PrintStateFooter As System.Nullable(Of Long) = 0
        Private _PrintZipFooter As System.Nullable(Of Long) = 0
        Private _PrintPhoneFooter As System.Nullable(Of Long) = 0
        Private _PrintFaxFooter As System.Nullable(Of Long) = 0
        Private _PrintEmailFooter As System.Nullable(Of Long) = 0
        Private _LogoPath As String = ""
        Private _LogoLandscapePath As String = ""
        Private _FooterLogoLocation As String = ""
        Private _FooterLogoPath As String = ""
        Private _FooterLogoLandscape As String = ""


#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ID", Storage:="_ID", DbType:="varchar", IsPrimaryKey:=True),
        System.ComponentModel.DisplayName("ID"),
        System.ComponentModel.DataAnnotations.MaxLength(6),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.Code)>
        Public Property ID() As String
			Get
				ID = _ID
			End Get
			Set(ByVal value As String)
				_ID = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="NAME", Storage:="_Name", DbType:="varchar"),
		System.ComponentModel.DisplayName("Name"),
		System.ComponentModel.DataAnnotations.MaxLength(50),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
		Public Property Name() As String
			Get
				Name = _Name
			End Get
			Set(ByVal value As String)
				_Name = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ADDRESS1", Storage:="_Address", DbType:="varchar"),
		System.ComponentModel.DisplayName("Address"),
		System.ComponentModel.DataAnnotations.MaxLength(50)>
		Public Property Address() As String
			Get
				Address = _Address
			End Get
			Set(ByVal value As String)
				_Address = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ADDRESS2", Storage:="_Address2", DbType:="varchar"),
		System.ComponentModel.DisplayName("Address2"),
		System.ComponentModel.DataAnnotations.MaxLength(50)>
		Public Property Address2() As String
			Get
				Address2 = _Address2
			End Get
			Set(ByVal value As String)
				_Address2 = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CITY", Storage:="_City", DbType:="varchar"),
		System.ComponentModel.DisplayName("City"),
		System.ComponentModel.DataAnnotations.MaxLength(35)>
		Public Property City() As String
			Get
				City = _City
			End Get
			Set(ByVal value As String)
				_City = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="STATE", Storage:="_State", DbType:="varchar"),
		System.ComponentModel.DisplayName("State"),
		System.ComponentModel.DataAnnotations.MaxLength(10)>
		Public Property State() As String
			Get
				State = _State
			End Get
			Set(ByVal value As String)
				_State = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ZIP", Storage:="_Zip", DbType:="varchar"),
		System.ComponentModel.DisplayName("Zip"),
		System.ComponentModel.DataAnnotations.MaxLength(10)>
		Public Property Zip() As String
			Get
				Zip = _Zip
			End Get
			Set(ByVal value As String)
				_Zip = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PHONE", Storage:="_Phone", DbType:="varchar"),
		System.ComponentModel.DisplayName("Phone"),
		System.ComponentModel.DataAnnotations.MaxLength(20)>
		Public Property Phone() As String
			Get
				Phone = _Phone
			End Get
			Set(ByVal value As String)
				_Phone = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FAX", Storage:="_Fax", DbType:="varchar"),
		System.ComponentModel.DisplayName("Fax"),
		System.ComponentModel.DataAnnotations.MaxLength(20)>
		Public Property Fax() As String
			Get
				Fax = _Fax
			End Get
			Set(ByVal value As String)
				_Fax = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EMAIL", Storage:="_Email", DbType:="varchar"),
		System.ComponentModel.DisplayName("Email"),
		System.ComponentModel.DataAnnotations.MaxLength(60)>
		Public Property Email() As String
			Get
				Email = _Email
			End Get
			Set(ByVal value As String)
				_Email = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LOC_FOOTER", Storage:="_LocationFooter", DbType:="varchar"),
		System.ComponentModel.DisplayName("LocationFooter"),
		System.ComponentModel.DataAnnotations.MaxLength(254),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property LocationFooter() As String
			Get
				LocationFooter = _LocationFooter
			End Get
			Set(ByVal value As String)
				_LocationFooter = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LOGO_LOCATION", Storage:="_LogoLocation", DbType:="varchar"),
		System.ComponentModel.DisplayName("LogoLocation"),
		System.ComponentModel.DataAnnotations.MaxLength(1),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property LogoLocation() As String
			Get
				LogoLocation = _LogoLocation
			End Get
			Set(ByVal value As String)
				_LogoLocation = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_HEADER", Storage:="_PrintHeader", DbType:="smallint"),
		System.ComponentModel.DisplayName("PrintHeader"),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property PrintHeader() As System.Nullable(Of Long)
			Get
				PrintHeader = _PrintHeader
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_PrintHeader = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_NAME", Storage:="_PrintNameHeader", DbType:="smallint"),
		System.ComponentModel.DisplayName("PrintNameHeader")>
		Public Property PrintNameHeader() As System.Nullable(Of Long)
			Get
				PrintNameHeader = _PrintNameHeader
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_PrintNameHeader = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_ADDR1", Storage:="_PrintAddressHeader", DbType:="smallint"),
		System.ComponentModel.DisplayName("PrintAddressHeader")>
		Public Property PrintAddressHeader() As System.Nullable(Of Long)
			Get
				PrintAddressHeader = _PrintAddressHeader
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_PrintAddressHeader = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_ADDR2", Storage:="_PrintAddress2Header", DbType:="smallint"),
		System.ComponentModel.DisplayName("PrintAddress2Header")>
		Public Property PrintAddress2Header() As System.Nullable(Of Long)
			Get
				PrintAddress2Header = _PrintAddress2Header
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_PrintAddress2Header = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_CITY", Storage:="_PrintCityHeader", DbType:="smallint"),
		System.ComponentModel.DisplayName("PrintCityHeader")>
		Public Property PrintCityHeader() As System.Nullable(Of Long)
			Get
				PrintCityHeader = _PrintCityHeader
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_PrintCityHeader = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_STATE", Storage:="_PrintStateHeader", DbType:="smallint"),
		System.ComponentModel.DisplayName("PrintStateHeader")>
		Public Property PrintStateHeader() As System.Nullable(Of Long)
			Get
				PrintStateHeader = _PrintStateHeader
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_PrintStateHeader = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_ZIP", Storage:="_PrintZipHeader", DbType:="smallint"),
		System.ComponentModel.DisplayName("PrintZipHeader")>
		Public Property PrintZipHeader() As System.Nullable(Of Long)
			Get
				PrintZipHeader = _PrintZipHeader
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_PrintZipHeader = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_PHONE", Storage:="_PrintPhoneHeader", DbType:="smallint"),
		System.ComponentModel.DisplayName("PrintPhoneHeader")>
		Public Property PrintPhoneHeader() As System.Nullable(Of Long)
			Get
				PrintPhoneHeader = _PrintPhoneHeader
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_PrintPhoneHeader = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_FAX", Storage:="_PrintFaxHeader", DbType:="smallint"),
		System.ComponentModel.DisplayName("PrintFaxHeader")>
		Public Property PrintFaxHeader() As System.Nullable(Of Long)
			Get
				PrintFaxHeader = _PrintFaxHeader
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_PrintFaxHeader = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_EMAIL", Storage:="_PrintEmailHeader", DbType:="smallint"),
		System.ComponentModel.DisplayName("PrintEmailHeader")>
		Public Property PrintEmailHeader() As System.Nullable(Of Long)
			Get
				PrintEmailHeader = _PrintEmailHeader
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_PrintEmailHeader = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_FOOTER", Storage:="_PrintFooter", DbType:="smallint"),
		System.ComponentModel.DisplayName("PrintFooter")>
		Public Property PrintFooter() As System.Nullable(Of Long)
			Get
				PrintFooter = _PrintFooter
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_PrintFooter = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_NAME_FTR", Storage:="_PrintNameFooter", DbType:="smallint"),
		System.ComponentModel.DisplayName("PrintNameFooter")>
		Public Property PrintNameFooter() As System.Nullable(Of Long)
			Get
				PrintNameFooter = _PrintNameFooter
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_PrintNameFooter = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_ADDR1_FTR", Storage:="_PrintAddressFooter", DbType:="smallint"),
		System.ComponentModel.DisplayName("PrintAddressFooter")>
		Public Property PrintAddressFooter() As System.Nullable(Of Long)
			Get
				PrintAddressFooter = _PrintAddressFooter
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_PrintAddressFooter = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_ADDR2_FTR", Storage:="_PrintAddress2Footer", DbType:="smallint"),
		System.ComponentModel.DisplayName("PrintAddress2Footer")>
		Public Property PrintAddress2Footer() As System.Nullable(Of Long)
			Get
				PrintAddress2Footer = _PrintAddress2Footer
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_PrintAddress2Footer = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_CITY_FTR", Storage:="_PrintCityFooter", DbType:="smallint"),
		System.ComponentModel.DisplayName("PrintCityFooter")>
		Public Property PrintCityFooter() As System.Nullable(Of Long)
			Get
				PrintCityFooter = _PrintCityFooter
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_PrintCityFooter = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_STATE_FTR", Storage:="_PrintStateFooter", DbType:="smallint"),
		System.ComponentModel.DisplayName("PrintStateFooter")>
		Public Property PrintStateFooter() As System.Nullable(Of Long)
			Get
				PrintStateFooter = _PrintStateFooter
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_PrintStateFooter = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_ZIP_FTR", Storage:="_PrintZipFooter", DbType:="smallint"),
		System.ComponentModel.DisplayName("PrintZipFooter")>
		Public Property PrintZipFooter() As System.Nullable(Of Long)
			Get
				PrintZipFooter = _PrintZipFooter
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_PrintZipFooter = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_PHONE_FTR", Storage:="_PrintPhoneFooter", DbType:="smallint"),
		System.ComponentModel.DisplayName("PrintPhoneFooter")>
		Public Property PrintPhoneFooter() As System.Nullable(Of Long)
			Get
				PrintPhoneFooter = _PrintPhoneFooter
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_PrintPhoneFooter = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_FAX_FTR", Storage:="_PrintFaxFooter", DbType:="smallint"),
		System.ComponentModel.DisplayName("PrintFaxFooter")>
		Public Property PrintFaxFooter() As System.Nullable(Of Long)
			Get
				PrintFaxFooter = _PrintFaxFooter
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_PrintFaxFooter = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_EMAIL_FTR", Storage:="_PrintEmailFooter", DbType:="smallint"),
		System.ComponentModel.DisplayName("PrintEmailFooter")>
		Public Property PrintEmailFooter() As System.Nullable(Of Long)
			Get
				PrintEmailFooter = _PrintEmailFooter
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_PrintEmailFooter = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LOGO_PATH", Storage:="_LogoPath", DbType:="varchar"),
		System.ComponentModel.DisplayName("LogoPath"),
		System.ComponentModel.DataAnnotations.MaxLength(254),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LogoPath() As String
			Get
				LogoPath = _LogoPath
			End Get
			Set(ByVal value As String)
				_LogoPath = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LOGO_PATH_LAND", Storage:="_LogoLandscapePath", DbType:="varchar"),
		System.ComponentModel.DisplayName("LogoLandscapePath"),
		System.ComponentModel.DataAnnotations.MaxLength(254),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LogoLandscapePath() As String
			Get
				LogoLandscapePath = _LogoLandscapePath
			End Get
			Set(ByVal value As String)
				_LogoLandscapePath = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LOGO_LOCATION_2", Storage:="_FooterLogoLocation", DbType:="varchar"),
		 System.ComponentModel.DisplayName("FooterLogoLocation"),
		 System.ComponentModel.DataAnnotations.MaxLength(1)>
		Public Property FooterLogoLocation() As String
			Get
				FooterLogoLocation = _FooterLogoLocation
			End Get
			Set(ByVal value As String)
				_FooterLogoLocation = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LOGO_PATH_2", Storage:="_FooterLogoPath", DbType:="varchar"),
		System.ComponentModel.DisplayName("FooterLogoPath"),
		System.ComponentModel.DataAnnotations.MaxLength(254)>
		Public Property FooterLogoPath() As String
			Get
				FooterLogoPath = _FooterLogoPath
			End Get
			Set(ByVal value As String)
				_FooterLogoPath = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LOGO_PATH_LAND_2", Storage:="_FooterLogoLandscape", DbType:="varchar"),
		System.ComponentModel.DisplayName("FooterLogoLandscape"),
		System.ComponentModel.DataAnnotations.MaxLength(254)>
		Public Property FooterLogoLandscape() As String
            Get
                FooterLogoLandscape = _FooterLogoLandscape
            End Get
            Set(ByVal value As String)
                _FooterLogoLandscape = value
            End Set
        End Property


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.Location.Properties.ID.ToString

                    If Value Is Nothing OrElse Value.Trim = "" Then

                        IsValid = False
                        ErrorText = "Please enter a location ID."

                    End If

                    If IsValid AndAlso Me.DatabaseAction = AdvantageFramework.Database.Action.Inserting Then

						PropertyValue = Value

						If (From Entity In DirectCast(Me.DataContext, AdvantageFramework.Database.DataContext).Locations
							Where Entity.ID.ToUpper = DirectCast(PropertyValue, String).ToUpper
							Select Entity).Any Then

							IsValid = False

							ErrorText = "Location already exists with this ID."

						End If

					End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace