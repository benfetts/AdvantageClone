Namespace Database.Procedures.PurchaseOrderPrintDefault

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PurchaseOrderPrintDefault)

            Load = From PurchaseOrderPrintDefault In DbContext.GetQuery(Of Database.Entities.PurchaseOrderPrintDefault)
                   Select PurchaseOrderPrintDefault

        End Function
        Public Function LoadByUserCode(ByVal DbContext As Database.DbContext, ByVal UserCode As String) As Database.Entities.PurchaseOrderPrintDefault

            Try

                LoadByUserCode = (From PurchaseOrderPrintDefault In DbContext.GetQuery(Of Database.Entities.PurchaseOrderPrintDefault)
                                  Where PurchaseOrderPrintDefault.UserID = UserCode
                                  Select PurchaseOrderPrintDefault).SingleOrDefault

            Catch ex As Exception
                LoadByUserCode = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                PurchaseOrderPrintDefault.UserID = DbContext.UserCode

                DbContext.PurchaseOrderPrintDefaults.Add(PurchaseOrderPrintDefault)

                ErrorText = PurchaseOrderPrintDefault.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(PurchaseOrderPrintDefault)

                ErrorText = PurchaseOrderPrintDefault.ValidateEntity(IsValid)

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
