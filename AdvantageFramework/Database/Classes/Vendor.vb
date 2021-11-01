Namespace Database.Classes

    <Serializable()>
    Public Class Vendor

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Name
            VendorType
            Office
            DefaultAPAccount
            Market
            VendorCity
            VendorState
            IsInactive
            IsCableSystem
            CallLetters
        End Enum

#End Region

#Region " Variables "

        Private _Code As String = Nothing
        Private _Name As String = Nothing
        Private _VendorType As String = Nothing
        Private _Office As String = Nothing
        Private _DefaultAPAccount As String = Nothing
        Private _Market As String = Nothing
        Private _VendorCity As String = Nothing
        Private _VendorState As String = Nothing
        Private _IsInactive As Boolean = Nothing

#End Region

#Region " Properties "

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
        Public Property Name() As String
            Get
                Name = _Name
            End Get
            Set(value As String)
                _Name = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Category")>
        Public Property VendorType() As String
            Get
                VendorType = _VendorType
            End Get
            Set(value As String)
                _VendorType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Office() As String
            Get
                Office = _Office
            End Get
            Set(value As String)
                _Office = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultAPAccount() As String
            Get
                DefaultAPAccount = _DefaultAPAccount
            End Get
            Set(value As String)
                _DefaultAPAccount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Market() As String
            Get
                Market = _Market
            End Get
            Set(value As String)
                _Market = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCity() As String
            Get
                VendorCity = _VendorCity
            End Get
            Set(value As String)
                _VendorCity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorState() As String
            Get
                VendorState = _VendorState
            End Get
            Set(value As String)
                _VendorState = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsCableSystem() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CallLetters() As String
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

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace

