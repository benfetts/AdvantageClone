Namespace Database.Procedures.BillingApprovalDetail

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

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.BillingApprovalDetail)

            Load = DbContext.Set(Of AdvantageFramework.Database.Entities.BillingApprovalDetail)()

        End Function
        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.BillingApprovalDetail

            Try

                LoadByID = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.BillingApprovalDetail)()
                            Where Entity.ID = ID
                            Select Entity).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace
