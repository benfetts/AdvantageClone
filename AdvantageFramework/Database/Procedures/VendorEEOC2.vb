Namespace Database.Procedures.VendorEEOC2

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

        Public Function LoadByVendorCode(ByVal DbContext As Database.DbContext, ByVal VendorCode As String) As Database.Entities.VendorEEOC2

            LoadByVendorCode = (From VendorEEOC2 In DbContext.GetQuery(Of Database.Entities.VendorEEOC2)
                                Where VendorEEOC2.VendorCode = VendorCode
                                Select VendorEEOC2).SingleOrDefault

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.VendorEEOC2)

            Load = From VendorEEOC2 In DbContext.GetQuery(Of Database.Entities.VendorEEOC2)
                   Select VendorEEOC2

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorEEOC2 As AdvantageFramework.Database.Entities.VendorEEOC2) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.VendorEEOC2s.Add(VendorEEOC2)

                ErrorText = VendorEEOC2.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorEEOC2 As AdvantageFramework.Database.Entities.VendorEEOC2) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(VendorEEOC2)

                ErrorText = VendorEEOC2.ValidateEntity(IsValid)

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
