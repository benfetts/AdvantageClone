Namespace Database.Procedures.TVOrderDetailLegacy

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.TVOrderDetailLegacy)

            Load = From TVOrderDetailLegacy In DbContext.GetQuery(Of Database.Entities.TVOrderDetailLegacy)
                   Select TVOrderDetailLegacy

        End Function

#End Region

    End Module

End Namespace
