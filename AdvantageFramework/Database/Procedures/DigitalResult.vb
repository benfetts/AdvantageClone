Namespace Database.Procedures.DigitalResult

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

        Public Function LoadByDateRange(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DateFrom As Date, ByVal EndDate As Date) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.DigitalResult)

            'objects
            Dim ModifiedEndDate As Date = Nothing

            ModifiedEndDate = EndDate.Date.AddDays(1).AddSeconds(-1)

            LoadByDateRange = From DigitalResult In DbContext.GetQuery(Of Database.Entities.DigitalResult)
                              Where DigitalResult.ResultDate >= DateFrom AndAlso
                                    DigitalResult.ResultDate <= ModifiedEndDate
                              Select DigitalResult

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.DigitalResult)

            Load = From DigitalResult In DbContext.GetQuery(Of Database.Entities.DigitalResult)
                   Select DigitalResult

        End Function
        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.DigitalResult

            Try

                LoadByID = (From DigitalResult In DbContext.GetQuery(Of Database.Entities.DigitalResult)
                            Where DigitalResult.ID = ID
                            Select DigitalResult).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DigitalResult As AdvantageFramework.Database.Entities.DigitalResult) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.DigitalResults.Add(DigitalResult)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DigitalResult As AdvantageFramework.Database.Entities.DigitalResult) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(DigitalResult)

                ErrorText = DigitalResult.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DigitalResult As AdvantageFramework.Database.Entities.DigitalResult) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(DigitalResult)

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