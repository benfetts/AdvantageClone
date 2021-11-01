Namespace BillingCommandCenter.Database.Procedures.BillingHistoryComplexType

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

        Public Function Load(ByVal BCCDbContext As Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.BillingHistory)

            'objects
            Dim JobNumberObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
            Dim JobComponentNumberObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing

            JobNumberObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("JobNumber", JobNumber)
            JobComponentNumberObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("JobComponentNumber", JobComponentNumber)

            Try

                Load = BCCDbContext.Database.SqlQuery(Of Database.Classes.BillingHistory)("BCCObjectContextConnection.LoadBillingHistory", JobNumberObjectParameter, JobComponentNumberObjectParameter)

            Catch ex As Exception
                Load = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace
