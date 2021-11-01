Namespace Database.Procedures.ImportAccountPayable

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

        Public Function LoadByBatchName(ByVal DbContext As Database.DbContext, ByVal BatchName As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportAccountPayable)

            LoadByBatchName = From ImportAccountPayable In DbContext.GetQuery(Of Database.Entities.ImportAccountPayable)
                              Where ImportAccountPayable.BatchName = BatchName
                              Select ImportAccountPayable

        End Function
        Public Function LoadByBatchNameAndVendorCodeAndInvoiceNumber(ByVal DbContext As Database.DbContext, ByVal BatchName As String, ByVal VendorCode As String, ByVal InvoiceNumber As String) As Database.Entities.ImportAccountPayable

            Try

                LoadByBatchNameAndVendorCodeAndInvoiceNumber = (From ImportAccountPayable In DbContext.GetQuery(Of Database.Entities.ImportAccountPayable)
                                                                Where ImportAccountPayable.BatchName = BatchName AndAlso
                                                                      ImportAccountPayable.VendorCode = VendorCode AndAlso
                                                                      ImportAccountPayable.InvoiceNumber = InvoiceNumber
                                                                Select ImportAccountPayable).SingleOrDefault

            Catch ex As Exception
                LoadByBatchNameAndVendorCodeAndInvoiceNumber = Nothing
            End Try

        End Function
        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Database.Entities.ImportAccountPayable

            Try

                LoadByID = (From ImportAccountPayable In DbContext.GetQuery(Of Database.Entities.ImportAccountPayable)
                            Where ImportAccountPayable.ID = ID
                            Select ImportAccountPayable).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportAccountPayable)

            Load = From ImportAccountPayable In DbContext.GetQuery(Of Database.Entities.ImportAccountPayable)
                   Select ImportAccountPayable

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportAccountPayable As AdvantageFramework.Database.Entities.ImportAccountPayable) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ImportAccountPayables.Add(ImportAccountPayable)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportAccountPayable As AdvantageFramework.Database.Entities.ImportAccountPayable) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ImportAccountPayable)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportAccountPayable As AdvantageFramework.Database.Entities.ImportAccountPayable) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.IMP_AP_ERROR WHERE IMPORT_ID = {0}", ImportAccountPayable.ID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.IMP_AP_GL WHERE IMPORT_ID = {0}", ImportAccountPayable.ID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.IMP_AP_JOB WHERE IMPORT_ID = {0}", ImportAccountPayable.ID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE 
	                                                                        DTL
                                                                        FROM
	                                                                        dbo.IMP_AP_BROADCAST_DTL DTL
                                                                        INNER JOIN
	                                                                        dbo.IMP_AP_MEDIA HDR ON DTL.IMP_AP_MEDIA_ID = HDR.ID
                                                                        WHERE
	                                                                        HDR.IMPORT_ID = {0}", ImportAccountPayable.ID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.IMP_AP_MEDIA WHERE IMPORT_ID = {0}", ImportAccountPayable.ID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.IMPORT_DOCUMENTS WHERE IMPORT_ID = {0} AND TEMPLATE_ID = {1}", ImportAccountPayable.ID, ImportAccountPayable.ImportTemplateID))

                Catch ex As Exception
                    IsValid = False
                End Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ImportAccountPayable)

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
        'Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BatchName As String) As Boolean

        '    'objects
        '    Dim Deleted As Boolean = False
        '    Dim IsValid As Boolean = True
        '    Dim ErrorText As String = ""

        '    Try

        '        If IsValid Then

        '            For Each Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ImportAccountPayable).Where(Function(ImpAP) ImpAP.BatchName = BatchName).ToList

        '                DbContext.DeleteEntityObject(Entity)

        '            Next

        '            DbContext.SaveChanges()

        '            Deleted = True

        '        Else

        '            AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

        '        End If

        '    Catch ex As Exception
        '        Deleted = False
        '    Finally
        '        Delete = Deleted
        '    End Try

        'End Function

#End Region

    End Module

End Namespace
