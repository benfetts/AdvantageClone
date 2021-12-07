Namespace Nielsen.Database.Procedures.NCCTVCablenet

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

        Public Function GetMaxID(DbContext As Nielsen.Database.DbContext) As Long

            If (From NCCTVCablenet In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVCablenet)
                Select NCCTVCablenet.ID).Any Then

                GetMaxID = (From NCCTVCablenet In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVCablenet)
                            Select NCCTVCablenet.ID).Max

            Else

                GetMaxID = 0

            End If

        End Function
        Public Function LoadByID(DbContext As Nielsen.Database.DbContext, ID As Integer) As Nielsen.Database.Entities.NCCTVCablenet

            LoadByID = (From NCCTVCablenet In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVCablenet)
                        Where NCCTVCablenet.ID = ID
                        Select NCCTVCablenet).SingleOrDefault

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NCCTVCablenet)

            Load = From NCCTVCablenet In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVCablenet)
                   Select NCCTVCablenet

        End Function
        Public Function LoadWithComscoreStationCode(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NCCTVCablenet)

            LoadWithComscoreStationCode = From NCCTVCablenet In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVCablenet)
                                          Where NCCTVCablenet.ComscoreStationCode.HasValue
                                          Select NCCTVCablenet

        End Function

#End Region

    End Module

End Namespace
