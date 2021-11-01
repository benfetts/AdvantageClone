Namespace Help.Classes

    <Serializable()>
    Public Class ContactSupportMessage

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ContactTechincalSupport
            ContactSoftwareSupport
            Name
            PhoneNumber
            EmployeeName
            EmailAddress
            Address
            Address2
            City
            State
            Zip
            IssueType
            Priorty
            Description
            SupportInformation
        End Enum

#End Region

#Region " Variables "

        Private _ContactTechincalSupport As Boolean = False
        Private _ContactSoftwareSupport As Boolean = False
        Private _Name As String = ""
        Private _PhoneNumber As String = ""
        Private _EmployeeName As String = ""
        Private _EmailAddress As String = ""
        Private _Address As String = ""
        Private _Address2 As String = ""
        Private _City As String = ""
        Private _State As String = ""
        Private _Zip As String = ""
        Private _IssueType As AdvantageFramework.Help.IssueTypes = AdvantageFramework.Help.IssueTypes.Bug
        Private _Priorty As AdvantageFramework.AlertSystem.PriorityLevels = AdvantageFramework.AlertSystem.PriorityLevels.Normal
        Private _Description As String = ""
        Private _SupportInformation As String = ""

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ContactTechincalSupport() As Boolean
            Get
                ContactTechincalSupport = _ContactTechincalSupport
            End Get
            Set(ByVal value As Boolean)
                _ContactTechincalSupport = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ContactSoftwareSupport() As Boolean
            Get
                ContactSoftwareSupport = _ContactSoftwareSupport
            End Get
            Set(ByVal value As Boolean)
                _ContactSoftwareSupport = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Name() As String
            Get
                Name = _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PhoneNumber() As String
            Get
                PhoneNumber = _PhoneNumber
            End Get
            Set(ByVal value As String)
                _PhoneNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EmployeeName() As String
            Get
                EmployeeName = _EmployeeName
            End Get
            Set(ByVal value As String)
                _EmployeeName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EmailAddress() As String
            Get
                EmailAddress = _EmailAddress
            End Get
            Set(ByVal value As String)
                _EmailAddress = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Address() As String
            Get
                Address = _Address
            End Get
            Set(ByVal value As String)
                _Address = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Address2() As String
            Get
                Address2 = _Address2
            End Get
            Set(ByVal value As String)
                _Address2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property City() As String
            Get
                City = _City
            End Get
            Set(ByVal value As String)
                _City = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property State() As String
            Get
                State = _State
            End Get
            Set(ByVal value As String)
                _State = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Zip() As String
            Get
                Zip = _Zip
            End Get
            Set(ByVal value As String)
                _Zip = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IssueType As AdvantageFramework.Help.IssueTypes
            Get
                IssueType = _IssueType
            End Get
            Set(ByVal value As AdvantageFramework.Help.IssueTypes)
                _IssueType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Priorty As AdvantageFramework.AlertSystem.PriorityLevels
            Get
                Priorty = _Priorty
            End Get
            Set(ByVal value As AdvantageFramework.AlertSystem.PriorityLevels)
                _Priorty = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SupportInformation() As String
            Get
                SupportInformation = _SupportInformation
            End Get
            Set(ByVal value As String)
                _SupportInformation = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace

