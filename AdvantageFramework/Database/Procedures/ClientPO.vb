Namespace Database.Procedures.ClientPO

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

        Public Function LoadActive(ByVal DataContext As Database.DataContext) As IQueryable(Of Database.Entities.ClientPO)

            LoadActive = From ClientPO In DataContext.ClientPOs
                         Where ClientPO.IsInactive = 0
                         Select ClientPO

        End Function
        Public Function LoadByID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ID As Long) As AdvantageFramework.Database.Entities.ClientPO

            Try

                LoadByID = (From ClientPO In DataContext.ClientPOs
                            Where ClientPO.ID = ID
                            Select ClientPO).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.ClientPO)

            Load = From ClientPO In DataContext.ClientPOs
                   Select ClientPO

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ClientPO As AdvantageFramework.Database.Entities.ClientPO) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ClientPO.DataContext = DataContext

                ClientPO.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.ClientPOs.InsertOnSubmit(ClientPO)

                ErrorText = ClientPO.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ClientPO As AdvantageFramework.Database.Entities.ClientPO) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                ClientPO.DataContext = DataContext

                ClientPO.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = ClientPO.ValidateEntity(IsValid)

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

#End Region

    End Module

End Namespace
