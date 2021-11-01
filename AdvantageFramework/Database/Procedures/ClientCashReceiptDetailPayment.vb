Namespace Database.Procedures.ClientCashReceiptDetailPayment

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

        Public Function LoadByClientCashReceiptDetailIDandSeqandItemID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCashReceiptID As Integer,
                                                                       ByVal ClientCashReceiptSequenceNumber As Short, ByVal ItemID As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ClientCashReceiptDetailPayment)

            LoadByClientCashReceiptDetailIDandSeqandItemID = From ClientCashReceiptDetailPayment In DbContext.GetQuery(Of Database.Entities.ClientCashReceiptDetailPayment)
                                                             Where ClientCashReceiptDetailPayment.ClientCashReceiptID = ClientCashReceiptID AndAlso
                                                                   ClientCashReceiptDetailPayment.ClientCashReceiptSequenceNumber = ClientCashReceiptSequenceNumber AndAlso
                                                                   ClientCashReceiptDetailPayment.ClientCashReceiptDetailItemID = ItemID
                                                             Select ClientCashReceiptDetailPayment

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ClientCashReceiptDetailPayment)

            Load = DbContext.Set(Of AdvantageFramework.Database.Entities.ClientCashReceiptDetailPayment)()

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCashReceiptDetailPayment As Entities.ClientCashReceiptDetailPayment) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ClientCashReceiptDetailPayments.Add(ClientCashReceiptDetailPayment)

                ErrorText = ClientCashReceiptDetailPayment.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCashReceiptDetailPayment As Entities.ClientCashReceiptDetailPayment) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Entry(ClientCashReceiptDetailPayment).State = Entity.EntityState.Modified

                ErrorText = ClientCashReceiptDetailPayment.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCashReceiptDetailPayment As Entities.ClientCashReceiptDetailPayment) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Entry(ClientCashReceiptDetailPayment).State = Entity.EntityState.Deleted

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

#End Region

    End Module

End Namespace
