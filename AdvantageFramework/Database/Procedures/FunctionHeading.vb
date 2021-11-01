Namespace Database.Procedures.FunctionHeading

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

        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.FunctionHeading)

            LoadAllActive = From FunctionHeading In DbContext.GetQuery(Of Database.Entities.FunctionHeading)
                            Where FunctionHeading.IsInactive Is Nothing OrElse
                                  FunctionHeading.IsInactive = 0
                            Select FunctionHeading

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.FunctionHeading)

            Load = From FunctionHeading In DbContext.GetQuery(Of Database.Entities.FunctionHeading)
                   Select FunctionHeading

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FunctionHeading As AdvantageFramework.Database.Entities.FunctionHeading) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim FunctionID As Integer = Nothing

            Try

                Try

                    FunctionID = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.FunctionHeading).ToList
                                  Select Entity.ID).Max + 1

                Catch ex As Exception
                    FunctionID = 1
                End Try

                FunctionHeading.ID = FunctionID

                DbContext.FunctionHeadings.Add(FunctionHeading)

                ErrorText = FunctionHeading.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FunctionHeading As AdvantageFramework.Database.Entities.FunctionHeading) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(FunctionHeading)

                ErrorText = FunctionHeading.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal FunctionHeading As AdvantageFramework.Database.Entities.FunctionHeading) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                Try

                    If (From Entity In DbContext.GetQuery(Of Database.Entities.Function)
                        Where Entity.FunctionHeadingID IsNot Nothing AndAlso
                                 Entity.FunctionHeadingID = FunctionHeading.ID
                        Select Entity).Any Then

                        IsValid = False

                        ErrorText = "Code is in use and cannot be deleted."

                    End If

                Catch ex As Exception
                    ErrorText = "Failed deleting function heading."
                    IsValid = False
                End Try

                If IsValid Then

                    DbContext.DeleteEntityObject(FunctionHeading)

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
