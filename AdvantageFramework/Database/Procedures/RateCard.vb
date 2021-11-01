Namespace Database.Procedures.RateCard

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.RateCard)

            Load = From RateCard In DbContext.GetQuery(Of Database.Entities.RateCard)
                   Select RateCard

        End Function
        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.RateCard

            LoadByID = (From RateCard In DbContext.GetQuery(Of Database.Entities.RateCard)
                        Where RateCard.ID = ID
                        Select RateCard).SingleOrDefault

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RateCard As AdvantageFramework.Database.Entities.RateCard) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.RateCards.Add(RateCard)

                ErrorText = RateCard.ValidateEntity(IsValid)

                If IsValid Then

                    If RateCard.Type Is Nothing OrElse RateCard.Type = "" Then

                        RateCard.Type = "N"

                    End If

                    If RateCard.ID = 0 Then

                        Try

                            RateCard.ID = (From Entity In AdvantageFramework.Database.Procedures.RateCard.Load(DbContext) _
                                                 Select Entity.ID).Max + 1

                        Catch ex As Exception
                            RateCard.ID = 1
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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RateCard As AdvantageFramework.Database.Entities.RateCard) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(RateCard)

                ErrorText = RateCard.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RateCard As AdvantageFramework.Database.Entities.RateCard) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try


                If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.NEWSPAPER_DETAIL WHERE RATE_CARD_ID = " & RateCard.ID).FirstOrDefault > 0 Then

                    ErrorText = "This Rate Card is in use and cannot be deleted."
                    IsValid = False

                ElseIf DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.PRINT_EST_DTL WHERE RATE_CARD_ID = " & RateCard.ID).FirstOrDefault > 0 Then

                    ErrorText = "This Rate Card is in use and cannot be deleted."
                    IsValid = False

                ElseIf DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.MAGAZINE_DETAIL WHERE RATE_CARD_ID = " & RateCard.ID).FirstOrDefault > 0 Then

                    ErrorText = "This Rate Card is in use and cannot be deleted."
                    IsValid = False

                End If

                If IsValid Then

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.RATE_CARD_DTL WHERE RATE_CARD_ID = {0}", RateCard.ID))

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.RATE_CARD_COLORCHG WHERE RATE_CARD_ID = {0}", RateCard.ID))

                    Catch ex As Exception
                        IsValid = False
                    End Try

                    DbContext.DeleteEntityObject(RateCard)

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
