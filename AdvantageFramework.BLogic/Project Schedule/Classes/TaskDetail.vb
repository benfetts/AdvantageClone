Namespace ProjectSchedule.Classes

    <Serializable()>
    Public Class TaskDetail
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            TaskTemplateCode
            TaskTemplateDescription
            TaskCode
            TaskDescription
            ProcessOrderNumber
            DaysToComplete
            HoursAllowed
            PhaseID
            PhaseDescription
            IsMilestone
            ParentTaskCode
            DefaultEmployeeCode
            RushDaysToComplete
            RushHoursToComplete
            FunctionCode
            RoleCode
            StatusCode
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _TaskTemplateCode As String = Nothing
        Private _TaskTemplateDescription As String = Nothing
        Private _TaskCode As String = Nothing
        Private _TaskDescription As String = Nothing
        Private _ProcessOrderNumber As Nullable(Of Short) = Nothing
        Private _DaysToComplete As Nullable(Of Short) = Nothing
        Private _HoursAllowed As Nullable(Of Decimal) = Nothing
        Private _PhaseID As Nullable(Of Integer) = Nothing
        Private _PhaseDescription As String = Nothing
        Private _IsMilestone As Short = Nothing
        Private _ParentTaskCode As String = Nothing
        Private _DefaultEmployeeCode As String = Nothing
        Private _RushDaysToComplete As Nullable(Of Short) = Nothing
        Private _RushHoursToComplete As Nullable(Of Decimal) = Nothing
        Private _FunctionCode As String = Nothing
        Private _RoleCode As String = Nothing
        Private _StatusCode As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True)> _
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True)> _
        Public Property TaskTemplateCode() As String
            Get
                TaskTemplateCode = _TaskTemplateCode
            End Get
            Set(ByVal value As String)
                _TaskTemplateCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True)> _
        Public Property TaskTemplateDescription() As String
            Get
                TaskTemplateDescription = _TaskTemplateDescription
            End Get
            Set(ByVal value As String)
                _TaskTemplateDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True)> _
        Public Property PhaseID() As Nullable(Of Integer)
            Get
                PhaseID = _PhaseID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _PhaseID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Phase", IsReadOnlyColumn:=True)> _
        Public Property PhaseDescription() As String
            Get
                PhaseDescription = _PhaseDescription
            End Get
            Set(ByVal value As String)
                _PhaseDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, IsReadOnlyColumn:=True, CustomColumnCaption:="Task")> _
        Public Property TaskCode() As String
            Get
                TaskCode = _TaskCode
            End Get
            Set(ByVal value As String)
                _TaskCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, IsReadOnlyColumn:=True, CustomColumnCaption:="Description")> _
        Public Property TaskDescription() As String
            Get
                TaskDescription = _TaskDescription
            End Get
            Set(ByVal value As String)
                _TaskDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Order")> _
        Public Property ProcessOrderNumber() As Nullable(Of Short)
            Get
                ProcessOrderNumber = _ProcessOrderNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _ProcessOrderNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Days")> _
        Public Property DaysToComplete() As Nullable(Of Short)
            Get
                DaysToComplete = _DaysToComplete
            End Get
            Set(ByVal value As Nullable(Of Short))
                _DaysToComplete = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Hours")> _
        Public Property HoursAllowed() As Nullable(Of Decimal)
            Get
                HoursAllowed = _HoursAllowed
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _HoursAllowed = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)> _
        Public Property IsMilestone() As Short
            Get
                IsMilestone = _IsMilestone
            End Get
            Set(ByVal value As Short)
                _IsMilestone = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True)> _
        Public Property ParentTaskCode() As String
            Get
                ParentTaskCode = _ParentTaskCode
            End Get
            Set(ByVal value As String)
                _ParentTaskCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True)> _
        Public Property DefaultEmployeeCode() As String
            Get
                DefaultEmployeeCode = _DefaultEmployeeCode
            End Get
            Set(ByVal value As String)
                _DefaultEmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True, CustomColumnCaption:="Rush Days")> _
        Public Property RushDaysToComplete() As Nullable(Of Short)
            Get
                RushDaysToComplete = _RushDaysToComplete
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RushDaysToComplete = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True, CustomColumnCaption:="Rush Hours")> _
        Public Property RushHoursToComplete() As Nullable(Of Decimal)
            Get
                RushHoursToComplete = _RushHoursToComplete
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _RushHoursToComplete = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True)> _
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True)> _
        Public Property RoleCode() As String
            Get
                RoleCode = _RoleCode
            End Get
            Set(ByVal value As String)
                _RoleCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, IsReadOnlyColumn:=True)> _
        Public Property StatusCode() As String
            Get
                StatusCode = _StatusCode
            End Get
            Set(ByVal value As String)
                _StatusCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace


