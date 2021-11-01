Namespace Database.Procedures.ContentUser

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

        Public Function LoadByID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.ContentUser

            Try

                LoadByID = (From ContentUser In DataContext.ContentUsers _
                            Where ContentUser.ID = ID _
                            Select ContentUser).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ContentUser As AdvantageFramework.Database.Entities.ContentUser) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ContentUser.DataContext = DataContext

                ContentUser.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = ContentUser.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ContentUser As AdvantageFramework.Database.Entities.ContentUser) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ContentUser.DataContext = DataContext

                ContentUser.DatabaseAction = Action.Inserting

                DataContext.ContentUsers.InsertOnSubmit(ContentUser)

                ErrorText = ContentUser.ValidateEntity(IsValid)

                If IsValid Then

                    DataContext.SubmitChanges()

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