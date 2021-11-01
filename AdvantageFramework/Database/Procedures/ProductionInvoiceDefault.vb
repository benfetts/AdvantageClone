Namespace Database.Procedures.ProductionInvoiceDefault

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ProductionInvoiceDefault)

            Load = From ProductionInvoiceDefault In DbContext.GetQuery(Of Database.Entities.ProductionInvoiceDefault)
                   Select ProductionInvoiceDefault

        End Function
        Public Function LoadByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As Database.Entities.ProductionInvoiceDefault

            Try

                LoadByClientCode = (From ProductionInvoiceDefault In DbContext.GetQuery(Of Database.Entities.ProductionInvoiceDefault)
                                    Where ProductionInvoiceDefault.ClientOrDefault = 2 AndAlso
                                          ProductionInvoiceDefault.ClientCode = ClientCode
                                    Select ProductionInvoiceDefault).SingleOrDefault

            Catch ex As Exception
                LoadByClientCode = Nothing
            End Try

        End Function
        Public Function LoadOneTimeSettings(ByVal DbContext As Database.DbContext) As Database.Entities.ProductionInvoiceDefault

            Try

                LoadOneTimeSettings = (From ProductionInvoiceDefault In DbContext.GetQuery(Of Database.Entities.ProductionInvoiceDefault)
                                       Where ProductionInvoiceDefault.ClientOrDefault = 0
                                       Select ProductionInvoiceDefault).SingleOrDefault

            Catch ex As Exception
                LoadOneTimeSettings = Nothing
            End Try

        End Function
        Public Function LoadAgencyDefault(ByVal DbContext As Database.DbContext) As Database.Entities.ProductionInvoiceDefault

            Try

                LoadAgencyDefault = (From ProductionInvoiceDefault In DbContext.GetQuery(Of Database.Entities.ProductionInvoiceDefault)
                                     Where ProductionInvoiceDefault.ClientOrDefault = 1
                                     Select ProductionInvoiceDefault).SingleOrDefault

            Catch ex As Exception
                LoadAgencyDefault = Nothing
            End Try

        End Function
        Public Function ResetToDefaults(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault) As Boolean

            'objects
            Dim Reseted As Boolean = False

            Reseted = ResetToDefaults(DbContext, ProductionInvoiceDefault.ID)

            ResetToDefaults = Reseted

        End Function
        Public Function ResetToDefaults(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ProductionInvoiceDefaultID As Integer) As Boolean

            'objects
            Dim Reseted As Boolean = False

            Try

                Reseted = (DbContext.Database.ExecuteSqlCommand(String.Format("[dbo].[advsp_production_invoice_format_reset_defaults] {0}", ProductionInvoiceDefaultID)) > 0)

            Catch ex As Exception
                Reseted = False
            End Try

            ResetToDefaults = Reseted

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ProductionInvoiceDefaults.Add(ProductionInvoiceDefault)

                ErrorText = ProductionInvoiceDefault.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ProductionInvoiceDefault)

                ErrorText = ProductionInvoiceDefault.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ProductionInvoiceDefault)

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