Namespace Nielsen.Database.Procedures.NCCTVAIUE

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

        Public Function GetMaxIDByNCCTVAIUELogID(DbContext As Nielsen.Database.DbContext, NCCTVAIUELogID As Integer) As Long

            If (From NCCTVAIUE In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVAIUE)
                Where NCCTVAIUE.NCCTVAIUELogID = NCCTVAIUELogID
                Select NCCTVAIUE.ID).Any Then

                GetMaxIDByNCCTVAIUELogID = (From NCCTVAIUE In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVAIUE)
                                            Where NCCTVAIUE.NCCTVAIUELogID = NCCTVAIUELogID
                                            Select NCCTVAIUE.ID).Max

            Else

                GetMaxIDByNCCTVAIUELogID = 0

            End If

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NCCTVAIUE)

            Load = From NCCTVAIUE In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVAIUE)
                   Select NCCTVAIUE

        End Function

#End Region

    End Module

End Namespace
