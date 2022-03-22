Namespace Controller.Media

    Public Class BroadcastResearchController
        Inherits AdvantageFramework.Controller.BaseController

        Private Class ProgramWeek

            Public Property program_name As String
            Public Property week As Integer

        End Class

#Region " Constants "

        Private Const _DaypartMessage As String = "Not all metrics are available for this Daypart.  Please check available metric list on the Daypart tab."

#End Region

#Region " Enum "

        Public Enum MoveItemDirection
            Down
            Up
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Function CreateSpotTVRankerReportDataTable(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                           MediaSpotTVResearchMetricList As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpotTVResearchMetric)) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim SortString As String = Nothing
            Dim RankDataTable As System.Data.DataTable = Nothing
            Dim DataRowRank As Nullable(Of Integer) = Nothing
            Dim StationCodeDaytimeIDs As Generic.List(Of String) = Nothing
            Dim RankStationCode As Integer = Nothing
            Dim RankDaytimeID As Integer = Nothing
            Dim RankDataRow As System.Data.DataRow = Nothing

            DataTable = New System.Data.DataTable

            StationCodeDaytimeIDs = New Generic.List(Of String)

            If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ShowSpill Then

                DataColumn = DataTable.Columns.Add("IsSpill")
                DataColumn.DataType = GetType(Boolean)

            End If

            DataColumn = DataTable.Columns.Add("StationCode")
            DataColumn.DataType = GetType(Integer)

            DataColumn = DataTable.Columns.Add("DaytimeID")
            DataColumn.DataType = GetType(Integer)

            DataColumn = DataTable.Columns.Add("Station")
            DataColumn.DataType = GetType(String)

            DataColumn = DataTable.Columns.Add("Days")
            DataColumn.DataType = GetType(String)

            DataColumn = DataTable.Columns.Add("Times")
            DataColumn.DataType = GetType(String)

            If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ShowProgramName Then

                DataColumn = DataTable.Columns.Add("ProgramName")
                DataColumn.DataType = GetType(String)

            End If

            For Each Demo In (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                              Select Entity.BookID,
                                     Entity.DemographicOrder,
                                     Entity.HPUTBookID,
                                     Entity.MediaSpotTVResearchBookID).OrderBy(Function(Entity) Entity.DemographicOrder).ThenBy(Function(Entity) Entity.MediaSpotTVResearchBookID).Distinct.ToList

                DataColumn = DataTable.Columns.Add("Demo" & Demo.DemographicOrder & "_" & Demo.BookID & "_" & Demo.HPUTBookID.GetValueOrDefault(0))
                DataColumn.DataType = GetType(String)

                DataColumn = DataTable.Columns.Add("Rank" & Demo.DemographicOrder & "_" & Demo.BookID & "_" & Demo.HPUTBookID.GetValueOrDefault(0))
                DataColumn.DataType = GetType(Integer)

                For Each MediaSpotTVResearchMetric In MediaSpotTVResearchMetricList.OrderBy(Function(Entity) Entity.Order)

                    DataColumn = DataTable.Columns.Add(MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "") & Demo.DemographicOrder & "_" & Demo.BookID & "_" & Demo.HPUTBookID.GetValueOrDefault(0))
                    DataColumn.DataType = GetType(Decimal)

                    If SortString Is Nothing Then

                        SortString = MediaSpotTVResearchMetric.MediaMetric.Description & " DESC"

                    End If
                    'SortString += If(String.IsNullOrWhiteSpace(SortString), MediaSpotTVResearchMetric.MediaMetric.Description & " DESC", ", " & MediaSpotTVResearchMetric.MediaMetric.Description & " DESC")

                Next

                DataColumn = DataTable.Columns.Add("ShowIntabWarning" & Demo.DemographicOrder & "_" & Demo.BookID & "_" & Demo.HPUTBookID.GetValueOrDefault(0))
                DataColumn.DataType = GetType(Boolean)

                If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                    DataColumn = DataTable.Columns.Add("CSInfo" & Demo.DemographicOrder & "_" & Demo.BookID & "_" & Demo.HPUTBookID.GetValueOrDefault(0))
                    DataColumn.DataType = GetType(String)

                End If

            Next

            For Each ResearchResult In (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                        Select Entity.Station, Entity.DaytimeID, Entity.StationCode, Entity.IsSpill).Distinct.ToList

                DataRow = DataTable.NewRow

                If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ShowSpill Then

                    DataRow("IsSpill") = ResearchResult.IsSpill

                End If

                DataRow("StationCode") = ResearchResult.StationCode

                DataRow("DaytimeID") = ResearchResult.DaytimeID

                DataRow("Station") = ResearchResult.Station

                DataRow("Days") = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                   Where Entity.Station = ResearchResult.Station AndAlso
                                         Entity.DaytimeID = ResearchResult.DaytimeID
                                   Select Entity).FirstOrDefault.Days

                DataRow("Times") = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                    Where Entity.Station = ResearchResult.Station AndAlso
                                          Entity.DaytimeID = ResearchResult.DaytimeID
                                    Select Entity).FirstOrDefault.Times

                If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ShowProgramName Then

                    DataRow("ProgramName") = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                              Where Entity.Station = ResearchResult.Station AndAlso
                                                Entity.DaytimeID = ResearchResult.DaytimeID
                                              Select Entity).FirstOrDefault.ProgramName

                End If

                For Each DemoOrder In (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                       Where Entity.Station = ResearchResult.Station AndAlso
                                             Entity.DaytimeID = ResearchResult.DaytimeID
                                       Select Entity.DemographicOrder,
                                              Entity.BookID,
                                              Entity.DemographicStream,
                                              Entity.HPUTBookID,
                                              Entity.MediaSpotTVResearchBookID).OrderBy(Function(Entity) Entity.DemographicOrder).ThenBy(Function(Entity) Entity.MediaSpotTVResearchBookID).Distinct.ToList

                    DataRow("Demo" & DemoOrder.DemographicOrder & "_" & DemoOrder.BookID & "_" & DemoOrder.HPUTBookID.GetValueOrDefault(0)) = DemoOrder.DemographicStream

                    If DemoOrder.DemographicOrder = 1 OrElse Not BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.MaxRank.HasValue Then

                        'rank
                        RankDataTable = AdvantageFramework.Database.ToDataTable((From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                 Where Entity.DemographicOrder = DemoOrder.DemographicOrder AndAlso
                                                                                       Entity.BookID = DemoOrder.BookID AndAlso
                                                                                       Entity.HPUTBookID.GetValueOrDefault(0) = DemoOrder.HPUTBookID.GetValueOrDefault(0)
                                                                                 Select Entity).ToList)

                        RankDataTable.DefaultView.Sort = Replace(SortString, "/", "")

                        If MediaSpotTVResearchMetricList IsNot Nothing AndAlso MediaSpotTVResearchMetricList.Count > 0 Then

                            RankIt(RankDataTable, MediaSpotTVResearchMetricList.OrderBy(Function(Entity) Entity.Order).FirstOrDefault.MediaMetric.Description.Replace("/", ""))

                        End If

                        If Not DataRowRank.HasValue Then

                            DataRowRank = RankDataTable.Select("StationCode = " & ResearchResult.StationCode & " AND DaytimeID = " & ResearchResult.DaytimeID).FirstOrDefault.Item("Rank")

                        End If

                        DataRow("Rank" & DemoOrder.DemographicOrder & "_" & DemoOrder.BookID & "_" & DemoOrder.HPUTBookID.GetValueOrDefault(0)) = RankDataTable.Select("StationCode = " & ResearchResult.StationCode & " AND DaytimeID = " & ResearchResult.DaytimeID).FirstOrDefault.Item("Rank")

                    End If

                    For Each MediaSpotTVResearchMetric In MediaSpotTVResearchMetricList.OrderBy(Function(Entity) Entity.Order)

                        Select Case MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "")

                            Case "Rating"

                                DataRow(MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "") & DemoOrder.DemographicOrder & "_" & DemoOrder.BookID &
                                         "_" & DemoOrder.HPUTBookID.GetValueOrDefault(0)) = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                             Where Entity.Station = ResearchResult.Station AndAlso
                                                                                                   Entity.DaytimeID = ResearchResult.DaytimeID AndAlso
                                                                                                   Entity.DemographicOrder = DemoOrder.DemographicOrder AndAlso
                                                                                                   Entity.BookID = DemoOrder.BookID AndAlso
                                                                                                   Entity.HPUTBookID.GetValueOrDefault(0) = DemoOrder.HPUTBookID.GetValueOrDefault(0)
                                                                                             Select Entity).FirstOrDefault.Rating

                            Case "Share"

                                DataRow(MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "") & DemoOrder.DemographicOrder & "_" & DemoOrder.BookID &
                                         "_" & DemoOrder.HPUTBookID.GetValueOrDefault(0)) = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                             Where Entity.Station = ResearchResult.Station AndAlso
                                                                                                   Entity.DaytimeID = ResearchResult.DaytimeID AndAlso
                                                                                                   Entity.DemographicOrder = DemoOrder.DemographicOrder AndAlso
                                                                                                   Entity.BookID = DemoOrder.BookID AndAlso
                                                                                                   Entity.HPUTBookID.GetValueOrDefault(0) = DemoOrder.HPUTBookID.GetValueOrDefault(0)
                                                                                             Select Entity).FirstOrDefault.Share

                            Case "Impressions"

                                DataRow(MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "") & DemoOrder.DemographicOrder & "_" & DemoOrder.BookID &
                                         "_" & DemoOrder.HPUTBookID.GetValueOrDefault(0)) = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                             Where Entity.Station = ResearchResult.Station AndAlso
                                                                                                   Entity.DaytimeID = ResearchResult.DaytimeID AndAlso
                                                                                                   Entity.DemographicOrder = DemoOrder.DemographicOrder AndAlso
                                                                                                   Entity.BookID = DemoOrder.BookID AndAlso
                                                                                                   Entity.HPUTBookID.GetValueOrDefault(0) = DemoOrder.HPUTBookID.GetValueOrDefault(0)
                                                                                             Select Entity).FirstOrDefault.Impressions

                            Case "HPUT"

                                DataRow(MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "") & DemoOrder.DemographicOrder & "_" & DemoOrder.BookID &
                                         "_" & DemoOrder.HPUTBookID.GetValueOrDefault(0)) = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                             Where Entity.Station = ResearchResult.Station AndAlso
                                                                                                   Entity.DaytimeID = ResearchResult.DaytimeID AndAlso
                                                                                                   Entity.DemographicOrder = DemoOrder.DemographicOrder AndAlso
                                                                                                   Entity.BookID = DemoOrder.BookID AndAlso
                                                                                                   Entity.HPUTBookID.GetValueOrDefault(0) = DemoOrder.HPUTBookID.GetValueOrDefault(0)
                                                                                             Select Entity).FirstOrDefault.HPUT

                            Case "Intab"

                                DataRow(MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "") & DemoOrder.DemographicOrder & "_" & DemoOrder.BookID &
                                         "_" & DemoOrder.HPUTBookID.GetValueOrDefault(0)) = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                             Where Entity.Station = ResearchResult.Station AndAlso
                                                                                                   Entity.DaytimeID = ResearchResult.DaytimeID AndAlso
                                                                                                   Entity.DemographicOrder = DemoOrder.DemographicOrder AndAlso
                                                                                                   Entity.BookID = DemoOrder.BookID AndAlso
                                                                                                   Entity.HPUTBookID.GetValueOrDefault(0) = DemoOrder.HPUTBookID.GetValueOrDefault(0)
                                                                                             Select Entity).FirstOrDefault.Intab

                                DataRow("ShowIntabWarning" & DemoOrder.DemographicOrder & "_" & DemoOrder.BookID &
                                        "_" & DemoOrder.HPUTBookID.GetValueOrDefault(0)) = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                            Where Entity.Station = ResearchResult.Station AndAlso
                                                                                                  Entity.DaytimeID = ResearchResult.DaytimeID AndAlso
                                                                                                  Entity.DemographicOrder = DemoOrder.DemographicOrder AndAlso
                                                                                                  Entity.BookID = DemoOrder.BookID AndAlso
                                                                                                  Entity.HPUTBookID.GetValueOrDefault(0) = DemoOrder.HPUTBookID.GetValueOrDefault(0)
                                                                                            Select Entity).FirstOrDefault.ShowIntabWarning

                            Case "Universe"

                                DataRow(MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "") & DemoOrder.DemographicOrder & "_" & DemoOrder.BookID &
                                         "_" & DemoOrder.HPUTBookID.GetValueOrDefault(0)) = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                             Where Entity.Station = ResearchResult.Station AndAlso
                                                                                                   Entity.DaytimeID = ResearchResult.DaytimeID AndAlso
                                                                                                   Entity.DemographicOrder = DemoOrder.DemographicOrder AndAlso
                                                                                                   Entity.BookID = DemoOrder.BookID AndAlso
                                                                                                   Entity.HPUTBookID.GetValueOrDefault(0) = DemoOrder.HPUTBookID.GetValueOrDefault(0)
                                                                                             Select Entity).FirstOrDefault.Universe

                        End Select

                    Next

                    If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                        If Not (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                Where Entity.Station = ResearchResult.Station AndAlso
                                      Entity.DaytimeID = ResearchResult.DaytimeID AndAlso
                                      Entity.DemographicOrder = DemoOrder.DemographicOrder AndAlso
                                      Entity.BookID = DemoOrder.BookID AndAlso
                                      Entity.HPUTBookID.GetValueOrDefault(0) = DemoOrder.HPUTBookID.GetValueOrDefault(0)
                                Select Entity).FirstOrDefault.ComscoreMeetsDemoThreshold Then

                            DataRow("CSInfo" & DemoOrder.DemographicOrder & "_" & DemoOrder.BookID & "_" & DemoOrder.HPUTBookID.GetValueOrDefault(0)) = "**"

                        ElseIf Not (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                    Where Entity.Station = ResearchResult.Station AndAlso
                                          Entity.DaytimeID = ResearchResult.DaytimeID AndAlso
                                          Entity.DemographicOrder = DemoOrder.DemographicOrder AndAlso
                                          Entity.BookID = DemoOrder.BookID AndAlso
                                          Entity.HPUTBookID.GetValueOrDefault(0) = DemoOrder.HPUTBookID.GetValueOrDefault(0)
                                    Select Entity).FirstOrDefault.ComscoreMeetsHighQualityDemoThreshold Then

                            DataRow("CSInfo" & DemoOrder.DemographicOrder & "_" & DemoOrder.BookID & "_" & DemoOrder.HPUTBookID.GetValueOrDefault(0)) = "*"

                        End If

                    End If

                Next

                If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.MaxRank.HasValue Then

                    If DataRowRank.Value <= BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.MaxRank.Value Then

                        DataTable.Rows.Add(DataRow)

                        StationCodeDaytimeIDs.Add(ResearchResult.StationCode.ToString & "|" & ResearchResult.DaytimeID.ToString)

                    End If

                    DataRowRank = Nothing

                Else

                    DataTable.Rows.Add(DataRow)

                End If

            Next

            For Each StationCodeDaytimeID In StationCodeDaytimeIDs

                RankStationCode = Left(StationCodeDaytimeID, InStr(StationCodeDaytimeID, "|") - 1)
                RankDaytimeID = Mid(StationCodeDaytimeID, InStr(StationCodeDaytimeID, "|") + 1)

                For Each DemoOrder In (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                       Where Entity.DemographicOrder > 1 AndAlso
                                             StationCodeDaytimeIDs.Contains(Entity.StationCode & "|" & Entity.DaytimeID)
                                       Select Entity.DemographicOrder,
                                              Entity.BookID,
                                              Entity.DemographicStream,
                                              Entity.HPUTBookID,
                                              Entity.MediaSpotTVResearchBookID).OrderBy(Function(Entity) Entity.DemographicOrder).ThenBy(Function(Entity) Entity.MediaSpotTVResearchBookID).Distinct.ToList

                    'rank
                    RankDataTable = AdvantageFramework.Database.ToDataTable((From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                             Where Entity.DemographicOrder = DemoOrder.DemographicOrder AndAlso
                                                                                   Entity.BookID = DemoOrder.BookID AndAlso
                                                                                   Entity.HPUTBookID.GetValueOrDefault(0) = DemoOrder.HPUTBookID.GetValueOrDefault(0) AndAlso
                                                                                   StationCodeDaytimeIDs.Contains(Entity.StationCode & "|" & Entity.DaytimeID)
                                                                             Select Entity).ToList)

                    RankDataTable.DefaultView.Sort = Replace(SortString, "/", "")

                    If MediaSpotTVResearchMetricList IsNot Nothing AndAlso MediaSpotTVResearchMetricList.Count > 0 Then

                        RankIt(RankDataTable, MediaSpotTVResearchMetricList.OrderBy(Function(Entity) Entity.Order).FirstOrDefault.MediaMetric.Description.Replace("/", ""))

                    End If

                    RankDataRow = DataTable.Select("StationCode = " & RankStationCode & " AND DaytimeID = " & RankDaytimeID).FirstOrDefault
                    RankDataRow("Rank" & DemoOrder.DemographicOrder & "_" & DemoOrder.BookID & "_" & DemoOrder.HPUTBookID.GetValueOrDefault(0)) = RankDataTable.Select("StationCode = " & RankStationCode & " AND DaytimeID = " & RankDaytimeID).FirstOrDefault.Item("Rank")

                Next

            Next

            CreateSpotTVRankerReportDataTable = DataTable

        End Function
        Private Function CreateSpotTVTrendByBookReportDataTable(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                                MediaSpotTVResearchMetricList As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpotTVResearchMetric)) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            DataTable = New System.Data.DataTable

            DataColumn = DataTable.Columns.Add("Books")
            DataColumn.DataType = GetType(String)

            DataColumn = DataTable.Columns.Add("Days")
            DataColumn.DataType = GetType(String)

            DataColumn = DataTable.Columns.Add("Times")
            DataColumn.DataType = GetType(String)

            DataColumn = DataTable.Columns.Add("BookIDDaytimeID")
            DataColumn.DataType = GetType(String)

            For Each Demo In (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                              Select Entity.StationCode).Distinct.ToList

                DataColumn = DataTable.Columns.Add("Station" & Demo.ToString)
                DataColumn.DataType = GetType(String)

                For Each MediaSpotTVResearchMetric In MediaSpotTVResearchMetricList.OrderBy(Function(Entity) Entity.Order)

                    DataColumn = DataTable.Columns.Add(MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "") & Demo.ToString)
                    DataColumn.DataType = GetType(Decimal)

                Next

                DataColumn = DataTable.Columns.Add("ShowIntabWarning" & Demo.ToString)
                DataColumn.DataType = GetType(Boolean)

                If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ShowProgramName Then

                    DataColumn = DataTable.Columns.Add("ProgramName" & Demo.ToString)
                    DataColumn.DataType = GetType(String)

                End If

                If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                    DataColumn = DataTable.Columns.Add("CSInfo" & Demo.ToString)
                    DataColumn.DataType = GetType(String)

                End If

            Next

            For Each ResearchResult In (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                        Select Entity.Books,
                                               Entity.BookID,
                                               Entity.HPUTBookID,
                                               Entity.DaytimeID,
                                               Entity.StreamYear,
                                               Entity.StreamMonth,
                                               Entity.StartHour).Distinct.OrderBy(Function(Entity) Entity.StartHour).ThenBy(Function(Entity) Entity.DaytimeID).ThenBy(Function(Entity) Entity.StreamYear).ThenBy(Function(Entity) Entity.StreamMonth).ToList

                DataRow = DataTable.NewRow

                DataRow("BookIDDaytimeID") = ResearchResult.BookID.ToString & "|" & ResearchResult.DaytimeID.ToString

                DataRow("Books") = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                    Where Entity.BookID = ResearchResult.BookID AndAlso
                                          Entity.DaytimeID = ResearchResult.DaytimeID AndAlso
                                          Entity.HPUTBookID.GetValueOrDefault(0) = ResearchResult.HPUTBookID.GetValueOrDefault(0)
                                    Select Entity).FirstOrDefault.Books

                DataRow("Days") = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                   Where Entity.BookID = ResearchResult.BookID AndAlso
                                         Entity.DaytimeID = ResearchResult.DaytimeID AndAlso
                                         Entity.HPUTBookID.GetValueOrDefault(0) = ResearchResult.HPUTBookID.GetValueOrDefault(0)
                                   Select Entity).FirstOrDefault.Days

                DataRow("Times") = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                    Where Entity.BookID = ResearchResult.BookID AndAlso
                                          Entity.DaytimeID = ResearchResult.DaytimeID AndAlso
                                          Entity.HPUTBookID.GetValueOrDefault(0) = ResearchResult.HPUTBookID.GetValueOrDefault(0)
                                    Select Entity).FirstOrDefault.Times

                For Each StreamOrder In (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                         Where Entity.BookID = ResearchResult.BookID AndAlso
                                               Entity.DaytimeID = ResearchResult.DaytimeID AndAlso
                                               Entity.HPUTBookID.GetValueOrDefault(0) = ResearchResult.HPUTBookID.GetValueOrDefault(0)
                                         Select Entity.Station, Entity.BookID, Entity.DaytimeID, Entity.StationCode, Entity.IsSpill, Entity.ProgramName, Entity.HPUTBookID).Distinct.ToList

                    DataRow("Station" & StreamOrder.StationCode) = StreamOrder.Station

                    For Each MediaSpotTVResearchMetric In MediaSpotTVResearchMetricList.OrderBy(Function(Entity) Entity.Order)

                        Select Case MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "")

                            Case "Rating"

                                DataRow(MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "") & StreamOrder.StationCode.ToString) = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                                                                                  Where Entity.StationCode = StreamOrder.StationCode AndAlso
                                                                                                                                                        Entity.DaytimeID = StreamOrder.DaytimeID AndAlso
                                                                                                                                                        Entity.BookID = StreamOrder.BookID AndAlso
                                                                                                                                                        Entity.HPUTBookID.GetValueOrDefault(0) = StreamOrder.HPUTBookID.GetValueOrDefault(0)
                                                                                                                                                  Select Entity).FirstOrDefault.Rating

                            Case "Share"

                                DataRow(MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "") & StreamOrder.StationCode.ToString) = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                                                                                  Where Entity.StationCode = StreamOrder.StationCode AndAlso
                                                                                                                                                        Entity.DaytimeID = StreamOrder.DaytimeID AndAlso
                                                                                                                                                        Entity.BookID = StreamOrder.BookID AndAlso
                                                                                                                                                        Entity.HPUTBookID.GetValueOrDefault(0) = StreamOrder.HPUTBookID.GetValueOrDefault(0)
                                                                                                                                                  Select Entity).FirstOrDefault.Share

                            Case "Impressions"

                                DataRow(MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "") & StreamOrder.StationCode.ToString) = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                                                                                  Where Entity.StationCode = StreamOrder.StationCode AndAlso
                                                                                                                                                        Entity.DaytimeID = StreamOrder.DaytimeID AndAlso
                                                                                                                                                        Entity.BookID = StreamOrder.BookID AndAlso
                                                                                                                                                        Entity.HPUTBookID.GetValueOrDefault(0) = StreamOrder.HPUTBookID.GetValueOrDefault(0)
                                                                                                                                                  Select Entity).FirstOrDefault.Impressions

                            Case "HPUT"

                                DataRow(MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "") & StreamOrder.StationCode.ToString) = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                                                                                  Where Entity.StationCode = StreamOrder.StationCode AndAlso
                                                                                                                                                        Entity.DaytimeID = StreamOrder.DaytimeID AndAlso
                                                                                                                                                        Entity.BookID = StreamOrder.BookID AndAlso
                                                                                                                                                        Entity.HPUTBookID.GetValueOrDefault(0) = StreamOrder.HPUTBookID.GetValueOrDefault(0)
                                                                                                                                                  Select Entity).FirstOrDefault.HPUT

                            Case "Intab"

                                DataRow(MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "") & StreamOrder.StationCode.ToString) = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                                                                                  Where Entity.StationCode = StreamOrder.StationCode AndAlso
                                                                                                                                                        Entity.DaytimeID = StreamOrder.DaytimeID AndAlso
                                                                                                                                                        Entity.BookID = StreamOrder.BookID AndAlso
                                                                                                                                                        Entity.HPUTBookID.GetValueOrDefault(0) = StreamOrder.HPUTBookID.GetValueOrDefault(0)
                                                                                                                                                  Select Entity).FirstOrDefault.Intab

                                DataRow("ShowIntabWarning" & StreamOrder.StationCode.ToString) = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                                  Where Entity.StationCode = StreamOrder.StationCode AndAlso
                                                                                                        Entity.DaytimeID = StreamOrder.DaytimeID AndAlso
                                                                                                        Entity.BookID = StreamOrder.BookID AndAlso
                                                                                                        Entity.HPUTBookID.GetValueOrDefault(0) = StreamOrder.HPUTBookID.GetValueOrDefault(0)
                                                                                                  Select Entity).FirstOrDefault.ShowIntabWarning

                            Case "Universe"

                                DataRow(MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "") & StreamOrder.StationCode.ToString) = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                                                                                  Where Entity.StationCode = StreamOrder.StationCode AndAlso
                                                                                                                                                        Entity.DaytimeID = StreamOrder.DaytimeID AndAlso
                                                                                                                                                        Entity.BookID = StreamOrder.BookID AndAlso
                                                                                                                                                        Entity.HPUTBookID.GetValueOrDefault(0) = StreamOrder.HPUTBookID.GetValueOrDefault(0)
                                                                                                                                                  Select Entity).FirstOrDefault.Universe

                        End Select

                    Next

                    If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ShowProgramName Then

                        DataRow("ProgramName" & StreamOrder.StationCode) = StreamOrder.ProgramName

                    End If

                    If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                        If Not (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                Where Entity.StationCode = StreamOrder.StationCode AndAlso
                                      Entity.DaytimeID = StreamOrder.DaytimeID AndAlso
                                      Entity.BookID = StreamOrder.BookID AndAlso
                                      Entity.HPUTBookID.GetValueOrDefault(0) = StreamOrder.HPUTBookID.GetValueOrDefault(0)
                                Select Entity).FirstOrDefault.ComscoreMeetsDemoThreshold Then

                            DataRow("CSInfo" & StreamOrder.StationCode.ToString) = "**"

                        ElseIf Not (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                    Where Entity.StationCode = StreamOrder.StationCode AndAlso
                                      Entity.DaytimeID = StreamOrder.DaytimeID AndAlso
                                      Entity.BookID = StreamOrder.BookID AndAlso
                                      Entity.HPUTBookID.GetValueOrDefault(0) = StreamOrder.HPUTBookID.GetValueOrDefault(0)
                                    Select Entity).FirstOrDefault.ComscoreMeetsHighQualityDemoThreshold Then

                            DataRow("CSInfo" & StreamOrder.StationCode.ToString) = "*"

                        End If

                    End If

                Next

                DataTable.Rows.Add(DataRow)

            Next

            CreateSpotTVTrendByBookReportDataTable = DataTable

        End Function
        Private Function CreateSpotTVTrendByStationReportDataTable(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                                   MediaSpotTVResearchMetricList As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpotTVResearchMetric)) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            DataTable = New System.Data.DataTable

            If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ShowSpill Then

                DataColumn = DataTable.Columns.Add("IsSpill")
                DataColumn.DataType = GetType(Boolean)

            End If

            DataColumn = DataTable.Columns.Add("Station")
            DataColumn.DataType = GetType(String)

            DataColumn = DataTable.Columns.Add("StationCode")
            DataColumn.DataType = GetType(String)

            DataColumn = DataTable.Columns.Add("Days")
            DataColumn.DataType = GetType(String)

            DataColumn = DataTable.Columns.Add("Times")
            DataColumn.DataType = GetType(String)

            For Each Book In (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                              Select Entity.MediaSpotTVResearchBookID).Distinct.ToList

                DataColumn = DataTable.Columns.Add("Books" & Book.ToString)
                DataColumn.DataType = GetType(String)

                DataColumn = DataTable.Columns.Add("BookIDDaytimeID" & Book.ToString)
                DataColumn.DataType = GetType(String)

                For Each MediaSpotTVResearchMetric In MediaSpotTVResearchMetricList.OrderBy(Function(Entity) Entity.Order)

                    DataColumn = DataTable.Columns.Add(MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "") & Book.ToString)
                    DataColumn.DataType = GetType(Decimal)

                Next

                DataColumn = DataTable.Columns.Add("ShowIntabWarning" & Book.ToString)
                DataColumn.DataType = GetType(Boolean)

                If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ShowProgramName Then

                    DataColumn = DataTable.Columns.Add("ProgramName" & Book.ToString)
                    DataColumn.DataType = GetType(String)

                End If

                If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                    DataColumn = DataTable.Columns.Add("CSInfo" & Book.ToString)
                    DataColumn.DataType = GetType(String)

                End If

            Next

            For Each ResearchResult In (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                        Select Entity.StartHour, Entity.Station, Entity.DaytimeID, Entity.StationCode, Entity.IsSpill).Distinct.OrderBy(Function(Entity) Entity.StartHour).ThenBy(Function(Entity) Entity.DaytimeID).ThenBy(Function(Entity) Entity.Station).ToList

                DataRow = DataTable.NewRow

                If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ShowSpill Then

                    DataRow("IsSpill") = ResearchResult.IsSpill

                End If

                DataRow("Station") = ResearchResult.Station

                DataRow("StationCode") = ResearchResult.StationCode

                DataRow("Days") = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                   Where Entity.Station = ResearchResult.Station AndAlso
                                         Entity.DaytimeID = ResearchResult.DaytimeID
                                   Select Entity).FirstOrDefault.Days

                DataRow("Times") = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                    Where Entity.Station = ResearchResult.Station AndAlso
                                          Entity.DaytimeID = ResearchResult.DaytimeID
                                    Select Entity).FirstOrDefault.Times

                For Each StreamOrder In (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                         Where Entity.Station = ResearchResult.Station AndAlso
                                               Entity.DaytimeID = ResearchResult.DaytimeID
                                         Select Entity.StationCode,
                                                Entity.DaytimeID,
                                                Entity.MediaSpotTVResearchBookID,
                                                Entity.Books,
                                                Entity.ProgramName,
                                                Entity.BookID).OrderBy(Function(Entity) Entity.MediaSpotTVResearchBookID).Distinct.ToList

                    DataRow("Books" & StreamOrder.MediaSpotTVResearchBookID) = StreamOrder.Books

                    DataRow("BookIDDaytimeID" & StreamOrder.MediaSpotTVResearchBookID) = StreamOrder.BookID.ToString & "|" & ResearchResult.DaytimeID.ToString

                    For Each MediaSpotTVResearchMetric In MediaSpotTVResearchMetricList.OrderBy(Function(Entity) Entity.Order)

                        Select Case MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "")

                            Case "Rating"

                                DataRow(MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "") & StreamOrder.MediaSpotTVResearchBookID.ToString) = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                                                                                                Where Entity.MediaSpotTVResearchBookID = StreamOrder.MediaSpotTVResearchBookID AndAlso
                                                                                                                                                                      Entity.StationCode = StreamOrder.StationCode AndAlso
                                                                                                                                                                      Entity.DaytimeID = StreamOrder.DaytimeID
                                                                                                                                                                Select Entity).FirstOrDefault.Rating

                            Case "Share"

                                DataRow(MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "") & StreamOrder.MediaSpotTVResearchBookID.ToString) = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                                                                                                Where Entity.MediaSpotTVResearchBookID = StreamOrder.MediaSpotTVResearchBookID AndAlso
                                                                                                                                                                      Entity.StationCode = StreamOrder.StationCode AndAlso
                                                                                                                                                                      Entity.DaytimeID = StreamOrder.DaytimeID
                                                                                                                                                                Select Entity).FirstOrDefault.Share

                            Case "Impressions"

                                DataRow(MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "") & StreamOrder.MediaSpotTVResearchBookID.ToString) = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                                                                                                Where Entity.MediaSpotTVResearchBookID = StreamOrder.MediaSpotTVResearchBookID AndAlso
                                                                                                                                                                      Entity.StationCode = StreamOrder.StationCode AndAlso
                                                                                                                                                                      Entity.DaytimeID = StreamOrder.DaytimeID
                                                                                                                                                                Select Entity).FirstOrDefault.Impressions

                            Case "HPUT"

                                DataRow(MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "") & StreamOrder.MediaSpotTVResearchBookID.ToString) = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                                                                                                Where Entity.MediaSpotTVResearchBookID = StreamOrder.MediaSpotTVResearchBookID AndAlso
                                                                                                                                                                      Entity.StationCode = StreamOrder.StationCode AndAlso
                                                                                                                                                                      Entity.DaytimeID = StreamOrder.DaytimeID
                                                                                                                                                                Select Entity).FirstOrDefault.HPUT

                            Case "Intab"

                                DataRow(MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "") & StreamOrder.MediaSpotTVResearchBookID.ToString) = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                                                                                                Where Entity.MediaSpotTVResearchBookID = StreamOrder.MediaSpotTVResearchBookID AndAlso
                                                                                                                                                                      Entity.StationCode = StreamOrder.StationCode AndAlso
                                                                                                                                                                      Entity.DaytimeID = StreamOrder.DaytimeID
                                                                                                                                                                Select Entity).FirstOrDefault.Intab

                                DataRow("ShowIntabWarning" & StreamOrder.MediaSpotTVResearchBookID.ToString) = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                                                Where Entity.MediaSpotTVResearchBookID = StreamOrder.MediaSpotTVResearchBookID AndAlso
                                                                                                                      Entity.StationCode = StreamOrder.StationCode AndAlso
                                                                                                                      Entity.DaytimeID = StreamOrder.DaytimeID
                                                                                                                Select Entity).FirstOrDefault.ShowIntabWarning

                            Case "Universe"

                                DataRow(MediaSpotTVResearchMetric.MediaMetric.Description.Replace("/", "") & StreamOrder.MediaSpotTVResearchBookID.ToString) = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                                                                                                Where Entity.MediaSpotTVResearchBookID = StreamOrder.MediaSpotTVResearchBookID AndAlso
                                                                                                                                                                      Entity.StationCode = StreamOrder.StationCode AndAlso
                                                                                                                                                                      Entity.DaytimeID = StreamOrder.DaytimeID
                                                                                                                                                                Select Entity).FirstOrDefault.Universe

                        End Select

                    Next

                    If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ShowProgramName Then

                        DataRow("ProgramName" & StreamOrder.MediaSpotTVResearchBookID) = StreamOrder.ProgramName

                    End If

                    If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                        If Not (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                Where Entity.MediaSpotTVResearchBookID = StreamOrder.MediaSpotTVResearchBookID AndAlso
                                      Entity.StationCode = StreamOrder.StationCode AndAlso
                                      Entity.DaytimeID = StreamOrder.DaytimeID
                                Select Entity).FirstOrDefault.ComscoreMeetsDemoThreshold Then

                            DataRow("CSInfo" & StreamOrder.MediaSpotTVResearchBookID.ToString) = "**"

                        ElseIf Not (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                    Where Entity.MediaSpotTVResearchBookID = StreamOrder.MediaSpotTVResearchBookID AndAlso
                                          Entity.StationCode = StreamOrder.StationCode AndAlso
                                          Entity.DaytimeID = StreamOrder.DaytimeID
                                    Select Entity).FirstOrDefault.ComscoreMeetsHighQualityDemoThreshold Then

                            DataRow("CSInfo" & StreamOrder.MediaSpotTVResearchBookID.ToString) = "*"

                        End If

                    End If

                Next

                DataTable.Rows.Add(DataRow)

            Next

            CreateSpotTVTrendByStationReportDataTable = DataTable

        End Function
        Private Sub RankIt(DataTable As System.Data.DataTable, PrimaryFieldName As String)

            'objects
            Dim CurrentRank As Integer = 0
            Dim LastValue As Decimal = -1
            Dim RankValue As Decimal = 0

            For i As Integer = 0 To DataTable.DefaultView.Count - 1

                Select Case PrimaryFieldName

                    Case "Rating", "Share", "HPUT"

                        RankValue = FormatNumber(DataTable.DefaultView.Item(i).Item(PrimaryFieldName), 2)

                    Case "Impressions", "AQHRating", "AQHShare", "PURPercent"

                        RankValue = FormatNumber(DataTable.DefaultView.Item(i).Item(PrimaryFieldName), 1)

                    Case Else

                        RankValue = DataTable.DefaultView.Item(i).Item(PrimaryFieldName)

                End Select

                If RankValue = LastValue Then

                    DataTable.DefaultView.Item(i).Item("Rank") = CurrentRank

                Else

                    DataTable.DefaultView.Item(i).Item("Rank") = i + 1

                    CurrentRank = i + 1

                    LastValue = RankValue

                End If

            Next

        End Sub
        Private Function RequiredSpotTVDataPresent(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                   ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsPresent As Boolean = False

            ErrorMessage = String.Empty

            If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID <> AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen AndAlso
                    BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID <> AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                ErrorMessage = "A ratings source must be selected."

            ElseIf BroadcastResearchViewModel.SpotTVSelectedNielsenStationList Is Nothing OrElse BroadcastResearchViewModel.SpotTVSelectedNielsenStationList.Count = 0 Then

                ErrorMessage += vbCrLf & "At least one station must be selected."

            ElseIf BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore AndAlso
                   BroadcastResearchViewModel.SpotTVSelectedNielsenStationList.Count > 100 Then

                ErrorMessage += vbCrLf & "No more than 100 stations can be selected for Comscore."

            End If

            If BroadcastResearchViewModel.SpotTVSelectedDayTimes Is Nothing OrElse BroadcastResearchViewModel.SpotTVSelectedDayTimes.Count = 0 Then

                ErrorMessage += vbCrLf & "At least one day/time must be selected."

            ElseIf BroadcastResearchViewModel.SpotTVSelectedDayTimes.Any(Function(Entity) Entity.HasError) Then

                ErrorMessage += vbCrLf & "Please fix day/time errors before saving."

            End If

            If BroadcastResearchViewModel.SpotTVShareHPUTBookViewModel Is Nothing OrElse (BroadcastResearchViewModel.SpotTVShareHPUTBookViewModel.SelectedShareHPUTBooks.Count = 0 AndAlso BroadcastResearchViewModel.SpotTVShareHPUTBookViewModel.UseLatest = False) Then

                ErrorMessage += vbCrLf & "At least one book must be selected."

            End If

            If BroadcastResearchViewModel.SpotTVSelectedDemographicList Is Nothing OrElse BroadcastResearchViewModel.SpotTVSelectedDemographicList.Count = 0 Then

                ErrorMessage += vbCrLf & "At least one demographic must be selected."

            ElseIf (BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.TrendByBook OrElse
                    BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.TrendByStation) AndAlso
                    BroadcastResearchViewModel.SpotTVSelectedDemographicList.Count > 1 Then

                ErrorMessage += vbCrLf & "Only one demographic can be selected for a trend report."

            ElseIf BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.Ranker AndAlso
                   BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore AndAlso
                   BroadcastResearchViewModel.SpotTVSelectedDemographicList.Count > 20 Then

                ErrorMessage += vbCrLf & "No more than 20 demographics can be selected for Comscore."

            End If

            If BroadcastResearchViewModel.SpotTVSelectedMetricList Is Nothing OrElse BroadcastResearchViewModel.SpotTVSelectedMetricList.Count = 0 Then

                ErrorMessage += vbCrLf & "At least one metric must be selected."

            End If

            If String.IsNullOrWhiteSpace(ErrorMessage) Then

                IsPresent = True

            End If

            RequiredSpotTVDataPresent = IsPresent

        End Function
        Private Function CheckCume(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                   ByRef ErrorMessage As String,
                                   ByRef InfoMessage As String) As Boolean

            'objects
            Dim IsOkay As Boolean = True
            Dim NielsenDaypartIDs As IEnumerable(Of Integer) = Nothing

            If BroadcastResearchViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.Ranker Then

                If BroadcastResearchViewModel.SelectedMetricList.Where(Function(Entity) Entity.Order = 1).FirstOrDefault.Description.ToUpper.StartsWith("CUME") Then

                    If (From Daypart In BroadcastResearchViewModel.NielsenDaypartList
                        Where Not BroadcastResearchViewModel.CumeNielsenPeriodIDs.Contains(Daypart.ID)
                        Select Daypart.ID).Any Then

                        IsOkay = False
                        ErrorMessage = _DaypartMessage
                    End If

                ElseIf BroadcastResearchViewModel.SelectedMetricList.Where(Function(Entity) Entity.Order = 1).FirstOrDefault.Description.ToUpper.StartsWith("EXCLUSIVE") Then

                    If (From Daypart In BroadcastResearchViewModel.NielsenDaypartList
                        Where Not BroadcastResearchViewModel.ExclusiveCumeNielsenPeriodIDs.Contains(Daypart.ID)
                        Select Daypart.ID).Any Then

                        IsOkay = False
                        ErrorMessage = _DaypartMessage

                    End If

                End If

            End If

            If BroadcastResearchViewModel.SelectedMetricList.Where(Function(Entity) Entity.Description.ToUpper.StartsWith("CUME")).Any Then

                If (From Daypart In BroadcastResearchViewModel.NielsenDaypartList
                    Where Not BroadcastResearchViewModel.CumeNielsenPeriodIDs.Contains(Daypart.ID)
                    Select Daypart.ID).Any Then

                    InfoMessage = _DaypartMessage

                End If

            End If

            If BroadcastResearchViewModel.SelectedMetricList.Where(Function(Entity) Entity.Description.ToUpper.StartsWith("EXCLUSIVE")).Any Then

                If (From Daypart In BroadcastResearchViewModel.NielsenDaypartList
                    Where Not BroadcastResearchViewModel.ExclusiveCumeNielsenPeriodIDs.Contains(Daypart.ID)
                    Select Daypart.ID).Any Then

                    InfoMessage = _DaypartMessage

                End If

            End If

            If BroadcastResearchViewModel.SelectedResearchCriteria.NielsenRadioQualitativeID <> 1 Then

                If (From Daypart In BroadcastResearchViewModel.NielsenDaypartList
                    Where Not BroadcastResearchViewModel.QualitativeNielsenPeriodIDs.Contains(Daypart.ID)
                    Select Daypart.ID).Any Then

                    InfoMessage = _DaypartMessage

                End If

            End If

            If BroadcastResearchViewModel.SelectedResearchCriteria.ListeningType = AdvantageFramework.Database.Entities.SpotRadioResearchListeningType.Work OrElse
                    BroadcastResearchViewModel.SelectedResearchCriteria.ListeningType = AdvantageFramework.Database.Entities.SpotRadioResearchListeningType.Car Then

                If (From Daypart In BroadcastResearchViewModel.NielsenDaypartList
                    Where Not BroadcastResearchViewModel.DiaryAtWorkInCarNielsenPeriodIDs.Contains(Daypart.ID)
                    Select Daypart.ID).Any Then

                    InfoMessage = _DaypartMessage

                End If

            End If

            If BroadcastResearchViewModel.SelectedResearchCriteria.ListeningType = AdvantageFramework.Database.Entities.SpotRadioResearchListeningType.Home OrElse
                    BroadcastResearchViewModel.SelectedResearchCriteria.ListeningType = AdvantageFramework.Database.Entities.SpotRadioResearchListeningType.OutOfHome Then

                If (From Daypart In BroadcastResearchViewModel.NielsenDaypartList
                    Where Not BroadcastResearchViewModel.PPMinHomeOutofHomeNielsenPeriodIDs.Contains(Daypart.ID)
                    Select Daypart.ID).Any Then

                    InfoMessage = _DaypartMessage

                End If

            End If

            CheckCume = IsOkay

        End Function
        Private Function RequiredSpotRadioDataPresent(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                      ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsPresent As Boolean = False

            ErrorMessage = String.Empty

            If BroadcastResearchViewModel.NielsenRadioBookList Is Nothing OrElse BroadcastResearchViewModel.NielsenRadioBookList.Count = 0 Then

                ErrorMessage += vbCrLf & "At least one book must be selected."

            ElseIf (BroadcastResearchViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.Ranker OrElse
                    BroadcastResearchViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.AudienceComposition) AndAlso
                    BroadcastResearchViewModel.NielsenRadioBookList.Count > 1 Then

                If BroadcastResearchViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.AudienceComposition Then

                    ErrorMessage += vbCrLf & "Only one set of books can be selected for an audience composition report."

                Else

                    ErrorMessage += vbCrLf & "Only one set of books can be selected for a ranker report."

                End If

            End If

            If BroadcastResearchViewModel.NielsenDaypartList Is Nothing OrElse BroadcastResearchViewModel.NielsenDaypartList.Count = 0 Then

                ErrorMessage += vbCrLf & "At least one day/time must be selected."

            ElseIf (BroadcastResearchViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.Trend OrElse
                    BroadcastResearchViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.AudienceComposition) AndAlso
                    BroadcastResearchViewModel.NielsenDaypartList.Count > 1 Then

                If BroadcastResearchViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.AudienceComposition Then

                    ErrorMessage += vbCrLf & "Only one daypart can be selected for an audience composition report."

                Else

                    ErrorMessage += vbCrLf & "Only one daypart can be selected for a trend report."

                End If

            End If

            If BroadcastResearchViewModel.SelectedMetricList Is Nothing OrElse BroadcastResearchViewModel.SelectedMetricList.Count = 0 Then

                ErrorMessage += vbCrLf & "At least one metric must be selected."

            End If

            If BroadcastResearchViewModel.SelectedStationList Is Nothing OrElse BroadcastResearchViewModel.SelectedStationList.Count = 0 Then

                ErrorMessage += vbCrLf & "At least one station must be selected."

            End If

            If String.IsNullOrWhiteSpace(ErrorMessage) Then

                IsPresent = True

            End If

            RequiredSpotRadioDataPresent = IsPresent

        End Function

#Region " Public "

		Public Sub New(Session As AdvantageFramework.Security.Session)

			MyBase.New(Session)

		End Sub

#Region " Spot TV "

        Public Sub AddToSelectedDemographics(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                             AvailableDemographicsSelected As IEnumerable(Of AdvantageFramework.DTO.Media.SpotTV.Demographic))

            If AvailableDemographicsSelected IsNot Nothing AndAlso AvailableDemographicsSelected.Count > 0 Then

                For Each Demographic In AvailableDemographicsSelected

                    BroadcastResearchViewModel.SpotTVSelectedDemographicList.Add(Demographic)
                    BroadcastResearchViewModel.SpotTVAvailableDemographicList.Remove(Demographic)

                Next

                BroadcastResearchViewModel.SpotTVIsDirty = True

            End If

        End Sub
        Public Sub RemoveFromSelectedDemographics(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                  SelectedDemographicSelected As IEnumerable(Of AdvantageFramework.DTO.Media.SpotTV.Demographic))

            If SelectedDemographicSelected IsNot Nothing AndAlso SelectedDemographicSelected.Count > 0 Then

                For Each Demographic In SelectedDemographicSelected

                    BroadcastResearchViewModel.SpotTVAvailableDemographicList.Add(Demographic)
                    BroadcastResearchViewModel.SpotTVSelectedDemographicList.Remove(Demographic)

                Next

                BroadcastResearchViewModel.SpotTVIsDirty = True

            End If

        End Sub
        Public Sub MoveDemographic(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                   Demographic As DTO.Media.SpotTV.Demographic, Direction As MoveItemDirection)

            'objects
            Dim OldIndex As Integer = -1

            OldIndex = BroadcastResearchViewModel.SpotTVSelectedDemographicList.IndexOf(Demographic)

            BroadcastResearchViewModel.SpotTVSelectedDemographicList.RemoveAt(OldIndex)

            If Direction = MoveItemDirection.Down Then

                BroadcastResearchViewModel.SpotTVSelectedDemographicList.Insert(OldIndex + 1, Demographic)

            Else

                BroadcastResearchViewModel.SpotTVSelectedDemographicList.Insert(OldIndex - 1, Demographic)

            End If

            BroadcastResearchViewModel.SpotTVIsDirty = True

        End Sub
        Public Sub MoveDaypart(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                               NielsenDaypart As DTO.Media.NielsenDaypart, Direction As MoveItemDirection)

            'objects
            Dim OldIndex As Integer = -1

            OldIndex = BroadcastResearchViewModel.NielsenDaypartList.IndexOf(NielsenDaypart)

            BroadcastResearchViewModel.NielsenDaypartList.RemoveAt(OldIndex)

            If Direction = MoveItemDirection.Down Then

                BroadcastResearchViewModel.NielsenDaypartList.Insert(OldIndex + 1, NielsenDaypart)

            Else

                BroadcastResearchViewModel.NielsenDaypartList.Insert(OldIndex - 1, NielsenDaypart)

            End If

            BroadcastResearchViewModel.SpotRadioIsDirty = True

        End Sub
        Public Sub AddToSelectedSpotTVMetrics(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                              AvailableMetricsSelected As IEnumerable(Of AdvantageFramework.DTO.Media.Metric))

            If AvailableMetricsSelected IsNot Nothing AndAlso AvailableMetricsSelected.Count > 0 Then

                For Each Metric In AvailableMetricsSelected

                    BroadcastResearchViewModel.SpotTVSelectedMetricList.Add(Metric)
                    BroadcastResearchViewModel.SpotTVAvailableMetricList.Remove(Metric)

                Next

                BroadcastResearchViewModel.SpotTVIsDirty = True

            End If

        End Sub
        Public Sub RemoveFromSelectedSpotTVMetrics(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                   SelectedMetricSelected As IEnumerable(Of AdvantageFramework.DTO.Media.Metric))

            If SelectedMetricSelected IsNot Nothing AndAlso SelectedMetricSelected.Count > 0 Then

                For Each Metric In SelectedMetricSelected

                    BroadcastResearchViewModel.SpotTVAvailableMetricList.Add(Metric)
                    BroadcastResearchViewModel.SpotTVSelectedMetricList.Remove(Metric)

                Next

                BroadcastResearchViewModel.SpotTVIsDirty = True

            End If

        End Sub
        Public Sub MoveMetricSpotTV(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                    Metric As DTO.Media.Metric, Direction As MoveItemDirection)

            'objects
            Dim OldIndex As Integer = -1

            OldIndex = BroadcastResearchViewModel.SpotTVSelectedMetricList.IndexOf(Metric)

            BroadcastResearchViewModel.SpotTVSelectedMetricList.RemoveAt(OldIndex)

            If Direction = MoveItemDirection.Down Then

                BroadcastResearchViewModel.SpotTVSelectedMetricList.Insert(OldIndex + 1, Metric)

            Else

                BroadcastResearchViewModel.SpotTVSelectedMetricList.Insert(OldIndex - 1, Metric)

            End If

            BroadcastResearchViewModel.SpotTVIsDirty = True

        End Sub
        Public Sub AddToSelectedSpotTVStations(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                               AvailableNielsenStationsSelected As IEnumerable(Of AdvantageFramework.DTO.Media.SpotTV.Station))

            If AvailableNielsenStationsSelected IsNot Nothing AndAlso AvailableNielsenStationsSelected.Count > 0 Then

                For Each NielsenStation In AvailableNielsenStationsSelected

                    BroadcastResearchViewModel.SpotTVSelectedNielsenStationList.Add(NielsenStation)
                    BroadcastResearchViewModel.SpotTVAvailableNielsenStationList.Remove(NielsenStation)

                Next

                BroadcastResearchViewModel.SpotTVIsDirty = True

            End If

        End Sub
        Public Sub RemoveFromSelectedSpotTVStations(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                    SelectedNielsenStationsSelected As IEnumerable(Of AdvantageFramework.DTO.Media.SpotTV.Station))

            If SelectedNielsenStationsSelected IsNot Nothing AndAlso SelectedNielsenStationsSelected.Count > 0 Then

                For Each NielsenStation In SelectedNielsenStationsSelected

                    BroadcastResearchViewModel.SpotTVAvailableNielsenStationList.Add(NielsenStation)
                    BroadcastResearchViewModel.SpotTVSelectedNielsenStationList.Remove(NielsenStation)

                Next

                BroadcastResearchViewModel.SpotTVIsDirty = True

            End If

        End Sub
        Public Function DeleteSpotTV(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ByRef ErrorMessage As String) As Boolean

            'objects 
            Dim Deleted As Boolean = True
            Dim MediaSpotTVResearch As AdvantageFramework.Database.Entities.MediaSpotTVResearch = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaSpotTVResearch = AdvantageFramework.Database.Procedures.MediaSpotTVResearch.LoadByID(DbContext, BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ID)

                If MediaSpotTVResearch IsNot Nothing Then

                    Deleted = AdvantageFramework.Database.Procedures.MediaSpotTVResearch.Delete(DbContext, MediaSpotTVResearch, ErrorMessage)

                End If

            End Using

            DeleteSpotTV = Deleted

        End Function
        Private Sub LoadTVMarketList(DbContext As AdvantageFramework.Database.DbContext, ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            'objects
            Dim NielsenMarketNumbers As IEnumerable(Of Integer) = Nothing
            Dim Markets As Generic.List(Of AdvantageFramework.Database.Entities.Market) = Nothing

            If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                    If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                        NielsenMarketNumbers = NielsenDbContext.Database.SqlQuery(Of Integer)(String.Format("EXEC advsp_hosted_spottv_get_market_numbers '{0}'", Session.NielsenClientCodeForHosted)).ToList

                    Else

                        NielsenMarketNumbers = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.LoadValidated(NielsenDbContext)
                                                Select Entity.NielsenMarketNumber).Distinct.ToArray

                    End If

                    BroadcastResearchViewModel.SpotTVMarketList = (From Entity In AdvantageFramework.Database.Procedures.Market.LoadAllActiveSpotTV(DbContext).Where(Function(Entity) NielsenMarketNumbers.Contains(CInt(Entity.NielsenTVCode))).ToList
                                                                   Select New AdvantageFramework.DTO.Market(Entity)).ToList

                End Using

            ElseIf BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                NielsenMarketNumbers = AdvantageFramework.Database.Procedures.ComscoreTVStation.LoadDistinctMarketNumbers(DbContext)

                Markets = AdvantageFramework.Database.Procedures.Market.LoadAllActiveComscore(DbContext, NielsenMarketNumbers).ToList

                BroadcastResearchViewModel.SpotTVMarketList = (From Entity In Markets
                                                               Select New AdvantageFramework.DTO.Market(Entity)).ToList

            End If

        End Sub
        Private Sub LoadTVStationList(DbContext As AdvantageFramework.Database.DbContext, ResearchID As Integer,
                                      ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            'objects
            Dim NielsenStationIDs As IEnumerable(Of Integer) = Nothing
            Dim SqlParameterNielsenMarketNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNielsenStationIDs As System.Data.SqlClient.SqlParameter = Nothing
            Dim StationList As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.Station) = Nothing

            If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.MarketNumber <> 0 Then

                NielsenStationIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotTVResearchStation.LoadByMediaSpotTVResearchID(DbContext, ResearchID).ToList
                                     Select Entity.NielsenStationID).ToArray

                If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                    Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                        SqlParameterNielsenMarketNumber = New System.Data.SqlClient.SqlParameter("@NIELSEN_MARKET_NUM", SqlDbType.Int)
                        SqlParameterNielsenMarketNumber.Value = BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.MarketNumber

                        SqlParameterNielsenStationIDs = New System.Data.SqlClient.SqlParameter("@NIELSEN_STATION_IDs", SqlDbType.VarChar)
                        SqlParameterNielsenStationIDs.Value = If(NielsenStationIDs Is Nothing, System.DBNull.Value, String.Join(",", NielsenStationIDs.ToArray))

                        StationList = NielsenDbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.SpotTV.Station)("exec dbo.advsp_media_spot_tv_stations @NIELSEN_MARKET_NUM, @NIELSEN_STATION_IDs",
                                                                                                                         SqlParameterNielsenMarketNumber, SqlParameterNielsenStationIDs).ToList

                    End Using

                ElseIf BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                    SqlParameterNielsenMarketNumber = New System.Data.SqlClient.SqlParameter("@PRIMARY_MARKET_NUMBER", SqlDbType.Int)
                    SqlParameterNielsenMarketNumber.Value = BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ComscoreNewMarketNumber

                    SqlParameterNielsenStationIDs = New System.Data.SqlClient.SqlParameter("@STATION_IDs", SqlDbType.VarChar)
                    SqlParameterNielsenStationIDs.Value = If(NielsenStationIDs Is Nothing, System.DBNull.Value, String.Join(",", NielsenStationIDs.ToArray))

                    StationList = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.SpotTV.Station)("exec dbo.advsp_comscore_stations @PRIMARY_MARKET_NUMBER, @STATION_IDs",
                                                                                                              SqlParameterNielsenMarketNumber, SqlParameterNielsenStationIDs).ToList

                End If

                If StationList IsNot Nothing AndAlso StationList.Count > 0 Then

                    BroadcastResearchViewModel.SpotTVAvailableNielsenStationList = StationList.Where(Function(Station) Station.IsSelected = False).ToList

                    BroadcastResearchViewModel.SpotTVSelectedNielsenStationList = StationList.Where(Function(Station) Station.IsSelected = True).ToList

                End If

            End If

        End Sub
        Private Sub LoadTVDemographicsList(DbContext As AdvantageFramework.Database.DbContext, ResearchID As Integer,
                                           ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            'objects
            Dim SelectedMediaDemoIDs As IEnumerable(Of Integer) = Nothing

            BroadcastResearchViewModel.SpotTVSelectedDemographicList = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotTVResearchDemo.LoadByMediaSpotTVResearchID(DbContext, ResearchID).Include("MediaDemographic").OrderBy(Function(Entity) Entity.Order).ToList
                                                                        Select New AdvantageFramework.DTO.Media.SpotTV.Demographic(Entity)).ToList

            SelectedMediaDemoIDs = (From Entity In BroadcastResearchViewModel.SpotTVSelectedDemographicList
                                    Select Entity.ID).ToArray

            If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                BroadcastResearchViewModel.SpotTVAvailableDemographicList = (From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.LoadActiveNielsenTV(DbContext).Where(Function(Entity) SelectedMediaDemoIDs.Contains(Entity.ID) = False).OrderBy(Function(Entity) Entity.Description).ToList
                                                                             Select New AdvantageFramework.DTO.Media.SpotTV.Demographic(Entity)).ToList

            ElseIf BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                BroadcastResearchViewModel.SpotTVAvailableDemographicList = (From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.LoadActiveComscoreTV(DbContext).Where(Function(Entity) SelectedMediaDemoIDs.Contains(Entity.ID) = False).OrderBy(Function(Entity) Entity.Description).ToList
                                                                             Select New AdvantageFramework.DTO.Media.SpotTV.Demographic(Entity)).OrderBy(Function(Entity) Entity.GroupSortOrder).ThenBy(Function(Entity) Entity.Group).ThenBy(Function(Entity) Entity.Category).ToList

            End If

        End Sub
        Private Sub LoadTVMetricsList(DbContext As AdvantageFramework.Database.DbContext, ResearchID As Integer,
                                      ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            'objects
            Dim SelectedMediaMetricIDs As IEnumerable(Of Integer) = Nothing

            If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                BroadcastResearchViewModel.SpotTVSelectedMetricList = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotTVResearchMetric.LoadByMediaSpotTVResearchID(DbContext, ResearchID).OrderBy(Function(Entity) Entity.Order).ToList
                                                                       Select New AdvantageFramework.DTO.Media.Metric(Entity)).ToList

                SelectedMediaMetricIDs = (From Entity In BroadcastResearchViewModel.SpotTVSelectedMetricList
                                          Select Entity.ID).ToArray

                BroadcastResearchViewModel.SpotTVAvailableMetricList = (From Entity In AdvantageFramework.Database.Procedures.MediaMetric.Load(DbContext).Where(Function(Entity) SelectedMediaMetricIDs.Contains(Entity.ID) = False AndAlso
                                                                                                                                                                                 Entity.Type = "T").ToList
                                                                        Select New AdvantageFramework.DTO.Media.Metric(Entity)).ToList

            ElseIf BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                BroadcastResearchViewModel.SpotTVSelectedMetricList = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotTVResearchMetric.LoadByMediaSpotTVResearchID(DbContext, ResearchID).OrderBy(Function(Entity) Entity.Order).ToList
                                                                       Select New AdvantageFramework.DTO.Media.Metric(Entity, True)).ToList

                SelectedMediaMetricIDs = (From Entity In BroadcastResearchViewModel.SpotTVSelectedMetricList
                                          Select Entity.ID).ToArray

                BroadcastResearchViewModel.SpotTVAvailableMetricList = (From Entity In AdvantageFramework.Database.Procedures.MediaMetric.Load(DbContext).Where(Function(Entity) SelectedMediaMetricIDs.Contains(Entity.ID) = False AndAlso
                                                                                                                                                                                 Entity.Type = "T" AndAlso
                                                                                                                                                                                 Entity.ID <> AdvantageFramework.Database.Entities.MediaMetricID.Intab).ToList
                                                                        Select New AdvantageFramework.DTO.Media.Metric(Entity, True)).ToList

            End If

        End Sub
        Public Function LoadSpotTV(ResearchID As Nullable(Of Integer)) As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel

            'objects
            Dim BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel = Nothing
            Dim Dashboard As AdvantageFramework.Database.Entities.Dashboard = Nothing

            BroadcastResearchViewModel = New AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel

            BroadcastResearchViewModel.SelectedResearchTab = ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTV

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If Session.IsNielsenSetup OrElse Session.IsComscoreSetup Then

                    BroadcastResearchViewModel.SpotTVAddEnabled = True

                End If

                BroadcastResearchViewModel.SpotTVResearchCriteriaList = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotTVResearch.Load(DbContext).Include("Market").ToList
                                                                         Select New AdvantageFramework.DTO.Media.SpotTV.ResearchCriteria(Entity)).ToList

                If Not Session.IsNielsenSetup AndAlso (From Entity In BroadcastResearchViewModel.SpotTVResearchCriteriaList
                                                       Where Entity.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen).Any Then

                    BroadcastResearchViewModel.SpotTVResearchCriteriaList = BroadcastResearchViewModel.SpotTVResearchCriteriaList.Where(Function(E) E.RatingsServiceID <> AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen).ToList
                    BroadcastResearchViewModel.MissingIntegrationSettingsMessage = "Nielsen and/or Comscore reports are not shown due to insufficient credentials.  Please check integration settings."

                End If

                If Not Session.IsComscoreSetup AndAlso (From Entity In BroadcastResearchViewModel.SpotTVResearchCriteriaList
                                                        Where Entity.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore).Any Then

                    BroadcastResearchViewModel.SpotTVResearchCriteriaList = BroadcastResearchViewModel.SpotTVResearchCriteriaList.Where(Function(E) E.RatingsServiceID <> AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore).ToList
                    BroadcastResearchViewModel.MissingIntegrationSettingsMessage = "Nielsen and/or Comscore reports are not shown due to insufficient credentials.  Please check integration settings."

                End If

                If ResearchID.HasValue Then

                    BroadcastResearchViewModel.SpotTVSelectedResearchCriteria = BroadcastResearchViewModel.SpotTVResearchCriteriaList.Where(Function(Entity) Entity.ID = ResearchID.Value).SingleOrDefault

                    LoadTVMarketList(DbContext, BroadcastResearchViewModel)

                    LoadTVStationList(DbContext, ResearchID.Value, BroadcastResearchViewModel)

                    LoadTVDemographicsList(DbContext, ResearchID.Value, BroadcastResearchViewModel)

                    LoadTVMetricsList(DbContext, ResearchID.Value, BroadcastResearchViewModel)

                    BroadcastResearchViewModel.SpotTVDayTimeList = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotTVResearchDayTime.LoadByMediaSpotTVResearchID(DbContext, ResearchID.Value).ToList
                                                                    Select New AdvantageFramework.DTO.DaysAndTime(AdvantageFramework.DTO.DaysAndTime.BroadcastTypes.TV, Entity)).ToList

                Else

                    BroadcastResearchViewModel.SpotTVSelectedResearchCriteria = Nothing

                End If

                BroadcastResearchViewModel.SpotTVSourceList = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID))
                                                               Where (Entity.Code = CStr(AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen) AndAlso Me.Session.IsNielsenSetup) OrElse
                                                                        (Entity.Code = CStr(AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore) AndAlso Me.Session.IsComscoreSetup)
                                                               Select New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

                BroadcastResearchViewModel.SpotTVResearchReportTypeList = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.SpotTVResearchReportType))
                                                                           Select New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

                Dashboard = AdvantageFramework.Database.Procedures.Dashboard.LoadByDashboardType(DbContext, AdvantageFramework.Database.Entities.DashboardTypes.BroadcastResearchTool_TV)

                If Dashboard IsNot Nothing Then

                    BroadcastResearchViewModel.Dashboard = New AdvantageFramework.DTO.Dashboard(Dashboard)

                Else

                    BroadcastResearchViewModel.Dashboard = New AdvantageFramework.DTO.Dashboard

                End If

            End Using

            BroadcastResearchViewModel.SpotTVReportDataTable = Nothing

            LoadSpotTV = BroadcastResearchViewModel

        End Function
        Public Sub SaveTVDashboard(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, DashboardLayout() As Byte)

			'objects
			Dim Dashboard As AdvantageFramework.Database.Entities.Dashboard = Nothing

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				Dashboard = AdvantageFramework.Database.Procedures.Dashboard.LoadByDashboardType(DbContext, AdvantageFramework.Database.Entities.DashboardTypes.BroadcastResearchTool_TV)

				If Dashboard IsNot Nothing Then

					Dashboard.Layout = DashboardLayout

					AdvantageFramework.Database.Procedures.Dashboard.Update(DbContext, Dashboard)

				Else

					Dashboard = New AdvantageFramework.Database.Entities.Dashboard

					Dashboard.DbContext = DbContext
					Dashboard.Type = AdvantageFramework.Database.Entities.DashboardTypes.BroadcastResearchTool_TV
					Dashboard.Layout = DashboardLayout

					AdvantageFramework.Database.Procedures.Dashboard.Insert(DbContext, Dashboard)

				End If

			End Using

			BroadcastResearchViewModel.Dashboard.Layout = DashboardLayout

		End Sub
		Public Function RunSpotTVReport(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                        ByRef ErrorMessage As String,
                                        ByRef InfoMessage As String)

            'objects
            Dim ResearchID As Integer = Nothing
            Dim MediaSpotTVResearchDaytimeTypes As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MediaSpotTVResearchDaytimeType) = Nothing
            Dim SqlParameterMediaSpotTVResearchDaytimeType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaDemoType As System.Data.SqlClient.SqlParameter = Nothing
            Dim MediaDemographicIDs As IEnumerable(Of Integer) = Nothing
            Dim SqlParameterMediaDemoDetailType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaSpotTVResearchDemoType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaSpotTVResearchBookType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaSpotTVResearchType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNielsenMarketNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMarketDescription As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStationCodes As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterHostedClientCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim NielsenStationIDs As Generic.List(Of Integer) = Nothing
            Dim MediaSpotTVResearchMetricList As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpotTVResearchMetric) = Nothing
            Dim Success As Boolean = False
            Dim CallLettersList As Generic.List(Of String) = Nothing
            Dim DemographicStreams As Integer = 0
            Dim StationDemographicStreamCount As Dictionary(Of Integer, Integer) = Nothing
            Dim DaytimeIDBooks As Integer = 0
            Dim StationDaytimeIDBookCount As Dictionary(Of Integer, Integer) = Nothing

            If RequiredSpotTVDataPresent(BroadcastResearchViewModel, ErrorMessage) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                        ResearchID = BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ID.Value

                        MediaSpotTVResearchDaytimeTypes = New Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MediaSpotTVResearchDaytimeType)

                        MediaSpotTVResearchDaytimeTypes.AddRange(From Entity In AdvantageFramework.Database.Procedures.MediaSpotTVResearchDayTime.LoadByMediaSpotTVResearchID(DbContext, ResearchID).ToList
                                                                 Select New AdvantageFramework.Classes.Media.Nielsen.MediaSpotTVResearchDaytimeType(Entity))

                        SqlParameterMediaSpotTVResearchDaytimeType = New System.Data.SqlClient.SqlParameter("@MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE", SqlDbType.Structured)
                        SqlParameterMediaSpotTVResearchDaytimeType.TypeName = "MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE"
                        SqlParameterMediaSpotTVResearchDaytimeType.Value = AdvantageFramework.Database.ToDataTable(MediaSpotTVResearchDaytimeTypes)

                        SqlParameterMediaDemoType = New System.Data.SqlClient.SqlParameter("@MEDIA_DEMO_TYPE", SqlDbType.Structured)
                        SqlParameterMediaDemoType.TypeName = "MEDIA_DEMO_TYPE"
                        SqlParameterMediaDemoType.Value = AdvantageFramework.Database.ToDataTable((From Entity In AdvantageFramework.Database.Procedures.MediaSpotTVResearchDemo.LoadByMediaSpotTVResearchID(DbContext, ResearchID)
                                                                                                   Select Entity.MediaDemographic.ID,
                                                                                                          Entity.MediaDemographic.Description).ToList)

                        MediaDemographicIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotTVResearchDemo.LoadByMediaSpotTVResearchID(DbContext, ResearchID)
                                               Select Entity.MediaDemoID).Distinct.ToArray

                        SqlParameterMediaDemoDetailType = New System.Data.SqlClient.SqlParameter("@MEDIA_DEMO_DETAIL_TYPE", SqlDbType.Structured)
                        SqlParameterMediaDemoDetailType.TypeName = "MEDIA_DEMO_DETAIL_TYPE"
                        SqlParameterMediaDemoDetailType.Value = AdvantageFramework.Database.ToDataTable((From Entity In AdvantageFramework.Database.Procedures.MediaDemographicDetail.Load(DbContext)
                                                                                                         Where MediaDemographicIDs.Contains(Entity.MediaDemographicID)
                                                                                                         Select Entity.MediaDemographicID,
                                                                                                                Entity.NielsenDemographicID).ToList)

                        SqlParameterMediaSpotTVResearchDemoType = New System.Data.SqlClient.SqlParameter("@MEDIA_SPOT_TV_RESEARCH_DEMO_TYPE", SqlDbType.Structured)
                        SqlParameterMediaSpotTVResearchDemoType.TypeName = "MEDIA_SPOT_TV_RESEARCH_DEMO_TYPE"
                        SqlParameterMediaSpotTVResearchDemoType.Value = AdvantageFramework.Database.ToDataTable((From Entity In AdvantageFramework.Database.Procedures.MediaSpotTVResearchDemo.LoadByMediaSpotTVResearchID(DbContext, ResearchID)
                                                                                                                 Select Entity.MediaDemoID,
                                                                                                                        Entity.Order).ToList)

                        SqlParameterMediaSpotTVResearchBookType = New System.Data.SqlClient.SqlParameter("@MEDIA_SPOT_TV_RESEARCH_BOOK_TYPE", SqlDbType.Structured)
                        SqlParameterMediaSpotTVResearchBookType.TypeName = "MEDIA_SPOT_TV_RESEARCH_BOOK_TYPE"
                        SqlParameterMediaSpotTVResearchBookType.Value = AdvantageFramework.Database.ToDataTable((From Entity In AdvantageFramework.Database.Procedures.MediaSpotTVResearchBook.LoadByMediaSpotTVResearchID(DbContext, ResearchID)
                                                                                                                 Select Entity.ID,
                                                                                                                        Entity.UseLatest,
                                                                                                                        Entity.LatestStream,
                                                                                                                        Entity.ShareBookID,
                                                                                                                        Entity.HPUTBookID).ToList)

                        SqlParameterMediaSpotTVResearchType = New System.Data.SqlClient.SqlParameter("@MEDIA_SPOT_TV_RESEARCH_TYPE", SqlDbType.Structured)
                        SqlParameterMediaSpotTVResearchType.TypeName = "MEDIA_SPOT_TV_RESEARCH_TYPE"
                        SqlParameterMediaSpotTVResearchType.Value = AdvantageFramework.Database.ToDataTable((From Entity In AdvantageFramework.Database.Procedures.MediaSpotTVResearch.Load(DbContext)
                                                                                                             Where Entity.ID = ResearchID
                                                                                                             Select Entity.ReportType,
                                                                                                                    Entity.DominantProgramming,
                                                                                                                    Entity.ShowProgramName,
                                                                                                                    Entity.ShowSpill).ToList)

                        SqlParameterNielsenMarketNumber = New System.Data.SqlClient.SqlParameter("@NIELSEN_MARKET_NUM", SqlDbType.Int)
                        SqlParameterNielsenMarketNumber.Value = BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.MarketNumber

                        SqlParameterMarketDescription = New System.Data.SqlClient.SqlParameter("@MARKET_DESCRIPTION", SqlDbType.VarChar)
                        SqlParameterMarketDescription.Value = AdvantageFramework.Database.Procedures.MediaSpotTVResearch.LoadByID(DbContext, ResearchID).Market.Description

                        SqlParameterStationCodes = New System.Data.SqlClient.SqlParameter("@STATION_IDs", SqlDbType.VarChar)

                        NielsenStationIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotTVResearchStation.LoadByMediaSpotTVResearchID(DbContext, ResearchID).ToList
                                             Select Entity.NielsenStationID).ToList

                        SqlParameterStationCodes.Value = String.Join(",", NielsenStationIDs.ToArray)

                        SqlParameterHostedClientCode = New System.Data.SqlClient.SqlParameter("@HOSTED_CLIENT_CODE", SqlDbType.VarChar)

                        If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                            SqlParameterHostedClientCode.Value = Session.NielsenClientCodeForHosted

                        Else

                            SqlParameterHostedClientCode.Value = System.DBNull.Value

                        End If

                        Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                            BroadcastResearchViewModel.SpotTVResearchResultList = NielsenDbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.SpotTV.ResearchResult)("EXEC advsp_nielsen_spot_tv_research_results_v2 @MEDIA_SPOT_TV_RESEARCH_DAYTIME_TYPE, @MEDIA_DEMO_TYPE, @MEDIA_DEMO_DETAIL_TYPE, @MEDIA_SPOT_TV_RESEARCH_DEMO_TYPE, @MEDIA_SPOT_TV_RESEARCH_BOOK_TYPE, @MEDIA_SPOT_TV_RESEARCH_TYPE, @NIELSEN_MARKET_NUM, @MARKET_DESCRIPTION, @STATION_IDs, @HOSTED_CLIENT_CODE",
                            SqlParameterMediaSpotTVResearchDaytimeType, SqlParameterMediaDemoType, SqlParameterMediaDemoDetailType, SqlParameterMediaSpotTVResearchDemoType, SqlParameterMediaSpotTVResearchBookType,
                            SqlParameterMediaSpotTVResearchType, SqlParameterNielsenMarketNumber, SqlParameterMarketDescription, SqlParameterStationCodes, SqlParameterHostedClientCode).ToList()

                            If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.Ranker Then

                                DemographicStreams = BroadcastResearchViewModel.SpotTVResearchResultList.Select(Function(Result) Result.DemographicStream).Distinct.Count

                                If AdvantageFramework.Database.Procedures.MediaSpotTVResearchBook.LoadByMediaSpotTVResearchID(DbContext, ResearchID).Count > DemographicStreams Then

                                    DemographicStreams = AdvantageFramework.Database.Procedures.MediaSpotTVResearchBook.LoadByMediaSpotTVResearchID(DbContext, ResearchID).Count

                                End If

                                StationDemographicStreamCount = (From Entity In (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                                 Select Entity.NielsenTVStationID, Entity.DemographicStream).Distinct.ToList
                                                                 Group By Entity.NielsenTVStationID Into Group
                                                                 Select New With {.NielsenTVStationID = NielsenTVStationID,
                                                                                  .Count = Group.Count}).ToDictionary(Function(E) E.NielsenTVStationID, Function(E) E.Count)

                                For Each KeyPair In StationDemographicStreamCount

                                    If KeyPair.Value = DemographicStreams Then

                                        NielsenStationIDs.Remove(KeyPair.Key)

                                    End If

                                Next

                            ElseIf (BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.TrendByBook OrElse
                                    BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.TrendByStation) Then

                                DaytimeIDBooks = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                  Select Entity.DaytimeID, Entity.Books).Distinct.Count

                                If AdvantageFramework.Database.Procedures.MediaSpotTVResearchBook.LoadByMediaSpotTVResearchID(DbContext, ResearchID).Count > DaytimeIDBooks Then

                                    DaytimeIDBooks = AdvantageFramework.Database.Procedures.MediaSpotTVResearchBook.LoadByMediaSpotTVResearchID(DbContext, ResearchID).Count

                                End If

                                StationDaytimeIDBookCount = (From Entity In (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                                                                             Select Entity.NielsenTVStationID, Entity.DaytimeID, Entity.Books).Distinct.ToList
                                                             Group By Entity.NielsenTVStationID Into Group
                                                             Select New With {.NielsenTVStationID = NielsenTVStationID,
                                                                              .Count = Group.Count}).ToDictionary(Function(E) E.NielsenTVStationID, Function(E) E.Count)

                                For Each KeyPair In StationDaytimeIDBookCount

                                    If KeyPair.Value = DaytimeIDBooks Then

                                        NielsenStationIDs.Remove(KeyPair.Key)

                                    End If

                                Next

                            End If

                            If NielsenStationIDs.Count > 0 Then

                                CallLettersList = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVStation.Load(NielsenDbContext)
                                                   Where NielsenStationIDs.Contains(Entity.ID)
                                                   Select Entity.CallLetters).ToList

                                InfoMessage = "The following " & CallLettersList.Count & " station(s) do not have data for all criteria selected: " & vbCrLf & String.Join(", ", CallLettersList.ToArray)

                            End If

                        End Using

                    ElseIf BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                        BroadcastResearchViewModel.SpotTVResearchResultList = AdvantageFramework.ComScore.GetLocalTimeViews(DbContext, BroadcastResearchViewModel)

                        If BroadcastResearchViewModel.SpotTVResearchResultList.Count = 0 Then

                            If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria IsNot Nothing Then

                                InfoMessage = "No data found for market: " & BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.MarketCode & ".  Please call customer support and verify your Comscore subscription includes this market and the books selected."

                            Else

                                InfoMessage = "No data found for selected market.  Please call customer support and verify your Comscore subscription includes this market and the books selected."

                            End If

                        End If

                    End If

                    MediaSpotTVResearchMetricList = AdvantageFramework.Database.Procedures.MediaSpotTVResearchMetric.LoadByMediaSpotTVResearchID(DbContext, BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ID).ToList

                    If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.Ranker Then

                        BroadcastResearchViewModel.SpotTVReportDataTable = CreateSpotTVRankerReportDataTable(BroadcastResearchViewModel, MediaSpotTVResearchMetricList)

                    ElseIf BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.TrendByBook Then

                        BroadcastResearchViewModel.SpotTVReportDataTable = CreateSpotTVTrendByBookReportDataTable(BroadcastResearchViewModel, MediaSpotTVResearchMetricList)

                    ElseIf BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.TrendByStation Then

                        BroadcastResearchViewModel.SpotTVReportDataTable = CreateSpotTVTrendByStationReportDataTable(BroadcastResearchViewModel, MediaSpotTVResearchMetricList)

                    End If

                    Success = True

                End Using

            End If

            RunSpotTVReport = Success

        End Function
        Public Function SaveSpotTV(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim MediaSpotTVResearch As AdvantageFramework.Database.Entities.MediaSpotTVResearch = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MediaSpotTVResearchStation As AdvantageFramework.Database.Entities.MediaSpotTVResearchStation = Nothing
            Dim MediaSpotTVResearchDayTime As AdvantageFramework.Database.Entities.MediaSpotTVResearchDayTime = Nothing
            Dim MediaSpotTVResearchDemo As AdvantageFramework.Database.Entities.MediaSpotTVResearchDemo = Nothing
            Dim MediaSpotTVResearchMetric As AdvantageFramework.Database.Entities.MediaSpotTVResearchMetric = Nothing
            Dim ShareHPUTBookController As AdvantageFramework.Controller.Media.ShareHPUTBookController = Nothing
            Dim Order As Integer = 0
            Dim Saved As Boolean = False
            Dim DaysAndTimeController As AdvantageFramework.Controller.DaysAndTimeController = Nothing

            If RequiredSpotTVDataPresent(BroadcastResearchViewModel, ErrorMessage) Then

                DaysAndTimeController = New AdvantageFramework.Controller.DaysAndTimeController(Me.Session)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    MediaSpotTVResearch = AdvantageFramework.Database.Procedures.MediaSpotTVResearch.LoadByID(DbContext, BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ID)

                    If MediaSpotTVResearch IsNot Nothing Then

                        BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.SaveToEntity(MediaSpotTVResearch)

                        Try

                            DbContext.Database.Connection.Open()

                            DbTransaction = DbContext.Database.BeginTransaction

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_TV_RESEARCH_DEMO WHERE MEDIA_SPOT_TV_RESEARCH_ID = {0}", MediaSpotTVResearch.ID))
                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_TV_RESEARCH_METRIC WHERE MEDIA_SPOT_TV_RESEARCH_ID = {0}", MediaSpotTVResearch.ID))
                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_TV_RESEARCH_STATION WHERE MEDIA_SPOT_TV_RESEARCH_ID = {0}", MediaSpotTVResearch.ID))
                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_TV_RESEARCH_DAYTIME WHERE MEDIA_SPOT_TV_RESEARCH_ID = {0}", MediaSpotTVResearch.ID))

                            For Each Station In BroadcastResearchViewModel.SpotTVSelectedNielsenStationList

                                MediaSpotTVResearchStation = New AdvantageFramework.Database.Entities.MediaSpotTVResearchStation
                                MediaSpotTVResearchStation.DbContext = DbContext

                                MediaSpotTVResearchStation.MediaSpotTVResearchID = MediaSpotTVResearch.ID
                                MediaSpotTVResearchStation.NielsenStationID = Station.ID

                                DbContext.MediaSpotTVResearchStations.Add(MediaSpotTVResearchStation)

                            Next

                            For Each DaysAndTime In BroadcastResearchViewModel.SpotTVDayTimeList

                                MediaSpotTVResearchDayTime = New AdvantageFramework.Database.Entities.MediaSpotTVResearchDayTime
                                MediaSpotTVResearchDayTime.DbContext = DbContext

                                DaysAndTimeController.ParseDays(DaysAndTime, DaysAndTime.Days, True)
                                DaysAndTime.SaveToEntity(MediaSpotTVResearchDayTime)

                                MediaSpotTVResearchDayTime.MediaSpotTVResearchID = MediaSpotTVResearch.ID

                                DbContext.MediaSpotTVResearchDayTimes.Add(MediaSpotTVResearchDayTime)

                            Next

                            Order = 1

                            For Each Demographic In BroadcastResearchViewModel.SpotTVSelectedDemographicList

                                MediaSpotTVResearchDemo = New AdvantageFramework.Database.Entities.MediaSpotTVResearchDemo
                                MediaSpotTVResearchDemo.DbContext = DbContext

                                MediaSpotTVResearchDemo.MediaSpotTVResearchID = MediaSpotTVResearch.ID
                                MediaSpotTVResearchDemo.Order = Order
                                MediaSpotTVResearchDemo.MediaDemoID = Demographic.ID

                                DbContext.MediaSpotTVResearchDemos.Add(MediaSpotTVResearchDemo)

                                Order += 1

                            Next

                            Order = 1

                            For Each Metric In BroadcastResearchViewModel.SpotTVSelectedMetricList

                                MediaSpotTVResearchMetric = New AdvantageFramework.Database.Entities.MediaSpotTVResearchMetric
                                MediaSpotTVResearchMetric.DbContext = DbContext

                                MediaSpotTVResearchMetric.MediaSpotTVResearchID = MediaSpotTVResearch.ID
                                MediaSpotTVResearchMetric.Order = Order
                                MediaSpotTVResearchMetric.MediaMetricID = Metric.ID

                                DbContext.MediaSpotTVResearchMetrics.Add(MediaSpotTVResearchMetric)

                                Order += 1

                            Next

                            DbContext.SaveChanges()

                            ShareHPUTBookController = New AdvantageFramework.Controller.Media.ShareHPUTBookController(Me.Session)

                            If ShareHPUTBookController.Save(DbContext, BroadcastResearchViewModel.SpotTVShareHPUTBookViewModel, MediaSpotTVResearch.ID, ErrorMessage) = False Then

                                Throw New Exception(ErrorMessage)

                            End If

                            If AdvantageFramework.Database.Procedures.MediaSpotTVResearch.Update(DbContext, MediaSpotTVResearch, ErrorMessage) = False Then

                                Throw New Exception(ErrorMessage)

                            End If

                            DbTransaction.Commit()

                            Saved = True

                            BroadcastResearchViewModel.SpotTVIsDirty = False
                            BroadcastResearchViewModel.SpotTVResearchResultList = Nothing
                            BroadcastResearchViewModel.SpotTVReportDataTable = Nothing

                        Catch ex As Exception
                            ErrorMessage = ex.Message
                        Finally

                            If DbContext.Database.Connection.State = ConnectionState.Open Then

                                DbContext.Database.Connection.Close()

                            End If

                        End Try

                    Else

                        ErrorMessage = "This research criteria Is no longer valid In the system."

                    End If

                End Using

            End If

            SaveSpotTV = Saved

        End Function
        Public Sub SetTVAvailableStationsDemographicsMetrics(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, MarketCode As String)

            'objects
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, MarketCode)

                If Market IsNot Nothing Then

                    BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.MarketCode = MarketCode
                    BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.MarketDescription = Market.Description

                    BroadcastResearchViewModel.SpotTVSelectedNielsenStationList.Clear()

                    If BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen AndAlso Not String.IsNullOrWhiteSpace(Market.NielsenTVCode) Then

                        If Session.IsNielsenSetup Then

                            Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                                BroadcastResearchViewModel.SpotTVAvailableNielsenStationList = NielsenDbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.SpotTV.Station)(String.Format("exec [advsp_media_spot_tv_stations] {0}, NULL", CInt(Market.NielsenTVCode))).ToList

                            End Using

                        End If

                        BroadcastResearchViewModel.SpotTVAvailableDemographicList = (From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.LoadActiveNielsenTV(DbContext).OrderBy(Function(Entity) Entity.Description).ToList
                                                                                     Select New AdvantageFramework.DTO.Media.SpotTV.Demographic(Entity)).ToList

                        If BroadcastResearchViewModel.SpotTVAvailableMetricList.Where(Function(E) E.ID = AdvantageFramework.Database.Entities.TVMediaMetrics.Intab).Any = False Then

                            BroadcastResearchViewModel.SpotTVAvailableMetricList.Add(New AdvantageFramework.DTO.Media.Metric(AdvantageFramework.Database.Entities.TVMediaMetrics.Intab, AdvantageFramework.Database.Entities.TVMediaMetrics.Intab.ToString))

                        End If

                    ElseIf BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore AndAlso Market.ComscoreNewMarketNumber.HasValue Then

                        BroadcastResearchViewModel.SpotTVAvailableNielsenStationList = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.SpotTV.Station)(String.Format("exec [advsp_comscore_stations] {0}, NULL", Market.ComscoreNewMarketNumber.Value)).ToList

                        BroadcastResearchViewModel.SpotTVAvailableDemographicList = (From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.LoadActiveComscoreTV(DbContext).OrderBy(Function(Entity) Entity.Description).ToList
                                                                                     Select New AdvantageFramework.DTO.Media.SpotTV.Demographic(Entity)).ToList

                        If BroadcastResearchViewModel.SpotTVAvailableMetricList.Where(Function(E) E.ID = AdvantageFramework.Database.Entities.TVMediaMetrics.Intab).Any Then

                            BroadcastResearchViewModel.SpotTVAvailableMetricList.Remove(BroadcastResearchViewModel.SpotTVAvailableMetricList.Where(Function(E) E.ID = AdvantageFramework.Database.Entities.TVMediaMetrics.Intab).Single)

                        End If

                        If BroadcastResearchViewModel.SpotTVSelectedMetricList.Where(Function(E) E.ID = AdvantageFramework.Database.Entities.TVMediaMetrics.Intab).Any Then

                            BroadcastResearchViewModel.SpotTVSelectedMetricList.Remove(BroadcastResearchViewModel.SpotTVSelectedMetricList.Where(Function(E) E.ID = AdvantageFramework.Database.Entities.TVMediaMetrics.Intab).Single)

                        End If

                    End If

                    BroadcastResearchViewModel.SpotTVIsDirty = True

                End If

            End Using

        End Sub
        Public Sub ShareHPUTBooksChanged(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            BroadcastResearchViewModel.SpotTVIsDirty = True

        End Sub
        Public Sub SetDominantProgramming(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, Checked As Boolean)

            BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.DominantProgramming = Checked

            BroadcastResearchViewModel.SpotTVIsDirty = True

        End Sub
        Public Sub SetGroupByDaysTimesSpotTV(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, Checked As Boolean)

            BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.GroupByDaysTimes = Checked

            BroadcastResearchViewModel.SpotTVIsDirty = True

        End Sub
        Public Sub SetShowProgramName(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, Checked As Boolean)

            BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ShowProgramName = Checked

            BroadcastResearchViewModel.SpotTVIsDirty = True

        End Sub
        Public Sub SetShowSpillSpotTV(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, Checked As Boolean)

            BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ShowSpill = Checked

            BroadcastResearchViewModel.SpotTVIsDirty = True

        End Sub
        Public Sub SetTVSource(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, RatingsServiceID As Integer)

            'objects
            Dim MarketCode As String = Nothing
            Dim Market As AdvantageFramework.DTO.Market = Nothing

            BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = RatingsServiceID

            If RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ShowProgramName = False
                BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ShowSpill = False

            End If

            If Not String.IsNullOrWhiteSpace(BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.MarketCode) Then

                MarketCode = BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.MarketCode

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadTVMarketList(DbContext, BroadcastResearchViewModel)

                LoadTVMetricsList(DbContext, BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ID, BroadcastResearchViewModel)

            End Using

            If Not String.IsNullOrWhiteSpace(MarketCode) Then

                Market = (From Entity In BroadcastResearchViewModel.SpotTVMarketList
                          Where Entity.Code = MarketCode
                          Select Entity).SingleOrDefault

                If Market IsNot Nothing AndAlso Market.ComscoreNewMarketNumber.HasValue AndAlso RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                    BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.MarketCode = MarketCode
                    BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.MarketDescription = Market.Description
                    BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.MarketNumber = Market.ComscoreMarketNumber
                    BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ComscoreNewMarketNumber = Market.ComscoreNewMarketNumber

                    SetTVAvailableStationsDemographicsMetrics(BroadcastResearchViewModel, MarketCode)

                    BroadcastResearchViewModel.SpotTVSelectedNielsenStationList.Clear()
                    BroadcastResearchViewModel.SpotTVSelectedDemographicList.Clear()

                ElseIf Market IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Market.NielsenTVCode) AndAlso RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                    BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.MarketCode = MarketCode
                    BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.MarketDescription = Market.Description
                    BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.MarketNumber = CInt(Market.NielsenTVCode)

                    SetTVAvailableStationsDemographicsMetrics(BroadcastResearchViewModel, MarketCode)

                    BroadcastResearchViewModel.SpotTVSelectedNielsenStationList.Clear()
                    BroadcastResearchViewModel.SpotTVSelectedDemographicList.Clear()

                Else

                    BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.MarketCode = Nothing
                    BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.MarketDescription = Nothing
                    BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.MarketNumber = 0

                    BroadcastResearchViewModel.SpotTVAvailableNielsenStationList.Clear()
                    BroadcastResearchViewModel.SpotTVSelectedNielsenStationList.Clear()

                End If

            End If

            BroadcastResearchViewModel.SpotTVIsDirty = True

        End Sub
        Public Sub SetReportType(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ReportType As Short)

            BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.ReportType = ReportType

            BroadcastResearchViewModel.SpotTVIsDirty = True

        End Sub
        Public Sub SetSelectedSpotTVResearchCriteria(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ID As Integer)

            BroadcastResearchViewModel.SpotTVSelectedResearchCriteria = BroadcastResearchViewModel.SpotTVResearchCriteriaList.Where(Function(Entity) Entity.ID = ID).SingleOrDefault

        End Sub
        Public Sub DeleteSelectedDayTimes(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                          SelectedDayTimes As Generic.List(Of DTO.DaysAndTime))

            If SelectedDayTimes IsNot Nothing AndAlso SelectedDayTimes.Count > 0 Then

                For Each SelectedDayTime In SelectedDayTimes

                    BroadcastResearchViewModel.SpotTVDayTimeList.Remove(SelectedDayTime)

                Next

                BroadcastResearchViewModel.SpotTVIsDirty = True

            End If

        End Sub
        Public Sub DayTimeCancelNewItemRow(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            BroadcastResearchViewModel.SpotTVDayTimeIsNewRow = False
            BroadcastResearchViewModel.SpotTVDayTimeCancelEnabled = False
            BroadcastResearchViewModel.SpotTVDayTimeDeleteEnabled = BroadcastResearchViewModel.SpotTVDayTimeList IsNot Nothing AndAlso BroadcastResearchViewModel.SpotTVDayTimeList.Count > 0

        End Sub
        Public Sub DayTimeSelectionChanged(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                           IsNewItemRow As Boolean,
                                           SelectedDayTimes As Generic.List(Of AdvantageFramework.DTO.DaysAndTime))

            BroadcastResearchViewModel.SpotTVDayTimeIsNewRow = IsNewItemRow
            BroadcastResearchViewModel.SpotTVDayTimeCancelEnabled = IsNewItemRow
            BroadcastResearchViewModel.SpotTVDayTimeDeleteEnabled = Not IsNewItemRow

            BroadcastResearchViewModel.SpotTVSelectedDayTimes = SelectedDayTimes

        End Sub
        Public Sub DayTimeAddNewRowEvent(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            BroadcastResearchViewModel.SpotTVIsDirty = True

        End Sub
        Public Sub DayTimeCellChanged(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            BroadcastResearchViewModel.SpotTVIsDirty = True

        End Sub
        Public Sub DayTimeInitNewRowEvent(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            BroadcastResearchViewModel.SpotTVDayTimeIsNewRow = True
            BroadcastResearchViewModel.SpotTVDayTimeCancelEnabled = True
            BroadcastResearchViewModel.SpotTVDayTimeDeleteEnabled = False

        End Sub
        Public Function DayTimeValidateEntity(DaysAndTime As AdvantageFramework.DTO.DaysAndTime, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim DaysAndTimeController As AdvantageFramework.Controller.DaysAndTimeController = Nothing

            DaysAndTimeController = New AdvantageFramework.Controller.DaysAndTimeController(Me.Session)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = DaysAndTimeController.ValidateEntity(DbContext, DataContext, DaysAndTime, IsValid)

                End Using

            End Using

            DayTimeValidateEntity = ErrorText

        End Function
        Public Function DayTimeValidateEntityProperty(DaysAndTime As AdvantageFramework.DTO.DaysAndTime, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim DaysAndTimeController As AdvantageFramework.Controller.DaysAndTimeController = Nothing

            DaysAndTimeController = New AdvantageFramework.Controller.DaysAndTimeController(Me.Session)

            If FieldName = AdvantageFramework.DTO.DaysAndTime.Properties.StartTime.ToString Then

                DaysAndTimeController.ParseTime(DaysAndTime, True, Value, IsValid)

            ElseIf FieldName = AdvantageFramework.DTO.DaysAndTime.Properties.EndTime.ToString Then

                DaysAndTimeController.ParseTime(DaysAndTime, False, Value, IsValid)

            ElseIf FieldName = AdvantageFramework.DTO.DaysAndTime.Properties.Days.ToString Then

                DaysAndTimeController.ParseDays(DaysAndTime, Value, IsValid)

            End If

            If IsValid Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ErrorText = DaysAndTimeController.ValidateEntityProperty(DaysAndTime, FieldName, IsValid, Value)

                    End Using

                End Using

            ElseIf FieldName = AdvantageFramework.DTO.DaysAndTime.Properties.StartTime.ToString Then

                ErrorText = "Invalid Time Entry"

            ElseIf FieldName = AdvantageFramework.DTO.DaysAndTime.Properties.EndTime.ToString Then

                ErrorText = "Invalid Time Entry"

            ElseIf FieldName = AdvantageFramework.DTO.DaysAndTime.Properties.Days.ToString Then

                ErrorText = "Invalid Day Entry"

            End If

            DayTimeValidateEntityProperty = ErrorText

        End Function
        Public Sub GetProgramDetails(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, StationCode As Integer, BookID As Integer, DaytimeID As Integer)

            'objects
            Dim MediaSpotTVResearchDayTime As AdvantageFramework.Database.Entities.MediaSpotTVResearchDayTime = Nothing
            Dim ProgramWeeks As Generic.List(Of ProgramWeek) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaSpotTVResearchDayTime = AdvantageFramework.Database.Procedures.MediaSpotTVResearchDayTime.LoadByID(DbContext, DaytimeID)

                If MediaSpotTVResearchDayTime IsNot Nothing Then

                    Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Me.Session.NielsenConnectionString, Nothing)

                        ProgramWeeks = NielsenDbContext.Database.SqlQuery(Of ProgramWeek)("Select program_name, week FROM dbo.[advtf_nielsen_program_get_by_week]( {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, 180)",
                            BookID, StationCode, MediaSpotTVResearchDayTime.StartHour, MediaSpotTVResearchDayTime.EndHour, If(MediaSpotTVResearchDayTime.Sunday, 1, 0), If(MediaSpotTVResearchDayTime.Monday, 1, 0),
                            If(MediaSpotTVResearchDayTime.Tuesday, 1, 0), If(MediaSpotTVResearchDayTime.Wednesday, 1, 0), If(MediaSpotTVResearchDayTime.Thursday, 1, 0), If(MediaSpotTVResearchDayTime.Friday, 1, 0), If(MediaSpotTVResearchDayTime.Saturday, 1, 0)).ToList

                        BroadcastResearchViewModel.ProgramWeeks = String.Empty

                        For Each ProgramWeek In ProgramWeeks

                            BroadcastResearchViewModel.ProgramWeeks += ProgramWeek.week.ToString & " - " & ProgramWeek.program_name & vbCrLf

                        Next

                    End Using

                End If

            End Using

        End Sub
        Public Sub SetTVMaxRank(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, MaxRank As Nullable(Of Short))

            BroadcastResearchViewModel.SpotTVSelectedResearchCriteria.MaxRank = MaxRank

            BroadcastResearchViewModel.SpotTVIsDirty = True

        End Sub

#End Region

#Region " Spot Radio "

        Private Function GetRadioStations(NielsenDbContext As AdvantageFramework.Nielsen.Database.DbContext, BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, NielsenStationIDs As IEnumerable(Of Integer)) As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.Station)

            'objects
            Dim SqlParameterNielsenRadioMarketNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNielsenStationIDs As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRadioSource As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterNielsenRadioMarketNumber = New System.Data.SqlClient.SqlParameter("@NIELSEN_RADIO_MARKET_NUMBER", SqlDbType.Int)
            SqlParameterNielsenStationIDs = New System.Data.SqlClient.SqlParameter("@NIELSEN_RADIO_STATION_IDs", SqlDbType.VarChar)
            SqlParameterRadioSource = New System.Data.SqlClient.SqlParameter("@RADIO_SOURCE", SqlDbType.Int)

            SqlParameterNielsenRadioMarketNumber.Value = BroadcastResearchViewModel.SelectedResearchCriteria.NielsenRadioMarketNumber

            If NielsenStationIDs Is Nothing Then

                SqlParameterNielsenStationIDs.Value = System.DBNull.Value

            Else

                SqlParameterNielsenStationIDs.Value = String.Join(",", NielsenStationIDs.ToArray)

            End If

            SqlParameterRadioSource.Value = BroadcastResearchViewModel.SelectedResearchCriteria.Source

            GetRadioStations = NielsenDbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.SpotRadio.Station)("exec dbo.advsp_media_spot_radio_stations_v2 @NIELSEN_RADIO_MARKET_NUMBER, @NIELSEN_RADIO_STATION_IDs, @RADIO_SOURCE",
                                                     SqlParameterNielsenRadioMarketNumber, SqlParameterNielsenStationIDs, SqlParameterRadioSource).ToList

        End Function
        Public Sub AddToSelectedSpotRadioMetrics(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                 AvailableMetricsSelected As IEnumerable(Of AdvantageFramework.DTO.Media.Metric))

            If AvailableMetricsSelected IsNot Nothing AndAlso AvailableMetricsSelected.Count > 0 Then

                For Each Metric In AvailableMetricsSelected

                    BroadcastResearchViewModel.SelectedMetricList.Add(Metric)
                    BroadcastResearchViewModel.AvailableMetricList.Remove(Metric)

                Next

                BroadcastResearchViewModel.SpotRadioIsDirty = True

            End If

        End Sub
        Public Sub RemoveFromSelectedSpotRadioMetrics(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                      SelectedMetricSelected As IEnumerable(Of AdvantageFramework.DTO.Media.Metric))

            If SelectedMetricSelected IsNot Nothing AndAlso SelectedMetricSelected.Count > 0 Then

                For Each Metric In SelectedMetricSelected

                    BroadcastResearchViewModel.AvailableMetricList.Add(Metric)
                    BroadcastResearchViewModel.SelectedMetricList.Remove(Metric)

                Next

                BroadcastResearchViewModel.SpotRadioIsDirty = True

            End If

        End Sub
        Public Sub AddToSelectedSpotRadioStations(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                  AvailableStationsSelected As IEnumerable(Of AdvantageFramework.DTO.Media.SpotRadio.Station))

            If AvailableStationsSelected IsNot Nothing AndAlso AvailableStationsSelected.Count > 0 Then

                For Each Station In AvailableStationsSelected

                    BroadcastResearchViewModel.SelectedStationList.Add(Station)
                    BroadcastResearchViewModel.AvailableStationList.Remove(Station)

                Next

                BroadcastResearchViewModel.SpotRadioIsDirty = True

            End If

        End Sub
        Public Sub RemoveFromSelectedSpotRadioStations(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                       SelectedStationsSelected As IEnumerable(Of AdvantageFramework.DTO.Media.SpotRadio.Station))

            If SelectedStationsSelected IsNot Nothing AndAlso SelectedStationsSelected.Count > 0 Then

                For Each Station In SelectedStationsSelected

                    BroadcastResearchViewModel.AvailableStationList.Add(Station)
                    BroadcastResearchViewModel.SelectedStationList.Remove(Station)

                Next

                BroadcastResearchViewModel.SpotRadioIsDirty = True

            End If

        End Sub
        Public Sub BookCancelNewItemRow(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            BroadcastResearchViewModel.BookIsNewRow = False
            BroadcastResearchViewModel.BookCancelEnabled = False
            BroadcastResearchViewModel.BookDeleteEnabled = BroadcastResearchViewModel.NielsenRadioBookList IsNot Nothing AndAlso BroadcastResearchViewModel.NielsenRadioBookList.Count > 0

        End Sub
        Public Sub DeleteSelectedBooks(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                       SelectedNielsenRadioBooks As Generic.List(Of DTO.Media.SpotRadio.NielsenRadioBook))

            If SelectedNielsenRadioBooks IsNot Nothing AndAlso SelectedNielsenRadioBooks.Count > 0 Then

                For Each SelectedNielsenRadioBook In SelectedNielsenRadioBooks

                    BroadcastResearchViewModel.NielsenRadioBookList.Remove(SelectedNielsenRadioBook)

                Next

                BroadcastResearchViewModel.SpotRadioIsDirty = True

            End If

        End Sub
        Public Sub DeleteSelectedDayparts(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                          SelectedNielsenDayparts As Generic.List(Of DTO.Media.NielsenDaypart))

            If SelectedNielsenDayparts IsNot Nothing AndAlso SelectedNielsenDayparts.Count > 0 Then

                For Each SelectedNielsenDaypart In SelectedNielsenDayparts

                    BroadcastResearchViewModel.NielsenDaypartList.Remove(SelectedNielsenDaypart)

                Next

                BroadcastResearchViewModel.SpotRadioIsDirty = True

            End If

        End Sub
        Public Function DeleteSpotRadio(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ByRef ErrorMessage As String) As Boolean

            'objects 
            Dim Deleted As Boolean = True
            Dim MediaSpotRadioResearch As AdvantageFramework.Database.Entities.MediaSpotRadioResearch = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaSpotRadioResearch = AdvantageFramework.Database.Procedures.MediaSpotRadioResearch.LoadByID(DbContext, BroadcastResearchViewModel.SelectedResearchCriteria.ID)

                If MediaSpotRadioResearch IsNot Nothing Then

                    Deleted = AdvantageFramework.Database.Procedures.MediaSpotRadioResearch.Delete(DbContext, MediaSpotRadioResearch, ErrorMessage)

                End If

            End Using

            DeleteSpotRadio = Deleted

        End Function
        Private Sub GetNielsenRadioPeriods(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                           ByRef NielsenRadioPeriodIDs As Generic.List(Of Integer))

            For Each NielsenRadioBook In BroadcastResearchViewModel.NielsenRadioBookList

                If NielsenRadioBook.NielsenRadioPeriodID1.HasValue AndAlso Not NielsenRadioPeriodIDs.Contains(NielsenRadioBook.NielsenRadioPeriodID1.Value) Then

                    NielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID1.Value)

                End If

                If NielsenRadioBook.NielsenRadioPeriodID2.HasValue AndAlso Not NielsenRadioPeriodIDs.Contains(NielsenRadioBook.NielsenRadioPeriodID2.Value) Then

                    NielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID2.Value)

                End If

                If NielsenRadioBook.NielsenRadioPeriodID3.HasValue AndAlso Not NielsenRadioPeriodIDs.Contains(NielsenRadioBook.NielsenRadioPeriodID3.Value) Then

                    NielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID3.Value)

                End If

                If NielsenRadioBook.NielsenRadioPeriodID4.HasValue AndAlso Not NielsenRadioPeriodIDs.Contains(NielsenRadioBook.NielsenRadioPeriodID4.Value) Then

                    NielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID4.Value)

                End If

                If NielsenRadioBook.NielsenRadioPeriodID5.HasValue AndAlso Not NielsenRadioPeriodIDs.Contains(NielsenRadioBook.NielsenRadioPeriodID5.Value) Then

                    NielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID5.Value)

                End If

            Next

        End Sub
        Public Sub SetBooks(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                            NielsenRadioBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook))

            'objects
            Dim DiaryReportTypes As IEnumerable(Of String) = Nothing
            Dim NielsenRadioPeriodIDs As Generic.List(Of Integer) = Nothing
            Dim DiaryPeriodIDs As IEnumerable(Of Integer) = Nothing
            Dim GeoIndicators As IEnumerable(Of Short) = Nothing

            DiaryReportTypes = {"1", "2", "3", "4", "6", "9"}

            BroadcastResearchViewModel.NielsenRadioBookList = NielsenRadioBooks

            BroadcastResearchViewModel.SpotRadioHasTSAData = False
            BroadcastResearchViewModel.SpotRadioHasDMAData = False

            NielsenRadioPeriodIDs = New Generic.List(Of Integer)

            GetNielsenRadioPeriods(BroadcastResearchViewModel, NielsenRadioPeriodIDs)

            Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                If NielsenRadioPeriodIDs.Count > 0 Then

                    DiaryPeriodIDs = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadValidated(NielsenDbContext)
                                      Where NielsenRadioPeriodIDs.Contains(Entity.ID) AndAlso
                                            DiaryReportTypes.Contains(Entity.NielsenRadioReportTypeCode)
                                      Select Entity.ID).ToArray

                End If

                If DiaryPeriodIDs IsNot Nothing AndAlso DiaryPeriodIDs.Count > 0 Then

                    BroadcastResearchViewModel.SpotRadioIsDiaryMarket = True

                    GeoIndicators = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioSegmentParent.Load(NielsenDbContext)
                                     Where DiaryPeriodIDs.Contains(Entity.NielsenRadioPeriodID)
                                     Select Entity.GeoIndicator).Distinct.ToArray

                    If GeoIndicators.Contains(AdvantageFramework.Database.Entities.NielsenRadioGeoIndicator.TSA) Then

                        BroadcastResearchViewModel.SpotRadioHasTSAData = True

                    End If

                    If GeoIndicators.Contains(AdvantageFramework.Database.Entities.NielsenRadioGeoIndicator.DMA) Then

                        BroadcastResearchViewModel.SpotRadioHasDMAData = True

                    End If

                Else

                    BroadcastResearchViewModel.SpotRadioIsDiaryMarket = False

                End If

            End Using

        End Sub
        Public Sub SetDayparts(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                               NielsenDayparts As Generic.List(Of AdvantageFramework.DTO.Media.NielsenDaypart))

            BroadcastResearchViewModel.NielsenDaypartList = NielsenDayparts

        End Sub
        Public Sub BookAddNewRowEvent(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            BroadcastResearchViewModel.SpotRadioIsDirty = True

        End Sub
        Public Sub BookCellChanged(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                   NielsenRadioBook As AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook, FieldName As String, Value As Object)

            If FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID1.ToString AndAlso Value Is Nothing Then

                NielsenRadioBook.NielsenRadioPeriodID2 = Nothing
                NielsenRadioBook.NielsenRadioPeriodID3 = Nothing
                NielsenRadioBook.NielsenRadioPeriodID4 = Nothing
                NielsenRadioBook.NielsenRadioPeriodID5 = Nothing

            ElseIf FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID2.ToString AndAlso Value Is Nothing Then

                NielsenRadioBook.NielsenRadioPeriodID3 = Nothing
                NielsenRadioBook.NielsenRadioPeriodID4 = Nothing
                NielsenRadioBook.NielsenRadioPeriodID5 = Nothing

            ElseIf FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID3.ToString AndAlso Value Is Nothing Then

                NielsenRadioBook.NielsenRadioPeriodID4 = Nothing
                NielsenRadioBook.NielsenRadioPeriodID5 = Nothing

            ElseIf FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID4.ToString AndAlso Value Is Nothing Then

                NielsenRadioBook.NielsenRadioPeriodID5 = Nothing

            End If

            BroadcastResearchViewModel.SpotRadioIsDirty = True

        End Sub
        Public Sub BookInitNewRowEvent(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            BroadcastResearchViewModel.BookIsNewRow = True
            BroadcastResearchViewModel.BookCancelEnabled = True
            BroadcastResearchViewModel.BookDeleteEnabled = False

        End Sub
        Public Sub BookSelectionChanged(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                        IsNewItemRow As Boolean,
                                        NielsenRadioBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook))

            BroadcastResearchViewModel.BookIsNewRow = IsNewItemRow
            BroadcastResearchViewModel.BookCancelEnabled = IsNewItemRow
            BroadcastResearchViewModel.BookDeleteEnabled = Not IsNewItemRow

        End Sub
        Public Sub DaypartAddNewRowEvent(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, NielsenDaypart As DTO.Media.NielsenDaypart)

            BroadcastResearchViewModel.NielsenDaypartList.Add(NielsenDaypart)
            BroadcastResearchViewModel.SpotRadioIsDirty = True

        End Sub
        Public Sub DaypartCancelNewItemRow(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            BroadcastResearchViewModel.DaypartIsNewRow = False
            BroadcastResearchViewModel.DaypartCancelEnabled = False
            BroadcastResearchViewModel.DaypartDeleteEnabled = BroadcastResearchViewModel.NielsenDaypartList IsNot Nothing AndAlso BroadcastResearchViewModel.NielsenDaypartList.Count > 0

        End Sub
        Public Sub DaypartInitNewRowEvent(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            BroadcastResearchViewModel.DaypartIsNewRow = True
            BroadcastResearchViewModel.DaypartCancelEnabled = True
            BroadcastResearchViewModel.DaypartDeleteEnabled = False

        End Sub
        Public Sub DaypartCellChanged(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                      NielsenDaypartID As Short,
                                      ByRef NielsenRadioDaypartDTO As AdvantageFramework.DTO.Media.NielsenDaypart)

            'objects
            Dim NielsenRadioDaypart As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDaypart = Nothing

            Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                NielsenRadioDaypart = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioDaypart.LoadByNielsenDaypartID(NielsenDbContext, NielsenDaypartID)

                If NielsenRadioDaypart IsNot Nothing Then

                    NielsenRadioDaypartDTO.AQH = NielsenRadioDaypart.AQH
                    NielsenRadioDaypartDTO.Cume = NielsenRadioDaypart.Cume
                    NielsenRadioDaypartDTO.ExclusiveCume = NielsenRadioDaypart.ExclusiveCume
                    NielsenRadioDaypartDTO.Qualitative = NielsenRadioDaypart.Qualitative
                    NielsenRadioDaypartDTO.DiaryAtWorkInCar = NielsenRadioDaypart.DiaryAtWorkInCar
                    NielsenRadioDaypartDTO.PPMinHomeOutofHome = NielsenRadioDaypart.PPMinHomeOutofHome

                End If

            End Using

            BroadcastResearchViewModel.SpotRadioIsDirty = True

        End Sub
        Public Sub DaypartSelectionChanged(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                           IsNewItemRow As Boolean,
                                           SelectedNielsenDayparts As Generic.List(Of AdvantageFramework.DTO.Media.NielsenDaypart))

            BroadcastResearchViewModel.DaypartIsNewRow = IsNewItemRow
            BroadcastResearchViewModel.DaypartCancelEnabled = IsNewItemRow
            BroadcastResearchViewModel.DaypartDeleteEnabled = Not IsNewItemRow

        End Sub
        Public Function GetRepositoryNielsenRadioDayparts(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                          FieldName As String,
                                                          NielsenDaypart As AdvantageFramework.DTO.Media.NielsenDaypart,
                                                          IncludeIsStandardOnly As Boolean) As Generic.List(Of AdvantageFramework.DTO.Media.NielsenDaypart)

            'objects
            Dim NielsenDayparts As Generic.List(Of AdvantageFramework.DTO.Media.NielsenDaypart) = Nothing
            Dim ExcludeNielsenDaypartIDs As Generic.List(Of Integer) = Nothing

            Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                ExcludeNielsenDaypartIDs = New Generic.List(Of Integer)

                If NielsenDaypart Is Nothing AndAlso FieldName = AdvantageFramework.DTO.Media.NielsenDaypart.Properties.ID.ToString Then

                    ExcludeNielsenDaypartIDs.AddRange(From Entity In BroadcastResearchViewModel.NielsenDaypartList
                                                      Select Entity.ID)

                ElseIf NielsenDaypart IsNot Nothing AndAlso FieldName = AdvantageFramework.DTO.Media.NielsenDaypart.Properties.ID.ToString Then

                    ExcludeNielsenDaypartIDs.AddRange(From Entity In BroadcastResearchViewModel.NielsenDaypartList
                                                      Where Entity.ID <> NielsenDaypart.ID
                                                      Select Entity.ID)

                End If

                NielsenDayparts = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioDaypart.LoadExcludeNielsenDaypartIDs(NielsenDbContext, ExcludeNielsenDaypartIDs).ToList
                                   Select New AdvantageFramework.DTO.Media.NielsenDaypart(Entity)).ToList

                If IncludeIsStandardOnly Then

                    NielsenDayparts = (From Entity In NielsenDayparts
                                       Where Entity.IsStandard = True
                                       Select Entity).ToList

                End If

            End Using

            GetRepositoryNielsenRadioDayparts = NielsenDayparts

        End Function
        Public Function GetRepositoryNielsenRadioPeriods(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                         FieldName As String,
                                                         NielsenRadioBook As AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook) As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)

            'objects
            Dim NielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod) = Nothing
            Dim ReportTypeCodes As IEnumerable(Of String) = Nothing
            Dim ExcludeNielsenRadioPeriodIDs As Generic.List(Of Integer) = Nothing
            Dim ClientNielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod) = Nothing

            Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                If BroadcastResearchViewModel.SelectedResearchCriteria.Ethnicity = 1 Then

                    ReportTypeCodes = {"1", "5", "4", "6", "9"}

                ElseIf BroadcastResearchViewModel.SelectedResearchCriteria.Ethnicity = 2 Then

                    ReportTypeCodes = {"2", "7"}

                ElseIf BroadcastResearchViewModel.SelectedResearchCriteria.Ethnicity = 3 Then

                    ReportTypeCodes = {"3", "8"}

                End If

                ExcludeNielsenRadioPeriodIDs = New Generic.List(Of Integer)

                If NielsenRadioBook Is Nothing AndAlso FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID1.ToString Then

                    ExcludeNielsenRadioPeriodIDs.AddRange(From Entity In BroadcastResearchViewModel.NielsenRadioBookList
                                                          Where Entity.NielsenRadioPeriodID1 IsNot Nothing
                                                          Select Entity.NielsenRadioPeriodID1.Value)

                ElseIf NielsenRadioBook IsNot Nothing Then

                    If FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID1.ToString Then

                        If NielsenRadioBook.NielsenRadioPeriodID2.HasValue Then ExcludeNielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID2.Value)
                        If NielsenRadioBook.NielsenRadioPeriodID3.HasValue Then ExcludeNielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID3.Value)
                        If NielsenRadioBook.NielsenRadioPeriodID4.HasValue Then ExcludeNielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID4.Value)
                        If NielsenRadioBook.NielsenRadioPeriodID5.HasValue Then ExcludeNielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID5.Value)

                        ExcludeNielsenRadioPeriodIDs.AddRange(From Entity In BroadcastResearchViewModel.NielsenRadioBookList
                                                              Where Entity.NielsenRadioPeriodID1 IsNot Nothing AndAlso
                                                                    Entity.NielsenRadioPeriodID1.GetValueOrDefault(0) <> NielsenRadioBook.NielsenRadioPeriodID1.GetValueOrDefault(0)
                                                              Select Entity.NielsenRadioPeriodID1.Value)

                    ElseIf FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID2.ToString Then

                        If NielsenRadioBook.NielsenRadioPeriodID1.HasValue Then ExcludeNielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID1.Value)
                        If NielsenRadioBook.NielsenRadioPeriodID3.HasValue Then ExcludeNielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID3.Value)
                        If NielsenRadioBook.NielsenRadioPeriodID4.HasValue Then ExcludeNielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID4.Value)
                        If NielsenRadioBook.NielsenRadioPeriodID5.HasValue Then ExcludeNielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID5.Value)

                    ElseIf FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID3.ToString Then

                        If NielsenRadioBook.NielsenRadioPeriodID1.HasValue Then ExcludeNielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID1.Value)
                        If NielsenRadioBook.NielsenRadioPeriodID2.HasValue Then ExcludeNielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID2.Value)
                        If NielsenRadioBook.NielsenRadioPeriodID4.HasValue Then ExcludeNielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID4.Value)
                        If NielsenRadioBook.NielsenRadioPeriodID5.HasValue Then ExcludeNielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID5.Value)

                    ElseIf FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID4.ToString Then

                        If NielsenRadioBook.NielsenRadioPeriodID1.HasValue Then ExcludeNielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID1.Value)
                        If NielsenRadioBook.NielsenRadioPeriodID2.HasValue Then ExcludeNielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID2.Value)
                        If NielsenRadioBook.NielsenRadioPeriodID3.HasValue Then ExcludeNielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID3.Value)
                        If NielsenRadioBook.NielsenRadioPeriodID5.HasValue Then ExcludeNielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID5.Value)

                    ElseIf FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID5.ToString Then

                        If NielsenRadioBook.NielsenRadioPeriodID1.HasValue Then ExcludeNielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID1.Value)
                        If NielsenRadioBook.NielsenRadioPeriodID2.HasValue Then ExcludeNielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID2.Value)
                        If NielsenRadioBook.NielsenRadioPeriodID3.HasValue Then ExcludeNielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID3.Value)
                        If NielsenRadioBook.NielsenRadioPeriodID4.HasValue Then ExcludeNielsenRadioPeriodIDs.Add(NielsenRadioBook.NielsenRadioPeriodID4.Value)

                    End If

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If BroadcastResearchViewModel.SelectedResearchCriteria.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

                        If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                            ClientNielsenRadioPeriods = NielsenDbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod)(String.Format("EXEC advsp_nielsen_spot_radio_get_client_periods '{0}'", Session.NielsenClientCodeForHosted)).ToList

                            NielsenRadioPeriods = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadByNielsenRadioMarketNumberAndNielsenRadioReportTypeCodesAndSource(NielsenDbContext, BroadcastResearchViewModel.SelectedResearchCriteria.NielsenRadioMarketNumber, ReportTypeCodes, ExcludeNielsenRadioPeriodIDs, Nielsen.Database.Entities.RadioSource.Nielsen).ToList
                                                   Select New AdvantageFramework.DTO.Media.NielsenRadioPeriod(Entity)).OrderByDescending(Function(Entity) Entity.Year).ThenByDescending(Function(Entity) Entity.SortMonth).ToList

                            NielsenRadioPeriods = (From Entity In NielsenRadioPeriods
                                                   Join NRP In ClientNielsenRadioPeriods On Entity.ID Equals NRP.NielsenRadioPeriodID And Entity.Month Equals NRP.Month And Entity.Year Equals NRP.Year
                                                   Select Entity).ToList

                        Else

                            NielsenRadioPeriods = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadByNielsenRadioMarketNumberAndNielsenRadioReportTypeCodesAndSource(NielsenDbContext, BroadcastResearchViewModel.SelectedResearchCriteria.NielsenRadioMarketNumber, ReportTypeCodes, ExcludeNielsenRadioPeriodIDs, Nielsen.Database.Entities.RadioSource.Nielsen).ToList
                                                   Select New AdvantageFramework.DTO.Media.NielsenRadioPeriod(Entity)).OrderByDescending(Function(Entity) Entity.Year).ThenByDescending(Function(Entity) Entity.SortMonth).ToList

                        End If

                    ElseIf BroadcastResearchViewModel.SelectedResearchCriteria.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan Then

                        NielsenRadioPeriods = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadByNielsenRadioMarketNumberAndNielsenRadioReportTypeCodesAndSource(NielsenDbContext, BroadcastResearchViewModel.SelectedResearchCriteria.NielsenRadioMarketNumber, ReportTypeCodes, ExcludeNielsenRadioPeriodIDs, Nielsen.Database.Entities.RadioSource.Eastlan).ToList
                                               Select New AdvantageFramework.DTO.Media.NielsenRadioPeriod(Entity)).OrderByDescending(Function(Entity) Entity.Year).ThenByDescending(Function(Entity) Entity.SortMonth).ToList

                    End If

                End Using

            End Using

            GetRepositoryNielsenRadioPeriods = NielsenRadioPeriods

        End Function
        Public Function SaveSpotRadio(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim MediaSpotRadioResearch As AdvantageFramework.Database.Entities.MediaSpotRadioResearch = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MediaSpotRadioResearchBook As AdvantageFramework.Database.Entities.MediaSpotRadioResearchBook = Nothing
            Dim MediaSpotRadioResearchStation As AdvantageFramework.Database.Entities.MediaSpotRadioResearchStation = Nothing
            Dim MediaSpotRadioResearchDaypart As AdvantageFramework.Database.Entities.MediaSpotRadioResearchDaypart = Nothing
            Dim MediaSpotRadioResearchMetric As AdvantageFramework.Database.Entities.MediaSpotRadioResearchMetric = Nothing
            Dim Order As Integer = 0
            Dim Saved As Boolean = False

            If RequiredSpotRadioDataPresent(BroadcastResearchViewModel, ErrorMessage) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    MediaSpotRadioResearch = AdvantageFramework.Database.Procedures.MediaSpotRadioResearch.LoadByID(DbContext, BroadcastResearchViewModel.SelectedResearchCriteria.ID)

                    If MediaSpotRadioResearch IsNot Nothing Then

                        BroadcastResearchViewModel.SelectedResearchCriteria.SaveToEntity(MediaSpotRadioResearch)

                        Try

                            DbContext.Database.Connection.Open()

                            DbTransaction = DbContext.Database.BeginTransaction

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_RADIO_RESEARCH_BOOK WHERE MEDIA_SPOT_RADIO_RESEARCH_ID = {0}", MediaSpotRadioResearch.ID))
                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_RADIO_RESEARCH_DAYPART WHERE MEDIA_SPOT_RADIO_RESEARCH_ID = {0}", MediaSpotRadioResearch.ID))
                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_RADIO_RESEARCH_METRIC WHERE MEDIA_SPOT_RADIO_RESEARCH_ID = {0}", MediaSpotRadioResearch.ID))
                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_RADIO_RESEARCH_STATION WHERE MEDIA_SPOT_RADIO_RESEARCH_ID = {0}", MediaSpotRadioResearch.ID))

                            For Each NielsenRadioBook In BroadcastResearchViewModel.NielsenRadioBookList

                                MediaSpotRadioResearchBook = New AdvantageFramework.Database.Entities.MediaSpotRadioResearchBook
                                MediaSpotRadioResearchBook.DbContext = DbContext

                                MediaSpotRadioResearchBook.MediaSpotRadioResearchID = MediaSpotRadioResearch.ID
                                MediaSpotRadioResearchBook.NielsenRadioPeriodID1 = NielsenRadioBook.NielsenRadioPeriodID1
                                MediaSpotRadioResearchBook.NielsenRadioPeriodID2 = NielsenRadioBook.NielsenRadioPeriodID2
                                MediaSpotRadioResearchBook.NielsenRadioPeriodID3 = NielsenRadioBook.NielsenRadioPeriodID3
                                MediaSpotRadioResearchBook.NielsenRadioPeriodID4 = NielsenRadioBook.NielsenRadioPeriodID4
                                MediaSpotRadioResearchBook.NielsenRadioPeriodID5 = NielsenRadioBook.NielsenRadioPeriodID5

                                DbContext.MediaSpotRadioResearchBooks.Add(MediaSpotRadioResearchBook)

                            Next

                            For Each NielsenDaypart In BroadcastResearchViewModel.NielsenDaypartList

                                MediaSpotRadioResearchDaypart = New AdvantageFramework.Database.Entities.MediaSpotRadioResearchDaypart
                                MediaSpotRadioResearchDaypart.DbContext = DbContext

                                NielsenDaypart.SaveToEntity(MediaSpotRadioResearchDaypart)

                                MediaSpotRadioResearchDaypart.MediaSpotRadioResearchID = MediaSpotRadioResearch.ID

                                DbContext.MediaSpotRadioResearchDayparts.Add(MediaSpotRadioResearchDaypart)

                            Next

                            Order = 1

                            For Each Metric In BroadcastResearchViewModel.SelectedMetricList

                                MediaSpotRadioResearchMetric = New AdvantageFramework.Database.Entities.MediaSpotRadioResearchMetric
                                MediaSpotRadioResearchMetric.DbContext = DbContext

                                MediaSpotRadioResearchMetric.MediaSpotRadioResearchID = MediaSpotRadioResearch.ID
                                MediaSpotRadioResearchMetric.Order = Order
                                MediaSpotRadioResearchMetric.MediaMetricID = Metric.ID

                                DbContext.MediaSpotRadioResearchMetrics.Add(MediaSpotRadioResearchMetric)

                                Order += 1

                            Next

                            For Each Station In BroadcastResearchViewModel.SelectedStationList

                                MediaSpotRadioResearchStation = New AdvantageFramework.Database.Entities.MediaSpotRadioResearchStation
                                MediaSpotRadioResearchStation.DbContext = DbContext

                                MediaSpotRadioResearchStation.MediaSpotRadioResearchID = MediaSpotRadioResearch.ID
                                MediaSpotRadioResearchStation.NielsenRadioStationID = Station.NielsenRadioStationID

                                DbContext.MediaSpotRadioResearchStations.Add(MediaSpotRadioResearchStation)

                            Next

                            DbContext.SaveChanges()

                            If AdvantageFramework.Database.Procedures.MediaSpotRadioResearch.Update(DbContext, MediaSpotRadioResearch, ErrorMessage) = False Then

                                Throw New Exception(ErrorMessage)

                            End If

                            DbTransaction.Commit()

                            Saved = True

                            BroadcastResearchViewModel.SpotRadioIsDirty = False
                            BroadcastResearchViewModel.SpotRadioResearchResultList = Nothing
                            BroadcastResearchViewModel.SpotRadioReportDataTable = Nothing

                        Catch ex As Exception
                            ErrorMessage = ex.Message
                        Finally

                            If DbContext.Database.Connection.State = ConnectionState.Open Then

                                DbContext.Database.Connection.Close()

                            End If

                        End Try

                    Else

                        ErrorMessage = "This research criteria is no longer valid in the system."

                    End If

                End Using

            End If

            SaveSpotRadio = Saved

        End Function
        Public Function LoadSpotRadio(ResearchID As Integer?) As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel

            'objects
            Dim BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel = Nothing
            Dim NielsenMarketNumbers As IEnumerable(Of Integer) = Nothing
            Dim NielsenStationIDs As IEnumerable(Of Integer) = Nothing
            Dim StationList As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.Station) = Nothing
            Dim SelectedMediaDemoIDs As IEnumerable(Of Integer) = Nothing
            Dim SelectedMediaMetricIDs As IEnumerable(Of Integer) = Nothing
            Dim NielsenRadioDaypartList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDaypart) = Nothing
            Dim Dashboard As AdvantageFramework.Database.Entities.Dashboard = Nothing
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing

            BroadcastResearchViewModel = New AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel

            BroadcastResearchViewModel.SelectedResearchTab = ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadio

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    If Session.IsNielsenSetup OrElse Session.IsEastlanSetup Then

                        BroadcastResearchViewModel.AddEnabled = True

                    End If

                    If Session.IsEastlanSetup Then

                        BroadcastResearchViewModel.SpotRadioSourceList = (From NielsenRadioPeriodSource In [Enum].GetValues(GetType(AdvantageFramework.Nielsen.Database.Entities.RadioSource))
                                                                          Where NielsenRadioPeriodSource <> AdvantageFramework.Nielsen.Database.Entities.RadioSource.NielsenCounty
                                                                          Select New AdvantageFramework.DTO.ComboBoxItem(CType(NielsenRadioPeriodSource, AdvantageFramework.Nielsen.Database.Entities.RadioSource))).ToList

                        BroadcastResearchViewModel.ResearchCriteriaList = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotRadioResearch.Load(DbContext).ToList
                                                                           Select New AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria(Entity)).ToList

                    Else

                        BroadcastResearchViewModel.SpotRadioSourceList = (From NielsenRadioPeriodSource In [Enum].GetValues(GetType(AdvantageFramework.Nielsen.Database.Entities.RadioSource))
                                                                          Where NielsenRadioPeriodSource <> AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan AndAlso
                                                                                    NielsenRadioPeriodSource <> AdvantageFramework.Nielsen.Database.Entities.RadioSource.NielsenCounty
                                                                          Select New AdvantageFramework.DTO.ComboBoxItem(CType(NielsenRadioPeriodSource, AdvantageFramework.Nielsen.Database.Entities.RadioSource))).ToList

                        BroadcastResearchViewModel.ResearchCriteriaList = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotRadioResearch.Load(DbContext).ToList
                                                                           Where Entity.Source <> AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan
                                                                           Select New AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria(Entity)).ToList

                    End If

                    If Not Session.IsNielsenSetup Then

                        BroadcastResearchViewModel.SpotRadioSourceList = BroadcastResearchViewModel.SpotRadioSourceList.Where(Function(E) E.Value <> AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen)).ToList

                    End If

                    If Not Session.IsNielsenSetup AndAlso (From Entity In BroadcastResearchViewModel.ResearchCriteriaList
                                                           Where Entity.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen).Any Then

                        BroadcastResearchViewModel.ResearchCriteriaList = BroadcastResearchViewModel.ResearchCriteriaList.Where(Function(E) E.Source <> AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen).ToList
                        BroadcastResearchViewModel.MissingIntegrationSettingsMessage = "Nielsen and/or Comscore reports are not shown due to insufficient credentials.  Please check integration settings."

                    End If

                    If Session.IsNielsenSetup Then

                        Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                            NielsenRadioDaypartList = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioDaypart.Load(NielsenDbContext).ToList

                            BroadcastResearchViewModel.NielsenRadioPeriodRepository = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadValidated(NielsenDbContext).ToList
                                                                                       Select New AdvantageFramework.DTO.Media.NielsenRadioPeriod(Entity)).ToList

                            BroadcastResearchViewModel.NielsenDaypartRepository = (From Entity In NielsenRadioDaypartList
                                                                                   Select New AdvantageFramework.DTO.Media.NielsenDaypart(Entity)).ToList

                            BroadcastResearchViewModel.NielsenRadioQualitativeList = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioQualitative.Load(NielsenDbContext).ToList
                                                                                      Select New AdvantageFramework.DTO.Media.NielsenRadioQualitative(Entity)).ToList

                            If ResearchID.HasValue Then

                                BroadcastResearchViewModel.SelectedResearchCriteria = BroadcastResearchViewModel.ResearchCriteriaList.Where(Function(Entity) Entity.ID = ResearchID.Value).SingleOrDefault

                                Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, BroadcastResearchViewModel.SelectedResearchCriteria.MarketCode)

                                If Market IsNot Nothing Then

                                    BroadcastResearchViewModel.SelectedResearchCriteria.SetNielsenRadioMarketNumber(Market)

                                End If

                                LoadRadioMarketList(DbContext, NielsenDbContext, BroadcastResearchViewModel)

                                If BroadcastResearchViewModel.SelectedResearchCriteria.NielsenRadioMarketNumber <> 0 Then

                                    NielsenStationIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotRadioResearchStation.LoadByMediaSpotRadioResearchID(DbContext, ResearchID.Value).ToList
                                                         Select Entity.NielsenRadioStationID).ToArray

                                End If

                                StationList = GetRadioStations(NielsenDbContext, BroadcastResearchViewModel, NielsenStationIDs)

                                If StationList IsNot Nothing AndAlso StationList.Count > 0 Then

                                    BroadcastResearchViewModel.AvailableStationList = StationList.Where(Function(Station) Station.IsSelected = False).ToList

                                    BroadcastResearchViewModel.SelectedStationList = StationList.Where(Function(Station) Station.IsSelected = True).ToList

                                End If

                                BroadcastResearchViewModel.NielsenRadioBookList = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotRadioResearchBook.LoadByMediaSpotRadioResearchID(DbContext, ResearchID.Value).ToList
                                                                                   Select New AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook(Entity)).ToList

                                SetBooks(BroadcastResearchViewModel, BroadcastResearchViewModel.NielsenRadioBookList)

                                BroadcastResearchViewModel.NielsenDaypartList = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotRadioResearchDaypart.LoadByMediaSpotRadioResearchID(DbContext, ResearchID.Value).ToList
                                                                                 Select New AdvantageFramework.DTO.Media.NielsenDaypart(Entity, NielsenRadioDaypartList)).ToList

                                BroadcastResearchViewModel.SelectedMetricList = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotRadioResearchMetric.LoadByMediaSpotRadioResearchID(DbContext, ResearchID.Value).OrderBy(Function(Entity) Entity.Order).ToList
                                                                                 Select New AdvantageFramework.DTO.Media.Metric(Entity)).ToList

                                SelectedMediaMetricIDs = (From Entity In BroadcastResearchViewModel.SelectedMetricList
                                                          Select Entity.ID).ToArray

                                If BroadcastResearchViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.AudienceComposition Then

                                    BroadcastResearchViewModel.AvailableMetricList = (From Entity In AdvantageFramework.Database.Procedures.MediaMetric.LoadForRadioAudienceComposition(DbContext).Where(Function(Entity) SelectedMediaMetricIDs.Contains(Entity.ID) = False).ToList
                                                                                      Select New AdvantageFramework.DTO.Media.Metric(Entity)).ToList

                                Else

                                    BroadcastResearchViewModel.AvailableMetricList = (From Entity In AdvantageFramework.Database.Procedures.MediaMetric.Load(DbContext).Where(Function(Entity) SelectedMediaMetricIDs.Contains(Entity.ID) = False AndAlso
                                                                                                                                                                                   Entity.Type = "R" AndAlso
                                                                                                                                                                                   Entity.ID <> AdvantageFramework.Database.Entities.MediaMetricID.StationShareOfCountyPercent AndAlso
                                                                                                                                                                                   Entity.ID <> AdvantageFramework.Database.Entities.MediaMetricID.CountyShareOfStation).ToList
                                                                                      Select New AdvantageFramework.DTO.Media.Metric(Entity)).ToList

                                End If

                                LimitMetrics(BroadcastResearchViewModel, False)

                            Else

                                BroadcastResearchViewModel.SelectedResearchCriteria = Nothing

                            End If

                        End Using

                    End If

                    BroadcastResearchViewModel.MediaDemographicList = (From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.LoadRadioReportable(DbContext).ToList
                                                                       Select New AdvantageFramework.DTO.Media.MediaDemographic(Entity)).OrderBy(Function(DTO) DTO.Description).ToList

                    BroadcastResearchViewModel.SpotRadioResearchReportTypeList = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.SpotRadioResearchReportType))
                                                                                  Select New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

                    Dashboard = AdvantageFramework.Database.Procedures.Dashboard.LoadByDashboardType(DbContext, AdvantageFramework.Database.Entities.DashboardTypes.BroadcastResearchTool_Radio)

                    If Dashboard IsNot Nothing Then

                        BroadcastResearchViewModel.Dashboard = New AdvantageFramework.DTO.Dashboard(Dashboard)

                    Else

                        BroadcastResearchViewModel.Dashboard = New AdvantageFramework.DTO.Dashboard

                    End If

                End Using

            End Using

            BroadcastResearchViewModel.SpotRadioReportDataTable = Nothing

            LoadSpotRadio = BroadcastResearchViewModel

        End Function
        Public Sub SaveRadioDashboard(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, DashboardLayout() As Byte)

            'objects
            Dim Dashboard As AdvantageFramework.Database.Entities.Dashboard = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Dashboard = AdvantageFramework.Database.Procedures.Dashboard.LoadByDashboardType(DbContext, AdvantageFramework.Database.Entities.DashboardTypes.BroadcastResearchTool_Radio)

                If Dashboard IsNot Nothing Then

                    Dashboard.Layout = DashboardLayout

                    AdvantageFramework.Database.Procedures.Dashboard.Update(DbContext, Dashboard)

                Else

                    Dashboard = New AdvantageFramework.Database.Entities.Dashboard

                    Dashboard.DbContext = DbContext
                    Dashboard.Type = AdvantageFramework.Database.Entities.DashboardTypes.BroadcastResearchTool_Radio
                    Dashboard.Layout = DashboardLayout

                    AdvantageFramework.Database.Procedures.Dashboard.Insert(DbContext, Dashboard)

                End If

            End Using

            BroadcastResearchViewModel.Dashboard.Layout = DashboardLayout

        End Sub
        Public Sub MoveMetricSpotRadio(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                       Metric As DTO.Media.Metric, Direction As MoveItemDirection)

            'objects
            Dim OldIndex As Integer = -1

            OldIndex = BroadcastResearchViewModel.SelectedMetricList.IndexOf(Metric)

            BroadcastResearchViewModel.SelectedMetricList.RemoveAt(OldIndex)

            If Direction = MoveItemDirection.Down Then

                BroadcastResearchViewModel.SelectedMetricList.Insert(OldIndex + 1, Metric)

            Else

                BroadcastResearchViewModel.SelectedMetricList.Insert(OldIndex - 1, Metric)

            End If

            BroadcastResearchViewModel.SpotRadioIsDirty = True

        End Sub
        Public Function RunSpotRadioReport(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                           ByRef ErrorMessage As String,
                                           ByRef InfoMessage As String)

            'objects
            Dim ResearchID As Integer = Nothing
            Dim SqlParameterNielsenRadioMarketNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNielsenRadioQualitativeID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterGeoIndicator As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterListeningLocation As System.Data.SqlClient.SqlParameter = Nothing
            Dim DaypartIDs As IEnumerable(Of Integer) = Nothing
            Dim SqlParameterDaypartIDs As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStationIDs As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaDemoID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaDemoType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaDemoDetailType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaSpotRadioResearchDaypartType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaSpotRadioResearchBookType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDisplayBy As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterHostedClientCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim MediaSpotRadioResearchBooks As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpotRadioResearchBook) = Nothing
            Dim NielsenRadioStationIDs As Generic.List(Of Integer) = Nothing
            Dim MediaDemoID As Integer = 0
            Dim MediaSpotRadioResearchMetricList As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpotRadioResearchMetric) = Nothing
            Dim Success As Boolean = False
            Dim NameList As Generic.List(Of String) = Nothing
            Dim DaypartBooks As Integer = 0
            Dim StationDaypartBookCount As Dictionary(Of Integer, Integer) = Nothing

            If RequiredSpotRadioDataPresent(BroadcastResearchViewModel, ErrorMessage) AndAlso CheckCume(BroadcastResearchViewModel, ErrorMessage, InfoMessage) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    ResearchID = BroadcastResearchViewModel.SelectedResearchCriteria.ID.Value

                    MediaDemoID = BroadcastResearchViewModel.SelectedResearchCriteria.MediaDemoID.Value

                    SqlParameterNielsenRadioMarketNumber = New System.Data.SqlClient.SqlParameter("@NIELSEN_RADIO_MARKET_NUMBER", SqlDbType.Int)
                    SqlParameterNielsenRadioMarketNumber.Value = BroadcastResearchViewModel.SelectedResearchCriteria.NielsenRadioMarketNumber

                    SqlParameterNielsenRadioQualitativeID = New System.Data.SqlClient.SqlParameter("@NIELSEN_RADIO_QUALITATIVE_ID", SqlDbType.Int)
                    SqlParameterNielsenRadioQualitativeID.Value = BroadcastResearchViewModel.SelectedResearchCriteria.NielsenRadioQualitativeID

                    SqlParameterGeoIndicator = New System.Data.SqlClient.SqlParameter("@GEO_INDICATOR", SqlDbType.SmallInt)
                    SqlParameterGeoIndicator.Value = BroadcastResearchViewModel.SelectedResearchCriteria.Geography

                    SqlParameterListeningLocation = New System.Data.SqlClient.SqlParameter("@LISTENING_LOCATION", SqlDbType.Char)
                    SqlParameterListeningLocation.Value = BroadcastResearchViewModel.SelectedResearchCriteria.ListeningType

                    MediaSpotRadioResearchBooks = AdvantageFramework.Database.Procedures.MediaSpotRadioResearchBook.LoadByMediaSpotRadioResearchID(DbContext, ResearchID).ToList

                    DaypartIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotRadioResearchDaypart.LoadByMediaSpotRadioResearchID(DbContext, ResearchID)
                                  Select Entity.NielsenRadioDaypartID).ToList

                    SqlParameterDaypartIDs = New System.Data.SqlClient.SqlParameter("@NIELSEN_RADIO_DAYPART_IDs", SqlDbType.VarChar)
                    SqlParameterDaypartIDs.Value = String.Join(",", DaypartIDs.ToArray)

                    NielsenRadioStationIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotRadioResearchStation.LoadByMediaSpotRadioResearchID(DbContext, ResearchID)
                                              Select Entity.NielsenRadioStationID).ToList

                    SqlParameterStationIDs = New System.Data.SqlClient.SqlParameter("@NIELSEN_RADIO_STATION_IDs", SqlDbType.VarChar)
                    SqlParameterStationIDs.Value = String.Join(",", NielsenRadioStationIDs.ToArray)

                    SqlParameterMediaDemoID = New System.Data.SqlClient.SqlParameter("@MEDIA_DEMO_ID", SqlDbType.Int)
                    SqlParameterMediaDemoID.Value = MediaDemoID

                    SqlParameterMediaDemoType = New System.Data.SqlClient.SqlParameter("@MEDIA_DEMO_TYPE", SqlDbType.Structured)
                    SqlParameterMediaDemoType.TypeName = "MEDIA_DEMO_TYPE"
                    SqlParameterMediaDemoType.Value = AdvantageFramework.Database.ToDataTable((From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.Load(DbContext)
                                                                                               Where Entity.ID = MediaDemoID
                                                                                               Select Entity.ID,
                                                                                                        Entity.Description).ToList)

                    SqlParameterMediaDemoDetailType = New System.Data.SqlClient.SqlParameter("@MEDIA_DEMO_DETAIL_TYPE", SqlDbType.Structured)
                    SqlParameterMediaDemoDetailType.TypeName = "MEDIA_DEMO_DETAIL_TYPE"
                    SqlParameterMediaDemoDetailType.Value = AdvantageFramework.Database.ToDataTable((From Entity In AdvantageFramework.Database.Procedures.MediaDemographicDetail.Load(DbContext)
                                                                                                     Where Entity.MediaDemographicID = MediaDemoID
                                                                                                     Select Entity.MediaDemographicID,
                                                                                                            Entity.NielsenDemographicID).ToList)

                    SqlParameterMediaSpotRadioResearchDaypartType = New System.Data.SqlClient.SqlParameter("@MEDIA_SPOT_RADIO_RESEARCH_DAYPART_TYPE", SqlDbType.Structured)
                    SqlParameterMediaSpotRadioResearchDaypartType.TypeName = "MEDIA_SPOT_RADIO_RESEARCH_DAYPART_TYPE"
                    SqlParameterMediaSpotRadioResearchDaypartType.Value = AdvantageFramework.Database.ToDataTable((From Entity In AdvantageFramework.Database.Procedures.MediaSpotRadioResearchDaypart.LoadByMediaSpotRadioResearchID(DbContext, ResearchID)
                                                                                                                   Select Entity.ID,
                                                                                                                            Entity.MediaSpotRadioResearchID,
                                                                                                                            Entity.NielsenRadioDaypartID).ToList)

                    SqlParameterMediaSpotRadioResearchBookType = New System.Data.SqlClient.SqlParameter("@MEDIA_SPOT_RADIO_RESEARCH_BOOK_TYPE", SqlDbType.Structured)
                    SqlParameterMediaSpotRadioResearchBookType.TypeName = "MEDIA_SPOT_RADIO_RESEARCH_BOOK_TYPE"
                    SqlParameterMediaSpotRadioResearchBookType.Value = AdvantageFramework.Database.ToDataTable((From Entity In AdvantageFramework.Database.Procedures.MediaSpotRadioResearchBook.LoadByMediaSpotRadioResearchID(DbContext, ResearchID)
                                                                                                                Select Entity.ID,
                                                                                                                        Entity.NielsenRadioPeriodID1,
                                                                                                                        Entity.NielsenRadioPeriodID2,
                                                                                                                        Entity.NielsenRadioPeriodID3,
                                                                                                                        Entity.NielsenRadioPeriodID4,
                                                                                                                        Entity.NielsenRadioPeriodID5).ToList)

                    SqlParameterHostedClientCode = New System.Data.SqlClient.SqlParameter("@HOSTED_CLIENT_CODE", SqlDbType.VarChar)

                    If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                        SqlParameterHostedClientCode.Value = Session.NielsenClientCodeForHosted

                    Else

                        SqlParameterHostedClientCode.Value = System.DBNull.Value

                    End If

                    Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                        MediaSpotRadioResearchMetricList = AdvantageFramework.Database.Procedures.MediaSpotRadioResearchMetric.LoadByMediaSpotRadioResearchID(DbContext, BroadcastResearchViewModel.SelectedResearchCriteria.ID).ToList

                        If BroadcastResearchViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.AudienceComposition Then

                            SqlParameterDisplayBy = New System.Data.SqlClient.SqlParameter("@DISPLAY_BY", SqlDbType.SmallInt)
                            SqlParameterDisplayBy.Value = BroadcastResearchViewModel.SelectedResearchCriteria.DisplayByValue

                            BroadcastResearchViewModel.SpotRadioAudienceCompositionList = NielsenDbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.SpotRadio.AudienceComposition)("EXEC advsp_nielsen_spot_radio_research_audience_composition @NIELSEN_RADIO_MARKET_NUMBER, @NIELSEN_RADIO_QUALITATIVE_ID, @GEO_INDICATOR, @LISTENING_LOCATION, @NIELSEN_RADIO_DAYPART_IDs, @NIELSEN_RADIO_STATION_IDs, @MEDIA_DEMO_ID, @MEDIA_DEMO_TYPE, @MEDIA_DEMO_DETAIL_TYPE, @MEDIA_SPOT_RADIO_RESEARCH_DAYPART_TYPE, @MEDIA_SPOT_RADIO_RESEARCH_BOOK_TYPE, @DISPLAY_BY, @HOSTED_CLIENT_CODE",
                                SqlParameterNielsenRadioMarketNumber, SqlParameterNielsenRadioQualitativeID, SqlParameterGeoIndicator, SqlParameterListeningLocation,
                                SqlParameterDaypartIDs, SqlParameterStationIDs, SqlParameterMediaDemoID, SqlParameterMediaDemoType, SqlParameterMediaDemoDetailType,
                                SqlParameterMediaSpotRadioResearchDaypartType, SqlParameterMediaSpotRadioResearchBookType, SqlParameterDisplayBy, SqlParameterHostedClientCode).ToList()

                        Else

                            BroadcastResearchViewModel.SpotRadioResearchResultList = NielsenDbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.SpotRadio.ResearchResult)("EXEC advsp_nielsen_spot_radio_research_ranker @NIELSEN_RADIO_MARKET_NUMBER, @NIELSEN_RADIO_QUALITATIVE_ID, @GEO_INDICATOR, @LISTENING_LOCATION, @NIELSEN_RADIO_DAYPART_IDs, @NIELSEN_RADIO_STATION_IDs, @MEDIA_DEMO_ID, @MEDIA_DEMO_TYPE, @MEDIA_DEMO_DETAIL_TYPE, @MEDIA_SPOT_RADIO_RESEARCH_DAYPART_TYPE, @MEDIA_SPOT_RADIO_RESEARCH_BOOK_TYPE, @HOSTED_CLIENT_CODE",
                                SqlParameterNielsenRadioMarketNumber, SqlParameterNielsenRadioQualitativeID, SqlParameterGeoIndicator, SqlParameterListeningLocation,
                                SqlParameterDaypartIDs, SqlParameterStationIDs, SqlParameterMediaDemoID, SqlParameterMediaDemoType, SqlParameterMediaDemoDetailType,
                                SqlParameterMediaSpotRadioResearchDaypartType, SqlParameterMediaSpotRadioResearchBookType, SqlParameterHostedClientCode).ToList()

                            DaypartBooks = BroadcastResearchViewModel.SpotRadioResearchResultList.Select(Function(Result) Result.DaypartBooks).Distinct.Count

                            If AdvantageFramework.Database.Procedures.MediaSpotRadioResearchBook.LoadByMediaSpotRadioResearchID(DbContext, ResearchID).Count > DaypartBooks Then

                                DaypartBooks = AdvantageFramework.Database.Procedures.MediaSpotRadioResearchBook.LoadByMediaSpotRadioResearchID(DbContext, ResearchID).Count

                            End If

                            StationDaypartBookCount = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                       Group By Entity.NielsenRadioStationID Into Group
                                                       Select New With {.NielsenRadioStationID = NielsenRadioStationID,
                                                                        .Count = Group.Count}).ToDictionary(Function(E) E.NielsenRadioStationID, Function(E) E.Count)

                            For Each KeyPair In StationDaypartBookCount

                                If KeyPair.Value = DaypartBooks Then

                                    NielsenRadioStationIDs.Remove(KeyPair.Key)

                                End If

                            Next

                            If NielsenRadioStationIDs.Count > 0 Then

                                NameList = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.Load(NielsenDbContext)
                                            Where NielsenRadioStationIDs.Contains(Entity.ID)
                                            Select Entity).OrderBy(Function(Entity) Entity.Name).ToList.Select(Function(E) E.Name).ToList

                                InfoMessage += vbCrLf & "The following " & NameList.Count & " station(s) do not have data for all criteria selected: " & vbCrLf & String.Join(", ", NameList.ToArray)

                            End If

                        End If

                    End Using

                    If BroadcastResearchViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.Ranker Then

                        BroadcastResearchViewModel.SpotRadioReportDataTable = CreateSpotRadioRankerReportDataTable(BroadcastResearchViewModel, MediaSpotRadioResearchMetricList)

                    ElseIf BroadcastResearchViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.Trend Then

                        BroadcastResearchViewModel.SpotRadioReportDataTable = CreateSpotRadioTrendReportDataTable(BroadcastResearchViewModel, MediaSpotRadioResearchMetricList)

                    ElseIf BroadcastResearchViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.AudienceComposition Then

                        BroadcastResearchViewModel.SpotRadioReportDataTable = CreateSpotRadioAudienceCompositionReportDataTable(BroadcastResearchViewModel, MediaSpotRadioResearchMetricList)

                    End If

                End Using

                Success = True

            End If

            RunSpotRadioReport = Success

        End Function
        Public Sub SetGeography(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, Geography As Short)

            BroadcastResearchViewModel.SelectedResearchCriteria.Geography = Geography

            BroadcastResearchViewModel.SpotRadioIsDirty = True

        End Sub
        Private Sub LimitMetrics(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                 AddBackToAvailableList As Boolean)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If BroadcastResearchViewModel.SelectedResearchCriteria.ListeningType <> AdvantageFramework.Database.Entities.SpotRadioResearchListeningType.Total Then

                    If BroadcastResearchViewModel.SelectedMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.CumeRating).SingleOrDefault IsNot Nothing Then

                        BroadcastResearchViewModel.SelectedMetricList.Remove(BroadcastResearchViewModel.SelectedMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.CumeRating).Single)

                    End If

                    If BroadcastResearchViewModel.SelectedMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.Cume).SingleOrDefault IsNot Nothing Then

                        BroadcastResearchViewModel.SelectedMetricList.Remove(BroadcastResearchViewModel.SelectedMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.Cume).Single)

                    End If

                    If BroadcastResearchViewModel.SelectedMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.ExclusiveCume).SingleOrDefault IsNot Nothing Then

                        BroadcastResearchViewModel.SelectedMetricList.Remove(BroadcastResearchViewModel.SelectedMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.ExclusiveCume).Single)

                    End If

                    If BroadcastResearchViewModel.AvailableMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.CumeRating).SingleOrDefault IsNot Nothing Then

                        BroadcastResearchViewModel.AvailableMetricList.Remove(BroadcastResearchViewModel.AvailableMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.CumeRating).Single)

                    End If

                    If BroadcastResearchViewModel.AvailableMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.Cume).SingleOrDefault IsNot Nothing Then

                        BroadcastResearchViewModel.AvailableMetricList.Remove(BroadcastResearchViewModel.AvailableMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.Cume).Single)

                    End If

                    If BroadcastResearchViewModel.AvailableMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.ExclusiveCume).SingleOrDefault IsNot Nothing Then

                        BroadcastResearchViewModel.AvailableMetricList.Remove(BroadcastResearchViewModel.AvailableMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.ExclusiveCume).Single)

                    End If

                ElseIf BroadcastResearchViewModel.SelectedResearchCriteria.ListeningType = AdvantageFramework.Database.Entities.SpotRadioResearchListeningType.Total AndAlso AddBackToAvailableList Then

                    If BroadcastResearchViewModel.AvailableMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.CumeRating).SingleOrDefault Is Nothing AndAlso
                                BroadcastResearchViewModel.SelectedMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.CumeRating).SingleOrDefault Is Nothing Then

                        BroadcastResearchViewModel.AvailableMetricList.AddRange(From Entity In AdvantageFramework.Database.Procedures.MediaMetric.Load(DbContext).Where(Function(Entity) Entity.ID = AdvantageFramework.Database.Entities.MediaMetricID.CumeRating).ToList
                                                                                Select New AdvantageFramework.DTO.Media.Metric(Entity))

                    End If

                    If BroadcastResearchViewModel.AvailableMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.Cume).SingleOrDefault Is Nothing AndAlso
                            BroadcastResearchViewModel.SelectedMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.Cume).SingleOrDefault Is Nothing Then

                        BroadcastResearchViewModel.AvailableMetricList.AddRange(From Entity In AdvantageFramework.Database.Procedures.MediaMetric.Load(DbContext).Where(Function(Entity) Entity.ID = AdvantageFramework.Database.Entities.MediaMetricID.Cume).ToList
                                                                                Select New AdvantageFramework.DTO.Media.Metric(Entity))

                    End If

                    If BroadcastResearchViewModel.AvailableMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.ExclusiveCume).SingleOrDefault Is Nothing AndAlso
                            BroadcastResearchViewModel.SelectedMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.ExclusiveCume).SingleOrDefault Is Nothing Then

                        BroadcastResearchViewModel.AvailableMetricList.AddRange(From Entity In AdvantageFramework.Database.Procedures.MediaMetric.Load(DbContext).Where(Function(Entity) Entity.ID = AdvantageFramework.Database.Entities.MediaMetricID.ExclusiveCume).ToList
                                                                                Select New AdvantageFramework.DTO.Media.Metric(Entity))

                    End If

                End If

                If BroadcastResearchViewModel.SelectedResearchCriteria.NielsenRadioQualitativeID <> 1 Then

                    If BroadcastResearchViewModel.SelectedMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.ExclusiveCume).SingleOrDefault IsNot Nothing Then

                        BroadcastResearchViewModel.SelectedMetricList.Remove(BroadcastResearchViewModel.SelectedMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.ExclusiveCume).Single)

                    End If

                    If BroadcastResearchViewModel.AvailableMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.ExclusiveCume).SingleOrDefault IsNot Nothing Then

                        BroadcastResearchViewModel.AvailableMetricList.Remove(BroadcastResearchViewModel.AvailableMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.ExclusiveCume).Single)

                    End If

                ElseIf BroadcastResearchViewModel.SelectedResearchCriteria.NielsenRadioQualitativeID = 1 AndAlso AddBackToAvailableList Then

                    If BroadcastResearchViewModel.AvailableMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.ExclusiveCume).SingleOrDefault Is Nothing AndAlso
                            BroadcastResearchViewModel.SelectedMetricList.Where(Function(MM) MM.ID = AdvantageFramework.Database.Entities.MediaMetricID.ExclusiveCume).SingleOrDefault Is Nothing Then

                        BroadcastResearchViewModel.AvailableMetricList.AddRange(From Entity In AdvantageFramework.Database.Procedures.MediaMetric.Load(DbContext).Where(Function(Entity) Entity.ID = AdvantageFramework.Database.Entities.MediaMetricID.ExclusiveCume).ToList
                                                                                Select New AdvantageFramework.DTO.Media.Metric(Entity))

                    End If

                End If

            End Using

        End Sub
        Public Sub SetListeningType(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ListeningType As Short)

            BroadcastResearchViewModel.SelectedResearchCriteria.ListeningType = ListeningType

            LimitMetrics(BroadcastResearchViewModel, True)

            BroadcastResearchViewModel.SpotRadioIsDirty = True

        End Sub
        Public Sub SetEthnicity(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, Ethnicity As Short)

            'objects
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing

            BroadcastResearchViewModel.SelectedResearchCriteria.Ethnicity = Ethnicity

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, BroadcastResearchViewModel.SelectedResearchCriteria.MarketCode)

            End Using

            BroadcastResearchViewModel.SelectedResearchCriteria.SetNielsenRadioMarketNumber(Market)

            BroadcastResearchViewModel.NielsenRadioBookList = New Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook)

            Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                BroadcastResearchViewModel.AvailableStationList = GetRadioStations(NielsenDbContext, BroadcastResearchViewModel, Nothing)

            End Using

            BroadcastResearchViewModel.SelectedStationList = New Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.Station)

            BroadcastResearchViewModel.SpotRadioIsDirty = True

        End Sub
        Public Sub SetIncludeTotalListeningSpotRadio(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, Checked As Boolean)

            BroadcastResearchViewModel.SelectedResearchCriteria.IncludeTotalListening = Checked

            BroadcastResearchViewModel.SpotRadioIsDirty = True

        End Sub
        Public Sub SetRadioReportType(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ReportType As Short)

            BroadcastResearchViewModel.SelectedResearchCriteria.ReportType = ReportType

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                BroadcastResearchViewModel.SelectedMetricList = New Generic.List(Of DTO.Media.Metric)

                If ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.AudienceComposition Then

                    BroadcastResearchViewModel.AvailableMetricList = (From Entity In AdvantageFramework.Database.Procedures.MediaMetric.LoadForRadioAudienceComposition(DbContext).ToList
                                                                      Select New AdvantageFramework.DTO.Media.Metric(Entity)).ToList

                    BroadcastResearchViewModel.SelectedResearchCriteria.NielsenRadioQualitativeID = 1
                    BroadcastResearchViewModel.SelectedResearchCriteria.ListeningType = AdvantageFramework.Database.Entities.NielsenRadioListeningLocation.Total

                Else

                    BroadcastResearchViewModel.AvailableMetricList = (From Entity In AdvantageFramework.Database.Procedures.MediaMetric.Load(DbContext).Where(Function(Entity) Entity.Type = "R" AndAlso
                                                                                                                                                                               Entity.ID <> AdvantageFramework.Database.Entities.MediaMetricID.StationShareOfCountyPercent AndAlso
                                                                                                                                                                               Entity.ID <> AdvantageFramework.Database.Entities.MediaMetricID.CountyShareOfStation).ToList
                                                                      Select New AdvantageFramework.DTO.Media.Metric(Entity)).ToList

                End If

            End Using

            BroadcastResearchViewModel.SpotRadioIsDirty = True

        End Sub
        Public Sub SetRadioMaxRank(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, MaxRank As Nullable(Of Short))

            BroadcastResearchViewModel.SelectedResearchCriteria.MaxRank = MaxRank

            BroadcastResearchViewModel.SpotRadioIsDirty = True

        End Sub
        Public Sub SetRadioSource(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, Source As AdvantageFramework.Nielsen.Database.Entities.RadioSource)

            'objects
            Dim SelectedMarketCode As String = Nothing

            BroadcastResearchViewModel.SelectedResearchCriteria.Source = Source

            If BroadcastResearchViewModel.SelectedResearchCriteria.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan Then

                BroadcastResearchViewModel.SelectedResearchCriteria.ShowSpill = False
                BroadcastResearchViewModel.SelectedResearchCriteria.ShowFormat = False
                BroadcastResearchViewModel.SelectedResearchCriteria.ShowFrequency = False

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                    LoadRadioMarketList(DbContext, NielsenDbContext, BroadcastResearchViewModel)

                End Using

            End Using

            SelectedMarketCode = BroadcastResearchViewModel.SelectedResearchCriteria.MarketCode

            If BroadcastResearchViewModel.RadioMarketList.Where(Function(ML) ML.Code = SelectedMarketCode).Any Then

                SetSpotRadioAvailableStations(BroadcastResearchViewModel, SelectedMarketCode, BroadcastResearchViewModel.SelectedResearchCriteria.ID)

            Else

                BroadcastResearchViewModel.SelectedResearchCriteria.MarketCode = Nothing

                BroadcastResearchViewModel.NielsenRadioBookList.Clear()

                BroadcastResearchViewModel.AvailableStationList.Clear()
                BroadcastResearchViewModel.SelectedStationList.Clear()

            End If

            BroadcastResearchViewModel.SpotRadioIsDirty = True

        End Sub
        Public Sub SetSelectedSpotRadioResearchCriteria(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ID As Integer)

            BroadcastResearchViewModel.SelectedResearchCriteria = BroadcastResearchViewModel.ResearchCriteriaList.Where(Function(Entity) Entity.ID = ID).SingleOrDefault

        End Sub
        Public Sub SetShowFormatSpotRadio(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, Checked As Boolean)

            BroadcastResearchViewModel.SelectedResearchCriteria.ShowFormat = Checked

            BroadcastResearchViewModel.SpotRadioIsDirty = True

        End Sub
        Public Sub SetShowFrequencySpotRadio(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, Checked As Boolean)

            BroadcastResearchViewModel.SelectedResearchCriteria.ShowFrequency = Checked

            BroadcastResearchViewModel.SpotRadioIsDirty = True

        End Sub
        Public Sub SetShowSpillSpotRadio(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, Checked As Boolean)

            BroadcastResearchViewModel.SelectedResearchCriteria.ShowSpill = Checked

            BroadcastResearchViewModel.SpotRadioIsDirty = True

        End Sub
        Public Sub SetSpotRadioDemographic(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, MediaDemoID As Integer)

            'objects
            Dim MediaDemographic As AdvantageFramework.Database.Entities.MediaDemographic = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaDemographic = AdvantageFramework.Database.Procedures.MediaDemographic.LoadByID(DbContext, MediaDemoID)

                If MediaDemographic IsNot Nothing AndAlso MediaDemographic.AgeFrom IsNot Nothing AndAlso MediaDemographic.AgeTo IsNot Nothing Then

                    If (MediaDemographic.AgeFrom.Value = 45 OrElse MediaDemographic.AgeFrom.Value = 21) OrElse
                            (MediaDemographic.AgeTo.Value = 44 OrElse MediaDemographic.AgeTo.Value = 20) Then

                        BroadcastResearchViewModel.SelectedResearchCriteria.NielsenRadioQualitativeID = 1
                        BroadcastResearchViewModel.SpotRadioQualitativeIsReadonly = True

                    Else

                        BroadcastResearchViewModel.SpotRadioQualitativeIsReadonly = False

                    End If

                Else

                    BroadcastResearchViewModel.SpotRadioQualitativeIsReadonly = False

                End If

            End Using

            BroadcastResearchViewModel.SelectedResearchCriteria.MediaDemoID = MediaDemoID

            BroadcastResearchViewModel.SpotRadioIsDirty = True

        End Sub
        Public Sub SetSpotRadioQualitative(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, NielsenRadioQualitativeID As Integer)

            BroadcastResearchViewModel.SelectedResearchCriteria.NielsenRadioQualitativeID = NielsenRadioQualitativeID

            LimitMetrics(BroadcastResearchViewModel, True)

            BroadcastResearchViewModel.SpotRadioIsDirty = True

        End Sub
        Public Sub SetSpotRadioAvailableStations(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, MarketCode As String, MediaSpotRadioResearchID As Nullable(Of Integer))

            'objects
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, MarketCode)

            End Using

            Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                BroadcastResearchViewModel.SelectedResearchCriteria.MarketCode = MarketCode

                BroadcastResearchViewModel.SelectedResearchCriteria.SetNielsenRadioMarketNumber(Market)

                BroadcastResearchViewModel.AvailableStationList = GetRadioStations(NielsenDbContext, BroadcastResearchViewModel, Nothing)

                BroadcastResearchViewModel.SelectedStationList = New Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.Station)

                BroadcastResearchViewModel.NielsenRadioBookList = New Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook)

                BroadcastResearchViewModel.SpotRadioReportDataTable = Nothing

                BroadcastResearchViewModel.SpotRadioIsDirty = True

            End Using

        End Sub
        Public Function ValidateBook(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                     NielsenRadioBook As AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim MediaSpotRadioResearchBook As AdvantageFramework.Database.Entities.MediaSpotRadioResearchBook = Nothing
            Dim DTOProperties As Generic.List(Of ComponentModel.PropertyDescriptor) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaSpotRadioResearchBook = New AdvantageFramework.Database.Entities.MediaSpotRadioResearchBook

                NielsenRadioBook.SaveToEntity(MediaSpotRadioResearchBook)

                MediaSpotRadioResearchBook.DbContext = DbContext

                ErrorText = MediaSpotRadioResearchBook.ValidateEntity(IsValid)

                If BroadcastResearchViewModel.NielsenRadioBookList.Where(Function(Entity) Entity.NielsenRadioPeriodID1 = NielsenRadioBook.NielsenRadioPeriodID1).Count > 1 Then

                    ErrorText += "Book 1 exists."
                    IsValid = False

                End If

                NielsenRadioBook.SetEntityError(ErrorText)

                DTOProperties = System.ComponentModel.TypeDescriptor.GetProperties(NielsenRadioBook.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(MediaSpotRadioResearchBook.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)()

                    If DTOProperties.Contains(PropertyDescriptor) Then

                        NielsenRadioBook.SetPropertyError(PropertyDescriptor.Name, MediaSpotRadioResearchBook.LoadErrorText(PropertyDescriptor.Name))

                    End If

                Next

            End Using

            ValidateBook = ErrorText

        End Function
        Public Function ValidateBookProperty(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                             NielsenRadioBook As AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim MediaSpotRadioResearchBook As AdvantageFramework.Database.Entities.MediaSpotRadioResearchBook = Nothing
            Dim NielsenRadioPeriodID As Integer = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaSpotRadioResearchBook = New AdvantageFramework.Database.Entities.MediaSpotRadioResearchBook

                NielsenRadioBook.SaveToEntity(MediaSpotRadioResearchBook)

                MediaSpotRadioResearchBook.DbContext = DbContext

                ErrorText = MediaSpotRadioResearchBook.ValidateEntityProperty(FieldName, IsValid, Value)

                If FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID1.ToString AndAlso Value IsNot Nothing Then

                    NielsenRadioPeriodID = DirectCast(Value, Integer)

                    If BroadcastResearchViewModel.NielsenRadioBookList.Where(Function(Entity) Entity.NielsenRadioPeriodID1 IsNot Nothing AndAlso Entity.NielsenRadioPeriodID1 = NielsenRadioPeriodID).Any Then

                        ErrorText += "Book 1 exists."
                        IsValid = False

                    End If

                End If

                NielsenRadioBook.SetPropertyError(FieldName, ErrorText)

            End Using

            ValidateBookProperty = ErrorText

        End Function
        Public Function ValidateDaypartEntity(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                              NielsenDaypart As AdvantageFramework.DTO.Media.NielsenDaypart, ByRef IsValid As Boolean) As String

            'objects
            Dim PropertyErrorText As String = String.Empty
            Dim ErrorText As String = String.Empty

            PropertyErrorText = Me.ValidateDaypartProperty(BroadcastResearchViewModel, NielsenDaypart, AdvantageFramework.DTO.Media.NielsenDaypart.Properties.ID.ToString, IsValid, NielsenDaypart.ID)

            ErrorText = IIf(ErrorText = "", PropertyErrorText, ErrorText & Environment.NewLine & PropertyErrorText)

            NielsenDaypart.SetEntityError(ErrorText)

            ValidateDaypartEntity = ErrorText

        End Function
        Public Function ValidateDaypartProperty(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                NielsenDaypart As AdvantageFramework.DTO.Media.NielsenDaypart, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty

            Select Case FieldName

                Case AdvantageFramework.DTO.Media.NielsenDaypart.Properties.ID.ToString

                    If NielsenDaypart.ID = 0 Then

                        IsValid = False

                        ErrorText = "Daypart is invalid."

                    ElseIf (From Entity In BroadcastResearchViewModel.NielsenDaypartList
                            Where Entity.ID = NielsenDaypart.ID AndAlso
                                  Entity.Guid <> NielsenDaypart.Guid
                            Select Entity.ID).Any Then

                        IsValid = False

                        ErrorText = "Duplicate daypart."

                    End If

            End Select

            NielsenDaypart.SetPropertyError(FieldName, ErrorText)

            ValidateDaypartProperty = ErrorText

        End Function
        Private Function FormatDescription(MediaMetricDescription As String) As String

            'objects
            Dim FormattedColumn As String = Nothing

            FormattedColumn = Replace(Replace(Replace(Replace(MediaMetricDescription, " ", ""), "(00)", ""), "%", "Percent"), "/", "")

            FormatDescription = FormattedColumn

        End Function
        Private Function CreateSpotRadioRankerReportDataTable(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                              MediaSpotRadioResearchMetricList As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpotRadioResearchMetric)) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim SortString As String = Nothing
            Dim RankDataTable As System.Data.DataTable = Nothing
            Dim DataRowRank As Nullable(Of Integer) = Nothing
            Dim StationNames As Generic.List(Of String) = Nothing
            Dim RankDataRow As System.Data.DataRow = Nothing
            Dim FirstMediaSpotRadioResearchDaypartID As Nullable(Of Integer) = Nothing

            DataTable = New System.Data.DataTable

            StationNames = New Generic.List(Of String)

            If BroadcastResearchViewModel.SelectedResearchCriteria.ShowSpill Then

                DataColumn = DataTable.Columns.Add("IsSpill")
                DataColumn.DataType = GetType(Boolean)

            End If

            DataColumn = DataTable.Columns.Add("StationName")
            DataColumn.DataType = GetType(String)

            If BroadcastResearchViewModel.SelectedResearchCriteria.ShowFormat Then

                DataColumn = DataTable.Columns.Add("StationFormat")
                DataColumn.DataType = GetType(String)

            End If

            If BroadcastResearchViewModel.SelectedResearchCriteria.ShowFrequency Then

                DataColumn = DataTable.Columns.Add("StationFrequency")
                DataColumn.DataType = GetType(String)

            End If

            For Each MediaSpotRadioResearchMetric In MediaSpotRadioResearchMetricList.OrderBy(Function(Entity) Entity.Order)

                SortString += If(String.IsNullOrWhiteSpace(SortString), FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & " DESC", ", " & FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & " DESC")

            Next

            For Each DP In (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                            Select Entity.NielsenRadioDaypartID, Entity.MediaSpotRadioResearchDaypartID).OrderBy(Function(Entity) Entity.MediaSpotRadioResearchDaypartID).Distinct.ToList

                DataColumn = DataTable.Columns.Add("Daypart" & DP.NielsenRadioDaypartID & "_" & DP.MediaSpotRadioResearchDaypartID)
                DataColumn.DataType = GetType(String)

                DataColumn = DataTable.Columns.Add("Rank" & DP.NielsenRadioDaypartID & "_" & DP.MediaSpotRadioResearchDaypartID)
                DataColumn.DataType = GetType(Integer)
                DataColumn.AllowDBNull = True

                For Each MediaSpotRadioResearchMetric In MediaSpotRadioResearchMetricList.OrderBy(Function(Entity) Entity.Order)

                    DataColumn = DataTable.Columns.Add(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DP.NielsenRadioDaypartID & "_" & DP.MediaSpotRadioResearchDaypartID)
                    DataColumn.DataType = GetType(Decimal)

                Next

            Next

            For Each ResearchResult In (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                        Select Entity.IsSpill, Entity.StationName, Entity.StationFormat, Entity.StationFrequency).Distinct.ToList

                DataRow = DataTable.NewRow

                If BroadcastResearchViewModel.SelectedResearchCriteria.ShowSpill Then

                    DataRow("IsSpill") = ResearchResult.IsSpill

                End If

                DataRow("StationName") = ResearchResult.StationName

                If BroadcastResearchViewModel.SelectedResearchCriteria.ShowFormat Then

                    DataRow("StationFormat") = ResearchResult.StationFormat

                End If

                If BroadcastResearchViewModel.SelectedResearchCriteria.ShowFrequency Then

                    DataRow("StationFrequency") = ResearchResult.StationFrequency

                End If

                For Each DaypartOrder In (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                          Where Entity.StationName = ResearchResult.StationName
                                          Select Entity.NielsenRadioDaypartID, Entity.MediaSpotRadioResearchDaypartID, Entity.Daypart).OrderBy(Function(Entity) Entity.MediaSpotRadioResearchDaypartID).Distinct.ToList

                    DataRow("Daypart" & DaypartOrder.NielsenRadioDaypartID & "_" & DaypartOrder.MediaSpotRadioResearchDaypartID) = DaypartOrder.Daypart

                    If Not FirstMediaSpotRadioResearchDaypartID.HasValue OrElse FirstMediaSpotRadioResearchDaypartID = DaypartOrder.MediaSpotRadioResearchDaypartID OrElse Not BroadcastResearchViewModel.SelectedResearchCriteria.MaxRank.HasValue Then

                        FirstMediaSpotRadioResearchDaypartID = DaypartOrder.MediaSpotRadioResearchDaypartID

                        'rank
                        RankDataTable = AdvantageFramework.Database.ToDataTable((From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                                 Where Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                                                                                 Select Entity).ToList)

                        RankDataTable.DefaultView.Sort = SortString

                        If MediaSpotRadioResearchMetricList IsNot Nothing AndAlso MediaSpotRadioResearchMetricList.Count > 0 Then

                            RankIt(RankDataTable, FormatDescription(MediaSpotRadioResearchMetricList.OrderBy(Function(Entity) Entity.Order).FirstOrDefault.MediaMetric.Description))

                        End If

                        If Not DataRowRank.HasValue Then

                            DataRowRank = RankDataTable.Select("StationName = '" & ResearchResult.StationName & "'").FirstOrDefault.Item("Rank")

                        End If

                        DataRow("Rank" & DaypartOrder.NielsenRadioDaypartID & "_" & DaypartOrder.MediaSpotRadioResearchDaypartID) = RankDataTable.Select("StationName = '" & ResearchResult.StationName & "'").FirstOrDefault.Item("Rank")

                    End If

                    For Each MediaSpotRadioResearchMetric In MediaSpotRadioResearchMetricList.OrderBy(Function(Entity) Entity.Order)

                        Select Case FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description)

                            Case "AQHRating"

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DaypartOrder.NielsenRadioDaypartID & "_" &
                                        DaypartOrder.MediaSpotRadioResearchDaypartID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                                         Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                               Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                                                                                         Select Entity).FirstOrDefault.AQHRating

                            Case "AQH"

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DaypartOrder.NielsenRadioDaypartID & "_" &
                                        DaypartOrder.MediaSpotRadioResearchDaypartID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                                         Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                               Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                                                                                         Select Entity).FirstOrDefault.AQH

                            Case "AQHShare"

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DaypartOrder.NielsenRadioDaypartID & "_" &
                                        DaypartOrder.MediaSpotRadioResearchDaypartID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                                         Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                               Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                                                                                         Select Entity).FirstOrDefault.AQHShare

                            Case "CumeRating"

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DaypartOrder.NielsenRadioDaypartID & "_" &
                                        DaypartOrder.MediaSpotRadioResearchDaypartID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                                         Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                               Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                                                                                         Select Entity).FirstOrDefault.CumeRating

                            Case "Cume"

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DaypartOrder.NielsenRadioDaypartID & "_" &
                                        DaypartOrder.MediaSpotRadioResearchDaypartID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                                         Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                               Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                                                                                         Select Entity).FirstOrDefault.Cume

                            'Case "CumeShare"

                            '    DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DaypartOrder.NielsenRadioDaypartID & "_" &
                            '            DaypartOrder.MediaSpotRadioResearchDaypartID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                            '                                                             Where Entity.StationName = ResearchResult.StationName AndAlso
                            '                                                                   Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                            '                                                             Select Entity).FirstOrDefault.CumeShare

                            Case "CumePercent"

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DaypartOrder.NielsenRadioDaypartID & "_" &
                                        DaypartOrder.MediaSpotRadioResearchDaypartID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                                         Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                               Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                                                                                         Select Entity).FirstOrDefault.CumePercent

                            Case "ExclusiveCume"

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DaypartOrder.NielsenRadioDaypartID & "_" &
                                        DaypartOrder.MediaSpotRadioResearchDaypartID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                                         Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                               Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                                                                                         Select Entity).FirstOrDefault.ExclusiveCume

                            Case "PUR"

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DaypartOrder.NielsenRadioDaypartID & "_" &
                                        DaypartOrder.MediaSpotRadioResearchDaypartID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                                         Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                               Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                                                                                         Select Entity).FirstOrDefault.PUR

                            Case "PURPercent"

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DaypartOrder.NielsenRadioDaypartID & "_" &
                                        DaypartOrder.MediaSpotRadioResearchDaypartID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                                         Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                               Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                                                                                         Select Entity).FirstOrDefault.PURPercent

                            Case "Population"

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DaypartOrder.NielsenRadioDaypartID & "_" &
                                        DaypartOrder.MediaSpotRadioResearchDaypartID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                                         Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                               Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                                                                                         Select Entity).FirstOrDefault.Population

                            Case "Intab"

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DaypartOrder.NielsenRadioDaypartID & "_" &
                                        DaypartOrder.MediaSpotRadioResearchDaypartID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                                         Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                               Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                                                                                         Select Entity).FirstOrDefault.Intab

                        End Select

                    Next

                Next

                If BroadcastResearchViewModel.SelectedResearchCriteria.MaxRank.HasValue Then

                    If DataRowRank IsNot Nothing AndAlso DataRowRank.Value <= BroadcastResearchViewModel.SelectedResearchCriteria.MaxRank Then

                        DataTable.Rows.Add(DataRow)

                        StationNames.Add(ResearchResult.StationName)

                    End If

                    DataRowRank = Nothing

                Else

                    DataTable.Rows.Add(DataRow)

                End If

            Next

            For Each StationName In StationNames

                For Each DaypartOrder In (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                          Where StationNames.Contains(Entity.StationName)
                                          Select Entity.NielsenRadioDaypartID, Entity.MediaSpotRadioResearchDaypartID, Entity.Daypart).OrderBy(Function(Entity) Entity.MediaSpotRadioResearchDaypartID).Distinct.ToList

                    'rank
                    RankDataTable = AdvantageFramework.Database.ToDataTable((From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                             Where Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID AndAlso
                                                                                   StationNames.Contains(Entity.StationName)
                                                                             Select Entity).ToList)

                    RankDataTable.DefaultView.Sort = SortString

                    If MediaSpotRadioResearchMetricList IsNot Nothing AndAlso MediaSpotRadioResearchMetricList.Count > 0 Then

                        RankIt(RankDataTable, FormatDescription(MediaSpotRadioResearchMetricList.OrderBy(Function(Entity) Entity.Order).FirstOrDefault.MediaMetric.Description))

                    End If

                    If DataTable.Select("StationName = '" & StationName & "'").FirstOrDefault IsNot Nothing Then

                        RankDataRow = DataTable.Select("StationName = '" & StationName & "'").FirstOrDefault

                        If RankDataTable.Select("StationName = '" & StationName & "'").FirstOrDefault IsNot Nothing Then

                            RankDataRow("Rank" & DaypartOrder.NielsenRadioDaypartID & "_" & DaypartOrder.MediaSpotRadioResearchDaypartID) = RankDataTable.Select("StationName = '" & StationName & "'").FirstOrDefault.Item("Rank")

                        Else

                            RankDataRow("Rank" & DaypartOrder.NielsenRadioDaypartID & "_" & DaypartOrder.MediaSpotRadioResearchDaypartID) = System.DBNull.Value

                        End If

                    End If

                Next

            Next

            CreateSpotRadioRankerReportDataTable = DataTable

        End Function
        Private Function CreateSpotRadioTrendReportDataTable(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                             MediaSpotRadioResearchMetricList As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpotRadioResearchMetric)) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            DataTable = New System.Data.DataTable

            If BroadcastResearchViewModel.SelectedResearchCriteria.ShowSpill Then

                DataColumn = DataTable.Columns.Add("IsSpill")
                DataColumn.DataType = GetType(Boolean)

            End If

            DataColumn = DataTable.Columns.Add("StationName")
            DataColumn.DataType = GetType(String)

            If BroadcastResearchViewModel.SelectedResearchCriteria.ShowFormat Then

                DataColumn = DataTable.Columns.Add("StationFormat")
                DataColumn.DataType = GetType(String)

            End If

            If BroadcastResearchViewModel.SelectedResearchCriteria.ShowFrequency Then

                DataColumn = DataTable.Columns.Add("StationFrequency")
                DataColumn.DataType = GetType(String)

            End If

            DataColumn = DataTable.Columns.Add("MetricName")
            DataColumn.DataType = GetType(String)

            For Each Book In (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                              Select Entity.BookID, Entity.Books, Entity.TrendBookOrder).Distinct.OrderBy(Function(Entity) Entity.TrendBookOrder).ToList

                DataColumn = DataTable.Columns.Add("BookMetric" & Book.BookID)
                DataColumn.DataType = GetType(Decimal)

            Next

            For Each ResearchResult In (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                        Select Entity.IsSpill, Entity.StationName, Entity.StationFormat, Entity.StationFrequency).Distinct.ToList

                For Each MediaSpotTVResearchMetric In MediaSpotRadioResearchMetricList.OrderBy(Function(Entity) Entity.Order)

                    DataRow = DataTable.NewRow

                    If BroadcastResearchViewModel.SelectedResearchCriteria.ShowSpill Then

                        DataRow("IsSpill") = ResearchResult.IsSpill

                    End If

                    DataRow("StationName") = ResearchResult.StationName

                    If BroadcastResearchViewModel.SelectedResearchCriteria.ShowFormat Then

                        DataRow("StationFormat") = ResearchResult.StationFormat

                    End If

                    If BroadcastResearchViewModel.SelectedResearchCriteria.ShowFrequency Then

                        DataRow("StationFrequency") = ResearchResult.StationFrequency

                    End If

                    DataRow("MetricName") = MediaSpotTVResearchMetric.MediaMetric.Description

                    For Each Book In (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                      Select Entity.BookID, Entity.Books, Entity.TrendBookOrder).Distinct.OrderBy(Function(Entity) Entity.TrendBookOrder).ToList

                        If (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                            Where Entity.StationName = ResearchResult.StationName AndAlso
                                  Entity.BookID = Book.BookID
                            Select Entity).FirstOrDefault IsNot Nothing Then

                            Select Case DataRow("MetricName")

                                Case "AQH Rating"

                                    DataRow("BookMetric" & Book.BookID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                           Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                 Entity.BookID = Book.BookID
                                                                           Select Entity).FirstOrDefault.AQHRating

                                Case "AQH (00)"

                                    DataRow("BookMetric" & Book.BookID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                           Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                 Entity.BookID = Book.BookID
                                                                           Select Entity).FirstOrDefault.AQH

                                Case "AQH Share"

                                    DataRow("BookMetric" & Book.BookID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                           Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                 Entity.BookID = Book.BookID
                                                                           Select Entity).FirstOrDefault.AQHShare

                                Case "Cume Rating"

                                    DataRow("BookMetric" & Book.BookID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                           Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                 Entity.BookID = Book.BookID
                                                                           Select Entity).FirstOrDefault.CumeRating

                                Case "Cume (00)"

                                    DataRow("BookMetric" & Book.BookID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                           Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                 Entity.BookID = Book.BookID
                                                                           Select Entity).FirstOrDefault.Cume

                                Case "Cume %"

                                    DataRow("BookMetric" & Book.BookID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                           Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                 Entity.BookID = Book.BookID
                                                                           Select Entity).FirstOrDefault.CumePercent

                                Case "Exclusive Cume (00)"

                                    DataRow("BookMetric" & Book.BookID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                           Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                 Entity.BookID = Book.BookID
                                                                           Select Entity).FirstOrDefault.ExclusiveCume

                                Case "PUR (00)"

                                    DataRow("BookMetric" & Book.BookID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                           Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                 Entity.BookID = Book.BookID
                                                                           Select Entity).FirstOrDefault.PUR

                                Case "PUR %"

                                    DataRow("BookMetric" & Book.BookID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                           Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                 Entity.BookID = Book.BookID
                                                                           Select Entity).FirstOrDefault.PURPercent

                                Case "Population (00)"

                                    DataRow("BookMetric" & Book.BookID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                           Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                 Entity.BookID = Book.BookID
                                                                           Select Entity).FirstOrDefault.Population

                                Case "Intab"

                                    DataRow("BookMetric" & Book.BookID) = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                                                                           Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                 Entity.BookID = Book.BookID
                                                                           Select Entity).FirstOrDefault.Intab

                            End Select

                        End If

                    Next

                    DataTable.Rows.Add(DataRow)

                Next

            Next

            CreateSpotRadioTrendReportDataTable = DataTable

        End Function
        Private Function CreateSpotRadioAudienceCompositionReportDataTable(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                                           MediaSpotRadioResearchMetricList As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpotRadioResearchMetric)) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim SortString As String = Nothing
            Dim RankDataTable As System.Data.DataTable = Nothing
            Dim PrimaryFieldName As String = Nothing
            Dim DataView As System.Data.DataView = Nothing
            Dim ColumnNames As Generic.List(Of String) = Nothing
            Dim PrimaryKeys(0) As System.Data.DataColumn
            Dim DataRowKey As System.Data.DataRow = Nothing

            ColumnNames = New Generic.List(Of String)
            ColumnNames.Add("StationName")
            ColumnNames.Add("Rank")

            DataTable = New System.Data.DataTable

            If BroadcastResearchViewModel.SelectedResearchCriteria.ShowSpill Then

                DataColumn = DataTable.Columns.Add("IsSpill")
                DataColumn.DataType = GetType(Boolean)

            End If

            DataColumn = DataTable.Columns.Add("StationName")
            DataColumn.DataType = GetType(String)
            PrimaryKeys(0) = DataColumn

            DataTable.PrimaryKey = PrimaryKeys

            If BroadcastResearchViewModel.SelectedResearchCriteria.ShowFormat Then

                DataColumn = DataTable.Columns.Add("StationFormat")
                DataColumn.DataType = GetType(String)

            End If

            If BroadcastResearchViewModel.SelectedResearchCriteria.ShowFrequency Then

                DataColumn = DataTable.Columns.Add("StationFrequency")
                DataColumn.DataType = GetType(String)

            End If

            DataColumn = DataTable.Columns.Add("Rank")
            DataColumn.DataType = GetType(Int64)

            DataColumn = DataTable.Columns.Add("Demographic")
            DataColumn.DataType = GetType(String)

            For Each MediaSpotRadioResearchMetric In MediaSpotRadioResearchMetricList.OrderBy(Function(Entity) Entity.Order)

                If MediaSpotRadioResearchMetric.MediaMetricID = Database.Entities.Methods.MediaMetricID.AQH Then

                    ColumnNames.Add("TotalAQH")

                    DataColumn = DataTable.Columns.Add("TotalAQH")
                    DataColumn.DataType = GetType(Int64)

                    SortString += If(String.IsNullOrWhiteSpace(SortString), "TotalAQH DESC", ", " & "TotalAQH DESC")

                    If PrimaryFieldName Is Nothing Then

                        PrimaryFieldName = "TotalAQH"

                    End If

                ElseIf MediaSpotRadioResearchMetric.MediaMetricID = Database.Entities.Methods.MediaMetricID.Cume Then

                    ColumnNames.Add("TotalCume")

                    DataColumn = DataTable.Columns.Add("TotalCume")
                    DataColumn.DataType = GetType(Int64)

                    SortString += If(String.IsNullOrWhiteSpace(SortString), "TotalCume DESC", ", " & "TotalCume DESC")

                    If PrimaryFieldName Is Nothing Then

                        PrimaryFieldName = "TotalCume"

                    End If

                ElseIf MediaSpotRadioResearchMetric.MediaMetricID = Database.Entities.Methods.MediaMetricID.ExclusiveCume Then

                    ColumnNames.Add("TotalExclusiveCume")

                    DataColumn = DataTable.Columns.Add("TotalExclusiveCume")
                    DataColumn.DataType = GetType(Int64)

                    SortString += If(String.IsNullOrWhiteSpace(SortString), "TotalExclusiveCume DESC", ", " & "TotalExclusiveCume DESC")

                    If PrimaryFieldName Is Nothing Then

                        PrimaryFieldName = "TotalExclusiveCume"

                    End If

                End If

            Next

            For Each Display In (From Entity In BroadcastResearchViewModel.SpotRadioAudienceCompositionList
                                 Select Entity.DisplayBy).OrderBy(Function(Entity) Entity.ToString).Distinct.ToList

                DataColumn = DataTable.Columns.Add("DisplayBy" & "_" & Display.ToString)
                DataColumn.DataType = GetType(String)

                For Each MediaSpotRadioResearchMetric In MediaSpotRadioResearchMetricList.OrderBy(Function(Entity) Entity.Order)

                    DataColumn = DataTable.Columns.Add(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & Display.ToString)
                    DataColumn.DataType = GetType(Decimal)

                    If MediaSpotRadioResearchMetric.MediaMetricID = Database.Entities.Methods.MediaMetricID.AQH Then

                        DataColumn = DataTable.Columns.Add("AQHPercent" & "_" & Display.ToString)
                        DataColumn.DataType = GetType(Decimal)

                    ElseIf MediaSpotRadioResearchMetric.MediaMetricID = Database.Entities.Methods.MediaMetricID.Cume Then

                        DataColumn = DataTable.Columns.Add("CumePercent" & "_" & Display.ToString)
                        DataColumn.DataType = GetType(Decimal)

                    ElseIf MediaSpotRadioResearchMetric.MediaMetricID = Database.Entities.Methods.MediaMetricID.ExclusiveCume Then

                        DataColumn = DataTable.Columns.Add("ExclusiveCumePercent" & "_" & Display.ToString)
                        DataColumn.DataType = GetType(Decimal)

                    End If

                Next

            Next

            For Each ResearchResult In (From Entity In BroadcastResearchViewModel.SpotRadioAudienceCompositionList
                                        Select Entity.IsSpill, Entity.StationName, Entity.StationFormat, Entity.StationFrequency).Distinct.ToList

                DataRow = DataTable.NewRow

                If BroadcastResearchViewModel.SelectedResearchCriteria.ShowSpill Then

                    DataRow("IsSpill") = ResearchResult.IsSpill

                End If

                DataRow("StationName") = ResearchResult.StationName

                If BroadcastResearchViewModel.SelectedResearchCriteria.ShowFormat Then

                    DataRow("StationFormat") = ResearchResult.StationFormat

                End If

                If BroadcastResearchViewModel.SelectedResearchCriteria.ShowFrequency Then

                    DataRow("StationFrequency") = ResearchResult.StationFrequency

                End If

                If DataTable.Columns.Item("TotalAQH") IsNot Nothing Then

                    DataRow("TotalAQH") = (From Entity In BroadcastResearchViewModel.SpotRadioAudienceCompositionList
                                           Where Entity.StationName = ResearchResult.StationName
                                           Select Entity.AQH).Sum

                End If

                If DataTable.Columns.Item("TotalCume") IsNot Nothing Then

                    DataRow("TotalCume") = (From Entity In BroadcastResearchViewModel.SpotRadioAudienceCompositionList
                                            Where Entity.StationName = ResearchResult.StationName
                                            Select Entity.Cume).Sum

                End If

                If DataTable.Columns.Item("TotalExclusiveCume") IsNot Nothing Then

                    DataRow("TotalExclusiveCume") = (From Entity In BroadcastResearchViewModel.SpotRadioAudienceCompositionList
                                                     Where Entity.StationName = ResearchResult.StationName
                                                     Select Entity.ExclusiveCume).Sum

                End If

                For Each DisplayOrder In (From Entity In BroadcastResearchViewModel.SpotRadioAudienceCompositionList
                                          Where Entity.StationName = ResearchResult.StationName
                                          Select Entity.DisplayBy, Entity.AgeFrom).OrderBy(Function(Entity) Entity.AgeFrom).ThenBy(Function(Entity) Entity.DisplayBy).Distinct.ToList

                    DataRow("DisplayBy" & "_" & DisplayOrder.DisplayBy) = DisplayOrder.DisplayBy

                    For Each MediaSpotRadioResearchMetric In MediaSpotRadioResearchMetricList.OrderBy(Function(Entity) Entity.Order)

                        Select Case FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description)

                            Case "AQH"

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) &
                                        "_" & DisplayOrder.DisplayBy) = (From Entity In BroadcastResearchViewModel.SpotRadioAudienceCompositionList
                                                                         Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                               Entity.DisplayBy = DisplayOrder.DisplayBy
                                                                         Select Entity).FirstOrDefault.AQH

                                If DataRow("TotalAQH") = 0 Then

                                    DataRow("AQHPercent" & "_" & DisplayOrder.DisplayBy) = 0

                                Else

                                    DataRow("AQHPercent" & "_" & DisplayOrder.DisplayBy) = FormatNumber(DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DisplayOrder.DisplayBy) / DataRow("TotalAQH") * 100, 0)

                                End If

                            Case "Cume"

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) &
                                        "_" & DisplayOrder.DisplayBy) = (From Entity In BroadcastResearchViewModel.SpotRadioAudienceCompositionList
                                                                         Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                               Entity.DisplayBy = DisplayOrder.DisplayBy
                                                                         Select Entity).FirstOrDefault.Cume

                                If DataRow("TotalCume") = 0 Then

                                    DataRow("CumePercent" & "_" & DisplayOrder.DisplayBy) = 0

                                Else

                                    DataRow("CumePercent" & "_" & DisplayOrder.DisplayBy) = FormatNumber(DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DisplayOrder.DisplayBy) / DataRow("TotalCume") * 100, 0)

                                End If

                            Case "ExclusiveCume"

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) &
                                        "_" & DisplayOrder.DisplayBy) = (From Entity In BroadcastResearchViewModel.SpotRadioAudienceCompositionList
                                                                         Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                               Entity.DisplayBy = DisplayOrder.DisplayBy
                                                                         Select Entity).FirstOrDefault.ExclusiveCume

                                If DataRow("TotalExclusiveCume") = 0 Then

                                    DataRow("ExclusiveCumePercent" & "_" & DisplayOrder.DisplayBy) = 0

                                Else

                                    DataRow("ExclusiveCumePercent" & "_" & DisplayOrder.DisplayBy) = FormatNumber(DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DisplayOrder.DisplayBy) / DataRow("TotalExclusiveCume") * 100, 0)

                                End If

                        End Select

                    Next

                Next

                DataTable.Rows.Add(DataRow)

            Next

            'rank
            DataView = New DataView(DataTable)

            RankDataTable = DataView.ToTable(True, ColumnNames.ToArray)

            RankDataTable.DefaultView.Sort = SortString

            If MediaSpotRadioResearchMetricList IsNot Nothing AndAlso MediaSpotRadioResearchMetricList.Count > 0 Then

                RankIt(RankDataTable, PrimaryFieldName)

            End If

            For Each ResearchResult In (From Entity In BroadcastResearchViewModel.SpotRadioAudienceCompositionList
                                        Select Entity.StationName).Distinct.ToList

                DataRowKey = DataTable.Rows.Find(ResearchResult.ToString)

                If DataRowKey IsNot Nothing Then

                    DataRowKey("Rank") = RankDataTable.Select("StationName = '" & ResearchResult.ToString & "'").FirstOrDefault.Item("Rank")

                End If

            Next

            CreateSpotRadioAudienceCompositionReportDataTable = DataTable

        End Function
        Public Sub SetAudienceCompositionDisplayBy(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                   DisplayBy As Integer)

            BroadcastResearchViewModel.SelectedResearchCriteria.DisplayByValue = DisplayBy

        End Sub
        Private Sub LoadRadioMarketList(DbContext As AdvantageFramework.Database.DbContext, NielsenDbContext As AdvantageFramework.Nielsen.Database.DbContext, ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            'objects
            Dim NielsenMarketNumbers As IEnumerable(Of Integer) = Nothing

            If BroadcastResearchViewModel.SelectedResearchCriteria.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                    NielsenMarketNumbers = NielsenDbContext.Database.SqlQuery(Of Integer)(String.Format("EXEC advsp_hosted_spotradio_get_market_numbers '{0}'", Session.NielsenClientCodeForHosted)).ToList

                Else

                    NielsenMarketNumbers = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadValidated(NielsenDbContext)
                                            Where Entity.Source = Nielsen.Database.Entities.Methods.RadioSource.Nielsen
                                            Select Entity.NielsenRadioMarketNumber).Distinct.ToArray

                End If

                BroadcastResearchViewModel.RadioMarketList = (From Entity In AdvantageFramework.Database.Procedures.Market.LoadAllActiveSpotRadio(DbContext).Where(Function(Entity) NielsenMarketNumbers.Contains(CInt(Entity.NielsenRadioCode)) OrElse
                                                                                                                                                                                    (Entity.NielsenBlackRadioCode IsNot Nothing AndAlso NielsenMarketNumbers.Contains(CInt(Entity.NielsenBlackRadioCode))) OrElse
                                                                                                                                                                                    (Entity.NielsenHispanicRadioCode IsNot Nothing AndAlso NielsenMarketNumbers.Contains(CInt(Entity.NielsenHispanicRadioCode)))).ToList
                                                              Select New AdvantageFramework.DTO.Market(Entity)).ToList

            ElseIf BroadcastResearchViewModel.SelectedResearchCriteria.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan Then

                NielsenMarketNumbers = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadValidated(NielsenDbContext)
                                        Where Entity.Source = Nielsen.Database.Entities.RadioSource.Eastlan
                                        Select Entity.NielsenRadioMarketNumber).Distinct.ToArray

                BroadcastResearchViewModel.RadioMarketList = (From Entity In AdvantageFramework.Database.Procedures.Market.LoadAllActiveEastlanRadio(DbContext).Where(Function(Entity) NielsenMarketNumbers.Contains(Entity.EastlanRadioCode) OrElse
                                                                                                                                                                                       (Entity.EastlanBlackRadioCode IsNot Nothing AndAlso NielsenMarketNumbers.Contains(Entity.NielsenBlackRadioCode)) OrElse
                                                                                                                                                                                       (Entity.EastlanHispanicRadioCode IsNot Nothing AndAlso NielsenMarketNumbers.Contains(Entity.NielsenHispanicRadioCode))).ToList
                                                              Select New AdvantageFramework.DTO.Market(Entity)).ToList

            End If

        End Sub

#End Region

#Region " Spot Radio County "

        Public Function SpotRadioCounty_Load(ResearchID As Integer?) As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel

            'objects
            Dim BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel = Nothing
            Dim StationNames As Generic.List(Of String) = Nothing
            Dim SelectedMediaDemoIDs As IEnumerable(Of Integer) = Nothing
            Dim SelectedMediaMetricIDs As IEnumerable(Of Integer) = Nothing
            Dim Dashboard As AdvantageFramework.Database.Entities.Dashboard = Nothing

            BroadcastResearchViewModel = New AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel

            BroadcastResearchViewModel.SelectedResearchTab = ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadioCounty

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        BroadcastResearchViewModel.SpotRadioCountyAddEnabled = True

                        BroadcastResearchViewModel.SpotRadioCountyResearchCriteriaList = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotRadioCountyResearch.Load(DbContext).ToList
                                                                                          Select New AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchCriteria(Entity)).ToList

                        If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                            BroadcastResearchViewModel.SpotRadioCountyList = NielsenDbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.SpotRadioCounty.County)(String.Format("EXEC advsp_hosted_spotradio_nielsen_get_counties '{0}'", Session.NielsenClientCodeForHosted)).ToList

                        Else

                            BroadcastResearchViewModel.SpotRadioCountyList = NielsenDbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.SpotRadioCounty.County)("EXEC advsp_spotradiocounty_get_counties").ToList

                        End If

                        BroadcastResearchViewModel.SpotRadioCountyYearList = New Generic.List(Of DTO.Media.SpotRadioCounty.Year)

                        BroadcastResearchViewModel.SpotRadioCountyYearRepository.AddRange(From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyPeriod.LoadDistinctYears(NielsenDbContext).ToList
                                                                                          Select New AdvantageFramework.DTO.ComboBoxItem(Entity, Entity))

                        If ResearchID.HasValue Then

                            BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria = BroadcastResearchViewModel.SpotRadioCountyResearchCriteriaList.Where(Function(Entity) Entity.ID = ResearchID.Value).SingleOrDefault

                            StationNames = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotRadioCountyResearchStation.LoadByMediaSpotRadioCountyResearchID(DbContext, ResearchID.Value).ToList
                                            Select Entity.CallLetters & "-" & Entity.Band).ToList

                            If BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.CountyCode.HasValue Then

                                SpotRadioCounty_SetAvailableWeightingFlags(BroadcastResearchViewModel, NielsenDbContext)

                            End If

                            If AdvantageFramework.Database.Procedures.MediaSpotRadioCountyResearchYear.LoadByMediaSpotRadioCountyResearchID(DbContext, ResearchID.Value).Any Then

                                BroadcastResearchViewModel.SpotRadioCountyYearList = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotRadioCountyResearchYear.LoadByMediaSpotRadioCountyResearchID(DbContext, ResearchID.Value).ToList
                                                                                      Select New AdvantageFramework.DTO.Media.SpotRadioCounty.Year(Entity)).ToList

                                SpotRadioCounty_SetAvailableStations(BroadcastResearchViewModel)

                                BroadcastResearchViewModel.SpotRadioCountyAvailableStationList = (From Entity In BroadcastResearchViewModel.SpotRadioCountyAvailableStationList
                                                                                                  Where StationNames.Contains(Entity.Name) = False
                                                                                                  Select Entity).ToList

                                BroadcastResearchViewModel.SpotRadioCountySelectedStationList.AddRange(From S In (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyStation.LoadByNielsenRadioCountyStationNames(NielsenDbContext, StationNames)
                                                                                                                  Select New With {.CallLetters = Entity.CallLetters,
                                                                                                                                   .Band = Entity.Band,
                                                                                                                                   .Frequecy = Entity.Frequency}).Distinct.ToList
                                                                                                       Select New AdvantageFramework.DTO.Media.SpotRadioCounty.Station(S.CallLetters, S.Band, S.Frequecy))

                            End If

                            BroadcastResearchViewModel.SpotRadioCountySelectedMetricList = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotRadioCountyResearchMetric.LoadByMediaSpotRadioCountyResearchID(DbContext, ResearchID.Value).OrderBy(Function(Entity) Entity.Order).ToList
                                                                                            Select New AdvantageFramework.DTO.Media.Metric(Entity)).ToList

                            SelectedMediaMetricIDs = (From Entity In BroadcastResearchViewModel.SpotRadioCountySelectedMetricList
                                                      Select Entity.ID).ToArray

                            BroadcastResearchViewModel.SpotRadioCountyAvailableMetricList = (From Entity In AdvantageFramework.Database.Procedures.MediaMetric.Load(DbContext).Where(Function(Entity) SelectedMediaMetricIDs.Contains(Entity.ID) = False AndAlso
                                                                                                                                                                                     Entity.Type = "R" AndAlso
                                                                                                                                                                                     Entity.ID <> AdvantageFramework.Database.Entities.MediaMetricID.AQHShare AndAlso
                                                                                                                                                                                     Entity.ID <> AdvantageFramework.Database.Entities.MediaMetricID.ExclusiveCume AndAlso
                                                                                                                                                                                     Entity.ID <> AdvantageFramework.Database.Entities.MediaMetricID.PUR AndAlso
                                                                                                                                                                                     Entity.ID <> AdvantageFramework.Database.Entities.MediaMetricID.PURPercent).ToList
                                                                                             Select New AdvantageFramework.DTO.Media.Metric(Entity)).ToList

                        Else

                            BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria = Nothing

                        End If

                        BroadcastResearchViewModel.SpotRadioCountyMediaDemographicList = (From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.LoadActiveRadioCounty(DbContext).ToList
                                                                                          Select New AdvantageFramework.DTO.Media.MediaDemographic(Entity)).OrderBy(Function(DTO) DTO.Description).ToList

                        BroadcastResearchViewModel.SpotRadioCountyResearchReportTypeList = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.SpotRadioCountyResearchReportType))
                                                                                            Select New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

                        Dashboard = AdvantageFramework.Database.Procedures.Dashboard.LoadByDashboardType(DbContext, AdvantageFramework.Database.Entities.DashboardTypes.BroadcastResearchTool_RadioCounty)

                        If Dashboard IsNot Nothing Then

                            BroadcastResearchViewModel.Dashboard = New AdvantageFramework.DTO.Dashboard(Dashboard)

                        Else

                            BroadcastResearchViewModel.Dashboard = New AdvantageFramework.DTO.Dashboard

                        End If

                    End Using

                End Using

            End Using

            BroadcastResearchViewModel.SpotRadioCountyReportDataTable = Nothing

            SpotRadioCounty_Load = BroadcastResearchViewModel

        End Function
        Public Function SpotRadioCounty_Save(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim MediaSpotRadioCountyResearch As AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearch = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MediaSpotRadioCountyResearchMetric As AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearchMetric = Nothing
            Dim MediaSpotRadioCountyResearchStation As AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearchStation = Nothing
            Dim MediaSpotRadioCountyResearchYear As AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearchYear = Nothing
            Dim Order As Integer = 0
            Dim Saved As Boolean = False

            If SpotRadioCounty_RequiredDataPresent(BroadcastResearchViewModel, ErrorMessage) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    MediaSpotRadioCountyResearch = AdvantageFramework.Database.Procedures.MediaSpotRadioCountyResearch.LoadByID(DbContext, BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.ID)

                    If MediaSpotRadioCountyResearch IsNot Nothing Then

                        BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.SaveToEntity(MediaSpotRadioCountyResearch)

                        Try

                            DbContext.Database.Connection.Open()

                            DbTransaction = DbContext.Database.BeginTransaction

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_RADIO_COUNTY_RESEARCH_METRIC WHERE MEDIA_SPOT_RADIO_COUNTY_RESEARCH_ID = {0}", MediaSpotRadioCountyResearch.ID))
                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_RADIO_COUNTY_RESEARCH_STATION WHERE MEDIA_SPOT_RADIO_COUNTY_RESEARCH_ID = {0}", MediaSpotRadioCountyResearch.ID))
                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_RADIO_COUNTY_RESEARCH_YEAR WHERE MEDIA_SPOT_RADIO_COUNTY_RESEARCH_ID = {0}", MediaSpotRadioCountyResearch.ID))

                            For Each SpotRadioCountyYear In BroadcastResearchViewModel.SpotRadioCountyYearList

                                MediaSpotRadioCountyResearchYear = New AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearchYear
                                MediaSpotRadioCountyResearchYear.DbContext = DbContext

                                MediaSpotRadioCountyResearchYear.MediaSpotRadioCountyResearchID = MediaSpotRadioCountyResearch.ID
                                MediaSpotRadioCountyResearchYear.Year1 = SpotRadioCountyYear.Year1
                                MediaSpotRadioCountyResearchYear.Year2 = SpotRadioCountyYear.Year2
                                MediaSpotRadioCountyResearchYear.Year3 = SpotRadioCountyYear.Year3
                                MediaSpotRadioCountyResearchYear.Year4 = SpotRadioCountyYear.Year4
                                MediaSpotRadioCountyResearchYear.Year5 = SpotRadioCountyYear.Year5

                                DbContext.MediaSpotRadioCountyResearchYears.Add(MediaSpotRadioCountyResearchYear)

                            Next

                            For Each Station In BroadcastResearchViewModel.SpotRadioCountySelectedStationList

                                MediaSpotRadioCountyResearchStation = New AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearchStation
                                MediaSpotRadioCountyResearchStation.DbContext = DbContext

                                MediaSpotRadioCountyResearchStation.MediaSpotRadioCountyResearchID = MediaSpotRadioCountyResearch.ID
                                MediaSpotRadioCountyResearchStation.CallLetters = Station.CallLetters
                                MediaSpotRadioCountyResearchStation.Band = Station.Band

                                DbContext.MediaSpotRadioCountyResearchStations.Add(MediaSpotRadioCountyResearchStation)

                            Next

                            Order = 1

                            For Each Metric In BroadcastResearchViewModel.SpotRadioCountySelectedMetricList

                                MediaSpotRadioCountyResearchMetric = New AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearchMetric
                                MediaSpotRadioCountyResearchMetric.DbContext = DbContext

                                MediaSpotRadioCountyResearchMetric.MediaSpotRadioCountyResearchID = MediaSpotRadioCountyResearch.ID
                                MediaSpotRadioCountyResearchMetric.Order = Order
                                MediaSpotRadioCountyResearchMetric.MediaMetricID = Metric.ID

                                DbContext.MediaSpotRadioCountyResearchMetrics.Add(MediaSpotRadioCountyResearchMetric)

                                Order += 1

                            Next

                            DbContext.SaveChanges()

                            If AdvantageFramework.Database.Procedures.MediaSpotRadioCountyResearch.Update(DbContext, MediaSpotRadioCountyResearch, ErrorMessage) = False Then

                                Throw New Exception(ErrorMessage)

                            End If

                            DbTransaction.Commit()

                            Saved = True

                            BroadcastResearchViewModel.SpotRadioCountyIsDirty = False
                            BroadcastResearchViewModel.SpotRadioCountyResearchResultList = Nothing
                            BroadcastResearchViewModel.SpotRadioCountyReportDataTable = Nothing

                        Catch ex As Exception
                            ErrorMessage = ex.Message
                        Finally

                            If DbContext.Database.Connection.State = ConnectionState.Open Then

                                DbContext.Database.Connection.Close()

                            End If

                        End Try

                    Else

                        ErrorMessage = "This research criteria is no longer valid in the system."

                    End If

                End Using

            End If

            SpotRadioCounty_Save = Saved

        End Function
        Public Function SpotRadioCounty_Delete(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ByRef ErrorMessage As String) As Boolean

            'objects 
            Dim Deleted As Boolean = True
            Dim MediaSpotRadioCountyResearch As AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearch = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaSpotRadioCountyResearch = AdvantageFramework.Database.Procedures.MediaSpotRadioCountyResearch.LoadByID(DbContext, BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.ID)

                If MediaSpotRadioCountyResearch IsNot Nothing Then

                    Deleted = AdvantageFramework.Database.Procedures.MediaSpotRadioCountyResearch.Delete(DbContext, MediaSpotRadioCountyResearch, ErrorMessage)

                End If

            End Using

            SpotRadioCounty_Delete = Deleted

        End Function
        Private Function SpotRadioCounty_RequiredDataPresent(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                             ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsPresent As Boolean = False

            ErrorMessage = String.Empty

            If BroadcastResearchViewModel.SpotRadioCountyYearList Is Nothing OrElse BroadcastResearchViewModel.SpotRadioCountyYearList.Count = 0 Then

                ErrorMessage += vbCrLf & "At least one year must be selected."

            ElseIf BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioCountyResearchReportType.Ranker AndAlso
                    (BroadcastResearchViewModel.SpotRadioCountyYearList Is Nothing OrElse BroadcastResearchViewModel.SpotRadioCountyYearList.Count > 1) Then

                ErrorMessage += vbCrLf & "Only one set of books can be selected for a ranker report."

            End If

            If BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.Daypart68 = False AndAlso BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.Daypart84 = False Then

                ErrorMessage += vbCrLf & "At least one daypart must be selected."

            ElseIf BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioCountyResearchReportType.Trend AndAlso
                    BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.Daypart68 AndAlso BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.Daypart84 Then

                ErrorMessage += vbCrLf & "Only one daypart can be selected for a trend report."

            End If

            If BroadcastResearchViewModel.SpotRadioCountySelectedStationList Is Nothing OrElse BroadcastResearchViewModel.SpotRadioCountySelectedStationList.Count = 0 Then

                ErrorMessage += vbCrLf & "At least one station must be selected."

            End If

            If BroadcastResearchViewModel.SpotRadioCountySelectedMetricList Is Nothing OrElse BroadcastResearchViewModel.SpotRadioCountySelectedMetricList.Count = 0 Then

                ErrorMessage += vbCrLf & "At least one metric must be selected."

            End If

            If String.IsNullOrWhiteSpace(ErrorMessage) Then

                IsPresent = True

            End If

            SpotRadioCounty_RequiredDataPresent = IsPresent

        End Function
        Public Sub SpotRadioCounty_SetShowFrequency(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, Checked As Boolean)

            BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.ShowFrequency = Checked

            BroadcastResearchViewModel.SpotRadioCountyIsDirty = True

        End Sub
        Public Sub SpotRadioCounty_SetMaxRank(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, MaxRank As Nullable(Of Short))

            BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.MaxRank = MaxRank

            BroadcastResearchViewModel.SpotRadioCountyIsDirty = True

        End Sub
        Public Sub SpotRadioCounty_SetDaypart68(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, Checked As Boolean)

            BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.Daypart68 = Checked

            BroadcastResearchViewModel.SpotRadioCountyIsDirty = True

        End Sub
        Public Sub SpotRadioCounty_SetDaypart84(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, Checked As Boolean)

            BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.Daypart84 = Checked

            BroadcastResearchViewModel.SpotRadioCountyIsDirty = True

        End Sub
        'Public Sub SpotRadioCounty_SetEthnicity(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, Ethnicity As Short)

        '    BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.Ethnicity = Ethnicity

        '    BroadcastResearchViewModel.NielsenRadioBookList = New Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook)

        '    Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

        '        'BroadcastResearchViewModel.SpotRadioCountyAvailableStationList = GetRadioStations(NielsenDbContext, BroadcastResearchViewModel, Nothing)

        '    End Using

        '    BroadcastResearchViewModel.SpotRadioCountySelectedStationList = New Generic.List(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Station)

        '    BroadcastResearchViewModel.SpotRadioCountyIsDirty = True

        'End Sub
        Public Sub SpotRadioCounty_SetSelectedResearchCriteria(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ID As Integer)

            BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria = BroadcastResearchViewModel.SpotRadioCountyResearchCriteriaList.Where(Function(Entity) Entity.ID = ID).SingleOrDefault

        End Sub
        Public Sub SpotRadioCounty_YearCellChanged(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                   Year As AdvantageFramework.DTO.Media.SpotRadioCounty.Year, FieldName As String, Value As Object)

            If FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.Year.Properties.Year1.ToString AndAlso Value Is Nothing Then

                Year.Year2 = Nothing
                Year.Year3 = Nothing
                Year.Year4 = Nothing
                Year.Year5 = Nothing

            ElseIf FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.Year.Properties.Year2.ToString AndAlso Value Is Nothing Then

                Year.Year3 = Nothing
                Year.Year4 = Nothing
                Year.Year5 = Nothing

            ElseIf FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.Year.Properties.Year3.ToString AndAlso Value Is Nothing Then

                Year.Year4 = Nothing
                Year.Year5 = Nothing

            ElseIf FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.Year.Properties.Year4.ToString AndAlso Value Is Nothing Then

                Year.Year5 = Nothing

            End If

            BroadcastResearchViewModel.SpotRadioCountyIsDirty = True

        End Sub
        Public Sub SpotRadioCounty_SetAvailableWeightingFlags(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, NielsenDbContext As AdvantageFramework.Nielsen.Database.DbContext)

            BroadcastResearchViewModel.SpotRadioCountyWeightingFlags = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyPeriod.LoadByCountyCode(NielsenDbContext, BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.CountyCode)
                                                                        Select Entity.WeightingFlag).Distinct.ToArray

        End Sub
        Public Sub SpotRadioCounty_SetAvailableYears(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, NielsenDbContext As AdvantageFramework.Nielsen.Database.DbContext,
                                                     DbContext As AdvantageFramework.Database.DbContext)

            'Dim WeightingFlag As String = Nothing

            'If BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.Ethnicity = 1 Then

            '    WeightingFlag = "N"

            'ElseIf BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.Ethnicity = 2 Then

            '    WeightingFlag = "B"

            'ElseIf BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.Ethnicity = 3 Then

            '    WeightingFlag = "S"

            'ElseIf BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.Ethnicity = 4 Then

            '    WeightingFlag = "A"

            'End If

            If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                BroadcastResearchViewModel.SpotRadioCountyAvailableYears = NielsenDbContext.Database.SqlQuery(Of Short)(String.Format("EXEC advsp_hosted_spotradio_nielsen_get_county_years '{0}', {1}", Session.NielsenClientCodeForHosted, BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.CountyCode.Value)).ToList

                'BroadcastResearchViewModel.SpotRadioCountyAvailableYears = NielsenDbContext.Database.SqlQuery(Of Short)(String.Format("EXEC advsp_hosted_spotradio_nielsen_get_county_years '{0}', {1}, '{2}'", Session.NielsenClientCodeForHosted, BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.CountyCode.Value, WeightingFlag)).ToList

            Else

                'BroadcastResearchViewModel.SpotRadioCountyAvailableYears = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyPeriod.LoadByCountyCode(NielsenDbContext, BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.CountyCode.Value)
                '                                                            Where Entity.WeightingFlag = WeightingFlag
                '                                                            Select Entity.Year).Distinct.ToList

                BroadcastResearchViewModel.SpotRadioCountyAvailableYears = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyPeriod.LoadByCountyCode(NielsenDbContext, BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.CountyCode.Value)
                                                                            Select Entity.Year).Distinct.ToList
            End If

        End Sub
        Public Sub SpotRadioCounty_SetCounty(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, CountyCode As Integer, MediaSpotRadioCountyResearchID As Nullable(Of Integer))

            Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.CountyCode = CountyCode

                    SpotRadioCounty_SetAvailableWeightingFlags(BroadcastResearchViewModel, NielsenDbContext)

                    SpotRadioCounty_SetAvailableYears(BroadcastResearchViewModel, NielsenDbContext, DbContext)

                    BroadcastResearchViewModel.SpotRadioCountyAvailableStationList.Clear()

                    BroadcastResearchViewModel.SpotRadioCountySelectedStationList.Clear()

                    BroadcastResearchViewModel.SpotRadioCountyReportDataTable = Nothing

                    BroadcastResearchViewModel.SpotRadioCountyIsDirty = True

                End Using

            End Using

        End Sub
        Public Sub SpotRadioCounty_SetDemographic(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, MediaDemoID As Integer)

            BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.MediaDemoID = MediaDemoID

            BroadcastResearchViewModel.SpotRadioCountyReportDataTable = Nothing

            BroadcastResearchViewModel.SpotRadioCountyIsDirty = True

        End Sub
        Public Sub SpotRadioCounty_SetReportType(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ReportType As Short)

            BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.ReportType = ReportType

            BroadcastResearchViewModel.SpotRadioCountyReportDataTable = Nothing

            BroadcastResearchViewModel.SpotRadioCountyIsDirty = True

        End Sub
        Public Function SpotRadioCounty_GetYearRepository(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, FieldName As String, YearIn As AdvantageFramework.DTO.Media.SpotRadioCounty.Year) As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

            'objects
            Dim Years As IEnumerable(Of Short) = Nothing
            Dim ComboBoxItems As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem) = Nothing
            'Dim WeightingFlag As String = Nothing
            Dim ExcludeYears As Generic.List(Of Short) = Nothing

            ComboBoxItems = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

            If BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria IsNot Nothing AndAlso BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.CountyCode.HasValue Then

                Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                    'If BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.Ethnicity = 1 Then

                    '    WeightingFlag = "N"

                    'ElseIf BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.Ethnicity = 2 Then

                    '    WeightingFlag = "B"

                    'ElseIf BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.Ethnicity = 3 Then

                    '    WeightingFlag = "S"

                    'ElseIf BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.Ethnicity = 4 Then

                    '    WeightingFlag = "A"

                    'End If

                    ExcludeYears = New Generic.List(Of Short)

                    If YearIn Is Nothing AndAlso FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.Year.Properties.Year1.ToString Then

                        If BroadcastResearchViewModel.SpotRadioCountyYearList.Count > 0 Then

                            ExcludeYears.AddRange(From Entity In BroadcastResearchViewModel.SpotRadioCountyYearList
                                                  Where Entity.Year1 IsNot Nothing
                                                  Select Entity.Year1.Value)

                        End If

                    ElseIf YearIn IsNot Nothing Then

                        If FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.Year.Properties.Year1.ToString Then

                            If YearIn.Year2.HasValue Then ExcludeYears.Add(YearIn.Year2.Value)
                            If YearIn.Year3.HasValue Then ExcludeYears.Add(YearIn.Year3.Value)
                            If YearIn.Year4.HasValue Then ExcludeYears.Add(YearIn.Year4.Value)
                            If YearIn.Year5.HasValue Then ExcludeYears.Add(YearIn.Year5.Value)

                            ExcludeYears.AddRange(From Entity In BroadcastResearchViewModel.SpotRadioCountyYearList
                                                  Where Entity.Year1 IsNot Nothing AndAlso
                                                        Entity.Year1.GetValueOrDefault(0) <> YearIn.Year1.GetValueOrDefault(0)
                                                  Select Entity.Year1.Value)

                        ElseIf FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.Year.Properties.Year2.ToString Then

                            If YearIn.Year1.HasValue Then ExcludeYears.Add(YearIn.Year1.Value)
                            If YearIn.Year3.HasValue Then ExcludeYears.Add(YearIn.Year3.Value)
                            If YearIn.Year4.HasValue Then ExcludeYears.Add(YearIn.Year4.Value)
                            If YearIn.Year5.HasValue Then ExcludeYears.Add(YearIn.Year5.Value)

                        ElseIf FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.Year.Properties.Year3.ToString Then

                            If YearIn.Year1.HasValue Then ExcludeYears.Add(YearIn.Year1.Value)
                            If YearIn.Year2.HasValue Then ExcludeYears.Add(YearIn.Year2.Value)
                            If YearIn.Year4.HasValue Then ExcludeYears.Add(YearIn.Year4.Value)
                            If YearIn.Year5.HasValue Then ExcludeYears.Add(YearIn.Year5.Value)

                        ElseIf FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.Year.Properties.Year4.ToString Then

                            If YearIn.Year1.HasValue Then ExcludeYears.Add(YearIn.Year1.Value)
                            If YearIn.Year2.HasValue Then ExcludeYears.Add(YearIn.Year2.Value)
                            If YearIn.Year3.HasValue Then ExcludeYears.Add(YearIn.Year3.Value)
                            If YearIn.Year5.HasValue Then ExcludeYears.Add(YearIn.Year5.Value)

                        ElseIf FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.Year.Properties.Year5.ToString Then

                            If YearIn.Year1.HasValue Then ExcludeYears.Add(YearIn.Year1.Value)
                            If YearIn.Year2.HasValue Then ExcludeYears.Add(YearIn.Year2.Value)
                            If YearIn.Year3.HasValue Then ExcludeYears.Add(YearIn.Year3.Value)
                            If YearIn.Year4.HasValue Then ExcludeYears.Add(YearIn.Year4.Value)

                        End If

                    End If

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                            'Years = NielsenDbContext.Database.SqlQuery(Of Short)(String.Format("EXEC advsp_hosted_spotradio_nielsen_get_county_years '{0}', {1}, '{2}'", Session.NielsenClientCodeForHosted, BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.CountyCode.Value, WeightingFlag)).ToArray

                            Years = NielsenDbContext.Database.SqlQuery(Of Short)(String.Format("EXEC advsp_hosted_spotradio_nielsen_get_county_years '{0}', {1}", Session.NielsenClientCodeForHosted, BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.CountyCode.Value)).ToArray

                        Else

                            'Years = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyPeriod.LoadByCountyCode(NielsenDbContext, BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.CountyCode.Value)
                            '         Where Entity.WeightingFlag = WeightingFlag
                            '         Select Entity.Year).Distinct.ToArray

                            Years = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyPeriod.LoadByCountyCode(NielsenDbContext, BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.CountyCode.Value)
                                     Select Entity.Year).Distinct.ToArray

                        End If

                        ComboBoxItems = (From Year In Years
                                         Where ExcludeYears.Contains(Year) = False
                                         Select New AdvantageFramework.DTO.ComboBoxItem(Year, Year)).ToList

                    End Using

                End Using

            End If

            SpotRadioCounty_GetYearRepository = ComboBoxItems

        End Function
        Public Sub SpotRadioCounty_SetYearList(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, YearList As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Year))

            BroadcastResearchViewModel.SpotRadioCountyYearList = YearList

        End Sub
        Public Sub SpotRadioCounty_SetAvailableStations(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            'objects
            Dim Years As Generic.List(Of Short) = Nothing
            Dim NielsenRadioCoutyPeriodIDs As IEnumerable(Of Integer) = Nothing
            Dim NielsenRadioCountyStationIDs As Generic.List(Of Integer) = Nothing

            Years = New Generic.List(Of Short)

            For Each SpotRadioCountyYear In BroadcastResearchViewModel.SpotRadioCountyYearList

                Years.Add(SpotRadioCountyYear.Year1)
                If SpotRadioCountyYear.Year2.HasValue Then Years.Add(SpotRadioCountyYear.Year2.Value)
                If SpotRadioCountyYear.Year3.HasValue Then Years.Add(SpotRadioCountyYear.Year3.Value)
                If SpotRadioCountyYear.Year4.HasValue Then Years.Add(SpotRadioCountyYear.Year4.Value)
                If SpotRadioCountyYear.Year5.HasValue Then Years.Add(SpotRadioCountyYear.Year5.Value)

            Next

            Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                NielsenRadioCoutyPeriodIDs = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyPeriod.LoadByCountyCode(NielsenDbContext, BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.CountyCode.Value)
                                              Where Years.Contains(Entity.Year)
                                              Select Entity.ID).ToArray

                NielsenRadioCountyStationIDs = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyAudience.Load(NielsenDbContext)
                                                Where NielsenRadioCoutyPeriodIDs.Contains(Entity.NielsenRadioCountyPeriodID)
                                                Select Entity.NielsenRadioCountyStationID).Distinct.ToList

                BroadcastResearchViewModel.SpotRadioCountyAvailableStationList.Clear()
                BroadcastResearchViewModel.SpotRadioCountyAvailableStationList.AddRange(From S In (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioCountyStation.LoadByStationIDs(NielsenDbContext, NielsenRadioCountyStationIDs)
                                                                                                   Select New With {.CallLetters = Entity.CallLetters,
                                                                                                                    .Band = Entity.Band,
                                                                                                                    .Frequecy = Entity.Frequency}).Distinct.ToList
                                                                                        Select New AdvantageFramework.DTO.Media.SpotRadioCounty.Station(S.CallLetters, S.Band, S.Frequecy))

                BroadcastResearchViewModel.SpotRadioCountySelectedStationList.Clear()

            End Using

        End Sub
        Public Sub SpotRadioCounty_YearAddNewRowEvent(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            BroadcastResearchViewModel.SpotRadioCountyAvailableStationList.Clear()

            BroadcastResearchViewModel.SpotRadioCountySelectedStationList.Clear()

            BroadcastResearchViewModel.SpotRadioCountyIsDirty = True

        End Sub
        Public Function SpotRadioCounty_ValidateYear(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                     Year As AdvantageFramework.DTO.Media.SpotRadioCounty.Year, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim MediaSpotRadioCountyResearchYear As AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearchYear = Nothing
            Dim DTOProperties As Generic.List(Of ComponentModel.PropertyDescriptor) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaSpotRadioCountyResearchYear = New AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearchYear

                Year.SaveToEntity(MediaSpotRadioCountyResearchYear)

                MediaSpotRadioCountyResearchYear.DbContext = DbContext

                ErrorText = MediaSpotRadioCountyResearchYear.ValidateEntity(IsValid)

                If BroadcastResearchViewModel.SpotRadioCountyYearList.Where(Function(Entity) Entity.Year1 = Year.Year1).Count > 1 Then

                    ErrorText += "Year 1 exists."
                    IsValid = False

                End If

                Year.SetEntityError(ErrorText)

                DTOProperties = System.ComponentModel.TypeDescriptor.GetProperties(Year.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(MediaSpotRadioCountyResearchYear.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)()

                    If DTOProperties.Contains(PropertyDescriptor) Then

                        Year.SetPropertyError(PropertyDescriptor.Name, MediaSpotRadioCountyResearchYear.LoadErrorText(PropertyDescriptor.Name))

                    End If

                Next

            End Using

            SpotRadioCounty_ValidateYear = ErrorText

        End Function
        Public Sub SpotRadioCounty_YearInitNewRowEvent(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            BroadcastResearchViewModel.YearIsNewRow = True
            BroadcastResearchViewModel.YearCancelEnabled = True
            BroadcastResearchViewModel.YearDeleteEnabled = False

        End Sub
        Public Sub SpotRadioCounty_YearSelectionChanged(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                        IsNewItemRow As Boolean)

            BroadcastResearchViewModel.YearIsNewRow = IsNewItemRow
            BroadcastResearchViewModel.YearCancelEnabled = IsNewItemRow
            BroadcastResearchViewModel.YearDeleteEnabled = Not IsNewItemRow

        End Sub
        Public Sub SpotRadioCounty_YearCancelNewItemRow(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            BroadcastResearchViewModel.YearIsNewRow = False
            BroadcastResearchViewModel.YearCancelEnabled = False
            BroadcastResearchViewModel.YearDeleteEnabled = BroadcastResearchViewModel.SpotRadioCountyYearList IsNot Nothing AndAlso BroadcastResearchViewModel.SpotRadioCountyYearList.Count > 0

        End Sub
        Public Sub SpotRadioCounty_DeleteSelectedYears(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                       SelectedYears As Generic.List(Of DTO.Media.SpotRadioCounty.Year))

            If SelectedYears IsNot Nothing AndAlso SelectedYears.Count > 0 Then

                For Each SelectedYear In SelectedYears

                    BroadcastResearchViewModel.SpotRadioCountyYearList.Remove(SelectedYear)

                Next

                BroadcastResearchViewModel.SpotRadioCountyIsDirty = True

            End If

        End Sub
        Public Sub SpotRadioCounty_AddToSelectedMetrics(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                        AvailableMetricsSelected As IEnumerable(Of AdvantageFramework.DTO.Media.Metric))

            If AvailableMetricsSelected IsNot Nothing AndAlso AvailableMetricsSelected.Count > 0 Then

                For Each Metric In AvailableMetricsSelected

                    BroadcastResearchViewModel.SpotRadioCountySelectedMetricList.Add(Metric)
                    BroadcastResearchViewModel.SpotRadioCountyAvailableMetricList.Remove(Metric)

                Next

                BroadcastResearchViewModel.SpotRadioCountyIsDirty = True

            End If

        End Sub
        Public Sub SpotRadioCounty_RemoveFromSelectedMetrics(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                             SelectedMetricSelected As IEnumerable(Of AdvantageFramework.DTO.Media.Metric))

            If SelectedMetricSelected IsNot Nothing AndAlso SelectedMetricSelected.Count > 0 Then

                For Each Metric In SelectedMetricSelected

                    BroadcastResearchViewModel.SpotRadioCountyAvailableMetricList.Add(Metric)
                    BroadcastResearchViewModel.SpotRadioCountySelectedMetricList.Remove(Metric)

                Next

                BroadcastResearchViewModel.SpotRadioCountyIsDirty = True

            End If

        End Sub
        Public Sub SpotRadioCounty_AddToSelectedStations(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                         AvailableStationsSelected As IEnumerable(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Station))

            If AvailableStationsSelected IsNot Nothing AndAlso AvailableStationsSelected.Count > 0 Then

                For Each Station In AvailableStationsSelected

                    BroadcastResearchViewModel.SpotRadioCountySelectedStationList.Add(Station)
                    BroadcastResearchViewModel.SpotRadioCountyAvailableStationList.Remove(Station)

                Next

                BroadcastResearchViewModel.SpotRadioCountyIsDirty = True

            End If

        End Sub
        Public Sub SpotRadioCounty_RemoveFromSelectedStations(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                              SelectedStationsSelected As IEnumerable(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Station))

            If SelectedStationsSelected IsNot Nothing AndAlso SelectedStationsSelected.Count > 0 Then

                For Each Station In SelectedStationsSelected

                    BroadcastResearchViewModel.SpotRadioCountyAvailableStationList.Add(Station)
                    BroadcastResearchViewModel.SpotRadioCountySelectedStationList.Remove(Station)

                Next

                BroadcastResearchViewModel.SpotRadioCountyIsDirty = True

            End If

        End Sub
        Public Sub SpotRadioCounty_MoveMetric(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                              Metric As DTO.Media.Metric, Direction As MoveItemDirection)

            'objects
            Dim OldIndex As Integer = -1

            OldIndex = BroadcastResearchViewModel.SpotRadioCountySelectedMetricList.IndexOf(Metric)

            BroadcastResearchViewModel.SpotRadioCountySelectedMetricList.RemoveAt(OldIndex)

            If Direction = MoveItemDirection.Down Then

                BroadcastResearchViewModel.SpotRadioCountySelectedMetricList.Insert(OldIndex + 1, Metric)

            Else

                BroadcastResearchViewModel.SpotRadioCountySelectedMetricList.Insert(OldIndex - 1, Metric)

            End If

            BroadcastResearchViewModel.SpotRadioCountyIsDirty = True

        End Sub
        Public Function SpotRadioCounty_RunReport(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                  ByRef ErrorMessage As String,
                                                  ByRef InfoMessage As String)

            'objects
            Dim ResearchID As Integer = Nothing
            Dim MediaDemoID As Integer = 0
            Dim MediaDemographic As AdvantageFramework.Database.Entities.MediaDemographic = Nothing
            Dim CallLettersBands As Generic.List(Of String) = Nothing
            Dim SqlParameterCountyCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaDemoCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaDemoDesc As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDaypart68 As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDaypart84 As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCallLettersBandList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaSpotRadioCountyResearchYearType As System.Data.SqlClient.SqlParameter = Nothing
            Dim MediaSpotRadioCountyResearchMetricList As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearchMetric) = Nothing
            Dim Success As Boolean = False
            'Dim NameList As Generic.List(Of String) = Nothing
            'Dim DaypartBooks As Integer = 0
            'Dim StationDaypartBookCount As Dictionary(Of Integer, Integer) = Nothing

            If SpotRadioCounty_RequiredDataPresent(BroadcastResearchViewModel, ErrorMessage) Then 'AndAlso CheckCume(BroadcastResearchViewModel, ErrorMessage, InfoMessage) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    ResearchID = BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.ID.Value

                    MediaDemoID = BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.MediaDemoID.Value

                    MediaDemographic = AdvantageFramework.Database.Procedures.MediaDemographic.LoadByID(DbContext, MediaDemoID)

                    If MediaDemographic Is Nothing Then

                        Throw New Exception("Cannot find the demographic!")

                    End If

                    CallLettersBands = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotRadioCountyResearchStation.LoadByMediaSpotRadioCountyResearchID(DbContext, ResearchID)
                                        Select Entity.CallLetters + "|" + Entity.Band).Distinct.ToList

                    SqlParameterCountyCode = New System.Data.SqlClient.SqlParameter("@COUNTY_CODE", SqlDbType.Int)
                    SqlParameterCountyCode.Value = BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.CountyCode.Value

                    SqlParameterMediaDemoCode = New System.Data.SqlClient.SqlParameter("@MEDIA_DEMO_CODE", SqlDbType.VarChar)
                    SqlParameterMediaDemoCode.Value = MediaDemographic.Code

                    SqlParameterMediaDemoDesc = New System.Data.SqlClient.SqlParameter("@MEDIA_DEMO_DESC", SqlDbType.VarChar)
                    SqlParameterMediaDemoDesc.Value = MediaDemographic.Description

                    SqlParameterDaypart68 = New System.Data.SqlClient.SqlParameter("@DAYPART_68", SqlDbType.Bit)
                    SqlParameterDaypart68.Value = BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.Daypart68

                    SqlParameterDaypart84 = New System.Data.SqlClient.SqlParameter("@DAYPART_84", SqlDbType.Bit)
                    SqlParameterDaypart84.Value = BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.Daypart84

                    SqlParameterCallLettersBandList = New System.Data.SqlClient.SqlParameter("@CALL_LETTERS_BAND", SqlDbType.VarChar)
                    SqlParameterCallLettersBandList.Value = String.Join(",", CallLettersBands)

                    SqlParameterMediaSpotRadioCountyResearchYearType = New System.Data.SqlClient.SqlParameter("@MEDIA_SPOT_RADIO_COUNTY_RESEARCH_YEAR_TYPE", SqlDbType.Structured)
                    SqlParameterMediaSpotRadioCountyResearchYearType.TypeName = "MEDIA_SPOT_RADIO_COUNTY_RESEARCH_YEAR_TYPE"
                    SqlParameterMediaSpotRadioCountyResearchYearType.Value = AdvantageFramework.Database.ToDataTable((From Entity In AdvantageFramework.Database.Procedures.MediaSpotRadioCountyResearchYear.LoadByMediaSpotRadioCountyResearchID(DbContext, ResearchID)
                                                                                                                      Select Entity.ID,
                                                                                                                             Entity.Year1,
                                                                                                                             Entity.Year2,
                                                                                                                             Entity.Year3,
                                                                                                                             Entity.Year4,
                                                                                                                             Entity.Year5).ToList)

                    Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                        MediaSpotRadioCountyResearchMetricList = AdvantageFramework.Database.Procedures.MediaSpotRadioCountyResearchMetric.LoadByMediaSpotRadioCountyResearchID(DbContext, ResearchID).ToList

                        BroadcastResearchViewModel.SpotRadioCountyResearchResultList = NielsenDbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult)("EXEC advsp_nielsen_spot_radio_county_research_ranker @COUNTY_CODE, @MEDIA_DEMO_CODE, @MEDIA_DEMO_DESC, @DAYPART_68, @DAYPART_84, @CALL_LETTERS_BAND, @MEDIA_SPOT_RADIO_COUNTY_RESEARCH_YEAR_TYPE",
                                SqlParameterCountyCode, SqlParameterMediaDemoCode, SqlParameterMediaDemoDesc, SqlParameterDaypart68, SqlParameterDaypart84, SqlParameterCallLettersBandList, SqlParameterMediaSpotRadioCountyResearchYearType).ToList

                        'DaypartBooks = BroadcastResearchViewModel.SpotRadioResearchResultList.Select(Function(Result) Result.DaypartBooks).Distinct.Count

                        'If AdvantageFramework.Database.Procedures.MediaSpotRadioResearchBook.LoadByMediaSpotRadioResearchID(DbContext, ResearchID).Count > DaypartBooks Then

                        '    DaypartBooks = AdvantageFramework.Database.Procedures.MediaSpotRadioResearchBook.LoadByMediaSpotRadioResearchID(DbContext, ResearchID).Count

                        'End If

                        'StationDaypartBookCount = (From Entity In BroadcastResearchViewModel.SpotRadioResearchResultList
                        '                           Group By Entity.NielsenRadioStationID Into Group
                        '                           Select New With {.NielsenRadioStationID = NielsenRadioStationID,
                        '                                                .Count = Group.Count}).ToDictionary(Function(E) E.NielsenRadioStationID, Function(E) E.Count)

                        'For Each KeyPair In StationDaypartBookCount

                        '    If KeyPair.Value = DaypartBooks Then

                        '        NielsenRadioStationIDs.Remove(KeyPair.Key)

                        '    End If

                        'Next

                        'If NielsenRadioStationIDs.Count > 0 Then

                        '    NameList = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.Load(NielsenDbContext)
                        '                Where NielsenRadioStationIDs.Contains(Entity.ID)
                        '                Select Entity).OrderBy(Function(Entity) Entity.Name).ToList.Select(Function(E) E.Name).ToList

                        '    InfoMessage += vbCrLf & "The following " & NameList.Count & " station(s) do not have data for all criteria selected: " & vbCrLf & String.Join(", ", NameList.ToArray)

                        'End If

                    End Using

                    If BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.Ranker Then

                        BroadcastResearchViewModel.SpotRadioCountyReportDataTable = SpotRadioCounty_CreateRankerReportDataTable(BroadcastResearchViewModel, MediaSpotRadioCountyResearchMetricList)

                    ElseIf BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.Trend Then

                        BroadcastResearchViewModel.SpotRadioCountyReportDataTable = SpotRadioCounty_CreateTrendReportDataTable(BroadcastResearchViewModel, MediaSpotRadioCountyResearchMetricList)

                    End If

                End Using

                Success = True

            End If

            SpotRadioCounty_RunReport = Success

        End Function
        Private Function SpotRadioCounty_CreateRankerReportDataTable(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                                     MediaSpotRadioCountyResearchMetricList As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearchMetric)) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim SortString As String = Nothing
            Dim RankDataTable As System.Data.DataTable = Nothing
            Dim DataRowRank As Nullable(Of Integer) = Nothing
            Dim StationNames As Generic.List(Of String) = Nothing
            Dim RankDataRow As System.Data.DataRow = Nothing

            DataTable = New System.Data.DataTable

            StationNames = New Generic.List(Of String)

            DataColumn = DataTable.Columns.Add(AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.StationName.ToString)
            DataColumn.DataType = GetType(String)

            If BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.ShowFrequency Then

                DataColumn = DataTable.Columns.Add(AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.StationFrequency.ToString)
                DataColumn.DataType = GetType(String)

            End If

            For Each MediaSpotRadioResearchMetric In MediaSpotRadioCountyResearchMetricList.OrderBy(Function(Entity) Entity.Order)

                SortString += If(String.IsNullOrWhiteSpace(SortString), FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & " DESC", ", " & FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & " DESC")

            Next

            For Each DP In (From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                            Select Entity.NielsenRadioDaypartID).Distinct.ToList

                DataColumn = DataTable.Columns.Add("Daypart" & DP)
                DataColumn.DataType = GetType(String)

                DataColumn = DataTable.Columns.Add("Rank" & DP)
                DataColumn.DataType = GetType(Integer)

                For Each MediaSpotRadioResearchMetric In MediaSpotRadioCountyResearchMetricList.OrderBy(Function(Entity) Entity.Order)

                    DataColumn = DataTable.Columns.Add(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DP)
                    DataColumn.DataType = GetType(Decimal)

                Next

            Next

            For Each ResearchResult In (From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                                        Select Entity.StationName, Entity.StationFrequency).Distinct.ToList

                DataRow = DataTable.NewRow

                DataRow(AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.StationName.ToString) = ResearchResult.StationName

                If BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.ShowFrequency Then

                    DataRow(AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.StationFrequency.ToString) = ResearchResult.StationFrequency

                End If

                For Each DaypartOrder In (From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                                          Where Entity.StationName = ResearchResult.StationName
                                          Select Entity.NielsenRadioDaypartID, Entity.Daypart).Distinct.ToList

                    DataRow("Daypart" & DaypartOrder.NielsenRadioDaypartID) = DaypartOrder.Daypart

                    'rank
                    RankDataTable = AdvantageFramework.Database.ToDataTable((From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                                                                             Where Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                                                                             Select Entity).ToList)

                    RankDataTable.DefaultView.Sort = SortString

                    If MediaSpotRadioCountyResearchMetricList IsNot Nothing AndAlso MediaSpotRadioCountyResearchMetricList.Count > 0 Then

                        RankIt(RankDataTable, FormatDescription(MediaSpotRadioCountyResearchMetricList.OrderBy(Function(Entity) Entity.Order).FirstOrDefault.MediaMetric.Description))

                    End If

                    If Not DataRowRank.HasValue Then

                        DataRowRank = RankDataTable.Select("StationName = '" & ResearchResult.StationName & "'").FirstOrDefault.Item("Rank")

                    End If

                    DataRow("Rank" & DaypartOrder.NielsenRadioDaypartID) = RankDataTable.Select("StationName = '" & ResearchResult.StationName & "'").FirstOrDefault.Item("Rank")

                    For Each MediaSpotRadioResearchMetric In MediaSpotRadioCountyResearchMetricList.OrderBy(Function(Entity) Entity.Order)

                        Select Case FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description)

                            Case AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.AQHRating.ToString

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DaypartOrder.NielsenRadioDaypartID) = (From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                                                                                                                                                               Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                                                                                                     Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                                                                                                                                                               Select Entity).FirstOrDefault.AQHRating

                            Case AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.AQH.ToString

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DaypartOrder.NielsenRadioDaypartID) = (From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                                                                                                                                                               Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                                                                                                     Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                                                                                                                                                               Select Entity).FirstOrDefault.AQH

                            Case AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.CumeRating.ToString

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DaypartOrder.NielsenRadioDaypartID) = (From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                                                                                                                                                               Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                                                                                                     Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                                                                                                                                                               Select Entity).FirstOrDefault.CumeRating

                            Case AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.Cume.ToString

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DaypartOrder.NielsenRadioDaypartID) = (From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                                                                                                                                                               Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                                                                                                     Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                                                                                                                                                               Select Entity).FirstOrDefault.Cume

                            Case AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.Population.ToString

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DaypartOrder.NielsenRadioDaypartID) = (From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                                                                                                                                                               Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                                                                                                     Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                                                                                                                                                               Select Entity).FirstOrDefault.Population

                            Case AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.Intab.ToString

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DaypartOrder.NielsenRadioDaypartID) = (From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                                                                                                                                                               Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                                                                                                     Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                                                                                                                                                               Select Entity).FirstOrDefault.Intab

                            Case AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.CountyShareofStationPercent.ToString

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DaypartOrder.NielsenRadioDaypartID) = (From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                                                                                                                                                               Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                                                                                                     Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                                                                                                                                                               Select Entity).FirstOrDefault.CountyShareofStationPercent

                            Case AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.StationShareofCountyPercent.ToString

                                DataRow(FormatDescription(MediaSpotRadioResearchMetric.MediaMetric.Description) & "_" & DaypartOrder.NielsenRadioDaypartID) = (From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                                                                                                                                                               Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                                                                                                     Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID
                                                                                                                                                               Select Entity).FirstOrDefault.StationShareofCountyPercent

                        End Select

                    Next

                Next

                If BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.MaxRank.HasValue Then

                    If DataRowRank IsNot Nothing AndAlso DataRowRank.Value <= BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.MaxRank Then

                        DataTable.Rows.Add(DataRow)

                        StationNames.Add(ResearchResult.StationName)

                    End If

                    DataRowRank = Nothing

                Else

                    DataTable.Rows.Add(DataRow)

                End If

            Next

            For Each StationName In StationNames

                For Each DaypartOrder In (From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                                          Where StationNames.Contains(Entity.StationName)
                                          Select Entity.NielsenRadioDaypartID, Entity.Daypart).Distinct.ToList

                    'rank
                    RankDataTable = AdvantageFramework.Database.ToDataTable((From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                                                                             Where Entity.NielsenRadioDaypartID = DaypartOrder.NielsenRadioDaypartID AndAlso
                                                                                   StationNames.Contains(Entity.StationName)
                                                                             Select Entity).ToList)

                    RankDataTable.DefaultView.Sort = SortString

                    If MediaSpotRadioCountyResearchMetricList IsNot Nothing AndAlso MediaSpotRadioCountyResearchMetricList.Count > 0 Then

                        RankIt(RankDataTable, FormatDescription(MediaSpotRadioCountyResearchMetricList.OrderBy(Function(Entity) Entity.Order).FirstOrDefault.MediaMetric.Description))

                    End If

                    RankDataRow = DataTable.Select("StationName = '" & StationName & "'").FirstOrDefault
                    RankDataRow("Rank" & DaypartOrder.NielsenRadioDaypartID) = RankDataTable.Select("StationName = '" & StationName & "'").FirstOrDefault.Item("Rank")

                Next

            Next

            SpotRadioCounty_CreateRankerReportDataTable = DataTable

        End Function
        Private Function SpotRadioCounty_CreateTrendReportDataTable(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                                    MediaSpotRadioCountyResearchMetricList As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpotRadioCountyResearchMetric)) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            DataTable = New System.Data.DataTable

            DataColumn = DataTable.Columns.Add(AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.StationName.ToString)
            DataColumn.DataType = GetType(String)

            If BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.ShowFrequency Then

                DataColumn = DataTable.Columns.Add(AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.StationFrequency.ToString)
                DataColumn.DataType = GetType(String)

            End If

            DataColumn = DataTable.Columns.Add("MetricName")
            DataColumn.DataType = GetType(String)

            For Each Book In (From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                              Select Entity.BookID, Entity.TrendBookOrder).Distinct.OrderBy(Function(Entity) Entity.TrendBookOrder).ToList

                DataColumn = DataTable.Columns.Add("BookMetric" & Book.BookID)
                DataColumn.DataType = GetType(Decimal)

            Next

            For Each ResearchResult In (From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                                        Select Entity.StationName, Entity.StationFrequency).Distinct.ToList

                For Each MediaSpotTVResearchMetric In MediaSpotRadioCountyResearchMetricList.OrderBy(Function(Entity) Entity.Order)

                    DataRow = DataTable.NewRow

                    DataRow(AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.StationName.ToString) = ResearchResult.StationName

                    If BroadcastResearchViewModel.SpotRadioCountySelectedResearchCriteria.ShowFrequency Then

                        DataRow(AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.StationFrequency.ToString) = ResearchResult.StationFrequency

                    End If

                    DataRow("MetricName") = MediaSpotTVResearchMetric.MediaMetric.Description

                    For Each Book In (From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                                      Select Entity.BookID, Entity.TrendBookOrder).Distinct.OrderBy(Function(Entity) Entity.TrendBookOrder).ToList

                        If (From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                            Where Entity.StationName = ResearchResult.StationName AndAlso
                                  Entity.BookID = Book.BookID
                            Select Entity).FirstOrDefault IsNot Nothing Then

                            Select Case DataRow("MetricName")

                                Case "AQH Rating"

                                    DataRow("BookMetric" & Book.BookID) = FormatNumber((From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                                                                                        Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                              Entity.BookID = Book.BookID
                                                                                        Select Entity).FirstOrDefault.AQHRating, 1)

                                Case "AQH (00)"

                                    DataRow("BookMetric" & Book.BookID) = FormatNumber((From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                                                                                        Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                              Entity.BookID = Book.BookID
                                                                                        Select Entity).FirstOrDefault.AQH, 0)

                                Case "Cume Rating"

                                    DataRow("BookMetric" & Book.BookID) = FormatNumber((From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                                                                                        Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                              Entity.BookID = Book.BookID
                                                                                        Select Entity).FirstOrDefault.CumeRating, 1)

                                Case "Cume (00)"

                                    DataRow("BookMetric" & Book.BookID) = FormatNumber((From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                                                                                        Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                              Entity.BookID = Book.BookID
                                                                                        Select Entity).FirstOrDefault.Cume, 0)

                                Case "Station Share of County %"

                                    DataRow("BookMetric" & Book.BookID) = FormatNumber((From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                                                                                        Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                              Entity.BookID = Book.BookID
                                                                                        Select Entity).FirstOrDefault.CountyShareofStationPercent, 1)

                                Case "County Share of Station %"

                                    DataRow("BookMetric" & Book.BookID) = FormatNumber((From Entity In BroadcastResearchViewModel.SpotRadioCountyResearchResultList
                                                                                        Where Entity.StationName = ResearchResult.StationName AndAlso
                                                                                              Entity.BookID = Book.BookID
                                                                                        Select Entity).FirstOrDefault.StationShareofCountyPercent, 1)

                            End Select

                        End If

                    Next

                    DataTable.Rows.Add(DataRow)

                Next

            Next

            SpotRadioCounty_CreateTrendReportDataTable = DataTable

        End Function
        Public Function SpotRadioCounty_YearValidateProperty(Year As AdvantageFramework.DTO.Media.SpotRadioCounty.Year, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(Year.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)().FirstOrDefault(Function(PD) PD.Name = FieldName)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTOProperty(DbContext, DataContext, Year, PropertyDescriptor, IsValid, Value)

                End Using

            End Using

            SpotRadioCounty_YearValidateProperty = ErrorText

        End Function
        Public Sub SaveRadioCountyDashboard(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, DashboardLayout() As Byte)

            'objects
            Dim Dashboard As AdvantageFramework.Database.Entities.Dashboard = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Dashboard = AdvantageFramework.Database.Procedures.Dashboard.LoadByDashboardType(DbContext, AdvantageFramework.Database.Entities.DashboardTypes.BroadcastResearchTool_RadioCounty)

                If Dashboard IsNot Nothing Then

                    Dashboard.Layout = DashboardLayout

                    AdvantageFramework.Database.Procedures.Dashboard.Update(DbContext, Dashboard)

                Else

                    Dashboard = New AdvantageFramework.Database.Entities.Dashboard

                    Dashboard.DbContext = DbContext
                    Dashboard.Type = AdvantageFramework.Database.Entities.DashboardTypes.BroadcastResearchTool_RadioCounty
                    Dashboard.Layout = DashboardLayout

                    AdvantageFramework.Database.Procedures.Dashboard.Insert(DbContext, Dashboard)

                End If

            End Using

            BroadcastResearchViewModel.Dashboard.Layout = DashboardLayout

        End Sub

#End Region

#Region " Available Books "

        Public Function AvailableBooks_LoadTV() As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel

            Dim BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel = Nothing
            Dim Markets As Generic.List(Of AdvantageFramework.Database.Entities.Market) = Nothing
            Dim NielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook) = Nothing

            BroadcastResearchViewModel = New AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel

            If Me.Session.IsNielsenSetup Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Markets = AdvantageFramework.Database.Procedures.Market.Load(DbContext).ToList

                    Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Me.Session.NielsenConnectionString, Nothing)

                        If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                            NielsenTVBooks = NielsenDbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)(String.Format("advsp_hosted_spottv_get_available_books '{0}'", Session.NielsenClientCodeForHosted)).ToList

                            For Each NielsenTVBook In NielsenTVBooks

                                NielsenTVBook.MonthName = NielsenTVBook.MonthName.Substring(0, 3)
                                NielsenTVBook.Year = NielsenTVBook.Year.ToString.Substring(2)

                                NielsenTVBook.SetMarketDescription(Markets)

                                BroadcastResearchViewModel.AvailableBooks_NielsenTVBooks.Add(NielsenTVBook)

                            Next

                        Else

                            BroadcastResearchViewModel.AvailableBooks_NielsenTVBooks = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.LoadValidated(NielsenDbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook(Entity, Markets)).ToList

                        End If

                    End Using

                End Using

            End If

            AvailableBooks_LoadTV = BroadcastResearchViewModel

        End Function
        Public Function AvailableBooks_LoadRadio() As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel

            Dim BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel = Nothing
            Dim Markets As Generic.List(Of AdvantageFramework.Database.Entities.Market) = Nothing
            Dim NielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod) = Nothing

            BroadcastResearchViewModel = New AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel

            If Me.Session.IsNielsenSetup Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Markets = AdvantageFramework.Database.Procedures.Market.Load(DbContext).ToList

                    Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Me.Session.NielsenConnectionString, Nothing)

                        If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                            NielsenRadioPeriods = NielsenDbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)(String.Format("advsp_hosted_spotradio_get_available_periods '{0}'", Session.NielsenClientCodeForHosted)).ToList

                            For Each NielsenRadioPeriod In NielsenRadioPeriods

                                NielsenRadioPeriod.SetMarketDescription(Markets)

                                BroadcastResearchViewModel.AvailableBooks_NielsenRadioPeriods.Add(NielsenRadioPeriod)

                            Next

                        Else

                            BroadcastResearchViewModel.AvailableBooks_NielsenRadioPeriods = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadValidated(NielsenDbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Media.NielsenRadioPeriod(Entity, Markets)).ToList

                        End If

                    End Using

                End Using

            End If

            AvailableBooks_LoadRadio = BroadcastResearchViewModel

        End Function

#End Region

#Region " National "

        Public Sub National_SetSelectedResearchCriteria(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ID As Integer)

            BroadcastResearchViewModel.NationalSelectedResearchCriteria = BroadcastResearchViewModel.NationalResearchCriteriaList.Where(Function(Entity) Entity.ID = ID).SingleOrDefault

        End Sub
        Public Sub National_SetReportType(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ReportType As Nullable(Of Short))

            BroadcastResearchViewModel.NationalSelectedResearchCriteria.ReportType = ReportType
            BroadcastResearchViewModel.NationalIsDirty = True

        End Sub
        Public Sub National_SetEthnicity(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, Ethnicity As String)

            BroadcastResearchViewModel.NationalSelectedResearchCriteria.Ethnicity = Ethnicity
            BroadcastResearchViewModel.NationalIsDirty = True

        End Sub
        Public Sub National_SetTimeType(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, TimeType As String)

            BroadcastResearchViewModel.NationalSelectedResearchCriteria.TimeType = TimeType
            BroadcastResearchViewModel.NationalIsDirty = True

        End Sub
        Public Sub National_SetStream(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, Stream As String)

            BroadcastResearchViewModel.NationalSelectedResearchCriteria.Stream = Stream
            BroadcastResearchViewModel.NationalIsDirty = True

        End Sub
        Public Sub National_SetShowAirings(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ShowAirings As Boolean)

            BroadcastResearchViewModel.NationalSelectedResearchCriteria.ShowAirings = ShowAirings
            BroadcastResearchViewModel.NationalIsDirty = True

        End Sub
        Public Sub National_SetShowProgramTypes(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ShowProgramTypes As Boolean)

            BroadcastResearchViewModel.NationalSelectedResearchCriteria.ShowProgramTypes = ShowProgramTypes
            BroadcastResearchViewModel.NationalIsDirty = True

        End Sub
        Public Function National_Delete(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ByRef ErrorMessage As String) As Boolean

            'objects 
            Dim Deleted As Boolean = True
            Dim MediaSpotNationalResearch As AdvantageFramework.Database.Entities.MediaSpotNationalResearch = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaSpotNationalResearch = AdvantageFramework.Database.Procedures.MediaSpotNationalResearch.LoadByID(DbContext, BroadcastResearchViewModel.NationalSelectedResearchCriteria.ID)

                If MediaSpotNationalResearch IsNot Nothing Then

                    Deleted = AdvantageFramework.Database.Procedures.MediaSpotNationalResearch.Delete(DbContext, MediaSpotNationalResearch, ErrorMessage)

                End If

            End Using

            National_Delete = Deleted

        End Function
        Public Function National_Load(ResearchID As Integer?) As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel

            'objects
            Dim BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel = Nothing
            Dim MediaSpotNationalResearch As AdvantageFramework.Database.Entities.MediaSpotNationalResearch = Nothing
            Dim SelectedMediaDemoIDs As Generic.List(Of Integer) = Nothing
            Dim SelectedMediaMetricIDs As IEnumerable(Of Integer) = Nothing
            Dim SelectedMediaNetworkIDs As IEnumerable(Of Integer) = Nothing
            Dim Dashboard As AdvantageFramework.Database.Entities.Dashboard = Nothing

            BroadcastResearchViewModel = New AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel

            BroadcastResearchViewModel.SelectedResearchTab = ViewModels.Media.BroadcastResearchViewModel.ResearchTab.National

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using NationalDbContext = New AdvantageFramework.National.Database.DbContext(Session.NationalConnectionString, Nothing)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        BroadcastResearchViewModel.NationalAddEnabled = True

                        BroadcastResearchViewModel.NationalResearchCriteriaList = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotNationalResearch.Load(DbContext).ToList
                                                                                   Select New AdvantageFramework.DTO.Media.National.ResearchCriteria(Entity)).ToList

                        BroadcastResearchViewModel.NationalNetworkList = (From Entity In AdvantageFramework.National.Database.Procedures.NationalNetwork.Load(NationalDbContext).ToList
                                                                          Select New AdvantageFramework.DTO.Media.National.Network(Entity)).ToList

                        If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                            'BroadcastResearchViewModel.SpotRadioCountyList = NielsenDbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.SpotRadioCounty.County)(String.Format("EXEC advsp_hosted_spotradio_nielsen_get_counties '{0}'", Session.NielsenClientCodeForHosted)).ToList

                        Else

                            'BroadcastResearchViewModel.SpotRadioCountyList = NielsenDbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.SpotRadioCounty.County)("EXEC advsp_spotradiocounty_get_counties").ToList

                        End If

                        If ResearchID.HasValue Then

                            MediaSpotNationalResearch = AdvantageFramework.Database.Procedures.MediaSpotNationalResearch.LoadByID(DbContext, ResearchID)

                            BroadcastResearchViewModel.NationalSelectedResearchCriteria = BroadcastResearchViewModel.NationalResearchCriteriaList.Where(Function(Entity) Entity.ID = ResearchID.Value).SingleOrDefault
                            BroadcastResearchViewModel.NationalSelectedResearchCriteria.DaysAndTime = New DTO.DaysAndTime(DTO.DaysAndTime.BroadcastTypes.National, MediaSpotNationalResearch)

                            SelectedMediaNetworkIDs = AdvantageFramework.Database.Procedures.MediaSpotNationalResearchNetwork.LoadByMediaSpotNationalResearchID(DbContext, ResearchID.Value).Select(Function(Entity) Entity.NationalNetworkID).ToArray

                            BroadcastResearchViewModel.NationalNetworkSelectedList = (From Entity In AdvantageFramework.National.Database.Procedures.NationalNetwork.Load(NationalDbContext).Where(Function(Entity) SelectedMediaNetworkIDs.Contains(Entity.ID) = True).ToList
                                                                                      Select New AdvantageFramework.DTO.Media.National.Network(Entity)).ToList

                            BroadcastResearchViewModel.NationalNetworkAvailableList = (From Entity In AdvantageFramework.National.Database.Procedures.NationalNetwork.Load(NationalDbContext).Where(Function(Entity) SelectedMediaNetworkIDs.Contains(Entity.ID) = False).ToList
                                                                                       Select New AdvantageFramework.DTO.Media.National.Network(Entity)).ToList

                            SelectedMediaDemoIDs = New Generic.List(Of Integer)

                            For Each MediaDemoID In AdvantageFramework.Database.Procedures.MediaSpotNationalResearchMediaDemo.LoadByMediaSpotNationalResearchID(DbContext, ResearchID.Value).OrderBy(Function(Entity) Entity.Order).Select(Function(Entity) Entity.MediaDemoID).ToList

                                BroadcastResearchViewModel.NationalDemographicSelectedList.Add(New AdvantageFramework.DTO.Media.National.Demographic(AdvantageFramework.Database.Procedures.MediaDemographic.LoadByID(DbContext, MediaDemoID)))

                                SelectedMediaDemoIDs.Add(MediaDemoID)

                            Next

                            BroadcastResearchViewModel.NationalDemographicAvailableList = (From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.LoadActiveNational(DbContext).Where(Function(Entity) SelectedMediaDemoIDs.Contains(Entity.ID) = False).ToList
                                                                                           Select New AdvantageFramework.DTO.Media.National.Demographic(Entity)).ToList

                            BroadcastResearchViewModel.NationalMetricSelectedList = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotNationalResearchMetric.LoadByMediaSpotNationalResearchID(DbContext, ResearchID.Value).OrderBy(Function(Entity) Entity.Order).ToList
                                                                                     Select New AdvantageFramework.DTO.Media.Metric(Entity)).ToList

                            SelectedMediaMetricIDs = (From Entity In BroadcastResearchViewModel.NationalMetricSelectedList
                                                      Select Entity.ID).ToArray

                            BroadcastResearchViewModel.NationalMetricAvailableList = (From Entity In AdvantageFramework.Database.Procedures.MediaMetric.Load(DbContext).Where(Function(Entity) SelectedMediaMetricIDs.Contains(Entity.ID) = False AndAlso
                                                                                                                                                                                     Entity.Type = "N").ToList
                                                                                      Select New AdvantageFramework.DTO.Media.Metric(Entity)).ToList

                        Else

                            BroadcastResearchViewModel.NationalSelectedResearchCriteria = Nothing

                        End If

                        BroadcastResearchViewModel.NationalResearchReportTypeList = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.NationalResearchReportType))
                                                                                     Select New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

                        BroadcastResearchViewModel.NationalResearchReportStreamList = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.NationalResearchStream))
                                                                                       Select New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

                        Dashboard = AdvantageFramework.Database.Procedures.Dashboard.LoadByDashboardType(DbContext, AdvantageFramework.Database.Entities.DashboardTypes.BroadcastResearchTool_National)

                        If Dashboard IsNot Nothing Then

                            BroadcastResearchViewModel.Dashboard = New AdvantageFramework.DTO.Dashboard(Dashboard)

                        Else

                            BroadcastResearchViewModel.Dashboard = New AdvantageFramework.DTO.Dashboard

                        End If

                        BroadcastResearchViewModel.NationalIsDirty = False

                    End Using

                End Using

            End Using

            BroadcastResearchViewModel.SpotRadioCountyReportDataTable = Nothing

            National_Load = BroadcastResearchViewModel

        End Function
        Public Sub National_MediaDemographicsAddToSelected(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                           AvailableMediaDemographicSelected As IEnumerable(Of AdvantageFramework.DTO.Media.National.Demographic))

            If AvailableMediaDemographicSelected IsNot Nothing AndAlso AvailableMediaDemographicSelected.Count > 0 Then

                For Each MediaDemographic In AvailableMediaDemographicSelected

                    BroadcastResearchViewModel.NationalDemographicSelectedList.Add(MediaDemographic)
                    BroadcastResearchViewModel.NationalDemographicAvailableList.Remove(MediaDemographic)

                Next

                BroadcastResearchViewModel.NationalIsDirty = True

            End If

        End Sub
        Public Sub National_MediaDemographicsRemoveFromSelected(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                                SelectedMediaDemographicSelected As IEnumerable(Of AdvantageFramework.DTO.Media.National.Demographic))

            If SelectedMediaDemographicSelected IsNot Nothing AndAlso SelectedMediaDemographicSelected.Count > 0 Then

                For Each MediaDemographic In SelectedMediaDemographicSelected

                    BroadcastResearchViewModel.NationalDemographicAvailableList.Add(MediaDemographic)
                    BroadcastResearchViewModel.NationalDemographicSelectedList.Remove(MediaDemographic)

                Next

                BroadcastResearchViewModel.NationalIsDirty = True

            End If

        End Sub
        Public Sub National_NetworksAddToSelected(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                  AvailableNetworksSelected As IEnumerable(Of AdvantageFramework.DTO.Media.National.Network))

            If AvailableNetworksSelected IsNot Nothing AndAlso AvailableNetworksSelected.Count > 0 Then

                For Each Network In AvailableNetworksSelected

                    BroadcastResearchViewModel.NationalNetworkSelectedList.Add(Network)
                    BroadcastResearchViewModel.NationalNetworkAvailableList.Remove(Network)

                Next

                BroadcastResearchViewModel.NationalIsDirty = True

            End If

        End Sub
        Public Sub National_NetworksRemoveFromSelected(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                       SelectedNetworksSelected As IEnumerable(Of AdvantageFramework.DTO.Media.National.Network))

            If SelectedNetworksSelected IsNot Nothing AndAlso SelectedNetworksSelected.Count > 0 Then

                For Each Network In SelectedNetworksSelected

                    BroadcastResearchViewModel.NationalNetworkAvailableList.Add(Network)
                    BroadcastResearchViewModel.NationalNetworkSelectedList.Remove(Network)

                Next

                BroadcastResearchViewModel.NationalIsDirty = True

            End If

        End Sub
        Public Sub National_MetricsAddToSelected(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                 AvailableMetricsSelected As IEnumerable(Of AdvantageFramework.DTO.Media.Metric))

            If AvailableMetricsSelected IsNot Nothing AndAlso AvailableMetricsSelected.Count > 0 Then

                For Each Metric In AvailableMetricsSelected

                    BroadcastResearchViewModel.NationalMetricSelectedList.Add(Metric)
                    BroadcastResearchViewModel.NationalMetricAvailableList.Remove(Metric)

                Next

                BroadcastResearchViewModel.NationalIsDirty = True

            End If

        End Sub
        Public Sub National_MetricsRemoveFromSelected(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                      SelectedMetricSelected As IEnumerable(Of AdvantageFramework.DTO.Media.Metric))

            If SelectedMetricSelected IsNot Nothing AndAlso SelectedMetricSelected.Count > 0 Then

                For Each Metric In SelectedMetricSelected

                    BroadcastResearchViewModel.NationalMetricAvailableList.Add(Metric)
                    BroadcastResearchViewModel.NationalMetricSelectedList.Remove(Metric)

                Next

                BroadcastResearchViewModel.NationalIsDirty = True

            End If

        End Sub
        Private Function National_RequiredDataPresent(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                      ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsPresent As Boolean = False

            ErrorMessage = String.Empty

            If BroadcastResearchViewModel.NationalSelectedResearchCriteria.StartDate.HasValue = False OrElse BroadcastResearchViewModel.NationalSelectedResearchCriteria.EndDate.HasValue = False Then

                ErrorMessage += vbCrLf & "Start date and end date are required."

            ElseIf BroadcastResearchViewModel.NationalSelectedResearchCriteria.StartDate.Value > BroadcastResearchViewModel.NationalSelectedResearchCriteria.EndDate.Value Then

                ErrorMessage += vbCrLf & "Start date must be less than end date."

            End If

            If (BroadcastResearchViewModel.NationalSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.NetworkFlowchart OrElse
                    BroadcastResearchViewModel.NationalSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.ProgramFlowchart) AndAlso
                    (BroadcastResearchViewModel.NationalDemographicSelectedList Is Nothing OrElse BroadcastResearchViewModel.NationalDemographicSelectedList.Count > 1) Then

                ErrorMessage += vbCrLf & "Only one demographic can be selected for a flowchart report."

            End If

            If (BroadcastResearchViewModel.NationalSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.NetworkFlowchart OrElse
                    BroadcastResearchViewModel.NationalSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.ProgramFlowchart) AndAlso
                    (BroadcastResearchViewModel.NationalMetricSelectedList Is Nothing OrElse BroadcastResearchViewModel.NationalMetricSelectedList.Count > 1) Then

                ErrorMessage += vbCrLf & "Only one metric can be selected for a flowchart report."

            End If

            If (BroadcastResearchViewModel.NationalSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.NetworkRanker OrElse
                    BroadcastResearchViewModel.NationalSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.ProgramRanker) AndAlso
                    (BroadcastResearchViewModel.NationalDemographicSelectedList Is Nothing OrElse BroadcastResearchViewModel.NationalDemographicSelectedList.Count > 10) Then

                ErrorMessage += vbCrLf & "A maximum of 10 demographics can be selected for a ranker report."

            End If

            If BroadcastResearchViewModel.NationalDemographicSelectedList Is Nothing OrElse BroadcastResearchViewModel.NationalDemographicSelectedList.Count = 0 Then

                ErrorMessage += vbCrLf & "At least one demographic must be selected."

            End If

            If BroadcastResearchViewModel.NationalNetworkSelectedList Is Nothing OrElse BroadcastResearchViewModel.NationalNetworkSelectedList.Count = 0 Then

                ErrorMessage += vbCrLf & "At least one network must be selected."

            End If

            If BroadcastResearchViewModel.NationalMetricSelectedList Is Nothing OrElse BroadcastResearchViewModel.NationalMetricSelectedList.Count = 0 Then

                ErrorMessage += vbCrLf & "At least one metric must be selected."

            End If

            If String.IsNullOrWhiteSpace(ErrorMessage) Then

                IsPresent = True

            End If

            National_RequiredDataPresent = IsPresent

        End Function
        Public Function National_Save(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim MediaSpotNationalResearch As AdvantageFramework.Database.Entities.MediaSpotNationalResearch = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MediaSpotNationalResearchMediaDemo As AdvantageFramework.Database.Entities.MediaSpotNationalResearchMediaDemo = Nothing
            Dim MediaSpotNationalResearchMetric As AdvantageFramework.Database.Entities.MediaSpotNationalResearchMetric = Nothing
            Dim MediaSpotNationalResearchNetwork As AdvantageFramework.Database.Entities.MediaSpotNationalResearchNetwork = Nothing
            Dim Order As Integer = 0
            Dim Saved As Boolean = False

            If National_RequiredDataPresent(BroadcastResearchViewModel, ErrorMessage) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    MediaSpotNationalResearch = AdvantageFramework.Database.Procedures.MediaSpotNationalResearch.LoadByID(DbContext, BroadcastResearchViewModel.NationalSelectedResearchCriteria.ID)

                    If MediaSpotNationalResearch IsNot Nothing Then

                        BroadcastResearchViewModel.NationalSelectedResearchCriteria.SaveToEntity(MediaSpotNationalResearch)

                        Try

                            DbContext.Database.Connection.Open()

                            DbTransaction = DbContext.Database.BeginTransaction

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_NATIONAL_RESEARCH_MEDIA_DEMO WHERE MEDIA_SPOT_NATIONAL_RESEARCH_ID = {0}", MediaSpotNationalResearch.ID))
                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_NATIONAL_RESEARCH_METRIC WHERE MEDIA_SPOT_NATIONAL_RESEARCH_ID = {0}", MediaSpotNationalResearch.ID))
                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_NATIONAL_RESEARCH_NETWORK WHERE MEDIA_SPOT_NATIONAL_RESEARCH_ID = {0}", MediaSpotNationalResearch.ID))

                            For Each Network In BroadcastResearchViewModel.NationalNetworkSelectedList

                                MediaSpotNationalResearchNetwork = New AdvantageFramework.Database.Entities.MediaSpotNationalResearchNetwork
                                MediaSpotNationalResearchNetwork.DbContext = DbContext

                                MediaSpotNationalResearchNetwork.MediaSpotNationalResearchID = MediaSpotNationalResearch.ID
                                MediaSpotNationalResearchNetwork.NationalNetworkID = Network.ID

                                DbContext.MediaSpotNationalResearchNetworks.Add(MediaSpotNationalResearchNetwork)

                            Next

                            Order = 1

                            For Each Demographic In BroadcastResearchViewModel.NationalDemographicSelectedList

                                MediaSpotNationalResearchMediaDemo = New AdvantageFramework.Database.Entities.MediaSpotNationalResearchMediaDemo
                                MediaSpotNationalResearchMediaDemo.DbContext = DbContext

                                MediaSpotNationalResearchMediaDemo.MediaSpotNationalResearchID = MediaSpotNationalResearch.ID
                                MediaSpotNationalResearchMediaDemo.Order = Order
                                MediaSpotNationalResearchMediaDemo.MediaDemoID = Demographic.ID

                                DbContext.MediaSpotNationalResearchMediaDemos.Add(MediaSpotNationalResearchMediaDemo)

                                Order += 1

                            Next

                            Order = 1

                            For Each Metric In BroadcastResearchViewModel.NationalMetricSelectedList

                                MediaSpotNationalResearchMetric = New AdvantageFramework.Database.Entities.MediaSpotNationalResearchMetric
                                MediaSpotNationalResearchMetric.DbContext = DbContext

                                MediaSpotNationalResearchMetric.MediaSpotNationalResearchID = MediaSpotNationalResearch.ID
                                MediaSpotNationalResearchMetric.Order = Order
                                MediaSpotNationalResearchMetric.MediaMetricID = Metric.ID

                                DbContext.MediaSpotNationalResearchMetrics.Add(MediaSpotNationalResearchMetric)

                                Order += 1

                            Next

                            DbContext.SaveChanges()

                            If AdvantageFramework.Database.Procedures.MediaSpotNationalResearch.Update(DbContext, MediaSpotNationalResearch, ErrorMessage) = False Then

                                Throw New Exception(ErrorMessage)

                            End If

                            DbTransaction.Commit()

                            Saved = True

                            BroadcastResearchViewModel.NationalIsDirty = False
                            BroadcastResearchViewModel.NationalReportDataTable = Nothing

                        Catch ex As Exception
                            ErrorMessage = ex.Message
                        Finally

                            If DbContext.Database.Connection.State = ConnectionState.Open Then

                                DbContext.Database.Connection.Close()

                            End If

                        End Try

                    Else

                        ErrorMessage = "This research criteria is no longer valid in the system."

                    End If

                End Using

            End If

            National_Save = Saved

        End Function
        Public Function National_ValidateDays(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ByRef Days As String) As Boolean

            'objects
            Dim DaysAndTimeController As AdvantageFramework.Controller.DaysAndTimeController = Nothing
            Dim IsValid As Boolean = True

            BroadcastResearchViewModel.NationalIsDirty = True

            DaysAndTimeController = New AdvantageFramework.Controller.DaysAndTimeController(Me.Session)

            DaysAndTimeController.ParseDays(BroadcastResearchViewModel.NationalSelectedResearchCriteria.DaysAndTime, Days, IsValid)

            BroadcastResearchViewModel.NationalSelectedResearchCriteria.DaysAndTime.Days = Days

            National_ValidateDays = IsValid

        End Function
        Public Function National_ValidateStartTime(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ByRef StartTime As String, ByRef ErrorText As String) As Boolean

            'objects
            Dim DaysAndTimeController As AdvantageFramework.Controller.DaysAndTimeController = Nothing
            Dim IsValid As Boolean = True

            BroadcastResearchViewModel.NationalIsDirty = True

            DaysAndTimeController = New AdvantageFramework.Controller.DaysAndTimeController(Me.Session)

            If StartTime IsNot Nothing Then

                StartTime = StartTime.Trim

            End If

            DaysAndTimeController.ParseTime(BroadcastResearchViewModel.NationalSelectedResearchCriteria.DaysAndTime, True, StartTime, IsValid)

            BroadcastResearchViewModel.NationalSelectedResearchCriteria.DaysAndTime.StartTime = StartTime

            If IsValid Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ErrorText = DaysAndTimeController.ValidateEntity(DbContext, DataContext, BroadcastResearchViewModel.NationalSelectedResearchCriteria.DaysAndTime, IsValid)

                    End Using

                End Using

            End If

            National_ValidateStartTime = IsValid

        End Function
        Public Function National_ValidateEndTime(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ByRef EndTime As String, ByRef ErrorText As String) As Boolean

            'objects
            Dim DaysAndTimeController As AdvantageFramework.Controller.DaysAndTimeController = Nothing
            Dim IsValid As Boolean = True

            BroadcastResearchViewModel.NationalIsDirty = True

            DaysAndTimeController = New AdvantageFramework.Controller.DaysAndTimeController(Me.Session)

            If EndTime IsNot Nothing Then

                EndTime = EndTime.Trim

            End If

            DaysAndTimeController.ParseTime(BroadcastResearchViewModel.NationalSelectedResearchCriteria.DaysAndTime, False, EndTime, IsValid)

            BroadcastResearchViewModel.NationalSelectedResearchCriteria.DaysAndTime.EndTime = EndTime

            If IsValid Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ErrorText = DaysAndTimeController.ValidateEntity(DbContext, DataContext, BroadcastResearchViewModel.NationalSelectedResearchCriteria.DaysAndTime, IsValid)

                    End Using

                End Using

            End If

            National_ValidateEndTime = IsValid

        End Function
        Public Function National_ValidateStartDate(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ByRef StartDate As Nullable(Of Date), ByRef ErrorText As String) As Boolean

            'objects
            Dim IsValid As Boolean = True

            BroadcastResearchViewModel.NationalIsDirty = True

            BroadcastResearchViewModel.NationalSelectedResearchCriteria.StartDate = StartDate

            If StartDate.HasValue AndAlso BroadcastResearchViewModel.NationalSelectedResearchCriteria.EndDate.HasValue Then

                If StartDate.Value > BroadcastResearchViewModel.NationalSelectedResearchCriteria.EndDate.Value Then

                    IsValid = False

                    ErrorText = "Start date must be before end date."

                End If

            End If

            National_ValidateStartDate = IsValid

        End Function
        Public Function National_ValidateEndDate(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ByRef EndDate As Nullable(Of Date), ByRef ErrorText As String) As Boolean

            'objects
            Dim IsValid As Boolean = True

            BroadcastResearchViewModel.NationalIsDirty = True

            BroadcastResearchViewModel.NationalSelectedResearchCriteria.StartDate = EndDate

            If EndDate.HasValue AndAlso BroadcastResearchViewModel.NationalSelectedResearchCriteria.EndDate.HasValue Then

                If EndDate.Value < BroadcastResearchViewModel.NationalSelectedResearchCriteria.StartDate.Value Then

                    IsValid = False

                    ErrorText = "End date must be after start date."

                End If

            End If

            National_ValidateEndDate = IsValid

        End Function
        Public Sub National_MoveMetric(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                       Metric As DTO.Media.Metric, Direction As MoveItemDirection)

            'objects
            Dim OldIndex As Integer = -1

            OldIndex = BroadcastResearchViewModel.NationalMetricSelectedList.IndexOf(Metric)

            BroadcastResearchViewModel.NationalMetricSelectedList.RemoveAt(OldIndex)

            If Direction = MoveItemDirection.Down Then

                BroadcastResearchViewModel.NationalMetricSelectedList.Insert(OldIndex + 1, Metric)

            Else

                BroadcastResearchViewModel.NationalMetricSelectedList.Insert(OldIndex - 1, Metric)

            End If

            BroadcastResearchViewModel.NationalIsDirty = True

        End Sub
        Public Function National_RunReport(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                           ByRef ErrorMessage As String,
                                           ByRef InfoMessage As String) As Boolean

            Dim Success As Boolean = False

            If BroadcastResearchViewModel.NationalSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.ProgramRanker OrElse
                    BroadcastResearchViewModel.NationalSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.NetworkRanker Then

                Success = National_RunRankerReport(BroadcastResearchViewModel, ErrorMessage, InfoMessage)

            ElseIf BroadcastResearchViewModel.NationalSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.ProgramFlowchart OrElse
                    BroadcastResearchViewModel.NationalSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.NetworkFlowchart Then

                Success = National_RunFlowchartReport(BroadcastResearchViewModel, ErrorMessage, InfoMessage)

            End If

            National_RunReport = Success

        End Function
        Public Function National_RunRankerReport(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                 ByRef ErrorMessage As String,
                                                 ByRef InfoMessage As String) As Boolean

            'objects
            Dim ResearchID As Integer = Nothing
            Dim MediaSpotNationalResearch As AdvantageFramework.Database.Entities.MediaSpotNationalResearch = Nothing
            Dim NationalNetworkIDs As IEnumerable(Of Integer) = Nothing
            Dim MediaDemographicIDs As IEnumerable(Of Integer) = Nothing
            Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTimeType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNationalNetworkIDs As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStartHour As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndHour As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMon As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTue As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterWed As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterThu As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFri As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSat As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSun As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBreakout As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRepeat As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSpecial As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPremiere As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOvernight As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCorrection As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStream As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterShowProgramTypes As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterShowAirings As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRankMetric As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaDemoType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaDemoDetailType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaSpotNationalResearchDemoType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNationalUniverseType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaMetricType As System.Data.SqlClient.SqlParameter = Nothing
            Dim MinYear As Nullable(Of Integer) = Nothing
            Dim MaxYear As Nullable(Of Integer) = Nothing
            Dim FindYear As Integer = 0
            Dim Universes As Generic.List(Of AdvantageFramework.DTO.Media.National.Universe) = Nothing
            Dim NationalUniverse As AdvantageFramework.National.Database.Entities.NationalUniverse = Nothing
            Dim LocalNationalUniverse As AdvantageFramework.Database.Entities.NationalUniverse = Nothing
            Dim IsEthnicityHispanic As Boolean = False
            Dim MediaSpotNationalResearchMetricList As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpotNationalResearchMetric) = Nothing
            Dim Success As Boolean = False
            Dim SqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing

            If National_RequiredDataPresent(BroadcastResearchViewModel, ErrorMessage) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    ResearchID = BroadcastResearchViewModel.NationalSelectedResearchCriteria.ID.Value

                    MediaSpotNationalResearch = AdvantageFramework.Database.Procedures.MediaSpotNationalResearch.LoadByID(DbContext, ResearchID)

                    NationalNetworkIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotNationalResearchNetwork.LoadByMediaSpotNationalResearchID(DbContext, ResearchID)
                                          Select Entity.NationalNetworkID).Distinct.ToArray

                    MediaSpotNationalResearchMetricList = AdvantageFramework.Database.Procedures.MediaSpotNationalResearchMetric.LoadByMediaSpotNationalResearchID(DbContext, ResearchID).ToList

                    SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@CLIENT_CODE", SqlDbType.Char)
                    SqlParameterClientCode.Value = Session.NielsenClientCodeForHosted

                    SqlParameterTimeType = New System.Data.SqlClient.SqlParameter("@TIME_TYPE", SqlDbType.Char)
                    SqlParameterTimeType.Value = MediaSpotNationalResearch.TimeType

                    SqlParameterNationalNetworkIDs = New System.Data.SqlClient.SqlParameter("@NATIONAL_NETWORK_IDS", SqlDbType.VarChar)
                    SqlParameterNationalNetworkIDs.Value = String.Join(",", NationalNetworkIDs.ToArray)

                    SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@STARTDATE", SqlDbType.SmallDateTime)
                    SqlParameterStartDate.Value = MediaSpotNationalResearch.StartDate.Value

                    SqlParameterEndDate = New System.Data.SqlClient.SqlParameter("@ENDDATE", SqlDbType.SmallDateTime)
                    SqlParameterEndDate.Value = MediaSpotNationalResearch.EndDate.Value

                    SqlParameterStartHour = New System.Data.SqlClient.SqlParameter("@STARTHOUR", SqlDbType.SmallInt)
                    SqlParameterStartHour.Value = MediaSpotNationalResearch.StartHour.Value

                    SqlParameterEndHour = New System.Data.SqlClient.SqlParameter("@ENDHOUR", SqlDbType.SmallInt)
                    SqlParameterEndHour.Value = MediaSpotNationalResearch.EndHour.Value

                    SqlParameterMon = New System.Data.SqlClient.SqlParameter("@MON", SqlDbType.Bit)
                    SqlParameterMon.Value = MediaSpotNationalResearch.Monday

                    SqlParameterTue = New System.Data.SqlClient.SqlParameter("@TUE", SqlDbType.Bit)
                    SqlParameterTue.Value = MediaSpotNationalResearch.Tuesday

                    SqlParameterWed = New System.Data.SqlClient.SqlParameter("@WED", SqlDbType.Bit)
                    SqlParameterWed.Value = MediaSpotNationalResearch.Wednesday

                    SqlParameterThu = New System.Data.SqlClient.SqlParameter("@THU", SqlDbType.Bit)
                    SqlParameterThu.Value = MediaSpotNationalResearch.Thursday

                    SqlParameterFri = New System.Data.SqlClient.SqlParameter("@FRI", SqlDbType.Bit)
                    SqlParameterFri.Value = MediaSpotNationalResearch.Friday

                    SqlParameterSat = New System.Data.SqlClient.SqlParameter("@SAT", SqlDbType.Bit)
                    SqlParameterSat.Value = MediaSpotNationalResearch.Saturday

                    SqlParameterSun = New System.Data.SqlClient.SqlParameter("@SUN", SqlDbType.Bit)
                    SqlParameterSun.Value = MediaSpotNationalResearch.Sunday

                    SqlParameterBreakout = New System.Data.SqlClient.SqlParameter("@BREAKOUT_FLAG", SqlDbType.Char)
                    SqlParameterBreakout.Value = MediaSpotNationalResearch.BreakoutFlag

                    SqlParameterRepeat = New System.Data.SqlClient.SqlParameter("@REPEAT_FLAG", SqlDbType.Char)
                    SqlParameterRepeat.Value = MediaSpotNationalResearch.RepeatsFlag

                    SqlParameterSpecial = New System.Data.SqlClient.SqlParameter("@SPECIAL_FLAG", SqlDbType.Char)
                    SqlParameterSpecial.Value = MediaSpotNationalResearch.SpecialsFlag

                    SqlParameterPremiere = New System.Data.SqlClient.SqlParameter("@PREMIERE_FLAG", SqlDbType.Char)
                    SqlParameterPremiere.Value = MediaSpotNationalResearch.PremieresFlag

                    SqlParameterOvernight = New System.Data.SqlClient.SqlParameter("@OVERNIGHT_FLAG", SqlDbType.Char)
                    SqlParameterOvernight.Value = MediaSpotNationalResearch.OvernightsFlag

                    SqlParameterCorrection = New System.Data.SqlClient.SqlParameter("@CORRECTION_FLAG", SqlDbType.Char)
                    SqlParameterCorrection.Value = MediaSpotNationalResearch.CorrectionsFlag

                    SqlParameterStream = New System.Data.SqlClient.SqlParameter("@STREAM", SqlDbType.VarChar)
                    SqlParameterStream.Value = MediaSpotNationalResearch.Stream

                    SqlParameterShowProgramTypes = New System.Data.SqlClient.SqlParameter("@SHOW_PROGRAM_TYPES", SqlDbType.Bit)
                    SqlParameterShowProgramTypes.Value = MediaSpotNationalResearch.ShowProgramTypes

                    SqlParameterShowAirings = New System.Data.SqlClient.SqlParameter("@SHOW_AIRINGS", SqlDbType.Bit)
                    SqlParameterShowAirings.Value = MediaSpotNationalResearch.ShowAirings

                    SqlParameterRankMetric = New System.Data.SqlClient.SqlParameter("@RANK_METRIC", SqlDbType.VarChar)
                    SqlParameterRankMetric.Value = MediaSpotNationalResearch.MediaSpotNationalResearchMetrics.Where(Function(M) M.Order = 1).Select(Function(M) M.MediaMetric.Description).First.Replace("/", "").Replace("%", "Percent")

                    SqlParameterMediaDemoType = New System.Data.SqlClient.SqlParameter("@MEDIA_DEMO_TYPE", SqlDbType.Structured)
                    SqlParameterMediaDemoType.TypeName = "MEDIA_DEMO_TYPE"
                    SqlParameterMediaDemoType.Value = AdvantageFramework.Database.ToDataTable((From Entity In AdvantageFramework.Database.Procedures.MediaSpotNationalResearchMediaDemo.LoadByMediaSpotNationalResearchID(DbContext, ResearchID)
                                                                                               Select Entity.MediaDemographic.ID,
                                                                                                      Entity.MediaDemographic.Description).ToList)

                    MediaDemographicIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotNationalResearchMediaDemo.LoadByMediaSpotNationalResearchID(DbContext, ResearchID)
                                           Select Entity.MediaDemoID).Distinct.ToArray

                    SqlParameterMediaDemoDetailType = New System.Data.SqlClient.SqlParameter("@MEDIA_DEMO_DETAIL_TYPE", SqlDbType.Structured)
                    SqlParameterMediaDemoDetailType.TypeName = "MEDIA_DEMO_DETAIL_TYPE"
                    SqlParameterMediaDemoDetailType.Value = AdvantageFramework.Database.ToDataTable((From Entity In AdvantageFramework.Database.Procedures.MediaDemographicDetail.Load(DbContext)
                                                                                                     Where MediaDemographicIDs.Contains(Entity.MediaDemographicID)
                                                                                                     Select Entity.MediaDemographicID,
                                                                                                            Entity.NielsenDemographicID).ToList)

                    SqlParameterMediaSpotNationalResearchDemoType = New System.Data.SqlClient.SqlParameter("@MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE", SqlDbType.Structured)
                    SqlParameterMediaSpotNationalResearchDemoType.TypeName = "MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE"
                    SqlParameterMediaSpotNationalResearchDemoType.Value = AdvantageFramework.Database.ToDataTable((From Entity In AdvantageFramework.Database.Procedures.MediaSpotNationalResearchMediaDemo.LoadByMediaSpotNationalResearchID(DbContext, ResearchID)
                                                                                                                   Select Entity.MediaDemoID,
                                                                                                                          Entity.Order).ToList)

                    Using NationalDbContext = New AdvantageFramework.National.Database.DbContext(Session.NationalConnectionString, Nothing)

                        Try

                            MinYear = (From Entity In AdvantageFramework.National.Database.Procedures.NationalYear.Load(NationalDbContext)
                                       Where Entity.StartDate <= MediaSpotNationalResearch.StartDate.Value AndAlso
                                             Entity.EndDate >= MediaSpotNationalResearch.StartDate.Value
                                       Select Entity.Year).SingleOrDefault

                            MaxYear = (From Entity In AdvantageFramework.National.Database.Procedures.NationalYear.Load(NationalDbContext)
                                       Where Entity.StartDate <= MediaSpotNationalResearch.EndDate.Value AndAlso
                                             Entity.EndDate >= MediaSpotNationalResearch.EndDate.Value
                                       Select Entity.Year).SingleOrDefault

                            If MinYear.HasValue = False Then

                                Throw New Exception("Could not find national year for start date of:" & MediaSpotNationalResearch.StartDate.Value.ToShortDateString)

                            ElseIf MaxYear.HasValue = False Then

                                Throw New Exception("Could not find national year for end date of:" & MediaSpotNationalResearch.EndDate.Value.ToShortDateString)

                            End If

                            Universes = New Generic.List(Of AdvantageFramework.DTO.Media.National.Universe)

                            IsEthnicityHispanic = If(MediaSpotNationalResearch.Ethnicity = Database.Entities.NationalResearchReportEthnicity.H.ToString, True, False)

                            For YR As Integer = MinYear To MaxYear

                                FindYear = YR

                                NationalUniverse = (From Entity In AdvantageFramework.National.Database.Procedures.NationalUniverse.Load(NationalDbContext)
                                                    Where Entity.Year = FindYear AndAlso
                                                          Entity.IsHispanic = IsEthnicityHispanic AndAlso
                                                          Entity.MarketBreakID = 1
                                                    Select Entity).SingleOrDefault

                                If NationalUniverse IsNot Nothing Then

                                    Universes.Add(New DTO.Media.National.Universe(NationalUniverse))

                                Else

                                    LocalNationalUniverse = (From Entity In AdvantageFramework.Database.Procedures.NationalUniverse.Load(DbContext)
                                                             Where Entity.Year = FindYear AndAlso
                                                                   Entity.IsHispanic = IsEthnicityHispanic AndAlso
                                                                   Entity.MarketBreakID = 1
                                                             Select Entity).SingleOrDefault

                                    If LocalNationalUniverse IsNot Nothing Then

                                        Universes.Add(New DTO.Media.National.Universe(LocalNationalUniverse))

                                    Else

                                        If IsEthnicityHispanic Then

                                            Throw New Exception("Missing Hispanic Universe for year: " & YR.ToString)

                                        Else

                                            Throw New Exception("Missing Universe for year: " & YR.ToString)

                                        End If

                                    End If

                                End If

                            Next

                            SqlParameterNationalUniverseType = New System.Data.SqlClient.SqlParameter("@NATIONAL_UNIVERSE_TYPE", SqlDbType.Structured)
                            SqlParameterNationalUniverseType.TypeName = "NATIONAL_UNIVERSE_TYPE"
                            SqlParameterNationalUniverseType.Value = AdvantageFramework.Database.ToDataTable((From Entity In Universes
                                                                                                              Select Entity.Year,
                                                                                                                     Entity.IsHispanic,
                                                                                                                     Entity.MarketBreakID,
                                                                                                                     Entity.Household,
                                                                                                                     Entity.Females2to5,
                                                                                                                     Entity.Females6to8,
                                                                                                                     Entity.Females9to11,
                                                                                                                     Entity.Females12to14,
                                                                                                                     Entity.Females15to17,
                                                                                                                     Entity.Females18to20,
                                                                                                                     Entity.Females21to24,
                                                                                                                     Entity.Females25to29,
                                                                                                                     Entity.Females30to34,
                                                                                                                     Entity.Females35to39,
                                                                                                                     Entity.Females40to44,
                                                                                                                     Entity.Females45to49,
                                                                                                                     Entity.Females50to54,
                                                                                                                     Entity.Females55to64,
                                                                                                                     Entity.Females65Plus,
                                                                                                                     Entity.Males2to5,
                                                                                                                     Entity.Males6to8,
                                                                                                                     Entity.Males9to11,
                                                                                                                     Entity.Males12to14,
                                                                                                                     Entity.Males15to17,
                                                                                                                     Entity.Males18to20,
                                                                                                                     Entity.Males21to24,
                                                                                                                     Entity.Males25to29,
                                                                                                                     Entity.Males30to34,
                                                                                                                     Entity.Males35to39,
                                                                                                                     Entity.Males40to44,
                                                                                                                     Entity.Males45to49,
                                                                                                                     Entity.Males50to54,
                                                                                                                     Entity.Males55to64,
                                                                                                                     Entity.Males65Plus,
                                                                                                                     Entity.WorkingWomen18to20,
                                                                                                                     Entity.WorkingWomen21to24,
                                                                                                                     Entity.WorkingWomen25to34,
                                                                                                                     Entity.WorkingWomen35to44,
                                                                                                                     Entity.WorkingWomen45to49,
                                                                                                                     Entity.WorkingWomen50to54,
                                                                                                                     Entity.WorkingWomen55Plus).ToList)

                            SqlParameterMediaMetricType = New System.Data.SqlClient.SqlParameter("@MEDIA_METRIC_TYPE", SqlDbType.Structured)
                            SqlParameterMediaMetricType.TypeName = "MEDIA_METRIC_TYPE"
                            SqlParameterMediaMetricType.Value = AdvantageFramework.Database.ToDataTable((From Entity In MediaSpotNationalResearchMetricList.ToList
                                                                                                         Select New With {.Description = Entity.MediaMetric.Description.Replace("/", "").Replace("%", "Percent"),
                                                                                                                          .Order = Entity.Order}).ToList)

                            BroadcastResearchViewModel.NationalReportDataTable = New System.Data.DataTable

                            SqlConnection = NationalDbContext.Database.Connection

                            If BroadcastResearchViewModel.NationalSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.ProgramRanker Then

                                SqlCommand = New System.Data.SqlClient.SqlCommand("advsp_national_research_program_ranker", SqlConnection)

                            ElseIf BroadcastResearchViewModel.NationalSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.NetworkRanker Then

                                SqlCommand = New System.Data.SqlClient.SqlCommand("advsp_national_research_network_ranker", SqlConnection)

                            End If

                            SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(SqlCommand)

                            Using SqlCommand

                                SqlCommand.CommandType = CommandType.StoredProcedure
                                SqlCommand.Parameters.Add(SqlParameterClientCode)
                                SqlCommand.Parameters.Add(SqlParameterTimeType)
                                SqlCommand.Parameters.Add(SqlParameterNationalNetworkIDs)
                                SqlCommand.Parameters.Add(SqlParameterStartDate)
                                SqlCommand.Parameters.Add(SqlParameterEndDate)
                                SqlCommand.Parameters.Add(SqlParameterStartHour)
                                SqlCommand.Parameters.Add(SqlParameterEndHour)
                                SqlCommand.Parameters.Add(SqlParameterMon)
                                SqlCommand.Parameters.Add(SqlParameterTue)
                                SqlCommand.Parameters.Add(SqlParameterWed)
                                SqlCommand.Parameters.Add(SqlParameterThu)
                                SqlCommand.Parameters.Add(SqlParameterFri)
                                SqlCommand.Parameters.Add(SqlParameterSat)
                                SqlCommand.Parameters.Add(SqlParameterSun)
                                SqlCommand.Parameters.Add(SqlParameterBreakout)
                                SqlCommand.Parameters.Add(SqlParameterRepeat)
                                SqlCommand.Parameters.Add(SqlParameterSpecial)
                                SqlCommand.Parameters.Add(SqlParameterPremiere)
                                SqlCommand.Parameters.Add(SqlParameterOvernight)
                                SqlCommand.Parameters.Add(SqlParameterCorrection)
                                SqlCommand.Parameters.Add(SqlParameterStream)
                                SqlCommand.Parameters.Add(SqlParameterShowProgramTypes)
                                SqlCommand.Parameters.Add(SqlParameterShowAirings)
                                SqlCommand.Parameters.Add(SqlParameterRankMetric)
                                SqlCommand.Parameters.Add(SqlParameterMediaDemoType)
                                SqlCommand.Parameters.Add(SqlParameterMediaDemoDetailType)
                                SqlCommand.Parameters.Add(SqlParameterMediaSpotNationalResearchDemoType)
                                SqlCommand.Parameters.Add(SqlParameterNationalUniverseType)
                                SqlCommand.Parameters.Add(SqlParameterMediaMetricType)

                                SqlDataAdapter.Fill(BroadcastResearchViewModel.NationalReportDataTable)

                            End Using

                            Success = True

                        Catch ex As Exception
                            ErrorMessage = ex.Message
                        End Try

                    End Using

                End Using

            End If

            National_RunRankerReport = Success

        End Function
        Public Sub National_MoveDemographic(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                            Demographic As DTO.Media.National.Demographic, Direction As MoveItemDirection)

            'objects
            Dim OldIndex As Integer = -1

            OldIndex = BroadcastResearchViewModel.NationalDemographicSelectedList.IndexOf(Demographic)

            BroadcastResearchViewModel.NationalDemographicSelectedList.RemoveAt(OldIndex)

            If Direction = MoveItemDirection.Down Then

                BroadcastResearchViewModel.NationalDemographicSelectedList.Insert(OldIndex + 1, Demographic)

            Else

                BroadcastResearchViewModel.NationalDemographicSelectedList.Insert(OldIndex - 1, Demographic)

            End If

            BroadcastResearchViewModel.NationalIsDirty = True

        End Sub
        Public Function National_RunFlowchartReport(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                    ByRef ErrorMessage As String,
                                                    ByRef InfoMessage As String) As Boolean

            'objects
            Dim ResearchID As Integer = Nothing
            Dim MediaSpotNationalResearch As AdvantageFramework.Database.Entities.MediaSpotNationalResearch = Nothing
            Dim NationalNetworkIDs As IEnumerable(Of Integer) = Nothing
            Dim MediaDemographicIDs As IEnumerable(Of Integer) = Nothing
            Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTimeType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNationalNetworkIDs As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStartHour As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndHour As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMon As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTue As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterWed As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterThu As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFri As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSat As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSun As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBreakout As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRepeat As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSpecial As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPremiere As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOvernight As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCorrection As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStream As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterShowProgramTypes As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterShowAirings As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaDemoType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaDemoDetailType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaSpotNationalResearchDemoType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNationalUniverseType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBroadcastDateType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMetric As System.Data.SqlClient.SqlParameter = Nothing
            Dim MinYear As Nullable(Of Integer) = Nothing
            Dim MaxYear As Nullable(Of Integer) = Nothing
            Dim FindYear As Integer = 0
            Dim Universes As Generic.List(Of AdvantageFramework.DTO.Media.National.Universe) = Nothing
            Dim NationalUniverse As AdvantageFramework.National.Database.Entities.NationalUniverse = Nothing
            Dim LocalNationalUniverse As AdvantageFramework.Database.Entities.NationalUniverse = Nothing
            Dim IsEthnicityHispanic As Boolean = False
            Dim BroadcastYearTypes As Generic.List(Of DTO.Media.National.BroadcastYearType) = Nothing
            Dim Success As Boolean = False
            Dim SqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing

            If National_RequiredDataPresent(BroadcastResearchViewModel, ErrorMessage) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    ResearchID = BroadcastResearchViewModel.NationalSelectedResearchCriteria.ID.Value

                    MediaSpotNationalResearch = AdvantageFramework.Database.Procedures.MediaSpotNationalResearch.LoadByID(DbContext, ResearchID)

                    NationalNetworkIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotNationalResearchNetwork.LoadByMediaSpotNationalResearchID(DbContext, ResearchID)
                                          Select Entity.NationalNetworkID).Distinct.ToArray

                    BroadcastYearTypes = DbContext.Database.SqlQuery(Of DTO.Media.National.BroadcastYearType)("SELECT YYYYMM = SUBSTRING(MMYYYY,3,4) + SUBSTRING(MMYYYY,1,2), StartDate = DATEADD(hh,6,BRD_WEEK_START), EndDate = DATEADD(ss,59,DATEADD(mi,59,DATEADD(hh,5,DATEADD(dd,1,CAST(BRD_WEEK_END as datetime))))) FROM dbo.fn_BroadcastCal2('12/31/2010')").ToList

                    SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@CLIENT_CODE", SqlDbType.Char)
                    SqlParameterClientCode.Value = Session.NielsenClientCodeForHosted

                    SqlParameterTimeType = New System.Data.SqlClient.SqlParameter("@TIME_TYPE", SqlDbType.Char)
                    SqlParameterTimeType.Value = MediaSpotNationalResearch.TimeType

                    SqlParameterNationalNetworkIDs = New System.Data.SqlClient.SqlParameter("@NATIONAL_NETWORK_IDS", SqlDbType.VarChar)
                    SqlParameterNationalNetworkIDs.Value = String.Join(",", NationalNetworkIDs.ToArray)

                    SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@STARTDATE", SqlDbType.SmallDateTime)
                    SqlParameterStartDate.Value = MediaSpotNationalResearch.StartDate.Value

                    SqlParameterEndDate = New System.Data.SqlClient.SqlParameter("@ENDDATE", SqlDbType.SmallDateTime)
                    SqlParameterEndDate.Value = MediaSpotNationalResearch.EndDate.Value

                    SqlParameterStartHour = New System.Data.SqlClient.SqlParameter("@STARTHOUR", SqlDbType.SmallInt)
                    SqlParameterStartHour.Value = MediaSpotNationalResearch.StartHour.Value

                    SqlParameterEndHour = New System.Data.SqlClient.SqlParameter("@ENDHOUR", SqlDbType.SmallInt)
                    SqlParameterEndHour.Value = MediaSpotNationalResearch.EndHour.Value

                    SqlParameterMon = New System.Data.SqlClient.SqlParameter("@MON", SqlDbType.Bit)
                    SqlParameterMon.Value = MediaSpotNationalResearch.Monday

                    SqlParameterTue = New System.Data.SqlClient.SqlParameter("@TUE", SqlDbType.Bit)
                    SqlParameterTue.Value = MediaSpotNationalResearch.Tuesday

                    SqlParameterWed = New System.Data.SqlClient.SqlParameter("@WED", SqlDbType.Bit)
                    SqlParameterWed.Value = MediaSpotNationalResearch.Wednesday

                    SqlParameterThu = New System.Data.SqlClient.SqlParameter("@THU", SqlDbType.Bit)
                    SqlParameterThu.Value = MediaSpotNationalResearch.Thursday

                    SqlParameterFri = New System.Data.SqlClient.SqlParameter("@FRI", SqlDbType.Bit)
                    SqlParameterFri.Value = MediaSpotNationalResearch.Friday

                    SqlParameterSat = New System.Data.SqlClient.SqlParameter("@SAT", SqlDbType.Bit)
                    SqlParameterSat.Value = MediaSpotNationalResearch.Saturday

                    SqlParameterSun = New System.Data.SqlClient.SqlParameter("@SUN", SqlDbType.Bit)
                    SqlParameterSun.Value = MediaSpotNationalResearch.Sunday

                    SqlParameterBreakout = New System.Data.SqlClient.SqlParameter("@BREAKOUT_FLAG", SqlDbType.Char)
                    SqlParameterBreakout.Value = MediaSpotNationalResearch.BreakoutFlag

                    SqlParameterRepeat = New System.Data.SqlClient.SqlParameter("@REPEAT_FLAG", SqlDbType.Char)
                    SqlParameterRepeat.Value = MediaSpotNationalResearch.RepeatsFlag

                    SqlParameterSpecial = New System.Data.SqlClient.SqlParameter("@SPECIAL_FLAG", SqlDbType.Char)
                    SqlParameterSpecial.Value = MediaSpotNationalResearch.SpecialsFlag

                    SqlParameterPremiere = New System.Data.SqlClient.SqlParameter("@PREMIERE_FLAG", SqlDbType.Char)
                    SqlParameterPremiere.Value = MediaSpotNationalResearch.PremieresFlag

                    SqlParameterOvernight = New System.Data.SqlClient.SqlParameter("@OVERNIGHT_FLAG", SqlDbType.Char)
                    SqlParameterOvernight.Value = MediaSpotNationalResearch.OvernightsFlag

                    SqlParameterCorrection = New System.Data.SqlClient.SqlParameter("@CORRECTION_FLAG", SqlDbType.Char)
                    SqlParameterCorrection.Value = MediaSpotNationalResearch.CorrectionsFlag

                    SqlParameterStream = New System.Data.SqlClient.SqlParameter("@STREAM", SqlDbType.VarChar)
                    SqlParameterStream.Value = MediaSpotNationalResearch.Stream

                    SqlParameterShowProgramTypes = New System.Data.SqlClient.SqlParameter("@SHOW_PROGRAM_TYPES", SqlDbType.Bit)
                    SqlParameterShowProgramTypes.Value = MediaSpotNationalResearch.ShowProgramTypes

                    SqlParameterShowAirings = New System.Data.SqlClient.SqlParameter("@SHOW_AIRINGS", SqlDbType.Bit)
                    SqlParameterShowAirings.Value = MediaSpotNationalResearch.ShowAirings

                    SqlParameterMediaDemoType = New System.Data.SqlClient.SqlParameter("@MEDIA_DEMO_TYPE", SqlDbType.Structured)
                    SqlParameterMediaDemoType.TypeName = "MEDIA_DEMO_TYPE"
                    SqlParameterMediaDemoType.Value = AdvantageFramework.Database.ToDataTable((From Entity In AdvantageFramework.Database.Procedures.MediaSpotNationalResearchMediaDemo.LoadByMediaSpotNationalResearchID(DbContext, ResearchID)
                                                                                               Select Entity.MediaDemographic.ID,
                                                                                                      Entity.MediaDemographic.Description).ToList)

                    MediaDemographicIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotNationalResearchMediaDemo.LoadByMediaSpotNationalResearchID(DbContext, ResearchID)
                                           Select Entity.MediaDemoID).Distinct.ToArray

                    SqlParameterMediaDemoDetailType = New System.Data.SqlClient.SqlParameter("@MEDIA_DEMO_DETAIL_TYPE", SqlDbType.Structured)
                    SqlParameterMediaDemoDetailType.TypeName = "MEDIA_DEMO_DETAIL_TYPE"
                    SqlParameterMediaDemoDetailType.Value = AdvantageFramework.Database.ToDataTable((From Entity In AdvantageFramework.Database.Procedures.MediaDemographicDetail.Load(DbContext)
                                                                                                     Where MediaDemographicIDs.Contains(Entity.MediaDemographicID)
                                                                                                     Select Entity.MediaDemographicID,
                                                                                                            Entity.NielsenDemographicID).ToList)

                    SqlParameterMediaSpotNationalResearchDemoType = New System.Data.SqlClient.SqlParameter("@MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE", SqlDbType.Structured)
                    SqlParameterMediaSpotNationalResearchDemoType.TypeName = "MEDIA_SPOT_NATIONAL_RESEARCH_DEMO_TYPE"
                    SqlParameterMediaSpotNationalResearchDemoType.Value = AdvantageFramework.Database.ToDataTable((From Entity In AdvantageFramework.Database.Procedures.MediaSpotNationalResearchMediaDemo.LoadByMediaSpotNationalResearchID(DbContext, ResearchID)
                                                                                                                   Select Entity.MediaDemoID,
                                                                                                                          Entity.Order).ToList)

                    Using NationalDbContext = New AdvantageFramework.National.Database.DbContext(Session.NationalConnectionString, Nothing)

                        Try

                            MinYear = (From Entity In AdvantageFramework.National.Database.Procedures.NationalYear.Load(NationalDbContext)
                                       Where Entity.StartDate <= MediaSpotNationalResearch.StartDate.Value AndAlso
                                             Entity.EndDate >= MediaSpotNationalResearch.StartDate.Value
                                       Select Entity.Year).SingleOrDefault

                            MaxYear = (From Entity In AdvantageFramework.National.Database.Procedures.NationalYear.Load(NationalDbContext)
                                       Where Entity.StartDate <= MediaSpotNationalResearch.EndDate.Value AndAlso
                                             Entity.EndDate >= MediaSpotNationalResearch.EndDate.Value
                                       Select Entity.Year).SingleOrDefault

                            If MinYear.HasValue = False Then

                                Throw New Exception("Could not find national year for start date of:" & MediaSpotNationalResearch.StartDate.Value.ToShortDateString)

                            ElseIf MaxYear.HasValue = False Then

                                Throw New Exception("Could not find national year for end date of:" & MediaSpotNationalResearch.EndDate.Value.ToShortDateString)

                            End If

                            Universes = New Generic.List(Of AdvantageFramework.DTO.Media.National.Universe)

                            IsEthnicityHispanic = If(MediaSpotNationalResearch.Ethnicity = Database.Entities.NationalResearchReportEthnicity.H.ToString, True, False)

                            For YR As Integer = MinYear To MaxYear

                                FindYear = YR

                                NationalUniverse = (From Entity In AdvantageFramework.National.Database.Procedures.NationalUniverse.Load(NationalDbContext)
                                                    Where Entity.Year = FindYear AndAlso
                                                          Entity.IsHispanic = IsEthnicityHispanic AndAlso
                                                          Entity.MarketBreakID = 1
                                                    Select Entity).SingleOrDefault

                                If NationalUniverse IsNot Nothing Then

                                    Universes.Add(New DTO.Media.National.Universe(NationalUniverse))

                                Else

                                    LocalNationalUniverse = (From Entity In AdvantageFramework.Database.Procedures.NationalUniverse.Load(DbContext)
                                                             Where Entity.Year = FindYear AndAlso
                                                                   Entity.IsHispanic = IsEthnicityHispanic AndAlso
                                                                   Entity.MarketBreakID = 1
                                                             Select Entity).SingleOrDefault

                                    If LocalNationalUniverse IsNot Nothing Then

                                        Universes.Add(New DTO.Media.National.Universe(LocalNationalUniverse))

                                    Else

                                        If IsEthnicityHispanic Then

                                            Throw New Exception("Missing Hispanic Universe for year: " & YR.ToString)

                                        Else

                                            Throw New Exception("Missing Universe for year: " & YR.ToString)

                                        End If

                                    End If

                                End If

                            Next

                            SqlParameterNationalUniverseType = New System.Data.SqlClient.SqlParameter("@NATIONAL_UNIVERSE_TYPE", SqlDbType.Structured)
                            SqlParameterNationalUniverseType.TypeName = "NATIONAL_UNIVERSE_TYPE"
                            SqlParameterNationalUniverseType.Value = AdvantageFramework.Database.ToDataTable((From Entity In Universes
                                                                                                              Select Entity.Year,
                                                                                                                     Entity.IsHispanic,
                                                                                                                     Entity.MarketBreakID,
                                                                                                                     Entity.Household,
                                                                                                                     Entity.Females2to5,
                                                                                                                     Entity.Females6to8,
                                                                                                                     Entity.Females9to11,
                                                                                                                     Entity.Females12to14,
                                                                                                                     Entity.Females15to17,
                                                                                                                     Entity.Females18to20,
                                                                                                                     Entity.Females21to24,
                                                                                                                     Entity.Females25to29,
                                                                                                                     Entity.Females30to34,
                                                                                                                     Entity.Females35to39,
                                                                                                                     Entity.Females40to44,
                                                                                                                     Entity.Females45to49,
                                                                                                                     Entity.Females50to54,
                                                                                                                     Entity.Females55to64,
                                                                                                                     Entity.Females65Plus,
                                                                                                                     Entity.Males2to5,
                                                                                                                     Entity.Males6to8,
                                                                                                                     Entity.Males9to11,
                                                                                                                     Entity.Males12to14,
                                                                                                                     Entity.Males15to17,
                                                                                                                     Entity.Males18to20,
                                                                                                                     Entity.Males21to24,
                                                                                                                     Entity.Males25to29,
                                                                                                                     Entity.Males30to34,
                                                                                                                     Entity.Males35to39,
                                                                                                                     Entity.Males40to44,
                                                                                                                     Entity.Males45to49,
                                                                                                                     Entity.Males50to54,
                                                                                                                     Entity.Males55to64,
                                                                                                                     Entity.Males65Plus,
                                                                                                                     Entity.WorkingWomen18to20,
                                                                                                                     Entity.WorkingWomen21to24,
                                                                                                                     Entity.WorkingWomen25to34,
                                                                                                                     Entity.WorkingWomen35to44,
                                                                                                                     Entity.WorkingWomen45to49,
                                                                                                                     Entity.WorkingWomen50to54,
                                                                                                                     Entity.WorkingWomen55Plus).ToList)

                            SqlParameterBroadcastDateType = New System.Data.SqlClient.SqlParameter("@BROADCAST_DATE_TYPE", SqlDbType.Structured)
                            SqlParameterBroadcastDateType.TypeName = "BROADCAST_DATE_TYPE"
                            SqlParameterBroadcastDateType.Value = AdvantageFramework.Database.ToDataTable((From Entity In BroadcastYearTypes
                                                                                                           Select Entity.YYYYMM,
                                                                                                                  Entity.StartDate,
                                                                                                                  Entity.EndDate).ToList)

                            SqlParameterMetric = New System.Data.SqlClient.SqlParameter("@SELECTED_METRIC", SqlDbType.VarChar)
                            SqlParameterMetric.Value = BroadcastResearchViewModel.NationalMetricSelectedList.First.Description.Replace("/", "").Replace("%", "Percent")

                            BroadcastResearchViewModel.NationalReportDataTable = New System.Data.DataTable

                            SqlConnection = NationalDbContext.Database.Connection

                            If BroadcastResearchViewModel.NationalSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.ProgramFlowchart Then

                                SqlCommand = New System.Data.SqlClient.SqlCommand("advsp_national_research_program_flowchart", SqlConnection)

                            ElseIf BroadcastResearchViewModel.NationalSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.NetworkFlowchart Then

                                SqlCommand = New System.Data.SqlClient.SqlCommand("advsp_national_research_network_flowchart", SqlConnection)

                            End If

                            SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter(SqlCommand)

                            Using SqlCommand

                                SqlCommand.CommandType = CommandType.StoredProcedure
                                SqlCommand.Parameters.Add(SqlParameterClientCode)
                                SqlCommand.Parameters.Add(SqlParameterTimeType)
                                SqlCommand.Parameters.Add(SqlParameterNationalNetworkIDs)
                                SqlCommand.Parameters.Add(SqlParameterStartDate)
                                SqlCommand.Parameters.Add(SqlParameterEndDate)
                                SqlCommand.Parameters.Add(SqlParameterStartHour)
                                SqlCommand.Parameters.Add(SqlParameterEndHour)
                                SqlCommand.Parameters.Add(SqlParameterMon)
                                SqlCommand.Parameters.Add(SqlParameterTue)
                                SqlCommand.Parameters.Add(SqlParameterWed)
                                SqlCommand.Parameters.Add(SqlParameterThu)
                                SqlCommand.Parameters.Add(SqlParameterFri)
                                SqlCommand.Parameters.Add(SqlParameterSat)
                                SqlCommand.Parameters.Add(SqlParameterSun)
                                SqlCommand.Parameters.Add(SqlParameterBreakout)
                                SqlCommand.Parameters.Add(SqlParameterRepeat)
                                SqlCommand.Parameters.Add(SqlParameterSpecial)
                                SqlCommand.Parameters.Add(SqlParameterPremiere)
                                SqlCommand.Parameters.Add(SqlParameterOvernight)
                                SqlCommand.Parameters.Add(SqlParameterCorrection)
                                SqlCommand.Parameters.Add(SqlParameterStream)
                                SqlCommand.Parameters.Add(SqlParameterShowProgramTypes)
                                SqlCommand.Parameters.Add(SqlParameterShowAirings)
                                SqlCommand.Parameters.Add(SqlParameterMediaDemoType)
                                SqlCommand.Parameters.Add(SqlParameterMediaDemoDetailType)
                                SqlCommand.Parameters.Add(SqlParameterMediaSpotNationalResearchDemoType)
                                SqlCommand.Parameters.Add(SqlParameterNationalUniverseType)
                                SqlCommand.Parameters.Add(SqlParameterBroadcastDateType)
                                SqlCommand.Parameters.Add(SqlParameterMetric)

                                SqlDataAdapter.Fill(BroadcastResearchViewModel.NationalReportDataTable)

                            End Using

                            Success = True

                        Catch ex As Exception
                            ErrorMessage = ex.Message
                        End Try

                    End Using

                End Using

            End If

            National_RunFlowchartReport = Success

        End Function
        'Private Function National_CreateProgramFlowchartReportDataTable(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
        '                                                                MediaSpotNationalResearchMetricList As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpotNationalResearchMetric)) As System.Data.DataTable

        '    'objects
        '    Dim DataTable As System.Data.DataTable = Nothing
        '    Dim Networks As Generic.List(Of String) = Nothing
        '    Dim DataColumn As System.Data.DataColumn = Nothing
        '    Dim DataRow As System.Data.DataRow = Nothing
        '    Dim ResearchResults As IEnumerable = Nothing
        '    Dim ResearchResultDTO As AdvantageFramework.DTO.Media.National.ResearchResult = Nothing

        '    DataTable = New System.Data.DataTable

        '    Networks = New Generic.List(Of String)

        '    DataColumn = DataTable.Columns.Add(AdvantageFramework.DTO.Media.National.ResearchResult.Properties.Network.ToString)
        '    DataColumn.DataType = GetType(String)

        '    DataColumn = DataTable.Columns.Add(AdvantageFramework.DTO.Media.National.ResearchResult.Properties.ProgramName.ToString)
        '    DataColumn.DataType = GetType(String)

        '    If BroadcastResearchViewModel.NationalSelectedResearchCriteria.ShowProgramTypes Then

        '        DataColumn = DataTable.Columns.Add(AdvantageFramework.DTO.Media.National.ResearchResult.Properties.ProgramType.ToString)
        '        DataColumn.DataType = GetType(String)

        '    End If

        '    If BroadcastResearchViewModel.NationalSelectedResearchCriteria.ShowAirings Then

        '        DataColumn = DataTable.Columns.Add(AdvantageFramework.DTO.Media.National.ResearchResult.Properties.Airings.ToString)
        '        DataColumn.DataType = GetType(Integer)

        '    End If

        '    For Each MonYear In (From Entity In BroadcastResearchViewModel.NationalResearchResultList.OrderBy(Function(Entity) Entity.YYYYMM)
        '                         Select Entity.MonthYear).Distinct.ToList

        '        DataColumn = DataTable.Columns.Add(MonYear)
        '        DataColumn.DataType = GetType(Decimal)

        '    Next

        '    If BroadcastResearchViewModel.NationalSelectedResearchCriteria.ShowProgramTypes AndAlso BroadcastResearchViewModel.NationalSelectedResearchCriteria.ShowAirings Then

        '        ResearchResults = (From Entity In BroadcastResearchViewModel.NationalResearchResultList
        '                           Select Entity.Network, Entity.ProgramName, Entity.ProgramType, Entity.Airings).Distinct.ToList

        '    ElseIf BroadcastResearchViewModel.NationalSelectedResearchCriteria.ShowProgramTypes Then

        '        ResearchResults = (From Entity In BroadcastResearchViewModel.NationalResearchResultList
        '                           Select Entity.Network, Entity.ProgramName, Entity.ProgramType).Distinct.ToList

        '    ElseIf BroadcastResearchViewModel.NationalSelectedResearchCriteria.ShowAirings Then

        '        ResearchResults = (From Entity In BroadcastResearchViewModel.NationalResearchResultList
        '                           Select Entity.Network, Entity.ProgramName, Entity.Airings).Distinct.ToList

        '    Else

        '        ResearchResults = (From Entity In BroadcastResearchViewModel.NationalResearchResultList
        '                           Select Entity.Network, Entity.ProgramName).Distinct.ToList

        '    End If

        '    For Each ResearchResult In ResearchResults

        '        DataRow = DataTable.NewRow

        '        DataRow(AdvantageFramework.DTO.Media.National.ResearchResult.Properties.Network.ToString) = ResearchResult.Network
        '        DataRow(AdvantageFramework.DTO.Media.National.ResearchResult.Properties.ProgramName.ToString) = ResearchResult.ProgramName

        '        If BroadcastResearchViewModel.NationalSelectedResearchCriteria.ShowProgramTypes Then

        '            DataRow(AdvantageFramework.DTO.Media.National.ResearchResult.Properties.ProgramType.ToString) = ResearchResult.ProgramType

        '        End If

        '        If BroadcastResearchViewModel.NationalSelectedResearchCriteria.ShowAirings Then

        '            DataRow(AdvantageFramework.DTO.Media.National.ResearchResult.Properties.Airings.ToString) = ResearchResult.Airings

        '        End If

        '        For Each NationalResearchResult In BroadcastResearchViewModel.NationalResearchResultList.OrderBy(Function(Entity) Entity.YYYYMM).Select(Function(Entity) Entity.MonthYear).Distinct.ToList

        '            ResearchResultDTO = (From Entity In BroadcastResearchViewModel.NationalResearchResultList
        '                                 Where Entity.Network = ResearchResult.Network AndAlso
        '                                       Entity.ProgramName = ResearchResult.ProgramName AndAlso
        '                                       Entity.MonthYear = NationalResearchResult
        '                                 Select Entity).FirstOrDefault

        '            If ResearchResultDTO IsNot Nothing Then

        '                Select Case BroadcastResearchViewModel.NationalMetricSelectedList.First.Description.Replace("/", "").Replace("%", "Percent")

        '                    Case AdvantageFramework.DTO.Media.National.ResearchResult.Properties.HPUT.ToString

        '                        DataRow(NationalResearchResult) = ResearchResultDTO.HPUT

        '                    Case AdvantageFramework.DTO.Media.National.ResearchResult.Properties.HPUTPercent.ToString

        '                        DataRow(NationalResearchResult) = ResearchResultDTO.HPUTPercent

        '                    Case AdvantageFramework.DTO.Media.National.ResearchResult.Properties.Impressions.ToString

        '                        DataRow(NationalResearchResult) = ResearchResultDTO.Impressions

        '                    Case AdvantageFramework.DTO.Media.National.ResearchResult.Properties.Rating.ToString

        '                        DataRow(NationalResearchResult) = ResearchResultDTO.Rating

        '                    Case AdvantageFramework.DTO.Media.National.ResearchResult.Properties.Share.ToString

        '                        DataRow(NationalResearchResult) = ResearchResultDTO.Share

        '                    Case AdvantageFramework.DTO.Media.National.ResearchResult.Properties.Universe.ToString

        '                        DataRow(NationalResearchResult) = ResearchResultDTO.Universe

        '                    Case AdvantageFramework.DTO.Media.National.ResearchResult.Properties.VPVH.ToString

        '                        DataRow(NationalResearchResult) = ResearchResultDTO.VPVH

        '                End Select

        '            End If

        '        Next

        '        DataTable.Rows.Add(DataRow)

        '    Next

        '    National_CreateProgramFlowchartReportDataTable = DataTable

        'End Function
        'Private Function National_CreateNetworkFlowchartReportDataTable(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
        '                                                                MediaSpotNationalResearchMetricList As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpotNationalResearchMetric)) As System.Data.DataTable

        '    'objects
        '    Dim DataTable As System.Data.DataTable = Nothing
        '    Dim DataColumn As System.Data.DataColumn = Nothing
        '    Dim DataRow As System.Data.DataRow = Nothing
        '    Dim SortString As String = Nothing
        '    Dim ResearchResults As IEnumerable = Nothing
        '    Dim ResearchResultDTO As AdvantageFramework.DTO.Media.National.ResearchResult = Nothing

        '    DataTable = New System.Data.DataTable

        '    DataColumn = DataTable.Columns.Add(AdvantageFramework.DTO.Media.National.ResearchResult.Properties.Network.ToString)
        '    DataColumn.DataType = GetType(String)

        '    If BroadcastResearchViewModel.NationalSelectedResearchCriteria.ShowProgramTypes Then

        '        DataColumn = DataTable.Columns.Add(AdvantageFramework.DTO.Media.National.ResearchResult.Properties.ProgramType.ToString)
        '        DataColumn.DataType = GetType(String)

        '    End If

        '    If BroadcastResearchViewModel.NationalSelectedResearchCriteria.ShowAirings Then

        '        DataColumn = DataTable.Columns.Add(AdvantageFramework.DTO.Media.National.ResearchResult.Properties.Airings.ToString)
        '        DataColumn.DataType = GetType(Integer)

        '    End If

        '    For Each MediaSpotNationalResearchMetric In MediaSpotNationalResearchMetricList.OrderBy(Function(Entity) Entity.Order)

        '        SortString += If(String.IsNullOrWhiteSpace(SortString), FormatDescription(MediaSpotNationalResearchMetric.MediaMetric.Description) & " DESC", ", " & FormatDescription(MediaSpotNationalResearchMetric.MediaMetric.Description) & " DESC")

        '    Next

        '    For Each MonYear In (From Entity In BroadcastResearchViewModel.NationalResearchResultList.OrderBy(Function(Entity) Entity.YYYYMM)
        '                         Select Entity.MonthYear).Distinct.ToList

        '        DataColumn = DataTable.Columns.Add(MonYear)
        '        DataColumn.DataType = GetType(Decimal)

        '    Next

        '    If BroadcastResearchViewModel.NationalSelectedResearchCriteria.ShowProgramTypes AndAlso BroadcastResearchViewModel.NationalSelectedResearchCriteria.ShowAirings Then

        '        ResearchResults = (From Entity In BroadcastResearchViewModel.NationalResearchResultList
        '                           Select Entity.Network, Entity.ProgramType, Entity.Airings).Distinct.ToList

        '    ElseIf BroadcastResearchViewModel.NationalSelectedResearchCriteria.ShowProgramTypes Then

        '        ResearchResults = (From Entity In BroadcastResearchViewModel.NationalResearchResultList
        '                           Select Entity.Network, Entity.ProgramType).Distinct.ToList

        '    ElseIf BroadcastResearchViewModel.NationalSelectedResearchCriteria.ShowAirings Then

        '        ResearchResults = (From Entity In BroadcastResearchViewModel.NationalResearchResultList
        '                           Select Entity.Network, Entity.Airings, ProgramType = "").Distinct.ToList

        '    Else

        '        ResearchResults = (From Entity In BroadcastResearchViewModel.NationalResearchResultList
        '                           Select Entity.Network, ProgramType = "").Distinct.ToList

        '    End If

        '    For Each ResearchResult In ResearchResults

        '        DataRow = DataTable.NewRow

        '        DataRow(AdvantageFramework.DTO.Media.National.ResearchResult.Properties.Network.ToString) = ResearchResult.Network

        '        If BroadcastResearchViewModel.NationalSelectedResearchCriteria.ShowProgramTypes Then

        '            DataRow(AdvantageFramework.DTO.Media.National.ResearchResult.Properties.ProgramType.ToString) = ResearchResult.ProgramType

        '        End If

        '        If BroadcastResearchViewModel.NationalSelectedResearchCriteria.ShowAirings Then

        '            DataRow(AdvantageFramework.DTO.Media.National.ResearchResult.Properties.Airings.ToString) = ResearchResult.Airings

        '        End If

        '        For Each NationalResearchResult In BroadcastResearchViewModel.NationalResearchResultList.OrderBy(Function(Entity) Entity.YYYYMM).Select(Function(Entity) Entity.MonthYear).Distinct.ToList

        '            ResearchResultDTO = (From Entity In BroadcastResearchViewModel.NationalResearchResultList
        '                                 Where Entity.Network = ResearchResult.Network AndAlso
        '                                       Entity.ProgramType = ResearchResult.ProgramType AndAlso
        '                                       Entity.MonthYear = NationalResearchResult
        '                                 Select Entity).FirstOrDefault

        '            If ResearchResultDTO IsNot Nothing Then

        '                Select Case BroadcastResearchViewModel.NationalMetricSelectedList.First.Description.Replace("/", "").Replace("%", "Percent")

        '                    Case AdvantageFramework.DTO.Media.National.ResearchResult.Properties.HPUT.ToString

        '                        DataRow(NationalResearchResult) = ResearchResultDTO.HPUT

        '                    Case AdvantageFramework.DTO.Media.National.ResearchResult.Properties.HPUTPercent.ToString

        '                        DataRow(NationalResearchResult) = ResearchResultDTO.HPUTPercent

        '                    Case AdvantageFramework.DTO.Media.National.ResearchResult.Properties.Impressions.ToString

        '                        DataRow(NationalResearchResult) = ResearchResultDTO.Impressions

        '                    Case AdvantageFramework.DTO.Media.National.ResearchResult.Properties.Rating.ToString

        '                        DataRow(NationalResearchResult) = ResearchResultDTO.Rating

        '                    Case AdvantageFramework.DTO.Media.National.ResearchResult.Properties.Share.ToString

        '                        DataRow(NationalResearchResult) = ResearchResultDTO.Share

        '                    Case AdvantageFramework.DTO.Media.National.ResearchResult.Properties.Universe.ToString

        '                        DataRow(NationalResearchResult) = ResearchResultDTO.Universe

        '                    Case AdvantageFramework.DTO.Media.National.ResearchResult.Properties.VPVH.ToString

        '                        DataRow(NationalResearchResult) = ResearchResultDTO.VPVH

        '                End Select

        '            End If

        '        Next

        '        DataTable.Rows.Add(DataRow)

        '    Next

        '    National_CreateNetworkFlowchartReportDataTable = DataTable

        'End Function

#End Region

#Region " Spot TV Puerto Rico "

        Public Function LoadSpotTVPuertoRico(ResearchID As Nullable(Of Integer)) As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel

            'objects
            Dim BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel = Nothing
            Dim Dashboard As AdvantageFramework.Database.Entities.Dashboard = Nothing

            BroadcastResearchViewModel = New AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel

            BroadcastResearchViewModel.SelectedResearchTab = ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTVPuertoRico

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If Session.IsNielsenPuertoRicoSetup Then

                    BroadcastResearchViewModel.SpotTVPuertoRicoAddEnabled = True

                End If

                BroadcastResearchViewModel.SpotTVPuertoRicoResearchCriteriaList = (From MediaSpotTVPuertoRicoResearch In DbContext.GetQuery(Of Database.Entities.MediaSpotTVPuertoRicoResearch).ToList
                                                                                   Select New AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchCriteria(MediaSpotTVPuertoRicoResearch)).ToList

                If ResearchID.HasValue Then

                    BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria = BroadcastResearchViewModel.SpotTVPuertoRicoResearchCriteriaList.Where(Function(Entity) Entity.ID = ResearchID.Value).SingleOrDefault

                    LoadTVPuertoRicoStationList(DbContext, ResearchID.Value, BroadcastResearchViewModel)

                    LoadTVPuertoRicoDemographicsList(DbContext, ResearchID.Value, BroadcastResearchViewModel)

                    LoadTVPuertoRicoMetricsList(DbContext, ResearchID.Value, BroadcastResearchViewModel)

                    BroadcastResearchViewModel.SpotTVPuertoRicoDayTimeList = (From Entity In (From Entity In DbContext.GetQuery(Of Database.Entities.MediaSpotTVPuertoRicoResearchDayTime)
                                                                                              Where Entity.MediaSpotTVPuertoRicoResearchID = ResearchID).ToList
                                                                              Select New AdvantageFramework.DTO.DaysAndTime(AdvantageFramework.DTO.DaysAndTime.BroadcastTypes.TVPuertoRico, Entity)).ToList

                Else

                    BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria = Nothing

                End If

                BroadcastResearchViewModel.SpotTVPuertoRicoResearchReportTypeList = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.SpotTVPuertoRicoResearchReportType))
                                                                                     Select New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

                Dashboard = AdvantageFramework.Database.Procedures.Dashboard.LoadByDashboardType(DbContext, AdvantageFramework.Database.Entities.DashboardTypes.BroadcastResearchTool_TVPuertoRico)

                If Dashboard IsNot Nothing Then

                    BroadcastResearchViewModel.Dashboard = New AdvantageFramework.DTO.Dashboard(Dashboard)

                Else

                    BroadcastResearchViewModel.Dashboard = New AdvantageFramework.DTO.Dashboard

                End If

            End Using

            BroadcastResearchViewModel.SpotTVPuertoRicoReportDataTable = Nothing

            LoadSpotTVPuertoRico = BroadcastResearchViewModel

        End Function
        Private Sub LoadTVPuertoRicoStationList(DbContext As AdvantageFramework.Database.DbContext, ResearchID As Integer,
                                                ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            'objects
            Dim AllStations As Generic.List(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Station) = Nothing
            Dim StationIDs As IEnumerable(Of Integer) = Nothing

            BroadcastResearchViewModel.SpotTVPuertoRicoAvailableStationList.Clear()
            BroadcastResearchViewModel.SpotTVPuertoRicoSelectedStationList.Clear()

            AllStations = (From NPRStation In DbContext.GetQuery(Of Database.Entities.NPRStation).ToList
                           Select New AdvantageFramework.DTO.Media.SpotTVPuertoRico.Station(NPRStation)).ToList

            StationIDs = (From MediaSpotTVPuertoRicoResearchStation In DbContext.GetQuery(Of Database.Entities.MediaSpotTVPuertoRicoResearchStation)
                          Where MediaSpotTVPuertoRicoResearchStation.MediaSpotTVPuertoRicoResearchID = ResearchID
                          Select MediaSpotTVPuertoRicoResearchStation.StationID).ToArray

            For Each Station In AllStations

                If StationIDs.Contains(Station.ID) Then

                    Station.IsSelected = True
                    BroadcastResearchViewModel.SpotTVPuertoRicoSelectedStationList.Add(Station)

                Else

                    Station.IsSelected = False
                    BroadcastResearchViewModel.SpotTVPuertoRicoAvailableStationList.Add(Station)

                End If

            Next

        End Sub
        Private Sub LoadTVPuertoRicoDemographicsList(DbContext As AdvantageFramework.Database.DbContext, ResearchID As Integer,
                                                     ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            'objects
            Dim SelectedMediaDemoIDs As IEnumerable(Of Integer) = Nothing

            BroadcastResearchViewModel.SpotTVPuertoRicoSelectedDemographicList = (From Entity In (From Entity In DbContext.GetQuery(Of Database.Entities.MediaSpotTVPuertoRicoResearchDemo).Include("MediaDemographic")
                                                                                                  Where Entity.MediaSpotTVPuertoRicoResearchID = ResearchID).ToList
                                                                                  Select New AdvantageFramework.DTO.Media.SpotTVPuertoRico.Demographic(Entity)).ToList

            SelectedMediaDemoIDs = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoSelectedDemographicList
                                    Select Entity.ID).ToArray

            BroadcastResearchViewModel.SpotTVPuertoRicoAvailableDemographicList = (From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.LoadActiveNielsenPuertoRicoTV(DbContext).Where(Function(Entity) SelectedMediaDemoIDs.Contains(Entity.ID) = False).OrderBy(Function(Entity) Entity.Description).ToList
                                                                                   Select New AdvantageFramework.DTO.Media.SpotTVPuertoRico.Demographic(Entity)).ToList

        End Sub
        Private Sub LoadTVPuertoRicoMetricsList(DbContext As AdvantageFramework.Database.DbContext, ResearchID As Integer,
                                                ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            'objects
            Dim SelectedMediaMetricIDs As IEnumerable(Of Integer) = Nothing

            BroadcastResearchViewModel.SpotTVPuertoRicoSelectedMetricList = (From Entity In (From Entity In DbContext.GetQuery(Of Database.Entities.MediaSpotTVPuertoRicoResearchMetric)
                                                                                             Where Entity.MediaSpotTVPuertoRicoResearchID = ResearchID).ToList
                                                                             Select New AdvantageFramework.DTO.Media.Metric(Entity)).ToList

            SelectedMediaMetricIDs = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoSelectedMetricList
                                      Select Entity.ID).ToArray

            BroadcastResearchViewModel.SpotTVPuertoRicoAvailableMetricList = (From Entity In AdvantageFramework.Database.Procedures.MediaMetric.Load(DbContext).Where(Function(Entity) SelectedMediaMetricIDs.Contains(Entity.ID) = False AndAlso
                                                                                                                                                                                       Entity.Type = "T").ToList
                                                                              Select New AdvantageFramework.DTO.Media.Metric(True, Entity)).ToList

        End Sub
        Public Function SaveSpotTVPuertoRico(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim MediaSpotTVPuertoRicoResearch As AdvantageFramework.Database.Entities.MediaSpotTVPuertoRicoResearch = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MediaSpotTVPuertoRicoResearchStation As AdvantageFramework.Database.Entities.MediaSpotTVPuertoRicoResearchStation = Nothing
            Dim MediaSpotTVPuertoRicoResearchDayTime As AdvantageFramework.Database.Entities.MediaSpotTVPuertoRicoResearchDayTime = Nothing
            Dim MediaSpotTVPuertoRicoResearchDemo As AdvantageFramework.Database.Entities.MediaSpotTVPuertoRicoResearchDemo = Nothing
            Dim MediaSpotTVPuertoRicoResearchMetric As AdvantageFramework.Database.Entities.MediaSpotTVPuertoRicoResearchMetric = Nothing
            Dim Order As Integer = 0
            Dim Saved As Boolean = False
            Dim DaysAndTimeController As AdvantageFramework.Controller.DaysAndTimeController = Nothing
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            If RequiredSpotTVPuertoRicoDataPresent(BroadcastResearchViewModel, ErrorMessage) Then

                DaysAndTimeController = New AdvantageFramework.Controller.DaysAndTimeController(Me.Session)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    MediaSpotTVPuertoRicoResearch = (From Entity In DbContext.GetQuery(Of Database.Entities.MediaSpotTVPuertoRicoResearch)
                                                     Where Entity.ID = BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ID
                                                     Select Entity).SingleOrDefault

                    If MediaSpotTVPuertoRicoResearch IsNot Nothing Then

                        BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria.SaveToEntity(MediaSpotTVPuertoRicoResearch)

                        Try

                            DbContext.Database.Connection.Open()

                            DbTransaction = DbContext.Database.BeginTransaction

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DEMO WHERE MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID = {0}", MediaSpotTVPuertoRicoResearch.ID))
                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_METRIC WHERE MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID = {0}", MediaSpotTVPuertoRicoResearch.ID))
                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_STATION WHERE MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID = {0}", MediaSpotTVPuertoRicoResearch.ID))
                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME WHERE MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID = {0}", MediaSpotTVPuertoRicoResearch.ID))

                            For Each Station In BroadcastResearchViewModel.SpotTVPuertoRicoSelectedStationList

                                MediaSpotTVPuertoRicoResearchStation = New AdvantageFramework.Database.Entities.MediaSpotTVPuertoRicoResearchStation
                                MediaSpotTVPuertoRicoResearchStation.DbContext = DbContext

                                MediaSpotTVPuertoRicoResearchStation.MediaSpotTVPuertoRicoResearchID = MediaSpotTVPuertoRicoResearch.ID
                                MediaSpotTVPuertoRicoResearchStation.StationID = Station.ID

                                DbContext.MediaSpotTVPuertoRicoResearchStations.Add(MediaSpotTVPuertoRicoResearchStation)

                            Next

                            For Each DaysAndTime In BroadcastResearchViewModel.SpotTVPuertoRicoDayTimeList

                                MediaSpotTVPuertoRicoResearchDayTime = New AdvantageFramework.Database.Entities.MediaSpotTVPuertoRicoResearchDayTime
                                MediaSpotTVPuertoRicoResearchDayTime.DbContext = DbContext

                                DaysAndTimeController.ParseDays(DaysAndTime, DaysAndTime.Days, True)
                                DaysAndTime.SaveToEntity(MediaSpotTVPuertoRicoResearchDayTime)

                                MediaSpotTVPuertoRicoResearchDayTime.MediaSpotTVPuertoRicoResearchID = MediaSpotTVPuertoRicoResearch.ID

                                DbContext.MediaSpotTVPuertoRicoResearchDayTimes.Add(MediaSpotTVPuertoRicoResearchDayTime)

                            Next

                            Order = 1

                            For Each Demographic In BroadcastResearchViewModel.SpotTVPuertoRicoSelectedDemographicList

                                MediaSpotTVPuertoRicoResearchDemo = New AdvantageFramework.Database.Entities.MediaSpotTVPuertoRicoResearchDemo
                                MediaSpotTVPuertoRicoResearchDemo.DbContext = DbContext

                                MediaSpotTVPuertoRicoResearchDemo.MediaSpotTVPuertoRicoResearchID = MediaSpotTVPuertoRicoResearch.ID
                                MediaSpotTVPuertoRicoResearchDemo.Order = Order
                                MediaSpotTVPuertoRicoResearchDemo.MediaDemoID = Demographic.ID

                                DbContext.MediaSpotTVPuertoRicoResearchDemos.Add(MediaSpotTVPuertoRicoResearchDemo)

                                Order += 1

                            Next

                            Order = 1

                            For Each Metric In BroadcastResearchViewModel.SpotTVPuertoRicoSelectedMetricList

                                MediaSpotTVPuertoRicoResearchMetric = New AdvantageFramework.Database.Entities.MediaSpotTVPuertoRicoResearchMetric
                                MediaSpotTVPuertoRicoResearchMetric.DbContext = DbContext

                                MediaSpotTVPuertoRicoResearchMetric.MediaSpotTVPuertoRicoResearchID = MediaSpotTVPuertoRicoResearch.ID
                                MediaSpotTVPuertoRicoResearchMetric.Order = Order
                                MediaSpotTVPuertoRicoResearchMetric.MediaMetricID = Metric.ID

                                DbContext.MediaSpotTVPuertoRicoResearchMetrics.Add(MediaSpotTVPuertoRicoResearchMetric)

                                Order += 1

                            Next

                            DbContext.SaveChanges()

                            DbContext.UpdateObject(MediaSpotTVPuertoRicoResearch)

                            ErrorMessage = MediaSpotTVPuertoRicoResearch.ValidateEntity(IsValid)

                            If IsValid Then

                                DbContext.SaveChanges()

                                Updated = True

                            Else

                                Throw New Exception(ErrorMessage)

                            End If

                            DbTransaction.Commit()

                            Saved = True

                            BroadcastResearchViewModel.SpotTVPuertoRicoIsDirty = False
                            BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList = Nothing
                            BroadcastResearchViewModel.SpotTVPuertoRicoReportDataTable = Nothing

                        Catch ex As Exception
                            ErrorMessage = ex.Message
                        Finally

                            If DbContext.Database.Connection.State = ConnectionState.Open Then

                                DbContext.Database.Connection.Close()

                            End If

                        End Try

                    Else

                        ErrorMessage = "This research criteria is no longer valid in the system."

                    End If

                End Using

            End If

            SaveSpotTVPuertoRico = Saved

        End Function
        Public Function DeleteSpotTVPuertoRico(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ByRef ErrorMessage As String) As Boolean

            'objects 
            Dim Deleted As Boolean = True
            Dim MediaSpotTVPuertoRicoResearch As AdvantageFramework.Database.Entities.MediaSpotTVPuertoRicoResearch = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaSpotTVPuertoRicoResearch = (From Entity In DbContext.GetQuery(Of Database.Entities.MediaSpotTVPuertoRicoResearch)
                                                 Where Entity.ID = BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ID
                                                 Select Entity).SingleOrDefault

                If MediaSpotTVPuertoRicoResearch IsNot Nothing Then

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DEMO WHERE MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID = {0}", MediaSpotTVPuertoRicoResearch.ID))
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_METRIC WHERE MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID = {0}", MediaSpotTVPuertoRicoResearch.ID))
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_STATION WHERE MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID = {0}", MediaSpotTVPuertoRicoResearch.ID))
                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DAYTIME WHERE MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID = {0}", MediaSpotTVPuertoRicoResearch.ID))

                        DbContext.DeleteEntityObject(MediaSpotTVPuertoRicoResearch)

                        DbContext.SaveChanges()

                        Deleted = True

                    Catch ex As Exception
                        Deleted = False
                    End Try

                End If

            End Using

            DeleteSpotTVPuertoRico = Deleted

        End Function
        Public Sub SetSelectedSpotTVPuertoRicoResearchCriteria(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ID As Integer)

            BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria = BroadcastResearchViewModel.SpotTVPuertoRicoResearchCriteriaList.Where(Function(Entity) Entity.ID = ID).SingleOrDefault

        End Sub
        Public Sub AddToSelectedPuertoRicoDemographics(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                       AvailableDemographicsSelected As IEnumerable(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Demographic))

            If AvailableDemographicsSelected IsNot Nothing AndAlso AvailableDemographicsSelected.Count > 0 Then

                For Each Demographic In AvailableDemographicsSelected

                    BroadcastResearchViewModel.SpotTVPuertoRicoSelectedDemographicList.Add(Demographic)
                    BroadcastResearchViewModel.SpotTVPuertoRicoAvailableDemographicList.Remove(Demographic)

                Next

                BroadcastResearchViewModel.SpotTVPuertoRicoIsDirty = True

            End If

        End Sub
        Public Sub RemoveFromSelectedPuertoRicoDemographics(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                            SelectedDemographicSelected As IEnumerable(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Demographic))

            If SelectedDemographicSelected IsNot Nothing AndAlso SelectedDemographicSelected.Count > 0 Then

                For Each Demographic In SelectedDemographicSelected

                    BroadcastResearchViewModel.SpotTVPuertoRicoAvailableDemographicList.Add(Demographic)
                    BroadcastResearchViewModel.SpotTVPuertoRicoSelectedDemographicList.Remove(Demographic)

                Next

                BroadcastResearchViewModel.SpotTVPuertoRicoIsDirty = True

            End If

        End Sub
        Public Sub MovePuertoRicoDemographic(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                             Demographic As DTO.Media.SpotTVPuertoRico.Demographic, Direction As MoveItemDirection)

            'objects
            Dim OldIndex As Integer = -1

            OldIndex = BroadcastResearchViewModel.SpotTVPuertoRicoSelectedDemographicList.IndexOf(Demographic)

            BroadcastResearchViewModel.SpotTVPuertoRicoSelectedDemographicList.RemoveAt(OldIndex)

            If Direction = MoveItemDirection.Down Then

                BroadcastResearchViewModel.SpotTVPuertoRicoSelectedDemographicList.Insert(OldIndex + 1, Demographic)

            Else

                BroadcastResearchViewModel.SpotTVPuertoRicoSelectedDemographicList.Insert(OldIndex - 1, Demographic)

            End If

            BroadcastResearchViewModel.SpotTVPuertoRicoIsDirty = True

        End Sub
        Public Sub AddToSelectedSpotTVPuertoRicoMetrics(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                        AvailableMetricsSelected As IEnumerable(Of AdvantageFramework.DTO.Media.Metric))

            If AvailableMetricsSelected IsNot Nothing AndAlso AvailableMetricsSelected.Count > 0 Then

                For Each Metric In AvailableMetricsSelected

                    BroadcastResearchViewModel.SpotTVPuertoRicoSelectedMetricList.Add(Metric)
                    BroadcastResearchViewModel.SpotTVPuertoRicoAvailableMetricList.Remove(Metric)

                Next

                BroadcastResearchViewModel.SpotTVPuertoRicoIsDirty = True

            End If

        End Sub
        Public Sub RemoveFromSelectedSpotTVPuertoRicoMetrics(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                             SelectedMetricSelected As IEnumerable(Of AdvantageFramework.DTO.Media.Metric))

            If SelectedMetricSelected IsNot Nothing AndAlso SelectedMetricSelected.Count > 0 Then

                For Each Metric In SelectedMetricSelected

                    BroadcastResearchViewModel.SpotTVPuertoRicoAvailableMetricList.Add(Metric)
                    BroadcastResearchViewModel.SpotTVPuertoRicoSelectedMetricList.Remove(Metric)

                Next

                BroadcastResearchViewModel.SpotTVPuertoRicoIsDirty = True

            End If

        End Sub
        Public Sub MoveMetricSpotTVPuertoRico(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                              Metric As DTO.Media.Metric, Direction As MoveItemDirection)

            'objects
            Dim OldIndex As Integer = -1

            OldIndex = BroadcastResearchViewModel.SpotTVPuertoRicoSelectedMetricList.IndexOf(Metric)

            BroadcastResearchViewModel.SpotTVPuertoRicoSelectedMetricList.RemoveAt(OldIndex)

            If Direction = MoveItemDirection.Down Then

                BroadcastResearchViewModel.SpotTVPuertoRicoSelectedMetricList.Insert(OldIndex + 1, Metric)

            Else

                BroadcastResearchViewModel.SpotTVPuertoRicoSelectedMetricList.Insert(OldIndex - 1, Metric)

            End If

            BroadcastResearchViewModel.SpotTVPuertoRicoIsDirty = True

        End Sub
        Public Sub AddToSelectedSpotTVPuertoRicoStations(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                         AvailableNielsenStationsSelected As IEnumerable(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Station))

            If AvailableNielsenStationsSelected IsNot Nothing AndAlso AvailableNielsenStationsSelected.Count > 0 Then

                For Each NielsenStation In AvailableNielsenStationsSelected

                    BroadcastResearchViewModel.SpotTVPuertoRicoSelectedStationList.Add(NielsenStation)
                    BroadcastResearchViewModel.SpotTVPuertoRicoAvailableStationList.Remove(NielsenStation)

                Next

                BroadcastResearchViewModel.SpotTVPuertoRicoIsDirty = True

            End If

        End Sub
        Public Sub RemoveFromSelectedSpotTVPuertoRicoStations(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                              SelectedNielsenStationsSelected As IEnumerable(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Station))

            If SelectedNielsenStationsSelected IsNot Nothing AndAlso SelectedNielsenStationsSelected.Count > 0 Then

                For Each NielsenStation In SelectedNielsenStationsSelected

                    BroadcastResearchViewModel.SpotTVPuertoRicoAvailableStationList.Add(NielsenStation)
                    BroadcastResearchViewModel.SpotTVPuertoRicoSelectedStationList.Remove(NielsenStation)

                Next

                BroadcastResearchViewModel.SpotTVPuertoRicoIsDirty = True

            End If

        End Sub
        Public Sub DeleteSelectedDayTimesPuertoRico(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                    SelectedDayTimes As Generic.List(Of DTO.DaysAndTime))

            If SelectedDayTimes IsNot Nothing AndAlso SelectedDayTimes.Count > 0 Then

                For Each SelectedDayTime In SelectedDayTimes

                    BroadcastResearchViewModel.SpotTVPuertoRicoDayTimeList.Remove(SelectedDayTime)

                Next

                BroadcastResearchViewModel.SpotTVPuertoRicoIsDirty = True

            End If

        End Sub
        Public Sub DayTimeCancelNewItemRowPuertoRico(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            BroadcastResearchViewModel.SpotTVPuertoRicoDayTimeIsNewRow = False
            BroadcastResearchViewModel.SpotTVPuertoRicoDayTimeCancelEnabled = False
            BroadcastResearchViewModel.SpotTVPuertoRicoDayTimeDeleteEnabled = BroadcastResearchViewModel.SpotTVPuertoRicoDayTimeList IsNot Nothing AndAlso BroadcastResearchViewModel.SpotTVPuertoRicoDayTimeList.Count > 0

        End Sub
        Public Sub DayTimeSelectionChangedPuertoRico(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                     IsNewItemRow As Boolean,
                                                     SelectedDayTimes As Generic.List(Of AdvantageFramework.DTO.DaysAndTime))

            BroadcastResearchViewModel.SpotTVPuertoRicoDayTimeIsNewRow = IsNewItemRow
            BroadcastResearchViewModel.SpotTVPuertoRicoDayTimeCancelEnabled = IsNewItemRow
            BroadcastResearchViewModel.SpotTVPuertoRicoDayTimeDeleteEnabled = Not IsNewItemRow

            BroadcastResearchViewModel.SpotTVPuertoRicoSelectedDayTimes = SelectedDayTimes

        End Sub
        Public Sub DayTimeAddNewRowPuertoRicoEvent(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            BroadcastResearchViewModel.SpotTVPuertoRicoIsDirty = True

        End Sub
        Public Sub DayTimeCellChangedPuertoRico(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            BroadcastResearchViewModel.SpotTVPuertoRicoIsDirty = True

        End Sub
        Public Sub DayTimeInitNewRowPuertoRicoEvent(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            BroadcastResearchViewModel.SpotTVPuertoRicoDayTimeIsNewRow = True
            BroadcastResearchViewModel.SpotTVPuertoRicoDayTimeCancelEnabled = True
            BroadcastResearchViewModel.SpotTVPuertoRicoDayTimeDeleteEnabled = False

        End Sub
        Public Sub PuertoRicoOptionGroupByDaysTimesChanged(Checked As Boolean, ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria.GroupByDaysTimes = Checked
            BroadcastResearchViewModel.SpotTVPuertoRicoIsDirty = True

        End Sub
        Public Sub PuertoRicoOptionShowProgramNameChanged(Checked As Boolean, ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ShowProgramName = Checked
            BroadcastResearchViewModel.SpotTVPuertoRicoIsDirty = True

        End Sub
        Public Sub PuertoRicoOptionSubtotalByWeekdayWeekendChanged(Checked As Boolean, ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria.SubtotalByWeekdayWeekend = Checked
            BroadcastResearchViewModel.SpotTVPuertoRicoIsDirty = True

        End Sub
        Public Sub PuertoRicoReportTypeChanged(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, ReportType As Short)

            BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ReportType = ReportType
            BroadcastResearchViewModel.SpotTVPuertoRicoIsDirty = True

        End Sub
        Public Sub PuertoRicoDatesChanged(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel)

            BroadcastResearchViewModel.SpotTVPuertoRicoIsDirty = True

        End Sub
        Private Function RequiredSpotTVPuertoRicoDataPresent(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                             ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsPresent As Boolean = False

            ErrorMessage = String.Empty

            If BroadcastResearchViewModel.SpotTVPuertoRicoSelectedStationList Is Nothing OrElse BroadcastResearchViewModel.SpotTVPuertoRicoSelectedStationList.Count = 0 Then

                ErrorMessage += vbCrLf & "At least one station must be selected."

            ElseIf BroadcastResearchViewModel.SpotTVPuertoRicoSelectedDayTimes Is Nothing OrElse BroadcastResearchViewModel.SpotTVPuertoRicoSelectedDayTimes.Count = 0 Then

                ErrorMessage += vbCrLf & "At least one day/time must be selected."

            ElseIf BroadcastResearchViewModel.SpotTVPuertoRicoSelectedDayTimes.Any(Function(Entity) Entity.HasError) Then

                ErrorMessage += vbCrLf & "Please fix day/time errors before saving."

            End If

            If BroadcastResearchViewModel.SpotTVPuertoRicoSelectedDemographicList Is Nothing OrElse BroadcastResearchViewModel.SpotTVPuertoRicoSelectedDemographicList.Count = 0 Then

                ErrorMessage += vbCrLf & "At least one demographic must be selected."

            ElseIf (BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVPuertoRicoResearchReportType.TrendByDate) AndAlso
                    BroadcastResearchViewModel.SpotTVPuertoRicoSelectedDemographicList.Count > 1 Then

                ErrorMessage += vbCrLf & "Only one demographic can be selected for a trend report."

            End If

            If BroadcastResearchViewModel.SpotTVPuertoRicoSelectedMetricList Is Nothing OrElse BroadcastResearchViewModel.SpotTVPuertoRicoSelectedMetricList.Count = 0 Then

                ErrorMessage += vbCrLf & "At least one metric must be selected."

            End If

            If String.IsNullOrWhiteSpace(ErrorMessage) Then

                IsPresent = True

            End If

            RequiredSpotTVPuertoRicoDataPresent = IsPresent

        End Function
        Public Function RunSpotTVPuertoRicoReport(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                  ByRef ErrorMessage As String,
                                                  ByRef InfoMessage As String)

            'objects
            Dim ResearchID As Integer = Nothing
            Dim StationIDs As Generic.List(Of Integer) = Nothing
            Dim MediaSpotTVPuertoRicoResearchMetricList As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpotTVPuertoRicoResearchMetric) = Nothing
            Dim Success As Boolean = False
            Dim CallLettersList As Generic.List(Of String) = Nothing
            Dim DemographicStreams As Integer = 0
            Dim StationDemographicStreamCount As Dictionary(Of Integer, Integer) = Nothing
            Dim StationDaytimeIDBookCount As Dictionary(Of Integer, Integer) = Nothing

            If RequiredSpotTVPuertoRicoDataPresent(BroadcastResearchViewModel, ErrorMessage) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    ResearchID = BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ID.Value

                    StationIDs = (From Entity In DbContext.GetQuery(Of Database.Entities.MediaSpotTVPuertoRicoResearchStation)
                                  Where Entity.MediaSpotTVPuertoRicoResearchID = ResearchID
                                  Select Entity.StationID).Distinct.ToList

                    If BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVPuertoRicoResearchReportType.Ranker Then

                        BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchResult)(String.Format("EXEC advsp_npr_spot_tv_puerto_rico_research_results {0}, '{1}'", ResearchID, String.Join(",", StationIDs.ToArray))).ToList()

                        'DemographicStreams = BroadcastResearchViewModel.SpotTVResearchResultList.Select(Function(Result) Result.DemographicStream).Distinct.Count

                        'If AdvantageFramework.Database.Procedures.MediaSpotTVResearchBook.LoadByMediaSpotTVResearchID(DbContext, ResearchID).Count > DemographicStreams Then

                        '    DemographicStreams = AdvantageFramework.Database.Procedures.MediaSpotTVResearchBook.LoadByMediaSpotTVResearchID(DbContext, ResearchID).Count

                        'End If

                        'StationDemographicStreamCount = (From Entity In (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                        '                                                 Select Entity.NielsenTVStationID, Entity.DemographicStream).Distinct.ToList
                        '                                 Group By Entity.NielsenTVStationID Into Group
                        '                                 Select New With {.NielsenTVStationID = NielsenTVStationID,
                        '                                                          .Count = Group.Count}).ToDictionary(Function(E) E.NielsenTVStationID, Function(E) E.Count)

                        'For Each KeyPair In StationDemographicStreamCount

                        '    If KeyPair.Value = DemographicStreams Then

                        '        NielsenStationIDs.Remove(KeyPair.Key)

                        '    End If

                        'Next

                    ElseIf (BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVPuertoRicoResearchReportType.TrendByDate) Then

                        BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchResult)(String.Format("EXEC advsp_npr_spot_tv_puerto_rico_research_results_trend {0}, '{1}'", ResearchID, String.Join(",", StationIDs.ToArray))).ToList()

                        'DaytimeIDBooks = (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                        '                  Select Entity.DaytimeID, Entity.Books).Distinct.Count

                        'If AdvantageFramework.Database.Procedures.MediaSpotTVResearchBook.LoadByMediaSpotTVResearchID(DbContext, ResearchID).Count > DaytimeIDBooks Then

                        '    DaytimeIDBooks = AdvantageFramework.Database.Procedures.MediaSpotTVResearchBook.LoadByMediaSpotTVResearchID(DbContext, ResearchID).Count

                        'End If

                        'StationDaytimeIDBookCount = (From Entity In (From Entity In BroadcastResearchViewModel.SpotTVResearchResultList
                        '                                             Select Entity.NielsenTVStationID, Entity.DaytimeID, Entity.Books).Distinct.ToList
                        '                             Group By Entity.NielsenTVStationID Into Group
                        '                             Select New With {.NielsenTVStationID = NielsenTVStationID,
                        '                                                      .Count = Group.Count}).ToDictionary(Function(E) E.NielsenTVStationID, Function(E) E.Count)

                        'For Each KeyPair In StationDaytimeIDBookCount

                        '    If KeyPair.Value = DaytimeIDBooks Then

                        '        NielsenStationIDs.Remove(KeyPair.Key)

                        '    End If

                        'Next

                    End If

                    'If NielsenStationIDs.Count > 0 Then

                    '    CallLettersList = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVStation.Load(NielsenDbContext)
                    '                       Where NielsenStationIDs.Contains(Entity.ID)
                    '                       Select Entity.CallLetters).ToList

                    '    InfoMessage = "The following " & CallLettersList.Count & " station(s) do not have data for all criteria selected: " & vbCrLf & String.Join(", ", CallLettersList.ToArray)

                    'End If

                    MediaSpotTVPuertoRicoResearchMetricList = (From Entity In DbContext.GetQuery(Of Database.Entities.MediaSpotTVPuertoRicoResearchMetric)
                                                               Where Entity.MediaSpotTVPuertoRicoResearchID = ResearchID
                                                               Select Entity).ToList

                    If BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVPuertoRicoResearchReportType.Ranker Then

                        BroadcastResearchViewModel.SpotTVPuertoRicoReportDataTable = CreateSpotTVPuertoRicoRankerReportDataTable(BroadcastResearchViewModel, MediaSpotTVPuertoRicoResearchMetricList)

                    ElseIf BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVPuertoRicoResearchReportType.TrendByDate Then

                        BroadcastResearchViewModel.SpotTVPuertoRicoReportDataTable = CreateSpotTVPuertoRicoTrendByDateReportDataTable(BroadcastResearchViewModel, MediaSpotTVPuertoRicoResearchMetricList)

                    End If

                    Success = True

                End Using

            End If

            RunSpotTVPuertoRicoReport = Success

        End Function
        Private Function CreateSpotTVPuertoRicoRankerReportDataTable(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                                     MediaSpotTVPuertoRicoResearchMetricList As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpotTVPuertoRicoResearchMetric)) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim SortString As String = Nothing
            Dim RankDataTable As System.Data.DataTable = Nothing
            Dim DataRowRank As Nullable(Of Integer) = Nothing
            Dim StationCodeDaytimeIDs As Generic.List(Of String) = Nothing
            Dim RankStationCode As Integer = Nothing
            Dim RankDaytimeID As Integer = Nothing
            Dim RankDataRow As System.Data.DataRow = Nothing

            DataTable = New System.Data.DataTable

            StationCodeDaytimeIDs = New Generic.List(Of String)

            DataColumn = DataTable.Columns.Add("StationCode")
            DataColumn.DataType = GetType(Integer)

            DataColumn = DataTable.Columns.Add("DaytimeID")
            DataColumn.DataType = GetType(Integer)

            DataColumn = DataTable.Columns.Add("Station")
            DataColumn.DataType = GetType(String)

            DataColumn = DataTable.Columns.Add("Days")
            DataColumn.DataType = GetType(String)

            DataColumn = DataTable.Columns.Add("Times")
            DataColumn.DataType = GetType(String)

            If BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ShowProgramName Then

                DataColumn = DataTable.Columns.Add("ProgramName")
                DataColumn.DataType = GetType(String)

            End If

            For Each Demo In (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                              Select Entity.DemographicOrder, Entity.Demographic).OrderBy(Function(Entity) Entity.DemographicOrder).Distinct.ToList

                DataColumn = DataTable.Columns.Add("Demo" & Demo.DemographicOrder)
                DataColumn.DataType = GetType(String)

                DataColumn = DataTable.Columns.Add("Rank" & Demo.DemographicOrder)
                DataColumn.DataType = GetType(Integer)

                For Each MediaSpotTVPuertoRicoResearchMetric In MediaSpotTVPuertoRicoResearchMetricList.OrderBy(Function(Entity) Entity.Order)

                    DataColumn = DataTable.Columns.Add(MediaSpotTVPuertoRicoResearchMetric.MediaMetric.Description.Replace("/", "") & Demo.DemographicOrder)
                    DataColumn.DataType = GetType(Decimal)

                    If SortString Is Nothing Then

                        SortString = MediaSpotTVPuertoRicoResearchMetric.MediaMetric.Description & " DESC"

                    End If
                    'SortString += If(String.IsNullOrWhiteSpace(SortString), MediaSpotTVResearchMetric.MediaMetric.Description & " DESC", ", " & MediaSpotTVResearchMetric.MediaMetric.Description & " DESC")

                Next

                DataColumn = DataTable.Columns.Add("ShowIntabWarning" & Demo.DemographicOrder)
                DataColumn.DataType = GetType(Boolean)

            Next

            For Each ResearchResult In (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                        Select Entity.StationID, Entity.Station, Entity.DaytimeID).Distinct.ToList

                DataRow = DataTable.NewRow

                DataRow("StationCode") = ResearchResult.StationID

                DataRow("DaytimeID") = ResearchResult.DaytimeID

                DataRow("Station") = ResearchResult.Station

                DataRow("Days") = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                   Where Entity.StationID = ResearchResult.StationID AndAlso
                                         Entity.DaytimeID = ResearchResult.DaytimeID
                                   Select Entity).FirstOrDefault.Days

                DataRow("Times") = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                    Where Entity.StationID = ResearchResult.StationID AndAlso
                                          Entity.DaytimeID = ResearchResult.DaytimeID
                                    Select Entity).FirstOrDefault.Times

                If BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ShowProgramName Then

                    DataRow("ProgramName") = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                              Where Entity.StationID = ResearchResult.StationID AndAlso
                                                    Entity.DaytimeID = ResearchResult.DaytimeID
                                              Select Entity).FirstOrDefault.ProgramName

                End If

                For Each DemoOrder In (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                       Where Entity.StationID = ResearchResult.StationID AndAlso
                                             Entity.DaytimeID = ResearchResult.DaytimeID
                                       Select Entity).OrderBy(Function(Entity) Entity.DemographicOrder).Distinct.ToList

                    DataRow("Demo" & DemoOrder.DemographicOrder) = DemoOrder.DemographicOrder

                    If DemoOrder.DemographicOrder = 1 OrElse Not BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria.MaxRank.HasValue Then

                        'rank
                        RankDataTable = AdvantageFramework.Database.ToDataTable((From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                                                                 Where Entity.DemographicOrder = DemoOrder.DemographicOrder
                                                                                 Select Entity).ToList)

                        RankDataTable.DefaultView.Sort = Replace(SortString, "/", "")

                        If MediaSpotTVPuertoRicoResearchMetricList IsNot Nothing AndAlso MediaSpotTVPuertoRicoResearchMetricList.Count > 0 Then

                            RankIt(RankDataTable, MediaSpotTVPuertoRicoResearchMetricList.OrderBy(Function(Entity) Entity.Order).FirstOrDefault.MediaMetric.Description.Replace("/", ""))

                        End If

                        If Not DataRowRank.HasValue Then

                            DataRowRank = RankDataTable.Select("StationID = " & ResearchResult.StationID & " AND DaytimeID = " & ResearchResult.DaytimeID).FirstOrDefault.Item("Rank")

                        End If

                        DataRow("Rank" & DemoOrder.DemographicOrder) = RankDataTable.Select("StationID = " & ResearchResult.StationID & " AND DaytimeID = " & ResearchResult.DaytimeID).FirstOrDefault.Item("Rank")

                    End If

                    For Each MediaSpotTVPuertoRicoResearchMetric In MediaSpotTVPuertoRicoResearchMetricList.OrderBy(Function(Entity) Entity.Order)

                        Select Case MediaSpotTVPuertoRicoResearchMetric.MediaMetric.Description.Replace("/", "")

                            Case "Rating"

                                DataRow(MediaSpotTVPuertoRicoResearchMetric.MediaMetric.Description.Replace("/", "") & DemoOrder.DemographicOrder) = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                                                                                                                                      Where Entity.StationID = ResearchResult.StationID AndAlso
                                                                                                                                                            Entity.DaytimeID = ResearchResult.DaytimeID AndAlso
                                                                                                                                                            Entity.DemographicOrder = DemoOrder.DemographicOrder
                                                                                                                                                      Select Entity).FirstOrDefault.Rating

                            Case "Share"

                                DataRow(MediaSpotTVPuertoRicoResearchMetric.MediaMetric.Description.Replace("/", "") & DemoOrder.DemographicOrder) = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                                                                                                                                      Where Entity.StationID = ResearchResult.StationID AndAlso
                                                                                                                                                            Entity.DaytimeID = ResearchResult.DaytimeID AndAlso
                                                                                                                                                            Entity.DemographicOrder = DemoOrder.DemographicOrder
                                                                                                                                                      Select Entity).FirstOrDefault.Share

                            Case "Impressions"

                                DataRow(MediaSpotTVPuertoRicoResearchMetric.MediaMetric.Description.Replace("/", "") & DemoOrder.DemographicOrder) = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                                                                                                                                      Where Entity.StationID = ResearchResult.StationID AndAlso
                                                                                                                                                            Entity.DaytimeID = ResearchResult.DaytimeID AndAlso
                                                                                                                                                            Entity.DemographicOrder = DemoOrder.DemographicOrder
                                                                                                                                                      Select Entity).FirstOrDefault.Impressions

                            Case "HPUT"

                                DataRow(MediaSpotTVPuertoRicoResearchMetric.MediaMetric.Description.Replace("/", "") & DemoOrder.DemographicOrder) = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                                                                                                                                      Where Entity.StationID = ResearchResult.StationID AndAlso
                                                                                                                                                            Entity.DaytimeID = ResearchResult.DaytimeID AndAlso
                                                                                                                                                            Entity.DemographicOrder = DemoOrder.DemographicOrder
                                                                                                                                                      Select Entity).FirstOrDefault.HPUT

                            Case "Intab"

                                DataRow(MediaSpotTVPuertoRicoResearchMetric.MediaMetric.Description.Replace("/", "") & DemoOrder.DemographicOrder) = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                                                                                                                                      Where Entity.StationID = ResearchResult.StationID AndAlso
                                                                                                                                                            Entity.DaytimeID = ResearchResult.DaytimeID AndAlso
                                                                                                                                                            Entity.DemographicOrder = DemoOrder.DemographicOrder
                                                                                                                                                      Select Entity).FirstOrDefault.Intab

                                DataRow("ShowIntabWarning" & DemoOrder.DemographicOrder) = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                                                                            Where Entity.StationID = ResearchResult.StationID AndAlso
                                                                                                  Entity.DaytimeID = ResearchResult.DaytimeID AndAlso
                                                                                                  Entity.DemographicOrder = DemoOrder.DemographicOrder
                                                                                            Select Entity).FirstOrDefault.ShowIntabWarning

                            Case "Universe"

                                DataRow(MediaSpotTVPuertoRicoResearchMetric.MediaMetric.Description.Replace("/", "") & DemoOrder.DemographicOrder) = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                                                                                                                                      Where Entity.StationID = ResearchResult.StationID AndAlso
                                                                                                                                                            Entity.DaytimeID = ResearchResult.DaytimeID AndAlso
                                                                                                                                                            Entity.DemographicOrder = DemoOrder.DemographicOrder
                                                                                                                                                      Select Entity).FirstOrDefault.Universe

                        End Select

                    Next

                Next

                If BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria.MaxRank.HasValue Then

                    If DataRowRank.Value <= BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria.MaxRank.Value Then

                        DataTable.Rows.Add(DataRow)

                        StationCodeDaytimeIDs.Add(ResearchResult.StationID.ToString & "|" & ResearchResult.DaytimeID.ToString)

                    End If

                    DataRowRank = Nothing

                Else

                    DataTable.Rows.Add(DataRow)

                End If

            Next

            For Each StationCodeDaytimeID In StationCodeDaytimeIDs

                RankStationCode = Left(StationCodeDaytimeID, InStr(StationCodeDaytimeID, "|") - 1)
                RankDaytimeID = Mid(StationCodeDaytimeID, InStr(StationCodeDaytimeID, "|") + 1)

                For Each DemoOrder In (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                       Where Entity.DemographicOrder > 1 AndAlso
                                             StationCodeDaytimeIDs.Contains(Entity.StationID & "|" & Entity.DaytimeID)
                                       Select Entity).OrderBy(Function(Entity) Entity.DemographicOrder).Distinct.ToList

                    'rank
                    RankDataTable = AdvantageFramework.Database.ToDataTable((From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                                                             Where Entity.DemographicOrder = DemoOrder.DemographicOrder AndAlso
                                                                                   StationCodeDaytimeIDs.Contains(Entity.StationID & "|" & Entity.DaytimeID)
                                                                             Select Entity).ToList)

                    RankDataTable.DefaultView.Sort = Replace(SortString, "/", "")

                    If MediaSpotTVPuertoRicoResearchMetricList IsNot Nothing AndAlso MediaSpotTVPuertoRicoResearchMetricList.Count > 0 Then

                        RankIt(RankDataTable, MediaSpotTVPuertoRicoResearchMetricList.OrderBy(Function(Entity) Entity.Order).FirstOrDefault.MediaMetric.Description.Replace("/", ""))

                    End If

                    RankDataRow = DataTable.Select("StationCode = " & RankStationCode & " AND DaytimeID = " & RankDaytimeID).FirstOrDefault
                    RankDataRow("Rank" & DemoOrder.DemographicOrder) = RankDataTable.Select("StationID = " & RankStationCode & " AND DaytimeID = " & RankDaytimeID).FirstOrDefault.Item("Rank")

                Next

            Next

            CreateSpotTVPuertoRicoRankerReportDataTable = DataTable

        End Function
        Public Sub SetTVPuertoRicoMaxRank(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, MaxRank As Nullable(Of Short))

            BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria.MaxRank = MaxRank

            BroadcastResearchViewModel.SpotTVPuertoRicoIsDirty = True

        End Sub
        Public Sub MoveDemographic(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                   Demographic As DTO.Media.SpotTVPuertoRico.Demographic, Direction As MoveItemDirection)

            'objects
            Dim OldIndex As Integer = -1

            OldIndex = BroadcastResearchViewModel.SpotTVPuertoRicoSelectedDemographicList.IndexOf(Demographic)

            BroadcastResearchViewModel.SpotTVPuertoRicoSelectedDemographicList.RemoveAt(OldIndex)

            If Direction = MoveItemDirection.Down Then

                BroadcastResearchViewModel.SpotTVPuertoRicoSelectedDemographicList.Insert(OldIndex + 1, Demographic)

            Else

                BroadcastResearchViewModel.SpotTVPuertoRicoSelectedDemographicList.Insert(OldIndex - 1, Demographic)

            End If

            BroadcastResearchViewModel.SpotTVPuertoRicoIsDirty = True

        End Sub
        Private Function CreateSpotTVPuertoRicoTrendByDateReportDataTable(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel,
                                                                          MediaSpotTVPuertoRicoResearchMetricList As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpotTVPuertoRicoResearchMetric)) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            DataTable = New System.Data.DataTable

            DataColumn = DataTable.Columns.Add("TrendDate")
            DataColumn.DataType = GetType(Date)

            DataColumn = DataTable.Columns.Add("Day")
            DataColumn.DataType = GetType(String)

            DataColumn = DataTable.Columns.Add("Times")
            DataColumn.DataType = GetType(String)

            DataColumn = DataTable.Columns.Add("DateDaytimeID")
            DataColumn.DataType = GetType(String)

            For Each Demo In (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                              Select Entity.StationID).Distinct.ToList

                DataColumn = DataTable.Columns.Add("Station_" & Demo.ToString)
                DataColumn.DataType = GetType(String)

                For Each MediaSpotTVPuertoRicoResearchMetric In MediaSpotTVPuertoRicoResearchMetricList.OrderBy(Function(Entity) Entity.Order)

                    DataColumn = DataTable.Columns.Add(MediaSpotTVPuertoRicoResearchMetric.MediaMetric.Description.Replace("/", "") & "_" & Demo.ToString)
                    DataColumn.DataType = GetType(Decimal)

                Next

                DataColumn = DataTable.Columns.Add("ShowIntabWarning_" & Demo.ToString)
                DataColumn.DataType = GetType(Boolean)

                If BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ShowProgramName Then

                    DataColumn = DataTable.Columns.Add("ProgramName_" & Demo.ToString)
                    DataColumn.DataType = GetType(String)

                End If

            Next

            For Each ResearchResult In (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                        Select Entity.TrendDate,
                                               Entity.DaytimeID,
                                               Entity.StartHour).Distinct.OrderBy(Function(Entity) Entity.TrendDate).ThenBy(Function(Entity) Entity.StartHour).ThenBy(Function(Entity) Entity.DaytimeID).ToList

                DataRow = DataTable.NewRow

                DataRow("DateDaytimeID") = ResearchResult.TrendDate.ToString & "|" & ResearchResult.DaytimeID.ToString

                DataRow("TrendDate") = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                        Where Entity.TrendDate = ResearchResult.TrendDate AndAlso
                                              Entity.DaytimeID = ResearchResult.DaytimeID
                                        Select Entity).FirstOrDefault.TrendDate

                Select Case CDate(DataRow("TrendDate")).DayOfWeek

                    Case DayOfWeek.Monday
                        DataRow("Day") = "M"

                    Case DayOfWeek.Tuesday
                        DataRow("Day") = "T"

                    Case DayOfWeek.Wednesday
                        DataRow("Day") = "W"

                    Case DayOfWeek.Thursday
                        DataRow("Day") = "Th"

                    Case DayOfWeek.Friday
                        DataRow("Day") = "F"

                    Case DayOfWeek.Saturday
                        DataRow("Day") = "Sa"

                    Case DayOfWeek.Sunday
                        DataRow("Day") = "Su"

                End Select

                'DataRow("Days") = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                '                   Where Entity.TrendDate = ResearchResult.TrendDate AndAlso
                '                         Entity.DaytimeID = ResearchResult.DaytimeID
                '                   Select Entity).FirstOrDefault.Days

                DataRow("Times") = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                    Where Entity.TrendDate = ResearchResult.TrendDate AndAlso
                                          Entity.DaytimeID = ResearchResult.DaytimeID
                                    Select Entity).FirstOrDefault.Times

                For Each StreamOrder In (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                         Where Entity.TrendDate = ResearchResult.TrendDate AndAlso
                                               Entity.DaytimeID = ResearchResult.DaytimeID
                                         Select Entity.StationID, Entity.TrendDate, Entity.DaytimeID, Entity.ProgramName).Distinct.ToList

                    DataRow("Station_" & StreamOrder.StationID) = StreamOrder.StationID

                    For Each MediaSpotTVPuertoRicoResearchMetric In MediaSpotTVPuertoRicoResearchMetricList.OrderBy(Function(Entity) Entity.Order)

                        Select Case MediaSpotTVPuertoRicoResearchMetric.MediaMetric.Description.Replace("/", "")

                            Case "Rating"

                                DataRow(MediaSpotTVPuertoRicoResearchMetric.MediaMetric.Description.Replace("/", "") & "_" & StreamOrder.StationID.ToString) = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                                                                                                                                                Where Entity.StationID = StreamOrder.StationID AndAlso
                                                                                                                                                                      Entity.DaytimeID = StreamOrder.DaytimeID AndAlso
                                                                                                                                                                      Entity.TrendDate = StreamOrder.TrendDate
                                                                                                                                                                Select Entity).FirstOrDefault.Rating

                            Case "Share"

                                DataRow(MediaSpotTVPuertoRicoResearchMetric.MediaMetric.Description.Replace("/", "") & "_" & StreamOrder.StationID.ToString) = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                                                                                                                                                Where Entity.StationID = StreamOrder.StationID AndAlso
                                                                                                                                                                      Entity.DaytimeID = StreamOrder.DaytimeID AndAlso
                                                                                                                                                                      Entity.TrendDate = StreamOrder.TrendDate
                                                                                                                                                                Select Entity).FirstOrDefault.Share

                            Case "Impressions"

                                DataRow(MediaSpotTVPuertoRicoResearchMetric.MediaMetric.Description.Replace("/", "") & "_" & StreamOrder.StationID.ToString) = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                                                                                                                                                Where Entity.StationID = StreamOrder.StationID AndAlso
                                                                                                                                                                      Entity.DaytimeID = StreamOrder.DaytimeID AndAlso
                                                                                                                                                                      Entity.TrendDate = StreamOrder.TrendDate
                                                                                                                                                                Select Entity).FirstOrDefault.Impressions

                            Case "HPUT"

                                DataRow(MediaSpotTVPuertoRicoResearchMetric.MediaMetric.Description.Replace("/", "") & "_" & StreamOrder.StationID.ToString) = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                                                                                                                                                Where Entity.StationID = StreamOrder.StationID AndAlso
                                                                                                                                                                      Entity.DaytimeID = StreamOrder.DaytimeID AndAlso
                                                                                                                                                                      Entity.TrendDate = StreamOrder.TrendDate
                                                                                                                                                                Select Entity).FirstOrDefault.HPUT

                            Case "Intab"

                                DataRow(MediaSpotTVPuertoRicoResearchMetric.MediaMetric.Description.Replace("/", "") & "_" & StreamOrder.StationID.ToString) = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                                                                                                                                                Where Entity.StationID = StreamOrder.StationID AndAlso
                                                                                                                                                                      Entity.DaytimeID = StreamOrder.DaytimeID AndAlso
                                                                                                                                                                      Entity.TrendDate = StreamOrder.TrendDate
                                                                                                                                                                Select Entity).FirstOrDefault.Intab

                                DataRow("ShowIntabWarning" & "_" & StreamOrder.StationID.ToString) = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                                                                                      Where Entity.StationID = StreamOrder.StationID AndAlso
                                                                                                            Entity.DaytimeID = StreamOrder.DaytimeID AndAlso
                                                                                                            Entity.TrendDate = StreamOrder.TrendDate
                                                                                                      Select Entity).FirstOrDefault.ShowIntabWarning

                            Case "Universe"

                                DataRow(MediaSpotTVPuertoRicoResearchMetric.MediaMetric.Description.Replace("/", "") & "_" & StreamOrder.StationID.ToString) = (From Entity In BroadcastResearchViewModel.SpotTVPuertoRicoResearchResultList
                                                                                                                                                                Where Entity.StationID = StreamOrder.StationID AndAlso
                                                                                                                                                                      Entity.DaytimeID = StreamOrder.DaytimeID AndAlso
                                                                                                                                                                      Entity.TrendDate = StreamOrder.TrendDate
                                                                                                                                                                Select Entity).FirstOrDefault.Universe

                        End Select

                    Next

                    If BroadcastResearchViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ShowProgramName Then

                        DataRow("ProgramName" & "_" & StreamOrder.StationID) = StreamOrder.ProgramName

                    End If

                Next

                DataTable.Rows.Add(DataRow)

            Next

            CreateSpotTVPuertoRicoTrendByDateReportDataTable = DataTable

        End Function
        Public Sub SaveTVPuertoRicoDashboard(ByRef BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, DashboardLayout() As Byte)

            'objects
            Dim Dashboard As AdvantageFramework.Database.Entities.Dashboard = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Dashboard = AdvantageFramework.Database.Procedures.Dashboard.LoadByDashboardType(DbContext, AdvantageFramework.Database.Entities.DashboardTypes.BroadcastResearchTool_TVPuertoRico)

                If Dashboard IsNot Nothing Then

                    Dashboard.Layout = DashboardLayout

                    AdvantageFramework.Database.Procedures.Dashboard.Update(DbContext, Dashboard)

                Else

                    Dashboard = New AdvantageFramework.Database.Entities.Dashboard

                    Dashboard.DbContext = DbContext
                    Dashboard.Type = AdvantageFramework.Database.Entities.DashboardTypes.BroadcastResearchTool_TVPuertoRico
                    Dashboard.Layout = DashboardLayout

                    AdvantageFramework.Database.Procedures.Dashboard.Insert(DbContext, Dashboard)

                End If

            End Using

            BroadcastResearchViewModel.Dashboard.Layout = DashboardLayout

        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace
