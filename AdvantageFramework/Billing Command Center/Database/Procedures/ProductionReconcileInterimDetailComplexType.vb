Namespace BillingCommandCenter.Database.Procedures.ProductionReconcileInterimDetailComplexType

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

        Public Function Load(ByVal BCCDbContext As Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                             ByVal BillingApprovalID As Integer?, ByVal EmployeeTimeDateCutoff As Date?, ByVal IncomeOnlyDateCutoff As Date?,
                             ByVal APPostPeriodCutoff As String) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.ProductionReconcileInterimDetail)

            'objects
            Dim JobNumberObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
            Dim JobComponentNumberObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
            Dim BillingApprovalIDObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
            Dim EmployeeTimeDateCutoffObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
            Dim IncomeOnlyDateCutoffObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
            Dim APPostPeriodCutoffObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
            Dim ReturnValueObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing

            JobNumberObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("job_number", JobNumber)
            JobComponentNumberObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("job_component_nbr", JobComponentNumber)

            If BillingApprovalID IsNot Nothing Then

                BillingApprovalIDObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("ba_id", BillingApprovalID)

            Else

                BillingApprovalIDObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("ba_id", GetType(System.Int32))
                BillingApprovalIDObjectParameter.Value = DBNull.Value

            End If

            If EmployeeTimeDateCutoff IsNot Nothing Then

                EmployeeTimeDateCutoffObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("et_cutoff_date", EmployeeTimeDateCutoff)

            Else

                EmployeeTimeDateCutoffObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("et_cutoff_date", GetType(System.DateTime))
                EmployeeTimeDateCutoffObjectParameter.Value = DBNull.Value

            End If

            If IncomeOnlyDateCutoff IsNot Nothing Then

                IncomeOnlyDateCutoffObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("io_cutoff_date", IncomeOnlyDateCutoff)

            Else

                IncomeOnlyDateCutoffObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("io_cutoff_date", GetType(System.DateTime))
                IncomeOnlyDateCutoffObjectParameter.Value = DBNull.Value

            End If

            If APPostPeriodCutoff IsNot Nothing Then

                APPostPeriodCutoffObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("ap_cutoff_pp", APPostPeriodCutoff)

            Else

                APPostPeriodCutoffObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("ap_cutoff_pp", GetType(System.String))
                APPostPeriodCutoffObjectParameter.Value = DBNull.Value

            End If

            ReturnValueObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("ret_val", 0)

            Load = BCCDbContext.Database.SqlQuery(Of Database.Classes.ProductionReconcileInterimDetail)("BCCObjectContextConnection.LoadProductionReconcileInterimDetails", JobNumberObjectParameter,
                    JobComponentNumberObjectParameter, BillingApprovalIDObjectParameter, EmployeeTimeDateCutoffObjectParameter, IncomeOnlyDateCutoffObjectParameter, APPostPeriodCutoffObjectParameter, ReturnValueObjectParameter)

        End Function

#End Region

    End Module

End Namespace
