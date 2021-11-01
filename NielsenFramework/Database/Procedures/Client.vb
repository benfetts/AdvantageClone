Namespace Database.Procedures.Client

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

        Public Function LoadByID(DbContext As Database.NielsenDbContext, ID As Integer) As Database.Entities.Client

            LoadByID = (From Client In DbContext.GetQuery(Of Database.Entities.Client)
                        Where Client.ID = ID
                        Select Client).SingleOrDefault

        End Function
        Public Function Load(DbContext As Database.NielsenDbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Client)

            Load = From Client In DbContext.GetQuery(Of Database.Entities.Client)
                   Select Client

        End Function
        Public Function Insert(DbContext As Database.NielsenDbContext, Client As Database.Entities.Client, ByRef ErrorText As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.Clients.Add(Client)

                ErrorText = Client.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception
                Inserted = False
                ErrorText = ex.Message
            Finally
                Insert = Inserted
            End Try

        End Function
        'Public Function Update(ByVal DbContext As Database.NielsenDbContext, ByVal Client As Database.Entities.Client) As Boolean

        '    'objects
        '    Dim Updated As Boolean = False
        '    Dim IsValid As Boolean = True
        '    Dim ErrorText As String = ""

        '    Try

        '        DbContext.UpdateObject(Client)

        '        ErrorText = Client.ValidateEntity(IsValid)

        '        If IsValid Then

        '            DbContext.SaveChanges()

        '            Updated = True

        '        Else

        '            AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

        '        End If

        '    Catch ex As Exception
        '        Updated = False
        '    Finally
        '        Update = Updated
        '    End Try

        'End Function
        Public Function DeleteByID(DbContext As Database.NielsenDbContext, ID As Integer, ByRef ErrorText As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim Client As Database.Entities.Client = Nothing

            Try

                If IsValid Then

                    Client = DbContext.Clients.Find(ID)

                    If Client IsNot Nothing Then

                        DbContext.Entry(Client).State = Entity.EntityState.Deleted

                        DbContext.SaveChanges()

                        Deleted = True

                    End If

                End If

            Catch ex As Exception
                Deleted = False
                ErrorText = ex.Message
            Finally
                DeleteByID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
