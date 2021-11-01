Namespace Database.Procedures.RateCardColorCharge

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.RateCardColorCharge)

            Load = From RateCardColorCharge In DbContext.GetQuery(Of Database.Entities.RateCardColorCharge)
                   Select RateCardColorCharge

        End Function
        Public Function LoadByRateCardID(ByVal DbContext As Database.DbContext, ByVal RateCardID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.RateCardColorCharge)

            LoadByRateCardID = From RateCardColorCharge In DbContext.GetQuery(Of Database.Entities.RateCardColorCharge)
                               Where RateCardColorCharge.RateCardID = RateCardID
                               Select RateCardColorCharge

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RateCardColorCharge As AdvantageFramework.Database.Entities.RateCardColorCharge) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.RateCardColorCharges.Add(RateCardColorCharge)

                ErrorText = RateCardColorCharge.ValidateEntity(IsValid)

                If IsValid Then

                    If RateCardColorCharge.ID = 0 Then

                        Try

                            RateCardColorCharge.ID = (From Entity In AdvantageFramework.Database.Procedures.RateCardColorCharge.Load(DbContext) _
                                                 Where Entity.RateCardID = RateCardColorCharge.RateCardID
                                                 Select Entity.ID).Max + 1

                        Catch ex As Exception
                            RateCardColorCharge.ID = 1
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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RateCardColorCharge As AdvantageFramework.Database.Entities.RateCardColorCharge) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(RateCardColorCharge)

                ErrorText = RateCardColorCharge.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RateCardColorCharge As AdvantageFramework.Database.Entities.RateCardColorCharge) As Boolean

            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(RateCardColorCharge)

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
