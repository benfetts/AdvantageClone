Namespace Database.Classes

    <Serializable()>
    Public Class VendorRep

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            VendorCode
            VendorName
            MediaType
            MarketName
            Code
            ContactType
            FirstName
            MiddleInitial
            LastName
            Email
            Telephone
            TelephoneExtension
            Fax
            FaxExtension
            CellPhone
            IsInactive
        End Enum

#End Region

#Region " Variables "

        Private _VendorCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _Code As String = Nothing
        Private _ContactType As String = Nothing
        Private _FirstName As String = Nothing
        Private _MiddleInitial As String = Nothing
        Private _LastName As String = Nothing
        Private _Email As String = Nothing
        Private _Telephone As String = Nothing
        Private _TelephoneExtension As String = Nothing
        Private _Fax As String = Nothing
        Private _FaxExtension As String = Nothing
        Private _CellPhone As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As String
            Get
                ID = Me.VendorCode & "|" & Me.Code
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(ByVal value As String)
                _VendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(ByVal value As String)
                _VendorName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaType() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarketName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Code() As String
            Get
                Code = _Code
            End Get
            Set(ByVal value As String)
                _Code = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ContactType() As String
            Get
                ContactType = _ContactType
            End Get
            Set(value As String)
                _ContactType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FirstName() As String
            Get
                FirstName = _FirstName
            End Get
            Set(ByVal value As String)
                _FirstName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MiddleInitial() As String
            Get
                MiddleInitial = _MiddleInitial
            End Get
            Set(ByVal value As String)
                _MiddleInitial = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastName() As String
            Get
                LastName = _LastName
            End Get
            Set(ByVal value As String)
                _LastName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Email() As String
            Get
                Email = _Email
            End Get
            Set(ByVal value As String)
                _Email = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Phone", ShowColumnInGrid:=False)>
        Public Property Telephone() As String
            Get
                Telephone = _Telephone
            End Get
            Set(ByVal value As String)
                _Telephone = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Phone Ext", ShowColumnInGrid:=False)>
        Public Property TelephoneExtension() As String
            Get
                TelephoneExtension = _TelephoneExtension
            End Get
            Set(ByVal value As String)
                _TelephoneExtension = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Fax", ShowColumnInGrid:=False)>
        Public Property Fax() As String
            Get
                Fax = _Fax
            End Get
            Set(ByVal value As String)
                _Fax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Fax Ext", ShowColumnInGrid:=False)>
        Public Property FaxExtension() As String
            Get
                FaxExtension = _FaxExtension
            End Get
            Set(ByVal value As String)
                _FaxExtension = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Cell", ShowColumnInGrid:=False)>
        Public Property CellPhone() As String
            Get
                CellPhone = _CellPhone
            End Get
            Set(ByVal value As String)
                _CellPhone = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive() As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(DbContext As AdvantageFramework.Database.DbContext, ByVal VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative, ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            'objects
            Dim ContactType As AdvantageFramework.Database.Entities.ContactType = Nothing

            _VendorCode = Vendor.Code
            _VendorName = Vendor.Name
            _Code = VendorRepresentative.Code

            If VendorRepresentative.ContactTypeID.GetValueOrDefault(0) > 0 Then

                ContactType = AdvantageFramework.Database.Procedures.ContactType.LoadByContactTypeID(DbContext, VendorRepresentative.ContactTypeID.GetValueOrDefault(0))

                If ContactType IsNot Nothing Then

                    _ContactType = ContactType.Description

                End If

            End If

            _FirstName = VendorRepresentative.FirstName
            _MiddleInitial = VendorRepresentative.MiddleInitial
            _LastName = VendorRepresentative.LastName
            _Email = VendorRepresentative.EmailAddress
            _Telephone = VendorRepresentative.Telephone
            _TelephoneExtension = VendorRepresentative.TelephoneExtension
            _Fax = VendorRepresentative.Fax
            _FaxExtension = VendorRepresentative.FaxExtension
            _CellPhone = VendorRepresentative.CellPhone
            _IsInactive = Convert.ToBoolean(VendorRepresentative.IsInactive.GetValueOrDefault(0))
            Me.MediaType = Vendor.VendorCategory

            If Vendor.Market IsNot Nothing Then

                Me.MarketName = Vendor.Market.Description

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code

        End Function

#End Region

    End Class

End Namespace

