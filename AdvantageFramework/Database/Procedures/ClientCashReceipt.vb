Namespace Database.Procedures.ClientCashReceipt

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

        Public Function LoadBatchNames(ByVal DbContext As Database.DbContext) As System.Collections.Generic.List(Of String)

            LoadBatchNames = (From ClientCashReceipt In DbContext.GetQuery(Of Database.Entities.ClientCashReceipt)
                              Where ClientCashReceipt.BatchName IsNot Nothing
                              Select ClientCashReceipt.BatchName).Distinct.ToList

        End Function
        Public Function LoadByClient(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientCashReceipt)

            LoadByClient = From ClientCashReceipt In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ClientCashReceipt).Include("ClientCashReceiptOnAccounts")
                           Where ClientCashReceipt.ClientCode = ClientCode
                           Select ClientCashReceipt

        End Function
        Public Function LoadByIDandSequenceNumber(ByVal DbContext As Database.DbContext, ByVal ID As Integer, ByVal SequenceNumber As Short) As Database.Entities.ClientCashReceipt

            Try

                LoadByIDandSequenceNumber = (From ClientCashReceipt In DbContext.ClientCashReceipts.AsNoTracking
                                             Where ClientCashReceipt.ID = ID AndAlso
                                                   ClientCashReceipt.SequenceNumber = SequenceNumber
                                             Select ClientCashReceipt).SingleOrDefault

            Catch ex As Exception
                LoadByIDandSequenceNumber = Nothing
            End Try

        End Function
        Public Function LoadByBatchName(ByVal DbContext As Database.DbContext, ByVal BatchName As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientCashReceipt)

            LoadByBatchName = From ClientCashReceipt In DbContext.GetQuery(Of Database.Entities.ClientCashReceipt)
                              Where ClientCashReceipt.BatchName = BatchName
                              Select ClientCashReceipt

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientCashReceipt)

            Load = From ClientCashReceipt In DbContext.GetQuery(Of Database.Entities.ClientCashReceipt)
                   Select ClientCashReceipt

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ClientCashReceipts.Add(ClientCashReceipt)

                ErrorText = ClientCashReceipt.ValidateEntity(IsValid)

                If IsValid Then

                    If ClientCashReceipt.ID = 0 Then

                        Try

                            ClientCashReceipt.ID = (From Entity In AdvantageFramework.Database.Procedures.ClientCashReceipt.Load(DbContext) _
                                                    Select Entity.ID).Max + 1

                        Catch ex As Exception
                            ClientCashReceipt.ID = 1
                        End Try

                        ClientCashReceipt.SequenceNumber = 0

                    Else

                        Try

                            ClientCashReceipt.SequenceNumber = (From Entity In AdvantageFramework.Database.Procedures.ClientCashReceipt.Load(DbContext) _
                                                                Where Entity.ID = ClientCashReceipt.ID
                                                                Select Entity.SequenceNumber).Max + 1

                        Catch ex As Exception
                            IsValid = False
                        End Try

                    End If

                End If

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ClientCashReceipt)

                ErrorText = ClientCashReceipt.ValidateEntity(IsValid)

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

#End Region

    End Module

End Namespace
