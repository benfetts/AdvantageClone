Namespace Database.Procedures.ImportVendorStaging

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

        Public Function ImportVendorFromImportVendorStaging(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext, _
                                                            ByVal ImportVendorStagingID As Integer, ByVal CreatedByUserCode As String, ByVal IsUpdating As Boolean) As Boolean

            ImportVendorFromImportVendorStaging = DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_import_vendor_from_staging] {0}, {1}, {2}", ImportVendorStagingID, CreatedByUserCode, IIf(IsUpdating, 1, 0))

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportVendorStaging)

            Load = From ImportVendorStaging In DbContext.GetQuery(Of Database.Entities.ImportVendorStaging)
                   Select ImportVendorStaging

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportVendorStaging As AdvantageFramework.Database.Entities.ImportVendorStaging) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ImportVendorStagings.Add(ImportVendorStaging)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportVendorStaging As AdvantageFramework.Database.Entities.ImportVendorStaging) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ImportVendorStaging)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportVendorStaging As AdvantageFramework.Database.Entities.ImportVendorStaging) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ImportVendorStaging)

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
        Public Function DeleteByImportVendorStagingIDs(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportVendorStagingIDs() As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.IMP_VENDOR_STAGING WHERE IMPORT_ID IN (" & Join(ImportVendorStagingIDs.Select(Function(ID) CStr(ID)).ToArray, ", ") & ")")

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByImportVendorStagingIDs = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
