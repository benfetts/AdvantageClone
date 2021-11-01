Namespace Database.Procedures.AccountPayable

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

        Public Function LoadAllByAccountPayableID(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayable)

            LoadAllByAccountPayableID = From AccountPayable In DbContext.GetQuery(Of Database.Entities.AccountPayable)
                                        Where AccountPayable.ID = AccountPayableID
                                        Select AccountPayable

        End Function
        Public Function LoadBatchNamesByUser(ByVal DbContext As Database.DbContext, ByVal UserCode As String) As System.Collections.Generic.List(Of String)

            LoadBatchNamesByUser = (From AccountPayable In DbContext.GetQuery(Of Database.Entities.AccountPayable)
                                    Where AccountPayable.BatchName IsNot Nothing AndAlso
                                          AccountPayable.CreatedByUserCode.ToUpper = UserCode.ToUpper
                                    Select AccountPayable.BatchName).Distinct.ToList

        End Function
        Public Function LoadByAccountPayableIDAndSequenceNumber(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer, ByVal SequenceNumber As Integer) As Database.Entities.AccountPayable

            Try

                LoadByAccountPayableIDAndSequenceNumber = (From AccountPayable In DbContext.GetQuery(Of Database.Entities.AccountPayable)
                                                           Where AccountPayable.ID = AccountPayableID AndAlso
                                                                 AccountPayable.SequenceNumber = SequenceNumber
                                                           Select AccountPayable).SingleOrDefault

            Catch ex As Exception
                LoadByAccountPayableIDAndSequenceNumber = Nothing
            End Try

        End Function
        Public Function LoadDistinct(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayable)

            LoadDistinct = From AccountPayable In DbContext.GetQuery(Of Database.Entities.AccountPayable)
                           Group AccountPayable By Key = AccountPayable.ID Into Group
                           Select Group.FirstOrDefault

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayable)

            Load = From AccountPayable In DbContext.GetQuery(Of Database.Entities.AccountPayable)
                   Select AccountPayable

        End Function
        Public Function LoadByVendor(ByVal DbContext As Database.DbContext, ByVal VendorCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayable)

            LoadByVendor = From AccountPayable In DbContext.GetQuery(Of Database.Entities.AccountPayable)
                           Where AccountPayable.VendorCode = VendorCode
                           Select AccountPayable

        End Function
        Public Function LoadByVendorAndInvoiceNumber(ByVal DbContext As Database.DbContext, ByVal VendorCode As String, ByVal InvoiceNumber As String) As Database.Entities.AccountPayable

            Dim AccountPayableDeleted As AdvantageFramework.Database.Entities.AccountPayable = Nothing

            Try

                AccountPayableDeleted = (From AccountPayable In DbContext.GetQuery(Of Database.Entities.AccountPayable)
                                         Where AccountPayable.VendorCode = VendorCode AndAlso
                                               AccountPayable.InvoiceNumber.ToUpper = InvoiceNumber.ToUpper AndAlso
                                               AccountPayable.Deleted = 1
                                         Select AccountPayable).OrderByDescending(Function(D) D.SequenceNumber).FirstOrDefault

            Catch ex As Exception
                AccountPayableDeleted = Nothing
            End Try

            Try

                If AccountPayableDeleted IsNot Nothing Then

                    LoadByVendorAndInvoiceNumber = AccountPayableDeleted

                Else

                    LoadByVendorAndInvoiceNumber = (From AccountPayable In DbContext.GetQuery(Of Database.Entities.AccountPayable)
                                                    Where AccountPayable.VendorCode = VendorCode AndAlso
                                                          AccountPayable.InvoiceNumber.ToUpper = InvoiceNumber.ToUpper AndAlso
                                                          AccountPayable.Vendor.ActiveFlag = 1 AndAlso
                                                          (AccountPayable.IsArchived Is Nothing OrElse
                                                          AccountPayable.IsArchived = 0) AndAlso
                                                          AccountPayable.Modified Is Nothing AndAlso
                                                          AccountPayable.Deleted Is Nothing
                                                    Select AccountPayable).SingleOrDefault

                End If

            Catch ex As Exception
                LoadByVendorAndInvoiceNumber = Nothing
            End Try

        End Function
        Public Function VendorAndInvoiceNumberExists(ByVal DbContext As Database.DbContext, ByVal VendorCode As String, ByVal InvoiceNumber As String) As Boolean

            If (From AccountPayable In DbContext.GetQuery(Of Database.Entities.AccountPayable)
                Where AccountPayable.VendorCode = VendorCode AndAlso
                      AccountPayable.InvoiceNumber = InvoiceNumber.Trim
                Select AccountPayable).Any Then

                VendorAndInvoiceNumberExists = True

            Else

                VendorAndInvoiceNumberExists = False

            End If

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AccountPayables.Add(AccountPayable)

                ErrorText = AccountPayable.ValidateEntity(IsValid)

                If IsValid Then

                    If AccountPayable.ID = 0 Then

                        If (From Entity In DbContext.GetQuery(Of Database.Entities.AccountPayable)
                            Where Entity.VendorCode = AccountPayable.VendorCode AndAlso
                                      Entity.InvoiceNumber = AccountPayable.InvoiceNumber
                            Select Entity).Any Then

                            ErrorText = "Please enter a unique vendor/invoice number."
                            IsValid = False

                        Else

                            AccountPayable.ID = AdvantageFramework.Database.Procedures.AssignNumber.GetNextNumber(DbContext, "AP_ID")

                        End If

                    End If

                End If

                If IsValid Then

                    Try

                        AccountPayable.SequenceNumber = (From Entity In AdvantageFramework.Database.Procedures.AccountPayable.Load(DbContext) _
                                                         Where Entity.ID = AccountPayable.ID
                                                         Select Entity.SequenceNumber).Max + 1

                    Catch ex As Exception
                        AccountPayable.SequenceNumber = 0
                    End Try

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable,
                               DoNotApplyCurrencyRequirement As Boolean) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AccountPayable)

                AccountPayable.DoNotApplyCurrencyRequirement = DoNotApplyCurrencyRequirement

                ErrorText = AccountPayable.ValidateEntity(IsValid)

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
