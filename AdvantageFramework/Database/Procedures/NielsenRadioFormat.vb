Namespace Database.Procedures.NielsenRadioFormat

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

        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenRadioFormat)

            Load = From NielsenRadioFormat In DbContext.GetQuery(Of Database.Entities.NielsenRadioFormat)
                   Select NielsenRadioFormat

        End Function

#End Region

    End Module

End Namespace
