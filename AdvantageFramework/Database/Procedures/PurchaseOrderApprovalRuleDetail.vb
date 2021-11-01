Namespace Database.Procedures.PurchaseOrderApprovalRuleDetail

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PurchaseOrderApprovalRuleDetail)

            Load = From PurchaseOrderApprovalRuleDetail In DbContext.GetQuery(Of Database.Entities.PurchaseOrderApprovalRuleDetail)
                   Select PurchaseOrderApprovalRuleDetail

        End Function
        Public Function LoadByPurchaseOrderApprovalRuleCode(ByVal DbContext As Database.DbContext, ByVal PurchaseOrderApprovalRuleCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PurchaseOrderApprovalRuleDetail)

            LoadByPurchaseOrderApprovalRuleCode = From PurchaseOrderApprovalRuleDetail In DbContext.GetQuery(Of Database.Entities.PurchaseOrderApprovalRuleDetail)
                                                  Where PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleCode = PurchaseOrderApprovalRuleCode
                                                  Select PurchaseOrderApprovalRuleDetail

        End Function
        Public Function LoadByPurchaseOrderApprovalRuleCodeSeqNum(ByVal DbContext As Database.DbContext, ByVal PurchaseOrderApprovalRuleCode As String, ByVal SequenceNumber As Integer) As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleDetail

            LoadByPurchaseOrderApprovalRuleCodeSeqNum = (From PurchaseOrderApprovalRuleDetail In DbContext.GetQuery(Of Database.Entities.PurchaseOrderApprovalRuleDetail)
                                                         Where PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleCode = PurchaseOrderApprovalRuleCode AndAlso
                                                  PurchaseOrderApprovalRuleDetail.SequenceNumber = SequenceNumber
                                                         Select PurchaseOrderApprovalRuleDetail).FirstOrDefault

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderApprovalRuleDetail As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.PurchaseOrderApprovalRuleDetails.Add(PurchaseOrderApprovalRuleDetail)

                ErrorText = PurchaseOrderApprovalRuleDetail.ValidateEntity(IsValid)

                If IsValid Then

                    If AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleDetail.LoadByPurchaseOrderApprovalRuleCode(DbContext, PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleCode).Count = 0 Then

                        PurchaseOrderApprovalRuleDetail.SequenceNumber = 1

                    Else

                        PurchaseOrderApprovalRuleDetail.SequenceNumber = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleDetail.LoadByPurchaseOrderApprovalRuleCode(DbContext, PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleCode) _
                                                                          Select Entity.SequenceNumber).Max + 1

                    End If

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderApprovalRuleDetail As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(PurchaseOrderApprovalRuleDetail)

                ErrorText = PurchaseOrderApprovalRuleDetail.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderApprovalRuleDetail As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                IsValid = ((From Entity In DbContext.POApprovals
                            Where Entity.POApprovalRuleCode = PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleCode AndAlso
                            Entity.POApprovalRuleDetailSequenceNumber = PurchaseOrderApprovalRuleDetail.SequenceNumber
                            Select Entity).Any = False)

                If IsValid Then

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE from dbo.PO_APPR_RULE_EMP where PO_APPR_RULE_CODE = '{0}' and SEQ_NBR = {1}", PurchaseOrderApprovalRuleDetail.PurchaseOrderApprovalRuleCode, PurchaseOrderApprovalRuleDetail.SequenceNumber))

                    Catch ex As Exception
                        IsValid = False
                    End Try

                    DbContext.DeleteEntityObject(PurchaseOrderApprovalRuleDetail)

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("This code is in use and cannot be deleted.")

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
