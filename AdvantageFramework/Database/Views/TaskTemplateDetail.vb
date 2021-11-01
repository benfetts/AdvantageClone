Namespace Database.Views

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.TASK_TEMPLATE_DETAIL")>
    Public Class TaskTemplateDetail
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            TaskTemplateDetailID
            TaskTemplateCode
            TaskCode
            TaskDescription
            ProcessOrderNumber
            DaysToComplete
            HoursAllowed
            PhaseID
            PhaseDescription
            IsMilestone
            DefaultEmployeeCode
            DefaultEmployeeName
            RushDaysToComplete
            RushHoursToComplete
            DefaultFunctionCode
            DefaultFunctionDescription
        End Enum

#End Region

#Region " Variables "

        Private _TaskTemplateDetailID As Long = 0
        Private _TaskTemplateCode As String = ""
        Private _TaskCode As String = ""
        Private _TaskDescription As String = ""
        Private _ProcessOrderNumber As Long = 0
        Private _DaysToComplete As Long = 0
        Private _HoursAllowed As Decimal = 0
        Private _PhaseID As Long = 0
        Private _PhaseDescription As String = ""
        Private _IsMilestone As Long = 0
        Private _DefaultEmployeeCode As String = ""
        Private _DefaultEmployeeName As String = ""
        Private _RushDaysToComplete As Long = 0
        Private _RushHoursToComplete As Decimal = 0
        Private _DefaultFunctionCode As String = ""
        Private _DefaultFunctionDescription As String = ""

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ROWID", Storage:="_TaskTemplateDetailID", DbType:="int"), _
        System.ComponentModel.DisplayName("Task Template Detail ID")> _
        Public Property TaskTemplateDetailID() As Long
            Get
                TaskTemplateDetailID = _TaskTemplateDetailID
            End Get
            Set(ByVal value As Long)
                _TaskTemplateDetailID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TRF_PRESET_CODE", Storage:="_TaskTemplateCode", DBType:="varchar"), _
        System.ComponentModel.DisplayName("Task Template Code")> _
        Public Property TaskTemplateCode() As String
            Get
                TaskTemplateCode = _TaskTemplateCode
            End Get
            Set(ByVal value As String)
                _TaskTemplateCode = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FNC_CODE", Storage:="_TaskCode", DBType:="varchar"), _
        System.ComponentModel.DisplayName("Task Code")> _
        Public Property TaskCode() As String
            Get
                TaskCode = _TaskCode
            End Get
            Set(ByVal value As String)
                _TaskCode = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TRF_DESC", Storage:="_TaskDescription", DBType:="varchar"), _
        System.ComponentModel.DisplayName("Task Description")> _
        Public Property TaskDescription() As String
            Get
                TaskDescription = _TaskDescription
            End Get
            Set(ByVal value As String)
                _TaskDescription = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TRF_PRESET_ORDER", Storage:="_ProcessOrderNumber", DBType:="smallint"), _
        System.ComponentModel.DisplayName("Process Order Number")> _
        Public Property ProcessOrderNumber() As Long
            Get
                ProcessOrderNumber = _ProcessOrderNumber
            End Get
            Set(ByVal value As Long)
                _ProcessOrderNumber = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TRF_PRESET_DAYS", Storage:="_DaysToComplete", DBType:="smallint"), _
        System.ComponentModel.DisplayName("Days To Complete")> _
        Public Property DaysToComplete() As Long
            Get
                DaysToComplete = _DaysToComplete
            End Get
            Set(ByVal value As Long)
                _DaysToComplete = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TRF_PRESET_HRS", Storage:="_HoursAllowed", DBType:="decimal"), _
        System.ComponentModel.DisplayName("Hours Allowed")> _
        Public Property HoursAllowed() As Decimal
            Get
                HoursAllowed = _HoursAllowed
            End Get
            Set(ByVal value As Decimal)
                _HoursAllowed = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TRAFFIC_PHASE_ID", Storage:="_PhaseID", DbType:="int"), _
        System.ComponentModel.DisplayName("Phase ID")> _
        Public Property PhaseID() As Long
            Get
                PhaseID = _PhaseID
            End Get
            Set(ByVal value As Long)
                _PhaseID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PHASE_DESC", Storage:="_PhaseDescription", DBType:="varchar"), _
        System.ComponentModel.DisplayName("Phase Description")> _
        Public Property PhaseDescription() As String
            Get
                PhaseDescription = _PhaseDescription
            End Get
            Set(ByVal value As String)
                _PhaseDescription = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MILESTONE", Storage:="_IsMilestone", DBType:="smallint"), _
        System.ComponentModel.DisplayName("Is Milestone")> _
        Public Property IsMilestone() As Long
            Get
                IsMilestone = _IsMilestone
            End Get
            Set(ByVal value As Long)
                _IsMilestone = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DEFAULT_EMP", Storage:="_DefaultEmployeeCode", DBType:="varchar"), _
        System.ComponentModel.DisplayName("Default Employee Code")> _
        Public Property DefaultEmployeeCode() As String
            Get
                DefaultEmployeeCode = _DefaultEmployeeCode
            End Get
            Set(ByVal value As String)
                _DefaultEmployeeCode = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DEFAULT_EMP_NAME", Storage:="_DefaultEmployeeName", DBType:="varchar"), _
        System.ComponentModel.DisplayName("Default Employee Name")> _
        Public Property DefaultEmployeeName() As String
            Get
                DefaultEmployeeName = _DefaultEmployeeName
            End Get
            Set(ByVal value As String)
                _DefaultEmployeeName = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="RUSH_DAYS", Storage:="_RushDaysToComplete", DBType:="smallint"), _
        System.ComponentModel.DisplayName("Rush Days To Complete")> _
        Public Property RushDaysToComplete() As Long
            Get
                RushDaysToComplete = _RushDaysToComplete
            End Get
            Set(ByVal value As Long)
                _RushDaysToComplete = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="RUSH_HOURS", Storage:="_RushHoursToComplete", DBType:="decimal"), _
        System.ComponentModel.DisplayName("Rush Hours To Complete")> _
        Public Property RushHoursToComplete() As Decimal
            Get
                RushHoursToComplete = _RushHoursToComplete
            End Get
            Set(ByVal value As Decimal)
                _RushHoursToComplete = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EST_FNC_CODE", Storage:="_DefaultFunctionCode", DBType:="varchar"), _
        System.ComponentModel.DisplayName("Default Function Code")> _
        Public Property DefaultFunctionCode() As String
            Get
                DefaultFunctionCode = _DefaultFunctionCode
            End Get
            Set(ByVal value As String)
                _DefaultFunctionCode = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FNC_DESCRIPTION", Storage:="_DefaultFunctionDescription", DBType:="varchar"), _
        System.ComponentModel.DisplayName("Default Function Description")> _
        Public Property DefaultFunctionDescription() As String
            Get
                DefaultFunctionDescription = _DefaultFunctionDescription
            End Get
            Set(ByVal value As String)
                _DefaultFunctionDescription = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
