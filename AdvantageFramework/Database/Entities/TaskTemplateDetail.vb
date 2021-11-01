Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.TRF_PRESET_DTL")>
    Public Class TaskTemplateDetail
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            TaskTemplateCode
            TaskCode
            ProcessOrderNumber
            DaysToComplete
            HoursAllowed
            PhaseID
            IsMilestone
            EmployeeCode
            RushDaysToComplete
            RushHoursToComplete
            FunctionCode
            RoleCode
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _TaskTemplateCode As String = ""
        Private _TaskCode As String = ""
        Private _ProcessOrderNumber As System.Nullable(Of Long) = 0
        Private _DaysToComplete As System.Nullable(Of Long) = 0
        Private _HoursAllowed As System.Nullable(Of Decimal) = 0
        Private _PhaseID As System.Nullable(Of Long) = 0
        Private _IsMilestone As Long = 0
        Private _EmployeeCode As String = ""
        Private _RushDaysToComplete As System.Nullable(Of Long) = 0
        Private _RushHoursToComplete As System.Nullable(Of Decimal) = 0
        Private _FunctionCode As String = ""
        Private _RoleCode As String = ""

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ROWID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DbType:="int NOT NULL IDENTITY"), _
        System.ComponentModel.DisplayName("ID"),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)> _
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TRF_PRESET_CODE", Storage:="_TaskTemplateCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("Task Template Code"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property TaskTemplateCode() As String
			Get
				TaskTemplateCode = _TaskTemplateCode
			End Get
			Set(ByVal value As String)
				_TaskTemplateCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TRAFFIC_PHASE_ID", Storage:="_PhaseID", DbType:="int"),
		System.ComponentModel.DisplayName("Phase ID"),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.Phase, CustomColumnCaption:="Phase")>
		Public Property PhaseID() As System.Nullable(Of Long)
			Get
				PhaseID = _PhaseID
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_PhaseID = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FNC_CODE", Storage:="_TaskCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("Task Code"),
		System.ComponentModel.DataAnnotations.MaxLength(10),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.TaskCode, CustomColumnCaption:="Task")>
		Public Property TaskCode() As String
			Get
				TaskCode = _TaskCode
			End Get
			Set(ByVal value As String)
				_TaskCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TRF_PRESET_ORDER", Storage:="_ProcessOrderNumber", DbType:="smallint"),
		System.ComponentModel.DisplayName("Process Order Number"),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F0")>
		Public Property ProcessOrderNumber() As System.Nullable(Of Long)
			Get
				ProcessOrderNumber = _ProcessOrderNumber
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_ProcessOrderNumber = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TRF_PRESET_DAYS", Storage:="_DaysToComplete", DbType:="smallint"),
		System.ComponentModel.DisplayName("Days To Complete"),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F0")>
		Public Property DaysToComplete() As System.Nullable(Of Long)
			Get
				DaysToComplete = _DaysToComplete
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_DaysToComplete = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TRF_PRESET_HRS", Storage:="_HoursAllowed", DbType:="decimal"),
		System.ComponentModel.DisplayName("Hours Allowed"),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F2")>
		Public Property HoursAllowed() As System.Nullable(Of Decimal)
			Get
				HoursAllowed = _HoursAllowed
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_HoursAllowed = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="RUSH_DAYS", Storage:="_RushDaysToComplete", DbType:="smallint"),
		System.ComponentModel.DisplayName("Rush Days To Complete"),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F0")>
		Public Property RushDaysToComplete() As System.Nullable(Of Long)
			Get
				RushDaysToComplete = _RushDaysToComplete
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_RushDaysToComplete = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="RUSH_HOURS", Storage:="_RushHoursToComplete", DbType:="decimal"),
		System.ComponentModel.DisplayName("Rush Hours To Complete"),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="F2")>
		Public Property RushHoursToComplete() As System.Nullable(Of Decimal)
			Get
				RushHoursToComplete = _RushHoursToComplete
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_RushHoursToComplete = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MILESTONE", Storage:="_IsMilestone", DbType:="smallint"),
		System.ComponentModel.DisplayName("Is Milestone"),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsMilestone() As Long
			Get
				IsMilestone = _IsMilestone
			End Get
			Set(ByVal value As Long)
				_IsMilestone = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DEFAULT_EMP", Storage:="_EmployeeCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("Employee Code"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.EmployeeCode, CustomColumnCaption:="Default Employee")>
		Public Property EmployeeCode() As String
			Get
				EmployeeCode = _EmployeeCode
			End Get
			Set(ByVal value As String)
				_EmployeeCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DEF_TRF_ROLE", Storage:="_RoleCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("Role Code"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.RoleCode, ShowColumnInGrid:=False)>
		Public Property RoleCode() As String
			Get
				RoleCode = _RoleCode
			End Get
			Set(ByVal value As String)
				_RoleCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EST_FNC_CODE", Storage:="_FunctionCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("Function Code"),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.EmployeeFunctionCode, CustomColumnCaption:="Default Function")>
		Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property

#End Region

#Region " Methods "


        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.TaskTemplateDetail.Properties.TaskTemplateCode.ToString

                    If Value Is Nothing OrElse Value.Trim = "" Then

                        IsValid = False
                        ErrorText = "Please enter a task template code."

                    End If

                Case AdvantageFramework.Database.Entities.TaskTemplateDetail.Properties.TaskCode.ToString

                    If Value Is Nothing OrElse Value.Trim = "" Then

                        IsValid = False
                        ErrorText = "Please enter a task code."

                    End If

                Case AdvantageFramework.Database.Entities.TaskTemplateDetail.Properties.RoleCode.ToString

                    If Value IsNot Nothing AndAlso Value.Trim = "" Then

                        Value = Nothing

                    End If

                Case AdvantageFramework.Database.Entities.TaskTemplateDetail.Properties.FunctionCode.ToString

                    If Value IsNot Nothing AndAlso Value.Trim = "" Then

                        Value = Nothing

                    End If

                Case AdvantageFramework.Database.Entities.TaskTemplateDetail.Properties.EmployeeCode.ToString

                    If Value IsNot Nothing AndAlso Value.Trim = "" Then

                        Value = Nothing

                    End If

                Case AdvantageFramework.Database.Entities.TaskTemplateDetail.Properties.PhaseID.ToString

                    If Value IsNot Nothing AndAlso Value = 0 Then

                        Value = Nothing

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function


#End Region

    End Class

End Namespace