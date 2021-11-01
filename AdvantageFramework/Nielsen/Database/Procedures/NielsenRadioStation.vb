Namespace Nielsen.Database.Procedures.NielsenRadioStation

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

        Public Function GetMaxIDByMarketNumber(DbContext As Nielsen.Database.DbContext, MarketNumber As Integer, Source As AdvantageFramework.Nielsen.Database.Entities.RadioSource) As Integer

            Try

                GetMaxIDByMarketNumber = (From NielsenRadioStation In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioStation)
                                          Where NielsenRadioStation.NielsenRadioMarketNumber = MarketNumber AndAlso
                                                NielsenRadioStation.Source = Source
                                          Select NielsenRadioStation.ID).Max

            Catch ex As Exception
                GetMaxIDByMarketNumber = 0
            End Try

        End Function
        Public Function LoadByID(DbContext As Nielsen.Database.DbContext, ID As Integer) As Nielsen.Database.Entities.NielsenRadioStation

            LoadByID = (From NielsenRadioStation In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioStation)
                        Where NielsenRadioStation.ID = ID
                        Select NielsenRadioStation).SingleOrDefault

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioStation)

            Load = From NielsenRadioStation In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioStation)
                   Select NielsenRadioStation

        End Function
        Public Function LoadByRadioSource(DbContext As Nielsen.Database.DbContext, RadioSource As AdvantageFramework.Nielsen.Database.Entities.RadioSource) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioStation)

            LoadByRadioSource = From NielsenRadioStation In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioStation)
                                Where NielsenRadioStation.Source = RadioSource
                                Select NielsenRadioStation

        End Function
        Public Function LoadByNielsenRadioMarketNumberRadioSource(DbContext As Nielsen.Database.DbContext, NielsenRadioMarketNumber As Integer, RadioSource As AdvantageFramework.Nielsen.Database.Entities.RadioSource) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioStation)

            LoadByNielsenRadioMarketNumberRadioSource = From NielsenRadioStation In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioStation)
                                                        Where NielsenRadioStation.NielsenRadioMarketNumber = NielsenRadioMarketNumber AndAlso
                                                              NielsenRadioStation.Source = RadioSource
                                                        Select NielsenRadioStation

        End Function
        Public Function Update(DbContext As Nielsen.Database.DbContext, NielsenRadioStation As Nielsen.Database.Entities.NielsenRadioStation,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.UpdateObject(NielsenRadioStation)

                ErrorText = NielsenRadioStation.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                End If

            Catch ex As Exception
                Updated = False
                ErrorText = ex.Message
            Finally
                Update = Updated
            End Try

        End Function

#End Region

    End Module

End Namespace
