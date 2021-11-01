Namespace Security.Database.Procedures.Office

    <HideModuleName()> _
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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.Office)

            Load = From SecurityOffice In DbContext.GetQuery(Of Database.Entities.Office)
                   Select SecurityOffice

        End Function

#End Region

    End Module

End Namespace
