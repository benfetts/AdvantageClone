Namespace Database.Procedures.PrintOrder

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

        Public Function LoadByAccountOrderNumberAndMediaTypeAndMediaInterface(ByVal DataContext As Database.DataContext, ByVal AccountOrderNumber As Long, _
                                                                              ByVal MediaType As String, ByVal MediaInterface As String) As Database.Entities.PrintOrder

            Try

                LoadByAccountOrderNumberAndMediaTypeAndMediaInterface = (From PrintOrder In DataContext.PrintOrders _
                                                                         Where PrintOrder.AccountOrderNumber = AccountOrderNumber AndAlso _
                                                                               PrintOrder.MediaType = MediaType AndAlso _
                                                                               PrintOrder.MediaInterface = MediaInterface
                                                                         Select PrintOrder).FirstOrDefault

            Catch ex As Exception
                LoadByAccountOrderNumberAndMediaTypeAndMediaInterface = Nothing
            End Try

        End Function
        Public Function Load(ByVal DataContext As AdvantageFramework.Database.DataContext) As IQueryable(Of AdvantageFramework.Database.Entities.PrintOrder)

            Load = From PrintOrder In DataContext.PrintOrders
                   Select PrintOrder

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, _
                               ByVal DataContext As AdvantageFramework.Database.DataContext, _
                               ByVal PrintOrder As AdvantageFramework.Database.Entities.PrintOrder) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                PrintOrder.DataContext = DataContext
                PrintOrder.DbContext = DbContext

                Try

                    PrintOrder.ID = (From Entity In Load(DataContext) _
                                     Select Entity.ID).Max + 1

                Catch ex As Exception
                    PrintOrder.ID = 1
                End Try

                PrintOrder.DatabaseAction = AdvantageFramework.Database.Action.Inserting

                DataContext.PrintOrders.InsertOnSubmit(PrintOrder)

                ErrorText = PrintOrder.ValidateEntity(IsValid)

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
                               ByVal PrintOrder As AdvantageFramework.Database.Entities.PrintOrder) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                PrintOrder.DataContext = DataContext
                PrintOrder.DbContext = DbContext

                PrintOrder.DatabaseAction = AdvantageFramework.Database.Action.Updating

                ErrorText = PrintOrder.ValidateEntity(IsValid)

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
                               ByVal PrintOrder As AdvantageFramework.Database.Entities.PrintOrder) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DataContext.PrintOrders.DeleteOnSubmit(PrintOrder)

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

