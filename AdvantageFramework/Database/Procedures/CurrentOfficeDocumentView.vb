Namespace Database.Procedures.CurrentOfficeDocumentView

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

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CurrentOfficeDocument)

            Load = From CurrentOfficeDocument In DbContext.CurrentOfficeDocuments
                   Select CurrentOfficeDocument

        End Function

#End Region

    End Module

End Namespace