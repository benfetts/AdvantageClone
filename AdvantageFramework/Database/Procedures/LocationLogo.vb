Namespace Database.Procedures.LocationLogo

    <HideModuleName()>
    Public Module LocationLogo

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadByLocationAndLocationLogoTypeID(DbContext As Database.DbContext, LocationID As String, LocationLogoTypeID As Integer) As AdvantageFramework.Database.Entities.LocationLogo

            Try

                LoadByLocationAndLocationLogoTypeID = (From Entity In DbContext.GetQuery(Of Database.Entities.LocationLogo)
                                                       Where Entity.LocationID = LocationID AndAlso
                                                             Entity.LocationLogoTypeID = LocationLogoTypeID).SingleOrDefault

            Catch ex As Exception
                LoadByLocationAndLocationLogoTypeID = Nothing
            End Try

        End Function
        Public Function LoadHeaderPortrait(ByVal DbContext As Database.DbContext, ByVal LocationID As String) As AdvantageFramework.Database.Entities.LocationLogo

            Dim LocationLogoTypeID As Integer = 0

            LocationLogoTypeID = CType(AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait, Integer)

            Try

                LoadHeaderPortrait = (From Entity In DbContext.GetQuery(Of Database.Entities.LocationLogo)
                                      Where Entity.LocationLogoTypeID = LocationLogoTypeID AndAlso
                                            Entity.LocationID = LocationID).SingleOrDefault

            Catch ex As Exception

                LoadHeaderPortrait = Nothing

            End Try

        End Function
        Public Function LoadHeaderLandscape(ByVal DbContext As Database.DbContext, ByVal LocationID As String) As AdvantageFramework.Database.Entities.LocationLogo

            Dim LocationLogoTypeID As Integer = 0

            LocationLogoTypeID = CType(AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderLandscape, Integer)

            Try

                LoadHeaderLandscape = (From Entity In DbContext.GetQuery(Of Database.Entities.LocationLogo)
                                       Where Entity.LocationLogoTypeID = LocationLogoTypeID AndAlso
                                             Entity.LocationID = LocationID).SingleOrDefault

            Catch ex As Exception

                LoadHeaderLandscape = Nothing

            End Try

        End Function
        Public Function LoadFooterPortrait(ByVal DbContext As Database.DbContext, ByVal LocationID As String) As AdvantageFramework.Database.Entities.LocationLogo

            Dim LocationLogoTypeID As Integer = 0

            LocationLogoTypeID = CType(AdvantageFramework.Database.Entities.LocationLogoTypes.FooterPortrait, Integer)

            Try

                LoadFooterPortrait = (From Entity In DbContext.GetQuery(Of Database.Entities.LocationLogo)
                                      Where Entity.LocationLogoTypeID = LocationLogoTypeID AndAlso
                                            Entity.LocationID = LocationID).SingleOrDefault

            Catch ex As Exception

                LoadFooterPortrait = Nothing

            End Try

        End Function
        Public Function LoadFooterLandscape(ByVal DbContext As Database.DbContext, ByVal LocationID As String) As AdvantageFramework.Database.Entities.LocationLogo

            Dim LocationLogoTypeID As Integer = 0

            LocationLogoTypeID = CType(AdvantageFramework.Database.Entities.LocationLogoTypes.FooterLandscape, Integer)

            Try

                LoadFooterLandscape = (From Entity In DbContext.GetQuery(Of Database.Entities.LocationLogo)
                                       Where Entity.LocationLogoTypeID = LocationLogoTypeID AndAlso
                                             Entity.LocationID = LocationID).SingleOrDefault

            Catch ex As Exception

                LoadFooterLandscape = Nothing

            End Try

        End Function
        Public Function LoadActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.LocationLogo)

            LoadActive = From LocationLogo In DbContext.GetQuery(Of Database.Entities.LocationLogo)
                         Where LocationLogo.IsActive = True
                         Select LocationLogo

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.LocationLogo)

            Load = From LocationLogo In DbContext.GetQuery(Of Database.Entities.LocationLogo)
                   Select LocationLogo

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal LocationLogo As AdvantageFramework.Database.Entities.LocationLogo) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.LocationLogos.Add(LocationLogo)

                ErrorText = LocationLogo.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal LocationLogo As AdvantageFramework.Database.Entities.LocationLogo) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(LocationLogo)

                ErrorText = LocationLogo.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal LocationLogo As AdvantageFramework.Database.Entities.LocationLogo) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(LocationLogo)

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
