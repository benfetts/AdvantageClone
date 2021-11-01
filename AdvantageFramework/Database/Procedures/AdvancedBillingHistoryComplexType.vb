Namespace Database.Procedures.AdvancedBillingHistoryComplexType

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.ComplexTypes.AdvancedBillingHistory)

            Load = DbContext.Database.SqlQuery(Of Database.ComplexTypes.AdvancedBillingHistory)("LoadAdvancedBillingHistories")

        End Function

#End Region

    End Module

End Namespace
