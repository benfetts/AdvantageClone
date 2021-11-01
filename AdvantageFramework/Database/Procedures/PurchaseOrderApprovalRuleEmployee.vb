Namespace Database.Procedures.PurchaseOrderApprovalRuleEmployee

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PurchaseOrderApprovalRuleEmployee)

            Load = From PurchaseOrderApprovalRuleEmployee In DbContext.GetQuery(Of Database.Entities.PurchaseOrderApprovalRuleEmployee)
                   Select PurchaseOrderApprovalRuleEmployee

        End Function
        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee

            Try

                LoadByID = (From PurchaseOrderApprovalRuleEmployee In DbContext.GetQuery(Of Database.Entities.PurchaseOrderApprovalRuleEmployee)
                            Where PurchaseOrderApprovalRuleEmployee.ID = ID
                            Select PurchaseOrderApprovalRuleEmployee).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function GetNextAvailableOrder(ByVal DbContext As Database.DbContext, ByVal PurchaseOrderApprovalRuleCode As String, ByVal SequenceNumber As Integer) As Short

            Dim NextOrder As Short = Nothing

            Try

                If AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.LoadByPurchaseOrderApprovalRuleCodeSeqNum(DbContext, PurchaseOrderApprovalRuleCode, SequenceNumber).Count = 0 Then

                    NextOrder = 10

                Else

                    NextOrder = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.LoadByPurchaseOrderApprovalRuleCodeSeqNum(DbContext, PurchaseOrderApprovalRuleCode, SequenceNumber)
                                 Select Entity.Order).Max + 10

                End If

            Catch ex As Exception
                NextOrder = Nothing
            End Try

            GetNextAvailableOrder = NextOrder

        End Function
        Public Function LoadByPurchaseOrderApprovalRuleCodeSeqNum(ByVal DbContext As Database.DbContext, ByVal PurchaseOrderApprovalRuleCode As String, ByVal SequenceNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PurchaseOrderApprovalRuleEmployee)

            LoadByPurchaseOrderApprovalRuleCodeSeqNum = From PurchaseOrderApprovalRuleEmployee In DbContext.GetQuery(Of Database.Entities.PurchaseOrderApprovalRuleEmployee)
                                                        Where PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleCode = PurchaseOrderApprovalRuleCode AndAlso
                                                  PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleDetailSequenceNumber = SequenceNumber
                                                        Select PurchaseOrderApprovalRuleEmployee

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderApprovalRuleEmployee As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.PurchaseOrderApprovalRuleEmployees.Add(PurchaseOrderApprovalRuleEmployee)

                ErrorText = PurchaseOrderApprovalRuleEmployee.ValidateEntity(IsValid)

                If IsValid Then

                    If (Not IsNumeric(PurchaseOrderApprovalRuleEmployee.Order)) OrElse PurchaseOrderApprovalRuleEmployee.Order = 0 Then

                        PurchaseOrderApprovalRuleEmployee.Order = GetNextAvailableOrder(DbContext, PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleCode, PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleDetailSequenceNumber)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderApprovalRuleEmployee As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(PurchaseOrderApprovalRuleEmployee)

                ErrorText = PurchaseOrderApprovalRuleEmployee.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderApprovalRuleEmployee As AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim POApprovalRuleEmployees As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee) = Nothing
            Dim NextOrder As Integer = Nothing

            Try

                IsValid = ((From Entity In DirectCast(PurchaseOrderApprovalRuleEmployee.DbContext, AdvantageFramework.Database.DbContext).POApprovals _
                            Where Entity.POApprovalRuleEmployeeID = PurchaseOrderApprovalRuleEmployee.ID 
                            Select Entity).Any = False)

                If IsValid Then

                    DbContext.DeleteEntityObject(PurchaseOrderApprovalRuleEmployee)

                    DbContext.SaveChanges()

                    Deleted = True

                    POApprovalRuleEmployees = AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.LoadByPurchaseOrderApprovalRuleCodeSeqNum(DbContext, PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleCode, PurchaseOrderApprovalRuleEmployee.PurchaseOrderApprovalRuleDetailSequenceNumber).OrderBy(Function(E) E.Order).ToList

                    NextOrder = 0

                    For Each POApprovalRuleEmployee In POApprovalRuleEmployees

                        NextOrder = NextOrder + 10

                        POApprovalRuleEmployee.Order = NextOrder

                        POApprovalRuleEmployee.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRuleEmployee.Update(DbContext, POApprovalRuleEmployee)

                    Next

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
