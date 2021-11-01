Namespace Database.Procedures.GeneralLedgerExternalGLIFaceCrossReference

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

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.GeneralLedgerExternalGLIFaceCrossReference)

            Load = From GeneralLedgerExternalGLIFaceCrossReference In DbContext.GetQuery(Of Database.Entities.GeneralLedgerExternalGLIFaceCrossReference)
                   Select GeneralLedgerExternalGLIFaceCrossReference

        End Function

#End Region

    End Module

End Namespace
