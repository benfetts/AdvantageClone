Namespace Database.Procedures.PurchaseOrderStatus

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

        'Public Function LoadByOrderNumberAndLineNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PONumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.PurchaseOrderStatus)

        '    LoadByOrderNumberAndLineNumber = From PurchaseOrderStatus In DbContext.GetQuery(Of Database.Entities.PurchaseOrderStatus)
        '                                     Where PurchaseOrderStatus.PONumber = PONumber
        '                                     Select PurchaseOrderStatus

        'End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Entities.PurchaseOrderStatus)

            Load = DbContext.Set(Of Entities.PurchaseOrderStatus)()

        End Function
        'Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PurchaseOrderStatus As AdvantageFramework.Database.Entities.PurchaseOrderStatus) As Boolean

        '    'objects
        '    Dim Inserted As Boolean = False
        '    Dim IsValid As Boolean = True
        '    Dim ErrorText As String = ""

        '    Try

        '        DbContext.PurchaseOrderStatuses.Add(PurchaseOrderStatus)

        '        ErrorText = PurchaseOrderStatus.ValidateEntity(IsValid)

        '        If IsValid Then

        '            DbContext.SaveChanges()

        '            Inserted = True

        '        Else

        '            AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

        '        End If

        '    Catch ex As Exception
        '        Inserted = False
        '    Finally
        '        Insert = Inserted
        '    End Try

        'End Function

#End Region

    End Module

End Namespace
