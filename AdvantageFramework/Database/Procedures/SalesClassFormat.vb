Namespace Database.Procedures.SalesClassFormat

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

        Public Function LoadBySalesClassCode(ByVal DbContext As Database.DbContext, ByVal SalesClassCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.SalesClassFormat)

            Try

                LoadBySalesClassCode = From SalesClassFormat In DbContext.GetQuery(Of Database.Entities.SalesClassFormat)
                                       Where SalesClassFormat.SalesClassCode = SalesClassCode
                                       Select SalesClassFormat

            Catch ex As Exception
                LoadBySalesClassCode = Nothing
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SalesClassFormat As AdvantageFramework.Database.Entities.SalesClassFormat) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(SalesClassFormat)

                ErrorText = SalesClassFormat.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SalesClassFormat As AdvantageFramework.Database.Entities.SalesClassFormat) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If AdvantageFramework.Database.Procedures.Job.LoadBySalesClassAndFormatCode(DbContext, SalesClassFormat.SalesClassCode, SalesClassFormat.Code).Any Then

                    IsValid = False
                    ErrorText = "This code is in use and cannot be deleted."

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(SalesClassFormat)

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
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SalesClassFormat As AdvantageFramework.Database.Entities.SalesClassFormat) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.SalesClassFormats.Add(SalesClassFormat)

                ErrorText = SalesClassFormat.ValidateEntity(IsValid)

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
#End Region

    End Module

End Namespace
