Namespace Nielsen.Database.Procedures.NielsenRadioSegmentChild

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

                GetMaxID = (From NielsenRadioSegmentChild In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioSegmentChild)
                            Select NielsenRadioSegmentChild.ID).Max

            Catch ex As Exception
                GetMaxID = 0
            End Try

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioSegmentChild)

            Load = From NielsenRadioSegmentChild In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioSegmentChild)
                   Select NielsenRadioSegmentChild

        End Function

#End Region

    End Module

End Namespace
