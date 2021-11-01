Namespace Database.Procedures.AdSize

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

        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AdSize)

            LoadAllActive = From AdSize In DbContext.GetQuery(Of Database.Entities.AdSize)
                            Where AdSize.IsInactive = 0 OrElse
                                  AdSize.IsInactive Is Nothing
                            Select AdSize

        End Function
        Public Function LoadByMediaType(ByVal DbContext As Database.DbContext, ByVal MediaType As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AdSize)

            LoadByMediaType = From AdSize In DbContext.GetQuery(Of Database.Entities.AdSize)
                              Where AdSize.MediaType = MediaType
                              Select AdSize

        End Function
        Public Function LoadByCodeAndMediaType(ByVal DbContext As Database.DbContext, ByVal AdSizeCode As String, ByVal MediaType As String) As Database.Entities.AdSize

            Try

                LoadByCodeAndMediaType = (From AdSize In DbContext.GetQuery(Of Database.Entities.AdSize)
                                          Where AdSize.Code = AdSizeCode AndAlso
                                                AdSize.MediaType = MediaType
                                          Select AdSize).SingleOrDefault

            Catch ex As Exception
                LoadByCodeAndMediaType = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AdSize)

            Load = From AdSize In DbContext.GetQuery(Of Database.Entities.AdSize)
                   Select AdSize

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AdSize As AdvantageFramework.Database.Entities.AdSize) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AdSizes.Add(AdSize)

                ErrorText = AdSize.ValidateEntity(IsValid)

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
        Public Function Insert(DbContext As AdvantageFramework.Database.DbContext, AdSize As AdvantageFramework.Database.Entities.AdSize,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                ErrorText = AdSize.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.AdSizes.Add(AdSize)

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception
                Inserted = False
                ErrorText = ex.Message
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AdSize As AdvantageFramework.Database.Entities.AdSize) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AdSize)

                ErrorText = AdSize.ValidateEntity(IsValid)

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
        Public Function Update(DbContext As AdvantageFramework.Database.DbContext, AdSize As AdvantageFramework.Database.Entities.AdSize, ByRef ErrorText As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.UpdateObject(AdSize)

                ErrorText = AdSize.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                End If

            Catch ex As Exception
                Updated = False
                ErrorText = ex.Message
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AdSize As AdvantageFramework.Database.Entities.AdSize) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try


                If (From Entity In DbContext.GetQuery(Of Database.Entities.Vendor)
                    Where Entity.DefaultAdSize.ToUpper = AdSize.Code.ToUpper
                    Select Entity).Any Then

                    IsValid = False

                End If

                If (From Entity In DbContext.GetQuery(Of Database.Entities.MediaSpecsHeader)
                    Where Entity.AdSize.ToUpper = AdSize.Code.ToUpper
                    Select Entity).Any Then

                    IsValid = False

                End If

                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM OUTDOOR_DETAIL WHERE SIZE = '{0}'", AdSize.Code)).FirstOrDefault > 0 Then

                    IsValid = False

                End If

                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM PRINT_EST_DTL WHERE SIZE = '{0}'", AdSize.Code)).FirstOrDefault > 0 Then

                    IsValid = False

                End If

                If IsValid = False Then

                    ErrorText = "This ad size is in use and cannot be deleted."

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(AdSize)

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