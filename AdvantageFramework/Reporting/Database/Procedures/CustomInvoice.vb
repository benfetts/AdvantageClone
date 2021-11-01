Namespace Reporting.Database.Procedures.CustomInvoice

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

        Public Function LoadByCustomInvoiceID(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal CustomInvoiceID As Integer) As Reporting.Database.Entities.CustomInvoice

            Try

                LoadByCustomInvoiceID = (From CustomInvoice In ReportingDbContext.GetQuery(Of Database.Entities.CustomInvoice)
                                         Where CustomInvoice.ID = CustomInvoiceID
                                         Select CustomInvoice).SingleOrDefault

            Catch ex As Exception
                LoadByCustomInvoiceID = Nothing
            End Try

        End Function
        Public Function LoadProductionCustomInvoices(ByVal ReportingDbContext As Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Entities.CustomInvoice)

            LoadProductionCustomInvoices = From CustomInvoice In ReportingDbContext.GetQuery(Of Database.Entities.CustomInvoice)
                                           Where CustomInvoice.Type <> 6
                                           Select CustomInvoice

        End Function
        Public Function LoadMediaCustomInvoices(ByVal ReportingDbContext As Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Entities.CustomInvoice)

            LoadMediaCustomInvoices = From CustomInvoice In ReportingDbContext.GetQuery(Of Database.Entities.CustomInvoice)
                                      Where CustomInvoice.Type = 6
                                      Select CustomInvoice

        End Function
        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Reporting.Database.Entities.CustomInvoice)

            Load = From CustomInvoice In ReportingDbContext.GetQuery(Of Database.Entities.CustomInvoice)
                   Select CustomInvoice

        End Function
        Public Function Insert(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext,
                               ByVal Type As Integer, ByVal Description As String, ByVal CreatedByUserCode As String,
                               ByVal CreatedDate As Date, ByVal ReportDefinition As String,
                               ByRef CustomInvoice As AdvantageFramework.Reporting.Database.Entities.CustomInvoice) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                CustomInvoice = New AdvantageFramework.Reporting.Database.Entities.CustomInvoice

                CustomInvoice.DbContext = ReportingDbContext
                CustomInvoice.Type = Type
                CustomInvoice.Description = Description
                CustomInvoice.CreatedByUserCode = CreatedByUserCode
                CustomInvoice.CreatedDate = CreatedDate
                CustomInvoice.UpdatedByUserCode = CreatedByUserCode
                CustomInvoice.UpdatedDate = CreatedDate
                CustomInvoice.ReportDefinition = ReportDefinition

                Inserted = Insert(ReportingDbContext, CustomInvoice)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal CustomInvoice As AdvantageFramework.Reporting.Database.Entities.CustomInvoice) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ReportingDbContext.CustomInvoices.Add(CustomInvoice)

                ErrorText = CustomInvoice.ValidateEntity(IsValid)

                If IsValid Then

                    ReportingDbContext.SaveChanges()

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
        Public Function Update(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal CustomInvoice As AdvantageFramework.Reporting.Database.Entities.CustomInvoice) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ReportingDbContext.UpdateObject(CustomInvoice)

                ErrorText = CustomInvoice.ValidateEntity(IsValid)

                If IsValid Then

                    ReportingDbContext.SaveChanges()

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
        Public Function Delete(ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext, ByVal CustomInvoice As AdvantageFramework.Reporting.Database.Entities.CustomInvoice) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    ReportingDbContext.DeleteEntityObject(CustomInvoice)

                    ReportingDbContext.SaveChanges()

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
