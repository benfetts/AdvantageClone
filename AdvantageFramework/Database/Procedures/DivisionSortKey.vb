Namespace Database.Procedures.DivisionSortKey

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

        Public Function LoadByClientAndDivisionCodeAndSortKey(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal SortKey As String) As AdvantageFramework.Database.Entities.DivisionSortKey

            Try

                LoadByClientAndDivisionCodeAndSortKey = (From DivisionSortKey In DbContext.GetQuery(Of Database.Entities.DivisionSortKey)
                                                         Where DivisionSortKey.ClientCode = ClientCode AndAlso
                                                               DivisionSortKey.DivisionCode = DivisionCode AndAlso
                                                               DivisionSortKey.SortKey = SortKey
                                                         Select DivisionSortKey).SingleOrDefault

            Catch ex As Exception
                LoadByClientAndDivisionCodeAndSortKey = Nothing
            End Try

        End Function
        Public Function LoadByClientAndDivisionCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.DivisionSortKey)

            LoadByClientAndDivisionCode = From DivisionSortKey In DbContext.GetQuery(Of Database.Entities.DivisionSortKey)
                                          Where DivisionSortKey.ClientCode = ClientCode AndAlso
                                                DivisionSortKey.DivisionCode = DivisionCode
                                          Select DivisionSortKey

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.DivisionSortKey)

            Load = From DivisionSortKey In DbContext.GetQuery(Of Database.Entities.DivisionSortKey)
                   Select DivisionSortKey

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal ClientCode As String, ByVal DivisionCode As String, ByVal SortKey As String, _
                               ByRef DivisionSortKey As AdvantageFramework.Database.Entities.DivisionSortKey) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                DivisionSortKey = New AdvantageFramework.Database.Entities.DivisionSortKey

                DivisionSortKey.DbContext = DbContext
                DivisionSortKey.ClientCode = ClientCode
                DivisionSortKey.DivisionCode = DivisionCode
                DivisionSortKey.SortKey = SortKey

                Inserted = Insert(DbContext, DivisionSortKey)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DivisionSortKey As AdvantageFramework.Database.Entities.DivisionSortKey) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.DivisionSortKeys.Add(DivisionSortKey)

                ErrorText = DivisionSortKey.ValidateEntity(IsValid)

                If IsValid Then

                    If DbContext.DivisionSortKeys.Any(Function(DivSrtKey) DivSrtKey.DivisionCode = DivisionSortKey.DivisionCode AndAlso _
                                                                              DivSrtKey.ClientCode = DivisionSortKey.ClientCode AndAlso _
                                                                              DivSrtKey.SortKey = DivisionSortKey.SortKey) = False Then

                        DbContext.SaveChanges()

                        Inserted = True

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("Please enter a unique division sort key.")

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DivisionSortKey As AdvantageFramework.Database.Entities.DivisionSortKey) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(DivisionSortKey)

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
