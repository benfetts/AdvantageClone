﻿Namespace Database.Procedures.AlertDocumentKeyword

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AlertDocumentKeyword)

            Load = From AlertDocumentKeyword In DbContext.GetQuery(Of Database.Entities.AlertDocumentKeyword)
                   Select AlertDocumentKeyword

        End Function

#End Region

    End Module

End Namespace
