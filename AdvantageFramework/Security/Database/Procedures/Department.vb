Namespace Security.Database.Procedures.Department

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.Department)

            Load = From Department In DbContext.GetQuery(Of Database.Entities.Department)
                   Select Department

        End Function

#End Region

    End Module

End Namespace
