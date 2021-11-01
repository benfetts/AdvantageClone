Namespace Database.Procedures.NielsenDemographic

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

        Public Function LoadByType(DbContext As Database.DbContext, Type As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenDemographic)

            LoadByType = From NielsenDemographic In DbContext.GetQuery(Of Database.Entities.NielsenDemographic)
                         Where NielsenDemographic.Type = Type
                         Select NielsenDemographic

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenDemographic)

            Load = From NielsenDemographic In DbContext.GetQuery(Of Database.Entities.NielsenDemographic)
                   Select NielsenDemographic

        End Function

#End Region

    End Module

End Namespace
