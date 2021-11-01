Namespace Database.Procedures.AlertDocument

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AlertDocument)

            Load = From AlertDocument In DbContext.GetQuery(Of Database.Entities.AlertDocument)
                   Select AlertDocument

        End Function

#End Region

    End Module

End Namespace
