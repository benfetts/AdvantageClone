Namespace Database.Procedures.PurchaseOrderApprovalRule

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

        Public Function LoadByPurchaseOrderApprovalRuleCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderApprovalRuleCode As String) As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule

            Try

                LoadByPurchaseOrderApprovalRuleCode = (From PurchaseOrderApprovalRule In DbContext.GetQuery(Of Database.Entities.PurchaseOrderApprovalRule)
                                                       Where PurchaseOrderApprovalRule.Code = PurchaseOrderApprovalRuleCode
                                                       Select PurchaseOrderApprovalRule).SingleOrDefault

            Catch ex As Exception
                LoadByPurchaseOrderApprovalRuleCode = Nothing
            End Try

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PurchaseOrderApprovalRule)

            LoadAllActive = From PurchaseOrderApprovalRule In DbContext.GetQuery(Of Database.Entities.PurchaseOrderApprovalRule)
                            Where PurchaseOrderApprovalRule.IsInactive Is Nothing OrElse
                                  PurchaseOrderApprovalRule.IsInactive = 0
                            Select PurchaseOrderApprovalRule

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PurchaseOrderApprovalRule)

            Load = From PurchaseOrderApprovalRule In DbContext.GetQuery(Of Database.Entities.PurchaseOrderApprovalRule)
                   Select PurchaseOrderApprovalRule

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderApprovalRule As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.PurchaseOrderApprovalRules.Add(PurchaseOrderApprovalRule)

                ErrorText = PurchaseOrderApprovalRule.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderApprovalRule As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(PurchaseOrderApprovalRule)

                ErrorText = PurchaseOrderApprovalRule.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
       Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderApprovalRule As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            Try

                If IsValid Then

                    DbContext.Database.Connection.Open()

                    DbTransaction = DbContext.Database.BeginTransaction

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE from dbo.PO_APPR_RULE_EMP where PO_APPR_RULE_CODE = '{0}'", PurchaseOrderApprovalRule.Code))

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE from dbo.PO_APPR_RULE_DTL where PO_APPR_RULE_CODE = '{0}'", PurchaseOrderApprovalRule.Code))

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE from dbo.PO_APPR_RULE_HDR WHERE PO_APPR_RULE_CODE = '{0}'", PurchaseOrderApprovalRule.Code))

                        Deleted = True

                    Catch ex As Exception
                        IsValid = False
                    End Try

                    If Deleted Then

                        DbTransaction.Commit()

                    Else

                        DbTransaction.Rollback()

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
