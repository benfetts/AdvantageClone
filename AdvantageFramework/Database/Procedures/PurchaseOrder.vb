Namespace Database.Procedures.PurchaseOrder

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PurchaseOrder)

            Load = From PurchaseOrder In DbContext.GetQuery(Of Database.Entities.PurchaseOrder)
                   Select PurchaseOrder

        End Function
        Public Function LoadNonVoided(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PurchaseOrder)

            LoadNonVoided = From PurchaseOrder In DbContext.GetQuery(Of Database.Entities.PurchaseOrder)
                            Where PurchaseOrder.IsVoid Is Nothing OrElse
                                  PurchaseOrder.IsVoid = 0
                            Select PurchaseOrder

        End Function
        Public Function LoadNonComplete(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PurchaseOrder)

            LoadNonComplete = From PurchaseOrder In DbContext.GetQuery(Of Database.Entities.PurchaseOrder)
                              Where PurchaseOrder.IsComplete Is Nothing OrElse
                                    PurchaseOrder.IsComplete = 0
                              Select PurchaseOrder

        End Function
        Public Function LoadNonVoidedNonCompleteByVendorCode(ByVal DbContext As Database.DbContext, ByVal VendorCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PurchaseOrder)

            LoadNonVoidedNonCompleteByVendorCode = From PurchaseOrder In DbContext.GetQuery(Of Database.Entities.PurchaseOrder)
                                                   Where PurchaseOrder.VendorCode = VendorCode AndAlso
                                                         (PurchaseOrder.IsVoid Is Nothing OrElse PurchaseOrder.IsVoid = 0) AndAlso
                                                         (PurchaseOrder.IsComplete Is Nothing OrElse PurchaseOrder.IsComplete = 0)
                                                   Select PurchaseOrder

        End Function
        Public Function LoadByPONumber(ByVal DbContext As Database.DbContext, ByVal PONumber As Integer) As Database.Entities.PurchaseOrder

            Try

                LoadByPONumber = (From PurchaseOrder In DbContext.GetQuery(Of Database.Entities.PurchaseOrder)
                                  Where PurchaseOrder.Number = PONumber
                                  Select PurchaseOrder).SingleOrDefault

            Catch ex As Exception
                LoadByPONumber = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If PurchaseOrder.IsWorkComplete.GetValueOrDefault(0) = 0 Then

                    PurchaseOrder.IsComplete = Nothing

                End If

                If PurchaseOrder.Number = Nothing OrElse PurchaseOrder.Number = 0 Then

                    Try

                        PurchaseOrder.Number = (From Entity In Load(DbContext) _
                                                Select Entity.Number).Max + 1

                    Catch ex As Exception
                        PurchaseOrder.Number = 1
                    End Try

                End If

                DbContext.PurchaseOrders.Add(PurchaseOrder)

                ErrorText = PurchaseOrder.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder, Optional ByVal print As Boolean = False) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try
                If print = False Then
                    PurchaseOrder.ModifiedByUserCode = DbContext.UserCode
                End If
                If PurchaseOrder.ModifiedDate Is Nothing And print = False Then PurchaseOrder.ModifiedDate = System.DateTime.Now

                DbContext.UpdateObject(PurchaseOrder)

                ErrorText = PurchaseOrder.ValidateEntity(IsValid)

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
        Public Function SetPOModified(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PONumber As Integer)

            'objects
            Dim Modified As Boolean = True

            Try

                DbContext.Database.Connection.Open()

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.PURCHASE_ORDER SET [MODIFIED_DATE] = '{0}', [USER_MODIFIED] = '{1}' WHERE [PO_NUMBER] = {2}", System.DateTime.Now, DbContext.UserCode, PONumber))

                DbContext.Database.Connection.Close()

            Catch ex As Exception
                Modified = False
            Finally
                SetPOModified = Modified
            End Try

        End Function

#End Region

    End Module

End Namespace
