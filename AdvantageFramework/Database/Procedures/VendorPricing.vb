Namespace Database.Procedures.VendorPricing

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.VendorPricing)

            Load = From VendorPricing In DbContext.GetQuery(Of Database.Entities.VendorPricing)
                   Select VendorPricing

        End Function
        Public Function LoadByVendorCode(ByVal DbContext As Database.DbContext, ByVal VendorCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.VendorPricing)

            LoadByVendorCode = From VendorPricing In DbContext.GetQuery(Of Database.Entities.VendorPricing)
                               Where VendorPricing.VendorCode = VendorCode
                               Select VendorPricing

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorPricing As AdvantageFramework.Database.Entities.VendorPricing) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try

                    VendorPricing.ID = (From Entity In DbContext.GetQuery(Of Database.Entities.VendorPricing)
                                        Select Entity.ID).Max + 1

                Catch ex As Exception
                    VendorPricing.ID = 1
                End Try

                DbContext.VendorPricings.Add(VendorPricing)

                ErrorText = VendorPricing.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorPricing As AdvantageFramework.Database.Entities.VendorPricing) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(VendorPricing)

                ErrorText = VendorPricing.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorPricing As AdvantageFramework.Database.Entities.VendorPricing) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(VendorPricing)

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
