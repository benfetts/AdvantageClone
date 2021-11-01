Namespace Nielsen.Database.Procedures.NielsenRadioQualitative

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

                GetMaxID = (From NielsenRadioQualitative In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioQualitative)
                            Select NielsenRadioQualitative.ID).Max

            Catch ex As Exception
                GetMaxID = 0
            End Try

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioQualitative)

            Load = From NielsenRadioQualitative In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioQualitative)
                   Select NielsenRadioQualitative

        End Function

#End Region

    End Module

End Namespace
