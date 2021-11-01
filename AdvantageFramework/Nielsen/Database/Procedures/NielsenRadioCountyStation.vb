Namespace Nielsen.Database.Procedures.NielsenRadioCountyStation

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

        Public Function GetMaxIDByYear(DbContext As Nielsen.Database.DbContext, Year As Short) As Long

            Try

                GetMaxIDByYear = (From NielsenRadioCountyStation In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioCountyStation)
                                  Where NielsenRadioCountyStation.Year = Year
                                  Select NielsenRadioCountyStation.ID).Max

            Catch ex As Exception
                GetMaxIDByYear = 0
            End Try

        End Function
        Public Function LoadByNielsenRadioCountyStationNames(DbContext As Nielsen.Database.DbContext, StationNames As Generic.List(Of String)) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioCountyStation)

            LoadByNielsenRadioCountyStationNames = From NielsenRadioCountyStation In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioCountyStation)
                                                   Where StationNames.Contains(NielsenRadioCountyStation.CallLetters & "-" & NielsenRadioCountyStation.Band)
                                                   Select NielsenRadioCountyStation

        End Function
        Public Function LoadByStationIDs(DbContext As Nielsen.Database.DbContext, StationIDs As Generic.List(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioCountyStation)

            LoadByStationIDs = From NielsenRadioCountyStation In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioCountyStation)
                               Where StationIDs.Contains(NielsenRadioCountyStation.ID)
                               Select NielsenRadioCountyStation

        End Function
        'Public Function LoadByYearExcludingSelectedStationNames(DbContext As Nielsen.Database.DbContext, Years As Generic.List(Of Short), StationNames As Generic.List(Of String)) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioCountyStation)

        '    LoadByYearExcludingSelectedStationNames = From NielsenRadioCountyStation In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioCountyStation)
        '                                              Where StationNames.Contains(NielsenRadioCountyStation.CallLetters & "-" & NielsenRadioCountyStation.Band) = False AndAlso
        '                                                    Years.Contains(NielsenRadioCountyStation.Year)
        '                                              Select NielsenRadioCountyStation

        'End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioCountyStation)

            Load = From NielsenRadioCountyStation In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioCountyStation)
                   Select NielsenRadioCountyStation

        End Function

#End Region

    End Module

End Namespace
