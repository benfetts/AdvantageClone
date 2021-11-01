Namespace Database.Classes

    <Serializable()>
    Public Class EmployeeSetting
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Name
            Email
            TimeAlert
            WeeklyTimeType
            ReceivesEmail
            ReceivesAlerts
            AlertNotificationType
            Seniority
            AllowPOGLSelection
            LimitPOGLSelectionOffice
            OmitFromMissingTimeTracking
        End Enum

#End Region

#Region " Variables "

        Private _ReceivesEmail As Short = Nothing
        Private _ReceivesAlerts As Short = Nothing
        Private _Employee As AdvantageFramework.Database.Views.Employee = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Overrides ReadOnly Property AttachedEntityType As System.Type
            Get
                AttachedEntityType = GetType(AdvantageFramework.Database.Views.Employee)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property Code() As String
            Get
                Code = _Employee.Code
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property Name() As String
            Get
                Name = _Employee.ToString
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Email Address")>
        Public Property Email As String
            Get
                Email = _Employee.Email
            End Get
            Set(ByVal value As String)
                _Employee.Email = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ConceptShareUserID As Nullable(Of Integer)
            Get
                ConceptShareUserID = _Employee.ConceptShareUserID
            End Get
            Set(value As Nullable(Of Integer))
                _Employee.ConceptShareUserID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Missing Time Alert", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property TimeAlert As Nullable(Of Short)
            Get
                TimeAlert = _Employee.TimeAlert
            End Get
            Set(ByVal value As Nullable(Of Short))
                _Employee.TimeAlert = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Report Missing Time")>
        Public Property WeeklyTimeType As Nullable(Of Short)
            Get
                WeeklyTimeType = _Employee.WeeklyTimeType
            End Get
            Set(value As Nullable(Of Short))
                _Employee.WeeklyTimeType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property ReceivesEmail As Short
            Get
                ReceivesEmail = _ReceivesEmail
            End Get
            Set(value As Short)
                _ReceivesEmail = value
                SetAlertNotificationType()
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property ReceivesAlerts As Short
            Get
                ReceivesAlerts = _ReceivesAlerts
            End Get
            Set(value As Short)
                _ReceivesAlerts = value
                SetAlertNotificationType()
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AlertNotificationType As Nullable(Of Short)
            Get
                AlertNotificationType = _Employee.AlertNotificationType
            End Get
            Set(value As Nullable(Of Short))
                _Employee.AlertNotificationType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Seniority / Priority")>
        Public Property Seniority As Nullable(Of Short)
            Get
                Seniority = _Employee.Seniority
            End Get
            Set(value As Nullable(Of Short))
                _Employee.Seniority = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Allow PO GL Selection", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property AllowPOGLSelection As Nullable(Of Short)
            Get
                AllowPOGLSelection = _Employee.AllowPOGLSelection
            End Get
            Set(value As Nullable(Of Short))
                _Employee.AllowPOGLSelection = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Limit PO GL Selection to Office", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property LimitPOGLSelectionOffice As Nullable(Of Short)
            Get
                LimitPOGLSelectionOffice = _Employee.LimitPOGLSelectionOffice
            End Get
            Set(value As Nullable(Of Short))
                _Employee.LimitPOGLSelectionOffice = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Omit from Missing Time Tracking", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property OmitFromMissingTimeTracking As Nullable(Of Short)
            Get
                OmitFromMissingTimeTracking = _Employee.OmitFromMissingTimeTracking
            End Get
            Set(ByVal value As Nullable(Of Short))
                _Employee.OmitFromMissingTimeTracking = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            _Employee = Employee

            Select Case Employee.AlertNotificationType

                Case 1, 3

                    _ReceivesEmail = 1
                    _ReceivesAlerts = 1

                Case 2

                    _ReceivesEmail = 0
                    _ReceivesAlerts = 1

                Case Else

                    _ReceivesEmail = 0
                    _ReceivesAlerts = 0

            End Select

        End Sub
        Private Sub SetAlertNotificationType()

            If _ReceivesEmail = 0 AndAlso _ReceivesAlerts = 1 Then

                _Employee.AlertNotificationType = 2

            ElseIf _ReceivesEmail = 1 AndAlso _ReceivesAlerts = 1 Then

                _Employee.AlertNotificationType = 3

            Else

                _Employee.AlertNotificationType = Nothing

            End If

        End Sub
        Public Overrides Function ValidateCustomProperties(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            ' Objects
            Dim ErrorText As String = ""

            If PropertyName = AdvantageFramework.Database.Classes.EmployeeSetting.Properties.ReceivesAlerts.ToString OrElse _
                PropertyName = AdvantageFramework.Database.Classes.EmployeeSetting.Properties.ReceivesEmail.ToString Then

                ErrorText = _Employee.ValidateEntityProperty(Properties.AlertNotificationType.ToString, IsValid, Me.AlertNotificationType)

            Else

                ErrorText = _Employee.ValidateEntityProperty(PropertyName, IsValid, Value)

            End If


            ValidateCustomProperties = ErrorText

        End Function
        Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""

            If PropertyName = AdvantageFramework.Database.Classes.EmployeeSetting.Properties.ReceivesAlerts.ToString OrElse _
                PropertyName = AdvantageFramework.Database.Classes.EmployeeSetting.Properties.ReceivesEmail.ToString Then

                ErrorText = _Employee.ValidateEntityProperty(Properties.AlertNotificationType.ToString, IsValid, Me.AlertNotificationType)

                _ErrorHashtable(Properties.AlertNotificationType.ToString) = ErrorText

            Else

                ErrorText = _Employee.ValidateEntityProperty(PropertyName, IsValid, Value)

                _ErrorHashtable(PropertyName) = ErrorText

            End If

            ValidateEntityProperty = ErrorText

        End Function

#End Region

    End Class

End Namespace