Namespace Database.Procedures.ClientSortKey

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

        Public Function LoadByClientCodeAndSortKey(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String, ByVal SortKey As String) As AdvantageFramework.Database.Entities.ClientSortKey

            Try

                LoadByClientCodeAndSortKey = (From ClientSortKey In DbContext.GetQuery(Of Database.Entities.ClientSortKey)
                                              Where ClientSortKey.ClientCode = ClientCode AndAlso
                                                    ClientSortKey.SortKey = SortKey
                                              Select ClientSortKey).SingleOrDefault

            Catch ex As Exception
                LoadByClientCodeAndSortKey = Nothing
            End Try

        End Function
        Public Function LoadByClientCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientSortKey)

            LoadByClientCode = From ClientSortKey In DbContext.GetQuery(Of Database.Entities.ClientSortKey)
                               Where ClientSortKey.ClientCode = ClientCode
                               Select ClientSortKey

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientSortKey)

            Load = From ClientSortKey In DbContext.GetQuery(Of Database.Entities.ClientSortKey)
                   Select ClientSortKey

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal ClientCode As String, ByVal SortKey As String, _
                               ByRef ClientSortKey As AdvantageFramework.Database.Entities.ClientSortKey) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                ClientSortKey = New AdvantageFramework.Database.Entities.ClientSortKey

                ClientSortKey.DbContext = DbContext
                ClientSortKey.ClientCode = ClientCode
                ClientSortKey.SortKey = SortKey

                Inserted = Insert(DbContext, ClientSortKey)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientSortKey As AdvantageFramework.Database.Entities.ClientSortKey) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ClientSortKeys.Add(ClientSortKey)

                ErrorText = ClientSortKey.ValidateEntity(IsValid)

                If IsValid Then

                    If DbContext.ClientSortKeys.Any(Function(ClSrtKey) ClSrtKey.ClientCode = ClientSortKey.ClientCode AndAlso _
                                                                           ClSrtKey.SortKey = ClientSortKey.SortKey) = False Then

                        DbContext.SaveChanges()

                        Inserted = True

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("Please enter a unique client sort key.")

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientSortKey As AdvantageFramework.Database.Entities.ClientSortKey) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ClientSortKey)

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
