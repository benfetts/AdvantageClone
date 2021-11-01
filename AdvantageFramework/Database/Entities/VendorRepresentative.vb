Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.VEN_REP")>
    Public Class VendorRepresentative
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            VendorCode
            Code
            FirstName
            LastName
            MiddleInitial
            FirmName
            Address1
            Address2
            City
            County
            State
            Country
            Zip
            Telephone
            TelephoneExtension
            Fax
            FaxExtension
            EmailAddress
            IsInactive
            Label
            CellPhone
            ContactTypeID
        End Enum

#End Region

#Region " Variables "

        Private _VendorCode As String = ""
        Private _Code As String = ""
        Private _FirstName As String = ""
        Private _LastName As String = ""
        Private _MiddleInitial As String = ""
        Private _FirmName As String = ""
        Private _Address1 As String = ""
        Private _Address2 As String = ""
        Private _City As String = ""
        Private _County As String = ""
        Private _State As String = ""
        Private _Country As String = ""
        Private _Zip As String = ""
        Private _Telephone As String = ""
        Private _TelephoneExtension As String = ""
        Private _Fax As String = ""
        Private _FaxExtension As String = ""
        Private _EmailAddress As String = ""
        Private _IsInactive As System.Nullable(Of Long) = 0
        Private _Label As String = ""
        Private _CellPhone As String = ""
        Private _ContactTypeID As System.Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As String
            Get
                ID = Me.VendorCode & "|" & Me.Code
            End Get
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VN_CODE", Storage:="_VendorCode", DbType:="varchar", IsPrimaryKey:=True),
		System.ComponentModel.DisplayName("VendorCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property VendorCode() As String
			Get
				VendorCode = _VendorCode
			End Get
			Set(ByVal value As String)
				_VendorCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_CODE", Storage:="_Code", DbType:="varchar", IsPrimaryKey:=True),
		System.ComponentModel.DisplayName("Code"),
		System.ComponentModel.DataAnnotations.MaxLength(4),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
			Get
				Code = _Code
			End Get
			Set(ByVal value As String)
				_Code = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_FNAME", Storage:="_FirstName", DbType:="varchar"),
		System.ComponentModel.DisplayName("FirstName"),
		System.ComponentModel.DataAnnotations.MaxLength(30)>
		Public Property FirstName() As String
			Get
				FirstName = _FirstName
			End Get
			Set(ByVal value As String)
				_FirstName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_LNAME", Storage:="_LastName", DbType:="varchar"),
		System.ComponentModel.DisplayName("LastName"),
		System.ComponentModel.DataAnnotations.MaxLength(30)>
		Public Property LastName() As String
			Get
				LastName = _LastName
			End Get
			Set(ByVal value As String)
				_LastName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_MI", Storage:="_MiddleInitial", DbType:="varchar"),
		System.ComponentModel.DisplayName("MiddleInitial"),
		System.ComponentModel.DataAnnotations.MaxLength(1)>
		Public Property MiddleInitial() As String
			Get
				MiddleInitial = _MiddleInitial
			End Get
			Set(ByVal value As String)
				_MiddleInitial = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_FIRM_NAME", Storage:="_FirmName", DbType:="varchar"),
		System.ComponentModel.DisplayName("FirmName"),
		System.ComponentModel.DataAnnotations.MaxLength(40)>
		Public Property FirmName() As String
			Get
				FirmName = _FirmName
			End Get
			Set(ByVal value As String)
				_FirmName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_ADDRESS1", Storage:="_Address1", DbType:="varchar"),
		System.ComponentModel.DisplayName("Address1"),
		System.ComponentModel.DataAnnotations.MaxLength(40)>
		Public Property Address1() As String
			Get
				Address1 = _Address1
			End Get
			Set(ByVal value As String)
				_Address1 = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_ADDRESS2", Storage:="_Address2", DbType:="varchar"),
		System.ComponentModel.DisplayName("Address2"),
		System.ComponentModel.DataAnnotations.MaxLength(40)>
		Public Property Address2() As String
			Get
				Address2 = _Address2
			End Get
			Set(ByVal value As String)
				_Address2 = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_CITY", Storage:="_City", DbType:="varchar"),
		System.ComponentModel.DisplayName("City"),
		System.ComponentModel.DataAnnotations.MaxLength(20)>
		Public Property City() As String
			Get
				City = _City
			End Get
			Set(ByVal value As String)
				_City = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_COUNTY", Storage:="_County", DbType:="varchar"),
		System.ComponentModel.DisplayName("County"),
		System.ComponentModel.DataAnnotations.MaxLength(20)>
		Public Property County() As String
			Get
				County = _County
			End Get
			Set(ByVal value As String)
				_County = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_STATE", Storage:="_State", DbType:="varchar"),
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
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_COUNTRY", Storage:="_Country", DbType:="varchar"),
		System.ComponentModel.DisplayName("Country"),
		System.ComponentModel.DataAnnotations.MaxLength(20)>
		Public Property Country() As String
			Get
				Country = _Country
			End Get
			Set(ByVal value As String)
				_Country = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_ZIP", Storage:="_Zip", DbType:="varchar"),
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
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_TELEPHONE", Storage:="_Telephone", DbType:="varchar"),
		System.ComponentModel.DisplayName("Telephone"),
		System.ComponentModel.DataAnnotations.MaxLength(13),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Telephone() As String
			Get
				Telephone = _Telephone
			End Get
			Set(ByVal value As String)
				_Telephone = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_EXTENTION", Storage:="_TelephoneExtension", DbType:="varchar"),
		System.ComponentModel.DisplayName("TelephoneExtension"),
		System.ComponentModel.DataAnnotations.MaxLength(4)>
		Public Property TelephoneExtension() As String
			Get
				TelephoneExtension = _TelephoneExtension
			End Get
			Set(ByVal value As String)
				_TelephoneExtension = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_FAX", Storage:="_Fax", DbType:="varchar"),
		System.ComponentModel.DisplayName("Fax"),
		System.ComponentModel.DataAnnotations.MaxLength(13),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Fax() As String
			Get
				Fax = _Fax
			End Get
			Set(ByVal value As String)
				_Fax = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_FAX_EXTENTION", Storage:="_FaxExtension", DbType:="varchar"),
		System.ComponentModel.DisplayName("FaxExtension"),
		System.ComponentModel.DataAnnotations.MaxLength(4)>
		Public Property FaxExtension() As String
			Get
				FaxExtension = _FaxExtension
			End Get
			Set(ByVal value As String)
				_FaxExtension = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EMAIL_ADDRESS", Storage:="_EmailAddress", DbType:="varchar"),
		System.ComponentModel.DisplayName("EmailAddress"),
		System.ComponentModel.DataAnnotations.MaxLength(50),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.Email)>
		Public Property EmailAddress() As String
			Get
				EmailAddress = _EmailAddress
			End Get
			Set(ByVal value As String)
				_EmailAddress = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_INACTIVE_FLAG", Storage:="_IsInactive", DbType:="smallint"),
		System.ComponentModel.DisplayName("IsInactive"),
		AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As System.Nullable(Of Long)
			Get
				IsInactive = _IsInactive
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_IsInactive = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_LABEL", Storage:="_Label", DbType:="varchar"),
		System.ComponentModel.DisplayName("Label"),
		System.ComponentModel.DataAnnotations.MaxLength(20)>
		Public Property Label() As String
			Get
				Label = _Label
			End Get
			Set(ByVal value As String)
				_Label = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VR_PHONE_CELL", Storage:="_CellPhone", DbType:="varchar"),
		System.ComponentModel.DisplayName("CellPhone"),
		System.ComponentModel.DataAnnotations.MaxLength(13),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CellPhone() As String
            Get
                CellPhone = _CellPhone
            End Get
            Set(ByVal value As String)
                _CellPhone = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CONTACT_TYPE_ID", Storage:="_ContactTypeID", DbType:="int"), _
        System.ComponentModel.DisplayName("ContactTypeID"),
        AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.PropertyTypes.ContactTypeID)> _
        Public Property ContactTypeID() As System.Nullable(Of Integer)
            Get
                ContactTypeID = _ContactTypeID
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _ContactTypeID = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            If Me.MiddleInitial IsNot Nothing AndAlso Me.MiddleInitial.Trim <> "" Then

                ToString = Me.FirstName & " " & Me.MiddleInitial & ". " & Me.LastName

            Else

                ToString = Me.FirstName & " " & Me.LastName

            End If

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.VendorRepresentative.Properties.Code.ToString

                    If Me.DatabaseAction = Action.Inserting Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DataContext, AdvantageFramework.Database.DataContext).VendorRepresentatives _
                                Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso _
                                      Entity.VendorCode.ToUpper = Me.VendorCode.ToUpper _
                                Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique code."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
