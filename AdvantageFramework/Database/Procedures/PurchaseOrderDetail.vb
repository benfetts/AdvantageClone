Namespace Database.Procedures.PurchaseOrderDetail

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

        Public Function LoadByJobNumber(ByVal DbContext As Database.DbContext, ByVal JobNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PurchaseOrderDetail)

            LoadByJobNumber = From PurchaseOrderDetail In DbContext.GetQuery(Of Database.Entities.PurchaseOrderDetail)
                              Where PurchaseOrderDetail.JobNumber = JobNumber
                              Select PurchaseOrderDetail

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PurchaseOrderDetail)

            Load = From PurchaseOrderDetail In DbContext.GetQuery(Of Database.Entities.PurchaseOrderDetail)
                   Select PurchaseOrderDetail

        End Function
        Public Function LoadByPurchaseOrderNumberForAccountPayableGLDistribution(ByVal DbContext As Database.DbContext, ByVal PurchaseOrderNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PurchaseOrderDetail)

            LoadByPurchaseOrderNumberForAccountPayableGLDistribution = From PurchaseOrderDetail In DbContext.GetQuery(Of Database.Entities.PurchaseOrderDetail)
                                                                       Where PurchaseOrderDetail.PurchaseOrderNumber = PurchaseOrderNumber AndAlso
                                                                             (PurchaseOrderDetail.IsComplete Is Nothing OrElse PurchaseOrderDetail.IsComplete = 0) AndAlso
                                                                             PurchaseOrderDetail.JobNumber Is Nothing
                                                                       Select PurchaseOrderDetail

        End Function
        Public Function LoadByPONumber(ByVal DbContext As Database.DbContext, ByVal PurchaseOrderNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PurchaseOrderDetail)

            LoadByPONumber = From PurchaseOrderDetail In DbContext.GetQuery(Of Database.Entities.PurchaseOrderDetail)
                             Where PurchaseOrderDetail.PurchaseOrderNumber = PurchaseOrderNumber
                             Select PurchaseOrderDetail

        End Function
        Public Function LoadByPONumberAndLineNumber(ByVal DbContext As Database.DbContext, ByVal PurchaseOrderNumber As Integer, ByVal LineNumber As Integer) As Database.Entities.PurchaseOrderDetail

            Try

                LoadByPONumberAndLineNumber = (From PurchaseOrderDetail In DbContext.GetQuery(Of Database.Entities.PurchaseOrderDetail)
                                               Where PurchaseOrderDetail.PurchaseOrderNumber = PurchaseOrderNumber AndAlso
                                                     PurchaseOrderDetail.LineNumber = LineNumber
                                               Select PurchaseOrderDetail).SingleOrDefault

            Catch ex As Exception
                LoadByPONumberAndLineNumber = Nothing
            End Try

        End Function
        Public Function LoadAllIncomplete(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PurchaseOrderDetail)

            LoadAllIncomplete = From PurchaseOrderDetail In DbContext.GetQuery(Of Database.Entities.PurchaseOrderDetail)
                                Where PurchaseOrderDetail.IsComplete Is Nothing OrElse
                                      PurchaseOrderDetail.IsComplete = 0
                                Select PurchaseOrderDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If PurchaseOrderDetail.LineNumber = Nothing OrElse PurchaseOrderDetail.LineNumber = 0 Then

                    Try

                        PurchaseOrderDetail.LineNumber = (From Entity In LoadByPONumber(DbContext, PurchaseOrderDetail.PurchaseOrderNumber) _
                                                          Select Entity.LineNumber).Max + 1

                    Catch ex As Exception
                        PurchaseOrderDetail.LineNumber = 1
                    End Try

                End If

                DbContext.PurchaseOrderDetails.Add(PurchaseOrderDetail)

                ErrorText = PurchaseOrderDetail.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(PurchaseOrderDetail)

                ErrorText = PurchaseOrderDetail.ValidateEntity(IsValid)

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
        Public Function UpdateIsCompleteAndParentPO(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PONumber As Integer, ByVal LineNumber As Integer, ByVal POComplete As Short) As Boolean

            Dim Updated As Boolean = False
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing

            Try

                PurchaseOrderDetail = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumberAndLineNumber(DbContext, PONumber, LineNumber)

                If PurchaseOrderDetail IsNot Nothing Then

                    PurchaseOrderDetail.IsComplete = POComplete
                    AdvantageFramework.Database.Procedures.PurchaseOrderDetail.Update(DbContext, PurchaseOrderDetail)

                End If

                PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(DbContext, PONumber)

                If PurchaseOrder IsNot Nothing Then

                    If AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(DbContext, PONumber).Where(Function(POD) POD.IsComplete Is Nothing OrElse POD.IsComplete = 0).Any Then

                        PurchaseOrder.IsComplete = 0
                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE PURCHASE_ORDER SET PO_COMPLETE = 0 WHERE PO_NUMBER = {0}", PONumber))

                    Else

                        PurchaseOrder.IsComplete = 1
                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE PURCHASE_ORDER SET PO_COMPLETE = 1 WHERE PO_NUMBER = {0}", PONumber))

                    End If

                End If

                Updated = True

            Catch ex As Exception
                Updated = False
            Finally
                UpdateIsCompleteAndParentPO = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(PurchaseOrderDetail)

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PONumber As Integer, ByVal LineNumber As Integer) As Boolean

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

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM [dbo].[PURCHASE_ORDER_DET] WHERE [PO_NUMBER] = {0} AND [LINE_NUMBER] = {1}", PONumber, LineNumber))

                        Deleted = True

                    Catch ex As Exception

                    End Try

                    If Deleted Then

                        DbTransaction.Commit()

                    Else

                        DbTransaction.Rollback()

                    End If

                    DbContext.Database.Connection.Close()

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
