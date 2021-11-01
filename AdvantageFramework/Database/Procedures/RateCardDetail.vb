Namespace Database.Procedures.RateCardDetail

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.RateCardDetail)

            Load = From RateCardDetail In DbContext.GetQuery(Of Database.Entities.RateCardDetail)
                   Select RateCardDetail

        End Function
        Public Function LoadByRateCardID(ByVal DbContext As Database.DbContext, ByVal RateCardID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.RateCardDetail)

            LoadByRateCardID = From RateCardDetail In DbContext.GetQuery(Of Database.Entities.RateCardDetail)
                               Where RateCardDetail.RateCardID = RateCardID
                               Select RateCardDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RateCardDetail As AdvantageFramework.Database.Entities.RateCardDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.RateCardDetails.Add(RateCardDetail)

                ErrorText = RateCardDetail.ValidateEntity(IsValid)

                If IsValid Then

                    If RateCardDetail.ID = 0 Then

                        Try

                            RateCardDetail.ID = (From Entity In AdvantageFramework.Database.Procedures.RateCardDetail.Load(DbContext) _
                                                 Where Entity.RateCardID = RateCardDetail.RateCardID
                                                 Select Entity.ID).Max + 1

                        Catch ex As Exception
                            RateCardDetail.ID = 1
                        End Try

                    End If

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RateCardDetail As AdvantageFramework.Database.Entities.RateCardDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(RateCardDetail)

                ErrorText = RateCardDetail.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RateCardDetail As AdvantageFramework.Database.Entities.RateCardDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(RateCardDetail)

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
