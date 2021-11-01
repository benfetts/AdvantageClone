Imports System.Data.SqlClient
Imports AdvantageFramework.ProjectSchedule.Classes.Schedule

Namespace ViewModels.ProjectSchedule


    Public Class Schedule

        Private _Session As AdvantageFramework.Security.Session = Nothing

        Public Property JobNumber As Integer
        Public Property JobComponentNumber As Short

        Public Property Columns As ScheduleColumn()

        Public Property IsClientPortal As Boolean = False
        Public Property CanUserEdit As Boolean
        Public Property CanUserView As Boolean
        Public Property CanUserInsert As Boolean
        Public Property CanUserCustom1 As Boolean
        Public Property Assignment1Label As String
        Public Property Assignment2Label As String
        Public Property Assignment3Label As String
        Public Property Assignment4Label As String
        Public Property Assignment5Label As String
        Public Property ProjectManagerColumn As String
        Public Property CalculateByPredecessor As Integer
        Public Property IsQuickEdit As Boolean
        Public Property HasApprovedEstimate As Boolean

        Public Property IsScheduleCalculationLocked As Boolean

        Sub Load(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short)

            Me.JobNumber = JobNumber
            Me.JobComponentNumber = JobComponentNumber

            Me.CanUserView = AdvantageFramework.Security.CanUserPrintInModule(_Session, AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule)
            Me.CanUserEdit = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule)
            Me.CanUserInsert = AdvantageFramework.Security.CanUserAddInModule(_Session, AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule)
            Me.CanUserCustom1 = AdvantageFramework.Security.CanUserCustom1InModule(_Session, AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                Dim aParam As List(Of SqlParameter) = New List(Of SqlParameter)
                aParam.Add(New SqlParameter("@JobNumber", JobNumber))
                aParam.Add(New SqlParameter("@JobComponentNumber", JobComponentNumber))

                Me.Columns = AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Load(_Session, DbContext, IsClientPortal, False, False, False).ToArray

                Me.CalculateByPredecessor = DbContext.Database.SqlQuery(Of Integer)("select ISNULL(SCHEDULE_CALC,0) CalculateByPredecessor from JOB_TRAFFIC WHERE JOB_NUMBER = @JobNumber AND JOB_COMPONENT_NBR = @JobComponentNumber", aParam.ToArray).FirstOrDefault

                Me.HasApprovedEstimate = (From Item In AdvantageFramework.Database.Procedures.EstimateApprovalView.Load(DbContext)
                                          Where Item.JobNumber = JobNumber AndAlso
                                                    Item.JobComponentNumber = JobComponentNumber
                                          Select Item).Any
            End Using

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                Dim Settings As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing

                Settings = AdvantageFramework.Database.Procedures.Setting.LoadBySettingModuleID(DataContext, 0).ToList

                With Settings

                    Me.IsScheduleCalculationLocked = CBool(.Where(Function(s) s.Code = AdvantageFramework.EnumUtilities.LoadEnumObject(AgencySettingCodes.IsScheduleCalculationLocked).Code).FirstOrDefault().Value)
                    Me.Assignment1Label = .Where(Function(s) s.Code = AdvantageFramework.EnumUtilities.LoadEnumObject(AgencySettingCodes.Assignment1Label).Code).FirstOrDefault().Value
                    Me.Assignment2Label = .Where(Function(s) s.Code = AdvantageFramework.EnumUtilities.LoadEnumObject(AgencySettingCodes.Assignment2Label).Code).FirstOrDefault().Value
                    Me.Assignment3Label = .Where(Function(s) s.Code = AdvantageFramework.EnumUtilities.LoadEnumObject(AgencySettingCodes.Assignment3Label).Code).FirstOrDefault().Value
                    Me.Assignment4Label = .Where(Function(s) s.Code = AdvantageFramework.EnumUtilities.LoadEnumObject(AgencySettingCodes.Assignment4Label).Code).FirstOrDefault().Value
                    Me.Assignment5Label = .Where(Function(s) s.Code = AdvantageFramework.EnumUtilities.LoadEnumObject(AgencySettingCodes.Assignment5Label).Code).FirstOrDefault().Value
                    Me.ProjectManagerColumn = .Where(Function(s) s.Code = AdvantageFramework.EnumUtilities.LoadEnumObject(AgencySettingCodes.ProjectManagerColumn).Code).FirstOrDefault().Value

                End With

            End Using

        End Sub

        Public Sub New()

            'Me.AgencySettings = New AgencySetting()
            'Me.UserSettings = New UserSetting()

        End Sub

        Public Sub New(ByVal Session As AdvantageFramework.Security.Session)

            Me.New()

            _Session = Session

        End Sub


    End Class

End Namespace
