Namespace Database.Procedures.ClientType1

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientType1)

            Load = From ClientType1 In DbContext.GetQuery(Of Database.Entities.ClientType1)
                   Select ClientType1

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientType1)

            LoadAllActive = From ClientType1 In DbContext.GetQuery(Of Database.Entities.ClientType1)
                            Where ClientType1.IsInactive = False
                            Select ClientType1

        End Function
        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientType1)

            LoadByID = From ClientType1 In DbContext.GetQuery(Of Database.Entities.ClientType1)
                       Where ClientType1.ID = ID
                       Select ClientType1

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientType1 As AdvantageFramework.Database.Entities.ClientType1) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ClientType1s.Add(ClientType1)

                ErrorText = ClientType1.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientType1 As AdvantageFramework.Database.Entities.ClientType1) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ClientType1)

                ErrorText = ClientType1.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientType1 As AdvantageFramework.Database.Entities.ClientType1) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If AdvantageFramework.Database.Procedures.CompanyProfile.Load(DbContext).Where(Function(Entity) Entity.ClientType1ID = ClientType1.ID).Any Then

                    IsValid = False
                    ErrorText = "This code is in use cannot be deleted."

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(ClientType1)

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
