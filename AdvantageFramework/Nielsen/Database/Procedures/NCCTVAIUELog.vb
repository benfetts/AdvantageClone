Namespace Nielsen.Database.Procedures.NCCTVAIUELog

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

            If (From NCCTVAIUELog In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVAIUELog)
                Select NCCTVAIUELog.ID).Any Then

                GetMaxID = (From NCCTVAIUELog In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVAIUELog)
                            Select NCCTVAIUELog.ID).Max

            Else

                GetMaxID = 0

            End If

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NCCTVAIUELog)

            Load = From NCCTVAIUELog In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVAIUELog)
                   Select NCCTVAIUELog

        End Function

#End Region

    End Module

End Namespace
