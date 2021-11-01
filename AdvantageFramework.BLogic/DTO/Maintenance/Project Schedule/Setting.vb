Namespace DTO.Maintenance.ProjectSchedule.Settings

    Public Class Tab

        Public SettingModuleID As Long = 0
        Public ID As Long = 0
        Public Description As String = ""
        Public Settings As IEnumerable(Of DTO.Maintenance.ProjectSchedule.Settings.Setting)

        Public Sub New()

        End Sub

        Public Function ToEntity(ByVal DataContext As AdvantageFramework.Database.DataContext) As AdvantageFramework.Database.Entities.SettingModuleTab

            'objects
            Dim SettingEntity As AdvantageFramework.Database.Entities.SettingModuleTab = Nothing

            If DataContext IsNot Nothing Then

                SettingEntity = AdvantageFramework.Database.Procedures.SettingModuleTab.LoadBySettingModuleID(DataContext, Me.SettingModuleID)

            End If

            If SettingEntity Is Nothing Then

                SettingEntity = New Database.Entities.SettingModuleTab

            End If

            With SettingEntity
                .SettingModuleID = Me.SettingModuleID
                .ID = Me.ID
                .Description = Me.Description
            End With


            Return SettingEntity

        End Function
        Public Shared Function FromEntity(ByVal Entity As AdvantageFramework.Database.Entities.SettingModuleTab) As Tab

            'objects
            Dim Tab As AdvantageFramework.DTO.Maintenance.ProjectSchedule.Settings.Tab = Nothing

            Tab = New AdvantageFramework.DTO.Maintenance.ProjectSchedule.Settings.Tab

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
        Public Property Value As Object
        Public Property DefaultValue As Object
        Public Property MinimumValue As System.Nullable(Of Long)
        Public Property MaximumValue() As System.Nullable(Of Long)
        Public Property SettingModuleID() As System.Nullable(Of Long)
        Public Property SettingModuleTabID() As System.Nullable(Of Long)
        Public Property SettingModuleGroupID() As System.Nullable(Of Long)
        Public Property OrderNumber() As System.Nullable(Of Long)
        Public Property SettingDatabaseTypeID() As System.Nullable(Of Long)
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
            Dim Setting As AdvantageFramework.DTO.Maintenance.ProjectSchedule.Settings.Setting = Nothing

            Setting = New AdvantageFramework.DTO.Maintenance.ProjectSchedule.Settings.Setting

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
End Namespace


