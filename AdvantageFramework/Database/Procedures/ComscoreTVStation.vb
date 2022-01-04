Namespace Database.Procedures.ComscoreTVStation

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

        Public Function LoadDistinctMarketNumbers(DbContext As Database.DbContext) As IEnumerable(Of Integer)

            LoadDistinctMarketNumbers = (From ComscoreTVStation In DbContext.GetQuery(Of Database.Entities.ComscoreTVStation)
                                         Where ComscoreTVStation.PrimaryMarketNumber.HasValue
                                         Select ComscoreTVStation.PrimaryMarketNumber.Value).Distinct.ToArray

        End Function
        Public Function LoadByPrimaryMarketNumber(DbContext As Database.DbContext, PrimaryMarketNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ComscoreTVStation)

            LoadByPrimaryMarketNumber = From ComscoreTVStation In DbContext.GetQuery(Of Database.Entities.ComscoreTVStation)
                                        Where ComscoreTVStation.PrimaryMarketNumber = PrimaryMarketNumber OrElse
                                              ComscoreTVStation.PrimaryMarketNumber Is Nothing
                                        Select ComscoreTVStation

        End Function
        Public Function LoadStrictlyByPrimaryMarketNumber(DbContext As Database.DbContext, PrimaryMarketNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ComscoreTVStation)

            LoadStrictlyByPrimaryMarketNumber = From ComscoreTVStation In DbContext.GetQuery(Of Database.Entities.ComscoreTVStation)
                                                Where ComscoreTVStation.PrimaryMarketNumber = PrimaryMarketNumber
                                                Select ComscoreTVStation

        End Function
        Public Function LoadCableNetworks(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ComscoreTVStation)

            LoadCableNetworks = From ComscoreTVStation In DbContext.GetQuery(Of Database.Entities.ComscoreTVStation)
                                Where ComscoreTVStation.PrimaryMarketNumber Is Nothing
                                Select ComscoreTVStation

        End Function
        Public Function LoadFirstByNetworkNumber(DbContext As Database.DbContext, Number As Integer) As Database.Entities.ComscoreTVStation

            LoadFirstByNetworkNumber = (From ComscoreTVStation In DbContext.GetQuery(Of Database.Entities.ComscoreTVStation)
                                        Where ComscoreTVStation.NetworkNumber = Number
                                        Select ComscoreTVStation).OrderBy(Function(CTS) CTS.Number).FirstOrDefault

        End Function
        Public Function LoadByID(DbContext As Database.DbContext, ID As Integer) As Database.Entities.ComscoreTVStation

            LoadByID = (From ComscoreTVStation In DbContext.GetQuery(Of Database.Entities.ComscoreTVStation)
                        Where ComscoreTVStation.ID = ID
                        Select ComscoreTVStation).SingleOrDefault

        End Function
        Public Function LoadByCallLetters(DbContext As Database.DbContext, CallLetters As String) As Database.Entities.ComscoreTVStation

            Try

                LoadByCallLetters = (From ComscoreTVStation In DbContext.GetQuery(Of Database.Entities.ComscoreTVStation)
                                     Where ComscoreTVStation.CallLetters = CallLetters
                                     Select ComscoreTVStation).OrderBy(Function(CTS) CTS.Number).FirstOrDefault

            Catch ex As Exception
                LoadByCallLetters = Nothing
            End Try

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ComscoreTVStation)

            Load = From ComscoreTVStation In DbContext.GetQuery(Of Database.Entities.ComscoreTVStation)
                   Select ComscoreTVStation

        End Function

#End Region

    End Module

End Namespace
