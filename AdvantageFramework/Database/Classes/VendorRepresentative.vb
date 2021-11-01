Namespace Database.Classes

    <Serializable()>
    Public Class VendorRepresentative

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Name
            ContactType
            EmailAddress
            DefaultRep1
            DefaultRep2
            IsInactive
        End Enum

#End Region

#Region " Variables "

        Private _Code As String = Nothing
        Private _Name As String = Nothing
        Private _ContactType As String = Nothing
        Private _EmailAddress As String = Nothing
        Private _DefaultRep1 As Boolean = Nothing
        Private _DefaultRep2 As Boolean = Nothing
        Private _IsInactive As Boolean = Nothing
        Private _VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property Code() As String
            Get
                Code = _Code
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property ContactType() As String
            Get
                ContactType = _ContactType
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property Name() As String
            Get
                Name = _Name
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property EmailAddress() As String
            Get
                EmailAddress = _EmailAddress
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Default Rep 1", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property DefaultRep1() As Boolean
            Get
                DefaultRep1 = _DefaultRep1
            End Get
            Set(ByVal value As Boolean)
                _DefaultRep1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Default Rep 2", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property DefaultRep2() As Boolean
            Get
                DefaultRep2 = _DefaultRep2
            End Get
            Set(ByVal value As Boolean)
                _DefaultRep2 = value
            End Set
        End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        'Public ReadOnly Property VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative
        '    Get
        '        VendorRepresentative = _VendorRepresentative
        '    End Get
        'End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public ReadOnly Property IsInactive() As Boolean
            Get
                IsInactive = _IsInactive
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(DbContext As AdvantageFramework.Database.DbContext, ByVal VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative, ByVal IsDefaultRep1 As Boolean, ByVal IsDefaultRep2 As Boolean)

            'objects
            Dim ContactType As AdvantageFramework.Database.Entities.ContactType = Nothing

            _VendorRepresentative = VendorRepresentative
            _Code = VendorRepresentative.Code

            If VendorRepresentative.ContactTypeID.GetValueOrDefault(0) > 0 Then

                ContactType = AdvantageFramework.Database.Procedures.ContactType.LoadByContactTypeID(DbContext, VendorRepresentative.ContactTypeID.GetValueOrDefault(0))

                If ContactType IsNot Nothing Then

                    _ContactType = ContactType.Description

                End If

            End If

            _Name = VendorRepresentative.FirstName & If(String.IsNullOrWhiteSpace(VendorRepresentative.MiddleInitial), " ", " " & VendorRepresentative.MiddleInitial & ". ") & VendorRepresentative.LastName
            _EmailAddress = VendorRepresentative.EmailAddress
            _IsInactive = Convert.ToBoolean(VendorRepresentative.IsInactive.GetValueOrDefault(0))
            _DefaultRep1 = IsDefaultRep1
            _DefaultRep2 = IsDefaultRep2

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code

        End Function

#End Region

    End Class

End Namespace

