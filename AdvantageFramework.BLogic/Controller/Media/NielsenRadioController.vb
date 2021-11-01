Namespace Controller.Media

	Public Class NielsenRadioController
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


#Region " Public "

		Public Sub New(Session As AdvantageFramework.Security.Session)

			MyBase.New(Session)

		End Sub
        Public Function LoadNieslenRadioPeriods(NielsenRadioMarketNumber As Integer, Ethnicity As Integer,
                                                GeoIndicator As Short, ExcludeNielsenRadioPeriodIDs As Generic.List(Of Integer), Source As Nielsen.Database.Entities.RadioSource) As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)

            'objects
            Dim NielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod) = Nothing
            Dim ReportTypeCodes As IEnumerable(Of String) = Nothing
            Dim ClientNielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod) = Nothing
            Dim GeoNielsenRadioPeriodIDs As Generic.List(Of Integer) = Nothing

            If Me.Session.IsNielsenSetup Then

                Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                    If Ethnicity = 1 Then

                        ReportTypeCodes = {"1", "5", "4", "6", "9"}

                    ElseIf Ethnicity = 2 Then

                        ReportTypeCodes = {"2", "7"}

                    ElseIf Ethnicity = 3 Then

                        ReportTypeCodes = {"3", "8"}

                    End If

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        GeoNielsenRadioPeriodIDs = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioSegmentParent.Load(NielsenDbContext).Where(Function(Entity) Entity.GeoIndicator = GeoIndicator).Select(Function(Entity) Entity.NielsenRadioPeriodID).Distinct.ToList

                        If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                            ClientNielsenRadioPeriods = NielsenDbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod)(String.Format("EXEC advsp_nielsen_spot_radio_get_client_periods '{0}'", Session.NielsenClientCodeForHosted)).ToList

                            NielsenRadioPeriods = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadByNielsenRadioMarketNumberAndNielsenRadioReportTypeCodesAndSource(NielsenDbContext, NielsenRadioMarketNumber, ReportTypeCodes, ExcludeNielsenRadioPeriodIDs, Source).ToList
                                                   Select New AdvantageFramework.DTO.Media.NielsenRadioPeriod(Entity)).OrderByDescending(Function(Entity) Entity.Year).ThenByDescending(Function(Entity) Entity.SortMonth).ToList

                            NielsenRadioPeriods = (From Entity In NielsenRadioPeriods
                                                   Join NRP In ClientNielsenRadioPeriods On Entity.ID Equals NRP.NielsenRadioPeriodID And Entity.Month Equals NRP.Month And Entity.Year Equals NRP.Year
                                                   Select Entity).ToList

                        Else

                            NielsenRadioPeriods = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadByNielsenRadioMarketNumberAndNielsenRadioReportTypeCodesAndSource(NielsenDbContext, NielsenRadioMarketNumber, ReportTypeCodes, ExcludeNielsenRadioPeriodIDs, Source).ToList
                                                   Select New AdvantageFramework.DTO.Media.NielsenRadioPeriod(Entity)).OrderByDescending(Function(Entity) Entity.Year).ThenByDescending(Function(Entity) Entity.SortMonth).ToList

                        End If

                        NielsenRadioPeriods = (From Entity In NielsenRadioPeriods
                                               Where GeoNielsenRadioPeriodIDs.Contains(Entity.ID)
                                               Select Entity).ToList

                    End Using

                End Using

            Else

                NielsenRadioPeriods = New Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)

            End If

            LoadNieslenRadioPeriods = NielsenRadioPeriods

        End Function
        Public Function LoadNieslenRadioPeriods(NielsenRadioMarketNumber As Integer) As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)

			'objects
			Dim NielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod) = Nothing
			Dim ClientNielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod) = Nothing

			If Me.Session.IsNielsenSetup Then

				Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

					Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

						If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

							ClientNielsenRadioPeriods = NielsenDbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod)(String.Format("EXEC advsp_nielsen_spot_radio_get_client_periods '{0}'", Session.NielsenClientCodeForHosted)).ToList

                            NielsenRadioPeriods = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadByNielsenRadioMarketNumber(NielsenDbContext, NielsenRadioMarketNumber).ToList
                                                   Select New AdvantageFramework.DTO.Media.NielsenRadioPeriod(Entity)).OrderByDescending(Function(Entity) Entity.Year).ThenByDescending(Function(Entity) Entity.SortMonth).ToList

                            NielsenRadioPeriods = (From Entity In NielsenRadioPeriods
												   Join NRP In ClientNielsenRadioPeriods On Entity.ID Equals NRP.NielsenRadioPeriodID And Entity.Month Equals NRP.Month And Entity.Year Equals NRP.Year
												   Select Entity).ToList

						Else

                            NielsenRadioPeriods = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadByNielsenRadioMarketNumber(NielsenDbContext, NielsenRadioMarketNumber).ToList
                                                   Select New AdvantageFramework.DTO.Media.NielsenRadioPeriod(Entity)).OrderByDescending(Function(Entity) Entity.Year).ThenByDescending(Function(Entity) Entity.SortMonth).ToList

                        End If

					End Using

				End Using

			Else

				NielsenRadioPeriods = New Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)

			End If

			LoadNieslenRadioPeriods = NielsenRadioPeriods

		End Function
		Public Function LoadAllNieslenRadioPeriods() As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)

			'objects
			Dim NielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod) = Nothing
			Dim ReportTypeCodes As IEnumerable(Of String) = Nothing
			Dim ClientNielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod) = Nothing

			If Me.Session.IsNielsenSetup Then

				Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

					Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

						If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

							ClientNielsenRadioPeriods = NielsenDbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Nielsen.ClientNielsenRadioPeriod)(String.Format("EXEC advsp_nielsen_spot_radio_get_client_periods '{0}'", Session.NielsenClientCodeForHosted)).ToList

                            NielsenRadioPeriods = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadValidated(NielsenDbContext).ToList
                                                   Select New AdvantageFramework.DTO.Media.NielsenRadioPeriod(Entity)).OrderByDescending(Function(Entity) Entity.Year).ThenByDescending(Function(Entity) Entity.SortMonth).ToList

                            NielsenRadioPeriods = (From Entity In NielsenRadioPeriods
												   Join NRP In ClientNielsenRadioPeriods On Entity.ID Equals NRP.NielsenRadioPeriodID And Entity.Month Equals NRP.Month And Entity.Year Equals NRP.Year
												   Select Entity).ToList

						Else

                            NielsenRadioPeriods = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadValidated(NielsenDbContext).ToList
                                                   Select New AdvantageFramework.DTO.Media.NielsenRadioPeriod(Entity)).OrderByDescending(Function(Entity) Entity.Year).ThenByDescending(Function(Entity) Entity.SortMonth).ToList

                        End If

					End Using

				End Using

			Else

				NielsenRadioPeriods = New Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)

			End If

			LoadAllNieslenRadioPeriods = NielsenRadioPeriods

		End Function

#End Region

#End Region

	End Class

End Namespace
