Namespace Database.Procedures.InvoiceCategory

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

        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.InvoiceCategory)

            LoadAllActive = From InvoiceCategory In DbContext.GetQuery(Of Database.Entities.InvoiceCategory)
                            Where InvoiceCategory.IsInactive Is Nothing OrElse
                                    InvoiceCategory.IsInactive = 0
                            Select InvoiceCategory

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.InvoiceCategory)

            Load = From InvoiceCategory In DbContext.GetQuery(Of Database.Entities.InvoiceCategory)
                   Select InvoiceCategory

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal InvoiceCategory As AdvantageFramework.Database.Entities.InvoiceCategory) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.InvoiceCategories.Add(InvoiceCategory)

                ErrorText = InvoiceCategory.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal InvoiceCategory As AdvantageFramework.Database.Entities.InvoiceCategory) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(InvoiceCategory)

                ErrorText = InvoiceCategory.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal InvoiceCategory As AdvantageFramework.Database.Entities.InvoiceCategory) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.ACCT_REC WHERE INV_CAT = '{0}'", InvoiceCategory.Code)).FirstOrDefault > 0 Then

                    IsValid = False
                    ErrorText = "This code is in use and cannot be deleted."

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(InvoiceCategory)

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
