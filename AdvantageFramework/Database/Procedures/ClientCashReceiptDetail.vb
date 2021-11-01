Namespace Database.Procedures.ClientCashReceiptDetail

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

        Public Function LoadByClientCashReceiptIDAndSequenceNumber(ByVal DbContext As Database.DbContext, ByVal ClientCashReceiptID As Integer, ByVal ClientCashReceiptSequenceNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientCashReceiptDetail)

            LoadByClientCashReceiptIDAndSequenceNumber = From ClientCashReceiptDetail In DbContext.GetQuery(Of Database.Entities.ClientCashReceiptDetail)
                                                         Where ClientCashReceiptDetail.ClientCashReceiptID = ClientCashReceiptID AndAlso
                                                               ClientCashReceiptDetail.ClientCashReceiptSequenceNumber = ClientCashReceiptSequenceNumber AndAlso
                                                               (ClientCashReceiptDetail.ModifyDelete Is Nothing OrElse
                                                                ClientCashReceiptDetail.ModifyDelete = False)
                                                         Select ClientCashReceiptDetail

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientCashReceiptDetail)

            Load = From ClientCashReceiptDetail In DbContext.GetQuery(Of Database.Entities.ClientCashReceiptDetail)
                   Select ClientCashReceiptDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCashReceiptDetail As AdvantageFramework.Database.Entities.ClientCashReceiptDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ClientCashReceiptDetails.Add(ClientCashReceiptDetail)

                ErrorText = ClientCashReceiptDetail.ValidateEntity(IsValid)

                If IsValid Then

                    If ClientCashReceiptDetail.ItemID = 0 Then

                        Try

                            ClientCashReceiptDetail.ItemID = (From Entity In AdvantageFramework.Database.Procedures.ClientCashReceiptDetail.Load(DbContext) _
                                                              Where Entity.ClientCashReceiptID = ClientCashReceiptDetail.ClientCashReceiptID AndAlso _
                                                                    Entity.ClientCashReceiptSequenceNumber = ClientCashReceiptDetail.ClientCashReceiptSequenceNumber _
                                                              Select Entity.ItemID).Max + 1

                        Catch ex As Exception
                            ClientCashReceiptDetail.ItemID = 1
                        End Try

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCashReceiptDetail As AdvantageFramework.Database.Entities.ClientCashReceiptDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ClientCashReceiptDetail)

                ErrorText = ClientCashReceiptDetail.ValidateEntity(IsValid)

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
