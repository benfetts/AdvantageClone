Namespace Database.Procedures.GridAdvantage

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

        Public Function LoadByGridAdvantageID(DataContext As AdvantageFramework.Database.DataContext, GridAdvantageID As Long) As Database.Entities.GridAdvantage

            Try

                LoadByGridAdvantageID = (From GridAdvantage In DataContext.GridAdvantages
                                         Where GridAdvantage.ID = GridAdvantageID
                                         Select GridAdvantage).SingleOrDefault

            Catch ex As Exception
                LoadByGridAdvantageID = Nothing
            End Try

        End Function
        Public Function LoadByGridTypeAndUserCode(DataContext As AdvantageFramework.Database.DataContext, GridType As AdvantageFramework.Database.Entities.GridAdvantageType, UserCode As String) As Database.Entities.GridAdvantage

            Try

                LoadByGridTypeAndUserCode = (From GridAdvantage In DataContext.GridAdvantages
                                             Where GridAdvantage.GridType = GridType AndAlso
                                                   GridAdvantage.UserCode = UserCode AndAlso
                                                   GridAdvantage.GridSubtype Is Nothing
                                             Select GridAdvantage).FirstOrDefault

            Catch ex As Exception
                LoadByGridTypeAndUserCode = Nothing
            End Try

        End Function
        Public Function LoadByGridTypeAndUserCodeAndGridSubtype(DataContext As AdvantageFramework.Database.DataContext, GridType As AdvantageFramework.Database.Entities.GridAdvantageType,
                                                                 UserCode As String, GridSubtype As Long) As Database.Entities.GridAdvantage

            Try

                LoadByGridTypeAndUserCodeAndGridSubtype = (From GridAdvantage In DataContext.GridAdvantages
                                                           Where GridAdvantage.GridType = GridType AndAlso
                                                                 GridAdvantage.UserCode = UserCode AndAlso
                                                                 GridAdvantage.GridSubtype = GridSubtype
                                                           Select GridAdvantage).FirstOrDefault

            Catch ex As Exception
                LoadByGridTypeAndUserCodeAndGridSubtype = Nothing
            End Try

        End Function
        Public Function Load(DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of Database.Entities.GridAdvantage)

            Load = From GridAdvantage In DataContext.GridAdvantages
                   Select GridAdvantage

        End Function
        Public Function Insert(DataContext As AdvantageFramework.Database.DataContext, GridAdvantage As AdvantageFramework.Database.Entities.GridAdvantage) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                GridAdvantage.DataContext = DataContext

                GridAdvantage.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.GridAdvantages.InsertOnSubmit(GridAdvantage)

                ErrorText = GridAdvantage.ValidateEntity(IsValid)

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
        Public Function Update(DataContext As AdvantageFramework.Database.DataContext, GridAdvantage As AdvantageFramework.Database.Entities.GridAdvantage) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                GridAdvantage.DataContext = DataContext

                GridAdvantage.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = GridAdvantage.ValidateEntity(IsValid)

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
        Public Function Delete(DataContext As AdvantageFramework.Database.DataContext, GridAdvantage As AdvantageFramework.Database.Entities.GridAdvantage) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    AdvantageFramework.Database.Procedures.GridAdvantageColumn.DeleteByGridID(DataContext, GridAdvantage.ID)

                    DataContext.GridAdvantages.DeleteOnSubmit(GridAdvantage)

                    DataContext.SubmitChanges()

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
        Public Function Delete(DataContext As AdvantageFramework.Database.DataContext, GridType As AdvantageFramework.Database.Entities.GridAdvantageType, UserCode As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim GridAdvantage As Database.Entities.GridAdvantage = Nothing

            Try

                If IsValid Then

                    GridAdvantage = LoadByGridTypeAndUserCode(DataContext, GridType, UserCode)

                    If GridAdvantage IsNot Nothing Then

                        AdvantageFramework.Database.Procedures.GridAdvantageColumn.DeleteByGridID(DataContext, GridAdvantage.ID)

                        DataContext.GridAdvantages.DeleteOnSubmit(GridAdvantage)

                        DataContext.SubmitChanges()

                    End If

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
        Public Function Delete(DataContext As AdvantageFramework.Database.DataContext, GridType As AdvantageFramework.Database.Entities.GridAdvantageType, UserCode As String,
                                GridSubtype As Long) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim GridAdvantage As AdvantageFramework.Database.Entities.GridAdvantage = Nothing

            Try

                If IsValid Then

                    GridAdvantage = LoadByGridTypeAndUserCodeAndGridSubtype(DataContext, GridType, UserCode, GridSubtype)

                    If GridAdvantage IsNot Nothing Then

                        AdvantageFramework.Database.Procedures.GridAdvantageColumn.DeleteByGridID(DataContext, GridAdvantage.ID)

                        DataContext.GridAdvantages.DeleteOnSubmit(GridAdvantage)

                    End If

                    DataContext.SubmitChanges()

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
