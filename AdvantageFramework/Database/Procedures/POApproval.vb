Namespace Database.Procedures.POApproval

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.POApproval)

            Load = From POApproval In DbContext.GetQuery(Of Database.Entities.POApproval)
                   Select POApproval

        End Function
        Public Function LoadByPurchaseOrderNumber(ByVal DbContext As Database.DbContext, ByVal PurchaseOrderNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.POApproval)

            LoadByPurchaseOrderNumber = From POApproval In DbContext.GetQuery(Of Database.Entities.POApproval)
                                        Where POApproval.Number = PurchaseOrderNumber
                                        Select POApproval

        End Function
        Public Function Insert(ByVal DbContext As Database.DbContext, ByVal POApproval As AdvantageFramework.Database.Entities.POApproval) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.POApprovals.Add(POApproval)

                ErrorText = POApproval.ValidateEntity(IsValid)

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

#End Region

    End Module

End Namespace
