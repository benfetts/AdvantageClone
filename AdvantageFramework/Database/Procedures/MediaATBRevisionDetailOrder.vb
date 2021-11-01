Namespace Database.Procedures.MediaATBRevisionDetailOrder

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

        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.MediaATBRevisionDetailOrder)

            Load = From MediaATBRevisionDetailOrder In DataContext.MediaATBRevisionDetailOrders
                   Select MediaATBRevisionDetailOrder

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, _
                               ByVal DataContext As AdvantageFramework.Database.DataContext, _
                               ByVal MediaATBRevisionDetailOrder As AdvantageFramework.Database.Entities.MediaATBRevisionDetailOrder) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                MediaATBRevisionDetailOrder.DataContext = DataContext
                MediaATBRevisionDetailOrder.DbContext = DbContext

                MediaATBRevisionDetailOrder.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.MediaATBRevisionDetailOrders.InsertOnSubmit(MediaATBRevisionDetailOrder)

                ErrorText = MediaATBRevisionDetailOrder.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, _
                               ByVal DataContext As AdvantageFramework.Database.DataContext, _
                               ByVal MediaATBRevisionDetailOrder As AdvantageFramework.Database.Entities.MediaATBRevisionDetailOrder) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                MediaATBRevisionDetailOrder.DataContext = DataContext
                MediaATBRevisionDetailOrder.DbContext = DbContext

                MediaATBRevisionDetailOrder.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = MediaATBRevisionDetailOrder.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, _
                               ByVal DataContext As AdvantageFramework.Database.DataContext, _
                               ByVal MediaATBRevisionDetailOrder As AdvantageFramework.Database.Entities.MediaATBRevisionDetailOrder) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.MediaATBRevisionDetailOrders.DeleteOnSubmit(MediaATBRevisionDetailOrder)

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

