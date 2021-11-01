Namespace Database.Procedures.VendorTerm

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

        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.VendorTerm)

            LoadAllActive = From VendorTerm In DbContext.GetQuery(Of Database.Entities.VendorTerm)
                            Where VendorTerm.IsInactive = 0 OrElse
                                  VendorTerm.IsInactive Is Nothing
                            Select VendorTerm

        End Function
        Public Function LoadByVendorTermCode(ByVal DbContext As Database.DbContext, ByVal VendorTermCode As String) As Database.Entities.VendorTerm

            Try

                LoadByVendorTermCode = (From VendorTerm In DbContext.GetQuery(Of Database.Entities.VendorTerm)
                                        Where VendorTerm.Code = VendorTermCode
                                        Select VendorTerm).SingleOrDefault

            Catch ex As Exception
                LoadByVendorTermCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.VendorTerm)

            Load = From VendorTerm In DbContext.GetQuery(Of Database.Entities.VendorTerm)
                   Select VendorTerm

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorTerm As AdvantageFramework.Database.Entities.VendorTerm) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.VendorTerms.Add(VendorTerm)

                ErrorText = VendorTerm.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorTerm As AdvantageFramework.Database.Entities.VendorTerm) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(VendorTerm)

                ErrorText = VendorTerm.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorTerm As AdvantageFramework.Database.Entities.VendorTerm) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If AdvantageFramework.Database.Procedures.Vendor.LoadByVendorTermCode(DbContext, VendorTerm.Code).Any Then

                    IsValid = False
                    ErrorText = "This code is in use and cannot be deleted."

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(VendorTerm)

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
