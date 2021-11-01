Namespace Database.Procedures.VendorServiceTax

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

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.VendorServiceTax)

            Load = From VendorServiceTax In DataContext.VendorServiceTaxes
                   Select VendorServiceTax

        End Function
        Public Function LoadAllActive(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.VendorServiceTax)

            LoadAllActive = From VendorServiceTax In DataContext.VendorServiceTaxes
                            Where VendorServiceTax.IsInactive = False
                            Select VendorServiceTax

        End Function
        Public Function LoadByVendorServiceTaxID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal VendorServiceTaxID As Long) As AdvantageFramework.Database.Entities.VendorServiceTax

            Try
                LoadByVendorServiceTaxID = (From VendorServiceTax In DataContext.VendorServiceTaxes _
                                            Where VendorServiceTax.ID = VendorServiceTaxID _
                                            Select VendorServiceTax).SingleOrDefault

            Catch ex As Exception
                LoadByVendorServiceTaxID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal VendorServiceTax As AdvantageFramework.Database.Entities.VendorServiceTax) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                VendorServiceTax.DataContext = DataContext

                VendorServiceTax.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.VendorServiceTaxes.InsertOnSubmit(VendorServiceTax)

                ErrorText = VendorServiceTax.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal VendorServiceTax As AdvantageFramework.Database.Entities.VendorServiceTax) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                VendorServiceTax.DataContext = DataContext

                VendorServiceTax.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = VendorServiceTax.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal VendorServiceTax As AdvantageFramework.Database.Entities.VendorServiceTax) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.VendorServiceTaxes.DeleteOnSubmit(VendorServiceTax)

                    DataContext.SubmitChanges()

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