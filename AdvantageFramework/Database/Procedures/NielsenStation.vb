Namespace Database.Procedures.NielsenStation

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

        Public Function LoadByNielsenMarketNumber(DbContext As Database.DbContext, NielsenMarketNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenStation)

            LoadByNielsenMarketNumber = From NielsenStation In DbContext.GetQuery(Of Database.Entities.NielsenStation)
                                        Where NielsenStation.NielsenMarketNumber = NielsenMarketNumber
                                        Select NielsenStation

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenStation)

            Load = From NielsenStation In DbContext.GetQuery(Of Database.Entities.NielsenStation)
                   Select NielsenStation

        End Function

#End Region

    End Module

End Namespace
