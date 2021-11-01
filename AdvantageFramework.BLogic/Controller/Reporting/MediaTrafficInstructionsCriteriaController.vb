'Imports AdvantageFramework.BaseClasses

Namespace Controller.Reporting

    Public Class MediaTrafficInstructionsCriteriaController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub LoadMediaBroadcastWorksheets(DbContext As AdvantageFramework.Database.DbContext, ByRef ViewModel As AdvantageFramework.ViewModels.Reporting.MediaTrafficInstructionsCriteriaViewModel)

            Dim SqlParameterIncludeInactive As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCriteriaType As System.Data.SqlClient.SqlParameter = Nothing
            Dim MediaBroadcastWorksheetMarketIDs As IEnumerable(Of Integer) = Nothing
            Dim MissingInstructions As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.MissingInstruction) = Nothing
            Dim MissingSpotsWorksheetMarketIDs As IEnumerable(Of Integer) = Nothing

            SqlParameterIncludeInactive = New System.Data.SqlClient.SqlParameter("@INCLUDE_INACTIVE_WORKSHEETS", SqlDbType.Bit)
            SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
            SqlParameterEndDate = New System.Data.SqlClient.SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
            SqlParameterCriteriaType = New System.Data.SqlClient.SqlParameter("@CRITERIA_TYPE", SqlDbType.SmallInt)

            SqlParameterIncludeInactive.Value = If(ViewModel.IncludeInactiveWorksheets, 1, 0)
            SqlParameterStartDate.Value = ViewModel.StartDate
            SqlParameterEndDate.Value = ViewModel.EndDate

            If ViewModel.IsMissingInstructionsDataset Then

                SqlParameterCriteriaType.Value = 1

            Else

                SqlParameterCriteriaType.Value = 0

            End If

            ViewModel.MediaBroadcastWorksheets = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.Traffic.Worksheet)("exec dbo.advsp_media_traffic_instructions_criteria @INCLUDE_INACTIVE_WORKSHEETS, @START_DATE, @END_DATE, @CRITERIA_TYPE",
                    SqlParameterIncludeInactive, SqlParameterStartDate, SqlParameterEndDate, SqlParameterCriteriaType).ToList

            If ViewModel.IsMissingInstructionsDataset Then

                MediaBroadcastWorksheetMarketIDs = ViewModel.MediaBroadcastWorksheets.Select(Function(W) W.MediaBroadcastWorksheetMarketID).Distinct.ToArray

                MissingInstructions = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.Traffic.MissingInstruction)(String.Format("exec dbo.advsp_media_traffic_missing_instructions NULL, NULL, '{0}'", String.Join(",", MediaBroadcastWorksheetMarketIDs.ToArray))).ToList

                MissingSpotsWorksheetMarketIDs = MissingInstructions.Where(Function(I) I.SpotDate >= SqlParameterStartDate.Value AndAlso I.SpotDate <= SqlParameterEndDate.Value).Select(Function(I) I.WorksheetMarketID).Distinct.ToArray

                ViewModel.MediaBroadcastWorksheets = (From Entity In ViewModel.MediaBroadcastWorksheets
                                                      Where MissingSpotsWorksheetMarketIDs.Contains(Entity.MediaBroadcastWorksheetMarketID)
                                                      Select Entity).ToList
            End If

        End Sub

#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Load(IsMissingInstructionsDataset As Boolean) As AdvantageFramework.ViewModels.Reporting.MediaTrafficInstructionsCriteriaViewModel

            'objects
            Dim MediaTrafficInstructionsCriteriaViewModel As AdvantageFramework.ViewModels.Reporting.MediaTrafficInstructionsCriteriaViewModel = Nothing

            MediaTrafficInstructionsCriteriaViewModel = New AdvantageFramework.ViewModels.Reporting.MediaTrafficInstructionsCriteriaViewModel
            MediaTrafficInstructionsCriteriaViewModel.IsMissingInstructionsDataset = IsMissingInstructionsDataset

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadMediaBroadcastWorksheets(DbContext, MediaTrafficInstructionsCriteriaViewModel)

            End Using

            Load = MediaTrafficInstructionsCriteriaViewModel

        End Function
        Public Sub RefreshWorksheets(ByRef MediaTrafficInstructionsCriteriaViewModel As AdvantageFramework.ViewModels.Reporting.MediaTrafficInstructionsCriteriaViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadMediaBroadcastWorksheets(DbContext, MediaTrafficInstructionsCriteriaViewModel)

            End Using

        End Sub

#End Region

#End Region

    End Class

End Namespace
