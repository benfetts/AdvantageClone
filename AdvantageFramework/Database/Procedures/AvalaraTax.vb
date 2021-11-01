Namespace Database.Procedures.AvalaraTax

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

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.AvalaraTax)

            Load = From AvalaraTax In DataContext.AvalaraTaxes
                   Select AvalaraTax

        End Function
        Public Function LoadAllActive(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.AvalaraTax)

            LoadAllActive = From AvalaraTax In DataContext.AvalaraTaxes
                            Where AvalaraTax.IsInactive = False
                            Select AvalaraTax

        End Function
        Public Function LoadByCode(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Code As String) As AdvantageFramework.Database.Entities.AvalaraTax

            Try

                LoadByCode = (From AvalaraTax In DataContext.AvalaraTaxes _
                              Where AvalaraTax.Code = Code _
                              Select AvalaraTax).SingleOrDefault

            Catch ex As Exception
                LoadByCode = Nothing
            End Try

        End Function
        Public Function LoadByID(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.AvalaraTax

            Try

                LoadByID = (From AvalaraTax In DataContext.AvalaraTaxes _
                            Where AvalaraTax.ID = ID _
                            Select AvalaraTax).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AvalaraTax As AdvantageFramework.Database.Entities.AvalaraTax) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                AvalaraTax.DataContext = DataContext

                AvalaraTax.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.AvalaraTaxes.InsertOnSubmit(AvalaraTax)

                ErrorText = AvalaraTax.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AvalaraTax As AdvantageFramework.Database.Entities.AvalaraTax) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                AvalaraTax.DataContext = DataContext

                AvalaraTax.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = AvalaraTax.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AvalaraTax As AdvantageFramework.Database.Entities.AvalaraTax) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.AvalaraTaxes.DeleteOnSubmit(AvalaraTax)

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