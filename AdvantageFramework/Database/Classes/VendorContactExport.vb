Namespace Database.Classes

    <Serializable()>
    Public Class VendorContactExport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Code
            VendorCode
            Vendor
            ContactType
            FirstName
            MiddleInitial
            LastName
            Email
            Phone
            PhoneExt
            Fax
            FaxExt
            Cell
            IsInactive
        End Enum

#End Region

#Region " Variables "

        Private _Code As String = Nothing
        Private _VendorCode As String = Nothing
        Private _Vendor As String = Nothing
        Private _ContactType As String = Nothing
        Private _FirstName As String = Nothing
        Private _MiddleInitial As String = Nothing
        Private _LastName As String = Nothing
        Private _Email As String = Nothing
        Private _Phone As String = Nothing
        Private _PhoneExt As String = Nothing
        Private _Fax As String = Nothing
        Private _FaxExt As String = Nothing
        Private _Cell As String = Nothing
        Private _IsInactive As Boolean = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As String
            Get
                ID = Me.VendorCode & "|" & Me.Code
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(ByVal value As String)
                _VendorCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Code() As String
            Get
                Code = _Code
            End Get
            Set(value As String)
                _Code = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor() As String
            Get
                Vendor = _Vendor
            End Get
            Set(value As String)
                _Vendor = value
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FirstName() As String
            Get
                FirstName = _FirstName
            End Get
            Set(value As String)
                _FirstName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastName() As String
            Get
                LastName = _LastName
            End Get
            Set(value As String)
                _LastName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MiddleInitial() As String
            Get
                MiddleInitial = _MiddleInitial
            End Get
            Set(value As String)
                _MiddleInitial = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Phone() As String
            Get
                Phone = _Phone
            End Get
            Set(value As String)
                _Phone = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PhoneExt() As String
            Get
                PhoneExt = _PhoneExt
            End Get
            Set(value As String)
                _PhoneExt = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Fax() As String
            Get
                Fax = _Fax
            End Get
            Set(value As String)
                _Fax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FaxExt() As String
            Get
                FaxExt = _FaxExt
            End Get
            Set(value As String)
                _FaxExt = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Cell() As String
            Get
                Cell = _Cell
            End Get
            Set(value As String)
                _Cell = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Email() As String
            Get
                Email = _Email
            End Get
            Set(value As String)
                _Email = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive() As Boolean
            Get
                IsInactive = _IsInactive
            End Get
            Set(value As Boolean)
                _IsInactive = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(DbContext As AdvantageFramework.Database.DbContext, ByVal VendorContact As AdvantageFramework.Database.Entities.VendorContact)

            'objects
            Dim ContactType As AdvantageFramework.Database.Entities.ContactType = Nothing

            _Code = VendorContact.Code
            _Vendor = If(VendorContact.Vendor IsNot Nothing, VendorContact.Vendor.ToString, Nothing)

            If VendorContact.ContactTypeID.GetValueOrDefault(0) > 0 Then

                ContactType = AdvantageFramework.Database.Procedures.ContactType.LoadByContactTypeID(DbContext, VendorContact.ContactTypeID.GetValueOrDefault(0))

                If ContactType IsNot Nothing Then

                    _ContactType = ContactType.Description

                End If

            End If

            _FirstName = VendorContact.FirstName
            _MiddleInitial = VendorContact.MiddleInitial
            _LastName = VendorContact.LastName
            _Email = VendorContact.Email
            _Phone = VendorContact.Phone
            _PhoneExt = VendorContact.PhoneExt
            _Fax = VendorContact.Fax
            _FaxExt = VendorContact.FaxExt
            _Cell = VendorContact.Cell
            _IsInactive = Convert.ToBoolean(VendorContact.IsInactive.GetValueOrDefault(0))

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code

        End Function

#End Region

    End Class

End Namespace

