Namespace Database.Procedures.NielsenRadioQualitative

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

        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenRadioQualitative)

            Load = From NielsenRadioQualitative In DbContext.GetQuery(Of Database.Entities.NielsenRadioQualitative)
                   Select NielsenRadioQualitative

        End Function

#End Region

    End Module

End Namespace
