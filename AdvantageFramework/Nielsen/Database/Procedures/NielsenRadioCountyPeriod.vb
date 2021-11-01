Namespace Nielsen.Database.Procedures.NielsenRadioCountyPeriod

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

        Public Function GetValidatedCount(DbContext As Nielsen.Database.DbContext) As Integer

            GetValidatedCount = (From NielsenRadioCountyPeriod In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioCountyPeriod)
                                 Where NielsenRadioCountyPeriod.Validated = True
                                 Select NielsenRadioCountyPeriod).Count

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioCountyPeriod)

            Load = From NielsenRadioCountyPeriod In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioCountyPeriod)
                   Select NielsenRadioCountyPeriod

        End Function
        Public Function LoadByID(DbContext As Nielsen.Database.DbContext, ID As Integer) As Nielsen.Database.Entities.NielsenRadioCountyPeriod

            LoadByID = (From NielsenRadioCountyPeriod In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioCountyPeriod)
                        Where NielsenRadioCountyPeriod.ID = ID
                        Select NielsenRadioCountyPeriod).SingleOrDefault

        End Function
        Public Function LoadByCountyCode(DbContext As Nielsen.Database.DbContext, CountyCode As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioCountyPeriod)

            LoadByCountyCode = From NielsenRadioCountyPeriod In LoadValidated(DbContext)
                               Where NielsenRadioCountyPeriod.CountyCode = CountyCode
                               Select NielsenRadioCountyPeriod

        End Function
        Public Function LoadByNielsenRadioMarketNumber(DbContext As Nielsen.Database.DbContext, NielsenRadioMarketNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioCountyPeriod)

            LoadByNielsenRadioMarketNumber = From NielsenRadioCountyPeriod In LoadValidated(DbContext)
                                             Where NielsenRadioCountyPeriod.NielsenRadioMarketNumber = NielsenRadioMarketNumber
                                             Select NielsenRadioCountyPeriod

        End Function
        Public Function LoadDistinctYears(DbContext As Nielsen.Database.DbContext) As Generic.List(Of Short)

            LoadDistinctYears = (From NielsenRadioCountyPeriod In LoadValidated(DbContext)
                                 Select NielsenRadioCountyPeriod.Year).Distinct.ToList

        End Function
        Public Function LoadValidated(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioCountyPeriod)

            LoadValidated = From NielsenRadioCountyPeriod In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioCountyPeriod)
                            Where NielsenRadioCountyPeriod.Validated = True
                            Select NielsenRadioCountyPeriod

        End Function
        Public Function Insert(DbContext As Nielsen.Database.DbContext, NielsenRadioCountyPeriod As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyPeriod, ByRef ErrorText As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.NielsenRadioCountyPeriods.Add(NielsenRadioCountyPeriod)

                ErrorText = NielsenRadioCountyPeriod.ValidateEntity(IsValid)

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
