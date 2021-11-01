Namespace Database.Procedures.Daypart

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

        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Daypart)

            LoadAllActive = From Daypart In DbContext.GetQuery(Of Database.Entities.Daypart)
                            Where Daypart.IsInactive = False
                            Select Daypart

        End Function
        Public Function LoadByDaypartCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Code As String) As AdvantageFramework.Database.Entities.Daypart

            Try

                LoadByDaypartCode = (From Daypart In DbContext.GetQuery(Of Database.Entities.Daypart)
                                     Where Daypart.Code = Code
                                     Select Daypart).SingleOrDefault

            Catch ex As Exception
                LoadByDaypartCode = Nothing
            End Try

        End Function
        Public Function LoadByDaypartID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DaypartID As Integer) As AdvantageFramework.Database.Entities.Daypart

            Try

                LoadByDaypartID = (From Daypart In DbContext.GetQuery(Of Database.Entities.Daypart)
                                   Where Daypart.ID = DaypartID
                                   Select Daypart).SingleOrDefault

            Catch ex As Exception
                LoadByDaypartID = Nothing
            End Try

        End Function
        Public Function LoadActiveByDaypartTypeID(ByVal DbContext As Database.DbContext, ByVal DaypartTypeID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Daypart)

            LoadActiveByDaypartTypeID = From Daypart In LoadAllActive(DbContext)
                                        Where Daypart.DaypartTypeID = DaypartTypeID
                                        Select Daypart

        End Function
        Public Function LoadByDaypartTypeID(ByVal DbContext As Database.DbContext, ByVal DaypartTypeID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Daypart)

            LoadByDaypartTypeID = From Daypart In DbContext.GetQuery(Of Database.Entities.Daypart)
                                  Where Daypart.DaypartTypeID = DaypartTypeID
                                  Select Daypart

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Daypart)

            Load = From Daypart In DbContext.GetQuery(Of Database.Entities.Daypart)
                   Select Daypart

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Daypart As AdvantageFramework.Database.Entities.Daypart) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Dayparts.Add(Daypart)

                ErrorText = Daypart.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Daypart As AdvantageFramework.Database.Entities.Daypart) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Daypart)

                ErrorText = Daypart.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Daypart As AdvantageFramework.Database.Entities.Daypart) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If DbContext.MediaPlanDetailLevelLineTags.Any(Function(MPDLLT) MPDLLT.DaypartID = Daypart.ID) Then

                    ErrorText = "The daypart is in use and cannot be deleted."
                    IsValid = False

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(Daypart)

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
