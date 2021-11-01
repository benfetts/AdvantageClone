Namespace CRMCentral.Classes

    Public Class CRMActivity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            OfficeCode
            OfficeName
            DefaultAccountExecutiveCode
            DefaultAccountExecutive
            NewBusiness
            IsInactive
            LastActivityDate
            LastActivityType
            LastActivitySubject
            LastContactDate
        End Enum

#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeName As String = Nothing
        Private _DefaultAccountExecutiveCode As String = Nothing
        Private _DefaultAccountExecutive As String = Nothing
        Private _NewBusiness As Boolean = Nothing
        Private _IsInactive As Boolean = Nothing
        Private _LastActivityDate As Nullable(Of Date) = Nothing
        Private _LastActivityType As String = Nothing
        Private _LastActivitySubject As String = Nothing
        Private _LastContactDate As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public ReadOnly Property ID() As String
            Get
                ID = Me.ClientCode & "|" & Me.DivisionCode & "|" & Me.ProductCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set(value As String)
                _ProductName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property OfficeName() As String
            Get
                OfficeName = _OfficeName
            End Get
            Set(value As String)
                _OfficeName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="AE Code")>
        Public Property DefaultAccountExecutiveCode() As String
            Get
                DefaultAccountExecutiveCode = _DefaultAccountExecutiveCode
            End Get
            Set(value As String)
                _DefaultAccountExecutiveCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Account Executive")>
        Public Property DefaultAccountExecutive() As String
            Get
                DefaultAccountExecutive = _DefaultAccountExecutive
            End Get
            Set(value As String)
                _DefaultAccountExecutive = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property NewBusiness() As Boolean
            Get
                NewBusiness = _NewBusiness
            End Get
            Set(value As Boolean)
                _NewBusiness = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive() As Boolean
            Get
                IsInactive = _IsInactive
            End Get
            Set(value As Boolean)
                _IsInactive = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property LastActivityDate() As Nullable(Of Date)
            Get
                LastActivityDate = _LastActivityDate
            End Get
            Set(value As Nullable(Of Date))
                _LastActivityDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property LastActivityType() As String
            Get
                LastActivityType = _LastActivityType
            End Get
            Set(value As String)
                _LastActivityType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property LastActivitySubject() As String
            Get
                LastActivitySubject = _LastActivitySubject
            End Get
            Set(value As String)
                _LastActivitySubject = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastContactDate() As Nullable(Of Date)
            Get
                LastContactDate = _LastContactDate
            End Get
            Set(value As Nullable(Of Date))
                _LastContactDate = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCode & " - " & Me.DivisionCode & " - " & Me.ProductCode

        End Function

#End Region

    End Class

End Namespace