Namespace Database.Procedures.ImportAccountPayableError

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

        Public Function LoadByImportAccountPayableID(ByVal DbContext As Database.DbContext,
                                                     ByVal ImportAccountPayableID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportAccountPayableError)

            LoadByImportAccountPayableID = From ImportAccountPayableError In DbContext.GetQuery(Of Database.Entities.ImportAccountPayableError)
                                           Where ImportAccountPayableError.ImportAccountPayableID = ImportAccountPayableID
                                           Select ImportAccountPayableError

        End Function
        Public Function LoadByImportAccountPayableIDAndImportAccountPayableMedia(ByVal DbContext As Database.DbContext,
                                                                                 ByVal ImportAccountPayableID As Integer,
                                                                                 ByVal ImportAccountPayableMediaID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportAccountPayableError)

            LoadByImportAccountPayableIDAndImportAccountPayableMedia = From ImportAccountPayableError In DbContext.GetQuery(Of Database.Entities.ImportAccountPayableError)
                                                                       Where ImportAccountPayableError.ImportAccountPayableID = ImportAccountPayableID AndAlso
                                                                             ImportAccountPayableError.ImportAccountPayableMediaID = ImportAccountPayableMediaID
                                                                       Select ImportAccountPayableError

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportAccountPayableError)

            Load = From ImportAccountPayableError In DbContext.GetQuery(Of Database.Entities.ImportAccountPayableError)
                   Select ImportAccountPayableError

        End Function

#End Region

    End Module

End Namespace
