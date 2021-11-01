Namespace DTO.Maintenance.General.Settings

    Public Class Tab

        Public SettingModuleID As Long
        Public ID As Long
        Public Description As String
        Public Property Footer As String
        Public Settings As IEnumerable(Of DTO.Maintenance.General.Settings.Setting)

        Public Sub New()

        End Sub

        Public Function ToEntity(ByVal DataContext As AdvantageFramework.Database.DataContext) As AdvantageFramework.Database.Entities.SettingModuleTab

            'objects
            Dim IntegrationSettingEntity As AdvantageFramework.Database.Entities.SettingModuleTab = Nothing

            If DataContext IsNot Nothing Then

                IntegrationSettingEntity = AdvantageFramework.Database.Procedures.SettingModuleTab.LoadBySettingModuleID(DataContext, Me.SettingModuleID)

            End If

            If IntegrationSettingEntity Is Nothing Then

                IntegrationSettingEntity = New Database.Entities.SettingModuleTab

            End If

            With IntegrationSettingEntity
                .SettingModuleID = Me.SettingModuleID
                .ID = Me.ID
                .Description = Me.Description
            End With


            Return IntegrationSettingEntity

        End Function
        Public Shared Function FromEntity(ByVal Entity As AdvantageFramework.Database.Entities.SettingModuleTab) As Tab

            'objects
            Dim Tab As AdvantageFramework.DTO.Maintenance.General.Settings.Tab = Nothing

            Tab = New AdvantageFramework.DTO.Maintenance.General.Settings.Tab

            With Tab

                .SettingModuleID = Entity.SettingModuleID
                .ID = Entity.ID
                .Description = Entity.Description

            End With

            Return Tab

        End Function

    End Class

    Public Class Setting

        Public Property Code As String
        Public Property Description As String = ""
        Public Property DisplayDescription As String = ""
        Public Property Value As Object
        Public Property DefaultValue As Object
        Public Property MinimumValue As System.Nullable(Of Long)
        Public Property MaximumValue() As System.Nullable(Of Long)
        Public Property SettingModuleID() As System.Nullable(Of Long)
        Public Property SettingModuleTabID() As System.Nullable(Of Long)
        Public Property SettingModuleGroupID() As System.Nullable(Of Long)
        Public Property OrderNumber() As System.Nullable(Of Long)
        Public Property SettingDatabaseTypeID() As System.Nullable(Of Long)
        Public Property SettingDatabaseType As SettingDatabaseType
        Public Property InputType As Short
        Public Property ShowPleaseSelect As Boolean
        Public Property FormatString As String = ""
        Public Property SettingValues As Generic.List(Of SettingValue)
        Public Property ChildCode As String
        Public Sub New()

        End Sub

        Public Function ToEntity(ByVal DataContext As AdvantageFramework.Database.DataContext) As AdvantageFramework.Database.Entities.Setting

            'objects
            Dim Entity As AdvantageFramework.Database.Entities.Setting = Nothing

            If DataContext IsNot Nothing Then

                Entity = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, Me.Code)

            End If

            If Entity Is Nothing Then

                Entity = New Database.Entities.Setting

            End If

            With Entity

                .SettingModuleID = Me.SettingModuleID
                .Code = Me.Code
                .Description = Me.Description
                .Value = Me.Value
                .DefaultValue = Me.DefaultValue
                .MinimumValue = Me.MinimumValue
                .MaximumValue = Me.MaximumValue
                .SettingModuleID = Me.SettingModuleID
                .SettingModuleTabID = Me.SettingModuleTabID
                .SettingModuleGroupID = Me.SettingModuleGroupID
                .OrderNumber = Me.OrderNumber
                .SettingDatabaseTypeID = Me.SettingDatabaseTypeID

            End With


            Return Entity

        End Function
        Public Shared Function FromEntity(ByVal Entity As AdvantageFramework.Database.Entities.Setting) As Setting

            'objects
            Dim Setting As AdvantageFramework.DTO.Maintenance.General.Settings.Setting = Nothing

            Setting = New AdvantageFramework.DTO.Maintenance.General.Settings.Setting

            With Setting

                .SettingModuleID = Entity.SettingModuleID
                .Code = Entity.Code
                .Description = Entity.Description
                .Value = Entity.Value
                .DefaultValue = Entity.DefaultValue
                .MinimumValue = Entity.MinimumValue
                .MaximumValue = Entity.MaximumValue
                .SettingModuleID = Entity.SettingModuleID
                .SettingModuleTabID = Entity.SettingModuleTabID
                .SettingModuleGroupID = Entity.SettingModuleGroupID
                .OrderNumber = Entity.OrderNumber
                .SettingDatabaseTypeID = Entity.SettingDatabaseTypeID

            End With

            Return Setting

        End Function

    End Class

    Public Class SettingDatabaseType

        Public Property ID As Long
        Public Property DatabaseTypeID As Long
        Public Property Precision As System.Nullable(Of Long)
        Public Property Scale As System.Nullable(Of Long)
        Public Property Column As String

        Public Function ToEntity(ByVal DataContext As AdvantageFramework.Database.DataContext) As AdvantageFramework.Database.Entities.SettingDatabaseType

            'objects
            Dim Entity As AdvantageFramework.Database.Entities.SettingDatabaseType = Nothing

            If DataContext IsNot Nothing Then

                Entity = AdvantageFramework.Database.Procedures.SettingDatabaseType.LoadBySettingDatabaseTypeID(DataContext, Me.DatabaseTypeID)

            End If

            If Entity Is Nothing Then

                Entity = New Database.Entities.SettingDatabaseType

            End If

            With Entity

                .ID = Me.ID
                .DatabaseTypeID = Me.DatabaseTypeID
                .Precision = Me.Precision
                .Scale = Me.Scale
                .Column = Me.Column

            End With


            Return Entity

        End Function
        Public Shared Function FromEntity(ByVal Entity As AdvantageFramework.Database.Entities.SettingDatabaseType) As SettingDatabaseType

            'objects
            Dim Setting As AdvantageFramework.DTO.Maintenance.General.Settings.SettingDatabaseType = Nothing

            Setting = New AdvantageFramework.DTO.Maintenance.General.Settings.SettingDatabaseType

            With Setting

                .ID = Entity.ID
                .DatabaseTypeID = Entity.DatabaseTypeID
                .Precision = Entity.Precision
                .Scale = Entity.Scale
                .Column = Entity.Column

            End With

            Return Setting

        End Function
    End Class

    Public Class SettingValue

        Public Property ID As Integer
        Public Property DisplayText As String
        Public Property Value As Object
        Public Property ParentID As Integer

        Public Shared Function FromEntity(ByVal Entity As AdvantageFramework.Database.Entities.SettingValue) As SettingValue

            'objects
            Dim SettingValue As AdvantageFramework.DTO.Maintenance.General.Settings.SettingValue = Nothing

            SettingValue = New AdvantageFramework.DTO.Maintenance.General.Settings.SettingValue

            With SettingValue

                .ID = Entity.ID
                .DisplayText = Entity.DisplayText
                .Value = Entity.Value

            End With

            Return SettingValue

        End Function

    End Class

    Public Class SettingEmployee

        Public Property Code As String
        Public Property Nickname As String
        Public Property BackgroundColor As String
        Public Property CustomTextColor As String
        Public Property TimeZone As String
        Public Property BackgroundPhoto As Byte()
        Public Property AgencySettings As Boolean
        Public Property ChangePassword As Boolean
        Public Property ShowDatabaseName As Boolean
        Public Property IsDarkMode As Boolean = False
        Public Sub New()

        End Sub

    End Class

End Namespace


