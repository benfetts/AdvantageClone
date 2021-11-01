Namespace Nielsen.Database.Procedures.NielsenRadioPeriod

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadByNielsenRadioMarketNumberAndNielsenRadioReportTypeCodesAndSource(DbContext As Nielsen.Database.DbContext, NielsenRadioMarketNumber As Integer,
                                                                                              NielsenRadioReportTypeCodes As IEnumerable(Of String),
                                                                                              ExcludeNielsenRadioPeriodIDs As Generic.List(Of Integer),
                                                                                              Source As Entities.RadioSource) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioPeriod)

            Dim EachDate As Date = Nothing
            Dim ExcludeDates As Generic.List(Of Date) = Nothing

            ExcludeDates = New Generic.List(Of Date)

            For Each ExcludePeriod In (From NielsenRadioPeriod In LoadValidated(DbContext)
                                       Where ExcludeNielsenRadioPeriodIDs.Contains(NielsenRadioPeriod.ID)
                                       Select NielsenRadioPeriod).ToList

                EachDate = ExcludePeriod.StartDate

                While EachDate <= ExcludePeriod.EndDate

                    If Not ExcludeDates.Contains(EachDate) Then

                        ExcludeDates.Add(EachDate)

                    End If

                    EachDate = EachDate.AddDays(1)

                End While

            Next

            LoadByNielsenRadioMarketNumberAndNielsenRadioReportTypeCodesAndSource = From NielsenRadioPeriod In LoadValidated(DbContext)
                                                                                    Where NielsenRadioPeriod.NielsenRadioMarketNumber = NielsenRadioMarketNumber AndAlso
                                                                                          NielsenRadioReportTypeCodes.Contains(NielsenRadioPeriod.NielsenRadioReportTypeCode) AndAlso
                                                                                          ExcludeNielsenRadioPeriodIDs.Contains(NielsenRadioPeriod.ID) = False AndAlso
                                                                                          NielsenRadioPeriod.Source = Source AndAlso
                                                                                          ExcludeDates.Contains(NielsenRadioPeriod.StartDate) = False AndAlso
                                                                                          ExcludeDates.Contains(NielsenRadioPeriod.EndDate) = False
                                                                                    Select NielsenRadioPeriod

        End Function
        Public Function LoadByNielsenRadioMarketNumber(DbContext As Nielsen.Database.DbContext, NielsenRadioMarketNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioPeriod)

            LoadByNielsenRadioMarketNumber = From NielsenRadioPeriod In LoadValidated(DbContext)
                                             Where NielsenRadioPeriod.NielsenRadioMarketNumber = NielsenRadioMarketNumber
                                             Select NielsenRadioPeriod

        End Function
        Public Function LoadByNielsenRadioMarketNumberAndSource(DbContext As Nielsen.Database.DbContext, NielsenRadioMarketNumber As Integer, Source As Entities.RadioSource) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioPeriod)

            LoadByNielsenRadioMarketNumberAndSource = From NielsenRadioPeriod In LoadValidated(DbContext)
                                                      Where NielsenRadioPeriod.NielsenRadioMarketNumber = NielsenRadioMarketNumber AndAlso
                                                            NielsenRadioPeriod.Source = Source
                                                      Select NielsenRadioPeriod

        End Function
        Public Function LoadByID(DbContext As Nielsen.Database.DbContext, ID As Integer) As Nielsen.Database.Entities.NielsenRadioPeriod

            LoadByID = (From NielsenRadioPeriod In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioPeriod)
                        Where NielsenRadioPeriod.ID = ID
                        Select NielsenRadioPeriod).SingleOrDefault

        End Function
        Public Function GetValidatedCount(DbContext As Nielsen.Database.DbContext) As Integer

            GetValidatedCount = (From NielsenRadioPeriod In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioPeriod)
                                 Where NielsenRadioPeriod.Validated = True
                                 Select NielsenRadioPeriod).Count

        End Function
        Public Function LoadValidated(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioPeriod)

            LoadValidated = From NielsenRadioPeriod In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioPeriod)
                            Where NielsenRadioPeriod.Validated = True
                            Select NielsenRadioPeriod

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioPeriod)

            Load = From NielsenRadioPeriod In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioPeriod)
                   Select NielsenRadioPeriod

        End Function
        Public Function Insert(DbContext As Nielsen.Database.DbContext, NielsenRadioPeriod As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod, ByRef ErrorText As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.NielsenRadioPeriods.Add(NielsenRadioPeriod)

                ErrorText = NielsenRadioPeriod.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception

                Inserted = False

                While ex.InnerException IsNot Nothing

                    ex = ex.InnerException

                End While

                ErrorText = ex.Message

            Finally
                Insert = Inserted
            End Try

        End Function

#End Region

    End Module

End Namespace
