Namespace Database.Procedures.ImportTemplateDetail

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

        Public Function LoadByTemplateID(ByVal DbContext As Database.DbContext, ByVal TemplateID As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportTemplateDetail)

            LoadByTemplateID = From ImportTemplateDetail In DbContext.GetQuery(Of Database.Entities.ImportTemplateDetail)
                               Where ImportTemplateDetail.TemplateID = TemplateID
                               Select ImportTemplateDetail

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ImportTemplateDetail)

            Load = From ImportTemplateDetail In DbContext.GetQuery(Of Database.Entities.ImportTemplateDetail)
                   Select ImportTemplateDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportTemplateDetail As AdvantageFramework.Database.Entities.ImportTemplateDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ImportTemplateDetails.Add(ImportTemplateDetail)

                ErrorText = ImportTemplateDetail.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportTemplateDetail As AdvantageFramework.Database.Entities.ImportTemplateDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ImportTemplateDetail)

                ErrorText = ImportTemplateDetail.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportTemplateDetail As AdvantageFramework.Database.Entities.ImportTemplateDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ImportTemplateDetail)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportTemplateID As Short) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim ImportTemplateDetail As AdvantageFramework.Database.Entities.ImportTemplateDetail = Nothing

            Try

                If IsValid Then

                    For Each ImportTemplateDetail In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ImportTemplateDetail).Where(Function(ImpTempDtl) ImpTempDtl.TemplateID = ImportTemplateID)

                        DbContext.DeleteEntityObject(ImportTemplateDetail)

                    Next

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
