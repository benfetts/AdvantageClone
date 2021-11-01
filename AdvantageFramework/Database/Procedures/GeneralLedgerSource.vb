Namespace Database.Procedures.GeneralLedgerSource

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralLedgerSource)

            Load = From GeneralLedgerSource In DbContext.GetQuery(Of Database.Entities.GeneralLedgerSource)
                   Select GeneralLedgerSource

        End Function

#End Region

    End Module

End Namespace
