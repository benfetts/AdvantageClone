Namespace Nielsen.Database.Procedures.NielsenRadioReportType

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

        Public Function GetMaxID(DbContext As Nielsen.Database.DbContext) As Integer

            Try

                GetMaxID = (From NielsenRadioReportType In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioReportType)
                            Select NielsenRadioReportType.ID).Max

            Catch ex As Exception
                GetMaxID = 0
            End Try

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioReportType)

            Load = From NielsenRadioReportType In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioReportType)
                   Select NielsenRadioReportType

        End Function

#End Region

    End Module

End Namespace
