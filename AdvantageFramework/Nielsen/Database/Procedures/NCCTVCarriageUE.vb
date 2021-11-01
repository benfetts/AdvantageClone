Namespace Nielsen.Database.Procedures.NCCTVCarriageUE

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

        Public Function GetMaxIDByNCCTVCarriageUELogID(DbContext As Nielsen.Database.DbContext, NCCTVCarriageUELogID As Integer) As Long

            If (From NCCTVCarriageUE In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVCarriageUE)
                Where NCCTVCarriageUE.NCCTVCarriageUELogID = NCCTVCarriageUELogID
                Select NCCTVCarriageUE.ID).Any Then

                GetMaxIDByNCCTVCarriageUELogID = (From NCCTVCarriageUE In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVCarriageUE)
                                                  Where NCCTVCarriageUE.NCCTVCarriageUELogID = NCCTVCarriageUELogID
                                                  Select NCCTVCarriageUE.ID).Max

            Else

                GetMaxIDByNCCTVCarriageUELogID = 0

            End If

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NCCTVCarriageUE)

            Load = From NCCTVCarriageUE In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVCarriageUE)
                   Select NCCTVCarriageUE

        End Function

#End Region

    End Module

End Namespace
